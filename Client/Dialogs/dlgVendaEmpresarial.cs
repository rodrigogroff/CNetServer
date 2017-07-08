using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

using System.Drawing.Printing;

namespace Client
{
	public partial class dlgVendaEmpresarial
	{
		public event_dlgVendaEmpresarial ev_layer;
		
		public dlgVendaEmpresarial ( event_dlgVendaEmpresarial par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgVendaEmpresarialLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgVendaEmpresarial.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgVendaEmpresarial.event_Confirmar, null );
		}
		
		public void Inven_Report ( object sender, PrintPageEventArgs e )
        {
			ev_layer.doEvent ( event_dlgVendaEmpresarial.event_Print, e );           
        }
	}
}

