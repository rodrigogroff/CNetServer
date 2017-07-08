using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgResPend
	{
		public event_dlgResPend ev_layer;
		
		public dlgResPend ( event_dlgResPend par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgResPend.event_Confirmar, null );
		}
		
		void DlgResPendLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgResPend.event_Load, null );
		}
		
		void BtnCancelarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgResPend.event_Cancelar, null );
		}
	}
}

