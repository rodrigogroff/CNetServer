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
	public class T_Loja : Synchronization
	{
		private string i_unique = "0";
		private string nu_CNPJ = "";
		private string st_nome = "";
		private string st_social = "";
		private string st_endereco = "";
		private string st_enderecoInst = "";
		private string nu_inscEst = "";
		private string st_cidade = "";
		private string st_estado = "";
		private string nu_CEP = "";
		private string nu_telefone = "";
		private string nu_fax = "";
		private string st_contato = "";
		private string vr_mensalidade = "0";
		private string nu_contaDeb = "";
		private string st_obs = "";
		private string st_loja = "";
		private string tg_blocked = "";
		private string nu_pctValor = "0";
		private string vr_transacao = "0";
		private string vr_minimo = "0";
		private string nu_franquia = "0";
		private string nu_periodoFat = "0";
		private string nu_diavenc = "0";
		private string tg_tipoCobranca = "";
		private string nu_bancoFat = "0";
		private string tg_isentoFat = "0";
		private string st_senha = "";
		private string tg_cancel = "0";
		
		public int var_FieldCount = 29;
		
		public T_Loja ( infra_Patch i_patch )  : base ( i_patch )
		{
			var_Tablename = TB_T_LOJA.Alias;
		}
		public string exportNames()
		{
			return "nu_CNPJ,st_nome,st_social,st_endereco,st_enderecoInst,nu_inscEst,st_cidade,st_estado,nu_CEP,nu_telefone,nu_fax,st_contato,vr_mensalidade,nu_contaDeb,st_obs,st_loja,tg_blocked,nu_pctValor,vr_transacao,vr_minimo,nu_franquia,nu_periodoFat,nu_diavenc,tg_tipoCobranca,nu_bancoFat,tg_isentoFat,st_senha,tg_cancel";
		}
		
		public string exportCSV()
		{
			return i_unique + str_field_sep + nu_CNPJ + str_field_sep + st_nome + str_field_sep + st_social + str_field_sep + st_endereco + str_field_sep + st_enderecoInst + str_field_sep + nu_inscEst + str_field_sep + st_cidade + str_field_sep + st_estado + str_field_sep + nu_CEP + str_field_sep + nu_telefone + str_field_sep + nu_fax + str_field_sep + st_contato + str_field_sep + vr_mensalidade + str_field_sep + nu_contaDeb + str_field_sep + st_obs + str_field_sep + st_loja + str_field_sep + tg_blocked + str_field_sep + nu_pctValor + str_field_sep + vr_transacao + str_field_sep + vr_minimo + str_field_sep + nu_franquia + str_field_sep + nu_periodoFat + str_field_sep + nu_diavenc + str_field_sep + tg_tipoCobranca + str_field_sep + nu_bancoFat + str_field_sep + tg_isentoFat + str_field_sep + st_senha + str_field_sep + tg_cancel;
		}
		
		public void Reset()
		{
			i_unique = "0";
			nu_CNPJ = "";
			st_nome = "";
			st_social = "";
			st_endereco = "";
			st_enderecoInst = "";
			nu_inscEst = "";
			st_cidade = "";
			st_estado = "";
			nu_CEP = "";
			nu_telefone = "";
			nu_fax = "";
			st_contato = "";
			vr_mensalidade = "0";
			nu_contaDeb = "";
			st_obs = "";
			st_loja = "";
			tg_blocked = "";
			nu_pctValor = "0";
			vr_transacao = "0";
			vr_minimo = "0";
			nu_franquia = "0";
			nu_periodoFat = "0";
			nu_diavenc = "0";
			tg_tipoCobranca = "";
			nu_bancoFat = "0";
			tg_isentoFat = "0";
			st_senha = "";
			tg_cancel = "0";
		}
		
		public void copy ( ref T_Loja cpy )
		{
			nu_CNPJ = cpy.nu_CNPJ;
			st_nome = cpy.st_nome;
			st_social = cpy.st_social;
			st_endereco = cpy.st_endereco;
			st_enderecoInst = cpy.st_enderecoInst;
			nu_inscEst = cpy.nu_inscEst;
			st_cidade = cpy.st_cidade;
			st_estado = cpy.st_estado;
			nu_CEP = cpy.nu_CEP;
			nu_telefone = cpy.nu_telefone;
			nu_fax = cpy.nu_fax;
			st_contato = cpy.st_contato;
			vr_mensalidade = cpy.vr_mensalidade;
			nu_contaDeb = cpy.nu_contaDeb;
			st_obs = cpy.st_obs;
			st_loja = cpy.st_loja;
			tg_blocked = cpy.tg_blocked;
			nu_pctValor = cpy.nu_pctValor;
			vr_transacao = cpy.vr_transacao;
			vr_minimo = cpy.vr_minimo;
			nu_franquia = cpy.nu_franquia;
			nu_periodoFat = cpy.nu_periodoFat;
			nu_diavenc = cpy.nu_diavenc;
			tg_tipoCobranca = cpy.tg_tipoCobranca;
			nu_bancoFat = cpy.nu_bancoFat;
			tg_isentoFat = cpy.tg_isentoFat;
			st_senha = cpy.st_senha;
			tg_cancel = cpy.tg_cancel;
		}
		
		public override void fetchRetrieve ( ref DB_Row row )
		{
			i_unique = row.GetField ( TB_T_LOJA.i_unique );
			nu_CNPJ = row.GetField ( TB_T_LOJA.nu_CNPJ );
			st_nome = row.GetField ( TB_T_LOJA.st_nome );
			st_social = row.GetField ( TB_T_LOJA.st_social );
			st_endereco = row.GetField ( TB_T_LOJA.st_endereco );
			st_enderecoInst = row.GetField ( TB_T_LOJA.st_enderecoInst );
			nu_inscEst = row.GetField ( TB_T_LOJA.nu_inscEst );
			st_cidade = row.GetField ( TB_T_LOJA.st_cidade );
			st_estado = row.GetField ( TB_T_LOJA.st_estado );
			nu_CEP = row.GetField ( TB_T_LOJA.nu_CEP );
			nu_telefone = row.GetField ( TB_T_LOJA.nu_telefone );
			nu_fax = row.GetField ( TB_T_LOJA.nu_fax );
			st_contato = row.GetField ( TB_T_LOJA.st_contato );
			vr_mensalidade = row.GetField ( TB_T_LOJA.vr_mensalidade );
			nu_contaDeb = row.GetField ( TB_T_LOJA.nu_contaDeb );
			st_obs = row.GetField ( TB_T_LOJA.st_obs );
			st_loja = row.GetField ( TB_T_LOJA.st_loja );
			tg_blocked = row.GetField ( TB_T_LOJA.tg_blocked );
			nu_pctValor = row.GetField ( TB_T_LOJA.nu_pctValor );
			vr_transacao = row.GetField ( TB_T_LOJA.vr_transacao );
			vr_minimo = row.GetField ( TB_T_LOJA.vr_minimo );
			nu_franquia = row.GetField ( TB_T_LOJA.nu_franquia );
			nu_periodoFat = row.GetField ( TB_T_LOJA.nu_periodoFat );
			nu_diavenc = row.GetField ( TB_T_LOJA.nu_diavenc );
			tg_tipoCobranca = row.GetField ( TB_T_LOJA.tg_tipoCobranca );
			nu_bancoFat = row.GetField ( TB_T_LOJA.nu_bancoFat );
			tg_isentoFat = row.GetField ( TB_T_LOJA.tg_isentoFat );
			st_senha = row.GetField ( TB_T_LOJA.st_senha );
			tg_cancel = row.GetField ( TB_T_LOJA.tg_cancel );
		}
		
		public bool synchronize_T_Loja ( )
		{
			try{
			
			if ( m_hshChangedFields.Count == 0 )
				return true;
			
			StartUpdate();
		
			if ( m_hshChangedFields [ "nu_CNPJ" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.nu_CNPJ , nu_CNPJ , TB_T_LOJA.type_nu_CNPJ );
			if ( m_hshChangedFields [ "st_nome" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.st_nome , st_nome , TB_T_LOJA.type_st_nome );
			if ( m_hshChangedFields [ "st_social" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.st_social , st_social , TB_T_LOJA.type_st_social );
			if ( m_hshChangedFields [ "st_endereco" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.st_endereco , st_endereco , TB_T_LOJA.type_st_endereco );
			if ( m_hshChangedFields [ "st_enderecoInst" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.st_enderecoInst , st_enderecoInst , TB_T_LOJA.type_st_enderecoInst );
			if ( m_hshChangedFields [ "nu_inscEst" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.nu_inscEst , nu_inscEst , TB_T_LOJA.type_nu_inscEst );
			if ( m_hshChangedFields [ "st_cidade" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.st_cidade , st_cidade , TB_T_LOJA.type_st_cidade );
			if ( m_hshChangedFields [ "st_estado" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.st_estado , st_estado , TB_T_LOJA.type_st_estado );
			if ( m_hshChangedFields [ "nu_CEP" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.nu_CEP , nu_CEP , TB_T_LOJA.type_nu_CEP );
			if ( m_hshChangedFields [ "nu_telefone" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.nu_telefone , nu_telefone , TB_T_LOJA.type_nu_telefone );
			if ( m_hshChangedFields [ "nu_fax" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.nu_fax , nu_fax , TB_T_LOJA.type_nu_fax );
			if ( m_hshChangedFields [ "st_contato" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.st_contato , st_contato , TB_T_LOJA.type_st_contato );
			if ( m_hshChangedFields [ "vr_mensalidade" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.vr_mensalidade , vr_mensalidade , TB_T_LOJA.type_vr_mensalidade );
			if ( m_hshChangedFields [ "nu_contaDeb" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.nu_contaDeb , nu_contaDeb , TB_T_LOJA.type_nu_contaDeb );
			if ( m_hshChangedFields [ "st_obs" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.st_obs , st_obs , TB_T_LOJA.type_st_obs );
			if ( m_hshChangedFields [ "st_loja" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.st_loja , st_loja , TB_T_LOJA.type_st_loja );
			if ( m_hshChangedFields [ "tg_blocked" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.tg_blocked , tg_blocked , TB_T_LOJA.type_tg_blocked );
			if ( m_hshChangedFields [ "nu_pctValor" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.nu_pctValor , nu_pctValor , TB_T_LOJA.type_nu_pctValor );
			if ( m_hshChangedFields [ "vr_transacao" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.vr_transacao , vr_transacao , TB_T_LOJA.type_vr_transacao );
			if ( m_hshChangedFields [ "vr_minimo" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.vr_minimo , vr_minimo , TB_T_LOJA.type_vr_minimo );
			if ( m_hshChangedFields [ "nu_franquia" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.nu_franquia , nu_franquia , TB_T_LOJA.type_nu_franquia );
			if ( m_hshChangedFields [ "nu_periodoFat" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.nu_periodoFat , nu_periodoFat , TB_T_LOJA.type_nu_periodoFat );
			if ( m_hshChangedFields [ "nu_diavenc" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.nu_diavenc , nu_diavenc , TB_T_LOJA.type_nu_diavenc );
			if ( m_hshChangedFields [ "tg_tipoCobranca" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.tg_tipoCobranca , tg_tipoCobranca , TB_T_LOJA.type_tg_tipoCobranca );
			if ( m_hshChangedFields [ "nu_bancoFat" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.nu_bancoFat , nu_bancoFat , TB_T_LOJA.type_nu_bancoFat );
			if ( m_hshChangedFields [ "tg_isentoFat" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.tg_isentoFat , tg_isentoFat , TB_T_LOJA.type_tg_isentoFat );
			if ( m_hshChangedFields [ "st_senha" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.st_senha , st_senha , TB_T_LOJA.type_st_senha );
			if ( m_hshChangedFields [ "tg_cancel" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_LOJA.tg_cancel , tg_cancel , TB_T_LOJA.type_tg_cancel );
		
			m_gen_dbStatement.AddWhere ( TB_T_LOJA.i_unique, i_unique, TB_T_LOJA.type_i_unique );
		
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
		
			return Update();
		}
			
		public string get_identity() { return i_unique; } 
		public string get_nu_CNPJ() { return nu_CNPJ; } 
		public string get_st_nome() { return st_nome; } 
		public string get_st_social() { return st_social; } 
		public string get_st_endereco() { return st_endereco; } 
		public string get_st_enderecoInst() { return st_enderecoInst; } 
		public string get_nu_inscEst() { return nu_inscEst; } 
		public string get_st_cidade() { return st_cidade; } 
		public string get_st_estado() { return st_estado; } 
		public string get_nu_CEP() { return nu_CEP; } 
		public string get_nu_telefone() { return nu_telefone; } 
		public string get_nu_fax() { return nu_fax; } 
		public string get_st_contato() { return st_contato; } 
		public string get_vr_mensalidade() { return vr_mensalidade; } 
		public string get_nu_contaDeb() { return nu_contaDeb; } 
		public string get_st_obs() { return st_obs; } 
		public string get_st_loja() { return st_loja; } 
		public string get_tg_blocked() { return tg_blocked; } 
		public string get_nu_pctValor() { return nu_pctValor; } 
		public string get_vr_transacao() { return vr_transacao; } 
		public string get_vr_minimo() { return vr_minimo; } 
		public string get_nu_franquia() { return nu_franquia; } 
		public string get_nu_periodoFat() { return nu_periodoFat; } 
		public string get_nu_diavenc() { return nu_diavenc; } 
		public string get_tg_tipoCobranca() { return tg_tipoCobranca; } 
		public string get_nu_bancoFat() { return nu_bancoFat; } 
		public string get_tg_isentoFat() { return tg_isentoFat; } 
		public string get_st_senha() { return st_senha; } 
		public string get_tg_cancel() { return tg_cancel; } 
			
		public long get_int_vr_mensalidade() { return Convert.ToInt64 ( vr_mensalidade ); } 
		public long get_int_nu_pctValor() { return Convert.ToInt64 ( nu_pctValor ); } 
		public long get_int_vr_transacao() { return Convert.ToInt64 ( vr_transacao ); } 
		public long get_int_vr_minimo() { return Convert.ToInt64 ( vr_minimo ); } 
		public long get_int_nu_franquia() { return Convert.ToInt64 ( nu_franquia ); } 
		public long get_int_nu_periodoFat() { return Convert.ToInt64 ( nu_periodoFat ); } 
		public long get_int_nu_diavenc() { return Convert.ToInt64 ( nu_diavenc ); } 
		public long get_int_nu_bancoFat() { return Convert.ToInt64 ( nu_bancoFat ); } 
		public long get_int_tg_isentoFat() { return Convert.ToInt64 ( tg_isentoFat ); } 
		public long get_int_tg_cancel() { return Convert.ToInt64 ( tg_cancel ); } 
			
		public void set_nu_CNPJ ( string val ) { nu_CNPJ = val; m_hshChangedFields [ "nu_CNPJ" ]="."; } 
		public void set_st_nome ( string val ) { st_nome = val; m_hshChangedFields [ "st_nome" ]="."; } 
		public void set_st_social ( string val ) { st_social = val; m_hshChangedFields [ "st_social" ]="."; } 
		public void set_st_endereco ( string val ) { st_endereco = val; m_hshChangedFields [ "st_endereco" ]="."; } 
		public void set_st_enderecoInst ( string val ) { st_enderecoInst = val; m_hshChangedFields [ "st_enderecoInst" ]="."; } 
		public void set_nu_inscEst ( string val ) { nu_inscEst = val; m_hshChangedFields [ "nu_inscEst" ]="."; } 
		public void set_st_cidade ( string val ) { st_cidade = val; m_hshChangedFields [ "st_cidade" ]="."; } 
		public void set_st_estado ( string val ) { st_estado = val; m_hshChangedFields [ "st_estado" ]="."; } 
		public void set_nu_CEP ( string val ) { nu_CEP = val; m_hshChangedFields [ "nu_CEP" ]="."; } 
		public void set_nu_telefone ( string val ) { nu_telefone = val; m_hshChangedFields [ "nu_telefone" ]="."; } 
		public void set_nu_fax ( string val ) { nu_fax = val; m_hshChangedFields [ "nu_fax" ]="."; } 
		public void set_st_contato ( string val ) { st_contato = val; m_hshChangedFields [ "st_contato" ]="."; } 
		public void set_vr_mensalidade ( string val ) { vr_mensalidade = val; m_hshChangedFields [ "vr_mensalidade" ]="."; } 
		public void set_nu_contaDeb ( string val ) { nu_contaDeb = val; m_hshChangedFields [ "nu_contaDeb" ]="."; } 
		public void set_st_obs ( string val ) { st_obs = val; m_hshChangedFields [ "st_obs" ]="."; } 
		public void set_st_loja ( string val ) { st_loja = val; m_hshChangedFields [ "st_loja" ]="."; } 
		public void set_tg_blocked ( string val ) { tg_blocked = val; m_hshChangedFields [ "tg_blocked" ]="."; } 
		public void set_nu_pctValor ( string val ) { nu_pctValor = val; m_hshChangedFields [ "nu_pctValor" ]="."; } 
		public void set_vr_transacao ( string val ) { vr_transacao = val; m_hshChangedFields [ "vr_transacao" ]="."; } 
		public void set_vr_minimo ( string val ) { vr_minimo = val; m_hshChangedFields [ "vr_minimo" ]="."; } 
		public void set_nu_franquia ( string val ) { nu_franquia = val; m_hshChangedFields [ "nu_franquia" ]="."; } 
		public void set_nu_periodoFat ( string val ) { nu_periodoFat = val; m_hshChangedFields [ "nu_periodoFat" ]="."; } 
		public void set_nu_diavenc ( string val ) { nu_diavenc = val; m_hshChangedFields [ "nu_diavenc" ]="."; } 
		public void set_tg_tipoCobranca ( string val ) { tg_tipoCobranca = val; m_hshChangedFields [ "tg_tipoCobranca" ]="."; } 
		public void set_nu_bancoFat ( string val ) { nu_bancoFat = val; m_hshChangedFields [ "nu_bancoFat" ]="."; } 
		public void set_tg_isentoFat ( string val ) { tg_isentoFat = val; m_hshChangedFields [ "tg_isentoFat" ]="."; } 
		public void set_st_senha ( string val ) { st_senha = val; m_hshChangedFields [ "st_senha" ]="."; } 
		public void set_tg_cancel ( string val ) { tg_cancel = val; m_hshChangedFields [ "tg_cancel" ]="."; } 
		
		public void set_vr_mensalidade ( long val ) { vr_mensalidade = Convert.ToString(val); m_hshChangedFields [ "vr_mensalidade" ]="."; } 
		public void set_nu_pctValor ( long val ) { nu_pctValor = Convert.ToString(val); m_hshChangedFields [ "nu_pctValor" ]="."; } 
		public void set_vr_transacao ( long val ) { vr_transacao = Convert.ToString(val); m_hshChangedFields [ "vr_transacao" ]="."; } 
		public void set_vr_minimo ( long val ) { vr_minimo = Convert.ToString(val); m_hshChangedFields [ "vr_minimo" ]="."; } 
		public void set_nu_franquia ( long val ) { nu_franquia = Convert.ToString(val); m_hshChangedFields [ "nu_franquia" ]="."; } 
		public void set_nu_periodoFat ( long val ) { nu_periodoFat = Convert.ToString(val); m_hshChangedFields [ "nu_periodoFat" ]="."; } 
		public void set_nu_diavenc ( long val ) { nu_diavenc = Convert.ToString(val); m_hshChangedFields [ "nu_diavenc" ]="."; } 
		public void set_nu_bancoFat ( long val ) { nu_bancoFat = Convert.ToString(val); m_hshChangedFields [ "nu_bancoFat" ]="."; } 
		public void set_tg_isentoFat ( long val ) { tg_isentoFat = Convert.ToString(val); m_hshChangedFields [ "tg_isentoFat" ]="."; } 
		public void set_tg_cancel ( long val ) { tg_cancel = Convert.ToString(val); m_hshChangedFields [ "tg_cancel" ]="."; } 
			
		public void fieldSelection()
		{
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.i_unique );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.nu_CNPJ );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.st_nome );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.st_social );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.st_endereco );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.st_enderecoInst );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.nu_inscEst );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.st_cidade );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.st_estado );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.nu_CEP );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.nu_telefone );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.nu_fax );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.st_contato );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.vr_mensalidade );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.nu_contaDeb );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.st_obs );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.st_loja );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.tg_blocked );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.nu_pctValor );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.vr_transacao );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.vr_minimo );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.nu_franquia );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.nu_periodoFat );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.nu_diavenc );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.tg_tipoCobranca );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.nu_bancoFat );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.tg_isentoFat );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.st_senha );
			m_gen_dbStatement.AddSelect ( TB_T_LOJA.tg_cancel );
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
			
				m_gen_dbStatement.AddWhere ( TB_T_LOJA.i_unique, identity, TB_T_LOJA.type_i_unique );
			
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
		
		public bool create_T_Loja ( )
		{
			try{
			string new_id = "";
			
			StartInsert();
			
			m_gen_dbStatement.AddValue ( TB_T_LOJA.nu_CNPJ, nu_CNPJ, TB_T_LOJA.type_nu_CNPJ );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.st_nome, st_nome, TB_T_LOJA.type_st_nome );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.st_social, st_social, TB_T_LOJA.type_st_social );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.st_endereco, st_endereco, TB_T_LOJA.type_st_endereco );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.st_enderecoInst, st_enderecoInst, TB_T_LOJA.type_st_enderecoInst );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.nu_inscEst, nu_inscEst, TB_T_LOJA.type_nu_inscEst );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.st_cidade, st_cidade, TB_T_LOJA.type_st_cidade );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.st_estado, st_estado, TB_T_LOJA.type_st_estado );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.nu_CEP, nu_CEP, TB_T_LOJA.type_nu_CEP );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.nu_telefone, nu_telefone, TB_T_LOJA.type_nu_telefone );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.nu_fax, nu_fax, TB_T_LOJA.type_nu_fax );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.st_contato, st_contato, TB_T_LOJA.type_st_contato );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.vr_mensalidade, vr_mensalidade, TB_T_LOJA.type_vr_mensalidade );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.nu_contaDeb, nu_contaDeb, TB_T_LOJA.type_nu_contaDeb );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.st_obs, st_obs, TB_T_LOJA.type_st_obs );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.st_loja, st_loja, TB_T_LOJA.type_st_loja );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.tg_blocked, tg_blocked, TB_T_LOJA.type_tg_blocked );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.nu_pctValor, nu_pctValor, TB_T_LOJA.type_nu_pctValor );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.vr_transacao, vr_transacao, TB_T_LOJA.type_vr_transacao );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.vr_minimo, vr_minimo, TB_T_LOJA.type_vr_minimo );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.nu_franquia, nu_franquia, TB_T_LOJA.type_nu_franquia );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.nu_periodoFat, nu_periodoFat, TB_T_LOJA.type_nu_periodoFat );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.nu_diavenc, nu_diavenc, TB_T_LOJA.type_nu_diavenc );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.tg_tipoCobranca, tg_tipoCobranca, TB_T_LOJA.type_tg_tipoCobranca );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.nu_bancoFat, nu_bancoFat, TB_T_LOJA.type_nu_bancoFat );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.tg_isentoFat, tg_isentoFat, TB_T_LOJA.type_tg_isentoFat );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.st_senha, st_senha, TB_T_LOJA.type_st_senha );
			m_gen_dbStatement.AddValue ( TB_T_LOJA.tg_cancel, tg_cancel, TB_T_LOJA.type_tg_cancel );
			
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
				m_gen_dbStatement.AddWhere ( TB_T_LOJA.i_unique, i_unique, TB_T_LOJA.type_i_unique );
			
			ret = Execute();
			
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
			
			return ret; 
		}
			
		public bool select_rows_cnpj ( string val_nu_CNPJ )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddWhere ( TB_T_LOJA.nu_CNPJ, val_nu_CNPJ , TB_T_LOJA.type_nu_CNPJ);
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
			
		public bool select_rows_loja ( string val_st_loja )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddWhere ( TB_T_LOJA.st_loja, val_st_loja , TB_T_LOJA.type_st_loja);
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
			
		public bool select_rows_nome ( string val_st_nome )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddLike ( TB_T_LOJA.st_nome, val_st_nome , TB_T_LOJA.type_st_nome);
			
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
			
			
				m_gen_dbStatement.AddOrderBy ( TB_T_LOJA.st_nome );
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
	}
}
