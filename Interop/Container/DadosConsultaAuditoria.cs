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
	public class DadosConsultaAuditoria : DataPortable 
	{
		public const string dt_ini = "dt_ini";
		public const string dt_fim = "dt_fim";
		public const string st_user = "st_user";
		public const string st_obs = "st_obs";
		public const string nu_oper = "nu_oper";
		
		public DadosConsultaAuditoria() { }
		
		public void Clear()
		{
			set_dt_ini ( "" );
			set_dt_fim ( "" );
			set_st_user ( "" );
			set_st_obs ( "" );
			set_nu_oper ( "" );
		}
		
		public DadosConsultaAuditoria ( DataPortable port ) 
		{
			Import ( port );
		}
		
		public override void Import ( DataPortable port ) 
		{
			set_dt_ini ( port.getValue ( dt_ini ) );
			set_dt_fim ( port.getValue ( dt_fim ) );
			set_st_user ( port.getValue ( st_user ) );
			set_st_obs ( port.getValue ( st_obs ) );
			set_nu_oper ( port.getValue ( nu_oper ) );
		}
		
		public string get_dt_ini () { return getValue ( dt_ini ); }
		public string get_dt_fim () { return getValue ( dt_fim ); }
		public string get_st_user () { return getValue ( st_user ); }
		public string get_st_obs () { return getValue ( st_obs ); }
		public string get_nu_oper () { return getValue ( nu_oper ); }
		
		public void set_dt_ini ( string val ) { setValue ( dt_ini , val ); }
		public void set_dt_fim ( string val ) { setValue ( dt_fim , val ); }
		public void set_st_user ( string val ) { setValue ( st_user , val ); }
		public void set_st_obs ( string val ) { setValue ( st_obs , val ); }
		public void set_nu_oper ( string val ) { setValue ( nu_oper , val ); }
	}
}
