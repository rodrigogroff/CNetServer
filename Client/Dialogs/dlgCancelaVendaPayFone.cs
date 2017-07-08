using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgCancelaVendaPayFone
	{
		public event_dlgCancelaVendaPayFone ev_layer;
		
		public dlgCancelaVendaPayFone ( event_dlgCancelaVendaPayFone par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgCancelaVendaPayFoneLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgCancelaVendaPayFone.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgCancelaVendaPayFone.event_Confirmar, null );
		}
	}
}

