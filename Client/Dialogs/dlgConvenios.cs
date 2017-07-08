using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgConvenios
	{
		public event_dlgConvenios ev_layer;
		
		public dlgConvenios ( event_dlgConvenios par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void BtnAdicionarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConvenios.event_Adicionar, null );
		}
		
		void BtnRemoverClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConvenios.event_Remover, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConvenios.event_Confirmar, null );
		}
		
		void DlgConveniosLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConvenios.event_Load, null );
		}
		
		void LstConveniosClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConvenios.event_Convenio, null );
		}
	}
}

