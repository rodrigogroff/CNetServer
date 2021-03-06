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
	public class Entidade : DataPortable 
	{
		public const string st_nome = "st_nome";
		public const string fk_fatura = "fk_fatura";
		
		public Entidade() { }
		
		public void Clear()
		{
			set_st_nome ( "" );
			set_fk_fatura ( "" );
		}
		
		public Entidade ( DataPortable port ) 
		{
			Import ( port );
		}
		
		public override void Import ( DataPortable port ) 
		{
			set_st_nome ( port.getValue ( st_nome ) );
			set_fk_fatura ( port.getValue ( fk_fatura ) );
		}
		
		public string get_st_nome () { return getValue ( st_nome ); }
		public string get_fk_fatura () { return getValue ( fk_fatura ); }
		
		public void set_st_nome ( string val ) { setValue ( st_nome , val ); }
		public void set_fk_fatura ( string val ) { setValue ( fk_fatura , val ); }
	}
}
