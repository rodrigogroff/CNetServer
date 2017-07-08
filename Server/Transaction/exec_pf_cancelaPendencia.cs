using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_pf_cancelaPendencia : type_pf_base
	{
		public string input_st_nsu_cancelado = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_pf_cancelaPendencia ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_pf_cancelaPendencia";
			constructor();
		}
		
		public exec_pf_cancelaPendencia()
		{
			var_Alias = "exec_pf_cancelaPendencia";
		
			ut_max = 0;
			
			constructor();
		}
		
		public override void constructor()
		{
			/// USER [ constructor ]
			
			GravaNSU = true;
			
			var_operacaoCartao     = OperacaoCartao.PAY_FONE_CANCELA_PEND;
			var_operacaoCartaoFail = OperacaoCartao.FALHA_PAY_FONE_CANCELA_PEND;
						
			/// USER [ constructor ] END
		}
		
		public override bool setup ( ) 
		{
			#region - SETUP TRANSACTION -
			Registry ( "setup exec_pf_cancelaPendencia " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_PF_CANCELAPENDENCIA.st_nsu_cancelado, ref input_st_nsu_cancelado ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_PF_CANCELAPENDENCIA.st_nsu_cancelado missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_PF_CANCELAPENDENCIA.st_telefone, ref input_st_telefone ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_PF_CANCELAPENDENCIA.st_telefone missing! " ); 
				return false;
			}
			
			Registry ( "setup done exec_pf_cancelaPendencia " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_pf_cancelaPendencia " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_pf_cancelaPendencia " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_pf_cancelaPendencia " ); 
		
			/// USER [ execute ]
			
			// ## Busco pendência de payfone pelo NSU informado
			// ## para atualização
			
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
			
			// ## busco terminal vinculado à pendência
			
			if ( !term.selectIdentity ( pend.get_fk_terminal() ) )
			{
				output_st_codResp 	= "80"; 
				output_st_msg 		= "Erro de aplicativo";
				return false;
			}
			
			var_valorTotal = pend.get_vr_valor();
			
			// ## Se pendência tiver sido cancelada ou confirmada, sair
			
			if ( pend.get_en_situacao() != TipoPendPayFone.PENDENTE )
			{
				output_st_codResp 	= "02"; 
				output_st_msg 		= "NSU não pendente (" + input_st_nsu_cancelado.TrimStart('0') + ")";
				return false;
			}
			
			// ## Nego esta pendência (requesição de usuário, não de lojista)
			
			pend.set_en_situacao ( TipoPendPayFone.NEGADO );
			
			// ## Atualizar
			
			if ( !pend.synchronize_T_PendPayFone() )
			{
				output_st_codResp 	= "80"; 
				output_st_msg 		= "Erro de aplicativo";
				return false;
			}
			
			// ## Buscar transação original para atualização
			
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
			
			// ## Atualizar valores
			
			tmp_l_tr.set_tg_contabil   ( Context.FALSE 			);
			tmp_l_tr.set_tg_confirmada ( TipoConfirmacao.Cancelada );
			
			if ( !tmp_l_tr.synchronize_LOG_Transacoes() )
			{
				output_st_msg = "Erro aplicativo";
				return false;
			}	
			
			output_st_codResp 	= "00"; 
			output_st_msg 		= "NSU: " + input_st_nsu_cancelado.TrimStart ( '0' );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_pf_cancelaPendencia " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_pf_cancelaPendencia " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done exec_pf_cancelaPendencia " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_EXEC_PF_CANCELAPENDENCIA.st_codResp, output_st_codResp ); 
			dp_out.MapTagValue ( COMM_OUT_EXEC_PF_CANCELAPENDENCIA.st_msg, output_st_msg ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
