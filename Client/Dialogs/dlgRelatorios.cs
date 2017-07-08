using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgRelatorios
	{
		public event_dlgRelatorios ev_layer;
		
		public dlgRelatorios ( event_dlgRelatorios par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
				
		void DlgRelatoriosLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgRelatorios.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgRelatorios.event_Consultar, null );
		}
	}		
}

