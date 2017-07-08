using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_pf_graficoGerencial : Transaction
	{
		public string input_tg_tipo = "";
		
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_pf_graficoGerencial ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_pf_graficoGerencial";
			constructor();
		}
		
		public exec_pf_graficoGerencial()
		{
			var_Alias = "exec_pf_graficoGerencial";
		
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
			Registry ( "setup exec_pf_graficoGerencial " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_PF_GRAFICOGERENCIAL.tg_tipo, ref input_tg_tipo ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_PF_GRAFICOGERENCIAL.tg_tipo missing! " ); 
				return false;
			}
			
			Registry ( "setup done exec_pf_graficoGerencial " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate exec_pf_graficoGerencial " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_pf_graficoGerencial " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute exec_pf_graficoGerencial " ); 
		
			/// USER [ execute ]
			
			string dt_start = ""; 			
			string dt_end   = ""; 
			
			if ( input_tg_tipo == "01" )
			{
				dt_start = GetTodayStartTime();
				dt_end   = GetTodayEndTime();
			}
			else if ( input_tg_tipo == "02" )
			{
				dt_start = GetMonthStartTime();
				dt_end   = GetMonthEndTime();
			}
			
			long Conf = 0;
			long Canc = 0;
			long Neg  = 0;
			long Pend = 0;
			
			LOG_Transacoes ltr = new LOG_Transacoes (this);
			
			if ( ltr.select_rows_dt ( dt_start, dt_end ) )
			{
				while ( ltr.fetch() )
				{
					if ( ltr.get_tg_confirmada() ==  TipoConfirmacao.Cancelada )
					{
						++Canc;	
					}
					else if ( ltr.get_tg_confirmada() ==  TipoConfirmacao.Confirmada )
					{
						++Conf;
					}
					else if ( ltr.get_tg_confirmada() ==  TipoConfirmacao.Negada ||  
					          ltr.get_tg_confirmada() ==  TipoConfirmacao.Erro )
					{
						++Neg;
					}
					else if ( ltr.get_tg_confirmada() ==  TipoConfirmacao.Pendente )
					{
						++Pend;
					}
				}					
			}
			
			{
				DataPortable dp = new DataPortable();
				
				dp.setValue ( "desc", "Canc" );
				dp.setValue ( "valor", Canc.ToString() );
				             
				output_array_generic_lst.Add ( dp );
			}
			
			{
				DataPortable dp = new DataPortable();
				
				dp.setValue ( "desc", "Conf" );
				dp.setValue ( "valor", Conf.ToString() );
				             
				output_array_generic_lst.Add ( dp );
			}
			
			{
				DataPortable dp = new DataPortable();
				
				dp.setValue ( "desc", "Neg" );
				dp.setValue ( "valor", Neg.ToString() );
				             
				output_array_generic_lst.Add ( dp );
			}
			
			{
				DataPortable dp = new DataPortable();
				
				dp.setValue ( "desc", "Pend" );
				dp.setValue ( "valor", Pend.ToString() );
				             
				output_array_generic_lst.Add ( dp );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_pf_graficoGerencial " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish exec_pf_graficoGerencial " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done exec_pf_graficoGerencial " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_EXEC_PF_GRAFICOGERENCIAL.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			return true;
		}
	}
}
