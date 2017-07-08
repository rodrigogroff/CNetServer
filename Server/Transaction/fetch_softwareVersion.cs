using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_softwareVersion : Transaction
	{
		public string input_st_version = "";
		
		public string output_st_versionOutdated = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_softwareVersion ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_softwareVersion";
			constructor();
		}
		
		public fetch_softwareVersion()
		{
			var_Alias = "fetch_softwareVersion";
		
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
			Registry ( "setup fetch_softwareVersion " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_SOFTWAREVERSION.st_version, ref input_st_version ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_SOFTWAREVERSION.st_version missing! " ); 
				return false;
			}
			
			Registry ( "setup done fetch_softwareVersion " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate fetch_softwareVersion " ); 
		
			/// USER [ authenticate ]
			
			if ( new InstallData().st_version != input_st_version )
			{
				output_st_versionOutdated = Context.TRUE;	
			}
			else
			{
				output_st_versionOutdated = Context.FALSE;
			}
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_softwareVersion " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute fetch_softwareVersion " ); 
		
			/// USER [ execute ]
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_softwareVersion " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish fetch_softwareVersion " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_softwareVersion " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_SOFTWAREVERSION.st_versionOutdated, output_st_versionOutdated ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
