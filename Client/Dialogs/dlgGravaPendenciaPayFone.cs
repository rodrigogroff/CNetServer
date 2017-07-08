using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgGravaPendenciaPayFone
	{
		public event_dlgGravaPendenciaPayFone ev_layer;
		
		public dlgGravaPendenciaPayFone ( event_dlgGravaPendenciaPayFone par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgGravaPendenciaPayFoneLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgGravaPendenciaPayFone.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgGravaPendenciaPayFone.event_Confirmar, null );
		}
	}
}

