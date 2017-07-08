using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgDadosCadastrais
	{
		public event_dlgDadosCadastrais ev_layer;
		
		public dlgDadosCadastrais ( event_dlgDadosCadastrais par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgDadosCadastraisLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgDadosCadastrais.event_Load, null );
		}
		
		void BtnAlterarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgDadosCadastrais.event_Alterar, null );
		}
	}
}

