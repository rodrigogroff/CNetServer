using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgLojista
	{
		public event_dlgLojista ev_layer;
		
		public dlgLojista ( event_dlgLojista par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgLojistaLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgLojista.event_Load, null );
		}
		
		void BtnVincularClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgLojista.event_Vincular, null );
		}
	}
}

