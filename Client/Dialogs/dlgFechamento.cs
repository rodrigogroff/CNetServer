using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgFechamento
	{
		public event_dlgFechamento ev_layer;
		
		public dlgFechamento ( event_dlgFechamento par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgFechamentoLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgFechamento.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgFechamento.event_Confirmar, null );
		}
		
		void BtnDBFClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgFechamento.event_BDF, null );
		}
	}
}

