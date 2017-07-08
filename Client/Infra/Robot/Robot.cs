using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class Robot : Form
	{
		RobotEngine  rb_Engine;
		
		public Robot ( RobotEngine  rb )
		{
			InitializeComponent();
			
			rb_Engine  = rb;
			int commands  = rb_Engine.getCommands();
			ArrayList tmp = rb_Engine.getConfigList();
			
			for (int t=0; t < tmp.Count; ++t )
			{
				lstJobs.Items.Add ( tmp[t] as string );
			}
			
			lblAvail.Text = "Available jobs (" +  tmp.Count + ") commands (" + commands.ToString()+ ")";
			
			ArrayList tmp_cover = rb_Engine.getCoverage ();
			
			for (int t=0; t < tmp_cover.Count; ++t)
			{
				lstCoverage.Items.Add ( tmp_cover[t] as string );
			}
			
			numDelay.Value = 350;
		}
		
		void RobotFormClosing(object sender, FormClosingEventArgs e)
		{
			rb_Engine.var_exchange.m_Client.ExitSession();
		}
		
		void BtnAllClick(object sender, EventArgs e)
		{
			btnAll.Enabled = false;
			
			Application.DoEvents();
			
			for (int t=0; t < lstJobs.Items.Count; ++t )
			{
				lstJobs.SelectedIndex = t;
				Application.DoEvents();
				
				LstJobsDoubleClick ( null, null );
			
				ArrayList tmp = rb_Engine.getCoverage ();
				
				lstCoverage.Items.Clear();
				for (int g=0; g < tmp.Count; ++g)
				{
					lstCoverage.Items.Add ( tmp[g] as string );
				}
				Application.DoEvents();
			}		
			
			btnAll.Enabled = true;
			
			lstJobs.SelectedIndex = -1;
		}
		
		void LstJobsDoubleClick(object sender, EventArgs e)
		{
			if ( lstJobs.SelectedItem == null )
				return;
			
			rb_Engine.execJob ( lstJobs.SelectedItem.ToString(), 
			                   	ref lstRobotScript, 
			                   	Convert.ToInt32 ( numDelay.Value ), 
			                   	chkEnabled.Checked );
			
			ArrayList tmp = rb_Engine.getCoverage ();
			
			lstCoverage.Items.Clear();
			for (int t=0; t < tmp.Count; ++t)
			{
				lstCoverage.Items.Add ( tmp[t] as string );
			}
			Application.DoEvents();
		}
		
		void ChkDisableCheckedChanged(object sender, EventArgs e)
		{
			lstRobotScript.Enabled = chkEnabled.Checked;
		}
	}
}
