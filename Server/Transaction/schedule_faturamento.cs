using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class schedule_faturamento : schedule_base
	{
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public schedule_faturamento ( Transaction trans ) : base (trans)
		{
			var_Alias = "schedule_faturamento";
			constructor();
		}
		
		public schedule_faturamento()
		{
			var_Alias = "schedule_faturamento";
		
			ut_max = 0;
			
			constructor();
		}
		
		public override void constructor()
		{
			/// USER [ constructor ]
			/// USER [ constructor ] END
		}
		
		public override bool setup ( ) 
		{
			#region - SETUP TRANSACTION -
			Registry ( "setup schedule_faturamento " ); 
		
			Registry ( "setup done schedule_faturamento " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate schedule_faturamento " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done schedule_faturamento " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute schedule_faturamento " ); 
		
			/// USER [ execute ]
			 
			T_Empresa	emp    = new T_Empresa( this );
			DateTime 	dtFat  = DateTime.Now.AddDays(-1);
			
			#region - ## Busca todas as empresas -
						
			if ( emp.selectAll() )
			{
				// ## Busco todos os registros
				
				while ( emp.fetch() )
				{
					// ## Se dia é hoje
					
					if ( emp.get_int_nu_periodoFat() == dtFat.Day && 
					          emp.get_tg_isentoFat() == Context.FALSE )
					{
						T_Faturamento fat     = new T_Faturamento (this);
						T_Faturamento fat_upd = new T_Faturamento (this);
						
						DateTime aux = dtFat;
							
						// ## Para casos onde o mês deve ser o próximo
						
						if ( emp.get_int_nu_diaVenc() < dtFat.Day )
							aux = dtFat.AddMonths ( 1 );
						
						DateTime dtVenc = new DateTime ( aux.Year, 
						                                 aux.Month, 
						                                 (int) emp.get_int_nu_diaVenc() );
							
						fat.set_dt_vencimento ( GetDataBaseTime ( dtVenc) 	);
						fat.set_fk_empresa 	  ( emp.get_identity() 			);
						fat.set_tg_situacao   ( TipoSitFat.Pendente 		);
												
						// ## Crio registro
						
						fat.create_T_Faturamento();
						
						long vr_total_fat = 0;
						
						// ## Crio registro detalhe
						
						#region - 1 - mensalidade - 
												
						{
							T_FaturamentoDetalhes fat_det = new T_FaturamentoDetalhes (this);
							
							fat_det.set_fk_fatura 		( fat.get_identity() 		);
							fat_det.set_vr_cobranca 	( emp.get_vr_mensalidade() 	);
							fat_det.set_tg_tipoFat   	( TipoFat.TBM 				);
							fat_det.set_tg_desconto		( Context.FALSE );
							fat_det.set_fk_empresa		( emp.get_identity() 	);
							fat_det.set_fk_loja			( Context.FALSE 		);
							
							vr_total_fat += fat_det.get_int_vr_cobranca();
							
							fat_det.create_T_FaturamentoDetalhes();
						}
						
						#endregion
						
						#region - 2 - valor por transações -
												
						if ( emp.get_int_vr_transacao() > 0 )
						{
							LOG_Transacoes l_tr = new LOG_Transacoes (this);
							
							l_tr.SetCountMode();
					
							l_tr.select_rows_dt_emp ( GetDataBaseTime ( dtFat.AddMonths (-1) ),
							                          GetDataBaseTime ( dtFat ),  
							                          emp.get_identity() );
							
							long trans = l_tr.GetCount() - emp.get_int_nu_franquia();
							
							if ( trans > 0 )
							{
								T_FaturamentoDetalhes fat_det = new T_FaturamentoDetalhes (this);
								
								fat_det.set_fk_fatura 		( fat.get_identity() 									);
								fat_det.set_vr_cobranca 	( ( trans * emp.get_int_vr_transacao() ).ToString() 	);
								fat_det.set_tg_tipoFat   	( TipoFat.FixoTrans										);
								fat_det.set_nu_quantidade   ( l_tr.GetCount().ToString() 							);
								fat_det.set_tg_desconto		( Context.FALSE );
								fat_det.set_fk_empresa		( emp.get_identity() 	);
								fat_det.set_fk_loja			( Context.FALSE 		);
								
								vr_total_fat += fat_det.get_int_vr_cobranca();
								
								fat_det.create_T_FaturamentoDetalhes();
							}
						}
						
						#endregion
						
						#region - 3 - valor percentual por transações -
												
						if ( emp.get_int_nu_pctValor() > 0 )
						{
							LOG_Transacoes l_tr = new LOG_Transacoes (this);
							
							// ## Busca por período e empresa
							
							if ( l_tr.select_rows_dt_emp ( 	GetDataBaseTime ( dtFat.AddMonths (-1) ),
															GetDataBaseTime ( dtFat ),  
															emp.get_identity() ) )
							{
								long vr_trans = 0;
								
								while ( l_tr.fetch() )
								{
									if ( l_tr.get_tg_confirmada() == TipoConfirmacao.Confirmada ) 
									{
										vr_trans += l_tr.get_int_vr_total();
									}
								}
								
								if ( vr_trans > 0 )
								{
									vr_trans = vr_trans * emp.get_int_nu_pctValor()/10000;
									
									T_FaturamentoDetalhes fat_det = new T_FaturamentoDetalhes (this);
								
									fat_det.set_fk_fatura 		( fat.get_identity() 	);
									fat_det.set_vr_cobranca 	( vr_trans.ToString()	);
									fat_det.set_tg_tipoFat   	( TipoFat.Percent		);
									fat_det.set_tg_desconto		( Context.FALSE );
									fat_det.set_fk_empresa		( emp.get_identity() 	);
									fat_det.set_fk_loja			( Context.FALSE 		);
									
									vr_total_fat += fat_det.get_int_vr_cobranca();
									
									fat_det.create_T_FaturamentoDetalhes();
								}
							}
						}
						
						#endregion
						
						#region - 4 - valor cartão ativo -
												
						if ( emp.get_int_vr_cartaoAtivo() > 0 )
						{
							T_Cartao cart = new T_Cartao (this);
							
							// ## Busca por período e empresa
							
							if ( cart.select_rows_empresa ( emp.get_st_empresa() ) )
							{
								T_FaturamentoDetalhes fat_det = new T_FaturamentoDetalhes (this);
							
								fat_det.set_fk_fatura 		( fat.get_identity() 							);
								fat_det.set_vr_cobranca 	( ( cart.RowCount() * emp.get_int_vr_cartaoAtivo() ).ToString()	);
								fat_det.set_tg_tipoFat   	( TipoFat.CartaoAtiv							);
								fat_det.set_tg_desconto		( Context.FALSE );
								fat_det.set_fk_empresa		( emp.get_identity() 	);
								fat_det.set_fk_loja			( Context.FALSE 		);
									
								vr_total_fat += fat_det.get_int_vr_cobranca();
								
								fat_det.create_T_FaturamentoDetalhes();
							}
						}						
						
						#endregion
		
						#region - 5 - valores extras -
												
						T_FaturamentoDetalhes fat_extras = new T_FaturamentoDetalhes (this);
						
						if ( fat_extras.select_rows_emp ( emp.get_identity(), TipoFat.Extras ) )
						{
							while ( fat_extras.fetch() )
							{
								vr_total_fat += fat_extras.get_int_vr_cobranca();
								
								T_FaturamentoDetalhes fat_extras_upd = new T_FaturamentoDetalhes (this);
								
								fat_extras_upd.ExclusiveAccess();
								
								fat_extras_upd.selectIdentity ( fat_extras.get_identity() 	);
								fat_extras_upd.set_fk_fatura  ( fat.get_identity() 			);
								
								fat_extras_upd.synchronize_T_FaturamentoDetalhes();
								fat_extras_upd.ReleaseExclusive();
							}
						}
						
						#endregion
												
						if ( emp.get_int_vr_minimo() > vr_total_fat )
						{
							 vr_total_fat = emp.get_int_vr_minimo();
						}
						
						fat_upd.ExclusiveAccess();
						fat_upd.selectIdentity ( fat.get_identity() );
						
						fat_upd.set_vr_cobranca ( vr_total_fat.ToString() );
						
						fat_upd.synchronize_T_Faturamento();
						fat_upd.ReleaseExclusive();						
					}
				}
			}
			
			#endregion
			
			T_Loja	loj = new T_Loja ( this );
						
			// ## Busca todas as lojas
			
			if ( loj.selectAll() )
			{
				// ## Busco todos os registros
				
				while ( loj.fetch() )
				{
					// ## Se dia é hoje
					
					Trace ( "Loja: " + loj.get_st_nome() );
					
					if ( loj.get_tg_cancel() == Context.TRUE )
						continue;
					
					Trace ( "Loja ok ");
					
					if ( loj.get_int_nu_periodoFat() == dtFat.Day && 
					          loj.get_tg_isentoFat() == Context.FALSE )
					{
						Trace ( "[A]");
						
						T_Faturamento fat     = new T_Faturamento (this);
						T_Faturamento fat_upd = new T_Faturamento (this);
						
						DateTime aux = dtFat;
							
						// ## Para casos onde o mês deve ser o próximo
						
						if ( loj.get_int_nu_diavenc() < dtFat.Day )
						{
							Trace ( "[B]");
							aux = dtFat.AddMonths ( 1 );
						}
						
						Trace ( "[C]");
						
						int zday = Convert.ToInt32 ( loj.get_int_nu_diavenc() );
						
						Trace ( "[C] 1 " + aux.Year.ToString() 	);
						Trace ( "[C] 2 " + aux.Month.ToString() );
						Trace ( "[C] 3 " + zday.ToString() 		);
						
						DateTime dtVenc = new DateTime ( aux.Year, aux.Month, zday );
						
						Trace ( "[D]");
							
						fat.set_dt_vencimento 	( GetDataBaseTime ( dtVenc) );
						fat.set_fk_loja 		( loj.get_identity() 		);
						fat.set_tg_situacao   	( TipoSitFat.Pendente 		);
												
						// ## Crio registro
						
						fat.create_T_Faturamento();
						
						long vr_total_fat = 0;
						
						// ## Crio registro detalhe
						
						#region - 1 - mensalidade -
												
						{
							Trace ( "[E]");
							
							T_FaturamentoDetalhes fat_det = new T_FaturamentoDetalhes (this);
							
							fat_det.set_fk_fatura 		( fat.get_identity() 		);
							fat_det.set_vr_cobranca 	( loj.get_vr_mensalidade() 	);
							fat_det.set_tg_tipoFat   	( TipoFat.TBM 				);
							fat_det.set_tg_desconto		( Context.FALSE 			);
							fat_det.set_fk_empresa		( Context.FALSE 			);
							fat_det.set_fk_loja			( loj.get_identity() 		);
							
							vr_total_fat += fat_det.get_int_vr_cobranca();
							
							fat_det.create_T_FaturamentoDetalhes();
						}
						
						#endregion
						
						#region - 2 - valor por transações -
												
						if ( loj.get_int_vr_transacao() > 0 )
						{
							Trace ( "[F]");
							
							LOG_Transacoes l_tr = new LOG_Transacoes (this);
							
							l_tr.SetCountMode();
					
							l_tr.select_rows_dt_loj ( GetDataBaseTime ( dtFat.AddMonths (-1) ),
							                          GetDataBaseTime ( dtFat ),  
							                          loj.get_identity() );
							
							long trans = l_tr.GetCount() - loj.get_int_nu_franquia();
							
							if ( trans > 0 )
							{
								Trace ( "[G]");
								
								T_FaturamentoDetalhes fat_det = new T_FaturamentoDetalhes (this);
								
								fat_det.set_fk_fatura 		( fat.get_identity() 									);
								fat_det.set_vr_cobranca 	( ( trans * loj.get_int_vr_transacao() ).ToString() 	);
								fat_det.set_tg_tipoFat   	( TipoFat.FixoTrans										);
								fat_det.set_nu_quantidade   ( l_tr.GetCount().ToString() 							);
								fat_det.set_tg_desconto		( Context.FALSE );
								fat_det.set_fk_empresa		( Context.FALSE 			);
								fat_det.set_fk_loja			( loj.get_identity() 		);
								
								vr_total_fat += fat_det.get_int_vr_cobranca();
								
								fat_det.create_T_FaturamentoDetalhes();
							}
						}
						
						#endregion
						
						#region - 3 - valor percentual por transações -
												
						if ( loj.get_int_nu_pctValor() > 0 )
						{
							Trace ( "[H]");
							
							LOG_Transacoes l_tr = new LOG_Transacoes (this);
							
							// ## Busca por período e empresa
							
							if ( l_tr.select_rows_dt_loj ( 	GetDataBaseTime ( dtFat.AddMonths (-1) ),
															GetDataBaseTime ( dtFat ),  
															loj.get_identity() ) )
							{
								Trace ( "[I]");
								
								long vr_trans = 0;
								
								while ( l_tr.fetch() )
								{
									if ( l_tr.get_tg_confirmada() == TipoConfirmacao.Confirmada ) 
									{
										vr_trans += l_tr.get_int_vr_total();
									}
								}
								
								if ( vr_trans > 0 )
								{
									Trace ( "[J]");
									
									vr_trans = vr_trans * loj.get_int_nu_pctValor()/10000;
									
									T_FaturamentoDetalhes fat_det = new T_FaturamentoDetalhes (this);
								
									fat_det.set_fk_fatura 		( fat.get_identity() 	);
									fat_det.set_vr_cobranca 	( vr_trans.ToString()	);
									fat_det.set_tg_tipoFat   	( TipoFat.Percent		);
									fat_det.set_tg_desconto		( Context.FALSE );
									fat_det.set_fk_empresa		( Context.FALSE 			);
									fat_det.set_fk_loja			( loj.get_identity() 		);
									
									vr_total_fat += fat_det.get_int_vr_cobranca();
									
									fat_det.create_T_FaturamentoDetalhes();
								}
							}
						}
						
						#endregion
						
						#region - 4 - valores extras -
						
						T_FaturamentoDetalhes fat_extras = new T_FaturamentoDetalhes (this);
						
						if ( fat_extras.select_rows_emp ( loj.get_identity(), TipoFat.Extras ) )
						{
							Trace ( "[K]");
							
							while ( fat_extras.fetch() )
							{
								Trace ( "[L]");
								
								vr_total_fat += fat_extras.get_int_vr_cobranca();
									
								T_FaturamentoDetalhes fat_extras_upd = new T_FaturamentoDetalhes (this);
								
								fat_extras_upd.ExclusiveAccess();
								
								fat_extras_upd.selectIdentity ( fat_extras.get_identity() 	);
								fat_extras_upd.set_fk_fatura  ( fat.get_identity() 			);
								
								fat_extras_upd.synchronize_T_FaturamentoDetalhes();
								fat_extras_upd.ReleaseExclusive();
							}
						}
						
						#endregion
						
						if ( vr_total_fat < loj.get_int_vr_minimo() )
						{
							 vr_total_fat = loj.get_int_vr_minimo();
						}
						
						fat_upd.ExclusiveAccess();
						fat_upd.selectIdentity ( fat.get_identity() );
						
						fat_upd.set_vr_cobranca ( vr_total_fat.ToString() );
						
						fat_upd.synchronize_T_Faturamento();
						fat_upd.ReleaseExclusive();	
						
						Trace ( "[M]");
					}
				}
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done schedule_faturamento " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish schedule_faturamento " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done schedule_faturamento " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
