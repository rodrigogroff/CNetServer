using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class web_fetch_edu_ranking : Transaction
	{
		public string output_st_csv = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public web_fetch_edu_ranking ( Transaction trans ) : base (trans)
		{
			var_Alias = "web_fetch_edu_ranking";
			constructor();
		}
		
		public web_fetch_edu_ranking()
		{
			var_Alias = "web_fetch_edu_ranking";
		
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
			Registry ( "setup web_fetch_edu_ranking " ); 
		
			Registry ( "setup done web_fetch_edu_ranking " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate web_fetch_edu_ranking " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done web_fetch_edu_ranking " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute web_fetch_edu_ranking " ); 
		
			/// USER [ execute ]
			
			StringBuilder sb = new StringBuilder();
			
			T_Cartao cart = new T_Cartao(this);
			T_Empresa emp = new T_Empresa (this);
			
			if ( cart.select_rows_ranking ( TipoCartao.educacional ) )
			{
				while ( cart.fetch() )
				{
					if ( cart.get_int_nu_rankVirtual() > 0 )
					{
						DadosRanking rnk = new DadosRanking();
						
						string nome = "";
						
						if ( emp.select_rows_empresa ( cart.get_st_empresa() ) )
							if ( emp.fetch() )
								nome += emp.get_st_fantasia() + " - ";
						
						nome += cart.get_st_aluno();
						    
						rnk.set_st_pos 		( cart.get_nu_rankVirtual() 		);
						rnk.set_st_nome 	( nome				);
						rnk.set_vr_valor 	( cart.get_vr_edu_total_ranking()	);
									
						DataPortable mem_rtc = rnk as DataPortable;
						
						string index = MemorySave ( ref mem_rtc );
						
						sb.Append ( index );
						sb.Append ( ","   );
					}
				}
				
				output_st_csv = sb.ToString().TrimEnd ( ',' );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done web_fetch_edu_ranking " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish web_fetch_edu_ranking " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done web_fetch_edu_ranking " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_WEB_FETCH_EDU_RANKING.st_csv, output_st_csv ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
