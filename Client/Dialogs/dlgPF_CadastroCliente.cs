using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgPF_CadastroCliente
	{
		public event_dlgPF_CadastroCliente ev_layer;
		
		public dlgPF_CadastroCliente ( event_dlgPF_CadastroCliente par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgPF_CadastroClienteLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgPF_CadastroCliente.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgPF_CadastroCliente.event_Confirmar, null );
		}
	}
}

