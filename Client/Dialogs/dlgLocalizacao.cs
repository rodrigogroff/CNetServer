using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgLocalizacao
	{
		public event_dlgLocalizacao ev_layer;
		
		public dlgLocalizacao ( event_dlgLocalizacao par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgLocalizacaoLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgLocalizacao.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgLocalizacao.event_Confirmar, null );
		}
	}
}

