using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_alteraProprietario : type_base
	{
		public string input_st_cpf_cnpj = "";
		
		public DadosProprietario input_cont_dp = new DadosProprietario();
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_alteraProprietario ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_alteraProprietario";
			constructor();
		}
		
		public exec_alteraProprietario()
		{
			var_Alias = "exec_alteraProprietario";
		
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
			Registry ( "setup exec_alteraProprietario " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_ALTERAPROPRIETARIO.st_cpf_cnpj, ref input_st_cpf_cnpj ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_ALTERAPROPRIETARIO.st_cpf_cnpj missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			DataPortable ct_2 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_ALTERAPROPRIETARIO.dp, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_ALTERAPROPRIETARIO.dp missing! " ); 
				return false;
			}
			if ( var_Comm.GetEntryPortableAtPosition(2).GetMapContainer ( COMM_IN_EXEC_ALTERAPROPRIETARIO.header, ref ct_2 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_ALTERAPROPRIETARIO.header missing! " ); 
				return false;
			}
			
			input_cont_dp.Import ( ct_1 );
			input_cont_header.Import ( ct_2 );
			
			Registry ( "setup done exec_alteraProprietario " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_alteraProprietario " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_alteraProprietario " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_alteraProprietario " ); 
		
			/// USER [ execute ]
			
			T_Proprietario prot = new T_Proprietario (this);
			
			if ( !prot.select_rows_cpf ( input_st_cpf_cnpj ) )
			{
				PublishError ( "" );
				return false;
			}
			
			if ( !prot.fetch() )
				return false;
			
			prot.set_st_nome 		( input_cont_dp.get_st_nome().ToUpper()	 	);
			prot.set_st_endereco 	( input_cont_dp.get_st_endereco() 			);
			prot.set_st_numero 		( input_cont_dp.get_st_numero() 			);
			prot.set_st_complemento ( input_cont_dp.get_st_complemento() 		);
			prot.set_st_bairro 		( input_cont_dp.get_st_bairro() 			);
			prot.set_st_cidade 		( input_cont_dp.get_st_cidade().ToUpper()	);
			prot.set_st_UF 			( input_cont_dp.get_st_UF() 				);
			prot.set_st_cep 		( input_cont_dp.get_st_CEP() 				);
			prot.set_st_ddd 		( input_cont_dp.get_st_ddd() 				);
			prot.set_st_telefone 	( input_cont_dp.get_st_telefone()	 		);
			prot.set_dt_nasc 		( input_cont_dp.get_dt_nasc() 				);
			prot.set_st_email 		( input_cont_dp.get_st_email() 				);
			prot.set_vr_renda 		( input_cont_dp.get_vr_renda() 				);
			
			if ( !prot.synchronize_T_Proprietario() )
				return false;
			
			PublishNote ( "Dados cadastrais alterados com sucesso" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_alteraProprietario " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_alteraProprietario " ); 
		
			/// USER [ finish ]
			
			// ## Grava registro de auditoria
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.AltDadosPropCart  		);
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( "" );
				
				aud.set_fk_generic  ( 0 );
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_alteraProprietario " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
