using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_rel_2_rlt : type_base
	{
		public string input_st_loja = "";
		public string input_st_dt_ini = "";
		public string input_st_dt_fim = "";
		public string input_st_empresa = "";
		
		public string output_st_total = "";
		public string output_st_total_cancelado = "";
		public string output_st_csv_subtotal = "";
		public string output_st_csv_subtotal_cancelado = "";
		public string output_st_csv = "";
		public string output_st_nome_loja = "";
		
		public ArrayList output_array_generic_lstTerminais = new ArrayList(); 
		
		/// USER [ var_decl ]
		
		LOG_Transacoes 	l_tr;
		T_Loja  		loj;
		
		string fk_loja = "0";
		
		/// USER [ var_decl ] END
		
		public fetch_rel_2_rlt ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_rel_2_rlt";
			constructor();
		}
		
		public fetch_rel_2_rlt()
		{
			var_Alias = "fetch_rel_2_rlt";
		
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
			Registry ( "setup fetch_rel_2_rlt " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_2_RLT.st_loja, ref input_st_loja ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_2_RLT.st_loja missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_2_RLT.st_dt_ini, ref input_st_dt_ini ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_2_RLT.st_dt_ini missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_2_RLT.st_dt_fim, ref input_st_dt_fim ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_2_RLT.st_dt_fim missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_2_RLT.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_2_RLT.st_empresa missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_REL_2_RLT.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_REL_2_RLT.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_rel_2_rlt " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_rel_2_rlt " ); 
		
			/// USER [ authenticate ]
			
			if ( input_st_loja.Length == 0 )
			{
				PublishError ( "Loja inválida" );
				return false;
			}
			
			loj = new T_Loja ( this );
			
			// ## Busca loja pelo seu código
			
			if ( !loj.select_rows_loja ( input_st_loja ) )
			{
				PublishError ( "Loja inválida" );
				return false;
			}
			
			if ( !loj.fetch() )
				return false;
			
			output_st_nome_loja = loj.get_st_social();
			    
			fk_loja = loj.get_identity();
			
			l_tr = new LOG_Transacoes (this);
			
			// ## busca transações pelo período e loja
			
			if ( !l_tr.select_rows_dt_loj  ( input_st_dt_ini, 
			                               	input_st_dt_fim, 
			                               	fk_loja ) )
			{
				PublishError ( "Nenhum registro encontrado" );
				return false;
			}
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_rel_2_rlt " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_rel_2_rlt " ); 
		
			/// USER [ execute ]
			
			if ( input_cont_header.get_tg_user_type() != TipoUsuario.Lojista )
			{
				input_st_empresa = input_st_empresa.PadLeft ( 6, '0' );
				
				T_Empresa emp = new T_Empresa (this);
				
				if ( !emp.select_rows_empresa ( input_st_empresa ) )
				{
					PublishError ( "Empresa não disponível" );
					return false;
				}				
			}
			else
			{
				input_st_empresa = "";
			}				
			
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
			
			Hashtable hsh_term_confirmada = new Hashtable();
			Hashtable hsh_term_cancelada  = new Hashtable();
			Hashtable hsh_term 			  = new Hashtable();

			T_Terminal term = new T_Terminal (this);
			T_Cartao   cart = new T_Cartao (this);
			
			string term_ident = "";
			
			long 	vr_sub_confirmada = 0, 
					vr_sub_cancelada  = 0,
					vr_tot_confirmada = 0,
					vr_tot_cancelada  = 0;
			
			ArrayList tmp_Terms = new ArrayList();
			
			// ## Busca registros de transações
			
			while ( l_tr.fetch() )
			{
				if ( hshLojas.Count > 0 )
					if ( hshLojas [ l_tr.get_fk_loja() ] == null )
						continue;
				
				// ## Busca terminal referente
				
				if ( !term.selectIdentity ( l_tr.get_fk_terminal() ) )
					continue;
				
				term_ident = term.get_nu_terminal();
				
				// ## Captura terminais
				
				if ( hsh_term [ term_ident ] == null )
				{
					DadosTerminal dt = new DadosTerminal();
					
					dt.set_st_terminal 		( term.get_nu_terminal() 	);
					dt.set_st_localizacao 	( term.get_st_localizacao() );
					
					output_array_generic_lstTerminais.Add ( dt );
					
					tmp_Terms.Add ( term_ident );
					
					hsh_term [ term_ident ] = 1;
				}
				
				// ## Busca cartão relacionado
				
				if ( !cart.selectIdentity ( l_tr.get_fk_cartao() ) )
					continue;
			
				if ( input_st_empresa.Length > 0 )
					if ( cart.get_st_empresa() != input_st_empresa )
						continue;
				
				// ## Se transação deve ser contabilizada
				
				if ( l_tr.get_tg_contabil() == Context.TRUE )
				{
					long cur_val = l_tr.get_int_vr_total();
					
					if ( l_tr.get_tg_confirmada() == TipoConfirmacao.Confirmada )
					{
						if ( hsh_term_confirmada [ term_ident ] == null )
							vr_sub_confirmada  = (long) 0;
						else
							vr_sub_confirmada  = (long) hsh_term_confirmada [ term_ident ];
											
						vr_tot_confirmada += cur_val;
						
						hsh_term_confirmada [ term_ident ] = vr_sub_confirmada + cur_val;
					}
					else if ( l_tr.get_tg_confirmada() == TipoConfirmacao.Cancelada )
					{
						if ( hsh_term_cancelada [ term_ident ] == null )
							vr_sub_cancelada  = (long) 0;
						else
							vr_sub_cancelada  = (long) hsh_term_cancelada [ term_ident ];
						
						vr_tot_cancelada += cur_val;
						
						hsh_term_cancelada [ term_ident ] = vr_sub_cancelada + cur_val;
					}
				}
									
				Rel_RLT rlt = new Rel_RLT();
				
				rlt.set_st_cartao 	 ( cart.get_st_empresa()   + "." + 
					                   cart.get_st_matricula() + "." + 
				                       cart.get_st_titularidade() );
				
				rlt.set_st_nsu	 	 ( l_tr.get_nu_nsu()			);
				rlt.set_vr_total	 ( l_tr.get_vr_total() 			);
				rlt.set_nu_parc 	 ( l_tr.get_nu_parcelas() 		);
				rlt.set_dt_trans  	 ( l_tr.get_dt_transacao() 		);
				rlt.set_tg_status 	 ( l_tr.get_tg_confirmada() 	);
				rlt.set_st_motivo 	 ( l_tr.get_st_msg_transacao() 	);
				rlt.set_en_op_cartao ( l_tr.get_en_operacao()		);
				rlt.set_st_terminal	 ( term_ident					);
								
				DataPortable mem_rlt = rlt as DataPortable;
				
				// ## Grava em memória
				
				sb.Append ( MemorySave ( ref mem_rlt ) );
				sb.Append ( ","   );				
			}
			
			string list_ids = sb.ToString().TrimEnd ( ',' );
			
			if ( list_ids == "" )
			{
				PublishNote ( "Nenhum resultado foi encontrado" );
				return false;
			}
									
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", list_ids );
						
			// ## Gera identificador geral
			
			output_st_csv = MemorySave ( ref dp );
						
			long value_sub = 0;
			
			// ## Percorre terminais
			
			for ( int t=0; t < tmp_Terms.Count; ++t )
			{
				term_ident = tmp_Terms[t].ToString();
				
				if ( hsh_term_confirmada [ term_ident ] == null )	hsh_term_confirmada [ term_ident ]  = (long) 0;
				if ( hsh_term_cancelada [ term_ident ] == null )	hsh_term_cancelada  [ term_ident ]  = (long) 0;
				
				// ## Contabiiza
				
				value_sub = (long) hsh_term_confirmada [ term_ident ];
								
				output_st_csv_subtotal 			 += value_sub.ToString() + ",";
				
				value_sub = (long) hsh_term_cancelada [ term_ident ];
				
				output_st_csv_subtotal_cancelado += value_sub.ToString() + ",";
			}
			
			output_st_csv_subtotal           = output_st_csv_subtotal.TrimEnd ( ',' );
			output_st_csv_subtotal_cancelado = output_st_csv_subtotal_cancelado.TrimEnd ( ',' );
			output_st_total                  = vr_tot_confirmada.ToString();
			output_st_total_cancelado        = vr_tot_cancelada.ToString();		
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_rel_2_rlt " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_rel_2_rlt " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_rel_2_rlt " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_2_RLT.st_total, output_st_total ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_2_RLT.st_total_cancelado, output_st_total_cancelado ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_2_RLT.st_csv_subtotal, output_st_csv_subtotal ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_2_RLT.st_csv_subtotal_cancelado, output_st_csv_subtotal_cancelado ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_2_RLT.st_csv, output_st_csv ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_2_RLT.st_nome_loja, output_st_nome_loja ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			DataPortable dp_array_generic_lstTerminais = new DataPortable();
		
			dp_array_generic_lstTerminais.MapTagArray ( COMM_OUT_FETCH_REL_2_RLT.lstTerminais , ref output_array_generic_lstTerminais );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lstTerminais );
		
			return true;
		}
	}
}
