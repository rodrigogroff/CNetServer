using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_rel_edu_movRedeEscola : type_base
	{
		public string input_st_dt_ini = "";
		public string input_st_dt_fim = "";
		
		public string output_st_content = "";
		public string output_st_empresa = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_rel_edu_movRedeEscola ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_rel_edu_movRedeEscola";
			constructor();
		}
		
		public fetch_rel_edu_movRedeEscola()
		{
			var_Alias = "fetch_rel_edu_movRedeEscola";
		
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
			Registry ( "setup fetch_rel_edu_movRedeEscola " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_EDU_MOVREDEESCOLA.st_dt_ini, ref input_st_dt_ini ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_EDU_MOVREDEESCOLA.st_dt_ini missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_EDU_MOVREDEESCOLA.st_dt_fim, ref input_st_dt_fim ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_EDU_MOVREDEESCOLA.st_dt_fim missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_REL_EDU_MOVREDEESCOLA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_REL_EDU_MOVREDEESCOLA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_rel_edu_movRedeEscola " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_rel_edu_movRedeEscola " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_rel_edu_movRedeEscola " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_rel_edu_movRedeEscola " ); 
		
			/// USER [ execute ]
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_cont_header.get_st_empresa() ) )
			{
				PublishError ( "Nenhuma empresa com o código fornecido" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			output_st_empresa = emp.get_st_fantasia();
			
			T_Empresa emp_escola = new T_Empresa (this);
			
			if ( !emp_escola.select_fk_admin ( emp.get_identity() ) )
			{
				PublishError ( "Nenhum colégio cadastrado" );
				return false;
			}
			
			ArrayList lstEscolas = new ArrayList();
					
			while ( emp_escola.fetch() )
				lstEscolas.Add ( emp_escola.get_identity() );
			
			ArrayList lstResults = new ArrayList();
			
			LOG_Transacoes ltr = new LOG_Transacoes (this);
			
			// busca todas escolas cadastradas
			for (int t=0; t < lstEscolas.Count; ++t )
			{
				emp_escola.selectIdentity ( lstEscolas[t].ToString() );
					
				if ( ltr.select_rows_emp_dt ( 	emp_escola.get_identity(),
				                         		input_st_dt_ini,
				                         		input_st_dt_fim,
				                         		TipoConfirmacao.Confirmada ) )
				{
					Hashtable hshLojaValor = new Hashtable();
					ArrayList lstLoja = new ArrayList();					
			
					// busca todas as transações das lojas e seu somatorio
					while ( ltr.fetch() )
					{
						string fk_loja = ltr.get_fk_loja();
					
						if ( !lstLoja.Contains ( fk_loja ) )
					    {
						    hshLojaValor [ fk_loja ] = Convert.ToInt64 ( 0 );
						    lstLoja.Add ( fk_loja );
					    }
			
						// acrescenta mais um valor na loja 
						hshLojaValor [ fk_loja ] = 	Convert.ToInt64 ( hshLojaValor [ fk_loja ] ) + 
													ltr.get_int_vr_total();
					}
					
					
					for (int h=0; h < lstLoja.Count; ++h )
					{
						string fk_loja    = lstLoja[h].ToString();
						string tot_amount = Convert.ToInt64 ( hshLojaValor [ fk_loja ] ).ToString();
					
						lstResults.Add ( tot_amount.PadLeft ( 12, '0' ) + 
						                 emp_escola.get_identity().PadLeft ( 12, '0' ) + 
						                 fk_loja.PadLeft ( 12, '0' ) );
					}
				}
			}
			
			// ordena
			lstResults.Sort();
			
			T_Loja loj = new T_Loja (this);
			
			StringBuilder sb = new StringBuilder();
			
			for ( int t=0; t < lstResults.Count; ++t )
			{
				string numbers = lstResults[t].ToString();
				
				string valor  = numbers.Substring (0, 12 ).TrimStart ( '0' );
				string escola = numbers.Substring (12, 12 ).TrimStart ( '0' );
				string loja   = numbers.Substring (24, 12 ).TrimStart ( '0' );
			
				if ( !emp_escola.selectIdentity ( escola ) )
					continue;
				
				if ( !loj.selectIdentity ( loja ) )
					continue;
					
				Rel_MovRedeEscola rme = new Rel_MovRedeEscola();
				
				rme.set_st_loja  	( loj.get_st_nome() + " - " + loj.get_st_social() 	);
				rme.set_vr_valor 	( valor 											);
				rme.set_st_colegio 	( emp_escola.get_st_fantasia() 						);
				
				DataPortable mem_rme = rme as DataPortable;
					
				// # Guarda registro
				
				sb.Append ( MemorySave ( ref mem_rme ) ); 
				sb.Append ( "," );						
			}
			
			string list_ids = sb.ToString().TrimEnd ( ',' );
								
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", list_ids );
			
			output_st_content = MemorySave ( ref dp );
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_rel_edu_movRedeEscola " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_rel_edu_movRedeEscola " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_rel_edu_movRedeEscola " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_EDU_MOVREDEESCOLA.st_content, output_st_content ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_EDU_MOVREDEESCOLA.st_empresa, output_st_empresa ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
