using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_nomeEmpresa : type_base
	{
		public string input_st_nome = "";
		
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		
		T_Empresa emp;
		
		/// USER [ var_decl ] END
		
		public fetch_nomeEmpresa ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_nomeEmpresa";
			constructor();
		}
		
		public fetch_nomeEmpresa()
		{
			var_Alias = "fetch_nomeEmpresa";
		
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
			Registry ( "setup fetch_nomeEmpresa " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_NOMEEMPRESA.st_nome, ref input_st_nome ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_NOMEEMPRESA.st_nome missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_NOMEEMPRESA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_NOMEEMPRESA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_nomeEmpresa " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_nomeEmpresa " ); 
		
			/// USER [ authenticate ]
			
			// ## Busca por nome
			
			emp = new T_Empresa (this);
			
			if ( !emp.select_rows_fantasia ( input_st_nome ) )
			{
				PublishError ( "Nenhuma empresa com a descrição '" +input_st_nome + "'"  );
				return false;
			}			
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_nomeEmpresa " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_nomeEmpresa " ); 
		
			/// USER [ execute ]
			
			while ( emp.fetch() )
			{
				// ## Copia dados de empresas com nome
				
				DadosEmpresa de = new DadosEmpresa();
				
				de.set_st_fantasia ( emp.get_st_fantasia() 	);
				de.set_st_empresa  ( emp.get_st_empresa()	);
				
				output_array_generic_lst.Add ( de );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_nomeEmpresa " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_nomeEmpresa " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_nomeEmpresa " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_FETCH_NOMEEMPRESA.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			return true;
		}
	}
}
