using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_edu_habilita : type_base
	{
		public string input_st_cartao = "";
		public string input_st_senha = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_edu_habilita ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_edu_habilita";
			constructor();
		}
		
		public exec_edu_habilita()
		{
			var_Alias = "exec_edu_habilita";
		
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
			Registry ( "setup exec_edu_habilita " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_EDU_HABILITA.st_cartao, ref input_st_cartao ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_EDU_HABILITA.st_cartao missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_EDU_HABILITA.st_senha, ref input_st_senha ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_EDU_HABILITA.st_senha missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_EDU_HABILITA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_EDU_HABILITA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_edu_habilita " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_edu_habilita " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_edu_habilita " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_edu_habilita " ); 
		
			/// USER [ execute ]
			
			
			// ## Busca cartão específico
			
			T_Cartao cart = new T_Cartao (this);
			
			cart.ExclusiveAccess();
			
			if ( !cart.select_rows_tudo ( input_st_cartao.Substring (0,6), 
			                              input_st_cartao.Substring (6,6), 
			                              "01" ) )
			{
				PublishError ( "Cartão inválido" );
				return false;
			}
			
			if ( !cart.fetch() )
				return false;
			
			// ## Se ainda não foi expedido, não tem como habilitar
			
			if ( cart.get_tg_emitido() != StatusExpedicao.Expedido )
			{
				PublishError ( "Cartão ainda não expedido" );
				return false;
			}
			
			// ## A senha vazia indica que cartão educacional está
			// ## expedido e não habilitado
			
			if ( cart.get_st_senha() != "" && cart.get_tg_tipoCartao() == TipoCartao.educacional )
			{
				PublishError ( "Cartão previamente habilitado" );
				return false;
			}
			
			// ## Atualiza senha e cartão
			
			cart.set_st_senha ( input_st_senha );
			
			if ( !cart.synchronize_T_Cartao() )
				return false;
			
			PublishNote ( "Cartão habilitado com sucesso" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_edu_habilita " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_edu_habilita " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done exec_edu_habilita " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
