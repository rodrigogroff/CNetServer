using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class schedule_nsu : schedule_base
	{
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public schedule_nsu ( Transaction trans ) : base (trans)
		{
			var_Alias = "schedule_nsu";
			constructor();
		}
		
		public schedule_nsu()
		{
			var_Alias = "schedule_nsu";
		
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
			Registry ( "setup schedule_nsu " ); 
		
			Registry ( "setup done schedule_nsu " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate schedule_nsu " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done schedule_nsu " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute schedule_nsu " ); 
		
			/// USER [ execute ]
			
			T_PendPayFone pf = new T_PendPayFone (this);
			
			pf.truncate();
			
			LOG_NSU l_nsu = new LOG_NSU (this);
			
			l_nsu.truncate();
			
			LOG_NS_FAT l_ns_fat = new LOG_NS_FAT (this);
			
			l_ns_fat.truncate();	
			
			{
				string schel_log = new InstallData().pathDir + "\\log\\scheduler_log";
				
				if ( Directory.Exists ( schel_log ) )
	      		{
	      			string [] 	my_files = Directory.GetFiles ( schel_log );
					int 		numFiles = my_files.GetLength (0);
				
					for ( int t=0; t < numFiles; ++t)
					{
						string archive = my_files[t];
						
						try
						{
							System.IO.File.Delete ( archive );
						}
						catch (System.Exception ex )
						{
							Trace ( ex.Message );
						}
					}
				}			
			}
			
			{
				string schel_log = new InstallData().pathDir + "\\log";
				
				if ( Directory.Exists ( schel_log ) )
	      		{
	      			string [] 	my_files = Directory.GetFiles ( schel_log );
					int 		numFiles = my_files.GetLength (0);
				
					for ( int t=0; t < numFiles; ++t)
					{
						string archive = my_files[t];
						
						try
						{
							System.IO.File.Delete ( archive );
						}
						catch (System.Exception ex )
						{
							Trace ( ex.Message );
						}
					}
				}			
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done schedule_nsu " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish schedule_nsu " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done schedule_nsu " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
