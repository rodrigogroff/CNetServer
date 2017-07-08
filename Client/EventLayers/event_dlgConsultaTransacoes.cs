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
	public class event_dlgConsultaTransacoes : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_val_TxtNSU = 5;
		public const int event_val_TxtCNPJEmpresa = 6;
		public const int event_val_TxtCNPJLoja = 7;
		public const int event_val_TxtTerminal = 8;
		public const int event_val_TxtValor = 9;
		public const int event_val_TxtParcelas = 10;
		public const int event_Confirmar = 11;
		public const int event_val_TxtDataIni = 12;
		public const int event_val_TxtDataFim = 13;
		public const int event_val_TxtCartao = 14;
		public const int event_val_TxtTelefone = 15;
		public const int event_val_TxtCodEmpresa = 16;
		public const int event_val_TxtCodLoja = 17;
		public const int event_BtnConsultarClick = 18;
		#endregion

		public dlgConsultaTransacoes i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController	ctrl_TxtCartao		= new numberTextController();
		numberTextController	ctrl_TxtCodLoja 	= new numberTextController();
		
		numberTextController  	ctrl_TxtNSU 		= new numberTextController();
		numberTextController	ctrl_TxtCodEmpresa  = new numberTextController();
		cnpjTextController	  	ctrl_TxtCNPJLoja	= new cnpjTextController();
		numberTextController  	ctrl_TxtTerminal 	= new numberTextController();
		moneyTextController  	ctrl_TxtValor 		= new moneyTextController();
		numberTextController  	ctrl_TxtParcelas 	= new numberTextController();
		
		dateTextController		ctrl_TxtDataIni     = new dateTextController();
		dateTextController		ctrl_TxtDataFim     = new dateTextController();
		
		numberTextController 	ctrl_TxtTelefone	= new numberTextController();
		
		Color 	colorInvalid 	= Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgConsultaTransacoes ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgConsultaTransacoes ( this );
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
					
					ctrl_TxtTelefone.AcquireTextBox 	( i_Form.TxtTelefone, 	this, event_val_TxtTelefone, 	10  );
					
					ctrl_TxtCartao.AcquireTextBox		( i_Form.TxtCartao,		 this, event_val_TxtCartao, 		14 	);
					ctrl_TxtCodLoja.AcquireTextBox		( i_Form.TxtCodLoja,	 this, event_val_TxtCodLoja, 		8 	);
					ctrl_TxtNSU.AcquireTextBox			( i_Form.TxtNSU, 		 this, event_val_TxtNSU, 			6 	);
					ctrl_TxtCodEmpresa.AcquireTextBox	( i_Form.TxtCodEmpresa,  this, event_val_TxtCNPJEmpresa, 	12	);
					ctrl_TxtCNPJLoja.AcquireTextBox		( i_Form.TxtCNPJLoja, 	 this, event_val_TxtCNPJLoja 			);
					ctrl_TxtTerminal.AcquireTextBox		( i_Form.TxtTerminal,  	 this, event_val_TxtTerminal, 		8 	);
					ctrl_TxtValor.AcquireTextBox		( i_Form.TxtValor,  	 this, event_val_TxtValor, "R$",  	9 	);
					ctrl_TxtParcelas.AcquireTextBox		( i_Form.TxtParcelas,  	 this, event_val_TxtParcelas, 		2 	);
					
					ctrl_TxtDataIni.AcquireTextBox 		( i_Form.TxtDataIni,	this, event_val_TxtDataIni, dateTextController.FORMAT_DDMMYYYY );
					ctrl_TxtDataFim.AcquireTextBox 		( i_Form.TxtDataFim,	this, event_val_TxtDataFim, dateTextController.FORMAT_DDMMYYYY );
					
					ctrl_TxtDataIni.SetTextBoxText ( 	DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Year.ToString().PadLeft ( 2, '0' ) );
					
					ctrl_TxtDataFim.SetTextBoxText ( 	DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Year.ToString().PadLeft ( 2, '0' ) );
					
					i_Form.CboOper.Items.Clear();
					i_Form.CboOper.Items.Add ( "(Todas)" );
					i_Form.CboOper.Items.AddRange ( new OperacaoCartaoDesc().GetArray().ToArray() );
					
					i_Form.CboOper.SelectedIndex = 0;
					
					if ( header.get_tg_user_type() == TipoUsuario.Administrador ) 
					{
						i_Form.TxtCodEmpresa.Text = header.get_st_empresa();
						i_Form.TxtCodEmpresa.ReadOnly = true;
					}
					
					i_Form.CboStat.Items.Clear();
					i_Form.CboStat.Items.Add ( "(Todos)" );
					i_Form.CboStat.Items.AddRange ( new TipoConfirmacaoDesc().GetArray().ToArray() );
					
					i_Form.CboStat.SelectedIndex = 0;
					
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
				
				#region - event_val_TxtNSU -
				
				case event_val_TxtNSU:
				{
					//InitEventCode event_val_TxtNSU
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( ctrl_TxtNSU.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtNSU.BackColor = Color.White;	
								ctrl_TxtNSU.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtNSU.BackColor = colorInvalid;	
								ctrl_TxtNSU.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCNPJEmpresa -
				
				case event_val_TxtCNPJEmpresa:
				{
					//InitEventCode event_val_TxtCNPJEmpresa
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCNPJLoja -
				
				case event_val_TxtCNPJLoja:
				{
					//InitEventCode event_val_TxtCNPJLoja
					
					switch ( arg as string )
					{
						case cnpjTextController.CNPJ_INCOMPLETE:
						case cnpjTextController.CNPJ_INVALID:
						{
							i_Form.TxtCNPJLoja.BackColor     = colorInvalid;	
							ctrl_TxtCNPJLoja.IsUserValidated = false;
							break;
						}
							
						case cnpjTextController.CNPJ_VALID:
						{
							i_Form.TxtCNPJLoja.BackColor     = Color.White;	
							ctrl_TxtCNPJLoja.IsUserValidated = true;
							ctrl_TxtCNPJLoja.CleanError();
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtTerminal -
				
				case event_val_TxtTerminal:
				{
					//InitEventCode event_val_TxtTerminal
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( ctrl_TxtTerminal.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtTerminal.BackColor = Color.White;	
								ctrl_TxtTerminal.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtTerminal.BackColor = colorInvalid;	
								ctrl_TxtTerminal.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtValor -
				
				case event_val_TxtValor:
				{
					//InitEventCode event_val_TxtValor
					
					if ( arg as string == moneyTextController.MONEY_ZERO )
					{
						i_Form.TxtValor.BackColor = colorInvalid;	
						ctrl_TxtValor.IsUserValidated = false;
					}
					else
					{
						i_Form.TxtValor.BackColor = Color.White;	
						ctrl_TxtValor.IsUserValidated = true;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtParcelas -
				
				case event_val_TxtParcelas:
				{
					//InitEventCode event_val_TxtParcelas
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( ctrl_TxtParcelas.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtParcelas.BackColor = Color.White;	
								ctrl_TxtParcelas.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtParcelas.BackColor = colorInvalid;	
								ctrl_TxtParcelas.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Confirmar -
				
				case event_Confirmar:
				{
					//InitEventCode event_Confirmar
					
					i_Form.BtnConsultar.Enabled = false;
					
					DadosConsultaTransacao dct = new DadosConsultaTransacao();
					
					dct.set_st_nsu 			( ctrl_TxtNSU.getTextBoxValue() 			);
					dct.set_st_cod_empresa  ( ctrl_TxtCodEmpresa.getTextBoxValue() 		);
					dct.set_st_cnpj_loja 	( ctrl_TxtCNPJLoja.getTextBoxValue()		);
					dct.set_st_cod_loja 	( ctrl_TxtCodLoja.getTextBoxValue()			);
					dct.set_st_terminal 	( ctrl_TxtTerminal.getTextBoxValue() 		);
					dct.set_tg_status		( ( i_Form.CboStat.SelectedIndex - 1 ).ToString() );
					
					if ( ctrl_TxtTelefone.IsUserValidated )
						dct.set_st_telefone  ( ctrl_TxtTelefone.getTextBoxValue() );
					
					if ( ctrl_TxtCartao.IsUserValidated )
						dct.set_st_cartao   ( ctrl_TxtCartao.getTextBoxValue() );
					
					if ( ctrl_TxtDataIni.IsUserValidated )
						dct.set_dt_ini		( var_util.GetDataBaseTimeFormat ( ctrl_TxtDataIni.getTextBoxValue_Date() )	);
					
					if ( ctrl_TxtDataFim.IsUserValidated )
						dct.set_dt_fim		( var_util.GetDataBaseTimeFormat ( ctrl_TxtDataFim.getTextBoxValue_Date().AddHours ( 23 ).AddMinutes ( 59 ).AddSeconds ( 59 ) )	);
					
					if ( ctrl_TxtValor.IsUserValidated )
						dct.set_vr_valor 	( ctrl_TxtValor.getTextBoxValue_NumberStr() );
					
					if ( ctrl_TxtParcelas.IsUserValidated )
						dct.set_nu_parcelas ( ctrl_TxtParcelas.getTextBoxValue() 		);
					
					if ( i_Form.CboOper.SelectedIndex > 0 )
						dct.set_en_oper 	( (i_Form.CboOper.SelectedIndex-1).ToString() 	);
										
					string st_csv_id = "";
					
					i_Form.LstTrans.Items.Clear();
					Application.DoEvents();
					
					ArrayList desc = new OperacaoCartaoDesc().GetArray();
					ArrayList  desc_status = new TipoConfirmacaoDesc().GetArray();
					
					i_Form.Cursor = Cursors.WaitCursor;
					
					if ( var_exchange.fetch_consultaTransacao ( ref dct, 
					                                      		ref header, 
					                                      		ref st_csv_id ) )
					{
						ArrayList full_memory = new ArrayList();
						
						while ( st_csv_id != "" )
						{
							ArrayList tmp_memory  = new ArrayList();
							
							if ( var_exchange.fetch_memory ( st_csv_id, "400", ref st_csv_id, ref tmp_memory ) )
								for ( int t=0; t < tmp_memory.Count; ++t )
									full_memory.Add ( tmp_memory[t] );
						}
						
						for ( int t=0; t < full_memory.Count; ++t )
						{
							DadosConsultaTransacao dt = new DadosConsultaTransacao ( full_memory[t] as DataPortable );
							
							try
							{
								int index = Convert.ToInt32 ( dt.get_en_oper() );
								
								string [] full_row = new string [] { 	dt.get_st_nsu().PadLeft ( 6, '0' ),
																		dt.get_st_cartao(),
																		dt.get_st_cnpj_loja(),
																		dt.get_st_terminal().PadLeft ( 8, '0' ),
																		"R$ " + new money().formatToMoney ( dt.get_vr_valor() ),
																		dt.get_nu_parcelas(),
																		dt.get_dt_transacao(),
																		desc [ index ].ToString(),
																		desc_status [ Convert.ToInt32 ( dt.get_tg_status() ) ].ToString(),
																		dt.get_st_msg_erro() };
								
								i_Form.LstTrans.Items.Add ( var_util.GetListViewItem( dt.get_st_nsu(), full_row ) );
							}
							catch ( System.Exception ex  )
							{
								ex.ToString();
								MessageBox.Show ( dt.get_st_nsu() + " - " + dt.get_st_cnpj_loja() );
							}
						}
						
						Application.DoEvents();
					}
					
					i_Form.BtnConsultar.Enabled = true;
					
					i_Form.Cursor = Cursors.Default;
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDataIni -
				
				case event_val_TxtDataIni:
				{
					//InitEventCode event_val_TxtDataIni
					
					switch ( arg as string )
					{
						case dateTextController.DATE_INVALID:
						{
							i_Form.TxtDataIni.BackColor = colorInvalid;	
							ctrl_TxtDataIni.IsUserValidated = false;
							break;
						}

						case dateTextController.DATE_VALID:
						{
							i_Form.TxtDataIni.BackColor = Color.White;	
							ctrl_TxtDataIni.IsUserValidated = true;
							break;
						}
								
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDataFim -
				
				case event_val_TxtDataFim:
				{
					//InitEventCode event_val_TxtDataFim
					
					switch ( arg as string )
					{
						case dateTextController.DATE_INVALID:
						{
							i_Form.TxtDataFim.BackColor = colorInvalid;	
							ctrl_TxtDataFim.IsUserValidated = false;
							break;
						}

						case dateTextController.DATE_VALID:
						{
							i_Form.TxtDataFim.BackColor = Color.White;	
							ctrl_TxtDataFim.IsUserValidated = true;
							break;
						}
								
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCartao -
				
				case event_val_TxtCartao:
				{
					//InitEventCode event_val_TxtCartao
				
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( ctrl_TxtCartao.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtCartao.BackColor = Color.White;	
								ctrl_TxtCartao.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtCartao.BackColor = colorInvalid;	
								ctrl_TxtCartao.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
										
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtTelefone -
				
				case event_val_TxtTelefone:
				{
					//InitEventCode event_val_TxtTelefone
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtTelefone.Text.Length == 10 )
							{
								i_Form.TxtTelefone.BackColor     = Color.White;	
								ctrl_TxtTelefone.IsUserValidated = true;
								ctrl_TxtTelefone.CleanError();
							}
							else
							{
								i_Form.TxtTelefone.BackColor     = colorInvalid;	
								ctrl_TxtTelefone.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCodEmpresa -
				
				case event_val_TxtCodEmpresa:
				{
					//InitEventCode event_val_TxtCodEmpresa
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( ctrl_TxtCodEmpresa.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtCodEmpresa.BackColor = Color.White;	
								ctrl_TxtCodEmpresa.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtCodEmpresa.BackColor = colorInvalid;	
								ctrl_TxtCodEmpresa.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCodLoja -
				
				case event_val_TxtCodLoja:
				{
					//InitEventCode event_val_TxtCodLoja
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( ctrl_TxtCodLoja.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtCodLoja.BackColor = Color.White;	
								ctrl_TxtCodLoja.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtCodLoja.BackColor = colorInvalid;	
								ctrl_TxtCodLoja.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnConsultarClick -
				
				case event_BtnConsultarClick:
				{
					//InitEventCode event_BtnConsultarClick
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
