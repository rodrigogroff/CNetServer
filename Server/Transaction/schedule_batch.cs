using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]

using System.Net;

/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class schedule_batch : Transaction
	{
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public schedule_batch ( Transaction trans ) : base (trans)
		{
			var_Alias = "schedule_batch";
			constructor();
		}
		
		public schedule_batch()
		{
			var_Alias = "schedule_batch";
		
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
			Registry ( "setup schedule_batch " ); 
		
			Registry ( "setup done schedule_batch " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate schedule_batch " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done schedule_batch " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute schedule_batch " ); 
		
			/// USER [ execute ]
			
			// #####################
			// ## Watch directory:
			// #####################
			
			string dir_watch = new SyCrafEngine.InstallData().pathDir + "\\proc";
			
			Registry ( dir_watch );		
			
			string [] my_files = Directory.GetFiles ( dir_watch );
			
			for ( int t=0; t < my_files.GetLength (0); ++t )
			{
				string archive = my_files[t];
				
				I_Batch bat = new I_Batch (this);
				
				if ( bat.select_rows_archive ( archive.Replace ( dir_watch + "\\", "" ) ) )
				{
					bat.fetch();
					
					if ( bat.get_tg_running() == Context.FALSE )
					{
						Trace ( "Moving file to rejected" );
						
						string dest_file = archive.Replace  ( "\\proc", "\\proc\\rejected" );
						
						if ( File.Exists ( dest_file ) )	File.Delete ( dest_file );
						
						File.Move ( archive, dest_file );
						
						Trace ( dest_file + " moved!" );
					}
					
					continue;
				}
				
				bat.set_st_archive 		( archive.Replace (  dir_watch + "\\", "" ) );
				bat.set_dt_start		( GetDataBaseTime() );
				bat.set_tg_processed 	( Context.FALSE		);
				bat.set_tg_running 		( Context.FALSE		);
				
				bat.create_I_Batch();
			}
			
			
			/// USER [ execute ] END
		
			Registry ( "execute done schedule_batch " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish schedule_batch " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done schedule_batch " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
