using System;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Data.Odbc;
using System.ComponentModel;

using SyCrafEngine;

namespace Client
{
	public class Program
	{
		[STAThread]
		public static void Main ( string[] args )
		{
			InstallData	var_data = new InstallData();
			
			bool isFirstInstance;
			
			using ( Mutex mtx = new Mutex ( true, "ConveyNET" + InstallData.app, out isFirstInstance ) )
			{
				if (!isFirstInstance) 
				{
					Application.Exit();
					return;
				} 
				
				Translator var_translator = new Translator();
								
				if ( !var_data.IsAppInstalled )
				{
					var_translator.SetLanguage ( Language.English.ToString() );
					
					MessageBox.Show ( var_translator.GetMsg ( "ServerSystem.FailRun" ), "SYSTEM" );		
					return;
				}
				
				var_translator.SetLanguage ( var_data.language );
				
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				
				try
				{
					Exchange 			exchange = new Exchange();
					ApplicationUtil 	var_util = new ApplicationUtil();
						
					try
					{	
						exchange.GetNewDataClient ( var_data.serverMachine,
						                            ref var_data.serverStandby,
						                            ref var_data.serverStandByPort,
						                           	Convert.ToInt32 ( var_data.clientServerPort ),
						                           	Convert.ToInt32 ( var_data.maxPacket ), 
						                           	var_data.language );
												
						var_data.ins_registration();
					}
					catch ( System.Exception sez )
					{
						if ( var_data.serverStandby     != "" && 
					     	 var_data.serverStandByPort != "" )
						{
							try
							{
								exchange.GetNewDataClient ( var_data.serverStandby, 
								                           	Convert.ToInt32 ( var_data.serverStandByPort ),
								                           	Convert.ToInt32 ( var_data.maxPacket ), 
								                           	var_data.language );
							}
							catch ( System.Exception se )
							{	
								if ( se.Message == "Exit" )
								{
									MessageBox.Show ( var_translator.GetMsg ( "ServerSystem.Unavailable" ) , "SYSTEM");
									
									Application.ExitThread();
									return;
								}	
							}
						}
						else if ( sez.Message == "Exit" )
						{
							MessageBox.Show ( var_translator.GetMsg ( "ServerSystem.Unavailable" ) , "SYSTEM");
							
							Application.ExitThread();
							return;
						}
					}
										
					string st_versionOutdated = "";
					
					exchange.fetch_softwareVersion ( var_data.st_version, ref st_versionOutdated );
					
					if ( st_versionOutdated == Context.TRUE )
					{
						#region  - fetch latest version - 
												
						string target_path = "app.txt";
						
						if ( File.Exists ( target_path ) )
							File.Delete ( target_path );
						
						StreamWriter sw = new StreamWriter ( target_path );
						
						sw.WriteLine ( InstallData.app );
						sw.Close();					
						
						event_dlgUpdate ev_call = new event_dlgUpdate ( var_util, exchange );
					
						ev_call.i_Form.ShowDialog();						
						
						#endregion
					}
					else
					{
						// ############################
						// ## Start main program!
						// ############################
						
						event_MainForm ev_MainForm = new event_MainForm ( var_util, exchange );
						
						ev_MainForm.doEvent ( event_MainForm.event_Start, null );					
					}
				}
				catch ( System.Exception se )
				{
					if ( se.Message != "Exit" )
					{
						MessageBox.Show ( se.Message , "SYSTEM OUT" );
					}
				}
				finally {}
			}
		}
	}
}
