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
	public class event_dlgFatRel : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_val_TxtDtIni = 5;
		public const int event_val_TxtDtFim = 6;
		public const int event_Confirmar = 7;
		public const int event_BtnConfirmarClick = 8;
		#endregion

		public dlgFatRel i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		dateTextController ctrl_TxtDtIni	= new dateTextController();
		dateTextController ctrl_TxtDtFim	= new dateTextController();
		
		Color 	colorInvalid 	= Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgFatRel ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgFatRel ( this );
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
					
					ctrl_TxtDtIni.SetTextBoxText 	( 	"01" +
					                                	DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Year.ToString().PadLeft ( 4, '0' ) );
					

					ctrl_TxtDtFim.SetTextBoxText 	( 	"15" +
					                                	DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Year.ToString().PadLeft ( 4, '0' ) );

					
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
					
					if ( i_Form.CboRelat.SelectedIndex == -1 )
					{
						MessageBox.Show ( "Informe a opção de cobrança", "Aviso" );
						bOk = false;
					}
					
					if ( !bOk )
						return false;
					
					i_Form.BtnConfirmar.Enabled = false;
					
					if ( i_Form.CboRelat.SelectedIndex == 0 )
					{
						#region - pendentes com detalhe -
						
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
						
						#endregion
					}
					else
					{
						#region - pagos - 
						
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
						string output_st_content_block 			= "";
						
						int sel = i_Form.CboRelat.SelectedIndex;					
							
						string tg_type = "";
						string st_rel  = "";
						
						switch ( sel )
						{
							case 1: 	tg_type = TipoSitFat.EmCobrança; 	st_rel  = "Relatório de faturamento em cobrança";						break;
							case 2: 	tg_type = TipoSitFat.PagoDoc; 		st_rel  = "Relatório de faturamento pago com doc";						break;
							case 3: 	tg_type = TipoSitFat.PagoCC; 		st_rel  = "Relatório de faturamento pago em débito em conta";			break;
							case 4: 	tg_type = TipoSitFat.BaixaCfeInst; 	st_rel  = "Relatório de faturamento baixado conforme instrução banco";	break;
						}
						
						dlgStatus stat = new dlgStatus ( "Relatório" );
						
						stat.LblActivity.Text = "Processando relatório no servidor";
						stat.Show();
						Application.DoEvents();
										
						if ( !var_exchange.fetch_relFat (	var_util.GetDataBaseTimeFormat ( ctrl_TxtDtIni.getTextBoxValue_Date() ),
											                var_util.GetDataBaseTimeFormat ( ctrl_TxtDtFim.getTextBoxValue_Date().AddDays(1) ),
											                tg_type,
										                 	ref header,
										                 	ref output_st_total,
										                 	ref output_st_content_block		) )
	                 	{
							stat.Close();
							i_Form.BtnConfirmar.Enabled = true;
							return false;                 		
	                 	}
						
						stat.LblActivity.Text = "Buscando detalhes de faturamento";
						Application.DoEvents();
						
						ArrayList full_memory = new ArrayList(); 
						
						ArrayList sortMem = new ArrayList();
						
						while ( output_st_content_block != "" )
						{
							ArrayList tmp_memory = new ArrayList();
							
							if ( var_exchange.fetch_memory ( output_st_content_block, "500", 
							                                 ref output_st_content_block, 
							                                 ref tmp_memory ) )
							{
								for ( int t=0; t < tmp_memory.Count; ++t )
								{
									Rel_FatCompleto tmp = new Rel_FatCompleto ( tmp_memory[t] as DataPortable );
									
									sortMem.Add ( tmp.get_st_nome() );
									
									full_memory.Add ( tmp );
								}
							}
						}
												
						sortMem.Sort();
	
						stat.LblActivity.Text = "Gerando relatório para web";
						Application.DoEvents();
						
						stat.pgStatus.Maximum = full_memory.Count;
						stat.pgStatus.Minimum = 0;
															
						money money_helper = new money();
						
						ArrayList lst_sub_tbl_head = new ArrayList();
							
						lst_sub_tbl_head.Add ( "Empresa/Loja" 		);
						lst_sub_tbl_head.Add ( "Cobrança R$" 	);
						lst_sub_tbl_head.Add ( "Vencimento" 	);
						lst_sub_tbl_head.Add ( "Cód. Banco" 	);
						lst_sub_tbl_head.Add ( "Mensagem" 		);
						lst_sub_tbl_head.Add ( "Data Baixa" 	);
						
						lstHeader.Add ( lst_sub_tbl_head );
						
						// Sub-título
						lstMessages.Add   ( "" );
						lstTableSizes.Add ( 800 );
						
						ArrayList lst_lines = new ArrayList();
						
						for ( int g=0; g < sortMem.Count; ++g )
						{
							stat.pgStatus.Value = g + 1;
							Application.DoEvents();
							
							for (int u=0; u < full_memory.Count; ++u )
							{
								Rel_FatCompleto rel = full_memory [u] as Rel_FatCompleto;
								
								if ( rel.get_st_nome() != sortMem[g].ToString() )
									continue;
						
								// Lista de items para uma linha
								ArrayList lst_sub_content = new ArrayList();
								
								lst_sub_content.Add ( rel.get_st_nome() 															);
								lst_sub_content.Add ( money_helper.formatToMoney ( rel.get_vr_cobranca() ) 							);
								lst_sub_content.Add ( var_util.getDDMMYYYY_format ( rel.get_dt_vencimento() ).Substring ( 0,10 ) 	);
								
								if ( rel.get_dt_baixa() == "" )
								{
									lst_sub_content.Add ( "-" );
									lst_sub_content.Add ( "-" );
									lst_sub_content.Add ( "-" );
								}
								else
								{
									lst_sub_content.Add ( rel.get_cod_retBanco() 														);
									lst_sub_content.Add ( rel.get_st_msgBanco() 														);
									lst_sub_content.Add ( var_util.getDDMMYYYY_format ( rel.get_dt_baixa() ).Substring ( 0, 10 )		);
								}
																						
								lst_lines.Add ( lst_sub_content );
							
								if ( g == full_memory.Count -1 )
								{
									ArrayList lst_sub_foot = new ArrayList();	
									
									lst_sub_foot.Add ( "Total contabilizado no período: R$ " + 
									                   money_helper.formatToMoney ( output_st_total ) );
									
									lstFooter.Add ( lst_sub_foot );
								}
							}
						}
						
						lstContent.Add ( lst_lines );
						
						stat.Close();
						Application.DoEvents();
											
						SyCrafReport relat = new SyCrafReport ( 	st_rel,
						                               		"RFD", 
							                               	"Lista completa de empresas e lojas",
							                               	ctrl_TxtDtIni.getTextBoxValue(),
							                               	ctrl_TxtDtFim.getTextBoxValue(),
							                               	ref lstHeader,
							                               	ref lstContent,
							                                ref lstTableSizes,
							                                ref lstFooter,
							                                ref lstMessages,
							                                ref lstFilters );
						#endregion
					}
					
					i_Form.BtnConfirmar.Enabled = true;
					
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
