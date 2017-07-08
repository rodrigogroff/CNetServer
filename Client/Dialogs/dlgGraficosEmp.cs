using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgGraficosEmp
	{
		public event_dlgGraficosEmp ev_layer;
		
		public dlgGraficosEmp ( event_dlgGraficosEmp par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgGraficosEmpLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgGraficosEmp.event_Load, null );
		}
		
		void BtnGraficoClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgGraficosEmp.event_GeraGrafico, null );
		}
		
		void BtnAdicionarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgGraficosEmp.event_Adicionar, null );
		}
		
		void BtnRemoverClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgGraficosEmp.event_Remover, null );
		}
		
		void BtnBuscarListaClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgGraficosEmp.event_BuscaListaLojasTransacao, null );
		}
		
		void BtnGeraTransClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgGraficosEmp.event_GeraGraficoTransacao, null );
		}
		
		void BtnRankingClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgGraficosEmp.event_Ranking, null );
		}
	}
}

