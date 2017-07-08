using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgManutencaoUsuario
	{
		public event_dlgManutencaoUsuario ev_layer;
		
		public dlgManutencaoUsuario ( event_dlgManutencaoUsuario par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgManutencaoUsuarioLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgManutencaoUsuario.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgManutencaoUsuario.event_Confirmar, null );
		}
		
		void BtnDetalhesClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgManutencaoUsuario.event_Detalhes, null );
		}
	}
}

