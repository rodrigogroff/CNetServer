using System;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_codEmpresa : type_base
	{
		public string output_st_empresa = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_codEmpresa ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_codEmpresa";
		}
		
		public fetch_codEmpresa()
		{
			var_Alias = "fetch_codEmpresa";
		
			dbProcedure = DB_PROCEDURE.on_demand;
		
			ut_max = 0;
			
			/// USER [ constructor ]
			/// USER [ constructor ] END
		}
		
		public override bool setup ( ) 
		{
			Registry ( "setup fetch_codEmpresa " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_FETCH_CODEMPRESA.header, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_CODEMPRESA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_0 );
			
			Registry ( "setup done fetch_codEmpresa " ); 
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_codEmpresa " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_codEmpresa " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_codEmpresa " ); 
		
			/// USER [ execute ]
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.selectAll () )
			{
				output_st_empresa = "1".PadLeft ( 6, '0' );
				return true;
			}
			
			output_st_empresa = ( emp.GetMax ( TB_T_USUARIO.st_empresa ) + 1 ).ToString().PadLeft ( 6, '0' );
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_codEmpresa " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish fetch_codEmpresa " ); 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_CODEMPRESA.st_empresa, output_st_empresa ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_codEmpresa " ); 
		
			return true;
		}
	}
}
