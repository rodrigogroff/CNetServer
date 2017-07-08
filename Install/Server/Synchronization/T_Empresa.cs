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
	public class T_Empresa : Synchronization
	{
		private string i_unique = "0";
		private string st_empresa = "";
		private string nu_CNPJ = "";
		private string st_fantasia = "";
		private string st_social = "";
		private string st_endereco = "";
		private string st_cidade = "";
		private string st_estado = "";
		private string nu_CEP = "";
		private string nu_telefone = "";
		private string nu_cartoes = "0";
		private string nu_parcelas = "0";
		private string tg_blocked = "";
		private string fk_admin = "0";
		private string nu_contaDeb = "";
		private string vr_mensalidade = "0";
		private string nu_pctValor = "0";
		private string vr_transacao = "0";
		private string vr_minimo = "0";
		private string nu_franquia = "0";
		private string nu_periodoFat = "0";
		private string nu_diaVenc = "0";
		private string tg_tipoCobranca = "";
		private string nu_bancoFat = "0";
		private string vr_cartaoAtivo = "0";
		private string tg_isentoFat = "0";
		private string st_obs = "";
		private string tg_bloq = "0";
		
		public int var_FieldCount = 28;
		
		public T_Empresa ( infra_Patch i_patch )  : base ( i_patch )
		{
			var_Tablename = TB_T_EMPRESA.Alias;
		}
		public string exportNames()
		{
			return "st_empresa,nu_CNPJ,st_fantasia,st_social,st_endereco,st_cidade,st_estado,nu_CEP,nu_telefone,nu_cartoes,nu_parcelas,tg_blocked,fk_admin,nu_contaDeb,vr_mensalidade,nu_pctValor,vr_transacao,vr_minimo,nu_franquia,nu_periodoFat,nu_diaVenc,tg_tipoCobranca,nu_bancoFat,vr_cartaoAtivo,tg_isentoFat,st_obs,tg_bloq";
		}
		
		public string exportCSV()
		{
			return i_unique + str_field_sep + st_empresa + str_field_sep + nu_CNPJ + str_field_sep + st_fantasia + str_field_sep + st_social + str_field_sep + st_endereco + str_field_sep + st_cidade + str_field_sep + st_estado + str_field_sep + nu_CEP + str_field_sep + nu_telefone + str_field_sep + nu_cartoes + str_field_sep + nu_parcelas + str_field_sep + tg_blocked + str_field_sep + fk_admin + str_field_sep + nu_contaDeb + str_field_sep + vr_mensalidade + str_field_sep + nu_pctValor + str_field_sep + vr_transacao + str_field_sep + vr_minimo + str_field_sep + nu_franquia + str_field_sep + nu_periodoFat + str_field_sep + nu_diaVenc + str_field_sep + tg_tipoCobranca + str_field_sep + nu_bancoFat + str_field_sep + vr_cartaoAtivo + str_field_sep + tg_isentoFat + str_field_sep + st_obs + str_field_sep + tg_bloq;
		}
		
		public void Reset()
		{
			i_unique = "0";
			st_empresa = "";
			nu_CNPJ = "";
			st_fantasia = "";
			st_social = "";
			st_endereco = "";
			st_cidade = "";
			st_estado = "";
			nu_CEP = "";
			nu_telefone = "";
			nu_cartoes = "0";
			nu_parcelas = "0";
			tg_blocked = "";
			fk_admin = "0";
			nu_contaDeb = "";
			vr_mensalidade = "0";
			nu_pctValor = "0";
			vr_transacao = "0";
			vr_minimo = "0";
			nu_franquia = "0";
			nu_periodoFat = "0";
			nu_diaVenc = "0";
			tg_tipoCobranca = "";
			nu_bancoFat = "0";
			vr_cartaoAtivo = "0";
			tg_isentoFat = "0";
			st_obs = "";
			tg_bloq = "0";
		}
		
		public void copy ( ref T_Empresa cpy )
		{
			st_empresa = cpy.st_empresa;
			nu_CNPJ = cpy.nu_CNPJ;
			st_fantasia = cpy.st_fantasia;
			st_social = cpy.st_social;
			st_endereco = cpy.st_endereco;
			st_cidade = cpy.st_cidade;
			st_estado = cpy.st_estado;
			nu_CEP = cpy.nu_CEP;
			nu_telefone = cpy.nu_telefone;
			nu_cartoes = cpy.nu_cartoes;
			nu_parcelas = cpy.nu_parcelas;
			tg_blocked = cpy.tg_blocked;
			fk_admin = cpy.fk_admin;
			nu_contaDeb = cpy.nu_contaDeb;
			vr_mensalidade = cpy.vr_mensalidade;
			nu_pctValor = cpy.nu_pctValor;
			vr_transacao = cpy.vr_transacao;
			vr_minimo = cpy.vr_minimo;
			nu_franquia = cpy.nu_franquia;
			nu_periodoFat = cpy.nu_periodoFat;
			nu_diaVenc = cpy.nu_diaVenc;
			tg_tipoCobranca = cpy.tg_tipoCobranca;
			nu_bancoFat = cpy.nu_bancoFat;
			vr_cartaoAtivo = cpy.vr_cartaoAtivo;
			tg_isentoFat = cpy.tg_isentoFat;
			st_obs = cpy.st_obs;
			tg_bloq = cpy.tg_bloq;
		}
		
		public override void fetchRetrieve ( ref DB_Row row )
		{
			i_unique = row.GetField ( TB_T_EMPRESA.i_unique );
			st_empresa = row.GetField ( TB_T_EMPRESA.st_empresa );
			nu_CNPJ = row.GetField ( TB_T_EMPRESA.nu_CNPJ );
			st_fantasia = row.GetField ( TB_T_EMPRESA.st_fantasia );
			st_social = row.GetField ( TB_T_EMPRESA.st_social );
			st_endereco = row.GetField ( TB_T_EMPRESA.st_endereco );
			st_cidade = row.GetField ( TB_T_EMPRESA.st_cidade );
			st_estado = row.GetField ( TB_T_EMPRESA.st_estado );
			nu_CEP = row.GetField ( TB_T_EMPRESA.nu_CEP );
			nu_telefone = row.GetField ( TB_T_EMPRESA.nu_telefone );
			nu_cartoes = row.GetField ( TB_T_EMPRESA.nu_cartoes );
			nu_parcelas = row.GetField ( TB_T_EMPRESA.nu_parcelas );
			tg_blocked = row.GetField ( TB_T_EMPRESA.tg_blocked );
			fk_admin = row.GetField ( TB_T_EMPRESA.fk_admin );
			nu_contaDeb = row.GetField ( TB_T_EMPRESA.nu_contaDeb );
			vr_mensalidade = row.GetField ( TB_T_EMPRESA.vr_mensalidade );
			nu_pctValor = row.GetField ( TB_T_EMPRESA.nu_pctValor );
			vr_transacao = row.GetField ( TB_T_EMPRESA.vr_transacao );
			vr_minimo = row.GetField ( TB_T_EMPRESA.vr_minimo );
			nu_franquia = row.GetField ( TB_T_EMPRESA.nu_franquia );
			nu_periodoFat = row.GetField ( TB_T_EMPRESA.nu_periodoFat );
			nu_diaVenc = row.GetField ( TB_T_EMPRESA.nu_diaVenc );
			tg_tipoCobranca = row.GetField ( TB_T_EMPRESA.tg_tipoCobranca );
			nu_bancoFat = row.GetField ( TB_T_EMPRESA.nu_bancoFat );
			vr_cartaoAtivo = row.GetField ( TB_T_EMPRESA.vr_cartaoAtivo );
			tg_isentoFat = row.GetField ( TB_T_EMPRESA.tg_isentoFat );
			st_obs = row.GetField ( TB_T_EMPRESA.st_obs );
			tg_bloq = row.GetField ( TB_T_EMPRESA.tg_bloq );
		}
		
		public bool synchronize_T_Empresa ( )
		{
			try{
			
			if ( m_hshChangedFields.Count == 0 )
				return true;
			
			StartUpdate();
		
			if ( m_hshChangedFields [ "st_empresa" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.st_empresa , st_empresa , TB_T_EMPRESA.type_st_empresa );
			if ( m_hshChangedFields [ "nu_CNPJ" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.nu_CNPJ , nu_CNPJ , TB_T_EMPRESA.type_nu_CNPJ );
			if ( m_hshChangedFields [ "st_fantasia" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.st_fantasia , st_fantasia , TB_T_EMPRESA.type_st_fantasia );
			if ( m_hshChangedFields [ "st_social" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.st_social , st_social , TB_T_EMPRESA.type_st_social );
			if ( m_hshChangedFields [ "st_endereco" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.st_endereco , st_endereco , TB_T_EMPRESA.type_st_endereco );
			if ( m_hshChangedFields [ "st_cidade" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.st_cidade , st_cidade , TB_T_EMPRESA.type_st_cidade );
			if ( m_hshChangedFields [ "st_estado" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.st_estado , st_estado , TB_T_EMPRESA.type_st_estado );
			if ( m_hshChangedFields [ "nu_CEP" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.nu_CEP , nu_CEP , TB_T_EMPRESA.type_nu_CEP );
			if ( m_hshChangedFields [ "nu_telefone" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.nu_telefone , nu_telefone , TB_T_EMPRESA.type_nu_telefone );
			if ( m_hshChangedFields [ "nu_cartoes" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.nu_cartoes , nu_cartoes , TB_T_EMPRESA.type_nu_cartoes );
			if ( m_hshChangedFields [ "nu_parcelas" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.nu_parcelas , nu_parcelas , TB_T_EMPRESA.type_nu_parcelas );
			if ( m_hshChangedFields [ "tg_blocked" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.tg_blocked , tg_blocked , TB_T_EMPRESA.type_tg_blocked );
			if ( m_hshChangedFields [ "fk_admin" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.fk_admin , fk_admin , TB_T_EMPRESA.type_fk_admin );
			if ( m_hshChangedFields [ "nu_contaDeb" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.nu_contaDeb , nu_contaDeb , TB_T_EMPRESA.type_nu_contaDeb );
			if ( m_hshChangedFields [ "vr_mensalidade" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.vr_mensalidade , vr_mensalidade , TB_T_EMPRESA.type_vr_mensalidade );
			if ( m_hshChangedFields [ "nu_pctValor" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.nu_pctValor , nu_pctValor , TB_T_EMPRESA.type_nu_pctValor );
			if ( m_hshChangedFields [ "vr_transacao" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.vr_transacao , vr_transacao , TB_T_EMPRESA.type_vr_transacao );
			if ( m_hshChangedFields [ "vr_minimo" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.vr_minimo , vr_minimo , TB_T_EMPRESA.type_vr_minimo );
			if ( m_hshChangedFields [ "nu_franquia" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.nu_franquia , nu_franquia , TB_T_EMPRESA.type_nu_franquia );
			if ( m_hshChangedFields [ "nu_periodoFat" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.nu_periodoFat , nu_periodoFat , TB_T_EMPRESA.type_nu_periodoFat );
			if ( m_hshChangedFields [ "nu_diaVenc" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.nu_diaVenc , nu_diaVenc , TB_T_EMPRESA.type_nu_diaVenc );
			if ( m_hshChangedFields [ "tg_tipoCobranca" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.tg_tipoCobranca , tg_tipoCobranca , TB_T_EMPRESA.type_tg_tipoCobranca );
			if ( m_hshChangedFields [ "nu_bancoFat" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.nu_bancoFat , nu_bancoFat , TB_T_EMPRESA.type_nu_bancoFat );
			if ( m_hshChangedFields [ "vr_cartaoAtivo" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.vr_cartaoAtivo , vr_cartaoAtivo , TB_T_EMPRESA.type_vr_cartaoAtivo );
			if ( m_hshChangedFields [ "tg_isentoFat" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.tg_isentoFat , tg_isentoFat , TB_T_EMPRESA.type_tg_isentoFat );
			if ( m_hshChangedFields [ "st_obs" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.st_obs , st_obs , TB_T_EMPRESA.type_st_obs );
			if ( m_hshChangedFields [ "tg_bloq" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_EMPRESA.tg_bloq , tg_bloq , TB_T_EMPRESA.type_tg_bloq );
		
			m_gen_dbStatement.AddWhere ( TB_T_EMPRESA.i_unique, i_unique, TB_T_EMPRESA.type_i_unique );
		
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
		
			return Update();
		}
			
		public string get_identity() { return i_unique; } 
		public string get_st_empresa() { return st_empresa; } 
		public string get_nu_CNPJ() { return nu_CNPJ; } 
		public string get_st_fantasia() { return st_fantasia; } 
		public string get_st_social() { return st_social; } 
		public string get_st_endereco() { return st_endereco; } 
		public string get_st_cidade() { return st_cidade; } 
		public string get_st_estado() { return st_estado; } 
		public string get_nu_CEP() { return nu_CEP; } 
		public string get_nu_telefone() { return nu_telefone; } 
		public string get_nu_cartoes() { return nu_cartoes; } 
		public string get_nu_parcelas() { return nu_parcelas; } 
		public string get_tg_blocked() { return tg_blocked; } 
		public string get_fk_admin() { return fk_admin; } 
		public string get_nu_contaDeb() { return nu_contaDeb; } 
		public string get_vr_mensalidade() { return vr_mensalidade; } 
		public string get_nu_pctValor() { return nu_pctValor; } 
		public string get_vr_transacao() { return vr_transacao; } 
		public string get_vr_minimo() { return vr_minimo; } 
		public string get_nu_franquia() { return nu_franquia; } 
		public string get_nu_periodoFat() { return nu_periodoFat; } 
		public string get_nu_diaVenc() { return nu_diaVenc; } 
		public string get_tg_tipoCobranca() { return tg_tipoCobranca; } 
		public string get_nu_bancoFat() { return nu_bancoFat; } 
		public string get_vr_cartaoAtivo() { return vr_cartaoAtivo; } 
		public string get_tg_isentoFat() { return tg_isentoFat; } 
		public string get_st_obs() { return st_obs; } 
		public string get_tg_bloq() { return tg_bloq; } 
			
		public long get_int_nu_cartoes() { return Convert.ToInt64 ( nu_cartoes ); } 
		public long get_int_nu_parcelas() { return Convert.ToInt64 ( nu_parcelas ); } 
		public long get_int_fk_admin() { return Convert.ToInt64 ( fk_admin ); } 
		public long get_int_vr_mensalidade() { return Convert.ToInt64 ( vr_mensalidade ); } 
		public long get_int_nu_pctValor() { return Convert.ToInt64 ( nu_pctValor ); } 
		public long get_int_vr_transacao() { return Convert.ToInt64 ( vr_transacao ); } 
		public long get_int_vr_minimo() { return Convert.ToInt64 ( vr_minimo ); } 
		public long get_int_nu_franquia() { return Convert.ToInt64 ( nu_franquia ); } 
		public long get_int_nu_periodoFat() { return Convert.ToInt64 ( nu_periodoFat ); } 
		public long get_int_nu_diaVenc() { return Convert.ToInt64 ( nu_diaVenc ); } 
		public long get_int_nu_bancoFat() { return Convert.ToInt64 ( nu_bancoFat ); } 
		public long get_int_vr_cartaoAtivo() { return Convert.ToInt64 ( vr_cartaoAtivo ); } 
		public long get_int_tg_isentoFat() { return Convert.ToInt64 ( tg_isentoFat ); } 
		public long get_int_tg_bloq() { return Convert.ToInt64 ( tg_bloq ); } 
			
		public void set_st_empresa ( string val ) { st_empresa = val; m_hshChangedFields [ "st_empresa" ]="."; } 
		public void set_nu_CNPJ ( string val ) { nu_CNPJ = val; m_hshChangedFields [ "nu_CNPJ" ]="."; } 
		public void set_st_fantasia ( string val ) { st_fantasia = val; m_hshChangedFields [ "st_fantasia" ]="."; } 
		public void set_st_social ( string val ) { st_social = val; m_hshChangedFields [ "st_social" ]="."; } 
		public void set_st_endereco ( string val ) { st_endereco = val; m_hshChangedFields [ "st_endereco" ]="."; } 
		public void set_st_cidade ( string val ) { st_cidade = val; m_hshChangedFields [ "st_cidade" ]="."; } 
		public void set_st_estado ( string val ) { st_estado = val; m_hshChangedFields [ "st_estado" ]="."; } 
		public void set_nu_CEP ( string val ) { nu_CEP = val; m_hshChangedFields [ "nu_CEP" ]="."; } 
		public void set_nu_telefone ( string val ) { nu_telefone = val; m_hshChangedFields [ "nu_telefone" ]="."; } 
		public void set_nu_cartoes ( string val ) { nu_cartoes = val; m_hshChangedFields [ "nu_cartoes" ]="."; } 
		public void set_nu_parcelas ( string val ) { nu_parcelas = val; m_hshChangedFields [ "nu_parcelas" ]="."; } 
		public void set_tg_blocked ( string val ) { tg_blocked = val; m_hshChangedFields [ "tg_blocked" ]="."; } 
		public void set_fk_admin ( string val ) { fk_admin = val; m_hshChangedFields [ "fk_admin" ]="."; } 
		public void set_nu_contaDeb ( string val ) { nu_contaDeb = val; m_hshChangedFields [ "nu_contaDeb" ]="."; } 
		public void set_vr_mensalidade ( string val ) { vr_mensalidade = val; m_hshChangedFields [ "vr_mensalidade" ]="."; } 
		public void set_nu_pctValor ( string val ) { nu_pctValor = val; m_hshChangedFields [ "nu_pctValor" ]="."; } 
		public void set_vr_transacao ( string val ) { vr_transacao = val; m_hshChangedFields [ "vr_transacao" ]="."; } 
		public void set_vr_minimo ( string val ) { vr_minimo = val; m_hshChangedFields [ "vr_minimo" ]="."; } 
		public void set_nu_franquia ( string val ) { nu_franquia = val; m_hshChangedFields [ "nu_franquia" ]="."; } 
		public void set_nu_periodoFat ( string val ) { nu_periodoFat = val; m_hshChangedFields [ "nu_periodoFat" ]="."; } 
		public void set_nu_diaVenc ( string val ) { nu_diaVenc = val; m_hshChangedFields [ "nu_diaVenc" ]="."; } 
		public void set_tg_tipoCobranca ( string val ) { tg_tipoCobranca = val; m_hshChangedFields [ "tg_tipoCobranca" ]="."; } 
		public void set_nu_bancoFat ( string val ) { nu_bancoFat = val; m_hshChangedFields [ "nu_bancoFat" ]="."; } 
		public void set_vr_cartaoAtivo ( string val ) { vr_cartaoAtivo = val; m_hshChangedFields [ "vr_cartaoAtivo" ]="."; } 
		public void set_tg_isentoFat ( string val ) { tg_isentoFat = val; m_hshChangedFields [ "tg_isentoFat" ]="."; } 
		public void set_st_obs ( string val ) { st_obs = val; m_hshChangedFields [ "st_obs" ]="."; } 
		public void set_tg_bloq ( string val ) { tg_bloq = val; m_hshChangedFields [ "tg_bloq" ]="."; } 
		
		public void set_nu_cartoes ( long val ) { nu_cartoes = Convert.ToString(val); m_hshChangedFields [ "nu_cartoes" ]="."; } 
		public void set_nu_parcelas ( long val ) { nu_parcelas = Convert.ToString(val); m_hshChangedFields [ "nu_parcelas" ]="."; } 
		public void set_fk_admin ( long val ) { fk_admin = Convert.ToString(val); m_hshChangedFields [ "fk_admin" ]="."; } 
		public void set_vr_mensalidade ( long val ) { vr_mensalidade = Convert.ToString(val); m_hshChangedFields [ "vr_mensalidade" ]="."; } 
		public void set_nu_pctValor ( long val ) { nu_pctValor = Convert.ToString(val); m_hshChangedFields [ "nu_pctValor" ]="."; } 
		public void set_vr_transacao ( long val ) { vr_transacao = Convert.ToString(val); m_hshChangedFields [ "vr_transacao" ]="."; } 
		public void set_vr_minimo ( long val ) { vr_minimo = Convert.ToString(val); m_hshChangedFields [ "vr_minimo" ]="."; } 
		public void set_nu_franquia ( long val ) { nu_franquia = Convert.ToString(val); m_hshChangedFields [ "nu_franquia" ]="."; } 
		public void set_nu_periodoFat ( long val ) { nu_periodoFat = Convert.ToString(val); m_hshChangedFields [ "nu_periodoFat" ]="."; } 
		public void set_nu_diaVenc ( long val ) { nu_diaVenc = Convert.ToString(val); m_hshChangedFields [ "nu_diaVenc" ]="."; } 
		public void set_nu_bancoFat ( long val ) { nu_bancoFat = Convert.ToString(val); m_hshChangedFields [ "nu_bancoFat" ]="."; } 
		public void set_vr_cartaoAtivo ( long val ) { vr_cartaoAtivo = Convert.ToString(val); m_hshChangedFields [ "vr_cartaoAtivo" ]="."; } 
		public void set_tg_isentoFat ( long val ) { tg_isentoFat = Convert.ToString(val); m_hshChangedFields [ "tg_isentoFat" ]="."; } 
		public void set_tg_bloq ( long val ) { tg_bloq = Convert.ToString(val); m_hshChangedFields [ "tg_bloq" ]="."; } 
			
		public void fieldSelection()
		{
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.i_unique );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.st_empresa );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.nu_CNPJ );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.st_fantasia );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.st_social );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.st_endereco );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.st_cidade );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.st_estado );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.nu_CEP );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.nu_telefone );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.nu_cartoes );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.nu_parcelas );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.tg_blocked );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.fk_admin );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.nu_contaDeb );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.vr_mensalidade );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.nu_pctValor );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.vr_transacao );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.vr_minimo );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.nu_franquia );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.nu_periodoFat );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.nu_diaVenc );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.tg_tipoCobranca );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.nu_bancoFat );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.vr_cartaoAtivo );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.tg_isentoFat );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.st_obs );
			m_gen_dbStatement.AddSelect ( TB_T_EMPRESA.tg_bloq );
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
			
				m_gen_dbStatement.AddWhere ( TB_T_EMPRESA.i_unique, identity, TB_T_EMPRESA.type_i_unique );
			
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
		
		public bool create_T_Empresa ( )
		{
			try{
			string new_id = "";
			
			StartInsert();
			
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.st_empresa, st_empresa, TB_T_EMPRESA.type_st_empresa );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.nu_CNPJ, nu_CNPJ, TB_T_EMPRESA.type_nu_CNPJ );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.st_fantasia, st_fantasia, TB_T_EMPRESA.type_st_fantasia );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.st_social, st_social, TB_T_EMPRESA.type_st_social );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.st_endereco, st_endereco, TB_T_EMPRESA.type_st_endereco );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.st_cidade, st_cidade, TB_T_EMPRESA.type_st_cidade );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.st_estado, st_estado, TB_T_EMPRESA.type_st_estado );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.nu_CEP, nu_CEP, TB_T_EMPRESA.type_nu_CEP );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.nu_telefone, nu_telefone, TB_T_EMPRESA.type_nu_telefone );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.nu_cartoes, nu_cartoes, TB_T_EMPRESA.type_nu_cartoes );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.nu_parcelas, nu_parcelas, TB_T_EMPRESA.type_nu_parcelas );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.tg_blocked, tg_blocked, TB_T_EMPRESA.type_tg_blocked );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.fk_admin, fk_admin, TB_T_EMPRESA.type_fk_admin );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.nu_contaDeb, nu_contaDeb, TB_T_EMPRESA.type_nu_contaDeb );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.vr_mensalidade, vr_mensalidade, TB_T_EMPRESA.type_vr_mensalidade );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.nu_pctValor, nu_pctValor, TB_T_EMPRESA.type_nu_pctValor );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.vr_transacao, vr_transacao, TB_T_EMPRESA.type_vr_transacao );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.vr_minimo, vr_minimo, TB_T_EMPRESA.type_vr_minimo );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.nu_franquia, nu_franquia, TB_T_EMPRESA.type_nu_franquia );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.nu_periodoFat, nu_periodoFat, TB_T_EMPRESA.type_nu_periodoFat );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.nu_diaVenc, nu_diaVenc, TB_T_EMPRESA.type_nu_diaVenc );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.tg_tipoCobranca, tg_tipoCobranca, TB_T_EMPRESA.type_tg_tipoCobranca );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.nu_bancoFat, nu_bancoFat, TB_T_EMPRESA.type_nu_bancoFat );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.vr_cartaoAtivo, vr_cartaoAtivo, TB_T_EMPRESA.type_vr_cartaoAtivo );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.tg_isentoFat, tg_isentoFat, TB_T_EMPRESA.type_tg_isentoFat );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.st_obs, st_obs, TB_T_EMPRESA.type_st_obs );
			m_gen_dbStatement.AddValue ( TB_T_EMPRESA.tg_bloq, tg_bloq, TB_T_EMPRESA.type_tg_bloq );
			
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
				m_gen_dbStatement.AddWhere ( TB_T_EMPRESA.i_unique, i_unique, TB_T_EMPRESA.type_i_unique );
			
			ret = Execute();
			
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
			
			return ret; 
		}
			
		public bool select_fk_admin ( string val_fk_admin )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddWhere ( TB_T_EMPRESA.fk_admin, val_fk_admin , TB_T_EMPRESA.type_fk_admin);
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
			
		public bool select_rows_cnpj ( string val_nu_CNPJ )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddWhere ( TB_T_EMPRESA.nu_CNPJ, val_nu_CNPJ , TB_T_EMPRESA.type_nu_CNPJ);
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
			
		public bool select_rows_empresa ( string val_st_empresa )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddWhere ( TB_T_EMPRESA.st_empresa, val_st_empresa , TB_T_EMPRESA.type_st_empresa);
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
			
		public bool select_rows_fantasia ( string val_st_fantasia )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddLike ( TB_T_EMPRESA.st_fantasia, val_st_fantasia , TB_T_EMPRESA.type_st_fantasia);
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
			
		public bool select_rows_tarifas (  )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
			
				m_gen_dbStatement.AddOrderBy ( TB_T_EMPRESA.st_fantasia );
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
	}
}
