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
	public class T_ChequesGift : Synchronization
	{
		private string i_unique = "0";
		private string st_identificador = "";
		private string fk_cartao = "0";
		private string dt_efetiva = "1900-01-01 00:00:00";
		private string tg_compensado = "0";
		private string vr_valor = "0";
		
		public int var_FieldCount = 6;
		
		public T_ChequesGift ()
		{
			var_Serial = TB_T_CHEQUESGIFT.serial;
			var_Tablename = TB_T_CHEQUESGIFT.Alias;
		}
		
		public T_ChequesGift ( Transaction trx )
		{
			AcquireTransaction ( ref trx );
			
			var_Serial = TB_T_CHEQUESGIFT.serial;
			var_Tablename = TB_T_CHEQUESGIFT.Alias;
			
			TraceLog ( var_Tablename + " serial : " + var_serialNumber);
		}
		
		public string exportNames()
		{
			return "st_identificador,fk_cartao,dt_efetiva,tg_compensado,vr_valor";
		}
		
		public string exportCSV()
		{
			return i_unique + str_field_sep + st_identificador + str_field_sep + fk_cartao + str_field_sep + dt_efetiva + str_field_sep + tg_compensado + str_field_sep + vr_valor;
		}
		
		public void Reset()
		{
			i_unique = "0";
			st_identificador = "";
			fk_cartao = "0";
			dt_efetiva = "1900-01-01 00:00:00";
			tg_compensado = "0";
			vr_valor = "0";
		
			ReleaseExclusive();
		}
		
		public void copy ( ref T_ChequesGift cpy )
		{
			st_identificador = cpy.st_identificador;
			fk_cartao = cpy.fk_cartao;
			dt_efetiva = cpy.dt_efetiva;
			tg_compensado = cpy.tg_compensado;
			vr_valor = cpy.vr_valor;
		}
		
		public override void fetchRetrieve ( ref DB_Row row )
		{
			i_unique = row.GetField ( TB_T_CHEQUESGIFT.i_unique );
			st_identificador = row.GetField ( TB_T_CHEQUESGIFT.st_identificador );
			fk_cartao = row.GetField ( TB_T_CHEQUESGIFT.fk_cartao );
			dt_efetiva = ConvertTime ( row.GetField ( TB_T_CHEQUESGIFT.dt_efetiva ) );
			tg_compensado = row.GetField ( TB_T_CHEQUESGIFT.tg_compensado );
			vr_valor = row.GetField ( TB_T_CHEQUESGIFT.vr_valor );
		}
		
		public bool synchronize_T_ChequesGift ( )
		{
			try{
			
			if ( m_hshChangedFields.Count == 0 )
				return true;
			
			StartUpdate();
		
			if ( m_hshChangedFields [ "st_identificador" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_CHEQUESGIFT.st_identificador , st_identificador , TB_T_CHEQUESGIFT.type_st_identificador );
			if ( m_hshChangedFields [ "fk_cartao" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_CHEQUESGIFT.fk_cartao , fk_cartao , TB_T_CHEQUESGIFT.type_fk_cartao );
			if ( m_hshChangedFields [ "dt_efetiva" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_CHEQUESGIFT.dt_efetiva , dt_efetiva , TB_T_CHEQUESGIFT.type_dt_efetiva );
			if ( m_hshChangedFields [ "tg_compensado" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_CHEQUESGIFT.tg_compensado , tg_compensado , TB_T_CHEQUESGIFT.type_tg_compensado );
			if ( m_hshChangedFields [ "vr_valor" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_CHEQUESGIFT.vr_valor , vr_valor , TB_T_CHEQUESGIFT.type_vr_valor );
		
			m_gen_dbStatement.AddWhere ( TB_T_CHEQUESGIFT.i_unique, i_unique, TB_T_CHEQUESGIFT.type_i_unique );
		
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
		
			return Update();
		}
			
		public string get_identity() { return i_unique; } 
		public string get_st_identificador() { return st_identificador; } 
		public string get_fk_cartao() { return fk_cartao; } 
		public string get_dt_efetiva() { return dt_efetiva; } 
		public string get_tg_compensado() { return tg_compensado; } 
		public string get_vr_valor() { return vr_valor; } 
			
		public long get_int_fk_cartao() { return Convert.ToInt64 ( fk_cartao ); } 
		public long get_int_tg_compensado() { return Convert.ToInt64 ( tg_compensado ); } 
		public long get_int_vr_valor() { return Convert.ToInt64 ( vr_valor ); } 
			
		public void set_st_identificador ( string val ) { st_identificador = val; m_hshChangedFields [ "st_identificador" ]="."; } 
		public void set_fk_cartao ( string val ) { fk_cartao = val; m_hshChangedFields [ "fk_cartao" ]="."; } 
		public void set_dt_efetiva ( string val ) { dt_efetiva = val; m_hshChangedFields [ "dt_efetiva" ]="."; } 
		public void set_tg_compensado ( string val ) { tg_compensado = val; m_hshChangedFields [ "tg_compensado" ]="."; } 
		public void set_vr_valor ( string val ) { vr_valor = val; m_hshChangedFields [ "vr_valor" ]="."; } 
		
		public void set_fk_cartao ( long val ) { fk_cartao = Convert.ToString(val); m_hshChangedFields [ "fk_cartao" ]="."; } 
		public void set_tg_compensado ( long val ) { tg_compensado = Convert.ToString(val); m_hshChangedFields [ "tg_compensado" ]="."; } 
		public void set_vr_valor ( long val ) { vr_valor = Convert.ToString(val); m_hshChangedFields [ "vr_valor" ]="."; } 
			
		public void fieldSelection()
		{
			m_gen_dbStatement.AddSelect ( TB_T_CHEQUESGIFT.i_unique );
			m_gen_dbStatement.AddSelect ( TB_T_CHEQUESGIFT.st_identificador );
			m_gen_dbStatement.AddSelect ( TB_T_CHEQUESGIFT.fk_cartao );
			m_gen_dbStatement.AddSelect ( TB_T_CHEQUESGIFT.dt_efetiva );
			m_gen_dbStatement.AddSelect ( TB_T_CHEQUESGIFT.tg_compensado );
			m_gen_dbStatement.AddSelect ( TB_T_CHEQUESGIFT.vr_valor );
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
			
				m_gen_dbStatement.AddWhere ( TB_T_CHEQUESGIFT.i_unique, identity, TB_T_CHEQUESGIFT.type_i_unique );
			
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
		
		public bool create_T_ChequesGift ( )
		{
			try{
			string new_id = "";
			
			StartInsert();
			
			m_gen_dbStatement.AddValue ( TB_T_CHEQUESGIFT.st_identificador, st_identificador, TB_T_CHEQUESGIFT.type_st_identificador );
			m_gen_dbStatement.AddValue ( TB_T_CHEQUESGIFT.fk_cartao, fk_cartao, TB_T_CHEQUESGIFT.type_fk_cartao );
			m_gen_dbStatement.AddValue ( TB_T_CHEQUESGIFT.dt_efetiva, dt_efetiva, TB_T_CHEQUESGIFT.type_dt_efetiva );
			m_gen_dbStatement.AddValue ( TB_T_CHEQUESGIFT.tg_compensado, tg_compensado, TB_T_CHEQUESGIFT.type_tg_compensado );
			m_gen_dbStatement.AddValue ( TB_T_CHEQUESGIFT.vr_valor, vr_valor, TB_T_CHEQUESGIFT.type_vr_valor );
			
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
				m_gen_dbStatement.AddWhere ( TB_T_CHEQUESGIFT.i_unique, i_unique, TB_T_CHEQUESGIFT.type_i_unique );
			
			ret = Execute();
			
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
			
			return ret; 
		}
			
		public bool select_rows_cart_comp ( string val_fk_cartao, string val_tg_compensado )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddWhere ( TB_T_CHEQUESGIFT.fk_cartao, val_fk_cartao , TB_T_CHEQUESGIFT.type_fk_cartao);
				m_gen_dbStatement.AddWhere ( TB_T_CHEQUESGIFT.tg_compensado, val_tg_compensado , TB_T_CHEQUESGIFT.type_tg_compensado);
			
				m_gen_dbStatement.AddOrderBy ( TB_T_CHEQUESGIFT.dt_efetiva );
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
			
		public bool select_rows_ident ( string val_st_identificador )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddWhere ( TB_T_CHEQUESGIFT.st_identificador, val_st_identificador , TB_T_CHEQUESGIFT.type_st_identificador);
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
		
		#if DEBUG
		
		public bool setup ( bool IsTruncate, ref string id, string var_st_identificador, string var_fk_cartao, string var_dt_efetiva, string var_tg_compensado, string var_vr_valor )
		{
			if ( IsTruncate ) 
			{
				i_unique = "";
				this.delete();
			}
		
			set_st_identificador ( var_st_identificador );
			set_fk_cartao ( var_fk_cartao );
			set_dt_efetiva ( var_dt_efetiva );
			set_tg_compensado ( var_tg_compensado );
			set_vr_valor ( var_vr_valor );
			
			if ( create_T_ChequesGift() == false )
			{
				return false;
			}
			
			id = get_identity();
			return true;
		}
		
		#endif
		
	}
}
