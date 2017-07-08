using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_alteraLoja : type_base
	{
		public string input_st_csv_empresas = "";
		public string input_st_csv_taxas = "";
		public string input_st_csv_dias = "";
		public string input_st_csv_banco = "";
		public string input_st_csv_ag = "";
		public string input_st_csv_conta = "";
		
		public DadosLoja input_cont_dl = new DadosLoja();
		
		/// USER [ var_decl ]
		
		T_Loja loj;
		
		/// USER [ var_decl ] END
		
		public exec_alteraLoja ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_alteraLoja";
			constructor();
		}
		
		public exec_alteraLoja()
		{
			var_Alias = "exec_alteraLoja";
		
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
			Registry ( "setup exec_alteraLoja " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_ALTERALOJA.st_csv_empresas, ref input_st_csv_empresas ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_ALTERALOJA.st_csv_empresas missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_ALTERALOJA.st_csv_taxas, ref input_st_csv_taxas ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_ALTERALOJA.st_csv_taxas missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_ALTERALOJA.st_csv_dias, ref input_st_csv_dias ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_ALTERALOJA.st_csv_dias missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_ALTERALOJA.st_csv_banco, ref input_st_csv_banco ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_ALTERALOJA.st_csv_banco missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_ALTERALOJA.st_csv_ag, ref input_st_csv_ag ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_ALTERALOJA.st_csv_ag missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_ALTERALOJA.st_csv_conta, ref input_st_csv_conta ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_ALTERALOJA.st_csv_conta missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			DataPortable ct_2 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_ALTERALOJA.dl, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_ALTERALOJA.dl missing! " ); 
				return false;
			}
			if ( var_Comm.GetEntryPortableAtPosition(2).GetMapContainer ( COMM_IN_EXEC_ALTERALOJA.header, ref ct_2 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_ALTERALOJA.header missing! " ); 
				return false;
			}
			
			input_cont_dl.Import ( ct_1 );
			input_cont_header.Import ( ct_2 );
			
			Registry ( "setup done exec_alteraLoja " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_alteraLoja " ); 
		
			/// USER [ authenticate ]
			
			loj = new T_Loja (this);
			
			// ## Busca loja em questão por um CNPJ
			
			if ( !loj.select_rows_cnpj ( input_cont_dl.get_nu_CNPJ() ) )
			{
				if ( !loj.select_rows_loja ( input_cont_dl.get_st_loja() ) )
				{
					PublishError ( "Loja não disponível" );
					return false;
				}
			}
			
			if ( !loj.fetch() )
				return false;
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_alteraLoja " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_alteraLoja " ); 
		
			/// USER [ execute ]
			
			
			// ## Se container estiver preenchido, alterar dados
			// ## cadastrais da loja
			
			if ( input_cont_dl.get_st_nome() != "" )
			{
				loj.set_nu_CNPJ 		( input_cont_dl.get_nu_CNPJ() 			);
				loj.set_st_nome 		( input_cont_dl.get_st_nome() 			);
				loj.set_st_social 		( input_cont_dl.get_st_social() 		);
				loj.set_st_endereco 	( input_cont_dl.get_st_endereco() 		);
				loj.set_st_enderecoInst ( input_cont_dl.get_st_enderecoInst() 	);
				loj.set_nu_inscEst 		( input_cont_dl.get_nu_inscEst() 		);
				
				loj.set_st_cidade 		( input_cont_dl.get_st_cidade() 		);
				loj.set_st_estado 		( input_cont_dl.get_st_estado()  		);
				loj.set_nu_CEP 			( input_cont_dl.get_nu_CEP() 			);
				loj.set_nu_telefone 	( input_cont_dl.get_nu_telefone()  		);
				loj.set_nu_fax 			( input_cont_dl.get_nu_fax() 			);
				loj.set_st_contato 		( input_cont_dl.get_st_contato() 		);
				loj.set_vr_mensalidade 	( input_cont_dl.get_vr_mensalidade() 	);
				loj.set_nu_contaDeb 	( input_cont_dl.get_nu_contaDeb() 		);
				loj.set_st_obs 			( input_cont_dl.get_st_obs() 			);
				
				loj.set_vr_mensalidade  ( input_cont_dl.get_vr_mensalidade()	);
				loj.set_nu_pctValor     ( input_cont_dl.get_nu_pctValor()		);
				loj.set_vr_transacao	( input_cont_dl.get_vr_transacao()		);
				loj.set_vr_minimo		( input_cont_dl.get_vr_minimo() 		);
				loj.set_nu_franquia		( input_cont_dl.get_nu_franquia()		);
				loj.set_nu_periodoFat	( input_cont_dl.get_nu_periodoFat()		);
				loj.set_nu_diavenc		( input_cont_dl.get_nu_diavenc()		);
				loj.set_tg_tipoCobranca ( input_cont_dl.get_tg_tipoCobranca()	);
				loj.set_nu_bancoFat		( input_cont_dl.get_nu_bancoFat()		);
				loj.set_tg_isentoFat	( input_cont_dl.get_tg_isento()			);
				loj.set_st_senha		( input_cont_dl.get_st_senhaWeb() 		);
			
				if ( !loj.synchronize_T_Loja() )
					return false;
			}
			
			// ## Alteração de convênios
			
			Hashtable hshEmps = new Hashtable();
			ArrayList lstEmps = new ArrayList();
			
			if ( input_st_csv_empresas.Length > 0 )
			{
				LINK_LojaEmpresa loj_emp = new LINK_LojaEmpresa (this);
				
				// ## buscar e limpar todos os registros de convênio
				
				T_Empresa  emp 	= new T_Empresa (this);
				
				if ( loj_emp.select_fk_loja ( loj.get_identity() ) )
				{
					while ( loj_emp.fetch() )
					{
						hshEmps [ loj_emp.get_fk_empresa() ] = "0";
						
						lstEmps.Add ( loj_emp.get_fk_empresa() );
						
						if ( !loj_emp.delete() )
							return false;
					}
				}
								
				ApplicationUtil util_taxa    = new ApplicationUtil();
				ApplicationUtil util_repasse = new ApplicationUtil();
				ApplicationUtil util_banco   = new ApplicationUtil();
				ApplicationUtil util_ag      = new ApplicationUtil();
				ApplicationUtil util_conta   = new ApplicationUtil();
				
				// ## Indexa as taxas
				
				util_taxa.indexCSV    	( input_st_csv_taxas );
				util_repasse.indexCSV 	( input_st_csv_dias  );
				
				util_banco.indexCSV 	( input_st_csv_banco );
				util_ag.indexCSV 		( input_st_csv_ag  	 );
				util_conta.indexCSV 	( input_st_csv_conta );
				
				// ## Percorre todas as empresas vinculadas
				
				for ( int t=0; t < var_util.indexCSV ( input_st_csv_empresas ); ++t )
				{
					string empresa = var_util.getCSV ( t );
					
					if ( !emp.select_rows_empresa ( empresa ) )
						return false;
					
					if ( !emp.fetch() )
						return false;
					
					// ## Cria o relacionamento
					
					loj_emp.set_fk_empresa 		( emp.get_identity() 		);
					loj_emp.set_fk_loja    		( loj.get_identity() 		);
					
					loj_emp.set_tx_admin   		( util_taxa.getCSV (t) 		);
					loj_emp.set_nu_dias_repasse ( util_repasse.getCSV (t) 	);
					loj_emp.set_st_banco 		( util_banco.getCSV (t) 	);
					loj_emp.set_st_ag 			( util_ag.getCSV (t) 		);
					loj_emp.set_st_conta 		( util_conta.getCSV (t) 	);
										
					if ( !loj_emp.create_LINK_LojaEmpresa () )
						return false;
				
					if ( hshEmps [ emp.get_identity() ] != null )
					{
						hshEmps [ emp.get_identity() ] = "1";
					}					
				}
				
				for ( int t=0; t < lstEmps.Count; ++t )
				{
					string tag = lstEmps[t].ToString();
					
					if (  hshEmps [ tag ] != null )
					{
						if ( hshEmps [ tag ].ToString() == "0" )
						{
							// foi removido
							
							emp.selectIdentity ( tag );
							
							LOG_Audit aud = new LOG_Audit (this);
				
							aud.set_tg_operacao		( TipoOperacao.RemoveConvenio			);
							aud.set_fk_usuario		( input_cont_header.get_st_user_id() 	);
							aud.set_dt_operacao 	( GetDataBaseTime() 					);
							aud.set_st_observacao 	( emp.get_st_fantasia()  				);
							aud.set_fk_generic  	( loj.get_identity() 					);
							
							if ( !aud.create_LOG_Audit() )
								return false;
						}
					}
				}
				
				PublishNote ( "Convênios atualizados para loja " + input_cont_dl.get_nu_CNPJ() );
			}
			else
			{
				PublishNote ( "Cadastro atualizado para loja " + input_cont_dl.get_nu_CNPJ() );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_alteraLoja " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_alteraLoja " ); 
		
			/// USER [ finish ]
			
			// ## Grava registro de auditoria
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao		( TipoOperacao.AlterLoja				);
				aud.set_fk_usuario		( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao 	( GetDataBaseTime() 					);
				aud.set_st_observacao 	( loj.get_nu_CNPJ() 					);
				aud.set_fk_generic  	( loj.get_identity() 					);
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_alteraLoja " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
