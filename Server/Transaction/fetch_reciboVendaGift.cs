using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_reciboVendaGift : type_base
	{
		public string input_nsu = "";
		
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		
		string fk_transacao = "";
		
		/// USER [ var_decl ] END
		
		public fetch_reciboVendaGift ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_reciboVendaGift";
			constructor();
		}
		
		public fetch_reciboVendaGift()
		{
			var_Alias = "fetch_reciboVendaGift";
		
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
			Registry ( "setup fetch_reciboVendaGift " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_RECIBOVENDAGIFT.nsu, ref input_nsu ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_RECIBOVENDAGIFT.nsu missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_RECIBOVENDAGIFT.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_RECIBOVENDAGIFT.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_reciboVendaGift " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_reciboVendaGift " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_reciboVendaGift " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_reciboVendaGift " ); 
		
			/// USER [ execute ]

			LOG_Transacoes 	ltr 	= new LOG_Transacoes 	(this);
			T_Loja 			loj 	= new T_Loja 			(this);
			T_Terminal		term    = new T_Terminal		(this);
			T_Cartao 		cart 	= new T_Cartao 			(this);
					
			if ( !ltr.select_rows_nsu ( input_nsu, GetTodayStartTime(), GetTodayEndTime() ) )
				return false;
			
			if ( !ltr.fetch() )
				return false;
			
			fk_transacao = ltr.get_identity();
			
			if ( !loj.selectIdentity ( ltr.get_fk_loja() ) ) 
				return false;
			
			if ( !term.selectIdentity ( ltr.get_fk_terminal() ) )
			    return false;
			    
			if ( !cart.selectIdentity ( ltr.get_fk_cartao() ) )
				return false;
				
			ArrayList lstContent = new ArrayList();
			
			lstContent.Add ( "Gift Card Lindóia Shopping" );
			lstContent.Add ( "Rede ConveyNET" );
			lstContent.Add ( "Cod. Estab: " + loj.get_st_loja() );
			lstContent.Add ( "Nr.Cartao: " + cart.get_st_empresa() + "." + cart.get_st_matricula() );
			lstContent.Add ( "No. Terminal: " + term.get_nu_terminal() );
			lstContent.Add ( "Loja: " + loj.get_st_nome() );
			lstContent.Add ( "--------------------------------------" );
			lstContent.Add ( "Cod.Process.: 2000 - Cartao Convenio" );
			
			string data = ltr.get_dt_transacao();
			
			lstContent.Add ( "Data Trans.: " + data.Substring ( 8, 2 ) + "/" +
			                                   data.Substring ( 5, 2 ) + "/" + 
			                                   data.Substring ( 0, 4 ) + " Hora: " + 
			                                   data.Substring ( 11, 8 ) );
			                                                  
			lstContent.Add ( "NSU: " + ltr.get_nu_nsu() );
			lstContent.Add ( "" );
			lstContent.Add ( "" );
			lstContent.Add ( "VALOR TOT. R$ " + new money().formatToMoney ( ltr.get_vr_total() ) );
			lstContent.Add ( "" );
			lstContent.Add ( "" );
			lstContent.Add ( "Operador: " + user.get_st_nome() );
						
			for (int t=0; t < lstContent.Count; ++t )
			{
				DataPortable port = new DataPortable();
				port.setValue ( "linha", lstContent[t].ToString() );
				output_array_generic_lst.Add ( port );
			}	
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_reciboVendaGift " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_reciboVendaGift " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				if ( !aud.select_rows_generic ( fk_transacao, TipoOperacao.VendaGift ) )
				{
					aud.set_tg_operacao	( TipoOperacao.VendaGift );
					
					aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
					aud.set_dt_operacao ( GetDataBaseTime() 					);
					
					aud.set_st_observacao ( "NSU:" + input_nsu + " - " + user.get_st_nome() );
					
					aud.set_fk_generic  ( fk_transacao );
					
					if ( !aud.create_LOG_Audit() )
						return false;
				}
			}
		
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_reciboVendaGift " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_FETCH_RECIBOVENDAGIFT.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			return true;
		}
	}
}
