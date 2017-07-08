using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgEducacional
	{
		public event_dlgEducacional ev_layer;
		
		public dlgEducacional ( event_dlgEducacional par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgEducacionalLoad ( object sender, EventArgs e )
		{
			ev_layer.doEvent ( event_dlgEducacional.event_Load, null );
		}
		
		void BtnAlterarClick ( object sender, EventArgs e )
		{
			ev_layer.doEvent ( event_dlgEducacional.event_Definir, null );
		}
		
		void BtnPagamentoClick ( object sender, EventArgs e )
		{
			ev_layer.doEvent ( event_dlgEducacional.event_Pagamento, null );
		}
		
		void BtnExtratoClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgEducacional.event_Vis, null );
		}
	}
}

