using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_login : Transaction
	{
		public string input_st_nome = "";
		public string input_st_empresa = "";
		public string input_st_senha = "";
		
		public string output_tg_trocaSenha = "";
		
		public CNetHeader output_cont_header = new CNetHeader();
		
		/// USER [ var_decl ]
		
		T_Usuario  user;
		
		bool loginLojista = false;
		
		/// USER [ var_decl ] END
		
		public exec_login ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_login";
			constructor();
		}
		
		public exec_login()
		{
			var_Alias = "exec_login";
		
			ut_max = 1;
			
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
			Registry ( "setup exec_login " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_LOGIN.st_nome, ref input_st_nome ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_LOGIN.st_nome missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_LOGIN.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_LOGIN.st_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_LOGIN.st_senha, ref input_st_senha ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_LOGIN.st_senha missing! " ); 
				return false;
			}
			
			Registry ( "setup done exec_login " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate exec_login " ); 
		
			/// USER [ authenticate ]
					
			input_st_empresa = input_st_empresa.ToUpper();

			if ( input_st_empresa.IndexOf ( "L" ) >= 0 )
			{
				loginLojista = true;	
			}
			else
			{
				input_st_empresa = input_st_empresa.PadLeft ( 6, '0' );
			}
						
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_login " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute exec_login " ); 
		
			/// USER [ execute ]
			
			output_tg_trocaSenha = Context.FALSE;
			
			user = new T_Usuario (this);
			
			user.ExclusiveAccess();
			
			// ## Busca usuário com nome e cód de empresa
			
			if ( loginLojista )
			{
				string st_loja = input_st_empresa.Replace ( "L", "" );
				
				T_Loja loj = new T_Loja (this);
				
				if ( !loj.select_rows_loja ( st_loja ) )
				{
					PublishError ( "Usuário ou senha incorretos" );
					return false;
				}
				
				if ( !loj.fetch() )
					return false;
				
				T_Terminal term = new T_Terminal (this);
				
				if ( !term.select_fk_loja ( loj.get_identity() ) )
				{
					PublishError ( "Usuário ou senha incorretos" );
					return false;
				}
				
				if ( !term.fetch() )
					return false;
				
				LINK_UsuarioTerminal lut = new LINK_UsuarioTerminal (this);
				
				if ( !lut.select_fk_term ( term.get_identity() ) )
				{
					PublishError ( "Usuário ou senha incorretos" );
					return false;
				}
				
				bool found = false;
				
				T_Usuario usr_lojista = new T_Usuario(this);
				
				while ( lut.fetch() )
				{
					if ( !usr_lojista.selectIdentity ( lut.get_fk_user() ) )
						return false;
					
					Trace ( usr_lojista.get_st_nome() );
					
					if ( usr_lojista.get_st_nome() == input_st_nome )
					{
						found = true;
						break;
					}
				}
				
				if ( !found )
				{
					PublishError ( "Usuário ou senha incorretos" );
					return false;
				}
				
				if ( !user.selectIdentity ( usr_lojista.get_identity() ) )
					return false;
				
				input_st_empresa = st_loja;
				
				output_cont_header.set_nu_terminal 	( term.get_nu_terminal() 	);
			}
			else
			{
				if ( !user.select_rows_login ( input_st_nome, input_st_empresa ) )
				{
					PublishError ( "Usuário ou senha incorretos" );
					return false;
				}
				
				if ( !user.fetch() )
					return false;
			}
			
			// ## Confere bloqueio
			
			if ( user.get_tg_bloqueio() != Context.FALSE )
			{
				PublishError ( "Usuário ou senha incorretos" );
				return false;
			}
					
			// ## Confere senha
			
			if ( user.get_st_senha() != input_st_senha )
			{
				user.set_nu_senhaErrada ( Convert.ToString ( user.get_int_nu_senhaErrada() + 1 ) );
				
				if ( user.get_int_nu_senhaErrada() >= 3 )
				{
					// ## Na terceira senha errada, bloqueia cartão
					
					//user.set_tg_bloqueio 		( Context.TRUE 	);
					//user.set_nu_senhaErrada 	(  0  			);
				}
				
				// ## Atualiza
				
				if ( !user.synchronize_T_Usuario() )
					return false;
				
				PublishError ( "Usuário ou senha incorretos" );
				return false;
			}			
			else
			{
				// ## Zera senhas erradas
				
				ut_coverMark ( 1 );
				
				user.set_nu_senhaErrada ( 0 );
			}
			
			// ## Caso o ultimo logoff não foi executado, ou seja, 
			// ## o usuário não fechou corretamente sua última instância
			
			if ( user.get_tg_logoff() == Context.FALSE )
			{
				// ## Mais de cinco minutos se passaram...
				
				if ( TimeSpanCtrl ( user.get_dt_ultUso(), 
				                    TSpan_Mode.MORE_THAN, 
				                    5, 
				                    TSpan_Range.Minutes ) ==  true )
				{
					PublishNote ( "Disconectando sessão ociosa por mais de cinco minutos" );
				}
				else
				{
					PublishError ( "Não são permitidas multiplas sessões" );
					return false;
				}
			}
			
			// ## Seto que o logoff precisa ser feito
			
			user.set_tg_logoff ( Context.FALSE );
			
			// ## Confere se senha expirou...
			
			if ( TimeSpanCtrl ( user.get_dt_trocaSenha(),
				 				TSpan_Mode.MORE_THAN, 
				                60, 
				                TSpan_Range.Days ) ==  true )
			{
				output_tg_trocaSenha = Context.TRUE;
				
				PublishNote ( "É necessário trocar sua senha" );
			}
			
			// ## Confere se admin requisitou troca de senha
			
			if ( user.get_tg_trocaSenha() == Context.TRUE )
			{
				output_tg_trocaSenha = Context.TRUE;
				
				PublishNote ( "É necessário trocar sua senha" );
			}
			
			// ## Seto login feito agora
			
			user.set_dt_ultUso ( GetDataBaseTime() );
			
			// ## Atualizo usuário
			
			if ( !user.synchronize_T_Usuario() )
				return false;
			
			output_cont_header.set_st_session 	( var_SessionKey		);
			output_cont_header.set_st_empresa 	( input_st_empresa		);
			output_cont_header.set_st_user_id 	( user.get_identity()	);
			output_cont_header.set_tg_user_type ( user.get_tg_nivel()	);
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_login " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish exec_login " ); 
		
			/// USER [ finish ]
			
			// ## Criar registro de auditoria
			
			LOG_Audit aud = new LOG_Audit (this);
			
			aud.set_tg_operacao	( TipoOperacao.Login 	);
			aud.set_fk_usuario	( user.get_identity() 	);
			aud.set_dt_operacao ( GetDataBaseTime() 	);
			aud.set_fk_generic  ( user.get_identity()	);
			
			if ( !aud.create_LOG_Audit() )
				return false;
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_login " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_EXEC_LOGIN.tg_trocaSenha, output_tg_trocaSenha ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			DataPortable dp_cont_1 = new DataPortable();
		
			dp_cont_1.MapTagContainer ( COMM_OUT_EXEC_LOGIN.header , output_cont_header as DataPortable );
		
			var_Comm.AddExitPortable ( ref dp_cont_1 ); 
		
			return true;
		}
	}
}
