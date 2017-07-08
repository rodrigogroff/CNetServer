using System;
using System.Threading;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SyCrafEngine
{
	public class InstallData
	{
		public string st_win_uninstall 	    = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
		public string st_win_start_menu 	= @"Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders";

		public string nameClient = ""; 
		public string pathDir = ""; 
		public string maxPacket = ""; 
		public string clientServerPort = ""; 
		public string serverMachine = ""; 
		public string upgradePath = ""; 
		public string language = ""; 
		public string lastUser = ""; 
		public const string app = "Updater"; 
		public string serverStandby = ""; 
		public string serverStandByPort = ""; 

		public bool IsAppInstalled = false;
		public bool IsUpgrade = false;

		public string st_version =  ""; 
		public string st_uninstallString = "";

		public InstallData()
		{
			load_registration();
			
			string path = "";

			if ( IsAppInstalled )
			{
				if ( upgradePath != "" )
					path  = upgradePath + @"\version.txt";
				else
					path  = "version.txt";
			}
			else
				path  = "version.txt";

			if ( File.Exists ( path + ".bak" ) )
			{
				return;
			}
	
			if ( !File.Exists ( path ) )
				return;
	
			FileStream 		file       = new FileStream   ( path, FileMode.Open, FileAccess.Read	);
			StreamReader 	configFile = new StreamReader ( file  );	
			
			string st_install_version = configFile.ReadLine();
	
			configFile.Close();
			file.Close();
	
			if ( st_version != "" )
			{
				if ( st_install_version == null )
					return;
				
				if ( st_install_version != st_version )
				{
					st_version = st_install_version;
					IsUpgrade  = true;
				}
			}
			else
			{
				st_version = st_install_version;
			}
		}

		public void load_registration()
		{
			#if LINUX_DIST
			
			if ( !File.Exists ( "linux.cfg" ) )
			{
				MessageBox.Show ( "Please edit the file 'linux.cfg'","Warning" );
	
				StreamWriter sw_linux = new StreamWriter ( "linux.cfg" );
	
				sw_linux.WriteLine ( "maxPacket:64000" );
				sw_linux.WriteLine ( "clientServerPort:1000" );
				sw_linux.WriteLine ( "serverMachine:localhost" );
				sw_linux.WriteLine ( "language:0" );
				sw_linux.WriteLine ( "serverStandby:" );	
				sw_linux.WriteLine ( "serverStandbyPort:" );	
				sw_linux.WriteLine ( "st_version:01.00.0000" );	
	
				sw_linux.Close();
				return;
			}

			StreamReader sr = new StreamReader ( "linux.cfg" );

			maxPacket = sr.ReadLine().Replace ( "maxPacket:","" );
			clientServerPort = sr.ReadLine().Replace ( "clientServerPort:","" );
			serverMachine = sr.ReadLine().Replace ( "serverMachine:","" );
			language = sr.ReadLine().Replace ( "language:","" );
			serverStandby = sr.ReadLine().Replace ( "serverStandby:","" );
			serverStandByPort = sr.ReadLine().Replace ( "serverStandbyPort:","" );
			st_version = sr.ReadLine().Replace ( "st_version:","" );

			sr.Close();

			IsAppInstalled = true;

			#else
	
			RegistryKey regKey = Registry.LocalMachine;
			regKey = regKey.OpenSubKey ( st_win_uninstall );
		
			string[] keys = regKey.GetSubKeyNames();

			StreamReader sr = new StreamReader ( "app.txt" );
			string app_target = InfraSoftwareClient.nameClient + " " + sr.ReadLine();
			sr.Close();

		
			if (keys != null && keys.Length > 0)
			{
				for (int i = 0; i < keys.Length; i ++)
				{
					RegistryKey k = regKey.OpenSubKey(keys[i]);
					object obj_appName = k.GetValue("DisplayName");

					if ( obj_appName != null )
					{
						if ( Convert.ToString ( obj_appName ) == app_target )
    					{
							IsAppInstalled = true;
							
							st_version = Convert.ToString ( k.GetValue( "st_version" ) );
							st_uninstallString = Convert.ToString ( k.GetValue( "UninstallString" ) );
							pathDir = Convert.ToString ( k.GetValue( InfraSoftwareClient.pathDir ) );
							maxPacket = Convert.ToString ( k.GetValue( InfraSoftwareClient.maxPacket ) );
							clientServerPort = Convert.ToString ( k.GetValue( InfraSoftwareClient.clientServerPort ) );
							serverMachine = Convert.ToString ( k.GetValue( InfraSoftwareClient.serverMachine ) );
							upgradePath = Convert.ToString ( k.GetValue( InfraSoftwareClient.upgradePath ) );
							language = Convert.ToString ( k.GetValue( InfraSoftwareClient.language ) );
							lastUser = Convert.ToString ( k.GetValue( InfraSoftwareClient.lastUser ) );
							serverStandby = Convert.ToString ( k.GetValue( InfraSoftwareClient.serverStandby ) );
							serverStandByPort = Convert.ToString ( k.GetValue( InfraSoftwareClient.serverStandByPort ) );
    					
    						return;
    					}
					}
				}
			}
			#endif
		}
		
		public bool ins_registration ( )
		{
			#if LINUX_DIST
			
			if ( File.Exists ( "linux.cfg" ) )
				File.Delete ( "linux.cfg" );
			
			StreamWriter sw_linux = new StreamWriter ( "linux.cfg" );
			
			sw_linux.WriteLine ( "maxPacket:"   			+ maxPacket );
			sw_linux.WriteLine ( "clientServerPort:" 		+ clientServerPort );
			sw_linux.WriteLine ( "serverMachine:" 		+ serverMachine );
			sw_linux.WriteLine ( "language:" 				+ language );
			sw_linux.WriteLine ( "serverStandby:" 		+ serverStandby );	
			sw_linux.WriteLine ( "serverStandByPort:" 	+ serverStandByPort );	
			sw_linux.WriteLine ( "st_version:" 			+ st_version );	

			sw_linux.Close();

			#else

			if ( IsAppInstalled )
			{
				rem_registration();
			}
		

			StreamReader sr = new StreamReader ( "app.txt" );
			string cur_app = sr.ReadLine();
			string app_target = InfraSoftwareClient.nameClient + " " + cur_app;
			sr.Close();

			RegistryKey regKey = Registry.LocalMachine;
			regKey = regKey.OpenSubKey ( st_win_uninstall, true );
		
			regKey.GetAccessControl();
			regKey = regKey.CreateSubKey ( app_target );
	
			regKey.SetValue ( "DisplayName", 	app_target );
			regKey.SetValue ( "UninstallString", 			st_uninstallString	);
			regKey.SetValue ( "st_version", 				st_version	);
	
			regKey.SetValue ( "nameClient", app_target );
			regKey.SetValue ( "pathDir", pathDir);
			regKey.SetValue ( "maxPacket", maxPacket);
			regKey.SetValue ( "clientServerPort", clientServerPort);
			regKey.SetValue ( "serverMachine", serverMachine);
			regKey.SetValue ( "upgradePath", upgradePath);
			regKey.SetValue ( "language", language);
			regKey.SetValue ( "lastUser", lastUser);
			regKey.SetValue ( "app", app);
			regKey.SetValue ( "serverStandby", serverStandby);
			regKey.SetValue ( "serverStandByPort", serverStandByPort);
	
			regKey.Close();
	     		    
			#endif
	     		    
			return true;
		}
	
		public void rem_registration ( )
		{
			RegistryKey regKey = Registry.LocalMachine;
			regKey = regKey.OpenSubKey ( st_win_uninstall, true );
		
			regKey.GetAccessControl();

			StreamReader sr = new StreamReader ( "app.txt" );
			string app_target = InfraSoftwareClient.nameClient + " " + sr.ReadLine();
			sr.Close();

			regKey.DeleteSubKeyTree ( app_target );
		
			regKey.Close();
		}
	
		public string getStartMenu()
		{
			RegistryKey regKey = Registry.LocalMachine;
			regKey = regKey.OpenSubKey ( st_win_start_menu );
			
			return Convert.ToString ( regKey.GetValue("Common Programs") );
		}

		public string CopyInstallation ( string remotePath, string nameApp )
		{
			string path = System.Environment.GetEnvironmentVariable ( "COMMONPROGRAMFILES" ) + "\\" + nameApp + "\\temp";
	
			if ( !Directory.Exists ( path ) )
				Directory.CreateDirectory ( path );
		
			string [] files = Directory.GetFiles ( remotePath );
	
			for ( int t=0; t < files.Length; ++t )
			{
				File.Copy ( files[t], path + "\\" + files[t].Replace ( remotePath + "\\", "" ), true );
			}
	
			string safe = path;
	
			remotePath 	+= "\\data";
			path 		+= "\\data";
	
			if ( !Directory.Exists ( path ) )
				Directory.CreateDirectory ( path );
			
			string [] data_files = Directory.GetFiles ( remotePath );
		
			for ( int t=0; t < data_files.Length; ++t )
			{
				File.Copy ( data_files[t], path + "\\" + data_files[t].Replace ( remotePath + "\\", "" ), true );
			}
		
			///USERCODE
			///USERCODE END
		
			return safe;
		}			
			
		public bool IsRemoteUpdateAvailable()
		{
			string path  = upgradePath + @"\version.txt";
		
			if ( !File.Exists ( path ) ) return false;
		
			FileStream 		file       = new FileStream   ( path, FileMode.Open, FileAccess.Read	);
			StreamReader 	configFile = new StreamReader ( file       	);	
			
			string st_upgrade_version = configFile.ReadLine();
		
			configFile.Close();
			file.Close();
			
			if ( st_upgrade_version != null )
			{
				if ( st_upgrade_version != st_version )
					return true;
			}
			
			return false;
		}				
	}
}
