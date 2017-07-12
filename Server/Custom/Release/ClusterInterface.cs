using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using ZedGraph;

namespace SyCrafEngine
{
	public partial class ClusterInterface : Form
	{
		InstallData		var_data = new InstallData();
		IServAppHandle 	app_handle;
		
		Translator 		var_translator;
		
		public ClusterInterface ( ref Translator trans )
		{
			InitializeComponent();
			
			string target_file = var_data.pathDir + "\\connection_stats.log";
			
			if ( File.Exists ( target_file ) )
				File.Delete ( target_file );
			
			target_file = var_data.pathDir + "\\load_stats.log";
			
			if ( File.Exists ( target_file ) )
				File.Delete ( target_file );
			
			target_file = var_data.pathDir + "\\cpu_stats.log";
			
			if ( File.Exists ( target_file ) )
				File.Delete ( target_file );
			
			target_file = var_data.pathDir + "\\scheduler.log";
			
			if ( File.Exists ( target_file ) )
				File.Delete ( target_file );
			
			BtnClientsClick ( null, null );
			
			var_translator = trans;
			
			app_handle = new IServAppHandle ( var_data.pathDir, ref var_translator );
			
			LoadParams();
			
			BtnPause.Enabled   = false;
			BtnBackup.Enabled  = true;
			BtnRestore.Enabled = true;
					
			tm_AppRefresh.Interval = 250;
			
			Text = app_handle.m_schema;
			
			refreshTitles();
			
			string schel_log = new SyCrafEngine.InstallData().pathDir + "\\log\\scheduler_log";
			
			if ( !Directory.Exists ( schel_log ) )
			{
				Directory.CreateDirectory ( schel_log );
			}
			
			string dir_watch = new SyCrafEngine.InstallData().pathDir + "\\proc";
			
			if ( !Directory.Exists ( dir_watch ) )
			{
				Directory.CreateDirectory ( dir_watch );
			}
			
			if ( !Directory.Exists ( dir_watch + "\\rejected" ) )
			{
				Directory.CreateDirectory ( dir_watch + "\\rejected" );
			}
			
			if ( !Directory.Exists ( dir_watch + "\\term" ) )
			{
				Directory.CreateDirectory ( dir_watch + "\\term" );
			}
		}
				
		public void LoadParams()
		{
			app_handle.m_connectionString    = IServAppHandle.getConnString ( 	var_data.db_machine,
																	     		InfraSoftwareServer.db_schema,
																         		var_data.user,
																	     		var_data.password,
																	     		Convert.ToInt32 ( var_data.db_port ),
																	     		Convert.ToInt32 ( var_data.db_choice ) );
			app_handle.m_DB_Machine 		 = var_data.db_machine;
			app_handle.m_schema				 = InfraSoftwareServer.db_schema;
			app_handle.m_language 			 = var_data.language;
			app_handle.m_clientServerPort 	 = Convert.ToInt32 ( var_data.clientServerPort );
			app_handle.m_max_packet_size 	 = Convert.ToInt32 ( var_data.maxPacket );
			
			app_handle.m_transDisp 			 = new ServerDispatcher();
			app_handle.m_recept				 = new ServerRecept();
			
			app_handle.m_master_server       = "";
			app_handle.m_standby_server	     = var_data.standBy;
			app_handle.m_standby_server_web	 = var_data.webStandBy;
			app_handle.m_standby_server_port = var_data.standByPort;
			app_handle.m_fail_fs			 = var_data.failFS;
		}
		
		void BtnStartClick(object sender, EventArgs e)
		{
			BtnBackup.Enabled = false;
			BtnRestore.Enabled = false;
			BtnStand.Enabled   = false;
			BtnStart.Enabled   = false;
			
			app_handle.setMaxThreads ( Convert.ToInt32 ( NumMaxThreads.Value ) );
			
			app_handle.RunMasterThread(true);
			tm_AppRefresh.Start();
			
			while ( ! app_handle.Is_ServerLoaded() )
			{
				Thread.Sleep(1);
				Application.DoEvents();
			}
			enableAll();
		}
		
