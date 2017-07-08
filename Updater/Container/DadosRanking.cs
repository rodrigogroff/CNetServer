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
	public class DadosRanking : DataPortable 
	{
		public const string st_pos = "st_pos";
		public const string st_nome = "st_nome";
		public const string vr_valor = "vr_valor";
		
		public DadosRanking() { }
		
		public void Clear()
		{
			set_st_pos ( "" );
			set_st_nome ( "" );
			set_vr_valor ( "" );
		}
		
		public DadosRanking ( DataPortable port ) 
		{
			Import ( port );
		}
		
		public override void Import ( DataPortable port ) 
		{
			set_st_pos ( port.getValue ( st_pos ) );
			set_st_nome ( port.getValue ( st_nome ) );
			set_vr_valor ( port.getValue ( vr_valor ) );
		}
		
		public string get_st_pos () { return getValue ( st_pos ); }
		public string get_st_nome () { return getValue ( st_nome ); }
		public string get_vr_valor () { return getValue ( vr_valor ); }
		
		public void set_st_pos ( string val ) { setValue ( st_pos , val ); }
		public void set_st_nome ( string val ) { setValue ( st_nome , val ); }
		public void set_vr_valor ( string val ) { setValue ( vr_valor , val ); }
	}
}
