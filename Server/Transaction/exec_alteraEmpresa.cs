using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_alteraEmpresa : type_base
	{
		public DadosEmpresa input_cont_de = new DadosEmpresa();
		
		/// USER [ var_decl ]
		
		T_Empresa emp;
		
		/// USER [ var_decl ] END
		
		public exec_alteraEmpresa ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_alteraEmpresa";
			constructor();
		}
		
		public exec_alteraEmpresa()
		{
			var_Alias = "exec_alteraEmpresa";
		
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
			Registry ( "setup exec_alteraEmpresa " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_EXEC_ALTERAEMPRESA.de, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_ALTERAEMPRESA.de missing! " ); 
				return false;
			}
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_ALTERAEMPRESA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_ALTERAEMPRESA.header missing! " ); 
				return false;
			}
			
			input_cont_de.Import ( ct_0 );
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_alteraEmpresa " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_alteraEmpresa " ); 
		
			/// USER [ authenticate ]
			
			emp = new T_Empresa (this);
			
			// ## Busca empresa especifica via CNPJ
			
			if ( !emp.select_rows_empresa ( input_cont_de.get_st_empresa().PadLeft ( 6, '0' ) ) )
			{
				PublishError ( "Empresa " + input_cont_de.get_st_empresa() + " não existente" );
				return false;
			}
				
			if ( !emp.fetch() )
				return false;
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_alteraEmpresa " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_alteraEmpresa " ); 
		
			/// USER [ execute ]
			
			// ## Atualiza valores
						
			emp.set_nu_CNPJ 		( input_cont_de.get_nu_CNPJ()			);
			emp.set_st_fantasia 	( input_cont_de.get_st_fantasia()		);
			emp.set_st_social 		( input_cont_de.get_st_social()			);
			emp.set_st_endereco 	( input_cont_de.get_st_endereco()		);
			emp.set_st_cidade 		( input_cont_de.get_st_cidade()			);
			emp.set_st_estado 		( input_cont_de.get_st_estado()			);
			emp.set_nu_CEP 			( input_cont_de.get_nu_CEP()			);
			emp.set_nu_telefone 	( input_cont_de.get_nu_telefone() 		);
			emp.set_nu_cartoes 		( input_cont_de.get_nu_cartoes()		);
			emp.set_nu_parcelas 	( input_cont_de.get_nu_parcelas()		);
			emp.set_nu_contaDeb		( input_cont_de.get_nu_contaDeb()		);
			emp.set_vr_mensalidade  ( input_cont_de.get_vr_mensalidade()	);
			emp.set_vr_cartaoAtivo  ( input_cont_de.get_vr_cartaoAtivo()	);
			emp.set_nu_pctValor     ( input_cont_de.get_nu_pctValor()		);
			emp.set_vr_transacao	( input_cont_de.get_vr_transacao()		);
			emp.set_vr_minimo		( input_cont_de.get_vr_minimo() 		);
			emp.set_nu_franquia		( input_cont_de.get_nu_franquia()		);
			emp.set_nu_periodoFat	( input_cont_de.get_nu_periodoFat()		);
			emp.set_nu_diaVenc		( input_cont_de.get_nu_diaVenc()		);
			emp.set_tg_tipoCobranca ( input_cont_de.get_tg_tipoCobranca()	);
			emp.set_nu_bancoFat		( input_cont_de.get_nu_bancoFat()		);
			emp.set_tg_isentoFat	( input_cont_de.get_tg_isento()			);
			
			emp.set_st_obs			( input_cont_de.get_st_obs()			);
			
			// ## Atualiza tabela
			
			if ( !emp.synchronize_T_Empresa () )
				return false;
			
			PublishNote ( "Cadastro atualizado para empresa " + input_cont_de.get_nu_CNPJ() );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_alteraEmpresa " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_alteraEmpresa " ); 
		
			/// USER [ finish ]
			
			// ## Grava registro em auditoria
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao		( TipoOperacao.AlterEmpresa				);
				aud.set_fk_usuario		( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao 	( GetDataBaseTime() 					);
				aud.set_st_observacao 	( emp.get_nu_CNPJ()  					);
				aud.set_fk_generic  	( emp.get_identity() 					);
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_alteraEmpresa " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
