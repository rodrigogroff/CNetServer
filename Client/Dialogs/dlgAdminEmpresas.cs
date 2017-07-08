using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgAdminEmpresas
	{
		public event_dlgAdminEmpresas ev_layer;
		
		public dlgAdminEmpresas ( event_dlgAdminEmpresas par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgAdminEmpresasLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgAdminEmpresas.event_Load, null );
		}
		
		void BtnRemoverClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgAdminEmpresas.event_Remover, null );
		}
		
		void BtnVincularClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgAdminEmpresas.event_Adicionar, null );
		}
	}
}

