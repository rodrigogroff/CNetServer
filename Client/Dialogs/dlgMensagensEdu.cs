using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgMensagensEdu
	{
		public event_dlgMensagensEdu ev_layer;
		
		public dlgMensagensEdu ( event_dlgMensagensEdu par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		public void dlgMensagensEduLoad ( object sender, EventArgs e )
		{
			ev_layer.doEvent ( event_dlgMensagensEdu.event_Load, null );
		}
		
		void BtnNovoClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgMensagensEdu.event_BtnNovoClick, null );
		}
		
		void BtnAtualizarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgMensagensEdu.event_BtnAtualizarClick, null );
		}
		
		void BtnRemoverClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgMensagensEdu.event_BtnRemoverClick, null );
		}
		
		void LstMsgDoubleClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgMensagensEdu.event_LstMsgDoubleClick, null );
		}
	}
}

