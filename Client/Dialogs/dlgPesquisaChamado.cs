using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

using System.Drawing.Printing;

namespace Client
{
	public partial class dlgPesquisaChamado
	{
		public event_dlgPesquisaChamado ev_layer;
		
		public dlgPesquisaChamado ( event_dlgPesquisaChamado par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgPesquisaChamadoLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgPesquisaChamado.event_Load, null );
		}
		
		void BtnProcurarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgPesquisaChamado.event_Procurar, null );
		}
		
		void LstChamadosDoubleClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgPesquisaChamado.event_Editar, null );
		}
		
		void BtnReportClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgPesquisaChamado.event_Relatorio, null );
		}
	}
}

