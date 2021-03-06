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
	public class T_Proprietario : Synchronization
	{
		private string i_unique = "0";
		private string st_cpf = "";
		private string st_nome = "";
		private string st_endereco = "";
		private string st_numero = "";
		private string st_complemento = "";
		private string st_bairro = "";
		private string st_cidade = "";
		private string st_UF = "";
		private string st_cep = "";
		private string st_ddd = "";
		private string st_telefone = "";
		private string dt_nasc = "1900-01-01 00:00:00";
		private string st_email = "";
		private string vr_renda = "0";
		private string st_senhaEdu = "";
		
		public int var_FieldCount = 16;
		
		public T_Proprietario ( infra_Patch i_patch )  : base ( i_patch )
		{
			var_Tablename = TB_T_PROPRIETARIO.Alias;
		}
		public string exportNames()
		{
			return "st_cpf,st_nome,st_endereco,st_numero,st_complemento,st_bairro,st_cidade,st_UF,st_cep,st_ddd,st_telefone,dt_nasc,st_email,vr_renda,st_senhaEdu";
		}
		
		public string exportCSV()
		{
			return i_unique + str_field_sep + st_cpf + str_field_sep + st_nome + str_field_sep + st_endereco + str_field_sep + st_numero + str_field_sep + st_complemento + str_field_sep + st_bairro + str_field_sep + st_cidade + str_field_sep + st_UF + str_field_sep + st_cep + str_field_sep + st_ddd + str_field_sep + st_telefone + str_field_sep + dt_nasc + str_field_sep + st_email + str_field_sep + vr_renda + str_field_sep + st_senhaEdu;
		}
		
		public void Reset()
		{
			i_unique = "0";
			st_cpf = "";
			st_nome = "";
			st_endereco = "";
			st_numero = "";
			st_complemento = "";
			st_bairro = "";
			st_cidade = "";
			st_UF = "";
			st_cep = "";
			st_ddd = "";
			st_telefone = "";
			dt_nasc = "1900-01-01 00:00:00";
			st_email = "";
			vr_renda = "0";
			st_senhaEdu = "";
		}
		
		public void copy ( ref T_Proprietario cpy )
		{
			st_cpf = cpy.st_cpf;
			st_nome = cpy.st_nome;
			st_endereco = cpy.st_endereco;
			st_numero = cpy.st_numero;
			st_complemento = cpy.st_complemento;
			st_bairro = cpy.st_bairro;
			st_cidade = cpy.st_cidade;
			st_UF = cpy.st_UF;
			st_cep = cpy.st_cep;
			st_ddd = cpy.st_ddd;
			st_telefone = cpy.st_telefone;
			dt_nasc = cpy.dt_nasc;
			st_email = cpy.st_email;
			vr_renda = cpy.vr_renda;
			st_senhaEdu = cpy.st_senhaEdu;
		}
		
		public override void fetchRetrieve ( ref DB_Row row )
		{
			i_unique = row.GetField ( TB_T_PROPRIETARIO.i_unique );
			st_cpf = row.GetField ( TB_T_PROPRIETARIO.st_cpf );
			st_nome = row.GetField ( TB_T_PROPRIETARIO.st_nome );
			st_endereco = row.GetField ( TB_T_PROPRIETARIO.st_endereco );
			st_numero = row.GetField ( TB_T_PROPRIETARIO.st_numero );
			st_complemento = row.GetField ( TB_T_PROPRIETARIO.st_complemento );
			st_bairro = row.GetField ( TB_T_PROPRIETARIO.st_bairro );
			st_cidade = row.GetField ( TB_T_PROPRIETARIO.st_cidade );
			st_UF = row.GetField ( TB_T_PROPRIETARIO.st_UF );
			st_cep = row.GetField ( TB_T_PROPRIETARIO.st_cep );
			st_ddd = row.GetField ( TB_T_PROPRIETARIO.st_ddd );
			st_telefone = row.GetField ( TB_T_PROPRIETARIO.st_telefone );
			dt_nasc = ConvertTime ( row.GetField ( TB_T_PROPRIETARIO.dt_nasc ) );
			st_email = row.GetField ( TB_T_PROPRIETARIO.st_email );
			vr_renda = row.GetField ( TB_T_PROPRIETARIO.vr_renda );
			st_senhaEdu = row.GetField ( TB_T_PROPRIETARIO.st_senhaEdu );
		}
		
		public bool synchronize_T_Proprietario ( )
		{
			try{
			
			if ( m_hshChangedFields.Count == 0 )
				return true;
			
			StartUpdate();
		
			if ( m_hshChangedFields [ "st_cpf" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_PROPRIETARIO.st_cpf , st_cpf , TB_T_PROPRIETARIO.type_st_cpf );
			if ( m_hshChangedFields [ "st_nome" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_PROPRIETARIO.st_nome , st_nome , TB_T_PROPRIETARIO.type_st_nome );
			if ( m_hshChangedFields [ "st_endereco" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_PROPRIETARIO.st_endereco , st_endereco , TB_T_PROPRIETARIO.type_st_endereco );
			if ( m_hshChangedFields [ "st_numero" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_PROPRIETARIO.st_numero , st_numero , TB_T_PROPRIETARIO.type_st_numero );
			if ( m_hshChangedFields [ "st_complemento" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_PROPRIETARIO.st_complemento , st_complemento , TB_T_PROPRIETARIO.type_st_complemento );
			if ( m_hshChangedFields [ "st_bairro" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_PROPRIETARIO.st_bairro , st_bairro , TB_T_PROPRIETARIO.type_st_bairro );
			if ( m_hshChangedFields [ "st_cidade" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_PROPRIETARIO.st_cidade , st_cidade , TB_T_PROPRIETARIO.type_st_cidade );
			if ( m_hshChangedFields [ "st_UF" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_PROPRIETARIO.st_UF , st_UF , TB_T_PROPRIETARIO.type_st_UF );
			if ( m_hshChangedFields [ "st_cep" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_PROPRIETARIO.st_cep , st_cep , TB_T_PROPRIETARIO.type_st_cep );
			if ( m_hshChangedFields [ "st_ddd" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_PROPRIETARIO.st_ddd , st_ddd , TB_T_PROPRIETARIO.type_st_ddd );
			if ( m_hshChangedFields [ "st_telefone" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_PROPRIETARIO.st_telefone , st_telefone , TB_T_PROPRIETARIO.type_st_telefone );
			if ( m_hshChangedFields [ "dt_nasc" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_PROPRIETARIO.dt_nasc , dt_nasc , TB_T_PROPRIETARIO.type_dt_nasc );
			if ( m_hshChangedFields [ "st_email" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_PROPRIETARIO.st_email , st_email , TB_T_PROPRIETARIO.type_st_email );
			if ( m_hshChangedFields [ "vr_renda" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_PROPRIETARIO.vr_renda , vr_renda , TB_T_PROPRIETARIO.type_vr_renda );
			if ( m_hshChangedFields [ "st_senhaEdu" ] != null )
				m_gen_dbStatement.AddUpdate ( TB_T_PROPRIETARIO.st_senhaEdu , st_senhaEdu , TB_T_PROPRIETARIO.type_st_senhaEdu );
		
			m_gen_dbStatement.AddWhere ( TB_T_PROPRIETARIO.i_unique, i_unique, TB_T_PROPRIETARIO.type_i_unique );
		
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
		
			return Update();
		}
			
		public string get_identity() { return i_unique; } 
		public string get_st_cpf() { return st_cpf; } 
		public string get_st_nome() { return st_nome; } 
		public string get_st_endereco() { return st_endereco; } 
		public string get_st_numero() { return st_numero; } 
		public string get_st_complemento() { return st_complemento; } 
		public string get_st_bairro() { return st_bairro; } 
		public string get_st_cidade() { return st_cidade; } 
		public string get_st_UF() { return st_UF; } 
		public string get_st_cep() { return st_cep; } 
		public string get_st_ddd() { return st_ddd; } 
		public string get_st_telefone() { return st_telefone; } 
		public string get_dt_nasc() { return dt_nasc; } 
		public string get_st_email() { return st_email; } 
		public string get_vr_renda() { return vr_renda; } 
		public string get_st_senhaEdu() { return st_senhaEdu; } 
			
		public long get_int_vr_renda() { return Convert.ToInt64 ( vr_renda ); } 
			
		public void set_st_cpf ( string val ) { st_cpf = val; m_hshChangedFields [ "st_cpf" ]="."; } 
		public void set_st_nome ( string val ) { st_nome = val; m_hshChangedFields [ "st_nome" ]="."; } 
		public void set_st_endereco ( string val ) { st_endereco = val; m_hshChangedFields [ "st_endereco" ]="."; } 
		public void set_st_numero ( string val ) { st_numero = val; m_hshChangedFields [ "st_numero" ]="."; } 
		public void set_st_complemento ( string val ) { st_complemento = val; m_hshChangedFields [ "st_complemento" ]="."; } 
		public void set_st_bairro ( string val ) { st_bairro = val; m_hshChangedFields [ "st_bairro" ]="."; } 
		public void set_st_cidade ( string val ) { st_cidade = val; m_hshChangedFields [ "st_cidade" ]="."; } 
		public void set_st_UF ( string val ) { st_UF = val; m_hshChangedFields [ "st_UF" ]="."; } 
		public void set_st_cep ( string val ) { st_cep = val; m_hshChangedFields [ "st_cep" ]="."; } 
		public void set_st_ddd ( string val ) { st_ddd = val; m_hshChangedFields [ "st_ddd" ]="."; } 
		public void set_st_telefone ( string val ) { st_telefone = val; m_hshChangedFields [ "st_telefone" ]="."; } 
		public void set_dt_nasc ( string val ) { dt_nasc = val; m_hshChangedFields [ "dt_nasc" ]="."; } 
		public void set_st_email ( string val ) { st_email = val; m_hshChangedFields [ "st_email" ]="."; } 
		public void set_vr_renda ( string val ) { vr_renda = val; m_hshChangedFields [ "vr_renda" ]="."; } 
		public void set_st_senhaEdu ( string val ) { st_senhaEdu = val; m_hshChangedFields [ "st_senhaEdu" ]="."; } 
		
		public void set_vr_renda ( long val ) { vr_renda = Convert.ToString(val); m_hshChangedFields [ "vr_renda" ]="."; } 
			
		public void fieldSelection()
		{
			m_gen_dbStatement.AddSelect ( TB_T_PROPRIETARIO.i_unique );
			m_gen_dbStatement.AddSelect ( TB_T_PROPRIETARIO.st_cpf );
			m_gen_dbStatement.AddSelect ( TB_T_PROPRIETARIO.st_nome );
			m_gen_dbStatement.AddSelect ( TB_T_PROPRIETARIO.st_endereco );
			m_gen_dbStatement.AddSelect ( TB_T_PROPRIETARIO.st_numero );
			m_gen_dbStatement.AddSelect ( TB_T_PROPRIETARIO.st_complemento );
			m_gen_dbStatement.AddSelect ( TB_T_PROPRIETARIO.st_bairro );
			m_gen_dbStatement.AddSelect ( TB_T_PROPRIETARIO.st_cidade );
			m_gen_dbStatement.AddSelect ( TB_T_PROPRIETARIO.st_UF );
			m_gen_dbStatement.AddSelect ( TB_T_PROPRIETARIO.st_cep );
			m_gen_dbStatement.AddSelect ( TB_T_PROPRIETARIO.st_ddd );
			m_gen_dbStatement.AddSelect ( TB_T_PROPRIETARIO.st_telefone );
			m_gen_dbStatement.AddSelect ( TB_T_PROPRIETARIO.dt_nasc );
			m_gen_dbStatement.AddSelect ( TB_T_PROPRIETARIO.st_email );
			m_gen_dbStatement.AddSelect ( TB_T_PROPRIETARIO.vr_renda );
			m_gen_dbStatement.AddSelect ( TB_T_PROPRIETARIO.st_senhaEdu );
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
			
				m_gen_dbStatement.AddWhere ( TB_T_PROPRIETARIO.i_unique, identity, TB_T_PROPRIETARIO.type_i_unique );
			
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
		
		public bool create_T_Proprietario ( )
		{
			try{
			string new_id = "";
			
			StartInsert();
			
			m_gen_dbStatement.AddValue ( TB_T_PROPRIETARIO.st_cpf, st_cpf, TB_T_PROPRIETARIO.type_st_cpf );
			m_gen_dbStatement.AddValue ( TB_T_PROPRIETARIO.st_nome, st_nome, TB_T_PROPRIETARIO.type_st_nome );
			m_gen_dbStatement.AddValue ( TB_T_PROPRIETARIO.st_endereco, st_endereco, TB_T_PROPRIETARIO.type_st_endereco );
			m_gen_dbStatement.AddValue ( TB_T_PROPRIETARIO.st_numero, st_numero, TB_T_PROPRIETARIO.type_st_numero );
			m_gen_dbStatement.AddValue ( TB_T_PROPRIETARIO.st_complemento, st_complemento, TB_T_PROPRIETARIO.type_st_complemento );
			m_gen_dbStatement.AddValue ( TB_T_PROPRIETARIO.st_bairro, st_bairro, TB_T_PROPRIETARIO.type_st_bairro );
			m_gen_dbStatement.AddValue ( TB_T_PROPRIETARIO.st_cidade, st_cidade, TB_T_PROPRIETARIO.type_st_cidade );
			m_gen_dbStatement.AddValue ( TB_T_PROPRIETARIO.st_UF, st_UF, TB_T_PROPRIETARIO.type_st_UF );
			m_gen_dbStatement.AddValue ( TB_T_PROPRIETARIO.st_cep, st_cep, TB_T_PROPRIETARIO.type_st_cep );
			m_gen_dbStatement.AddValue ( TB_T_PROPRIETARIO.st_ddd, st_ddd, TB_T_PROPRIETARIO.type_st_ddd );
			m_gen_dbStatement.AddValue ( TB_T_PROPRIETARIO.st_telefone, st_telefone, TB_T_PROPRIETARIO.type_st_telefone );
			m_gen_dbStatement.AddValue ( TB_T_PROPRIETARIO.dt_nasc, dt_nasc, TB_T_PROPRIETARIO.type_dt_nasc );
			m_gen_dbStatement.AddValue ( TB_T_PROPRIETARIO.st_email, st_email, TB_T_PROPRIETARIO.type_st_email );
			m_gen_dbStatement.AddValue ( TB_T_PROPRIETARIO.vr_renda, vr_renda, TB_T_PROPRIETARIO.type_vr_renda );
			m_gen_dbStatement.AddValue ( TB_T_PROPRIETARIO.st_senhaEdu, st_senhaEdu, TB_T_PROPRIETARIO.type_st_senhaEdu );
			
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
				m_gen_dbStatement.AddWhere ( TB_T_PROPRIETARIO.i_unique, i_unique, TB_T_PROPRIETARIO.type_i_unique );
			
			ret = Execute();
			
			} catch ( System.Exception ex ) {
				StreamWriter wr = new StreamWriter ( 	"CRITICAL_" + var_Tablename + "_" + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) + "_" + DateTime.Now.Hour.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Minute.ToString().PadLeft ( 2, '0' ) + DateTime.Now.Second.ToString().PadLeft ( 2, '0' ) + ".txt" );
				wr.WriteLine ( ex.ToString() );
				wr.Flush();
				wr.Close();
			}
			
			return ret; 
		}
			
		public bool select_rows_nome ( string val_st_nome )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddLike ( TB_T_PROPRIETARIO.st_nome, val_st_nome , TB_T_PROPRIETARIO.type_st_nome);
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
			
		public bool select_rows_cpf ( string val_st_cpf )
		{
			do
			{
				StartSelect();
				fieldSelection();
			
				m_gen_dbStatement.AddWhere ( TB_T_PROPRIETARIO.st_cpf, val_st_cpf , TB_T_PROPRIETARIO.type_st_cpf);
			
				if ( !executeQuery() )
					return false;
			}
			while ( EndSelect() == false ); // row lock
			
			return HasRows();
		}
	}
}
