using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class web_fetch_edu_virtual : Transaction
	{
		public string input_st_cartao = "";
		public string input_st_senha = "";
		public string input_dt_mov = "";
		
		public DadosCartaoEdu output_cont_dce = new DadosCartaoEdu();
		
		public ArrayList output_array_generic_lst = new ArrayList(); 
		public ArrayList output_array_generic_lstEmp = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public web_fetch_edu_virtual ( Transaction trans ) : base (trans)
		{
			var_Alias = "web_fetch_edu_virtual";
			constructor();
		}
		
		public web_fetch_edu_virtual()
		{
			var_Alias = "web_fetch_edu_virtual";
		
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
			Registry ( "setup web_fetch_edu_virtual " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_FETCH_EDU_VIRTUAL.st_cartao, ref input_st_cartao ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_FETCH_EDU_VIRTUAL.st_cartao missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_FETCH_EDU_VIRTUAL.st_senha, ref input_st_senha ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_FETCH_EDU_VIRTUAL.st_senha missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_FETCH_EDU_VIRTUAL.dt_mov, ref input_dt_mov ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_FETCH_EDU_VIRTUAL.dt_mov missing! " ); 
				return false;
			}
			
			Registry ( "setup done web_fetch_edu_virtual " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate web_fetch_edu_virtual " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done web_fetch_edu_virtual " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute web_fetch_edu_virtual " ); 
		
			/// USER [ execute ]
			
			input_st_cartao = input_st_cartao.PadLeft ( 14, '0' );
			input_dt_mov    = input_dt_mov.Substring ( 0, 11 ) + "00:00:00";
			
			T_Cartao cart = new T_Cartao (this);
			
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
						
			output_cont_dce.set_st_aluno  		( cart.get_st_aluno() 				);
			output_cont_dce.set_vr_diario 		( cart.get_vr_edu_diario() 			);
			output_cont_dce.set_vr_disp   		( cart.get_vr_disp_educacional() 	);
			output_cont_dce.set_vr_depot  		( cart.get_vr_educacional() 		);
			output_cont_dce.set_vr_disp_virtual ( cart.get_vr_edu_disp_virtual() 	);
			output_cont_dce.set_nu_vrRank	 	( cart.get_nu_rankVirtual() 		);
					
			long invest_virtual = 0;
			
			LINK_Edu_FundoEmpresa  		lnk 		= new LINK_Edu_FundoEmpresa 	(this);
			T_Edu_EmpresaVirtual 		emp 		= new T_Edu_EmpresaVirtual 		(this);
			LOG_Edu_RendimentoEmpresa	log_rend	= new LOG_Edu_RendimentoEmpresa (this);
			
			T_Edu_AplicacaoVirtual app = new T_Edu_AplicacaoVirtual (this);
			
			if ( lnk.select_fk_cart ( cart.get_identity() ) )
			{
				while ( lnk.fetch() )
				{
					DadosMovEmpresaVirtual dMovAtual = new DadosMovEmpresaVirtual();
					
					if ( !emp.selectIdentity ( lnk.get_fk_empresa() ) )
						return false;

					dMovAtual.set_st_nome		( emp.get_st_nome()			);
					dMovAtual.set_vr_acoes 		( lnk.get_vr_fundo()		);
					dMovAtual.set_vr_dia 		( emp.get_vr_valorAcao()	);
					
					invest_virtual += lnk.get_int_vr_fundo() * emp.get_int_vr_valorAcao();
					
					if ( log_rend.select_rows_date ( GetDataBaseTime(), emp.get_identity() ) )
					{
						if ( !log_rend.fetch() )
							return false;
						
						if ( log_rend.get_tg_neg() == Context.TRUE )
							dMovAtual.set_vr_osc ( "-" + log_rend.get_vr_pct() );
						else
							dMovAtual.set_vr_osc ( log_rend.get_vr_pct() );
					}
					
					//  busca preço médio
					long preco_medio = 0;
					
					if ( app.select_rows_cart_emp ( cart.get_identity(), emp.get_identity() ) )
					{
						while ( app.fetch() )
						{
							preco_medio += app.get_int_vr_preco_fundo();
						}
						
						preco_medio = preco_medio / app.RowCount();
						
						app.Reset();
					}
					
					dMovAtual.set_vr_preco_medio ( preco_medio.ToString() );
	        		
	        		output_array_generic_lstEmp.Add ( dMovAtual );
				}
			}
			
			if ( lnk.select_fk_cart ( cart.get_identity() ) )
			{
				while ( lnk.fetch() )
				{
					if ( !emp.selectIdentity ( lnk.get_fk_empresa() ) )
						return false;
					
					long aplic = 0;
									
					if ( app.select_rows_date ( input_dt_mov, cart.get_identity() ) )
					{
						while ( app.fetch() )
						{
							if ( app.get_fk_empresaVirtual() != lnk.get_fk_empresa() )
								continue;
							
							DadosMovEmpresaVirtual dMov = new DadosMovEmpresaVirtual();
					
							dMov.set_st_nome		( emp.get_st_nome()			);
							
							if ( app.get_tg_neg() == Context.TRUE )
							{
								dMov.set_vr_mov_fundo	( "-" + app.get_vr_aplicado()		);
								aplic -= app.get_int_vr_aplicado();
								
								dMov.set_vr_total ( ( Convert.ToInt64 ( app.get_vr_fundo_hora() ) -
							                      Convert.ToInt64 ( app.get_vr_aplicado() ) ).ToString() );
							}
							else
							{
								dMov.set_vr_mov_fundo	( app.get_vr_aplicado()		);
								aplic += app.get_int_vr_aplicado();
								
								dMov.set_vr_total ( ( Convert.ToInt64 ( app.get_vr_fundo_hora() ) + 
							                      Convert.ToInt64 ( app.get_vr_aplicado() ) ).ToString() );
							}
							
                    		output_array_generic_lst.Add ( dMov );
						}
					}
				}
			}					
				
			output_cont_dce.set_vr_invest_virtual 	( invest_virtual.ToString() );			
									
			/// USER [ execute ] END
		
			Registry ( "execute done web_fetch_edu_virtual " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish web_fetch_edu_virtual " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done web_fetch_edu_virtual " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_cont_1 = new DataPortable();
		
			dp_cont_1.MapTagContainer ( COMM_OUT_WEB_FETCH_EDU_VIRTUAL.dce , output_cont_dce as DataPortable );
		
			var_Comm.AddExitPortable ( ref dp_cont_1 ); 
		
			DataPortable dp_array_generic_lst = new DataPortable();
			DataPortable dp_array_generic_lstEmp = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_WEB_FETCH_EDU_VIRTUAL.lst , ref output_array_generic_lst );
			dp_array_generic_lstEmp.MapTagArray ( COMM_OUT_WEB_FETCH_EDU_VIRTUAL.lstEmp , ref output_array_generic_lstEmp );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
			var_Comm.AddExitPortable ( ref dp_array_generic_lstEmp );
		
			return true;
		}
	}
}
