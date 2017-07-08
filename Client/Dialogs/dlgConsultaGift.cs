using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgConsultaGift
	{
		public event_dlgConsultaGift ev_layer;
		
		public dlgConsultaGift ( event_dlgConsultaGift par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgConsultaGiftLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConsultaGift.event_Load, null );
		}
	}
}

