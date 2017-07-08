using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_alteraUsuario : type_base
	{
		public string input_tg_action = "";
		public string input_id_usuario = "";
		
		/// USER [ var_decl ]
		
		string tg_acao = "";
		
		/// USER [ var_decl ] END
		
		public exec_alteraUsuario ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_alteraUsuario";
			constructor();
		}
		
		public exec_alteraUsuario()
		{
			var_Alias = "exec_alteraUsuario";
		
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
			Registry ( "setup exec_alteraUsuario " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_ALTERAUSUARIO.tg_action, ref input_tg_action ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_ALTERAUSUARIO.tg_action missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_ALTERAUSUARIO.id_usuario, ref input_id_usuario ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_ALTERAUSUARIO.id_usuario missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_ALTERAUSUARIO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_ALTERAUSUARIO.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_alteraUsuario " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_alteraUsuario " ); 
		
			/// USER [ authenticate ]
			
			// ## Busca usuário especifico
			
			user.ExclusiveAccess();
			
			if ( !user.selectIdentity ( input_id_usuario ) )
				return false;
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_alteraUsuario " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_alteraUsuario " ); 
		
			/// USER [ execute ]
			
			// ## Executa tipo de ação (informada pelo client)
			
			switch ( input_tg_action )
			{
				case AlteraUsuario.Bloqueio:
				{
					user.set_tg_bloqueio 	( Context.TRUE 	);
					user.set_nu_senhaErrada ( 0 			);
					
					if ( !user.synchronize_T_Usuario() )
						return false;
					
					tg_acao = "Bloq ";
					
					PublishNote ( "Usuário " + user.get_st_nome() + " bloqueado com sucesso" );
					
					break;
				}
					
				case AlteraUsuario.Desbloqueio:
				{
					user.set_tg_bloqueio 	( Context.FALSE );
					user.set_nu_senhaErrada ( 0 			);
					
					if ( !user.synchronize_T_Usuario() )
						return false;
					
					tg_acao = "Desbloq ";
					
					PublishNote ( "Usuário " + user.get_st_nome() + " desbloqueado com sucesso" );
					
					break;
				}
					
				case AlteraUsuario.TrocaSenha:
				{
					user.set_tg_trocaSenha ( Context.TRUE );
					
					if ( !user.synchronize_T_Usuario() )
						return false;
					
					tg_acao = "Senha ";
					
					PublishNote ( "Foi solicitado ao usuário " + user.get_st_nome() + " troca de senha" );
					
					break;
				}
					
				case AlteraUsuario.Remover:
				{
					user.set_tg_bloqueio    ( "2" );
					
					if ( !user.synchronize_T_Usuario() )
						return false;
					
					tg_acao = "Remover ";
					
					PublishNote ( "Usuário " + user.get_st_nome() + " removido com sucesso" );
					
					break;
				}
					
				case AlteraUsuario.ResetSenha:
				{
					user.set_tg_trocaSenha 	( Context.TRUE 	);
					user.set_tg_bloqueio    ( Context.FALSE );
					
					user.set_st_senha 		( var_util.getMd5Hash ( user.get_st_nome() ) 	);
					
					if ( !user.synchronize_T_Usuario() )
						return false;
					
					tg_acao = "ResetSenha ";
					
					PublishNote ( "Usuário " + user.get_st_nome() + " teve sua senha limpa. No próximo login deverá informar seu nome \n no campo senha e será pedido para trocar de senha novamente." );
					
					break;
				}
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_alteraUsuario " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_alteraUsuario " ); 
		
			/// USER [ finish ]
			
			// ## Grava registro de auditoria
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao		( TipoOperacao.AlterOper				);
				aud.set_fk_usuario		( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao 	( GetDataBaseTime() 					);
				aud.set_st_observacao 	( tg_acao + user.get_st_nome() 			);
				aud.set_fk_generic  	( user.get_identity() 					);
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_alteraUsuario " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
