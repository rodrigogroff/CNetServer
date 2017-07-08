using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgSelecionaEmpresa
	{
		public event_dlgSelecionaEmpresa ev_layer;
		
		public dlgSelecionaEmpresa ( event_dlgSelecionaEmpresa par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgSelecionaEmpresaLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgSelecionaEmpresa.event_Load, null );			
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgSelecionaEmpresa.event_Confirmar, null );			
		}
	}
}

