using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class MainForm
	{
		public event_MainForm ev_layer;
				
		public MainForm ( event_MainForm par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;		
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_FormIsClosing,  null );
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
		}
		
		void BtnVendaOnlineClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_BtnVendaOnlineClick,  null );
		}
		
		void BtnVendaDigitadaClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_BtnVendaDigitadaClick,  null );
		}
		
		void BtnPendenciasClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_BtnPendenciasClick,  null );
		}
		
		void BtnCancelamentoClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_BtnCancelamentoClick,  null );
		}
		
		void BtnFinanceiroClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_BtnFinanceiroClick,  null );
		}
	}
}
