using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_loginLojista : Transaction
	{
		public string input_st_cnpj = "";
		public string input_st_senha = "";
		
		public string output_nome = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_loginLojista ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_loginLojista";
			constructor();
		}
		
		public exec_loginLojista()
		{
			var_Alias = "exec_loginLojista";
		
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
			Registry ( "setup exec_loginLojista " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_LOGINLOJISTA.st_cnpj, ref input_st_cnpj ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_LOGINLOJISTA.st_cnpj missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_LOGINLOJISTA.st_senha, ref input_st_senha ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_LOGINLOJISTA.st_senha missing! " ); 
				return false;
			}
			
			Registry ( "setup done exec_loginLojista " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate exec_loginLojista " ); 
		
			/// USER [ authenticate ]
			
			T_Loja loj = new T_Loja (this);
			
			if ( !loj.select_rows_loja ( input_st_cnpj ) )
			{
				PublishError ( "Cnpj não disponível" );
				return false;
			}
			
			if ( !loj.fetch() )
				return false;
			
			if ( loj.get_st_senha() != input_st_senha )
			{
				PublishError ( "Senha inválida" );
				return false;
			}
			
			output_nome = loj.get_st_nome() + " - " + loj.get_st_social();
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_loginLojista " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute exec_loginLojista " ); 
		
			/// USER [ execute ]
			/// USER [ execute ] END
		
			Registry ( "execute done exec_loginLojista " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish exec_loginLojista " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done exec_loginLojista " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_EXEC_LOGINLOJISTA.nome, output_nome ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
