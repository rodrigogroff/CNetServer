using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_empresasAfiliadas : type_base
	{
		public string input_st_empresa = "";
		
		public string output_st_nome_emp = "";
		
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_empresasAfiliadas ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_empresasAfiliadas";
			constructor();
		}
		
		public fetch_empresasAfiliadas()
		{
			var_Alias = "fetch_empresasAfiliadas";
		
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
			Registry ( "setup fetch_empresasAfiliadas " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_EMPRESASAFILIADAS.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_EMPRESASAFILIADAS.st_empresa missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_EMPRESASAFILIADAS.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_EMPRESASAFILIADAS.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_empresasAfiliadas " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_empresasAfiliadas " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_empresasAfiliadas " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_empresasAfiliadas " ); 
		
			/// USER [ execute ]
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_st_empresa.PadLeft ( 6, '0' ) ) )
			{
				PublishError ( "Empresa não disponível" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			output_st_nome_emp = emp.get_st_fantasia();
			
			T_EmpresaAfiliada emp_aff = new T_EmpresaAfiliada (this);
			
			if ( emp_aff.select_fk_empresa ( emp.get_identity() ) )
			{
				while ( emp_aff.fetch() )
				{
					DadosEmpresa de = new DadosEmpresa();
					
					de.set_st_empresa ( emp_aff.get_st_nome() );
					
					output_array_generic_lst.Add ( de );
				}
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_empresasAfiliadas " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_empresasAfiliadas " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_empresasAfiliadas " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_EMPRESASAFILIADAS.st_nome_emp, output_st_nome_emp ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_FETCH_EMPRESASAFILIADAS.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			return true;
		}
	}
}
