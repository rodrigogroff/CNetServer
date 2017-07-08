using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgBloqueio
	{
		public event_dlgBloqueio ev_layer;
		
		public dlgBloqueio ( event_dlgBloqueio par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgBloqueioLoad ( object sender, EventArgs e )
		{
			ev_layer.doEvent ( event_dlgBloqueio.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgBloqueio.event_Confirmar, null );
		}
	}
}

