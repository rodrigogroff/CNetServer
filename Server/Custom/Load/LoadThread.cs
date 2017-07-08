using System;
using System.Threading;
using System.Windows.Forms;
using SyCrafEngine;

namespace SyCrafEngine
{
	public class LoadThread
	{
		string			var_connect_string 	= "";
		string			var_transaction 	= "";
		int 			var_pos 			= 0;
		
		Thread 	workThread;
		Thread 	workThreadTimer;
		
		DateTime  work_time = new DateTime();
		
		public bool StopTimer = false;
		public ListViewItem 	var_lstResults;
		public string var_time = "";
		
		public LoadThread ( string connect_string, ref ListViewItem lstResults, int pos, string transaction )
		{
			var_connect_string = connect_string;
			var_lstResults     = lstResults;
			var_pos 		   = pos;
			var_transaction	   = transaction;
		}
		
		public void Run()
		{
			work_time = DateTime.Now;
			
			workThreadTimer = new Thread ( new ThreadStart ( ProcessTimer ));
			workThreadTimer.Start();
			
			workThread = new Thread ( new ThreadStart ( Process ));
			workThread.Start();
		}
		
		public void Process()
		{
			#if LOAD
			LoadAutomated  loadSuite = new LoadAutomated ( var_connect_string, ref var_lstResults, var_pos, var_transaction );
			StopTimer = true;
			#endif
		}
		
		public void ProcessTimer()
		{
			while (!StopTimer)
			{
				double seconds = -work_time.Subtract ( DateTime.Now ).TotalSeconds;
				
				int hours      = (int) seconds/3600;
				int minutes    = (int) seconds/60;
				int i_seconds  = (int) seconds - ( (hours * 3600) + (minutes * 60) );
			
				var_time  = 	hours.ToString().PadLeft(2,'0') + ":" +
								minutes.ToString().PadLeft(2,'0') + ":" +
								i_seconds.ToString().PadLeft(2,'0');
				
				var_lstResults.SubItems[3].Text = var_time;
				Application.DoEvents();
				
				Thread.Sleep (1000);
			}
		}
	}
}
