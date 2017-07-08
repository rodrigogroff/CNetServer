using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class ins_cartaoProprietario : type_base
	{
		public string input_st_csv_deps = "";
		
		public DadosCartao input_cont_dc = new DadosCartao();
		public DadosProprietario input_cont_dp = new DadosProprietario();
		public DadosAdicionais input_cont_da = new DadosAdicionais();
		
		/// USER [ var_decl ]
		
		T_Cartao cart;
		T_Proprietario prot;
		
		/// USER [ var_decl ] END
		
		public ins_cartaoProprietario ( Transaction trans ) : base (trans)
		{
			var_Alias = "ins_cartaoProprietario";
			constructor();
		}
		
		public ins_cartaoProprietario()
		{
			var_Alias = "ins_cartaoProprietario";
		
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
			Registry ( "setup ins_cartaoProprietario " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_CARTAOPROPRIETARIO.st_csv_deps, ref input_st_csv_deps ) == false ) 
			{
				Trace ( "# COMM_IN_INS_CARTAOPROPRIETARIO.st_csv_deps missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			DataPortable ct_2 = new DataPortable();
			DataPortable ct_3 = new DataPortable();
			DataPortable ct_4 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_INS_CARTAOPROPRIETARIO.dc, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_INS_CARTAOPROPRIETARIO.dc missing! " ); 
				return false;
			}
			if ( var_Comm.GetEntryPortableAtPosition(2).GetMapContainer ( COMM_IN_INS_CARTAOPROPRIETARIO.dp, ref ct_2 ) == false )
			{
				Trace ( "# COMM_IN_INS_CARTAOPROPRIETARIO.dp missing! " ); 
				return false;
			}
			if ( var_Comm.GetEntryPortableAtPosition(3).GetMapContainer ( COMM_IN_INS_CARTAOPROPRIETARIO.da, ref ct_3 ) == false )
			{
				Trace ( "# COMM_IN_INS_CARTAOPROPRIETARIO.da missing! " ); 
				return false;
			}
			if ( var_Comm.GetEntryPortableAtPosition(4).GetMapContainer ( COMM_IN_INS_CARTAOPROPRIETARIO.header, ref ct_4 ) == false )
			{
				Trace ( "# COMM_IN_INS_CARTAOPROPRIETARIO.header missing! " ); 
				return false;
			}
			
			input_cont_dc.Import ( ct_1 );
			input_cont_dp.Import ( ct_2 );
			input_cont_da.Import ( ct_3 );
			input_cont_header.Import ( ct_4 );
			
			Registry ( "setup done ins_cartaoProprietario " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate ins_cartaoProprietario " ); 
		
			/// USER [ authenticate ]
			
			cart = new T_Cartao (this);
			prot = new T_Proprietario (this);
			
			string empresa   = input_cont_dc.get_st_empresa().PadLeft   ( 6, '0' );
			string matricula = input_cont_dc.get_st_matricula().PadLeft ( 6, '0' );
			
			if ( input_cont_dc.get_tg_tipoCartao()	!= TipoCartao.presente )
			{
				if ( cart.select_rows_empresa_matricula ( empresa, matricula ) )
				{
					PublishError ( Erro.CartaoExiste );
					return false;
				}
			}
			else
			{
				if ( !cart.select_rows_empresa_matricula ( empresa, matricula ) )
				{
					PublishError ( "Cartão inexistente" );
					return false;
				}
				
				if ( !cart.fetch() )
					return false;
				
				if ( cart.get_tg_emitido() != StatusExpedicao.Expedido )
				{
					PublishError ( "Cartão não expedido" );
					return false;
				}
				
				if ( cart.get_fk_dadosProprietario() != Context.NONE )
				{
					PublishError ( "Cartão previamente adquirido" );
					return false;
				}
			}
						
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done ins_cartaoProprietario " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute ins_cartaoProprietario " ); 
		
			/// USER [ execute ]
								
			bool update_Proprietario = false;
			
			int titularidade = 1;
			
			prot.ExclusiveAccess();
			
			if ( prot.select_rows_cpf ( input_cont_dp.get_st_cpf() ) )
			{
				if ( !prot.fetch() )
				{
					PublishError ( Erro.NovoCartao );
					return false;
				}
				
				update_Proprietario = true;
				
				// confere se tem mais de um cartão nesta empresa
				
				T_Cartao tmp_cart = new T_Cartao ( this );
				
				if ( tmp_cart.select_rows_emp_prop ( input_cont_dc.get_st_empresa().PadLeft ( 6, '0' ), prot.get_identity() ) )
				{
					if ( tmp_cart.RowCount() > 0 )
					{
						prot.ReleaseExclusive();
						
						PublishError ( "CPF já cadastrrado para outro cartão nesta empresa (" +  input_cont_dc.get_st_empresa().PadLeft ( 6, '0' ) + ")" );
						return false;
					}
				}
			}
			
			prot.set_st_cpf			( input_cont_dp.get_st_cpf()				);
			prot.set_st_nome 		( input_cont_dp.get_st_nome().ToUpper()	 	);
			prot.set_st_endereco 	( input_cont_dp.get_st_endereco() 			);
			prot.set_st_numero 		( input_cont_dp.get_st_numero() 			);
			prot.set_st_complemento ( input_cont_dp.get_st_complemento() 		);
			prot.set_st_bairro 		( input_cont_dp.get_st_bairro() 			);
			prot.set_st_cidade 		( input_cont_dp.get_st_cidade().ToUpper()	);
			prot.set_st_UF 			( input_cont_dp.get_st_UF() 				);
			prot.set_st_cep 		( input_cont_dp.get_st_CEP() 				);
			prot.set_st_ddd 		( input_cont_dp.get_st_ddd() 				);
			prot.set_st_telefone 	( input_cont_dp.get_st_telefone()	 		);
			prot.set_dt_nasc 		( input_cont_dp.get_dt_nasc() 				);
			prot.set_st_email 		( input_cont_dp.get_st_email() 				);
			prot.set_vr_renda 		( input_cont_dp.get_vr_renda() 				);
			prot.set_st_senhaEdu	( input_cont_da.get_st_senha_resp()			);
			
			if ( update_Proprietario )
			{
				if ( !prot.synchronize_T_Proprietario() )
				{
					PublishError ( Erro.NovoCartao );
					return false;
				}
			}
			else
			{
				if ( !prot.create_T_Proprietario() )
				{
					PublishError ( Erro.NovoCartao );
					return false;
				}
			}
		
			prot.ReleaseExclusive();			
		
			T_InfoAdicionais add_info = new T_InfoAdicionais (this);
			
			add_info.set_st_codigo	 		( Context.NOT_SET 						);
			add_info.set_st_empresaAfiliada ( input_cont_da.get_st_empresa() 		);
			add_info.set_st_presenteado 	( input_cont_da.get_st_presenteado()	);
			add_info.set_st_recado 			( input_cont_da.get_st_recado()			);
						
			if ( !add_info.create_T_InfoAdicionais() )
			{
				PublishError ( Erro.NovoCartao );
				return false;
			}
		
			if ( input_cont_dc.get_tg_tipoCartao()	== TipoCartao.presente )
			{
				cart.set_fk_dadosProprietario 	( prot.get_identity() 					);
				cart.set_fk_infoAdicionais 		( add_info.get_identity() 				);
				cart.set_tg_status 				( CartaoStatus.Habilitado				);
				cart.set_vr_limiteTotal 		( input_cont_dc.get_vr_dispTotal() 		);
				cart.set_tg_tipoCartao			( TipoCartao.presente 					);
				
				cart.set_st_senha ( var_util.DESCript ( "9999".PadLeft ( 8, '*'), "12345678" ) );
					
				if ( !cart.synchronize_T_Cartao() )
					return false;	
			}
			else
			{
				cart.Reset();
				
				cart.set_st_empresa 			( input_cont_dc.get_st_empresa().PadLeft ( 6, '0' ) 	);
				cart.set_st_matricula 			( input_cont_dc.get_st_matricula().PadLeft ( 6, '0' ) 	);
				cart.set_st_titularidade 		( titularidade.ToString().PadLeft ( 2, '0' )			);
				cart.set_st_senha 				( input_cont_dc.get_st_senha() 							);
				cart.set_tg_tipoCartao 			( input_cont_dc.get_tg_tipoCartao()						);
				cart.set_st_venctoCartao		( input_cont_dc.get_st_vencimento()						);
				cart.set_tg_status 				( CartaoStatus.Habilitado 								);
				cart.set_dt_utlPagto 			( GetDataBaseTime() 									);
				cart.set_nu_senhaErrada 		( Context.NONE 											);
				cart.set_dt_inclusao 			( GetDataBaseTime() 									);
				cart.set_dt_bloqueio 			( GetDataBaseTime()	 									);
				cart.set_tg_motivoBloqueio 		( CartaoMotivoBloqueio.Expirado 						);
				cart.set_st_banco 				( input_cont_dc.get_st_banco() 							);
				cart.set_st_agencia 			( input_cont_dc.get_st_agencia() 						);
				cart.set_st_conta 				( input_cont_dc.get_st_conta()						 	);
				cart.set_st_matriculaExtra 		( Context.FALSE 										);
				cart.set_st_celCartao 			( input_cont_dc.get_st_celCartao() 						);
				cart.set_fk_dadosProprietario 	( prot.get_identity() 									);
				cart.set_fk_infoAdicionais 		( add_info.get_identity() 								);
				
				cart.set_nu_viaCartao 			( "1" );
				
				cart.set_vr_limiteTotal 		( input_cont_dc.get_vr_limiteTotal() 					);
				cart.set_vr_limiteMensal 		( input_cont_dc.get_vr_limiteMensal() 					);
				cart.set_vr_limiteRotativo 		( input_cont_dc.get_vr_limiteRotativo() 				);
				cart.set_vr_extraCota 			( input_cont_dc.get_vr_extraCota() 						);
				
				cart.set_st_aluno 				( input_cont_da.get_st_nome_aluno() 					);
				
				cart.set_vr_educacional			( "0" );
				cart.set_vr_disp_educacional	( "0" );
				cart.set_vr_edu_diario 			( "0" );
				
				if ( input_cont_dc.get_tg_tipoCartao()	== TipoCartao.presente )
				{
					// necessita de confirmação de produtos 
					cart.set_tg_status ( CartaoStatus.Bloqueado );
				}
					
				if ( !cart.create_T_Cartao() )
				{
					PublishError ( Erro.NovoCartao );
					return false;
				}
			}
				
			LINK_ProprietarioCartao prop_cart = new LINK_ProprietarioCartao (this);
			
			prop_cart.set_fk_cartao 		( cart.get_identity() );
			prop_cart.set_fk_proprietario 	( prot.get_identity() );
			
			if ( !prop_cart.create_LINK_ProprietarioCartao () )
			{
				PublishError ( Erro.NovoCartao );
				return false;
			}
								
			for ( int t=0; t < var_util.indexCSV ( input_st_csv_deps, '|' ); ++t )
			{
				T_Cartao cart_dep = new T_Cartao (this);
				
				cart_dep.copy ( ref cart );
				
				cart_dep.set_st_titularidade ( (++titularidade).ToString().PadLeft ( 2, '0' ) );
												
				if ( !cart_dep.create_T_Cartao() )
				{
					PublishError ( Erro.NovoCartao );
					return false;
				}
				
				T_Dependente dep = new T_Dependente (this);
				
				dep.set_nu_titularidade ( cart_dep.get_st_titularidade() 	);
				dep.set_st_nome 		( var_util.getCSV ( t ) 			);
				dep.set_fk_proprietario ( prot.get_identity() 				);

				if ( !dep.create_T_Dependente () )
				{
					PublishError ( Erro.NovoCartao );
					return false;
				}
			}
			
			PublishNote ( "Cartão criado com sucesso" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done ins_cartaoProprietario " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish ins_cartaoProprietario " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao		( TipoOperacao.CadCartao 				);
				aud.set_fk_usuario		( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao 	( GetDataBaseTime() 					);
				aud.set_st_observacao 	( prot.get_st_cpf() 					);
				aud.set_fk_generic  	( cart.get_identity() 					);
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done ins_cartaoProprietario " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
