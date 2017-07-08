using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_alteraSenhaCartao : type_base
	{
		public string input_st_cart_empresa = "";
		public string input_st_cart_mat = "";
		public string input_st_cart_tit = "";
		public string input_st_senha = "";
		public string input_st_novaSenha = "";
		
		/// USER [ var_decl ]
		
		T_Cartao cart;
		
		/// USER [ var_decl ] END
		
		public exec_alteraSenhaCartao ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_alteraSenhaCartao";
			constructor();
		}
		
		public exec_alteraSenhaCartao()
		{
			var_Alias = "exec_alteraSenhaCartao";
		
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
			Registry ( "setup exec_alteraSenhaCartao " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_ALTERASENHACARTAO.st_cart_empresa, ref input_st_cart_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_ALTERASENHACARTAO.st_cart_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_ALTERASENHACARTAO.st_cart_mat, ref input_st_cart_mat ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_ALTERASENHACARTAO.st_cart_mat missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_ALTERASENHACARTAO.st_cart_tit, ref input_st_cart_tit ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_ALTERASENHACARTAO.st_cart_tit missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_ALTERASENHACARTAO.st_senha, ref input_st_senha ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_ALTERASENHACARTAO.st_senha missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_ALTERASENHACARTAO.st_novaSenha, ref input_st_novaSenha ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_ALTERASENHACARTAO.st_novaSenha missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_ALTERASENHACARTAO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_ALTERASENHACARTAO.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_alteraSenhaCartao " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_alteraSenhaCartao " ); 
		
			/// USER [ authenticate ]
		
			// ## Prepara dados
			
			input_st_cart_empresa = input_st_cart_empresa.PadLeft 	( 6, '0' );
			input_st_cart_mat     = input_st_cart_mat.PadLeft 		( 6, '0' );
			input_st_cart_tit     = input_st_cart_tit.PadLeft 		( 2, '0' );
			
			cart = new T_Cartao (this);
			
			cart.ExclusiveAccess();
			
			// ## Obtem cartão especifico
			
			if ( !cart.select_rows_tudo ( input_st_cart_empresa, 
			                             input_st_cart_mat, 
			                             input_st_cart_tit ) )
		    {
				PublishError ( "Cartão inválido" );
				return false;
		    }
			
			if ( !cart.fetch() )
				return false;
			
			// ## Confere senhas
		
			if ( cart.get_st_senha() == input_st_novaSenha )
			{
				PublishError ( "Nova senha deve ser diferente da atual" );
				return false;
			}
					
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_alteraSenhaCartao " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_alteraSenhaCartao " ); 
		
			/// USER [ execute ]
			
			// ## Atualiza senha
			
			cart.set_st_senha ( input_st_novaSenha );
			
			// ## Atualiza tabela
			
			if ( !cart.synchronize_T_Cartao() )
				return false;			
			
			PublishNote ( "Senha trocada com sucesso" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_alteraSenhaCartao " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_alteraSenhaCartao " ); 
		
			/// USER [ finish ]
			
			// ## Grava registro de auditoria
			
			if ( !IsFail )
			{			
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.AlterSenha 	);
				aud.set_fk_usuario	( user.get_identity() 		);
				aud.set_dt_operacao ( GetDataBaseTime() 		);
				aud.set_fk_generic  ( user.get_identity()		);
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
					
			/// USER [ finish ] END
		
			Registry ( "finish done exec_alteraSenhaCartao " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
