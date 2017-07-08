using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_rel_edu_movEscola : type_base
	{
		public string input_st_empresa = "";
		public string input_st_dt_ini = "";
		public string input_st_dt_fim = "";
		
		public string output_st_content = "";
		public string output_st_nome_escola = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_rel_edu_movEscola ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_rel_edu_movEscola";
			constructor();
		}
		
		public fetch_rel_edu_movEscola()
		{
			var_Alias = "fetch_rel_edu_movEscola";
		
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
			Registry ( "setup fetch_rel_edu_movEscola " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_EDU_MOVESCOLA.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_EDU_MOVESCOLA.st_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_EDU_MOVESCOLA.st_dt_ini, ref input_st_dt_ini ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_EDU_MOVESCOLA.st_dt_ini missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_EDU_MOVESCOLA.st_dt_fim, ref input_st_dt_fim ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_EDU_MOVESCOLA.st_dt_fim missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_REL_EDU_MOVESCOLA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_REL_EDU_MOVESCOLA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_rel_edu_movEscola " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_rel_edu_movEscola " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_rel_edu_movEscola " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_rel_edu_movEscola " ); 
		
			/// USER [ execute ]
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_st_empresa ) )
			{
				PublishError ( "Nenhuma empresa com o código fornecido" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			output_st_nome_escola = emp.get_st_fantasia();
			
			LOG_Transacoes ltr = new LOG_Transacoes (this);
			
			StringBuilder sb = new StringBuilder();
			
			if ( ltr.select_rows_emp_dt ( 	emp.get_identity(),
			                         		input_st_dt_ini,
			                         		input_st_dt_fim,
			                         		TipoConfirmacao.Confirmada ) )
			{
				
				T_Cartao cart = new T_Cartao (this);
				T_Loja   loj  = new T_Loja (this);
				
				while ( ltr.fetch() )
				{
					if ( !cart.selectIdentity ( ltr.get_fk_cartao() ) )
						continue;
					
					if ( !loj.selectIdentity ( ltr.get_fk_loja() ) )
						continue;
					
					Rel_MovEscola rme = new Rel_MovEscola();
					
					rme.set_st_aluno ( cart.get_st_aluno() 								);
					rme.set_st_loja  ( loj.get_st_nome() + " - " + loj.get_st_social() 	);
					rme.set_vr_valor ( ltr.get_vr_total() 								);
					rme.set_dt_trans ( ltr.get_dt_transacao() 							);
					
					DataPortable mem_rme = rme as DataPortable;
						
					// # Guarda registro
					
					sb.Append ( MemorySave ( ref mem_rme ) ); 
					sb.Append ( "," );						
				}
			}
			
			string list_ids = sb.ToString().TrimEnd ( ',' );
								
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", list_ids );
			
			output_st_content = MemorySave ( ref dp );
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_rel_edu_movEscola " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_rel_edu_movEscola " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_rel_edu_movEscola " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_EDU_MOVESCOLA.st_content, output_st_content ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_EDU_MOVESCOLA.st_nome_escola, output_st_nome_escola ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
