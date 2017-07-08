using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_financ_lojista : type_base
	{
		public string input_dt = "";
		
		public string output_oper = "";
		public string output_vendas = "";
		public string output_canc = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_financ_lojista ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_financ_lojista";
			constructor();
		}
		
		public fetch_financ_lojista()
		{
			var_Alias = "fetch_financ_lojista";
		
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
			Registry ( "setup fetch_financ_lojista " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_FINANC_LOJISTA.dt, ref input_dt ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_FINANC_LOJISTA.dt missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_FINANC_LOJISTA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_FINANC_LOJISTA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_financ_lojista " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_financ_lojista " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_financ_lojista " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_financ_lojista " ); 
		
			/// USER [ execute ]
			
			T_Terminal term  = new T_Terminal (this);
			
			if ( !term.select_rows_terminal ( input_cont_header.get_nu_terminal() ) )
				return false;
			
			if ( !term.fetch() )
				return false;
			
			DateTime tim = new DateTime ( 	Convert.ToInt32 ( input_dt.Substring (0,4 ) ),
			                             	Convert.ToInt32 ( input_dt.Substring (5,2 ) ),
			                             	Convert.ToInt32 ( input_dt.Substring (8,2 ) ) );
			
			LOG_Transacoes ltr = new LOG_Transacoes (this);
			
			if ( !ltr.select_rows_dt_loj ( 	GetDataBaseTime ( tim ) , 
			                        		GetDataBaseTime ( tim.AddDays(1) ) ,
			                        		term.get_fk_loja() ) )
			{
				PublishError ( "Nenhum registro encontrado" );
				return false;
			}
			
			long vendas =  0;
			long canc =  0;
			int opers =  0;
			
			while ( ltr.fetch() )
			{
				if ( ltr.get_tg_confirmada() != TipoConfirmacao.Confirmada &&
					 ltr.get_tg_confirmada() != TipoConfirmacao.Cancelada )
				{
					continue;
				}
						
				opers++;
				
				if ( ltr.get_tg_confirmada() == TipoConfirmacao.Confirmada )
				{
					vendas += ltr.get_int_vr_total();
				}
				else
				{
					canc += ltr.get_int_vr_total();
				}
			}
			
			output_canc   = Convert.ToString ( canc 	);
			output_oper   = Convert.ToString ( opers 	);
			output_vendas = Convert.ToString ( vendas 	);
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_financ_lojista " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_financ_lojista " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_financ_lojista " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_FINANC_LOJISTA.oper, output_oper ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_FINANC_LOJISTA.vendas, output_vendas ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_FINANC_LOJISTA.canc, output_canc ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
