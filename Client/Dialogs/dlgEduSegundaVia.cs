using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgEduSegundaVia
	{
		public event_dlgEduSegundaVia ev_layer;
		
		public dlgEduSegundaVia ( event_dlgEduSegundaVia par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgEduSegundaViaLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgEduSegundaVia.event_Load, null );
		}
		
		void BtnEmitirClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgEduSegundaVia.event_Emitir, null );
		}
	}
}

