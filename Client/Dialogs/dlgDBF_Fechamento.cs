using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgDBF_Fechamento
	{
		public event_dlgDBF_Fechamento ev_layer;
		
		public dlgDBF_Fechamento ( event_dlgDBF_Fechamento par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgDBF_FechamentoLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgDBF_Fechamento.event_Load, null );
		}
		
		void BtnProcurarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgDBF_Fechamento.event_Procurar, null );
		}
	}
}

