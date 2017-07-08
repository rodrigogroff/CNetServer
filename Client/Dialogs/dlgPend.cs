using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgPend
	{
		public event_dlgPend ev_layer;
		
		public dlgPend ( event_dlgPend par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		public void dlgPendLoad ( object sender, EventArgs e )
		{
			ev_layer.doEvent ( event_dlgPend.event_Load, null );
		}
	}
}

