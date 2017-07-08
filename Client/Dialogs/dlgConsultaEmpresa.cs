using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgConsultaEmpresa
	{
		public event_dlgConsultaEmpresa ev_layer;
		
		public dlgConsultaEmpresa ( event_dlgConsultaEmpresa par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgConsultaEmpresaLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConsultaEmpresa.event_Load, null );
		}
		
		void BtnConsultarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConsultaEmpresa.event_Consultar, null );
		}
		
		void LstEmpresasDoubleClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConsultaEmpresa.event_Editar, null );
		}
		
		void BtnCancelarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConsultaEmpresa.event_Cancelar, null );
		}
	}
}

