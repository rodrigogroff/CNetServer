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
	public class LINK_Agenda : Synchronization
	{
		private string i_unique = "0";
		private string fk_schedule = "0";
		private string fk_empresa = "0";
		private string en_atividade = "0";
		private string st_emp_afiliada = "";
		
		public int var_FieldCount = 5;
		
		public LINK_Agenda ( infra_Patch i_patch )  : base ( i_patch )
		{
			var_Tablename = TB_LINK_AGENDA.Alias;
		}
		public string exportNames()
		{
			return "fk_schedule,fk_empresa,en_atividade,st_emp_afiliada";
		}
		
		public string exportCSV()
		{
			return i_unique + str_field_sep + fk_schedule + str_field_sep + fk_empresa + str_field_sep + en_atividade + str_field_sep + st_emp_afiliada;
		}
		
		public void Reset()
		{
			i_unique = "0";
			fk_schedule = "0";
			fk_empresa = "0";
			en_atividade = "0";
			st_emp_afiliada = "";
		}
		
		public void copy ( ref LINK_Agenda cpy )
		{
			fk_schedule = cpy.fk_schedule;
			fk_empresa = cpy.fk_empresa;
			en_atividade = cpy.en_atividade;
			st_emp_afiliada = cpy.st_emp_afiliada;
		}
		
		public override void fetchRetrieve ( ref DB_Row row )
		{
			i_unique = row.GetField ( TB_LINK_AGENDA.i_unique );
			fk_schedule = row.GetField ( TB_LINK_AGENDA.fk_schedule );
			fk_empresa = row.GetField ( TB_LINK_AGENDA.fk_empresa );
			en_atividade = row.GetField ( TB_LINK_AGENDA.en_atividade );
			st_emp_afiliada = row.GetField ( TB_LINK_AGENDA.st_emp_afiliada );
		}
		
		public bool synchronize_LINK_Agenda ( )
		{
			try{
			
			if ( m_hshChangedFields.Count == 0 )
				return true;
			
			StartUpdate();
		
			if ( m_hshChangedFields [ "fk_schedule" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LINK_AGENDA.fk_schedule , fk_schedule , TB_LINK_AGENDA.type_fk_schedule );
			if ( m_hshChangedFields [ "fk_empresa" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LINK_AGENDA.fk_empresa , fk_empresa , TB_LINK_AGENDA.type_fk_empresa );
			if ( m_hshChangedFields [ "en_atividade" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LINK_AGENDA.en_atividade , en_atividade , TB_LINK_AGENDA.type_en_atividade );
			if ( m_hshChangedFields [ "st_emp_afiliada" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LINK_AGENDA.st_emp_afiliada , st_emp_afiliada , TB_LINK_AGENDA.type_st_emp_afiliada );
		
			m_gen_dbStatement.AddWhere ( TB_LINK_AGENDA.i_unique, i_unique, TB_LINK_AGENDA.type_i_unique );
		
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
		
			return Update();
		}
			
		public string get_identity() { return i_unique; } 
		public string get_fk_schedule() { return fk_schedule; } 
		public string get_fk_empresa() { return fk_empresa; } 
		public string get_en_atividade() { return en_atividade; } 
		public string get_st_emp_afiliada() { return st_emp_afiliada; } 
			
		public long get_int_fk_schedule() { return Convert.ToInt64 ( fk_schedule ); } 
		public long get_int_fk_empresa() { return Convert.ToInt64 ( fk_empresa ); } 
		public long get_int_en_atividade() { return Convert.ToInt64 ( en_atividade ); } 
			
		public void set_fk_schedule ( string val ) { fk_schedule = val; m_hshChangedFields [ "fk_schedule" ]="."; } 
		public void set_fk_empresa ( string val ) { fk_empresa = val; m_hshChangedFields [ "fk_empresa" ]="."; } 
		public void set_en_atividade ( string val ) { en_atividade = val; m_hshChangedFields [ "en_atividade" ]="."; } 
		public void set_st_emp_afiliada ( string val ) { st_emp_afiliada = val; m_hshChangedFields [ "st_emp_afiliada" ]="."; } 
		
		public void set_fk_schedule ( long val ) { fk_schedule = Convert.ToString(val); m_hshChangedFields [ "fk_schedule" ]="."; } 
		public void set_fk_empresa ( long val ) { fk_empresa = Convert.ToString(val); m_hshChangedFields [ "fk_empresa" ]="."; } 
		public void set_en_atividade ( long val ) { en_atividade = Convert.ToString(val); m_hshChangedFields [ "en_atividade" ]="."; } 
			
		public void fieldSelection()
		{
			m_gen_dbStatement.AddSelect ( TB_LINK_AGENDA.i_unique );
			m_gen_dbStatement.AddSelect ( TB_LINK_AGENDA.fk_schedule );
			m_gen_dbStatement.AddSelect ( TB_LINK_AGENDA.fk_empresa );
			m_gen_dbStatement.AddSelect ( TB_LINK_AGENDA.en_atividade );
			m_gen_dbStatement.AddSelect ( TB_LINK_AGENDA.st_emp_afiliada );
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
			
				m_gen_dbStatement.AddWhere ( TB_LINK_AGENDA.i_unique, identity, TB_LINK_AGENDA.type_i_unique );
			
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
		
		public bool create_LINK_Agenda ( )
		{
			try{
			string new_id = "";
			
			StartInsert();
			
			m_gen_dbStatement.AddValue ( TB_LINK_AGENDA.fk_schedule, fk_schedule, TB_LINK_AGENDA.type_fk_schedule );
			m_gen_dbStatement.AddValue ( TB_LINK_AGENDA.fk_empresa, fk_empresa, TB_LINK_AGENDA.type_fk_empresa );
			m_gen_dbStatement.AddValue ( TB_LINK_AGENDA.en_atividade, en_atividade, TB_LINK_AGENDA.type_en_atividade );
			m_gen_dbStatement.AddValue ( TB_LINK_AGENDA.st_emp_afiliada, st_emp_afiliada, TB_LINK_AGENDA.type_st_emp_afiliada );
			
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
				m_gen_dbStatement.AddWhere ( TB_LINK_AGENDA.i_unique, i_unique, TB_LINK_AGENDA.type_i_unique );
			
			ret = Execute();
			
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
			
			return ret; 
		}
			
		public bool select_rows_emp_ativ ( string val_fk_empresa, string val_en_atividade )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddWhere ( TB_LINK_AGENDA.fk_empresa, val_fk_empresa , TB_LINK_AGENDA.type_fk_empresa);
				m_gen_dbStatement.AddWhere ( TB_LINK_AGENDA.en_atividade, val_en_atividade , TB_LINK_AGENDA.type_en_atividade);
			
				m_gen_dbStatement.AddOrderBy ( TB_LINK_AGENDA.fk_empresa );
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
	}
}
