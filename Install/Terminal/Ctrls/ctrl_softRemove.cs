using System;
using System.IO;
using System.Threading;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace ClientSetup
{
	public partial class ctrl_softRemove : UserControl
	{
		public Translator 	var_trans;
		public InstallData  var_data;
		
		public bool IsSoftRemovalReady = false;
		public bool IsSoftRemovalProblem = false;
		
		public ctrl_softRemove()
		{
			InitializeComponent();
		}
		
		public void reset ( )
		{
			lblEnd.Visible = false;
				
			lblRemove.Text 	= var_trans.GetMsg ( "CI_ctrl_softRemove", "lblRemove" );
			lblEnd.Text 	= var_trans.GetMsg ( "CI_ctrl_softRemove", "lblEnd" );
			
			IsSoftRemovalProblem = false;
			
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
		
		public bool rem_shortcut()
		{
			string shortcut = 	System.Environment.GetEnvironmentVariable ( "USERPROFILE" ) + 
							  	"\\Desktop\\" + 
								InfraSoftwareClient.nameClient + " " + InstallData.app + ".lnk";			

			if ( File.Exists ( shortcut ) )
			{
				try
				{
					System.IO.File.Delete ( shortcut );
				}
				catch (System.Exception ex )
				{
					MessageBox.Show ( ex.Message, "SYSTEM" );
					return false;
				}	
			}
			
			return true;
		}
		
		public bool rem_StartMenu()
		{
			string StartMenu = var_data.getStartMenu() + "\\" + InfraSoftwareClient.nameClient;
      		
      		if ( Directory.Exists ( StartMenu ) )
      		{
      			string [] 	my_files = Directory.GetFiles ( StartMenu );
				int 		numFiles = my_files.GetLength (0);
			
				for ( int t=0; t < numFiles; ++t)
				{
					string archive = my_files[t];
					
					if ( archive.EndsWith ( InstallData.app + ".lnk" ) ||
					     archive.EndsWith ( "uninstall " + InstallData.app + ".lnk" )  )
					{
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
				}
				
				if ( numFiles == 2 )
				{
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
