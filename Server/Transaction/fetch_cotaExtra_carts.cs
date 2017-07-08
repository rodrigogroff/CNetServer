using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_cotaExtra_carts : type_base
	{
		public string input_emp = "";
		
		public string output_csv = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_cotaExtra_carts ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_cotaExtra_carts";
			constructor();
		}
		
		public fetch_cotaExtra_carts()
		{
			var_Alias = "fetch_cotaExtra_carts";
		
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
			Registry ( "setup fetch_cotaExtra_carts " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_COTAEXTRA_CARTS.emp, ref input_emp ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_COTAEXTRA_CARTS.emp missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_COTAEXTRA_CARTS.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_COTAEXTRA_CARTS.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_cotaExtra_carts " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_cotaExtra_carts " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_cotaExtra_carts " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_cotaExtra_carts " ); 
		
			/// USER [ execute ]
			
			T_Empresa emp = new T_Empresa ( this );
			
			if ( !emp.select_rows_empresa ( input_emp.PadLeft ( 6, '0' ) ) )
				return false;
			
			if ( !emp.fetch() )
				return false;
			
			T_Cartao cart = new T_Cartao (this);
			
			StringBuilder sb = new StringBuilder();
			
			if ( cart.select_rows_empresa ( input_emp.PadLeft ( 6, '0' ) ) )
			{
				T_Proprietario prot = new T_Proprietario (this);
				
				while ( cart.fetch() )
				{
					if ( cart.get_tg_status() != CartaoStatus.Habilitado )
						continue;
					
					if ( cart.get_st_titularidade() != "01" )
						continue;
					
					if ( !prot.selectIdentity ( cart.get_fk_dadosProprietario() ) )
						continue;
					
					DadosCartao dc = new DadosCartao ();
					
					dc.set_st_matricula 	( cart.get_st_matricula() 		);
					dc.set_st_proprietario 	( prot.get_st_nome().ToUpper() 	);
					
					DataPortable mem_rtc_parc = dc as DataPortable;
				
					// ## obtem indice
					
					sb.Append ( MemorySave ( ref mem_rtc_parc ) );
					sb.Append ( ","   );
				}
			}
			
			string list_ids = sb.ToString().TrimEnd ( ',' );
									
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", list_ids );
				
			// ## obtem indice geral
			
			output_csv = MemorySave ( ref dp );
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_cotaExtra_carts " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_cotaExtra_carts " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_cotaExtra_carts " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_COTAEXTRA_CARTS.csv, output_csv ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
