using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_pf_consultaPendencia : type_pf_base
	{
		public string output_st_nsu = "";
		public string output_st_valor = "";
		public string output_st_nomeLoja = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_pf_consultaPendencia ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_pf_consultaPendencia";
			constructor();
		}
		
		public exec_pf_consultaPendencia()
		{
			var_Alias = "exec_pf_consultaPendencia";
		
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
			Registry ( "setup exec_pf_consultaPendencia " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_PF_CONSULTAPENDENCIA.st_telefone, ref input_st_telefone ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_PF_CONSULTAPENDENCIA.st_telefone missing! " ); 
				return false;
			}
			
			Registry ( "setup done exec_pf_consultaPendencia " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_pf_consultaPendencia " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_pf_consultaPendencia " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_pf_consultaPendencia " ); 
		
			/// USER [ execute ]

			// ## Busca pendênciade um cartão
			
			T_PendPayFone pendPayFone = new T_PendPayFone (this);
			
			if ( !pendPayFone.select_rows_cart_sit ( pf_usuario.get_fk_cartao(), 
			                                        TipoPendPayFone.PENDENTE ) )
			{
				output_st_codResp = "01"; 
				output_st_msg = "Nenhuma pendencia";
				return false;
			}
			
			if ( !pendPayFone.fetch() )
			{
				output_st_codResp = "80"; 
				output_st_msg = "Erro de aplicativo";
				return false;
			}
			
			// ## Busca terminal da pendência
			
			T_Terminal tmp_term = new T_Terminal (this);
			
			if ( !tmp_term.selectIdentity ( pendPayFone.get_fk_terminal() ) )
			{
				output_st_codResp = "80"; 
				output_st_msg = "Erro de aplicativo";
				return false;
			}
			
			// ## Busca Loja vinculada ao terminal
			
			T_Loja loj = new T_Loja (this);
			
			if ( !loj.selectIdentity ( tmp_term.get_fk_loja() ) )
			{
				output_st_codResp = "80"; 
				output_st_msg = "Erro de aplicativo";
				return false;
			}
			
			// ## Devolve nsu, valor e nome da loja
			
			output_st_nsu 		= pendPayFone.get_nu_nsu();
			output_st_valor 	= pendPayFone.get_vr_valor();
			output_st_nomeLoja  = loj.get_st_nome();
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_pf_consultaPendencia " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_pf_consultaPendencia " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done exec_pf_consultaPendencia " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_EXEC_PF_CONSULTAPENDENCIA.st_nsu, output_st_nsu ); 
			dp_out.MapTagValue ( COMM_OUT_EXEC_PF_CONSULTAPENDENCIA.st_valor, output_st_valor ); 
			dp_out.MapTagValue ( COMM_OUT_EXEC_PF_CONSULTAPENDENCIA.st_nomeLoja, output_st_nomeLoja ); 
			dp_out.MapTagValue ( COMM_OUT_EXEC_PF_CONSULTAPENDENCIA.st_codResp, output_st_codResp ); 
			dp_out.MapTagValue ( COMM_OUT_EXEC_PF_CONSULTAPENDENCIA.st_msg, output_st_msg ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
