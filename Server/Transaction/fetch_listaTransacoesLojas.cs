using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_listaTransacoesLojas : type_base
	{
		public string input_dt_ini = "";
		public string input_dt_fim = "";
		
		public string output_st_csv = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_listaTransacoesLojas ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_listaTransacoesLojas";
			constructor();
		}
		
		public fetch_listaTransacoesLojas()
		{
			var_Alias = "fetch_listaTransacoesLojas";
		
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
			Registry ( "setup fetch_listaTransacoesLojas " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_LISTATRANSACOESLOJAS.dt_ini, ref input_dt_ini ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_LISTATRANSACOESLOJAS.dt_ini missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_LISTATRANSACOESLOJAS.dt_fim, ref input_dt_fim ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_LISTATRANSACOESLOJAS.dt_fim missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_LISTATRANSACOESLOJAS.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_LISTATRANSACOESLOJAS.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_listaTransacoesLojas " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_listaTransacoesLojas " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_listaTransacoesLojas " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_listaTransacoesLojas " ); 
		
			/// USER [ execute ]
			
			LOG_Transacoes ltr = new LOG_Transacoes (this);
			
			if ( !ltr.select_rows_dt ( input_dt_ini, input_dt_fim ) )
			{
				PublishError ( "Nenhuma transação disponível" );
				return false;
			}	
			
			Hashtable hshEmp = new Hashtable();
			Hashtable hshLoj = new Hashtable();
			
			ArrayList lstEmp = new ArrayList();
			ArrayList lstLoj = new ArrayList();
						
			while ( ltr.fetch() )
			{
				string fk_empresa = ltr.get_fk_empresa();
				
				if ( hshEmp [ fk_empresa ] == null )
				{
					hshEmp [ fk_empresa ] = (long) 0;
					lstEmp.Add ( fk_empresa );
				}
				
				hshEmp [ fk_empresa ] = (long) hshEmp [ fk_empresa ] + 1;
				
				string fk_loja = ltr.get_fk_loja();
				
				if ( hshLoj [ fk_loja ] == null )
				{
					hshLoj [ fk_loja ] = (long) 0;
					lstLoj.Add ( fk_loja );
				}
				
				hshLoj [ fk_loja ] = (long) hshLoj [ fk_loja ] + 1;
			}
			
			ArrayList lstEmpSort = new ArrayList();
			
			for ( int t=0; t < lstEmp.Count; ++t )
			{
				string  tg = lstEmp[t].ToString();
				long   qtd = (long) hshEmp [ tg ];
				string res = qtd.ToString().PadLeft ( 12, '0' ) + tg;
				
				lstEmpSort.Add ( res );
			}
			
			ArrayList lstLojSort = new ArrayList();
			
			for ( int t=0; t < lstLoj.Count; ++t )
			{
				string tg  = lstLoj[t].ToString();
				long   qtd = (long) hshLoj [ tg ];
				string res = qtd.ToString().PadLeft ( 12, '0' ) + tg;
				
				lstLojSort.Add ( res );
			}
			
			lstEmpSort.Sort();
			lstLojSort.Sort();
			
			StringBuilder sb_global = new StringBuilder();
			
			T_Empresa emp = new T_Empresa(this);
			
			for ( int t = lstEmpSort.Count - 1; t >=0  ; --t )
			{
				string line = lstEmpSort[t].ToString();
				string qtd  = line.Substring ( 0 , 12 ).TrimStart ( '0' );
			
				if ( emp.selectIdentity ( line.Substring ( 12, line.Length - 12 )  ) )
				{
					DadosConsultaGraficoTransLojas dl = new DadosConsultaGraficoTransLojas();
					
					dl.set_nu_trans ( qtd 					);
					dl.set_nu_cod   ( emp.get_st_empresa() 	);
					dl.set_st_nome  ( emp.get_st_fantasia() );
					dl.set_tg_tipo  ( "E" 					);
					
					DataPortable mem = dl as DataPortable;
						
					sb_global.Append ( MemorySave ( ref mem ) );
					sb_global.Append ( ","   );
				}
			}
					
			T_Loja loj = new T_Loja(this);
			
			for ( int t = lstLojSort.Count - 1; t >=0  ; --t )
			{
				string line = lstLojSort[t].ToString();
				string qtd  = line.Substring ( 0 , 12 ).TrimStart ( '0' );
				
				if ( loj.selectIdentity( line.Substring ( 12, line.Length - 12 )  ) )
				{
					DadosConsultaGraficoTransLojas dl = new DadosConsultaGraficoTransLojas();
					
					dl.set_nu_trans ( qtd 					);
					dl.set_nu_cod   ( loj.get_st_loja() 	);
					dl.set_st_nome  ( loj.get_st_nome() + " - " + loj.get_st_social() );
					dl.set_tg_tipo  ( "L" 					);
					
					DataPortable mem = dl as DataPortable;
						
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
		
			Registry ( "execute done fetch_listaTransacoesLojas " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_listaTransacoesLojas " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_listaTransacoesLojas " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_LISTATRANSACOESLOJAS.st_csv, output_st_csv ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
