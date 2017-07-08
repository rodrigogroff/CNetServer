using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

using System.Drawing.Printing;

namespace Client
{
	public partial class dlgReimpGift
	{
		public event_dlgReimpGift ev_layer;
		
		public dlgReimpGift ( event_dlgReimpGift par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgReimpGiftLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgReimpGift.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgReimpGift.event_Confirmar, null );
		}
		
		public void Inven_Report ( object sender, PrintPageEventArgs e )
        {
			ev_layer.doEvent ( event_dlgReimpGift.event_Print, e );           
        }
	}
}

