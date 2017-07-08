using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgFatRecManual
	{
		public event_dlgFatRecManual ev_layer;
		
		public dlgFatRecManual ( event_dlgFatRecManual par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgFatRecManualLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgFatRecManual.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgFatRecManual.event_BtnConfirmar, null );
		}
	}
}

