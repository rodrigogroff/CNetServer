using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using SyCrafEngine;

//UserIncludes

using System.Diagnostics;

//UserIncludes END

namespace Client
{
	public class event_MainForm : EventLayer
	{
		#region - EVENTS -
		public const int event_Start = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int event_FormIsClosing = 3;
		public const int robot_ShowDialog = 4;
		public const int robot_CloseDialog = 5;
		#endregion

		public MainForm i_Form;

		//UserVariables
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_MainForm ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new MainForm ( this );
		}
		
		public override bool doEvent ( int event_number, object arg )
		{
			switch ( event_number )
			{
				#region - event_Start -
				
				case event_Start:
				{
					//InitEventCode event_Start
					
					#if ROBOT
					#else
									
					doEvent ( event_Translate, 			null );
					doEvent ( event_FormIsOpening, 		null );
					
					#endif
				
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Translate -
				
				case event_Translate:
				{
					//InitEventCode event_Translate
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_FormIsOpening -
				
				case event_FormIsOpening:
				{
					//InitEventCode event_FormIsOpening
					
					string st_csv_files = "";
					string st_new_version = "";
					
					StreamReader sr = new StreamReader ( "app.txt" );
					
					string app = sr.ReadLine();
					
					sr.Close();
									
					i_Form.LblCmd.Text = "Buscando lista de arquivos...";
					i_Form.Show();
										
					Application.DoEvents();
					Thread.Sleep ( 500 );
					
					#if LINUX_DIST
					
					var_exchange.infra_fetchIncomingVersion ( app, Context.FALSE, ref st_csv_files, ref st_new_version );
					
					#else
					
					var_exchange.infra_fetchIncomingVersion ( app, ref st_csv_files, ref st_new_version );
					
					#endif
										
					// pares de "nome_arquivo,indice"
					int tot = var_util.indexCSV ( st_csv_files );
					
					int num = 1;
					
					for ( int t=0, dot = 0; t < tot; ++t )
					{
						string fileName  = var_util.getCSV (t); 	// busca nome
						string next_part = var_util.getCSV (++t);	// busca indice
						
						// mostrador no diálogo
						string basicTag  = "Buscando arquivo [" + num.ToString() + " de " + (tot/2).ToString() + "] ";
					
						++num;
						
						StringBuilder archive = new StringBuilder();
						
						while ( next_part != "" )
						{
							string 	current_tag = basicTag, 
									tmp_content = "";
						
							// pequena animação indicando download...
							if ( ++dot == 15 ) dot = 1;
							
							for ( int g=0; g < dot; ++g )	
								current_tag += ".";
					
							Application.DoEvents();
							i_Form.LblCmd.Text = current_tag;
							Application.DoEvents();

							var_exchange.infra_fetchFile ( next_part, ref next_part, ref tmp_content );
							
							archive.Append ( tmp_content );
						}
						
						if ( File.Exists ( fileName ) )
							File.Delete ( fileName );
						
						FileStream  fs = new FileStream ( fileName, FileMode.CreateNew );
						BinaryWriter bw = new BinaryWriter(fs); 
						
						bw.Write ( HexEncoding.GetBytes ( archive.ToString() ) );
						
						bw.Close(); 
						fs.Close(); 
					}
					
					InstallData ins = new InstallData();
					
					i_Form.LblCmd.Text = "Alterando versão do software...";
					Application.DoEvents();
					Thread.Sleep ( 250 );
					
					ins.st_version = st_new_version;
					
					ins.ins_registration();
					
					string ver_path = System.Environment.GetEnvironmentVariable ( "COMMONPROGRAMFILES" ) + 
						              "\\" + 
						 			  InfraSoftwareClient.nameClient + " " + app + "\\version.txt";
					
					if ( File.Exists ( ver_path ) ) 
					{
						File.Delete ( ver_path );
					}
					
					StreamWriter sw = new StreamWriter ( ver_path );
					sw.WriteLine ( st_new_version );
					sw.Close();
					
					File.Delete ( "app.txt" );
					
					var_exchange.m_Client.ExitSession();
					
					Process p = new Process();
				    
					#if LINUX_DIST
				    p.StartInfo.FileName 		 = "Linux" + app + ".exe";
				    #else
				    p.StartInfo.FileName 		 = app + ".exe";
				    #endif
				    
				    p.StartInfo.Arguments 		 =  "";
				    p.StartInfo.CreateNoWindow 	 = false;
				    p.Start();
					
					i_Form.Close();
					
					Application.ExitThread();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_FormIsClosing -
				
				case event_FormIsClosing:
				{
					//InitEventCode event_FormIsClosing
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - robot_ShowDialog -
				
				case robot_ShowDialog:
				{
					//InitEventCode robot_ShowDialog
					
					if ( i_Form.IsDisposed ) i_Form = new MainForm ( this );
					
					i_Form.Show();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - robot_CloseDialog -
				
				case robot_CloseDialog:
				{
					//InitEventCode robot_CloseDialog
					
					i_Form.Close();
					
					//EndEventCode
					return true;
				}
				
				#endregion
		
				default: break;
			}
		
			return false;
		}
	}
}
