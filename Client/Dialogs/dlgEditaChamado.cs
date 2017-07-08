using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgEditaChamado
	{
		public event_dlgEditaChamado ev_layer;
		
		public dlgEditaChamado ( event_dlgEditaChamado par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgEditaChamadoLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgEditaChamado.event_Load, null );
		}
		
		void BtnAlterarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgEditaChamado.event_Alterar, null );
		}
	}
}

