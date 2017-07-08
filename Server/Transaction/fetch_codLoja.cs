using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_codLoja : type_base
	{
		public string output_st_cod = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_codLoja ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_codLoja";
			constructor();
		}
		
		public fetch_codLoja()
		{
			var_Alias = "fetch_codLoja";
		
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
			Registry ( "setup fetch_codLoja " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_FETCH_CODLOJA.header, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_CODLOJA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_0 );
			
			Registry ( "setup done fetch_codLoja " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_codLoja " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_codLoja " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_codLoja " ); 
		
			/// USER [ execute ]
			
			T_Loja loj = new T_Loja(this);
			
			if ( loj.selectAll() )
			{
				output_st_cod = ( loj.GetMax ( TB_T_LOJA.st_loja ) + 1 ).ToString();
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_codLoja " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_codLoja " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_codLoja " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_CODLOJA.st_cod, output_st_cod ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
