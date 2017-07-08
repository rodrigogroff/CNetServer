using System;
using System.Threading;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace SyCrafEngine
{
	public partial class LoadInterface : Form
	{
		InstallData var_data 	= new InstallData();
		ArrayList 	lst_runs    = new ArrayList();
		
		System.Windows.Forms.Timer  var_tim = new System.Windows.Forms.Timer();
		
		int 	indexRun   = 0;
		
		string 	connString = "";
		
		public LoadInterface()
		{
			InitializeComponent();
			
			connString = IServAppHandle.getConnString ( var_data.db_machine,
												    	InfraSoftwareServer.db_schema,
												       	var_data.user,
												     	var_data.password,
												     	Convert.ToInt32 ( var_data.db_port ),
												     	Convert.ToInt32 ( var_data.db_choice ) );
			
			var_tim.Interval = 1000;
			var_tim.Tick += time_up;
			var_tim.Start();
		}
		
		void BtnRunClick(object sender, EventArgs e)
		{
			BtnRun.Enabled = false;
			
			int max = Convert.ToInt32 ( numThreads.Value );
			
			ArrayList lst_threads = new ArrayList();
			
			LstThreads.Items.Clear();
			
			for ( int t=1; t <= max; ++t)
			{
				ListViewItem item = new ListViewItem();
				item.SubItems[0].Text = t.ToString();
				
				item.SubItems.Add ( "0.00 %" );
				item.SubItems.Add ( "0,0 ms" );
				item.SubItems.Add ( "00:00:00" );				
					
				LstThreads.Items.Add ( item );
				
				LoadThread   myLoadThread 	= new LoadThread ( connString, ref item, t, TxtTransaction.Text );
				lst_threads.Add ( myLoadThread );
			}
			
			lst_runs.Add ( lst_threads );
			
			for (int t=0; t < lst_threads.Count; ++t )
			{
				LoadThread   myLoadThread = lst_threads [t] as LoadThread;
				
				myLoadThread.Run();				
			}
		}
		
		void time_up (object sender, EventArgs e)
		{
			Application.DoEvents();
			
			if ( IsFinished () )
				UpdateReport();
		}
		
		public void UpdateReport()
		{
			ArrayList lst_threads = lst_runs [ indexRun ] as ArrayList;
			
			double total  = 0;
			double lowest = 0;
			double avg    = 0;
			
			ListViewItem 	var_item = null;
			
			for (int t=0; t < lst_threads.Count; ++t )
			{
				LoadThread   myLoadThread = lst_threads [t] as LoadThread;
				
				double tmp = Convert.ToDouble ( myLoadThread.var_lstResults.Tag );
				
				if ( lowest < tmp ) 
				{
					lowest = tmp;
					var_item = myLoadThread.var_lstResults;
				}
				
				total += tmp;
			}			
			
			avg = total / lst_threads.Count;
			
			ListViewItem item = new ListViewItem();
			
			item.SubItems[0].Text = lst_threads.Count.ToString();
			
			item.SubItems.Add ( String.Format( "{0:n}", lowest ) 	);	// Lowest
			item.SubItems.Add ( String.Format( "{0:n}", avg    ) 	);	// Average
			item.SubItems.Add ( var_item.SubItems[3].Text 			);	// Max Time
			
			LstReport.Items.Add ( item );

			BtnRun.Enabled = true;
			
			indexRun++;
		}
		
		public bool IsFinished ()
		{
			if ( lst_runs.Count ==  indexRun )
				return false;
			
			ArrayList lst_threads = lst_runs [ indexRun ] as ArrayList;
			
			if ( lst_threads == null )
				return false;
			
			bool IsDone = true;
			
			for (int t=0; t < lst_threads.Count; ++t )
			{
				LoadThread   myLoadThread = lst_threads [t] as LoadThread;
				
				if ( !myLoadThread.StopTimer )
				{
					IsDone = false;
					break;
				}
			}
			
			return IsDone;
		}
		
		void LoadInterfaceFormClosing(object sender, FormClosingEventArgs e)
		{
			if ( BtnRun.Enabled == false )
				if ( !IsFinished () )
					e.Cancel  = true;
		}
	}
}
