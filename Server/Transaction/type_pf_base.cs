using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class type_pf_base : Transaction
	{
		public string input_st_telefone = "";
		
		public string output_st_codResp = "";
		public string output_st_msg = "";
		
		/// USER [ var_decl ]
		
		public T_PayFone 	pf_usuario;
						
		public LOG_NSU 		l_nsu;
		public T_Terminal 	term;
		public T_Empresa   	emp;
		public T_Cartao 	cart;
		
		public bool GravaNSU = false;
		
		public string var_valorTotal   	     = "0";
		public string var_nsu 		      	 = "0";
		public string var_operacaoCartao 	 = "0";
		public string var_operacaoCartaoFail = "0";
		
		public long vr_limMes, vr_limTot;
		
		/// USER [ var_decl ] END
		
		public type_pf_base ( Transaction trans ) : base (trans)
		{
			var_Alias = "type_pf_base";
			constructor();
		}
		
		public type_pf_base()
		{
			var_Alias = "type_pf_base";
		
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
			Registry ( "setup type_pf_base " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_TYPE_PF_BASE.st_telefone, ref input_st_telefone ) == false ) 
			{
				Trace ( "# COMM_IN_TYPE_PF_BASE.st_telefone missing! " ); 
				return false;
			}
			
			Registry ( "setup done type_pf_base " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate type_pf_base " ); 
		
			/// USER [ authenticate ]
			
			output_st_codResp = "00";
			
			pf_usuario 	= new T_PayFone  (this);
			l_nsu 		= new LOG_NSU	 (this);
			term 		= new T_Terminal (this);
			emp 		= new T_Empresa  (this);
			cart 		= new T_Cartao 	 (this);
			
			if ( !pf_usuario.select_rows_telefone ( input_st_telefone ) )
			{
				output_st_codResp = "99"; 
				output_st_msg     = "Telefone invalido";
				return false;
			}
			
			if ( !pf_usuario.fetch() )
			{
				output_st_codResp = "80"; 
				output_st_msg = "Erro de aplicativo";
				return false;
			}	
			
			if ( !cart.selectIdentity ( pf_usuario.get_fk_cartao() ) )
			{
				output_st_codResp = "90"; 
				output_st_msg = "Cartão invalido";
				return false;
			}
			
			if ( cart.get_tg_status() == CartaoStatus.Bloqueado )
            {
				output_st_codResp = "19";
            	output_st_msg     = "Cartão inválido";
            	return false;
            }
			
			if ( cart.get_tg_tipoCartao() == TipoCartao.empresarial )
			{
				int year  = 2000 + Convert.ToInt32 ( cart.get_st_venctoCartao().Substring ( 2,2 ) );
				int month = Convert.ToInt32 ( cart.get_st_venctoCartao().Substring ( 0,2 ) );
				int day   = 1;
				
	            DateTime tim_venc = new DateTime ( year, month, day );
				
	            if ( tim_venc < DateTime.Now )
				{
					output_st_codResp = "21";
	            	output_st_msg     = "Cartão vencido";
	            	return false;
				}
			}
			
			if ( !emp.select_rows_empresa ( cart.get_st_empresa() ) )
			{
				output_st_codResp = "88"; 
				output_st_msg     = "Empresa invalida";
				return false;
			}
			
			if ( !emp.fetch() )
			{
				output_st_codResp = "80"; 
				output_st_msg     = "Erro de aplicativo";
				return false;
			}
	
            if ( emp.get_tg_blocked() == Context.TRUE )
            {
            	output_st_msg       = "Empresa bloqueada";
            	output_st_codResp   = "0621";            	
            	return false;
            }

			/// USER [ authenticate ] END
		
			Registry ( "authenticate done type_pf_base " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute type_pf_base " ); 
		
			/// USER [ execute ]
			
			if ( GravaNSU )
			{
				l_nsu.set_dt_log ( GetDataBaseTime() );
					
	            if ( !l_nsu.create_LOG_NSU() )
	            {
					output_st_codResp = "80"; 
					output_st_msg = "Erro de aplicativo";
					return false;
				}
	            
	            var_nsu = l_nsu.get_identity();
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done type_pf_base " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish type_pf_base " ); 
		
			/// USER [ finish ]

			if ( IsFail )
				var_operacaoCartao = var_operacaoCartaoFail;
			
			if ( GravaNSU )
			{
				LOG_Transacoes l_tr = new LOG_Transacoes (this);
				
				l_tr.set_fk_terminal	( term.get_identity()					);
				l_tr.set_fk_empresa		( emp.get_identity()					);
				l_tr.set_fk_cartao		( cart.get_identity()					);
				
				l_tr.set_vr_total		( var_valorTotal						);
				l_tr.set_nu_nsu 		( var_nsu			 					);
				l_tr.set_en_operacao	( var_operacaoCartao					);
				
				l_tr.set_nu_cod_erro 	( output_st_codResp						);
				
				l_tr.set_nu_parcelas	( "1"									); 
				l_tr.set_nu_nsuOrig		( Context.NOT_SET 						);
								
				if ( var_operacaoCartao == OperacaoCartao.PAY_FONE_GRAVA_PEND )
				{
					l_tr.set_tg_confirmada	( TipoConfirmacao.Pendente		);
				}
				else
				{
					if ( IsFail )
						l_tr.set_tg_confirmada	( TipoConfirmacao.Erro		);
					else
						l_tr.set_tg_confirmada	( TipoConfirmacao.Registro		);
				}
	
				l_tr.set_dt_transacao		( GetDataBaseTime()		);
				l_tr.set_st_msg_transacao 	( output_st_msg 		);
				l_tr.set_tg_contabil 	  	( Context.FALSE 		);
				
				if ( output_st_codResp != "00" )
					l_tr.set_tg_contabil  ( Context.FALSE );
				
				l_tr.set_fk_loja	( term.get_fk_loja()	);
				
				if ( cart.get_tg_tipoCartao() == TipoCartao.educacional )
				{
					l_tr.set_vr_saldo_disp		( cart.get_vr_disp_educacional()	);
					l_tr.set_vr_saldo_disp_tot	( cart.get_vr_educacional()			);
				}
				else
				{
					l_tr.set_vr_saldo_disp		( vr_limMes.ToString()	);
					l_tr.set_vr_saldo_disp_tot	( vr_limTot.ToString()	);
				}
				
				if ( !l_tr.create_LOG_Transacoes() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done type_pf_base " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
