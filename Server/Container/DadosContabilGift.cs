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
	public class DadosContabilGift : DataPortable 
	{
		public const string st_item = "st_item";
		public const string nu_valor = "nu_valor";
		
		public DadosContabilGift() { }
		
		public void Clear()
		{
			set_st_item ( "" );
			set_nu_valor ( "" );
		}
		
		public DadosContabilGift ( DataPortable port ) 
		{
			Import ( port );
		}
		
		public override void Import ( DataPortable port ) 
		{
			set_st_item ( port.getValue ( st_item ) );
			set_nu_valor ( port.getValue ( nu_valor ) );
		}
		
		public string get_st_item () { return getValue ( st_item ); }
		public string get_nu_valor () { return getValue ( nu_valor ); }
		
		public void set_st_item ( string val ) { setValue ( st_item , val ); }
		public void set_nu_valor ( string val ) { setValue ( nu_valor , val ); }
	}
}