		void BtnPauseClick(object sender, EventArgs e)
		{
			if ( app_handle.Is_ServerLoaded() )
			{
				if ( app_handle.Is_PauseTraffic() )
				{
					BtnPause.Text = "Pause";
					app_handle.cmd_Release();		
				}
				else
				{
					BtnPause.Text = "Release";
					app_handle.cmd_Pause();		
				}
			}
		}

		void enableAll()
		{
			BtnClients.Enabled 	= true;
			BtnCluster.Enabled 	= true;
			BtnCpu.Enabled     	= true;
			BtnLoad.Enabled    	= true;						
		}
				
		private void CreateGraph( ZedGraphControl zgc, ref PointPairList list, string title, string xAx, string yAx, string my_curve )
		{
			GraphPane myPane = zgc.GraphPane;

			// Set the titles and axis labels
			myPane.Title.Text = title;
			myPane.XAxis.Title.Text = xAx;
			myPane.YAxis.Title.Text = yAx;
			myPane.XAxis.Type = AxisType.Date;
			
			myPane.CurveList.Clear();

			// Generate a blue curve with circle symbols, and "My Curve 2" in the legend
			LineItem myCurve = myPane.AddCurve( my_curve, list, Color.Red, SymbolType.None );
		
			// Fill the area under the curve with a white-red gradient at 45 degrees
			myCurve.Line.Fill = new Fill( Color.White, Color.Red, 45F );
			// Make the symbols opaque by filling them with white
			myCurve.Symbol.Fill = new Fill( Color.White );
			
			myCurve.Line.IsAntiAlias = true;
						
			myCurve.Line.Fill = new Fill( Color.White, Color.FromArgb( 60, Color.Red.R, Color.Red.G, Color.Red.B ), 90F );
			
			// Fill the axis background with a color gradient
			myPane.Chart.Fill = new Fill( Color.White, Color.LightGoldenrodYellow, 45F );

			// Fill the pane background with a color gradient
			myPane.Fill = new Fill( Color.White, Color.FromArgb( 220, 220, 255 ), 45F );
			
			// Calculate the Axis Scale Ranges
			zgc.AxisChange();
			
			zgc.Location = new Point( zgc.Location.X, zgc.Location.Y );
			zgc.Size     = new Size( zgc.Size.Width, zgc.Size.Height );
			
			zgc.Refresh();
		}
		
		private void CreateGraph2( ZedGraphControl zgc, ref PointPairList list, ref PointPairList list2, string title, string xAx, string yAx, string my_curve, string my_curve2 )
		{
			GraphPane myPane = zgc.GraphPane;

			// Set the titles and axis labels
			myPane.Title.Text = title;
			myPane.XAxis.Title.Text = xAx;
			myPane.YAxis.Title.Text = yAx;
			myPane.XAxis.Type = AxisType.Date;
			
			myPane.CurveList.Clear();
			
			Color col = Color.Blue;

			{
				// Generate a blue curve with circle symbols, and "My Curve 2" in the legend
				LineItem myCurve = myPane.AddCurve( my_curve, list, col, SymbolType.None );
				
				// Fill the area under the curve with a white-red gradient at 45 degrees
				myCurve.Line.Fill = new Fill( Color.White, col, 45F );
				// Make the symbols opaque by filling them with white
				myCurve.Symbol.Fill = new Fill( Color.White );
	
				myCurve.Line.IsAntiAlias = true;
				//myCurve.Line.IsSmooth    = true;
				
				myCurve.Line.Fill = new Fill( Color.White, Color.FromArgb( 60, col.R, col.G, col.B ), 90F );
				
				// Fill the axis background with a color gradient
				myPane.Chart.Fill = new Fill( Color.White, Color.LightGoldenrodYellow, 45F );
	
				// Fill the pane background with a color gradient
				myPane.Fill = new Fill( Color.White, Color.FromArgb( 220, 220, 255 ), 45F );
			}
			
			col = Color.Gray;
			
			{
				// Generate a blue curve with circle symbols, and "My Curve 2" in the legend
				LineItem myCurve2 = myPane.AddCurve( my_curve2, list2, col, SymbolType.None );
				
				// Fill the area under the curve with a white-red gradient at 45 degrees
				myCurve2.Line.Fill = new Fill( Color.White, col, 45F );
				// Make the symbols opaque by filling them with white
				myCurve2.Symbol.Fill = new Fill( Color.White );
	
				myCurve2.Line.IsAntiAlias = true;
				//myCurve2.Line.IsSmooth    = true;
				
				myCurve2.Line.Fill = new Fill( Color.White, Color.FromArgb( 60, col.R, col.G, col.B ), 90F );
				
				// Fill the axis background with a color gradient
				myPane.Chart.Fill = new Fill( Color.White, Color.LightGoldenrodYellow, 45F );
				
				// Fill the pane background with a color gradient
				myPane.Fill = new Fill( Color.White, Color.FromArgb( 220, 220, 255 ), 45F );
			}
	
			// Calculate the Axis Scale Ranges
			zgc.AxisChange();
			
			zgc.Location = new Point( zgc.Location.X, zgc.Location.Y );
			zgc.Size =  new Size( zgc.Size.Width, zgc.Size.Height );
			
			zgc.Refresh();
		}
			
