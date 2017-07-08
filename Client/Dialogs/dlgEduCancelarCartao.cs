using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgEduCancelarCartao
	{
		public event_dlgEduCancelarCartao ev_layer;
		
		public dlgEduCancelarCartao ( event_dlgEduCancelarCartao par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void BtnCancelarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgEduCancelarCartao.event_Cancelar, null );
		}
		
		void DlgEduCancelarCartaoLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgEduCancelarCartao.event_Load, null );
		}
	}
}

