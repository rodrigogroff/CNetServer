using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgFatExtra
	{
		public event_dlgFatExtra ev_layer;
		
		public dlgFatExtra ( event_dlgFatExtra par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
				
		void DlgFatExtraLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgFatExtra.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgFatExtra.event_Confirmar, null );
		}
	}	
}

