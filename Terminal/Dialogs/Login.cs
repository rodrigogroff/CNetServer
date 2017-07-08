using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class Login
	{
		public event_Login ev_layer;
		
		public Login ( event_Login par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		public void LoginLoad ( object sender, EventArgs e )
		{
			ev_layer.doEvent ( event_Login.event_Load, null );
		}
	}
}

