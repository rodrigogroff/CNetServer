using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class type_load : Transaction
	{
		/// USER [ var_decl ]
		
		public ApplicationUtil var_util = new ApplicationUtil();
		
		public string 	dir_watch  = "";
		public string   db_archive = "";
		public string 	archive    = "";	
		
		public I_Batch bat;
		
		/// USER [ var_decl ] END
		
		public type_load ( Transaction trans ) : base (trans)
		{
			var_Alias = "type_load";
			constructor();
		}
		
		public type_load()
		{
			var_Alias = "type_load";
		
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
			Registry ( "setup type_load " ); 
		
			Registry ( "setup done type_load " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate type_load " ); 
		
			/// USER [ authenticate ]
			
			DataPortable   dp = MemoryGet ( "input" );
			
			db_archive = dp.getValue ( "archive" );
			dir_watch  = new SyCrafEngine.InstallData().pathDir + "\\proc\\";
			archive    = dir_watch + db_archive;	
			
			Trace ( archive );
			
			bat = new I_Batch(this);
			
			bat.ExclusiveAccess();
			
			if ( bat.select_rows_archive ( db_archive ) )
			{
				bat.fetch();
				
				bat.set_dt_proc_start 	( GetDataBaseTime() );
				bat.set_tg_running 		( Context.TRUE 		);
				
				bat.synchronize_I_Batch();
				
				bat.ReleaseExclusive();				
			}
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done type_load " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute type_load " ); 
		
			/// USER [ execute ]
			/// USER [ execute ] END
		
			Registry ( "execute done type_load " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish type_load " ); 
		
			/// USER [ finish ]
			
			bat.ExclusiveAccess();
			
			if ( bat.select_rows_archive ( db_archive ) )
			{
				bat.fetch();
				
				bat.set_dt_proc_end 	( GetDataBaseTime() );
				bat.set_tg_running 		( Context.FALSE		);
				bat.set_tg_processed    ( Context.TRUE		);
				
				bat.synchronize_I_Batch();
				
				bat.ReleaseExclusive();				
			}
			
			string archive_dest = archive.Replace ( "\\proc" , "\\proc\\term" );
			
			if ( File.Exists ( archive_dest ) )	File.Delete ( archive_dest );
						
			File.Move ( archive, archive.Replace ( "\\proc" , "\\proc\\term" ) );				
			
			/// USER [ finish ] END
		
			Registry ( "finish done type_load " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
