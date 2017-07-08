using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_segundaVia : type_base
	{
		public string input_st_empresa = "";
		public string input_st_mat = "";
		public string input_st_tit = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_segundaVia ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_segundaVia";
			constructor();
		}
		
		public exec_segundaVia()
		{
			var_Alias = "exec_segundaVia";
		
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
			Registry ( "setup exec_segundaVia " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_SEGUNDAVIA.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_SEGUNDAVIA.st_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_SEGUNDAVIA.st_mat, ref input_st_mat ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_SEGUNDAVIA.st_mat missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_SEGUNDAVIA.st_tit, ref input_st_tit ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_SEGUNDAVIA.st_tit missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_SEGUNDAVIA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_SEGUNDAVIA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_segundaVia " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_segundaVia " ); 
		
			/// USER [ authenticate ]
			
			input_st_empresa = input_st_empresa.PadLeft ( 6, '0' );
			input_st_mat 	 = input_st_mat.PadLeft 	( 6, '0' );
			input_st_tit 	 = input_st_tit.PadLeft 	( 2, '0' );
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_segundaVia " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_segundaVia " ); 
		
			/// USER [ execute ]
			
			T_Cartao cart = new T_Cartao (this);
			
			cart.ExclusiveAccess();
			
			if ( !cart.select_rows_tudo ( input_st_empresa, input_st_mat, input_st_tit ) )
			{
				PublishError ( "Cartão inválido" );
				return false;
			}
			
			if ( !cart.fetch() )
				return false;
			
			if ( cart.get_tg_status() == CartaoStatus.Bloqueado )
			{
				PublishError ( "Este cartão está bloqueado" );
				return false;
			}	
			
			cart.set_nu_viaCartao ( cart.get_int_nu_viaCartao() + 1 );
			cart.set_tg_emitido   ( StatusExpedicao.NaoExpedido		);
			
			if ( !cart.synchronize_T_Cartao() )
				return false;
			
			PublishNote ( "Segunda via requerida" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_segundaVia " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_segundaVia " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.ReqSegViaCart );
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( "" );
				
				aud.set_fk_generic  ( 0 );
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_segundaVia " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
