using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_rel_edu_extrato : type_base
	{
		public string input_st_dt_ini = "";
		public string input_st_dt_fim = "";
		public string input_st_emp = "";
		public string input_st_mat = "";
		
		public string output_st_csv = "";
		public string output_st_empresa = "";
		public string output_st_total_periodo = "";
		
		/// USER [ var_decl ]
		
		LOG_Transacoes 	l_tr;
		
		string st_cart_id   = "";
		
		/// USER [ var_decl ] END
		
		public fetch_rel_edu_extrato ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_rel_edu_extrato";
			constructor();
		}
		
		public fetch_rel_edu_extrato()
		{
			var_Alias = "fetch_rel_edu_extrato";
		
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
			Registry ( "setup fetch_rel_edu_extrato " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_EDU_EXTRATO.st_dt_ini, ref input_st_dt_ini ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_EDU_EXTRATO.st_dt_ini missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_EDU_EXTRATO.st_dt_fim, ref input_st_dt_fim ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_EDU_EXTRATO.st_dt_fim missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_EDU_EXTRATO.st_emp, ref input_st_emp ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_EDU_EXTRATO.st_emp missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_EDU_EXTRATO.st_mat, ref input_st_mat ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_EDU_EXTRATO.st_mat missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_REL_EDU_EXTRATO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_REL_EDU_EXTRATO.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_rel_edu_extrato " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_rel_edu_extrato " ); 
		
			/// USER [ authenticate ]
			
						
			T_Cartao cart = new T_Cartao (this);			
					
			if ( !cart.select_rows_tudo ( 	input_st_emp, 		// empresa
			                            	input_st_mat, 		// matricula
			                            	"01" ) )	// titularidade
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
			
			// ## Busca todas transações do cartão no período
			
			l_tr = new LOG_Transacoes (this);
			
			if ( !l_tr.select_rows_dt_cart ( input_st_dt_ini,
			                               	 input_st_dt_fim, 
			                               	 st_cart_id ) )
			{
				PublishError ( "Nenhum registro encontrado" );
				return false;
			}
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_rel_edu_extrato " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_rel_edu_extrato " ); 
		
			/// USER [ execute ]

			T_Terminal term = new T_Terminal (this);
			T_Loja loj = new T_Loja (this);	
			
			StringBuilder sb = new StringBuilder();
			
			long vr_tot = 0;
			
			// ## Busca registros
			
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
							// ## Contabilizar em total
							
							vr_tot += l_tr.get_int_vr_total();	
						}
					}
					else if ( l_tr.get_en_operacao() != OperacaoCartao.EDU_DEP_DIARIO    &&
					          l_tr.get_en_operacao() != OperacaoCartao.EDU_DEP_FUNDO     &&
					          l_tr.get_en_operacao() != OperacaoCartao.EDU_DEP_IMEDIATO  )
					{
						// ## desprezar
						
						continue;
					}
				}
				else
				{
					if ( l_tr.get_en_operacao() != OperacaoCartao.PAY_FONE_CANCELA_VENDA && 
					     l_tr.get_en_operacao() != OperacaoCartao.VENDA_EMPRESARIAL_CANCELA  )
					{
						// ## desprezar
						
						continue;
					}
				}
				
				// ## Guardar este registro em memória
				
				EduExtrato etc = new EduExtrato();
				
				etc.set_st_nsu	 	 ( l_tr.get_nu_nsu()				);
				etc.set_dt_trans  	 ( l_tr.get_dt_transacao() 			);
				
				if ( l_tr.get_en_operacao() == OperacaoCartao.VENDA_EMPRESARIAL || 
				     l_tr.get_en_operacao() == OperacaoCartao.PAY_FONE_GRAVA_PEND )
				{
					// ## débito
					
					etc.set_vr_valor 	 ( "-" + l_tr.get_vr_total()  );	
				}
				else
				{
					// ## depósito
					
					etc.set_vr_valor ( l_tr.get_vr_total() );
				}
				
				// ## Busca loja
				
				if ( !loj.selectIdentity ( l_tr.get_fk_loja() ) )
				{
					// ## depósito automático de conversão de fundo ao disponivel
					
					etc.set_st_loja 	 ( "ConveyNET" );
				}
				else
				{
					etc.set_st_loja 	 ( loj.get_st_nome() 				);
				}
				
				etc.set_vr_disp 	 ( l_tr.get_vr_saldo_disp() 		);
				etc.set_vr_fundo 	 ( l_tr.get_vr_saldo_disp_tot()		);
				
				etc.set_en_oper 	 ( l_tr.get_en_operacao()			);
				    							
				DataPortable mem_rtc = etc as DataPortable;
				
				// ## Gera identificador
				
				sb.Append ( MemorySave ( ref mem_rtc ) );
				sb.Append ( ","   );
			}
			
			string list_ids = sb.ToString().TrimEnd ( ',' );
									
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", list_ids );
						 
			// # Guarda todos os registros
			
			output_st_csv = MemorySave ( ref dp );
			
			T_Empresa  emp = new T_Empresa (this);
			
			// ## Busca empresa
			
			if ( emp.select_rows_empresa ( input_st_emp ) )
				if ( !emp.fetch() )
					return false;
				
			output_st_empresa = emp.get_st_fantasia();
			
			output_st_total_periodo = vr_tot.ToString();
			
			if ( output_st_csv == "" )
			{
				PublishNote ( "Nenhum resultado foi encontrado" );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_rel_edu_extrato " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_rel_edu_extrato " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_rel_edu_extrato " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_EDU_EXTRATO.st_csv, output_st_csv ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_EDU_EXTRATO.st_empresa, output_st_empresa ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_EDU_EXTRATO.st_total_periodo, output_st_total_periodo ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
