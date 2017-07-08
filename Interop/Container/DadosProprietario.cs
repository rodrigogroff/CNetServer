﻿// ###################################################### 
// ## SyCraf Engine Codegen                          #### 
// ###################################################### 
// ## This file is entirely written by               #### 
// ## the construction bot. DO NOT EDIT THIS FILE.   #### 
// ###################################################### 

using System;
using System.Collections;

namespace SyCrafEngine
{
	public class DadosProprietario : DataPortable 
	{
		public const string st_cpf = "st_cpf";
		public const string st_nome = "st_nome";
		public const string st_endereco = "st_endereco";
		public const string st_numero = "st_numero";
		public const string st_complemento = "st_complemento";
		public const string st_bairro = "st_bairro";
		public const string st_cidade = "st_cidade";
		public const string st_UF = "st_UF";
		public const string st_CEP = "st_CEP";
		public const string st_ddd = "st_ddd";
		public const string st_telefone = "st_telefone";
		public const string dt_nasc = "dt_nasc";
		public const string st_email = "st_email";
		public const string id_profissao = "id_profissao";
		public const string vr_renda = "vr_renda";
		public const string tg_found = "tg_found";
		public const string st_profissao = "st_profissao";
		public const string id_instrucao = "id_instrucao";
		
		public DadosProprietario() { }
		
		public void Clear()
		{
			set_st_cpf ( "" );
			set_st_nome ( "" );
			set_st_endereco ( "" );
			set_st_numero ( "" );
			set_st_complemento ( "" );
			set_st_bairro ( "" );
			set_st_cidade ( "" );
			set_st_UF ( "" );
			set_st_CEP ( "" );
			set_st_ddd ( "" );
			set_st_telefone ( "" );
			set_dt_nasc ( "" );
			set_st_email ( "" );
			set_id_profissao ( "" );
			set_vr_renda ( "" );
			set_tg_found ( "" );
			set_st_profissao ( "" );
			set_id_instrucao ( "" );
		}
		
		public DadosProprietario ( DataPortable port ) 
		{
			Import ( port );
		}
		
		public override void Import ( DataPortable port ) 
		{
			set_st_cpf ( port.getValue ( st_cpf ) );
			set_st_nome ( port.getValue ( st_nome ) );
			set_st_endereco ( port.getValue ( st_endereco ) );
			set_st_numero ( port.getValue ( st_numero ) );
			set_st_complemento ( port.getValue ( st_complemento ) );
			set_st_bairro ( port.getValue ( st_bairro ) );
			set_st_cidade ( port.getValue ( st_cidade ) );
			set_st_UF ( port.getValue ( st_UF ) );
			set_st_CEP ( port.getValue ( st_CEP ) );
			set_st_ddd ( port.getValue ( st_ddd ) );
			set_st_telefone ( port.getValue ( st_telefone ) );
			set_dt_nasc ( port.getValue ( dt_nasc ) );
			set_st_email ( port.getValue ( st_email ) );
			set_id_profissao ( port.getValue ( id_profissao ) );
			set_vr_renda ( port.getValue ( vr_renda ) );
			set_tg_found ( port.getValue ( tg_found ) );
			set_st_profissao ( port.getValue ( st_profissao ) );
			set_id_instrucao ( port.getValue ( id_instrucao ) );
		}
		
		public string get_st_cpf () { return getValue ( st_cpf ); }
		public string get_st_nome () { return getValue ( st_nome ); }
		public string get_st_endereco () { return getValue ( st_endereco ); }
		public string get_st_numero () { return getValue ( st_numero ); }
		public string get_st_complemento () { return getValue ( st_complemento ); }
		public string get_st_bairro () { return getValue ( st_bairro ); }
		public string get_st_cidade () { return getValue ( st_cidade ); }
		public string get_st_UF () { return getValue ( st_UF ); }
		public string get_st_CEP () { return getValue ( st_CEP ); }
		public string get_st_ddd () { return getValue ( st_ddd ); }
		public string get_st_telefone () { return getValue ( st_telefone ); }
		public string get_dt_nasc () { return getValue ( dt_nasc ); }
		public string get_st_email () { return getValue ( st_email ); }
		public string get_id_profissao () { return getValue ( id_profissao ); }
		public string get_vr_renda () { return getValue ( vr_renda ); }
		public string get_tg_found () { return getValue ( tg_found ); }
		public string get_st_profissao () { return getValue ( st_profissao ); }
		public string get_id_instrucao () { return getValue ( id_instrucao ); }
		
		public void set_st_cpf ( string val ) { setValue ( st_cpf , val ); }
		public void set_st_nome ( string val ) { setValue ( st_nome , val ); }
		public void set_st_endereco ( string val ) { setValue ( st_endereco , val ); }
		public void set_st_numero ( string val ) { setValue ( st_numero , val ); }
		public void set_st_complemento ( string val ) { setValue ( st_complemento , val ); }
		public void set_st_bairro ( string val ) { setValue ( st_bairro , val ); }
		public void set_st_cidade ( string val ) { setValue ( st_cidade , val ); }
		public void set_st_UF ( string val ) { setValue ( st_UF , val ); }
		public void set_st_CEP ( string val ) { setValue ( st_CEP , val ); }
		public void set_st_ddd ( string val ) { setValue ( st_ddd , val ); }
		public void set_st_telefone ( string val ) { setValue ( st_telefone , val ); }
		public void set_dt_nasc ( string val ) { setValue ( dt_nasc , val ); }
		public void set_st_email ( string val ) { setValue ( st_email , val ); }
		public void set_id_profissao ( string val ) { setValue ( id_profissao , val ); }
		public void set_vr_renda ( string val ) { setValue ( vr_renda , val ); }
		public void set_tg_found ( string val ) { setValue ( tg_found , val ); }
		public void set_st_profissao ( string val ) { setValue ( st_profissao , val ); }
		public void set_id_instrucao ( string val ) { setValue ( id_instrucao , val ); }
	}
}
