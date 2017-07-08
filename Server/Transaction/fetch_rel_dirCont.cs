using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_rel_dirCont : type_base
	{
		public string input_st_empresa = "";
		public string input_dt_ini = "";
		public string input_dt_fim = "";
		
		public string output_st_csv_contents = "";
		public string output_st_nome_empresa = "";
		
		public DadosSinteticoContGift output_cont_dsc = new DadosSinteticoContGift();
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_rel_dirCont ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_rel_dirCont";
			constructor();
		}
		
		public fetch_rel_dirCont()
		{
			var_Alias = "fetch_rel_dirCont";
		
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
			Registry ( "setup fetch_rel_dirCont " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_DIRCONT.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_DIRCONT.st_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_DIRCONT.dt_ini, ref input_dt_ini ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_DIRCONT.dt_ini missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_DIRCONT.dt_fim, ref input_dt_fim ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_DIRCONT.dt_fim missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_REL_DIRCONT.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_REL_DIRCONT.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_rel_dirCont " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_rel_dirCont " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_rel_dirCont " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_rel_dirCont " ); 
		
			/// USER [ execute ]
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_st_empresa.PadLeft ( 6, '0') ) )
			{
				PublishError ( "Empresa não disponível" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			output_st_nome_empresa = emp.get_st_fantasia();
			
			StringBuilder sb_content = new StringBuilder();
			
			{
				DadosContabilGift dcg = new DadosContabilGift();
				
				dcg.set_st_item ( "Quant. Cartões Cancelados" );
				
				T_Cartao cart = new T_Cartao (this);
				
				cart.SetCountMode();
				
				cart.select_rows_canc ( input_cont_header.get_st_empresa(),
			                            input_dt_ini,
			                            input_dt_fim,
			                            MotivoBloqueio.CANCELAMENTO,
			                            TipoCartao.presente,
			                            CartaoStatus.Bloqueado );
				
				dcg.set_nu_valor ( cart.GetCount().ToString() );
				
				Trace ( dcg.get_st_item() );
				Trace ( dcg.get_nu_valor() );
                
                DataPortable port = dcg;
                
                sb_content.Append ( MemorySave ( ref port ) );
                sb_content.Append ( "," 				);
			}
			
			{
				DadosContabilGift dcg = new DadosContabilGift();
				
				dcg.set_st_item ( "Quant. Recargas" );
				
				LOG_VendaCartaoGift lvc = new LOG_VendaCartaoGift (this);
				
				lvc.SetCountMode();
				
				lvc.select_rows_cargas (  input_dt_ini,
			                            	input_dt_fim,
			                            	emp.get_identity(),
			                            	Context.FALSE );
				
				dcg.set_nu_valor ( lvc.GetCount().ToString() );
				
				Trace ( dcg.get_st_item() );
				Trace ( dcg.get_nu_valor() );
				
				DataPortable port = dcg;
				
				sb_content.Append ( MemorySave ( ref port ) );
				sb_content.Append ( "," 				);
			}
			
			long vendidos = 0;
			
			{
				DadosContabilGift dcg = new DadosContabilGift();
				
				dcg.set_st_item ( "Quant. Cartões Vendidos" );
				
				LOG_VendaCartaoGift lvc = new LOG_VendaCartaoGift (this);
				
				lvc.SetCountMode();
				
				lvc.select_rows_cargas (    input_dt_ini,
			                            	input_dt_fim,
			                            	emp.get_identity(),
			                            	Context.TRUE );
				
				
				vendidos = lvc.GetCount();
				
				dcg.set_nu_valor ( vendidos.ToString() );
				
				Trace ( dcg.get_st_item() );
				Trace ( dcg.get_nu_valor() );
				
				DataPortable port = dcg;
				
				sb_content.Append ( MemorySave ( ref port ) );
				sb_content.Append ( "," 				);
			}
			
			long disp = 0;
			
			{
				DadosContabilGift dcg = new DadosContabilGift();
				
				dcg.set_st_item ( "Saldo Anterior" );
				
				T_Cartao cart = new T_Cartao (this);
				
				cart.SetCountMode();
				
				cart.select_rows_gift_disp ( Context.NONE, TipoCartao.presente );
					
				disp = cart.GetCount();
				
				long anterior = vendidos + cart.GetCount();
				
				dcg.set_nu_valor ( anterior.ToString() );
				
				DataPortable port = dcg;
				
				sb_content.Append ( MemorySave ( ref port ) );
				sb_content.Append ( "," 				);
			}
			
			{
				DadosContabilGift dcg = new DadosContabilGift();
				
				dcg.set_st_item ( "Saldo Atual" );
				dcg.set_nu_valor ( disp.ToString() );
				
				DataPortable port = dcg;
				
				sb_content.Append ( MemorySave ( ref port ) );
				sb_content.Append ( "," 				);
			}
			
			long novo_cartao_carga 	= 0;
			long cartao_recarga 	= 0;
			
			long tarifa_novo_cartao_carga = 0;
			long tarifa_cartao_recarga 	= 0;
			
			{
				DadosContabilGift dcg = new DadosContabilGift();
				
				dcg.set_st_item ( "Movimento do dia" );
				dcg.set_nu_valor ( "0" );
				
				LOG_VendaCartaoGift lvc = new LOG_VendaCartaoGift (this);
				
				T_ExtraGift eGift = new T_ExtraGift (this);
				
				eGift.selectAll();
				eGift.fetch();
				
				long vr_valor = 0;
				long tx_adesao = eGift.get_int_vr_valor();
				
				eGift.fetch();
				
				long tx_recarga = eGift.get_int_vr_valor();				
								
				// novo cartão
				lvc.select_rows_cargas (  	input_dt_ini,
			                            	input_dt_fim,
			                            	emp.get_identity(),
			                            	Context.TRUE );
				
				long qtd_novo_cartao_carga = lvc.RowCount();
				
				while ( lvc.fetch() )
				{
					novo_cartao_carga += lvc.get_int_vr_carga();
				}
				
				tarifa_novo_cartao_carga = qtd_novo_cartao_carga * tx_adesao;
				
				vr_valor += novo_cartao_carga + tarifa_novo_cartao_carga;
								
				lvc.Reset();
				
				// recargas
				if ( lvc.select_rows_cargas (  	input_dt_ini,
			                            		input_dt_fim,
			                            		emp.get_identity(),
			                            		Context.FALSE ) )
				{
					
					long qtd_cartao_recarga = lvc.RowCount();
					
					while ( lvc.fetch() )
					{
						cartao_recarga += lvc.get_int_vr_carga();
					}
					
					tarifa_cartao_recarga = qtd_cartao_recarga * tx_recarga;
						
					vr_valor += cartao_recarga + tarifa_cartao_recarga;
				}
				
				dcg.set_nu_valor ( "R$ " + new money().formatToMoney ( vr_valor.ToString() ) );
				
				DataPortable port = dcg;
				
				sb_content.Append ( MemorySave ( ref port ) );
				sb_content.Append ( "," 				);
			}			
			
			output_cont_dsc.set_vr_tot_carga 	( ( cartao_recarga +  novo_cartao_carga ).ToString() );
			output_cont_dsc.set_vr_tot_tarifa 	( ( tarifa_cartao_recarga + tarifa_novo_cartao_carga ).ToString() );
			
			long tot_compras = 0;
			long tot_taxa 	 = 0;
			long tot_repasse = 0;
			
			{
				T_Parcelas parc = new T_Parcelas (this);
				LINK_LojaEmpresa loj_emp = new LINK_LojaEmpresa (this);
				
				// busca parcelas da empresa no dia
				if ( parc.select_rows_empresa_gift ( emp.get_identity(), input_dt_ini, input_dt_fim ) )
				{
					while ( parc.fetch() )
					{
						// busca convenio
						if ( !loj_emp.select_fk_empresa_loja ( emp.get_identity(), parc.get_fk_loja() )  )
							return false;
						
						if ( !loj_emp.fetch() )
							return false;
						
						double tx   = loj_emp.get_int_tx_admin();
						
						long   taxa = Convert.ToInt64 ( parc.get_int_vr_valor() * tx / 10000 );
						
						tot_compras += parc.get_int_vr_valor();
						tot_taxa    += taxa;
						tot_repasse += Convert.ToInt64 ( parc.get_int_vr_valor() - taxa );
					}
				}				
			}
			
			output_cont_dsc.set_vr_tot_compras	( tot_compras.ToString() 	);
			output_cont_dsc.set_vr_tot_tx 		( tot_taxa.ToString() 		);
			output_cont_dsc.set_vr_tot_repasse 	( tot_repasse.ToString() 	);
			
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
		
			Registry ( "execute done fetch_rel_dirCont " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_rel_dirCont " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_rel_dirCont " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_DIRCONT.st_csv_contents, output_st_csv_contents ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_DIRCONT.st_nome_empresa, output_st_nome_empresa ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			DataPortable dp_cont_1 = new DataPortable();
		
			dp_cont_1.MapTagContainer ( COMM_OUT_FETCH_REL_DIRCONT.dsc , output_cont_dsc as DataPortable );
		
			var_Comm.AddExitPortable ( ref dp_cont_1 ); 
		
			return true;
		}
	}
}
