using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class infra_SchedulerDispatcher : Transaction
	{
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public infra_SchedulerDispatcher ( Transaction trans ) : base (trans)
		{
			var_Alias = "infra_SchedulerDispatcher";
			constructor();
		}
		
		public infra_SchedulerDispatcher()
		{
			var_Alias = "infra_SchedulerDispatcher";
		
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
			Registry ( "setup infra_SchedulerDispatcher " ); 
		
			Registry ( "setup done infra_SchedulerDispatcher " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate infra_SchedulerDispatcher " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done infra_SchedulerDispatcher " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute infra_SchedulerDispatcher " ); 
		
			/// USER [ execute ]
			
			I_Scheduler 	sch 	 = new I_Scheduler(this);
			DateTime 		time_now = DateTime.Now;
			
			if ( sch.selectAll() )
			{
				while ( sch.fetch() )
				{
					bool Exec = false;
					
					if ( sch.get_tg_status() == Context.CLOSED )
						continue;
					
					switch ( sch.get_tg_type() )
					{
						case Scheduler.Specific:
						{
							DateTime time = Convert.ToDateTime ( sch.get_dt_specific() );
							
							if ( time_now.Year == time.Year )
								if ( time_now.Month == time.Month )
									if ( time_now.Day == time.Day )
										if ( time_now.Hour == time.Hour )
											if ( time_now.Minute == time.Minute )
												Exec = true;
							break;
						}
							
						case Scheduler.Daily:
						{
							int daily_hh = Convert.ToInt32 ( sch.get_st_daily_hhmm().Substring (0,2) );
							int daily_mm = Convert.ToInt32 ( sch.get_st_daily_hhmm().Substring (2,2) );
							
							if ( time_now.Hour == daily_hh )
								if ( time_now.Minute == daily_mm )
									Exec = true;
							
							break;
						}
							
						case Scheduler.Weekly:
						{
							long weekly_dow = sch.get_int_st_weekly_dow();
							long weekly_hh = Convert.ToInt64 ( sch.get_st_daily_hhmm().Substring (0,2) );
							long weekly_mm = Convert.ToInt64 ( sch.get_st_daily_hhmm().Substring (2,2) );
							
							switch ( weekly_dow )
							{
								case 0: if ( time_now.DayOfWeek != DayOfWeek.Sunday ) 		continue;	break;
								case 1: if ( time_now.DayOfWeek != DayOfWeek.Monday ) 		continue;	break;
								case 2: if ( time_now.DayOfWeek != DayOfWeek.Tuesday ) 		continue;	break;
								case 3: if ( time_now.DayOfWeek != DayOfWeek.Wednesday ) 	continue;	break;
								case 4: if ( time_now.DayOfWeek != DayOfWeek.Thursday ) 	continue;	break;
								case 5: if ( time_now.DayOfWeek != DayOfWeek.Friday ) 		continue;	break;
								case 6: if ( time_now.DayOfWeek != DayOfWeek.Saturday ) 	continue;	break;
								
								default: break;	// 7 is everyday
							}
							
							if ( time_now.Hour == weekly_hh )
								if ( time_now.Minute == weekly_mm )
									Exec = true;
							
							break;
						}
							
						case Scheduler.Monthly:
						{
							long monthly_dd = sch.get_int_nu_monthly_day();
							long monthly_hh = Convert.ToInt64 ( sch.get_st_monthly_hhmm().Substring (0,2) );
							long monthly_mm = Convert.ToInt64 ( sch.get_st_monthly_hhmm().Substring (2,2) );
							
							if ( time_now.Day == monthly_dd )
								if ( time_now.Hour == monthly_hh )
									if ( time_now.Minute == monthly_mm )
										Exec = true;
							
							break;
						}
							
						case Scheduler.Minute:
						{
							Exec = true;
							break;
						}							
							
						default: 
						{
							Registry ( "Unrecognized code! " + sch.get_tg_type() );	
							break;
						}
					}
					
					if ( Exec )
					{
						Registry ( sch.get_st_job() + " >> MATCH!" );
					}
										
					Registry ( sch.get_st_job() );
					
					if ( !Exec )
					{
						Registry ( sch.get_st_job() + " >> Checking backlog...." );
						
						DateTime tim = Convert.ToDateTime ( sch.get_dt_prev() );
					
						Registry ( tim.ToString() );
						Registry ( time_now.ToString() );
								
						if ( time_now >= tim )
						{
							Registry ( "Back log for: " + sch.get_st_job() );
							Exec = true;
						}
					}
					
					if ( !Exec )
						continue;
											
					Registry ( "Running: " + sch.get_st_job() );
					
					ApplicationUtil var_util = new ApplicationUtil();
					
					int 			max_params 	= var_util.indexCSV ( sch.get_st_job(), ';' );
					string 			job 		= var_util.getCSV   ( 0 );
					
					string path =   var_SessionKey + 
									"\\Log_" +
									DateTime.Now.Year.ToString() +
	    							DateTime.Now.Month.ToString().PadLeft ( 2, '0') +
	    							DateTime.Now.Day.ToString().PadLeft ( 2, '0') +
	    							DateTime.Now.Hour.ToString().PadLeft ( 2, '0') +
	    							DateTime.Now.Minute.ToString().PadLeft ( 2, '0') +
	    							DateTime.Now.Second.ToString().PadLeft ( 2, '0') +
									"_" + 
									job + 
									"_" +
									sch.get_identity() + 
									".txt.wrk";
					
					FileStream 		logFile;
					StreamWriter 	logStream;
			
		        	if ( File.Exists ( path ) ) 
						logFile = new FileStream ( path, FileMode.Append, FileAccess.Write);
		        	else
		        		logFile = new FileStream ( path, FileMode.Create, FileAccess.Write);
						     	
					logStream = new StreamWriter ( logFile );
					logStream.AutoFlush = true;	
					
					var_Comm.Clear();
					
					DB_Access new_access = new DB_Access ( ref m_gen_my_access );
					
					var_disp.var_Translator = var_Translator;
										
					if ( max_params >= 3 )
					{
						DataPortable port = new DataPortable();
						
						for (int t=1; t < max_params; )
						{
							string ident     = var_util.getCSV ( t ); ++t;
							string ident_val = var_util.getCSV ( t ); ++t;
							
							port.setValue ( ident, ident_val );
						}
						
						string buffer = "";
						
						port.ExportBuffer ( ref buffer );
						
						Registry ( buffer );						
						
						new_access.MemorySave ( "input", ref port );
					}
					
					// Runnig in a new thread
					var_disp.ExecuteThreadTransaction (	job,
					                                    Convert.ToInt32 ( sch.get_identity() ),
						                                ref logStream,
						                                ref var_Comm,
						                                ref new_access,
						                                path );
				}
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done infra_SchedulerDispatcher " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish infra_SchedulerDispatcher " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done infra_SchedulerDispatcher " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
