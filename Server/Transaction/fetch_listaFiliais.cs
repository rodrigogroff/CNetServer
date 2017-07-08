using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_listaFiliais : type_base
	{
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_listaFiliais ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_listaFiliais";
			constructor();
		}
		
		public fetch_listaFiliais()
		{
			var_Alias = "fetch_listaFiliais";
		
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
			Registry ( "setup fetch_listaFiliais " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_FETCH_LISTAFILIAIS.header, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_LISTAFILIAIS.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_0 );
			
			Registry ( "setup done fetch_listaFiliais " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_listaFiliais " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_listaFiliais " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_listaFiliais " ); 
		
			/// USER [ execute ]
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_cont_header.get_st_empresa() ) )
			{
				PublishError ( "Nenhuma empresa com o código '" + input_cont_header.get_st_empresa() + "'"  );
				return false;
			}	
			
			if (! emp.fetch() )
				return false;
			
			if ( !emp.select_fk_admin ( emp.get_identity() ) )
			{
				PublishError ( "Nenhuma empresa afiliada encontrada!"  );
				return false;
			}	
			
			while ( emp.fetch() )
			{
				// ## Copia dados de empresas com nome
				
				DadosEmpresa de = new DadosEmpresa();
				
				de.set_st_fantasia ( emp.get_st_fantasia() 	);
				de.set_st_empresa  ( emp.get_st_empresa()	);
				
				output_array_generic_lst.Add ( de );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_listaFiliais " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_listaFiliais " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_listaFiliais " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_FETCH_LISTAFILIAIS.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			return true;
		}
	}
}
