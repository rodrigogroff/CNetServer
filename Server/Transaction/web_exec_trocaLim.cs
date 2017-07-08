using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class web_exec_trocaLim : Transaction
	{
		public string input_st_cartao = "";
		public string input_st_senha = "";
		public string input_vr_dispDiario = "";
		public string input_tg_semanaToda = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public web_exec_trocaLim ( Transaction trans ) : base (trans)
		{
			var_Alias = "web_exec_trocaLim";
			constructor();
		}
		
		public web_exec_trocaLim()
		{
			var_Alias = "web_exec_trocaLim";
		
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
			Registry ( "setup web_exec_trocaLim " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_EXEC_TROCALIM.st_cartao, ref input_st_cartao ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_EXEC_TROCALIM.st_cartao missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_EXEC_TROCALIM.st_senha, ref input_st_senha ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_EXEC_TROCALIM.st_senha missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_EXEC_TROCALIM.vr_dispDiario, ref input_vr_dispDiario ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_EXEC_TROCALIM.vr_dispDiario missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_EXEC_TROCALIM.tg_semanaToda, ref input_tg_semanaToda ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_EXEC_TROCALIM.tg_semanaToda missing! " ); 
				return false;
			}
			
			Registry ( "setup done web_exec_trocaLim " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate web_exec_trocaLim " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done web_exec_trocaLim " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute web_exec_trocaLim " ); 
		
			/// USER [ execute ]
			
			input_st_cartao = input_st_cartao.PadLeft ( 14, '0' );
			
			T_Cartao cart = new T_Cartao (this);
			
			cart.ExclusiveAccess();
			
			if ( !cart.select_rows_tudo ( input_st_cartao.Substring (  0,6 ),
			                              input_st_cartao.Substring (  6,6 ),
			                              input_st_cartao.Substring ( 12,2 ) ) )
          	{
				PublishError ( "Cartão inválido" );
				return false;
          	}
			
			if ( !cart.fetch() )
				return false;
		
			cart.set_vr_edu_diario 		( input_vr_dispDiario );
			cart.set_tg_semanaCompleta 	( input_tg_semanaToda );
				
			if ( !cart.synchronize_T_Cartao() )
				return false;
			
			PublishNote ( "Crédito diário de aluno alterado com sucesso para R$ " + new money().formatToMoney ( cart.get_vr_edu_diario () ) );
			
			/// USER [ execute ] END
		
			Registry ( "execute done web_exec_trocaLim " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish web_exec_trocaLim " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done web_exec_trocaLim " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
