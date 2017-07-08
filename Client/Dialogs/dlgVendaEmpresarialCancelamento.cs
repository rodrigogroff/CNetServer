using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgVendaEmpresarialCancelamento
	{
		public event_dlgVendaEmpresarialCancelamento ev_layer;
		
		public dlgVendaEmpresarialCancelamento ( event_dlgVendaEmpresarialCancelamento par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgVendaEmpresarialCancelamentoLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgVendaEmpresarialCancelamento.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgVendaEmpresarialCancelamento.event_Confirmar, null );
		}
	}
}

