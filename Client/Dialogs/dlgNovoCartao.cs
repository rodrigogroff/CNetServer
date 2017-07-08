using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgNovoCartao
	{
		public event_dlgNovoCartao ev_layer;
		
		public dlgNovoCartao ( event_dlgNovoCartao par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgNovoCartaoLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgNovoCartao.event_Load, e );
		}
		
		void BtnAdicionarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgNovoCartao.event_AdicionarDependente, e );
		}
		
		void CboDependentesSelectedIndexChanged(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgNovoCartao.event_CboDepChange, e );
		}
		
		void BtnAtualizarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgNovoCartao.event_AtualizarDep, e );
		}
		
		void BtnCancelarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgNovoCartao.event_Cancelar, e );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgNovoCartao.event_Confirmar, e );
		}
	}
}

