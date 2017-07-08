using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgConfirmarRepasse
	{
		public event_dlgConfirmarRepasse ev_layer;
		
		public dlgConfirmarRepasse ( event_dlgConfirmarRepasse par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgConfirmarRepasseLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConfirmarRepasse.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConfirmarRepasse.event_Confirmar, null );
		}
		
		void ListView1ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			ev_layer.doEvent ( event_dlgConfirmarRepasse.event_DetalheCheck, null );
		}
		
		void LstLojasClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConfirmarRepasse.event_SelecionaLoja, null );
		}
	}
}

