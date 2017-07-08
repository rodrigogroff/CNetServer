using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_recargaGift : type_base
	{
		public string input_st_empresa = "";
		public string input_st_matricula = "";
		public string input_vr_carga = "";
		public string input_tg_tipoPag = "";
		public string input_tg_tipoCartao = "";
		public string input_st_cheque = "";
		public string input_tg_adesao = "";
		
		public ArrayList input_array_generic_lstProd = new ArrayList();
		
		public string output_id_gift = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_recargaGift ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_recargaGift";
			constructor();
		}
		
		public exec_recargaGift()
		{
			var_Alias = "exec_recargaGift";
		
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
			Registry ( "setup exec_recargaGift " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_RECARGAGIFT.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_RECARGAGIFT.st_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_RECARGAGIFT.st_matricula, ref input_st_matricula ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_RECARGAGIFT.st_matricula missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_RECARGAGIFT.vr_carga, ref input_vr_carga ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_RECARGAGIFT.vr_carga missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_RECARGAGIFT.tg_tipoPag, ref input_tg_tipoPag ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_RECARGAGIFT.tg_tipoPag missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_RECARGAGIFT.tg_tipoCartao, ref input_tg_tipoCartao ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_RECARGAGIFT.tg_tipoCartao missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_RECARGAGIFT.st_cheque, ref input_st_cheque ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_RECARGAGIFT.st_cheque missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_RECARGAGIFT.tg_adesao, ref input_tg_adesao ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_RECARGAGIFT.tg_adesao missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_RECARGAGIFT.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_RECARGAGIFT.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			DataPortable dp_array_generic_lstProd = var_Comm.GetEntryPortableAtPosition ( 2 );
			
			if ( dp_array_generic_lstProd.GetMapArray ( COMM_IN_EXEC_RECARGAGIFT.lstProd , ref input_array_generic_lstProd ) == false )
			{
				Trace ( "# COMM_IN_EXEC_RECARGAGIFT.lstProd missing! " ); 
				return false;
			}
			
			Registry ( "setup done exec_recargaGift " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_recargaGift " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_recargaGift " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_recargaGift " ); 
		
			/// USER [ execute ]
			
			input_st_matricula = input_st_matricula.PadLeft ( 6, '0' );
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_st_empresa ) )
				return false;
			
			if ( !emp.fetch() )
				return false;
			
			T_Cartao cart = new T_Cartao (this);
			
			if ( input_tg_tipoPag != TipoPagamento.Cheque )
				cart.ExclusiveAccess();
			
			if ( !cart.select_rows_empresa_matricula ( input_st_empresa, 
			                                           input_st_matricula ) )
			{
				return false;
			}
			
			if ( !cart.fetch() )
				return false;
						
			LOG_VendaCartaoGift lvc = new LOG_VendaCartaoGift (this);
			
			lvc.set_fk_vendedor 	( user.get_identity() 	);
			lvc.set_fk_empresa 		( emp.get_identity() 	);
			lvc.set_fk_cartao 		( cart.get_identity() 	);
			lvc.set_tg_tipoPag 		( input_tg_tipoPag 		);
			lvc.set_dt_compra 		( GetDataBaseTime()		);
			lvc.set_tg_tipoCartao 	( input_tg_tipoCartao 	);
			lvc.set_tg_adesao 		( input_tg_adesao		);
			lvc.set_vr_carga 		( input_vr_carga 		);
			
			if ( input_tg_tipoPag == TipoPagamento.Cheque )
			{
				lvc.set_st_cheque ( input_st_cheque );
			}
			else if ( input_tg_tipoPag == TipoPagamento.Cartao )
			{
				lvc.set_nu_nsuCartao ( input_st_cheque );	
			}
						
			if ( !lvc.create_LOG_VendaCartaoGift() )
				return false;
			
			output_id_gift = lvc.get_identity();
			
			LOG_VendaProdutoGift lvpg = new LOG_VendaProdutoGift (this);
			
			long vr_tot = lvc.get_int_vr_carga();
			
			for ( int t=0; t < input_array_generic_lstProd.Count; ++t )
			{
				DadosProdutoGift dpg = new DadosProdutoGift ( input_array_generic_lstProd[t] as DataPortable );
				
				lvpg.set_fk_vendaCartao ( lvc.get_identity() 	);
				lvpg.set_st_produto 	( dpg.get_st_nome() 	);
				lvpg.set_vr_valor 		( dpg.get_vr_valor() 	);
				
				vr_tot += Convert.ToInt64 ( dpg.get_vr_valor() );
		
				if ( !lvpg.create_LOG_VendaProdutoGift() )
					return false;
			}
			
			if ( input_tg_tipoPag == TipoPagamento.Cheque )
			{
				T_ChequesGift chq_gift = new T_ChequesGift (this);
				
				chq_gift.set_st_identificador 	( input_st_cheque 		);
				chq_gift.set_fk_cartao 			( cart.get_identity() 	);
				chq_gift.set_dt_efetiva 		( GetDataBaseTime() 	);
				chq_gift.set_tg_compensado 		( Context.FALSE  		);
				chq_gift.set_vr_valor			( vr_tot				);
				
				if ( !chq_gift.create_T_ChequesGift() )
					return false;
			}
			else 
			{	
				if ( input_tg_adesao == Context.TRUE ) // adesão
				{
					cart.set_vr_limiteTotal ( Convert.ToInt64 ( input_vr_carga ) );
				}
				else // recarga
				{
					cart.set_vr_limiteTotal ( 	cart.get_int_vr_limiteTotal() + 
				                          		Convert.ToInt64 ( input_vr_carga ) );
				}
					
				if ( !cart.synchronize_T_Cartao() )
					return false;
				
				cart.ReleaseExclusive();
			}
			
			if ( input_tg_adesao == Context.FALSE )
			{
				PublishNote ( "Recarga de cartão efetuada com sucesso" );
			}
		
			/// USER [ execute ] END
		
			Registry ( "execute done exec_recargaGift " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_recargaGift " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.RecargaGift        		);
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( "" );
				
				aud.set_fk_generic  ( 0 );
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
						
			/// USER [ finish ] END
		
			Registry ( "finish done exec_recargaGift " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_EXEC_RECARGAGIFT.id_gift, output_id_gift ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
