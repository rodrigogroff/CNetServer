using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_canc_dia_lojista : type_base
	{
		public string output_st_content = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_canc_dia_lojista ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_canc_dia_lojista";
			constructor();
		}
		
		public fetch_canc_dia_lojista()
		{
			var_Alias = "fetch_canc_dia_lojista";
		
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
			Registry ( "setup fetch_canc_dia_lojista " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_FETCH_CANC_DIA_LOJISTA.header, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_CANC_DIA_LOJISTA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_0 );
			
			Registry ( "setup done fetch_canc_dia_lojista " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_canc_dia_lojista " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_canc_dia_lojista " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_canc_dia_lojista " ); 
		
			/// USER [ execute ]
			
			T_Terminal term  = new T_Terminal (this);
			
			if ( !term.select_rows_terminal ( input_cont_header.get_nu_terminal() ) )
				return false;
			
			if ( !term.fetch() )
				return false;
			
			DateTime tim = new DateTime ( DateTime.Now.Year, 
			                              DateTime.Now.Month,
			                              DateTime.Now.Day );
			
			LOG_Transacoes ltr = new LOG_Transacoes (this);
			
			if ( !ltr.select_rows_dt_loj ( 	GetDataBaseTime ( tim) , 
			                        		GetDataBaseTime ( tim.AddDays(1) ) ,
			                        		term.get_fk_loja() ) )
			{
				PublishError ( "Nenhum registro encontrado" );
				return false;
			}
			
			StringBuilder sb = new StringBuilder();
			
			T_Cartao cart = new T_Cartao (this);
			
			while ( ltr.fetch() )
			{
				if ( !cart.selectIdentity ( ltr.get_fk_cartao() ) )
					continue;
				
				if ( ltr.get_tg_confirmada() != TipoConfirmacao.Confirmada )
					continue;
				
				string st_cartao =  cart.get_st_empresa() + 
					 				cart.get_st_matricula() + 
									cart.get_st_titularidade();
				
				DadosConsultaTransacao dct = new DadosConsultaTransacao();
				
				dct.set_vr_valor ( ltr.get_vr_total() );
				dct.set_st_nsu   ( ltr.get_nu_nsu()   );
				dct.set_dt_transacao ( ltr.get_dt_transacao() );
				dct.set_st_cartao  ( st_cartao );
				
				DataPortable tmp = dct as DataPortable;
				
				// ## Obtem identificador para registro
					
				sb.Append ( MemorySave ( ref tmp ) );
				sb.Append ( "," 				   );
			}
			
			string list_ids = sb.ToString().TrimEnd ( ',' );
			
			if ( list_ids == "" )
			{
				PublishNote ( "Nenhum resultado foi encontrado" );
				return true;
			}
											
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", list_ids );
			
			output_st_content = MemorySave ( ref dp );			
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_canc_dia_lojista " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_canc_dia_lojista " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_canc_dia_lojista " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_CANC_DIA_LOJISTA.st_content, output_st_content ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
