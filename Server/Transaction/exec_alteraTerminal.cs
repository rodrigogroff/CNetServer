using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_alteraTerminal : type_base
	{
		public string input_st_terminal = "";
		public string input_st_localizacao = "";
		
		/// USER [ var_decl ]
		
		T_Terminal term;
		
		/// USER [ var_decl ] END
		
		public exec_alteraTerminal ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_alteraTerminal";
			constructor();
		}
		
		public exec_alteraTerminal()
		{
			var_Alias = "exec_alteraTerminal";
		
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
			Registry ( "setup exec_alteraTerminal " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_ALTERATERMINAL.st_terminal, ref input_st_terminal ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_ALTERATERMINAL.st_terminal missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_ALTERATERMINAL.st_localizacao, ref input_st_localizacao ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_ALTERATERMINAL.st_localizacao missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_ALTERATERMINAL.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_ALTERATERMINAL.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_alteraTerminal " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_alteraTerminal " ); 
		
			/// USER [ authenticate ]
			
			term = new T_Terminal (this);
			
			term.ExclusiveAccess();
			
			// ## Busca terminal pelo nome informado
			
			if ( !term.select_rows_terminal ( input_st_terminal ) )
			{
				PublishError ( "Terminal " + input_st_terminal + " não encontrado" );
				return false;
			}
			
			if ( !term.fetch() )
				return false;
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_alteraTerminal " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_alteraTerminal " ); 
		
			/// USER [ execute ]
			
			// ## Atualiza dados
			
			term.set_st_localizacao ( input_st_localizacao );
			
			if ( !term.synchronize_T_Terminal() )
				return false;
			
			PublishNote ( "Terminal atualizado com sucesso" );
						
			/// USER [ execute ] END
		
			Registry ( "execute done exec_alteraTerminal " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_alteraTerminal " ); 
		
			/// USER [ finish ]
			
			// ## Grava registro de auditoria
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao		( TipoOperacao.AlterTerminal 	);
				aud.set_fk_usuario		( user.get_identity() 			);
				aud.set_dt_operacao 	( GetDataBaseTime() 			);
				aud.set_st_observacao 	( input_st_localizacao 			);
				aud.set_fk_generic  	( user.get_identity()			);
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_alteraTerminal " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
