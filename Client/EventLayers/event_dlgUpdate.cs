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
	public class event_dlgUpdate : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		#endregion

		public dlgUpdate i_Form;

		//UserVariables
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgUpdate ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgUpdate ( this );
		}
		
		public override bool doEvent ( int event_number, object arg )
		{
			switch ( event_number )
			{
				#region - event_Load -
				
				case event_Load:
				{
					//InitEventCode event_Load
					
					doEvent ( event_Translate, 			null );
					doEvent ( event_FormIsOpening, 		null );
					
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
														
					i_Form.LblCmd.Text = "Buscando ultima versão do programa de atualização...";
					i_Form.Show();
										
					Application.DoEvents();
					Thread.Sleep ( 500 );

					#if LINUX_DIST

					//var_exchange.infra_fetchUpdaterVersion ( Context.FALSE, ref st_csv_files );
					
					#else
					
					var_exchange.infra_fetchUpdaterVersion ( ref st_csv_files );
					
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
					
					var_exchange.m_Client.ExitSession();
						
				    Process p = new Process();
				    
				    #if LINUX_DIST
				    
				    p.StartInfo.FileName 		 = "LinuxUpdater.exe";
				    
				    #else
				    
				    p.StartInfo.FileName 		 = "Updater.exe";
				    
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
				
				#region - robot_ShowDialog -
				
				case robot_ShowDialog:
				{
					//InitEventCode robot_ShowDialog
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - robot_CloseDialog -
				
				case robot_CloseDialog:
				{
					//InitEventCode robot_CloseDialog
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
