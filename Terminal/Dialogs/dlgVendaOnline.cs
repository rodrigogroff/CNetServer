using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgVendaOnline
	{
		public event_dlgVendaOnline ev_layer;
		
		public dlgVendaOnline ( event_dlgVendaOnline par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		public void dlgVendaOnlineLoad ( object sender, EventArgs e )
		{
			ev_layer.doEvent ( event_dlgVendaOnline.event_Load, null );
		}
	}
}

