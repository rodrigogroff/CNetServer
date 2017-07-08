using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_dadosLoja : type_base
	{
		public string input_st_cnpj = "";
		public string input_st_cod = "";
		
		public DadosLoja output_cont_dl = new DadosLoja();
		
		/// USER [ var_decl ]
		
		T_Loja loj;
		
		/// USER [ var_decl ] END
		
		public fetch_dadosLoja ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_dadosLoja";
			constructor();
		}
		
		public fetch_dadosLoja()
		{
			var_Alias = "fetch_dadosLoja";
		
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
			Registry ( "setup fetch_dadosLoja " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_DADOSLOJA.st_cnpj, ref input_st_cnpj ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_DADOSLOJA.st_cnpj missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_DADOSLOJA.st_cod, ref input_st_cod ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_DADOSLOJA.st_cod missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_DADOSLOJA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_DADOSLOJA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_dadosLoja " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_dadosLoja " ); 
		
			/// USER [ authenticate ]
			
			// ## Busca loja pelo CNPJ
			
			loj = new T_Loja ( this ); 
			
			if ( input_st_cod == "" )
			{
				if ( !loj.select_rows_cnpj ( input_st_cnpj.PadLeft ( 6, '0' ) ) )
				{
					PublishError ( "Loja de CNPJ " + input_st_cnpj + " inexistente" );
					return false;
				}
			}
			else
			{
				if ( !loj.select_rows_loja ( input_st_cod ) )
				{
					PublishError ( "Loja de código " + input_st_cod + " inexistente" );
					return false;
				}
			}
			
			if ( !loj.fetch() )
				return false;
							
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_dadosLoja " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_dadosLoja " ); 
		
			/// USER [ execute ]
			
			// ## Copia para saida
			
			output_cont_dl.set_st_loja 			( loj.get_st_loja() 		);
			output_cont_dl.set_nu_CNPJ 			( loj.get_nu_CNPJ() 		);
			output_cont_dl.set_st_nome 			( loj.get_st_nome() 		);
			output_cont_dl.set_st_social 		( loj.get_st_social() 		);
			output_cont_dl.set_st_endereco 		( loj.get_st_endereco() 	);
			output_cont_dl.set_st_enderecoInst 	( loj.get_st_enderecoInst() );
			output_cont_dl.set_nu_inscEst 		( loj.get_nu_inscEst() 		);
			
			output_cont_dl.set_st_cidade 		( loj.get_st_cidade()		);
			output_cont_dl.set_st_estado 		( loj.get_st_estado() 		);
			output_cont_dl.set_nu_CEP 			( loj.get_nu_CEP() 			);
			output_cont_dl.set_nu_telefone 		( loj.get_nu_telefone() 	);
			output_cont_dl.set_nu_fax 			( loj.get_nu_fax() 			);
			output_cont_dl.set_st_contato 		( loj.get_st_contato() 		);
			output_cont_dl.set_vr_mensalidade 	( loj.get_vr_mensalidade() 	);
			output_cont_dl.set_nu_contaDeb 		( loj.get_nu_contaDeb() 	);
			output_cont_dl.set_st_obs 			( loj.get_st_obs() 			);			
			
			output_cont_dl.set_nu_pctValor		( loj.get_nu_pctValor()		);
			output_cont_dl.set_vr_transacao		( loj.get_vr_transacao()	);
			output_cont_dl.set_vr_minimo		( loj.get_vr_minimo()		);
			output_cont_dl.set_nu_franquia		( loj.get_nu_franquia()		);
			output_cont_dl.set_nu_periodoFat	( loj.get_nu_periodoFat()	);
			output_cont_dl.set_nu_diavenc		( loj.get_nu_diavenc()		);
			output_cont_dl.set_nu_bancoFat		( loj.get_nu_bancoFat()		);
			output_cont_dl.set_tg_tipoCobranca	( loj.get_tg_tipoCobranca()	);
			output_cont_dl.set_tg_blocked 		( loj.get_tg_blocked()		);
			output_cont_dl.set_tg_cancel 		( loj.get_tg_cancel()		);
			output_cont_dl.set_tg_isento        ( loj.get_tg_isentoFat()	);
			output_cont_dl.set_st_senhaWeb      ( loj.get_st_senha() 		);
			
			LINK_LojaEmpresa loj_emp = new LINK_LojaEmpresa (this);
			T_Empresa emp = new T_Empresa (this);
			
			string convs = "";
			
			if ( loj_emp.select_fk_loja ( loj.get_identity() ) )
		    {
				while ( loj_emp.fetch() )
				{
					emp.selectIdentity ( loj_emp.get_fk_empresa() );
					
					convs += emp.get_st_empresa().TrimStart ( '0' ) + ",";
				}
		    }
			
			output_cont_dl.set_st_convenios ( convs.TrimEnd ( ',' ) );
						
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_dadosLoja " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_dadosLoja " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_dadosLoja " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_cont_1 = new DataPortable();
		
			dp_cont_1.MapTagContainer ( COMM_OUT_FETCH_DADOSLOJA.dl , output_cont_dl as DataPortable );
		
			var_Comm.AddExitPortable ( ref dp_cont_1 ); 
		
			return true;
		}
	}
}
