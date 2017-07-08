using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgLimiteCartao
	{
		public event_dlgLimiteCartao ev_layer;
		
		public dlgLimiteCartao ( event_dlgLimiteCartao par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgLimiteCartaoLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgLimiteCartao.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgLimiteCartao.event_Confirmar, null );
		}
		
		void LstCartoesClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgLimiteCartao.event_Click, null );
		}
	}
}

