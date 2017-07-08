using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgAlterarSenhaCartao
	{
		public event_dlgAlterarSenhaCartao ev_layer;
		
		public dlgAlterarSenhaCartao ( event_dlgAlterarSenhaCartao par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgAlterarSenhaCartao.event_Confirmar, null );
		}
		
		void DlgAlterarSenhaCartaoLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgAlterarSenhaCartao.event_Load, null );			
		}
	}
}

