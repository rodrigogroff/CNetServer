using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

using System.Drawing.Printing;

namespace Client
{
	public partial class dlgVendaLojista
	{
		public event_dlgVendaLojista ev_layer;
		
		public dlgVendaLojista ( event_dlgVendaLojista par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgVendaLojistaLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgVendaLojista.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgVendaLojista.event_Confirmar, null );
		}
		
		public void Inven_Report ( object sender, PrintPageEventArgs e )
        {
			ev_layer.doEvent ( event_dlgVendaLojista.event_Print, e );           
        }
		
		void BtnDivisaoClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgVendaLojista.event_Definir, e );           
		}
	}
}

