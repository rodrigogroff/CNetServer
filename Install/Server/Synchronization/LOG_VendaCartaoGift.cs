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
	public class LOG_VendaCartaoGift : Synchronization
	{
		private string i_unique = "0";
		private string fk_vendedor = "0";
		private string fk_empresa = "0";
		private string fk_cartao = "0";
		private string tg_tipoPag = "0";
		private string dt_compra = "1900-01-01 00:00:00";
		private string tg_tipoCartao = "0";
		private string st_cheque = "";
		private string nu_nsuCartao = "0";
		private string vr_carga = "0";
		private string tg_adesao = "0";
		private string st_codImpresso = "";
		
		public int var_FieldCount = 12;
		
		public LOG_VendaCartaoGift ( infra_Patch i_patch )  : base ( i_patch )
		{
			var_Tablename = TB_LOG_VENDACARTAOGIFT.Alias;
		}
		public string exportNames()
		{
			return "fk_vendedor,fk_empresa,fk_cartao,tg_tipoPag,dt_compra,tg_tipoCartao,st_cheque,nu_nsuCartao,vr_carga,tg_adesao,st_codImpresso";
		}
		
		public string exportCSV()
		{
			return i_unique + str_field_sep + fk_vendedor + str_field_sep + fk_empresa + str_field_sep + fk_cartao + str_field_sep + tg_tipoPag + str_field_sep + dt_compra + str_field_sep + tg_tipoCartao + str_field_sep + st_cheque + str_field_sep + nu_nsuCartao + str_field_sep + vr_carga + str_field_sep + tg_adesao + str_field_sep + st_codImpresso;
		}
		
		public void Reset()
		{
			i_unique = "0";
			fk_vendedor = "0";
			fk_empresa = "0";
			fk_cartao = "0";
			tg_tipoPag = "0";
			dt_compra = "1900-01-01 00:00:00";
			tg_tipoCartao = "0";
			st_cheque = "";
			nu_nsuCartao = "0";
			vr_carga = "0";
			tg_adesao = "0";
			st_codImpresso = "";
		}
		
		public void copy ( ref LOG_VendaCartaoGift cpy )
		{
			fk_vendedor = cpy.fk_vendedor;
			fk_empresa = cpy.fk_empresa;
			fk_cartao = cpy.fk_cartao;
			tg_tipoPag = cpy.tg_tipoPag;
			dt_compra = cpy.dt_compra;
			tg_tipoCartao = cpy.tg_tipoCartao;
			st_cheque = cpy.st_cheque;
			nu_nsuCartao = cpy.nu_nsuCartao;
			vr_carga = cpy.vr_carga;
			tg_adesao = cpy.tg_adesao;
			st_codImpresso = cpy.st_codImpresso;
		}
		
		public override void fetchRetrieve ( ref DB_Row row )
		{
			i_unique = row.GetField ( TB_LOG_VENDACARTAOGIFT.i_unique );
			fk_vendedor = row.GetField ( TB_LOG_VENDACARTAOGIFT.fk_vendedor );
			fk_empresa = row.GetField ( TB_LOG_VENDACARTAOGIFT.fk_empresa );
			fk_cartao = row.GetField ( TB_LOG_VENDACARTAOGIFT.fk_cartao );
			tg_tipoPag = row.GetField ( TB_LOG_VENDACARTAOGIFT.tg_tipoPag );
			dt_compra = ConvertTime ( row.GetField ( TB_LOG_VENDACARTAOGIFT.dt_compra ) );
			tg_tipoCartao = row.GetField ( TB_LOG_VENDACARTAOGIFT.tg_tipoCartao );
			st_cheque = row.GetField ( TB_LOG_VENDACARTAOGIFT.st_cheque );
			nu_nsuCartao = row.GetField ( TB_LOG_VENDACARTAOGIFT.nu_nsuCartao );
			vr_carga = row.GetField ( TB_LOG_VENDACARTAOGIFT.vr_carga );
			tg_adesao = row.GetField ( TB_LOG_VENDACARTAOGIFT.tg_adesao );
			st_codImpresso = row.GetField ( TB_LOG_VENDACARTAOGIFT.st_codImpresso );
		}
		
		public bool synchronize_LOG_VendaCartaoGift ( )
		{
			try{
			
			if ( m_hshChangedFields.Count == 0 )
				return true;
			
			StartUpdate();
		
			if ( m_hshChangedFields [ "fk_vendedor" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_VENDACARTAOGIFT.fk_vendedor , fk_vendedor , TB_LOG_VENDACARTAOGIFT.type_fk_vendedor );
			if ( m_hshChangedFields [ "fk_empresa" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_VENDACARTAOGIFT.fk_empresa , fk_empresa , TB_LOG_VENDACARTAOGIFT.type_fk_empresa );
			if ( m_hshChangedFields [ "fk_cartao" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_VENDACARTAOGIFT.fk_cartao , fk_cartao , TB_LOG_VENDACARTAOGIFT.type_fk_cartao );
			if ( m_hshChangedFields [ "tg_tipoPag" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_VENDACARTAOGIFT.tg_tipoPag , tg_tipoPag , TB_LOG_VENDACARTAOGIFT.type_tg_tipoPag );
			if ( m_hshChangedFields [ "dt_compra" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_VENDACARTAOGIFT.dt_compra , dt_compra , TB_LOG_VENDACARTAOGIFT.type_dt_compra );
			if ( m_hshChangedFields [ "tg_tipoCartao" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_VENDACARTAOGIFT.tg_tipoCartao , tg_tipoCartao , TB_LOG_VENDACARTAOGIFT.type_tg_tipoCartao );
			if ( m_hshChangedFields [ "st_cheque" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_VENDACARTAOGIFT.st_cheque , st_cheque , TB_LOG_VENDACARTAOGIFT.type_st_cheque );
			if ( m_hshChangedFields [ "nu_nsuCartao" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_VENDACARTAOGIFT.nu_nsuCartao , nu_nsuCartao , TB_LOG_VENDACARTAOGIFT.type_nu_nsuCartao );
			if ( m_hshChangedFields [ "vr_carga" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_VENDACARTAOGIFT.vr_carga , vr_carga , TB_LOG_VENDACARTAOGIFT.type_vr_carga );
			if ( m_hshChangedFields [ "tg_adesao" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_VENDACARTAOGIFT.tg_adesao , tg_adesao , TB_LOG_VENDACARTAOGIFT.type_tg_adesao );
			if ( m_hshChangedFields [ "st_codImpresso" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_LOG_VENDACARTAOGIFT.st_codImpresso , st_codImpresso , TB_LOG_VENDACARTAOGIFT.type_st_codImpresso );
		
			m_gen_dbStatement.AddWhere ( TB_LOG_VENDACARTAOGIFT.i_unique, i_unique, TB_LOG_VENDACARTAOGIFT.type_i_unique );
		
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
		
			return Update();
		}
			
		public string get_identity() { return i_unique; } 
		public string get_fk_vendedor() { return fk_vendedor; } 
		public string get_fk_empresa() { return fk_empresa; } 
		public string get_fk_cartao() { return fk_cartao; } 
		public string get_tg_tipoPag() { return tg_tipoPag; } 
		public string get_dt_compra() { return dt_compra; } 
		public string get_tg_tipoCartao() { return tg_tipoCartao; } 
		public string get_st_cheque() { return st_cheque; } 
		public string get_nu_nsuCartao() { return nu_nsuCartao; } 
		public string get_vr_carga() { return vr_carga; } 
		public string get_tg_adesao() { return tg_adesao; } 
		public string get_st_codImpresso() { return st_codImpresso; } 
			
		public long get_int_fk_vendedor() { return Convert.ToInt64 ( fk_vendedor ); } 
		public long get_int_fk_empresa() { return Convert.ToInt64 ( fk_empresa ); } 
		public long get_int_fk_cartao() { return Convert.ToInt64 ( fk_cartao ); } 
		public long get_int_tg_tipoPag() { return Convert.ToInt64 ( tg_tipoPag ); } 
		public long get_int_tg_tipoCartao() { return Convert.ToInt64 ( tg_tipoCartao ); } 
		public long get_int_nu_nsuCartao() { return Convert.ToInt64 ( nu_nsuCartao ); } 
		public long get_int_vr_carga() { return Convert.ToInt64 ( vr_carga ); } 
		public long get_int_tg_adesao() { return Convert.ToInt64 ( tg_adesao ); } 
			
		public void set_fk_vendedor ( string val ) { fk_vendedor = val; m_hshChangedFields [ "fk_vendedor" ]="."; } 
		public void set_fk_empresa ( string val ) { fk_empresa = val; m_hshChangedFields [ "fk_empresa" ]="."; } 
		public void set_fk_cartao ( string val ) { fk_cartao = val; m_hshChangedFields [ "fk_cartao" ]="."; } 
		public void set_tg_tipoPag ( string val ) { tg_tipoPag = val; m_hshChangedFields [ "tg_tipoPag" ]="."; } 
		public void set_dt_compra ( string val ) { dt_compra = val; m_hshChangedFields [ "dt_compra" ]="."; } 
		public void set_tg_tipoCartao ( string val ) { tg_tipoCartao = val; m_hshChangedFields [ "tg_tipoCartao" ]="."; } 
		public void set_st_cheque ( string val ) { st_cheque = val; m_hshChangedFields [ "st_cheque" ]="."; } 
		public void set_nu_nsuCartao ( string val ) { nu_nsuCartao = val; m_hshChangedFields [ "nu_nsuCartao" ]="."; } 
		public void set_vr_carga ( string val ) { vr_carga = val; m_hshChangedFields [ "vr_carga" ]="."; } 
		public void set_tg_adesao ( string val ) { tg_adesao = val; m_hshChangedFields [ "tg_adesao" ]="."; } 
		public void set_st_codImpresso ( string val ) { st_codImpresso = val; m_hshChangedFields [ "st_codImpresso" ]="."; } 
		
		public void set_fk_vendedor ( long val ) { fk_vendedor = Convert.ToString(val); m_hshChangedFields [ "fk_vendedor" ]="."; } 
		public void set_fk_empresa ( long val ) { fk_empresa = Convert.ToString(val); m_hshChangedFields [ "fk_empresa" ]="."; } 
		public void set_fk_cartao ( long val ) { fk_cartao = Convert.ToString(val); m_hshChangedFields [ "fk_cartao" ]="."; } 
		public void set_tg_tipoPag ( long val ) { tg_tipoPag = Convert.ToString(val); m_hshChangedFields [ "tg_tipoPag" ]="."; } 
		public void set_tg_tipoCartao ( long val ) { tg_tipoCartao = Convert.ToString(val); m_hshChangedFields [ "tg_tipoCartao" ]="."; } 
		public void set_nu_nsuCartao ( long val ) { nu_nsuCartao = Convert.ToString(val); m_hshChangedFields [ "nu_nsuCartao" ]="."; } 
		public void set_vr_carga ( long val ) { vr_carga = Convert.ToString(val); m_hshChangedFields [ "vr_carga" ]="."; } 
		public void set_tg_adesao ( long val ) { tg_adesao = Convert.ToString(val); m_hshChangedFields [ "tg_adesao" ]="."; } 
			
		public void fieldSelection()
		{
			m_gen_dbStatement.AddSelect ( TB_LOG_VENDACARTAOGIFT.i_unique );
			m_gen_dbStatement.AddSelect ( TB_LOG_VENDACARTAOGIFT.fk_vendedor );
			m_gen_dbStatement.AddSelect ( TB_LOG_VENDACARTAOGIFT.fk_empresa );
			m_gen_dbStatement.AddSelect ( TB_LOG_VENDACARTAOGIFT.fk_cartao );
			m_gen_dbStatement.AddSelect ( TB_LOG_VENDACARTAOGIFT.tg_tipoPag );
			m_gen_dbStatement.AddSelect ( TB_LOG_VENDACARTAOGIFT.dt_compra );
			m_gen_dbStatement.AddSelect ( TB_LOG_VENDACARTAOGIFT.tg_tipoCartao );
			m_gen_dbStatement.AddSelect ( TB_LOG_VENDACARTAOGIFT.st_cheque );
			m_gen_dbStatement.AddSelect ( TB_LOG_VENDACARTAOGIFT.nu_nsuCartao );
			m_gen_dbStatement.AddSelect ( TB_LOG_VENDACARTAOGIFT.vr_carga );
			m_gen_dbStatement.AddSelect ( TB_LOG_VENDACARTAOGIFT.tg_adesao );
			m_gen_dbStatement.AddSelect ( TB_LOG_VENDACARTAOGIFT.st_codImpresso );
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
			
				m_gen_dbStatement.AddWhere ( TB_LOG_VENDACARTAOGIFT.i_unique, identity, TB_LOG_VENDACARTAOGIFT.type_i_unique );
			
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
		
		public bool create_LOG_VendaCartaoGift ( )
		{
			try{
			string new_id = "";
			
			StartInsert();
			
			m_gen_dbStatement.AddValue ( TB_LOG_VENDACARTAOGIFT.fk_vendedor, fk_vendedor, TB_LOG_VENDACARTAOGIFT.type_fk_vendedor );
			m_gen_dbStatement.AddValue ( TB_LOG_VENDACARTAOGIFT.fk_empresa, fk_empresa, TB_LOG_VENDACARTAOGIFT.type_fk_empresa );
			m_gen_dbStatement.AddValue ( TB_LOG_VENDACARTAOGIFT.fk_cartao, fk_cartao, TB_LOG_VENDACARTAOGIFT.type_fk_cartao );
			m_gen_dbStatement.AddValue ( TB_LOG_VENDACARTAOGIFT.tg_tipoPag, tg_tipoPag, TB_LOG_VENDACARTAOGIFT.type_tg_tipoPag );
			m_gen_dbStatement.AddValue ( TB_LOG_VENDACARTAOGIFT.dt_compra, dt_compra, TB_LOG_VENDACARTAOGIFT.type_dt_compra );
			m_gen_dbStatement.AddValue ( TB_LOG_VENDACARTAOGIFT.tg_tipoCartao, tg_tipoCartao, TB_LOG_VENDACARTAOGIFT.type_tg_tipoCartao );
			m_gen_dbStatement.AddValue ( TB_LOG_VENDACARTAOGIFT.st_cheque, st_cheque, TB_LOG_VENDACARTAOGIFT.type_st_cheque );
			m_gen_dbStatement.AddValue ( TB_LOG_VENDACARTAOGIFT.nu_nsuCartao, nu_nsuCartao, TB_LOG_VENDACARTAOGIFT.type_nu_nsuCartao );
			m_gen_dbStatement.AddValue ( TB_LOG_VENDACARTAOGIFT.vr_carga, vr_carga, TB_LOG_VENDACARTAOGIFT.type_vr_carga );
			m_gen_dbStatement.AddValue ( TB_LOG_VENDACARTAOGIFT.tg_adesao, tg_adesao, TB_LOG_VENDACARTAOGIFT.type_tg_adesao );
			m_gen_dbStatement.AddValue ( TB_LOG_VENDACARTAOGIFT.st_codImpresso, st_codImpresso, TB_LOG_VENDACARTAOGIFT.type_st_codImpresso );
			
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
				m_gen_dbStatement.AddWhere ( TB_LOG_VENDACARTAOGIFT.i_unique, i_unique, TB_LOG_VENDACARTAOGIFT.type_i_unique );
			
			ret = Execute();
			
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
			
			return ret; 
		}
			
		public bool select_fk_cart ( string val_fk_cartao )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddWhere ( TB_LOG_VENDACARTAOGIFT.fk_cartao, val_fk_cartao , TB_LOG_VENDACARTAOGIFT.type_fk_cartao);
			
				m_gen_dbStatement.AddOrderBy ( TB_LOG_VENDACARTAOGIFT.dt_compra );
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
			
		public bool select_rows_vendedor ( string val_fk_vendedor, string val_dt_compra, string val_dt_compra1 )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddWhere ( TB_LOG_VENDACARTAOGIFT.fk_vendedor, val_fk_vendedor , TB_LOG_VENDACARTAOGIFT.type_fk_vendedor);
				m_gen_dbStatement.AddWhereGreaterEqual ( TB_LOG_VENDACARTAOGIFT.dt_compra, val_dt_compra , TB_LOG_VENDACARTAOGIFT.type_dt_compra);
				m_gen_dbStatement.AddWhereLessThan ( TB_LOG_VENDACARTAOGIFT.dt_compra, val_dt_compra1 , TB_LOG_VENDACARTAOGIFT.type_dt_compra);
			
				m_gen_dbStatement.AddOrderBy ( TB_LOG_VENDACARTAOGIFT.dt_compra );
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
			
		public bool select_rows_cargas ( string val_dt_compra, string val_dt_compra1, string val_fk_empresa, string val_tg_adesao )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddWhereGreaterEqual ( TB_LOG_VENDACARTAOGIFT.dt_compra, val_dt_compra , TB_LOG_VENDACARTAOGIFT.type_dt_compra);
				m_gen_dbStatement.AddWhereLessThan ( TB_LOG_VENDACARTAOGIFT.dt_compra, val_dt_compra1 , TB_LOG_VENDACARTAOGIFT.type_dt_compra);
				m_gen_dbStatement.AddWhere ( TB_LOG_VENDACARTAOGIFT.fk_empresa, val_fk_empresa , TB_LOG_VENDACARTAOGIFT.type_fk_empresa);
				m_gen_dbStatement.AddWhere ( TB_LOG_VENDACARTAOGIFT.tg_adesao, val_tg_adesao , TB_LOG_VENDACARTAOGIFT.type_tg_adesao);
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
	}
}
