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
	public class LOG_Chamado : Synchronization
	{
		private string i_unique = "0";
		private string fk_chamado = "0";
		private string fk_operador = "0";
		private string st_solucao = "";
		private string dt_solucao = "1900-01-01 00:00:00";
		
		public int var_FieldCount = 5;
		
		public LOG_Chamado ( infra_Patch i_patch )  : base ( i_patch )
		{
			var_Tablename = TB_LOG_CHAMADO.Alias;
		}
		public string exportNames()
		{
			return "fk_chamado,fk_operador,st_solucao,dt_solucao";
		}
		
		public string exportCSV()
		{
			return i_unique + str_field_sep + fk_chamado + str_field_sep + fk_operador + str_field_sep + st_solucao + str_field_sep + dt_solucao;
		}
		
		public void Reset()
		{
			i_unique = "0";
			fk_chamado = "0";
			fk_operador = "0";
			st_solucao = "";
			dt_solucao = "1900-01-01 00:00:00";
		}
		
		public void copy ( ref LOG_Chamado cpy )
		{
			fk_chamado = cpy.fk_chamado;
			fk_operador = cpy.fk_operador;
			st_solucao = cpy.st_solucao;
			dt_solucao = cpy.dt_solucao;
		}
		
		public override void fetchRetrieve ( ref DB_Row row )
		{
			i_unique = row.GetField ( TB_LOG_CHAMADO.i_unique );
			fk_chamado = row.GetField ( TB_LOG_CHAMADO.fk_chamado );
			fk_operador = row.GetField ( TB_LOG_CHAMADO.fk_operador );
			st_solucao = row.GetField ( TB_LOG_CHAMADO.st_solucao );
			dt_solucao = ConvertTime ( row.GetField ( TB_LOG_CHAMADO.dt_solucao ) );
		}
		
		public bool synchronize_LOG_Chamado ( )
		{
			try{
			
			if ( m_hshChangedFields.Count == 0 )
				return true;
			
			StartUpdate();
		
			if ( m_hshChangedFields [ "fk_chamado" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_CHAMADO.fk_chamado , fk_chamado , TB_LOG_CHAMADO.type_fk_chamado );
			if ( m_hshChangedFields [ "fk_operador" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_CHAMADO.fk_operador , fk_operador , TB_LOG_CHAMADO.type_fk_operador );
			if ( m_hshChangedFields [ "st_solucao" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_CHAMADO.st_solucao , st_solucao , TB_LOG_CHAMADO.type_st_solucao );
			if ( m_hshChangedFields [ "dt_solucao" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_CHAMADO.dt_solucao , dt_solucao , TB_LOG_CHAMADO.type_dt_solucao );
		
			m_gen_dbStatement.AddWhere ( TB_LOG_CHAMADO.i_unique, i_unique, TB_LOG_CHAMADO.type_i_unique );
		
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
		
			return Update();
		}
			
		public string get_identity() { return i_unique; } 
		public string get_fk_chamado() { return fk_chamado; } 
		public string get_fk_operador() { return fk_operador; } 
		public string get_st_solucao() { return st_solucao; } 
		public string get_dt_solucao() { return dt_solucao; } 
			
		public long get_int_fk_chamado() { return Convert.ToInt64 ( fk_chamado ); } 
		public long get_int_fk_operador() { return Convert.ToInt64 ( fk_operador ); } 
			
		public void set_fk_chamado ( string val ) { fk_chamado = val; m_hshChangedFields [ "fk_chamado" ]="."; } 
		public void set_fk_operador ( string val ) { fk_operador = val; m_hshChangedFields [ "fk_operador" ]="."; } 
		public void set_st_solucao ( string val ) { st_solucao = val; m_hshChangedFields [ "st_solucao" ]="."; } 
		public void set_dt_solucao ( string val ) { dt_solucao = val; m_hshChangedFields [ "dt_solucao" ]="."; } 
		
		public void set_fk_chamado ( long val ) { fk_chamado = Convert.ToString(val); m_hshChangedFields [ "fk_chamado" ]="."; } 
		public void set_fk_operador ( long val ) { fk_operador = Convert.ToString(val); m_hshChangedFields [ "fk_operador" ]="."; } 
			
		public void fieldSelection()
		{
			m_gen_dbStatement.AddSelect ( TB_LOG_CHAMADO.i_unique );
			m_gen_dbStatement.AddSelect ( TB_LOG_CHAMADO.fk_chamado );
			m_gen_dbStatement.AddSelect ( TB_LOG_CHAMADO.fk_operador );
			m_gen_dbStatement.AddSelect ( TB_LOG_CHAMADO.st_solucao );
			m_gen_dbStatement.AddSelect ( TB_LOG_CHAMADO.dt_solucao );
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
			
				m_gen_dbStatement.AddWhere ( TB_LOG_CHAMADO.i_unique, identity, TB_LOG_CHAMADO.type_i_unique );
			
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
		
		public bool create_LOG_Chamado ( )
		{
			try{
			string new_id = "";
			
			StartInsert();
			
			m_gen_dbStatement.AddValue ( TB_LOG_CHAMADO.fk_chamado, fk_chamado, TB_LOG_CHAMADO.type_fk_chamado );
			m_gen_dbStatement.AddValue ( TB_LOG_CHAMADO.fk_operador, fk_operador, TB_LOG_CHAMADO.type_fk_operador );
			m_gen_dbStatement.AddValue ( TB_LOG_CHAMADO.st_solucao, st_solucao, TB_LOG_CHAMADO.type_st_solucao );
			m_gen_dbStatement.AddValue ( TB_LOG_CHAMADO.dt_solucao, dt_solucao, TB_LOG_CHAMADO.type_dt_solucao );
			
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
				m_gen_dbStatement.AddWhere ( TB_LOG_CHAMADO.i_unique, i_unique, TB_LOG_CHAMADO.type_i_unique );
			
			ret = Execute();
			
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
			
			return ret; 
		}
			
		public bool select_fk_chamado ( string val_fk_chamado )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddWhere ( TB_LOG_CHAMADO.fk_chamado, val_fk_chamado , TB_LOG_CHAMADO.type_fk_chamado);
			
				m_gen_dbStatement.AddOrderBy ( TB_LOG_CHAMADO.dt_solucao );
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
	}
}