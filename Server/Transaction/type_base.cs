using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class type_base : Transaction
	{
		public CNetHeader input_cont_header = new CNetHeader();
		
		/// USER [ var_decl ]
		
		public ApplicationUtil var_util = new ApplicationUtil();
		public T_Usuario user; 
		
		/// USER [ var_decl ] END
		
		public type_base ( Transaction trans ) : base (trans)
		{
			var_Alias = "type_base";
			constructor();
		}
		
		public type_base()
		{
			var_Alias = "type_base";
		
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
			Registry ( "setup type_base " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_TYPE_BASE.header, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_TYPE_BASE.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_0 );
			
			Registry ( "setup done type_base " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate type_base " ); 
		
			/// USER [ authenticate ]
			
			if ( var_SessionKey != input_cont_header.get_st_session() ) 
				return false;
			
			user = new T_Usuario ( this );
			
			if ( !user.selectIdentity ( input_cont_header.get_st_user_id() ) )
				return false;
						
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done type_base " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute type_base " ); 
		
			/// USER [ execute ]
			
			input_cont_header.set_st_empresa ( input_cont_header.get_st_empresa().PadLeft ( 6, '0' ) );
			
			user.set_dt_ultUso ( GetDataBaseTime() 	);
			
			if ( !user.synchronize_T_Usuario() )
				return false;
			
			if ( user.get_int_tg_aviso() == 1 )
			{
				PublishNote ( "Favor fechar sua sessão para atualização de sistema" );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done type_base " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish type_base " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done type_base " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
