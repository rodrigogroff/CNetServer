using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgCancelaDespesa
	{
		public event_dlgCancelaDespesa ev_layer;
		
		public dlgCancelaDespesa ( event_dlgCancelaDespesa par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgCancelaDespesaLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgCancelaDespesa.event_Load, null );
		}
		
		void BtnCancelarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgCancelaDespesa.event_Cancelar, null );
		}
	}
}

