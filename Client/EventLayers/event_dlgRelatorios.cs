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
	public class event_dlgRelatorios : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_val_TxtDtIni = 5;
		public const int event_val_TxtDtFim = 6;
		public const int event_Consultar = 7;
		public const int event_val_TxtEmpresa = 8;
		public const int event_val_TxtLoja = 9;
		public const int event_val_TxtCartao = 10;
		public const int event_val_TxtPayFone = 11;
		public const int event_val_TxtEstado = 12;
		public const int event_val_TxtCidade = 13;
		public const int event_rel_1_TransPorCartao = 14;
		public const int event_val_TxtTit = 15;
		public const int event_rel_2_TransPorLoja = 16;
		public const int event_rel_4_repasse = 17;
		public const int event_rel_5_empresaLoja = 18;
		public const int event_rel_6_fat = 19;
		public const int event_rel_repEfetivo = 20;
		public const int event_rel_fechCaixa = 21;
		public const int event_rel_dirCont = 22;
		public const int event_BtnConfirmarClick = 23;
		public const int event_rel_residuo = 24;
		public const int event_rel_movEscola = 25;
		public const int event_rel_movEduRede = 26;
		public const int event_rel_listaCart = 27;
		public const int event_rel_listaLojas = 28;
		#endregion

		public dlgRelatorios i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		dateTextController		ctrl_TxtDtIni   = new dateTextController();
		dateTextController		ctrl_TxtDtFim   = new dateTextController();
		
		numberTextController 	ctrl_TxtEmpresa	= new numberTextController();
		numberTextController 	ctrl_TxtLoja	= new numberTextController();
		numberTextController 	ctrl_TxtCartao	= new numberTextController();
		numberTextController 	ctrl_TxtTit  	= new numberTextController();
		numberTextController 	ctrl_TxtPayFone	= new numberTextController();
		
		alphaTextController		ctrl_TxtEstado	= new alphaTextController();
		alphaTextController		ctrl_TxtCidade	= new alphaTextController();
		
		Color 	colorInvalid = Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgRelatorios ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgRelatorios ( this );
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
					
					ctrl_TxtDtIni.AcquireTextBox 		( i_Form.TxtDtIni,	this, event_val_TxtDtIni, dateTextController.FORMAT_DDMMYYYY );
					ctrl_TxtDtFim.AcquireTextBox 		( i_Form.TxtDtFim,	this, event_val_TxtDtFim, dateTextController.FORMAT_DDMMYYYY );
					
					ctrl_TxtDtIni.SetTextBoxText ( 	DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Year.ToString().PadLeft ( 2, '0' ) );
					
					ctrl_TxtDtFim.SetTextBoxText ( 	DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Year.ToString().PadLeft ( 2, '0' ) );
					
					ctrl_TxtEmpresa.AcquireTextBox 	( i_Form.TxtEmpresa, 	this, event_val_TxtEmpresa, 	6   );
					ctrl_TxtLoja.AcquireTextBox 	( i_Form.TxtLoja, 		this, event_val_TxtLoja, 		16   );
					ctrl_TxtCartao.AcquireTextBox 	( i_Form.TxtCartao, 	this, event_val_TxtCartao, 		6   );
					ctrl_TxtTit.AcquireTextBox 		( i_Form.TxtTit, 		this, event_val_TxtTit, 		2   );
					ctrl_TxtPayFone.AcquireTextBox 	( i_Form.TxtPayFone, 	this, event_val_TxtPayFone, 	10  );
					
					ctrl_TxtEstado.AcquireTextBox 	( i_Form.TxtEstado, 	this, event_val_TxtEstado, 		2, false  );
					ctrl_TxtCidade.AcquireTextBox 	( i_Form.TxtCidade, 	this, event_val_TxtCidade, 		20, false  );

					ctrl_TxtDtIni.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtDtFim.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtEmpresa.SetupErrorProvider 	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtLoja.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtPayFone.SetupErrorProvider  ( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtEstado.SetupErrorProvider   ( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtCidade.SetupErrorProvider   ( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtCartao.SetupErrorProvider   ( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtTit.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 					
					
					if ( header.get_tg_user_type () ==  TipoUsuario.AdminGift )
					{
						ctrl_TxtTit.SetTextBoxText ( "01" );
						i_Form.TxtTit.ReadOnly = true;
					}
					
					if ( header.get_tg_user_type () ==  TipoUsuario.Administrador || 
					     header.get_tg_user_type () ==  TipoUsuario.AdminGift || 
				     	 header.get_tg_user_type() == TipoUsuario.Operador )
					{
						ctrl_TxtEmpresa.SetTextBoxText ( header.get_st_empresa() );
						i_Form.TxtEmpresa.ReadOnly = true;
					}
					
					if ( header.get_tg_user_type () ==  TipoUsuario.Lojista )
					{
						ctrl_TxtLoja.SetTextBoxText ( header.get_st_empresa() );
						
						i_Form.TxtEmpresa.ReadOnly 	= true;
						i_Form.TxtLoja.ReadOnly 	= true;		
						i_Form.TxtCartao.ReadOnly 	= true;		
						i_Form.TxtEstado.ReadOnly 	= true;		
						i_Form.TxtTit.ReadOnly 		= true;		
						i_Form.TxtCidade.ReadOnly 	= true;		
						i_Form.TxtPayFone.ReadOnly 	= true;		
						
						i_Form.LstReport.Items.Add ( "Transações por loja filtrado por terminais" );
						i_Form.LstReport.Items.Add ( "Previsão de repasse por associação" );
						
						return true;
					}
					else
					{
						i_Form.LstReport.Items.Add ( "Transações por cartão ou pay fone" );
						i_Form.LstReport.Items.Add ( "Transações por loja filtrado por terminais" );
						i_Form.LstReport.Items.Add ( "Transações de todas as lojas de uma empresa" );
					}
						
					if ( header.get_tg_user_type () !=  TipoUsuario.Operador && 
					     header.get_tg_user_type () !=  TipoUsuario.AdminGift )
					{
						i_Form.LstReport.Items.Add ( "Fechamento mensal da empresa" );
					}
						
					if ( header.get_tg_user_type () ==  TipoUsuario.AdminGift )
					{
						i_Form.LstReport.Items.Add ( "Previsão de repasse financeiro de empresa" );
						i_Form.LstReport.Items.Add ( "Repasses efetivos da empresa" );
						i_Form.LstReport.Items.Add ( "Fechamento de Caixa" );
						i_Form.LstReport.Items.Add ( "GiftCard diário contábil" );						
					}
					
					i_Form.LstReport.Items.Add ( "Lista completa de cartões" );
					i_Form.LstReport.Items.Add ( "Lista completa de lojas" );
					
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
				
				#region - event_Consultar -
				
				case event_Consultar:
				{
					//InitEventCode event_Consultar
					
					if ( i_Form.LstReport.SelectedItem == null )
					{
						MessageBox.Show ( "Selecione o relatório", "Aviso" );
						return false;
					}
					
					int index = i_Form.LstReport.SelectedIndex + 1;
					
					if ( header.get_tg_user_type () ==  TipoUsuario.Lojista )
					{
						switch ( index )
						{
							case 1:
							{
								doEvent ( event_rel_2_TransPorLoja, null );
								break;
							}
							
							case 2:  
							{
								event_dlgPrevLojista ev_call = new event_dlgPrevLojista ( var_util, var_exchange );
					
								ev_call.header = header;
								
								ev_call.i_Form.ShowDialog();
								break;
							}
							
							default: break;
						}
						
						return true;
					}
					
					switch ( index )
					{
						case 1:  doEvent ( event_rel_1_TransPorCartao, null );	break;
						case 2:  doEvent ( event_rel_2_TransPorLoja, null );	break;
						
						case 3:  
						{
							doEvent ( event_rel_5_empresaLoja, null );	
							break;
						}
						
						case 4:  
						{
							if ( header.get_tg_user_type () ==  TipoUsuario.AdminGift )
							{
								doEvent ( event_rel_4_repasse, null );	
							}
							else
							{
								event_dlgFechamento ev_call = new event_dlgFechamento ( var_util, var_exchange );
						
								ev_call.header = header;
								ev_call.st_cod_empresa = ctrl_TxtEmpresa.getTextBoxValue();
								
								ev_call.i_Form.ShowDialog();
							}
							
							break;
						}
						
						case 5:  
						{
							doEvent ( event_rel_listaCart, null );	
							break;
						}
						
						case 6:  
						{
							doEvent ( event_rel_listaLojas, null );	
							break;
						}
						
						/*
						case 5:  
						{
							doEvent ( event_rel_repEfetivo, null );	
							break;
						}
						
						case 6:  
						{
							doEvent ( event_rel_fechCaixa, null );	
							break;
						}
						
						case 7:  
						{
							doEvent ( event_rel_dirCont, null );	
							break;
						}
						
						case 8:  
						{
							doEvent ( event_rel_residuo, null );	
							break;
						}
						
						case 9:	
						{
							ArrayList lst = new ArrayList();
							
							var_exchange.fetch_listaFiliais ( ref header, ref lst );
							
							event_dlgSelecionaEmpresa ev_call = new event_dlgSelecionaEmpresa ( var_util, var_exchange );
							
							ev_call.header = header;
							ev_call.lst = lst;
							
							ev_call.i_Form.ShowDialog();
							
							doEvent ( event_rel_movEscola, ev_call.var_empresa );	
							
							break;
						}
						
						case 10:	
						{
							doEvent ( event_rel_movEduRede, null );	
							
							break;
						}
						*/
							
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
							if ( i_Form.TxtEmpresa.Text.Length > 0 )
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
				
				#region - event_val_TxtLoja -
				
				case event_val_TxtLoja:
				{
					//InitEventCode event_val_TxtLoja
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtLoja.Text.Length > 0 )
							{
								i_Form.TxtLoja.BackColor     = Color.White;	
								ctrl_TxtLoja.IsUserValidated = true;
								ctrl_TxtLoja.CleanError();
							}
							else
							{
								i_Form.TxtLoja.BackColor     = colorInvalid;	
								ctrl_TxtLoja.IsUserValidated = false;
							}
							
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
							if ( i_Form.TxtCartao.Text.Length > 0 )
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
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtPayFone -
				
				case event_val_TxtPayFone:
				{
					//InitEventCode event_val_TxtPayFone
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtPayFone.Text.Length == 10 )
							{
								i_Form.TxtPayFone.BackColor     = Color.White;	
								ctrl_TxtPayFone.IsUserValidated = true;
								ctrl_TxtPayFone.CleanError();
							}
							else
							{
								i_Form.TxtPayFone.BackColor     = colorInvalid;	
								ctrl_TxtPayFone.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtEstado -
				
				case event_val_TxtEstado:
				{
					//InitEventCode event_val_TxtEstado
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtEstado.getTextBoxValue().Length == 2 )
							{
								i_Form.TxtEstado.BackColor = Color.White;	
								ctrl_TxtEstado.IsUserValidated = true;
								ctrl_TxtEstado.CleanError();
							}
							else
							{
								i_Form.TxtEstado.BackColor = colorInvalid;	
								ctrl_TxtEstado.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCidade -
				
				case event_val_TxtCidade:
				{
					//InitEventCode event_val_TxtCidade
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtCidade.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtCidade.BackColor = Color.White;	
								ctrl_TxtCidade.IsUserValidated = true;
								ctrl_TxtCidade.CleanError();
							}
							else
							{
								i_Form.TxtCidade.BackColor = colorInvalid;	
								ctrl_TxtCidade.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_rel_1_TransPorCartao -
				
				case event_rel_1_TransPorCartao:
				{
					//InitEventCode event_rel_1_TransPorCartao
					
					bool IsDone = true;
					
					if ( !ctrl_TxtPayFone.IsUserValidated )
					{
						if ( !ctrl_TxtEmpresa.IsUserValidated )	
						{	
							ctrl_TxtEmpresa.SetErrorMessage ( "O número da empresa deve ser informado" );
							IsDone = false;	
						}
						
						if ( !ctrl_TxtCartao.IsUserValidated )	
						{	
							ctrl_TxtCartao.SetErrorMessage ( "O número do cartão deve ser informado" );
							IsDone = false;	
						}
						
						if ( !ctrl_TxtTit.IsUserValidated )	
						{	
							ctrl_TxtTit.SetErrorMessage ( "O número da titularidade deve ser informado" );
							IsDone = false;	
						}
					}
					
					if ( !ctrl_TxtDtIni.IsUserValidated )	{	ctrl_TxtDtIni.SetErrorMessage 		( "A data inicial deve ser informada corretamente" );	IsDone = false;	}
					if ( !ctrl_TxtDtFim.IsUserValidated )	{	ctrl_TxtDtFim.SetErrorMessage 		( "A data final deve ser informada corretamente" );	IsDone = false;	}
					
					if ( !IsDone )
						return false;
					
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
					
					ArrayList lstFooterSub2 = new ArrayList();
					ArrayList lstHeaderSub2 = new ArrayList();
					ArrayList lstContentSub2 = new ArrayList();
					
					ArrayList lstFooterSub3 = new ArrayList();
					ArrayList lstHeaderSub3 = new ArrayList();
					ArrayList lstContentSub3 = new ArrayList();
										
					lstHeader.Add 	( lstHeaderSub1 	);
					lstFooter.Add 	( lstFooterSub1 	);
					lstContent.Add 	( lstContentSub1 	);
					
					lstHeader.Add 	( lstHeaderSub2 	);
					lstFooter.Add 	( lstFooterSub2 	);
					lstContent.Add 	( lstContentSub2 	);
					
					lstHeader.Add 	( lstHeaderSub3 	);
					lstFooter.Add 	( lstFooterSub3 	);
					lstContent.Add 	( lstContentSub3 	);
					
					// ##############################
					// # CUSTOMIZE
					// ##############################
					
					string st_csv 				 = "";
					string st_empresa 			 = "";
					string st_total_periodo 	 = "";
					string st_total_canc_periodo = "";
					string st_cartao 			 = "";
					string st_parcs 			 = "";
					string st_parcs_total		 = "";
					string st_parcs_content 	 = "";
					
					dlgStatus stat = new dlgStatus ( "Relatório" );
					
					stat.LblActivity.Text = "Processando relatório no servidor";
					stat.Show();
					Application.DoEvents();
					
					if ( !var_exchange.fetch_rel_1_rtc (	ctrl_TxtEmpresa.getTextBoxValue().PadLeft 	( 6, '0' ) + 
					                                    	ctrl_TxtCartao.getTextBoxValue().PadLeft 	( 6, '0' ) +
					                                    	ctrl_TxtTit.getTextBoxValue().PadLeft 		( 2, '0' ),
								                       		ctrl_TxtPayFone.getTextBoxValue(),
									                       	ctrl_TxtCidade.getTextBoxValue(),
									                       	ctrl_TxtEstado.getTextBoxValue(),
										                 	ctrl_TxtLoja.getTextBoxValue(),
										                 	var_util.GetDataBaseTimeFormat ( ctrl_TxtDtIni.getTextBoxValue_Date() ),
										                 	var_util.GetDataBaseTimeFormat ( ctrl_TxtDtFim.getTextBoxValue_Date().AddDays(1) ),
										                 	ref header, 
										                 	ref st_csv, 
										                 	ref st_empresa,
										                 	ref st_total_periodo,
										                    ref st_cartao,
										                    ref st_total_canc_periodo,
										                    ref st_parcs,
										                    ref st_parcs_total,
										                    ref st_parcs_content ) )
                 	{
						stat.Close();
						return false;                 		
                 	}
					
					money money_helper = new money();
				
					if ( ctrl_TxtPayFone.IsUserValidated )	lstFilters.Add ( "Filtrando por Pay Fone: " + ctrl_TxtPayFone.getTextBoxValue() );
					if ( ctrl_TxtCidade.IsUserValidated )	lstFilters.Add ( "Filtrando por Cidade: " 	+ ctrl_TxtCidade.getTextBoxValue() 	);
					if ( ctrl_TxtEstado.IsUserValidated )	lstFilters.Add ( "Filtrando por Estado: " 	+ ctrl_TxtEstado.getTextBoxValue() 	);
					if ( ctrl_TxtLoja.IsUserValidated )		lstFilters.Add ( "Filtrando por Loja: " 	+ ctrl_TxtLoja.getTextBoxValue() 	);
					
					lstMessages.Add   ( "Transações confirmadas: " + st_cartao );
					lstMessages.Add   ( "Transações canceladas: " + st_cartao );
					lstMessages.Add   ( "Movimentação completa do Cartão: " + st_cartao );

					lstTableSizes.Add ( 950 			);
					lstTableSizes.Add ( 950 			);
					lstTableSizes.Add ( 950 			);
					
					lstHeaderSub1.Add ( "Loja" 			);
					lstHeaderSub1.Add ( "Terminal" 		);
					lstHeaderSub1.Add ( "NSU" 			);
					lstHeaderSub1.Add ( "Valor Total R$" 	);
					lstHeaderSub1.Add ( "Parcelas" 		);
					lstHeaderSub1.Add ( "Data e Hora" 	);
					lstHeaderSub1.Add ( "Status" 		);
					lstHeaderSub1.Add ( "Operação" 		);
					
					lstHeaderSub2.Add ( "Loja" 			);
					lstHeaderSub2.Add ( "Terminal" 		);
					lstHeaderSub2.Add ( "NSU" 			);
					lstHeaderSub2.Add ( "Valor Total R$" 	);
					lstHeaderSub2.Add ( "Parcelas" 		);
					lstHeaderSub2.Add ( "Data e Hora" 	);
					lstHeaderSub2.Add ( "Status" 		);
					lstHeaderSub2.Add ( "Operação" 		);
					
					lstHeaderSub3.Add ( "Loja" 			);
					lstHeaderSub3.Add ( "Terminal" 		);
					lstHeaderSub3.Add ( "NSU" 			);
					lstHeaderSub3.Add ( "Valor Total R$" 	);
					lstHeaderSub3.Add ( "Parcelas" 		);
					lstHeaderSub3.Add ( "Data e Hora" 	);
					lstHeaderSub3.Add ( "Status" 		);
					lstHeaderSub3.Add ( "Operação" 		);
										
					ArrayList desc = new TipoConfirmacaoDesc().GetArray();
					ArrayList desc_op = new OperacaoCartaoDesc().GetArray();
					
					ArrayList full_memory = new ArrayList();
					ArrayList full_memory_parc = new ArrayList();
						
					stat.LblActivity.Text = "Buscando detalhes de faturamento";
					Application.DoEvents();

					while ( st_csv != "" )
					{
						ArrayList tmp_memory  = new ArrayList();
						
						if ( var_exchange.fetch_memory ( st_csv, "400", ref st_csv, ref tmp_memory ) )
							for ( int t=0; t < tmp_memory.Count; ++t )
								full_memory.Add ( tmp_memory[t] );
					}
					
					stat.LblActivity.Text = "Gerando relatório para web";
					Application.DoEvents();
					
					stat.pgStatus.Maximum = full_memory.Count;
					stat.pgStatus.Minimum = 0;

					for ( int t=0; t < full_memory.Count; ++t )
					{
						stat.pgStatus.Value = t + 1;
						
						Application.DoEvents();
						
						Rel_RTC rel_line = new Rel_RTC ( full_memory[t] as DataPortable );
						
						ArrayList lstLine1 = new ArrayList();
				
						lstLine1.Add ( rel_line.get_st_loja() 											);
						lstLine1.Add ( rel_line.get_st_term() 											);
						lstLine1.Add ( rel_line.get_st_nsu()											);
						lstLine1.Add ( money_helper.formatToMoney ( rel_line.get_vr_total() ) 			);
						lstLine1.Add ( rel_line.get_nu_parc() 											);
						lstLine1.Add ( var_util.getDDMMYYYY_format ( rel_line.get_dt_trans() )			);
						lstLine1.Add ( desc [ Convert.ToInt32 ( rel_line.get_tg_status() ) ].ToString() );
						
						if ( rel_line.get_st_motivo().Length > 0 )
							lstLine1.Add ( rel_line.get_st_motivo() + " - " + desc_op [ Convert.ToInt32 ( rel_line.get_en_op_cartao() ) ].ToString() );
						else
							lstLine1.Add ( desc_op [ Convert.ToInt32 ( rel_line.get_en_op_cartao() ) ].ToString() );
						
						lstContentSub3.Add ( lstLine1 );
						
						if ( rel_line.get_tg_status() == TipoConfirmacao.Cancelada )
							lstContentSub2.Add ( lstLine1 );
						
						if ( rel_line.get_tg_status() == TipoConfirmacao.Confirmada )
							lstContentSub1.Add ( lstLine1 );
					}
					
					lstFooterSub1.Add ( "Total período: R$ " 				+ money_helper.formatToMoney ( st_total_periodo ) );
					
					lstFooterSub2.Add ( "Total cancelado no período: R$ " 	+ money_helper.formatToMoney ( st_total_canc_periodo ) );
					
					lstFooterSub3.Add ( "Total período: R$ " 				+ money_helper.formatToMoney ( st_total_periodo ) );
					lstFooterSub3.Add ( "Total cancelado no período: R$ " 	+ money_helper.formatToMoney ( st_total_canc_periodo ) );
					
					
					// ########################################
					// #### Relatório sobre todas as parcelas
					// ########################################
										
					while ( st_parcs_content != "" )
					{
						ArrayList tmp_memory  = new ArrayList();
						
						if ( var_exchange.fetch_memory ( st_parcs_content, "400", ref st_parcs_content, ref tmp_memory ) )
							for ( int t=0; t < tmp_memory.Count; ++t )
								full_memory_parc.Add ( tmp_memory[t] );
					}
					
					ApplicationUtil tmp_util = new ApplicationUtil();
					
					var_util.indexCSV ( st_parcs_total );
					int max_parc = tmp_util.indexCSV ( st_parcs );
					
					for ( int y=0,k=0; y < max_parc; ++y )
					{
						ArrayList lstFooterSubParc  = new ArrayList();
						ArrayList lstHeaderSubParc  = new ArrayList();
						ArrayList lstContentSubParc = new ArrayList();
						
						lstTableSizes.Add ( 950 			);
						
						lstHeaderSubParc.Add ( "Loja" 			);
						lstHeaderSubParc.Add ( "Terminal" 		);
						lstHeaderSubParc.Add ( "NSU" 			);
						lstHeaderSubParc.Add ( "Valor Total R$" );
						lstHeaderSubParc.Add ( "Índice Parcela" );
						lstHeaderSubParc.Add ( "Data e Hora" 	);
						lstHeaderSubParc.Add ( "Status" 		);
						lstHeaderSubParc.Add ( "Operação" 		);
						
						string parc_atual = tmp_util.getCSV (y);
					
						lstMessages.Add ( tmp_util.getCSV (y) );
						
						for ( int t=0; t < full_memory_parc.Count; ++t )
						{
							Rel_RTC rel_line = new Rel_RTC ( full_memory_parc[t] as DataPortable );
							
							if ( rel_line.get_st_indice_parcela() != parc_atual )
								continue;
							
							ArrayList lstLine1 = new ArrayList();
					
							lstLine1.Add ( rel_line.get_st_loja() 											);
							lstLine1.Add ( rel_line.get_st_term() 											);
							lstLine1.Add ( rel_line.get_st_nsu()											);
							lstLine1.Add ( money_helper.formatToMoney ( rel_line.get_vr_total() ) 			);
							lstLine1.Add ( rel_line.get_nu_parc() 											);
							lstLine1.Add ( var_util.getDDMMYYYY_format ( rel_line.get_dt_trans() )			);
							lstLine1.Add ( desc [ Convert.ToInt32 ( rel_line.get_tg_status() ) ].ToString() );
							
							if ( rel_line.get_st_motivo().Length > 0 )
								lstLine1.Add ( rel_line.get_st_motivo() + " - " + desc_op [ Convert.ToInt32 ( rel_line.get_en_op_cartao() ) ].ToString() );
							else
								lstLine1.Add ( desc_op [ Convert.ToInt32 ( rel_line.get_en_op_cartao() ) ].ToString() );
							
							lstContentSubParc.Add ( lstLine1 );
						}
							
						lstFooterSubParc.Add ( "Total parcela: R$ " + 
						                       money_helper.formatToMoney ( var_util.getCSV (k++) ) );
						lstFooterSubParc.Add ( "Disponível: R$ " + 
						                       money_helper.formatToMoney ( var_util.getCSV (k++) ) );
										
						lstHeader.Add 	( lstHeaderSubParc 	);
						lstFooter.Add 	( lstFooterSubParc 	);
						lstContent.Add 	( lstContentSubParc	);
					}
					
					stat.Close();

					SyCrafReport rel = new SyCrafReport ( "Relatório de Transações por cartão",
					                               	"RTC", 
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
				
				#region - event_val_TxtTit -
				
				case event_val_TxtTit:
				{
					//InitEventCode event_val_TxtTit
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtTit.Text.Length > 0 )
							{
								i_Form.TxtTit.BackColor     = Color.White;	
								ctrl_TxtTit.IsUserValidated = true;
								ctrl_TxtTit.CleanError();
							}
							else
							{
								i_Form.TxtTit.BackColor     = colorInvalid;	
								ctrl_TxtTit.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_rel_2_TransPorLoja -
				
				case event_rel_2_TransPorLoja:
				{
					//InitEventCode event_rel_2_TransPorLoja
					
					bool IsDone = true;
					
					if ( !ctrl_TxtLoja.IsUserValidated )	
					{	
						ctrl_TxtLoja.SetErrorMessage ( "O número da loja deve ser informado" );
						IsDone = false;	
					}
					
					if ( !ctrl_TxtDtIni.IsUserValidated )	{	ctrl_TxtDtIni.SetErrorMessage 		( "A data inicial deve ser informada corretamente" );	IsDone = false;	}
					if ( !ctrl_TxtDtFim.IsUserValidated )	{	ctrl_TxtDtFim.SetErrorMessage 		( "A data final deve ser informada corretamente" );	IsDone = false;	}
					
					if ( !IsDone )
						return false;
					
					// ##############################
					// # SETUP LISTS ################
					// ##############################
					
					ArrayList lstHeader 	= new ArrayList();
					ArrayList lstContent 	= new ArrayList();
					ArrayList lstTableSizes = new ArrayList();
					ArrayList lstFooter 	= new ArrayList();
					ArrayList lstMessages 	= new ArrayList();
					ArrayList lstFilters 	= new ArrayList();
					
					// ##############################
					// # CUSTOMIZE
					// ##############################
					
					string st_csv = "";
					string st_empresa = "";
					string st_total = "";
					string st_total_cancelado = "";
					string st_csv_subtotal = "";
					string st_csv_subtotal_cancelado = "";
					
					ArrayList lstTerminais = new ArrayList();
					
					dlgStatus stat = new dlgStatus ( "Relatório" );
					
					stat.LblActivity.Text = "Processando relatório no servidor";
					stat.Show();
					Application.DoEvents();
					
					if ( !var_exchange.fetch_rel_2_rlt (	ctrl_TxtLoja.getTextBoxValue(),
										                 	var_util.GetDataBaseTimeFormat ( ctrl_TxtDtIni.getTextBoxValue_Date() ),
										                 	var_util.GetDataBaseTimeFormat ( ctrl_TxtDtFim.getTextBoxValue_Date().AddDays(1) ),
										                 	ctrl_TxtEmpresa.getTextBoxValue().PadLeft ( 6, '0' ),
										                 	ref header, 
										                 	ref st_total, 
										                 	ref st_total_cancelado,
										                 	ref st_csv_subtotal,
										                    ref st_csv_subtotal_cancelado,
										                    ref st_csv,
										                    ref st_empresa,
										                   	ref lstTerminais ) )
                 	{
						stat.Close();
						return false;                 		
                 	}
					
					
					stat.LblActivity.Text = "Buscando dados do relatório";
					Application.DoEvents();
					
					ArrayList full_memory = new ArrayList();
						
					while ( st_csv != "" )
					{
						ArrayList tmp_memory  = new ArrayList();
						
						if ( var_exchange.fetch_memory ( st_csv, "400", ref st_csv, ref tmp_memory ) )
							for ( int t=0; t < tmp_memory.Count; ++t )
								full_memory.Add ( tmp_memory[t] );
					}
					
					money money_helper = new money();
					
					ArrayList  desc    = new TipoConfirmacaoDesc().GetArray();
					ArrayList  desc_op = new OperacaoCartaoDesc().GetArray();
					
					stat.LblActivity.Text = "Gerando relatório para web";
					Application.DoEvents();
					
					stat.pgStatus.Maximum = lstTerminais.Count;
					stat.pgStatus.Minimum = 0;
					
					for ( int g=0; g < lstTerminais.Count; ++g )
					{
						stat.pgStatus.Value = g + 1;
						
						Application.DoEvents();

						DadosTerminal dt = new DadosTerminal ( lstTerminais[g] as DataPortable );
						
						lstMessages.Add   ( "Terminal: " + dt.get_st_terminal() + " " + dt.get_st_localizacao() );
	
						lstTableSizes.Add ( 950 );
						
						ArrayList lst_sub_tbl_head = new ArrayList();
						
						lst_sub_tbl_head.Add ( "Cartão" );
						lst_sub_tbl_head.Add ( "NSU" );
						lst_sub_tbl_head.Add ( "Valor Total R$" );
						lst_sub_tbl_head.Add ( "Parcelas" );
						lst_sub_tbl_head.Add ( "Data e Hora" );
						lst_sub_tbl_head.Add ( "Status" );
						lst_sub_tbl_head.Add ( "Operação" );
						
						lstHeader.Add ( lst_sub_tbl_head );
						
						ArrayList my_term_cont = new ArrayList();
						
						for ( int t=0; t < full_memory.Count; ++t )
						{
							Rel_RLT rel_line = new Rel_RLT ( full_memory[t] as DataPortable );
							
							if ( rel_line.get_st_terminal() != dt.get_st_terminal() )
							    continue;
							
							ArrayList lst_sub_content = new ArrayList();
							
							lst_sub_content.Add ( rel_line.get_st_cartao() );
							lst_sub_content.Add ( rel_line.get_st_nsu() 							);
							lst_sub_content.Add ( money_helper.formatToMoney ( rel_line.get_vr_total() ) 	);
							lst_sub_content.Add ( rel_line.get_nu_parc() 											);
							lst_sub_content.Add ( var_util.getDDMMYYYY_format ( rel_line.get_dt_trans() )			);
							lst_sub_content.Add ( desc [ Convert.ToInt32 ( rel_line.get_tg_status() ) ].ToString() );
							
							if ( rel_line.get_st_motivo().Length > 0 )
								lst_sub_content.Add ( rel_line.get_st_motivo() + " - " + desc_op [ Convert.ToInt32 ( rel_line.get_en_op_cartao() ) ].ToString() );
							else
								lst_sub_content.Add ( desc_op [ Convert.ToInt32 ( rel_line.get_en_op_cartao() ) ].ToString() );
														
							my_term_cont.Add ( lst_sub_content );
						}			
						
						lstContent.Add ( my_term_cont );
						
						ArrayList lst_sub_foot = new ArrayList();
						
						var_util.indexCSV ( st_csv_subtotal );
						lst_sub_foot.Add ( "Sub-Total: R$ " 			+ money_helper.formatToMoney ( var_util.getCSV (g) ) );
						
						var_util.indexCSV ( st_csv_subtotal_cancelado );	
						lst_sub_foot.Add ( "Sub-Total cancelado: R$ " 	+ money_helper.formatToMoney ( var_util.getCSV (g) ) );
						
						if ( g == lstTerminais.Count -1 )
						{
							lst_sub_foot.Add ( "" );
							lst_sub_foot.Add ( "Total da loja no período: R$ " 				+ money_helper.formatToMoney ( st_total ) );
							lst_sub_foot.Add ( "Total cancelado da loja no período: R$ " 	+ money_helper.formatToMoney ( st_total_cancelado ) );
						}
						
						lstFooter.Add ( lst_sub_foot );						
					}
					
					stat.Close();
										
					SyCrafReport rel = new SyCrafReport ( "Relatório de Transações por loja",
					                               	"RLT", 
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
				
				#region - event_rel_4_repasse -
				
				case event_rel_4_repasse:
				{
					//InitEventCode event_rel_4_repasse
					
					bool IsDone = true;
					
					if ( !ctrl_TxtEmpresa.IsUserValidated )	
					{	
						ctrl_TxtEmpresa.SetErrorMessage ( "O número da empresa deve ser informado" );
						IsDone = false;	
					}
					
					if ( !ctrl_TxtDtIni.IsUserValidated )	
					{	
						ctrl_TxtDtIni.SetErrorMessage ( "A data inicial de repasse deve ser informada corretamente" );	
						IsDone = false;	
					}
					
					if ( !ctrl_TxtDtFim.IsUserValidated )	
					{	
						ctrl_TxtDtFim.SetErrorMessage ( "A data fnal de repasse deve ser informada corretamente" );	
						IsDone = false;	
					}


					if ( !IsDone )
						return false;
					
					// ##############################
					// # SETUP LISTS ################
					// ##############################
					
					ArrayList lstHeader 	= new ArrayList();
					ArrayList lstContent 	= new ArrayList();
					ArrayList lstTableSizes = new ArrayList();
					ArrayList lstFooter 	= new ArrayList();
					ArrayList lstMessages 	= new ArrayList();
					ArrayList lstFilters 	= new ArrayList();
					
					// ##############################
					// # CUSTOMIZE
					// ##############################
					
					string st_csv_contents	 	 = "";
					string st_nome_empresa 	 	 = "";
					string st_csv_lojas		 	 = "";
					string st_csv_subtotal 	 	 = "";
					string st_csv_subtotal_geral = "";
					string st_total 		 	 = "";
					string st_csv_nome_lojas 	 = "";
					string st_total_geral	 	 = "";
					
					dlgStatus stat = new dlgStatus ( "Relatório" );
					
					stat.LblActivity.Text = "Processando relatório no servidor";
					stat.Show();
					Application.DoEvents();
					
					if ( !var_exchange.fetch_rel_4_rrp ( ctrl_TxtEmpresa.getTextBoxValue().PadLeft ( 6, '0' ),
					                                     ctrl_TxtDtIni.getTextBoxValue(),
					                                     ctrl_TxtDtFim.getTextBoxValue(),
					                                     ref header,
					                                     ref st_csv_contents,
											             ref st_nome_empresa,
														 ref st_csv_lojas,
														 ref st_csv_subtotal,
														 ref st_total,
														 ref st_csv_nome_lojas,
														 ref st_csv_subtotal_geral,
														 ref st_total_geral ) )
					{
						stat.Close();
						return false;
					}
					                       
					#region - PREP INDEXING  -
					
					Hashtable hsh_lojas         = new Hashtable();
					Hashtable hsh_sub_tot_lojas = new Hashtable();
					
					int tot_lojas = var_util.indexCSV ( st_csv_lojas );
					
					for ( int t=0; t < tot_lojas; ++t )
					{
						string tag = var_util.getCSV ( t );
						
						hsh_lojas 			[ tag ] = new ArrayList();
						hsh_sub_tot_lojas  	[ tag ] = (long) 0;
					}
					
					#endregion
					
					stat.LblActivity.Text = "Buscando dados do relatório";
					Application.DoEvents();
					
					#region - SETUP INDEXING -
					{
						ArrayList full_memory = new ArrayList();
							
						while ( st_csv_contents != "" )
						{
							ArrayList tmp_memory  = new ArrayList();
							
							if ( var_exchange.fetch_memory ( st_csv_contents, "400", ref st_csv_contents, ref tmp_memory ) )
								for ( int t=0; t < tmp_memory.Count; ++t )
									full_memory.Add ( tmp_memory[t] );
						}
						
						for ( int t=0; t < full_memory.Count; ++t )
						{
							DadosRepasse 	rel_line = new DadosRepasse ( full_memory[t] as DataPortable );
							ArrayList 		tmp      = hsh_lojas [ rel_line.get_st_loja() ] as ArrayList;
							
							tmp.Add ( rel_line ); 
						}
					}					
					#endregion
					
					money money_helper = new money();
					
					ApplicationUtil var_util_nome     = new ApplicationUtil();
					ApplicationUtil var_util_subTotal = new ApplicationUtil();
					ApplicationUtil var_util_subTotal_geral = new ApplicationUtil();
										
					tot_lojas = var_util.indexCSV 			( st_csv_lojas 		);
					tot_lojas = var_util_nome.indexCSV 		( st_csv_nome_lojas );
					tot_lojas = var_util_subTotal.indexCSV 	( st_csv_subtotal 	);
					
					var_util_subTotal_geral.indexCSV ( st_csv_subtotal_geral );
					
					stat.LblActivity.Text = "Gerando relatório para web";
					Application.DoEvents();
					
					stat.pgStatus.Maximum = tot_lojas;
					stat.pgStatus.Minimum = 0;
					
					for ( int t=0; t < tot_lojas; ++t )
					{
						stat.pgStatus.Value = t + 1;
						
						Application.DoEvents();
						
						string tag  = var_util.getCSV 		(t);
						string nome = var_util_nome.getCSV 	(t);
						
						ArrayList sub_loja_content  = hsh_lojas [ tag ] as ArrayList;
						
						ArrayList lst_sub_foot = new ArrayList();
						
						ArrayList my_line_container = new ArrayList();
						
						lstMessages.Add   ( "Loja: (" + tag + ") " + nome );

						lstTableSizes.Add ( 950 );
						
						ArrayList lst_sub_tbl_head = new ArrayList();
						
						lst_sub_tbl_head.Add ( "NSU" 				);
						lst_sub_tbl_head.Add ( "Cartão" 			);
						lst_sub_tbl_head.Add ( "Data Venda" 		);
						lst_sub_tbl_head.Add ( "Data Repasse" 		);
						lst_sub_tbl_head.Add ( "Repasse R$" 		);
						lst_sub_tbl_head.Add ( "Valor Total R$" 	);
						
						lstHeader.Add ( lst_sub_tbl_head );
						
						for ( int h=0; h < sub_loja_content.Count; ++h )
						{
							DadosRepasse  rel_line = new DadosRepasse ( sub_loja_content[h] as DataPortable );
							
							ArrayList lst_line_content = new ArrayList();

							lst_line_content.Add ( rel_line.get_st_nsu() );
							lst_line_content.Add ( rel_line.get_st_cartao() 		);
							lst_line_content.Add ( var_util.getDDMMYYYY_format ( rel_line.get_dt_trans() )					);
							lst_line_content.Add ( var_util.getDDMMYYYY_format ( rel_line.get_dt_repasse() ).Substring (0,10) );
							lst_line_content.Add ( money_helper.formatToMoney ( rel_line.get_vr_repasse() ) 	);
							lst_line_content.Add ( money_helper.formatToMoney ( rel_line.get_vr_total() ) 		);
														
							my_line_container.Add ( lst_line_content );
						}			
						
						lstContent.Add ( my_line_container );
													
						lst_sub_foot.Add ( "Sub-Total Repasse: R$ " + money_helper.formatToMoney ( var_util_subTotal.getCSV (t) ) );
						lst_sub_foot.Add ( "Sub-Total Geral: R$ " + money_helper.formatToMoney ( var_util_subTotal_geral.getCSV (t) ) );
						
						if ( t == tot_lojas - 1 )
						{
							long tx = Convert.ToInt64 ( st_total_geral ) -  Convert.ToInt64 ( st_total );
							
							lst_sub_foot.Add ( "" );
							lst_sub_foot.Add ( "Total Geral de Vendas: R$ " + money_helper.formatToMoney ( st_total_geral ) );
							lst_sub_foot.Add ( "Total Geral de taxa de administração: R$ " + money_helper.formatToMoney ( tx.ToString() ) );
							lst_sub_foot.Add ( "Total Repasse: R$ " + money_helper.formatToMoney ( st_total ) );
						}
						
						lstFooter.Add ( lst_sub_foot );			
					}
					
					stat.Close();
					
					SyCrafReport rel = new SyCrafReport ( "Relatório de previsão de repasses financeiros para lojistas",
					                               	"RRL", 
					                               	st_nome_empresa,
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
				
				#region - event_rel_5_empresaLoja -
				
				case event_rel_5_empresaLoja:
				{
					//InitEventCode event_rel_5_empresaLoja
					
					bool IsDone = true;
					
					if ( !ctrl_TxtEmpresa.IsUserValidated )	
					{	
						ctrl_TxtEmpresa.SetErrorMessage ( "O número da empresa deve ser informado" );
						IsDone = false;	
					}
					
					if ( !ctrl_TxtDtIni.IsUserValidated )	{	ctrl_TxtDtIni.SetErrorMessage 		( "A data inicial deve ser informada corretamente" );	IsDone = false;	}
					if ( !ctrl_TxtDtFim.IsUserValidated )	{	ctrl_TxtDtFim.SetErrorMessage 		( "A data final deve ser informada corretamente" );	IsDone = false;	}
					
					if ( !IsDone )
						return false;
					
					i_Form.BtnConfirmar.Enabled = false;
					
					// ##############################
					// # SETUP LISTS ################
					// ##############################
					
					ArrayList lstHeader 	= new ArrayList();
					ArrayList lstContent 	= new ArrayList();
					ArrayList lstTableSizes = new ArrayList();
					ArrayList lstFooter 	= new ArrayList();
					ArrayList lstMessages 	= new ArrayList();
					ArrayList lstFilters 	= new ArrayList();
					
					// ##############################
					// # CUSTOMIZE
					// ##############################
					
					string st_block 				 = "";
					string st_empresa 				 = "";
					string st_total 				 = "";
					string st_total_cancelado 		 = "";
					string st_csv_subtotal 			 = "";
					string st_csv_subtotal_cancelado = "";
					
					ArrayList lstLojas = new ArrayList();
					
					i_Form.Visible = false;
					
					dlgStatus stat = new dlgStatus ( "Relatório" );
					
					stat.LblActivity.Text = "Processando relatório no servidor";
					stat.Show();
					Application.DoEvents();
									
					if ( !var_exchange.fetch_rel_5_rle (	ctrl_TxtEmpresa.getTextBoxValue().PadLeft ( 6, '0' ),
										                 	var_util.GetDataBaseTimeFormat ( ctrl_TxtDtIni.getTextBoxValue_Date() ),
										                 	var_util.GetDataBaseTimeFormat ( ctrl_TxtDtFim.getTextBoxValue_Date().AddDays(1) ),
										                 	ref header, 
										                 	ref st_total, 
										                 	ref st_total_cancelado,
										                 	ref st_csv_subtotal,
										                    ref st_csv_subtotal_cancelado,
										                    ref st_block,
										                    ref st_empresa,
										                   	ref lstLojas ) )
                 	{
						stat.Close();
						return false;                 		
                 	}
					
					stat.LblActivity.Text = "Obtendo resultados";
					
					Application.DoEvents();
					
					ArrayList full_memory = new ArrayList();
										
					while ( st_block != "" )
					{
						ArrayList tmp_memory = new ArrayList();
						
						if ( var_exchange.fetch_memory ( st_block, "190", ref st_block, ref tmp_memory ) )
						{
							for ( int t=0; t < tmp_memory.Count; ++t )
								full_memory.Add ( tmp_memory[t] );
							
							tmp_memory.Clear();
						}
					}
					
					stat.LblActivity.Text = "Gerando relatório para web";
					
					Application.DoEvents();
					
					stat.pgStatus.Maximum = lstLojas.Count;
					stat.pgStatus.Minimum = 0;
														
					money money_helper = new money();
					
					ArrayList  desc    = new TipoConfirmacaoDesc().GetArray();
					ArrayList  desc_op = new OperacaoCartaoDesc().GetArray();
					
					long tot_trans = 0;
					
					for ( int g=0; g < lstLojas.Count; ++g )
					{
						stat.pgStatus.Value = g + 1;
						
						Application.DoEvents();
						
						DadosLoja dl = new DadosLoja ( lstLojas[g] as DataPortable );
						
						lstMessages.Add   ( "Loja: " + " " + dl.get_st_nome() );
	
						lstTableSizes.Add ( 950 );
						
						ArrayList lst_sub_tbl_head = new ArrayList();
						
						lst_sub_tbl_head.Add ( "Cartão" );
						lst_sub_tbl_head.Add ( "NSU" );
						lst_sub_tbl_head.Add ( "Valor Total R$" );
						lst_sub_tbl_head.Add ( "Parcelas" );
						lst_sub_tbl_head.Add ( "Data e Hora" );
						lst_sub_tbl_head.Add ( "Status" );
						lst_sub_tbl_head.Add ( "Operação" );
						
						lstHeader.Add ( lst_sub_tbl_head );
						
						ArrayList my_loja_cont = new ArrayList();
						
						for ( int t=0; t < full_memory.Count; ++t )
						{
							Rel_RLE rel_line = new Rel_RLE ( full_memory[t] as DataPortable );
							
							if ( rel_line.get_st_loja() != dl.get_st_loja() )
							    continue;
							
							ArrayList lst_sub_content = new ArrayList();
							
							lst_sub_content.Add ( rel_line.get_st_cartao() );
							lst_sub_content.Add ( rel_line.get_st_nsu() 							);
							lst_sub_content.Add ( money_helper.formatToMoney ( rel_line.get_vr_total() ) 	);
							lst_sub_content.Add ( rel_line.get_nu_parc() 											);
							lst_sub_content.Add ( var_util.getDDMMYYYY_format ( rel_line.get_dt_trans() )			);
							
							if ( rel_line.get_tg_status() == TipoConfirmacao.Cancelada )
								lst_sub_content.Add ( "** " + desc [ Convert.ToInt32 ( rel_line.get_tg_status() ) ].ToString() );
							else
								lst_sub_content.Add ( desc [ Convert.ToInt32 ( rel_line.get_tg_status() ) ].ToString() );

							string dsc = desc_op [ Convert.ToInt32 ( rel_line.get_en_op_cartao() ) ].ToString();
							
							if ( rel_line.get_st_motivo().Length > 0 )
								lst_sub_content.Add ( rel_line.get_st_motivo() + " - " + dsc );
							else
								lst_sub_content.Add ( dsc );
														
							++tot_trans;
							
							my_loja_cont.Add ( lst_sub_content );
						}			
						
						lstContent.Add ( my_loja_cont );
						
						ArrayList lst_sub_foot = new ArrayList();
						
						var_util.indexCSV ( st_csv_subtotal );
						lst_sub_foot.Add ( "Sub-Total da Loja: R$ " 			+ money_helper.formatToMoney ( var_util.getCSV (g) ) );
						
						var_util.indexCSV ( st_csv_subtotal_cancelado );	
						lst_sub_foot.Add ( "Sub-Total cancelado da Loja: R$ " 	+ money_helper.formatToMoney ( var_util.getCSV (g) ) );
						
						if ( g == lstLojas.Count -1 )
						{
							lst_sub_foot.Add ( "" );
							lst_sub_foot.Add ( "Total de transaçõess no período: " + tot_trans.ToString() );
							lst_sub_foot.Add ( "" );
							lst_sub_foot.Add ( "Total da empresa no período: R$ " 				+ money_helper.formatToMoney ( st_total ) );
							lst_sub_foot.Add ( "Total cancelado da empresa no período: R$ " 	+ money_helper.formatToMoney ( st_total_cancelado ) );
						}
						
						lstFooter.Add ( lst_sub_foot );						
					}
					
					stat.Close();
										
					SyCrafReport rel = new SyCrafReport ( "Relatório de transações efetuadas nas lojas",
					                               	"RLE", 
					                               	st_empresa,
					                               	ctrl_TxtDtIni.getTextBoxValue(),
					                               	ctrl_TxtDtFim.getTextBoxValue(),
					                               	ref lstHeader,
					                               	ref lstContent,
					                                ref lstTableSizes,
					                                ref lstFooter,
					                                ref lstMessages,
					                                ref lstFilters );
					
					i_Form.BtnConfirmar.Enabled = true;
					i_Form.Visible = true;
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_rel_6_fat -
				
				case event_rel_6_fat:
				{
					//InitEventCode event_rel_6_fat
					
					bool IsDone = true;
					
					if ( !ctrl_TxtDtIni.IsUserValidated )	{	ctrl_TxtDtIni.SetErrorMessage 		( "A data inicial deve ser informada corretamente" );	IsDone = false;	}
					if ( !ctrl_TxtDtFim.IsUserValidated )	{	ctrl_TxtDtFim.SetErrorMessage 		( "A data final deve ser informada corretamente" );	IsDone = false;	}
					
					if ( !IsDone )
						return false;
					
					i_Form.BtnConfirmar.Enabled = false;
					
					// ##############################
					// # SETUP LISTS ################
					// ##############################
					
					ArrayList lstHeader 	= new ArrayList();
					ArrayList lstContent 	= new ArrayList();
					ArrayList lstTableSizes = new ArrayList();
					ArrayList lstFooter 	= new ArrayList();
					ArrayList lstMessages 	= new ArrayList();
					ArrayList lstFilters 	= new ArrayList();
					
					// ##############################
					// # CUSTOMIZE
					// ##############################
					
					string output_st_total 					= "";
					string output_st_total_desconto 		= "";
					string output_st_csv_subtotal 			= "";
					string output_st_csv_subtotal_desconto 	= "";
					string output_st_content_block 			= "";
					string output_st_emp_loj_block 			= "";
					
					string output_CartaoAtiv 	= "";
					string output_Extras 		= "";
					string output_FixoTrans 	= "";
					string output_Percent 		= "";
					string output_TBM 			= "";
					
					i_Form.Visible = false;
					
					dlgStatus stat = new dlgStatus ( "Relatório" );
					
					stat.LblActivity.Text = "Processando relatório no servidor";
					stat.Show();
					Application.DoEvents();
									
					if ( !var_exchange.fetch_rel_6_fat (	var_util.GetDataBaseTimeFormat ( ctrl_TxtDtIni.getTextBoxValue_Date() ),
										                 	var_util.GetDataBaseTimeFormat ( ctrl_TxtDtFim.getTextBoxValue_Date().AddDays(1) ),
										                 	ref header,
										                 	ref output_st_total,
										                 	ref output_st_total_desconto,
										                 	ref output_st_csv_subtotal,
										                 	ref output_st_csv_subtotal_desconto,
										                 	ref output_st_content_block,
										                 	ref output_st_emp_loj_block, 
										                 	ref output_CartaoAtiv,
										                 	ref output_Extras,
															ref output_FixoTrans,
															ref output_Percent,
															ref output_TBM 				) )
                 	{
						stat.Close();
						return false;                 		
                 	}
					
					stat.LblActivity.Text = "Buscando detalhes de faturamento";
					Application.DoEvents();
					
					// index de todos os itens de cobrança
					Hashtable hsh_Memory = new Hashtable(); 
							
					while ( output_st_content_block != "" )
					{
						ArrayList tmp_memory = new ArrayList();
						
						if ( var_exchange.fetch_memory ( output_st_content_block, "200", 
						                                 ref output_st_content_block, 
						                                 ref tmp_memory ) )
						{
							for ( int t=0; t < tmp_memory.Count; ++t )
							{
								Rel_FAT f_t = new Rel_FAT ( tmp_memory [t] as DataPortable );
								
								if ( hsh_Memory [ f_t.get_fk_fatura() ] == null )
									hsh_Memory [ f_t.get_fk_fatura() ] = new ArrayList();
								
								ArrayList tmp = hsh_Memory [ f_t.get_fk_fatura() ] as ArrayList;
								
								tmp.Add ( f_t );
							}
						}
					}

					// lista de todas as empresas e lojas
					ArrayList full_memory_ent = new ArrayList(); 
					
					stat.LblActivity.Text = "Buscando lista de lojas e empresas";
					Application.DoEvents();
					
					while ( output_st_emp_loj_block != "" )
					{
						ArrayList tmp_memory = new ArrayList();
						
						if ( var_exchange.fetch_memory ( output_st_emp_loj_block, "200", 
						                                 ref output_st_emp_loj_block, 
						                                 ref tmp_memory ) )
						{
							for ( int t=0; t < tmp_memory.Count; ++t )
							{
								Entidade ent = new Entidade ( tmp_memory[t] as DataPortable );
								
								full_memory_ent.Add ( ent );
							}
						}
					}
					
					stat.LblActivity.Text = "Gerando relatório para web";
					Application.DoEvents();
					
					stat.pgStatus.Maximum = full_memory_ent.Count;
					stat.pgStatus.Minimum = 0;
														
					money money_helper = new money();
					
					// tradução do indice para texto
					ArrayList  desc = new TipoFatDesc().GetArray();
					
					// Passa por todas as empresas e lojas
					for ( int g=0; g < full_memory_ent.Count; ++g )
					{
						Entidade ent = full_memory_ent [g] as Entidade;
						
						stat.pgStatus.Value = g + 1;
						
						Application.DoEvents();
					
						// Sub-título
						lstMessages.Add   ( ent.get_st_nome() );
						lstTableSizes.Add ( 500 );
						
						ArrayList lst_sub_tbl_head = new ArrayList();
						
						lst_sub_tbl_head.Add ( "Descrição de item faturado" );
						lst_sub_tbl_head.Add ( "Valor Cobrança R$" );
						
						lstHeader.Add ( lst_sub_tbl_head );
						
						// Lista de items
						ArrayList my_cobranca = new ArrayList();
						
						// Obtem index da memoria
						ArrayList lstMemory = hsh_Memory [ ent.get_fk_fatura() ] as ArrayList;
						
						if ( lstMemory == null )
						{
							my_cobranca.Add ( new ArrayList() );							
						}
						else for ( int t=0; t < lstMemory.Count; ++t )
						{
							Rel_FAT f_t = lstMemory [t] as Rel_FAT;
							
							// Lista de items para uma linha
							ArrayList lst_sub_content = new ArrayList();
							
							string st_desc = "";
							string vr_cob  = "";
							
							switch ( f_t.get_tg_tipoFat() )
							{
								case TipoFat.Extras: 		st_desc = "Extra: " + f_t.get_st_extra();	break;
								case TipoFat.TBM:			st_desc = "Tarifa básica mensal";			break;
								case TipoFat.CartaoAtiv:	st_desc = "Tarifa por cartões ativos";  	break;
								case TipoFat.FixoTrans:		st_desc = "Valor sobre Transações"; 		break;
								case TipoFat.Percent:		st_desc = "Percentual sobre Transações";	break;
												
								default: break;
							}
							
							if ( f_t.get_tg_desconto() == Context.TRUE )
								vr_cob = "-" + f_t.get_vr_cob();
							else
								vr_cob = f_t.get_vr_cob();
							
							lst_sub_content.Add ( st_desc 								);
							lst_sub_content.Add ( money_helper.formatToMoney ( vr_cob )	);
																					
							my_cobranca.Add ( lst_sub_content );
						}	
						
						lstContent.Add ( my_cobranca );
						
						ArrayList lst_sub_foot = new ArrayList();
						
						var_util.indexCSV ( output_st_csv_subtotal );
						lst_sub_foot.Add ( "Sub-Total: R$ " + money_helper.formatToMoney ( var_util.getCSV (g) ) );
						
						var_util.indexCSV ( output_st_csv_subtotal_desconto );	
						lst_sub_foot.Add ( "Sub-Total desconto: R$ " 	+ money_helper.formatToMoney ( var_util.getCSV (g) ) );
						
						if ( g == full_memory_ent.Count -1 )
						{
							lst_sub_foot.Add ( "" );
							lst_sub_foot.Add ( "Total de faturamento no período: R$ " 				+ money_helper.formatToMoney ( output_st_total ) );
							lst_sub_foot.Add ( "Total em descontos no faturamento no período: R$ " 	+ money_helper.formatToMoney ( output_st_total_desconto ) );
							lst_sub_foot.Add ( "" );
							lst_sub_foot.Add ( "Valor em cartões ativos: " + money_helper.formatToMoney ( output_CartaoAtiv ) ); 
							lst_sub_foot.Add ( "Valor em despesas extras: " + money_helper.formatToMoney ( output_Extras ) ); 
							lst_sub_foot.Add ( "Valor fixo por transações: " + money_helper.formatToMoney ( output_FixoTrans ) ); 
							lst_sub_foot.Add ( "Valor por percentual em transações: " + money_helper.formatToMoney ( output_Percent ) ); 
							lst_sub_foot.Add ( "Valor em mensalidades: " + money_helper.formatToMoney ( output_TBM ) ); 
						}
						
						lstFooter.Add ( lst_sub_foot );						
					}
					
					stat.Close();
										
					SyCrafReport rel = new SyCrafReport ( "Relatório de faturamento pendente",
					                               	"RFP", 
					                               	"",
					                               	ctrl_TxtDtIni.getTextBoxValue(),
					                               	ctrl_TxtDtFim.getTextBoxValue(),
					                               	ref lstHeader,
					                               	ref lstContent,
					                                ref lstTableSizes,
					                                ref lstFooter,
					                                ref lstMessages,
					                                ref lstFilters );
					
					i_Form.BtnConfirmar.Enabled = true;
					i_Form.Visible = true;
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_rel_repEfetivo -
				
				case event_rel_repEfetivo:
				{
					//InitEventCode event_rel_repEfetivo
					
					bool IsDone = true;
					
					if ( !ctrl_TxtEmpresa.IsUserValidated )	
					{	
						ctrl_TxtEmpresa.SetErrorMessage ( "O número da empresa deve ser informado" );
						IsDone = false;	
					}
					
					if ( !ctrl_TxtDtIni.IsUserValidated )	
					{	
						ctrl_TxtDtIni.SetErrorMessage ( "A data inicial de repasse deve ser informada corretamente" );	
						IsDone = false;	
					}
					
					if ( !ctrl_TxtDtFim.IsUserValidated )	
					{	
						ctrl_TxtDtFim.SetErrorMessage ( "A data fnal de repasse deve ser informada corretamente" );	
						IsDone = false;	
					}

					if ( !IsDone )
						return false;
					
					// ##############################
					// # SETUP LISTS ################
					// ##############################
					
					ArrayList lstHeader 	= new ArrayList();
					ArrayList lstContent 	= new ArrayList();
					ArrayList lstTableSizes = new ArrayList();
					ArrayList lstFooter 	= new ArrayList();
					ArrayList lstMessages 	= new ArrayList();
					ArrayList lstFilters 	= new ArrayList();
					
					// ##############################
					// # CUSTOMIZE
					// ##############################
					
					string st_csv_contents	= "";
					string st_csv_pagto	 	= "";
					string st_nome_empresa 	= "";
					string st_csv_lojas		= "";
										
					dlgStatus stat = new dlgStatus ( "Relatório" );
					
					stat.LblActivity.Text = "Processando relatório no servidor";
					stat.Show();
					Application.DoEvents();
					
					if ( !var_exchange.fetch_rel_repEfetivo ( 	ctrl_TxtEmpresa.getTextBoxValue().PadLeft ( 6, '0' ),
							                                    var_util.GetDataBaseTimeFormat ( ctrl_TxtDtIni.getTextBoxValue_Date() ),
										                 		var_util.GetDataBaseTimeFormat ( ctrl_TxtDtFim.getTextBoxValue_Date().AddDays(1) ),
										                 		ctrl_TxtLoja.getTextBoxValue(),
										                 		ref header,
							                                    ref st_csv_contents,	// todos os detalhes
							                                    ref st_csv_pagto,		// como foi pago
													            ref st_nome_empresa,// obrigatorio (ex: ADM)
													            ref st_csv_lojas // lista de lojas
													           ) )
					{
						stat.Close();
						return false;
					}
					                       
					Hashtable hsh_lojas      = new Hashtable();
					Hashtable hsh_lojasPagto = new Hashtable();
													
					int tot_lojas = var_util.indexCSV ( st_csv_lojas );
					
					for ( int t=0; t < tot_lojas; ++t )
						hsh_lojas [ var_util.getCSV ( t ) ] = new ArrayList();
					
					// ordenando em memória os detalhes
					{
						ArrayList full_memory = new ArrayList();
							
						stat.LblActivity.Text = "Buscando detalhes de vendas dos lojistas";
						Application.DoEvents();
					
						while ( st_csv_contents != "" )
						{
							ArrayList tmp_memory  = new ArrayList();
							
							if ( var_exchange.fetch_memory ( st_csv_contents, "400", ref st_csv_contents, ref tmp_memory ) )
								for ( int t=0; t < tmp_memory.Count; ++t )
									full_memory.Add ( tmp_memory[t] );
						}
					
						for ( int t=0; t < full_memory.Count; ++t )
						{
							DadosRepasse 	rel_line = new DadosRepasse ( full_memory[t] as DataPortable );
							ArrayList 		tmp      = hsh_lojas [ rel_line.get_st_loja() ] as ArrayList;
							
							tmp.Add ( rel_line ); 
						}
						
						full_memory.Clear();
					}					
					
					// ordenando em memória os detalhes de pagamento
					{
						ArrayList full_memory = new ArrayList();
							
						stat.LblActivity.Text = "Buscando detalhes de pagamentos";
						Application.DoEvents();
					
						while ( st_csv_pagto != "" )
						{
							ArrayList tmp_memory  = new ArrayList();
							
							if ( var_exchange.fetch_memory ( st_csv_pagto, "400", ref st_csv_pagto, ref tmp_memory ) )
								for ( int t=0; t < tmp_memory.Count; ++t )
									full_memory.Add ( tmp_memory[t] );
						}
					
						for ( int t=0; t < full_memory.Count; ++t )
						{
							DadosPagtoRepasse d_pr = new DadosPagtoRepasse ( full_memory[t] as DataPortable );
							
							// Existe um registro para cada loja
							hsh_lojasPagto [ d_pr.get_st_loja() ] = d_pr;
						}
						
						full_memory.Clear();
					}
					
					money money_helper = new money();
					
					stat.LblActivity.Text = "Gerando relatório para web";
					Application.DoEvents();
					
					stat.pgStatus.Maximum = tot_lojas;
					stat.pgStatus.Minimum = 0;
					
					long vr_tot = 0;
					
					
					for ( int t=0; t < tot_lojas; ++t )
					{
						stat.pgStatus.Value = t + 1;
						
						Application.DoEvents();
						
						string tag = var_util.getCSV 	(t);
						
						lstMessages.Add ( "Loja: " + tag );

						lstTableSizes.Add ( 650 );
						
						ArrayList lst_sub_tbl_head = new ArrayList();
						
						lst_sub_tbl_head.Add ( "NSU" 		);
						lst_sub_tbl_head.Add ( "Cartão" 	);
						lst_sub_tbl_head.Add ( "Data Venda" );
						lst_sub_tbl_head.Add ( "Venda R$" 	);
						lst_sub_tbl_head.Add ( "Repasse R$" );
					
						long vr_tot_orig = 0;
												
						lstHeader.Add ( lst_sub_tbl_head );
							
						ArrayList my_line_container = new ArrayList();
						ArrayList sub_loja_content  = hsh_lojas [ tag ] as ArrayList;
						
						for ( int h=0; h < sub_loja_content.Count; ++h )
						{
							DadosRepasse  rel_line = new DadosRepasse ( sub_loja_content[h] as DataPortable );
							
							ArrayList lst_line_content = new ArrayList();

							lst_line_content.Add ( rel_line.get_st_nsu() 										);
							lst_line_content.Add ( rel_line.get_st_cartao() 									);
							lst_line_content.Add ( var_util.getDDMMYYYY_format ( rel_line.get_dt_trans() 	)	);
							lst_line_content.Add ( money_helper.formatToMoney ( rel_line.get_vr_total() 	) 	);
							lst_line_content.Add ( money_helper.formatToMoney ( rel_line.get_vr_repasse() 	) 	);							
							
							vr_tot_orig += money_helper.getNumericValue ( rel_line.get_vr_total() );
														
							my_line_container.Add ( lst_line_content );
						}			
						
						lstContent.Add ( my_line_container );
						
						ArrayList lst_sub_foot = new ArrayList();
						
						DadosPagtoRepasse dpr = hsh_lojasPagto [ tag ] as DadosPagtoRepasse;
						
						string pagamento = "Depósito";
						
						if ( dpr.get_tg_opcao() == TipoPagamento.Dinheiro )
							pagamento = "Dinheiro";
						else if ( dpr.get_tg_opcao() == TipoPagamento.Cheque )
							pagamento = "Cheque";
						
						vr_tot += Convert.ToInt64 ( dpr.get_vr_valor() );
						
						lst_sub_foot.Add ( "Data Pagto: " 		+ var_util.getDDMMYYYY_format ( dpr.get_dt_pagto() ) );
						lst_sub_foot.Add ( "Pagamento: " 		+ pagamento 			);						
						lst_sub_foot.Add ( "Valor Total de venda: R$ " 		+ money_helper.formatToMoney ( vr_tot_orig.ToString() ) );
						lst_sub_foot.Add ( "Valor Total de repasse: R$ " 		+ money_helper.formatToMoney ( dpr.get_vr_valor() ) );
						
						if ( dpr.get_tg_opcao() != TipoPagamento.Dinheiro )
							lst_sub_foot.Add ( "Informação Extra: " + dpr.get_st_extra() 	);
												
						if ( t == tot_lojas - 1 )
						{
							lst_sub_foot.Add ( "" );
							lst_sub_foot.Add ( "Total de repasses no período: R$ " + money_helper.formatToMoney ( vr_tot.ToString() ) );
						}
						
						lstFooter.Add ( lst_sub_foot );			
					}
					
					stat.Close();
					
					SyCrafReport rel = new SyCrafReport ( "Relatório de pagamento efetivo para lojistas",
					                               	"RPE", 
					                               	st_nome_empresa,
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
				
				#region - event_rel_fechCaixa -
				
				case event_rel_fechCaixa:
				{
					//InitEventCode event_rel_fechCaixa
					
					bool IsDone = true;
					
					if ( !ctrl_TxtEmpresa.IsUserValidated )	
					{	
						ctrl_TxtEmpresa.SetErrorMessage ( "O número da empresa deve ser informado" );
						IsDone = false;	
					}
					
					if ( !ctrl_TxtDtIni.IsUserValidated )	
					{	
						ctrl_TxtDtIni.SetErrorMessage ( "A data inicial de fechamento deve ser informada corretamente" );	
						IsDone = false;	
					}
					
					if ( !ctrl_TxtDtFim.IsUserValidated )	
					{	
						ctrl_TxtDtFim.SetErrorMessage ( "A data fnal de fechamento deve ser informada corretamente" );	
						IsDone = false;	
					}

					if ( !IsDone )
						return false;
					
					// ##############################
					// # SETUP LISTS ################
					// ##############################
					
					ArrayList lstHeader 	= new ArrayList();
					ArrayList lstContent 	= new ArrayList();
					ArrayList lstTableSizes = new ArrayList();
					ArrayList lstFooter 	= new ArrayList();
					ArrayList lstMessages 	= new ArrayList();
					ArrayList lstFilters 	= new ArrayList();
					
					// ##############################
					// # CUSTOMIZE
					// ##############################
					
					string st_csv_contents	= "";
					string st_nome_empresa 	= "";
					
					ArrayList lstQuiosques = new ArrayList();
										
					dlgStatus stat = new dlgStatus ( "Relatório" );
					
					stat.LblActivity.Text = "Processando relatório no servidor";
					stat.Show();
					Application.DoEvents();
					
					if ( !var_exchange.fetch_rel_fechCaixa ( 	ctrl_TxtEmpresa.getTextBoxValue().PadLeft ( 6, '0' ),
							                                    var_util.GetDataBaseTimeFormat ( ctrl_TxtDtIni.getTextBoxValue_Date() ),
										                 		var_util.GetDataBaseTimeFormat ( ctrl_TxtDtFim.getTextBoxValue_Date().AddDays(1) ),
							                                    ref header,
							                                    ref st_csv_contents,	// todos os detalhes
													            ref st_nome_empresa,	// obrigatorio (ex: ADM)
													            ref lstQuiosques 		// lista de quiosques
													           ) )
					{
						stat.Close();
						return false;
					}
					                       
					Hashtable hsh_quiosques = new Hashtable();
					
					for ( int t=0; t < lstQuiosques.Count; ++t )
					{
						DadosQuiosque 	dq = new DadosQuiosque ( lstQuiosques[t] as DataPortable );
						
						hsh_quiosques [ dq.get_st_nome() ] = new ArrayList();
					}
					
					// indexando vendas
					{
						ArrayList full_memory = new ArrayList();
							
						stat.LblActivity.Text = "Buscando detalhes...";
						Application.DoEvents();
					
						while ( st_csv_contents != "" )
						{
							ArrayList tmp_memory  = new ArrayList();
							
							if ( var_exchange.fetch_memory ( st_csv_contents, "400", ref st_csv_contents, ref tmp_memory ) )
								for ( int t=0; t < tmp_memory.Count; ++t )
									full_memory.Add ( tmp_memory[t] );
						}
					
						for ( int t=0; t < full_memory.Count; ++t )
						{
							DadosFechCaixa 	rel_line = new DadosFechCaixa ( full_memory[t] as DataPortable );
							ArrayList 		tmp      = hsh_quiosques [ rel_line.get_st_quiosque() ] as ArrayList;
							
							tmp.Add ( rel_line ); 
						}
						
						full_memory.Clear();
					}					
					
					money money_helper = new money();
					
					stat.LblActivity.Text = "Gerando relatório para web";
					Application.DoEvents();
					
					stat.pgStatus.Maximum = lstQuiosques.Count;
					stat.pgStatus.Minimum = 0;
					
					long 	tot_dinheiro = 0, 
						 	tot_cheque = 0, 
						 	tot_cartao = 0,
						 	tot_canc = 0;
					
					for ( int t=0; t < lstQuiosques.Count; ++t )
					{
						stat.pgStatus.Value = t + 1;
						
						Application.DoEvents();
						
						DadosQuiosque 	dq = new DadosQuiosque ( lstQuiosques[t] as DataPortable );
						
						string tag = dq.get_st_nome();
						
						lstMessages.Add ( "Quiosque: " + tag );

						lstTableSizes.Add ( 850 );
						
						ArrayList lst_sub_tbl_head = new ArrayList();
						
						lst_sub_tbl_head.Add ( "Vendedor" 		);
						lst_sub_tbl_head.Add ( "Data" 			);
						lst_sub_tbl_head.Add ( "Cartão" 		);
						lst_sub_tbl_head.Add ( "Crédito R$" 	);
						lst_sub_tbl_head.Add ( "Tarifa R$" 		);
						lst_sub_tbl_head.Add ( "Produtos R$" 	);
						lst_sub_tbl_head.Add ( "Total R$" 		);
						lst_sub_tbl_head.Add ( "Extra" 			);
												
						lstHeader.Add ( lst_sub_tbl_head );
							
						ArrayList my_line_container = new ArrayList();
						ArrayList sub_quiosque_content  = hsh_quiosques [ tag ] as ArrayList;
						
						long 	sub_tot_dinheiro = 0, 
						 	 	sub_tot_cheque = 0, 
						 	 	sub_tot_cartao = 0,
						 	 	sub_tot_canc = 0;
						 	 	
						ArrayList lst_Sort = new ArrayList();
						
						for ( int h=0; h < sub_quiosque_content.Count; ++h )
						{
							DadosFechCaixa  rel_line = new DadosFechCaixa ( sub_quiosque_content[h] as DataPortable );
							
							lst_Sort.Add ( rel_line.get_dt_venda() );
						}
						
						lst_Sort.Sort();
						
						for ( int l = 0; l < lst_Sort.Count; ++l )
						{
							string dta = lst_Sort[l].ToString();
							
							for ( int h=0; h < sub_quiosque_content.Count; ++h )
							{
								DadosFechCaixa  rel_line = new DadosFechCaixa ( sub_quiosque_content[h] as DataPortable );
								
								if ( rel_line.get_dt_venda() != dta )
									continue;
								
								ArrayList lst_line_content = new ArrayList();
	
								lst_line_content.Add ( rel_line.get_st_vendedor() );
								lst_line_content.Add ( var_util.getDDMMYYYY_format ( rel_line.get_dt_venda() ) );
								lst_line_content.Add ( rel_line.get_st_cartao() );
								lst_line_content.Add ( money_helper.formatToMoney ( rel_line.get_vr_credito() ) );
								lst_line_content.Add ( money_helper.formatToMoney ( rel_line.get_vr_tarifa() ) );
								lst_line_content.Add ( money_helper.formatToMoney ( rel_line.get_vr_prods() ) );
								
								long sum =  Convert.ToInt64 ( rel_line.get_vr_credito() ) + 
											Convert.ToInt64 ( rel_line.get_vr_tarifa() ) + 
											Convert.ToInt64 ( rel_line.get_vr_prods() );
									   
								lst_line_content.Add ( money_helper.formatToMoney ( sum.ToString() ) );
								
								if ( rel_line.get_tg_pagto() == TipoPagamento.Cheque )
									lst_line_content.Add ( "(Cheque) " + rel_line.get_st_extra() );
								else if ( rel_line.get_tg_pagto() == TipoPagamento.Cartao )
									lst_line_content.Add ( "(Cartão) " + rel_line.get_st_extra() );
								else 
									lst_line_content.Add ( rel_line.get_st_extra() );
								
								if ( rel_line.get_tg_pagto() == TipoPagamento.Dinheiro )
									sub_tot_dinheiro += sum;
								else if ( rel_line.get_tg_pagto() == TipoPagamento.Cheque )
									sub_tot_cheque += sum;
								else if ( rel_line.get_tg_pagto() == TipoPagamento.Cartao )
									sub_tot_cartao += sum;
								else 
									sub_tot_canc += sum;								
								
								my_line_container.Add ( lst_line_content );
							}			
						}
						
						lstContent.Add ( my_line_container );
						
						ArrayList lst_sub_foot = new ArrayList();
						
						lst_sub_foot.Add ( "Quiosque totalização em dinheiro: "+ money_helper.formatToMoney ( sub_tot_dinheiro.ToString() ) );
						lst_sub_foot.Add ( "Quiosque totalização em cheque: " + money_helper.formatToMoney ( sub_tot_cheque.ToString() ) );
						lst_sub_foot.Add ( "Quiosque totalização em cartao: " + money_helper.formatToMoney ( sub_tot_cartao.ToString() ) );
						lst_sub_foot.Add ( "Quiosque totalização em cancelados: " + money_helper.formatToMoney ( sub_tot_canc.ToString() ) );
						
						tot_dinheiro += sub_tot_dinheiro;
						tot_cheque 	 += sub_tot_cheque;
						tot_cartao   += sub_tot_cartao;
						tot_canc     += sub_tot_canc;
												
						if ( t == lstQuiosques.Count - 1 )
						{
							lst_sub_foot.Add ( "" );
							lst_sub_foot.Add ( "Total em dinheiro: R$ " + money_helper.formatToMoney ( tot_dinheiro.ToString() ) );
							lst_sub_foot.Add ( "Total em cheque: R$ " + money_helper.formatToMoney ( tot_cheque.ToString() ) );
							lst_sub_foot.Add ( "Total em cartao: R$ " + money_helper.formatToMoney ( tot_cartao.ToString() ) );
							lst_sub_foot.Add ( "Total em cancelados: R$ " + money_helper.formatToMoney ( tot_canc.ToString() ) );
							lst_sub_foot.Add ( "" );
							
							long vr_tot = tot_dinheiro + tot_cheque + tot_cartao;
							
							lst_sub_foot.Add ( "Total: R$ " + money_helper.formatToMoney ( vr_tot.ToString() ) );
						}
						
						lstFooter.Add ( lst_sub_foot );			
					}
					
					stat.Close();
					
					SyCrafReport rel = new SyCrafReport ( "Relatório de fechamento de caixa por quiosque",
					                               	"RFC", 
					                               	st_nome_empresa,
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
				
				#region - event_rel_dirCont -
				
				case event_rel_dirCont:
				{
					//InitEventCode event_rel_dirCont

					bool IsDone = true;
					
					if ( !ctrl_TxtEmpresa.IsUserValidated )	
					{	
						ctrl_TxtEmpresa.SetErrorMessage ( "O número da empresa deve ser informado" );
						IsDone = false;	
					}
					
					if ( !ctrl_TxtDtIni.IsUserValidated )	
					{	
						ctrl_TxtDtIni.SetErrorMessage ( "A data inicial de fechamento deve ser informada corretamente" );	
						IsDone = false;	
					}

					if ( !IsDone )
						return false;
					
					// ##############################
					// # SETUP LISTS ################
					// ##############################
					
					ArrayList lstHeader 	= new ArrayList();
					ArrayList lstContent 	= new ArrayList();
					ArrayList lstTableSizes = new ArrayList();
					ArrayList lstFooter 	= new ArrayList();
					ArrayList lstMessages 	= new ArrayList();
					ArrayList lstFilters 	= new ArrayList();
					
					// ##############################
					// # CUSTOMIZE
					// ##############################
					
					string st_csv_contents	= "";
					string st_nome_empresa 	= "";
					
					ArrayList lstQuiosques = new ArrayList();
										
					dlgStatus stat = new dlgStatus ( "Relatório" );
					
					stat.LblActivity.Text = "Processando relatório no servidor";
					stat.Show();
					Application.DoEvents();
					
					DadosSinteticoContGift dsg = new DadosSinteticoContGift();
					
					if ( !var_exchange.fetch_rel_dirCont ( 	ctrl_TxtEmpresa.getTextBoxValue().PadLeft ( 6, '0' ),
							                                var_util.GetDataBaseTimeFormat ( ctrl_TxtDtIni.getTextBoxValue_Date() ),
										                 	var_util.GetDataBaseTimeFormat ( ctrl_TxtDtIni.getTextBoxValue_Date().AddDays(1) ),
						                                    ref header,
						                                    ref st_csv_contents,	// todos os detalhes
												            ref st_nome_empresa,	// obrigatorio (ex: ADM)
												            ref dsg
												           ) )
					{
						stat.Close();
						return false;
					}
					                       
					ArrayList full_memory = new ArrayList();
						
					stat.LblActivity.Text = "Buscando detalhes...";
					Application.DoEvents();
				
					while ( st_csv_contents != "" )
					{
						ArrayList tmp_memory  = new ArrayList();
						
						if ( var_exchange.fetch_memory ( st_csv_contents, "150", ref st_csv_contents, ref tmp_memory ) )
							for ( int t=0; t < tmp_memory.Count; ++t )
								full_memory.Add ( tmp_memory[t] );
					}
				
					money money_helper = new money();
					
					stat.LblActivity.Text = "Gerando relatório para web";
					Application.DoEvents();
					
					stat.pgStatus.Maximum = full_memory.Count;
					stat.pgStatus.Minimum = 0;
					
					lstMessages.Add ( "Informações referentes ao período" );

					lstTableSizes.Add ( 350 );
					
					ArrayList lst_sub_tbl_head = new ArrayList();
					
					lst_sub_tbl_head.Add ( "Item" 		);
					lst_sub_tbl_head.Add ( "Total" 		);
											
					lstHeader.Add ( lst_sub_tbl_head );
												
					ArrayList my_line_container = new ArrayList();
					
					for ( int t=0; t < full_memory.Count; ++t )
					{
						stat.pgStatus.Value = t + 1;
						
						Application.DoEvents();
						
						DadosContabilGift  rel_line = new DadosContabilGift ( full_memory[t] as DataPortable );
							
						ArrayList lst_line_content = new ArrayList();

						lst_line_content.Add ( rel_line.get_st_item() );
						lst_line_content.Add ( rel_line.get_nu_valor() );
						
						my_line_container.Add ( lst_line_content );
					}
					
					lstContent.Add ( my_line_container );
						
					ArrayList lst_sub_foot = new ArrayList();
						
					lst_sub_foot.Add ( "Sintético Administrativo" 																		);
					lst_sub_foot.Add ( "    Total em carga: R$ " 			  + money_helper.formatToMoney ( dsg.get_vr_tot_carga() ) 	);
					lst_sub_foot.Add ( "    Total em tarifa de carga: R$ "    + money_helper.formatToMoney ( dsg.get_vr_tot_tarifa() ) 	);
					lst_sub_foot.Add ( "" 																								);
					lst_sub_foot.Add ( "Sintético Lojista" 																				);
					lst_sub_foot.Add ( "    Total em compras: R$ " 			  + money_helper.formatToMoney ( dsg.get_vr_tot_compras() ) );
					lst_sub_foot.Add ( "    Total em taxa aministrativa: R$ " + money_helper.formatToMoney ( dsg.get_vr_tot_tx() ) 		);
					lst_sub_foot.Add ( "    Total em repasse: R$ " 			  + money_helper.formatToMoney ( dsg.get_vr_tot_repasse() ) );
					lst_sub_foot.Add ( "" 																								);							
				
					lstFooter.Add ( lst_sub_foot );			
				
					stat.Close();
					
					SyCrafReport rel = new SyCrafReport ( "Relatório de contábil diário",
					                               	"RCD", 
					                               	st_nome_empresa,
					                               	ctrl_TxtDtIni.getTextBoxValue(),
					                               	"",
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
				
				#region - event_BtnConfirmarClick -
				
				case event_BtnConfirmarClick:
				{
					//InitEventCode event_BtnConfirmarClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_rel_residuo -
				
				case event_rel_residuo:
				{
					//InitEventCode event_rel_residuo
					
					bool IsDone = true;
					
					if ( !ctrl_TxtEmpresa.IsUserValidated )	
					{	
						ctrl_TxtEmpresa.SetErrorMessage ( "O número da empresa deve ser informado" );
						IsDone = false;	
					}
					
					if ( !IsDone )
						return false;
					
					i_Form.BtnConfirmar.Enabled = false;
					
					// ##############################
					// # SETUP LISTS ################
					// ##############################
					
					ArrayList lstHeader 	= new ArrayList();
					ArrayList lstContent 	= new ArrayList();
					ArrayList lstTableSizes = new ArrayList();
					ArrayList lstFooter 	= new ArrayList();
					ArrayList lstMessages 	= new ArrayList();
					ArrayList lstFilters 	= new ArrayList();
					
					// ##############################
					// # CUSTOMIZE
					// ##############################
					
					string st_block 				 = "";
					string st_empresa 				 = "";
					
					ArrayList lstLojas = new ArrayList();
					
					i_Form.Visible = false;
					
					dlgStatus stat = new dlgStatus ( "Relatório" );
					
					stat.LblActivity.Text = "Processando relatório no servidor";
					stat.Show();
					Application.DoEvents();
									
					if ( !var_exchange.fetch_rel_residuo_gift  ( ctrl_TxtEmpresa.getTextBoxValue().PadLeft ( 6, '0' ),
										                 		 ref header, 
										                    	 ref st_block,
										                    	 ref st_empresa ) )
                 	{
						stat.Close();
						return false;                 		
                 	}
					
					stat.LblActivity.Text = "Obtendo resultados";
					
					Application.DoEvents();
					
					ArrayList full_memory = new ArrayList();
										
					while ( st_block != "" )
					{
						ArrayList tmp_memory = new ArrayList();
						
						if ( var_exchange.fetch_memory ( st_block, "190", ref st_block, ref tmp_memory ) )
						{
							for ( int t=0; t < tmp_memory.Count; ++t )
								full_memory.Add ( tmp_memory[t] );
							
							tmp_memory.Clear();
						}
					}
					
					stat.LblActivity.Text = "Gerando relatório para web";
					
					Application.DoEvents();
					
					stat.pgStatus.Maximum = full_memory.Count;
					stat.pgStatus.Minimum = 0;
														
					money money_helper = new money();
					
					ArrayList  desc    = new TipoConfirmacaoDesc().GetArray();
					ArrayList  desc_op = new OperacaoCartaoDesc().GetArray();
					
					lstMessages.Add   ( "Lista de cartões com valores disponíveis para compra" );
					
					lstTableSizes.Add ( 600 );
					
					ArrayList lst_sub_tbl_head = new ArrayList();
					
					lst_sub_tbl_head.Add ( "Matrícula" 				);
					lst_sub_tbl_head.Add ( "Nome" 					);
					lst_sub_tbl_head.Add ( "Valor Resíduo R$" 		);
					lst_sub_tbl_head.Add ( "Ultima Compra" 			);
					lst_sub_tbl_head.Add ( "Ultima carga/recarga" 	);
					lst_sub_tbl_head.Add ( "Valor carga R$" 	);
											
					lstHeader.Add ( lst_sub_tbl_head );
					
					ArrayList lst_main_content = new ArrayList();
					
					long tot = 0;
										
					for ( int t=0; t < full_memory.Count; ++t )
					{
						stat.pgStatus.Value = t + 1;
						
						Application.DoEvents();										
						
						DadosCartao dc = new DadosCartao ( full_memory[t] as DataPortable );
	
						ArrayList lst_sub_content = new ArrayList();
						
						lst_sub_content.Add ( dc.get_st_matricula() 									);
						lst_sub_content.Add ( dc.get_st_proprietario() 									);
						lst_sub_content.Add ( money_helper.formatToMoney ( dc.get_vr_limiteTotal() ) 	);
						
						if ( dc.get_dt_ultUso() == "" )
						{
							lst_sub_content.Add ( "- -"	);
						}
						else
						{
							lst_sub_content.Add ( var_util.getDDMMYYYY_format ( dc.get_dt_ultUso() ) );
						}
						
						if ( dc.get_dt_ultCarga() == "" )
						{
							lst_sub_content.Add ( "- -"	);
						}
						else
						{
							lst_sub_content.Add ( var_util.getDDMMYYYY_format ( dc.get_dt_ultCarga() ) );
						}
						
						lst_sub_content.Add ( money_helper.formatToMoney ( dc.get_vr_extraCota() ) 	);
						
						tot += Convert.ToInt64 ( dc.get_vr_limiteTotal() );
						
						lst_main_content.Add ( lst_sub_content );
					}
						
					lstContent.Add ( lst_main_content );
						
					ArrayList lst_sub_foot = new ArrayList();
					
					lst_sub_foot.Add ( "Total R$: " + money_helper.formatToMoney ( tot.ToString() ) );
						
					lstFooter.Add ( lst_sub_foot );						
					
					stat.Close();
										
					SyCrafReport rel = new SyCrafReport (   "Relatório de resíduo de cartões",
							                               	"RRC", 
							                               	st_empresa,
							                               	ctrl_TxtDtIni.getTextBoxValue(),
							                               	ctrl_TxtDtFim.getTextBoxValue(),
							                               	ref lstHeader,
							                               	ref lstContent,
							                                ref lstTableSizes,
							                                ref lstFooter,
							                                ref lstMessages,
							                                ref lstFilters );
					
					i_Form.BtnConfirmar.Enabled = true;
					i_Form.Visible = true;
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_rel_movEscola -
				
				case event_rel_movEscola:
				{
					//InitEventCode event_rel_movEscola
					
					bool IsDone = true;
					
					if ( !ctrl_TxtEmpresa.IsUserValidated )	
					{	
						ctrl_TxtEmpresa.SetErrorMessage ( "O número da empresa deve ser informado" );
						IsDone = false;	
					}
					
					if ( !ctrl_TxtDtIni.IsUserValidated )	{	ctrl_TxtDtIni.SetErrorMessage 		( "A data inicial deve ser informada corretamente" );	IsDone = false;	}
					if ( !ctrl_TxtDtFim.IsUserValidated )	{	ctrl_TxtDtFim.SetErrorMessage 		( "A data final deve ser informada corretamente" );	IsDone = false;	}
					
					if ( !IsDone )
						return false;
					
					i_Form.BtnConfirmar.Enabled = false;
					
					// ##############################
					// # SETUP LISTS ################
					// ##############################
					
					ArrayList lstHeader 	= new ArrayList();
					ArrayList lstContent 	= new ArrayList();
					ArrayList lstTableSizes = new ArrayList();
					ArrayList lstFooter 	= new ArrayList();
					ArrayList lstMessages 	= new ArrayList();
					ArrayList lstFilters 	= new ArrayList();
					
					// ##############################
					// # CUSTOMIZE
					// ##############################
					
					string st_content 		= "";
					string st_empresa 		= arg as string;
					string st_nome_escola	= "";
					
					i_Form.Visible = false;
					
					dlgStatus stat = new dlgStatus ( "Relatório" );
					
					stat.LblActivity.Text = "Processando relatório no servidor";
					stat.Show();
					Application.DoEvents();
									
					if ( !var_exchange.fetch_rel_edu_movEscola ( st_empresa,
										                 		 var_util.GetDataBaseTimeFormat ( ctrl_TxtDtIni.getTextBoxValue_Date() ),
										                 		 var_util.GetDataBaseTimeFormat ( ctrl_TxtDtFim.getTextBoxValue_Date().AddDays(1) ),
										                 		 ref header, 
										                 		 ref st_content,
										                    	 ref st_nome_escola ) )
                 	{
						stat.Close();
						return false;                 		
                 	}
					
					stat.LblActivity.Text = "Obtendo resultados";
					
					Application.DoEvents();
					
					ArrayList full_memory = new ArrayList();
										
					while ( st_content != "" )
					{
						ArrayList tmp_memory = new ArrayList();
						
						if ( var_exchange.fetch_memory ( st_content, "250", ref st_content, ref tmp_memory ) )
						{
							for ( int t=0; t < tmp_memory.Count; ++t )
								full_memory.Add ( tmp_memory[t] );
							
							tmp_memory.Clear();
						}
					}
					
					stat.LblActivity.Text = "Gerando relatório para web";
					
					Application.DoEvents();
					
					ArrayList lst_sub_tbl_head = new ArrayList();
						
					lst_sub_tbl_head.Add ( "Aluno" );
					lst_sub_tbl_head.Add ( "Valor Total R$" );
					lst_sub_tbl_head.Add ( "Loja" );					
					lst_sub_tbl_head.Add ( "Data e Hora" );
					
					lstHeader.Add ( lst_sub_tbl_head );
					
					lstMessages.Add   ( "Operações do período" );
	
					lstTableSizes.Add ( 550 );
					
					money money_helper = new money();
					
					ArrayList container_lst = new ArrayList();
					
					long tot_valor = 0, tot_trans = 0;
					
					for ( int g=0; g < full_memory.Count; ++g )
					{
						Rel_MovEscola dl = new Rel_MovEscola ( full_memory[g] as DataPortable );
						
						ArrayList lst_sub_content = new ArrayList();
						
						lst_sub_content.Add ( dl.get_st_aluno() 									);
						lst_sub_content.Add ( money_helper.formatToMoney ( dl.get_vr_valor() ) 		);
						lst_sub_content.Add ( dl.get_st_loja()										);
						lst_sub_content.Add ( var_util.getDDMMYYYY_format ( dl.get_dt_trans() )		);
													
						container_lst.Add ( lst_sub_content );
						
						++tot_trans;
						
						tot_valor += Convert.ToInt64 ( dl.get_vr_valor() );
					}
					
					ArrayList lst_sub_foot = new ArrayList();
							
					lst_sub_foot.Add ( "Total de transaçõess no período: " + tot_trans.ToString() );
					lst_sub_foot.Add ( "Total movimentado no período: R$ " + money_helper.formatToMoney ( Convert.ToString(tot_valor) ) );
					
					lstContent.Add 	( container_lst 	);
					lstFooter.Add 	( lst_sub_foot 		);
					
					stat.Close();
										
					SyCrafReport rel = new SyCrafReport ( 	"Relatório de transações efetuadas em determinada escola",
					                               			"RME", 
					                               			st_nome_escola,
							                               	ctrl_TxtDtIni.getTextBoxValue(),
							                               	ctrl_TxtDtFim.getTextBoxValue(),
							                               	ref lstHeader,
							                               	ref lstContent,
							                                ref lstTableSizes,
							                                ref lstFooter,
							                                ref lstMessages,
							                                ref lstFilters 		);
					
					i_Form.BtnConfirmar.Enabled = true;
					i_Form.Visible = true;
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_rel_movEduRede -
				
				case event_rel_movEduRede:
				{
					//InitEventCode event_rel_movEduRede
					
					bool IsDone = true;
					
					if ( !ctrl_TxtEmpresa.IsUserValidated )	
					{	
						ctrl_TxtEmpresa.SetErrorMessage ( "O número da empresa deve ser informado" );
						IsDone = false;	
					}
					
					if ( !ctrl_TxtDtIni.IsUserValidated )	{	ctrl_TxtDtIni.SetErrorMessage 		( "A data inicial deve ser informada corretamente" );	IsDone = false;	}
					if ( !ctrl_TxtDtFim.IsUserValidated )	{	ctrl_TxtDtFim.SetErrorMessage 		( "A data final deve ser informada corretamente" );	IsDone = false;	}
					
					if ( !IsDone )
						return false;
					
					i_Form.BtnConfirmar.Enabled = false;
					
					// ##############################
					// # SETUP LISTS ################
					// ##############################
					
					ArrayList lstHeader 	= new ArrayList();
					ArrayList lstContent 	= new ArrayList();
					ArrayList lstTableSizes = new ArrayList();
					ArrayList lstFooter 	= new ArrayList();
					ArrayList lstMessages 	= new ArrayList();
					ArrayList lstFilters 	= new ArrayList();
					
					// ##############################
					// # CUSTOMIZE
					// ##############################
					
					string st_content 	= "";
					string st_nome_emp	= "";
					
					i_Form.Visible = false;
					
					dlgStatus stat = new dlgStatus ( "Relatório" );
					
					stat.LblActivity.Text = "Processando relatório no servidor";
					stat.Show();
					Application.DoEvents();
									
					if ( !var_exchange.fetch_rel_edu_movRedeEscola ( var_util.GetDataBaseTimeFormat ( ctrl_TxtDtIni.getTextBoxValue_Date() ),
										                 		 	 var_util.GetDataBaseTimeFormat ( ctrl_TxtDtFim.getTextBoxValue_Date().AddDays(1) ),
										                 		 	 ref header, 
										                 		 	 ref st_content,
										                 		 	 ref st_nome_emp ) )
                 	{
						stat.Close();
						return false;                 		
                 	}
					
					stat.LblActivity.Text = "Obtendo resultados";
					
					Application.DoEvents();
					
					ArrayList full_memory = new ArrayList();
										
					while ( st_content != "" )
					{
						ArrayList tmp_memory = new ArrayList();
						
						if ( var_exchange.fetch_memory ( st_content, "150", ref st_content, ref tmp_memory ) )
						{
							for ( int t=0; t < tmp_memory.Count; ++t )
								full_memory.Add ( tmp_memory[t] );
							
							tmp_memory.Clear();
						}
					}
					
					stat.LblActivity.Text = "Gerando relatório para web";
					
					Application.DoEvents();
					
					ArrayList lst_sub_tbl_head = new ArrayList();
						
					lst_sub_tbl_head.Add ( "Loja" );					
					lst_sub_tbl_head.Add ( "Valor Total R$" );
					lst_sub_tbl_head.Add ( "Colégio" );					
										
					lstHeader.Add ( lst_sub_tbl_head );
					
					lstMessages.Add   ( "Operações do período" );
	
					lstTableSizes.Add ( 550 );
					
					money money_helper = new money();
					
					ArrayList container_lst = new ArrayList();
					
					long tot_valor = 0;
					
					for ( int g=0; g < full_memory.Count; ++g )
					{
						Rel_MovRedeEscola dl = new Rel_MovRedeEscola ( full_memory[g] as DataPortable );
						
						ArrayList lst_sub_content = new ArrayList();
						
						lst_sub_content.Add ( dl.get_st_loja()										);
						lst_sub_content.Add ( money_helper.formatToMoney ( dl.get_vr_valor() ) 		);
						lst_sub_content.Add ( dl.get_st_colegio()										);
																			
						container_lst.Add ( lst_sub_content );
						
						tot_valor += Convert.ToInt64 ( dl.get_vr_valor() );
					}
					
					ArrayList lst_sub_foot = new ArrayList();
							
					lst_sub_foot.Add ( "Total movimentado no período: R$ " + money_helper.formatToMoney ( Convert.ToString(tot_valor) ) );
					
					lstContent.Add 	( container_lst 	);
					lstFooter.Add 	( lst_sub_foot 		);
					
					stat.Close();
										
					SyCrafReport rel = new SyCrafReport ( 	"Relatório Educard de movimento da rede",
					                               			"RMRE", 
					                               			st_nome_emp,
							                               	ctrl_TxtDtIni.getTextBoxValue(),
							                               	ctrl_TxtDtFim.getTextBoxValue(),
							                               	ref lstHeader,
							                               	ref lstContent,
							                                ref lstTableSizes,
							                                ref lstFooter,
							                                ref lstMessages,
							                                ref lstFilters 		);
					
					i_Form.BtnConfirmar.Enabled = true;
					i_Form.Visible = true;
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_rel_listaCart -
				
				case event_rel_listaCart:
				{
					//InitEventCode event_rel_listaCart
					
					bool IsDone = true;
					
					if ( !ctrl_TxtEmpresa.IsUserValidated )	
					{	
						ctrl_TxtEmpresa.SetErrorMessage ( "O número da empresa deve ser informado" );
						IsDone = false;	
					}
					
					if ( !IsDone )
						return false;
					
					i_Form.BtnConfirmar.Enabled = false;
					
					// ##############################
					// # SETUP LISTS ################
					// ##############################
					
					ArrayList lstHeader 	= new ArrayList();
					ArrayList lstContent 	= new ArrayList();
					ArrayList lstTableSizes = new ArrayList();
					ArrayList lstFooter 	= new ArrayList();
					ArrayList lstMessages 	= new ArrayList();
					ArrayList lstFilters 	= new ArrayList();
					
					// ##############################
					// # CUSTOMIZE
					// ##############################
					
					string st_content 	= "";
					string st_nome_emp	= "";
					
					i_Form.Visible = false;
					
					dlgStatus stat = new dlgStatus ( "Relatório" );
					
					stat.LblActivity.Text = "Processando relatório no servidor";
					stat.Show();
					Application.DoEvents();
									
					if ( !var_exchange.fetch_rel_listaCarts ( ctrl_TxtEmpresa.getTextBoxValue().PadLeft (6, '0'),
										                 		 	 ref header, 
										                 		 	 ref st_content,
										                 		 	 ref st_nome_emp ) )
                 	{
						stat.Close();
						return false;                 		
                 	}
					
					stat.LblActivity.Text = "Obtendo resultados";
					
					Application.DoEvents();
					
					ArrayList full_memory = new ArrayList();
										
					while ( st_content != "" )
					{
						ArrayList tmp_memory = new ArrayList();
						
						if ( var_exchange.fetch_memory ( st_content, "650", ref st_content, ref tmp_memory ) )
						{
							for ( int t=0; t < tmp_memory.Count; ++t )
								full_memory.Add ( tmp_memory[t] );
							
							tmp_memory.Clear();
						}
					}
					
					stat.LblActivity.Text = "Gerando relatório para web";
					
					Application.DoEvents();
					
					ArrayList lst_sub_tbl_head = new ArrayList();
						
					lst_sub_tbl_head.Add ( "Cartão" );
					lst_sub_tbl_head.Add ( "Proprietário" );
					lst_sub_tbl_head.Add ( "Bloq." );
					lst_sub_tbl_head.Add ( "Lim. Total" );
					lst_sub_tbl_head.Add ( "Lim. Mensal" );
					lst_sub_tbl_head.Add ( "Cota Extra" );
					lst_sub_tbl_head.Add ( "Disp. Mês" );
					lst_sub_tbl_head.Add ( "Disp. Total" );
					lst_sub_tbl_head.Add ( "Validade" );
										
					lstHeader.Add ( lst_sub_tbl_head );
					
					lstMessages.Add   ( "Listagem completa" );
	
					lstTableSizes.Add ( 1100 );
					
					money money_helper = new money();
					
					ArrayList container_lst = new ArrayList();
					
					money mon = new money ();
					
					ArrayList lst_sort = new ArrayList ();
					Hashtable hsh_sort = new Hashtable ();
					
					for ( int g=0; g < full_memory.Count; ++g )
					{
						DataPortable port= full_memory[g] as DataPortable;
						
						lst_sort.Add ( port.getValue ( "prop" ) );
						hsh_sort [ port.getValue ( "prop" ) ] = port;
					}
					
					lst_sort.Sort();
					
					for ( int g=0; g < lst_sort.Count; ++g )
					{
						DataPortable port= hsh_sort [  lst_sort[g].ToString() ] as DataPortable;
												
						{
							ArrayList lst_sub_content = new ArrayList();
							
							lst_sub_content.Add ( port.getValue ( "cart" ) );
							lst_sub_content.Add ( port.getValue ( "prop" ) );
							lst_sub_content.Add ( port.getValue ( "bloq" ) );
							lst_sub_content.Add ( mon.formatToMoney ( port.getValue ( "ltot" ) ) );
							lst_sub_content.Add ( mon.formatToMoney ( port.getValue ( "lmen" ) ) );
							lst_sub_content.Add ( mon.formatToMoney ( port.getValue ( "ext" ) ) );
							lst_sub_content.Add ( mon.formatToMoney ( port.getValue ( "dmen" ) ) );
							lst_sub_content.Add ( mon.formatToMoney ( port.getValue ( "dtot" ) ) );
							lst_sub_content.Add ( port.getValue ( "val" ) );
																				
							container_lst.Add ( lst_sub_content );
						}
						
						{
							ArrayList lst_sub_content = new ArrayList();
							
							lst_sub_content.Add ( port.getValue ( "cel" ) );
							lst_sub_content.Add ( port.getValue ( "end" ) );
							lst_sub_content.Add ( "" );
							lst_sub_content.Add ( port.getValue ( "cpf" ) );
							lst_sub_content.Add ( port.getValue ( "tel" ) );
							lst_sub_content.Add ( "" );
							lst_sub_content.Add ( "" );
							lst_sub_content.Add ( "" );
							lst_sub_content.Add ( "" );
																				
							container_lst.Add ( lst_sub_content );
						}
					}
					
					ArrayList lst_sub_foot = new ArrayList();
							
					lstContent.Add 	( container_lst 	);
					lstFooter.Add 	( lst_sub_foot 		);
					
					stat.Close();
										
					SyCrafReport rel = new SyCrafReport ( 	"Relatório de listagem de todos os cartões",
					                               			"RLTC", 
					                               			st_nome_emp,
							                               	ctrl_TxtDtIni.getTextBoxValue(),
							                               	"",
							                               	ref lstHeader,
							                               	ref lstContent,
							                                ref lstTableSizes,
							                                ref lstFooter,
							                                ref lstMessages,
							                                ref lstFilters 		);
					
					i_Form.BtnConfirmar.Enabled = true;
					i_Form.Visible = true;
				
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_rel_listaLojas -
				
				case event_rel_listaLojas:
				{
					//InitEventCode event_rel_listaLojas
					
					bool IsDone = true;
					
					if ( !ctrl_TxtEmpresa.IsUserValidated )	
					{	
						ctrl_TxtEmpresa.SetErrorMessage ( "O número da empresa deve ser informado" );
						IsDone = false;	
					}
					
					if ( !IsDone )
						return false;
					
					i_Form.BtnConfirmar.Enabled = false;
					
					// ##############################
					// # SETUP LISTS ################
					// ##############################
					
					ArrayList lstHeader 	= new ArrayList();
					ArrayList lstContent 	= new ArrayList();
					ArrayList lstTableSizes = new ArrayList();
					ArrayList lstFooter 	= new ArrayList();
					ArrayList lstMessages 	= new ArrayList();
					ArrayList lstFilters 	= new ArrayList();
					
					// ##############################
					// # CUSTOMIZE
					// ##############################
					
					string st_content 	= "";
					string st_nome_emp	= "";
					
					i_Form.Visible = false;
					
					dlgStatus stat = new dlgStatus ( "Relatório" );
					
					stat.LblActivity.Text = "Processando relatório no servidor";
					stat.Show();
					Application.DoEvents();
									
					if ( !var_exchange.fetch_rel_listaLojas ( 	ctrl_TxtEmpresa.getTextBoxValue().PadLeft (6, '0'),
										                 		ref header, 
										                 		ref st_content,
										                 		ref st_nome_emp ) )
                 	{
						stat.Close();
						return false;                 		
                 	}
					
					stat.LblActivity.Text = "Obtendo resultados";
					
					Application.DoEvents();
					
					ArrayList full_memory = new ArrayList();
										
					while ( st_content != "" )
					{
						ArrayList tmp_memory = new ArrayList();
						
						if ( var_exchange.fetch_memory ( st_content, "650", ref st_content, ref tmp_memory ) )
						{
							for ( int t=0; t < tmp_memory.Count; ++t )
								full_memory.Add ( tmp_memory[t] );
							
							tmp_memory.Clear();
						}
					}
					
					stat.LblActivity.Text = "Gerando relatório para web";
					
					Application.DoEvents();
					
					ArrayList lst_sub_tbl_head = new ArrayList();
						
					lst_sub_tbl_head.Add ( "Código" );
					lst_sub_tbl_head.Add ( "Nome" );
					lst_sub_tbl_head.Add ( "Telefone" );
					lst_sub_tbl_head.Add ( "Cidade" );
					lst_sub_tbl_head.Add ( "Estado" );
					lst_sub_tbl_head.Add ( "Terminais" );
					lst_sub_tbl_head.Add ( "CNPJ" );
					lst_sub_tbl_head.Add ( "Dias Rep." );
					lst_sub_tbl_head.Add ( "Pct. Rep." );
															
					lstHeader.Add ( lst_sub_tbl_head );
					
					lstMessages.Add   ( "Listagem completa" );
	
					lstTableSizes.Add ( 1100 );
					
					money money_helper = new money();
					
					ArrayList container_lst = new ArrayList();
					
					money mon = new money ();
					
					ArrayList lst_sort = new ArrayList ();
					Hashtable hsh_sort = new Hashtable ();
					
					for ( int g=0; g < full_memory.Count; ++g )
					{
						DataPortable port= full_memory[g] as DataPortable;
						
						lst_sort.Add ( port.getValue ( "nome" ) );
						hsh_sort [ port.getValue ( "nome" ) ] = port;
					}
					
					lst_sort.Sort();
					
					for ( int g=0; g < lst_sort.Count; ++g )
					{
						DataPortable port= hsh_sort [  lst_sort[g].ToString() ] as DataPortable;
												
						{
							ArrayList lst_sub_content = new ArrayList();
						
							lst_sub_content.Add ( port.getValue ( "cod" ) );
							lst_sub_content.Add ( port.getValue ( "nome" ) );
							lst_sub_content.Add ( port.getValue ( "tel" ) );
							lst_sub_content.Add ( port.getValue ( "cid" ) );
							lst_sub_content.Add ( port.getValue ( "est" ) );
							lst_sub_content.Add ( port.getValue ( "term" ) );
							lst_sub_content.Add ( port.getValue ( "cnpj" ) );
							lst_sub_content.Add ( port.getValue ( "drep" ) );
							lst_sub_content.Add ( port.getValue ( "prep" ) );						
							
							container_lst.Add ( lst_sub_content );
						}
					}
					
					ArrayList lst_sub_foot = new ArrayList();
							
					lstContent.Add 	( container_lst 	);
					lstFooter.Add 	( lst_sub_foot 		);
					
					stat.Close();
										
					SyCrafReport rel = new SyCrafReport ( 	"Relatório de listagem de todas as lojas",
					                               			"RLTL", 
					                               			st_nome_emp,
							                               	ctrl_TxtDtIni.getTextBoxValue(),
							                               	"",
							                               	ref lstHeader,
							                               	ref lstContent,
							                                ref lstTableSizes,
							                                ref lstFooter,
							                                ref lstMessages,
							                                ref lstFilters 		);
					
					i_Form.BtnConfirmar.Enabled = true;
					i_Form.Visible = true;
					
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
