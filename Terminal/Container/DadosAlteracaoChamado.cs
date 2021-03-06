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
	public class DadosAlteracaoChamado : DataPortable 
	{
		public const string dt_alt = "dt_alt";
		public const string st_oper_alt = "st_oper_alt";
		public const string st_desc_alt = "st_desc_alt";
		
		public DadosAlteracaoChamado() { }
		
		public void Clear()
		{
			set_dt_alt ( "" );
			set_st_oper_alt ( "" );
			set_st_desc_alt ( "" );
		}
		
		public DadosAlteracaoChamado ( DataPortable port ) 
		{
			Import ( port );
		}
		
		public override void Import ( DataPortable port ) 
		{
			set_dt_alt ( port.getValue ( dt_alt ) );
			set_st_oper_alt ( port.getValue ( st_oper_alt ) );
			set_st_desc_alt ( port.getValue ( st_desc_alt ) );
		}
		
		public string get_dt_alt () { return getValue ( dt_alt ); }
		public string get_st_oper_alt () { return getValue ( st_oper_alt ); }
		public string get_st_desc_alt () { return getValue ( st_desc_alt ); }
		
		public void set_dt_alt ( string val ) { setValue ( dt_alt , val ); }
		public void set_st_oper_alt ( string val ) { setValue ( st_oper_alt , val ); }
		public void set_st_desc_alt ( string val ) { setValue ( st_desc_alt , val ); }
	}
}
