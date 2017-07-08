using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgVendaOffline
	{
		public event_dlgVendaOffline ev_layer;
		
		public dlgVendaOffline ( event_dlgVendaOffline par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		public void dlgVendaOfflineLoad ( object sender, EventArgs e )
		{
			ev_layer.doEvent ( event_dlgVendaOffline.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgVendaOffline.event_BtnConfirmarClick, null );
		}
	}
}

