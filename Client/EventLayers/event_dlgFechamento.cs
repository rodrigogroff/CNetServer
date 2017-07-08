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
	public class event_dlgFechamento : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_val_TxtMes = 6;
		public const int event_val_TxtAno = 7;
		public const int event_PorEmpresa = 8;
		public const int event_PorCartao = 9;
		public const int event_BDF = 10;
		public const int event_BtnConfirmarClick = 11;
		public const int event_BtnDBFClick = 12;
		#endregion

		public dlgFechamento i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController	ctrl_TxtMes	= new numberTextController();
		numberTextController	ctrl_TxtAno	= new numberTextController();
		
		Color 	colorInvalid = Color.Lavender;
		
		public string st_cod_empresa = "";
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgFechamento ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgFechamento ( this );
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
					
					i_Form.Text += " " + st_cod_empresa.PadLeft (  6, '0' );
					
					i_Form.CboReport.SelectedIndex = 0;
					
					ctrl_TxtMes.AcquireTextBox	( i_Form.TxtMes, this, event_val_TxtMes, 2 );
					ctrl_TxtAno.AcquireTextBox	( i_Form.TxtAno, this, event_val_TxtAno, 4 );
					
					ctrl_TxtMes.SetTextBoxText  ( DateTime.Now.Month.ToString() );
					ctrl_TxtAno.SetTextBoxText  ( DateTime.Now.Year.ToString()  );
					
					ArrayList lst = new ArrayList();
					
					string nome_emp = "";
					
					var_exchange.fetch_empresasAfiliadas ( 	st_cod_empresa,
					                                     	ref header,
					                                     	ref nome_emp,
					                                     	ref lst );
					
					for ( int t=0; t < lst.Count; ++t )
					{
						DadosEmpresa de = new DadosEmpresa ( lst [t] as DataPortable );
						
						i_Form.CboAfiliada.Items.Add ( de.get_st_empresa() );
					}
					
					if ( lst.Count == 0 )
						i_Form.CboAfiliada.Items.Add ( "" );
						
					i_Form.CboAfiliada.SelectedIndex = 0;
					
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
					
					if ( !ctrl_TxtAno.IsUserValidated && !ctrl_TxtMes.IsUserValidated )
						return false;
					
					switch ( i_Form.CboReport.SelectedIndex )
					{
						case 0: doEvent ( event_PorEmpresa, null );	break;
						case 1: doEvent ( event_PorCartao, null );	break;
					}
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtMes -
				
				case event_val_TxtMes:
				{
					//InitEventCode event_val_TxtMes
					
					if ( ctrl_TxtMes.getTextBoxValue() == "" || 
					     ctrl_TxtMes.getTextBoxValue_Long() > 12 )
					{
						i_Form.TxtMes.BackColor     = colorInvalid;	
						ctrl_TxtMes.IsUserValidated = false;
					}
					else
					{
						i_Form.TxtMes.BackColor     = Color.White;	
						ctrl_TxtMes.IsUserValidated = true;
					}
			
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtAno -
				
				case event_val_TxtAno:
				{
					//InitEventCode event_val_TxtAno
					
					if ( ctrl_TxtAno.getTextBoxValue().Length < 4 )
					{
						i_Form.TxtAno.BackColor     = colorInvalid;	
						ctrl_TxtAno.IsUserValidated = false;
					}
					else
					{
						i_Form.TxtAno.BackColor     = Color.White;	
						ctrl_TxtAno.IsUserValidated = true;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_PorEmpresa -
				
				case event_PorEmpresa:
				{
					//InitEventCode event_PorEmpresa
					
					// ##############################
					// # SETUP LISTS ################
					// ##############################
					
					ArrayList lstHeader 	= new ArrayList();
					ArrayList lstContent 	= new ArrayList();
					ArrayList lstTableSizes = new ArrayList();
					ArrayList lstFooter 	= new ArrayList();
					ArrayList lstMessages 	= new ArrayList();
					ArrayList lstFilters 	= new ArrayList();
					
					string st_empresa 				= "";
					string st_csv_cartao 			= "";
					string st_csv_loja 				= "";
					string st_csv_loja_content 		= "";
					string st_csv_subtotal_loja 	= ""; 
					string st_csv_subtotal_cartao 	= "";
					string st_csv_cartao_content 	= "";
					string st_total 				= "";
					
					dlgStatus stat = new dlgStatus ( "Relatório" );
					
					stat.LblActivity.Text = "Processando relatório no servidor";
					stat.Show();
					Application.DoEvents();
					
					if ( !var_exchange.fetch_rel_3_fech (	"0",
							                                ctrl_TxtMes.getTextBoxValue(),
							                                ctrl_TxtAno.getTextBoxValue(),
							                                st_cod_empresa,
							                                i_Form.CboAfiliada.SelectedItem.ToString(),
										                 	ref header,
										                 	ref st_empresa, 
										                 	ref st_csv_cartao,
										                 	ref st_csv_loja,
										                    ref st_csv_loja_content,
										                    ref st_csv_subtotal_loja,
										                    ref st_csv_subtotal_cartao,
										                    ref st_csv_cartao_content,
										                    ref st_total ) )
                 	{
						stat.Close();
						return false;                 		
                 	}
					
					money 		money_helper = new money();
					Hashtable 	mem_Lojas  = new Hashtable();
					
					stat.LblActivity.Text = "Obtendo resultados";
					
					Application.DoEvents();
					
					#region Busca todos os registros de todos as lojas
					{
						ArrayList full_memory = new ArrayList();
						
						while ( st_csv_loja_content != "" )
						{
							ArrayList tmp_memory  = new ArrayList();
							
							if ( var_exchange.fetch_memory ( st_csv_loja_content, "400", ref st_csv_loja_content, ref tmp_memory ) )
								for ( int t=0; t < tmp_memory.Count; ++t )
									full_memory.Add ( tmp_memory[t] );
						}
					
						for ( int t=0; t < full_memory.Count; ++t )
						{
							DadosFechamento df = new DadosFechamento ( full_memory[t] as DataPortable );
							
							string tmp_loja = df.get_st_loja();
							
							if ( mem_Lojas [ tmp_loja ] == null )
								mem_Lojas [ tmp_loja ] = new ArrayList();
							
							ArrayList memoryLoja = mem_Lojas [ tmp_loja ] as ArrayList;
							
							memoryLoja.Add ( df );
						}
					}										
					#endregion

					stat.LblActivity.Text = "Gerando relatório para web";
					
					Application.DoEvents();
					
					int tot_Lojas = var_util.indexCSV ( st_csv_loja );
					
					long tot_repasse = 0;
					
					ApplicationUtil var_utilFooter = new ApplicationUtil();
						
					var_utilFooter.indexCSV ( st_csv_subtotal_loja );
					
					for ( int h=0; h < tot_Lojas; ++h )
					{
						string loja = var_util.getCSV (h);
						
						ArrayList memLojaList = mem_Lojas [ loja ] as ArrayList;
							
						ArrayList lstFooterSub  = new ArrayList();
						ArrayList lstHeaderSub  = new ArrayList();
						ArrayList lstContentSub = new ArrayList();
						
						lstMessages.Add   ( "Fechamento da loja: " + loja );
						
						lstTableSizes.Add ( 650 			);
						
						lstHeaderSub.Add ( "NSU" 			);
						lstHeaderSub.Add ( "Cartão" 		);
						lstHeaderSub.Add ( "Nome" 			);
						lstHeaderSub.Add ( "Data e Hora" 	);
						lstHeaderSub.Add ( "Valor R$" 		);
						lstHeaderSub.Add ( "Parcela" 		);
						lstHeaderSub.Add ( "Terminal" 		);
						
						long sub_repasse = 0;
						
						if ( memLojaList != null )
						{
							for ( int t=0; t < memLojaList.Count; ++t )
							{
								DadosFechamento df = new DadosFechamento ( memLojaList[t] as DataPortable );
								
								ArrayList lstLine = new ArrayList();
								
								lstLine.Add ( df.get_st_nsu().PadLeft ( 6, '0' ) 				);
								lstLine.Add ( df.get_st_cartao()								);
								lstLine.Add ( df.get_st_nome()									);
								lstLine.Add ( var_util.getDDMMYYYY_format ( df.get_dt_trans() ) );
								lstLine.Add ( money_helper.formatToMoney ( df.get_vr_valor() ) );
								lstLine.Add ( df.get_nu_parcela() 	);
								lstLine.Add ( df.get_st_terminal() 	);
								
								sub_repasse += Convert.ToInt64 ( df.get_vr_repasse() );
								
								lstContentSub.Add ( lstLine );
							}
						}
						
						lstFooterSub.Add ( "Sub-Total: " + "R$ " + money_helper.formatToMoney ( var_utilFooter.getCSV(h) ) );
						lstFooterSub.Add ( "Sub-Total repasse: " + "R$ " + money_helper.setMoneyFormat ( sub_repasse ) );
						
						tot_repasse += sub_repasse;
						
						lstHeader.Add 	( lstHeaderSub 	);
						lstFooter.Add 	( lstFooterSub 	);
						lstContent.Add 	( lstContentSub 	);
						
						if ( h == tot_Lojas -1 )
						{
							lstFooterSub.Add ( "" 					);
							lstFooterSub.Add ( "Total de vendas nas lojas: " + "R$ " + money_helper.formatToMoney ( st_total ) );
							lstFooterSub.Add ( "Total de repasse para lojas: " + "R$ " + money_helper.setMoneyFormat ( tot_repasse ) );
						}
					}
					
					stat.Close();
					
					SyCrafReport rel = new SyCrafReport ( "Relatório de Fechamento por loja",
					                               	"RFE", 
					                               	st_empresa,
					                               	"Mês " + ctrl_TxtMes.getTextBoxValue(),
					                               	"Ano " + ctrl_TxtAno.getTextBoxValue(),
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
				
				#region - event_PorCartao -
				
				case event_PorCartao:
				{
					//InitEventCode event_PorCartao
										
					// ##############################
					// # SETUP LISTS ################
					// ##############################
					
					ArrayList lstHeader 	= new ArrayList();
					ArrayList lstContent 	= new ArrayList();
					ArrayList lstTableSizes = new ArrayList();
					ArrayList lstFooter 	= new ArrayList();
					ArrayList lstMessages 	= new ArrayList();
					ArrayList lstFilters 	= new ArrayList();
					
					string st_empresa 				= "";
					string st_csv_cartao 			= "";
					string st_csv_loja 				= "";
					string st_csv_loja_content 		= "";
					string st_csv_subtotal_loja 	= ""; 
					string st_csv_subtotal_cartao 	= "";
					string st_csv_cartao_content 	= "";
					string st_total 				= "";
					
					dlgStatus stat = new dlgStatus ( "Relatório" );
					
					stat.LblActivity.Text = "Processando relatório no servidor";
					stat.Show();
					Application.DoEvents();
					
					if ( !var_exchange.fetch_rel_3_fech (	"1",
							                                ctrl_TxtMes.getTextBoxValue(),
							                                ctrl_TxtAno.getTextBoxValue(),
							                                st_cod_empresa,
							                                i_Form.CboAfiliada.SelectedItem.ToString(),
										                 	ref header,
										                 	ref st_empresa, 
										                 	ref st_csv_cartao,
										                 	ref st_csv_loja,
										                    ref st_csv_loja_content,
										                    ref st_csv_subtotal_loja,
										                    ref st_csv_subtotal_cartao,
										                    ref st_csv_cartao_content,
										                    ref st_total ) )
                 	{
						stat.Close();
						return false;                 		
                 	}
					
					money 		money_helper = new money();
					Hashtable 	mem_Cartoes  = new Hashtable();
					
					stat.LblActivity.Text = "Obtendo resultados";
					
					Application.DoEvents();
					
					#region Busca todos os registros de todos os cartoes
					{
						ArrayList full_memory = new ArrayList();
						
						while ( st_csv_cartao_content != "" )
						{
							ArrayList tmp_memory  = new ArrayList();
							
							if ( var_exchange.fetch_memory ( st_csv_cartao_content, "400", ref st_csv_cartao_content, ref tmp_memory ) )
								for ( int t=0; t < tmp_memory.Count; ++t )
									full_memory.Add ( tmp_memory[t] );
						}
					
						for ( int t=0; t < full_memory.Count; ++t )
						{
							DadosFechamento df = new DadosFechamento ( full_memory[t] as DataPortable );
							
							string tmp_cartao = df.get_st_cartao();
							
							if ( mem_Cartoes [ tmp_cartao ] == null )
								mem_Cartoes [ tmp_cartao ] = new ArrayList();
							
							ArrayList memoryCart = mem_Cartoes [ tmp_cartao ] as ArrayList;
							
							memoryCart.Add ( df );
						}
					}
					
					#endregion
					
					stat.LblActivity.Text = "Gerando relatório para web";
					
					Application.DoEvents();
					
					int tot_Cartoes = var_util.indexCSV ( st_csv_cartao );
					
					ApplicationUtil var_utilFooter = new ApplicationUtil();
						
					var_utilFooter.indexCSV ( st_csv_subtotal_cartao );
					
					for ( int h=0; h < tot_Cartoes; ++h )
					{
						string cart = var_util.getCSV (h);
							
						ArrayList lstFooterSub  = new ArrayList();
						ArrayList lstHeaderSub  = new ArrayList();
						ArrayList lstContentSub = new ArrayList();
						
						lstMessages.Add   ( "Fechamento do cartão: " + cart );
						
						lstTableSizes.Add ( 800 			);
						
						lstHeaderSub.Add ( "NSU" 			);
						lstHeaderSub.Add ( "Loja" 			);
						lstHeaderSub.Add ( "Data e Hora" 	);
						lstHeaderSub.Add ( "Valor R$" 		);
						lstHeaderSub.Add ( "Parcela" 		);
						
						ArrayList memCartList = mem_Cartoes [ cart ] as ArrayList;
						
						if ( memCartList != null )
						{
							for ( int t=0; t < memCartList.Count; ++t )
							{
								DadosFechamento df = new DadosFechamento ( memCartList[t] as DataPortable );
								
								ArrayList lstLine = new ArrayList();
								
								lstLine.Add ( df.get_st_nsu().PadLeft ( 6, '0' ) 				);	
								lstLine.Add ( df.get_st_loja()									);
								lstLine.Add ( var_util.getDDMMYYYY_format ( df.get_dt_trans() ) );
								lstLine.Add ( money_helper.formatToMoney ( df.get_vr_valor() ) 	);
								lstLine.Add ( df.get_nu_parcela() 								);
							
								lstContentSub.Add ( lstLine );
							}
						}
						
						lstFooterSub.Add ( "Sub-Total: R$ " + money_helper.formatToMoney ( var_utilFooter.getCSV(h) ) );
						
						lstHeader.Add 	( lstHeaderSub 	);
						lstFooter.Add 	( lstFooterSub 	);
						lstContent.Add 	( lstContentSub 	);
						
						if ( h == tot_Cartoes -1 )
						{
							lstFooterSub.Add ( "" 					);
							lstFooterSub.Add ( "Total: " + "R$ " + money_helper.formatToMoney ( st_total ) );
						}
					}
					
					stat.Close();
					
					SyCrafReport rel = new SyCrafReport ( "Relatório de Fechamento por cartões",
					                               	"RFE", 
					                               	st_empresa,
					                               	"Mês : " + ctrl_TxtMes.getTextBoxValue(),
					                               	"Ano : " + ctrl_TxtAno.getTextBoxValue(),
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
				
				#region - event_BDF -
				
				case event_BDF:
				{
					//InitEventCode event_BDF
					
					if ( i_Form.CboReport.SelectedIndex != 1 )
					{
						MessageBox.Show ( "Geração somente para relatório de cartões", "Aviso" );
						return false;
					}
					
					event_dlgDBF_Fechamento ev_call = new event_dlgDBF_Fechamento ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.mes = ctrl_TxtMes.getTextBoxValue();
					ev_call.ano = ctrl_TxtAno.getTextBoxValue();
					ev_call.st_cod_empresa = st_cod_empresa;
					
					ev_call.i_Form.ShowDialog();
					
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
				
				#region - event_BtnDBFClick -
				
				case event_BtnDBFClick:
				{
					//InitEventCode event_BtnDBFClick
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
