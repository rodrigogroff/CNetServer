using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class ins_usuario : type_base
	{
		public string input_st_nome = "";
		public string input_st_senha = "";
		public string input_tg_trocaSenha = "";
		public string input_st_nivel = "";
		public string input_st_empresa = "";
		
		/// USER [ var_decl ]
		
		T_Usuario nvo_user;
		
		/// USER [ var_decl ] END
		
		public ins_usuario ( Transaction trans ) : base (trans)
		{
			var_Alias = "ins_usuario";
			constructor();
		}
		
		public ins_usuario()
		{
			var_Alias = "ins_usuario";
		
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
			Registry ( "setup ins_usuario " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_USUARIO.st_nome, ref input_st_nome ) == false ) 
			{
				Trace ( "# COMM_IN_INS_USUARIO.st_nome missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_USUARIO.st_senha, ref input_st_senha ) == false ) 
			{
				Trace ( "# COMM_IN_INS_USUARIO.st_senha missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_USUARIO.tg_trocaSenha, ref input_tg_trocaSenha ) == false ) 
			{
				Trace ( "# COMM_IN_INS_USUARIO.tg_trocaSenha missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_USUARIO.st_nivel, ref input_st_nivel ) == false ) 
			{
				Trace ( "# COMM_IN_INS_USUARIO.st_nivel missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_USUARIO.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_INS_USUARIO.st_empresa missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_INS_USUARIO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_INS_USUARIO.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done ins_usuario " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate ins_usuario " ); 
		
			/// USER [ authenticate ]
			
			T_Empresa emp = new T_Empresa (this);
			nvo_user      = new T_Usuario ( this );
			
			input_st_empresa = input_st_empresa.PadLeft ( 6, '0' );
			
			if ( input_st_nivel != TipoUsuario.SuperUser && 
			     input_st_nivel != TipoUsuario.OperadorConvey && 
			     input_st_nivel != TipoUsuario.OperadorCont && 
			     input_st_nivel != TipoUsuario.Lojista 			)
			{
				if ( !emp.select_rows_empresa ( input_st_empresa ) )
				{
					PublishError ( "Empresa " + input_st_empresa + " inexistente" );
					return false;
				}
			}
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done ins_usuario " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute ins_usuario " ); 
		
			/// USER [ execute ]
			
			nvo_user.set_st_nome 		( input_st_nome 		);
			nvo_user.set_st_senha 		( input_st_senha 		);
			nvo_user.set_st_empresa 	( input_st_empresa		);
			nvo_user.set_tg_nivel		( input_st_nivel 		);
			nvo_user.set_tg_trocaSenha	( input_tg_trocaSenha	);
			
			nvo_user.set_dt_trocaSenha 	( GetDataBaseTime() 	);
			nvo_user.set_dt_ultUso     	( GetDataBaseTime() 	);
			nvo_user.set_nu_senhaErrada ( 0 					);
			nvo_user.set_st_senha_1 	( Context.NOT_SET 		);
			nvo_user.set_st_senha_2 	( Context.NOT_SET 		);
			nvo_user.set_st_senha_3 	( Context.NOT_SET 		);
			nvo_user.set_st_senha_4 	( Context.NOT_SET 		);
			nvo_user.set_st_senha_5 	( Context.NOT_SET 		);
			nvo_user.set_tg_bloqueio	( Context.FALSE			);
			nvo_user.set_tg_logoff		( Context.TRUE			);
			
			if ( !nvo_user.create_T_Usuario() )
				return false;
			
			PublishNote ( "Usuário "+ input_st_nome + " criado com sucesso" );
				
			/// USER [ execute ] END
		
			Registry ( "execute done ins_usuario " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish ins_usuario " ); 
		
			/// USER [ finish ]

			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.CadNovoOper 				);
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( nvo_user.get_st_nome() );
				
				aud.set_fk_generic  ( nvo_user.get_identity() 				);
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done ins_usuario " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
