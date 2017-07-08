using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class graph_transacoes : type_base
	{
		public string input_dt_ini = "";
		public string input_dt_fim = "";
		
		public ArrayList input_array_generic_lst = new ArrayList();
		
		public string output_st_csv = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public graph_transacoes ( Transaction trans ) : base (trans)
		{
			var_Alias = "graph_transacoes";
			constructor();
		}
		
		public graph_transacoes()
		{
			var_Alias = "graph_transacoes";
		
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
			Registry ( "setup graph_transacoes " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_GRAPH_TRANSACOES.dt_ini, ref input_dt_ini ) == false ) 
			{
				Trace ( "# COMM_IN_GRAPH_TRANSACOES.dt_ini missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_GRAPH_TRANSACOES.dt_fim, ref input_dt_fim ) == false ) 
			{
				Trace ( "# COMM_IN_GRAPH_TRANSACOES.dt_fim missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_GRAPH_TRANSACOES.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_GRAPH_TRANSACOES.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			DataPortable dp_array_generic_lst = var_Comm.GetEntryPortableAtPosition ( 2 );
			
			if ( dp_array_generic_lst.GetMapArray ( COMM_IN_GRAPH_TRANSACOES.lst , ref input_array_generic_lst ) == false )
			{
				Trace ( "# COMM_IN_GRAPH_TRANSACOES.lst missing! " ); 
				return false;
			}
			
			Registry ( "setup done graph_transacoes " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate graph_transacoes " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done graph_transacoes " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute graph_transacoes " ); 
		
			/// USER [ execute ]
			
			LOG_Transacoes ltr = new LOG_Transacoes (this);
			
			StringBuilder sb_global = new StringBuilder();
			
			T_Loja    loj = new T_Loja (this);
			T_Empresa emp = new T_Empresa (this);
			
			DateTime t_start = Convert.ToDateTime ( input_dt_ini );
			DateTime t_end   = Convert.ToDateTime ( input_dt_fim ).AddHours ( 23 ).AddMinutes ( 59 ).AddSeconds ( 59 );
			
			if ( t_start.Day == t_end.Day )
			{
				if ( t_start.Month == t_end.Month )
				{
					PublishError ( "Favor informar período com datas diferentes" );
					return false;
				}
			}
			
			for ( int u=0; u < input_array_generic_lst.Count; ++u )
			{
				DadosConsultaGraficoTransLojas dl = new DadosConsultaGraficoTransLojas ( input_array_generic_lst[u] as DataPortable );
				
				ltr.Reset();
				
				Hashtable hsh_globalday = new Hashtable();
				ArrayList lst_globalday = new ArrayList();
				
				if ( dl.get_tg_tipo() == "E" )
				{
					if ( emp.select_rows_empresa ( dl.get_nu_cod() ) )
					{
						if ( emp.fetch() )
						{
							if ( !ltr.select_rows_dt_emp ( GetDataBaseTime ( t_start ),
				 		                               	   GetDataBaseTime ( t_end ),
				 		                               	   emp.get_identity() ) )
							{
								continue;
							}
						}
					}
				}
				else
				{
					if ( loj.select_rows_loja ( dl.get_nu_cod() ) )
					{
						if ( loj.fetch() )
						{
							if ( !ltr.select_rows_dt_loj ( GetDataBaseTime ( t_start ),
				 		                               	   GetDataBaseTime ( t_end ),
				 		                               	   loj.get_identity() ) )
							{
								continue;
							}
						}
					}
				}
				
				long nu_tot = 0;
				
				while ( ltr.fetch() )
				{
					string day = ltr.get_dt_transacao().Substring ( 0, 10 );
					
					if ( hsh_globalday [ day ] == null )
					{
						hsh_globalday [ day ] = (long) nu_tot;
						lst_globalday.Add ( day );
					}
					
					hsh_globalday [ day ] = ++nu_tot;
				}
				
				for ( int t=0; t < lst_globalday.Count; ++t )
				{
					string day = lst_globalday[t].ToString();
					
					long nu_trans = (long) hsh_globalday [day];
					
					DadosConsultaGraficoTransLojas dgtl = new DadosConsultaGraficoTransLojas();
					
					dgtl.set_dt_trans ( day + " 00:00" 		);
					dgtl.set_nu_trans ( nu_trans.ToString() );
					dgtl.set_nu_id 	  ( u.ToString() 		);
										
					DataPortable mem = dgtl as DataPortable;
					
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
			
			output_st_csv = MemorySave ( ref dp );
			
			/// USER [ execute ] END
		
			Registry ( "execute done graph_transacoes " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish graph_transacoes " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done graph_transacoes " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_GRAPH_TRANSACOES.st_csv, output_st_csv ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
