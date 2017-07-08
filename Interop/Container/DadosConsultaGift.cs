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
	public class DadosConsultaGift : DataPortable 
	{
		public const string st_nome = "st_nome";
		public const string vr_valor = "vr_valor";
		public const string dt_data = "dt_data";
		
		public DadosConsultaGift() { }
		
		public void Clear()
		{
			set_st_nome ( "" );
			set_vr_valor ( "" );
			set_dt_data ( "" );
		}
		
		public DadosConsultaGift ( DataPortable port ) 
		{
			Import ( port );
		}
		
		public override void Import ( DataPortable port ) 
		{
			set_st_nome ( port.getValue ( st_nome ) );
			set_vr_valor ( port.getValue ( vr_valor ) );
			set_dt_data ( port.getValue ( dt_data ) );
		}
		
		public string get_st_nome () { return getValue ( st_nome ); }
		public string get_vr_valor () { return getValue ( vr_valor ); }
		public string get_dt_data () { return getValue ( dt_data ); }
		
		public void set_st_nome ( string val ) { setValue ( st_nome , val ); }
		public void set_vr_valor ( string val ) { setValue ( vr_valor , val ); }
		public void set_dt_data ( string val ) { setValue ( dt_data , val ); }
	}
}