using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_validaEmpresa : type_base
	{
		public string input_st_empresa = "";
		
		public string output_st_nome = "";
		
		/// USER [ var_decl ]
		
		T_Empresa emp;
		
		/// USER [ var_decl ] END
		
		public fetch_validaEmpresa ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_validaEmpresa";
			constructor();
		}
		
		public fetch_validaEmpresa()
		{
			var_Alias = "fetch_validaEmpresa";
		
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
			Registry ( "setup fetch_validaEmpresa " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_VALIDAEMPRESA.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_VALIDAEMPRESA.st_empresa missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_VALIDAEMPRESA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_VALIDAEMPRESA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_validaEmpresa " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_validaEmpresa " ); 
		
			/// USER [ authenticate ]
			
			emp = new T_Empresa (this);
			
			input_st_empresa = input_st_empresa.PadLeft ( 6, '0' );
				
			if ( !emp.select_rows_empresa ( input_st_empresa ) )
			{
				PublishError ( "Código de empresa inválido" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_validaEmpresa " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_validaEmpresa " ); 
		
			/// USER [ execute ]
			
			output_st_nome = emp.get_st_fantasia();
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_validaEmpresa " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_validaEmpresa " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_validaEmpresa " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_VALIDAEMPRESA.st_nome, output_st_nome ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
