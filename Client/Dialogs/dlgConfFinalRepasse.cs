using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

using System.Drawing.Printing;

namespace Client
{
	public partial class dlgConfFinalRepasse
	{
		public event_dlgConfFinalRepasse ev_layer;
		
		public dlgConfFinalRepasse ( event_dlgConfFinalRepasse par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgConfFinalRepasseLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConfFinalRepasse.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConfFinalRepasse.event_Confirmar, null );
		}
		
		public void Inven_Report ( object sender, PrintPageEventArgs e )
        {
			ev_layer.doEvent ( event_dlgConfFinalRepasse.event_Print, e );           
        }
	}
}

