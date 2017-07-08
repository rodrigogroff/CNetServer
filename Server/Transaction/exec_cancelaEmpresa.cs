using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_cancelaEmpresa : type_base
	{
		public string input_st_pass_user = "";
		public string input_st_empresa = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_cancelaEmpresa ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_cancelaEmpresa";
			constructor();
		}
		
		public exec_cancelaEmpresa()
		{
			var_Alias = "exec_cancelaEmpresa";
		
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
			Registry ( "setup exec_cancelaEmpresa " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_CANCELAEMPRESA.st_pass_user, ref input_st_pass_user ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_CANCELAEMPRESA.st_pass_user missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_CANCELAEMPRESA.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_CANCELAEMPRESA.st_empresa missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_CANCELAEMPRESA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_CANCELAEMPRESA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_cancelaEmpresa " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_cancelaEmpresa " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_cancelaEmpresa " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_cancelaEmpresa " ); 
		
			/// USER [ execute ]
			
			// ## Verifica senha do operador
			
			if ( user.get_st_senha() != input_st_pass_user )
			{
				PublishError ( "Autenticação inválida" );
				return false;
			}
			
			T_Empresa emp = new T_Empresa (this);
			
			emp.ExclusiveAccess();
			
			// ## Busca empresa pelo CNPJ informado no client
			
			if ( !emp.select_rows_empresa ( input_st_empresa ) ) 
			{
				PublishError ( "Empresa com CNPJ desconhecido" );
				return false;
			}
			
			emp.set_tg_blocked ( Context.TRUE );
			
			// ## Atualiza empresa
			
			if ( !emp.synchronize_T_Empresa() )
				return false;
			
			PublishNote ( "Empresa bloqueada com sucesso" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_cancelaEmpresa " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_cancelaEmpresa " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.CancCadEmpresa    		);
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( "" );
				
				aud.set_fk_generic  ( 0 );
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_cancelaEmpresa " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
