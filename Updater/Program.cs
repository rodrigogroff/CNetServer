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
			Translator 		var_translator 	= new Translator();
			InstallData		var_data 		= new InstallData();
			
			if ( !var_data.IsAppInstalled )
			{
				var_translator.SetLanguage ( Language.English.ToString() );
				
				MessageBox.Show ( var_translator.GetMsg ( "ServerSystem.FailRun" ), "SYSTEM" );		
				return;
			}
			
			var_translator.SetLanguage ( var_data.language );
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			{
				// ----------------------------
				// PRODUCTION CODE
				// ----------------------------
			
				try
				{
					Exchange 			exchange = new Exchange();
					ApplicationUtil 	var_util = new ApplicationUtil();
					
					exchange.GetNewDataClient ( var_data.serverMachine, 
					                           	Convert.ToInt32 ( var_data.clientServerPort ),
					                           	Convert.ToInt32 ( var_data.maxPacket ), 
					                           	var_data.language );
					
					event_MainForm ev_MainForm = new event_MainForm ( var_util, exchange );
					
					ev_MainForm.doEvent ( event_MainForm.event_Start, null );					
				}
				catch ( System.Exception se )
				{
					if ( se.Message != "Exit" )
					{
						MessageBox.Show ( se.Message , "END SYSTEM" );
					}
				}
				finally {}
			}
		}
	}
}