		void BtnClientsClick(object sender, EventArgs e)
		{
			PointPairList list = new PointPairList();
			
			if ( File.Exists ( var_data.pathDir + "\\connection_stats.log"  ) )
			{
				long lines = 0;
				
				{
					StreamReader st = new StreamReader ( var_data.pathDir + "\\connection_stats.log" );
					
					while ( !st.EndOfStream )
					{
						st.ReadLine();
						++lines;
					}
					
					st.Close();
				}
				
				{
					StreamReader st = new StreamReader ( var_data.pathDir + "\\connection_stats.log" );
					
					long start = lines - 60;
					
					// pega só ultimas 100 linhas
					while ( start > 0 )
					{
						st.ReadLine();
						--start;
					}
					
					while ( !st.EndOfStream )
					{
						string line        = st.ReadLine();
						string time        = line.Substring ( 11, 5 ).Replace ( ":", "," );
						string simultaneos = line.Substring ( 29,9 );
									
						XDate x = new XDate ( Convert.ToInt32 ( line.Substring ( 0, 4 ) ), // ano
						                      Convert.ToInt32 ( line.Substring ( 5, 2 ) ), // mes
						                      Convert.ToInt32 ( line.Substring ( 8, 2 ) ), // dia
											  Convert.ToInt32 ( line.Substring ( 11, 2 ) ), // hora
											  Convert.ToInt32 ( line.Substring ( 14, 2 ) ), 0, 0 ); // minuto
						
						list.Add ( (double) x, Convert.ToDouble ( simultaneos ) );
					}
					
					st.Close();
				}
			}
			
			CreateGraph ( zed, ref list, "Client access to server", "Time of day", "Incoming connections", "" );
		}
		
		void BtnLoadClick(object sender, EventArgs e)
		{
			PointPairList list = new PointPairList();
			PointPairList list2 = new PointPairList();
			
			if ( File.Exists ( var_data.pathDir + "\\load_stats.log"  ) )
			{
				long lines = 0;
				
				{
					StreamReader st = new StreamReader ( var_data.pathDir + "\\load_stats.log" );
					
					while ( !st.EndOfStream )
					{
						st.ReadLine();
						++lines;
					}
					
					st.Close();
				}
				
				{
					StreamReader st = new StreamReader ( var_data.pathDir + "\\load_stats.log" );
					
					long start = lines - 60;
					
					while ( start > 0 )
					{
						st.ReadLine();
						--start;
					}
					
					while ( !st.EndOfStream )
					{
						string line = st.ReadLine();
						
						XDate x = new XDate ( Convert.ToInt32 ( line.Substring ( 0, 4 ) ), // ano
						                      Convert.ToInt32 ( line.Substring ( 5, 2 ) ), // mes
						                      Convert.ToInt32 ( line.Substring ( 8, 2 ) ), // dia
											  Convert.ToInt32 ( line.Substring ( 11, 2 ) ), // hora
											  Convert.ToInt32 ( line.Substring ( 14, 2 ) ), 0, 0 ); // minuto
						
						string upload   = line.Substring ( 29,9 );
						string download = line.Substring ( 60,9 );
						
						list.Add  ( (double) x, Convert.ToDouble ( upload   ) );
						list2.Add ( (double) x, Convert.ToDouble ( download ) );
					}
					
					st.Close();
				}
			}
			
			CreateGraph2 ( zed, ref list, ref list2, "Load input/output to server", "Time of day", "download | upload bytes per sec", "upload", "download" );
		}
		
