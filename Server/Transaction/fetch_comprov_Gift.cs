using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_comprov_Gift : type_base
	{
		public string input_id_gift = "";
		public string input_tg_reimp = "";
		
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_comprov_Gift ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_comprov_Gift";
			constructor();
		}
		
		public fetch_comprov_Gift()
		{
			var_Alias = "fetch_comprov_Gift";
		
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
			Registry ( "setup fetch_comprov_Gift " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_COMPROV_GIFT.id_gift, ref input_id_gift ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_COMPROV_GIFT.id_gift missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_COMPROV_GIFT.tg_reimp, ref input_tg_reimp ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_COMPROV_GIFT.tg_reimp missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_COMPROV_GIFT.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_COMPROV_GIFT.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_comprov_Gift " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_comprov_Gift " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_comprov_Gift " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_comprov_Gift " ); 
		
			/// USER [ execute ]
			
			ArrayList lstContent = new ArrayList();
			
			ApplicationUtil util = new ApplicationUtil();
			
			LOG_VendaCartaoGift lvc 	= new LOG_VendaCartaoGift (this);
			T_Empresa 			emp 	= new T_Empresa (this);
			T_Cartao 			cart 	= new T_Cartao (this);
			T_Proprietario 		prot 	= new T_Proprietario (this);
						
			lvc.ExclusiveAccess();
			
			if ( !lvc.selectIdentity ( input_id_gift ) )
				return false;
						
			if ( !emp.selectIdentity ( lvc.get_fk_empresa() ) )
				return false;
						
			if ( !cart.selectIdentity ( lvc.get_fk_cartao() ) )
				return false;
					
			if ( !prot.selectIdentity ( cart.get_fk_dadosProprietario() ) )
				return false;
			 
			if ( input_tg_reimp == Context.TRUE )
			{
				lstContent.Add ( "Reimpressão de comprovante de venda giftcard"	);
				lstContent.Add ( "" 	);
				
				DateTime tm = Convert.ToDateTime ( lvc.get_dt_compra() );
				
				string data = "Porto Alegre, " + tm.ToLongDateString() + " - " + tm.ToLongTimeString();
				
				lstContent.Add ( data.PadLeft ( 80, ' ' ) 	);
			}
			else
			{
				string data = "Porto Alegre, " + DateTime.Now.ToLongDateString() + " - " + DateTime.Now.ToLongTimeString();
				
				lstContent.Add ( data.PadLeft ( 80, ' ' ) 	);
			}
			
			lstContent.Add ( "" 						);
			lstContent.Add ( emp.get_st_social() 		);
			lstContent.Add ( "GIFTCARD LINDÓIA" 		);
			
			string num_cart = cart.get_st_empresa() + "." + cart.get_st_matricula() + ".";
				
			num_cart += util.calculaCodigoAcesso ( 	cart.get_st_empresa(),
				                                    cart.get_st_matricula(),
				                                    cart.get_st_venctoCartao() );
			
			num_cart += ".";
			num_cart += cart.get_st_venctoCartao().PadLeft ( 4, '0' );
			        
			lstContent.Add ( "Número do cartão: " + num_cart 	);
			
			string cod_trans = var_util.DESCript ( cart.get_st_matricula() + 
			                                       DateTime.Now.Second.ToString().PadLeft ( 2, '0') ,
			                                       "66666666" );
			
			lvc.set_st_codImpresso ( cod_trans );
			
			if ( !lvc.synchronize_LOG_VendaCartaoGift() )
				return false;
			
			lstContent.Add ( "Cod. Transação: " + cod_trans 				);
			lstContent.Add ( "Cpf do comprador: " + prot.get_st_cpf() 		);
			lstContent.Add ( "--------------------------------------------" );
			lstContent.Add ( "Valor da carga: R$ " + new money().formatToMoney ( lvc.get_vr_carga() ) );
			lstContent.Add ( "--------------------------------------------" );
			
			LOG_VendaProdutoGift lvp = new LOG_VendaProdutoGift (this);
			
			long extras = 0;
			long total_extras = 0;
			
			if ( lvp.select_fk_venda ( input_id_gift ) )
			{
				extras = lvp.RowCount();
			}
			
			lstContent.Add ( "Extras: " +  	extras.ToString()			);
			
			while ( lvp.fetch() )
			{
				total_extras += lvp.get_int_vr_valor();
					
				lstContent.Add ( 	"-" + 
				                	lvp.get_st_produto().PadRight ( 25, ' ' ) +
				                	" R$ "  + 
				                	new money().formatToMoney ( lvp.get_vr_valor() ) );
			}
			
			lstContent.Add ( "Total Extras: R$ " +  new money().formatToMoney ( total_extras.ToString() ) );
			
			total_extras += lvc.get_int_vr_carga();
			
			lstContent.Add ( "Valor Total: R$ " +  new money().formatToMoney ( total_extras.ToString() ) );
			
			string formPag = "dinheiro";
			
			if ( lvc.get_tg_tipoPag() == TipoPagamento.Cheque )
			{
				formPag = "Cheque (" + lvc.get_st_cheque() + ")";
			}
			else if ( lvc.get_tg_tipoPag() == TipoPagamento.Cartao )
			{
				formPag = "Cartão (" + lvc.get_nu_nsuCartao() + ")";
			}
			
			lstContent.Add ( "Forma de pagamento: " + formPag );
			lstContent.Add ( "" );
			lstContent.Add ( "RECEBI O CARTAO GIFTCARD LINDOIA, COMPROMETO-ME A ORIENTAR O" );
			lstContent.Add ( "PRESENTEADO QUANTO AO SEU USO E GUARDA." );
			lstContent.Add ( "" );
			lstContent.Add ( "_________________________________" );
			lstContent.Add ( prot.get_st_nome() );
			lstContent.Add ( "" );
			lstContent.Add ( "**Caso o pagamento tenha sido efetuado em cheque, somente estará liberado o uso" );
			lstContent.Add ( "do cartão após a compensação do mesmo" );
			
			for (int t=0; t < lstContent.Count; ++t )
			{
				DataPortable port = new DataPortable();
				port.setValue ( "linha", lstContent[t].ToString() );
				output_array_generic_lst.Add ( port );
			}
			
			{
				DataPortable port = new DataPortable();
				port.setValue ( "linha", "" );
				output_array_generic_lst.Add ( port );
			}
			
			
			{
				DataPortable port = new DataPortable();
				port.setValue ( "linha", "---------------------------------------------------------------" );
				output_array_generic_lst.Add ( port );
			}

			
			{
				DataPortable port = new DataPortable();
				port.setValue ( "linha", "" );
				output_array_generic_lst.Add ( port );
			}

			
			for (int t=0; t < lstContent.Count; ++t )
			{
				DataPortable port = new DataPortable();
				port.setValue ( "linha", lstContent[t].ToString() );
				output_array_generic_lst.Add ( port );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_comprov_Gift " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_comprov_Gift " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_comprov_Gift " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_FETCH_COMPROV_GIFT.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			return true;
		}
	}
}
