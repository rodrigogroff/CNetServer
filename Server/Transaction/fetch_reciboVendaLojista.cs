using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_reciboVendaLojista : type_base
	{
		public string input_nsu_venda = "";
		
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_reciboVendaLojista ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_reciboVendaLojista";
			constructor();
		}
		
		public fetch_reciboVendaLojista()
		{
			var_Alias = "fetch_reciboVendaLojista";
		
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
			Registry ( "setup fetch_reciboVendaLojista " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_RECIBOVENDALOJISTA.nsu_venda, ref input_nsu_venda ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_RECIBOVENDALOJISTA.nsu_venda missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_RECIBOVENDALOJISTA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_RECIBOVENDALOJISTA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_reciboVendaLojista " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_reciboVendaLojista " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_reciboVendaLojista " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_reciboVendaLojista " ); 
		
			/// USER [ execute ]
			
			LOG_Transacoes 	ltr 	= new LOG_Transacoes 	(this);
			T_Loja 			loj 	= new T_Loja 			(this);
			T_Terminal		term    = new T_Terminal		(this);
			T_Cartao 		cart 	= new T_Cartao 			(this);
					
			if ( !ltr.select_rows_nsu ( input_nsu_venda, GetTodayStartTime(), GetTodayEndTime() ) )
				return false;
			
			if ( !ltr.fetch() )
				return false;
			
			if ( !loj.selectIdentity ( ltr.get_fk_loja() ) ) 
				return false;
			
			if ( !term.selectIdentity ( ltr.get_fk_terminal() ) )
			    return false;
			    
			if ( !cart.selectIdentity ( ltr.get_fk_cartao() ) )
				return false;
				
			ArrayList lstContent = new ArrayList();
			
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
			
			if ( ltr.get_int_nu_parcelas() == 1 )
			{
				lstContent.Add ( "VALOR TOT. R$ " + new money().formatToMoney ( ltr.get_vr_total() ) );
				lstContent.Add ( "" );
				lstContent.Add ( "" );
			}
			else
			{
				T_Parcelas parc = new T_Parcelas(this);
				
				int t=1;
				
				if ( parc.select_fk_log_trans ( ltr.get_identity() ) )
				{
					while ( parc.fetch() )
					{
						lstContent.Add ( "Parcela (" + t.ToString() + ") R$ " + new money().formatToMoney ( parc.get_vr_valor() ) );
						++t;
					}
					
					lstContent.Add ( "" );
					lstContent.Add ( "" );
				}
			}
			lstContent.Add ( "Operador: " + user.get_st_nome() );
						
			for (int t=0; t < lstContent.Count; ++t )
			{
				DataPortable port = new DataPortable();
				port.setValue ( "linha", lstContent[t].ToString() );
				output_array_generic_lst.Add ( port );
			}	
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_reciboVendaLojista " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_reciboVendaLojista " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_reciboVendaLojista " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_FETCH_RECIBOVENDALOJISTA.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			return true;
		}
	}
}
