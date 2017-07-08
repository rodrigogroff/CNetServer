using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_dadosProprietario : type_base
	{
		public string input_cpf_cnpj = "";
		
		public DadosProprietario output_cont_dp = new DadosProprietario();
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_dadosProprietario ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_dadosProprietario";
			constructor();
		}
		
		public fetch_dadosProprietario()
		{
			var_Alias = "fetch_dadosProprietario";
		
			dbProcedure = DB_PROCEDURE.on_demand;
		
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
			Registry ( "setup fetch_dadosProprietario " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_DADOSPROPRIETARIO.cpf_cnpj, ref input_cpf_cnpj ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_DADOSPROPRIETARIO.cpf_cnpj missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_DADOSPROPRIETARIO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_DADOSPROPRIETARIO.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_dadosProprietario " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_dadosProprietario " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_dadosProprietario " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_dadosProprietario " ); 
		
			/// USER [ execute ]
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_dadosProprietario " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_dadosProprietario " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_dadosProprietario " ); 
		
			DataPortable dp_cont_1 = new DataPortable();
		
			dp_cont_1.MapTagContainer ( COMM_OUT_FETCH_DADOSPROPRIETARIO.dp , output_cont_dp as DataPortable );
		
			var_Comm.AddExitPortable ( ref dp_cont_1 ); 
		
			return true;
		}
	}
}
