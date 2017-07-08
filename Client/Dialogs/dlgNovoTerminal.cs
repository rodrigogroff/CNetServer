using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgNovoTerminal
	{
		public event_dlgNovoTerminal ev_layer;
		
		public dlgNovoTerminal ( event_dlgNovoTerminal par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgNovoTerminalLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgNovoTerminal.event_Load, null );			
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgNovoTerminal.event_Confirmar, null );			
		}
	}
}

