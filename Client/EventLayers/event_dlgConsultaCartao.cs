using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using SyCrafEngine;

//UserIncludes

using System.Drawing.Printing;

//UserIncludes END

namespace Client
{
	public class event_dlgConsultaCartao : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Consultar = 5;
		public const int event_val_TxtEmpresa = 6;
		public const int event_val_TxtCNPJ = 7;
		public const int event_val_TxtNome = 8;
		public const int event_val_TxtLimTotal = 9;
		public const int event_val_TxtLimMensal = 10;
		public const int event_val_TxtCotaExtra = 11;
		public const int event_val_TxtCidade = 12;
		public const int event_val_TxtEstado = 13;
		public const int event_val_TxtCartao = 14;
		public const int event_val_TxtCpf = 15;
		public const int event_Editar = 16;
		public const int event_Print = 17;
		public const int event_Report = 18;
		public const int event_BtnConsultarClick = 19;
		public const int event_LstCartaoDoubleClick = 20;
		public const int event_BtnRelatorioClick = 21;
		public const int event_ChkAlfaCheckedChanged = 22;
		public const int event_BtnExcluiClick = 23;
		#endregion

		public dlgConsultaCartao i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController		ctrl_TxtCartao		= new numberTextController();
		numberTextController		ctrl_TxtEmpresa		= new numberTextController();
		cnpjTextController			ctrl_TxtCNPJ		= new cnpjTextController();
		alphaTextController			ctrl_TxtNome		= new alphaTextController();
		alphaTextController			ctrl_TxtCidade		= new alphaTextController();
		alphaTextController			ctrl_TxtEstado		= new alphaTextController();
		moneyTextController			ctrl_TxtLimTotal	= new moneyTextController();
		moneyTextController			ctrl_TxtLimMensal	= new moneyTextController();
		moneyTextController			ctrl_TxtCotaExtra	= new moneyTextController();
		
		cpfCnpjTextController		ctrl_TxtCpf			= new cpfCnpjTextController();
		
		Color 	colorInvalid 	= Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgConsultaCartao ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgConsultaCartao ( this );
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
					
					ctrl_TxtCartao.AcquireTextBox		( i_Form.TxtCartao,			this, event_val_TxtCartao, 		 6 	);
					ctrl_TxtEmpresa.AcquireTextBox		( i_Form.TxtEmpresa,		this, event_val_TxtEmpresa, 	 6 	);
					ctrl_TxtNome.AcquireTextBox			( i_Form.TxtNome,			this, event_val_TxtNome, 		20  );
					ctrl_TxtLimTotal.AcquireTextBox		( i_Form.TxtLimTotal,		this, event_val_TxtLimTotal, 	"R$", 6  );
					ctrl_TxtLimMensal.AcquireTextBox	( i_Form.TxtLimMensal,		this, event_val_TxtLimMensal, 	"R$", 6  );
					ctrl_TxtCotaExtra.AcquireTextBox	( i_Form.TxtCotaExtra,		this, event_val_TxtCotaExtra, 	"R$", 6  );
					
					ctrl_TxtCidade.AcquireTextBox		( i_Form.TxtCidade,			this, event_val_TxtCidade, 			20, false  );
					ctrl_TxtEstado.AcquireTextBox		( i_Form.TxtEstado,			this, event_val_TxtEstado, 			20, false  );					
					
					ctrl_TxtCpf.AcquireTextBox 			( i_Form.TxtCpf, 			this, event_val_TxtCpf 						);
					ctrl_TxtCNPJ.AcquireTextBox ( i_Form.TxtCNPJ, this, event_val_TxtCNPJ );
					
					if ( header.get_tg_user_type() == TipoUsuario.Administrador || 
					     header.get_tg_user_type() == TipoUsuario.AdminGift 	|| 
					     header.get_tg_user_type() == TipoUsuario.VendedorGift 	|| 
					     header.get_tg_user_type() == TipoUsuario.Operador )
					{
						ctrl_TxtEmpresa.SetTextBoxText ( header.get_st_empresa() );
						
						i_Form.TxtEmpresa.ReadOnly = true;
					}
					
					if ( header.get_tg_user_type() == TipoUsuario.SuperUser )
					{
						i_Form.BtnExclui.Visible = true;
					}
					
					i_Form.CboSit.SelectedIndex = 3;
					i_Form.CboExp.SelectedIndex = 2;
					
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
				
				#region - event_Consultar -
				
