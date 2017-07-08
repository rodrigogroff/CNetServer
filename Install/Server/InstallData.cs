using System;
using System.Threading;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ServerSetup
{
	public class InstallData
	{
		public string st_win_uninstall 	    = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
		public string st_win_start_menu 	= @"Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders";

		public string nameServer = ""; 
		public string db_schema = ""; 
		public string pathDir = ""; 
		public string db_choice = ""; 
		public string slaveOnly = ""; 
		public string db_machine = ""; 
		public string maxPacket = ""; 
		public string clientServerPort = ""; 
		public string user = ""; 
		public string password = ""; 
		public string db_port = ""; 
		public string upgradePath = ""; 
		public string language = ""; 
		public string standBy = ""; 
		public string standByPort = ""; 
		public string failFS = ""; 
		public string webStandBy = ""; 

		public bool IsAppInstalled = false;
		public bool IsUpgrade = false;
		public bool IsEnabled = true;

		public string st_version =  ""; 
		public string st_uninstallString = "";

		///USERCODE
		///USERCODE END

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
				IsEnabled = false;
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
	
	
				sw_linux.Close();
				return;
			}

			StreamReader sr = new StreamReader ( "linux.cfg" );


			sr.Close();

			IsAppInstalled = true;

			#else
	
			RegistryKey regKey = Registry.LocalMachine;
			regKey = regKey.OpenSubKey ( st_win_uninstall );
		
			string[] keys = regKey.GetSubKeyNames();
		
			if (keys != null && keys.Length > 0)
			{
				for (int i = 0; i < keys.Length; i ++)
				{
					RegistryKey k = regKey.OpenSubKey(keys[i]);
					object obj_appName = k.GetValue("DisplayName");

					if ( obj_appName != null )
					{
						if ( Convert.ToString ( obj_appName ) == InfraSoftwareServer.nameServer )
    					{
							IsAppInstalled = true;
							
							st_version = Convert.ToString ( k.GetValue( "st_version" ) );
							st_uninstallString = Convert.ToString ( k.GetValue( "UninstallString" ) );
							db_schema = Convert.ToString ( k.GetValue( "db_schema" ) );
							nameServer = Convert.ToString ( k.GetValue( InfraSoftwareServer.nameServer ) );
							pathDir = Convert.ToString ( k.GetValue( InfraSoftwareServer.pathDir ) );
							db_choice = Convert.ToString ( k.GetValue( InfraSoftwareServer.db_choice ) );
							slaveOnly = Convert.ToString ( k.GetValue( InfraSoftwareServer.slaveOnly ) );
							db_machine = Convert.ToString ( k.GetValue( InfraSoftwareServer.db_machine ) );
							maxPacket = Convert.ToString ( k.GetValue( InfraSoftwareServer.maxPacket ) );
							clientServerPort = Convert.ToString ( k.GetValue( InfraSoftwareServer.clientServerPort ) );
							user = Convert.ToString ( k.GetValue( InfraSoftwareServer.user ) );
							password = Convert.ToString ( k.GetValue( InfraSoftwareServer.password ) );
							db_port = Convert.ToString ( k.GetValue( InfraSoftwareServer.db_port ) );
							upgradePath = Convert.ToString ( k.GetValue( InfraSoftwareServer.upgradePath ) );
							language = Convert.ToString ( k.GetValue( InfraSoftwareServer.language ) );
							standBy = Convert.ToString ( k.GetValue( InfraSoftwareServer.standBy ) );
							standByPort = Convert.ToString ( k.GetValue( InfraSoftwareServer.standByPort ) );
							failFS = Convert.ToString ( k.GetValue( InfraSoftwareServer.failFS ) );
							webStandBy = Convert.ToString ( k.GetValue( InfraSoftwareServer.webStandBy ) );
    					
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
			

			sw_linux.Close();

			#else

			if ( IsAppInstalled )
			{
				rem_registration();
			}
		
			RegistryKey regKey = Registry.LocalMachine;
			regKey = regKey.OpenSubKey ( st_win_uninstall, true );
		
			regKey.GetAccessControl();
			regKey = regKey.CreateSubKey (  InfraSoftwareServer.nameServer );
	
			regKey.SetValue ( "DisplayName", 					InfraSoftwareServer.nameServer	);
			regKey.SetValue ( "UninstallString", 			st_uninstallString	);
			regKey.SetValue ( "st_version", 				st_version	);
	
			regKey.SetValue ( "nameServer", nameServer);
			regKey.SetValue ( "db_schema", db_schema);
			regKey.SetValue ( "pathDir", pathDir);
			regKey.SetValue ( "db_choice", db_choice);
			regKey.SetValue ( "slaveOnly", slaveOnly);
			regKey.SetValue ( "db_machine", db_machine);
			regKey.SetValue ( "maxPacket", maxPacket);
			regKey.SetValue ( "clientServerPort", clientServerPort);
			regKey.SetValue ( "user", user);
			regKey.SetValue ( "password", password);
			regKey.SetValue ( "db_port", db_port);
			regKey.SetValue ( "upgradePath", upgradePath);
			regKey.SetValue ( "language", language);
			regKey.SetValue ( "standBy", standBy);
			regKey.SetValue ( "standByPort", standByPort);
			regKey.SetValue ( "failFS", failFS);
			regKey.SetValue ( "webStandBy", webStandBy);
	
			regKey.Close();
	     		    
			#endif
	     		    
			return true;
		}
	
		public void rem_registration ( )
		{
			RegistryKey regKey = Registry.LocalMachine;
			regKey = regKey.OpenSubKey ( st_win_uninstall, true );
		
			regKey.GetAccessControl();
			regKey.DeleteSubKeyTree ( InfraSoftwareServer.nameServer );
		
			regKey.Close();
		}
	
		public string getStartMenu()
		{
			RegistryKey regKey = Registry.LocalMachine;
			regKey = regKey.OpenSubKey ( st_win_start_menu );
			
			return Convert.ToString ( regKey.GetValue("Common Programs") );
		}
	}
}
