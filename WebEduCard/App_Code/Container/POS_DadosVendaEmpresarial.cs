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
	public class POS_DadosVendaEmpresarial : DataPortable 
	{
		public const string vr_valor = "vr_valor";
		public const string nu_parcelas = "nu_parcelas";
		public const string st_via = "st_via";
		public const string st_valores = "st_valores";
		
		public POS_DadosVendaEmpresarial() { }
		
		public void Clear()
		{
			set_vr_valor ( "" );
			set_nu_parcelas ( "" );
			set_st_via ( "" );
			set_st_valores ( "" );
		}
		
		public POS_DadosVendaEmpresarial ( DataPortable port ) 
		{
			Import ( port );
		}
		
		public override void Import ( DataPortable port ) 
		{
			set_vr_valor ( port.getValue ( vr_valor ) );
			set_nu_parcelas ( port.getValue ( nu_parcelas ) );
			set_st_via ( port.getValue ( st_via ) );
			set_st_valores ( port.getValue ( st_valores ) );
		}
		
		public string get_vr_valor () { return getValue ( vr_valor ); }
		public string get_nu_parcelas () { return getValue ( nu_parcelas ); }
		public string get_st_via () { return getValue ( st_via ); }
		public string get_st_valores () { return getValue ( st_valores ); }
		
		public void set_vr_valor ( string val ) { setValue ( vr_valor , val ); }
		public void set_nu_parcelas ( string val ) { setValue ( nu_parcelas , val ); }
		public void set_st_via ( string val ) { setValue ( st_via , val ); }
		public void set_st_valores ( string val ) { setValue ( st_valores , val ); }
	}
}