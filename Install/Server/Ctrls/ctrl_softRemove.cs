using System;
using System.IO;
using System.Threading;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace ServerSetup
{
	public partial class ctrl_softRemove : UserControl
	{
		public Translator 	var_trans;
		public InstallData  var_data;
		public ExchangeArea var_ex;
		
		public bool IsSoftRemovalReady = false;
		public bool IsSoftRemovalProblem = false;
		
		public ctrl_softRemove()
		{
			InitializeComponent();
		}
		
		public void reset ( )
		{
			lblEnd.Visible = false;
				
			lblRemove.Text 	= var_trans.GetMsg ( "SI_ctrl_softRemove", "lblRemove" );
			lblEnd.Text 	= var_trans.GetMsg ( "SI_ctrl_softRemove", "lblEnd" );
			
			IsSoftRemovalProblem = false;
			
			if ( !rem_applicationFiles( var_data.pathDir + "\\proc\\rejected" ) )
			{
				IsSoftRemovalProblem = true;
				return;
			}
			
			if ( !rem_applicationFiles( var_data.pathDir + "\\proc\\term" ) )
			{
				IsSoftRemovalProblem = true;
				return;
			}
			
			if ( !rem_applicationFiles( var_data.pathDir + "\\proc" ) )
			{
				IsSoftRemovalProblem = true;
				return;
			}
			
			if ( !rem_applicationFiles( var_data.pathDir + "\\log\\scheduler_log" ) )
			{
				IsSoftRemovalProblem = true;
				return;
			}
			
			if ( !rem_applicationFiles( var_data.pathDir + "\\log" ) )
			{
				IsSoftRemovalProblem = true;
				return;
			}
						
			if ( !rem_applicationFiles( var_data.pathDir ) )
			{
				IsSoftRemovalProblem = true;
				return;
			}
		
			if ( !rem_shortcut() )
			{
				IsSoftRemovalProblem = true;
				return;
			}
			
			if ( !rem_StartMenu() )
			{
				IsSoftRemovalProblem = true;
				return;
			}
			
			var_data.rem_registration();
						
			IsSoftRemovalReady = true;
			lblEnd.Visible = true;
		}
		
		public bool rem_applicationFiles ( string rem_path )
		{
			if ( !Directory.Exists ( rem_path ) )
				return true;				
			
			string [] 	my_files = Directory.GetFiles ( rem_path );
			int 		numFiles = my_files.GetLength (0);
			
			pgRemFiles.Maximum = numFiles;
			
			if ( numFiles == 0 )
			{
				pgRemFiles.Maximum 	= 1;
				pgRemFiles.Value 	= 1;
			}
			else
			{
				for ( int t=0; t < numFiles; ++t)
				{
					string archive = my_files[t];
					Application.DoEvents(); 
					
					try
					{
						System.IO.File.Delete ( archive );
					}
					catch (System.Exception ex )
					{
						MessageBox.Show ( ex.Message, "SYSTEM" );
						return false;
					}
					
					pgRemFiles.Value = t + 1;
					Application.DoEvents();
				}
			}
			
			try
			{
				if ( Directory.Exists ( rem_path ) )
					Directory.Delete ( rem_path  );
			}
			catch (System.Exception ex )
			{
				MessageBox.Show ( ex.Message, "SYSTEM" );
				return false;
			}
			
			return true;
		}
		
		public bool rem_shortcut()
		{
			string shortcut = 	System.Environment.GetEnvironmentVariable ( "USERPROFILE" ) + 
							  	"\\Desktop\\" + 
								InfraSoftwareServer.nameServer + " Server.lnk";

			try
			{
				if ( System.IO.File.Exists ( shortcut ) )
					System.IO.File.Delete ( shortcut );
			}
			catch (System.Exception ex )
			{
				MessageBox.Show ( ex.Message, "SYSTEM" );
				return false;
			}	
			return true;
		}
		
		public bool rem_StartMenu()
		{
			string StartMenu = var_data.getStartMenu() + "\\" + InfraSoftwareServer.nameServer + " Server";
      		
      		if ( Directory.Exists ( StartMenu ) )
      		{
      			string [] 	my_files = Directory.GetFiles ( StartMenu );
				int 		numFiles = my_files.GetLength (0);
			
				for ( int t=0; t < numFiles; ++t)
				{
					string archive = my_files[t];
					
					try
					{
						System.IO.File.Delete ( archive );
					}
					catch (System.Exception ex )
					{
						MessageBox.Show ( ex.Message, "SYSTEM" );
						return false;
					}
				}
				
				try
				{
					Directory.Delete ( StartMenu );		
				}
				catch (System.Exception ex )
				{
					MessageBox.Show ( ex.Message, "SYSTEM" );
					return false;
				}
      		}
      		
      		return true;
		}
		
		public bool IsPrevReady ( ref string msg )
		{
			return false;
		}
		
		public bool IsNextReady ( ref string msg )
		{
			return true;
		}
	}
}
