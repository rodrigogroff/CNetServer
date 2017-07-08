using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgSegundaVia
	{
		public event_dlgSegundaVia ev_layer;
		
		public dlgSegundaVia ( event_dlgSegundaVia par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgSegundaViaLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgSegundaVia.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgSegundaVia.event_Confirmar, null );
		}
	}
}

