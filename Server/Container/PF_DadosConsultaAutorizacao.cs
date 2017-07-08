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
	public class PF_DadosConsultaAutorizacao : DataPortable 
	{
		public const string vr_valor = "vr_valor";
		public const string st_nsu = "st_nsu";
		public const string tg_sit = "tg_sit";
		public const string dt_ocorr = "dt_ocorr";
		
		public PF_DadosConsultaAutorizacao() { }
		
		public void Clear()
		{
			set_vr_valor ( "" );
			set_st_nsu ( "" );
			set_tg_sit ( "" );
			set_dt_ocorr ( "" );
		}
		
		public PF_DadosConsultaAutorizacao ( DataPortable port ) 
		{
			Import ( port );
		}
		
		public override void Import ( DataPortable port ) 
		{
			set_vr_valor ( port.getValue ( vr_valor ) );
			set_st_nsu ( port.getValue ( st_nsu ) );
			set_tg_sit ( port.getValue ( tg_sit ) );
			set_dt_ocorr ( port.getValue ( dt_ocorr ) );
		}
		
		public string get_vr_valor () { return getValue ( vr_valor ); }
		public string get_st_nsu () { return getValue ( st_nsu ); }
		public string get_tg_sit () { return getValue ( tg_sit ); }
		public string get_dt_ocorr () { return getValue ( dt_ocorr ); }
		
		public void set_vr_valor ( string val ) { setValue ( vr_valor , val ); }
		public void set_st_nsu ( string val ) { setValue ( st_nsu , val ); }
		public void set_tg_sit ( string val ) { setValue ( tg_sit , val ); }
		public void set_dt_ocorr ( string val ) { setValue ( dt_ocorr , val ); }
	}
}