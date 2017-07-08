using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgFatRel
	{
		public event_dlgFatRel ev_layer;
		
		public dlgFatRel ( event_dlgFatRel par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgFatRelLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgFatRel.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgFatRel.event_Confirmar, null );
		}
	}
}

