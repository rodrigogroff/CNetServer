using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgCustoChamado
	{
		public event_dlgCustoChamado ev_layer;
		
		public dlgCustoChamado ( event_dlgCustoChamado par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}

		void DlgCustoChamadoLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgCustoChamado.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgCustoChamado.event_Confirmar, null );
		}
	}
}

