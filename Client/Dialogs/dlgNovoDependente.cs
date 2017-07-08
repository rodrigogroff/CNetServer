using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgNovoDependente
	{
		public event_dlgNovoDependente ev_layer;
		
		public dlgNovoDependente ( event_dlgNovoDependente par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgNovoDependenteLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgNovoDependente.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgNovoDependente.event_Confirmar, null );
		}
	}
}

