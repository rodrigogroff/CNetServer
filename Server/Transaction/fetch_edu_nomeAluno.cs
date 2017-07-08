using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_edu_nomeAluno : type_base
	{
		public string input_st_nome = "";
		
		public string output_st_csv = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_edu_nomeAluno ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_edu_nomeAluno";
			constructor();
		}
		
		public fetch_edu_nomeAluno()
		{
			var_Alias = "fetch_edu_nomeAluno";
		
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
			Registry ( "setup fetch_edu_nomeAluno " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_EDU_NOMEALUNO.st_nome, ref input_st_nome ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_EDU_NOMEALUNO.st_nome missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_EDU_NOMEALUNO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_EDU_NOMEALUNO.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_edu_nomeAluno " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_edu_nomeAluno " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_edu_nomeAluno " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_edu_nomeAluno " ); 
		
			/// USER [ execute ]
			
			string emp = input_cont_header.get_st_empresa().PadLeft ( 6, '0' );
					
			T_Cartao cart = new T_Cartao (this);
			
			// ## Busca registros de cartões
			
			if ( emp != "000000" )
			{
				if ( !cart.select_rows_emp_edu ( emp, TipoCartao.educacional ) )
				{
					PublishError ( "Nenhum aluno cadastrado" );
					return false;
				}
			}
			else if ( !cart.select_rows_tipo ( TipoCartao.educacional ) )
			{
				PublishError ( "Nenhum aluno cadastrado" );
				return false;
			}
			
			StringBuilder sb = new StringBuilder();
			
			// ## Busca registros
			
			while ( cart.fetch() )
			{
				if ( !cart.get_st_aluno().Contains ( input_st_nome ) )
					continue;
				
				// ## Copia dados para memória
				
				DadosCartaoEdu dce = new DadosCartaoEdu();
				
				dce.set_st_aluno  ( cart.get_st_aluno() );
				dce.set_st_cartao ( cart.get_st_empresa() + 
				                    cart.get_st_matricula() + 
				                    "01" );
				
				DataPortable mem_rtc = dce as DataPortable;
				
				// ## obtem indexador
				
				sb.Append ( MemorySave ( ref mem_rtc ) );
				sb.Append ( ","   );
			}
			
			string list_ids = sb.ToString().TrimEnd ( ',' );
			
			if ( list_ids == "" )
			{
				PublishNote ( "Nenhum resultado foi encontrado" );
				return true;
			}
									
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", list_ids );
			
			// ## obtem indexador geral de grupo
						  
			output_st_csv = MemorySave ( ref dp );
					
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_edu_nomeAluno " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_edu_nomeAluno " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_edu_nomeAluno " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_EDU_NOMEALUNO.st_csv, output_st_csv ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
