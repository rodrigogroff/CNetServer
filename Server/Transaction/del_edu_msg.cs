using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class del_edu_msg : type_base
	{
		public string input_id_msg = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public del_edu_msg ( Transaction trans ) : base (trans)
		{
			var_Alias = "del_edu_msg";
			constructor();
		}
		
		public del_edu_msg()
		{
			var_Alias = "del_edu_msg";
		
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
			Registry ( "setup del_edu_msg " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_DEL_EDU_MSG.id_msg, ref input_id_msg ) == false ) 
			{
				Trace ( "# COMM_IN_DEL_EDU_MSG.id_msg missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_DEL_EDU_MSG.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_DEL_EDU_MSG.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done del_edu_msg " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate del_edu_msg " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done del_edu_msg " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute del_edu_msg " ); 
		
			/// USER [ execute ]
			
			T_MensagemEdu msg = new T_MensagemEdu (this);
			
			if ( !msg.selectIdentity ( input_id_msg ) )
				return false;
			
			msg.delete();
			
			/// USER [ execute ] END
		
			Registry ( "execute done del_edu_msg " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish del_edu_msg " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done del_edu_msg " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
