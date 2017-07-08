using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_codTerminal : type_base
	{
		public string output_st_terminal = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_codTerminal ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_codTerminal";
			constructor();
		}
		
		public fetch_codTerminal()
		{
			var_Alias = "fetch_codTerminal";
		
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
			Registry ( "setup fetch_codTerminal " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_FETCH_CODTERMINAL.header, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_CODTERMINAL.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_0 );
			
			Registry ( "setup done fetch_codTerminal " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_codTerminal " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_codTerminal " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_codTerminal " ); 
		
			/// USER [ execute ]
			
			// ## Busca último terminal
			
			T_Terminal trm = new T_Terminal (this);
			
			if ( !trm.selectAll () )
			{
				output_st_terminal = "1".PadLeft ( 6, '0' );
				return true;
			}
			
			output_st_terminal = ( trm.GetMax ( TB_T_TERMINAL.nu_terminal ) + 1 ).ToString().PadLeft ( 6, '0' );
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_codTerminal " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_codTerminal " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_codTerminal " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_CODTERMINAL.st_terminal, output_st_terminal ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
