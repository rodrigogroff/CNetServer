using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

using System.Drawing.Printing;

namespace Client
{
	public partial class dlgConsultaCartao
	{
		public event_dlgConsultaCartao ev_layer;
		
		public dlgConsultaCartao ( event_dlgConsultaCartao par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgConsultaCartaoLoad ( object sender, EventArgs e )
		{
			ev_layer.doEvent ( event_dlgConsultaCartao.event_Load, null );
		}
		
		void BtnConsultarClick ( object sender, EventArgs e )
		{
			ev_layer.doEvent ( event_dlgConsultaCartao.event_Consultar, null );
		}
		
		void LstCartaoDoubleClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConsultaCartao.event_Editar, null );
		}
		
		void BtnRelatorioClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConsultaCartao.event_Report, null );
		}
		
		void ChkAlfaCheckedChanged(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConsultaCartao.event_ChkAlfaCheckedChanged, null );
		}
		
		void BtnExcluiClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConsultaCartao.event_BtnExcluiClick, null );
		}
	}
}

