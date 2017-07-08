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
	public class T_WebBlock : Synchronization
	{
		private string i_unique = "0";
		private string st_ip = "";
		private string fk_cartao = "0";
		private string dt_expire = "1900-01-01 00:00:00";
		
		public int var_FieldCount = 4;
		
		public T_WebBlock ( infra_Patch i_patch )  : base ( i_patch )
		{
			var_Tablename = TB_T_WEBBLOCK.Alias;
		}
		public string exportNames()
		{
			return "st_ip,fk_cartao,dt_expire";
		}
		
		public string exportCSV()
		{
			return i_unique + str_field_sep + st_ip + str_field_sep + fk_cartao + str_field_sep + dt_expire;
		}
		
		public void Reset()
		{
			i_unique = "0";
			st_ip = "";
			fk_cartao = "0";
			dt_expire = "1900-01-01 00:00:00";
		}
		
		public void copy ( ref T_WebBlock cpy )
		{
			st_ip = cpy.st_ip;
			fk_cartao = cpy.fk_cartao;
			dt_expire = cpy.dt_expire;
		}
		
		public override void fetchRetrieve ( ref DB_Row row )
		{
			i_unique = row.GetField ( TB_T_WEBBLOCK.i_unique );
			st_ip = row.GetField ( TB_T_WEBBLOCK.st_ip );
			fk_cartao = row.GetField ( TB_T_WEBBLOCK.fk_cartao );
			dt_expire = ConvertTime ( row.GetField ( TB_T_WEBBLOCK.dt_expire ) );
		}
		
		public bool synchronize_T_WebBlock ( )
		{
			try{
			
			if ( m_hshChangedFields.Count == 0 )
				return true;
			
			StartUpdate();
		
			if ( m_hshChangedFields [ "st_ip" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_WEBBLOCK.st_ip , st_ip , TB_T_WEBBLOCK.type_st_ip );
			if ( m_hshChangedFields [ "fk_cartao" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_WEBBLOCK.fk_cartao , fk_cartao , TB_T_WEBBLOCK.type_fk_cartao );
			if ( m_hshChangedFields [ "dt_expire" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_WEBBLOCK.dt_expire , dt_expire , TB_T_WEBBLOCK.type_dt_expire );
		
			m_gen_dbStatement.AddWhere ( TB_T_WEBBLOCK.i_unique, i_unique, TB_T_WEBBLOCK.type_i_unique );
		
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
		
			return Update();
		}
			
		public string get_identity() { return i_unique; } 
		public string get_st_ip() { return st_ip; } 
		public string get_fk_cartao() { return fk_cartao; } 
		public string get_dt_expire() { return dt_expire; } 
			
		public long get_int_fk_cartao() { return Convert.ToInt64 ( fk_cartao ); } 
			
		public void set_st_ip ( string val ) { st_ip = val; m_hshChangedFields [ "st_ip" ]="."; } 
		public void set_fk_cartao ( string val ) { fk_cartao = val; m_hshChangedFields [ "fk_cartao" ]="."; } 
		public void set_dt_expire ( string val ) { dt_expire = val; m_hshChangedFields [ "dt_expire" ]="."; } 
		
		public void set_fk_cartao ( long val ) { fk_cartao = Convert.ToString(val); m_hshChangedFields [ "fk_cartao" ]="."; } 
			
		public void fieldSelection()
		{
			m_gen_dbStatement.AddSelect ( TB_T_WEBBLOCK.i_unique );
			m_gen_dbStatement.AddSelect ( TB_T_WEBBLOCK.st_ip );
			m_gen_dbStatement.AddSelect ( TB_T_WEBBLOCK.fk_cartao );
			m_gen_dbStatement.AddSelect ( TB_T_WEBBLOCK.dt_expire );
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
			
				m_gen_dbStatement.AddWhere ( TB_T_WEBBLOCK.i_unique, identity, TB_T_WEBBLOCK.type_i_unique );
			
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
		
		public bool create_T_WebBlock ( )
		{
			try{
			string new_id = "";
			
			StartInsert();
			
			m_gen_dbStatement.AddValue ( TB_T_WEBBLOCK.st_ip, st_ip, TB_T_WEBBLOCK.type_st_ip );
			m_gen_dbStatement.AddValue ( TB_T_WEBBLOCK.fk_cartao, fk_cartao, TB_T_WEBBLOCK.type_fk_cartao );
			m_gen_dbStatement.AddValue ( TB_T_WEBBLOCK.dt_expire, dt_expire, TB_T_WEBBLOCK.type_dt_expire );
			
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
				m_gen_dbStatement.AddWhere ( TB_T_WEBBLOCK.i_unique, i_unique, TB_T_WEBBLOCK.type_i_unique );
			
			ret = Execute();
			
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
			
			return ret; 
		}
			
		public bool select_rows_ip ( string val_st_ip, string val_dt_expire, string val_fk_cartao )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddWhere ( TB_T_WEBBLOCK.st_ip, val_st_ip , TB_T_WEBBLOCK.type_st_ip);
				m_gen_dbStatement.AddWhereGreaterEqual ( TB_T_WEBBLOCK.dt_expire, val_dt_expire , TB_T_WEBBLOCK.type_dt_expire);
				m_gen_dbStatement.AddWhere ( TB_T_WEBBLOCK.fk_cartao, val_fk_cartao , TB_T_WEBBLOCK.type_fk_cartao);
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
	}
}