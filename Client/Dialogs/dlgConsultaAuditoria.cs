using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgConsultaAuditoria
	{
		public event_dlgConsultaAuditoria ev_layer;
		
		public dlgConsultaAuditoria ( event_dlgConsultaAuditoria par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgConsultaAuditoriaLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConsultaAuditoria.event_Load, null );
		}
		
		void BtnConsultarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConsultaAuditoria.event_Consultar, null );
		}
	}
}

