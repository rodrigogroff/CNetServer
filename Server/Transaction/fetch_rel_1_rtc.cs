using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_rel_1_rtc : type_base
	{
		public string input_st_cart = "";
		public string input_st_pf = "";
		public string input_st_cidade = "";
		public string input_st_estado = "";
		public string input_st_loja = "";
		public string input_st_dt_ini = "";
		public string input_st_dt_fim = "";
		
		public string output_st_csv = "";
		public string output_st_empresa = "";
		public string output_st_total_periodo = "";
		public string output_st_cartao = "";
		public string output_st_total_cancelado = "";
		public string output_st_parcs = "";
		public string output_st_parcs_total = "";
		public string output_st_parcs_content = "";
		
		/// USER [ var_decl ]
		
		LOG_Transacoes 	l_tr;
		T_Loja  		loj;
		
		string fk_loja 		= "";
		string st_cart_id   = "";
		
		/// USER [ var_decl ] END
		
		public fetch_rel_1_rtc ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_rel_1_rtc";
			constructor();
		}
		
		public fetch_rel_1_rtc()
		{
			var_Alias = "fetch_rel_1_rtc";
		
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
			Registry ( "setup fetch_rel_1_rtc " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_1_RTC.st_cart, ref input_st_cart ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_1_RTC.st_cart missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_1_RTC.st_pf, ref input_st_pf ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_1_RTC.st_pf missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_1_RTC.st_cidade, ref input_st_cidade ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_1_RTC.st_cidade missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_1_RTC.st_estado, ref input_st_estado ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_1_RTC.st_estado missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_1_RTC.st_loja, ref input_st_loja ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_1_RTC.st_loja missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_1_RTC.st_dt_ini, ref input_st_dt_ini ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_1_RTC.st_dt_ini missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_1_RTC.st_dt_fim, ref input_st_dt_fim ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_1_RTC.st_dt_fim missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_REL_1_RTC.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_REL_1_RTC.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_rel_1_rtc " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_rel_1_rtc " ); 
		
			/// USER [ authenticate ]
			
			input_st_cart = input_st_cart.PadLeft ( 14, '0' );
			
			l_tr = new LOG_Transacoes (this);
			
			// ## Confere telefone
			
			if ( input_st_pf.Length == 10 )
			{
				T_PayFone pf = new T_PayFone (this);
				
				if ( !pf.select_rows_telefone ( input_st_pf ) )
				{
					PublishError ( "Telefone inválido" );
					return true;
				}
				else
				{
					if ( !pf.fetch() )
						return false;
				
					st_cart_id = pf.get_fk_cartao();
				}
			}
			
			// ##  Confere cartão
			
			else if ( input_st_cart.Length == 14 )
			{
				T_Cartao cart = new T_Cartao (this);
					
				if ( !cart.select_rows_tudo ( 	input_st_cart.Substring (0,6), 		// empresa
				                            	input_st_cart.Substring (6,6), 		// matricula
				                            	input_st_cart.Substring (12,2) ) )	// titularidade
				{
					PublishError ( "Cartão inválido" );
					return true;
				}
				else
				{
					if ( !cart.fetch() )
						return false;
					
					st_cart_id = cart.get_identity();
				}
			}
						
			// ## Confere Loja
			
			loj = new T_Loja (this);
			
			if ( input_st_loja.Length > 0 )
			{
				// ## Busca pelo código
				
				if ( !loj.select_rows_loja ( input_st_loja ) )
				{
					PublishError ( "Loja inexistente" );
					return true;
				}
				
				if ( !loj.fetch() )
					return false;
				
				fk_loja = loj.get_identity();
			}
				
			// ## Seleciona os registros de transações
			
			l_tr.select_rows_dt_cart ( 	input_st_dt_ini, 
	                               		input_st_dt_fim, 
	                               		st_cart_id );
							
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_rel_1_rtc " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_rel_1_rtc " ); 
		
			/// USER [ execute ]
			
			// ## 
			// ## O seguinte trecho indexa as lojas possíveis
			// ## de retorno para uma determinada empresa.
			// ## 
			// ## E, no caso de a empresa original ser administradora
			// ## de empresas, indexar todas as lojas de todas empresas
			// ## desta rede.
			// ## 
			
			Hashtable hshLojas = new Hashtable();
			
			#region - filtro de lojas da empresa - 
						
			if ( user.get_tg_nivel() == TipoUsuario.Administrador )
			{
				T_Empresa emp_orig = new T_Empresa (this);
				
				// ## Busca empresa original
				
				if ( !emp_orig.select_rows_empresa ( user.get_st_empresa() ) )
					return false;
				
				if ( !emp_orig.fetch())
					return false;
				
				LINK_LojaEmpresa lnk = new LINK_LojaEmpresa (this);
				
				// ## busca relacionamento das empresas com lojas
				
				if ( lnk.select_fk_empresa_geral ( emp_orig.get_identity() ) )
				{
					while ( lnk.fetch() )
					{
						// ## indexa lojas
						
						hshLojas [ lnk.get_fk_loja() ] = "*";
					}
				}				
				
				// ## busca empresas administradas
				
				T_Empresa emp_lnk_admin = new T_Empresa (this);
				
				if ( emp_lnk_admin.select_fk_admin ( emp_orig.get_identity() ) )
				{
					while ( emp_lnk_admin.fetch() )
					{
						// ## busca lojas de cada empresa administrada
						
						LINK_LojaEmpresa lnk_admin = new LINK_LojaEmpresa (this);
						
						if ( lnk_admin.select_fk_empresa_geral ( emp_lnk_admin.get_identity() ) )
						{
							while ( lnk_admin.fetch() )
							{
								// ## indexa loja
							
								hshLojas [ lnk_admin.get_fk_loja() ] = "*";
							}
						}		
					}
				}
			}
			
			#endregion
			
			StringBuilder sb = new StringBuilder();
			
			long vr_tot = 0;
			long vr_tot_cancelado = 0;
			
			T_Terminal term = new T_Terminal (this);
			
			while ( l_tr.fetch() )
			{
				// ## Filtra lojas não vinculadas à empresa
				
				if ( hshLojas.Count > 0 )
					if ( hshLojas [ l_tr.get_fk_loja() ] == null )
						continue;
				
				// ## Busca terminal
				
				if ( term.selectIdentity ( l_tr.get_fk_terminal() ) )
				{
					if ( fk_loja.Length > 0 )
						if ( term.get_fk_loja() != fk_loja )
							continue;
					
					if ( !loj.selectIdentity ( term.get_fk_loja() ) )
						continue;
					
					if ( input_st_cidade.Length > 0 )
						if ( !loj.get_st_cidade().Contains ( input_st_cidade ) )
							continue;
					
					if ( input_st_estado.Length > 0 )
						if ( !loj.get_st_estado().Contains ( input_st_estado ) )
							continue;
					
					if ( l_tr.get_tg_contabil() == Context.TRUE )
					{
						if ( l_tr.get_tg_confirmada() == TipoConfirmacao.Cancelada )
							vr_tot_cancelado += l_tr.get_int_vr_total();
						else
							if ( l_tr.get_tg_confirmada() == TipoConfirmacao.Confirmada )
								vr_tot += l_tr.get_int_vr_total();
					}
				}
				
				// ## Copia dados para memória
				
				Rel_RTC rtc = new Rel_RTC();
				
				rtc.set_st_loja 	 ( loj.get_st_nome() 			);
				rtc.set_st_term 	 ( term.get_nu_terminal() 		);
				rtc.set_st_nsu	 	 ( l_tr.get_nu_nsu()			);
				rtc.set_vr_total	 ( l_tr.get_vr_total() 			);
				rtc.set_nu_parc 	 ( l_tr.get_nu_parcelas() 		);
				rtc.set_dt_trans  	 ( l_tr.get_dt_transacao() 		);
				rtc.set_tg_status 	 ( l_tr.get_tg_confirmada() 	);
				rtc.set_st_motivo 	 ( l_tr.get_st_msg_transacao() 	);
				rtc.set_en_op_cartao ( l_tr.get_en_operacao()		);
								
				DataPortable mem_rtc = rtc as DataPortable;
				
				// ## obtem indice
				
				sb.Append ( MemorySave ( ref mem_rtc ) );
				sb.Append ( ","   );
				
				if ( l_tr.get_int_nu_parcelas()  > 1 )
				{
					T_Parcelas parc = new T_Parcelas (this);
					
					if ( parc.select_fk_log_trans ( l_tr.get_identity() ) )
					{
						while ( parc.fetch() )
						{
							Rel_RTC rtc2 = new Rel_RTC();
				
							rtc2.set_vr_total	 	( parc.get_vr_valor()			);
							rtc2.set_nu_parc 	 	( parc.get_nu_indice() 			);
							rtc2.set_dt_trans  	 	( l_tr.get_dt_transacao() 		);
							rtc2.set_tg_status 	 	( l_tr.get_tg_confirmada()	 	);
							rtc2.set_st_motivo 	 	( l_tr.get_st_msg_transacao() 	);
							rtc2.set_en_op_cartao 	( l_tr.get_en_operacao()		);
							
							DataPortable mem_rtc_parc = rtc2 as DataPortable;
				
							// ## obtem indice
							
							sb.Append ( MemorySave ( ref mem_rtc_parc ) );
							sb.Append ( ","   );
						}
					}
				}
			}
			
			string list_ids = sb.ToString().TrimEnd ( ',' );
									
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", list_ids );
				
			// ## obtem indice geral
			
			output_st_csv = MemorySave ( ref dp );
			
			// ## obtem dados adicionais
			
			T_Cartao cart = new T_Cartao (this);
			
			if ( !cart.selectIdentity ( st_cart_id ) )
				return false;
			
			T_Empresa emp = new T_Empresa ( this );
			
			if ( !emp.select_rows_empresa ( cart.get_st_empresa() ) )
				return false;
			
			if ( !emp.fetch() )
				return false;
			
			string nome = "";
			
			if ( cart.get_st_titularidade() != "01" )
			{
				T_Dependente dep = new T_Dependente (this);
				
				dep.select_rows_prop_tit ( cart.get_fk_dadosProprietario(), cart.get_st_titularidade() );
				dep.fetch();
				
				nome = dep.get_st_nome() + " (Dependente)";
			}
			else
			{
				T_Proprietario prot = new T_Proprietario (this);
				
				prot.selectIdentity ( cart.get_fk_dadosProprietario() );
				
				nome = prot.get_st_nome() + " - CPF " + prot.get_st_cpf();
			}
			
			output_st_empresa = emp.get_st_fantasia();
			
			output_st_cartao  = cart.get_st_empresa() + "." +
								cart.get_st_matricula() + "." + 
								cart.get_st_titularidade() + ":" + 
								cart.get_nu_viaCartao() + " - " + 
								nome;
			
			output_st_total_periodo = vr_tot.ToString();
			output_st_total_cancelado = vr_tot_cancelado.ToString();
						
			
			
			// ##### ------------------------------------------------------
			// ##### Relatório extra sobre todas as parcelas do cartão
			// ##### ------------------------------------------------------
			{
				T_Cartao cart_parc     = new T_Cartao (this);
				T_Cartao cart_parc_dep = new T_Cartao (this);
				
				ArrayList  lstDeps = new ArrayList();
				
				if ( cart_parc.selectIdentity ( st_cart_id ) )
				{
					if ( cart_parc.get_tg_tipoCartao() == TipoCartao.presente )
						return true;
					
					if ( cart_parc_dep.select_rows_empresa_matricula ( 	cart_parc.get_st_empresa(),
					                                                	cart_parc.get_st_matricula() ) )
					{
						while ( cart_parc_dep.fetch() )
						{
							lstDeps.Add ( cart_parc_dep.get_identity() );
						}
					}
				}
				
				StringBuilder sb_parcs = new StringBuilder();
				
				T_Parcelas parc = new T_Parcelas (this);
				
				for ( int u = 1; u <=  12; ++u )
				{
					string cur_pac = "Comprometimento mensal (" + u.ToString() + ")";
					
					if ( u == 1 )
						cur_pac += " - vigente";
					
					bool HasContent   = false;
					long tot_parc_ind = 0;
					
					if ( parc.select_rows_relat_parc ( u.ToString(), ref lstDeps ) )
					{
						while ( parc.fetch() )
						{
							if ( !term.selectIdentity ( parc.get_fk_terminal() ) )
								continue;
							
							if ( !loj.selectIdentity ( term.get_fk_loja() ) )
								continue;
							
							if ( l_tr.selectIdentity ( parc.get_fk_log_transacoes() ) )
								if ( l_tr.get_tg_confirmada() != TipoConfirmacao.Confirmada )
									continue;
							
							tot_parc_ind += parc.get_int_vr_valor();
							
							HasContent = true;
							
							Rel_RTC rtc = new Rel_RTC();
				
							rtc.set_st_loja 	 ( loj.get_st_nome() 			);
							rtc.set_st_term 	 ( term.get_nu_terminal() 		);
							rtc.set_st_nsu	 	 ( l_tr.get_nu_nsu()			);
							rtc.set_vr_total	 ( parc.get_vr_valor() 			);
							rtc.set_nu_parc 	 ( u.ToString()					);
							rtc.set_dt_trans  	 ( l_tr.get_dt_transacao() 		);
							rtc.set_tg_status 	 ( l_tr.get_tg_confirmada() 	);
							rtc.set_st_motivo 	 ( l_tr.get_st_msg_transacao() 	);
							rtc.set_en_op_cartao ( l_tr.get_en_operacao()		);
							
							rtc.set_st_indice_parcela ( parc.get_nu_indice() );
											
							DataPortable mem_rtc = rtc as DataPortable;
							
							// ## obtem indice
							
							sb_parcs.Append ( MemorySave ( ref mem_rtc ) );
							sb_parcs.Append ( ","   );
						}
					}
					
					if ( !HasContent )
						break;
				
					output_st_parcs 	    += cur_pac + ",";
					output_st_parcs_total   += tot_parc_ind.ToString() + "," + 
											   ( cart_parc.get_int_vr_limiteMensal() - tot_parc_ind ).ToString()  + ",";
				}
				
				string list_ids_parc = sb_parcs.ToString().TrimEnd ( ',' );
									
				DataPortable dp_parcs = new DataPortable();
		
				dp_parcs.setValue ( "ids", list_ids_parc );
				
				output_st_parcs_content = MemorySave ( ref dp_parcs );
				output_st_parcs         = output_st_parcs.TrimEnd ( ',' );
				output_st_parcs_total   = output_st_parcs_total.TrimEnd ( ',' );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_rel_1_rtc " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_rel_1_rtc " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_rel_1_rtc " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_1_RTC.st_csv, output_st_csv ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_1_RTC.st_empresa, output_st_empresa ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_1_RTC.st_total_periodo, output_st_total_periodo ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_1_RTC.st_cartao, output_st_cartao ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_1_RTC.st_total_cancelado, output_st_total_cancelado ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_1_RTC.st_parcs, output_st_parcs ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_1_RTC.st_parcs_total, output_st_parcs_total ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_1_RTC.st_parcs_content, output_st_parcs_content ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
