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
	public class event_dlgEducacional : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Definir = 5;
		public const int event_Pagamento = 6;
		public const int event_Vis = 7;
		public const int event_val_TxtCartao = 8;
		public const int event_val_TxtDiario = 9;
		public const int event_val_TxtMensal = 10;
		public const int event_val_TxtEdu = 11;
		public const int event_val_TxtExtra = 12;
		public const int event_val_TxtDoc = 13;
		public const int event_BuscaDados = 14;
		public const int event_val_TxtDin = 15;
		public const int event_val_TxtDtIni = 16;
		public const int event_val_TxtDtFim = 17;
		public const int event_val_TxtEmpresa = 18;
		public const int event_BtnAlterarClick = 19;
		public const int event_BtnPagamentoClick = 20;
		public const int event_BtnExtratoClick = 21;
		#endregion

		public dlgEducacional i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController 	ctrl_TxtEmpresa	= new numberTextController();
		numberTextController 	ctrl_TxtCartao	= new numberTextController();
		
		moneyTextController  	ctrl_TxtDiario 	= new moneyTextController();
		moneyTextController  	ctrl_TxtMensal 	= new moneyTextController();
		moneyTextController  	ctrl_TxtEdu 	= new moneyTextController();
		moneyTextController  	ctrl_TxtExtra	= new moneyTextController();
		
		moneyTextController  	ctrl_TxtDin		= new moneyTextController();
		
		dateTextController		ctrl_TxtDtIni   = new dateTextController();
		dateTextController		ctrl_TxtDtFim   = new dateTextController();
		
		Color colorInvalid = Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgEducacional ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgEducacional ( this );
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
					
					ctrl_TxtEmpresa.AcquireTextBox 	( i_Form.TxtEmpresa, this, event_val_TxtEmpresa, 6 );
					ctrl_TxtCartao.AcquireTextBox 	( i_Form.TxtCartao,  this, event_val_TxtCartao,  6 );
					
					ctrl_TxtDiario.AcquireTextBox 	( i_Form.TxtDiario, this, event_val_TxtDiario, "R$", 8 );
					ctrl_TxtMensal.AcquireTextBox 	( i_Form.TxtMensal, this, event_val_TxtMensal, "R$", 8 );
					ctrl_TxtEdu.AcquireTextBox 		( i_Form.TxtEdu, 	this, event_val_TxtEdu,    "R$", 8 );
					ctrl_TxtExtra.AcquireTextBox 	( i_Form.TxtExtra, 	this, event_val_TxtExtra,  "R$", 8 );
					
					ctrl_TxtDin.AcquireTextBox 		( i_Form.TxtDin, 	this, event_val_TxtDin,    "R$", 8 );
					
					ctrl_TxtCartao.SetupErrorProvider   ( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtDiario.SetupErrorProvider   ( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtMensal.SetupErrorProvider   ( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtEdu.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtExtra.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					
					ctrl_TxtDin.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false );
					
					ctrl_TxtCartao.IsUserValidated = false;
					
					ctrl_TxtDtIni.AcquireTextBox 		( i_Form.TxtDtIni,	this, event_val_TxtDtIni, dateTextController.FORMAT_DDMMYYYY );
					ctrl_TxtDtFim.AcquireTextBox 		( i_Form.TxtDtFim,	this, event_val_TxtDtFim, dateTextController.FORMAT_DDMMYYYY );
					
					ctrl_TxtDtIni.SetTextBoxText ( 	DateTime.Now.AddDays (-7).Day.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.AddDays (-7).Month.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.AddDays (-7).Year.ToString().PadLeft ( 2, '0' ) );
					
					ctrl_TxtDtFim.SetTextBoxText ( 	DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Year.ToString().PadLeft ( 2, '0' ) );
					
					if ( header.get_tg_user_type() != TipoUsuario.SuperUser  && 
					     header.get_tg_user_type() == TipoUsuario.OperadorEdu )
					{
						i_Form.TxtEmpresa.Text = header.get_st_empresa();
						i_Form.TxtEmpresa.ReadOnly = true;						
					}
						
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
				
				#region - event_Definir -
				
				case event_Definir:
				{
					//InitEventCode event_Definir
					
					if ( !ctrl_TxtCartao.IsUserValidated )
						return false;
					
					dlgAutorizacao autor = new dlgAutorizacao();
					
					autor.ShowDialog();
					
					Application.DoEvents();
					
					if ( autor.IsConfirmed )
					{
						var_exchange.exec_edu_alteraDiario ( 	var_util.getMd5Hash ( autor.senha ), 
						                 						ctrl_TxtDiario.getTextBoxValue_NumberStr(),
						                 						ctrl_TxtEmpresa.getTextBoxValue() + 
						                                   		ctrl_TxtCartao.getTextBoxValue() + "01",
						                                   		ref header );
					}
					
					doEvent ( event_BuscaDados, null );
							 			
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Pagamento -
				
				case event_Pagamento:
				{
					//InitEventCode event_Pagamento
					
					if ( !ctrl_TxtCartao.IsUserValidated )
						return false;
					
					dlgAutorizacao autor = new dlgAutorizacao();
					
					autor.ShowDialog();
					
					Application.DoEvents();
					
					if ( autor.IsConfirmed )
					{
						var_exchange.exec_depotEduImediato ( var_util.getMd5Hash ( autor.senha ), 
						                                     ctrl_TxtEdu.getTextBoxValue_NumberStr(),
						                                   	 ctrl_TxtExtra.getTextBoxValue_NumberStr(),
						                                   	 ctrl_TxtEmpresa.getTextBoxValue(),
						                                   	 ctrl_TxtCartao.getTextBoxValue(),
						                                   	 ref header );
					}
					
					doEvent ( event_BuscaDados, null );
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Vis -
				
				case event_Vis:
				{
					//InitEventCode event_Vis
					
					// ##############################
					// # SETUP LISTS ################
					// ##############################
					
					ArrayList lstHeader 	= new ArrayList();
					ArrayList lstContent 	= new ArrayList();
					ArrayList lstTableSizes = new ArrayList();
					ArrayList lstFooter 	= new ArrayList();
					ArrayList lstMessages 	= new ArrayList();
					ArrayList lstFilters 	= new ArrayList();
					
					ArrayList lstFooterSub1 = new ArrayList();
					ArrayList lstHeaderSub1 = new ArrayList();
					ArrayList lstContentSub1 = new ArrayList();
										
					lstHeader.Add 	( lstHeaderSub1 	);
					lstFooter.Add 	( lstFooterSub1 	);
					lstContent.Add 	( lstContentSub1 	);
					
					// ##############################
					// # CUSTOMIZE
					// ##############################
					
					string st_csv = "";
					string st_empresa = "";
					string st_total_periodo = "";
					
					if ( !var_exchange.fetch_rel_edu_extrato (	var_util.GetDataBaseTimeFormat ( ctrl_TxtDtIni.getTextBoxValue_Date() ),
											                 	var_util.GetDataBaseTimeFormat ( ctrl_TxtDtFim.getTextBoxValue_Date().AddDays(1) ),
											                 	ctrl_TxtEmpresa.getTextBoxValue(),
											                 	ctrl_TxtCartao.getTextBoxValue(),
											                 	ref header, 
											                 	ref st_csv, 
											                 	ref st_empresa,
											                 	ref st_total_periodo ) )
                 	{
						return false;                 		
                 	}
					
					lstMessages.Add   ( "Extrato do aluno: " + i_Form.TxtAluno.Text );

					lstTableSizes.Add ( 950 			);
					
					lstHeaderSub1.Add ( "NSU" 			);
					lstHeaderSub1.Add ( "Data" 			);
					lstHeaderSub1.Add ( "Valor R$" 		);
					lstHeaderSub1.Add ( "Loja" 			);
					lstHeaderSub1.Add ( "Saldo R$" 		);
					lstHeaderSub1.Add ( "Fundo R$" 		);
					lstHeaderSub1.Add ( "Operação" 		);
					
					money money_helper = new money();
					
					ArrayList full_memory = new ArrayList();
						
					while ( st_csv != "" )
					{
						ArrayList tmp_memory  = new ArrayList();
						
						if ( var_exchange.fetch_memory ( st_csv, "400", ref st_csv, ref tmp_memory ) )
							for ( int t=0; t < tmp_memory.Count; ++t )
								full_memory.Add ( tmp_memory[t] );
					}
					
					ArrayList desc    = new TipoConfirmacaoDesc().GetArray();
					ArrayList desc_op = new OperacaoCartaoDesc().GetArray();
					
					for ( int t=0; t < full_memory.Count; ++t )
					{
						EduExtrato rel_line = new EduExtrato ( full_memory[t] as DataPortable );
						
						ArrayList lstLine1 = new ArrayList();
				
						lstLine1.Add ( rel_line.get_st_nsu() 											);
						lstLine1.Add ( var_util.getDDMMYYYY_format ( rel_line.get_dt_trans() )			);
						
						lstLine1.Add ( money_helper.formatToMoney ( rel_line.get_vr_valor() ) 	);
						
						lstLine1.Add ( rel_line.get_st_loja() 											);
						lstLine1.Add ( money_helper.formatToMoney ( rel_line.get_vr_disp() ) 	);
						lstLine1.Add ( money_helper.formatToMoney ( rel_line.get_vr_fundo() ) 	);								
						
						if ( rel_line.get_en_oper() == OperacaoCartao.VENDA_EMPRESARIAL )
							lstLine1.Add ( "Utilização do cartão" );
						else
							lstLine1.Add ( desc_op [ Convert.ToInt32 ( rel_line.get_en_oper() ) ].ToString() );
						
						lstContentSub1.Add ( lstLine1 );
					}
					
					SyCrafReport rel = new SyCrafReport ( 	"Extrado de Transações por cartão",
							                               	"ETC", 
							                               	st_empresa,
							                               	ctrl_TxtDtIni.getTextBoxValue(),
							                               	ctrl_TxtDtFim.getTextBoxValue(),
							                               	ref lstHeader,
							                               	ref lstContent,
							                                ref lstTableSizes,
							                                ref lstFooter,
							                                ref lstMessages,
							                                ref lstFilters );
					
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
							if ( i_Form.TxtCartao.Text.Length == 6 )
							{
								i_Form.TxtCartao.BackColor     = Color.White;	
								ctrl_TxtCartao.IsUserValidated = true;
								ctrl_TxtCartao.CleanError();
							}
							else
							{
								i_Form.TxtCartao.BackColor     = colorInvalid;	
								ctrl_TxtCartao.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					if ( ctrl_TxtCartao.IsUserValidated )
					{
						if ( ctrl_TxtCartao.GetEnterPressed() )
						{
							doEvent ( event_BuscaDados, null );
						}
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDiario -
				
				case event_val_TxtDiario:
				{
					//InitEventCode event_val_TxtDiario
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtMensal -
				
				case event_val_TxtMensal:
				{
					//InitEventCode event_val_TxtMensal
					
					if ( !ctrl_TxtCartao.IsUserValidated )
						return false;
					
					long val = ctrl_TxtMensal.getTextBoxValue_Long();
					
					if ( val > 0 )
					{
						ctrl_TxtDiario.SetTextBoxLong ( val / 31 );
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtEdu -
				
				case event_val_TxtEdu:
				{
					//InitEventCode event_val_TxtEdu
					
					if ( !ctrl_TxtCartao.IsUserValidated )
						return false;
					
					long val = ctrl_TxtEdu.getTextBoxValue_Long() + 
						       ctrl_TxtExtra.getTextBoxValue_Long();
					
					ctrl_TxtDin.SetTextBoxLong ( val );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtExtra -
				
				case event_val_TxtExtra:
				{
					//InitEventCode event_val_TxtExtra
					
					if ( !ctrl_TxtCartao.IsUserValidated )
						return false;
					
					long val = ctrl_TxtEdu.getTextBoxValue_Long() + 
						       ctrl_TxtExtra.getTextBoxValue_Long();
					
					ctrl_TxtDin.SetTextBoxLong ( val );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDoc -
				
				case event_val_TxtDoc:
				{
					//InitEventCode event_val_TxtDoc
					
					/*if ( !ctrl_TxtCartao.IsUserValidated )
						return false;
					
					if ( ctrl_TxtDoc.getTextBoxValue_Long() > 0 )
					{
						long diario = ctrl_TxtDoc.getTextBoxValue_Long() / 31;
					
						i_Form.rb1.Text = 	"Em Fundo Educacional, definindo R$ " + 
											new money().formatToMoney ( diario.ToString() ) + 
											" diário";
					}
					*/
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BuscaDados -
				
				case event_BuscaDados:
				{
					//InitEventCode event_BuscaDados
					
					if ( !ctrl_TxtEmpresa.IsUserValidated || !ctrl_TxtCartao.IsUserValidated )
						return false;
					
					DadosCartaoEdu dce = new DadosCartaoEdu();
							
					if ( var_exchange.fetch_dadosAluno ( ctrl_TxtEmpresa.getTextBoxValue() + 
					                                     ctrl_TxtCartao.getTextBoxValue() + 
					                                     "01",
					                                     ref header, 
					                                     ref dce ) )
					{
						i_Form.TxtAluno.Text = dce.get_st_aluno();
					
						ctrl_TxtDiario.SetTextBoxString ( dce.get_vr_diario().PadLeft (6, '0') );
						
						int diario = Convert.ToInt32 ( dce.get_vr_diario() );
						int calc_mes = diario * 31;
						
						i_Form.TxtMensal.Text       = "R$ " + new money().formatToMoney ( calc_mes.ToString() 	);
						
						i_Form.TxtVrDisp.Text       = "R$ " + new money().formatToMoney ( dce.get_vr_disp() 	);
						i_Form.TxtVrDispDiario.Text = "R$ " + new money().formatToMoney ( diario.ToString() 	);
						i_Form.TxtVrDispMensal.Text = "R$ " + new money().formatToMoney ( calc_mes.ToString() 	);
						i_Form.TxtSaldoTotal.Text   = "R$ " + new money().formatToMoney ( dce.get_vr_depot() 	);
						
						DateTime tim = new DateTime ( 	DateTime.Now.Year, 
						                             	DateTime.Now.Month,
						                             	1 ).AddMonths ( 1 );
						
						long dias     = tim.Subtract ( DateTime.Now ).Days;
						long prev_mes = dias * diario;
						
						i_Form.TxtVrSaldoMes.Text = "R$ " + new money().formatToMoney ( prev_mes.ToString() );
					}
							
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDin -
				
				case event_val_TxtDin:
				{
					//InitEventCode event_val_TxtDin
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
						case dateTextController.DATE_INVALID:
						{
							i_Form.TxtDtIni.BackColor = colorInvalid;	
							ctrl_TxtDtIni.IsUserValidated = false;
							break;
						}

						case dateTextController.DATE_VALID:
						{
							i_Form.TxtDtIni.BackColor = Color.White;	
							ctrl_TxtDtIni.IsUserValidated = true;
							ctrl_TxtDtIni.CleanError();
							break;
						}
								
						default: break;
					}
					
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
						case dateTextController.DATE_INVALID:
						{
							i_Form.TxtDtFim.BackColor = colorInvalid;	
							ctrl_TxtDtFim.IsUserValidated = false;
							break;
						}

						case dateTextController.DATE_VALID:
						{
							i_Form.TxtDtFim.BackColor = Color.White;	
							ctrl_TxtDtFim.IsUserValidated = true;
							ctrl_TxtDtIni.CleanError();
							break;
						}
								
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtEmpresa -
				
				case event_val_TxtEmpresa:
				{
					//InitEventCode event_val_TxtEmpresa
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtEmpresa.Text.Length == 6 )
							{
								i_Form.TxtEmpresa.BackColor     = Color.White;	
								ctrl_TxtEmpresa.IsUserValidated = true;
								ctrl_TxtEmpresa.CleanError();
							}
							else
							{
								i_Form.TxtEmpresa.BackColor     = colorInvalid;	
								ctrl_TxtEmpresa.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnAlterarClick -
				
				case event_BtnAlterarClick:
				{
					//InitEventCode event_BtnAlterarClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnPagamentoClick -
				
				case event_BtnPagamentoClick:
				{
					//InitEventCode event_BtnPagamentoClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnExtratoClick -
				
				case event_BtnExtratoClick:
				{
					//InitEventCode event_BtnExtratoClick
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
