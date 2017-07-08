using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_rel_4_rrp : type_base
	{
		public string input_st_empresa = "";
		public string input_dt_ini = "";
		public string input_dt_fim = "";
		
		public string output_st_csv_content = "";
		public string output_st_nome_empresa = "";
		public string output_st_csv_lojas = "";
		public string output_st_csv_subtotal = "";
		public string output_st_total = "";
		public string output_st_csv_nome_lojas = "";
		public string output_st_csv_subtotal_geral = "";
		public string output_st_total_geral = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_rel_4_rrp ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_rel_4_rrp";
			constructor();
		}
		
		public fetch_rel_4_rrp()
		{
			var_Alias = "fetch_rel_4_rrp";
		
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
			Registry ( "setup fetch_rel_4_rrp " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_4_RRP.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_4_RRP.st_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_4_RRP.dt_ini, ref input_dt_ini ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_4_RRP.dt_ini missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_4_RRP.dt_fim, ref input_dt_fim ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_4_RRP.dt_fim missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_REL_4_RRP.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_REL_4_RRP.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_rel_4_rrp " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_rel_4_rrp " ); 
		
			/// USER [ authenticate ]
			
			input_st_empresa = input_st_empresa.PadLeft ( 6, '0' );
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_rel_4_rrp " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_rel_4_rrp " ); 
		
			/// USER [ execute ]
		
			DateTime t_end   = Convert.ToDateTime ( input_dt_fim ).AddDays(1);
			
			// ## 
			// ## O seguinte trecho indexa as lojas possíveis
			// ## de retorno para uma determinada empresa.
			// ## 
			// ## E, no caso de a empresa original ser administradora
			// ## de empresas, indexar todas as lojas de todas empresas
			// ## desta rede.
			// ## 
			
			Hashtable hshLojas = new Hashtable();
			
			#region - filtro de lojas da empresa - 
						
			if ( user.get_tg_nivel() == TipoUsuario.Administrador )
			{
				T_Empresa emp_orig = new T_Empresa (this);
				
				// ## Busca empresa original
				
				if ( !emp_orig.select_rows_empresa ( user.get_st_empresa() ) )
					return false;
				
				if ( !emp_orig.fetch())
					return false;
				
				LINK_LojaEmpresa lnk = new LINK_LojaEmpresa (this);
				
				// ## busca relacionamento das empresas com lojas
				
				if ( lnk.select_fk_empresa_geral ( emp_orig.get_identity() ) )
				{
					while ( lnk.fetch() )
					{
						// ## indexa lojas
						
						hshLojas [ lnk.get_fk_loja() ] = "*";
					}
				}				
				
				// ## busca empresas administradas
				
				T_Empresa emp_lnk_admin = new T_Empresa (this);
				
				if ( emp_lnk_admin.select_fk_admin ( emp_orig.get_identity() ) )
				{
					while ( emp_lnk_admin.fetch() )
					{
						// ## busca lojas de cada empresa administrada
						
						LINK_LojaEmpresa lnk_admin = new LINK_LojaEmpresa (this);
						
						if ( lnk_admin.select_fk_empresa_geral ( emp_lnk_admin.get_identity() ) )
						{
							while ( lnk_admin.fetch() )
							{
								// ## indexa loja
							
								hshLojas [ lnk_admin.get_fk_loja() ] = "*";
							}
						}		
					}
				}
			}
			
			#endregion
			
			// ## Busca empresa
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_st_empresa ) )
			{
				PublishError ( "Código de empresa inválida" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			output_st_nome_empresa = emp.get_st_fantasia();
			
			LINK_LojaEmpresa loj_emp = new LINK_LojaEmpresa ( this );
			
			// ## Busca convenios
			
			if ( !loj_emp.select_fk_empresa_geral ( emp.get_identity() ) )
			{
				PublishError ( "Nenhuma loja cadastrada" );
				return false;
			}
			
			T_Loja   		loj  = new T_Loja (this);
			T_Cartao 		cart = new T_Cartao (this);
			LOG_Transacoes  ltr  = new LOG_Transacoes (this);
						
			long total = 0;
			long total_geral = 0;
			
			StringBuilder sb = new StringBuilder();
			
			// ## Busca registros de convênios
			
			T_Parcelas parc = new T_Parcelas (this);
			
			while ( loj_emp.fetch() )
			{
				if  ( hshLojas.Count > 0 )
					if ( hshLojas [ loj_emp.get_fk_loja() ] == null )
						continue;
				
				// ## Busca loja

				if ( !loj.selectIdentity ( loj_emp.get_fk_loja() ) )
					return false;
				
				double 	 tx   = loj_emp.get_int_tx_admin();
				long	 dias = loj_emp.get_int_nu_dias_repasse();
				
				long 	subtotal   = 0, 
						repasse    = 0, 
						total_loja = 0;
								
				// ## Busca nas transações do periodo
				
				bool   zerada = true;
								
				if ( parc.select_rows_repasse ( loj.get_identity(), 
				                                TipoParcela.EM_ABERTO ) ) // ainda não pagos
				{
					while ( parc.fetch() )
					{	
						if ( ltr.selectIdentity ( parc.get_fk_log_transacoes() ) )
						    if ( ltr.get_tg_confirmada() != TipoConfirmacao.Confirmada )
						    	continue;
						    	
						if ( !cart.selectIdentity ( parc.get_fk_cartao() ) )
							return false;
						
						DateTime tim = Convert.ToDateTime ( parc.get_dt_inclusao() ).AddDays ( dias );
						
						// fora da faixa requerida pelo relatório
						if ( tim > t_end )
							continue;
						
						DadosRepasse dr = new DadosRepasse();
						
						dr.set_tg_tipoCartao ( cart.get_tg_tipoCartao() );
						dr.set_st_nsu 		 ( parc.get_nu_nsu() 		);
						dr.set_st_loja 		 ( loj.get_st_loja() 		);
						
						dr.set_st_cartao 	 ( cart.get_st_empresa() + "." + 
						                       cart.get_st_matricula() + "." + 
						                       cart.get_st_titularidade() 	);
						
						dr.set_dt_trans ( parc.get_dt_inclusao()  	);
						dr.set_vr_total ( parc.get_vr_valor() 		);
						
						// acerta data correta do repasse
						dr.set_dt_repasse ( GetDataBaseTime ( tim ) );
						
						total_loja += parc.get_int_vr_valor();
						repasse     = Convert.ToInt64 ( parc.get_int_vr_valor() - ( parc.get_int_vr_valor() * tx / 10000 ) );
						subtotal   += repasse;
						
						dr.set_vr_repasse ( repasse.ToString() );
						
						DataPortable mem = dr as DataPortable;
						
						sb.Append ( MemorySave ( ref mem ) );
						sb.Append ( ","   );
						
						zerada = false;
					}
				}                                
				
				if ( !zerada )
				{
					total		+= subtotal;
					total_geral += total_loja;
	
					output_st_csv_lojas          += loj.get_st_loja() + ",";
					output_st_csv_nome_lojas     += loj.get_st_nome() + 
													" - CNPJ (" + loj.get_nu_CNPJ() + 
													") - Percentual " + ( (double) loj_emp.get_int_tx_admin()/100 ).ToString().Replace (",", "." ) + 
													"% - Dias de repasse " + loj_emp.get_nu_dias_repasse() + ",";
					
					output_st_csv_subtotal       += subtotal.ToString() + ",";
					output_st_csv_subtotal_geral += total_loja.ToString() + ",";
				}
			}
			
			string list_ids = sb.ToString().TrimEnd ( ',' );
			
			if ( list_ids == "" )
			{
				PublishNote ( "Nenhum registro encontrado" );
				return false;
			}
									
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", list_ids );
			
			// ## Guarda indexador de grupo
						  
			output_st_csv_content = MemorySave ( ref dp );
			
			output_st_csv_lojas      	 = output_st_csv_lojas.TrimEnd 			( ',' );
			output_st_csv_nome_lojas 	 = output_st_csv_nome_lojas.TrimEnd 	( ',' );
			output_st_csv_subtotal   	 = output_st_csv_subtotal.TrimEnd 		( ',' );
			output_st_csv_subtotal_geral = output_st_csv_subtotal_geral.TrimEnd ( ',' );
			
			output_st_total = total.ToString();
			output_st_total_geral = total_geral.ToString();

			/// USER [ execute ] END
		
			Registry ( "execute done fetch_rel_4_rrp " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_rel_4_rrp " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_rel_4_rrp " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_4_RRP.st_csv_content, output_st_csv_content ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_4_RRP.st_nome_empresa, output_st_nome_empresa ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_4_RRP.st_csv_lojas, output_st_csv_lojas ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_4_RRP.st_csv_subtotal, output_st_csv_subtotal ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_4_RRP.st_total, output_st_total ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_4_RRP.st_csv_nome_lojas, output_st_csv_nome_lojas ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_4_RRP.st_csv_subtotal_geral, output_st_csv_subtotal_geral ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_4_RRP.st_total_geral, output_st_total_geral ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
