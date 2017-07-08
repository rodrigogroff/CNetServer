using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgQuiosque
	{
		public event_dlgQuiosque ev_layer;
		
		public dlgQuiosque ( event_dlgQuiosque par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgQuiosqueLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgQuiosque.event_Load, null );
		}
		
		void BtnRemoverClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgQuiosque.event_Remover, null );
		}
		
		void BtnLiberarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgQuiosque.event_Liberar, null );
		}
		
		void BtnVincularClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgQuiosque.event_Vincular, null );
		}
		
		void BtnAdicionarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgQuiosque.event_Adicionar, null );
		}
		
		void LstQSelectedIndexChanged(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgQuiosque.event_Quiosque, null );
		}
	}
}

