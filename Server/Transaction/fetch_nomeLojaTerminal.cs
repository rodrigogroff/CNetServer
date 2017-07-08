using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_nomeLojaTerminal : type_base
	{
		public string input_st_terminal = "";
		
		public string output_st_nome_loja = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_nomeLojaTerminal ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_nomeLojaTerminal";
			constructor();
		}
		
		public fetch_nomeLojaTerminal()
		{
			var_Alias = "fetch_nomeLojaTerminal";
		
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
			Registry ( "setup fetch_nomeLojaTerminal " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_NOMELOJATERMINAL.st_terminal, ref input_st_terminal ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_NOMELOJATERMINAL.st_terminal missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_NOMELOJATERMINAL.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_NOMELOJATERMINAL.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_nomeLojaTerminal " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_nomeLojaTerminal " ); 
		
			/// USER [ authenticate ]
			
			input_st_terminal = input_st_terminal.PadLeft ( 8, '0' );
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_nomeLojaTerminal " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_nomeLojaTerminal " ); 
		
			/// USER [ execute ]
			
			// ## Obtem terminal
			
			T_Terminal term = new T_Terminal (this);
			
			if ( !term.select_rows_terminal ( input_st_terminal ) )
			{
				PublishError ( "Terminal inválido" );
				return false;
			}
			
			if ( !term.fetch() )
				return false;
			
			// ## Obtem loja

			T_Loja loj = new T_Loja (this);
			
			if ( !loj.selectIdentity ( term.get_fk_loja( ) ) )
			    return false;
			    
			output_st_nome_loja = loj.get_st_nome();
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_nomeLojaTerminal " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_nomeLojaTerminal " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_nomeLojaTerminal " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_NOMELOJATERMINAL.st_nome_loja, output_st_nome_loja ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
