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
	public class LINK_LojaEmpresa : Synchronization
	{
		private string i_unique = "0";
		private string fk_loja = "0";
		private string fk_empresa = "0";
		private string tx_admin = "0";
		private string nu_dias_repasse = "0";
		private string st_ag = "";
		private string st_conta = "";
		private string st_banco = "";
		
		public int var_FieldCount = 8;
		
		public LINK_LojaEmpresa ( infra_Patch i_patch )  : base ( i_patch )
		{
			var_Tablename = TB_LINK_LOJAEMPRESA.Alias;
		}
		public string exportNames()
		{
			return "fk_loja,fk_empresa,tx_admin,nu_dias_repasse,st_ag,st_conta,st_banco";
		}
		
		public string exportCSV()
		{
			return i_unique + str_field_sep + fk_loja + str_field_sep + fk_empresa + str_field_sep + tx_admin + str_field_sep + nu_dias_repasse + str_field_sep + st_ag + str_field_sep + st_conta + str_field_sep + st_banco;
		}
		
		public void Reset()
		{
			i_unique = "0";
			fk_loja = "0";
			fk_empresa = "0";
			tx_admin = "0";
			nu_dias_repasse = "0";
			st_ag = "";
			st_conta = "";
			st_banco = "";
		}
		
		public void copy ( ref LINK_LojaEmpresa cpy )
		{
			fk_loja = cpy.fk_loja;
			fk_empresa = cpy.fk_empresa;
			tx_admin = cpy.tx_admin;
			nu_dias_repasse = cpy.nu_dias_repasse;
			st_ag = cpy.st_ag;
			st_conta = cpy.st_conta;
			st_banco = cpy.st_banco;
		}
		
		public override void fetchRetrieve ( ref DB_Row row )
		{
			i_unique = row.GetField ( TB_LINK_LOJAEMPRESA.i_unique );
			fk_loja = row.GetField ( TB_LINK_LOJAEMPRESA.fk_loja );
			fk_empresa = row.GetField ( TB_LINK_LOJAEMPRESA.fk_empresa );
			tx_admin = row.GetField ( TB_LINK_LOJAEMPRESA.tx_admin );
			nu_dias_repasse = row.GetField ( TB_LINK_LOJAEMPRESA.nu_dias_repasse );
			st_ag = row.GetField ( TB_LINK_LOJAEMPRESA.st_ag );
			st_conta = row.GetField ( TB_LINK_LOJAEMPRESA.st_conta );
			st_banco = row.GetField ( TB_LINK_LOJAEMPRESA.st_banco );
		}
		
		public bool synchronize_LINK_LojaEmpresa ( )
		{
			try{
			
			if ( m_hshChangedFields.Count == 0 )
				return true;
			
			StartUpdate();
		
			if ( m_hshChangedFields [ "fk_loja" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LINK_LOJAEMPRESA.fk_loja , fk_loja , TB_LINK_LOJAEMPRESA.type_fk_loja );
			if ( m_hshChangedFields [ "fk_empresa" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LINK_LOJAEMPRESA.fk_empresa , fk_empresa , TB_LINK_LOJAEMPRESA.type_fk_empresa );
			if ( m_hshChangedFields [ "tx_admin" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LINK_LOJAEMPRESA.tx_admin , tx_admin , TB_LINK_LOJAEMPRESA.type_tx_admin );
			if ( m_hshChangedFields [ "nu_dias_repasse" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LINK_LOJAEMPRESA.nu_dias_repasse , nu_dias_repasse , TB_LINK_LOJAEMPRESA.type_nu_dias_repasse );
			if ( m_hshChangedFields [ "st_ag" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LINK_LOJAEMPRESA.st_ag , st_ag , TB_LINK_LOJAEMPRESA.type_st_ag );
			if ( m_hshChangedFields [ "st_conta" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LINK_LOJAEMPRESA.st_conta , st_conta , TB_LINK_LOJAEMPRESA.type_st_conta );
			if ( m_hshChangedFields [ "st_banco" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LINK_LOJAEMPRESA.st_banco , st_banco , TB_LINK_LOJAEMPRESA.type_st_banco );
		
			m_gen_dbStatement.AddWhere ( TB_LINK_LOJAEMPRESA.i_unique, i_unique, TB_LINK_LOJAEMPRESA.type_i_unique );
		
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
		
			return Update();
		}
			
		public string get_identity() { return i_unique; } 
		public string get_fk_loja() { return fk_loja; } 
		public string get_fk_empresa() { return fk_empresa; } 
		public string get_tx_admin() { return tx_admin; } 
		public string get_nu_dias_repasse() { return nu_dias_repasse; } 
		public string get_st_ag() { return st_ag; } 
		public string get_st_conta() { return st_conta; } 
		public string get_st_banco() { return st_banco; } 
			
		public long get_int_fk_loja() { return Convert.ToInt64 ( fk_loja ); } 
		public long get_int_fk_empresa() { return Convert.ToInt64 ( fk_empresa ); } 
		public long get_int_tx_admin() { return Convert.ToInt64 ( tx_admin ); } 
		public long get_int_nu_dias_repasse() { return Convert.ToInt64 ( nu_dias_repasse ); } 
			
		public void set_fk_loja ( string val ) { fk_loja = val; m_hshChangedFields [ "fk_loja" ]="."; } 
		public void set_fk_empresa ( string val ) { fk_empresa = val; m_hshChangedFields [ "fk_empresa" ]="."; } 
		public void set_tx_admin ( string val ) { tx_admin = val; m_hshChangedFields [ "tx_admin" ]="."; } 
		public void set_nu_dias_repasse ( string val ) { nu_dias_repasse = val; m_hshChangedFields [ "nu_dias_repasse" ]="."; } 
		public void set_st_ag ( string val ) { st_ag = val; m_hshChangedFields [ "st_ag" ]="."; } 
		public void set_st_conta ( string val ) { st_conta = val; m_hshChangedFields [ "st_conta" ]="."; } 
		public void set_st_banco ( string val ) { st_banco = val; m_hshChangedFields [ "st_banco" ]="."; } 
		
		public void set_fk_loja ( long val ) { fk_loja = Convert.ToString(val); m_hshChangedFields [ "fk_loja" ]="."; } 
		public void set_fk_empresa ( long val ) { fk_empresa = Convert.ToString(val); m_hshChangedFields [ "fk_empresa" ]="."; } 
		public void set_tx_admin ( long val ) { tx_admin = Convert.ToString(val); m_hshChangedFields [ "tx_admin" ]="."; } 
		public void set_nu_dias_repasse ( long val ) { nu_dias_repasse = Convert.ToString(val); m_hshChangedFields [ "nu_dias_repasse" ]="."; } 
			
		public void fieldSelection()
		{
			m_gen_dbStatement.AddSelect ( TB_LINK_LOJAEMPRESA.i_unique );
			m_gen_dbStatement.AddSelect ( TB_LINK_LOJAEMPRESA.fk_loja );
			m_gen_dbStatement.AddSelect ( TB_LINK_LOJAEMPRESA.fk_empresa );
			m_gen_dbStatement.AddSelect ( TB_LINK_LOJAEMPRESA.tx_admin );
			m_gen_dbStatement.AddSelect ( TB_LINK_LOJAEMPRESA.nu_dias_repasse );
			m_gen_dbStatement.AddSelect ( TB_LINK_LOJAEMPRESA.st_ag );
			m_gen_dbStatement.AddSelect ( TB_LINK_LOJAEMPRESA.st_conta );
			m_gen_dbStatement.AddSelect ( TB_LINK_LOJAEMPRESA.st_banco );
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
			
				m_gen_dbStatement.AddWhere ( TB_LINK_LOJAEMPRESA.i_unique, identity, TB_LINK_LOJAEMPRESA.type_i_unique );
			
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
		
		public bool create_LINK_LojaEmpresa ( )
		{
			try{
			string new_id = "";
			
			StartInsert();
			
			m_gen_dbStatement.AddValue ( TB_LINK_LOJAEMPRESA.fk_loja, fk_loja, TB_LINK_LOJAEMPRESA.type_fk_loja );
			m_gen_dbStatement.AddValue ( TB_LINK_LOJAEMPRESA.fk_empresa, fk_empresa, TB_LINK_LOJAEMPRESA.type_fk_empresa );
			m_gen_dbStatement.AddValue ( TB_LINK_LOJAEMPRESA.tx_admin, tx_admin, TB_LINK_LOJAEMPRESA.type_tx_admin );
			m_gen_dbStatement.AddValue ( TB_LINK_LOJAEMPRESA.nu_dias_repasse, nu_dias_repasse, TB_LINK_LOJAEMPRESA.type_nu_dias_repasse );
			m_gen_dbStatement.AddValue ( TB_LINK_LOJAEMPRESA.st_ag, st_ag, TB_LINK_LOJAEMPRESA.type_st_ag );
			m_gen_dbStatement.AddValue ( TB_LINK_LOJAEMPRESA.st_conta, st_conta, TB_LINK_LOJAEMPRESA.type_st_conta );
			m_gen_dbStatement.AddValue ( TB_LINK_LOJAEMPRESA.st_banco, st_banco, TB_LINK_LOJAEMPRESA.type_st_banco );
			
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
				m_gen_dbStatement.AddWhere ( TB_LINK_LOJAEMPRESA.i_unique, i_unique, TB_LINK_LOJAEMPRESA.type_i_unique );
			
			ret = Execute();
			
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
			
			return ret; 
		}
			
		public bool select_fk_empresa_geral ( string val_fk_empresa )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddWhere ( TB_LINK_LOJAEMPRESA.fk_empresa, val_fk_empresa , TB_LINK_LOJAEMPRESA.type_fk_empresa);
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
			
		public bool select_fk_empresa_loja ( string val_fk_empresa, string val_fk_loja )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddWhere ( TB_LINK_LOJAEMPRESA.fk_empresa, val_fk_empresa , TB_LINK_LOJAEMPRESA.type_fk_empresa);
				m_gen_dbStatement.AddWhere ( TB_LINK_LOJAEMPRESA.fk_loja, val_fk_loja , TB_LINK_LOJAEMPRESA.type_fk_loja);
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
			
		public bool select_fk_loja ( string val_fk_loja )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddWhere ( TB_LINK_LOJAEMPRESA.fk_loja, val_fk_loja , TB_LINK_LOJAEMPRESA.type_fk_loja);
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
			
		public bool select_rows_empresas ( ref ArrayList lst_fk_empresa_0 )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddWhereIn ( TB_LINK_LOJAEMPRESA.fk_empresa, ref lst_fk_empresa_0 );
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
	}
}
