using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_rel_fechCaixa : type_base
	{
		public string input_st_empresa = "";
		public string input_dt_ini = "";
		public string input_dt_fim = "";
		
		public string output_st_csv_contents = "";
		public string output_st_nome_empresa = "";
		
		public ArrayList output_array_generic_lstQuiosques = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_rel_fechCaixa ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_rel_fechCaixa";
			constructor();
		}
		
		public fetch_rel_fechCaixa()
		{
			var_Alias = "fetch_rel_fechCaixa";
		
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
			Registry ( "setup fetch_rel_fechCaixa " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_FECHCAIXA.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_FECHCAIXA.st_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_FECHCAIXA.dt_ini, ref input_dt_ini ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_FECHCAIXA.dt_ini missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_FECHCAIXA.dt_fim, ref input_dt_fim ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_FECHCAIXA.dt_fim missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_REL_FECHCAIXA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_REL_FECHCAIXA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_rel_fechCaixa " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_rel_fechCaixa " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_rel_fechCaixa " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_rel_fechCaixa " ); 
		
			/// USER [ execute ]
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_st_empresa ) )
			{
				PublishError ( "Empresa não disponível" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			output_st_nome_empresa = emp.get_st_fantasia();
			
			T_Quiosque qui = new T_Quiosque (this);
			
			if ( !qui.select_fk_empresa ( emp.get_identity() ) )
			{
				PublishError ( "Nenhum quiosque disponível" );
				return false;
			}
				
			while ( qui.fetch() )
			{
				DadosQuiosque dq = new DadosQuiosque();
			
				dq.set_st_nome ( qui.get_st_nome() );
				
				output_array_generic_lstQuiosques.Add ( dq );
			}
			
			T_Usuario usrQuiosque = new T_Usuario ( this );
			
			if ( !usrQuiosque.select_rows_empresa ( input_st_empresa ) )
			{
				PublishError ( "Nenhum vendedor disponível" );
				return false;
			}
			
			StringBuilder sb_content = new StringBuilder();
			
			T_Cartao cart = new T_Cartao(this);
			
			LOG_VendaCartaoGift lvc = new LOG_VendaCartaoGift (this);
			LOG_VendaProdutoGift lvp = new LOG_VendaProdutoGift (this);
			
			while ( usrQuiosque.fetch() )
			{
				if ( usrQuiosque.get_tg_nivel() != TipoUsuario.VendedorGift &&
				     usrQuiosque.get_tg_nivel() != TipoUsuario.AdminGift )
				{
					continue;
				}
				
				if ( !lvc.select_rows_vendedor ( 	usrQuiosque.get_identity(), 
				                                	input_dt_ini,
				                                	input_dt_fim ) )
				{
					continue;
				}	
				
				qui.selectIdentity ( usrQuiosque.get_fk_quiosque() );
				
				while ( lvc.fetch() )
				{
					if ( !cart.selectIdentity ( lvc.get_fk_cartao() ) )
						return false;
					
					DadosFechCaixa rel_line = new DadosFechCaixa();
					
					rel_line.set_st_quiosque ( qui.get_st_nome() 			);
					rel_line.set_st_vendedor ( usrQuiosque.get_st_nome() 	);
					
					rel_line.set_st_cartao	 ( 	cart.get_st_empresa() + "." + 
					                         	cart.get_st_matricula() + "." + 
					                         	cart.get_st_titularidade() );
					
					rel_line.set_vr_credito	 ( lvc.get_vr_carga()  );
					
					long tot_prods = 0;
					long tot = lvc.get_int_vr_carga();
					
					if ( lvp.select_fk_venda ( lvc.get_identity() ) )
					{
						// primeira sempre é carga ou recarga
						if ( lvp.fetch() )
						{
							rel_line.set_vr_tarifa ( lvp.get_vr_valor() );
						}
						
						while ( lvp.fetch() )
						{
							tot_prods += lvp.get_int_vr_valor();
						}
					}
					
					tot += tot_prods;
										
					rel_line.set_vr_prods	 ( tot_prods.ToString() );
					rel_line.set_st_extra	 ( lvc.get_st_cheque()	);
					rel_line.set_tg_pagto	 ( lvc.get_tg_tipoPag() );
					rel_line.set_dt_venda    ( lvc.get_dt_compra()  );
					
					if ( cart.get_tg_status() == CartaoStatus.Bloqueado )
					{
						if ( cart.get_tg_motivoBloqueio() == MotivoBloqueio.CANCELAMENTO )
						{
							rel_line.set_st_extra ( "Cancelado" );
							rel_line.set_tg_pagto ( "4" 		);
						}
					}
					
					rel_line.set_vr_total    ( tot.ToString() );
					
					// index em memoria, retrieve depois
					{
						DataPortable port = rel_line;
						
						sb_content.Append ( MemorySave ( ref port ) );
						sb_content.Append ( "," 				);
					}
				}
			}
			
			// indexa todos os items
			{
				string list_ids = sb_content.ToString().TrimEnd ( ',' );
			
				if ( list_ids == "" )
				{
					PublishNote ( "Nenhum registro encontrado" );
					return false;
				}
										
				DataPortable dp = new DataPortable();
				
				dp.setValue ( "ids", list_ids );
				
				// ## Guarda indexador de grupo
							  
				output_st_csv_contents = MemorySave ( ref dp );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_rel_fechCaixa " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_rel_fechCaixa " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_rel_fechCaixa " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_FECHCAIXA.st_csv_contents, output_st_csv_contents ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_FECHCAIXA.st_nome_empresa, output_st_nome_empresa ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			DataPortable dp_array_generic_lstQuiosques = new DataPortable();
		
			dp_array_generic_lstQuiosques.MapTagArray ( COMM_OUT_FETCH_REL_FECHCAIXA.lstQuiosques , ref output_array_generic_lstQuiosques );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lstQuiosques );
		
			return true;
		}
	}
}
