using System;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_cadastros : type_base
	{
		public string output_st_csv_futebol = "";
		public string output_st_csv_profissoes = "";
		public string output_st_csv_comoSoube = "";
		public string output_st_csv_futebol_id = "";
		public string output_st_csv_profissoes_id = "";
		public string output_st_csv_comoSoube_id = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_cadastros ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_cadastros";
		}
		
		public fetch_cadastros()
		{
			var_Alias = "fetch_cadastros";
		
			dbProcedure = DB_PROCEDURE.on_demand;
		
			ut_max = 3;
			
			/// USER [ constructor ]
			/// USER [ constructor ] END
		}
		
		public override bool setup ( ) 
		{
			Registry ( "setup fetch_cadastros " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_FETCH_CADASTROS.header, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_CADASTROS.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_0 );
			
			Registry ( "setup done fetch_cadastros " ); 
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_cadastros " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_cadastros " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_cadastros " ); 
		
			/// USER [ execute ]

			StringBuilder 	build_fut 		= new StringBuilder();
			StringBuilder 	build_fut_id 	= new StringBuilder();
			T_Futebol  		fut 			= new T_Futebol (this);
			
			if ( fut.selectAll() )
			{
				int max = fut.RowCount() - 1, cnt = 0;
				
				while ( fut.fetch() )
				{
					ut_coverMark ( 1 );
					
					build_fut.Append 	( fut.get_st_nome() );
					build_fut_id.Append ( fut.get_identity() );
					
					if ( cnt++ < max )	
					{
						build_fut.Append 	( "|" );
						build_fut_id.Append ( "|" );
					}
				}
				
				output_st_csv_futebol = build_fut.ToString();
				output_st_csv_futebol_id = build_fut_id.ToString();
			}
			
			StringBuilder 	build_pro 		= new StringBuilder();
			StringBuilder 	build_pro_id 	= new StringBuilder();
			T_Profissoes	pro 			= new T_Profissoes (this);
			
			if ( pro.selectAll() )
			{
				int max = pro.RowCount() - 1, cnt = 0;
				
				while ( pro.fetch() )
				{
					ut_coverMark ( 2 );
					
					build_pro.Append 	( pro.get_st_codigo() + " - " + pro.get_st_profissao() );
					build_pro_id.Append ( pro.get_identity() );
					
					if ( cnt++ < max )	
					{
						build_pro.Append 	( "|" );
						build_pro_id.Append ( "|" );
					}
				}
				
				output_st_csv_profissoes = build_pro.ToString();
				output_st_csv_profissoes_id = build_pro_id.ToString();
			}
			
			StringBuilder 	build_cms 		= new StringBuilder();
			StringBuilder 	build_cms_id 	= new StringBuilder();
			T_ComoSoube		cms 			= new T_ComoSoube (this);
			
			if ( cms.selectAll() )
			{
				int max = cms.RowCount() - 1, cnt = 0;
				
				while ( cms.fetch() )
				{
					ut_coverMark ( 3 );
					
					build_cms.Append 	( cms.get_st_descricao() 	);
					build_cms_id.Append ( cms.get_identity() 		);
					
					if ( cnt++ < max )	
					{
						build_cms.Append 	( "|" );
						build_cms_id.Append ( "|" );
					}
				}
				
				output_st_csv_comoSoube = build_cms.ToString();
				output_st_csv_comoSoube_id = build_cms_id.ToString();
			}

			/// USER [ execute ] END
		
			Registry ( "execute done fetch_cadastros " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish fetch_cadastros " ); 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_CADASTROS.st_csv_futebol, output_st_csv_futebol ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_CADASTROS.st_csv_profissoes, output_st_csv_profissoes ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_CADASTROS.st_csv_comoSoube, output_st_csv_comoSoube ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_CADASTROS.st_csv_futebol_id, output_st_csv_futebol_id ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_CADASTROS.st_csv_profissoes_id, output_st_csv_profissoes_id ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_CADASTROS.st_csv_comoSoube_id, output_st_csv_comoSoube_id ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_cadastros " ); 
		
			return true;
		}
	}
}
