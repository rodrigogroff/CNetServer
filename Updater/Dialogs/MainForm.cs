using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class MainForm
	{
		public event_MainForm ev_layer;
				
		public MainForm ( event_MainForm par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;		
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_FormIsClosing,  null );
		}
	}
}
