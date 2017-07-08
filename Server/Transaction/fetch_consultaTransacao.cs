using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_consultaTransacao : type_base
	{
		public DadosConsultaTransacao input_cont_dct = new DadosConsultaTransacao();
		
		public string output_st_csv_id = "";
		
		/// USER [ var_decl ]
		
		LOG_Transacoes l_tr;
		
		string fk_empresa 	= "";
		string fk_loja 		= "";
		string fk_terminal	= "";
		
		string st_nsu   	= "";
		string nu_parc  	= "";
		string en_oper  	= "";
		string en_conf  	= "";
		string vr_valor 	= "";
		
		string st_cart_id   = "";
		
		/// USER [ var_decl ] END
		
		public fetch_consultaTransacao ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_consultaTransacao";
			constructor();
		}
		
		public fetch_consultaTransacao()
		{
			var_Alias = "fetch_consultaTransacao";
		
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
			Registry ( "setup fetch_consultaTransacao " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_FETCH_CONSULTATRANSACAO.dct, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_CONSULTATRANSACAO.dct missing! " ); 
				return false;
			}
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_CONSULTATRANSACAO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_CONSULTATRANSACAO.header missing! " ); 
				return false;
			}
			
			input_cont_dct.Import ( ct_0 );
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_consultaTransacao " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_consultaTransacao " ); 
		
			/// USER [ authenticate ]
			
			l_tr = new LOG_Transacoes (this);
			
			// ## obtem filtros rápidos
			
			string cod_empresa  = input_cont_dct.get_st_cod_empresa().PadLeft ( 6, '0' );
			string cnpj_loja    = input_cont_dct.get_st_cnpj_loja();
			string cod_loja     = input_cont_dct.get_st_cod_loja();
			string st_terminal  = input_cont_dct.get_st_terminal().PadLeft ( 8, '0' ).TrimEnd ( '0' );
			string dt_ini       = input_cont_dct.get_dt_ini();
			string dt_fim       = input_cont_dct.get_dt_fim();
			string st_cart      = input_cont_dct.get_st_cartao();
			string st_telefone  = input_cont_dct.get_st_telefone();
			
			#region - resolve todos os links - 
			
			// ## Confere telefone
			
			if ( st_telefone.Length == 10 )
			{
				T_PayFone pf = new T_PayFone (this);
				
				if ( !pf.select_rows_telefone ( st_telefone ) )
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
			
			else if ( st_cart.Length > 0 )
			{
				T_Cartao cart = new T_Cartao (this);
					
				if ( !cart.select_rows_tudo ( 	cod_empresa, 				// empresa
				                             	st_cart.PadLeft ( 6, '0'), 	// matricula
				                            	"01" ) )					// titularidade
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
			
			// ## Confere pelo código de empresa
			
			if ( cod_empresa.Length > 0 )
			{
				T_Empresa emp = new T_Empresa (this);
				
				if ( cod_empresa == "000000" && 
				     ( input_cont_header.get_tg_user_type() == TipoUsuario.SuperUser || 
				       input_cont_header.get_tg_user_type() == TipoUsuario.OperadorConvey ) )
				{
					cod_empresa = "";
				}
				else
				{
					if ( !emp.select_rows_empresa ( cod_empresa ) )
					{
						PublishError ( "Código de Empresa inexistente" );
						return false;
					}
					
					if ( !emp.fetch() )
						return false;
					
					fk_empresa = emp.get_identity();
				}
			}
			
			// ## Confere por cód de loja
			
			if ( cnpj_loja.Length > 0 )
			{
				T_Loja loj = new T_Loja (this);
				
				if ( !loj.select_rows_cnpj ( cnpj_loja ) )
				{
					PublishError ( "CNPJ de Loja inexistente" );
					return false;
				}
				
				if ( !loj.fetch() )
					return false;
				
				fk_loja = loj.get_identity();
			}
			else if ( cod_loja.Length > 0 )
			{
				T_Loja loj = new T_Loja (this);
				
				if ( !loj.select_rows_loja ( cod_loja ) )
				{
					PublishError ( "Código de Loja inexistente" );
					return false;
				}
				
				if ( !loj.fetch() )
					return false;
				
				fk_loja = loj.get_identity();
			}
			
			// ## Busca Relação da loja com Empresa (Convênio)
			
			if ( ( cnpj_loja.Length > 0 || cod_loja.Length > 0 ) && 
			       cod_empresa.Length > 0 )
			{
	            LINK_LojaEmpresa loj_emp = new LINK_LojaEmpresa (this);
	            
	            if ( !loj_emp.select_fk_empresa_loja ( fk_empresa, fk_loja ) )
	            {
	            	PublishError ( "Loja não conveniada com a empresa" );
					return false;
	            }
			}
			
			// ## Confere terminal
			
			if ( st_terminal.Length > 0 )
			{
				T_Terminal term = new T_Terminal (this);
				
				if ( !term.select_rows_terminal ( st_terminal ) )
				{
					PublishError ( "Terminal inexistente" );
					return false;
				}
				
				if ( !term.fetch() )
					return false;
				
				fk_terminal = term.get_identity();
			
				// ## Confere convenio com loja (se preenchida)
				
				if ( fk_empresa.Length > 0 )
				{
					if ( term.get_fk_loja() != fk_empresa )
					{
						PublishError ( "Terminal não residente à loja" );
						return false;
					}					
				}
			}
			
			#endregion
			
			// ## Obtem mais filtros
			
			st_nsu   = input_cont_dct.get_st_nsu();
			nu_parc  = input_cont_dct.get_nu_parcelas();
			en_oper  = input_cont_dct.get_en_oper();
			vr_valor = input_cont_dct.get_vr_valor();
			
			if ( input_cont_dct.get_tg_status() != "-1" )
				en_conf  = input_cont_dct.get_tg_status();
			
			// ## Escolha da query mais vantajosa pela ordem de filtros
			// ## informados
				
			if ( fk_terminal.Length > 0 &&
			     fk_empresa.Length > 0 && 
			     dt_ini.Length > 0  &&
			     dt_fim.Length > 0 )
			{
				// ## Obtem registros com período
				
				if ( !l_tr.select_rows_term_emp_dt ( fk_terminal,
				                                   	fk_empresa,
				                                   	dt_ini,
				                                   	dt_fim ) )
				{
					PublishError ( "Nenhum registro encontrado" );
					return false;
				}
			}
			else if ( fk_terminal.Length > 0 &&
			          fk_empresa.Length > 0 && 
			          dt_ini.Length > 0  )
			{
				// ## Obtem registros com período inicial
				
				if ( !l_tr.select_rows_term_emp_dt_ini ( fk_terminal,
				                                   	fk_empresa,
				                                   	dt_ini ) )
				{
					PublishError ( "Nenhum registro encontrado" );
					return false;
				}
			}
			else if ( fk_terminal.Length > 0 &&
			          fk_empresa.Length > 0 )
			{
				// ## Obtem registros com terminal e empresa
				
				if ( !l_tr.select_fk_term_empresa ( fk_terminal, fk_empresa ) )
				{
					PublishError ( "Nenhum registro encontrado" );
					return false;
				}			
			}
			else if ( dt_ini.Length > 0 && dt_fim.Length > 0 )
			{
				// ## Obtem registro por período de inicio e fim
				
				if ( !l_tr.select_rows_dt ( dt_ini, dt_fim ) )
				{
					PublishError ( "Nenhum registro encontrado" );
					return false;
				}
			}
			else if ( dt_ini.Length > 0 )
			{
				// ## Obtem registro por período de inicio 
				
				if ( !l_tr.select_rows_dt_ini ( dt_ini ) )
				{
					PublishError ( "Nenhum registro encontrado" );
					return false;
				}
			}	
			else if ( fk_empresa.Length > 0 )
			{
				// ## Obtem registros com empresa
				
				if ( !l_tr.select_fk_empresa ( fk_empresa ) )
				{
					PublishError ( "Nenhum registro encontrado" );
					return false;
				}			
			}
			else if ( fk_terminal.Length > 0 )
			{
				// ## Obtem registros com terminal
				
				if ( !l_tr.select_fk_terminal ( fk_terminal ) )
				{
					PublishError ( "Nenhum registro encontrado" );
					return false;
				}			
			}
			else if ( 	nu_parc.Length > 0 &&
				    	en_oper.Length > 0 && 
				    	vr_valor.Length > 0 &&
				        dt_ini.Length > 0 && 
				        dt_fim.Length > 0 )
			{
				// ## Obtem registro por parcelas, operacao, valor
				// ## e por período de inicio e fim
				
				if ( !l_tr.select_rows_par_oper_valor_dt ( nu_parc, 
				                                           en_oper, 
				                                           vr_valor, 
				                                           dt_ini, 
				                                           dt_fim ) )
				{
					PublishError ( "Nenhum registro encontrado" );
					return false;
				}
			}
			else if ( 	nu_parc.Length > 0 &&
				    	en_oper.Length > 0 && 
				    	vr_valor.Length > 0 &&
				        dt_ini.Length > 0  )
			{
				// ## Obtem registro por parcelas, operacao, valor
				// ## e por período de inicio 
				
				if ( !l_tr.select_rows_par_oper_valor_dt_ini ( nu_parc, 
				                                               en_oper, 
				                                               vr_valor, 
				                                               dt_ini ) )
				{
					PublishError ( "Nenhum registro encontrado" );
					return false;
				}
			}
			else if ( 	nu_parc.Length > 0 &&
				    	en_oper.Length > 0 && 
				    	vr_valor.Length > 0 )
			{
				// ## Obtem registro por parcelas, operacao, valor
				
				if ( !l_tr.select_rows_par_oper_valor ( nu_parc, en_oper, vr_valor ) )
				{
					PublishError ( "Nenhum registro encontrado" );
					return false;
				}
			}
			else if ( 	nu_parc.Length > 0 &&
			         	en_oper.Length > 0 )
			{
				// ## Obtem registro por parcelas, operacao
				
				if ( !l_tr.select_rows_parc_oper ( nu_parc, en_oper ) )
				{
					PublishError ( "Nenhum registro encontrado" );
					return false;
				}
			}
			else if ( nu_parc.Length > 0 )
			{
				// ## Obtem registro por parcelas
				
				if ( !l_tr.select_rows_parc ( nu_parc ) )
				{
					PublishError ( "Nenhum registro encontrado" );
					return false;
				}
			}			
			else if ( st_cart_id.Length >  0 )
			{
				// ## Obtem registro por somente determinado cartão 
				
				if ( !l_tr.select_fk_cartao ( st_cart_id ) )
				{
					PublishError ( "NSU inválido" );
					return false;
				}
			}				
			else
			{
				// ## Obtem TODOS os registros
				
				if ( !l_tr.selectAll() )
				{
					PublishError ( "Nenhum registro encontrado" );
					return false;
				}
			}
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_consultaTransacao " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_consultaTransacao " ); 
		
			/// USER [ execute ]

			T_Terminal 	term = new T_Terminal (this);
			T_Cartao	cart = new T_Cartao (this);
			T_Loja      loj  = new T_Loja (this);
			
			StringBuilder sb = new StringBuilder();
			
			int 	i_nu_parc  = 0;
			long 	i_vr_valor = 0;
			
			if ( nu_parc.Length > 0 )
				i_nu_parc = Convert.ToInt32 ( nu_parc );
			
			if ( vr_valor.Length > 0 )
				i_vr_valor = Convert.ToInt64 ( vr_valor );
			
			string nsu = input_cont_dct.get_st_nsu();
			
			Hashtable hshEmpresas = new Hashtable();
			
			#region - para o caso de administrador -
			
			if ( user.get_tg_nivel() == TipoUsuario.Administrador )
			{
				T_Empresa emp_admin = new T_Empresa (this);
				
				if ( emp_admin.select_rows_empresa ( user.get_st_empresa() ) )
				{
					if ( !emp_admin.fetch() )
						return false;
					
					T_Empresa emp_tb = new T_Empresa (this);
					
					// ## Para o caso de empresa administradora de empresas
					
					if ( emp_tb.select_fk_admin ( emp_admin.get_identity() ) )
					{
						while ( emp_tb.fetch() )
						{
							hshEmpresas [ emp_tb.get_identity() ] = "*";
						}
					}					    
				}
			}
			
			#endregion
			
			// ## Busca as transações
			
			SQL_LOGGING_ENABLE = false;
			
			int max_trans = 200;
			
			if ( input_cont_header.get_tg_user_type() == TipoUsuario.SuperUser )
				max_trans = 1000;
				
			while ( l_tr.fetch() )
			{
				// ## Filtro de empresas 
				// ## somente de administradora ou de vinculadas
				
				if ( hshEmpresas.Count > 0 )
					if ( hshEmpresas [ l_tr.get_fk_empresa() ] == null )
						continue;
				
				if ( nsu.Length > 0 )
					if ( l_tr.get_nu_nsu() != nsu )
						continue;
				
				if ( st_cart_id.Length > 0 )
					if ( l_tr.get_fk_cartao() != st_cart_id )
						continue;
				
				if ( nu_parc.Length > 0 )
					if ( l_tr.get_int_nu_parcelas() < i_nu_parc )
						continue;
				
				if ( vr_valor.Length > 0 )
					if ( l_tr.get_int_vr_total() < i_vr_valor )
						continue;
				
				if ( en_oper.Length > 0 )
					if ( l_tr.get_en_operacao() != en_oper )
						continue;
				
				if ( en_conf.Length > 0 )
					if ( l_tr.get_tg_confirmada() != en_conf )
						continue;
				
				if ( fk_empresa.Length > 0 )
					if ( l_tr.get_fk_empresa() != fk_empresa )
						continue;
								
				if ( fk_terminal.Length > 0 )
					if ( l_tr.get_fk_terminal() != fk_terminal )
						continue;
				
				term.Reset();
				loj.Reset();
				cart.Reset();
				
				// ## Busca terminal
				
				term.selectIdentity ( l_tr.get_fk_terminal() );
									
				if ( fk_loja.Length > 0 )
					if ( term.get_fk_loja() != fk_loja )
						continue;
				
				loj.selectIdentity  ( l_tr.get_fk_loja() 	);
				cart.selectIdentity ( l_tr.get_fk_cartao() 	);
				
				// ## Cria registro em memória

				if ( --max_trans == 0 )
				{
					PublishNote ( "Limite máximo de registros excedido" );
					break;
				}
				
				DadosConsultaTransacao dt = new DadosConsultaTransacao ();
							
				dt.set_en_oper			( l_tr.get_en_operacao() 		);
				dt.set_st_nsu			( l_tr.get_nu_nsu() 			);
				
				dt.set_st_cartao		( cart.get_st_empresa()   + "." + 
				                          cart.get_st_matricula() + "." + 
				                          cart.get_st_titularidade() );
								
				dt.set_st_cnpj_loja		( loj.get_st_nome() 			);
				
				dt.set_st_terminal		( term.get_nu_terminal() 		);
				dt.set_vr_valor			( l_tr.get_vr_total() 			);
				dt.set_nu_parcelas		( l_tr.get_nu_parcelas() 		);
				dt.set_dt_transacao		( l_tr.get_dt_transacao() 		);
				dt.set_tg_status		( l_tr.get_tg_confirmada() 		);
				
				dt.set_st_msg_erro		( l_tr.get_st_msg_transacao() + 
				                     	  l_tr.get_st_doc() 			);
				
				DataPortable tmp = dt as DataPortable;
				
				// ## indexa em memória
				
				sb.Append ( MemorySave ( ref tmp ) );
				sb.Append ( "," 				 	  );
			}
			
			SQL_LOGGING_ENABLE = true;
			
			string list_ids = sb.ToString().TrimEnd ( ',' );
			
			if ( list_ids == "" )
			{
				PublishNote ( "Nenhum resultado foi encontrado" );
				return true;
			}
											
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", list_ids );
			
			// ## cria indexador de bloco
						  
			output_st_csv_id = MemorySave ( ref dp );
				
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_consultaTransacao " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_consultaTransacao " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_consultaTransacao " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_CONSULTATRANSACAO.st_csv_id, output_st_csv_id ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