		void BtnCpuClick(object sender, EventArgs e)
		{
			PointPairList list = new PointPairList();
			PointPairList list2 = new PointPairList();
			
			if ( File.Exists ( var_data.pathDir + "\\cpu_stats.log"  ) )
			{
				long lines = 0;
				
				{
					StreamReader st = new StreamReader ( var_data.pathDir + "\\cpu_stats.log" );
					
					while ( !st.EndOfStream )
					{
						st.ReadLine();
						++lines;
					}
					
					st.Close();
				}
				
				{
					StreamReader st = new StreamReader ( var_data.pathDir + "\\cpu_stats.log" );
					
					long start = lines - 60;
					
					while ( start > 0 )
					{
						st.ReadLine();
						--start;
					}
					
					while ( !st.EndOfStream )
					{
						string line = st.ReadLine();
						
						int start_c = 0;
						int len_c = 0;
						
						for ( int t=0; t < line.Length; ++t )
						{
							if ( line[t] == '(' )
							{
								start_c = t + 1;
							}
							else if ( line[t] == '%' )
							{
								len_c = t - start_c;
								break;
							}
						}
						
						string idle     = line.Substring ( start_c, len_c );
						
						int par = 0;
						
						for ( int t=40; t < line.Length; ++t )
						{
							if ( line[t] == '(' )
							{
								++par;
								
								if ( par == 2 )
									start_c = t + 1;
							}
							else if ( line[t] == '%' )
							{
								len_c = t - start_c;
								break;
							}
						}
						
						string database = line.Substring ( start_c, len_c );
						
						XDate x = new XDate ( Convert.ToInt32 ( line.Substring ( 0, 4 ) ), // ano
						                      Convert.ToInt32 ( line.Substring ( 5, 2 ) ), // mes
						                      Convert.ToInt32 ( line.Substring ( 8, 2 ) ), // dia
											  Convert.ToInt32 ( line.Substring ( 11, 2 ) ), // hora
											  Convert.ToInt32 ( line.Substring ( 14, 2 ) ), 0, 0 ); // minuto
						
						
						list.Add  ( (double)x, Convert.ToDouble ( database   ) );
						list2.Add ( (double)x, Convert.ToDouble ( idle ) );
					}
					
					st.Close();
				}
			}
			
			CreateGraph2 ( zed, ref list, ref list2, "CPU usage from server", "Time of day", "Percentage %", "database", "idle" );
		}
		
		void BtnClusterClick(object sender, EventArgs e)
		{
			
		}
		
		void tm_AppRefreshTick(object sender, EventArgs e)
		{
			refreshTitles();
		}
		
		void refreshTitles()
		{
			lblVersion.Text = "Version: " + var_data.st_version;
			lblConfig.Text  = "Port: " 			 + app_handle.m_clientServerPort + 
				              " Database: " 	 + app_handle.m_DB_Machine + 
				              "(" 				 + app_handle.m_schema + ")";

			if ( app_handle.Is_ServerLoaded() )
			{
				if ( app_handle.Is_ServingStandBy() )
				{
					lblState.Text = "Standby (Replication)";
				}
				else
				{
					if ( app_handle.Is_StandByAvailable() )
						lblState.Text = "Online (Secure)";
					else
						lblState.Text = "Online (Non-Secure)";
				}
				
				if ( app_handle.Is_PauseTraffic() )
					lblMode.Text = "Master Mode (Paused)";
				else
					lblMode.Text = "Master Mode";
			
				lblNowStats.Text = "Active Clients: " + app_handle.getAliveConnections();
			}
			else
			{
				lblState.Text = "Offline";
				lblMode.Text = "";
				lblNowStats.Text = "";
			}
			Application.DoEvents();
		}
			
