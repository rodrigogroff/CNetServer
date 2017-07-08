using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgSelecionaFilial
	{
		public event_dlgSelecionaFilial ev_layer;
		
		public dlgSelecionaFilial ( event_dlgSelecionaFilial par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		public void dlgSelecionaFilialLoad ( object sender, EventArgs e )
		{
			ev_layer.doEvent ( event_dlgSelecionaFilial.event_Load, null );
		}
	}
}

