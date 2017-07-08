using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgPrevLojista
	{
		public event_dlgPrevLojista ev_layer;
		
		public dlgPrevLojista ( event_dlgPrevLojista par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgPrevLojistaLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgPrevLojista.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgPrevLojista.event_Confirmar, null );
		}
	}
}

