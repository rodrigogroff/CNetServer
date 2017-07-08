using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_pos_confirmaVendaEmpresarial : Transaction
	{
		public string input_st_nsu = "";
		
		public POS_Entrada input_cont_pe = new POS_Entrada();
		
		public string output_st_msg = "";
		
		public POS_Resposta output_cont_pr = new POS_Resposta();
		
		/// USER [ var_decl ]
		
		LOG_Transacoes old_l_tr;
		T_Cartao cart;
			
		string var_nu_nsuAtual 			= "0";
		string var_codResp 				= "0";
		string var_operacaoCartao	 	= "0";
		string var_operacaoCartaoFail 	= "0";
		
		/// USER [ var_decl ] END
		
		public exec_pos_confirmaVendaEmpresarial ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_pos_confirmaVendaEmpresarial";
			constructor();
		}
		
		public exec_pos_confirmaVendaEmpresarial()
		{
			var_Alias = "exec_pos_confirmaVendaEmpresarial";
		
			ut_max = 0;
			
			constructor();
		}
		
		public override void constructor()
		{
			/// USER [ constructor ]
			
			var_operacaoCartao     = OperacaoCartao.CONF_VENDA_EMP;
			var_operacaoCartaoFail = OperacaoCartao.FALHA_CONF_VENDA_EMP;
			
			/// USER [ constructor ] END
		}
		
		public override bool setup ( ) 
		{
			#region - SETUP TRANSACTION -
			Registry ( "setup exec_pos_confirmaVendaEmpresarial " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_POS_CONFIRMAVENDAEMPRESARIAL.st_nsu, ref input_st_nsu ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_POS_CONFIRMAVENDAEMPRESARIAL.st_nsu missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_POS_CONFIRMAVENDAEMPRESARIAL.pe, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_POS_CONFIRMAVENDAEMPRESARIAL.pe missing! " ); 
				return false;
			}
			
			input_cont_pe.Import ( ct_1 );
			
			Registry ( "setup done exec_pos_confirmaVendaEmpresarial " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate exec_pos_confirmaVendaEmpresarial " ); 
		
			/// USER [ authenticate ]

			input_st_nsu = input_st_nsu.PadLeft ( 6, '0' );
			
			old_l_tr = new LOG_Transacoes (this); 
			
			old_l_tr.ExclusiveAccess();
			
			// ## Busca NSU de hoje para
			// ## confirmação de cancelamento
			
			if ( !old_l_tr.select_rows_nsu_oper ( 	input_st_nsu, 
					                             	OperacaoCartao.VENDA_EMPRESARIAL,
			                                		GetTodayStartTime(),
			                                		GetTodayEndTime() ) )
			{
				output_st_msg      = "NSU inválido (" + input_st_nsu.TrimStart('0') + ")";
		    	return false;
			}
		    	
			if ( !old_l_tr.fetch() )
				return false;
			
			// ## Busca cartão envolvido na transação
			
			cart = new T_Cartao (this);
			
			cart.ExclusiveAccess();
			
			if ( !cart.selectIdentity ( old_l_tr.get_fk_cartao() ) )
				return false;
			
			var_nu_nsuAtual = input_st_nsu;
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_pos_confirmaVendaEmpresarial " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute exec_pos_confirmaVendaEmpresarial " ); 
		
			/// USER [ execute ]
			
			// ## Confirmo transação original
			
			old_l_tr.set_tg_confirmada ( TipoConfirmacao.Confirmada );

			// ## Cálculo de disponível
			
			long disp = old_l_tr.get_int_vr_saldo_disp() - 
				        old_l_tr.get_int_vr_total();
			
			// ## No caso de cartão educacional, descontar valor do disponível
						
			if ( cart.get_tg_tipoCartao() == TipoCartao.educacional )
			{
				cart.set_vr_disp_educacional ( disp.ToString() );
			}
					
			// ## Contabilizo valor disp na transação (para extratos)
			
			old_l_tr.set_vr_saldo_disp  ( disp.ToString() );
			
			// ## Atualizo transação
			
			if ( !old_l_tr.synchronize_LOG_Transacoes() )
				return false;
			
			// ## Atualizo cartão
			
			if ( !cart.synchronize_T_Cartao() )
				return false;
			
			output_st_msg = "Confirmação";
			var_codResp   = "0000";
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_pos_confirmaVendaEmpresarial " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish exec_pos_confirmaVendaEmpresarial " ); 
		
			/// USER [ finish ]
			
            var_nu_nsuAtual = old_l_tr.get_identity();
            	            
			if ( IsFail )
				var_operacaoCartao = var_operacaoCartaoFail;
			
			// ## Buscar todas as tabelas auxiliares
			
			T_Empresa 		 emp  = new T_Empresa 		 (this);
			T_Terminal 		 term = new T_Terminal 		 (this);
			T_Loja 			 loj  = new T_Loja 			 (this);
			T_Proprietario	 prot = new T_Proprietario 	 (this);
			T_InfoAdicionais info = new T_InfoAdicionais (this);
			
			if ( emp.select_rows_empresa ( cart.get_st_empresa() ) )
				emp.fetch();
			
			term.selectIdentity ( old_l_tr.get_fk_terminal() 		);
			loj.selectIdentity 	( term.get_fk_loja() 				);
			prot.selectIdentity ( cart.get_fk_dadosProprietario() 	);
			info.selectIdentity ( cart.get_fk_infoAdicionais() 		);
			
			// ## Copiar dados para saída
						
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
			
			T_Dependente dep_f = new T_Dependente(this);
					
			if ( dep_f.select_rows_prop_tit ( 	cart.get_fk_dadosProprietario(), 
			                                 	cart.get_st_titularidade() ) )
			{
				if ( dep_f.fetch() )
					output_cont_pr.set_st_nomeCliente ( dep_f.get_st_nome() );
			}
			
			output_cont_pr.set_st_variavel 		( info.get_st_empresaAfiliada() );
						
			/// USER [ finish ] END
		
			Registry ( "finish done exec_pos_confirmaVendaEmpresarial " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_EXEC_POS_CONFIRMAVENDAEMPRESARIAL.st_msg, output_st_msg ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			DataPortable dp_cont_1 = new DataPortable();
		
			dp_cont_1.MapTagContainer ( COMM_OUT_EXEC_POS_CONFIRMAVENDAEMPRESARIAL.pr , output_cont_pr as DataPortable );
		
			var_Comm.AddExitPortable ( ref dp_cont_1 ); 
		
			return true;
		}
	}
}
