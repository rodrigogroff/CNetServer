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
	public class DadosConsultaLoja : DataPortable 
	{
		public const string st_nome = "st_nome";
		public const string st_cidade = "st_cidade";
		public const string st_estado = "st_estado";
		public const string st_ramo = "st_ramo";
		public const string vr_mens_min = "vr_mens_min";
		public const string vr_mens_max = "vr_mens_max";
		public const string nu_qtd_term = "nu_qtd_term";
		public const string st_empresa = "st_empresa";
		public const string st_loja = "st_loja";
		public const string st_cnpj = "st_cnpj";
		public const string st_codigo = "st_codigo";
		
		public DadosConsultaLoja() { }
		
		public void Clear()
		{
			set_st_nome ( "" );
			set_st_cidade ( "" );
			set_st_estado ( "" );
			set_st_ramo ( "" );
			set_vr_mens_min ( "" );
			set_vr_mens_max ( "" );
			set_nu_qtd_term ( "" );
			set_st_empresa ( "" );
			set_st_loja ( "" );
			set_st_cnpj ( "" );
			set_st_codigo ( "" );
		}
		
		public DadosConsultaLoja ( DataPortable port ) 
		{
			Import ( port );
		}
		
		public override void Import ( DataPortable port ) 
		{
			set_st_nome ( port.getValue ( st_nome ) );
			set_st_cidade ( port.getValue ( st_cidade ) );
			set_st_estado ( port.getValue ( st_estado ) );
			set_st_ramo ( port.getValue ( st_ramo ) );
			set_vr_mens_min ( port.getValue ( vr_mens_min ) );
			set_vr_mens_max ( port.getValue ( vr_mens_max ) );
			set_nu_qtd_term ( port.getValue ( nu_qtd_term ) );
			set_st_empresa ( port.getValue ( st_empresa ) );
			set_st_loja ( port.getValue ( st_loja ) );
			set_st_cnpj ( port.getValue ( st_cnpj ) );
			set_st_codigo ( port.getValue ( st_codigo ) );
		}
		
		public string get_st_nome () { return getValue ( st_nome ); }
		public string get_st_cidade () { return getValue ( st_cidade ); }
		public string get_st_estado () { return getValue ( st_estado ); }
		public string get_st_ramo () { return getValue ( st_ramo ); }
		public string get_vr_mens_min () { return getValue ( vr_mens_min ); }
		public string get_vr_mens_max () { return getValue ( vr_mens_max ); }
		public string get_nu_qtd_term () { return getValue ( nu_qtd_term ); }
		public string get_st_empresa () { return getValue ( st_empresa ); }
		public string get_st_loja () { return getValue ( st_loja ); }
		public string get_st_cnpj () { return getValue ( st_cnpj ); }
		public string get_st_codigo () { return getValue ( st_codigo ); }
		
		public void set_st_nome ( string val ) { setValue ( st_nome , val ); }
		public void set_st_cidade ( string val ) { setValue ( st_cidade , val ); }
		public void set_st_estado ( string val ) { setValue ( st_estado , val ); }
		public void set_st_ramo ( string val ) { setValue ( st_ramo , val ); }
		public void set_vr_mens_min ( string val ) { setValue ( vr_mens_min , val ); }
		public void set_vr_mens_max ( string val ) { setValue ( vr_mens_max , val ); }
		public void set_nu_qtd_term ( string val ) { setValue ( nu_qtd_term , val ); }
		public void set_st_empresa ( string val ) { setValue ( st_empresa , val ); }
		public void set_st_loja ( string val ) { setValue ( st_loja , val ); }
		public void set_st_cnpj ( string val ) { setValue ( st_cnpj , val ); }
		public void set_st_codigo ( string val ) { setValue ( st_codigo , val ); }
	}
}
