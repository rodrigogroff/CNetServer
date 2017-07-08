using System;
using System.Threading;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Collections;
using System.Data.Odbc;
using IWshRuntimeLibrary;
using Microsoft.Win32;
using SyCrafEngine;

namespace ServerSetup
{
	public partial class ctrl_installing : UserControl
	{
		public Translator 	var_trans;
		public InstallData  var_data;
		public ExchangeArea var_ex;
		
		public bool 	IsInstallDone 	= false;
		public bool 	IsDBFailure 	= false;
				
		public string 	newLine 		= "\r\n";
		
		public int 		numFiles 		= 0;

		public ctrl_installing()
		{
			InitializeComponent();
		}
		
		public void reset ()
		{
			lblEnd.Visible 		= false;
			lblActions.Visible 	= false;
			
			if ( var_data.slaveOnly == "True" )
			{
				lblDB.Visible 	   = false;
				pgDataBase.Visible = false;
			}
			
			lblCopy.Text  = var_trans.GetMsg ( "SI_ctrl_installing", "lblCopy" 	);
			lblDB.Text    = var_trans.GetMsg ( "SI_ctrl_installing", "lblDB" 	);
			
			copyDatatoPathDir(); 
			copyUninstallFiles();
			createUninstallShortcut();
			createStartMenu();
			
			var_data.db_schema = InfraSoftwareServer.db_schema;
			
			if ( var_data.slaveOnly == "False" )
			{
				if ( !new InstallDB().createDataBase (   var_trans,
														 pgDataBase,
									                     var_data.user, 
									                     var_data.password, 
									                     var_data.db_port, 
									                     var_data.db_machine,
									                     Convert.ToInt32 ( var_data.db_choice ),
									                     InfraSoftwareServer.db_schema ) )
				{
					MessageBox.Show ( var_trans.GetMsg ( "SI_ctrl_installing", "DBFailure" ), "SYSTEM" );
					IsDBFailure = true;
					
					ctrl_softRemove  rem = new ctrl_softRemove();
					
					rem.var_data  = var_data;
					rem.var_trans = var_trans;
					
					rem.rem_applicationFiles( var_data.pathDir );
					rem.rem_shortcut();
					rem.rem_StartMenu();
					
					var_data.rem_registration();
					
					return;
				}
				
				int choice = Convert.ToInt32 ( var_data.db_choice );
								
				Patch db_patch_tool = new Patch ( StrConnector.getConnString (		var_data.db_machine,
				                                                              		InfraSoftwareServer.db_schema,
				                                									var_data.user, 
									            									var_data.password, 
									           										var_data.db_port, 
									           										choice ) );
				
				
				if ( db_patch_tool.nu_total_patch > 0 )
				{
					lblDB.Text = var_trans.GetMsg ( "SI_ctrl_installing", "lblDB_Patch" 	);
					Application.DoEvents();
					
					Thread.Sleep ( 250 );
				
					if ( !db_patch_tool.execute ( pgDataBase ) )
					{
						MessageBox.Show ( var_trans.GetMsg ( "SI_ctrl_installing", "DBFailure" ), "SYSTEM" );
						IsDBFailure = true;
						
						ctrl_softRemove  rem = new ctrl_softRemove();
						
						rem.var_data = var_data;
						rem.var_trans = var_trans;
						
						rem.rem_applicationFiles( var_data.pathDir );
						rem.rem_shortcut();
						rem.rem_StartMenu();
						
						var_data.rem_registration();
						
						return;	
					}
					lblDB.Text = var_trans.GetMsg ( "SI_ctrl_installing", "lblDB_PatchDone" 	);
				}
			}
			
			// Number of files copied
			lblActions.Text = 	var_trans.GetMsg ( "SI_ctrl_installing", "lblOpt1" ).
								Replace ( "{$1}", Convert.ToString (numFiles) ) + 
								newLine;
			
			if ( var_ex.tg_desktopShortcut )
			{
				// Shortcut
				createShortcut();
				lblActions.Text += 	var_trans.GetMsg ( "SI_ctrl_installing", "lblOpt2" ) + 
									newLine;
			}
			
			// Registering
			var_data.ins_registration();
			
			lblActions.Text += 	var_trans.GetMsg ( "SI_ctrl_installing", "lblOpt3" ) +
								newLine;
			
			// Complete			
			lblEnd.Text	 		= var_trans.GetMsg ( "SI_ctrl_installing", "lblOpt4" );
			lblEnd.Visible 		= true;
			lblActions.Visible 	= true;
			
			IsInstallDone = true;
		}
				
		void createShortcut()
		{
			string shortcut = 	System.Environment.GetEnvironmentVariable ( "USERPROFILE" ) + 
							  	"\\Desktop\\" + 
								InfraSoftwareServer.nameServer + " Server.lnk";
				
			if ( System.IO.File.Exists ( shortcut ) ) 
				System.IO.File.Delete ( shortcut );
				
			WshShellClass 	WshShell   = new WshShellClass();
			IWshShortcut 	MyShortcut = (IWshShortcut) WshShell.CreateShortcut( shortcut );
			
			MyShortcut.TargetPath 		= var_data.pathDir + @"\" + InfraSoftwareServer.nameServer + ".exe";
			MyShortcut.IconLocation     = var_data.pathDir + @"\" + InfraSoftwareServer.nameServer + ".exe";
			MyShortcut.WorkingDirectory = var_data.pathDir;
			
			MyShortcut.Save();
		}
		
