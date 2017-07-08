using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgVerificaPendenciaPayFone
	{
		public event_dlgVerificaPendenciaPayFone ev_layer;
		
		public dlgVerificaPendenciaPayFone ( event_dlgVerificaPendenciaPayFone par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgVerificaPendenciaPayFoneLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgVerificaPendenciaPayFone.event_Load, null );
		}
		
		void BtnConfirmaClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgVerificaPendenciaPayFone.event_Confirmar, null );
		}
	}
}

