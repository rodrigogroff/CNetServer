using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgCancelamento
	{
		public event_dlgCancelamento ev_layer;
		
		public dlgCancelamento ( event_dlgCancelamento par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		public void dlgCancelamentoLoad ( object sender, EventArgs e )
		{
			ev_layer.doEvent ( event_dlgCancelamento.event_Load, null );
		}
		
		void BtnCancelarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgCancelamento.event_BtnCancelarClick, null );
		}
	}
}

