using System;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_listaTerminais : type_base
	{
		public string input_st_empresa = "";
		
		public string output_st_csvId = "";
		
		/// USER [ var_decl ]
		
		T_Empresa emp;
		
		/// USER [ var_decl ] END
		
		public fetch_listaTerminais ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_listaTerminais";
		}
		
		public fetch_listaTerminais()
		{
			var_Alias = "fetch_listaTerminais";
		
			dbProcedure = DB_PROCEDURE.on_demand;
		
			ut_max = 0;
			
			/// USER [ constructor ]
			/// USER [ constructor ] END
		}
		
		public override bool setup ( ) 
		{
			Registry ( "setup fetch_listaTerminais " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_LISTATERMINAIS.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_LISTATERMINAIS.st_empresa missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_LISTATERMINAIS.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_LISTATERMINAIS.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_listaTerminais " ); 
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_listaTerminais " ); 
		
			/// USER [ authenticate ]
			
			input_st_empresa = input_st_empresa.PadLeft ( 6, '0' );
			
			emp = new T_Empresa (this);
			
			if ( !emp.fetch_rows_empresa ( input_st_empresa ) )
				return false;
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_listaTerminais " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_listaTerminais " ); 
		
			/// USER [ execute ]
			
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_listaTerminais " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish fetch_listaTerminais " ); 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_LISTATERMINAIS.st_csvId, output_st_csvId ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_listaTerminais " ); 
		
			return true;
		}
	}
}
