using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_repasseData : type_base
	{
		public string input_dt_ini = "";
		
		public string output_block_detalhe_loja = "";
		public string output_block_sumario_loja = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_repasseData ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_repasseData";
			constructor();
		}
		
		public fetch_repasseData()
		{
			var_Alias = "fetch_repasseData";
		
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
			Registry ( "setup fetch_repasseData " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REPASSEDATA.dt_ini, ref input_dt_ini ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REPASSEDATA.dt_ini missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_REPASSEDATA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_REPASSEDATA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_repasseData " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_repasseData " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_repasseData " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_repasseData " ); 
		
			/// USER [ execute ]
			
			DateTime t_start = Convert.ToDateTime ( input_dt_ini );
			DateTime t_end   = t_start.AddDays (1);
			
			Hashtable hshLojas = new Hashtable();
			
			ArrayList lstEmpresas = new ArrayList();
		
			// ## Busca empresa
			
			T_Empresa emp = new T_Empresa (this);
			T_Empresa emp_link = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_cont_header.get_st_empresa() ) )
			{
				PublishError ( "Código de empresa inválida" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;	
			
			lstEmpresas.Add ( emp.get_identity() );
			
			if ( emp_link.select_fk_admin ( emp.get_identity() ) )
			{
				while ( emp_link.fetch() )
				{
					lstEmpresas.Add ( emp_link.get_identity() );		
				}
			}
			
			LINK_LojaEmpresa loj_emp = new LINK_LojaEmpresa ( this );
			
			// ## Busca convenios
			
			if ( !loj_emp.select_rows_empresas ( ref lstEmpresas ) )
			{
				PublishError ( "Nenhuma loja cadastrada" );
				return false;
			}
			
			T_Loja   		loj  = new T_Loja (this);
			T_Cartao 		cart = new T_Cartao (this);
			LOG_Transacoes  ltr  = new LOG_Transacoes (this);
			T_Parcelas 		parc = new T_Parcelas (this);
			
			StringBuilder sb = new StringBuilder();
			StringBuilder sb_lojas = new StringBuilder();
			
			while ( loj_emp.fetch() )
			{
				if ( !loj.selectIdentity ( loj_emp.get_fk_loja() ) )
					return false;
				
				double 	tx   	   = loj_emp.get_int_tx_admin();
				long	dias 	   = loj_emp.get_int_nu_dias_repasse();
				
				long 	repasse    = 0, 
						total_loja = 0;
				
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
						
						DadosRepasse dr = new DadosRepasse();
												
						dr.set_st_nsu 		( parc.get_nu_nsu() 		);
						dr.set_st_loja 		( loj.get_st_loja() 		);
						dr.set_st_cartao 	( cart.get_st_empresa() + "." + 
						                      cart.get_st_matricula() + "." + 
						                      cart.get_st_titularidade() 	);
						
						DateTime tim = Convert.ToDateTime ( parc.get_dt_inclusao() );
						
						// fora da faixa requerida pelo relatório
						if ( tim > t_end )
							continue;
						
						dr.set_dt_trans ( parc.get_dt_inclusao()  );
						
						// acerta data correta do repasse
						dr.set_dt_repasse ( GetDataBaseTime ( tim.AddDays ( dias) ) );
												
						repasse = Convert.ToInt64 ( parc.get_int_vr_valor() - ( parc.get_int_vr_valor() * tx / 10000 ) );
						
						dr.set_vr_repasse ( repasse.ToString() );
						dr.set_id_parcela ( parc.get_identity() );
							
						DateTime tm_rep = Convert.ToDateTime ( dr.get_dt_repasse() );
						
						dr.set_tg_confirmado ( Context.TRUE );

						if ( tm_rep <= t_start )
						{
							total_loja += repasse;	
						}
						else if ( tm_rep <= t_end )	
						{
							total_loja += repasse;	
						}						
						    
						// salva registro do detalhe
						{
							DataPortable mem = dr as DataPortable;
							
							sb.Append ( MemorySave ( ref mem ) );
							sb.Append ( ","   );
						}
					}
				}                       
				
				// salva registro da loja 
				if ( total_loja > 0 )
				{
					DadosSumarioRepasse dsr = new DadosSumarioRepasse();
					
					dsr.set_st_loja 	( "(" + loj.get_st_loja()  + ") " + loj.get_st_nome() + " - " + loj.get_st_social() );
					dsr.set_st_codLoja 	( loj.get_st_loja() 		);
					dsr.set_vr_valor	( total_loja.ToString() 	);
					
					DataPortable mem = dsr as DataPortable;
						
					sb_lojas.Append ( MemorySave ( ref mem ) );
					sb_lojas.Append ( ","   );
				}
			}		
			
			// ## Guarda indexador de grupo dos detalhes
			{
				string list_ids = sb.ToString().TrimEnd ( ',' );
				
				if ( list_ids == "" )
				{
					PublishNote ( "Nenhum registro encontrado" );
					return false;
				}
										
				DataPortable dp = new DataPortable();
				
				dp.setValue ( "ids", list_ids );
										  
				output_block_detalhe_loja = MemorySave ( ref dp );
			}
			
			// ## Guarda indexador de grupo de sumario das lojas
			{
				string list_ids = sb_lojas.ToString().TrimEnd ( ',' );
				
				if ( list_ids == "" )
				{
					PublishNote ( "Nenhum registro encontrado" );
					return false;
				}
										
				DataPortable dp = new DataPortable();
				
				dp.setValue ( "ids", list_ids );
										  
				output_block_sumario_loja = MemorySave ( ref dp );
			}
							
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_repasseData " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_repasseData " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_repasseData " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_REPASSEDATA.block_detalhe_loja, output_block_detalhe_loja ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REPASSEDATA.block_sumario_loja, output_block_sumario_loja ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
