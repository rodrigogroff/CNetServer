using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class load_legado : type_load
	{
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public load_legado ( Transaction trans ) : base (trans)
		{
			var_Alias = "load_legado";
			constructor();
		}
		
		public load_legado()
		{
			var_Alias = "load_legado";
		
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
			Registry ( "setup load_legado " ); 
		
			Registry ( "setup done load_legado " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate load_legado " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done load_legado " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute load_legado " ); 
		
			/// USER [ execute ]
			
			/*
			T_Empresa 			emp 		= new T_Empresa 		(this);
			T_Loja 				loj 		= new T_Loja 			(this);
			T_Terminal 			term 		= new T_Terminal 		(this);
			LINK_LojaEmpresa 	lnk_lojEmp	= new LINK_LojaEmpresa 	(this);
			T_Proprietario 		prot 		= new T_Proprietario 	(this);
			T_Dependente 		dep 		= new T_Dependente 		(this);
			T_InfoAdicionais	info        = new T_InfoAdicionais  (this);
			T_Cartao 			cart 		= new T_Cartao 			(this);	
			
			ApplicationUtil 	var_util 	= new ApplicationUtil();
			StreamReader 		reader 	 	= new StreamReader ( archive );
			
			ArrayList 			rows_log_transacoes = new ArrayList();
			Hashtable 			hsh_log_transacoes  = new Hashtable();
				
			try
			{
				while ( !reader.EndOfStream )
				{
					System.Threading.Thread.Sleep (1);
					
					string line = reader.ReadLine();
					
					if ( line.StartsWith ( "#" ) )
					{
						string table = line.Replace ( "#","" );
						
						Trace ( "New table: " + table );
						
						ArrayList rows = new ArrayList ();
						
						long tmp_count = 0;
						
						while ( !reader.EndOfStream )		
						{
							line = reader.ReadLine().Trim();
							
							if ( line == "" ) break;
							
							DataPortable dp_row = new DataPortable();
							
							#region - read row -
							
							int max = var_util.indexCSV ( line ) - 1;
							
							for ( int t=0; t < max; )
							{
								string tag = var_util.getCSV ( t++ );
								string val = var_util.getCSV ( t++ ).Trim().Replace ( "{SE02}","," );
							
								dp_row.setValue ( tag, val );
							}
							
							rows.Add ( dp_row );
							
							#endregion
							
							if ( ++tmp_count % 100 == 0 )
							{
								Registry ( "Leu " + tmp_count.ToString() );
							}
						}		
						
						Trace ( rows.Count.ToString() );
						
						switch ( table )
						{
							case "senhasWeb":
							{
								for ( int t=0; t < rows.Count; ++t )
								{
									DataPortable dp = rows[t] as DataPortable;
								
									loj.ExclusiveAccess();
									
									if ( !loj.select_rows_cnpj ( dp.getValue ( "cnpj" ) ) )
										continue;
									
									loj.synchronize_T_Loja();
									loj.ReleaseExclusive();									
								}
									
								rows.Clear();
								break;
							}
								
							case "empresa":
							{
								#region - empresa -
							
								for ( int t=0; t < rows.Count; ++t )
								{
									DataPortable dp = rows[t] as DataPortable;
								
									if ( emp.select_rows_empresa ( dp.getValue ( "codigo" ) ) )
										continue;
									
									emp.set_st_empresa 		( dp.getValue ( "codigo" ) 												);
									emp.set_nu_CNPJ 		( dp.getValue ( "cgc" ) 												);
									emp.set_st_fantasia 	( dp.getValue ( "Fantasia" ) 											);
									emp.set_st_social 		( dp.getValue ( "Razao_social" ) 										);
									emp.set_st_endereco 	( dp.getValue ( "endereco" ) 											);
									emp.set_st_cidade 		( var_util.CleanUpperPonctuation ( dp.getValue ( "cidade" ) )			);
									emp.set_st_estado 		( dp.getValue ( "estado" ).ToUpper()									);
									emp.set_nu_CEP 			( dp.getValue ( "cep" ).Replace ( "-","" ) 								);
									emp.set_nu_telefone 	( dp.getValue ( "telefone" ).Replace ( "-","" ) 						);
									emp.set_nu_cartoes 		( dp.getValue ( "nro_cartoes" ).PadLeft ( 1, '0' ) 						);	// ??? manter legado?
									emp.set_nu_parcelas 	( dp.getValue ( "maximo_parcelas" ).PadLeft ( 1, '0' ) 					);
									emp.set_vr_mensalidade 	( dp.getValue ( "taxa" ).Replace ( ",","" ).PadLeft ( 1, '0' ) 			);
									
									emp.set_tg_blocked 		( Context.FALSE 														);
									emp.set_tg_tipoCobranca ( TipoCobranca.Doc														);
									emp.set_fk_admin   		( Context.NONE 															);
									
									emp.create_T_Empresa();				
								}
								
								#endregion
								
								rows.Clear();
								break;
							}
								
							case "loja":
							{
								#region - loja - 
											
								for ( int t=0; t < rows.Count; ++t )
								{
									DataPortable dp = rows[t] as DataPortable;
									
									if ( loj.select_rows_loja ( dp.getValue ( "codigo" ) ) )
										continue;
									
									loj.Reset();
									
									loj.set_st_loja			( dp.getValue ( "codigo" ) 	);	
									loj.set_nu_CNPJ 		( dp.getValue ( "cgc" ) 			);
									loj.set_st_nome 		( dp.getValue ( "nome" ) 			);
									loj.set_st_social 		( dp.getValue ( "razao_social" ) 	);
									
									string end = dp.getValue ( "endereco" ).ToUpper();
									
									end = end.PadRight ( 900, ' ' ).Substring ( 0, 900 );
									
									loj.set_st_endereco 	( dp.getValue ( "endereco" ).ToUpper() 	);
									loj.set_st_enderecoInst ( dp.getValue ( "endereco_inst" ).ToUpper() 	);
									loj.set_nu_inscEst 		( dp.getValue ( "inscr_est" ).Replace ( "-","" ) 	);	
									
									loj.set_st_cidade 		( var_util.CleanUpperPonctuation ( dp.getValue ( "cidade" ) ) 	);
									loj.set_st_estado 		( dp.getValue ( "estado" ).ToUpper() 	);
									loj.set_nu_CEP 			( dp.getValue ( "cep" ) 	);
									
									string tel = dp.getValue ( "telefone" )
													.Replace ( "(", "" )
													.Replace ( ")", "" )
													.Replace ( "-", "" );
									
									tel = tel.Trim().PadLeft ( 10, '0' ).Substring ( 0,10 );
									
									loj.set_nu_telefone		( tel );
									
									string fax = dp.getValue ( "fax" )
													.Replace ( "(", "" )
													.Replace ( ")", "" )
													.Replace ( "-", "" );
									
									fax = fax.Trim().PadLeft ( 10, '0' ).Substring ( 0,10 );
									
									loj.set_nu_fax			( fax							);
									loj.set_st_contato		( dp.getValue ( "contato" ) 	);
									loj.set_vr_mensalidade	( dp.getValue ( "mensalidade" ).Replace ( ",","" ).PadLeft (1,'0') 	);
									loj.set_st_obs			( dp.getValue ( "observ" ) 	);						
									loj.set_tg_tipoCobranca ( TipoCobranca.Doc	);
									
									loj.create_T_Loja();					
								}
								
								rows.Clear();
								
								#endregion	
								
								rows.Clear();
								break;
							}
						
							case "terminal":
							{
								#region - terminal -
				
								for ( int t=0; t < rows.Count; ++t )
								{
									DataPortable dp = rows[t] as DataPortable;
									
									if ( term.select_rows_terminal ( dp.getValue ( "nro_terminal" ) ) )
										continue;
									
									term.set_nu_terminal    ( dp.getValue ( "nro_terminal" ) );
									term.set_st_localizacao ( dp.getValue ( "localizacao" )  );
									
									loj.select_rows_loja ( dp.getValue ( "codigo_loja" ) );
									loj.fetch();
									
									term.set_fk_loja ( loj.get_identity() );
									
									term.create_T_Terminal();		
								}
								
								#endregion	
								
								rows.Clear();
								break;
							}
								
							case "convenio":
							{
								#region - link entre loja e empresa (convenio) -
							
								for ( int t=0; t < rows.Count; ++t )
								{
									DataPortable dp = rows[t] as DataPortable;
									
									loj.select_rows_loja ( dp.getValue ( "cod_loja" ) );
									loj.fetch();
									
									emp.select_rows_empresa ( dp.getValue ( "cod_empresa" ) );
									emp.fetch();
									
									if ( lnk_lojEmp.select_fk_empresa_loja ( emp.get_identity(), 
									                                         loj.get_identity() ) )
										continue;
														
									lnk_lojEmp.set_fk_loja 			( loj.get_identity() 	);
									lnk_lojEmp.set_fk_empresa 		( emp.get_identity() 	);
									lnk_lojEmp.set_tx_admin 		( Context.NOT_SET 		);
									lnk_lojEmp.set_nu_dias_repasse 	( Context.NOT_SET 		);
									
									lnk_lojEmp.create_LINK_LojaEmpresa();
								}
							
								#endregion	
								
								rows.Clear();
								break;
							}	
								
							case "proprietario":
							{
								#region - proprietario - 
				
								for ( int t=0; t < rows.Count; ++t )
								{
									DataPortable dp = rows[t] as DataPortable;
									
									if ( prot.select_rows_cpf ( dp.getValue ( "cpf" ).Trim() ) )
										continue;
									
									prot.set_st_cpf 		( dp.getValue ( "cpf" ).Trim() 						);
									prot.set_st_nome 		( dp.getValue ( "nome" ).ToUpper().Trim() 			);
														
									string end = dp.getValue ( "endereco" ).ToUpper().Trim();
									
									prot.set_st_endereco 	( end );				
									
									prot.set_st_numero 		( dp.getValue ( "numero" ).Trim().PadLeft (1,'0' )		);
									prot.set_st_complemento	( dp.getValue ( "complemento" ).Trim().PadLeft (1,'0')	);
									prot.set_st_bairro 		( var_util.CleanUpperPonctuation ( dp.getValue ( "bairro" ) ).Trim() );
									prot.set_st_cidade 		( var_util.CleanUpperPonctuation ( dp.getValue ( "cidade" ) ).Trim() );
									prot.set_st_UF 			( dp.getValue ( "estado" ).ToUpper().Trim()			);
									prot.set_st_cep 		( dp.getValue ( "cep" ).Trim()							);
									prot.set_st_ddd 		( dp.getValue ( "ddd" ).Trim()							);
									
									string tel = dp.getValue ( "telefone" )
													.Replace ( "(", "" )
													.Replace ( ")", "" )
													.Replace ( @"\", "" )
													.Replace ( "-", "" );
									
									tel = tel.Trim().PadLeft ( 10, '0' ).Substring ( 0,10 );
									
									prot.set_st_telefone ( tel );
									
									string dt_nasc = dp.getValue ( "data_nasc" );
									
									DateTime tim = new DateTime ( 	Convert.ToInt32 ( dt_nasc.Substring (6,4) ),
																	Convert.ToInt32 ( dt_nasc.Substring (3,2) ),
									                                Convert.ToInt32 ( dt_nasc.Substring (0,2) ) );
																	
									prot.set_dt_nasc 		( GetDataBaseTime ( tim ) 											);
									prot.set_st_email 		( dp.getValue ( "email"		).Trim()										);
									prot.set_vr_renda 		( dp.getValue ( "renda" 	).Replace ( ",","" ).PadLeft (1,'0')	);
									prot.set_st_senhaEdu 	( Context.EMPTY														);
									
									prot.create_T_Proprietario();
								}
								
								#endregion
								
								rows.Clear();
								break;
							}
								
							case "dependente":
							{
								#region - dependente - 
						
								for ( int t=0; t < rows.Count; ++t )
								{
									DataPortable dp = rows[t] as DataPortable;
									
									prot.select_rows_cpf ( dp.getValue ( "cpf_prop" ) );
									prot.fetch();
									
									if ( dep.select_rows_prop_tit ( prot.get_identity(), 
									                                dp.getValue ( "titularidade" ) ) )
										continue;
									
									dep.set_nu_titularidade ( dp.getValue ( "titularidade" ) 	);
									dep.set_st_nome 		( dp.getValue ( "nome" ) 			);
									dep.set_fk_proprietario ( prot.get_identity() );
						
									dep.create_T_Dependente();
								}
								
								#endregion
								
								rows.Clear();
								break;
							}
								
							case "cartao_infad":
							{
								#region - informações adicionais - 
						
								for ( int t=0; t < rows.Count; ++t )
								{
									DataPortable dp = rows[t] as DataPortable;
											
									if ( info.select_rows_emp_mat ( dp.getValue ( "cod_empresa" ), 
									                                dp.getValue ( "matricula" ) ) )
									{
										continue;
									}
									
									info.set_st_empresa 			( dp.getValue ( "cod_empresa" ) );
									info.set_st_matricula	 		( dp.getValue ( "matricula" ) );
									info.set_st_codigo 				( dp.getValue ( "codigo" ) );
									info.set_st_empresaAfiliada 	( dp.getValue ( "empresa_afiliada" ) );
									info.set_st_presenteado 		( dp.getValue ( "nome_presenteado" ) );
									info.set_st_recado 				( dp.getValue ( "recado" ) );
	
									info.create_T_InfoAdicionais();
								}
								
								#endregion
								
								rows.Clear();
								break;
							}
								
							case "cartao":
							{
								#region - cartao - 
										
								for ( int t=0; t < rows.Count; ++t )
								{
									DataPortable dp = rows[t] as DataPortable;
									
									if ( cart.select_rows_tudo ( dp.getValue ( "cod_empresa" ),
									                             dp.getValue ( "matricula" ),
									                             dp.getValue ( "titularidade" ) ) )
									{
										continue;
									}
								
									cart.set_tg_emitido		 	(  StatusExpedicao.Expedido ); // no legado não tem como descobrir
								
									cart.set_st_empresa 		( dp.getValue ( "cod_empresa" ) );
									cart.set_st_matricula 		( dp.getValue ( "matricula" ) );
									cart.set_st_titularidade 	( dp.getValue ( "titularidade" ) );
									cart.set_st_senha 			( dp.getValue ( "senha" ) );
									
									prot.select_rows_cpf ( dp.getValue ( "cpf_prop_cartao" ) );
									prot.fetch();
																			
									cart.set_fk_dadosProprietario   ( prot.get_identity() );
									
									info.select_rows_emp_mat ( cart.get_st_empresa(), cart.get_st_matricula() );
									info.fetch();
									
									cart.set_fk_infoAdicionais ( info.get_identity() );
																	
									string tp_cart = dp.getValue ( "tipo_cartao" );
									
									cart.set_tg_tipoCartao ( TipoCartao.empresarial );	
									
									cart.set_st_venctoCartao (  dp.getValue ( "vencto_cartao" ).PadLeft ( 4, '0' ) );
									
									if ( cart.get_st_venctoCartao() == "0000" )
										continue;
									
									string stat_cart = dp.getValue ( "status_cartao" );
									
									if ( stat_cart == "1" || stat_cart == "" )
									{
										cart.set_tg_status (  CartaoStatus.Habilitado );
									}
									else
									{
										cart.set_tg_status (  CartaoStatus.Bloqueado );
									}
									
									cart.set_dt_utlPagto 			( GetDataBaseTime() );
									
									cart.set_nu_senhaErrada 		(  dp.getValue ( "Senhas_erradas" ).PadLeft ( 1,'0' ) 	);
									
									string data_inclusao = dp.getValue ( "data_inclusao" );
									
									DateTime tim;
									
									if ( data_inclusao == "" )
									{
										tim = new DateTime ( 	Convert.ToInt32 ( data_inclusao.Substring (6,4) ),
																Convert.ToInt32 ( data_inclusao.Substring (3,2) ),
									                            Convert.ToInt32 ( data_inclusao.Substring (0,2) ) );
									}
									else
									{
										tim = DateTime.Now;
									}
															
									cart.set_dt_inclusao (  GetDataBaseTime ( tim )  );
									
									string data_bloqueio = dp.getValue ( "data_bloqueio" );
									
									DateTime tim2;
										
									if ( data_bloqueio != "" )
									{
										tim2 = new DateTime ( 	Convert.ToInt32 ( data_bloqueio.Substring (6,4) ),
																Convert.ToInt32 ( data_bloqueio.Substring (3,2) ),
								                                Convert.ToInt32 ( data_bloqueio.Substring (0,2) ) );
									}
									else
									{
										tim2 = DateTime.Now;
									}
																	
									cart.set_dt_bloqueio ( GetDataBaseTime ( tim2 ) );
									
									cart.set_tg_motivoBloqueio 		(  dp.getValue ( "motivo_bloqueio" ) );
									
									cart.set_st_banco			 	(  dp.getValue ( "Banco_debito" ).PadLeft ( 1,'0' ) );
									cart.set_st_agencia 			(  dp.getValue ( "Agencia_debito" ).PadLeft ( 1,'0' ) );
									cart.set_st_conta 				(  dp.getValue ( "Conta_debito" ).PadLeft ( 1,'0' ) );
								
									cart.set_st_matriculaExtra	 	(  dp.getValue ( "matriculaextra" ) );
									cart.set_st_celCartao 			(  dp.getValue ( "cel_cartao" ) );
									cart.set_nu_viaCartao 			(  dp.getValue ( "via_cartao" ).PadLeft ( 1,'0' ) );
									cart.set_vr_limiteTotal		 	(  dp.getValue ( "limite_total" ).Replace ( ",","" ).PadRight ( 1, '0' ) );
									
									if ( tp_cart == "A" )
									{
										cart.set_vr_limiteMensal		(  dp.getValue ( "limite_mensal" ).Replace ( ",","" ).PadRight ( 1, '0' ) );
										cart.set_vr_limiteRotativo 		(  dp.getValue ( "limite_rotativo" ).Replace ( ",","" ).PadRight ( 1, '0' ) );
										cart.set_vr_extraCota 			(  dp.getValue ( "Extra_cota" ).Replace ( ",","" ).PadRight ( 1, '0' ) );
									}
									
									cart.set_vr_educacional 		(  "0" );
									cart.set_vr_disp_educacional	(  "0" );
									cart.set_vr_edu_diario 			(  "0" );
									cart.set_st_aluno 				(  "" );
									cart.set_vr_edu_disp_virtual 	(  "0" );
									cart.set_nu_rankVirtual 		(  "0" );
									cart.set_vr_edu_total_ranking 	(  "0" );
									cart.set_nu_webSenhaErrada 		(  "0" );
									
									cart.create_T_Cartao();
									
									LINK_ProprietarioCartao prot_cart = new LINK_ProprietarioCartao (this);
									
									if ( !prot_cart.select_fk_tudo ( cart.get_identity(), prot.get_identity() ) )
									{
										prot_cart.set_fk_proprietario ( prot.get_identity() );
										prot_cart.set_fk_cartao       ( cart.get_identity() );
										
										prot_cart.create_LINK_ProprietarioCartao();
									}
								}
								
								#endregion
								
								rows.Clear();
								break;
							}
								
							case "log_cartao_presente":
							{
								string vend = "";
									
								LOG_VendaCartaoGift lvc = new LOG_VendaCartaoGift (this);
								LOG_VendaProdutoGift lvp = new LOG_VendaProdutoGift (this);
								
								for ( int t=0; t < rows.Count; ++t )
								{
									DataPortable dp = rows[t] as DataPortable;
									
									if (  dp.getValue ( "cod_empresa" ) != "003522" )
										continue;
									
									if (  dp.getValue ( "tipo_reg" ) == "9" )
										continue;
									
									if ( !emp.select_rows_empresa ( dp.getValue ( "cod_empresa" ) ) )
									    continue;
								
									if ( !emp.fetch() )
										continue;
									    
									if ( !cart.select_rows_tudo ( dp.getValue ( "cod_empresa" ), 
									                              dp.getValue ( "matricula" ), 
									                              "01" ) )
										continue;
									
									if ( !cart.fetch() )
										continue;
									
									// tipo reg 0 - carga
									// tipo reg 1 - tarifa de carga
									// tipo reg 2 - produto
									
									if ( dp.getValue ( "tipo_reg" ) == "0" )
									{
										lvc.set_dt_compra ( dp.getValue ( "data" ).Substring (6,4) + "-" +
										                    dp.getValue ( "data" ).Substring (3,2) + "-" +
										                    dp.getValue ( "data" ).Substring (0,2) + " " +
										                   	dp.getValue ( "hora" ).Substring (0,8) );
									
										lvc.set_fk_empresa 	( emp.get_identity() 												);
										lvc.set_fk_cartao 	( cart.get_identity()	 											);
										lvc.set_vr_carga	( dp.getValue ( "valor" ).Replace ( ",","" ).PadLeft ( 1, '0' ) 	);
										lvc.set_tg_adesao   ( Context.TRUE 														);
										
										if ( !lvc.create_LOG_VendaCartaoGift() )
											continue;
										
										vend = lvc.get_identity();
									}
									else if ( dp.getValue ( "tipo_reg" ) == "1" )
									{
										lvp.set_fk_vendaCartao ( vend );
										lvp.set_st_produto ( "Tarifa de carga" );
										lvp.set_vr_valor ( dp.getValue ( "valor" ).Replace ( ",","" ).PadLeft ( 1, '0' ) );
										
										if ( !lvp.create_LOG_VendaProdutoGift() )
											continue;
									}
									else if ( dp.getValue ( "tipo_reg" ) == "2" )
									{
										lvp.set_fk_vendaCartao ( vend );
										lvp.set_st_produto ( dp.getValue ( "descricao" ) );
										lvp.set_vr_valor ( dp.getValue ( "valor" ).Replace ( ",","" ).PadLeft ( 1, '0' ) );
										
										if ( !lvp.create_LOG_VendaProdutoGift() )
											continue;
									}
									else
									{
										continue;
									}
								}
									
								rows.Clear();
								break;
							}
								
							case "log_transacoes":
							{
								rows_log_transacoes = rows;
									
								for ( int g=0; g < rows_log_transacoes.Count; ++g )
								{
									if ( g % 100 == 0 )
										Registry ( "Proc TR -> " + g.ToString() );
									
									DataPortable tmp = rows_log_transacoes[g] as DataPortable;
									hsh_log_transacoes [ tmp.getValue ( "nsu_rcb" ) + tmp.getValue ( "nsu_banco" ) ] = tmp;
								}
									
								break;
							}
								
							case "valor_parcela":
							{
								SQL_LOGGING_ENABLE = false;
									
								LOG_Transacoes 	log_trans = new LOG_Transacoes(this);
								
								#region - parcelas de pagamento - 
								
								for ( int t=0; t < rows.Count; ++t )
								{
									if ( t % 100 == 0 )
										Registry ( "Proc A -> " + t.ToString() );
									
									T_Parcelas 		parc      = new T_Parcelas (this);
									
									DataPortable dp       = rows[t] as DataPortable;
									
									DataPortable dp_trans = hsh_log_transacoes [ dp.getValue ( "nsu_rcb" ) + dp.getValue ( "nsu_ce" ) ] as DataPortable;
									
									if ( dp_trans == null )
										continue;
									
									#region - busca FK´s - 
									
									if ( !emp.select_rows_empresa ( dp.getValue ( "cod_empresa" ) ) )
									{
										Registry ( "Rejected!");
										continue;
									}
									
									emp.fetch();
									
									if ( !cart.select_rows_tudo ( dp.getValue ( "cod_empresa" ), 
									                       	dp.getValue ( "matricula" ), 
									                       	dp.getValue ( "titularidade" ) ) )
									{
										Registry ( "Rejected!");
										continue;
									}
											
									cart.fetch();
									
									if ( !term.select_rows_terminal ( dp_trans.getValue ( "nro_terminal" ) ) )
									{
										Registry ( "Rejected!");
										continue;
									}

									term.fetch();
									
									#endregion
				
									DateTime tim;
									
									string data_inclusao = dp.getValue ( "datat" );
									string hora_inclusao = dp.getValue ( "hora" );
									
									if ( data_inclusao != "" )
									{
										tim = new DateTime ( Convert.ToInt32 ( data_inclusao.Substring (6,4) ),
															 Convert.ToInt32 ( data_inclusao.Substring (3,2) ),
									                         Convert.ToInt32 ( data_inclusao.Substring (0,2) ), 
									                         Convert.ToInt32 ( hora_inclusao.Substring (0,2) ),
									                         Convert.ToInt32 ( hora_inclusao.Substring (3,2) ),
									                         Convert.ToInt32 ( hora_inclusao.Substring (6,2) ) );
									}
									else
									{
										continue;
									}
									
									data_inclusao = GetDataBaseTime ( tim );
	
									log_trans.set_fk_empresa 		( emp.get_identity() 															);
									log_trans.set_fk_cartao 		( cart.get_identity() 															);
									log_trans.set_fk_terminal 		( term.get_identity() 															);
									log_trans.set_fk_loja 			( term.get_fk_loja()  															);
									log_trans.set_nu_nsu 			( dp.getValue ( "nsu_rcb" ).PadLeft ( 1, '0' ) 									);
									log_trans.set_dt_transacao 		( data_inclusao 																);
									log_trans.set_nu_parcelas 		( dp_trans.getValue ( "qtd_parcelas" ).PadLeft ( 1, '0' )						);
									log_trans.set_vr_total 			( dp_trans.getValue ( "valor_total"  ).Replace ( ",","" ).PadLeft ( 1, '0' ) 	);
									log_trans.set_nu_nsuOrig 		( "0"			 																); 
									log_trans.set_nu_cod_erro 		( dp.getValue ( "coderro" ) 													);
									log_trans.set_st_msg_transacao 	( "" 																			);
									
									try
									{
										// confere se nsu é valido
										long nsu = Convert.ToInt64 ( log_trans.get_nu_nsu() );
									}
									catch ( System.Exception ex )
									{
										ex.ToString();
										continue;
									}
									
									if ( dp_trans.getValue ( "confirmada" ) == "1" )
									{
										log_trans.set_tg_confirmada ( TipoConfirmacao.Confirmada 	);	
									}
									else if ( dp_trans.getValue ( "confirmada" ) == "3" )
									{
										log_trans.set_tg_confirmada ( TipoConfirmacao.Cancelada );	
									}
									else if ( dp_trans.getValue ( "confirmada" ) == "0" && log_trans.get_nu_cod_erro() == "00" )
									{
										log_trans.set_tg_confirmada ( TipoConfirmacao.Pendente );
									}
									else if ( log_trans.get_nu_cod_erro() != "00" )
									{
										log_trans.set_tg_confirmada ( TipoConfirmacao.Negada );
									}
									
									if (log_trans.get_nu_cod_erro() == "00" )
									{
										log_trans.set_tg_contabil 	( Context.TRUE );
									}
									else
									{
										log_trans.set_tg_contabil 	( Context.FALSE 		 );			
									}

									if ( dp_trans.getValue ( "tipo_oper" ) == "08" )
									{
										log_trans.set_en_operacao ( OperacaoCartao.VENDA_EMPRESARIAL_CANCELA );
									}
									else
									{
										log_trans.set_en_operacao ( OperacaoCartao.VENDA_EMPRESARIAL );
									}
	
									int tot_parc = Convert.ToInt32 ( log_trans.get_nu_parcelas() );
									
									if ( tot_parc == 0 )
										continue;
																							
									string val = ( log_trans.get_int_vr_total() / tot_parc ).ToString();
									
									parc.set_nu_nsu 			( log_trans.get_nu_nsu() 			);
									parc.set_fk_empresa 		( log_trans.get_fk_empresa() 		);
									parc.set_fk_cartao 			( log_trans.get_fk_cartao() 		);
									parc.set_fk_terminal 		( log_trans.get_fk_terminal() 		);
									parc.set_fk_loja 			( log_trans.get_fk_loja() 			);
									parc.set_dt_inclusao 		( log_trans.get_dt_transacao() 		);
									parc.set_nu_indice 			( dp.getValue ("nro_parcela")		);
									parc.set_nu_parcela 		( dp.getValue ("indice_pagamento")	);
									parc.set_vr_valor 			( dp.getValue ("valor_parcela").Replace ( ",","").PadLeft ( 1, '0') );
									parc.set_nu_tot_parcelas 	( tot_parc.ToString() 				);
									
									if ( dp.getValue ( "pagosn" ) == "N" )
									{
										parc.set_tg_pago ( TipoParcela.EM_ABERTO );
									}
									else
									{
										parc.set_tg_pago ( TipoParcela.QUITADO );										
									}
									
									if ( dp.getValue ("nro_parcela") == "1" ) 
									{
										// uma transação para n parcelas, grava somente na primeira
										log_trans.create_LOG_Transacoes();
									}
									
									parc.set_fk_log_transacoes ( log_trans.get_identity() );
									
									parc.create_T_Parcelas();							
								}
								
								#endregion
													
								rows.Clear();
						
								log_trans.Reset();
								log_trans.selectAll();
								
								long u = 0;
								
								while ( log_trans.fetch() )
								{
									if ( ++u % 100 == 0 )
										Registry ( "Proc B -> " + u.ToString() );
									
									T_Parcelas 		parc      = new T_Parcelas (this);
									T_Parcelas 		parc_upd      = new T_Parcelas (this);
																
									
									parc.select_rows_nsu_dt ( log_trans.get_nu_nsu(), 
									        				  log_trans.get_dt_transacao() );
									
									parc.fetch();
									
									parc_upd.ExclusiveAccess();
									parc_upd.selectIdentity ( parc.get_identity() );
									
									parc_upd.set_fk_log_transacoes ( log_trans.get_identity() );
									
									parc_upd.synchronize_T_Parcelas();
									parc_upd.ReleaseExclusive();
								}
								
								SQL_LOGGING_ENABLE = true;
								
								break;
							}
						}
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
			
			// ## Corrige código de lojas muito antigo
			
			loj.ExclusiveAccess();
			loj.select_rows_loja ( "019927000088" );
			loj.fetch();
			loj.set_st_loja ( "4200" );
			loj.synchronize_T_Loja();
			loj.ReleaseExclusive();
			
			loj.ExclusiveAccess();
			loj.select_rows_loja ( "019927000099" );
			loj.fetch();
			loj.set_st_loja ( "4201" );
			loj.synchronize_T_Loja();
			loj.ReleaseExclusive();			
			*/
			
			/// USER [ execute ] END
		
			Registry ( "execute done load_legado " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish load_legado " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done load_legado " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
