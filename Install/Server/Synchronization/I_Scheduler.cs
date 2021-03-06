﻿// ###################################################### 
// ## SyCraf Engine Codegen                          #### 
// ###################################################### 
// ## This file is entirely written by               #### 
// ## the construction bot. DO NOT EDIT THIS FILE.   #### 
// ###################################################### 

using System;
using System.IO;
using System.Threading;
using System.Collections;

namespace SyCrafEngine
{
	public class I_Scheduler : Synchronization
	{
		private string i_unique = "0";
		private string st_job = "";
		private string tg_type = "";
		private string dt_specific = "1900-01-01 00:00:00";
		private string st_daily_hhmm = "";
		private string st_weekly_dow = "0";
		private string st_weekly_hhmm = "";
		private string nu_monthly_day = "0";
		private string st_monthly_hhmm = "";
		private string dt_last = "1900-01-01 00:00:00";
		private string tg_status = "";
		private string dt_prev = "1900-01-01 00:00:00";
		
		public int var_FieldCount = 12;
		
		public I_Scheduler ( infra_Patch i_patch )  : base ( i_patch )
		{
			var_Tablename = TB_I_SCHEDULER.Alias;
		}
		public string exportNames()
		{
			return "st_job,tg_type,dt_specific,st_daily_hhmm,st_weekly_dow,st_weekly_hhmm,nu_monthly_day,st_monthly_hhmm,dt_last,tg_status,dt_prev";
		}
		
		public string exportCSV()
		{
			return i_unique + str_field_sep + st_job + str_field_sep + tg_type + str_field_sep + dt_specific + str_field_sep + st_daily_hhmm + str_field_sep + st_weekly_dow + str_field_sep + st_weekly_hhmm + str_field_sep + nu_monthly_day + str_field_sep + st_monthly_hhmm + str_field_sep + dt_last + str_field_sep + tg_status + str_field_sep + dt_prev;
		}
		
		public void Reset()
		{
			i_unique = "0";
			st_job = "";
			tg_type = "";
			dt_specific = "1900-01-01 00:00:00";
			st_daily_hhmm = "";
			st_weekly_dow = "0";
			st_weekly_hhmm = "";
			nu_monthly_day = "0";
			st_monthly_hhmm = "";
			dt_last = "1900-01-01 00:00:00";
			tg_status = "";
			dt_prev = "1900-01-01 00:00:00";
		}
		
		public void copy ( ref I_Scheduler cpy )
		{
			st_job = cpy.st_job;
			tg_type = cpy.tg_type;
			dt_specific = cpy.dt_specific;
			st_daily_hhmm = cpy.st_daily_hhmm;
			st_weekly_dow = cpy.st_weekly_dow;
			st_weekly_hhmm = cpy.st_weekly_hhmm;
			nu_monthly_day = cpy.nu_monthly_day;
			st_monthly_hhmm = cpy.st_monthly_hhmm;
			dt_last = cpy.dt_last;
			tg_status = cpy.tg_status;
			dt_prev = cpy.dt_prev;
		}
		
		public override void fetchRetrieve ( ref DB_Row row )
		{
			i_unique = row.GetField ( TB_I_SCHEDULER.i_unique );
			st_job = row.GetField ( TB_I_SCHEDULER.st_job );
			tg_type = row.GetField ( TB_I_SCHEDULER.tg_type );
			dt_specific = ConvertTime ( row.GetField ( TB_I_SCHEDULER.dt_specific ) );
			st_daily_hhmm = row.GetField ( TB_I_SCHEDULER.st_daily_hhmm );
			st_weekly_dow = row.GetField ( TB_I_SCHEDULER.st_weekly_dow );
			st_weekly_hhmm = row.GetField ( TB_I_SCHEDULER.st_weekly_hhmm );
			nu_monthly_day = row.GetField ( TB_I_SCHEDULER.nu_monthly_day );
			st_monthly_hhmm = row.GetField ( TB_I_SCHEDULER.st_monthly_hhmm );
			dt_last = ConvertTime ( row.GetField ( TB_I_SCHEDULER.dt_last ) );
			tg_status = row.GetField ( TB_I_SCHEDULER.tg_status );
			dt_prev = ConvertTime ( row.GetField ( TB_I_SCHEDULER.dt_prev ) );
		}
		
