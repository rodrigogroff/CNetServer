using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgFinanceiro
	{
		public event_dlgFinanceiro ev_layer;
		
		public dlgFinanceiro ( event_dlgFinanceiro par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		public void dlgFinanceiroLoad ( object sender, EventArgs e )
		{
			ev_layer.doEvent ( event_dlgFinanceiro.event_Load, null );
		}
		
		void MonthCalendar1DateSelected(object sender, DateRangeEventArgs e)
		{
			ev_layer.doEvent ( event_dlgFinanceiro.event_Load, null );
		}
		
		void CalDateChanged(object sender, DateRangeEventArgs e)
		{
			ev_layer.doEvent ( event_dlgFinanceiro.event_CalDateChanged, null );
		}
		
		void CalDateSelected(object sender, DateRangeEventArgs e)
		{
			ev_layer.doEvent ( event_dlgFinanceiro.event_CalDateChanged, null );
		}
	}
}