		void createUninstallShortcut()
		{
			string shortcut = var_data.pathDir + "\\uninstall.lnk";
				
			if ( System.IO.File.Exists ( shortcut ) ) 
				System.IO.File.Delete ( shortcut );
				
			WshShellClass 	WshShell   = new WshShellClass();
			IWshShortcut 	MyShortcut = (IWshShortcut) WshShell.CreateShortcut( shortcut );
			
			string path = 	System.Environment.GetEnvironmentVariable ( "COMMONPROGRAMFILES" ) + 
							"\\" + 
							InfraSoftwareServer.nameServer;
						
			MyShortcut.TargetPath 		= path + "\\ServerSetup.exe";
			MyShortcut.IconLocation     = path + "\\ServerSetup.exe";
			MyShortcut.WorkingDirectory = path;
					
			MyShortcut.Save();
		}
		
		void createStartMenu()
		{
			string StartMenu = var_data.getStartMenu() + "\\" + InfraSoftwareServer.nameServer + " Server";
      		
      		if ( !Directory.Exists ( StartMenu ) )
				Directory.CreateDirectory ( StartMenu );							
      		
      		// Program link
      		{
	      		string shortcut = StartMenu + "\\Server.lnk";
					
				if ( System.IO.File.Exists ( shortcut ) ) 
					System.IO.File.Delete ( shortcut );
					
				WshShellClass 	WshShell   = new WshShellClass();
				IWshShortcut 	MyShortcut = (IWshShortcut) WshShell.CreateShortcut( shortcut );
				
				MyShortcut.TargetPath 		= var_data.pathDir + @"\" + InfraSoftwareServer.nameServer + ".exe";
				MyShortcut.IconLocation     = var_data.pathDir + @"\" + InfraSoftwareServer.nameServer + ".exe";
				MyShortcut.WorkingDirectory = var_data.pathDir;
						
				MyShortcut.Save();
			}
      		
      		// Uninstall link
      		{
	      		string shortcut = StartMenu + "\\uninstall.lnk";
					
				if ( System.IO.File.Exists ( shortcut ) ) 
					System.IO.File.Delete ( shortcut );
					
				WshShellClass 	WshShell   = new WshShellClass();
				IWshShortcut 	MyShortcut = (IWshShortcut) WshShell.CreateShortcut( shortcut );
				
				string path = 	System.Environment.GetEnvironmentVariable ( "COMMONPROGRAMFILES" ) + 
								"\\" + 
								InfraSoftwareServer.nameServer;
							
				MyShortcut.TargetPath 		= path + "\\ServerSetup.exe";
				MyShortcut.WorkingDirectory = path;
				MyShortcut.IconLocation     = path + "\\ServerSetup.exe";
						
				MyShortcut.Save();
			}
		}
				
		void copyDatatoPathDir()
		{
			lblCurrentFile.Text = "";
			
			string [] 	my_files = Directory.GetFiles ( "data" );
			
			numFiles = 0;
			for ( int t=0; t < my_files.GetLength (0); ++t)
			{
				string archive = my_files[t];
				
				if ( !archive.Contains ( "sql" ))
					numFiles++; 
			}
			
			pgDisk.Maximum = numFiles;
			
			for ( int t=0; t < my_files.GetLength (0); ++t)
			{
				string archive 		= my_files[t];
				string dest_archive = var_data.pathDir + archive.Replace ( "data\\", "\\" );
				
				if ( !archive.Contains ( "sql" ))
				{
					lblCurrentFile.Text = archive;
					Application.DoEvents(); 
				
					try
					{
						if ( System.IO.File.Exists ( dest_archive ) )	
							System.IO.File.Delete ( dest_archive );
						
						System.IO.File.Copy ( my_files[t], dest_archive, true );
					}
					catch ( System.Exception ex )
					{
						MessageBox.Show ( ex.ToString(), "System" );
					}
					
					pgDisk.Value++;
					Application.DoEvents();
				}				
			}
			
			lblCurrentFile.Text = var_trans.GetMsg ( "SI_ctrl_installing", "Done" 	);
			Application.DoEvents();
		}
		
		void copyUninstallFiles()
		{
			string path = 	System.Environment.GetEnvironmentVariable ( "COMMONPROGRAMFILES" ) + 
							"\\" + 
							InfraSoftwareServer.nameServer;
			
			if ( !Directory.Exists ( path ) )
				Directory.CreateDirectory ( path );							

			string archive = "";

			var_data.st_uninstallString = path + "\\ServerSetup.exe";
			
			archive = "ServerSetup.exe"; 				if ( System.IO.File.Exists ( path + "\\" + archive ) ) System.IO.File.Delete ( path + "\\" + archive ); System.IO.File.Copy ( archive, path + "\\" + archive );
			archive = "InstallEngine.dll";			 	if ( System.IO.File.Exists ( path + "\\" + archive ) ) System.IO.File.Delete ( path + "\\" + archive ); System.IO.File.Copy ( archive, path + "\\" + archive );
			archive = "Interop.IWshRuntimeLibrary.dll"; if ( System.IO.File.Exists ( path + "\\" + archive ) ) System.IO.File.Delete ( path + "\\" + archive ); System.IO.File.Copy ( archive, path + "\\" + archive );
			archive = "translator.dat";		 			if ( System.IO.File.Exists ( path + "\\" + archive ) ) System.IO.File.Delete ( path + "\\" + archive ); System.IO.File.Copy ( archive, path + "\\" + archive );
			archive = "version.txt";		 			if ( System.IO.File.Exists ( path + "\\" + archive ) ) System.IO.File.Delete ( path + "\\" + archive ); System.IO.File.Copy ( archive, path + "\\" + archive );
		}
	}
}