		void ClusterInterfaceFormClosing(object sender, FormClosingEventArgs e)
		{
			if ( MessageBox.Show("Stop '" + app_handle.m_schema + "' Server?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2 ) == DialogResult.No )
				e.Cancel = true;						
		}	
		
		void ClusterInterfaceFormClosed(object sender, FormClosedEventArgs e)
		{
			app_handle.cmd_Quit();
		}
		
		void BtnBackupClick(object sender, EventArgs e)
		{
			saveFileDialog1.Title = "Select your folder and backup name:";
			
			saveFileDialog1.FileName =  DateTime.Now.Year.ToString() 					+
										DateTime.Now.Month.ToString().PadLeft(2, '0') 					+ 
										DateTime.Now.Day.ToString().PadLeft(2, '0') 					+ 
										DateTime.Now.Hour.ToString().PadLeft(2, '0') 	+
										DateTime.Now.Minute.ToString().PadLeft(2, '0') 	+
										"_" + app_handle.m_schema + ".bkp";
			
			saveFileDialog1.Filter = "Backup files (*.bkp)|*.bkp";
			
			if ( saveFileDialog1.ShowDialog() == DialogResult.OK )
			{
				Backup bkp = new Backup ();
				
				string connection =  IServAppHandle.getConnString ( 	var_data.db_machine,
																	   	InfraSoftwareServer.db_schema,
																	   	var_data.user,
																		var_data.password,
																		Convert.ToInt32 ( var_data.db_port ),
																		Convert.ToInt32 ( var_data.db_choice ) );
				
				
				if ( saveFileDialog1.FileName != "" )
				{
					pgBackup.Visible 	= true;
						
					BtnStart.Enabled 	= false;
					BtnBackup.Enabled 	= false;
					BtnRestore.Enabled 	= false;
					
					LblBackup.Text = "Saving Database";
					Application.DoEvents();
					
					bkp.doBackup ( saveFileDialog1.FileName, connection, pgBackup );
					
					MessageBox.Show ( "Backup Completed!", "SYSTEM" );
					
					LblBackup.Text = "";
					
					pgBackup.Visible 	= false;
					BtnStart.Enabled 	= true;
					BtnBackup.Enabled 	= true;
					BtnRestore.Enabled 	= true;
				}
			}
		}
		
		void BtnRestoreClick(object sender, EventArgs e)
		{
			openFileDialog1.Title = "Select your backup file:";
			openFileDialog1.Filter = "Backup files (*.bkp)|*.bkp";
			openFileDialog1.FileName = "";
			
			if ( openFileDialog1.ShowDialog() == DialogResult.OK )
			{
				Backup bkp = new Backup ();
				
				string connection =  IServAppHandle.getConnString ( 	var_data.db_machine,
																	   	InfraSoftwareServer.db_schema,
																	   	var_data.user,
																		var_data.password,
																		Convert.ToInt32 ( var_data.db_port ),
																		Convert.ToInt32 ( var_data.db_choice ) );
				
				if ( openFileDialog1.FileName != "" )
				{
					pgBackup.Visible 	= true;
					
					BtnStart.Enabled 	= false;
					BtnBackup.Enabled 	= false;
					BtnRestore.Enabled 	= false;
					
					bkp.doRestore ( openFileDialog1.FileName, connection, pgBackup, LblBackup );
					
					MessageBox.Show ( "Restore Completed!", "SYSTEM" );
					
					LblBackup.Text = "";
					
					pgBackup.Visible 	= false;
					BtnStart.Enabled 	= true;
					BtnBackup.Enabled 	= true;
					BtnRestore.Enabled 	= true;
				}
			}
		}
		
		void NumMaxThreadsValueChanged(object sender, EventArgs e)
		{
			app_handle.setMaxThreads ( Convert.ToInt32 ( NumMaxThreads.Value ) );
		}
		
		void BtnStandClick(object sender, EventArgs e)
		{
			BtnBackup.Enabled  = false;
			BtnRestore.Enabled = false;
			BtnPause.Enabled   = false;
			BtnStart.Enabled   = false;
			BtnStand.Enabled   = false;
			
			app_handle.setMaxThreads ( Convert.ToInt32 ( NumMaxThreads.Value ) );
			
			app_handle.RunMasterThread( false );
			tm_AppRefresh.Start();
			
			while ( ! app_handle.Is_ServerLoaded() )
			{
				Thread.Sleep(1);
				Application.DoEvents();
			}
			enableAll();			
		}
	}
}
