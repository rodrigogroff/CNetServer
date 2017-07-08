using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_bloqueio : type_base
	{
		public string input_st_cartao = "";
		public string input_st_motivo = "";
		
		/// USER [ var_decl ]
		
		string st_mat = "";
		string st_emp = "";
		string fk_cartao = "";
		
		bool canc = false;
		
		/// USER [ var_decl ] END
		
		public exec_bloqueio ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_bloqueio";
			constructor();
		}
		
		public exec_bloqueio()
		{
			var_Alias = "exec_bloqueio";
		
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
			Registry ( "setup exec_bloqueio " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_BLOQUEIO.st_cartao, ref input_st_cartao ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_BLOQUEIO.st_cartao missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_BLOQUEIO.st_motivo, ref input_st_motivo ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_BLOQUEIO.st_motivo missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_BLOQUEIO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_BLOQUEIO.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_bloqueio " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_bloqueio " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_bloqueio " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_bloqueio " ); 
		
			/// USER [ execute ]
			
			// ## Busca cartão específico
			
			T_Cartao cart = new T_Cartao (this);
			
			input_st_cartao = input_st_cartao.PadLeft ( 14, '0' );
			
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
			
			// ## Confere status
			
			if ( cart.get_tg_status() == CartaoStatus.Bloqueado )
			{
				PublishError ( "Cartão previamente bloqueado" );
				return false;
			}
			
			cart.set_tg_motivoBloqueio 	( input_st_motivo 			);
			cart.set_tg_status       	( CartaoStatus.Bloqueado 	);
			cart.set_dt_bloqueio		( GetDataBaseTime()			);
			
			if ( cart.get_tg_motivoBloqueio() == MotivoBloqueio.CANCELAMENTO )
			{
				canc = true;
			
				if ( cart.get_tg_tipoCartao() == TipoCartao.presente )
					cart.set_vr_limiteTotal ( 0 );
			}
			
			st_mat = cart.get_st_matricula();
			st_emp = cart.get_st_empresa();
			
			fk_cartao = cart.get_identity();
			
			// ## Atualiza
			
			if ( !cart.synchronize_T_Cartao() )
				return false;
			
			PublishNote ( "Cartão bloqueado" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_bloqueio " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_bloqueio " ); 
		
			/// USER [ finish ]
			
			// ## Grava registro de auditoria
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				if ( !canc )
					aud.set_tg_operacao	( TipoOperacao.BloqueioCartao		);
				else
					aud.set_tg_operacao	( TipoOperacao.CancelamentoCartao	);
				
				aud.set_fk_usuario		( input_cont_header.get_st_user_id() 				 );
				aud.set_dt_operacao 	( GetDataBaseTime() 								 );
				aud.set_st_observacao 	( st_emp + "." + st_mat + " - " + user.get_st_nome() );
				aud.set_fk_generic  	( fk_cartao 										 );
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_bloqueio " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
