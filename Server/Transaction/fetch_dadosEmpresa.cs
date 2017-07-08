using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_dadosEmpresa : type_base
	{
		public string input_st_empresa = "";
		
		public DadosEmpresa output_cont_de = new DadosEmpresa();
		
		/// USER [ var_decl ]
		
		T_Empresa emp;
			
		/// USER [ var_decl ] END
		
		public fetch_dadosEmpresa ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_dadosEmpresa";
			constructor();
		}
		
		public fetch_dadosEmpresa()
		{
			var_Alias = "fetch_dadosEmpresa";
		
			ut_max = 0;
			
			constructor();
		}
		
		public override void constructor()
		{
			/// USER [ constructor ]
			/// USER [ constructor ] END
		}
		
		public override bool setup ( ) 
		{
			#region - SETUP TRANSACTION -
			Registry ( "setup fetch_dadosEmpresa " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_DADOSEMPRESA.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_DADOSEMPRESA.st_empresa missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_DADOSEMPRESA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_DADOSEMPRESA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_dadosEmpresa " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_dadosEmpresa " ); 
		
			/// USER [ authenticate ]
			
			input_st_empresa = input_st_empresa.PadLeft ( 6, '0' );
			
			emp = new T_Empresa (this);
			
			// ## Buscar empresa pelo código ou cnpj
			
			if ( !emp.select_rows_empresa ( input_st_empresa ) )
			{
				PublishError ( "Empresa de código " + input_st_empresa + " não existente" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;				
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_dadosEmpresa " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_dadosEmpresa " ); 
		
			/// USER [ execute ]
			
			// ## Copiar para memória
			
			output_cont_de.set_st_empresa 		( emp.get_st_empresa() 		);
			output_cont_de.set_nu_CNPJ 			( emp.get_nu_CNPJ() 		);
			output_cont_de.set_st_fantasia 		( emp.get_st_fantasia()	 	);
			output_cont_de.set_st_social 		( emp.get_st_social() 		);
			output_cont_de.set_st_endereco 		( emp.get_st_endereco() 	);
			output_cont_de.set_st_cidade 		( emp.get_st_cidade()		);
			output_cont_de.set_st_estado 		( emp.get_st_estado() 		);
			output_cont_de.set_nu_CEP 			( emp.get_nu_CEP() 			);
			output_cont_de.set_nu_telefone 		( emp.get_nu_telefone() 	);
			output_cont_de.set_nu_cartoes 		( emp.get_nu_cartoes() 		);
			output_cont_de.set_nu_parcelas 		( emp.get_nu_parcelas() 	);
			output_cont_de.set_nu_contaDeb		( emp.get_nu_contaDeb() 	);
			output_cont_de.set_vr_mensalidade	( emp.get_vr_mensalidade()	);
			output_cont_de.set_vr_cartaoAtivo	( emp.get_vr_cartaoAtivo()	);
			output_cont_de.set_nu_pctValor		( emp.get_nu_pctValor()		);
			output_cont_de.set_vr_transacao		( emp.get_vr_transacao()	);
			output_cont_de.set_vr_minimo		( emp.get_vr_minimo()		);
			output_cont_de.set_nu_franquia		( emp.get_nu_franquia()		);
			output_cont_de.set_nu_diaVenc		( emp.get_nu_diaVenc()		);
			output_cont_de.set_nu_bancoFat		( emp.get_nu_bancoFat()		);			
			output_cont_de.set_tg_tipoCobranca	( emp.get_tg_tipoCobranca()	);
			output_cont_de.set_nu_periodoFat	( emp.get_nu_periodoFat()	);		
			output_cont_de.set_tg_bloq			( emp.get_tg_bloq()			);
			
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_dadosEmpresa " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_dadosEmpresa " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_dadosEmpresa " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_cont_1 = new DataPortable();
		
			dp_cont_1.MapTagContainer ( COMM_OUT_FETCH_DADOSEMPRESA.de , output_cont_de as DataPortable );
		
			var_Comm.AddExitPortable ( ref dp_cont_1 ); 
		
			return true;
		}
	}
}
