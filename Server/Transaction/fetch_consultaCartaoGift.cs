using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_consultaCartaoGift : type_base
	{
		public string input_st_empresa = "";
		public string input_st_matricula = "";
		
		public string output_st_nome = "";
		public string output_vr_disp = "";
		public string output_st_sit = "";
		
		public ArrayList output_array_generic_lstCred = new ArrayList(); 
		public ArrayList output_array_generic_lstProd = new ArrayList(); 
		public ArrayList output_array_generic_lstComprov = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_consultaCartaoGift ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_consultaCartaoGift";
			constructor();
		}
		
		public fetch_consultaCartaoGift()
		{
			var_Alias = "fetch_consultaCartaoGift";
		
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
			Registry ( "setup fetch_consultaCartaoGift " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CONSULTACARTAOGIFT.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CONSULTACARTAOGIFT.st_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CONSULTACARTAOGIFT.st_matricula, ref input_st_matricula ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CONSULTACARTAOGIFT.st_matricula missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_CONSULTACARTAOGIFT.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_CONSULTACARTAOGIFT.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_consultaCartaoGift " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_consultaCartaoGift " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_consultaCartaoGift " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_consultaCartaoGift " ); 
		
			/// USER [ execute ]
			
			T_Cartao cart = new T_Cartao (this);
			
			if ( !cart.select_rows_empresa_matricula ( input_st_empresa.PadLeft ( 6, '0' ), 
			                                           input_st_matricula.PadLeft ( 6, '0' ) ) )
			{
				PublishError ( "Cartão não disponível" );
				return false;
	        }
			
			if ( !cart.fetch() )
				return false;
			
			if ( cart.get_tg_status() == CartaoStatus.Bloqueado )
			{
				if ( cart.get_tg_motivoBloqueio() == MotivoBloqueio.CANCELAMENTO )
					output_st_sit = "Cartão cancelado";
				else
					output_st_sit = "Cartão bloqueado";
			}
			else 
				output_st_sit = "Cartão habilitado";
			
			T_Proprietario prot = new T_Proprietario (this);
				
			if ( !prot.selectIdentity ( cart.get_fk_dadosProprietario() ) )
			{
				PublishError ( "Cartão não disponível" );
				return false;
			}
			
			output_st_nome = prot.get_st_nome();
			output_vr_disp = cart.get_vr_limiteTotal();
			
			LOG_VendaCartaoGift  lvc = new LOG_VendaCartaoGift (this);
			LOG_VendaProdutoGift lvp = new LOG_VendaProdutoGift (this);
			
			if ( lvc.select_fk_cart ( cart.get_identity() ) )
			{
				while ( lvc.fetch() )
				{
					DadosConsultaGift dcg = new DadosConsultaGift();
					DadosComprovGift  comprov = new DadosComprovGift();
					
					comprov.set_id_venda ( lvc.get_identity() 	);
					comprov.set_dt_venda ( lvc.get_dt_compra() 	);
					
					if ( lvc.get_tg_adesao() == Context.TRUE )
					{
						dcg.set_st_nome 	( "Primeira Carga de Cartão" );
						comprov.set_st_tipo ( "CARGA" 					 );
					}
					else
					{
						dcg.set_st_nome 	( "Recarga de Cartão" 	);
						comprov.set_st_tipo ( "RECARGA" 		  	);
					}
						
					comprov.set_vr_valor ( lvc.get_vr_carga() 		);
					dcg.set_vr_valor 	 ( lvc.get_vr_carga() 		);
					
					output_array_generic_lstProd.Add 	( dcg 		);
					output_array_generic_lstComprov.Add ( comprov 	);
					
					if ( lvp.select_fk_venda ( lvc.get_identity() ) )
					{
						while ( lvp.fetch() )
						{
							DadosConsultaGift in_dcg = new DadosConsultaGift();
							
							in_dcg.set_st_nome 	( lvp.get_st_produto() 	);
							in_dcg.set_vr_valor ( lvp.get_vr_valor() 	);
							
							output_array_generic_lstProd.Add ( in_dcg );
						}
					}
				}
			}
			    
			T_ChequesGift cg = new T_ChequesGift (this);
			
			if ( cg.select_rows_cart_comp ( cart.get_identity(), Context.FALSE ) )
			{
				while ( cg.fetch() )
				{
					DadosConsultaGift in_dcg = new DadosConsultaGift();
							
					in_dcg.set_st_nome 	( cg.get_st_identificador() );
					in_dcg.set_dt_data	( cg.get_dt_efetiva()		);
					in_dcg.set_vr_valor	( cg.get_vr_valor()			);
					
					output_array_generic_lstCred.Add ( in_dcg );
				}
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_consultaCartaoGift " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_consultaCartaoGift " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_consultaCartaoGift " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_CONSULTACARTAOGIFT.st_nome, output_st_nome ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_CONSULTACARTAOGIFT.vr_disp, output_vr_disp ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_CONSULTACARTAOGIFT.st_sit, output_st_sit ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			DataPortable dp_array_generic_lstCred = new DataPortable();
			DataPortable dp_array_generic_lstProd = new DataPortable();
			DataPortable dp_array_generic_lstComprov = new DataPortable();
		
			dp_array_generic_lstCred.MapTagArray ( COMM_OUT_FETCH_CONSULTACARTAOGIFT.lstCred , ref output_array_generic_lstCred );
			dp_array_generic_lstProd.MapTagArray ( COMM_OUT_FETCH_CONSULTACARTAOGIFT.lstProd , ref output_array_generic_lstProd );
			dp_array_generic_lstComprov.MapTagArray ( COMM_OUT_FETCH_CONSULTACARTAOGIFT.lstComprov , ref output_array_generic_lstComprov );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lstCred );
			var_Comm.AddExitPortable ( ref dp_array_generic_lstProd );
			var_Comm.AddExitPortable ( ref dp_array_generic_lstComprov );
		
			return true;
		}
	}
}
