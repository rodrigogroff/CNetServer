using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgNovaEmpresa
	{
		public event_dlgNovaEmpresa ev_layer;
		
		public dlgNovaEmpresa ( event_dlgNovaEmpresa par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgNovaEmpresaLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgNovaEmpresa.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgNovaEmpresa.event_Confirmar, null );
		}
		
		void BtnBloqClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgNovaEmpresa.event_BtnBloqClick, null );
		}
		
		void BtnDesbloqClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgNovaEmpresa.event_BtnDesbloqClick, null );
		}

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtHomepage_TextChanged(object sender, EventArgs e)
        {

        }
	}
}

