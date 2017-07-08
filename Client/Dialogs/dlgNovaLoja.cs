using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgNovaLoja
	{
		public event_dlgNovaLoja ev_layer;
		
		public dlgNovaLoja ( event_dlgNovaLoja par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgNovaLojaLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgNovaLoja.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgNovaLoja.event_Confirmar, null );
		}
		
		void BtnBloqClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgNovaLoja.event_Bloq, null );
		}
		
		void BtnDesbloqClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgNovaLoja.event_Desbloq, null );
		}
		
		void BtnCancelarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgNovaLoja.event_Cancelar, null );
		}
	}
}

