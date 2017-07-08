using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgPassword
	{
		public event_dlgPassword ev_layer;
		
		public dlgPassword ( event_dlgPassword par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
			
		void DlgPasswordLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgPassword.event_Load, e );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgPassword.event_Confirmar, e );
		}
	}
}

