using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_bloq_loja : type_base
	{
		public string input_st_cnpj = "";
		public string input_st_motivo = "";
		
		/// USER [ var_decl ]
		
		string st_cod_loja = "";
		
		/// USER [ var_decl ] END
		
		public exec_bloq_loja ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_bloq_loja";
			constructor();
		}
		
		public exec_bloq_loja()
		{
			var_Alias = "exec_bloq_loja";
		
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
			Registry ( "setup exec_bloq_loja " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_BLOQ_LOJA.st_cnpj, ref input_st_cnpj ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_BLOQ_LOJA.st_cnpj missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_BLOQ_LOJA.st_motivo, ref input_st_motivo ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_BLOQ_LOJA.st_motivo missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_BLOQ_LOJA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_BLOQ_LOJA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_bloq_loja " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_bloq_loja " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_bloq_loja " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_bloq_loja " ); 
		
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
			
			if ( loj.get_tg_blocked() == Context.TRUE )
			{
				PublishError ( "Loja previamente bloqueada" );
				return false;
			}
			
			st_cod_loja = loj.get_st_loja();
			
			loj.set_tg_blocked ( Context.TRUE );
			
			if ( !loj.synchronize_T_Loja() )
				return false;
			
			PublishNote ( "Loja bloqueada com sucesso" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_bloq_loja " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_bloq_loja " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao		( TipoOperacao.BloqueioLoja						);
				aud.set_fk_usuario		( input_cont_header.get_st_user_id() 			);
				aud.set_dt_operacao 	( GetDataBaseTime() 							);
				aud.set_st_observacao 	( st_cod_loja + " (" + user.get_st_nome() + ") " + input_st_motivo 	);
				aud.set_fk_generic  	( user.get_identity() 							);
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_bloq_loja " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
