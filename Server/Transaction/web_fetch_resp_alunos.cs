using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class web_fetch_resp_alunos : Transaction
	{
		public string input_st_cpf = "";
		public string input_st_senha = "";
		
		public string output_st_nomeResp = "";
		
		public ArrayList output_array_generic_lst = new ArrayList(); 
		public ArrayList output_array_generic_lstMsg = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public web_fetch_resp_alunos ( Transaction trans ) : base (trans)
		{
			var_Alias = "web_fetch_resp_alunos";
			constructor();
		}
		
		public web_fetch_resp_alunos()
		{
			var_Alias = "web_fetch_resp_alunos";
		
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
			Registry ( "setup web_fetch_resp_alunos " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_FETCH_RESP_ALUNOS.st_cpf, ref input_st_cpf ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_FETCH_RESP_ALUNOS.st_cpf missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_FETCH_RESP_ALUNOS.st_senha, ref input_st_senha ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_FETCH_RESP_ALUNOS.st_senha missing! " ); 
				return false;
			}
			
			Registry ( "setup done web_fetch_resp_alunos " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate web_fetch_resp_alunos " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done web_fetch_resp_alunos " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute web_fetch_resp_alunos " ); 
		
			/// USER [ execute ]
			
			ArrayList lstEscolas = new ArrayList();
			
			if  ( input_st_cpf.Length > 0 )
			{
				T_Proprietario prot = new T_Proprietario(this);
				
				if ( !prot.select_rows_cpf ( input_st_cpf ) )
				{
					PublishError ( "CPF inválido" );
					return false;
				}
				
				if ( !prot.fetch () )
					return false;
				
				if ( prot.get_st_senhaEdu() != input_st_senha )
				{
					PublishError ( "Senha inválida" );
					return false;
				}
				
				output_st_nomeResp = prot.get_st_nome();
				
				LINK_ProprietarioCartao prop_cart = new LINK_ProprietarioCartao (this);
				
				if ( !prop_cart.select_fk_proprietario ( prot.get_identity() ) )
				{
					PublishError ( "Nenhum cartão educacional cadastrado" );
					return false;
				}
				
				T_Cartao cart = new T_Cartao (this);
				
				while ( prop_cart.fetch() )
				{
					if ( !cart.selectIdentity ( prop_cart.get_fk_cartao() ) )
						return false;	
					
					if ( cart.get_tg_tipoCartao() == TipoCartao.educacional )
					{
						DadosCartaoEdu dce = new DadosCartaoEdu();
						
						if ( !lstEscolas.Contains ( cart.get_st_empresa() ) )
							lstEscolas.Add ( cart.get_st_empresa() );
						
						dce.set_st_aluno  ( cart.get_st_aluno() );
						dce.set_st_cartao ( cart.get_st_empresa() + cart.get_st_matricula() + cart.get_st_titularidade() );
						
						dce.set_vr_disp   ( cart.get_vr_disp_educacional() );
						
						output_array_generic_lst.Add ( dce );
					}
				}	
			}

			T_Empresa escola = new T_Empresa(this);
			T_MensagemEdu msg_edu = new T_MensagemEdu (this);
		
			for ( int t=0; t < lstEscolas.Count; ++t )
			{
				string t_escola = lstEscolas[t].ToString();
				
				if ( !escola.select_rows_empresa ( t_escola ) )
					continue;
				
				if ( !escola.fetch() )
					continue;
				
				if ( msg_edu.select_rows_dt ( escola.get_identity(), GetDataBaseTime(), GetDataBaseTime() ) )
				{
					while ( msg_edu.fetch() )
					{
						DadosEduMessage dem = new DadosEduMessage();
						
						DateTime tim = Convert.ToDateTime ( msg_edu.get_dt_ini() );
				
						dem.set_st_title ( escola.get_st_fantasia() + " - " + tim.ToLongDateString() );
						
						string db_msg = msg_edu.get_st_mens();
						
						string final_msg = "";
						
						for ( int g=0; g < db_msg.Length; ++g )
						{
							if ( db_msg[g] == 13 )
								final_msg += "<br>";
							else
								final_msg += db_msg[g].ToString();
						}
						
						dem.set_st_msg ( final_msg );
				
						output_array_generic_lstMsg.Add ( dem );
					}
				}
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done web_fetch_resp_alunos " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish web_fetch_resp_alunos " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done web_fetch_resp_alunos " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_WEB_FETCH_RESP_ALUNOS.st_nomeResp, output_st_nomeResp ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			DataPortable dp_array_generic_lst = new DataPortable();
			DataPortable dp_array_generic_lstMsg = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_WEB_FETCH_RESP_ALUNOS.lst , ref output_array_generic_lst );
			dp_array_generic_lstMsg.MapTagArray ( COMM_OUT_WEB_FETCH_RESP_ALUNOS.lstMsg , ref output_array_generic_lstMsg );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
			var_Comm.AddExitPortable ( ref dp_array_generic_lstMsg );
		
			return true;
		}
	}
}
