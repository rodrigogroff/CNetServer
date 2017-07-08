using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_resolvePend : type_base
	{
		public string input_nsu = "";
		public string input_dt_ini = "";
		public string input_tg_confirmada = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_resolvePend ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_resolvePend";
			constructor();
		}
		
		public exec_resolvePend()
		{
			var_Alias = "exec_resolvePend";
		
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
			Registry ( "setup exec_resolvePend " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_RESOLVEPEND.nsu, ref input_nsu ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_RESOLVEPEND.nsu missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_RESOLVEPEND.dt_ini, ref input_dt_ini ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_RESOLVEPEND.dt_ini missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_RESOLVEPEND.tg_confirmada, ref input_tg_confirmada ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_RESOLVEPEND.tg_confirmada missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_RESOLVEPEND.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_RESOLVEPEND.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_resolvePend " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_resolvePend " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_resolvePend " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_resolvePend " ); 
		
			/// USER [ execute ]
			
			DateTime start = Convert.ToDateTime ( input_dt_ini );
			DateTime end   = Convert.ToDateTime ( input_dt_ini ).AddDays (1);
			
			LOG_Transacoes ltr = new LOG_Transacoes (this);
			
			ltr.ExclusiveAccess();
			
			if ( !ltr.select_rows_nsu ( input_nsu, 
			                           	GetDataBaseTime(start),
				                       	GetDataBaseTime(end) ) )
			{
				PublishError ( "NSU não disponível" );
				return false;
			}
			
			if ( !ltr.fetch() )
				return false;
			    
			if ( ltr.get_tg_confirmada() == input_tg_confirmada )
			{
				PublishError ( "Transação previamente resolvida" );
				return false;
			}
			
			if ( input_tg_confirmada == TipoConfirmacao.Cancelada )
			{
				T_Cartao cart = new T_Cartao (this);
				
				cart.ExclusiveAccess();
				
				if ( cart.selectIdentity ( ltr.get_fk_cartao() ) )
				{
					if ( cart.get_tg_tipoCartao() == TipoCartao.presente )
					{
						cart.set_vr_limiteTotal ( cart.get_int_vr_limiteTotal() + 
						                          ltr.get_int_vr_total() );
						
						if ( !cart.synchronize_T_Cartao() )
							return false;
					}
				}
				
				cart.ReleaseExclusive();
			}
			
			ltr.set_tg_confirmada ( input_tg_confirmada );
			
			if ( !ltr.synchronize_LOG_Transacoes() )
				return false;
			
			ltr.ReleaseExclusive();
						
			if ( input_tg_confirmada == TipoConfirmacao.Confirmada  )
			{
				PublishNote ( "Transação confirmada com sucesso" );
			}
			else
			{
				PublishNote ( "Transação cancelada com sucesso" );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_resolvePend " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_resolvePend " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.ResolvePend				);
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				string dta = input_dt_ini.Substring ( 8,2 ) + "/" + 
							 input_dt_ini.Substring ( 5,2 );
				
				if ( input_tg_confirmada == TipoConfirmacao.Confirmada )
					aud.set_st_observacao ( input_nsu + " " + dta + " confirmado" );
				else
					aud.set_st_observacao ( input_nsu + " " + dta + " cancelado" );
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_resolvePend " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
