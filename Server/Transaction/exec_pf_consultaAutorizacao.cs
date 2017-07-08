using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_pf_consultaAutorizacao : type_pf_base
	{
		public string input_st_tel_lojista = "";
		
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		
		T_PayFone pf_lojista;
		
		/// USER [ var_decl ] END
		
		public exec_pf_consultaAutorizacao ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_pf_consultaAutorizacao";
			constructor();
		}
		
		public exec_pf_consultaAutorizacao()
		{
			var_Alias = "exec_pf_consultaAutorizacao";
		
			ut_max = 0;
			
			constructor();
		}
		
		public override void constructor()
		{
			/// USER [ constructor ]
			GravaNSU = false;
			/// USER [ constructor ] END
		}
		
		public override bool setup ( ) 
		{
			#region - SETUP TRANSACTION -
			Registry ( "setup exec_pf_consultaAutorizacao " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_PF_CONSULTAAUTORIZACAO.st_tel_lojista, ref input_st_tel_lojista ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_PF_CONSULTAAUTORIZACAO.st_tel_lojista missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_PF_CONSULTAAUTORIZACAO.st_telefone, ref input_st_telefone ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_PF_CONSULTAAUTORIZACAO.st_telefone missing! " ); 
				return false;
			}
			
			Registry ( "setup done exec_pf_consultaAutorizacao " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_pf_consultaAutorizacao " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_pf_consultaAutorizacao " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_pf_consultaAutorizacao " ); 
		
			/// USER [ execute ]
			
			// ## Busca telefone de lojista
			
			pf_lojista = new T_PayFone (this);
			
			if ( !pf_lojista.select_rows_telefone ( input_st_tel_lojista ) )
			{
				output_st_codResp = "98"; 
				output_st_msg = "Telefone invalido";
				return false;
			}
			
			if ( !pf_lojista.fetch() )
			{
				output_st_codResp = "80"; 
				output_st_msg = "Erro de aplicativo";
				return false;
			}
			
			// ## busca pendência pelo cartão e terminal
			
			T_PendPayFone pendPayFone = new T_PendPayFone (this);
			
			if ( pendPayFone.select_rows_cart_term ( cart.get_identity(), 
			                                         pf_lojista.get_fk_terminal() ) )
			{
				// ## Pega do mais novo ao mais antigo
				
				pendPayFone.SetReversedFetch();
				
				// ## Somente primeiros três registros
				
				while ( pendPayFone.fetch() && output_array_generic_lst.Count < 3 )
				{
					PF_DadosConsultaAutorizacao tmp = new PF_DadosConsultaAutorizacao();
					
					tmp.set_vr_valor ( pendPayFone.get_vr_valor() 		);
					tmp.set_st_nsu   ( pendPayFone.get_nu_nsu() 		);
					tmp.set_tg_sit   ( pendPayFone.get_en_situacao() 	);

					DateTime dt_data = Convert.ToDateTime ( pendPayFone.get_dt_inclusao() );
					
					tmp.set_dt_ocorr ( new StringBuilder().Append ( dt_data.Day.ToString().PadLeft(2, '0' ) )
										                  .Append ( @"/" )
										                  .Append ( dt_data.Month.ToString().PadLeft(2, '0' ) )
										                  .Append ( @"/" )
										                  .Append ( dt_data.Year.ToString() ).ToString() );
					
					output_array_generic_lst.Add ( tmp );
				}
			}
			
			while ( output_array_generic_lst.Count < 3 )
				output_array_generic_lst.Add ( new PF_DadosConsultaAutorizacao() );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_pf_consultaAutorizacao " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_pf_consultaAutorizacao " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done exec_pf_consultaAutorizacao " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_EXEC_PF_CONSULTAAUTORIZACAO.st_codResp, output_st_codResp ); 
			dp_out.MapTagValue ( COMM_OUT_EXEC_PF_CONSULTAAUTORIZACAO.st_msg, output_st_msg ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_EXEC_PF_CONSULTAAUTORIZACAO.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			return true;
		}
	}
}
