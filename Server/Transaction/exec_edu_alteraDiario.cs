using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_edu_alteraDiario : type_base
	{
		public string input_st_pass = "";
		public string input_vr_diario = "";
		public string input_st_cartao = "";
		
		/// USER [ var_decl ]
		 
		T_Cartao cart;
		 
		/// USER [ var_decl ] END
		
		public exec_edu_alteraDiario ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_edu_alteraDiario";
			constructor();
		}
		
		public exec_edu_alteraDiario()
		{
			var_Alias = "exec_edu_alteraDiario";
		
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
			Registry ( "setup exec_edu_alteraDiario " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_EDU_ALTERADIARIO.st_pass, ref input_st_pass ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_EDU_ALTERADIARIO.st_pass missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_EDU_ALTERADIARIO.vr_diario, ref input_vr_diario ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_EDU_ALTERADIARIO.vr_diario missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_EDU_ALTERADIARIO.st_cartao, ref input_st_cartao ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_EDU_ALTERADIARIO.st_cartao missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_EDU_ALTERADIARIO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_EDU_ALTERADIARIO.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_edu_alteraDiario " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_edu_alteraDiario " ); 
		
			/// USER [ authenticate ]
			
			// ## Confere se a autorização é válida
			
			if ( user.get_st_senha() != input_st_pass )
			{
				PublishError ( "Autorização inválida" );
				return false;
			}
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_edu_alteraDiario " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_edu_alteraDiario " ); 
		
			/// USER [ execute ]
					
			input_st_cartao = input_st_cartao.PadLeft ( 14, '0' );
						
			// ## busca cartão específico
			
			cart = new T_Cartao (this);
			
			cart.ExclusiveAccess();
			
			if ( !cart.select_rows_tudo ( input_st_cartao.Substring (  0,6 ),
			                              input_st_cartao.Substring (  6,6 ),
			                              input_st_cartao.Substring ( 12,2 ) ) )
          	{
				PublishError ( "Cartão inválido" );
				return false;
          	}
			
			if ( !cart.fetch() )
				return false;
			
			// ## Atualiza valor diário para cartão educacional
			
			cart.set_vr_edu_diario ( input_vr_diario );
			
			if ( !cart.synchronize_T_Cartao() )
				return false;
			
			PublishNote ( "Limite diario alterado com sucesso" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_edu_alteraDiario " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_edu_alteraDiario " ); 
		
			/// USER [ finish ]
			
			// ## Cria registro de auditoria
			
			LOG_Audit aud = new LOG_Audit (this);
			
			aud.set_tg_operacao		( TipoOperacao.AlterEduDiario			);
			aud.set_fk_usuario		( input_cont_header.get_st_user_id() 	);
			aud.set_dt_operacao 	( GetDataBaseTime() 					);
			aud.set_fk_generic  	( cart.get_identity() 					);
			aud.set_st_observacao 	( 	cart.get_st_empresa() + 
			                       		cart.get_st_matricula() + 
			                       		cart.get_st_titularidade() 			);
			
			if ( !aud.create_LOG_Audit() )
				return false;
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_edu_alteraDiario " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
