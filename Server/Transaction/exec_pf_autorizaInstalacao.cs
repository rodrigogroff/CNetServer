using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_pf_autorizaInstalacao : Transaction
	{
		public string input_st_codigo = "";
		
		public string output_st_codResp = "";
		public string output_st_msg = "";
		public string output_st_telefone = "";
		public string output_st_terminal = "";
		public string output_tg_tipoCelular = "";
		public string output_st_lojaTB = "";
		
		/// USER [ var_decl ]
		
		LINK_PFAtivacao pf_ativa;
		
		/// USER [ var_decl ] END
		
		public exec_pf_autorizaInstalacao ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_pf_autorizaInstalacao";
			constructor();
		}
		
		public exec_pf_autorizaInstalacao()
		{
			var_Alias = "exec_pf_autorizaInstalacao";
		
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
			Registry ( "setup exec_pf_autorizaInstalacao " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_PF_AUTORIZAINSTALACAO.st_codigo, ref input_st_codigo ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_PF_AUTORIZAINSTALACAO.st_codigo missing! " ); 
				return false;
			}
			
			Registry ( "setup done exec_pf_autorizaInstalacao " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate exec_pf_autorizaInstalacao " ); 
		
			/// USER [ authenticate ]
			
			pf_ativa = new LINK_PFAtivacao (this);
			
			pf_ativa.ExclusiveAccess();
			
			if ( !pf_ativa.select_rows_ativ ( input_st_codigo ) )
			{
				output_st_codResp = "01";
				output_st_msg     = "Código inexistente";
				return false;
			}
			
			if ( !pf_ativa.fetch() )
			{
				output_st_codResp = "80";
				output_st_msg     = "Erro aplicativo";
				return false;
			}
			
			if ( pf_ativa.get_tg_status() == Context.CLOSED )
			{
				output_st_codResp = "02";
				output_st_msg     = "Ativação inválida";
				return false;
			}
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_pf_autorizaInstalacao " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute exec_pf_autorizaInstalacao " ); 
		
			/// USER [ execute ]
			
			T_PayFone pf = new T_PayFone (this);
			
			if ( !pf.selectIdentity ( pf_ativa.get_fk_payfone() ) )
			{
				output_st_codResp = "80";
				output_st_msg     = "Erro aplicativo";
				return false;
			}
			
			output_st_telefone = pf.get_st_telefone();
			
			if ( pf.get_tg_tipoCelular() == TipoCelular.LOJA )
			{
				output_tg_tipoCelular = "0";
				
				T_Terminal term = new T_Terminal (this);
				
				if ( !term.selectIdentity ( pf.get_fk_terminal() ) )
				{
					output_st_codResp = "80";
					output_st_msg     = "Erro aplicativo";
					return false;
				}
				
				output_st_terminal = term.get_nu_terminal();
			}
			else
			{
				output_tg_tipoCelular = "1";
			}
			
			pf_ativa.set_tg_status 		( Context.CLOSED 	);
			pf_ativa.set_dt_ativacao 	( GetDataBaseTime() );
			
			if ( !pf_ativa.synchronize_LINK_PFAtivacao() )
			{
				output_st_codResp = "80";
				output_st_msg     = "Erro aplicativo";
				return false;
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_pf_autorizaInstalacao " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish exec_pf_autorizaInstalacao " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done exec_pf_autorizaInstalacao " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_EXEC_PF_AUTORIZAINSTALACAO.st_codResp, output_st_codResp ); 
			dp_out.MapTagValue ( COMM_OUT_EXEC_PF_AUTORIZAINSTALACAO.st_msg, output_st_msg ); 
			dp_out.MapTagValue ( COMM_OUT_EXEC_PF_AUTORIZAINSTALACAO.st_telefone, output_st_telefone ); 
			dp_out.MapTagValue ( COMM_OUT_EXEC_PF_AUTORIZAINSTALACAO.st_terminal, output_st_terminal ); 
			dp_out.MapTagValue ( COMM_OUT_EXEC_PF_AUTORIZAINSTALACAO.tg_tipoCelular, output_tg_tipoCelular ); 
			dp_out.MapTagValue ( COMM_OUT_EXEC_PF_AUTORIZAINSTALACAO.st_lojaTB, output_st_lojaTB ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
