using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Data.Odbc;
using System.ComponentModel;

namespace SyCrafEngine
{
	internal sealed class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			bool isFirstInstance;
			
			using ( Mutex mtx = new Mutex ( true, InfraSoftwareServer.nameServer, out isFirstInstance ) )
			{
				if (!isFirstInstance) 
				{
					Application.Exit();
					return;
				} 
				
				Translator 		var_translator = new Translator ();
				InstallData		var_data       = new InstallData();
				
				if ( !var_data.IsAppInstalled )
				{
					MessageBox.Show ( var_translator.GetMsg ( Language.English.ToString(), "ServerSystem.FailRun" ), "SYSTEM" );		
					return;
				}
				
				try
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					
					/*#if DEBUG
					
					Application.Run ( new UnitTestInterface() );
					
					#else*/
					
					if ( var_data.IsUpgrade )
					{
					    Process p = new Process();
					    
					    p.StartInfo.WorkingDirectory = var_data.CopyInstallation ( var_data.upgradePath, InfraSoftwareServer.nameServer );
					    p.StartInfo.FileName 		 = "ServerSetup.exe";
					    p.StartInfo.Arguments 		 =  "";
					    p.StartInfo.CreateNoWindow 	 = false;
					    p.Start();
					    
						return;
					}
	
					Application.Run ( new ClusterInterface ( ref var_translator ) );
						
					/* #endif */
				}
				catch ( System.Security.SecurityException ex )
				{
					ex.ToString();
					MessageBox.Show ( var_translator.GetMsg ( var_data.language, "ServerSystem.Security" ), "SYSTEM" );		
				}
				catch ( System.Exception se )
				{
					MessageBox.Show ( se.ToString(), "SYSTEM" );
				}	
				finally {}
			}		
		}
	}
}

