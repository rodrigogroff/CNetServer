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
	public class LOG_NS_FAT : Synchronization
	{
		private string i_unique = "0";
		private string dt_log = "1900-01-01 00:00:00";
		
		public int var_FieldCount = 2;
		
		public LOG_NS_FAT ()
		{
			var_Serial = TB_LOG_NS_FAT.serial;
			var_Tablename = TB_LOG_NS_FAT.Alias;
		}
		
		public LOG_NS_FAT ( Transaction trx )
		{
			AcquireTransaction ( ref trx );
			
			var_Serial = TB_LOG_NS_FAT.serial;
			var_Tablename = TB_LOG_NS_FAT.Alias;
			
			TraceLog ( var_Tablename + " serial : " + var_serialNumber);
		}
		
		public string exportNames()
		{
			return "dt_log";
		}
		
		public string exportCSV()
		{
			return i_unique + str_field_sep + dt_log;
		}
		
		public void Reset()
		{
			i_unique = "0";
			dt_log = "1900-01-01 00:00:00";
		
			ReleaseExclusive();
		}
		
		public void copy ( ref LOG_NS_FAT cpy )
		{
			dt_log = cpy.dt_log;
		}
		
		public override void fetchRetrieve ( ref DB_Row row )
		{
			i_unique = row.GetField ( TB_LOG_NS_FAT.i_unique );
			dt_log = ConvertTime ( row.GetField ( TB_LOG_NS_FAT.dt_log ) );
		}
		
		public bool synchronize_LOG_NS_FAT ( )
		{
			try{
			
			if ( m_hshChangedFields.Count == 0 )
				return true;
			
			StartUpdate();
		
			if ( m_hshChangedFields [ "dt_log" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_NS_FAT.dt_log , dt_log , TB_LOG_NS_FAT.type_dt_log );
		
			m_gen_dbStatement.AddWhere ( TB_LOG_NS_FAT.i_unique, i_unique, TB_LOG_NS_FAT.type_i_unique );
		
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
		
			return Update();
		}
			
		public string get_identity() { return i_unique; } 
		public string get_dt_log() { return dt_log; } 
			
		public void set_dt_log ( string val ) { dt_log = val; m_hshChangedFields [ "dt_log" ]="."; } 
		
		public void fieldSelection()
		{
			m_gen_dbStatement.AddSelect ( TB_LOG_NS_FAT.i_unique );
			m_gen_dbStatement.AddSelect ( TB_LOG_NS_FAT.dt_log );
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
			
				m_gen_dbStatement.AddWhere ( TB_LOG_NS_FAT.i_unique, identity, TB_LOG_NS_FAT.type_i_unique );
			
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
		
		public bool create_LOG_NS_FAT ( )
		{
			try{
			string new_id = "";
			
			StartInsert();
			
			m_gen_dbStatement.AddValue ( TB_LOG_NS_FAT.dt_log, dt_log, TB_LOG_NS_FAT.type_dt_log );
			
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
				m_gen_dbStatement.AddWhere ( TB_LOG_NS_FAT.i_unique, i_unique, TB_LOG_NS_FAT.type_i_unique );
			
			ret = Execute();
			
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
			
			return ret; 
		}
		
		#if DEBUG
		
		public bool setup ( bool IsTruncate, ref string id, string var_dt_log )
		{
			if ( IsTruncate ) 
			{
				i_unique = "";
				this.delete();
			}
		
			set_dt_log ( var_dt_log );
			
			if ( create_LOG_NS_FAT() == false )
			{
				return false;
			}
			
			id = get_identity();
			return true;
		}
		
		#endif
		
	}
}
