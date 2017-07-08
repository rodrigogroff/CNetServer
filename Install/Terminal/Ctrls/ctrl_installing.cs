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

namespace ClientSetup
{
	public partial class ctrl_installing : UserControl
	{
		public Translator var_trans;
		public InstallData  var_data;
		
		public bool 	IsInstallDone 	= false;
		
		public string 	newLine 		= "\r\n";
		public int 		numFiles 		= 0;

		public ctrl_installing()
		{
			InitializeComponent();
		}
		
		public void reset ()
		{
			lblEnd.Visible = false;
			lblActions.Visible = false;
			
			lblCopy.Text  = var_trans.GetMsg ( "CI_ctrl_installing", "lblCopy" 	);
			
			copyDatatoPathDir(); 
			copyUninstallFiles();
			createUninstallShortcut();
			createStartMenu();
						
			// Number of files copied
			lblActions.Text = var_trans.GetMsg ( "CI_ctrl_installing", "lblOpt1" ).Replace ( "{$1}", Convert.ToString (numFiles) ) + newLine;
			
			// Shortcut
			createShortcut();
			lblActions.Text += var_trans.GetMsg ( "CI_ctrl_installing", "lblOpt2" ) + newLine;
			
			// Registering
			var_data.ins_registration();
			
			lblActions.Text += var_trans.GetMsg ( "CI_ctrl_installing", "lblOpt3" );
			lblActions.Text += newLine;
			
			// Complete			
			lblEnd.Text	 		= var_trans.GetMsg ( "CI_ctrl_installing", "lblOpt4" );
			lblEnd.Visible 		= true;
			lblActions.Visible 	= true;
			
			IsInstallDone = true;
		}
				
		void createShortcut()
		{
			string shortcut = 	System.Environment.GetEnvironmentVariable ( "USERPROFILE" ) + 
							  	"\\Desktop\\" + 
								InfraSoftwareClient.nameClient + " " + InstallData.app + ".lnk";
				
			if ( System.IO.File.Exists ( shortcut ) ) 
				System.IO.File.Delete ( shortcut );
				
			WshShellClass 	WshShell   = new WshShellClass();
			IWshShortcut 	MyShortcut = (IWshShortcut) WshShell.CreateShortcut( shortcut );
			
			MyShortcut.TargetPath 		= var_data.pathDir + @"\" + InstallData.app + ".exe";
			MyShortcut.WorkingDirectory = var_data.pathDir;
			MyShortcut.IconLocation     = var_data.pathDir + @"\" + InstallData.app + ".exe";
			
			MyShortcut.Save();
		}
		
		void createUninstallShortcut()
		{
			string shortcut = var_data.pathDir + "\\uninstall " + InstallData.app + ".lnk";
				
			if ( System.IO.File.Exists ( shortcut ) ) 
				System.IO.File.Delete ( shortcut );
				
			WshShellClass 	WshShell   = new WshShellClass();
			IWshShortcut 	MyShortcut = (IWshShortcut) WshShell.CreateShortcut( shortcut );
			
			string path = 	System.Environment.GetEnvironmentVariable ( "COMMONPROGRAMFILES" ) + 
							"\\" + 
							InfraSoftwareClient.nameClient + " " + InstallData.app;
						
			MyShortcut.TargetPath 		= path + "\\" + InstallData.app + "Setup.exe";
			MyShortcut.WorkingDirectory = path;
			MyShortcut.IconLocation     = path + "\\" + InstallData.app + "Setup.exe";;
					
			MyShortcut.Save();
		}
		
