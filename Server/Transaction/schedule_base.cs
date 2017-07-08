using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class schedule_base : Transaction
	{
		/// USER [ var_decl ]
		 
		DateTime 	elapsed_time = new DateTime();
		I_Scheduler sch;
		
		/// USER [ var_decl ] END
		
		public schedule_base ( Transaction trans ) : base (trans)
		{
			var_Alias = "schedule_base";
			constructor();
		}
		
		public schedule_base()
		{
			var_Alias = "schedule_base";
		
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
			Registry ( "setup schedule_base " ); 
		
			Registry ( "setup done schedule_base " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate schedule_base " ); 
		
			/// USER [ authenticate ]
			
			sch = new I_Scheduler (this);
			
			sch.ExclusiveAccess();
			
			if ( !sch.selectIdentity ( var_iPid.ToString() ) )
				return false;
			
			sch.set_tg_status ( Context.CLOSED );
			
			if ( !sch.synchronize_I_Scheduler() )
				return false;
			
			sch.ReleaseExclusive();
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done schedule_base " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute schedule_base " ); 
		
			/// USER [ execute ]
			
			elapsed_time = DateTime.Now;
			
			/// USER [ execute ] END
		
			Registry ( "execute done schedule_base " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish schedule_base " ); 
		
			/// USER [ finish ]
			
			sch.ExclusiveAccess();
			
			if ( !sch.selectIdentity ( var_iPid.ToString() ) )
				return false;
			
			sch.set_tg_status  	( Context.OPEN );
			
			switch ( sch.get_tg_type() )
			{
				case Scheduler.Daily:	
				{
					int year   = DateTime.Now.Year;
					int month  = DateTime.Now.Month;
					int day    = DateTime.Now.Day;
					int hour   = Convert.ToInt32 ( sch.get_st_daily_hhmm().Substring ( 0,2) );
					int minute = Convert.ToInt32 ( sch.get_st_daily_hhmm().Substring ( 2,2) );
					
					sch.set_dt_prev ( GetDataBaseTime ( new DateTime ( year, month, day, hour, minute, 0 ).AddDays (1) ) );
					
					break;
				}
					
				case Scheduler.Weekly:
				{
					int year   = DateTime.Now.Year;
					int month  = DateTime.Now.Month;
					int day    = DateTime.Now.Day;
					int hour   = Convert.ToInt32 ( sch.get_st_weekly_hhmm().Substring ( 0,2) );
					int minute = Convert.ToInt32 ( sch.get_st_weekly_hhmm().Substring ( 2,2) );
					
					sch.set_dt_prev ( GetDataBaseTime ( new DateTime ( year, month, day, hour, minute, 0 ).AddDays (7) ) );
					
					break;
				}
				
				case Scheduler.Monthly:	
				{
					int year   = DateTime.Now.Year;
					int month  = DateTime.Now.Month;
					int day    = DateTime.Now.Day;
					int hour   = Convert.ToInt32 ( sch.get_st_monthly_hhmm().Substring ( 0,2) );
					int minute = Convert.ToInt32 ( sch.get_st_monthly_hhmm().Substring ( 2,2) );
					
					sch.set_dt_prev ( GetDataBaseTime ( new DateTime ( year, month, day, hour, minute, 0 ).AddMonths(1) ) );
					
					break;
				}
				
				default: break;
			}
			
			sch.set_dt_last 	( GetDataBaseTime() );
			
			if ( !sch.synchronize_I_Scheduler() )
				return false;
			
			sch.ReleaseExclusive();
			
			/// USER [ finish ] END
		
			Registry ( "finish done schedule_base " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
