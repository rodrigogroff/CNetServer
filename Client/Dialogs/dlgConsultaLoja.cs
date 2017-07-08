using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

using System.Drawing.Printing;

namespace Client
{
	public partial class dlgConsultaLoja
	{
		public event_dlgConsultaLoja ev_layer;
		
		public dlgConsultaLoja ( event_dlgConsultaLoja par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgConsultaLojaLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConsultaLoja.event_Load, null );
		}
		
		void BtnConsultarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConsultaLoja.event_Consultar, null );
		}
		
		void LstLojasDoubleClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConsultaLoja.event_Editar, null );
		}
		
		void BtnRelatorioClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConsultaLoja.event_Report, null );
		}
	}
}

