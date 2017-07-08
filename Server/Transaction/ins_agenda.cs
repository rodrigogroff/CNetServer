using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class ins_agenda : type_base
	{
		public string input_st_empresa = "";
		public string input_en_atividade = "";
		public string input_en_tipo_schedule = "";
		public string input_st_horario = "";
		public string input_st_aux = "";
		public string input_st_afiliada = "";
		
		/// USER [ var_decl ]
		
		T_Empresa emp;
		LINK_Agenda l_a;
		
		/// USER [ var_decl ] END
		
		public ins_agenda ( Transaction trans ) : base (trans)
		{
			var_Alias = "ins_agenda";
			constructor();
		}
		
		public ins_agenda()
		{
			var_Alias = "ins_agenda";
		
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
			Registry ( "setup ins_agenda " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_AGENDA.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_INS_AGENDA.st_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_AGENDA.en_atividade, ref input_en_atividade ) == false ) 
			{
				Trace ( "# COMM_IN_INS_AGENDA.en_atividade missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_AGENDA.en_tipo_schedule, ref input_en_tipo_schedule ) == false ) 
			{
				Trace ( "# COMM_IN_INS_AGENDA.en_tipo_schedule missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_AGENDA.st_horario, ref input_st_horario ) == false ) 
			{
				Trace ( "# COMM_IN_INS_AGENDA.st_horario missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_AGENDA.st_aux, ref input_st_aux ) == false ) 
			{
				Trace ( "# COMM_IN_INS_AGENDA.st_aux missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_AGENDA.st_afiliada, ref input_st_afiliada ) == false ) 
			{
				Trace ( "# COMM_IN_INS_AGENDA.st_afiliada missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_INS_AGENDA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_INS_AGENDA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done ins_agenda " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate ins_agenda " ); 
		
			/// USER [ authenticate ]
			
			emp = new T_Empresa ( this );
			l_a = new LINK_Agenda (this);
			
			input_st_empresa = input_st_empresa.PadLeft ( 6, '0' );
			
			if ( !emp.select_rows_empresa ( input_st_empresa ) )
			{
				PublishError ( "Código inválido de empresa" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			if ( input_en_atividade != TipoAtividade.FechMensal )
			{
				PublishError ( "Código inválido de atividade" );
				return false;
			}
			else
			{
				if ( input_en_tipo_schedule != Scheduler.Monthly )
				{
					PublishError ( "Esta atividade permite somente agendamento mensal" );
					return false;
				}
			}
			
			if ( l_a.select_rows_emp_ativ ( emp.get_identity(), input_en_atividade ) )
			{
				while ( l_a.fetch() )
				{
					if ( l_a.get_st_emp_afiliada().ToUpper().Trim() == input_st_afiliada.ToUpper().Trim() )
					{
						PublishError ( "Atividade previamente agendada" );
						return false;
					}
				}				
			}
				
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done ins_agenda " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute ins_agenda " ); 
		
			/// USER [ execute ]
			
			I_Scheduler schel = new I_Scheduler (this);
			
			if ( input_en_atividade == TipoAtividade.FechMensal )
			{
				string job = 	"schedule_fech_mensal;empresa;" + 
								input_st_empresa + ";afiliada;" + 
								input_st_afiliada;
				
				schel.set_st_job ( job );
			}
			
			schel.set_tg_type 			( input_en_tipo_schedule 	);
			schel.set_dt_specific 		( GetDataBaseTime() 		);
			schel.set_tg_status	 		( Context.OPEN				);
			
			switch ( input_en_tipo_schedule )
			{
				case Scheduler.Daily:
				{
					schel.set_st_daily_hhmm ( input_st_horario );
					
					schel.set_dt_last 			( GetDataBaseTime( DateTime.Now.AddDays (1) ) );
					schel.set_dt_prev			( GetDataBaseTime( DateTime.Now.AddDays (1) ) );
					
					break;
				}
					
				case Scheduler.Weekly:
				{
					schel.set_st_weekly_dow  ( input_st_aux 	);
					schel.set_st_weekly_hhmm ( input_st_horario );
					
					schel.set_dt_last 			( GetDataBaseTime( DateTime.Now.AddDays (7) ) );
					schel.set_dt_prev			( GetDataBaseTime( DateTime.Now.AddDays (7) ) );
					
					break;
				}
					
				case Scheduler.Monthly:
				{
					schel.set_nu_monthly_day  ( input_st_aux 	);
					schel.set_st_monthly_hhmm ( input_st_horario );
					
					schel.set_dt_last 			( GetDataBaseTime( DateTime.Now.AddMonths (1) ) );
					schel.set_dt_prev			( GetDataBaseTime( DateTime.Now.AddMonths (1) ) );
			
					break;
				}
			}
			
			if ( !schel.create_I_Scheduler() )
				return false;
			
			l_a = new LINK_Agenda (this);
			
			l_a.set_en_atividade 	( input_en_atividade 		);
			l_a.set_fk_schedule  	( schel.get_identity() 		);
			l_a.set_fk_empresa   	( emp.get_identity()		);
			l_a.set_st_emp_afiliada	( input_st_afiliada 		);
				
			if ( !l_a.create_LINK_Agenda() )
				return false;
			
			PublishNote ( "Agendamento criado com sucesso" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done ins_agenda " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish ins_agenda " ); 
		
			/// USER [ finish ]

			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
			
				aud.set_tg_operacao	( TipoOperacao.NovaAgenda 				);
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( l_a.get_fk_schedule() );
				
				aud.set_fk_generic  ( l_a.get_identity()  );
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done ins_agenda " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
