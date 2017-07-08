using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgAutorizaVendaPayFone
	{
		public event_dlgAutorizaVendaPayFone ev_layer;
		
		public dlgAutorizaVendaPayFone ( event_dlgAutorizaVendaPayFone par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgAutorizaVendaPayFoneLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgAutorizaVendaPayFone.event_Load, null );
		}
		
		void BntConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgAutorizaVendaPayFone.event_Confirmar, null );
		}
	}
}

