using System;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_listaCartoes : type_base
	{
		public string input_st_csv_cartoes = "";
		
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_listaCartoes ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_listaCartoes";
		}
		
		public fetch_listaCartoes()
		{
			var_Alias = "fetch_listaCartoes";
		
			dbProcedure = DB_PROCEDURE.on_demand;
		
			ut_max = 0;
			
			/// USER [ constructor ]
			/// USER [ constructor ] END
		}
		
		public override bool setup ( ) 
		{
			Registry ( "setup fetch_listaCartoes " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_LISTACARTOES.st_csv_cartoes, ref input_st_csv_cartoes ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_LISTACARTOES.st_csv_cartoes missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_LISTACARTOES.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_LISTACARTOES.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_listaCartoes " ); 
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_listaCartoes " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_listaCartoes " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_listaCartoes " ); 
		
			/// USER [ execute ]
			
			T_Cartao cart = new T_Cartao (this);
			T_Proprietario prot = new T_Proprietario(this);
			
			for ( int t=0; t < var_util.indexCSV ( input_st_csv_cartoes ); ++t )
			{
				if ( !cart.selectIdentity ( var_util.getCSV ( t ) ) )
					return false;
				
				if ( !prot.selectIdentity ( cart.get_fk_dadosProprietario() ) )
					return false;
				
				DadosCartao dc = new DadosCartao();
				
				dc.set_st_proprietario ( prot.get_st_nome() );
				
				dc.set_st_empresa	 	( cart.get_st_empresa() 		);
				dc.set_st_matricula 	( cart.get_st_matricula() 		);
				dc.set_tg_status 		( cart.get_tg_status()		 	);
				dc.set_st_vencimento 	( cart.get_st_venctoCartao() 	);
				
				dc.set_vr_limiteTotal		( cart.get_vr_limiteTotal()		);
				dc.set_vr_limiteMensal		( cart.get_vr_limiteMensal() 	);
				dc.set_vr_limiteRotativo	( cart.get_vr_limiteRotativo() 	);
				dc.set_vr_extraCota			( cart.get_vr_extraCota() 		);
				
				output_array_generic_lst.Add ( dc );
			}
				
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_listaCartoes " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish fetch_listaCartoes " ); 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_FETCH_LISTACARTOES.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_listaCartoes " ); 
		
			return true;
		}
	}
}
