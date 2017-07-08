using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class web_exec_confirmaBoleto : Transaction
	{
		public string input_vr_fundoEdu = "";
		public string input_vr_imediato = "";
		public string input_st_cartao = "";
		
		public string output_st_id = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public web_exec_confirmaBoleto ( Transaction trans ) : base (trans)
		{
			var_Alias = "web_exec_confirmaBoleto";
			constructor();
		}
		
		public web_exec_confirmaBoleto()
		{
			var_Alias = "web_exec_confirmaBoleto";
		
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
			Registry ( "setup web_exec_confirmaBoleto " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_EXEC_CONFIRMABOLETO.vr_fundoEdu, ref input_vr_fundoEdu ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_EXEC_CONFIRMABOLETO.vr_fundoEdu missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_EXEC_CONFIRMABOLETO.vr_imediato, ref input_vr_imediato ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_EXEC_CONFIRMABOLETO.vr_imediato missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_EXEC_CONFIRMABOLETO.st_cartao, ref input_st_cartao ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_EXEC_CONFIRMABOLETO.st_cartao missing! " ); 
				return false;
			}
			
			Registry ( "setup done web_exec_confirmaBoleto " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate web_exec_confirmaBoleto " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done web_exec_confirmaBoleto " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute web_exec_confirmaBoleto " ); 
		
			/// USER [ execute ]
			
			T_BoletoEdu bol = new T_BoletoEdu(this);
			
			bol.set_dt_emissao 	   ( GetDataBaseTime() );
			bol.set_vr_educacional ( input_vr_fundoEdu );
			bol.set_vr_imediato    ( input_vr_imediato );
			
			T_Cartao cart = new T_Cartao (this);			
					
			if ( !cart.select_rows_tudo ( 	input_st_cartao.Substring (0,6), 		// empresa
			                            	input_st_cartao.Substring (6,6), 		// matricula
			                            	input_st_cartao.Substring (12,2) ) )	// titularidade
			{
				PublishError ( "Cartão inválido" );
				return false;
			}
			else
			{
				if ( !cart.fetch() )
					return false;
			}
			
			bol.set_fk_cartao ( cart.get_identity() );
			
			if ( !bol.create_T_BoletoEdu() )
				return false;		
			
			output_st_id = bol.get_identity();
			
			/// USER [ execute ] END
		
			Registry ( "execute done web_exec_confirmaBoleto " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish web_exec_confirmaBoleto " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done web_exec_confirmaBoleto " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_WEB_EXEC_CONFIRMABOLETO.st_id, output_st_id ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
