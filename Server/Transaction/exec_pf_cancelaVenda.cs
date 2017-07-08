using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_pf_cancelaVenda : type_pf_base
	{
		public string input_st_nsu_cancelado = "";
		public string input_st_tel_lojista = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_pf_cancelaVenda ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_pf_cancelaVenda";
			constructor();
		}
		
		public exec_pf_cancelaVenda()
		{
			var_Alias = "exec_pf_cancelaVenda";
		
			ut_max = 0;
			
			constructor();
		}
		
		public override void constructor()
		{
			/// USER [ constructor ]
			
			GravaNSU = true;
			
			var_operacaoCartao 		= OperacaoCartao.PAY_FONE_CANCELA_VENDA;
			var_operacaoCartaoFail 	= OperacaoCartao.FALHA_PAY_FONE_CANCELA_VENDA;
						
			/// USER [ constructor ] END
		}
		
		public override bool setup ( ) 
		{
			#region - SETUP TRANSACTION -
			Registry ( "setup exec_pf_cancelaVenda " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_PF_CANCELAVENDA.st_nsu_cancelado, ref input_st_nsu_cancelado ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_PF_CANCELAVENDA.st_nsu_cancelado missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_PF_CANCELAVENDA.st_tel_lojista, ref input_st_tel_lojista ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_PF_CANCELAVENDA.st_tel_lojista missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_PF_CANCELAVENDA.st_telefone, ref input_st_telefone ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_PF_CANCELAVENDA.st_telefone missing! " ); 
				return false;
			}
			
			Registry ( "setup done exec_pf_cancelaVenda " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_pf_cancelaVenda " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_pf_cancelaVenda " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_pf_cancelaVenda " ); 
		
			/// USER [ execute ]

			// ## Buscar pendência (já confirmada) para cancelamento

			T_PendPayFone pend = new T_PendPayFone ( this );
			
			pend.ExclusiveAccess();
			
			if ( !pend.select_rows_nsu ( input_st_nsu_cancelado ) )
			{
				output_st_codResp 	= "01"; 
				output_st_msg 		= "NSU inválido (" + input_st_nsu_cancelado.TrimStart('0') + ")";
				return false;
			}
			
			if ( !pend.fetch() )
			{
				output_st_codResp 	= "80"; 
				output_st_msg 		= "Erro de aplicativo";
				return false;
			}
			
			// ## Buscar terminal vinculado
			
			term = new T_Terminal (this);
			
			if ( !term.selectIdentity ( pend.get_fk_terminal() ) )
			{
				output_st_codResp = "80"; 
				output_st_msg     = "Erro de aplicativo";
				return false;
			}
			
			var_valorTotal = pend.get_vr_valor();
			
			// ## Buscar lojista pelo terminal usado na pendência
			
			T_PayFone pf_lojista = new T_PayFone (this);
			
			if ( !pf_lojista.select_fk_term ( pend.get_fk_terminal() ) )
			{
				output_st_codResp 	= "05"; 
				output_st_msg 		= "Lojista invalido";
				return false;
			}
			
			// ## Confere se telefones batem
			
			if ( pf_lojista.get_st_telefone() != input_st_tel_lojista )
			{
				output_st_codResp 	= "06"; 
				output_st_msg 		= "Lojista invalido";
			}
			
			// ## Se não estiver confirmado, não pode cancelar
			
			if ( pend.get_en_situacao() != TipoPendPayFone.CONFIRMADO )
			{
				output_st_codResp   = "02"; 
				output_st_msg 	    = "NSU não confirmado " + input_st_nsu_cancelado.TrimStart('0');
				return false;
			}
			
			// ## Se já estiver cancelado, não pode cancelar
			
			if ( pend.get_en_situacao() == TipoPendPayFone.CANCELADO )
			{
				output_st_codResp   = "02"; 
				output_st_msg 	    = "NSU prev. cancelado " + input_st_nsu_cancelado.TrimStart('0');
				return false;
			}
			
			// ## Atribui como cancelado
			
			pend.set_en_situacao ( TipoPendPayFone.CANCELADO );
			
			// ## Atualizar
			
			if ( !pend.synchronize_T_PendPayFone() )
			{
				output_st_codResp   = "80"; 
				output_st_msg       = "Erro de aplicativo";
				return false;
			}
			
			// ## Buscar parcelas de hoje para determinado NSU
			
			T_Parcelas parc = new T_Parcelas (this);
			
			parc.ExclusiveAccess();
			
			if ( !parc.select_rows_nsu ( pend.get_nu_nsu(), 
			                             GetTodayStartTime(), 
			                             GetTodayEndTime() ) )
			{
				output_st_codResp   = "80"; 
				output_st_msg  	 	= "Erro de aplicativo";
				return false;
			}
			
			if ( !parc.fetch() )
			{
				output_st_codResp   = "80"; 
				output_st_msg 		= "Erro de aplicativo";
				return false;
			}
			
			// ## Buscar cartão envolvido
			
			T_Cartao cart = new T_Cartao (this);
			
			cart.ExclusiveAccess();
			
			if ( !cart.selectIdentity ( parc.get_fk_cartao() ) )
			{
				output_st_codResp 	= "80"; 
				output_st_msg 		= "Erro de aplicativo";
				return false;
			}
			
			// ## Se for edu, disponibilizar imediatamente (estorno)
			
			if ( cart.get_tg_tipoCartao() == TipoCartao.educacional )
			{
				long disp = Convert.ToInt64 ( cart.get_vr_disp_educacional() ) + 
							Convert.ToInt64 ( parc.get_vr_valor() );
				
				cart.set_vr_disp_educacional ( disp.ToString() );
			}
			
			// ## Atualiza cartão
			
			if ( !cart.synchronize_T_Cartao() )
			{
				output_st_codResp 	= "80"; 
				output_st_msg 		= "Erro de aplicativo";
				return false;
			}
			
			// ## Atualizar transação original
			
			LOG_Transacoes  tmp_l_tr = new LOG_Transacoes (this);
			
			tmp_l_tr.ExclusiveAccess();
			
			if ( !tmp_l_tr.select_rows_nsu_oper ( 	input_st_nsu_cancelado, 
					                            	OperacaoCartao.PAY_FONE_GRAVA_PEND,
			                                		GetTodayStartTime(),
			                                		GetTodayEndTime() ) )
			{
				output_st_msg = "NSU inválido (" + input_st_nsu_cancelado.TrimStart('0') + ")";
				return false;			
			}
			
			if ( !tmp_l_tr.fetch() )
			{
				output_st_msg = "Erro aplicativo";
				return false;			
			}
			
			// ## Confirma cancelamento
			
			tmp_l_tr.set_tg_contabil   ( Context.TRUE				);
			tmp_l_tr.set_tg_confirmada ( TipoConfirmacao.Cancelada 	);
			
			// ## Atualiza transação
			
			if ( !tmp_l_tr.synchronize_LOG_Transacoes() )
			{
				output_st_msg = "Erro aplicativo";
				return false;
			}	
			
			output_st_codResp = "00"; 
			output_st_msg 	  = "NSU: " + input_st_nsu_cancelado.TrimStart ( '0' );		
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_pf_cancelaVenda " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_pf_cancelaVenda " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done exec_pf_cancelaVenda " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_EXEC_PF_CANCELAVENDA.st_codResp, output_st_codResp ); 
			dp_out.MapTagValue ( COMM_OUT_EXEC_PF_CANCELAVENDA.st_msg, output_st_msg ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
