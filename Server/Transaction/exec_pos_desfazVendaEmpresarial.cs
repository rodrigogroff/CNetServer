using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_pos_desfazVendaEmpresarialSITEF : Transaction
	{
		public POS_Entrada input_cont_pe = new POS_Entrada();
		
		public string output_st_msg = "";
		
		public POS_Resposta output_cont_pr = new POS_Resposta();
		
		/// USER [ var_decl ]
		
		LOG_Transacoes l_tr;
		T_Terminal term;
					
		string var_codResp = "0";
		
		/// USER [ var_decl ] END
		
		public exec_pos_desfazVendaEmpresarialSITEF( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_pos_desfazVendaEmpresarialSITEF";
			constructor();
		}
		
		public exec_pos_desfazVendaEmpresarialSITEF()
		{
			var_Alias = "exec_pos_desfazVendaEmpresarialSITEF";
		
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
			Registry ("setup exec_pos_desfazVendaEmpresarialSITEF "); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_EXEC_POS_DESFAZVENDAEMPRESARIAL.pe, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_POS_DESFAZVENDAEMPRESARIAL.pe missing! " ); 
				return false;
			}
			
			input_cont_pe.Import ( ct_0 );
			
			Registry ("setup done exec_pos_desfazVendaEmpresarialSITEF "); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ("authenticate exec_pos_desfazVendaEmpresarialSITEF "); 
		
			/// USER [ authenticate ]
			
			// ## Buscar terminal
			
			term = new T_Terminal (this);
		
			var_codResp = "0606";
			
			if ( !term.select_rows_terminal ( input_cont_pe.get_st_terminal() ) )
			{
				output_st_msg = "Erro aplicativo";
				return false;
			}
			
			if ( !term.fetch() )
			{
				output_st_msg = "Erro aplicativo";
				return false;
			}
			
			// ## Buscar transação pelo terminal e pelo valor
			
			l_tr = new LOG_Transacoes (this);
			
			if ( !l_tr.select_rows_term_vr ( term.get_identity(),
			                                 input_cont_pe.get_vr_valor() ) )
			{
				output_st_msg = "Erro aplicativo";
				return false;
			}
			
			l_tr.SetReversedFetch();
			
			if ( !l_tr.fetch() )
			{
				output_st_msg = "Erro aplicativo";
				return false;
			}
			
			// ## Conferir se status já desfeito
			
			if ( l_tr.get_tg_confirmada() == TipoConfirmacao.Desfeita )
			{
				var_codResp = "N3N3";
				output_st_msg = "Trans. já desfeita";
				return false;
			}
			
			// ## Conferir se status dif de pendente
			
			if ( l_tr.get_tg_confirmada() != TipoConfirmacao.Pendente )
			{
				output_st_msg = "Erro aplicativo";
				return false;
			}
			
			var_codResp = "0000";
								
			/// USER [ authenticate ] END
		
			Registry ("authenticate done exec_pos_desfazVendaEmpresarialSITEF "); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ("execute exec_pos_desfazVendaEmpresarialSITEF "); 
		
			/// USER [ execute ]
			
			// ## Atualizar transação
			
			LOG_Transacoes l_tr_upd = new LOG_Transacoes (this);
			
			l_tr_upd.ExclusiveAccess();
			
			if ( !l_tr_upd.selectIdentity ( l_tr.get_identity() ) )
			{
				output_st_msg = "Erro aplicativo";
				return false;
			}
			
			// ## Setar como desfeita
			
			l_tr_upd.set_tg_confirmada ( TipoConfirmacao.Desfeita );
						
			// ## Atualizar
			
			if ( !l_tr_upd.synchronize_LOG_Transacoes() )
			{
				output_st_msg = "Erro aplicativo";
				return false;
			}
			
			output_cont_pr.set_st_nsuRcb ( l_tr.get_nu_nsu() );
			
			/// USER [ execute ] END
		
			Registry ("execute done exec_pos_desfazVendaEmpresarialSITEF "); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ("finish exec_pos_desfazVendaEmpresarialSITEF "); 
		
			/// USER [ finish ]

			// ## Copiar para saída cod de resposta
			
			LOG_NSU l_nsu = new LOG_NSU (this);
				
			l_nsu.set_dt_log ( GetDataBaseTime() );
			
            l_nsu.create_LOG_NSU();
			
			output_cont_pr.set_st_codResp  ( var_codResp 			);
			output_cont_pr.set_st_nsuBanco ( l_nsu.get_identity() 	);
			
			LOG_Transacoes l_tr_fin = new LOG_Transacoes (this);
			
			#region - registra a transação - 
			
			l_tr_fin.set_fk_terminal		( term.get_identity()						);
			l_tr_fin.set_dt_transacao		( GetDataBaseTime()							);
			
			if ( output_cont_pr.get_st_codResp() == "N3N3" )
				l_tr_fin.set_nu_cod_erro 		( "1313" 								);	
			else
				l_tr_fin.set_nu_cod_erro 		( output_cont_pr.get_st_codResp() 		);
			
			l_tr_fin.set_nu_nsuOrig			( l_tr.get_nu_nsu()							);
			l_tr_fin.set_nu_nsu 			( l_nsu.get_identity() 						);
			l_tr_fin.set_st_msg_transacao	( "Registro: " + l_tr.get_nu_nsu()			);
			l_tr_fin.set_en_operacao		( OperacaoCartao.VENDA_EMPRESARIAL_DESFAZ 	);
			l_tr_fin.set_fk_loja			( term.get_fk_loja()						);
			l_tr_fin.set_tg_confirmada		( TipoConfirmacao.Registro					);
			l_tr_fin.set_tg_contabil 		( Context.FALSE 							);
			l_tr_fin.set_vr_saldo_disp		( l_tr.get_vr_saldo_disp()					);
			l_tr_fin.set_vr_saldo_disp_tot	( l_tr.get_vr_saldo_disp_tot()				);
			l_tr_fin.set_vr_total			( l_tr.get_vr_total()						);
			l_tr_fin.set_fk_empresa			( l_tr.get_fk_empresa()						);
			l_tr_fin.set_fk_loja			( l_tr.get_fk_loja()						);
			l_tr_fin.set_fk_cartao			( l_tr.get_fk_cartao()						);
		
			#endregion
			
			l_tr_fin.create_LOG_Transacoes();		
					
			/// USER [ finish ] END
		
			Registry ("finish done exec_pos_desfazVendaEmpresarialSITEF "); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_EXEC_POS_DESFAZVENDAEMPRESARIAL.st_msg, output_st_msg ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			DataPortable dp_cont_1 = new DataPortable();
		
			dp_cont_1.MapTagContainer ( COMM_OUT_EXEC_POS_DESFAZVENDAEMPRESARIAL.pr , output_cont_pr as DataPortable );
		
			var_Comm.AddExitPortable ( ref dp_cont_1 ); 
		
			return true;
		}
	}
}
