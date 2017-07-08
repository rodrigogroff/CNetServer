using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgRecargaGift
	{
		public event_dlgRecargaGift ev_layer;
		
		public dlgRecargaGift ( event_dlgRecargaGift par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}	
		
		void DlgRecargaGiftLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgRecargaGift.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgRecargaGift.event_Confirmar, null );
		}
		
		void Calendar1SelectionChanged(object sender, EventArgs e)
		{
			
		}
	}
}

