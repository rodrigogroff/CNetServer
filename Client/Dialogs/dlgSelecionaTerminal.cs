using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgSelecionaTerminal
	{
		public event_dlgSelecionaTerminal ev_layer;
		
		public dlgSelecionaTerminal ( event_dlgSelecionaTerminal par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgSelecionaTerminalLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgSelecionaTerminal.event_Load, null );
		}
		
		void LstLojasClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgSelecionaTerminal.event_LojaClick, null );
		}
		
		void LstTermClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgSelecionaTerminal.event_TermClick, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgSelecionaTerminal.event_Confirmar, null );
		}
	}
}

