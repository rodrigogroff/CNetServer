using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgManutencaoTerminal
	{
		public event_dlgManutencaoTerminal ev_layer;
		
		public dlgManutencaoTerminal ( event_dlgManutencaoTerminal par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgManutencaoTerminalLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgManutencaoTerminal.event_Load, null );
		}
		
		void BtnAlterarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgManutencaoTerminal.event_Alterar, null );
		}
		
		void BtnRemoverClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgManutencaoTerminal.event_Remover, null );
		}
	}
}

