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
	public class DadosComprovGift : DataPortable 
	{
		public const string dt_venda = "dt_venda";
		public const string vr_valor = "vr_valor";
		public const string st_tipo = "st_tipo";
		public const string id_venda = "id_venda";
		
		public DadosComprovGift() { }
		
		public void Clear()
		{
			set_dt_venda ( "" );
			set_vr_valor ( "" );
			set_st_tipo ( "" );
			set_id_venda ( "" );
		}
		
		public DadosComprovGift ( DataPortable port ) 
		{
			Import ( port );
		}
		
		public override void Import ( DataPortable port ) 
		{
			set_dt_venda ( port.getValue ( dt_venda ) );
			set_vr_valor ( port.getValue ( vr_valor ) );
			set_st_tipo ( port.getValue ( st_tipo ) );
			set_id_venda ( port.getValue ( id_venda ) );
		}
		
		public string get_dt_venda () { return getValue ( dt_venda ); }
		public string get_vr_valor () { return getValue ( vr_valor ); }
		public string get_st_tipo () { return getValue ( st_tipo ); }
		public string get_id_venda () { return getValue ( id_venda ); }
		
		public void set_dt_venda ( string val ) { setValue ( dt_venda , val ); }
		public void set_vr_valor ( string val ) { setValue ( vr_valor , val ); }
		public void set_st_tipo ( string val ) { setValue ( st_tipo , val ); }
		public void set_id_venda ( string val ) { setValue ( id_venda , val ); }
	}
}
