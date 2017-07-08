using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_alteraChamado : type_base
	{
		public string input_id_chamado = "";
		public string input_st_new_desc = "";
		public string input_tg_fechado = "";
		public string input_st_operador = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_alteraChamado ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_alteraChamado";
			constructor();
		}
		
		public exec_alteraChamado()
		{
			var_Alias = "exec_alteraChamado";
		
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
			Registry ( "setup exec_alteraChamado " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_ALTERACHAMADO.id_chamado, ref input_id_chamado ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_ALTERACHAMADO.id_chamado missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_ALTERACHAMADO.st_new_desc, ref input_st_new_desc ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_ALTERACHAMADO.st_new_desc missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_ALTERACHAMADO.tg_fechado, ref input_tg_fechado ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_ALTERACHAMADO.tg_fechado missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_ALTERACHAMADO.st_operador, ref input_st_operador ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_ALTERACHAMADO.st_operador missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_ALTERACHAMADO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_ALTERACHAMADO.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_alteraChamado " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_alteraChamado " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_alteraChamado " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_alteraChamado " ); 
		
			/// USER [ execute ]
			
			T_Chamado 	cham 		= new T_Chamado 	(this);
			T_Usuario 	usrConvey 	= new T_Usuario 	(this);
			LOG_Chamado l_c 		= new LOG_Chamado 	(this);
			
			if ( input_tg_fechado == Context.TRUE )
				cham.ExclusiveAccess();
			
			if ( !cham.selectIdentity ( input_id_chamado ) )
				return false;
			
			if ( cham.get_tg_fechado() == Context.TRUE )
			{
				PublishError ( "Chamado fechado não pode ser alterado" );
				return false;
			}
			
			if ( !usrConvey.select_rows_login ( input_st_operador, "000000" ) )
			{
				PublishError ( "Usuário inexistente" );
				return false;
			}
			
			if ( !usrConvey.fetch() )
				return false;
					
			l_c.set_fk_chamado  ( cham.get_identity() 		);	
			l_c.set_fk_operador ( user.get_identity() 		);
			l_c.set_st_solucao  ( input_st_new_desc 		);
			l_c.set_dt_solucao 	( GetDataBaseTime() 		);
						
			if ( !l_c.create_LOG_Chamado() )
				return false;
			
			cham.set_tg_fechado 	( input_tg_fechado			);
			cham.set_fk_operador 	( usrConvey.get_identity() 	);
			
			if ( input_tg_fechado == Context.TRUE )
				cham.set_dt_fechamento ( GetDataBaseTime() );
			
			if ( !cham.synchronize_T_Chamado() )
				return false;
			
			if ( input_tg_fechado == Context.TRUE )
			{
				l_c.set_st_solucao  ( "## Chamado fechado" );
										
				if ( !l_c.create_LOG_Chamado() )
					return false;
			}		
			
			PublishNote ( "Chamado alterado com sucesso" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_alteraChamado " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_alteraChamado " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.AlterChamConvey 		);
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( "" );
				
				aud.set_fk_generic  ( 0 );
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_alteraChamado " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
