using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_conveyUsuarios : type_base
	{
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_conveyUsuarios ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_conveyUsuarios";
			constructor();
		}
		
		public fetch_conveyUsuarios()
		{
			var_Alias = "fetch_conveyUsuarios";
		
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
			Registry ( "setup fetch_conveyUsuarios " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_FETCH_CONVEYUSUARIOS.header, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_CONVEYUSUARIOS.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_0 );
			
			Registry ( "setup done fetch_conveyUsuarios " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_conveyUsuarios " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_conveyUsuarios " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_conveyUsuarios " ); 
		
			/// USER [ execute ]
			
			T_Usuario usrConvey = new T_Usuario (this);
			
			if ( usrConvey.select_rows_empresa ( "000000" ) )
			{
				while ( usrConvey.fetch() )
				{
					DadosUsuario du = new DadosUsuario();
					
					du.set_st_nome ( usrConvey.get_st_nome() );
					
					output_array_generic_lst.Add ( du );
				}
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_conveyUsuarios " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_conveyUsuarios " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_conveyUsuarios " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_FETCH_CONVEYUSUARIOS.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			return true;
		}
	}
}
