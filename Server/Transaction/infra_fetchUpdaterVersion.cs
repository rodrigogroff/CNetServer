using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class infra_fetchUpdaterVersion : Transaction
	{
		public string output_st_csv_files = "";
		
		/// USER [ var_decl ]
		
		public string input_tg_windows = Context.TRUE;
		
		/// USER [ var_decl ] END
		
		public infra_fetchUpdaterVersion ( Transaction trans ) : base (trans)
		{
			var_Alias = "infra_fetchUpdaterVersion";
			constructor();
		}
		
		public infra_fetchUpdaterVersion()
		{
			var_Alias = "infra_fetchUpdaterVersion";
		
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
			Registry ( "setup infra_fetchUpdaterVersion " ); 
		
			Registry ( "setup done infra_fetchUpdaterVersion " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate infra_fetchUpdaterVersion " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done infra_fetchUpdaterVersion " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute infra_fetchUpdaterVersion " ); 
		
			/// USER [ execute ]
			
			string upgradePath = new InstallData().upgradePath.Replace ( "depot\\Server", "depot\\Client\\Data" );
			
			if ( Directory.Exists ( upgradePath ) )
      		{
      			string [] 	my_files = Directory.GetFiles ( upgradePath );
				int 		numFiles = my_files.GetLength (0);
			
				for ( int t=0; t < numFiles; ++t)
				{
					string fileName = my_files[t];
					
					for ( int h=fileName.Length-1; h > 0; --h )
					{
						if ( fileName [h] == '\\' )
						{
							fileName = fileName.Substring ( h + 1, fileName.Length - h - 1);
							break;
						}
					}
					
					Trace ( fileName );
					
					if ( input_tg_windows == Context.TRUE )
					{
						if ( fileName != "UpdateEngine.dll" && fileName != "Updater.exe" )
							continue;
					}
					else // linux_dist
					{
						if ( fileName != "UpdateEngine.dll" && fileName != "LinuxUpdater.exe" )
							continue;
					}
					
					DataPortable port = new DataPortable();
					
					string 	filePath = upgradePath + "\\" + fileName;
					
					FileStream fs = new FileStream(filePath, FileMode.Open );
					BinaryReader br = new BinaryReader(fs);
					byte[] bin = br.ReadBytes(Convert.ToInt32(fs.Length));
					fs.Close();
					br.Close();
					
					StringBuilder hexString = new StringBuilder();
						
					for (int i=0; i<bin.Length; i++)
						hexString.Append ( bin[i].ToString("X2") );
					
					port.setValue ( "data", hexString.ToString() );
					
					output_st_csv_files += fileName + ",";
					output_st_csv_files += MemorySave ( ref port ) + ",";
				}
			}
			
			output_st_csv_files = output_st_csv_files.TrimEnd ( ',' );
			
			/// USER [ execute ] END
		
			Registry ( "execute done infra_fetchUpdaterVersion " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish infra_fetchUpdaterVersion " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done infra_fetchUpdaterVersion " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_INFRA_FETCHUPDATERVERSION.st_csv_files, output_st_csv_files ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
