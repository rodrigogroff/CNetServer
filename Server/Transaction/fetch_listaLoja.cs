using System;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_listaLoja : type_base
	{
		public string input_st_csv = "";
		
		public ArrayList output_array_generic_list = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_listaLoja ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_listaLoja";
		}
		
		public fetch_listaLoja()
		{
			var_Alias = "fetch_listaLoja";
		
			dbProcedure = DB_PROCEDURE.on_demand;
		
			ut_max = 0;
			
			/// USER [ constructor ]
			/// USER [ constructor ] END
		}
		
		public override bool setup ( ) 
		{
			Registry ( "setup fetch_listaLoja " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_LISTALOJA.st_csv, ref input_st_csv ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_LISTALOJA.st_csv missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_LISTALOJA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_LISTALOJA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_listaLoja " ); 
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_listaLoja " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_listaLoja " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_listaLoja " ); 
		
			/// USER [ execute ]
			
			T_Loja loj = new T_Loja(this);
			T_Terminal term = new T_Terminal (this);
			
			for ( int t=0; t < var_util.indexCSV ( input_st_csv ); ++t )
			{
				if ( !loj.selectIdentity ( var_util.getCSV ( t ) ) )
					return false;
				
				term.fetch_fk_loja ( loj.get_identity() );
									
				DadosLoja dl = new DadosLoja ();
				
				dl.set_st_loja			( loj.get_st_loja()				);
				dl.set_nu_CNPJ			( loj.get_nu_CNPJ()				);
				dl.set_st_nome			( loj.get_st_nome() 			);
				dl.set_st_cidade		( loj.get_st_cidade()			);
				dl.set_st_estado		( loj.get_st_estado()			);
				dl.set_vr_mensalidade	( loj.get_vr_mensalidade()		);
				dl.set_st_obs			( term.RowCount().ToString()	);
				
				output_array_generic_list.Add ( dl );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_listaLoja " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish fetch_listaLoja " ); 
		
			DataPortable dp_array_generic_list = new DataPortable();
		
			dp_array_generic_list.MapTagArray ( COMM_OUT_FETCH_LISTALOJA.list , ref output_array_generic_list );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_list );
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_listaLoja " ); 
		
			return true;
		}
	}
}
