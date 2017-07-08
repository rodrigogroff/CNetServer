using System;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Net;
using System.Collections;
using System.Data.Odbc;
using SyCrafEngine;

namespace ServerSetup
{
	public class Patch : infra_Patch
	{
		public Patch ( string conn ) : base ( conn ) 
		{
			nu_total_patch = 27;
		}
		
		public override bool run ( int patch_num )
		{
			switch ( patch_num )
			{
				case 1:
				{
					//PatchUserCode
					I_Scheduler sch = new I_Scheduler ( this ); 
					
					sch.set_st_job 			( "schedule_batch" 		);
					sch.set_tg_type 		( Scheduler.Minute 			);
					sch.set_dt_specific 	( GetDataBaseTime() 		);
					sch.set_st_daily_hhmm 	( "0001" 					);
					sch.set_st_weekly_dow 	( "0" 					);
					sch.set_st_weekly_hhmm 	( "0000" 					);
					sch.set_nu_monthly_day 	( "0" 					);
					sch.set_st_monthly_hhmm ( "0000" 					);
					sch.set_dt_last 		( GetDataBaseTime() 		);
					sch.set_tg_status 		( Context.OPEN 				);
					sch.set_dt_prev 		( GetDataBaseTime() 		);
					
					sch.create_I_Scheduler();
					
					sch.set_st_job 			( "schedule_proc_batch" 	);
					
					sch.create_I_Scheduler();
					
					//PatchUserCodeEnd
					break;
				}
				
				case 2:
				{
					//PatchUserCode
					
					I_Scheduler sch = new I_Scheduler ( this );
					
					sch.set_st_job 			( "schedule_nsu" 	);
					sch.set_tg_type 		( Scheduler.Daily 	);
					sch.set_dt_specific 	( GetDataBaseTime() );
					sch.set_st_daily_hhmm 	( "0000" 			);
					sch.set_st_weekly_dow 	( "0" 				);
					sch.set_st_weekly_hhmm 	( "0000" 			);
					sch.set_nu_monthly_day 	( "0" 				);
					sch.set_st_monthly_hhmm ( "0000" 			);
					sch.set_dt_last 		( GetDataBaseTime() );
					sch.set_tg_status 		( Context.OPEN 		);
					sch.set_dt_prev 		( GetDataBaseTime() );
					
					sch.create_I_Scheduler();
														
					//PatchUserCodeEnd
					break;
				}
				
				case 3:
				{
					//PatchUserCode
					
					I_Scheduler sch = new I_Scheduler ( this );
					
					sch.set_st_job 			( "schedule_educacional" 	);
					sch.set_tg_type 		( Scheduler.Daily 			);
					sch.set_dt_specific 	( GetDataBaseTime() 		);
					sch.set_st_daily_hhmm 	( "0001" 					);
					sch.set_st_weekly_dow 	( "0" 						);
					sch.set_st_weekly_hhmm 	( "0000" 					);
					sch.set_nu_monthly_day 	( "0" 						);
					sch.set_st_monthly_hhmm ( "0000" 					);
					sch.set_dt_last 		( GetDataBaseTime() 		);
					sch.set_tg_status 		( Context.OPEN 				);
					sch.set_dt_prev 		( GetDataBaseTime() 		);
					
					sch.create_I_Scheduler();
					
					//PatchUserCodeEnd
					break;
				}
				
				case 4:
				{
					//PatchUserCode
					
					I_Scheduler sch = new I_Scheduler ( this );
					
					sch.set_st_job 			( "schedule_batch" 			);
					sch.set_tg_type 		( Scheduler.Minute 			);
					sch.set_dt_specific 	( GetDataBaseTime() 		);
					sch.set_st_daily_hhmm 	( "0001" 					);
					sch.set_st_weekly_dow 	( "0" 						);
					sch.set_st_weekly_hhmm 	( "0000" 					);
					sch.set_nu_monthly_day 	( "0" 						);
					sch.set_st_monthly_hhmm ( "0000" 					);
					sch.set_dt_last 		( GetDataBaseTime() 		);
					sch.set_tg_status 		( Context.OPEN 				);
					sch.set_dt_prev 		( GetDataBaseTime() 		);
					
					sch.create_I_Scheduler();
					
					sch.set_st_job 			( "schedule_proc_batch" 	);
					
					sch.create_I_Scheduler();
					
					//PatchUserCodeEnd
					break;
				}
				
				case 5:
				{
					//PatchUserCode
					
					I_Scheduler sch = new I_Scheduler ( this );
					
					sch.set_st_job 			( "schedule_edu_fundo" 	);
					sch.set_tg_type 		( Scheduler.Daily 	);
					sch.set_dt_specific 	( GetDataBaseTime() );
					sch.set_st_daily_hhmm 	( "1830" 			);
					sch.set_st_weekly_dow 	( "0" 				);
					sch.set_st_weekly_hhmm 	( "0000" 			);
					sch.set_nu_monthly_day 	( "0" 				);
					sch.set_st_monthly_hhmm ( "0000" 			);
					sch.set_dt_last 		( GetDataBaseTime() );
					sch.set_tg_status 		( Context.OPEN 		);
					sch.set_dt_prev 		( GetDataBaseTime() );
					
					sch.create_I_Scheduler();
					
					//PatchUserCodeEnd
					break;
				}
				
				case 6:
				{
					//PatchUserCode
					//PatchUserCodeEnd
					break;
				}
				
				case 7:
				{
					//PatchUserCode
					
					I_Scheduler sch = new I_Scheduler ( this );
					
					sch.set_st_job 			( "schedule_faturamento"	);
					sch.set_tg_type 		( Scheduler.Daily			);
					sch.set_dt_specific 	( GetDataBaseTime() 		);
					sch.set_st_daily_hhmm 	( "0100" 					);
					sch.set_st_weekly_dow 	( "0" 						);
					sch.set_st_weekly_hhmm 	( "0000" 					);
					sch.set_nu_monthly_day 	( "0" 						);
					sch.set_st_monthly_hhmm ( "0000" 					);
					sch.set_dt_last 		( GetDataBaseTime() 		);
					sch.set_tg_status 		( Context.OPEN 				);
					sch.set_dt_prev 		( GetDataBaseTime() 		);
					
					sch.create_I_Scheduler();
					
					//PatchUserCodeEnd
					break;
				}
				
				case 8:
				{
					//PatchUserCode
					
					T_RetCobranca ret_cob = new T_RetCobranca (this);
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "02" );
					ret_cob.set_st_codMsg  	( "Confirmação da Entrada" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "03" );
					ret_cob.set_st_codMsg  	( "Entrada Rejeitada" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "06" );
					ret_cob.set_st_codMsg  	( "Liquidação Normal" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "07" );
					ret_cob.set_st_codMsg  	( "Liquidação Parcial" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "08" );
					ret_cob.set_st_codMsg  	( "Baixa por Pagamento, Liquidação pelo Saldo" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "09" );
					ret_cob.set_st_codMsg  	( "Devolução Automática" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "02" );
					ret_cob.set_st_codMsg  	( "Confirmação da Entrada" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "10" );
					ret_cob.set_st_codMsg  	( "Baixado conforme Instruções" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "11" );
					ret_cob.set_st_codMsg  	( "Arquivo Levantamento" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "12" );
					ret_cob.set_st_codMsg  	( "Concessão de Abatimento" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "13" );
					ret_cob.set_st_codMsg  	( "Cancelamento de Abatimento" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "14" );
					ret_cob.set_st_codMsg  	( "Vencimento Alterado" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "15" );
					ret_cob.set_st_codMsg  	( "Pagamento em Cartório" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "16" );
					ret_cob.set_st_codMsg  	( "Alteração de dados" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "18" );
					ret_cob.set_st_codMsg  	( "Alteração de instruções" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "19" );
					ret_cob.set_st_codMsg  	( "Confirmação Instrução Protesto" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "20" );
					ret_cob.set_st_codMsg  	( "Confirmação Instrução  p/ Sustar Protesto" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "21" );
					ret_cob.set_st_codMsg  	( "Aguardando autorização para protesto por edital" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "22" );
					ret_cob.set_st_codMsg  	( "Protesto sustado por alt. de vcto. e prazo de cartório" );
					
					ret_cob.create_T_RetCobranca();
										
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "23" );
					ret_cob.set_st_codMsg  	( "Confirmação da Entrada em Cartório." );
					
					ret_cob.create_T_RetCobranca();					
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "25" );
					ret_cob.set_st_codMsg  	( "Devolução, Liquidado Anteriormente." );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "26" );
					ret_cob.set_st_codMsg  	( "Devolvido pelo cartório - erro de informação" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "30" );
					ret_cob.set_st_codMsg  	( "Cobrança a creditar (em trânsito)." );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "31" );
					ret_cob.set_st_codMsg  	( "Título em trânsito pago em cartório." );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "32" );
					ret_cob.set_st_codMsg  	( "Reembolso e Transferência (Vêndor Eletrônico)" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "33" );
					ret_cob.set_st_codMsg  	( "Reembolso e Devolução (Vêndor Eletrônico)" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "40" );
					ret_cob.set_st_codMsg  	( "Baixa de títulos protestados." );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "41" );
					ret_cob.set_st_codMsg  	( "Despesa de aponte." );
					
					ret_cob.create_T_RetCobranca();
										
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "42" );
					ret_cob.set_st_codMsg  	( "Alteração de título." );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "43" );
					ret_cob.set_st_codMsg  	( "Relação de títulos." );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "44" );
					ret_cob.set_st_codMsg  	( "Manutenção mensal." );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "45" );
					ret_cob.set_st_codMsg  	( "Sustação de cartório e envio de título à cartório." );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "0" );
					ret_cob.set_nu_cod 		( "46" );
					ret_cob.set_st_codMsg  	( "Fornecimento de formulário pré-impresso." );
					
					ret_cob.create_T_RetCobranca();
					
					//PatchUserCodeEnd
					break;
				}
				
				case 9:
				{
					//PatchUserCode
					
					T_RetCobranca ret_cob = new T_RetCobranca (this);
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "1" );
					ret_cob.set_nu_cod 		( "00" );
					ret_cob.set_st_codMsg  	( "Débito efetuado" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "1" );
					ret_cob.set_nu_cod 		( "01" );
					ret_cob.set_st_codMsg  	( "Insuficiência de fundos" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "1" );
					ret_cob.set_nu_cod 		( "02" );
					ret_cob.set_st_codMsg  	( "Conta não cadastrada" );
					
					ret_cob.create_T_RetCobranca();
										
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "1" );
					ret_cob.set_nu_cod 		( "04" );
					ret_cob.set_st_codMsg  	( "Outras restrições" );
					
					ret_cob.create_T_RetCobranca();					
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "1" );
					ret_cob.set_nu_cod 		( "10" );
					ret_cob.set_st_codMsg  	( "Agência encerrada" );
					
					ret_cob.create_T_RetCobranca();
										
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "1" );
					ret_cob.set_nu_cod 		( "12" );
					ret_cob.set_st_codMsg  	( "Valor inválido" );
					
					ret_cob.create_T_RetCobranca();					
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "1" );
					ret_cob.set_nu_cod 		( "13" );
					ret_cob.set_st_codMsg  	( "Data inválida" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "1" );
					ret_cob.set_nu_cod 		( "14" );
					ret_cob.set_st_codMsg  	( "Agência inválida" );
					
					ret_cob.create_T_RetCobranca();
										
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "1" );
					ret_cob.set_nu_cod 		( "15" );
					ret_cob.set_st_codMsg  	( "Conta inválida" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "1" );
					ret_cob.set_nu_cod 		( "18" );
					ret_cob.set_st_codMsg  	( "Data de déb. inválida" );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "1" );
					ret_cob.set_nu_cod 		( "30" );
					ret_cob.set_st_codMsg  	( "Sem contrato déb." );
					
					ret_cob.create_T_RetCobranca();
					
					ret_cob.set_nu_codBanco ( "41" );
					ret_cob.set_tg_tipoCob 	( "1" );
					ret_cob.set_nu_cod 		( "96" );
					ret_cob.set_st_codMsg  	( "Manutenção" );
					
					ret_cob.create_T_RetCobranca();
					
					//PatchUserCodeEnd
					break;
				}
				
				case 10:
				{
					//PatchUserCode
					
					T_Cartao cart = new T_Cartao(this);
					T_Cartao cart_upd = new T_Cartao(this);
					
					if ( cart.select_rows_empresa ( "003522" ) )
					{
						while ( cart.fetch() )
						{
							if ( cart.get_fk_dadosProprietario() == "2673" )
							{
								cart_upd.selectIdentity ( cart.get_identity() );
								
								cart_upd.set_fk_dadosProprietario ( "0" );
								cart_upd.set_fk_infoAdicionais    ( "0" );
								
								cart_upd.synchronize_T_Cartao();
							}
						}
					}
					
					T_Proprietario prot = new T_Proprietario (this);
					
					if ( prot.selectIdentity ( "2673" ) )
					{
						prot.delete();
					}
					
					//PatchUserCodeEnd
					break;
				}
				
				case 11:
				{
					//PatchUserCode
					//PatchUserCodeEnd
					break;
				}
				
				case 12:
				{
					//PatchUserCode
					//PatchUserCodeEnd
					break;
				}
				
				case 13:
				{
					//PatchUserCode
					
					T_Cartao cart = new T_Cartao (this);
					T_Cartao cart_upd = new T_Cartao (this);
					
					if ( cart.select_rows_tipo ( TipoCartao.presente ) )
					{
						while ( cart.fetch() )
						{
							LOG_Transacoes ltr = new LOG_Transacoes (this);
							
							long carga = cart.get_int_vr_limiteTotal();
							
							if ( ltr.select_fk_cartao ( cart.get_identity() ) )
							{
								while ( ltr.fetch() )
								{
									if ( ltr.get_tg_confirmada() == TipoConfirmacao.Confirmada )
									{
										carga -= ltr.get_int_vr_total();
									}
								}
							}
														
							cart_upd.selectIdentity ( cart.get_identity() );
							                         
							cart_upd.set_vr_limiteTotal ( carga );
							
							cart_upd.synchronize_T_Cartao();
						}
					}
					
					//PatchUserCodeEnd
					break;
				}
				
				case 14:
				{
					//PatchUserCode
					
					LINK_ProprietarioCartao lpc = new LINK_ProprietarioCartao (this);
					
					if ( lpc.selectAll() )
					{
						while ( lpc.fetch() )
						{
							lpc.delete();		
						}
					}
										
					T_Cartao cart = new T_Cartao(this);
					
					if ( cart.selectAll() )
					{
						while ( cart.fetch() )
						{
							lpc.set_fk_cartao ( cart.get_identity() );
							lpc.set_fk_proprietario ( cart.get_fk_dadosProprietario() );
							
							lpc.create_LINK_ProprietarioCartao();								
						}
					}
					
					//PatchUserCodeEnd
					break;
				}
				
				case 15:
				{
					//PatchUserCode
					
					T_Empresa 			emp 	= new T_Empresa			(this);
					T_Cartao 			cart 	= new T_Cartao 			(this);
					T_InfoAdicionais 	info 	= new T_InfoAdicionais 	(this);
					
					if ( emp.select_rows_empresa ( "000019" ) )
					{
						emp.fetch();
					}
					
					Hashtable hshDistinct  = new Hashtable();
					ArrayList lstAfiliadas = new ArrayList();
					
					if ( cart.select_rows_empresa ( "000019" ) )
					{
						while ( cart.fetch() )
						{
							if ( info.selectIdentity ( cart.get_fk_infoAdicionais() ) )
							{
								if ( info.get_st_empresaAfiliada().Trim().Length == 0 )
									continue;
								
								if ( hshDistinct [ info.get_st_empresaAfiliada() ] == null )
								{
									lstAfiliadas.Add ( info.get_st_empresaAfiliada() );
									hshDistinct [ info.get_st_empresaAfiliada() ] = "*";
								}
							}
						}
					}
					
					T_EmpresaAfiliada 	empAff 	= new T_EmpresaAfiliada (this);
					
					for ( int t=0; t < lstAfiliadas.Count; ++t )
					{
						empAff.set_fk_empresa ( emp.get_identity() );
						empAff.set_st_nome    ( lstAfiliadas[t].ToString() );
						
						empAff.create_T_EmpresaAfiliada();
					}
						
					//PatchUserCodeEnd
					break;
				}
				
				case 16:
				{
					//PatchUserCode
					
					T_Parcelas 		tmp  	 = new T_Parcelas 		(this);
					LOG_Fechamento 	log_fech = new LOG_Fechamento 	(this);
					LOG_Fechamento 	log_del = new LOG_Fechamento 	(this);
					
					log_fech.selectAll();
					
					while ( log_fech.fetch() )
					{
						if ( tmp.selectIdentity ( log_fech.get_fk_parcela() ) )
						{
							tmp.set_nu_parcela 	( tmp.get_int_nu_parcela() + 1 	);
							tmp.set_tg_pago 	( Context.FALSE 				);
							
							tmp.synchronize_T_Parcelas();
						}			
						
						log_del.selectIdentity ( log_fech.get_identity() );
						log_del.delete();
					}
					
					//PatchUserCodeEnd
					break;
				}
				
				case 17:
				{
					//PatchUserCode
					
					T_Parcelas 		tmp  	 = new T_Parcelas 		(this);
					LOG_Fechamento 	log_fech = new LOG_Fechamento 	(this);
					LOG_Fechamento 	log_del = new LOG_Fechamento 	(this);
					
					log_fech.selectAll();
					
					while ( log_fech.fetch() )
					{
						if ( tmp.selectIdentity ( log_fech.get_fk_parcela() ) )
						{
							tmp.set_nu_parcela 	( tmp.get_int_nu_parcela() + 1 	);
							tmp.set_tg_pago 	( Context.FALSE 				);
							
							tmp.synchronize_T_Parcelas();
						}			
						
						log_del.selectIdentity ( log_fech.get_identity() );
						log_del.delete();
					}
					
					//PatchUserCodeEnd
					break;
				}
				
				case 18:
				{
					//PatchUserCode
					
										T_Parcelas 		tmp  	 = new T_Parcelas 		(this);
					LOG_Fechamento 	log_fech = new LOG_Fechamento 	(this);
					LOG_Fechamento 	log_del = new LOG_Fechamento 	(this);
					
					log_fech.selectAll();
					
					while ( log_fech.fetch() )
					{
						if ( tmp.selectIdentity ( log_fech.get_fk_parcela() ) )
						{
							tmp.set_nu_parcela 	( tmp.get_int_nu_parcela() + 1 	);
							tmp.set_tg_pago 	( Context.FALSE 				);
							
							tmp.synchronize_T_Parcelas();
						}			
						
						log_del.selectIdentity ( log_fech.get_identity() );
						log_del.delete();
					}

					
					//PatchUserCodeEnd
					break;
				}
				
				case 19:
				{
					//PatchUserCode
					
					LOG_Transacoes ltr 		= new LOG_Transacoes (this);
					LOG_Transacoes ltr_upd 	= new LOG_Transacoes (this);
					T_Parcelas     parc 	= new T_Parcelas 	 (this);
					T_Parcelas     parc_upd = new T_Parcelas 	 (this);
					
					if ( ltr.select_rows_dt ( "2008-09-08 12:00:00", "2008-09-08 23:59:59" ) )
				    {
						while ( ltr.fetch() )
						{
							ltr_upd.selectIdentity ( ltr.get_identity() );
							
							LOG_NSU nsu = new LOG_NSU(this);
							
							nsu.set_dt_log ( GetDataBaseTime() );
							
							nsu.create_LOG_NSU();
							
							ltr_upd.set_nu_nsu ( nsu.get_identity() );
							
							ltr_upd.synchronize_LOG_Transacoes();
							
							if ( parc.select_fk_log_trans ( ltr.get_identity() ) )
							{
								while ( parc.fetch() )
								{
									parc_upd.selectIdentity ( parc.get_identity() );
									
									parc_upd.set_nu_nsu ( nsu.get_identity() );
									
									parc_upd.synchronize_T_Parcelas();
								}
							}
						}
				    }
					
					//PatchUserCodeEnd
					break;
				}
				
				case 20:
				{
					//PatchUserCode
					
					ArrayList lstSenhas = new ArrayList();
					ArrayList lstCNPJ   = new ArrayList();
					
					lstSenhas.Add("liv1");lstCNPJ.Add("93835544000154");
					lstSenhas.Add("999999");lstCNPJ.Add("93835544000154");
					lstSenhas.Add("931530");lstCNPJ.Add("93153054000178");
					lstSenhas.Add("884903");lstCNPJ.Add("88490370000103");
					lstSenhas.Add("877210");lstCNPJ.Add("87721098000154");
					lstSenhas.Add("900418");lstCNPJ.Add("90041849000104");
					lstSenhas.Add("900418");lstCNPJ.Add("90041849000600");
					lstSenhas.Add("015474");lstCNPJ.Add("01547468000163");
					lstSenhas.Add("908907");lstCNPJ.Add("90890765000137");
					lstSenhas.Add("958140");lstCNPJ.Add("95814000000131");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113000444");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113000959");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113000363");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113000100");
					lstSenhas.Add("909693");lstCNPJ.Add("90969387001153");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113000525");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113000606");
					lstSenhas.Add("and1499");lstCNPJ.Add("72381965000182");
					lstSenhas.Add("katy10");lstCNPJ.Add("92814250000183");
					lstSenhas.Add("928142");lstCNPJ.Add("92814250000779");
					lstSenhas.Add("043540");lstCNPJ.Add("04354022000100");
					lstSenhas.Add("027608");lstCNPJ.Add("02760879000103");
					lstSenhas.Add("899956");lstCNPJ.Add("89995658000194");
					lstSenhas.Add("032931");lstCNPJ.Add("03293196000148");
					lstSenhas.Add("983380");lstCNPJ.Add("98338072001624");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113001254");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113001173");
					lstSenhas.Add("041306");lstCNPJ.Add("04130648000133");
					lstSenhas.Add("all2057");lstCNPJ.Add("92664150000207");
					lstSenhas.Add("all2058");lstCNPJ.Add("9266415000380");
					lstSenhas.Add("895996");lstCNPJ.Add("89599666000383");
					lstSenhas.Add("962033");lstCNPJ.Add("96203393000100");
					lstSenhas.Add("912843");lstCNPJ.Add("91284307000117");
					lstSenhas.Add("210585");lstCNPJ.Add("90293390000128");
					lstSenhas.Add("962033");lstCNPJ.Add("96203310000182");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113001335");
					lstSenhas.Add("000322");lstCNPJ.Add("87723417000322");
					lstSenhas.Add("005410");lstCNPJ.Add("00541076000124");
					lstSenhas.Add("900819");lstCNPJ.Add("90081951000125");
					lstSenhas.Add("010458");lstCNPJ.Add("01045826000130");
					lstSenhas.Add("931530");lstCNPJ.Add("93153054000330");
					lstSenhas.Add("080641");lstCNPJ.Add("02064172000154");
					lstSenhas.Add("876874");lstCNPJ.Add("87687489000108");
					lstSenhas.Add("026151");lstCNPJ.Add("02615147000111");
					lstSenhas.Add("030248");lstCNPJ.Add("03024829000112");
					lstSenhas.Add("051036");lstCNPJ.Add("05103600000107");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113001416");
					lstSenhas.Add("003948");lstCNPJ.Add("00394805000329");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113001505");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113001688");
					lstSenhas.Add("901200");lstCNPJ.Add("90120007000210");
					lstSenhas.Add("all2727");lstCNPJ.Add("92664150000118");
					lstSenhas.Add("907382");lstCNPJ.Add("90738204000117");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113001769");
					lstSenhas.Add("123456");lstCNPJ.Add("92132489000173");
					lstSenhas.Add("921324");lstCNPJ.Add("92132489000173");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113001920");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113002226");
					lstSenhas.Add("015768");lstCNPJ.Add("01576890000147");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113002307");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113002579");
					lstSenhas.Add("007000");lstCNPJ.Add("88212113002579");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113002650");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113002730");
					lstSenhas.Add("882121");lstCNPJ.Add("92941681000291");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113002811");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113002145");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113002900");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113003036");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113003117");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113003206");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113000797");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113003389");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113003540");
					lstSenhas.Add("936417");lstCNPJ.Add("93641710001404");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113003621");
					lstSenhas.Add("074476");lstCNPJ.Add("07447673000133");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113003460");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113003702");
					lstSenhas.Add("city3547");lstCNPJ.Add("07086798000185");
					lstSenhas.Add("milo3548");lstCNPJ.Add("03364454000130");
					lstSenhas.Add("1111");lstCNPJ.Add("07103777000120");
					lstSenhas.Add("spl3557");lstCNPJ.Add("07509246000132");
					lstSenhas.Add("cia3558");lstCNPJ.Add("06009802000149");
					lstSenhas.Add("all3559");lstCNPJ.Add("92664150000460");
					lstSenhas.Add("all3560");lstCNPJ.Add("92664150000541");
					lstSenhas.Add("5899");lstCNPJ.Add("03845784000147");
					lstSenhas.Add("ubss3563");lstCNPJ.Add("90863291000134");
					lstSenhas.Add("042652");lstCNPJ.Add("04265280000110");
					lstSenhas.Add("724624");lstCNPJ.Add("72462450000298");
					lstSenhas.Add("940107");lstCNPJ.Add("94010709000111");
					lstSenhas.Add("940107");lstCNPJ.Add("94010709000111");
					lstSenhas.Add("926136");lstCNPJ.Add("92613678000168");
					lstSenhas.Add("900670");lstCNPJ.Add("90067026000140");
					lstSenhas.Add("062193");lstCNPJ.Add("06219376000178");
					lstSenhas.Add("052610");lstCNPJ.Add("05261044000199");
					lstSenhas.Add("893924");lstCNPJ.Add("89392484000175");
					lstSenhas.Add("873832");lstCNPJ.Add("87383238000121");
					lstSenhas.Add("873832");lstCNPJ.Add("87383238000121");
					lstSenhas.Add("931530");lstCNPJ.Add("93153054000410");
					lstSenhas.Add("posto123");lstCNPJ.Add("98248644002141");
					lstSenhas.Add("311081");lstCNPJ.Add("90624941000199");
					lstSenhas.Add("073188");lstCNPJ.Add("07318885000110");
					lstSenhas.Add("958225");lstCNPJ.Add("95822516000128");
					lstSenhas.Add("052017");lstCNPJ.Add("05201758000101");
					lstSenhas.Add("085686");lstCNPJ.Add("08568646000181");
					lstSenhas.Add("056846");lstCNPJ.Add("05684601000184");
					lstSenhas.Add("056846");lstCNPJ.Add("05684601000184");
					lstSenhas.Add("022073");lstCNPJ.Add("02207341000168");
					lstSenhas.Add("075043");lstCNPJ.Add("07504307000179");
					lstSenhas.Add("055007");lstCNPJ.Add("05500711000149");
					lstSenhas.Add("970475");lstCNPJ.Add("97047526000169");
					lstSenhas.Add("970475");lstCNPJ.Add("97047526000169");
					lstSenhas.Add("061662");lstCNPJ.Add("06166296000100");
					lstSenhas.Add("877930");lstCNPJ.Add("87793063000635");
					lstSenhas.Add("056517");lstCNPJ.Add("05651786000120");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113005837");
					lstSenhas.Add("958213");lstCNPJ.Add("95821310004170");
					lstSenhas.Add("958213");lstCNPJ.Add("95821310001236");
					lstSenhas.Add("958213");lstCNPJ.Add("95821310001236");
					lstSenhas.Add("060617");lstCNPJ.Add("06061787000269");
					lstSenhas.Add("917200");lstCNPJ.Add("91720045000196");
					lstSenhas.Add("038031");lstCNPJ.Add("03803120000115");
					lstSenhas.Add("063399");lstCNPJ.Add("06339959000132");
					lstSenhas.Add("063399");lstCNPJ.Add("06339959000132");
					lstSenhas.Add("071880");lstCNPJ.Add("07188081000144");
					lstSenhas.Add("071880");lstCNPJ.Add("07188081000144");
					lstSenhas.Add("940022");lstCNPJ.Add("94002284000107");
					lstSenhas.Add("940022");lstCNPJ.Add("94002284000107");
					lstSenhas.Add("930030");lstCNPJ.Add("93003044000156");
					lstSenhas.Add("935618");lstCNPJ.Add("93561885000100");
					lstSenhas.Add("938807");lstCNPJ.Add("93880722000169");
					lstSenhas.Add("042929");lstCNPJ.Add("04292984000182");
					lstSenhas.Add("042929");lstCNPJ.Add("04292984000182");
					lstSenhas.Add("039642");lstCNPJ.Add("03964256000107");
					lstSenhas.Add("005393");lstCNPJ.Add("00539303000187");
					lstSenhas.Add("054442");lstCNPJ.Add("05444261000114");
					lstSenhas.Add("081437");lstCNPJ.Add("08143721000162");
					lstSenhas.Add("089170");lstCNPJ.Add("05556703000114");
					lstSenhas.Add("055567");lstCNPJ.Add("05556703000114");
					lstSenhas.Add("049653");lstCNPJ.Add("04965386000127");
					lstSenhas.Add("101010");lstCNPJ.Add("07248386000102");
					lstSenhas.Add("060708");lstCNPJ.Add("06070836000149");
					lstSenhas.Add("088917");lstCNPJ.Add("93336451000266");
					lstSenhas.Add("903364");lstCNPJ.Add("93336451000266");
					lstSenhas.Add("933364");lstCNPJ.Add("93336451000185");
					lstSenhas.Add("mega85");lstCNPJ.Add("02998543000175");
					lstSenhas.Add("075400");lstCNPJ.Add("07540049000186");
					lstSenhas.Add("933012");lstCNPJ.Add("93309912000120");
					lstSenhas.Add("933099");lstCNPJ.Add("93309912000635");
					lstSenhas.Add("040928");lstCNPJ.Add("04092855000140");
					lstSenhas.Add("gsfmnh361");lstCNPJ.Add("88870530000131");
					lstSenhas.Add("936417");lstCNPJ.Add("93641710001668");
					lstSenhas.Add("006971");lstCNPJ.Add("00693710000144");
					lstSenhas.Add("006937");lstCNPJ.Add("00693710000144");
					lstSenhas.Add("948561");lstCNPJ.Add("94856150000145");
					lstSenhas.Add("948561");lstCNPJ.Add("94856150000145");
					lstSenhas.Add("877234");lstCNPJ.Add("87723417000756");
					lstSenhas.Add("877234");lstCNPJ.Add("87723417000756");
					lstSenhas.Add("056669");lstCNPJ.Add("05666947000120");
					lstSenhas.Add("024667");lstCNPJ.Add("02466798000197");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113005675");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113005918");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113005756");
					lstSenhas.Add("070866");lstCNPJ.Add("07086643000149");
					lstSenhas.Add("916930");lstCNPJ.Add("91693044000108");
					lstSenhas.Add("2370");lstCNPJ.Add("91896811000178");
					lstSenhas.Add("044470");lstCNPJ.Add("04447004000173");
					lstSenhas.Add("061128");lstCNPJ.Add("06112880000174");
					lstSenhas.Add("061128");lstCNPJ.Add("06112880000255");
					lstSenhas.Add("902938");lstCNPJ.Add("90293820000101");
					lstSenhas.Add("1234");lstCNPJ.Add("04727990000115");
					lstSenhas.Add("068857");lstCNPJ.Add("06885740000139");
					lstSenhas.Add("911271");lstCNPJ.Add("91127142000684");
					lstSenhas.Add("911271");lstCNPJ.Add("91127142000170");
					lstSenhas.Add("877268");lstCNPJ.Add("87726899000102");
					lstSenhas.Add("875447");lstCNPJ.Add("87544714000149");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113006213");
					lstSenhas.Add("000174");lstCNPJ.Add("88727797000174");
					lstSenhas.Add("150899");lstCNPJ.Add("91883009000143");
					lstSenhas.Add("426108");lstCNPJ.Add("89189625000157");
					lstSenhas.Add("575057");lstCNPJ.Add("02563170000100");
					lstSenhas.Add("074677");lstCNPJ.Add("07467743000115");
					lstSenhas.Add("946827");lstCNPJ.Add("94682796000153");
					lstSenhas.Add("016349");lstCNPJ.Add("01634935000192");
					lstSenhas.Add("050706");lstCNPJ.Add("05070609000150");
					lstSenhas.Add("935434");lstCNPJ.Add("93543429000106");
					lstSenhas.Add("2525");lstCNPJ.Add("07223906000114");
					lstSenhas.Add("039992");lstCNPJ.Add("03999252000164");
					lstSenhas.Add("902781");lstCNPJ.Add("90278169000109");
					lstSenhas.Add("495689");lstCNPJ.Add("49568973087");
					lstSenhas.Add("880269");lstCNPJ.Add("88026901000101");
					lstSenhas.Add("000130");lstCNPJ.Add("01799687000130");
					lstSenhas.Add("017314");lstCNPJ.Add("01731418000484");
					lstSenhas.Add("35947477");lstCNPJ.Add("94222981000165");
					lstSenhas.Add("933708");lstCNPJ.Add("93370898000170");
					lstSenhas.Add("000251");lstCNPJ.Add("93370898000251");
					lstSenhas.Add("024771");lstCNPJ.Add("02477147000100");
					lstSenhas.Add("898885");lstCNPJ.Add("89888564000205");
					lstSenhas.Add("898886");lstCNPJ.Add("89888564000116");
					lstSenhas.Add("918961");lstCNPJ.Add("91896183000120");
					lstSenhas.Add("039313");lstCNPJ.Add("03931311000162");
					lstSenhas.Add("079582");lstCNPJ.Add("07958224000150");
					lstSenhas.Add("877034");lstCNPJ.Add("87703401000196");
					lstSenhas.Add("farmacia");lstCNPJ.Add("87703401000439");
					lstSenhas.Add("084914");lstCNPJ.Add("08491447000112");
					lstSenhas.Add("000110");lstCNPJ.Add("05569940000110");
					lstSenhas.Add("724887");lstCNPJ.Add("72488703000111");
					lstSenhas.Add("740094");lstCNPJ.Add("74009440000146");
					lstSenhas.Add("070719");lstCNPJ.Add("07071906000146");
					lstSenhas.Add("940864");lstCNPJ.Add("94086444000135");
					lstSenhas.Add("009724");lstCNPJ.Add("00972460000181");
					lstSenhas.Add("035548");lstCNPJ.Add("03554882000125");
					lstSenhas.Add("905208");lstCNPJ.Add("90520818000128");
					lstSenhas.Add("041922");lstCNPJ.Add("04192238000117");
					lstSenhas.Add("928528");lstCNPJ.Add("91852871000199");
					lstSenhas.Add("038662");lstCNPJ.Add("03866310000181");
					lstSenhas.Add("038663");lstCNPJ.Add("03866310000262");
					lstSenhas.Add("000197");lstCNPJ.Add("01990883000197");
					lstSenhas.Add("026615");lstCNPJ.Add("02661534000194");
					lstSenhas.Add("012700");lstCNPJ.Add("01270021000190");
					lstSenhas.Add("037687");lstCNPJ.Add("03768727000101");
					lstSenhas.Add("019617");lstCNPJ.Add("01961702000285");
					lstSenhas.Add("048242");lstCNPJ.Add("04824236000101");
					lstSenhas.Add("048242");lstCNPJ.Add("04824236000284");
					lstSenhas.Add("069604");lstCNPJ.Add("06960404000103");
					lstSenhas.Add("052428");lstCNPJ.Add("05242848000140");
					lstSenhas.Add("080811");lstCNPJ.Add("08081164000100");
					lstSenhas.Add("aga4990");lstCNPJ.Add("05909143000134");
					lstSenhas.Add("aga0267");lstCNPJ.Add("04835326000190");
					lstSenhas.Add("aga1000");lstCNPJ.Add("73317356000127");
					lstSenhas.Add("000319");lstCNPJ.Add("72429814000319");
					lstSenhas.Add("026019");lstCNPJ.Add("02601986000180");
					lstSenhas.Add("000190");lstCNPJ.Add("08731624000190");
					lstSenhas.Add("000172");lstCNPJ.Add("92270347000172");
					lstSenhas.Add("000113");lstCNPJ.Add("06202093000113");
					lstSenhas.Add("0129");lstCNPJ.Add("90779240000129");
					lstSenhas.Add("3708");lstCNPJ.Add("92903723000119");
					lstSenhas.Add("088917");lstCNPJ.Add("08891754000190");
					lstSenhas.Add("000192");lstCNPJ.Add("74780321000192");
					lstSenhas.Add("895996");lstCNPJ.Add("89599666000626");
					lstSenhas.Add("000182");lstCNPJ.Add("05256224000182");
					lstSenhas.Add("042897");lstCNPJ.Add("04289769000122");
					lstSenhas.Add("000186");lstCNPJ.Add("94171519000186");
					lstSenhas.Add("916732");lstCNPJ.Add("91673251000516");
					lstSenhas.Add("000192");lstCNPJ.Add("91673251000192");
					lstSenhas.Add("137335");lstCNPJ.Add("03733595000182");
					lstSenhas.Add("catita");lstCNPJ.Add("03733595000182");
					lstSenhas.Add("086197");lstCNPJ.Add("08619746000190");
					lstSenhas.Add("936417");lstCNPJ.Add("93641710000424");
					lstSenhas.Add("875440");lstCNPJ.Add("87544052000107");
					lstSenhas.Add("916732");lstCNPJ.Add("91673251000354");
					lstSenhas.Add("916732");lstCNPJ.Add("91673251001164");
					lstSenhas.Add("916732");lstCNPJ.Add("91673251001679");
					lstSenhas.Add("752080");lstCNPJ.Add("75208016087");
					lstSenhas.Add("368569");lstCNPJ.Add("91362590002959");
					lstSenhas.Add("034897");lstCNPJ.Add("03489764000180");
					lstSenhas.Add("894704");lstCNPJ.Add("89470462000771");
					lstSenhas.Add("087261");lstCNPJ.Add("08726175000192");
					lstSenhas.Add("916746");lstCNPJ.Add("91674655000281");
					lstSenhas.Add("916746");lstCNPJ.Add("91674655000362");
					lstSenhas.Add("916746");lstCNPJ.Add("91674655000443");
					lstSenhas.Add("916746");lstCNPJ.Add("91674655000524");
					lstSenhas.Add("916746");lstCNPJ.Add("91674655000605");
					lstSenhas.Add("916746");lstCNPJ.Add("91674655001415");
					lstSenhas.Add("041767");lstCNPJ.Add("04176743000178");
					lstSenhas.Add("010884");lstCNPJ.Add("01088413000132");
					lstSenhas.Add("929928");lstCNPJ.Add("92992882000137");
					lstSenhas.Add("352600");lstCNPJ.Add("00263596000112");
					lstSenhas.Add("896141");lstCNPJ.Add("89614101000166");
					lstSenhas.Add("075360");lstCNPJ.Add("07536098000145");
					lstSenhas.Add("062859");lstCNPJ.Add("06285909000110");
					lstSenhas.Add("023915");lstCNPJ.Add("02391587000132");
					lstSenhas.Add("000213");lstCNPJ.Add("02391587000213");
					lstSenhas.Add("361482");lstCNPJ.Add("36148270030");
					lstSenhas.Add("058519");lstCNPJ.Add("05851918000168");
					lstSenhas.Add("877234");lstCNPJ.Add("87723417000160");
					lstSenhas.Add("449033");lstCNPJ.Add("44903308049");
					lstSenhas.Add("056659");lstCNPJ.Add("05665942000102");
					lstSenhas.Add("025232");lstCNPJ.Add("02523259000142");
					lstSenhas.Add("030914");lstCNPJ.Add("03091420000119");
					lstSenhas.Add("226892");lstCNPJ.Add("22689249049");
					lstSenhas.Add("916746");lstCNPJ.Add("91674655001172");
					lstSenhas.Add("916746");lstCNPJ.Add("91674655000877");
					lstSenhas.Add("012677");lstCNPJ.Add("01267721000125");
					lstSenhas.Add("895996");lstCNPJ.Add("89599666000545");
					lstSenhas.Add("010564");lstCNPJ.Add("01056433000121");
					lstSenhas.Add("204676");lstCNPJ.Add("20467664072");
					lstSenhas.Add("089817");lstCNPJ.Add("08981780000100");
					lstSenhas.Add("500889");lstCNPJ.Add("50088998053");
					lstSenhas.Add("062304");lstCNPJ.Add("06230416000182");
					lstSenhas.Add("076081");lstCNPJ.Add("07608132000140");
					lstSenhas.Add("887749");lstCNPJ.Add("88774922000105");
					lstSenhas.Add("640572");lstCNPJ.Add("64057232087");
					lstSenhas.Add("396027");lstCNPJ.Add("39602770082");
					lstSenhas.Add("037457");lstCNPJ.Add("03745737000121");
					lstSenhas.Add("055658");lstCNPJ.Add("05565836000157");
					lstSenhas.Add("028886");lstCNPJ.Add("02888685000180");
					lstSenhas.Add("971641");lstCNPJ.Add("97164123000280");
					lstSenhas.Add("915108");lstCNPJ.Add("91510800000108");
					lstSenhas.Add("739317");lstCNPJ.Add("73931743000159");
					lstSenhas.Add("032642");lstCNPJ.Add("03264239000167");
					lstSenhas.Add("868614");lstCNPJ.Add("86861440000159");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113002498");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113006990");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113008500");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113001092");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113001840");
					lstSenhas.Add("296723");lstCNPJ.Add("29672368020");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113004199");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113005241");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175000131");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113006809");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113006132");
					lstSenhas.Add("899050");lstCNPJ.Add("89905020000549");
					lstSenhas.Add("899050");lstCNPJ.Add("89905020000620");
					lstSenhas.Add("899050");lstCNPJ.Add("89905020000115");
					lstSenhas.Add("909693");lstCNPJ.Add("90969387000696");
					lstSenhas.Add("084967");lstCNPJ.Add("08496707000142");
					lstSenhas.Add("901189");lstCNPJ.Add("90118969000154");
					lstSenhas.Add("087739");lstCNPJ.Add("08773950000160");
					lstSenhas.Add("899564");lstCNPJ.Add("89956494000196");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113002064");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113003893");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113003974");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113004008");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113004270");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113004350");
					lstSenhas.Add("909692");lstCNPJ.Add("90969387000424");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113004512");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113004431");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113004784");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113004601");
					lstSenhas.Add("017092");lstCNPJ.Add("01709220000151");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113004865");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113004946");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113005080");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113005160");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113005322");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113005403");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113005594");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113006051");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113006302");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113006485");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113006566");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113006728");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113006647");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113007023");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113007104");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113007295");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113007880");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113007376");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113007457");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113007538");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113007619");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113007708");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113007961");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113008003");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113008348");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113008186");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113008267");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113008429");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113008771");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113008690");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113008852");
					lstSenhas.Add("882121");lstCNPJ.Add("88212113008933");
					lstSenhas.Add("023281");lstCNPJ.Add("02328130000183");
					lstSenhas.Add("923526");lstCNPJ.Add("92352673000129");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175000646");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175000212");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175000484");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175000727");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175000301");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175000565");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175000808");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175000999");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175001022");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175001103");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175001375");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175001294");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175001456");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175001537");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175001618");
					lstSenhas.Add("916732");lstCNPJ.Add("91673251001598");
					lstSenhas.Add("916732");lstCNPJ.Add("91673251001245");
					lstSenhas.Add("916732");lstCNPJ.Add("91673251000435");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175001707");
					lstSenhas.Add("895996");lstCNPJ.Add("89599666000111");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175001880");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175001960");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175002002");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175002185");
					lstSenhas.Add("942833");lstCNPJ.Add("94283314000192");
					lstSenhas.Add("921369");lstCNPJ.Add("92136985000103");
					lstSenhas.Add("920246");lstCNPJ.Add("92024603000141");
					lstSenhas.Add("040858");lstCNPJ.Add("04085812000138");
					lstSenhas.Add("902939");lstCNPJ.Add("90293960000180");
					lstSenhas.Add("087663");lstCNPJ.Add("08766331000149");
					lstSenhas.Add("901200");lstCNPJ.Add("90120007000130");
					lstSenhas.Add("007173");lstCNPJ.Add("00717372000303");
					lstSenhas.Add("982230");lstCNPJ.Add("98223089068");
					lstSenhas.Add("512899");lstCNPJ.Add("51289903034");
					lstSenhas.Add("063540");lstCNPJ.Add("06354019000112");
					lstSenhas.Add("061222");lstCNPJ.Add("06122272000140");
					lstSenhas.Add("901200");lstCNPJ.Add("90120007000300");
					lstSenhas.Add("910336");lstCNPJ.Add("91033621000127");
					lstSenhas.Add("062065");lstCNPJ.Add("06206523000175");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175002347");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175002428");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175002509");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175002690");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175002770");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175002851");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175002932");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175003157");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175003076");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175003238");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175003319");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175003408");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175003580");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175003661");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175003742");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175003823");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175003904");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175004048");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175004129");
					lstSenhas.Add("871893");lstCNPJ.Add("87189395000109");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175004390");
					lstSenhas.Add("942961");lstCNPJ.Add("06208183000111");
					lstSenhas.Add("062081");lstCNPJ.Add("06208183000111");
					lstSenhas.Add("936201");lstCNPJ.Add("93620185000118");
					lstSenhas.Add("352401");lstCNPJ.Add("07976722000125");
					lstSenhas.Add("936417");lstCNPJ.Add("93641710001587");
					lstSenhas.Add("004946");lstCNPJ.Add("00494603000197");
					lstSenhas.Add("083863");lstCNPJ.Add("08386395000114");
					lstSenhas.Add("868699");lstCNPJ.Add("86869971000198");
					lstSenhas.Add("930983");lstCNPJ.Add("93098358000180");
					lstSenhas.Add("080311");lstCNPJ.Add("08031176000112");
					lstSenhas.Add("059725");lstCNPJ.Add("05972580000100");
					lstSenhas.Add("020601");lstCNPJ.Add("02060124000198");
					lstSenhas.Add("919317");lstCNPJ.Add("91931709000166");
					lstSenhas.Add("919317");lstCNPJ.Add("91931709000328");
					lstSenhas.Add("919317");lstCNPJ.Add("91931709000247");
					lstSenhas.Add("026788");lstCNPJ.Add("02678870000140");
					lstSenhas.Add("001199");lstCNPJ.Add("00119978000177");
					lstSenhas.Add("036367");lstCNPJ.Add("03636724000203");
					lstSenhas.Add("060740");lstCNPJ.Add("06074069000146");
					lstSenhas.Add("071089");lstCNPJ.Add("07108963000152");
					lstSenhas.Add("037547");lstCNPJ.Add("03754709000170");
					lstSenhas.Add("086889");lstCNPJ.Add("08688929000167");
					lstSenhas.Add("972909");lstCNPJ.Add("97290977000122");
					lstSenhas.Add("903834");lstCNPJ.Add("90383449000179");
					lstSenhas.Add("941724");lstCNPJ.Add("94172483000155");
					lstSenhas.Add("054754");lstCNPJ.Add("05475475000158");
					lstSenhas.Add("010247");lstCNPJ.Add("01024732000184");
					lstSenhas.Add("082275");lstCNPJ.Add("08227559000160");
					lstSenhas.Add("078947");lstCNPJ.Add("07894760000139");
					lstSenhas.Add("936016");lstCNPJ.Add("93601680000180");
					lstSenhas.Add("031567");lstCNPJ.Add("03156711000148");
					lstSenhas.Add("005759");lstCNPJ.Add("00575929000149");
					lstSenhas.Add("035536");lstCNPJ.Add("03553679000134");
					lstSenhas.Add("023884");lstCNPJ.Add("02388467000186");
					lstSenhas.Add("082152");lstCNPJ.Add("08215243000159");
					lstSenhas.Add("330145");lstCNPJ.Add("33014556000196");
					lstSenhas.Add("013245");lstCNPJ.Add("01324549000102");
					lstSenhas.Add("035523");lstCNPJ.Add("03552385000198");
					lstSenhas.Add("070818");lstCNPJ.Add("07081898000119");
					lstSenhas.Add("053739");lstCNPJ.Add("05373929000180");
					lstSenhas.Add("042392");lstCNPJ.Add("04239277000122");
					lstSenhas.Add("944600");lstCNPJ.Add("94460052000194");
					lstSenhas.Add("057358");lstCNPJ.Add("05735802000163");
					lstSenhas.Add("037040");lstCNPJ.Add("03704057000160");
					lstSenhas.Add("074204");lstCNPJ.Add("07420432000109");
					lstSenhas.Add("868860");lstCNPJ.Add("86886017000103");
					lstSenhas.Add("061964");lstCNPJ.Add("06196445000175");
					lstSenhas.Add("036355");lstCNPJ.Add("03635591000161");
					lstSenhas.Add("000702");lstCNPJ.Add("00070217000178");
					lstSenhas.Add("916563");lstCNPJ.Add("91656371000181");
					lstSenhas.Add("047068");lstCNPJ.Add("04706897000124");
					lstSenhas.Add("895232");lstCNPJ.Add("89523294000301");
					lstSenhas.Add("091515");lstCNPJ.Add("09151557000106");
					lstSenhas.Add("081916");lstCNPJ.Add("08191663000142");
					lstSenhas.Add("068627");lstCNPJ.Add("06862786000132");
					lstSenhas.Add("088592");lstCNPJ.Add("08859251000138");
					lstSenhas.Add("078499");lstCNPJ.Add("07849924000106");
					lstSenhas.Add("046603");lstCNPJ.Add("04660388000108");
					lstSenhas.Add("018976");lstCNPJ.Add("01897653000188");
					lstSenhas.Add("070358");lstCNPJ.Add("07035816000108");
					lstSenhas.Add("084286");lstCNPJ.Add("08428687000172");
					lstSenhas.Add("938667");lstCNPJ.Add("93866739001214");
					lstSenhas.Add("014221");lstCNPJ.Add("01422165000203");
					lstSenhas.Add("933656");lstCNPJ.Add("93365690000163");
					lstSenhas.Add("010845");lstCNPJ.Add("01084522001315");
					lstSenhas.Add("013946");lstCNPJ.Add("01394644000174");
					lstSenhas.Add("078518");lstCNPJ.Add("07851839000182");
					lstSenhas.Add("020942");lstCNPJ.Add("02094242000117");
					lstSenhas.Add("016266");lstCNPJ.Add("01626666000112");
					lstSenhas.Add("889363");lstCNPJ.Add("88936323000485");
					lstSenhas.Add("070848");lstCNPJ.Add("07084893000140");
					lstSenhas.Add("048203");lstCNPJ.Add("04820393000130");
					lstSenhas.Add("077657");lstCNPJ.Add("07765703000150");
					lstSenhas.Add("088155");lstCNPJ.Add("08815577000163");
					lstSenhas.Add("087339");lstCNPJ.Add("08733997000109");
					lstSenhas.Add("030960");lstCNPJ.Add("03096076000150");
					lstSenhas.Add("741251");lstCNPJ.Add("74125105000103");
					lstSenhas.Add("887129");lstCNPJ.Add("88712955000627");
					lstSenhas.Add("061353");lstCNPJ.Add("06135392000182");
					lstSenhas.Add("049026");lstCNPJ.Add("04902601000140");
					lstSenhas.Add("072776");lstCNPJ.Add("07277662000748");
					lstSenhas.Add("933427");lstCNPJ.Add("93342715000103");
					lstSenhas.Add("054701");lstCNPJ.Add("05470137000123");
					lstSenhas.Add("027646");lstCNPJ.Add("02764601000287");
					lstSenhas.Add("074886");lstCNPJ.Add("07488639000107");
					lstSenhas.Add("926656");lstCNPJ.Add("92665611007007");
					lstSenhas.Add("057991");lstCNPJ.Add("05799188000101");
					lstSenhas.Add("056475");lstCNPJ.Add("05647529000115");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175004633");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175004714");
					lstSenhas.Add("949016");lstCNPJ.Add("94901600000174");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175004986");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175005010");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175005109");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175005281");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175005362");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175005443");
					lstSenhas.Add("972517");lstCNPJ.Add("97251755000109");
					lstSenhas.Add("972517");lstCNPJ.Add("97251755000281");
					lstSenhas.Add("018939");lstCNPJ.Add("01893929000150");
					lstSenhas.Add("906249");lstCNPJ.Add("90624941000350");
					lstSenhas.Add("906449");lstCNPJ.Add("90624941000270");
					lstSenhas.Add("054864");lstCNPJ.Add("05486448000180");
					lstSenhas.Add("076762");lstCNPJ.Add("07676230000114");
					lstSenhas.Add("007025");lstCNPJ.Add("00702519000383");
					lstSenhas.Add("900720");lstCNPJ.Add("90072059000269");
					lstSenhas.Add("092615");lstCNPJ.Add("09261510000197");
					lstSenhas.Add("041350");lstCNPJ.Add("04135078000174");
					lstSenhas.Add("059565");lstCNPJ.Add("05956551000147");
					lstSenhas.Add("888899");lstCNPJ.Add("88889999777745");
					lstSenhas.Add("020145");lstCNPJ.Add("02014572000155");
					lstSenhas.Add("092710");lstCNPJ.Add("09271009000101");
					lstSenhas.Add("076642");lstCNPJ.Add("07664276000113");
					lstSenhas.Add("088560");lstCNPJ.Add("08856086000160");
					lstSenhas.Add("076642");lstCNPJ.Add("07664276000202");
					lstSenhas.Add("078437");lstCNPJ.Add("07843738000160");
					lstSenhas.Add("891164");lstCNPJ.Add("89116479000210");
					lstSenhas.Add("749099");lstCNPJ.Add("74909904000170");
					lstSenhas.Add("891203");lstCNPJ.Add("89120323000122");
					lstSenhas.Add("092602");lstCNPJ.Add("09260210000193");
					lstSenhas.Add("951314");lstCNPJ.Add("95131470000109");
					lstSenhas.Add("937910");lstCNPJ.Add("93791010000173");
					lstSenhas.Add("937910");lstCNPJ.Add("93791010000173");
					lstSenhas.Add("047839");lstCNPJ.Add("04783982000196");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175005524");
					lstSenhas.Add("942961");lstCNPJ.Add("94296175005605");
					lstSenhas.Add("095287");lstCNPJ.Add("09528735000167");
					lstSenhas.Add("913880");lstCNPJ.Add("91388074000100");
					lstSenhas.Add("007389");lstCNPJ.Add("00738969000245");
					lstSenhas.Add("962167");lstCNPJ.Add("96216718000199");
					lstSenhas.Add("070410");lstCNPJ.Add("07041074000115");
					lstSenhas.Add("071660");lstCNPJ.Add("07166055000115");
					lstSenhas.Add("093985");lstCNPJ.Add("09398564000107");
					lstSenhas.Add("037223");lstCNPJ.Add("03722348000180");
					lstSenhas.Add("885086");lstCNPJ.Add("88508619000152");
					lstSenhas.Add("083825");lstCNPJ.Add("08382548000155");
					lstSenhas.Add("015691");lstCNPJ.Add("01569107000118");
					lstSenhas.Add("015691");lstCNPJ.Add("01569107000118");
					lstSenhas.Add("024331");lstCNPJ.Add("02433108000101");
					lstSenhas.Add("053310");lstCNPJ.Add("05331016000109");
					lstSenhas.Add("032477");lstCNPJ.Add("03247747000307");
					lstSenhas.Add("913321");lstCNPJ.Add("91332171000173");
					lstSenhas.Add("905784");lstCNPJ.Add("90578410000107");
					lstSenhas.Add("810230");lstCNPJ.Add("87023008000151");
					lstSenhas.Add("972153");lstCNPJ.Add("97215370000188");
					lstSenhas.Add("007025");lstCNPJ.Add("00702519000111");
					
					T_Loja loj = new T_Loja ( this );
					
					for ( int t=0; t < lstCNPJ.Count; ++t )
					{
						if ( loj.select_rows_cnpj ( lstCNPJ[t].ToString() ) )
						{
							if ( loj.fetch() )
							{
								loj.set_st_senha ( lstSenhas[t].ToString() );
								loj.synchronize_T_Loja();
							}
						}
					}
					
					//PatchUserCodeEnd
					break;
				}
				
				case 21:
				{
					//PatchUserCode
					
					T_Parcelas parc 			= new T_Parcelas(this);
					T_Parcelas parc_upd 		= new T_Parcelas(this);
					T_Parcelas parc_fk_error 	= new T_Parcelas(this);
					
					LOG_Transacoes ltr = new LOG_Transacoes(this);
					
					if ( parc.select_rows_dt ( "2008-08-31 00:00:00" ) )
					{
						while ( parc.fetch() )
						{
							parc_upd.selectIdentity ( parc.get_identity() );
							
							ltr.select_rows_nsu_fix ( parc_upd.get_nu_nsu(), parc_upd.get_dt_inclusao() );
							ltr.fetch();
							
							parc_upd.set_fk_log_transacoes ( ltr.get_identity() );
							
							parc_upd.synchronize_T_Parcelas();
						}
					}
					
					//PatchUserCodeEnd
					break;
				}
				
				case 22:
				{
					//PatchUserCode
					
					T_Parcelas parc     = new T_Parcelas (this);
					T_Parcelas parc_nsu = new T_Parcelas (this);
					T_Parcelas parc_fix = new T_Parcelas (this);
					
					Hashtable hsh_done = new Hashtable();
					
					// indice > 1
					if ( parc.select_rows_fix_nu_parc ( "1" ) )
					{
						while ( parc.fetch() )
						{
							if ( hsh_done [ parc.get_nu_nsu() + parc.get_dt_inclusao() ] != null )
								continue;
							
							if ( parc_nsu.select_rows_fix_nsu_dt_parc ( parc.get_nu_nsu(), parc.get_dt_inclusao() ) )
							{
								if ( parc_nsu.RowCount() > 1 )
								{
									hsh_done [ parc.get_nu_nsu() + parc.get_dt_inclusao() ] = "*";
									
									#region - arruma -
									
									Hashtable hsh_id = new Hashtable();
									ArrayList lst_id  = new ArrayList();
									
									while ( parc_nsu.fetch() )
									{
										if ( parc_nsu.get_int_nu_parcela() > 0 )
										{
											string nu_indice =  parc_nsu.get_nu_indice().PadLeft ( 2, '0' );
											
											lst_id.Add ( nu_indice );
											
											hsh_id [ nu_indice ] = parc_nsu.get_identity();
										}
									}									
									
									lst_id.Sort();
									
									for ( int t=0; t < lst_id.Count; ++t )
									{
										string id = hsh_id [ lst_id[t].ToString() ] as string;
										
										parc_fix.selectIdentity ( id 				);
										parc_fix.set_nu_parcela ( (t+1).ToString() 	);
										
										parc_fix.synchronize_T_Parcelas();
									}
									
									#endregion									
								}
							}
						}
					}
							
					//PatchUserCodeEnd
					break;
				}
				
				case 23:
				{
					//PatchUserCode
					
					T_Parcelas parc = new T_Parcelas (this);
					T_Parcelas parc_upd = new T_Parcelas (this);
					
					LOG_Transacoes ltr = new LOG_Transacoes(this);
					
					if ( parc.selectAll() )
					{
						while ( parc.fetch() )
						{
							if ( ltr.select_rows_nsu_fix ( parc.get_nu_nsu(), parc.get_dt_inclusao() ) )
							{
								if ( ltr.fetch() )
								{
									if ( parc.get_fk_log_transacoes() != ltr.get_identity() )
									{
										parc_upd.selectIdentity ( parc.get_identity() );
										
										parc_upd.set_fk_log_transacoes ( ltr.get_identity() );
										
										parc_upd.synchronize_T_Parcelas();
									}
								}
							}
						}
					}
					
					//PatchUserCodeEnd
					break;
				}
				
				case 24:
				{
					//PatchUserCode
					
					LOG_Fechamento lf 	  = new LOG_Fechamento (this);
					LOG_Fechamento lf_del = new LOG_Fechamento (this);
					
					T_Parcelas parc 	= new T_Parcelas (this);
					T_Parcelas parc_nsu = new T_Parcelas (this);
					T_Parcelas parc_fix = new T_Parcelas (this);
					
					ArrayList lstParcelasAlteradas = new ArrayList();
						
					if ( lf.select_rows_mes_ano ( "09", "2008", "6" ) )
					{
						string chave_anterior = "";
						
						while ( lf.fetch() )
						{
							string chave = lf.get_fk_loja() + lf.get_fk_cartao() + lf.get_dt_compra();
							
							if ( chave != chave_anterior )
							{
								chave_anterior = chave;
							}
							else
							{
								// ajusta parcela
								
								parc.selectIdentity ( lf.get_fk_parcela() );
								parc.set_nu_parcela ( 1 );
								
								parc.synchronize_T_Parcelas();
								
								lstParcelasAlteradas.Add ( parc.get_identity() );
								
								// remove fechamento incorreto
								
								lf_del.selectIdentity ( lf.get_identity() );
								lf_del.delete();
							}
						}
					}				
					
					for ( int g=0; g < lstParcelasAlteradas.Count; ++g )
					{
						parc.selectIdentity ( lstParcelasAlteradas[g].ToString() );
						
						if ( parc_nsu.select_rows_nsu_dt ( parc.get_nu_nsu(), 
						                                   parc.get_dt_inclusao() ) )
					    {
							Hashtable hsh_id = new Hashtable();
							ArrayList lst_id  = new ArrayList();
								
							while ( parc_nsu.fetch() )
							{
								if ( parc_nsu.get_int_nu_parcela() > 0 )
								{
									string nu_indice =  parc_nsu.get_nu_indice().PadLeft ( 2, '0' );
									
									lst_id.Add ( nu_indice );
									
									hsh_id [ nu_indice ] = parc_nsu.get_identity();
								}
							}									
							
							lst_id.Sort();
							
							for ( int t=0; t < lst_id.Count; ++t )
							{
								string id = hsh_id [ lst_id[t].ToString() ] as string;
								
								parc_fix.selectIdentity ( id 				);
								parc_fix.set_nu_parcela ( (t+1).ToString() 	);
								
								parc_fix.synchronize_T_Parcelas();
							}
					    }
					}
					
					//PatchUserCodeEnd
					break;
				}
				
				case 25:
				{
					//PatchUserCode
					
					T_Loja loj = new T_Loja (this);
					
					loj.selectAll();
					
					while ( loj.fetch() )
					{
						if ( loj.get_int_nu_pctValor() > 0 )
						{
							T_Faturamento fat = new T_Faturamento(this);
							T_Faturamento fat_upd = new T_Faturamento(this);
							
							if ( fat.select_rows_loj ( loj.get_identity() ) )
							{
								while ( fat.fetch() )
								{
									if ( fat.get_dt_vencimento() == "2008-10-03 00:00:00" )
									{
										long vr_total_cobranca = 0;
										
										T_FaturamentoDetalhes fat_det     = new T_FaturamentoDetalhes (this);
										T_FaturamentoDetalhes fat_det_upd = new T_FaturamentoDetalhes (this);
										
										if ( fat_det.select_fk_fat ( fat.get_identity() ) )
										{
											while ( fat_det.fetch() )
											{
												if ( fat_det.get_tg_tipoFat() == TipoFat.Percent )
												{
													fat_det_upd.selectIdentity ( fat_det.get_identity() );
													
													LOG_Transacoes l_tr = new LOG_Transacoes (this);
													
													long vr_trans = 0;
													
													if ( l_tr.select_rows_dt_loj ( 	"2008-08-20 00:00:00",
																					"2008-09-20 00:00:00",  
																					loj.get_identity() ) )
													{
														while ( l_tr.fetch() )
															if ( l_tr.get_tg_confirmada() == TipoConfirmacao.Confirmada ) 
																vr_trans += l_tr.get_int_vr_total();
														
														if ( vr_trans > 0 )
														{
															vr_trans = vr_trans * loj.get_int_nu_pctValor()/10000;
														}
													}
													
													vr_total_cobranca += vr_trans;
													
													fat_det_upd.set_vr_cobranca ( vr_trans );
													
													fat_det_upd.synchronize_T_FaturamentoDetalhes();
												}
												else
												{
													vr_total_cobranca += fat_det.get_int_vr_cobranca();
												}													
											}
										}
										
										fat_upd.selectIdentity ( fat.get_identity() );
										
										fat_upd.set_vr_cobranca ( vr_total_cobranca );
										
										fat_upd.synchronize_T_Faturamento();
									}
								}
							}
						}						
					}
					
					//PatchUserCodeEnd
					break;
				}
				
				case 26:
				{
					//PatchUserCode
					
					ArrayList lstTerm = new ArrayList();
					
					lstTerm.Add ( "38" );
					lstTerm.Add ( "40" );
					lstTerm.Add ( "41" );
					lstTerm.Add ( "43" );
					lstTerm.Add ( "46" );
					lstTerm.Add ( "47" );
					lstTerm.Add ( "85" );
					lstTerm.Add ( "86" );
					lstTerm.Add ( "88" );
					lstTerm.Add ( "89" );
					lstTerm.Add ( "52" );
					lstTerm.Add ( "53" );
					lstTerm.Add ( "55" );
					lstTerm.Add ( "56" );
					lstTerm.Add ( "66" );
					lstTerm.Add ( "67" );
					lstTerm.Add ( "68" );
					lstTerm.Add ( "60" );
					lstTerm.Add ( "64" );
					lstTerm.Add ( "7" );
					lstTerm.Add ( "71" );
					lstTerm.Add ( "11" );
					lstTerm.Add ( "16" );
					lstTerm.Add ( "17" );
					lstTerm.Add ( "18" );
					lstTerm.Add ( "96" );
					lstTerm.Add ( "101" );
					lstTerm.Add ( "102" );
					lstTerm.Add ( "104" );
					lstTerm.Add ( "110" );
					lstTerm.Add ( "111" );
					lstTerm.Add ( "112" );
					lstTerm.Add ( "113" );
					lstTerm.Add ( "114" );
					lstTerm.Add ( "115" );
					lstTerm.Add ( "82" );
					lstTerm.Add ( "83" );
					lstTerm.Add ( "118" );
					lstTerm.Add ( "122" );
					lstTerm.Add ( "124" );
					lstTerm.Add ( "125" );
					lstTerm.Add ( "126" );
					lstTerm.Add ( "128" );
					lstTerm.Add ( "130" );
					lstTerm.Add ( "132" );
					lstTerm.Add ( "133" );
					lstTerm.Add ( "134" );
					lstTerm.Add ( "137" );
					lstTerm.Add ( "138" );
					lstTerm.Add ( "139" );
					lstTerm.Add ( "141" );
					lstTerm.Add ( "143" );
					lstTerm.Add ( "151" );
					lstTerm.Add ( "152" );
					lstTerm.Add ( "156" );
					lstTerm.Add ( "157" );
					lstTerm.Add ( "171" );
					lstTerm.Add ( "189" );
					lstTerm.Add ( "192" );
					lstTerm.Add ( "194" );
					lstTerm.Add ( "195" );
					lstTerm.Add ( "196" );
					lstTerm.Add ( "197" );
					lstTerm.Add ( "198" );
					lstTerm.Add ( "199" );
					lstTerm.Add ( "200" );
					lstTerm.Add ( "201" );
					lstTerm.Add ( "202" );
					lstTerm.Add ( "203" );
					lstTerm.Add ( "204" );
					lstTerm.Add ( "205" );
					lstTerm.Add ( "206" );
					lstTerm.Add ( "207" );
					lstTerm.Add ( "208" );
					lstTerm.Add ( "209" );
					lstTerm.Add ( "210" );
					lstTerm.Add ( "211" );
					lstTerm.Add ( "212" );
					lstTerm.Add ( "213" );
					lstTerm.Add ( "214" );
					lstTerm.Add ( "215" );
					lstTerm.Add ( "216" );
					lstTerm.Add ( "217" );
					lstTerm.Add ( "218" );
					lstTerm.Add ( "219" );
					lstTerm.Add ( "220" );
					lstTerm.Add ( "221" );
					lstTerm.Add ( "222" );
					lstTerm.Add ( "223" );
					lstTerm.Add ( "225" );
					lstTerm.Add ( "226" );
					lstTerm.Add ( "227" );
					lstTerm.Add ( "229" );
					lstTerm.Add ( "230" );
					lstTerm.Add ( "231" );
					lstTerm.Add ( "232" );
					lstTerm.Add ( "233" );
					lstTerm.Add ( "234" );
					lstTerm.Add ( "235" );
					lstTerm.Add ( "237" );
					lstTerm.Add ( "238" );
					lstTerm.Add ( "239" );
					lstTerm.Add ( "240" );
					lstTerm.Add ( "241" );
					lstTerm.Add ( "242" );
					lstTerm.Add ( "243" );
					lstTerm.Add ( "244" );
					lstTerm.Add ( "245" );
					lstTerm.Add ( "246" );
					lstTerm.Add ( "247" );
					lstTerm.Add ( "248" );
					lstTerm.Add ( "249" );
					lstTerm.Add ( "250" );
					lstTerm.Add ( "251" );
					lstTerm.Add ( "252" );
					lstTerm.Add ( "253" );
					lstTerm.Add ( "254" );
					lstTerm.Add ( "255" );
					lstTerm.Add ( "256" );
					lstTerm.Add ( "257" );
					lstTerm.Add ( "264" );
					lstTerm.Add ( "268" );
					lstTerm.Add ( "269" );
					lstTerm.Add ( "270" );
					lstTerm.Add ( "271" );
					lstTerm.Add ( "272" );
					lstTerm.Add ( "273" );
					lstTerm.Add ( "274" );
					lstTerm.Add ( "275" );
					lstTerm.Add ( "276" );
					lstTerm.Add ( "277" );
					lstTerm.Add ( "278" );
					lstTerm.Add ( "279" );
					lstTerm.Add ( "280" );
					lstTerm.Add ( "281" );
					lstTerm.Add ( "282" );
					lstTerm.Add ( "283" );
					lstTerm.Add ( "286" );
					lstTerm.Add ( "287" );
					lstTerm.Add ( "288" );
					lstTerm.Add ( "289" );
					lstTerm.Add ( "290" );
					lstTerm.Add ( "371" );
					lstTerm.Add ( "372" );
					lstTerm.Add ( "374" );
					lstTerm.Add ( "375" );
					lstTerm.Add ( "376" );
					lstTerm.Add ( "377" );
					lstTerm.Add ( "378" );
					lstTerm.Add ( "379" );
					lstTerm.Add ( "383" );
					lstTerm.Add ( "391" );
					lstTerm.Add ( "400" );
					lstTerm.Add ( "423" );
					lstTerm.Add ( "424" );
					lstTerm.Add ( "405" );
					lstTerm.Add ( "26" );
					lstTerm.Add ( "29" );
					lstTerm.Add ( "30" );
					lstTerm.Add ( "31" );
					lstTerm.Add ( "107" );
					lstTerm.Add ( "1" );
					lstTerm.Add ( "33" );
					lstTerm.Add ( "35" );
					
					T_Terminal term = new T_Terminal (this);
					
					for ( int t=0; t < lstTerm.Count; ++t )
					{
						string id = lstTerm[t].ToString();
						
						if ( term.selectIdentity ( id ) )
						{
							term.set_fk_loja ( "0" );
							term.synchronize_T_Terminal();
						}
					}
					
					//PatchUserCodeEnd
					break;
				}
				
				case 27:
				{
					//PatchUserCode
					
					ArrayList lstMat = new ArrayList();
					ArrayList lstVal = new ArrayList();

					#region = pain == 
						
					lstMat.Add("000156"); lstVal.Add("13990");
					lstMat.Add("000181"); lstVal.Add("1750");
					lstMat.Add("000185"); lstVal.Add("2990");
					lstMat.Add("000187"); lstVal.Add("2000");
					lstMat.Add("000190"); lstVal.Add("2190");
					lstMat.Add("000193"); lstVal.Add("1860");
					lstMat.Add("000194"); lstVal.Add("3000");
					lstMat.Add("000202"); lstVal.Add("12000");
					lstMat.Add("000204"); lstVal.Add("5000");
					lstMat.Add("000204"); lstVal.Add("2000");
					lstMat.Add("000209"); lstVal.Add("9500");
					lstMat.Add("000209"); lstVal.Add("250");
					lstMat.Add("000210"); lstVal.Add("11556");
					lstMat.Add("000212"); lstVal.Add("20000");
					lstMat.Add("000213"); lstVal.Add("20000");
					lstMat.Add("000214"); lstVal.Add("2450");
					lstMat.Add("000215"); lstVal.Add("5000");
					lstMat.Add("000216"); lstVal.Add("1250");
					lstMat.Add("000216"); lstVal.Add("460");
					lstMat.Add("000217"); lstVal.Add("1900");
					lstMat.Add("000221"); lstVal.Add("3000");
					lstMat.Add("000222"); lstVal.Add("3000");
					lstMat.Add("000223"); lstVal.Add("8470");
					lstMat.Add("000223"); lstVal.Add("1416");
					lstMat.Add("000226"); lstVal.Add("2950");
					lstMat.Add("000227"); lstVal.Add("1900");
					lstMat.Add("000231"); lstVal.Add("4000");
					lstMat.Add("000232"); lstVal.Add("2000");
					lstMat.Add("000233"); lstVal.Add("3500");
					lstMat.Add("000234"); lstVal.Add("2000");
					lstMat.Add("000236"); lstVal.Add("9396");
					lstMat.Add("000237"); lstVal.Add("1200");
					lstMat.Add("000237"); lstVal.Add("17990");
					lstMat.Add("000237"); lstVal.Add("760");
					lstMat.Add("000239"); lstVal.Add("5000");
					lstMat.Add("000245"); lstVal.Add("2000");
					lstMat.Add("000253"); lstVal.Add("5000");
					lstMat.Add("000254"); lstVal.Add("2000");
					lstMat.Add("000258"); lstVal.Add("10");
					lstMat.Add("000258"); lstVal.Add("01");
					lstMat.Add("000258"); lstVal.Add("1490");
					lstMat.Add("000259"); lstVal.Add("2000");
					lstMat.Add("000261"); lstVal.Add("5000");
					lstMat.Add("000273"); lstVal.Add("3000");
					lstMat.Add("000274"); lstVal.Add("10000");
					lstMat.Add("000275"); lstVal.Add("2500");
					lstMat.Add("000276"); lstVal.Add("2000");
					lstMat.Add("000277"); lstVal.Add("3000");
					lstMat.Add("000278"); lstVal.Add("1990");
					lstMat.Add("000279"); lstVal.Add("3000");
					lstMat.Add("000281"); lstVal.Add("3000");
					lstMat.Add("000283"); lstVal.Add("2500");
					lstMat.Add("000284"); lstVal.Add("3000");
					lstMat.Add("000285"); lstVal.Add("2000");
					lstMat.Add("000289"); lstVal.Add("4000");
					lstMat.Add("000291"); lstVal.Add("3488");
					lstMat.Add("000291"); lstVal.Add("1500");
					lstMat.Add("000292"); lstVal.Add("3000");
					lstMat.Add("000298"); lstVal.Add("2500");
					lstMat.Add("000299"); lstVal.Add("2500");
					lstMat.Add("000300"); lstVal.Add("7000");
					lstMat.Add("000301"); lstVal.Add("2000");
					lstMat.Add("000303"); lstVal.Add("7900");
					lstMat.Add("000309"); lstVal.Add("3000");
					lstMat.Add("000313"); lstVal.Add("1490");
					lstMat.Add("000314"); lstVal.Add("2000");
					lstMat.Add("000314"); lstVal.Add("390");
					lstMat.Add("000314"); lstVal.Add("2598");
					lstMat.Add("000314"); lstVal.Add("2100");
					lstMat.Add("000502"); lstVal.Add("2000");
					lstMat.Add("000505"); lstVal.Add("2490");
					lstMat.Add("000505"); lstVal.Add("1000");
					lstMat.Add("000506"); lstVal.Add("2000");
					lstMat.Add("000509"); lstVal.Add("2980");
					lstMat.Add("000510"); lstVal.Add("1710");
					lstMat.Add("000510"); lstVal.Add("440");
					lstMat.Add("000514"); lstVal.Add("3500");
					lstMat.Add("000518"); lstVal.Add("2000");
					lstMat.Add("000519"); lstVal.Add("4705");
					lstMat.Add("000520"); lstVal.Add("4000");
					lstMat.Add("000522"); lstVal.Add("2050");
					lstMat.Add("000523"); lstVal.Add("1990");
					lstMat.Add("000525"); lstVal.Add("3000");
					lstMat.Add("000529"); lstVal.Add("917");
					lstMat.Add("000529"); lstVal.Add("1612");
					lstMat.Add("000529"); lstVal.Add("1290");
					lstMat.Add("000529"); lstVal.Add("1080");
					lstMat.Add("000531"); lstVal.Add("2000");
					lstMat.Add("000532"); lstVal.Add("2000");
					lstMat.Add("000538"); lstVal.Add("2000");
					lstMat.Add("000539"); lstVal.Add("2574");
					lstMat.Add("000539"); lstVal.Add("3490");
					lstMat.Add("000543"); lstVal.Add("7000");
					lstMat.Add("000544"); lstVal.Add("3000");
					lstMat.Add("000545"); lstVal.Add("3000");
					lstMat.Add("000548"); lstVal.Add("1696");
					lstMat.Add("000548"); lstVal.Add("1150");
					lstMat.Add("000548"); lstVal.Add("1100");
					lstMat.Add("000549"); lstVal.Add("1690");
					lstMat.Add("000552"); lstVal.Add("3000");
					lstMat.Add("000554"); lstVal.Add("14500");
					lstMat.Add("000554"); lstVal.Add("5500");
					lstMat.Add("000556"); lstVal.Add("3000");
					lstMat.Add("000557"); lstVal.Add("4970");
					lstMat.Add("000558"); lstVal.Add("999");
					lstMat.Add("000558"); lstVal.Add("2000");
					lstMat.Add("000559"); lstVal.Add("2000");
					lstMat.Add("000562"); lstVal.Add("2000");
					lstMat.Add("000569"); lstVal.Add("10000");
					lstMat.Add("000570"); lstVal.Add("1999");
					lstMat.Add("000570"); lstVal.Add("8001");
					lstMat.Add("000573"); lstVal.Add("3000");
					lstMat.Add("000574"); lstVal.Add("3124");
					lstMat.Add("000574"); lstVal.Add("1793");
					lstMat.Add("000574"); lstVal.Add("2000");
					lstMat.Add("000574"); lstVal.Add("2768");
					lstMat.Add("000574"); lstVal.Add("1028");
					lstMat.Add("000574"); lstVal.Add("1060");
					lstMat.Add("000579"); lstVal.Add("1750");
					lstMat.Add("000580"); lstVal.Add("1000");
					lstMat.Add("000585"); lstVal.Add("2000");
					lstMat.Add("000586"); lstVal.Add("1990");
					lstMat.Add("000590"); lstVal.Add("2000");
					lstMat.Add("000593"); lstVal.Add("6000");
					lstMat.Add("000594"); lstVal.Add("3500");
					lstMat.Add("000595"); lstVal.Add("3970");
					lstMat.Add("000596"); lstVal.Add("3900");
					lstMat.Add("000597"); lstVal.Add("450");
					lstMat.Add("000597"); lstVal.Add("1010");
					lstMat.Add("000597"); lstVal.Add("10690");
					lstMat.Add("000597"); lstVal.Add("4320");
					lstMat.Add("000597"); lstVal.Add("980");
					lstMat.Add("000597"); lstVal.Add("850");
					lstMat.Add("000597"); lstVal.Add("850");
					lstMat.Add("000599"); lstVal.Add("2395");
					lstMat.Add("000600"); lstVal.Add("6990");
					lstMat.Add("000600"); lstVal.Add("3000");
					lstMat.Add("000601"); lstVal.Add("2000");
					lstMat.Add("000604"); lstVal.Add("10000");
					lstMat.Add("000605"); lstVal.Add("15000");
					lstMat.Add("000606"); lstVal.Add("15000");
					lstMat.Add("000607"); lstVal.Add("3990");
					lstMat.Add("000607"); lstVal.Add("3945");
					lstMat.Add("000612"); lstVal.Add("4350");
					lstMat.Add("000613"); lstVal.Add("3000");
					lstMat.Add("000619"); lstVal.Add("4000");
					lstMat.Add("000626"); lstVal.Add("4550");
					lstMat.Add("000627"); lstVal.Add("1490");
					lstMat.Add("000629"); lstVal.Add("4660");
					lstMat.Add("000629"); lstVal.Add("7350");
					lstMat.Add("000629"); lstVal.Add("7990");
					lstMat.Add("000636"); lstVal.Add("2000");
					lstMat.Add("000637"); lstVal.Add("1167");
					lstMat.Add("000749"); lstVal.Add("5000");
					lstMat.Add("000751"); lstVal.Add("2000");
					lstMat.Add("000753"); lstVal.Add("300");
					lstMat.Add("000753"); lstVal.Add("1700");
					lstMat.Add("000756"); lstVal.Add("4000");
					lstMat.Add("000760"); lstVal.Add("2000");
					lstMat.Add("000762"); lstVal.Add("1050");
					lstMat.Add("000762"); lstVal.Add("950");
					lstMat.Add("000763"); lstVal.Add("10000");
					lstMat.Add("000765"); lstVal.Add("4500");
					lstMat.Add("000766"); lstVal.Add("3000");
					lstMat.Add("000770"); lstVal.Add("4000");
					lstMat.Add("000772"); lstVal.Add("2000");
					lstMat.Add("000773"); lstVal.Add("2000");
					lstMat.Add("000774"); lstVal.Add("2000");
					lstMat.Add("000778"); lstVal.Add("2000");
					lstMat.Add("000779"); lstVal.Add("5000");
					lstMat.Add("000780"); lstVal.Add("2000");
					lstMat.Add("000782"); lstVal.Add("2000");
					lstMat.Add("000785"); lstVal.Add("2000");
					lstMat.Add("000786"); lstVal.Add("2000");
					lstMat.Add("000787"); lstVal.Add("2999");
					lstMat.Add("000787"); lstVal.Add("1980");
					lstMat.Add("000793"); lstVal.Add("4999");
					lstMat.Add("000797"); lstVal.Add("480");
					lstMat.Add("000797"); lstVal.Add("1520");
					lstMat.Add("000798"); lstVal.Add("1995");
					lstMat.Add("000799"); lstVal.Add("1990");
					lstMat.Add("000802"); lstVal.Add("3000");
					lstMat.Add("000804"); lstVal.Add("2800");
					lstMat.Add("000805"); lstVal.Add("3000");
					lstMat.Add("000806"); lstVal.Add("3000");
					lstMat.Add("000807"); lstVal.Add("1990");
					lstMat.Add("000807"); lstVal.Add("1010");
					lstMat.Add("000809"); lstVal.Add("3000");
					lstMat.Add("000811"); lstVal.Add("3000");
					lstMat.Add("000812"); lstVal.Add("3000");
					lstMat.Add("000815"); lstVal.Add("3000");
					lstMat.Add("000816"); lstVal.Add("3000");
					lstMat.Add("000817"); lstVal.Add("3000");
					lstMat.Add("000818"); lstVal.Add("3000");
					lstMat.Add("000820"); lstVal.Add("3000");
					lstMat.Add("000822"); lstVal.Add("13970");
					lstMat.Add("000822"); lstVal.Add("2100");
					lstMat.Add("000824"); lstVal.Add("2990");
					lstMat.Add("000824"); lstVal.Add("2000");
					lstMat.Add("000826"); lstVal.Add("1594");
					lstMat.Add("000826"); lstVal.Add("310");
					lstMat.Add("000830"); lstVal.Add("10000");
					lstMat.Add("000831"); lstVal.Add("9970");
					lstMat.Add("000833"); lstVal.Add("2990");
					lstMat.Add("000833"); lstVal.Add("2000");
					lstMat.Add("000836"); lstVal.Add("2000");
					lstMat.Add("000840"); lstVal.Add("5000");
					lstMat.Add("000842"); lstVal.Add("3000");
					lstMat.Add("000843"); lstVal.Add("3000");
					lstMat.Add("000844"); lstVal.Add("2999");
					lstMat.Add("000846"); lstVal.Add("5000");
					lstMat.Add("000848"); lstVal.Add("4990");
					lstMat.Add("000849"); lstVal.Add("5000");
					lstMat.Add("000855"); lstVal.Add("5000");
					lstMat.Add("000856"); lstVal.Add("5000");
					lstMat.Add("000858"); lstVal.Add("5000");
					lstMat.Add("000859"); lstVal.Add("5000");
					lstMat.Add("000860"); lstVal.Add("5000");
					lstMat.Add("000865"); lstVal.Add("5000");
					lstMat.Add("000872"); lstVal.Add("2000");
					lstMat.Add("000873"); lstVal.Add("5000");
					lstMat.Add("000879"); lstVal.Add("2000");
					lstMat.Add("000880"); lstVal.Add("4000");
					lstMat.Add("000881"); lstVal.Add("2000");
					lstMat.Add("000882"); lstVal.Add("4597");
					lstMat.Add("000882"); lstVal.Add("2695");
					lstMat.Add("000882"); lstVal.Add("12650");
					lstMat.Add("000883"); lstVal.Add("4000");
					lstMat.Add("000884"); lstVal.Add("2000");
					lstMat.Add("000894"); lstVal.Add("6000");
					lstMat.Add("000895"); lstVal.Add("2490");
					lstMat.Add("000896"); lstVal.Add("8000");
					lstMat.Add("000900"); lstVal.Add("2000");
					lstMat.Add("000905"); lstVal.Add("6980");
					lstMat.Add("000908"); lstVal.Add("1798");
					lstMat.Add("000908"); lstVal.Add("199");
					lstMat.Add("000909"); lstVal.Add("5000");
					lstMat.Add("000910"); lstVal.Add("5000");
					lstMat.Add("000911"); lstVal.Add("9900");
					lstMat.Add("000911"); lstVal.Add("10000");
					lstMat.Add("000913"); lstVal.Add("290");
					lstMat.Add("000913"); lstVal.Add("290");
					lstMat.Add("000913"); lstVal.Add("1890");
					lstMat.Add("000917"); lstVal.Add("2000");
					lstMat.Add("000920"); lstVal.Add("7195");
					lstMat.Add("000921"); lstVal.Add("7000");
					lstMat.Add("000921"); lstVal.Add("1000");
					lstMat.Add("000921"); lstVal.Add("7000");
					lstMat.Add("000925"); lstVal.Add("3238");
					lstMat.Add("000925"); lstVal.Add("8065");
					lstMat.Add("000925"); lstVal.Add("18697");
					lstMat.Add("000926"); lstVal.Add("4380");
					lstMat.Add("000926"); lstVal.Add("2740");
					lstMat.Add("000926"); lstVal.Add("17183");
					lstMat.Add("000926"); lstVal.Add("990");
					lstMat.Add("000926"); lstVal.Add("2700");
					lstMat.Add("000927"); lstVal.Add("1990");
					lstMat.Add("000933"); lstVal.Add("2000");
					lstMat.Add("000935"); lstVal.Add("5980");
					lstMat.Add("000935"); lstVal.Add("2348");
					lstMat.Add("000935"); lstVal.Add("1600");
					lstMat.Add("000943"); lstVal.Add("2990");
					lstMat.Add("000976"); lstVal.Add("20");
					lstMat.Add("000976"); lstVal.Add("3990");
					lstMat.Add("000976"); lstVal.Add("1990");
					lstMat.Add("000977"); lstVal.Add("6000");
					lstMat.Add("000978"); lstVal.Add("4400");
					lstMat.Add("000979"); lstVal.Add("124");
					lstMat.Add("000979"); lstVal.Add("2896");
					lstMat.Add("000979"); lstVal.Add("2980");
					lstMat.Add("000980"); lstVal.Add("3596");
					lstMat.Add("000981"); lstVal.Add("6000");
					lstMat.Add("000982"); lstVal.Add("6000");
					lstMat.Add("000983"); lstVal.Add("6000");
					lstMat.Add("000984"); lstVal.Add("6000");
					lstMat.Add("000985"); lstVal.Add("6000");
					lstMat.Add("000988"); lstVal.Add("6000");
					lstMat.Add("000989"); lstVal.Add("6000");
					lstMat.Add("000990"); lstVal.Add("6000");
					lstMat.Add("000994"); lstVal.Add("4000");
					lstMat.Add("000996"); lstVal.Add("4000");
										
					#endregion

					T_Cartao cart = new T_Cartao (this);
					
					for ( int t=0; t < lstMat.Count; ++t )
					{
						cart.select_rows_empresa_matricula ( "003522", lstMat[t].ToString() );
						
						cart.fetch();
						
						long tmp = Convert.ToInt64 ( lstVal[t].ToString() );
						long res = cart.get_int_vr_limiteTotal() - tmp;
						
						if ( res < 0 ) res = 0;
						
						cart.set_vr_limiteTotal ( res );
						
						cart.synchronize_T_Cartao();
					}
					
					//PatchUserCodeEnd
					break;
				}
				
				default:break;
			}
			
			return true;
		}
	}
}
