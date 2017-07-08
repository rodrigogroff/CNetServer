using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgVendaParcelada
	{
		public event_dlgVendaParcelada ev_layer;
		
		public dlgVendaParcelada ( event_dlgVendaParcelada par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgVendaParceladaLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgVendaParcelada.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgVendaParcelada.event_Confirmar, null );
		}
		
		void LstParcsClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgVendaParcelada.event_LstClick, null );
		}
	}
}

