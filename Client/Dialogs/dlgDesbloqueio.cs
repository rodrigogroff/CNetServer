using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgDesbloqueio
	{
		public event_dlgDesbloqueio ev_layer;
		
		public dlgDesbloqueio ( event_dlgDesbloqueio par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgDesbloqueioLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgDesbloqueio.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgDesbloqueio.event_Confirmar, null );
		}
	}
}

