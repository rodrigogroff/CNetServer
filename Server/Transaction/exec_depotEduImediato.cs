using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_depotEduImediato : type_base
	{
		public string input_st_pass = "";
		public string input_vr_valor = "";
		public string input_st_valor_imediato = "";
		public string input_st_empresa = "";
		public string input_st_cartao = "";
		
		/// USER [ var_decl ]
		
		T_Cartao cart;
		
		/// USER [ var_decl ] END
		
		public exec_depotEduImediato ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_depotEduImediato";
			constructor();
		}
		
		public exec_depotEduImediato()
		{
			var_Alias = "exec_depotEduImediato";
		
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
			Registry ( "setup exec_depotEduImediato " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_DEPOTEDUIMEDIATO.st_pass, ref input_st_pass ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_DEPOTEDUIMEDIATO.st_pass missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_DEPOTEDUIMEDIATO.vr_valor, ref input_vr_valor ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_DEPOTEDUIMEDIATO.vr_valor missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_DEPOTEDUIMEDIATO.st_valor_imediato, ref input_st_valor_imediato ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_DEPOTEDUIMEDIATO.st_valor_imediato missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_DEPOTEDUIMEDIATO.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_DEPOTEDUIMEDIATO.st_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_DEPOTEDUIMEDIATO.st_cartao, ref input_st_cartao ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_DEPOTEDUIMEDIATO.st_cartao missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_DEPOTEDUIMEDIATO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_DEPOTEDUIMEDIATO.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_depotEduImediato " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_depotEduImediato " ); 
		
			/// USER [ authenticate ]
			
			// ## Confere senha
			
			if ( user.get_st_senha() != input_st_pass )
			{
				PublishError ( "Autorização inválida" );
				return false;
			}
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_depotEduImediato " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_depotEduImediato " ); 
		
			/// USER [ execute ]
			
			// ## Busca cartão específico
			
			cart = new T_Cartao (this);
			
			cart.ExclusiveAccess();
			
			if ( !cart.select_rows_tudo ( input_st_empresa, input_st_cartao, "01" ) )
          	{
				PublishError ( "Cartão inválido" );
				return false;
          	}
			
			if ( !cart.fetch() )
				return false;		
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_depotEduImediato " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_depotEduImediato " ); 
		
			/// USER [ finish ]

			// ## Se falhou o authenticate (senha) não faz nada
			
			if ( IsFail )
				return true;
			
			// ## Busca empresa conveniada
				
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_st_empresa ) )
				return false;
			
			if ( !emp.fetch() )
				return false;
			
			if ( Convert.ToInt64 ( input_vr_valor ) > 0 )
			{
				// ## Atualiza valor atual do FUNDO EDUCACIONAL 
				
				cart.set_vr_educacional 	 ( ( cart.get_int_vr_educacional()      
				                              + Convert.ToInt64 ( input_vr_valor ) ).ToString() );
				
				#region - obtem nsu - 
				
				LOG_NSU l_nsu = new LOG_NSU (this);
				
				l_nsu.set_dt_log ( GetDataBaseTime() );
					
	            if ( !l_nsu.create_LOG_NSU() )
	        		return false;
	            
	            #endregion
	            
	            string var_nu_nsuAtual = l_nsu.get_identity();
				
				// ## Cria transação representando este depósito
	
				LOG_Transacoes l_tr = new LOG_Transacoes (this);
				
				l_tr.set_fk_terminal		( "0"								);
				l_tr.set_fk_empresa			( emp.get_identity()				);
				l_tr.set_fk_cartao			( cart.get_identity()				);
				
				l_tr.set_vr_total			( ( Convert.ToInt64 ( input_vr_valor ) ).ToString() );
				
				l_tr.set_nu_parcelas		( "1"								);
				l_tr.set_nu_nsu 			( var_nu_nsuAtual	 				);
				l_tr.set_dt_transacao		( GetDataBaseTime()					);
				l_tr.set_nu_cod_erro 		( "0"								);
				l_tr.set_tg_confirmada		( TipoConfirmacao.Confirmada		);
				l_tr.set_nu_nsuOrig			( "0" 								);
				l_tr.set_en_operacao		( OperacaoCartao.EDU_DEP_FUNDO	 	);
				l_tr.set_st_msg_transacao 	( "" 								);
				l_tr.set_tg_contabil 	  	( Context.TRUE 						);				
				l_tr.set_fk_loja			( "0"								);
			
				l_tr.set_vr_saldo_disp		( cart.get_vr_disp_educacional()  	);
				l_tr.set_vr_saldo_disp_tot	( cart.get_vr_educacional()			);
				
				if ( !l_tr.create_LOG_Transacoes() )
					return false;
			}
						
			if ( Convert.ToInt64 ( input_st_valor_imediato ) > 0 )
			{
				// ## Atualiza valor atual do DISPONIVEL IMEDIATO
				
				cart.set_vr_disp_educacional ( ( cart.get_int_vr_disp_educacional() + 
				                                 Convert.ToInt64 ( input_st_valor_imediato ) ).ToString() );
				
				#region - obtem nsu - 
				
				LOG_NSU l_nsu = new LOG_NSU (this);
				
				l_nsu.set_dt_log ( GetDataBaseTime() );
					
	            if ( !l_nsu.create_LOG_NSU() )
	        		return false;
	            
	            #endregion
	            
	            string var_nu_nsuAtual    = l_nsu.get_identity();
				
				// ## Cria transação representando este depósito 
				
				LOG_Transacoes l_tr = new LOG_Transacoes (this);
	
				l_tr.set_fk_terminal		( "0"								);
				l_tr.set_fk_empresa			( emp.get_identity()				);
				l_tr.set_fk_cartao			( cart.get_identity()				);
				
				l_tr.set_vr_total			( ( Convert.ToInt64 ( input_st_valor_imediato ) ).ToString() );
				
				l_tr.set_nu_parcelas		( "1"								);
				l_tr.set_nu_nsu 			( var_nu_nsuAtual	 				);
				l_tr.set_dt_transacao		( GetDataBaseTime()					);
				l_tr.set_nu_cod_erro 		( "0"								);
				l_tr.set_tg_confirmada		( TipoConfirmacao.Confirmada		);
				l_tr.set_nu_nsuOrig			( "0" 								);
				l_tr.set_en_operacao		( OperacaoCartao.EDU_DEP_IMEDIATO 	);
				l_tr.set_st_msg_transacao 	( "" 								);
				l_tr.set_tg_contabil 	  	( Context.TRUE 						);				
				l_tr.set_fk_loja			( "0"								);
				l_tr.set_vr_saldo_disp		( cart.get_vr_disp_educacional()  );
				l_tr.set_vr_saldo_disp_tot	( cart.get_vr_educacional()			);
				
				if ( !l_tr.create_LOG_Transacoes() )
					return false;
			}
			
			// ## Atualiza tabela
						
			if ( !cart.synchronize_T_Cartao() )
				return false;
			
			PublishNote ( "Carga efetuada com sucesso" );
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_depotEduImediato " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