		void createStartMenu()
		{
			string StartMenu = var_data.getStartMenu() + "\\" + 
								InfraSoftwareClient.nameClient;
      		
      		if ( !Directory.Exists ( StartMenu ) )
				Directory.CreateDirectory ( StartMenu );							
      		
      		// Program link
      		{
	      		string shortcut = StartMenu + "\\" + InstallData.app + ".lnk";
					
				if ( System.IO.File.Exists ( shortcut ) ) 
					System.IO.File.Delete ( shortcut );
					
				WshShellClass 	WshShell   = new WshShellClass();
				IWshShortcut 	MyShortcut = (IWshShortcut) WshShell.CreateShortcut( shortcut );
				
				MyShortcut.TargetPath 		= var_data.pathDir + "\\" +  InstallData.app + ".exe"; 
				MyShortcut.WorkingDirectory = var_data.pathDir;
				MyShortcut.IconLocation     = var_data.pathDir + "\\" +  InstallData.app + ".exe";
						
				MyShortcut.Save();
			}
      		
      		// Uninstall link
      		{
	      		string shortcut = StartMenu + "\\uninstall " + InstallData.app + ".lnk";
					
				if ( System.IO.File.Exists ( shortcut ) ) 
					System.IO.File.Delete ( shortcut );
					
				WshShellClass 	WshShell   = new WshShellClass();
				IWshShortcut 	MyShortcut = (IWshShortcut) WshShell.CreateShortcut( shortcut );
				
				string path = 	System.Environment.GetEnvironmentVariable ( "COMMONPROGRAMFILES" ) + 
								"\\" + 
								InfraSoftwareClient.nameClient + " " + InstallData.app;
							
				MyShortcut.TargetPath 		= path + "\\" +  InstallData.app + "Setup.exe";
				MyShortcut.WorkingDirectory = path;
				MyShortcut.IconLocation     = path + "\\" +  InstallData.app + "Setup.exe";
						
				MyShortcut.Save();
			}
		}
				
		void copyDatatoPathDir()
		{
			lblCurrentFile.Text = "";
			
			string [] 	my_files = Directory.GetFiles ( "data" );
			numFiles = my_files.GetLength (0);
			
			pgDisk.Maximum = numFiles;
			
			for ( int t=0; t < numFiles; ++t)
			{
				string archive 		= my_files[t];
				string dest_archive = var_data.pathDir + archive.Replace ( "data\\", "\\" );
				
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
				
				pgDisk.Value = t + 1;
				Application.DoEvents();
			}
			
			lblCurrentFile.Text = var_trans.GetMsg ( "CI_ctrl_installing", "Done" 	);
			Application.DoEvents();
		}
		
		void copyUninstallFiles()
		{
			string path = 	System.Environment.GetEnvironmentVariable ( "COMMONPROGRAMFILES" ) + 
							"\\" + 
							InfraSoftwareClient.nameClient + " " + InstallData.app;
			
			if ( !Directory.Exists ( path ) )
				Directory.CreateDirectory ( path );							

			string archive = "";

			var_data.st_uninstallString = path + "\\" +  InstallData.app + "Setup.exe";
			
			archive = InstallData.app + "Setup.exe"; 	if ( System.IO.File.Exists ( path + "\\" + archive ) ) System.IO.File.Delete ( path + "\\" + archive ); System.IO.File.Copy ( archive, path + "\\" + archive );
			archive = "InstallEngine.dll";			 	if ( System.IO.File.Exists ( path + "\\" + archive ) ) System.IO.File.Delete ( path + "\\" + archive ); System.IO.File.Copy ( archive, path + "\\" + archive );
			archive = "Interop.IWshRuntimeLibrary.dll"; if ( System.IO.File.Exists ( path + "\\" + archive ) ) System.IO.File.Delete ( path + "\\" + archive ); System.IO.File.Copy ( archive, path + "\\" + archive );
			archive = "translator.dat";		 			if ( System.IO.File.Exists ( path + "\\" + archive ) ) System.IO.File.Delete ( path + "\\" + archive ); System.IO.File.Copy ( archive, path + "\\" + archive );
			archive = "version.txt";		 			if ( System.IO.File.Exists ( path + "\\" + archive ) ) System.IO.File.Delete ( path + "\\" + archive ); System.IO.File.Copy ( archive, path + "\\" + archive );
		}
	}
}
