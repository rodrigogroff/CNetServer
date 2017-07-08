using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgCadastroAtividade
	{
		public event_dlgCadastroAtividade ev_layer;
		
		public dlgCadastroAtividade ( event_dlgCadastroAtividade par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgCadastroAtividadeLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgCadastroAtividade.event_Load, null );				
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgCadastroAtividade.event_Confirmar, null );				
		}
	}
}

