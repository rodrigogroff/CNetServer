using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class infra_fetchIncomingVersion : Transaction
	{
		public string input_app = "";
		
		public string output_st_csv_files = "";
		public string output_st_version = "";
		
		/// USER [ var_decl ]
		
		public string input_tg_windows = Context.TRUE;
		
		/// USER [ var_decl ] END
		
		public infra_fetchIncomingVersion ( Transaction trans ) : base (trans)
		{
			var_Alias = "infra_fetchIncomingVersion";
			constructor();
		}
		
		public infra_fetchIncomingVersion()
		{
			var_Alias = "infra_fetchIncomingVersion";
		
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
			Registry ( "setup infra_fetchIncomingVersion " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_INFRA_FETCHINCOMINGVERSION.app, ref input_app ) == false ) 
			{
				Trace ( "# COMM_IN_INFRA_FETCHINCOMINGVERSION.app missing! " ); 
				return false;
			}
			
			Registry ( "setup done infra_fetchIncomingVersion " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate infra_fetchIncomingVersion " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done infra_fetchIncomingVersion " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute infra_fetchIncomingVersion " ); 
		
			/// USER [ execute ]
			
			string upgradePath = "";
			
			if ( input_tg_windows == Context.TRUE )
			{
				upgradePath = new InstallData().upgradePath.Replace ( "depot\\Server", "depot\\" + input_app + "\\Data" );
			}
			else
			{
				upgradePath = new InstallData().upgradePath.Replace ( "depot\\Server", "depot\\Linux_Dist\\" + input_app  );
			}
			
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
						if ( fileName == "Updater.exe" || fileName == "UpdateEngine.dll" )
							continue;
					}
					else
					{
						if ( fileName == "LinuxUpdater.exe" || fileName == "UpdateEngine.dll" )
							continue;
						
						if ( fileName.EndsWith ( ".exe" ) )
							if ( !fileName.StartsWith ( "Linux" ) )
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
			output_st_version   = new InstallData().st_version;
			
			/// USER [ execute ] END
		
			Registry ( "execute done infra_fetchIncomingVersion " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish infra_fetchIncomingVersion " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done infra_fetchIncomingVersion " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_INFRA_FETCHINCOMINGVERSION.st_csv_files, output_st_csv_files ); 
			dp_out.MapTagValue ( COMM_OUT_INFRA_FETCHINCOMINGVERSION.st_version, output_st_version ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
