using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_pf_autorizaVendaPendente : type_pf_base
	{
		public string input_st_nsu = "";
		public string input_st_senha = "";
		
		public string output_st_nsu_autorizado = "";
		
		/// USER [ var_decl ]
		
		T_PendPayFone pendPayFone;
		
		/// USER [ var_decl ] END
		
		public exec_pf_autorizaVendaPendente ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_pf_autorizaVendaPendente";
			constructor();
		}
		
		public exec_pf_autorizaVendaPendente()
		{
			var_Alias = "exec_pf_autorizaVendaPendente";
		
			ut_max = 0;
			
			constructor();
		}
		
		public override void constructor()
		{
			/// USER [ constructor ]

			GravaNSU = true;
			
			var_operacaoCartao 		= OperacaoCartao.PAY_FONE_AUTORIZA_VENDA;
			var_operacaoCartaoFail 	= OperacaoCartao.FALHA_PAY_FONE_AUTORIZA_VENDA;
			
			/// USER [ constructor ] END
		}
		
		public override bool setup ( ) 
		{
			#region - SETUP TRANSACTION -
			Registry ( "setup exec_pf_autorizaVendaPendente " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_PF_AUTORIZAVENDAPENDENTE.st_nsu, ref input_st_nsu ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_PF_AUTORIZAVENDAPENDENTE.st_nsu missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_PF_AUTORIZAVENDAPENDENTE.st_senha, ref input_st_senha ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_PF_AUTORIZAVENDAPENDENTE.st_senha missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_PF_AUTORIZAVENDAPENDENTE.st_telefone, ref input_st_telefone ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_PF_AUTORIZAVENDAPENDENTE.st_telefone missing! " ); 
				return false;
			}
			
			Registry ( "setup done exec_pf_autorizaVendaPendente " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_pf_autorizaVendaPendente " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_pf_autorizaVendaPendente " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_pf_autorizaVendaPendente " ); 
		
			/// USER [ execute ]
			
			// ## Busco pendência de acordo com NSU
			
			pendPayFone = new T_PendPayFone ( this );
			
			/*DateTime tim = new DateTime ( DateTime.Now.Year, 
			                              DateTime.Now.Month,
			                              DateTime.Now.Day );
			*/
			
			if ( !pendPayFone.select_rows_nsu ( input_st_nsu 
			                                    /*GetDataBaseTime ( tim ) ,
			                        			GetDataBaseTime ( tim.AddDays(1) )*/ ) )
			{
				output_st_codResp = "01"; 
				output_st_msg     = "Nenhuma pendência (" + input_st_nsu.TrimStart('0') + ")";
				return false;
			}
			
			if ( !pendPayFone.fetch() )
			{
				output_st_codResp = "80"; 
				output_st_msg     = "Erro de aplicativo";
				return false;
			}
			
			// ## Busco terminal de acordo com FK da pendência
			
			if ( !term.selectIdentity ( pendPayFone.get_fk_terminal() ) )
			{
				output_st_codResp 	= "80"; 
				output_st_msg 		= "Erro de aplicativo";
				return false;
			}
			
			var_valorTotal = pendPayFone.get_vr_valor();
			
			Trace ( pendPayFone.get_en_situacao() );
			
			// ## Se sit. já foi confirmada, sair
			
			if ( pendPayFone.get_en_situacao() == TipoPendPayFone.CONFIRMADO )
			{
				output_st_codResp = "03"; 
				output_st_msg     = "NSU Prev. Confirmado (" + input_st_nsu.TrimStart('0') + ")";
				return false;
			}
			
			// ## Se esta pendência já foi cancelada ou negada, sair
			
			if ( pendPayFone.get_en_situacao() == TipoPendPayFone.NEGADO || 
			     pendPayFone.get_en_situacao() == TipoPendPayFone.CANCELADO )
			{
				output_st_codResp = "04"; 
				output_st_msg     = "NSU Prev. Cancelado (" + input_st_nsu.TrimStart('0') + ")";
				return false;
			}
						
			// ## Atualizar senhas
			
			cart.ExclusiveAccess();
			
			// ## Busco o mesmo registro para atualização
            	
        	if ( !cart.selectIdentity ( cart.get_identity() ) )
        		return false;
            
        	// ## Verifico senhas
        	
            if ( cart.get_st_senha() != input_st_senha )
            {
	          	long senhasErradas = cart.get_int_nu_senhaErrada() + 1;
            	
            	cart.set_nu_senhaErrada ( senhasErradas.ToString() );
            	
            	// ## Cinco senhas erradas, bloqueia cartão vinculado ao payfone
            	
            	if ( senhasErradas > 4 )
            	{
            		cart.set_tg_status ( CartaoStatus.Bloqueado );
            	}
            	
            	// ## Atualiza
            	
            	if ( !cart.synchronize_T_Cartao() )
        		{
					output_st_codResp = "80"; 
					output_st_msg 	  = "Erro de aplicativo";
					return false;
				}
            	
            	output_st_codResp = "02"; 
				output_st_msg     = "Senha Errada";
				return false;
            }
            else
            {
            	// ## Zera senhas
            	
            	cart.set_nu_senhaErrada ( Context.NONE );
            	
            	if ( !cart.synchronize_T_Cartao() )
        		{
					output_st_codResp = "80"; 
					output_st_msg 	  = "Erro de aplicativo";
					return false;
				}
            }           
			
			// ## Verifica disponivel mensal nas parcelas
			
            T_Parcelas parc = new T_Parcelas (this);
            
            vr_limMes = cart.get_int_vr_limiteMensal();
			vr_limTot = cart.get_int_vr_limiteTotal() + cart.get_int_vr_extraCota();
				
			new ApplicationUtil().GetSaldoDisponivel ( ref cart, ref vr_limMes, ref vr_limTot );

			// ## Conferir limite mensal
			
			if ( pendPayFone.get_int_vr_valor() > vr_limMes )
			{
				output_st_codResp = "03" ;
				output_st_msg     = "limite mês excedido";            		
        		return false;
			}
			
			// ## Conferir limite total

			if ( pendPayFone.get_int_vr_valor() > vr_limTot )
			{
        		output_st_codResp = "04" ;
				output_st_msg     = "limite total excedido";            		
        		return false;
        	}
			
			// ## Criar as parcelas
				
            T_Parcelas new_parc = new T_Parcelas (this);
			
            #region - atribuição - 
            
			new_parc.set_nu_nsu				( input_st_nsu					);
			new_parc.set_fk_empresa			( emp.get_identity()			);
			new_parc.set_fk_cartao			( cart.get_identity()			);
			new_parc.set_dt_inclusao		( GetDataBaseTime()				);	
			new_parc.set_nu_parcela			( "1"							);
			new_parc.set_nu_tot_parcelas	( "1"							);
			new_parc.set_nu_indice			( "1" 							); 
			new_parc.set_vr_valor			( pendPayFone.get_vr_valor() 	);
			new_parc.set_tg_pago			( TipoParcela.EM_ABERTO			);
			
			#endregion
					
			// ## Buscar terminal
			
			term = new T_Terminal (this);
			
			if ( !term.selectIdentity ( pendPayFone.get_fk_terminal() ) )
			{
				output_st_codResp = "80"; 
				output_st_msg     = "Erro de aplicativo";
				return false;
			}
			
			// ## Atribuir os links corretamente
			
			new_parc.set_fk_loja ( term.get_fk_loja() );
			new_parc.set_fk_terminal ( term.get_identity() );
					
			// ## Confirmo a pendência
			
			pendPayFone.set_en_situacao ( TipoPendPayFone.CONFIRMADO );
			
			// ## Atualizar tabela
			
			if ( !pendPayFone.synchronize_T_PendPayFone() )
			{
				output_st_codResp = "80"; 
				output_st_msg     = "Erro de aplicativo";
				return false;
			}
			
			// ## Busco transação de gravação de pendência do payfone
			
			LOG_Transacoes l_tr = new LOG_Transacoes (this);
			
			l_tr.ExclusiveAccess();
			
			if ( !l_tr.select_rows_nsu_oper ( 	input_st_nsu, 
			                                	OperacaoCartao.PAY_FONE_GRAVA_PEND,
			                                	GetTodayStartTime(),
			                                	GetTodayEndTime() ) )
			{
				output_st_codResp = "80"; 
				output_st_msg     = "Erro de aplicativo";
				return false;
			}
			
			if ( !l_tr.fetch() )
			{
				output_st_codResp = "80"; 
				output_st_msg     = "Erro de aplicativo";
				return false;
			}
			
			output_st_nsu_autorizado = input_st_nsu;
		
			// ## Confirmo esta transação
			
			l_tr.set_tg_contabil   ( Context.TRUE 				);
			l_tr.set_tg_confirmada ( TipoConfirmacao.Confirmada );
			
			// ## Atualizo
			
			if ( !l_tr.synchronize_LOG_Transacoes() ) 
			{
				output_st_codResp = "80"; 
				output_st_msg     = "Erro de aplicativo";
				return false;
			}
			
			// ## Atribuo a minha transação para a parcela criada com payfone
			
			new_parc.set_fk_log_transacoes ( l_tr.get_identity() );
						
			// ## Crio o registro na tabela de parcelas (somente a vista!)
			
			if ( !new_parc.create_T_Parcelas() )
			{
				output_st_codResp = "80";
				output_st_msg     = "Erro de aplicativo";
				return false;
			}
			
			output_st_codResp = "00"; 
			output_st_msg     = "NSU: " + input_st_nsu.TrimStart ( '0' );
				
			/// USER [ execute ] END
		
			Registry ( "execute done exec_pf_autorizaVendaPendente " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_pf_autorizaVendaPendente " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done exec_pf_autorizaVendaPendente " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_EXEC_PF_AUTORIZAVENDAPENDENTE.st_nsu_autorizado, output_st_nsu_autorizado ); 
			dp_out.MapTagValue ( COMM_OUT_EXEC_PF_AUTORIZAVENDAPENDENTE.st_codResp, output_st_codResp ); 
			dp_out.MapTagValue ( COMM_OUT_EXEC_PF_AUTORIZAVENDAPENDENTE.st_msg, output_st_msg ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
