using System;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_listaEmpresas : type_base
	{
		public string input_st_csv_empresas = "";
		
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_listaEmpresas ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_listaEmpresas";
		}
		
		public fetch_listaEmpresas()
		{
			var_Alias = "fetch_listaEmpresas";
		
			dbProcedure = DB_PROCEDURE.on_demand;
		
			ut_max = 0;
			
			/// USER [ constructor ]
			/// USER [ constructor ] END
		}
		
		public override bool setup ( ) 
		{
			Registry ( "setup fetch_listaEmpresas " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_LISTAEMPRESAS.st_csv_empresas, ref input_st_csv_empresas ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_LISTAEMPRESAS.st_csv_empresas missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_LISTAEMPRESAS.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_LISTAEMPRESAS.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_listaEmpresas " ); 
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_listaEmpresas " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_listaEmpresas " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_listaEmpresas " ); 
		
			/// USER [ execute ]
			
			T_Empresa m_emp = new T_Empresa(this);
			
			for ( int t=0; t < var_util.indexCSV ( input_st_csv_empresas ); ++t )
			{
				if ( !m_emp.fetch_rows_empresa ( var_util.getCSV ( t ) ) )
					return false;
				
				if ( !m_emp.fetch() )
					return false;
				
				LINK_LojaEmpresa loj_emp = new LINK_LojaEmpresa (this);
				
				loj_emp.fetch_fk_empresa_geral ( m_emp.get_identity() );
				
				DadosEmpresa de = new DadosEmpresa();
				
				de.set_nu_CNPJ 		( m_emp.get_nu_CNPJ() 			);
				de.set_st_empresa 	( m_emp.get_st_empresa() 		);
				de.set_st_fantasia 	( m_emp.get_st_fantasia() 		);
				de.set_st_cidade	( m_emp.get_st_cidade() 		);
				de.set_st_estado	( m_emp.get_st_estado() 		);
				de.set_nu_cartoes	( m_emp.get_nu_cartoes() 		);
				de.set_nu_parcelas	( m_emp.get_nu_parcelas()		);
				de.set_vr_taxa		( m_emp.get_vr_taxa()			);
				de.set_nu_lojas		( loj_emp.RowCount().ToString() );
				
				output_array_generic_lst.Add ( de );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_listaEmpresas " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish fetch_listaEmpresas " ); 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_FETCH_LISTAEMPRESAS.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_listaEmpresas " ); 
		
			return true;
		}
	}
}
