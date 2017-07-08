using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgHabilitarCartao
	{
		public event_dlgHabilitarCartao ev_layer;
		
		public dlgHabilitarCartao ( event_dlgHabilitarCartao par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgHabilitarCartao.event_Confirmar, null );
		}
		
		void DlgHabilitarCartaoLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgHabilitarCartao.event_Load, null );
		}
	}
}

