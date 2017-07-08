using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class web_exec_alterSenhaEdu : Transaction
	{
		public string input_st_cpf = "";
		public string input_st_senha = "";
		public string input_st_novaSenha = "";
		public string input_tg_resp = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public web_exec_alterSenhaEdu ( Transaction trans ) : base (trans)
		{
			var_Alias = "web_exec_alterSenhaEdu";
			constructor();
		}
		
		public web_exec_alterSenhaEdu()
		{
			var_Alias = "web_exec_alterSenhaEdu";
		
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
			Registry ( "setup web_exec_alterSenhaEdu " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_EXEC_ALTERSENHAEDU.st_cpf, ref input_st_cpf ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_EXEC_ALTERSENHAEDU.st_cpf missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_EXEC_ALTERSENHAEDU.st_senha, ref input_st_senha ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_EXEC_ALTERSENHAEDU.st_senha missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_EXEC_ALTERSENHAEDU.st_novaSenha, ref input_st_novaSenha ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_EXEC_ALTERSENHAEDU.st_novaSenha missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_EXEC_ALTERSENHAEDU.tg_resp, ref input_tg_resp ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_EXEC_ALTERSENHAEDU.tg_resp missing! " ); 
				return false;
			}
			
			Registry ( "setup done web_exec_alterSenhaEdu " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate web_exec_alterSenhaEdu " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done web_exec_alterSenhaEdu " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute web_exec_alterSenhaEdu " ); 
		
			/// USER [ execute ]
			
			if ( input_tg_resp == Context.TRUE )
			{
				T_Proprietario prot = new T_Proprietario(this);
				
				prot.ExclusiveAccess();
				
				if ( !prot.select_rows_cpf ( input_st_cpf ) )
				{
					PublishError ( "CPF inválido" );
					return false;
				}
				
				if ( !prot.fetch () )
					return false;
				
				if ( prot.get_st_senhaEdu() != input_st_senha )
				{
					PublishError ( "Senha atual inválida" );
					return false;
				}
				
				prot.set_st_senhaEdu ( input_st_novaSenha );
				
				if ( !prot.synchronize_T_Proprietario() )
					return false;			
			}
			else
			{
				T_Cartao cart = new T_Cartao (this);
				
				cart.ExclusiveAccess();
				
				if ( cart.select_rows_tudo ( input_st_cpf.Substring ( 0,6 ),
				                            	input_st_cpf.Substring ( 6,6 ),
				                            	"01" ) )
				{
					if ( !cart.fetch() )
						return false;
					
					cart.set_st_senha ( input_st_novaSenha );
					
					if ( !cart.synchronize_T_Cartao() )
						return false;
				}
			}
			
			PublishNote ( "Senha trocada com sucesso" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done web_exec_alterSenhaEdu " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish web_exec_alterSenhaEdu " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done web_exec_alterSenhaEdu " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
