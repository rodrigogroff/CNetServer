using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class upload_archive : type_base
	{
		public string input_st_id = "";
		
		public ArrayList input_array_generic_lst = new ArrayList();
		
		public string output_st_new_id = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public upload_archive ( Transaction trans ) : base (trans)
		{
			var_Alias = "upload_archive";
			constructor();
		}
		
		public upload_archive()
		{
			var_Alias = "upload_archive";
		
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
			Registry ( "setup upload_archive " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_UPLOAD_ARCHIVE.st_id, ref input_st_id ) == false ) 
			{
				Trace ( "# COMM_IN_UPLOAD_ARCHIVE.st_id missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_UPLOAD_ARCHIVE.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_UPLOAD_ARCHIVE.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			DataPortable dp_array_generic_lst = var_Comm.GetEntryPortableAtPosition ( 2 );
			
			if ( dp_array_generic_lst.GetMapArray ( COMM_IN_UPLOAD_ARCHIVE.lst , ref input_array_generic_lst ) == false )
			{
				Trace ( "# COMM_IN_UPLOAD_ARCHIVE.lst missing! " ); 
				return false;
			}
			
			Registry ( "setup done upload_archive " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate upload_archive " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done upload_archive " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute upload_archive " ); 
		
			/// USER [ execute ]
			
			DataPortable csv_AllArchive = MemoryGet ( input_st_id );
			
			StringBuilder sb_csv = new StringBuilder (  );
			
			if ( csv_AllArchive.getValue ( "ids" ) != "" )
			{
				sb_csv.Append ( csv_AllArchive.getValue ( "ids" ) 	);
				sb_csv.Append ( "," 								);
			}
			
			for ( int t=0; t < input_array_generic_lst.Count; ++t )
			{
				DataPortable port = input_array_generic_lst [ t ] as DataPortable;
				
				sb_csv.Append ( MemorySave ( ref port ) 	);
				sb_csv.Append ( "," 						);
			}
			
			csv_AllArchive.setValue ( "ids", sb_csv.ToString().TrimEnd ( ',' ) );
			
			output_st_new_id = MemorySave ( ref csv_AllArchive );
			
			/// USER [ execute ] END
		
			Registry ( "execute done upload_archive " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish upload_archive " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done upload_archive " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_UPLOAD_ARCHIVE.st_new_id, output_st_new_id ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
