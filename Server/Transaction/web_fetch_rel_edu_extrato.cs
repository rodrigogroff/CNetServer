using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class web_fetch_rel_edu_extrato : Transaction
	{
		public string input_st_cart = "";
		public string input_st_senha = "";
		public string input_st_dt_ini = "";
		public string input_st_dt_fim = "";
		public string input_tg_resp = "";
		
		public string output_st_csv = "";
		public string output_st_total_periodo = "";
		
		/// USER [ var_decl ]
		
		LOG_Transacoes 	l_tr;
		
		string st_cart_id   = "";
		
		/// USER [ var_decl ] END
		
		public web_fetch_rel_edu_extrato ( Transaction trans ) : base (trans)
		{
			var_Alias = "web_fetch_rel_edu_extrato";
			constructor();
		}
		
		public web_fetch_rel_edu_extrato()
		{
			var_Alias = "web_fetch_rel_edu_extrato";
		
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
			Registry ( "setup web_fetch_rel_edu_extrato " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_FETCH_REL_EDU_EXTRATO.st_cart, ref input_st_cart ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_FETCH_REL_EDU_EXTRATO.st_cart missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_FETCH_REL_EDU_EXTRATO.st_senha, ref input_st_senha ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_FETCH_REL_EDU_EXTRATO.st_senha missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_FETCH_REL_EDU_EXTRATO.st_dt_ini, ref input_st_dt_ini ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_FETCH_REL_EDU_EXTRATO.st_dt_ini missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_FETCH_REL_EDU_EXTRATO.st_dt_fim, ref input_st_dt_fim ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_FETCH_REL_EDU_EXTRATO.st_dt_fim missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_FETCH_REL_EDU_EXTRATO.tg_resp, ref input_tg_resp ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_FETCH_REL_EDU_EXTRATO.tg_resp missing! " ); 
				return false;
			}
			
			Registry ( "setup done web_fetch_rel_edu_extrato " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate web_fetch_rel_edu_extrato " ); 
		
			/// USER [ authenticate ]
			
			input_st_cart = input_st_cart.PadLeft ( 14, '0' );
			
			l_tr = new LOG_Transacoes (this);
						
			T_Cartao cart = new T_Cartao (this);			
					
			if ( !cart.select_rows_tudo ( 	input_st_cart.Substring (0,6), 		// empresa
			                            	input_st_cart.Substring (6,6), 		// matricula
			                            	input_st_cart.Substring (12,2) ) )	// titularidade
			{
				PublishError ( "Cartão inválido" );
				return false;
			}
			else
			{
				if ( !cart.fetch() )
					return false;
				
				st_cart_id = cart.get_identity();
				
				if ( input_tg_resp == Context.TRUE )
				{
					T_Proprietario prot = new T_Proprietario (this);
					
					if ( !prot.selectIdentity ( cart.get_fk_dadosProprietario() ) )
						return false;
						
					if ( prot.get_st_senhaEdu() != input_st_senha )
					{
						PublishError ( "Senha de responsável inválida" );
						return false;
					}
				}
				else
				{
					if ( cart.get_st_senha() != input_st_senha )
					{
						PublishError ( "Senha de aluno inválida" );
						return false;
					}
				}
			}
			
			if ( !l_tr.select_rows_dt_cart ( input_st_dt_ini, 
			                               	 input_st_dt_fim, 
			                               	 st_cart_id ) )
			{
				PublishError ( "Nenhum registro encontrado" );
				return false;
			}
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done web_fetch_rel_edu_extrato " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute web_fetch_rel_edu_extrato " ); 
		
			/// USER [ execute ]
			
			StringBuilder sb = new StringBuilder();
			
			long vr_tot = 0;

			T_Terminal term = new T_Terminal (this);
			
			T_Loja loj = new T_Loja (this);	
			
			while ( l_tr.fetch() )
			{
				loj.set_st_nome ( "" );
				
				if ( l_tr.get_tg_contabil() == Context.TRUE )
				{
					if ( l_tr.get_en_operacao() == OperacaoCartao.VENDA_EMPRESARIAL ||  
					     l_tr.get_en_operacao() == OperacaoCartao.PAY_FONE_GRAVA_PEND )
					{
						if ( l_tr.get_tg_confirmada() == TipoConfirmacao.Confirmada )
						{
							vr_tot += l_tr.get_int_vr_total();	
						}
					}
					else if ( l_tr.get_en_operacao() != OperacaoCartao.EDU_DEP_DIARIO    &&
					          l_tr.get_en_operacao() != OperacaoCartao.EDU_DEP_FUNDO     &&
					          l_tr.get_en_operacao() != OperacaoCartao.EDU_DEP_IMEDIATO  )
					{
						continue;
					}
				}
				else
				{
					if ( l_tr.get_en_operacao() != OperacaoCartao.PAY_FONE_CANCELA_VENDA && 
					     l_tr.get_en_operacao() != OperacaoCartao.VENDA_EMPRESARIAL_CANCELA  )
					{
						continue;
					}
				}
				
				EduExtrato etc = new EduExtrato();
				
				etc.set_st_nsu	 	 ( l_tr.get_nu_nsu()				);
				etc.set_dt_trans  	 ( l_tr.get_dt_transacao() 			);
				
				if ( l_tr.get_en_operacao() == OperacaoCartao.VENDA_EMPRESARIAL || 
				     l_tr.get_en_operacao() == OperacaoCartao.PAY_FONE_GRAVA_PEND )
				{
					etc.set_vr_valor 	 ( "-" + l_tr.get_vr_total()  );	
				}
				else
				{
					etc.set_vr_valor ( l_tr.get_vr_total() );
				}
				
				if ( !loj.selectIdentity ( l_tr.get_fk_loja() ) )
				{
					etc.set_st_loja 	 ( "ConveyNET" );
				}
				else
				{
					etc.set_st_loja 	 ( loj.get_st_nome() 				);
				}
				
				etc.set_vr_disp 	( l_tr.get_vr_saldo_disp() 		);
				etc.set_vr_fundo 	( l_tr.get_vr_saldo_disp_tot()	);
				etc.set_en_oper 	( l_tr.get_en_operacao()		);
				    							
				DataPortable mem_rtc = etc as DataPortable;
				
				string index = MemorySave ( ref mem_rtc );
				
				sb.Append ( index );
				sb.Append ( ","   );
			}
			
			// indexa todos os pagamentos
			{
				string list_ids = sb.ToString().TrimEnd ( ',' );
			
				if ( list_ids == "" )
				{
					PublishNote ( "Nenhum registro encontrado" );
					return false;
				}
										
				DataPortable dp = new DataPortable();
				
				dp.setValue ( "ids", list_ids );
				
				// ## Guarda indexador de grupo
							  
				output_st_csv = MemorySave ( ref dp );
			}
			
			output_st_total_periodo = vr_tot.ToString();
			
			if ( output_st_csv == "" )
			{
				PublishNote ( "Nenhum resultado foi encontrado" );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done web_fetch_rel_edu_extrato " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish web_fetch_rel_edu_extrato " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done web_fetch_rel_edu_extrato " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_WEB_FETCH_REL_EDU_EXTRATO.st_csv, output_st_csv ); 
			dp_out.MapTagValue ( COMM_OUT_WEB_FETCH_REL_EDU_EXTRATO.st_total_periodo, output_st_total_periodo ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
