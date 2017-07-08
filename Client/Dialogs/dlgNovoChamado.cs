using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgNovoChamado
	{
		public event_dlgNovoChamado ev_layer;
		
		public dlgNovoChamado ( event_dlgNovoChamado par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgNovoChamadoLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgNovoChamado.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgNovoChamado.event_Confirmar, null );
		}
	}
}