				case event_Consultar:
				{
					//InitEventCode event_Consultar
					
					i_Form.BtnConsultar.Enabled = false;
						
					DadosConsultaCartoes dcc = new DadosConsultaCartoes();
					
					if ( header.get_tg_user_type() == TipoUsuario.Administrador )
					{
						dcc.set_st_empresa 	(  header.get_st_empresa() );
					}
					else
					{
						dcc.set_st_cnpj 	(  ctrl_TxtCNPJ.getTextBoxValue() 		);
						dcc.set_st_empresa 	(  ctrl_TxtEmpresa.getTextBoxValue() 	);
					}
					
					dcc.set_st_cpf	 		( ctrl_TxtCpf.getTextBoxValue() 				);
					dcc.set_st_cartao       ( ctrl_TxtCartao.getTextBoxValue()				);
					dcc.set_st_nome 		( ctrl_TxtNome.getTextBoxValue() 				);
					dcc.set_vr_limTotal 	( ctrl_TxtLimTotal.getTextBoxValue_NumberStr() 	);
					dcc.set_vr_limMensal 	( ctrl_TxtLimMensal.getTextBoxValue_NumberStr() );
					dcc.set_vr_cotaExtra 	( ctrl_TxtCotaExtra.getTextBoxValue_NumberStr() );
					
					dcc.set_st_cidade 		( ctrl_TxtCidade.getTextBoxValue() 				);
					dcc.set_st_estado 		( ctrl_TxtEstado.getTextBoxValue() 				);
					
					dcc.set_tg_bloqueado    ( i_Form.CboSit.SelectedIndex.ToString() 		);
					dcc.set_tg_expedido     ( i_Form.CboExp.SelectedIndex.ToString()		);
					
					string st_csv_block = "";
					
					i_Form.LstCartao.Items.Clear();
										
					i_Form.LblCart.Text = "Processando...";
					Application.DoEvents();
					
					ArrayList full_memory = new ArrayList();
					
					if ( var_exchange.fetch_consultaCartao ( 	ref dcc, 
					                                      		ref header, 
					                                      		ref st_csv_block ) )
					{
						while ( st_csv_block != "" )
						{
							ArrayList tmp_memory  = new ArrayList();
							
							if ( var_exchange.fetch_memory ( st_csv_block, "400",  ref st_csv_block, ref tmp_memory ) )
								for ( int t=0; t < tmp_memory.Count; ++t )
									full_memory.Add ( tmp_memory[t] );
						}
						
						string bloq = "";
						
						if ( i_Form.ChkAlfa.Checked )
						{
							ArrayList lst_sort= new ArrayList();
							Hashtable hsh_sort = new Hashtable();
							
							for ( int t=0; t < full_memory.Count; ++t )
							{
								DadosCartao dc = new DadosCartao ( full_memory[t] as DataPortable );
								
								lst_sort.Add ( dc.get_st_proprietario() + dc.get_st_matricula() );
								
								hsh_sort [ dc.get_st_proprietario() + dc.get_st_matricula() ] = dc;
							}
							
							lst_sort.Sort();
							
							for ( int t=0; t < lst_sort.Count; ++t )
							{
								DadosCartao dc = hsh_sort [ lst_sort[t] ] as DadosCartao;

								if ( dc.get_tg_status() == CartaoStatus.Bloqueado )
									bloq = "Sim";
								else
									bloq = "Não";
								
								string [] full_row = new string [] { 	dc.get_st_empresa() + "." + dc.get_st_matricula() + "-" + dc.get_st_titularidade(),
																		bloq,
																		dc.get_st_proprietario(),																	
																		"R$ " + new money().formatToMoney ( dc.get_vr_limiteTotal() ),
																		"R$ " + new money().formatToMoney ( dc.get_vr_limiteMensal() ),
																		"R$ " + new money().formatToMoney ( dc.get_vr_extraCota() ),
																		"R$ " + new money().formatToMoney ( dc.get_vr_dispMes() ),
																		"R$ " + new money().formatToMoney ( dc.get_vr_dispTotal() ) };
									
								i_Form.LstCartao.Items.Add ( var_util.GetListViewItem ( dc.get_st_cpf(), full_row ) );
							}							
						}
						else
						{
							for ( int t=0; t < full_memory.Count; ++t )
							{
								DadosCartao dc = new DadosCartao ( full_memory[t] as DataPortable );
								
								if ( dc.get_tg_status() == CartaoStatus.Bloqueado )
									bloq = "Sim";
								else
									bloq = "Não";
								
								string [] full_row = new string [] { 	dc.get_st_empresa() + "." + dc.get_st_matricula() + "-" + dc.get_st_titularidade(),
																		bloq,
																		dc.get_st_proprietario(),																	
																		"R$ " + new money().formatToMoney ( dc.get_vr_limiteTotal() ),
																		"R$ " + new money().formatToMoney ( dc.get_vr_limiteMensal() ),
																		"R$ " + new money().formatToMoney ( dc.get_vr_extraCota() ),
																		"R$ " + new money().formatToMoney ( dc.get_vr_dispMes() ),
																		"R$ " + new money().formatToMoney ( dc.get_vr_dispTotal() ) };
									
								i_Form.LstCartao.Items.Add ( var_util.GetListViewItem ( dc.get_st_cpf(), full_row ) );
							}
						}
					}	
					
					if ( full_memory.Count != 0 )
						i_Form.LblCart.Text = full_memory.Count.ToString() + " cartões encontrados";
					else
						i_Form.LblCart.Text = "Nenhum cartão encontrado";
					
					i_Form.BtnConsultar.Enabled = true;
					
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
							if ( ctrl_TxtEmpresa.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtEmpresa.BackColor = Color.White;	
								ctrl_TxtEmpresa.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtEmpresa.BackColor = colorInvalid;	
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
				
				#region - event_val_TxtCNPJ -
				
				case event_val_TxtCNPJ:
				{
					//InitEventCode event_val_TxtCNPJ
					
					switch ( arg as string )
					{
						case cnpjTextController.CNPJ_INCOMPLETE:
						case cnpjTextController.CNPJ_INVALID:
						{
							i_Form.TxtCNPJ.BackColor     = colorInvalid;	
							ctrl_TxtCNPJ.IsUserValidated = false;
							break;
						}
							
						case cnpjTextController.CNPJ_VALID:
						{
							i_Form.TxtCNPJ.BackColor     = Color.White;	
							ctrl_TxtCNPJ.IsUserValidated = true;
							ctrl_TxtCNPJ.CleanError();
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtNome -
				
				case event_val_TxtNome:
				{
					//InitEventCode event_val_TxtNome
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtNome.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtNome.BackColor = Color.White;	
								ctrl_TxtNome.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtNome.BackColor = colorInvalid;	
								ctrl_TxtNome.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtLimTotal -
				
				case event_val_TxtLimTotal:
				{
					//InitEventCode event_val_TxtLimTotal
					
					if ( arg as string == moneyTextController.MONEY_ZERO )
					{
						i_Form.TxtLimTotal.BackColor = colorInvalid;	
						ctrl_TxtLimTotal.IsUserValidated = false;
					}
					else
					{
						i_Form.TxtLimTotal.BackColor = Color.White;	
						ctrl_TxtLimTotal.IsUserValidated = true;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtLimMensal -
				
				case event_val_TxtLimMensal:
				{
					//InitEventCode event_val_TxtLimMensal
					
					if ( arg as string == moneyTextController.MONEY_ZERO )
					{
						i_Form.TxtLimMensal.BackColor = colorInvalid;	
						ctrl_TxtLimMensal.IsUserValidated = false;
					}
					else
					{
						i_Form.TxtLimMensal.BackColor = Color.White;	
						ctrl_TxtLimMensal.IsUserValidated = true;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCotaExtra -
				
				case event_val_TxtCotaExtra:
				{
					//InitEventCode event_val_TxtCotaExtra
					
					if ( arg as string == moneyTextController.MONEY_ZERO )
					{
						i_Form.TxtCotaExtra.BackColor = colorInvalid;	
						ctrl_TxtCotaExtra.IsUserValidated = false;
					}
					else
					{
						i_Form.TxtCotaExtra.BackColor = Color.White;	
						ctrl_TxtCotaExtra.IsUserValidated = true;
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
				
				#region - event_val_TxtEstado -
				
				case event_val_TxtEstado:
				{
					//InitEventCode event_val_TxtEstado
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtEstado.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtEstado.BackColor = Color.White;	
								ctrl_TxtEstado.IsUserValidated = true;
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
				
				#region - event_val_TxtCpf -
				
				case event_val_TxtCpf:
				{
					//InitEventCode event_val_TxtCpf
					
					switch ( arg as string )
					{
						case cnpjTextController.CNPJ_INCOMPLETE:
						case cnpjTextController.CNPJ_INVALID:
						case cpfTextController.CPF_INCOMPLETE:
						case cpfTextController.CPF_INVALID:
						{
							i_Form.TxtCpf.BackColor = colorInvalid;
							ctrl_TxtCpf.IsUserValidated = false;
							break;
						}
							
						case cpfTextController.CPF_VALID:
						case cnpjTextController.CNPJ_VALID:
						{
							i_Form.TxtCpf.BackColor = System.Drawing.Color.White;
							ctrl_TxtCpf.IsUserValidated = true;
							break;
						}
							
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Editar -
				
				case event_Editar:
				{
					//InitEventCode event_Editar
					
					if ( i_Form.LstCartao.SelectedItems.Count > 0 )
					{
						string cpf_cnpj = var_util.getSelectedListViewItemTag ( i_Form.LstCartao );
						
						DadosProprietario dp = new DadosProprietario();
						
						if ( var_exchange.fetch_proprietario ( 	cpf_cnpj,
						                                      	ref header,
						                                      	ref dp ) )
						{
							if ( dp.get_tg_found() == Context.TRUE )
							{
								event_dlgDadosCadastrais ev_call = new event_dlgDadosCadastrais ( var_util, var_exchange );
					
								ev_call.header   = header;
								ev_call.dp       = dp;
								ev_call.cpf_cnpj = cpf_cnpj;
								
								ev_call.i_Form.ShowDialog();	
							}
						}
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Print -
				
				case event_Print:
				{
					//InitEventCode event_Print
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Report -
				
				case event_Report:
				{
					//InitEventCode event_Report
					
					ArrayList lstReport = new ArrayList();
					
					lstReport.Add ( "RELATÓRIO DE CONSULTA DE CARTÃO" );
					lstReport.Add ( "" );	            	
	            	lstReport.Add ( "                                                                 Limite    Limite   Cota Extra  Disponível  Disponível " 		);
	            	lstReport.Add ( "CARTÃO              BLOQ NOME                                    TOTAL     MENSAL               MENSAL      TOTAL" 			);
	            	lstReport.Add ( "------------------------------------------------------------------------------------------------------------------------" 	);
	            	lstReport.Add ( "" );	            	
	            	
	            	string line = "";
	            	
	            	for ( int t=0; t < i_Form.LstCartao.Items.Count; ++t )
	            	{
	            		line  = i_Form.LstCartao.Items[t].SubItems[0].Text + " ";	
	            		line += i_Form.LstCartao.Items[t].SubItems[1].Text.PadLeft ( 4, ' ' ) + " ";
	            		line += i_Form.LstCartao.Items[t].SubItems[2].Text.PadRight ( 38, ' ' ).Substring ( 0, 38 );
	            		line += i_Form.LstCartao.Items[t].SubItems[3].Text.PadLeft ( 14, ' ' ).Replace ( "R$ ","" ) ;
	            		line += i_Form.LstCartao.Items[t].SubItems[4].Text.PadLeft ( 14, ' ' ).Replace ( "R$ ","" ) ;
	            		line += i_Form.LstCartao.Items[t].SubItems[5].Text.PadLeft ( 14, ' ' ).Replace ( "R$ ","" ) ;
	            		line += i_Form.LstCartao.Items[t].SubItems[6].Text.PadLeft ( 14, ' ' ).Replace ( "R$ ","" ) ;
	            		line += i_Form.LstCartao.Items[t].SubItems[7].Text.PadLeft ( 14, ' ' ).Replace ( "R$ ","" ) ;
	            		
	            		lstReport.Add ( line );
	            	}
					
					new ConveyPrinter ( "Courier New", 7, 10, ref lstReport );
		            
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
				
				#region - event_LstCartaoDoubleClick -
				
				case event_LstCartaoDoubleClick:
				{
					//InitEventCode event_LstCartaoDoubleClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnRelatorioClick -
				
				case event_BtnRelatorioClick:
				{
					//InitEventCode event_BtnRelatorioClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ChkAlfaCheckedChanged -
				
				case event_ChkAlfaCheckedChanged:
				{
					//InitEventCode event_ChkAlfaCheckedChanged
					
					doEvent ( event_Consultar, null );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnExcluiClick -
				
				case event_BtnExcluiClick:
				{
					//InitEventCode event_BtnExcluiClick
					
					if ( i_Form.LstCartao.SelectedItems.Count == 1 )
					{
						string emp = i_Form.LstCartao.SelectedItems[0].SubItems[0].Text.Substring ( 0,6 );
						string mat = i_Form.LstCartao.SelectedItems[0].SubItems[0].Text.Substring ( 7,6 );
						string tit = i_Form.LstCartao.SelectedItems[0].SubItems[0].Text.Substring ( 14,2 );
						
						var_exchange.exec_excluiCart ( emp, mat, tit, ref header );
					}
					
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
