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
	public class LOG_VendaProdutoGift : Synchronization
	{
		private string i_unique = "0";
		private string fk_vendaCartao = "0";
		private string st_produto = "";
		private string vr_valor = "0";
		
		public int var_FieldCount = 4;
		
		public LOG_VendaProdutoGift ( infra_Patch i_patch )  : base ( i_patch )
		{
			var_Tablename = TB_LOG_VENDAPRODUTOGIFT.Alias;
		}
		public string exportNames()
		{
			return "fk_vendaCartao,st_produto,vr_valor";
		}
		
		public string exportCSV()
		{
			return i_unique + str_field_sep + fk_vendaCartao + str_field_sep + st_produto + str_field_sep + vr_valor;
		}
		
		public void Reset()
		{
			i_unique = "0";
			fk_vendaCartao = "0";
			st_produto = "";
			vr_valor = "0";
		}
		
		public void copy ( ref LOG_VendaProdutoGift cpy )
		{
			fk_vendaCartao = cpy.fk_vendaCartao;
			st_produto = cpy.st_produto;
			vr_valor = cpy.vr_valor;
		}
		
		public override void fetchRetrieve ( ref DB_Row row )
		{
			i_unique = row.GetField ( TB_LOG_VENDAPRODUTOGIFT.i_unique );
			fk_vendaCartao = row.GetField ( TB_LOG_VENDAPRODUTOGIFT.fk_vendaCartao );
			st_produto = row.GetField ( TB_LOG_VENDAPRODUTOGIFT.st_produto );
			vr_valor = row.GetField ( TB_LOG_VENDAPRODUTOGIFT.vr_valor );
		}
		
		public bool synchronize_LOG_VendaProdutoGift ( )
		{
			try{
			
			if ( m_hshChangedFields.Count == 0 )
				return true;
			
			StartUpdate();
		
			if ( m_hshChangedFields [ "fk_vendaCartao" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_VENDAPRODUTOGIFT.fk_vendaCartao , fk_vendaCartao , TB_LOG_VENDAPRODUTOGIFT.type_fk_vendaCartao );
			if ( m_hshChangedFields [ "st_produto" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_VENDAPRODUTOGIFT.st_produto , st_produto , TB_LOG_VENDAPRODUTOGIFT.type_st_produto );
			if ( m_hshChangedFields [ "vr_valor" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_VENDAPRODUTOGIFT.vr_valor , vr_valor , TB_LOG_VENDAPRODUTOGIFT.type_vr_valor );
		
			m_gen_dbStatement.AddWhere ( TB_LOG_VENDAPRODUTOGIFT.i_unique, i_unique, TB_LOG_VENDAPRODUTOGIFT.type_i_unique );
		
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
		
			return Update();
		}
			
		public string get_identity() { return i_unique; } 
		public string get_fk_vendaCartao() { return fk_vendaCartao; } 
		public string get_st_produto() { return st_produto; } 
		public string get_vr_valor() { return vr_valor; } 
			
		public long get_int_fk_vendaCartao() { return Convert.ToInt64 ( fk_vendaCartao ); } 
		public long get_int_vr_valor() { return Convert.ToInt64 ( vr_valor ); } 
			
		public void set_fk_vendaCartao ( string val ) { fk_vendaCartao = val; m_hshChangedFields [ "fk_vendaCartao" ]="."; } 
		public void set_st_produto ( string val ) { st_produto = val; m_hshChangedFields [ "st_produto" ]="."; } 
		public void set_vr_valor ( string val ) { vr_valor = val; m_hshChangedFields [ "vr_valor" ]="."; } 
		
		public void set_fk_vendaCartao ( long val ) { fk_vendaCartao = Convert.ToString(val); m_hshChangedFields [ "fk_vendaCartao" ]="."; } 
		public void set_vr_valor ( long val ) { vr_valor = Convert.ToString(val); m_hshChangedFields [ "vr_valor" ]="."; } 
			
		public void fieldSelection()
		{
			m_gen_dbStatement.AddSelect ( TB_LOG_VENDAPRODUTOGIFT.i_unique );
			m_gen_dbStatement.AddSelect ( TB_LOG_VENDAPRODUTOGIFT.fk_vendaCartao );
			m_gen_dbStatement.AddSelect ( TB_LOG_VENDAPRODUTOGIFT.st_produto );
			m_gen_dbStatement.AddSelect ( TB_LOG_VENDAPRODUTOGIFT.vr_valor );
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
			
				m_gen_dbStatement.AddWhere ( TB_LOG_VENDAPRODUTOGIFT.i_unique, identity, TB_LOG_VENDAPRODUTOGIFT.type_i_unique );
			
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
		
		public bool create_LOG_VendaProdutoGift ( )
		{
			try{
			string new_id = "";
			
			StartInsert();
			
			m_gen_dbStatement.AddValue ( TB_LOG_VENDAPRODUTOGIFT.fk_vendaCartao, fk_vendaCartao, TB_LOG_VENDAPRODUTOGIFT.type_fk_vendaCartao );
			m_gen_dbStatement.AddValue ( TB_LOG_VENDAPRODUTOGIFT.st_produto, st_produto, TB_LOG_VENDAPRODUTOGIFT.type_st_produto );
			m_gen_dbStatement.AddValue ( TB_LOG_VENDAPRODUTOGIFT.vr_valor, vr_valor, TB_LOG_VENDAPRODUTOGIFT.type_vr_valor );
			
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
				m_gen_dbStatement.AddWhere ( TB_LOG_VENDAPRODUTOGIFT.i_unique, i_unique, TB_LOG_VENDAPRODUTOGIFT.type_i_unique );
			
			ret = Execute();
			
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
			
			return ret; 
		}
			
		public bool select_fk_venda ( string val_fk_vendaCartao )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddWhere ( TB_LOG_VENDAPRODUTOGIFT.fk_vendaCartao, val_fk_vendaCartao , TB_LOG_VENDAPRODUTOGIFT.type_fk_vendaCartao);
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
	}
}
