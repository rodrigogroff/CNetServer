using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class del_agenda : type_base
	{
		public string input_fk_agenda = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public del_agenda ( Transaction trans ) : base (trans)
		{
			var_Alias = "del_agenda";
			constructor();
		}
		
		public del_agenda()
		{
			var_Alias = "del_agenda";
		
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
			Registry ( "setup del_agenda " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_DEL_AGENDA.fk_agenda, ref input_fk_agenda ) == false ) 
			{
				Trace ( "# COMM_IN_DEL_AGENDA.fk_agenda missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_DEL_AGENDA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_DEL_AGENDA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done del_agenda " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate del_agenda " ); 
		
			/// USER [ authenticate ]
			
			LINK_Agenda la = new LINK_Agenda(this);
			
			if ( !la.selectIdentity ( input_fk_agenda ) )
			{
				PublishError ( "Agenda não encontrada" );
				return false;
			}
			
			I_Scheduler sch = new I_Scheduler (this);
			
			if ( !sch.selectIdentity ( la.get_fk_schedule() ) )
				return false;
			
			if ( !sch.delete() )
				return false;
			
			if ( !la.delete() )
				return false;
						
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done del_agenda " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute del_agenda " ); 
		
			/// USER [ execute ]
			
			PublishNote ( "Agendamento removido com sucesso" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done del_agenda " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish del_agenda " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.RemAgenda 				);
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( "" );
				
				aud.set_fk_generic  ( input_fk_agenda  );
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done del_agenda " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
