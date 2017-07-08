using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class ins_loja : type_base
	{
		public string input_st_csv_empresas = "";
		public string input_st_csv_taxas = "";
		public string input_st_csv_dias = "";
		
		public DadosLoja input_cont_dl = new DadosLoja();
		
		/// USER [ var_decl ]
		
		T_Loja loj;
		
		/// USER [ var_decl ] END
		
		public ins_loja ( Transaction trans ) : base (trans)
		{
			var_Alias = "ins_loja";
			constructor();
		}
		
		public ins_loja()
		{
			var_Alias = "ins_loja";
		
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
			Registry ( "setup ins_loja " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_LOJA.st_csv_empresas, ref input_st_csv_empresas ) == false ) 
			{
				Trace ( "# COMM_IN_INS_LOJA.st_csv_empresas missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_LOJA.st_csv_taxas, ref input_st_csv_taxas ) == false ) 
			{
				Trace ( "# COMM_IN_INS_LOJA.st_csv_taxas missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_LOJA.st_csv_dias, ref input_st_csv_dias ) == false ) 
			{
				Trace ( "# COMM_IN_INS_LOJA.st_csv_dias missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			DataPortable ct_2 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_INS_LOJA.dl, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_INS_LOJA.dl missing! " ); 
				return false;
			}
			if ( var_Comm.GetEntryPortableAtPosition(2).GetMapContainer ( COMM_IN_INS_LOJA.header, ref ct_2 ) == false )
			{
				Trace ( "# COMM_IN_INS_LOJA.header missing! " ); 
				return false;
			}
			
			input_cont_dl.Import ( ct_1 );
			input_cont_header.Import ( ct_2 );
			
			Registry ( "setup done ins_loja " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate ins_loja " ); 
		
			/// USER [ authenticate ]
			
			loj = new T_Loja (this);
						
			if ( loj.select_rows_loja ( input_cont_dl.get_st_loja() ) )
			{
				PublishError ( 	"Loja " + 
				              	input_cont_dl.get_st_loja() + 
				              	" previamente cadastrada" );
				return false;
			}
						
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done ins_loja " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute ins_loja " ); 
		
			/// USER [ execute ]
			
			if ( loj.select_rows_loja ( input_cont_dl.get_st_loja() ) )
			{
				PublishError ( "Loja " +input_cont_dl.get_st_loja() + " previamente cadastrada" );
				return false;
			}
			    
			loj.set_st_loja 		( input_cont_dl.get_st_loja() 			);
			loj.set_nu_CNPJ 		( input_cont_dl.get_nu_CNPJ() 			);
			loj.set_st_nome 		( input_cont_dl.get_st_nome() 			);
			loj.set_st_social 		( input_cont_dl.get_st_social() 		);
			loj.set_st_endereco 	( input_cont_dl.get_st_endereco() 		);
			loj.set_st_enderecoInst ( input_cont_dl.get_st_enderecoInst() 	);
			loj.set_nu_inscEst 		( input_cont_dl.get_nu_inscEst() 		);
			
			loj.set_st_cidade 		( input_cont_dl.get_st_cidade() 		);
			loj.set_st_estado 		( input_cont_dl.get_st_estado()  		);
			loj.set_nu_CEP 			( input_cont_dl.get_nu_CEP() 			);
			loj.set_nu_telefone 	( input_cont_dl.get_nu_telefone()  		);
			loj.set_nu_fax 			( input_cont_dl.get_nu_fax() 			);
			loj.set_st_contato 		( input_cont_dl.get_st_contato() 		);
			loj.set_vr_mensalidade 	( input_cont_dl.get_vr_mensalidade() 	);
			loj.set_nu_contaDeb 	( input_cont_dl.get_nu_contaDeb() 		);
			loj.set_st_obs 			( input_cont_dl.get_st_obs() 			);
			loj.set_tg_blocked		( Context.FALSE		 					);
			
			loj.set_vr_mensalidade  ( input_cont_dl.get_vr_mensalidade()	);
			loj.set_nu_pctValor     ( input_cont_dl.get_nu_pctValor()		);
			loj.set_vr_transacao	( input_cont_dl.get_vr_transacao()		);
			loj.set_vr_minimo		( input_cont_dl.get_vr_minimo() 		);
			loj.set_nu_franquia		( input_cont_dl.get_nu_franquia()		);
			loj.set_nu_periodoFat	( input_cont_dl.get_nu_periodoFat()		);
			loj.set_nu_diavenc		( input_cont_dl.get_nu_diavenc()		);
			loj.set_tg_tipoCobranca ( input_cont_dl.get_tg_tipoCobranca()	);
			loj.set_nu_bancoFat		( input_cont_dl.get_nu_bancoFat()		);
			loj.set_tg_isentoFat	( input_cont_dl.get_tg_isento()			);
			loj.set_st_senha        ( input_cont_dl.get_st_senhaWeb() 			);
			
			if ( !loj.create_T_Loja () )
				return false;
			
			LINK_LojaEmpresa 	loj_emp = new LINK_LojaEmpresa 	(this);
			T_Empresa   		emp 	= new T_Empresa 		(this);
			
			ApplicationUtil util_taxa    = new ApplicationUtil();
			ApplicationUtil util_repasse = new ApplicationUtil();
			
			util_taxa.indexCSV    ( input_st_csv_taxas );
			util_repasse.indexCSV ( input_st_csv_dias  );

			for ( int t=0; t < var_util.indexCSV ( input_st_csv_empresas ); ++t )
			{
				string empresa = var_util.getCSV ( t );
				
				if ( !emp.select_rows_empresa ( empresa ) )
					return false;
				
				if ( !emp.fetch() )
					return false;
				
				loj_emp.set_fk_empresa		( emp.get_identity() 		);
				loj_emp.set_fk_loja   	 	( loj.get_identity() 		);
				loj_emp.set_tx_admin   		( util_taxa.getCSV (t) 		);
				loj_emp.set_nu_dias_repasse ( util_repasse.getCSV (t) 	);
				
				if ( !loj_emp.create_LINK_LojaEmpresa () )
					return false;
			}
	
			PublishNote ( 	"Loja " + 
			             	input_cont_dl.get_st_nome()  + 
			             	" ("+ input_cont_dl.get_nu_CNPJ() + 
			             	") cadastrada com sucesso" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done ins_loja " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish ins_loja " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
	
				aud.set_tg_operacao	( TipoOperacao.CadLoja	);
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( loj.get_nu_CNPJ() );
				
				aud.set_fk_generic  ( loj.get_identity() 					);
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done ins_loja " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
