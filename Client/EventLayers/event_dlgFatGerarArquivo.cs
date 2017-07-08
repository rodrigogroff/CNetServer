using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using SyCrafEngine;

//UserIncludes
//UserIncludes END

namespace Client
{
	public class event_dlgFatGerarArquivo : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_Dir = 6;
		public const int event_val_TxtDtFim = 7;
		public const int event_val_TxtDtIni = 8;
		public const int event_BtnDirClick = 9;
		public const int event_BtnConfirmarClick = 10;
		#endregion

		public dlgFatGerarArquivo i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		dateTextController ctrl_TxtDtIni	= new dateTextController();
		dateTextController ctrl_TxtDtFim	= new dateTextController();
		
		Color 	colorInvalid 	= Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgFatGerarArquivo ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgFatGerarArquivo ( this );
		}
		
		public override bool doEvent ( int event_number, object arg )
		{
			switch ( event_number )
			{
				#region - event_Load -
				
				case event_Load:
				{
					//InitEventCode event_Load
					
					#if ROBOT
					var_util.execDefinedRobot ( this, var_alias );	
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
					
					ctrl_TxtDtIni.AcquireTextBox 	 ( i_Form.TxtDtIni, this, event_val_TxtDtIni, dateTextController.FORMAT_DDMMYYYY );
					ctrl_TxtDtFim.AcquireTextBox 	 ( i_Form.TxtDtFim, this, event_val_TxtDtFim, dateTextController.FORMAT_DDMMYYYY );
					
					ctrl_TxtDtIni.SetupErrorProvider ( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtDtFim.SetupErrorProvider ( ErrorIconAlignment.MiddleRight, false );
						
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
				
				#region - event_Confirmar -
				
				case event_Confirmar:
				{
					//InitEventCode event_Confirmar
					
					bool bOk = true;
					
					if ( !ctrl_TxtDtFim.IsUserValidated )
					{
						ctrl_TxtDtFim.SetErrorMessage ( "Informe o dia final" );
						bOk = false;
					}
					
					if ( !ctrl_TxtDtIni.IsUserValidated )
					{
						ctrl_TxtDtIni.SetErrorMessage ( "Informe o dia inicial" );
						bOk = false;
					}
					
					if ( i_Form.TxtFile.Text == "" )
					{
						MessageBox.Show ( "Informe o arquivo de saída", "Aviso" );
						bOk = false;
					}
					
					if ( i_Form.CboOption.SelectedIndex == -1 )
					{
						MessageBox.Show ( "Informe a opção de cobrança", "Aviso" );
						bOk = false;
					}
					
					if ( !bOk )
						return false;
					
					i_Form.BtnConfirmar.Enabled = false;
					
					string st_block = "";
					string nu_nsFat = "";
					
					dlgStatus stat = new dlgStatus ( "Faturamento" );
					
					stat.LblActivity.Text = "Processando dados no servidor";
					
					stat.pgStatus.Maximum = 1;
					stat.pgStatus.Minimum = 0;
					
					stat.Show();
					Application.DoEvents();
					
					if ( var_exchange.fetch_arquivoFat (   	var_util.GetDataBaseTimeFormat ( ctrl_TxtDtIni.getTextBoxValue_Date() ),
					       	                        	    var_util.GetDataBaseTimeFormat ( ctrl_TxtDtFim.getTextBoxValue_Date().AddDays(1) ),
					       	                        	    i_Form.CboOption.SelectedIndex.ToString(),
															ref header,
															ref st_block,
															ref nu_nsFat ) )
					{
						ArrayList full_memory = new ArrayList();
								
						while ( st_block != "" )
						{
							ArrayList tmp_memory  = new ArrayList();
							
							if ( var_exchange.fetch_memory ( st_block, "600",  ref st_block, ref tmp_memory ) )
								for ( int t=0; t < tmp_memory.Count; ++t )
									full_memory.Add ( tmp_memory[t] );
						}
						
						string file = i_Form.TxtFile.Text.Replace ( "ZZ", nu_nsFat.PadLeft ( 2, '0' ) );
				
						StreamWriter sw = new StreamWriter ( file, false, Encoding.Default );
					
						for ( int t=0; t < full_memory.Count; ++t )
						{
							DataPortable port = full_memory[t] as DataPortable;
							
							sw.WriteLine ( port.getValue ( "line" ) );
						}
						
						sw.Close();		
					
						MessageBox.Show ( "Arquivo '" + file + "' gerado com sucesso", "Aviso" );
					}
					
					stat.Close();
					Application.DoEvents();
										
					i_Form.BtnConfirmar.Enabled = true;
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Dir -
				
				case event_Dir:
				{
					//InitEventCode event_Dir
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDtFim -
				
				case event_val_TxtDtFim:
				{
					//InitEventCode event_val_TxtDtFim
					
					switch ( arg as string )
					{
						case dateTextController.DATE_VALID:
						{
							i_Form.TxtDtFim.BackColor     = Color.White;	
							ctrl_TxtDtFim.IsUserValidated = true;
							ctrl_TxtDtFim.CleanError();
							break;
						}
							
						case dateTextController.DATE_INVALID:
						{
							i_Form.TxtDtFim.BackColor     = colorInvalid;	
							ctrl_TxtDtFim.IsUserValidated = false;
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDtIni -
				
				case event_val_TxtDtIni:
				{
					//InitEventCode event_val_TxtDtIni
					
					switch ( arg as string )
					{
						case dateTextController.DATE_VALID:
						{
							i_Form.TxtDtIni.BackColor     = Color.White;	
							ctrl_TxtDtIni.IsUserValidated = true;
							ctrl_TxtDtIni.CleanError();
							break;
						}
							
						case dateTextController.DATE_INVALID:
						{
							i_Form.TxtDtIni.BackColor     = colorInvalid;	
							ctrl_TxtDtIni.IsUserValidated = false;
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnDirClick -
				
				case event_BtnDirClick:
				{
					//InitEventCode event_BtnDirClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnConfirmarClick -
				
				case event_BtnConfirmarClick:
				{
					//InitEventCode event_BtnConfirmarClick
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
