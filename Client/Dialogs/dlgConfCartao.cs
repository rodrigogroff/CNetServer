using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgConfCartao
	{
		public event_dlgConfCartao ev_layer;
		
		public dlgConfCartao ( event_dlgConfCartao par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgConfCartaoLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConfCartao.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConfCartao.event_Confirmar, null );
		}
	}
}

