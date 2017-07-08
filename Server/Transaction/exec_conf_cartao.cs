using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_conf_cartao : type_base
	{
		public string input_st_cartao = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_conf_cartao ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_conf_cartao";
			constructor();
		}
		
		public exec_conf_cartao()
		{
			var_Alias = "exec_conf_cartao";
		
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
			Registry ( "setup exec_conf_cartao " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_CONF_CARTAO.st_cartao, ref input_st_cartao ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_CONF_CARTAO.st_cartao missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_CONF_CARTAO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_CONF_CARTAO.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_conf_cartao " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_conf_cartao " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_conf_cartao " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_conf_cartao " ); 
		
			/// USER [ execute ]
			 
			// ## Busca cartão específico
			
			T_Cartao cart = new T_Cartao (this);
			
			cart.ExclusiveAccess();
			
			if ( !cart.select_rows_tudo ( 	input_st_cartao.Substring (0,6), 
			                             	input_st_cartao.Substring (6,6), 
			                             	input_st_cartao.Substring (12,2) ) )
			{
				PublishError ( "Cartão inválido" );
				return false;
			}
			
			if ( !cart.fetch() )
				return false;
				
			// ## Confirma se já foi expedido
			
			if ( cart.get_tg_emitido() == StatusExpedicao.Expedido )
			{
				PublishError ( "Cartão previamente confirmado" );
				return false;
			}
			
			if ( cart.get_nu_viaCartao() != input_st_cartao.Substring (14,1) )
			{
				PublishError ( "Via de cartão inválida, não corresponde a ultima via requerida" );
				return false;
			}
			
			// ## seta como expedido neste momento
			
			cart.set_tg_emitido ( StatusExpedicao.Expedido );
			
			// ## Atualiza
			
			if ( !cart.synchronize_T_Cartao() )
				return false;
			
			PublishNote ( "Cartão expedido com sucesso" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_conf_cartao " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_conf_cartao " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.ConfCartConv      		);
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( "" );
				
				aud.set_fk_generic  ( 0 );
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_conf_cartao " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
