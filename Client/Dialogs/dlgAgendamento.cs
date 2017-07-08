using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgAgendamento
	{
		public event_dlgAgendamento ev_layer;
		
		public dlgAgendamento ( event_dlgAgendamento par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgAgendamentoLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgAgendamento.event_Load, null );				
		}
		
		void BtnAdicionarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgAgendamento.event_Adicionar, null );				
		}
		
		void BtnRemoverClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgAgendamento.event_Remover, null );
		}
		
		void DlgAgendamentoShown(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgAgendamento.event_buscaDados, null );
		}
	}
}

