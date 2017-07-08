using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class web_exec_edu_aplic_fundo : Transaction
	{
		public string input_st_cartao = "";
		public string input_st_senha = "";
		public string input_st_codigo = "";
		public string input_st_valor = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public web_exec_edu_aplic_fundo ( Transaction trans ) : base (trans)
		{
			var_Alias = "web_exec_edu_aplic_fundo";
			constructor();
		}
		
		public web_exec_edu_aplic_fundo()
		{
			var_Alias = "web_exec_edu_aplic_fundo";
		
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
			Registry ( "setup web_exec_edu_aplic_fundo " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_EXEC_EDU_APLIC_FUNDO.st_cartao, ref input_st_cartao ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_EXEC_EDU_APLIC_FUNDO.st_cartao missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_EXEC_EDU_APLIC_FUNDO.st_senha, ref input_st_senha ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_EXEC_EDU_APLIC_FUNDO.st_senha missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_EXEC_EDU_APLIC_FUNDO.st_codigo, ref input_st_codigo ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_EXEC_EDU_APLIC_FUNDO.st_codigo missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_EXEC_EDU_APLIC_FUNDO.st_valor, ref input_st_valor ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_EXEC_EDU_APLIC_FUNDO.st_valor missing! " ); 
				return false;
			}
			
			Registry ( "setup done web_exec_edu_aplic_fundo " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate web_exec_edu_aplic_fundo " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done web_exec_edu_aplic_fundo " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute web_exec_edu_aplic_fundo " ); 
		
			/// USER [ execute ]
			
			#region - busca cartao e empresa - 
			
			input_st_cartao = input_st_cartao.PadLeft ( 14, '0' );
			
			T_Cartao cart = new T_Cartao (this);
			
			cart.ExclusiveAccess();
			
			if ( !cart.select_rows_tudo ( input_st_cartao.Substring (  0,6 ),
			                              input_st_cartao.Substring (  6,6 ),
			                              input_st_cartao.Substring ( 12,2 ) ) )
          	{
				PublishError ( "Cartão inválido" );
				return false;
          	}
			
			if ( !cart.fetch() )
				return false;
			
			if ( cart.get_st_senha() != input_st_senha )
			{
				PublishError ( "Senha aluno inválida" );
				return false;
			}
						
			T_Edu_EmpresaVirtual emp = new T_Edu_EmpresaVirtual (this);
			
			if ( !emp.select_rows_codigo ( input_st_codigo ) )
			{
				PublishError ( "Código inválido" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			#endregion
			
			long val       = Convert.ToInt64 ( input_st_valor 	);		// valor requerido
			long val_emp   = emp.get_int_vr_valorAcao();				// valor da empresa
			long val_acoes = Convert.ToInt64 ( val / val_emp 	);		// arrendonda para numro de acoes
			long val_din   = val_acoes * emp.get_int_vr_valorAcao();	// valor real de compra
			long val_max   = (val_acoes - 1 ) * emp.get_int_vr_valorAcao();
			long virt_calc = cart.get_int_vr_edu_disp_virtual() - val_din - 25;
			
			if ( val_acoes == 0 )
			{
				PublishError ( "Valor mínimo de compra: " + new money().setMoneyFormat ( val_emp ) );
				return false;
			}
			
			if ( virt_calc < 0 )
			{
				// pegar maximo valor possível
				
				long max_virt_calc = cart.get_int_vr_edu_disp_virtual() - 25;
				long max_val_acoes = Convert.ToInt64 ( max_virt_calc / val_emp 	);		
				long max_val_din   = max_val_acoes * emp.get_int_vr_valorAcao();
								
				PublishError ( "Valor máximo " + new money().setMoneyFormat ( max_val_din ) + " excedido" );
				return false;
			}
			
			T_Edu_AplicacaoVirtual app = new T_Edu_AplicacaoVirtual(this);
			
			app.set_vr_preco_fundo ( emp.get_vr_valorAcao() );
			
			app.set_dt_aplic ( 	DateTime.Now.Year.ToString() + "-" + 
			                  	DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + "-" + 
			                  	DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + 
			                  	" 00:00:00" );
			
			app.set_fk_cartao ( cart.get_identity() );
			app.set_fk_empresaVirtual ( emp.get_identity() );
			
			if ( val < 0 )
				app.set_tg_neg ( Context.TRUE );
			else
				app.set_tg_neg ( Context.FALSE );
					
			app.set_vr_aplicado ( val_acoes.ToString().Replace ( "-","" ) );
													
			LINK_Edu_FundoEmpresa lnk_fundo = new LINK_Edu_FundoEmpresa (this);
			
			lnk_fundo.ExclusiveAccess();
			
			if ( !lnk_fundo.select_fk_cart_emp ( cart.get_identity(), emp.get_identity() ) )
			{
				app.set_vr_fundo_hora ( "0" );
				
				if ( val <= 0 )
				{
					PublishError ( "Sem fundos disponíveis para venda" );
					return false;
				}
				
				lnk_fundo.set_fk_cartao 	( cart.get_identity() 	);
				lnk_fundo.set_fk_empresa 	( emp.get_identity() 	);
				lnk_fundo.set_vr_fundo 		( val_acoes.ToString()	);
				
				if ( !lnk_fundo.create_LINK_Edu_FundoEmpresa () )
					return false;
			}
			else
			{
				if ( !lnk_fundo.fetch() )
					return false;
				
				long val_final = lnk_fundo.get_int_vr_fundo() + val_acoes;
				
				app.set_vr_fundo_hora ( lnk_fundo.get_vr_fundo() );
				
				if ( val_final < 0 )
				{
					PublishError ( "Valor de resgate superior ao fundo" );
					return false;
				}
								
				lnk_fundo.set_vr_fundo ( val_final.ToString() );
				
				if ( !lnk_fundo.synchronize_LINK_Edu_FundoEmpresa() )
					return false;
			}
			
			if ( !app.create_T_Edu_AplicacaoVirtual() )
				return false;
					
			cart.set_vr_edu_disp_virtual ( virt_calc.ToString() );
			
			if ( !cart.synchronize_T_Cartao() )
				return false;
						
			/// USER [ execute ] END
		
			Registry ( "execute done web_exec_edu_aplic_fundo " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish web_exec_edu_aplic_fundo " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done web_exec_edu_aplic_fundo " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
