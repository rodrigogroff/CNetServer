using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

using System.Drawing.Printing;

namespace Client
{
	public partial class dlgFinalGift
	{
		public event_dlgFinalGift ev_layer;
		
		public dlgFinalGift ( event_dlgFinalGift par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgFinalGiftLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgFinalGift.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgFinalGift.event_Confirmar, null );
		}
		
		public void Inven_Report ( object sender, PrintPageEventArgs e )
        {
			ev_layer.doEvent ( event_dlgFinalGift.event_Print, e );           
        }
	}
}

