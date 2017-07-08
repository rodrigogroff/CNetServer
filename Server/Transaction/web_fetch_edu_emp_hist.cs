using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class web_fetch_edu_emp_hist : Transaction
	{
		public string input_st_cartao = "";
		public string input_st_senha = "";
		public string input_st_codigo = "";
		
		public string output_st_csv = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public web_fetch_edu_emp_hist ( Transaction trans ) : base (trans)
		{
			var_Alias = "web_fetch_edu_emp_hist";
			constructor();
		}
		
		public web_fetch_edu_emp_hist()
		{
			var_Alias = "web_fetch_edu_emp_hist";
		
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
			Registry ( "setup web_fetch_edu_emp_hist " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_FETCH_EDU_EMP_HIST.st_cartao, ref input_st_cartao ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_FETCH_EDU_EMP_HIST.st_cartao missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_FETCH_EDU_EMP_HIST.st_senha, ref input_st_senha ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_FETCH_EDU_EMP_HIST.st_senha missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_FETCH_EDU_EMP_HIST.st_codigo, ref input_st_codigo ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_FETCH_EDU_EMP_HIST.st_codigo missing! " ); 
				return false;
			}
			
			Registry ( "setup done web_fetch_edu_emp_hist " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate web_fetch_edu_emp_hist " ); 
		
			/// USER [ authenticate ]
			
			input_st_cartao = input_st_cartao.PadLeft ( 14, '0' );
			
			T_Cartao cart = new T_Cartao (this);
			
			if ( !cart.select_rows_tudo ( input_st_cartao.Substring (  0,6 ),
			                              input_st_cartao.Substring (  6,6 ),
			                              input_st_cartao.Substring ( 12,2 ) ) )
          	{
				PublishError ( "Cartão inválido" );
				return false;
          	}
			
			if ( !cart.fetch() )
				return false;
			
			if ( cart.get_st_senha() != input_st_senha )
			{
				PublishError ( "Senha aluno inválida" );
				return false;
			}
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done web_fetch_edu_emp_hist " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute web_fetch_edu_emp_hist " ); 
		
			/// USER [ execute ]
			
			StringBuilder sb = new StringBuilder();
			
			LOG_Edu_RendimentoEmpresa rend_emp = new LOG_Edu_RendimentoEmpresa (this);		
			T_Edu_EmpresaVirtual      emp      = new T_Edu_EmpresaVirtual (this);
			
			if ( !emp.select_rows_codigo ( input_st_codigo ) )
			{
				PublishError ( "Código inválido" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			for (int t=0; t < 31; ++t )
			{
				DateTime tim = DateTime.Now.AddDays ( -t );
				
				string dt_dia =  tim.Year.ToString() + "-" + 
                                 tim.Month.ToString().PadLeft ( 2, '0' ) + "-" + 
                                 tim.Day.ToString().PadLeft ( 2, '0' ) + " 00:00:00";
				
				if ( rend_emp.select_rows_date ( dt_dia, emp.get_identity() ) )
				{
					if ( !rend_emp.fetch() )
						return false;
										
					DadosMovEmpresaVirtual mov = new DadosMovEmpresaVirtual();
								
					if ( rend_emp.get_tg_neg() == Context.TRUE )
						mov.set_vr_osc ( "-" + rend_emp.get_vr_pct() );
					else
						mov.set_vr_osc ( rend_emp.get_vr_pct() );
					
					mov.set_dt_dia      ( dt_dia 				);
					mov.set_st_nome     ( emp.get_st_nome() 	);
									
					DataPortable mem = mov as DataPortable;
				
					string index = MemorySave ( ref mem );
					
					sb.Append ( index );
					sb.Append ( ","   );
				}
			}
		
			output_st_csv = sb.ToString().TrimEnd ( ',' );
			
			/// USER [ execute ] END
		
			Registry ( "execute done web_fetch_edu_emp_hist " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish web_fetch_edu_emp_hist " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done web_fetch_edu_emp_hist " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_WEB_FETCH_EDU_EMP_HIST.st_csv, output_st_csv ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
