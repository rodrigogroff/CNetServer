using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgFaturamento
	{
		public event_dlgFaturamento ev_layer;
		
		public dlgFaturamento ( event_dlgFaturamento par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgFaturamentoLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgFaturamento.event_Load, null );
		}
	}
}

