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
	public class LOG_Fechamento : Synchronization
	{
		private string i_unique = "0";
		private string st_mes = "";
		private string st_ano = "";
		private string vr_valor = "0";
		private string dt_fechamento = "1900-01-01 00:00:00";
		private string fk_empresa = "0";
		private string fk_loja = "0";
		private string fk_cartao = "0";
		private string fk_parcela = "0";
		private string dt_compra = "1900-01-01 00:00:00";
		private string nu_parcela = "0";
		private string st_cartao = "";
		private string st_afiliada = "";
		
		public int var_FieldCount = 13;
		
		public LOG_Fechamento ( infra_Patch i_patch )  : base ( i_patch )
		{
			var_Tablename = TB_LOG_FECHAMENTO.Alias;
		}
		public string exportNames()
		{
			return "st_mes,st_ano,vr_valor,dt_fechamento,fk_empresa,fk_loja,fk_cartao,fk_parcela,dt_compra,nu_parcela,st_cartao,st_afiliada";
		}
		
		public string exportCSV()
		{
			return i_unique + str_field_sep + st_mes + str_field_sep + st_ano + str_field_sep + vr_valor + str_field_sep + dt_fechamento + str_field_sep + fk_empresa + str_field_sep + fk_loja + str_field_sep + fk_cartao + str_field_sep + fk_parcela + str_field_sep + dt_compra + str_field_sep + nu_parcela + str_field_sep + st_cartao + str_field_sep + st_afiliada;
		}
		
		public void Reset()
		{
			i_unique = "0";
			st_mes = "";
			st_ano = "";
			vr_valor = "0";
			dt_fechamento = "1900-01-01 00:00:00";
			fk_empresa = "0";
			fk_loja = "0";
			fk_cartao = "0";
			fk_parcela = "0";
			dt_compra = "1900-01-01 00:00:00";
			nu_parcela = "0";
			st_cartao = "";
			st_afiliada = "";
		}
		
		public void copy ( ref LOG_Fechamento cpy )
		{
			st_mes = cpy.st_mes;
			st_ano = cpy.st_ano;
			vr_valor = cpy.vr_valor;
			dt_fechamento = cpy.dt_fechamento;
			fk_empresa = cpy.fk_empresa;
			fk_loja = cpy.fk_loja;
			fk_cartao = cpy.fk_cartao;
			fk_parcela = cpy.fk_parcela;
			dt_compra = cpy.dt_compra;
			nu_parcela = cpy.nu_parcela;
			st_cartao = cpy.st_cartao;
			st_afiliada = cpy.st_afiliada;
		}
		
		public override void fetchRetrieve ( ref DB_Row row )
		{
			i_unique = row.GetField ( TB_LOG_FECHAMENTO.i_unique );
			st_mes = row.GetField ( TB_LOG_FECHAMENTO.st_mes );
			st_ano = row.GetField ( TB_LOG_FECHAMENTO.st_ano );
			vr_valor = row.GetField ( TB_LOG_FECHAMENTO.vr_valor );
			dt_fechamento = ConvertTime ( row.GetField ( TB_LOG_FECHAMENTO.dt_fechamento ) );
			fk_empresa = row.GetField ( TB_LOG_FECHAMENTO.fk_empresa );
			fk_loja = row.GetField ( TB_LOG_FECHAMENTO.fk_loja );
			fk_cartao = row.GetField ( TB_LOG_FECHAMENTO.fk_cartao );
			fk_parcela = row.GetField ( TB_LOG_FECHAMENTO.fk_parcela );
			dt_compra = ConvertTime ( row.GetField ( TB_LOG_FECHAMENTO.dt_compra ) );
			nu_parcela = row.GetField ( TB_LOG_FECHAMENTO.nu_parcela );
			st_cartao = row.GetField ( TB_LOG_FECHAMENTO.st_cartao );
			st_afiliada = row.GetField ( TB_LOG_FECHAMENTO.st_afiliada );
		}
		
		public bool synchronize_LOG_Fechamento ( )
		{
			try{
			
			if ( m_hshChangedFields.Count == 0 )
				return true;
			
			StartUpdate();
		
			if ( m_hshChangedFields [ "st_mes" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_FECHAMENTO.st_mes , st_mes , TB_LOG_FECHAMENTO.type_st_mes );
			if ( m_hshChangedFields [ "st_ano" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_FECHAMENTO.st_ano , st_ano , TB_LOG_FECHAMENTO.type_st_ano );
			if ( m_hshChangedFields [ "vr_valor" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_FECHAMENTO.vr_valor , vr_valor , TB_LOG_FECHAMENTO.type_vr_valor );
			if ( m_hshChangedFields [ "dt_fechamento" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_FECHAMENTO.dt_fechamento , dt_fechamento , TB_LOG_FECHAMENTO.type_dt_fechamento );
			if ( m_hshChangedFields [ "fk_empresa" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_FECHAMENTO.fk_empresa , fk_empresa , TB_LOG_FECHAMENTO.type_fk_empresa );
			if ( m_hshChangedFields [ "fk_loja" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_FECHAMENTO.fk_loja , fk_loja , TB_LOG_FECHAMENTO.type_fk_loja );
			if ( m_hshChangedFields [ "fk_cartao" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_FECHAMENTO.fk_cartao , fk_cartao , TB_LOG_FECHAMENTO.type_fk_cartao );
			if ( m_hshChangedFields [ "fk_parcela" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_FECHAMENTO.fk_parcela , fk_parcela , TB_LOG_FECHAMENTO.type_fk_parcela );
			if ( m_hshChangedFields [ "dt_compra" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_FECHAMENTO.dt_compra , dt_compra , TB_LOG_FECHAMENTO.type_dt_compra );
			if ( m_hshChangedFields [ "nu_parcela" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_FECHAMENTO.nu_parcela , nu_parcela , TB_LOG_FECHAMENTO.type_nu_parcela );
			if ( m_hshChangedFields [ "st_cartao" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_FECHAMENTO.st_cartao , st_cartao , TB_LOG_FECHAMENTO.type_st_cartao );
			if ( m_hshChangedFields [ "st_afiliada" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_FECHAMENTO.st_afiliada , st_afiliada , TB_LOG_FECHAMENTO.type_st_afiliada );
		
			m_gen_dbStatement.AddWhere ( TB_LOG_FECHAMENTO.i_unique, i_unique, TB_LOG_FECHAMENTO.type_i_unique );
		
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
		
			return Update();
		}
			
		public string get_identity() { return i_unique; } 
		public string get_st_mes() { return st_mes; } 
		public string get_st_ano() { return st_ano; } 
		public string get_vr_valor() { return vr_valor; } 
		public string get_dt_fechamento() { return dt_fechamento; } 
		public string get_fk_empresa() { return fk_empresa; } 
		public string get_fk_loja() { return fk_loja; } 
		public string get_fk_cartao() { return fk_cartao; } 
		public string get_fk_parcela() { return fk_parcela; } 
		public string get_dt_compra() { return dt_compra; } 
		public string get_nu_parcela() { return nu_parcela; } 
		public string get_st_cartao() { return st_cartao; } 
		public string get_st_afiliada() { return st_afiliada; } 
			
		public long get_int_vr_valor() { return Convert.ToInt64 ( vr_valor ); } 
		public long get_int_fk_empresa() { return Convert.ToInt64 ( fk_empresa ); } 
		public long get_int_fk_loja() { return Convert.ToInt64 ( fk_loja ); } 
		public long get_int_fk_cartao() { return Convert.ToInt64 ( fk_cartao ); } 
		public long get_int_fk_parcela() { return Convert.ToInt64 ( fk_parcela ); } 
		public long get_int_nu_parcela() { return Convert.ToInt64 ( nu_parcela ); } 
			
		public void set_st_mes ( string val ) { st_mes = val; m_hshChangedFields [ "st_mes" ]="."; } 
		public void set_st_ano ( string val ) { st_ano = val; m_hshChangedFields [ "st_ano" ]="."; } 
		public void set_vr_valor ( string val ) { vr_valor = val; m_hshChangedFields [ "vr_valor" ]="."; } 
		public void set_dt_fechamento ( string val ) { dt_fechamento = val; m_hshChangedFields [ "dt_fechamento" ]="."; } 
		public void set_fk_empresa ( string val ) { fk_empresa = val; m_hshChangedFields [ "fk_empresa" ]="."; } 
		public void set_fk_loja ( string val ) { fk_loja = val; m_hshChangedFields [ "fk_loja" ]="."; } 
		public void set_fk_cartao ( string val ) { fk_cartao = val; m_hshChangedFields [ "fk_cartao" ]="."; } 
		public void set_fk_parcela ( string val ) { fk_parcela = val; m_hshChangedFields [ "fk_parcela" ]="."; } 
		public void set_dt_compra ( string val ) { dt_compra = val; m_hshChangedFields [ "dt_compra" ]="."; } 
		public void set_nu_parcela ( string val ) { nu_parcela = val; m_hshChangedFields [ "nu_parcela" ]="."; } 
		public void set_st_cartao ( string val ) { st_cartao = val; m_hshChangedFields [ "st_cartao" ]="."; } 
		public void set_st_afiliada ( string val ) { st_afiliada = val; m_hshChangedFields [ "st_afiliada" ]="."; } 
		
		public void set_vr_valor ( long val ) { vr_valor = Convert.ToString(val); m_hshChangedFields [ "vr_valor" ]="."; } 
		public void set_fk_empresa ( long val ) { fk_empresa = Convert.ToString(val); m_hshChangedFields [ "fk_empresa" ]="."; } 
		public void set_fk_loja ( long val ) { fk_loja = Convert.ToString(val); m_hshChangedFields [ "fk_loja" ]="."; } 
		public void set_fk_cartao ( long val ) { fk_cartao = Convert.ToString(val); m_hshChangedFields [ "fk_cartao" ]="."; } 
		public void set_fk_parcela ( long val ) { fk_parcela = Convert.ToString(val); m_hshChangedFields [ "fk_parcela" ]="."; } 
		public void set_nu_parcela ( long val ) { nu_parcela = Convert.ToString(val); m_hshChangedFields [ "nu_parcela" ]="."; } 
			
		public void fieldSelection()
		{
			m_gen_dbStatement.AddSelect ( TB_LOG_FECHAMENTO.i_unique );
			m_gen_dbStatement.AddSelect ( TB_LOG_FECHAMENTO.st_mes );
			m_gen_dbStatement.AddSelect ( TB_LOG_FECHAMENTO.st_ano );
			m_gen_dbStatement.AddSelect ( TB_LOG_FECHAMENTO.vr_valor );
			m_gen_dbStatement.AddSelect ( TB_LOG_FECHAMENTO.dt_fechamento );
			m_gen_dbStatement.AddSelect ( TB_LOG_FECHAMENTO.fk_empresa );
			m_gen_dbStatement.AddSelect ( TB_LOG_FECHAMENTO.fk_loja );
			m_gen_dbStatement.AddSelect ( TB_LOG_FECHAMENTO.fk_cartao );
			m_gen_dbStatement.AddSelect ( TB_LOG_FECHAMENTO.fk_parcela );
			m_gen_dbStatement.AddSelect ( TB_LOG_FECHAMENTO.dt_compra );
			m_gen_dbStatement.AddSelect ( TB_LOG_FECHAMENTO.nu_parcela );
			m_gen_dbStatement.AddSelect ( TB_LOG_FECHAMENTO.st_cartao );
			m_gen_dbStatement.AddSelect ( TB_LOG_FECHAMENTO.st_afiliada );
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
			
				m_gen_dbStatement.AddWhere ( TB_LOG_FECHAMENTO.i_unique, identity, TB_LOG_FECHAMENTO.type_i_unique );
			
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
		
		public bool create_LOG_Fechamento ( )
		{
			try{
			string new_id = "";
			
			StartInsert();
			
			m_gen_dbStatement.AddValue ( TB_LOG_FECHAMENTO.st_mes, st_mes, TB_LOG_FECHAMENTO.type_st_mes );
			m_gen_dbStatement.AddValue ( TB_LOG_FECHAMENTO.st_ano, st_ano, TB_LOG_FECHAMENTO.type_st_ano );
			m_gen_dbStatement.AddValue ( TB_LOG_FECHAMENTO.vr_valor, vr_valor, TB_LOG_FECHAMENTO.type_vr_valor );
			m_gen_dbStatement.AddValue ( TB_LOG_FECHAMENTO.dt_fechamento, dt_fechamento, TB_LOG_FECHAMENTO.type_dt_fechamento );
			m_gen_dbStatement.AddValue ( TB_LOG_FECHAMENTO.fk_empresa, fk_empresa, TB_LOG_FECHAMENTO.type_fk_empresa );
			m_gen_dbStatement.AddValue ( TB_LOG_FECHAMENTO.fk_loja, fk_loja, TB_LOG_FECHAMENTO.type_fk_loja );
			m_gen_dbStatement.AddValue ( TB_LOG_FECHAMENTO.fk_cartao, fk_cartao, TB_LOG_FECHAMENTO.type_fk_cartao );
			m_gen_dbStatement.AddValue ( TB_LOG_FECHAMENTO.fk_parcela, fk_parcela, TB_LOG_FECHAMENTO.type_fk_parcela );
			m_gen_dbStatement.AddValue ( TB_LOG_FECHAMENTO.dt_compra, dt_compra, TB_LOG_FECHAMENTO.type_dt_compra );
			m_gen_dbStatement.AddValue ( TB_LOG_FECHAMENTO.nu_parcela, nu_parcela, TB_LOG_FECHAMENTO.type_nu_parcela );
			m_gen_dbStatement.AddValue ( TB_LOG_FECHAMENTO.st_cartao, st_cartao, TB_LOG_FECHAMENTO.type_st_cartao );
			m_gen_dbStatement.AddValue ( TB_LOG_FECHAMENTO.st_afiliada, st_afiliada, TB_LOG_FECHAMENTO.type_st_afiliada );
			
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
				m_gen_dbStatement.AddWhere ( TB_LOG_FECHAMENTO.i_unique, i_unique, TB_LOG_FECHAMENTO.type_i_unique );
			
			ret = Execute();
			
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
			
			return ret; 
		}
			
		public bool select_rows_mes_ano ( string val_st_mes, string val_st_ano, string val_fk_empresa )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddWhere ( TB_LOG_FECHAMENTO.st_mes, val_st_mes , TB_LOG_FECHAMENTO.type_st_mes);
				m_gen_dbStatement.AddWhere ( TB_LOG_FECHAMENTO.st_ano, val_st_ano , TB_LOG_FECHAMENTO.type_st_ano);
				m_gen_dbStatement.AddWhere ( TB_LOG_FECHAMENTO.fk_empresa, val_fk_empresa , TB_LOG_FECHAMENTO.type_fk_empresa);
			
				m_gen_dbStatement.AddOrderBy ( TB_LOG_FECHAMENTO.fk_loja );
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
			
		public bool select_rows_mes_ano_carts ( string val_st_mes, string val_st_ano, ref ArrayList lst_fk_cartao_2 )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddWhere ( TB_LOG_FECHAMENTO.st_mes, val_st_mes , TB_LOG_FECHAMENTO.type_st_mes);
				m_gen_dbStatement.AddWhere ( TB_LOG_FECHAMENTO.st_ano, val_st_ano , TB_LOG_FECHAMENTO.type_st_ano);
				m_gen_dbStatement.AddWhereIn ( TB_LOG_FECHAMENTO.fk_cartao, ref lst_fk_cartao_2 );
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
	}
}