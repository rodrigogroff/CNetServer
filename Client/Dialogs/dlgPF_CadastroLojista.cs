using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgPF_CadastroLojista
	{
		public event_dlgPF_CadastroLojista ev_layer;
		
		public dlgPF_CadastroLojista ( event_dlgPF_CadastroLojista par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgPF_CadastroLojistaLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgPF_CadastroLojista.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgPF_CadastroLojista.event_Confirmar, null );
		}
	}
}

