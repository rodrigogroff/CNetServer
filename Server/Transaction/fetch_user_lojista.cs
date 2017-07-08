using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_user_lojista : type_base
	{
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_user_lojista ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_user_lojista";
			constructor();
		}
		
		public fetch_user_lojista()
		{
			var_Alias = "fetch_user_lojista";
		
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
			Registry ( "setup fetch_user_lojista " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_FETCH_USER_LOJISTA.header, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_USER_LOJISTA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_0 );
			
			Registry ( "setup done fetch_user_lojista " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_user_lojista " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_user_lojista " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_user_lojista " ); 
		
			/// USER [ execute ]
			
			T_Usuario lojista = new T_Usuario (this);
			LINK_UsuarioTerminal lut = new LINK_UsuarioTerminal (this);
			
			if ( lojista.selectAll() )
			{
				while ( lojista.fetch() )
				{
					if ( lojista.get_tg_nivel() == TipoUsuario.Lojista )
					{
						if ( !lut.select_fk_user ( lojista.get_identity() ) )
						{
							DadosUsuario du = new DadosUsuario();
							
							du.set_id_usuario ( lojista.get_identity() 	);
							du.set_st_nome    ( lojista.get_st_nome()	);
							
							output_array_generic_lst.Add ( du );
						}
					}
				}
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_user_lojista " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_user_lojista " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_user_lojista " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_FETCH_USER_LOJISTA.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			return true;
		}
	}
}
