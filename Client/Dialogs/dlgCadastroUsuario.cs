using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgCadastroUsuario
	{
		public event_dlgCadastroUsuario ev_layer;
		
		public dlgCadastroUsuario ( event_dlgCadastroUsuario par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgCadastroUsuarioLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgCadastroUsuario.event_Load, e );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgCadastroUsuario.event_Confirmar, e );
		}
	}
}

