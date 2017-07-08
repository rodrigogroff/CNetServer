using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_compensaChequeGift : type_base
	{
		public string input_st_ident = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_compensaChequeGift ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_compensaChequeGift";
			constructor();
		}
		
		public exec_compensaChequeGift()
		{
			var_Alias = "exec_compensaChequeGift";
		
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
			Registry ( "setup exec_compensaChequeGift " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_COMPENSACHEQUEGIFT.st_ident, ref input_st_ident ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_COMPENSACHEQUEGIFT.st_ident missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_COMPENSACHEQUEGIFT.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_COMPENSACHEQUEGIFT.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_compensaChequeGift " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_compensaChequeGift " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_compensaChequeGift " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_compensaChequeGift " ); 
		
			/// USER [ execute ]
			
			T_ChequesGift chq = new T_ChequesGift (this);
			
			chq.ExclusiveAccess();
			
			if ( !chq.select_rows_ident ( input_st_ident ) ) 
			{
				PublishError ( "Cheque não disponível" );
				return false;
			}
			
			if ( !chq.fetch() )
				return false;
			
			if ( chq.get_tg_compensado() != Context.FALSE && // aguardando
			     chq.get_tg_compensado() != Context.TRUE )   // compensado
			{
				PublishError ( "Não é possível compensar cheque cancelado" );
				return false;
			}
			else if ( chq.get_tg_compensado() == Context.TRUE )   // compensado
			{
				PublishError ( "Cheque previamente compensado" );
				return false;
			}		
			
			chq.set_tg_compensado ( Context.TRUE );
			
			if ( !chq.synchronize_T_ChequesGift() )
				return false;
			
			T_Cartao cart = new T_Cartao (this);
			
			cart.ExclusiveAccess();
			
			if ( !cart.selectIdentity ( chq.get_fk_cartao() ) )
				return false;
			
			cart.set_vr_limiteTotal ( cart.get_int_vr_limiteTotal() + chq.get_int_vr_valor() );
			
			if ( !cart.synchronize_T_Cartao() )
				return false;
			
			PublishNote ( "Cheque " + input_st_ident + " compensado" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_compensaChequeGift " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_compensaChequeGift " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.CompChequeGift     		);
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( "" );
				
				aud.set_fk_generic  ( 0 );
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_compensaChequeGift " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
