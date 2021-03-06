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
	public class T_Futebol : Synchronization
	{
		private string i_unique = "0";
		private string st_logotipo = "";
		private string st_nome = "";
		
		public int var_FieldCount = 3;
		
		public T_Futebol ()
		{
			var_Serial = TB_T_FUTEBOL.serial;
			var_Tablename = TB_T_FUTEBOL.Alias;
		}
		
		public T_Futebol ( Transaction trx )
		{
			AcquireTransaction ( ref trx );
			
			var_Serial = TB_T_FUTEBOL.serial;
			var_Tablename = TB_T_FUTEBOL.Alias;
			
			TraceLog ( var_Tablename + " serial : " + var_serialNumber);
		}
		
		public string exportNames()
		{
			return "st_logotipo,st_nome";
		}
		
		public string exportCSV()
		{
			return i_unique + str_field_sep + st_logotipo + str_field_sep + st_nome;
		}
		
		public void Reset()
		{
			i_unique = "0";
			st_logotipo = "";
			st_nome = "";
		
			ReleaseExclusive();
		}
		
		public void copy ( ref T_Futebol cpy )
		{
			st_logotipo = cpy.st_logotipo;
			st_nome = cpy.st_nome;
		}
		
		public override void fetchRetrieve ( ref DB_Row row )
		{
			i_unique = row.GetField ( TB_T_FUTEBOL.i_unique );
			st_logotipo = row.GetField ( TB_T_FUTEBOL.st_logotipo );
			st_nome = row.GetField ( TB_T_FUTEBOL.st_nome );
		}
		
		public bool synchronize_T_Futebol ( )
		{
			try{
			
			if ( m_hshChangedFields.Count == 0 )
				return true;
			
			StartUpdate();
		
			if ( m_hshChangedFields [ "st_logotipo" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_FUTEBOL.st_logotipo , st_logotipo , TB_T_FUTEBOL.type_st_logotipo );
			if ( m_hshChangedFields [ "st_nome" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_FUTEBOL.st_nome , st_nome , TB_T_FUTEBOL.type_st_nome );
		
			m_gen_dbStatement.AddWhere ( TB_T_FUTEBOL.i_unique, i_unique, TB_T_FUTEBOL.type_i_unique );
		
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
		
			return Update();
		}
			
		public string get_identity() { return i_unique; } 
		public string get_st_logotipo() { return st_logotipo; } 
		public string get_st_nome() { return st_nome; } 
			
		public void set_st_logotipo ( string val ) { st_logotipo = val; m_hshChangedFields [ "st_logotipo" ]="."; } 
		public void set_st_nome ( string val ) { st_nome = val; m_hshChangedFields [ "st_nome" ]="."; } 
		
		public void fieldSelection()
		{
			m_gen_dbStatement.AddSelect ( TB_T_FUTEBOL.i_unique );
			m_gen_dbStatement.AddSelect ( TB_T_FUTEBOL.st_logotipo );
			m_gen_dbStatement.AddSelect ( TB_T_FUTEBOL.st_nome );
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
			
				m_gen_dbStatement.AddWhere ( TB_T_FUTEBOL.i_unique, identity, TB_T_FUTEBOL.type_i_unique );
			
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
		
		public bool create_T_Futebol ( )
		{
			try{
			string new_id = "";
			
			StartInsert();
			
			m_gen_dbStatement.AddValue ( TB_T_FUTEBOL.st_logotipo, st_logotipo, TB_T_FUTEBOL.type_st_logotipo );
			m_gen_dbStatement.AddValue ( TB_T_FUTEBOL.st_nome, st_nome, TB_T_FUTEBOL.type_st_nome );
			
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
			
			if ( i_unique != "" )
				m_gen_dbStatement.AddWhere ( TB_T_FUTEBOL.i_unique, i_unique, TB_T_FUTEBOL.type_i_unique );
			
			ret = Execute();
			
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
			
			return ret; 
		}
		
		#if DEBUG || LOAD
		
		public bool setup ( bool IsTruncate, ref string id, string var_st_logotipo, string var_st_nome )
		{
			if ( IsTruncate ) 
			{
				i_unique = "";
				this.delete();
			}
		
			set_st_logotipo ( var_st_logotipo );
			set_st_nome ( var_st_nome );
			
			if ( create_T_Futebol() == false )
			{
				return false;
			}
			
			id = get_identity();
			return true;
		}
		
		#endif
		
	}
}
