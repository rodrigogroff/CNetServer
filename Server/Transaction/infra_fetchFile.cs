using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class infra_fetchFile : Transaction
	{
		public string input_st_part = "";
		
		public string output_st_next_part = "";
		public string output_st_content = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public infra_fetchFile ( Transaction trans ) : base (trans)
		{
			var_Alias = "infra_fetchFile";
			constructor();
		}
		
		public infra_fetchFile()
		{
			var_Alias = "infra_fetchFile";
		
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
			Registry ( "setup infra_fetchFile " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_INFRA_FETCHFILE.st_part, ref input_st_part ) == false ) 
			{
				Trace ( "# COMM_IN_INFRA_FETCHFILE.st_part missing! " ); 
				return false;
			}
			
			Registry ( "setup done infra_fetchFile " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate infra_fetchFile " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done infra_fetchFile " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute infra_fetchFile " ); 
		
			/// USER [ execute ]
			
			bool Stop = false;
			
			DataPortable port = MemoryGet ( input_st_part );
			
			string data = port.getValue ( "data" );
			
			int tam = Convert.ToInt32 ( new InstallData().maxPacket ) - 200;
			
			if ( data.Length < tam )
			{
				tam = data.Length;
				Stop = true;
			}
			
			output_st_content = data.Substring (0, tam );
			
			if ( !Stop )
			{
				port.setValue ( "data", data.Substring ( tam, data.Length - tam ) );
				
				output_st_next_part = MemorySave ( ref port );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done infra_fetchFile " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish infra_fetchFile " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done infra_fetchFile " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_INFRA_FETCHFILE.st_next_part, output_st_next_part ); 
			dp_out.MapTagValue ( COMM_OUT_INFRA_FETCHFILE.st_content, output_st_content ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
