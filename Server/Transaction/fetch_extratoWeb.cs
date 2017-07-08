using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_extratoWeb : Transaction
	{
		public string input_st_cartao = "";
		public string input_st_senha = "";
		
		public string output_st_content = "";
		public string output_vr_disp = "";
		public string output_vr_lim = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_extratoWeb ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_extratoWeb";
			constructor();
		}
		
		public fetch_extratoWeb()
		{
			var_Alias = "fetch_extratoWeb";
		
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
			Registry ( "setup fetch_extratoWeb " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_EXTRATOWEB.st_cartao, ref input_st_cartao ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_EXTRATOWEB.st_cartao missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_EXTRATOWEB.st_senha, ref input_st_senha ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_EXTRATOWEB.st_senha missing! " ); 
				return false;
			}
			
			Registry ( "setup done fetch_extratoWeb " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate fetch_extratoWeb " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_extratoWeb " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute fetch_extratoWeb " ); 
		
			/// USER [ execute ]
			
			T_Cartao cart          = new T_Cartao (this);
			T_Cartao cart_all      = new T_Cartao (this);
			T_Cartao cart_search      = new T_Cartao (this);
			
			string emp = input_st_cartao.Substring (0,6);
			string mat = input_st_cartao.Substring (6,6);
			
			if ( !cart.select_rows_tudo ( 	emp, mat, input_st_cartao.Substring (12,2) ) )
			{
				PublishError ( "Matrícula não disponível" );
				return false;
			}
			
			if ( !cart.fetch() )
				return false;
			
			if ( cart.get_st_senha() != input_st_senha )
			{
				PublishError ( "Senha inválida" );
				return false;
			}
			
			ArrayList lst_all_carts = new ArrayList ();
			
			if ( cart_all.select_rows_empresa_matricula ( emp, mat ) )
			{
				while ( cart_all.fetch() )
				{
					lst_all_carts.Add ( cart_all.get_identity() );
				}
			}
			
			string mes = input_st_cartao.Substring ( 14,2 );
			string ano = input_st_cartao.Substring ( 16,4 );
			
			LOG_Transacoes l_tr = new LOG_Transacoes ( this );
			T_Loja     		loj = new T_Loja (this);
			T_Parcelas     parc = new T_Parcelas (this);
			
			T_Dependente  dep = new T_Dependente(this);
			T_Proprietario prot = new T_Proprietario (this);
			
			StringBuilder sb_parcs = new StringBuilder();

			LOG_Fechamento lf = new LOG_Fechamento ( this );
			
			if  ( lf.select_rows_mes_ano_carts ( mes, ano, ref lst_all_carts ) )
			{
				while ( lf.fetch() )
				{
					if ( !loj.selectIdentity ( lf.get_fk_loja() ) )
						continue;					    
					
					if ( !parc.selectIdentity ( lf.get_fk_parcela() ) )
						continue;
					
					if ( !parc.fetch() )
						continue;
					
					string nome = "";
					
					if ( !cart_search.selectIdentity ( lf.get_fk_cartao() ) )
						continue;
					
					if ( cart_search.get_st_titularidade() == "01" )
					{
						if ( !prot.selectIdentity ( cart_search.get_fk_dadosProprietario() ) )
							continue;
						
						nome = prot.get_st_nome();
					}
					else
					{
						if ( !dep.select_rows_prop_tit ( cart_search.get_fk_dadosProprietario(), cart_search.get_st_titularidade() ) )
						    continue;
						
						if ( !dep.fetch() )
							continue;
						
						nome = dep.get_st_nome();
					}
					
					if ( parc.get_vr_valor() == "0" )
						continue;
					
					Rel_RTC rtc = new Rel_RTC();
		
					rtc.set_dt_trans			( parc.get_dt_inclusao() 		);
					rtc.set_st_loja 	 		( loj.get_st_nome() 			);
					rtc.set_st_nsu	 			( parc.get_nu_nsu()				);
					rtc.set_vr_total	 		( parc.get_vr_valor() 			);
					rtc.set_st_indice_parcela 	( parc.get_nu_indice() 			);
					rtc.set_st_term				( parc.get_nu_tot_parcelas()	);
					rtc.set_en_op_cartao		( nome 							);
									
					DataPortable mem_rtc = rtc as DataPortable;
					
					// ## obtem indice
					
					sb_parcs.Append ( MemorySave ( ref mem_rtc ) );
					sb_parcs.Append ( ","   );					
				}
			}
			else // presente e futuro
			{
				DateTime dt_target = new DateTime ( Convert.ToInt32 ( ano ), Convert.ToInt32 ( mes ), 1 );
				
				DateTime dt_it = new DateTime ( DateTime.Now.Year, DateTime.Now.Month, 1  ) ;
				
				int my_parc = 1;
				
				while ( dt_it < dt_target )
				{
					my_parc++;
					dt_it = dt_it.AddMonths (1);
				}
				
				if ( parc.select_rows_cartao ( ref lst_all_carts, my_parc.ToString() ) )
				{
					while ( parc.fetch() )
					{
						if ( !loj.selectIdentity ( parc.get_fk_loja() ) )
							continue;					    
						
						string nome = "";
						
						if ( !cart_search.selectIdentity ( parc.get_fk_cartao() ) )
							continue;
						
						if ( cart_search.get_st_titularidade() == "01" )
						{
							if ( !prot.selectIdentity ( cart_search.get_fk_dadosProprietario() ) )
								continue;
							
							nome = prot.get_st_nome();
						}
						else
						{
							if ( !dep.select_rows_prop_tit ( cart_search.get_fk_dadosProprietario(), cart_search.get_st_titularidade() ) )
							    continue;
							
							if ( !dep.fetch() )
								continue;
							
							nome = dep.get_st_nome();
						}
						
						Rel_RTC rtc = new Rel_RTC();
			
						rtc.set_dt_trans			( parc.get_dt_inclusao() 		);
						rtc.set_st_loja 	 		( loj.get_st_nome() 			);
						rtc.set_st_nsu	 			( parc.get_nu_nsu()				);
						rtc.set_vr_total	 		( parc.get_vr_valor() 			);
						rtc.set_st_indice_parcela 	( parc.get_nu_indice() 			);
						rtc.set_st_term				( parc.get_nu_tot_parcelas()	);
						rtc.set_en_op_cartao		( nome 							);
										
						DataPortable mem_rtc = rtc as DataPortable;
						
						// ## obtem indice
						
						sb_parcs.Append ( MemorySave ( ref mem_rtc ) );
						sb_parcs.Append ( ","   );					
					}
				}
			}
			
			string list_ids_parc = sb_parcs.ToString().TrimEnd ( ',' );
									
			DataPortable dp_parcs = new DataPortable();
	
			dp_parcs.setValue ( "ids", list_ids_parc );
			
			output_st_content = MemorySave ( ref dp_parcs );
			
			ApplicationUtil var_util = new ApplicationUtil();
			
			long    dispMensal = cart.get_int_vr_limiteMensal() + cart.get_int_vr_extraCota(),
			  		dispTotal = cart.get_int_vr_limiteTotal() + cart.get_int_vr_extraCota();
			
			var_util.GetSaldoDisponivel ( ref cart, ref dispMensal, ref dispTotal );
			
			output_vr_disp = dispMensal.ToString();
			output_vr_lim  = ( cart.get_int_vr_limiteMensal() + cart.get_int_vr_extraCota() ).ToString();
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_extratoWeb " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish fetch_extratoWeb " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_extratoWeb " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_EXTRATOWEB.st_content, output_st_content ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_EXTRATOWEB.vr_disp, output_vr_disp ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_EXTRATOWEB.vr_lim, output_vr_lim ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
