using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class load_edu : type_load
	{
		/// USER [ var_decl ]
		
		string dt_atual = "";
		string escola = "";
		
		/// USER [ var_decl ] END
		
		public load_edu ( Transaction trans ) : base (trans)
		{
			var_Alias = "load_edu";
			constructor();
		}
		
		public load_edu()
		{
			var_Alias = "load_edu";
		
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
			Registry ( "setup load_edu " ); 
		
			Registry ( "setup done load_edu " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate load_edu " ); 
		
			/// USER [ authenticate ]
						
			dt_atual = GetDataBaseTime();
				
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done load_edu " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute load_edu " ); 
		
			/// USER [ execute ]
			
			StreamReader reader = new StreamReader ( archive );
			
			try
			{
				while ( !reader.EndOfStream )
				{
					string line = reader.ReadLine();
					
					Trace ( line );
					
					if ( line.Length < 311 )
					{
						Trace ( "Registro Rejeitado" );	
						continue;
					}
					else
					{
						Trace ( "Registro Aceito" );	
					}
					
					int pos = 0;
					
					string cpf_resp          = line.Substring ( pos, 11 ); pos += 11; 
					string nome_resp         = line.Substring ( pos, 50 ); pos += 50;  
					string nome_aluno        = line.Substring ( pos, 50 ); pos += 50; 
					string end               = line.Substring ( pos, 40 ); pos += 40;
					string bairro            = line.Substring ( pos, 20 ); pos += 20; 
					string cep               = line.Substring ( pos,  8 ); pos +=  8; 
					string cidade            = line.Substring ( pos, 20 ); pos += 20; 
					string tel               = line.Substring ( pos, 10 ); pos += 10; 
					string email_resp        = line.Substring ( pos, 50 ); pos += 50; 
					string dt_nasc_aluno     = line.Substring ( pos,  8 ); pos +=  8; 
					string sexo              = line.Substring ( pos,  1 ); pos +=  1; 
					string grau              = line.Substring ( pos,  1 ); pos +=  1; 
					string serie_semestre    = line.Substring ( pos,  2 ); pos +=  2;  
					string turma             = line.Substring ( pos, 10 ); pos += 10; 
					string curso             = line.Substring ( pos, 30 ); pos += 30;
					
					if ( cpf_resp.Trim().Length < 4 )
					{
						Trace ( "CPF inválido" );	
						continue;
					}
					
					if ( nome_resp.Trim().Length == 0 )
					{
						Trace ( "Nome Resp. inválido" );	
						continue;
					}
					
					if ( nome_aluno.Trim().Length == 0 )
					{
						Trace ( "Nome Resp. inválido" );	
						continue;
					}
					
					string senha = cpf_resp.Substring ( 0, 4 );
					
					bool createProt = false;
					
					T_Proprietario prot = new T_Proprietario (this);
					
					if ( !prot.select_rows_cpf ( cpf_resp ) )
					{
						createProt = true;
					}
					else
					{
						prot.fetch();
					}
					
					prot.set_st_nome 		( nome_resp 							);
					prot.set_st_cpf			( cpf_resp								);
					prot.set_st_endereco 	( end 									);
					prot.set_st_bairro      ( bairro    							);
					prot.set_st_cep         ( cep       							);
					prot.set_st_cidade      ( cidade    							);
					prot.set_st_ddd         ( tel.Substring ( 0, 2 	)			  	);
					prot.set_st_telefone    ( tel.Substring ( 2, tel.Length - 2 ) 	);
					prot.set_st_email		( email_resp 							);
					
					if ( createProt )
					{
						prot.set_st_senhaEdu    ( var_util.DESCript ( senha.PadLeft ( 8, '*'), "12345678" )	);
					
						prot.create_T_Proprietario();
					}
					else
					{
						prot.synchronize_T_Proprietario();
					}			
					
					T_InfoAdicionais info = new T_InfoAdicionais (this);
					T_Cartao 		 cart = new T_Cartao (this);
					
					if ( !createProt )
					{
						cart.select_rows_edu_nome_prop ( nome_aluno, prot.get_identity(), TipoCartao.educacional );
						cart.fetch();
							
						info.selectIdentity ( cart.get_fk_infoAdicionais() );						
					}
					
					int year  = Convert.ToInt32 ( dt_nasc_aluno.Substring ( 4,4 ) );
					int month = Convert.ToInt32 ( dt_nasc_aluno.Substring ( 2,2 ) );
					int day   = Convert.ToInt32 ( dt_nasc_aluno.Substring ( 0,2 ) );
					
					dt_nasc_aluno = GetDataBaseTime ( new DateTime ( year, month, day ) );
					
					info.set_dt_edu_nasc      		( dt_nasc_aluno		 );
					info.set_st_edu_sexo      		( sexo 				 );
					info.set_st_edu_grau     	 	( grau 				 );
					info.set_st_edu_serie_semestre  ( serie_semestre 	 );
					info.set_st_edu_turma     		( turma 			 );
					info.set_st_edu_curso     		( curso 			 );
					info.set_dt_edu_atualizacao		( dt_atual 			 );
					
					if ( !createProt )
					{
						info.synchronize_T_InfoAdicionais();
					}
					else
					{
						info.create_T_InfoAdicionais();
						
						cart.Reset();
												
						T_Cartao cart_mat = new T_Cartao (this);
							
						if ( !cart_mat.select_rows_empresa ( "003522" ) )
						{
							cart.set_st_matricula ( "000001" );
						}
						else
						{
							cart.set_st_matricula ( ( cart_mat.GetMax ( TB_T_CARTAO.st_matricula ) + 1 ).ToString().PadLeft ( 6, '0' ) );
						}

						cart.set_fk_dadosProprietario 	( prot.get_identity() 			);
						cart.set_fk_infoAdicionais    	( info.get_identity() 			);
						cart.set_st_empresa   	 		( "003522"						);
						cart.set_st_titularidade 		( "01" 							);
						cart.set_st_senha	 	 		( Context.EMPTY 				);
						cart.set_st_aluno 		 		( nome_aluno					);
						cart.set_tg_tipoCartao   		( TipoCartao.educacional 		);
						cart.set_tg_status 		 		( CartaoStatus.Habilitado 		);
						cart.set_dt_inclusao 			( GetDataBaseTime() 			);
						cart.set_tg_emitido				( StatusExpedicao.NaoExpedido 	);
						cart.set_vr_edu_disp_virtual    ( 1000000 						);
						
						cart.create_T_Cartao();
						
						LINK_ProprietarioCartao prop_cart = new LINK_ProprietarioCartao (this);
				
						prop_cart.set_fk_cartao 		( cart.get_identity() );
						prop_cart.set_fk_proprietario 	( prot.get_identity() );
	
						prop_cart.create_LINK_ProprietarioCartao();
					}
				}
			}
			catch ( System.Exception ex )
			{
				Registry ( ex.ToString() );
				reader.Close();	
				
				return false;
			}
			
			reader.Close();
			
			/// USER [ execute ] END
		
			Registry ( "execute done load_edu " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish load_edu " ); 
		
			/// USER [ finish ]
			
			T_Cartao 			cart 	 = new T_Cartao (this);
			T_Cartao 			cart_upd = new T_Cartao (this);
			T_InfoAdicionais 	info 	 = new T_InfoAdicionais (this);
			
			if ( cart.select_rows_empresa ( escola ) )
			{
				while ( cart.fetch() )
				{
					if ( info.selectIdentity ( cart.get_fk_infoAdicionais() ) )
					{
						if ( info.get_dt_edu_atualizacao() != dt_atual )
						{
							cart_upd.ExclusiveAccess();
							
							if ( cart_upd.selectIdentity ( cart.get_identity() ) )
							{
								cart_upd.set_tg_status ( CartaoStatus.EmDesativacao );
								
								cart_upd.synchronize_T_Cartao();
								cart_upd.ReleaseExclusive();
							}
						}
					}
				}
			}		
			
			/// USER [ finish ] END
		
			Registry ( "finish done load_edu " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
