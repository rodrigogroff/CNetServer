using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_trocaSenha : type_base
	{
		public string input_senha = "";
		public string input_nova_senha = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_trocaSenha ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_trocaSenha";
			constructor();
		}
		
		public exec_trocaSenha()
		{
			var_Alias = "exec_trocaSenha";
		
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
			Registry ( "setup exec_trocaSenha " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_TROCASENHA.senha, ref input_senha ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_TROCASENHA.senha missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_TROCASENHA.nova_senha, ref input_nova_senha ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_TROCASENHA.nova_senha missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_TROCASENHA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_TROCASENHA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_trocaSenha " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_trocaSenha " ); 
		
			/// USER [ authenticate ]
			
			// ## Valida senha
			
			if ( input_senha != user.get_st_senha() )
			{
				PublishError ( "Senha atual não confere" );
				return false;
			}
			
			// ## Tamanho esperado de 4 caracters ou mais
			
			if ( input_nova_senha.Length < 4 )
			{
				PublishError ( "Senha deve ter 4 caracteres no minimo" );
				return false;
			}
					
			// ## nova senha deve ser diferente de outras cinco anteriores
			
			if ( input_nova_senha == user.get_st_senha()  || 
			     input_nova_senha == user.get_st_senha_1() ||
			     input_nova_senha == user.get_st_senha_2() ||
			     input_nova_senha == user.get_st_senha_3() ||
			     input_nova_senha == user.get_st_senha_4() ||
			     input_nova_senha == user.get_st_senha_5() )
			{
				PublishError ( "Não repetir suas últimas cinco senhas" );
				return false;
			}
			
			PublishNote ( "Senha trocada com sucesso" );
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_trocaSenha " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_trocaSenha " ); 
		
			/// USER [ execute ]
			
			// ## Busca usuário
			
			user.ExclusiveAccess();
			
			if ( !user.selectIdentity ( input_cont_header.get_st_user_id() ) )
				return false;
			
			user.set_st_senha_5  	( user.get_st_senha_4() 	);
			user.set_st_senha_4  	( user.get_st_senha_3() 	);
			user.set_st_senha_3  	( user.get_st_senha_2() 	);
			user.set_st_senha_2  	( user.get_st_senha_1() 	);
			user.set_st_senha_1 	( user.get_st_senha()  	 	);
			
			user.set_st_senha       ( input_nova_senha 			);	
			user.set_dt_trocaSenha  ( GetDataBaseTime() 		);
			user.set_tg_trocaSenha  ( Context.FALSE 			);
			
			// ## Atualiza
			
			if ( !user.synchronize_T_Usuario() )
				return false;
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_trocaSenha " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_trocaSenha " ); 
		
			/// USER [ finish ]
			
			// ## Cria registro de auditoria
			
			LOG_Audit aud = new LOG_Audit (this);
			
			aud.set_tg_operacao	( TipoOperacao.TrocaSenha				);
			aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
			aud.set_dt_operacao ( GetDataBaseTime() 					);
			aud.set_fk_generic  ( user.get_identity() 					);
			
			if ( !aud.create_LOG_Audit() )
				return false;
		
			/// USER [ finish ] END
		
			Registry ( "finish done exec_trocaSenha " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
