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
	public class Rel_MovEscola : DataPortable 
	{
		public const string st_aluno = "st_aluno";
		public const string vr_valor = "vr_valor";
		public const string st_loja = "st_loja";
		public const string dt_trans = "dt_trans";
		
		public Rel_MovEscola() { }
		
		public void Clear()
		{
			set_st_aluno ( "" );
			set_vr_valor ( "" );
			set_st_loja ( "" );
			set_dt_trans ( "" );
		}
		
		public Rel_MovEscola ( DataPortable port ) 
		{
			Import ( port );
		}
		
		public override void Import ( DataPortable port ) 
		{
			set_st_aluno ( port.getValue ( st_aluno ) );
			set_vr_valor ( port.getValue ( vr_valor ) );
			set_st_loja ( port.getValue ( st_loja ) );
			set_dt_trans ( port.getValue ( dt_trans ) );
		}
		
		public string get_st_aluno () { return getValue ( st_aluno ); }
		public string get_vr_valor () { return getValue ( vr_valor ); }
		public string get_st_loja () { return getValue ( st_loja ); }
		public string get_dt_trans () { return getValue ( dt_trans ); }
		
		public void set_st_aluno ( string val ) { setValue ( st_aluno , val ); }
		public void set_vr_valor ( string val ) { setValue ( vr_valor , val ); }
		public void set_st_loja ( string val ) { setValue ( st_loja , val ); }
		public void set_dt_trans ( string val ) { setValue ( dt_trans , val ); }
	}
}
