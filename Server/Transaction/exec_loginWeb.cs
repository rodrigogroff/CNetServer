using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_loginWeb : Transaction
	{
		public string input_st_cartao = "";
		public string input_st_senha = "";
		
		public string output_nome = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_loginWeb ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_loginWeb";
			constructor();
		}
		
		public exec_loginWeb()
		{
			var_Alias = "exec_loginWeb";
		
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
			Registry ( "setup exec_loginWeb " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_LOGINWEB.st_cartao, ref input_st_cartao ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_LOGINWEB.st_cartao missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_LOGINWEB.st_senha, ref input_st_senha ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_LOGINWEB.st_senha missing! " ); 
				return false;
			}
			
			Registry ( "setup done exec_loginWeb " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate exec_loginWeb " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_loginWeb " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute exec_loginWeb " ); 
		
			/// USER [ execute ]
			
			T_Cartao cart = new T_Cartao (this);
			
			if ( !cart.select_rows_tudo ( 	input_st_cartao.Substring (0,6), 
			                             	input_st_cartao.Substring (6,6), 
			                             	input_st_cartao.Substring (12,2) ) )
			{
				PublishError ( "Matrícula não disponível" );
				return false;
			}
			
			if ( !cart.fetch() )
				return false;
			
			if ( cart.get_st_senha() != input_st_senha )
			{
				PublishError ( "Senha inválida" );
				return false;
			} 
			
			if ( cart.get_st_titularidade() == "01" )
			{
				T_Proprietario prot = new T_Proprietario (this);
				
				if ( !prot.selectIdentity ( cart.get_fk_dadosProprietario() ) )
					return false;
				
				output_nome = prot.get_st_nome();
			}
			else
			{
				T_Dependente dep = new T_Dependente (this);
				
				if ( !dep.select_rows_prop_tit ( cart.get_fk_dadosProprietario(),
				                               cart.get_st_titularidade() ) )
				{
					return false;
				}
				
				if ( !dep.fetch() )
					return false;
				
				output_nome = dep.get_st_nome();
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_loginWeb " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish exec_loginWeb " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done exec_loginWeb " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_EXEC_LOGINWEB.nome, output_nome ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
