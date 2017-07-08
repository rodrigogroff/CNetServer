using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgConsultaTransacoes
	{
		public event_dlgConsultaTransacoes ev_layer;
		
		public dlgConsultaTransacoes ( event_dlgConsultaTransacoes par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgConsultaTransacoesLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConsultaTransacoes.event_Load, null );
		}
		
		void BtnConsultarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConsultaTransacoes.event_Confirmar, null );
		}
	}
}

