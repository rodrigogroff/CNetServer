using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_desbloqueio : type_base
	{
		public string input_st_cartao = "";
		
		/// USER [ var_decl ]
		
		string st_mat = "";
		
		/// USER [ var_decl ] END
		
		public exec_desbloqueio ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_desbloqueio";
			constructor();
		}
		
		public exec_desbloqueio()
		{
			var_Alias = "exec_desbloqueio";
		
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
			Registry ( "setup exec_desbloqueio " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_DESBLOQUEIO.st_cartao, ref input_st_cartao ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_DESBLOQUEIO.st_cartao missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_DESBLOQUEIO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_DESBLOQUEIO.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_desbloqueio " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_desbloqueio " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_desbloqueio " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_desbloqueio " ); 
		
			/// USER [ execute ]
			
			input_st_cartao = input_st_cartao.PadLeft ( 14, '0' );
			
			// ## Busca cartão informado no client
			
			T_Cartao cart = new T_Cartao (this);
			
			cart.ExclusiveAccess();
			
			if ( !cart.select_rows_tudo ( input_st_cartao.Substring ( 0, 6 ),
			                              input_st_cartao.Substring ( 6, 6 ),
			                              input_st_cartao.Substring ( 12, 2 ) ) )
          	{
				PublishError ( "Cartão Inválido" );
				return false;
          	}
			
			if ( !cart.fetch() )
				return false;
			
			// ## Confere se já foi habilitado
			
			if ( cart.get_tg_status() == CartaoStatus.Habilitado )
			{
				PublishError ( "Cartão previamente desbloqueado" );
				return false;
			}
	
			/*
			if ( cart.get_tg_motivoBloqueio() == MotivoBloqueio.CANCELAMENTO )
			{
				PublishError ( "Cartão cancelado não pode ser desbloqueado" );
				return false;
			}
			*/
			
			st_mat = cart.get_st_matricula();
			
			// ## Atualiza
			
			cart.set_tg_status 		( CartaoStatus.Habilitado 	);
			cart.set_nu_senhaErrada ( "0" 						);			
			
			if ( !cart.synchronize_T_Cartao() )
				return false;
			
			PublishNote ( "Cartão desbloqueado" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_desbloqueio " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_desbloqueio " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao		( TipoOperacao.DesbloqueioCartao		);
				aud.set_fk_usuario		( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao 	( GetDataBaseTime() 					);
				aud.set_st_observacao 	( st_mat + " - " + user.get_st_nome() 					);
				aud.set_fk_generic  	( user.get_identity() 					);
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_desbloqueio " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
