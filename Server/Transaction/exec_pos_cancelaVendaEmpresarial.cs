using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_pos_cancelaVendaEmpresarial : Transaction
	{
		public string input_st_nsu_cancel = "";
		public string input_dt_hoje = "";
		public string input_id_user = "";
		
		public POS_Entrada input_cont_pe = new POS_Entrada();
		
		public string output_st_msg = "";
		
		public POS_Resposta output_cont_pr = new POS_Resposta();
		
		/// USER [ var_decl ]

		LOG_Transacoes old_l_tr;
		T_Cartao       cart;
			
		string var_nu_nsuAtual 			= "0";
		string var_codResp 				= "0";
		string var_operacaoCartao	 	= "0";
		string var_operacaoCartaoFail 	= "0";
		
		public string valor = "0";
		public string dt_orig = "";
				
		/// USER [ var_decl ] END
		
		public exec_pos_cancelaVendaEmpresarial ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_pos_cancelaVendaEmpresarial";
			constructor();
		}
		
		public exec_pos_cancelaVendaEmpresarial()
		{
			var_Alias = "exec_pos_cancelaVendaEmpresarial";
		
			ut_max = 0;
			
			constructor();
		}
		
		public override void constructor()
		{
			/// USER [ constructor ]
			
			var_operacaoCartao     = OperacaoCartao.VENDA_EMPRESARIAL_CANCELA;
			var_operacaoCartaoFail = OperacaoCartao.FALHA_VENDA_EMPRESARIAL_CANCELA;
			
			/// USER [ constructor ] END
		}
		
		public override bool setup ( ) 
		{
			#region - SETUP TRANSACTION -
			Registry ( "setup exec_pos_cancelaVendaEmpresarial " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_POS_CANCELAVENDAEMPRESARIAL.st_nsu_cancel, ref input_st_nsu_cancel ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_POS_CANCELAVENDAEMPRESARIAL.st_nsu_cancel missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_POS_CANCELAVENDAEMPRESARIAL.dt_hoje, ref input_dt_hoje ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_POS_CANCELAVENDAEMPRESARIAL.dt_hoje missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_POS_CANCELAVENDAEMPRESARIAL.id_user, ref input_id_user ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_POS_CANCELAVENDAEMPRESARIAL.id_user missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_POS_CANCELAVENDAEMPRESARIAL.pe, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_POS_CANCELAVENDAEMPRESARIAL.pe missing! " ); 
				return false;
			}
			
			input_cont_pe.Import ( ct_1 );
			
			Registry ( "setup done exec_pos_cancelaVendaEmpresarial " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate exec_pos_cancelaVendaEmpresarial " ); 
		
			/// USER [ authenticate ]
			
			var_codResp = "0606";
				
			cart     = new T_Cartao (this);
			old_l_tr = new LOG_Transacoes (this);
			
			// ## Buscar transação original
			
			old_l_tr.ExclusiveAccess();
			
			if ( input_dt_hoje != "" )
			{
				DateTime start = Convert.ToDateTime ( input_dt_hoje );
				DateTime end   = Convert.ToDateTime ( input_dt_hoje ).AddDays (1);
				
				// ## Buscar transação de NSU com data especifica
				
				if ( !old_l_tr.select_rows_nsu_oper ( 	input_st_nsu_cancel, 
						                           		OperacaoCartao.VENDA_EMPRESARIAL,
				                                		GetDataBaseTime(start),
				                                		GetDataBaseTime(end) ) )
				{
					output_st_msg = "NSU inválido (" + input_st_nsu_cancel.TrimStart('0') + ")";
					var_codResp   = "1212";
					return false;			
				}
			}
			else
			{
				// ## Buscar transação de NSU com data de hoje
				
				if ( !old_l_tr.select_rows_nsu_oper ( 	input_st_nsu_cancel, 
						                           		OperacaoCartao.VENDA_EMPRESARIAL,
				                                		GetTodayStartTime(),
				                                		GetTodayEndTime() ) )
				{
					output_st_msg = "NSU inválido (" + input_st_nsu_cancel.TrimStart('0') + ")";
					var_codResp   = "1212";
					return false;			
				}
			}
			
			if ( !old_l_tr.fetch() )
			{
				output_st_msg = "Erro aplicativo";
				return false;			
			}
			
			valor   = old_l_tr.get_vr_total();
			dt_orig = old_l_tr.get_dt_transacao();
			
			// ## Buscar terminal
			
			T_Terminal term = new T_Terminal (this);
			
			if ( !term.selectIdentity ( old_l_tr.get_fk_terminal() ) )
		    {
				output_st_msg = "Erro aplicativo";
				return false;
		    }

            // ## Caso terminais diferentes, sair

            // desnecessário
            /*
            if (term.get_nu_terminal() != input_cont_pe.get_st_terminal())
            {
                output_st_msg = "Terminal inválido";
                var_codResp = "0303";
                return false;
            }*/
			
			// conferir se usuário que quer cancelar (via client)
			// a transação é da mesma empresa ou 
			// se for lojista, for o mesmo terminal
			
			if ( input_id_user != "" )
			{
				T_Usuario user = new T_Usuario (this);
				
				if ( !user.selectIdentity ( input_id_user ) )
				{
					output_st_msg = "Usuário inválido";
					var_codResp   = "0303";
					return false;	
				}
				
				if ( user.get_tg_nivel() == TipoUsuario.Lojista )
				{
					#region - lojista - 
					
					LINK_UsuarioTerminal lut = new LINK_UsuarioTerminal (this);
					
					if ( !lut.select_fk_term ( term.get_identity() ) )
					{
						output_st_msg = "Usuário inválido";
						var_codResp   = "0303";
						return false;	
					}
					
					if ( !lut.fetch() )
					{
						output_st_msg = "Usuário inválido";
						var_codResp   = "0303";
						return false;	
					}
					
					if ( lut.get_fk_user() != user.get_identity() )
					{
						output_st_msg = "Transação não pertence à sua loja";
						var_codResp   = "0303";
						return false;	
					}
					
					#endregion
				}
				else if ( user.get_tg_nivel() != TipoUsuario.OperadorConvey &&  
				          user.get_tg_nivel() != TipoUsuario.SuperUser  )
				{
					#region - operadores normais - 
										
					T_Empresa emp = new T_Empresa (this);
					
					if ( !emp.select_rows_empresa ( user.get_st_empresa() ) )
					{
						output_st_msg = "Empresa inválida";
						var_codResp   = "0303";
						return false;	
					}
					
					if ( !emp.fetch() )
					{
						output_st_msg = "Empresa inválida";
						var_codResp   = "0303";
						return false;	
					}
				
					if ( old_l_tr.get_fk_empresa() != emp.get_identity() )
					{
						output_st_msg = "Transação não pertence à sua empresa";
						var_codResp   = "0303";
						return false;	
					}
					
					#endregion
				}				
			}
			
			// ## Atualizar cartão
			
			cart.ExclusiveAccess();
			
			if ( !cart.selectIdentity ( old_l_tr.get_fk_cartao() ) )
			{
				output_st_msg = "Erro aplicativo";
				return false;
			}
						
			// ## Se transação já foi cancelada, sair
			
			if ( old_l_tr.get_tg_confirmada() == TipoConfirmacao.Cancelada )
			{
				output_st_msg = "prev. cancel";
				var_codResp   = "N3N3";
				return false;
			}
			
			// ## Confirma cancelamento
			
			old_l_tr.set_tg_contabil   ( Context.TRUE 				);
			old_l_tr.set_tg_confirmada ( TipoConfirmacao.Cancelada 	);
			
			// ## Atualizar transação original
			
			if ( !old_l_tr.synchronize_LOG_Transacoes() )
			{
				output_st_msg = "Erro aplicativo";
				return false;
			}	
			
			var_codResp = "0000";
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_pos_cancelaVendaEmpresarial " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute exec_pos_cancelaVendaEmpresarial " ); 
		
			/// USER [ execute ]

			// ## Buscar parcelas com NSU e data de hoje
			// ## pois somente pode-se cancelar transações no mesmo dia
			
			T_Parcelas parc = new T_Parcelas (this);
			
			if ( !parc.select_rows_nsu ( input_st_nsu_cancel, 
			                             GetTodayStartTime(), 
			                             GetTodayEndTime() ) )
			{
				output_st_msg = "erro aplicativo";
				return false;			
			}
			
			T_Parcelas tmp = new T_Parcelas (this);
			
			while ( parc.fetch() )
			{
				// ## Atualizar parcela
				
				tmp.ExclusiveAccess();
				
				if ( !tmp.selectIdentity ( parc.get_identity() ) )
				{
					output_st_msg = "erro aplicativo";
					return false;			
				}
				
				// ## Se parcela já foi cancelada, sair
				
				if (tmp.get_tg_pago() == TipoParcela.CANCELADA )
				{
					output_st_msg = "prev. cancel";
					return false;			
				}
				
				// ## Se for cartão edu, estornar imediatamente no disponivel
				
				if ( cart.get_tg_tipoCartao() == TipoCartao.educacional )
				{
					long disp = Convert.ToInt64 ( cart.get_vr_disp_educacional() ) + 
								Convert.ToInt64 ( tmp.get_vr_valor() );
				
					cart.set_vr_disp_educacional ( disp.ToString() );
				}	
				else if ( cart.get_tg_tipoCartao() == TipoCartao.presente )
				{
					cart.set_vr_limiteTotal ( cart.get_int_vr_limiteTotal() +  tmp.get_int_vr_valor() );
				}
				
				// ## Atualizar
				
				if ( !tmp.synchronize_T_Parcelas() )
				{
					output_st_msg = "erro aplicativo";
					return false;			
				}
			}
			
			// ## Atualiza cartão
			
			if ( !cart.synchronize_T_Cartao() )
			{
				output_st_msg = "erro aplicativo";
				return false;
			}
			
			output_st_msg = "NSU: " + input_st_nsu_cancel.TrimStart ( '0' );
            var_codResp   = "0000";
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_pos_cancelaVendaEmpresarial " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish exec_pos_cancelaVendaEmpresarial " ); 
		
			/// USER [ finish ]
			
			#region - cria NSU - 
			
			LOG_NSU l_nsu = new LOG_NSU (this);
				
			l_nsu.set_dt_log ( GetDataBaseTime() );
			
            l_nsu.create_LOG_NSU();
            
            #endregion
	            
            var_nu_nsuAtual = l_nsu.get_identity();
            	            
			if ( IsFail )
				var_operacaoCartao = var_operacaoCartaoFail;
			
			T_Empresa 		 emp  = new T_Empresa 		 (this);
			T_Terminal 		 term = new T_Terminal 		 (this);
			T_Loja 			 loj  = new T_Loja 			 (this);
			T_Proprietario	 prot = new T_Proprietario 	 (this);
			T_InfoAdicionais info = new T_InfoAdicionais (this);
			
			// ## Busca outras tabelas
			
			emp.select_rows_empresa ( cart.get_st_empresa() );
			emp.fetch();
			
			term.selectIdentity ( old_l_tr.get_fk_terminal() 		);
			loj.selectIdentity 	( term.get_fk_loja() 				);
			prot.selectIdentity ( cart.get_fk_dadosProprietario() 	);
			info.selectIdentity ( cart.get_fk_infoAdicionais() 		);
			
			// ## Copia dados para saída
						
			output_cont_pr.set_st_codResp 		( var_codResp							);
			output_cont_pr.set_st_nsuRcb 		( var_nu_nsuAtual.PadLeft ( 6, '0' ) 	);
			
			output_cont_pr.set_st_nsuBanco 		( 	new StringBuilder().Append ( DateTime.Now.Year.ToString() 		)
										                               .Append ( DateTime.Now.Month.ToString("00")  )
										                               .Append ( DateTime.Now.Day.ToString("00") 	)
										                               .Append ( var_nu_nsuAtual.PadLeft ( 6, '0')  ).ToString() );
			
			output_cont_pr.set_st_PAN			( cart.get_st_empresa() + 
			                                      cart.get_st_matricula() );
			
			output_cont_pr.set_st_mesPri		( Context.EMPTY  				);
			
			output_cont_pr.set_st_loja 			( loj.get_st_loja() 			);
			output_cont_pr.set_st_nomeCliente 	( prot.get_st_nome() 			);
			
			if ( cart.get_st_titularidade() != "01" && 
			     cart.get_st_titularidade() != "" )
			{
				T_Dependente dep_f = new T_Dependente(this);
					
				if ( dep_f.select_rows_prop_tit ( 	cart.get_fk_dadosProprietario(), 
				                                 	cart.get_st_titularidade() ) )
				{
					if ( dep_f.fetch() )
						output_cont_pr.set_st_nomeCliente ( dep_f.get_st_nome() );
				}
			}
			
			output_cont_pr.set_st_variavel 		( info.get_st_empresaAfiliada() );
			
			// ## Cria nova transacao de registro ou de erro 
			// ## para cancelamento
			
			LOG_Transacoes l_tr = new LOG_Transacoes (this);

			if ( IsFail )
				l_tr.set_tg_confirmada	( TipoConfirmacao.Erro			);
			else
				l_tr.set_tg_confirmada	( TipoConfirmacao.Cancelada		);
			
			l_tr.set_fk_terminal		( term.get_identity()				);
			l_tr.set_fk_empresa			( emp.get_identity()				);
			l_tr.set_fk_cartao			( cart.get_identity()				);
			l_tr.set_vr_total			( old_l_tr.get_vr_total()			);
			l_tr.set_nu_parcelas		( old_l_tr.get_nu_parcelas()		);
			l_tr.set_nu_nsu 			( l_nsu.get_identity()				);
			l_tr.set_dt_transacao		( GetDataBaseTime()					);			
			l_tr.set_nu_cod_erro 		( output_cont_pr.get_st_codResp() 	);
			l_tr.set_nu_nsuOrig			( "0" 								);
			l_tr.set_en_operacao		( var_operacaoCartao				);

            // ajustado
            if (input_cont_pe.get_st_terminalSITEF().Length > 0)
			    l_tr.set_st_msg_transacao(input_cont_pe.get_st_terminalSITEF());
            else
                l_tr.set_st_msg_transacao(output_st_msg);

            l_tr.set_tg_contabil 	  	( Context.FALSE 					);
			l_tr.set_fk_loja			( term.get_fk_loja()				);
			l_tr.set_vr_saldo_disp		( cart.get_vr_disp_educacional()	);
			l_tr.set_vr_saldo_disp_tot	( cart.get_vr_educacional()			);
			
			// ## Cria registro
			
			l_tr.create_LOG_Transacoes();				
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_pos_cancelaVendaEmpresarial " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_EXEC_POS_CANCELAVENDAEMPRESARIAL.st_msg, output_st_msg ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			DataPortable dp_cont_1 = new DataPortable();
		
			dp_cont_1.MapTagContainer ( COMM_OUT_EXEC_POS_CANCELAVENDAEMPRESARIAL.pr , output_cont_pr as DataPortable );
		
			var_Comm.AddExitPortable ( ref dp_cont_1 ); 
		
			return true;
		}
	}
}
