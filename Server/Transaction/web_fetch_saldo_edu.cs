using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class web_fetch_saldo_edu : Transaction
	{
		public string input_st_cartao = "";
		public string input_st_senha = "";
		public string input_tg_resp = "";
		
		public DadosCartaoEdu output_cont_dce = new DadosCartaoEdu();
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public web_fetch_saldo_edu ( Transaction trans ) : base (trans)
		{
			var_Alias = "web_fetch_saldo_edu";
			constructor();
		}
		
		public web_fetch_saldo_edu()
		{
			var_Alias = "web_fetch_saldo_edu";
		
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
			Registry ( "setup web_fetch_saldo_edu " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_FETCH_SALDO_EDU.st_cartao, ref input_st_cartao ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_FETCH_SALDO_EDU.st_cartao missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_FETCH_SALDO_EDU.st_senha, ref input_st_senha ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_FETCH_SALDO_EDU.st_senha missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_FETCH_SALDO_EDU.tg_resp, ref input_tg_resp ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_FETCH_SALDO_EDU.tg_resp missing! " ); 
				return false;
			}
			
			Registry ( "setup done web_fetch_saldo_edu " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate web_fetch_saldo_edu " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done web_fetch_saldo_edu " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute web_fetch_saldo_edu " ); 
		
			/// USER [ execute ]
			
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
			
			if ( input_tg_resp == Context.TRUE )
			{
				T_Proprietario prot = new T_Proprietario (this);
				
				if ( !prot.selectIdentity ( cart.get_fk_dadosProprietario() ) )
					return false;
				
				if ( prot.get_st_senhaEdu() != input_st_senha )
				{
					PublishError ( "Senha responsável inválida" );
					return false;
				}
			}
			else
			{
				if ( cart.get_st_senha() != input_st_senha )
				{
					PublishError ( "Senha aluno inválida" );
					return false;
				}
			}
						
			output_cont_dce.set_st_aluno  ( cart.get_st_aluno() 			);
			output_cont_dce.set_vr_diario ( cart.get_vr_edu_diario() 		);
			output_cont_dce.set_vr_disp   ( cart.get_vr_disp_educacional() 	);
			output_cont_dce.set_vr_depot  ( cart.get_vr_educacional() 		);
			output_cont_dce.set_tg_semanaToda ( cart.get_tg_semanaCompleta() );
			
			/// USER [ execute ] END
		
			Registry ( "execute done web_fetch_saldo_edu " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish web_fetch_saldo_edu " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done web_fetch_saldo_edu " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_cont_1 = new DataPortable();
		
			dp_cont_1.MapTagContainer ( COMM_OUT_WEB_FETCH_SALDO_EDU.dce , output_cont_dce as DataPortable );
		
			var_Comm.AddExitPortable ( ref dp_cont_1 ); 
		
			return true;
		}
	}
}