		public bool synchronize_I_Scheduler ( )
		{
			try{
			
			if ( m_hshChangedFields.Count == 0 )
				return true;
			
			StartUpdate();
		
			if ( m_hshChangedFields [ "st_job" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_I_SCHEDULER.st_job , st_job , TB_I_SCHEDULER.type_st_job );
			if ( m_hshChangedFields [ "tg_type" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_I_SCHEDULER.tg_type , tg_type , TB_I_SCHEDULER.type_tg_type );
			if ( m_hshChangedFields [ "dt_specific" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_I_SCHEDULER.dt_specific , dt_specific , TB_I_SCHEDULER.type_dt_specific );
			if ( m_hshChangedFields [ "st_daily_hhmm" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_I_SCHEDULER.st_daily_hhmm , st_daily_hhmm , TB_I_SCHEDULER.type_st_daily_hhmm );
			if ( m_hshChangedFields [ "st_weekly_dow" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_I_SCHEDULER.st_weekly_dow , st_weekly_dow , TB_I_SCHEDULER.type_st_weekly_dow );
			if ( m_hshChangedFields [ "st_weekly_hhmm" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_I_SCHEDULER.st_weekly_hhmm , st_weekly_hhmm , TB_I_SCHEDULER.type_st_weekly_hhmm );
			if ( m_hshChangedFields [ "nu_monthly_day" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_I_SCHEDULER.nu_monthly_day , nu_monthly_day , TB_I_SCHEDULER.type_nu_monthly_day );
			if ( m_hshChangedFields [ "st_monthly_hhmm" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_I_SCHEDULER.st_monthly_hhmm , st_monthly_hhmm , TB_I_SCHEDULER.type_st_monthly_hhmm );
			if ( m_hshChangedFields [ "dt_last" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_I_SCHEDULER.dt_last , dt_last , TB_I_SCHEDULER.type_dt_last );
			if ( m_hshChangedFields [ "tg_status" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_I_SCHEDULER.tg_status , tg_status , TB_I_SCHEDULER.type_tg_status );
			if ( m_hshChangedFields [ "dt_prev" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_I_SCHEDULER.dt_prev , dt_prev , TB_I_SCHEDULER.type_dt_prev );
		
			m_gen_dbStatement.AddWhere ( TB_I_SCHEDULER.i_unique, i_unique, TB_I_SCHEDULER.type_i_unique );
		
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
		
			return Update();
		}
			
		public string get_identity() { return i_unique; } 
		public string get_st_job() { return st_job; } 
		public string get_tg_type() { return tg_type; } 
		public string get_dt_specific() { return dt_specific; } 
		public string get_st_daily_hhmm() { return st_daily_hhmm; } 
		public string get_st_weekly_dow() { return st_weekly_dow; } 
		public string get_st_weekly_hhmm() { return st_weekly_hhmm; } 
		public string get_nu_monthly_day() { return nu_monthly_day; } 
		public string get_st_monthly_hhmm() { return st_monthly_hhmm; } 
		public string get_dt_last() { return dt_last; } 
		public string get_tg_status() { return tg_status; } 
		public string get_dt_prev() { return dt_prev; } 
			
		public long get_int_st_weekly_dow() { return Convert.ToInt64 ( st_weekly_dow ); } 
		public long get_int_nu_monthly_day() { return Convert.ToInt64 ( nu_monthly_day ); } 
			
		public void set_st_job ( string val ) { st_job = val; m_hshChangedFields [ "st_job" ]="."; } 
		public void set_tg_type ( string val ) { tg_type = val; m_hshChangedFields [ "tg_type" ]="."; } 
		public void set_dt_specific ( string val ) { dt_specific = val; m_hshChangedFields [ "dt_specific" ]="."; } 
		public void set_st_daily_hhmm ( string val ) { st_daily_hhmm = val; m_hshChangedFields [ "st_daily_hhmm" ]="."; } 
		public void set_st_weekly_dow ( string val ) { st_weekly_dow = val; m_hshChangedFields [ "st_weekly_dow" ]="."; } 
		public void set_st_weekly_hhmm ( string val ) { st_weekly_hhmm = val; m_hshChangedFields [ "st_weekly_hhmm" ]="."; } 
		public void set_nu_monthly_day ( string val ) { nu_monthly_day = val; m_hshChangedFields [ "nu_monthly_day" ]="."; } 
		public void set_st_monthly_hhmm ( string val ) { st_monthly_hhmm = val; m_hshChangedFields [ "st_monthly_hhmm" ]="."; } 
		public void set_dt_last ( string val ) { dt_last = val; m_hshChangedFields [ "dt_last" ]="."; } 
		public void set_tg_status ( string val ) { tg_status = val; m_hshChangedFields [ "tg_status" ]="."; } 
		public void set_dt_prev ( string val ) { dt_prev = val; m_hshChangedFields [ "dt_prev" ]="."; } 
		
		public void set_st_weekly_dow ( long val ) { st_weekly_dow = Convert.ToString(val); m_hshChangedFields [ "st_weekly_dow" ]="."; } 
		public void set_nu_monthly_day ( long val ) { nu_monthly_day = Convert.ToString(val); m_hshChangedFields [ "nu_monthly_day" ]="."; } 
			
		public void fieldSelection()
		{
			m_gen_dbStatement.AddSelect ( TB_I_SCHEDULER.i_unique );
			m_gen_dbStatement.AddSelect ( TB_I_SCHEDULER.st_job );
			m_gen_dbStatement.AddSelect ( TB_I_SCHEDULER.tg_type );
			m_gen_dbStatement.AddSelect ( TB_I_SCHEDULER.dt_specific );
			m_gen_dbStatement.AddSelect ( TB_I_SCHEDULER.st_daily_hhmm );
			m_gen_dbStatement.AddSelect ( TB_I_SCHEDULER.st_weekly_dow );
			m_gen_dbStatement.AddSelect ( TB_I_SCHEDULER.st_weekly_hhmm );
			m_gen_dbStatement.AddSelect ( TB_I_SCHEDULER.nu_monthly_day );
			m_gen_dbStatement.AddSelect ( TB_I_SCHEDULER.st_monthly_hhmm );
			m_gen_dbStatement.AddSelect ( TB_I_SCHEDULER.dt_last );
			m_gen_dbStatement.AddSelect ( TB_I_SCHEDULER.tg_status );
			m_gen_dbStatement.AddSelect ( TB_I_SCHEDULER.dt_prev );
		}
			
		public bool selectAll()
		{
			do
			{
				StartSelect();
				fieldSelection();
				
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return  HasRows();
		}
		
		public bool selectIdentity ( string identity )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddWhere ( TB_I_SCHEDULER.i_unique, identity, TB_I_SCHEDULER.type_i_unique );
			
				if ( !executeQuery())
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			if ( HasRows() == true)
			{
				DB_Row row = m_db_result.GetFirstRow();
				fetchRetrieve ( ref row );
				return true;
			}
			
			return false;
		}
		
		public bool create_I_Scheduler ( )
		{
			try{
			string new_id = "";
			
			StartInsert();
			
			m_gen_dbStatement.AddValue ( TB_I_SCHEDULER.st_job, st_job, TB_I_SCHEDULER.type_st_job );
			m_gen_dbStatement.AddValue ( TB_I_SCHEDULER.tg_type, tg_type, TB_I_SCHEDULER.type_tg_type );
			m_gen_dbStatement.AddValue ( TB_I_SCHEDULER.dt_specific, dt_specific, TB_I_SCHEDULER.type_dt_specific );
			m_gen_dbStatement.AddValue ( TB_I_SCHEDULER.st_daily_hhmm, st_daily_hhmm, TB_I_SCHEDULER.type_st_daily_hhmm );
			m_gen_dbStatement.AddValue ( TB_I_SCHEDULER.st_weekly_dow, st_weekly_dow, TB_I_SCHEDULER.type_st_weekly_dow );
			m_gen_dbStatement.AddValue ( TB_I_SCHEDULER.st_weekly_hhmm, st_weekly_hhmm, TB_I_SCHEDULER.type_st_weekly_hhmm );
			m_gen_dbStatement.AddValue ( TB_I_SCHEDULER.nu_monthly_day, nu_monthly_day, TB_I_SCHEDULER.type_nu_monthly_day );
			m_gen_dbStatement.AddValue ( TB_I_SCHEDULER.st_monthly_hhmm, st_monthly_hhmm, TB_I_SCHEDULER.type_st_monthly_hhmm );
			m_gen_dbStatement.AddValue ( TB_I_SCHEDULER.dt_last, dt_last, TB_I_SCHEDULER.type_dt_last );
			m_gen_dbStatement.AddValue ( TB_I_SCHEDULER.tg_status, tg_status, TB_I_SCHEDULER.type_tg_status );
			m_gen_dbStatement.AddValue ( TB_I_SCHEDULER.dt_prev, dt_prev, TB_I_SCHEDULER.type_dt_prev );
			
			if ( !ExecuteScalar ( ref new_id ) )
				return false;
			
			i_unique = new_id;
			
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
			
			return true;
		}
			
		public bool delete ( )
		{
		
			bool ret = false;
		
			try{
			StartDelete();
			
			if ( i_unique != "0" )
				m_gen_dbStatement.AddWhere ( TB_I_SCHEDULER.i_unique, i_unique, TB_I_SCHEDULER.type_i_unique );
			
			ret = Execute();
			
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
			
			return ret; 
		}
	}
}
