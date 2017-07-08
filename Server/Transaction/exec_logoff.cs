using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_logoff : type_base
	{
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_logoff ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_logoff";
			constructor();
		}
		
		public exec_logoff()
		{
			var_Alias = "exec_logoff";
		
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
			Registry ( "setup exec_logoff " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_EXEC_LOGOFF.header, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_LOGOFF.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_0 );
			
			Registry ( "setup done exec_logoff " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_logoff " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_logoff " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_logoff " ); 
		
			/// USER [ execute ]
			
			// ## Busco cartão específico
			
			user.ExclusiveAccess();
			
			if ( !user.selectIdentity ( input_cont_header.get_st_user_id() ) )
				return false;
						
			user.set_dt_ultUso ( GetDataBaseTime() 	);
			
			// ## Confirmo que logoff foi feito com sucesso
			
			user.set_tg_logoff ( Context.TRUE 		);
			
			// ## Atualizo
			
			if ( !user.synchronize_T_Usuario() )
				return false;
						
			/// USER [ execute ] END
		
			Registry ( "execute done exec_logoff " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_logoff " ); 
		
			/// USER [ finish ]
			
			// ## Crio registro de auditoria
			
			LOG_Audit aud = new LOG_Audit (this);
			
			aud.set_tg_operacao	( TipoOperacao.Logoff 					);
			aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
			aud.set_dt_operacao ( GetDataBaseTime() 					);
			aud.set_fk_generic  ( user.get_identity() 					);
			
			if ( !aud.create_LOG_Audit() )
				return false;
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_logoff " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
