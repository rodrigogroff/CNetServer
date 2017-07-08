using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgObservacao
	{
		public event_dlgObservacao ev_layer;
		
		public dlgObservacao ( event_dlgObservacao par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgObservacaoLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgObservacao.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgObservacao.event_Confirmar, null );
		}
		
		void DlgObservacaoFormClosing(object sender, FormClosingEventArgs e)
		{
			ev_layer.doEvent ( event_dlgObservacao.event_FormIsClosing, e );
		}
	}
}

