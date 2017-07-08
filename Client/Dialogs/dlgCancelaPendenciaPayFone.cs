using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgCancelaPendenciaPayFone
	{
		public event_dlgCancelaPendenciaPayFone ev_layer;
		
		public dlgCancelaPendenciaPayFone ( event_dlgCancelaPendenciaPayFone par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgCancelaPendenciaPayFoneLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgCancelaPendenciaPayFone.event_Load, null );
		}
		
		void BtnCOnfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgCancelaPendenciaPayFone.event_Confirmar, null );
		}
	}
}

