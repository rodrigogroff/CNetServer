using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class schedule_fech_mensal : schedule_base
	{
		/// USER [ var_decl ]
		
		string st_empresa = "";
		string st_empresaAfiliada = "";
		
		T_Empresa emp;
				
		/// USER [ var_decl ] END
		
		public schedule_fech_mensal ( Transaction trans ) : base (trans)
		{
			var_Alias = "schedule_fech_mensal";
			constructor();
		}
		
		public schedule_fech_mensal()
		{
			var_Alias = "schedule_fech_mensal";
		
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
			Registry ( "setup schedule_fech_mensal " ); 
		
			Registry ( "setup done schedule_fech_mensal " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate schedule_fech_mensal " ); 
		
			/// USER [ authenticate ]
			
			DataPortable port = MemoryGet ( "input" );
			
			st_empresa 			= port.getValue ( "empresa" );
			st_empresaAfiliada 	= port.getValue ( "afiliada" );
			
			Trace ( "Empresa : " + st_empresa );
			Trace ( "Empresa Afiliada : " + st_empresaAfiliada );
			
			emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( st_empresa ) )
			{
				Trace ( "Empresa inválida" );
				return false;
			}
						
			if ( !emp.fetch() )
				return false;	
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done schedule_fech_mensal " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute schedule_fech_mensal " ); 
		
			/// USER [ execute ]
			
			T_Parcelas parc = new T_Parcelas (this);
			
			string mes = DateTime.Now.Month.ToString().PadLeft ( 2, '0' );
			string ano = DateTime.Now.Year.ToString();
			
			T_Cartao cart = new T_Cartao (this);
			T_Cartao cart_upd = new T_Cartao (this);
			
			if ( parc.select_rows_emp_fechamento ( emp.get_identity(), "0" ) ) // numero parcela > 0
			{
				T_Parcelas 			tmp  	= new T_Parcelas 		(this);
				LOG_Transacoes 		ltr 	= new LOG_Transacoes 	(this);
				T_InfoAdicionais 	info	= new T_InfoAdicionais  (this);
				
				while ( parc.fetch() )
				{
					if ( !tmp.selectIdentity ( parc.get_identity() ) )
						continue;
					
					if ( !cart.selectIdentity ( parc.get_fk_cartao() ) )
						continue;
					
					if ( !ltr.selectIdentity ( parc.get_fk_log_transacoes() ) )
					    continue;
					    
					if ( ltr.get_tg_confirmada() != TipoConfirmacao.Confirmada )
						continue;
					
					if ( st_empresaAfiliada != "" )
					{
						if ( !info.selectIdentity ( cart.get_fk_infoAdicionais() ) )
							continue;
						
						if ( info.get_st_empresaAfiliada().ToUpper().Trim() != st_empresaAfiliada.ToUpper().Trim() )
							continue;
					}
					
					if ( parc.get_int_nu_parcela() == 1 )
					{
						LOG_Fechamento log_fech = new LOG_Fechamento (this);
						
						log_fech.set_st_mes 		( mes 						);
						log_fech.set_st_ano 		( ano 						);
						log_fech.set_vr_valor 		( parc.get_vr_valor() 		);
						log_fech.set_dt_fechamento 	( GetDataBaseTime() 		);
						log_fech.set_fk_empresa 	( parc.get_fk_empresa() 	);
						log_fech.set_fk_loja 		( parc.get_fk_loja() 		);
						log_fech.set_fk_cartao 		( parc.get_fk_cartao() 		);
						log_fech.set_fk_parcela 	( parc.get_identity() 		);
						log_fech.set_dt_compra 		( parc.get_dt_inclusao() 	);
						log_fech.set_nu_parcela 	( parc.get_nu_parcela() 	);
						
						log_fech.set_st_afiliada 	( st_empresaAfiliada 		);
						
						log_fech.set_st_cartao 		( cart.get_st_empresa() + 
							                          cart.get_st_matricula() +
							                          cart.get_st_titularidade() );
						
						if ( !log_fech.create_LOG_Fechamento() )
							return false;
					}

					// decrementa parcela
					tmp.set_nu_parcela ( tmp.get_int_nu_parcela() - 1 );
					
					tmp.set_tg_pago ( Context.TRUE );
					
					if ( !tmp.synchronize_T_Parcelas() )
						return false;
				}
			}
			
			//zera cota extra de todo mundo
			
			if ( cart.select_rows_empresa ( emp.get_st_empresa() ) )
			{
				while ( cart.fetch() )
				{
					cart_upd.ExclusiveAccess();
					
					cart_upd.selectIdentity ( cart.get_identity() );
					cart_upd.set_vr_extraCota ( "0" );
					
					cart_upd.synchronize_T_Cartao();
					cart_upd.ReleaseExclusive();					
				}
			}
			
			
			/// USER [ execute ] END
		
			Registry ( "execute done schedule_fech_mensal " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish schedule_fech_mensal " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done schedule_fech_mensal " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
