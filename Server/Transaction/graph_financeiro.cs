using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class graph_financeiro : type_base
	{
		public string input_tg_tipo = "";
		
		public ArrayList input_array_generic_lstCurves = new ArrayList();
		
		public string output_st_content = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public graph_financeiro ( Transaction trans ) : base (trans)
		{
			var_Alias = "graph_financeiro";
			constructor();
		}
		
		public graph_financeiro()
		{
			var_Alias = "graph_financeiro";
		
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
			Registry ( "setup graph_financeiro " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_GRAPH_FINANCEIRO.tg_tipo, ref input_tg_tipo ) == false ) 
			{
				Trace ( "# COMM_IN_GRAPH_FINANCEIRO.tg_tipo missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_GRAPH_FINANCEIRO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_GRAPH_FINANCEIRO.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			DataPortable dp_array_generic_lstCurves = var_Comm.GetEntryPortableAtPosition ( 2 );
			
			if ( dp_array_generic_lstCurves.GetMapArray ( COMM_IN_GRAPH_FINANCEIRO.lstCurves , ref input_array_generic_lstCurves ) == false )
			{
				Trace ( "# COMM_IN_GRAPH_FINANCEIRO.lstCurves missing! " ); 
				return false;
			}
			
			Registry ( "setup done graph_financeiro " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate graph_financeiro " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done graph_financeiro " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute graph_financeiro " ); 
		
			/// USER [ execute ]

			LOG_Transacoes ltr = new LOG_Transacoes (this);
			
			StringBuilder sb_global = new StringBuilder();
			
			T_Loja    loj = new T_Loja (this);
			T_Empresa emp = new T_Empresa (this);
			
			for ( int u=0; u < input_array_generic_lstCurves.Count; ++u )
			{
				DadosGraficoFinanceiro tmp_dgf = new DadosGraficoFinanceiro ( input_array_generic_lstCurves[u] as DataPortable );
				
				DateTime t_start = Convert.ToDateTime ( tmp_dgf.get_dt_ini() );
				DateTime t_end   = Convert.ToDateTime ( tmp_dgf.get_dt_fim() ).AddHours ( 23 ).AddMinutes ( 59 ).AddSeconds ( 59 );
				
				loj.Reset();
				
				if ( loj.select_rows_loja ( tmp_dgf.get_st_loja() ) )
				{
					if ( !loj.fetch() )
						return false;
				}
				
				emp.Reset();
				
				if ( emp.select_rows_empresa ( tmp_dgf.get_st_empresa().PadLeft ( 6, '0' ) ) )
				{
					if ( !emp.fetch() )
						return false;
				}
				
				Hashtable hsh_globalday = new Hashtable();
				ArrayList lst_globalday = new ArrayList();
				
				bool loj_fetch = false;
				bool tudo      = false;
							
				if ( t_start.Day == t_end.Day )
				{
					if ( t_start.Month == t_end.Month )
					{
						PublishError ( "Favor informar período com datas diferentes" );
						return false;
					}
				}
	
				if ( loj.get_identity() != Context.NOT_SET && 
				     emp.get_identity() != Context.NOT_SET )
				{
					loj_fetch = true;
						
					if ( !ltr.select_rows_graph_financ_loj ( GetDataBaseTime ( t_start ),
				 		                               		 GetDataBaseTime ( t_end ),
				 		                               		 TipoConfirmacao.Confirmada,
				 		                               		 loj.get_identity(),
				 		                               		 emp.get_identity() ) )
					{
						PublishNote ( "Nenhum resultado para " + loj.get_st_nome() );
					}
				}
				else if ( emp.get_identity() != Context.NOT_SET )
				{
					if ( !ltr.select_rows_graph_financ_emp ( GetDataBaseTime ( t_start ),
				 		                               		 GetDataBaseTime ( t_end ),
				 		                               		 TipoConfirmacao.Confirmada,
				 		                               		 emp.get_identity() ) )
					{
						PublishNote ( "Nenhum resultado para " + emp.get_st_fantasia() );
					}
				}
				else if ( tmp_dgf.get_st_empresa() == Context.NOT_SET )
				{
					tudo = true;
						
					ltr.select_rows_graph_financ 	(  GetDataBaseTime ( t_start ),
				 		                               GetDataBaseTime ( t_end ),
				 		                               TipoConfirmacao.Confirmada ); 
				}
				
				long vr_tot = 0;
				
				while ( ltr.fetch() )
				{
					string day = ltr.get_dt_transacao().Substring ( 0, 10 );
					
					if ( hsh_globalday [ day ] == null )
					{
						if ( input_tg_tipo == "0" ) // variavel
							hsh_globalday [ day ] = (long) 0;
						else
							hsh_globalday [ day ] = (long) vr_tot;
							
						lst_globalday.Add ( day );
					}
					
					vr_tot += ltr.get_int_vr_total();
					
					if ( input_tg_tipo == "0" ) // variavel
						hsh_globalday [ day ] = (long) hsh_globalday [ day ] + ltr.get_int_vr_total();
					else
						hsh_globalday [ day ] = vr_tot;
				}
				
				for ( int t=0; t < lst_globalday.Count; ++t )
				{
					string day = lst_globalday[t].ToString();
					
					string nome_desc = "";
					
					if ( loj_fetch )
						nome_desc = "Loja " + loj.get_st_loja() + " " + loj.get_st_nome() + " [" + emp.get_st_empresa() + "]";
					else if ( !tudo )
						nome_desc = "Empresa " + emp.get_st_empresa();
					else
						nome_desc = "ConveyNET";
					
					long vr_valor = (long) hsh_globalday [day];
					
					DadosGraficoFinanceiro dgf = new DadosGraficoFinanceiro();
					
					dgf.set_nu_id 	 ( u.ToString() 		);
					dgf.set_dt_point ( day + " 00:00" 		);
					dgf.set_st_loja  ( nome_desc 			);
					dgf.set_vr_point ( vr_valor.ToString()	);
					
					DataPortable mem = dgf as DataPortable;
					
					sb_global.Append ( MemorySave ( ref mem ) );
					sb_global.Append ( ","   );
				}
			}
						
			string list_ids = sb_global.ToString().TrimEnd ( ',' );
			
			if ( list_ids == "" )
			{
				PublishNote ( "Nenhum registro encontrado" );
				return false;
			}
									
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", list_ids );
			
			output_st_content = MemorySave ( ref dp );
			
			/// USER [ execute ] END
		
			Registry ( "execute done graph_financeiro " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish graph_financeiro " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done graph_financeiro " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_GRAPH_FINANCEIRO.st_content, output_st_content ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
