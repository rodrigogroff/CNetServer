using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]

using System.Threading;

/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class schedule_proc_batch : Transaction
	{
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public schedule_proc_batch ( Transaction trans ) : base (trans)
		{
			var_Alias = "schedule_proc_batch";
			constructor();
		}
		
		public schedule_proc_batch()
		{
			var_Alias = "schedule_proc_batch";
		
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
			Registry ( "setup schedule_proc_batch " ); 
		
			Registry ( "setup done schedule_proc_batch " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate schedule_proc_batch " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done schedule_proc_batch " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute schedule_proc_batch " ); 
		
			/// USER [ execute ]
			
			string dir_watch = new SyCrafEngine.InstallData().pathDir + "\\proc\\";
			
			I_Batch bat = new I_Batch (this);
			
			Thread.Sleep ( 3000 ); //  Wait to build valid filelist
			
			if ( bat.select_rows_free ( Context.FALSE, Context.FALSE ) )
			{
				while ( bat.fetch() )
				{
					string archive = bat.get_st_archive();
					
					#region - SETUP -
					
					string path =   new InstallData().pathDir + "\\Log_" +
									DateTime.Now.Year.ToString() +
	    							DateTime.Now.Month.ToString().PadLeft ( 2, '0') +
	    							DateTime.Now.Day.ToString().PadLeft ( 2, '0') +
	    							DateTime.Now.Hour.ToString().PadLeft ( 2, '0') +
	    							DateTime.Now.Minute.ToString().PadLeft ( 2, '0') +
	    							DateTime.Now.Second.ToString().PadLeft ( 2, '0') +
									"_batch_" + archive + ".txt.wrk";
					
					FileStream 		logFile;
					StreamWriter 	logStream;
			
		        	if ( File.Exists ( path ) ) 
						logFile = new FileStream ( path, FileMode.Append, FileAccess.Write);
		        	else
		        		logFile = new FileStream ( path, FileMode.Create, FileAccess.Write);
						     	
					logStream = new StreamWriter ( logFile );
					logStream.AutoFlush = true;	
					
					var_Comm.Clear();
					DB_Access new_access = new DB_Access ( ref m_gen_my_access );
					
					var_disp.var_Translator = var_Translator;
					
					DataPortable 	port = new DataPortable();
						
					port.setValue ( "archive", archive );
				
					new_access.MemorySave ( "input", ref port );
					
					#endregion
					
					if ( archive.StartsWith ( "CARGA_EDU_" ) )
				    {
						// Runnig in a new thread
						var_disp.ExecuteThreadTransaction (	"load_edu",
						                                    Convert.ToInt32 ( bat.get_identity() ),
							                                ref logStream,
							                                ref var_Comm,
							                                ref new_access,
							                                path );
				    }
					else if ( archive.StartsWith ( "CARGA_EDUEMPRESASVIRTUAIS" ) )
				    {
						// Runnig in a new thread
						var_disp.ExecuteThreadTransaction (	"load_edu_emp_virtual",
						                                    Convert.ToInt32 ( bat.get_identity() ),
							                                ref logStream,
							                                ref var_Comm,
							                                ref new_access,
							                                path );
				    }
					else if ( archive.StartsWith ( "LEGADO" ) )
				    {
						// Runnig in a new thread
						var_disp.ExecuteThreadTransaction (	"load_legado",
						                                    Convert.ToInt32 ( bat.get_identity() ),
							                                ref logStream,
							                                ref var_Comm,
							                                ref new_access,
							                                path );
					}
				}
			}		
			
			/// USER [ execute ] END
		
			Registry ( "execute done schedule_proc_batch " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish schedule_proc_batch " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done schedule_proc_batch " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
