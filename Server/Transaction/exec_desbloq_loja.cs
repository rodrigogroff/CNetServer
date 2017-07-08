using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_desbloq_loja : type_base
	{
		public string input_st_cnpj = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_desbloq_loja ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_desbloq_loja";
			constructor();
		}
		
		public exec_desbloq_loja()
		{
			var_Alias = "exec_desbloq_loja";
		
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
			Registry ( "setup exec_desbloq_loja " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_DESBLOQ_LOJA.st_cnpj, ref input_st_cnpj ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_DESBLOQ_LOJA.st_cnpj missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_DESBLOQ_LOJA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_DESBLOQ_LOJA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_desbloq_loja " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_desbloq_loja " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_desbloq_loja " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_desbloq_loja " ); 
		
			/// USER [ execute ]
			
			T_Loja loj = new T_Loja (this);
			
			loj.ExclusiveAccess();
			
			if ( !loj.select_rows_cnpj ( input_st_cnpj ) )
			{
				PublishError ( "Loja não disponível" );
				return false;
			}
			
			if ( !loj.fetch() )
				return false;
			
			if ( loj.get_tg_blocked() == Context.FALSE )
			{
				PublishError ( "Loja esta ativa" );
				return false;
			}
			
			loj.set_tg_blocked ( Context.FALSE );
			
			if ( !loj.synchronize_T_Loja() )
				return false;
			
			PublishNote ( "Loja desbloqueada com sucesso" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_desbloq_loja " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_desbloq_loja " ); 
		
			/// USER [ finish ]

			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao		( TipoOperacao.DesbloqueioLoja			);
				aud.set_fk_usuario		( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao 	( GetDataBaseTime() 					);
				aud.set_st_observacao 	( user.get_st_nome() 					);
				aud.set_fk_generic  	( user.get_identity() 					);
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_desbloq_loja " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
