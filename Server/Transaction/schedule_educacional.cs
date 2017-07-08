using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class schedule_educacional : schedule_base
	{
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public schedule_educacional ( Transaction trans ) : base (trans)
		{
			var_Alias = "schedule_educacional";
			constructor();
		}
		
		public schedule_educacional()
		{
			var_Alias = "schedule_educacional";
		
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
			Registry ( "setup schedule_educacional " ); 
		
			Registry ( "setup done schedule_educacional " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate schedule_educacional " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done schedule_educacional " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute schedule_educacional " ); 
		
			/// USER [ execute ]
			
			T_Cartao cart     = new T_Cartao (this);
			T_Cartao upd_cart = new T_Cartao (this);
			
			T_Empresa emp = new T_Empresa (this);
			LOG_NSU l_nsu = new LOG_NSU (this);
			
			DateTime t_today = DateTime.Now;
			
			bool fimdeSemana = false;
			
			if ( t_today.DayOfWeek == DayOfWeek.Saturday || 
			    t_today.DayOfWeek == DayOfWeek.Sunday )
			{
				fimdeSemana = true;
			}
			
			if ( cart.select_rows_tipo ( TipoCartao.educacional ) )
			{
				while ( cart.fetch() )
				{
					if ( cart.get_tg_semanaCompleta() != Context.TRUE )
						if ( fimdeSemana )
							continue;
					
					if ( upd_cart.selectIdentity ( cart.get_identity() ) )
					{
						long depot  = upd_cart.get_int_vr_educacional();
						long disp   = upd_cart.get_int_vr_disp_educacional();
						
						long diario = upd_cart.get_int_vr_edu_diario();
						
						if ( diario == 0 )
							continue;
						
						depot -= diario;
						disp  += diario;
						
						if ( depot < 0 ) 
						{
							disp += depot;
							depot = 0;
						}
															
						upd_cart.set_vr_educacional      ( depot.ToString() );
						upd_cart.set_vr_disp_educacional ( disp.ToString()  );
						
						upd_cart.synchronize_T_Cartao();
						
						emp.select_rows_empresa ( 	upd_cart.get_st_empresa()  );
						emp.fetch();
									
						l_nsu.set_dt_log ( GetDataBaseTime() );
							
			            l_nsu.create_LOG_NSU();
						
						LOG_Transacoes l_tr = new LOG_Transacoes (this);
						
						l_tr.set_fk_terminal		( "0"								);
						l_tr.set_fk_empresa			( emp.get_identity()				);
						l_tr.set_fk_cartao			( upd_cart.get_identity()			);
						l_tr.set_vr_total			( diario.ToString()					);
						l_tr.set_nu_parcelas		( "1"								);
						l_tr.set_nu_nsu 			( l_nsu.get_identity() 				);
						l_tr.set_dt_transacao		( GetDataBaseTime()					);						
						l_tr.set_nu_cod_erro 		( "0"								);
						l_tr.set_tg_confirmada		( TipoConfirmacao.Confirmada		);						
						l_tr.set_nu_nsuOrig			( "0" 								);
						l_tr.set_en_operacao		( OperacaoCartao.EDU_DEP_DIARIO     );
						l_tr.set_st_msg_transacao 	( "" 								);
						l_tr.set_tg_contabil 	  	( Context.TRUE 						);				
						l_tr.set_fk_loja			( "0"								);
						
						l_tr.set_vr_saldo_disp		( upd_cart.get_vr_disp_educacional()	);
						l_tr.set_vr_saldo_disp_tot	( upd_cart.get_vr_educacional()			);
			
						l_tr.create_LOG_Transacoes();
					}
				}
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done schedule_educacional " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish schedule_educacional " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done schedule_educacional " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
