using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgCompensaCheque
	{
		public event_dlgCompensaCheque ev_layer;
		
		public dlgCompensaCheque ( event_dlgCompensaCheque par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgCompensaChequeLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgCompensaCheque.event_Load, null );
		}
		
		void BtnCancelarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgCompensaCheque.event_Cancelar, null );
		}
		
		void BtnCompensarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgCompensaCheque.event_Compensar, null );
		}
	}
}

