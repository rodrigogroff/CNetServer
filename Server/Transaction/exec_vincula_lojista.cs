using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_vincula_lojista : type_base
	{
		public string input_st_cod_loja = "";
		public string input_id_usuario = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_vincula_lojista ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_vincula_lojista";
			constructor();
		}
		
		public exec_vincula_lojista()
		{
			var_Alias = "exec_vincula_lojista";
		
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
			Registry ( "setup exec_vincula_lojista " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_VINCULA_LOJISTA.st_cod_loja, ref input_st_cod_loja ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_VINCULA_LOJISTA.st_cod_loja missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_VINCULA_LOJISTA.id_usuario, ref input_id_usuario ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_VINCULA_LOJISTA.id_usuario missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_VINCULA_LOJISTA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_VINCULA_LOJISTA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_vincula_lojista " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_vincula_lojista " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_vincula_lojista " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_vincula_lojista " ); 
		
			/// USER [ execute ]
			
			T_Loja loj = new T_Loja (this);
			
			if ( !loj.select_rows_loja ( input_st_cod_loja ) )
			{
				PublishError ( "loja inexistente" );
				return false;
			}
			
			if (!loj.fetch() )
				return false;
			
			T_Usuario lojista = new T_Usuario (this);
			
			if ( !lojista.selectIdentity ( input_id_usuario ) )
			{
				PublishError ( "Usuário inexistente" );
				return false;
			}
			
			if ( lojista.get_tg_nivel() != TipoUsuario.Lojista )
			{
				PublishError ( "Usuário incorreto" );
				return false;
			}
			
			T_Terminal term = new T_Terminal (this);
			
			if ( !term.select_fk_loja ( loj.get_identity() ) )
			{
				PublishError ( "Loja não possui terminais" );
				return false;
			}	
			
			if ( !term.fetch() )
				return false;
			
			LINK_UsuarioTerminal lut = new LINK_UsuarioTerminal (this);
			
			if ( lut.select_fk_user ( lojista.get_identity() ) )
			{
				PublishError ( "Usuário já possui terminal" );
				return false;
			}
			
			lut.set_fk_term ( term.get_identity() 		);
			lut.set_fk_user ( lojista.get_identity() 	);
			
			if ( !lut.create_LINK_UsuarioTerminal() )
				return false;
			
			PublishNote ( "Lojista vinculado ao seu terminal com sucesso" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_vincula_lojista " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_vincula_lojista " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done exec_vincula_lojista " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
