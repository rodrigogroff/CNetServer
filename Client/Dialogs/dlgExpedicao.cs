using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgExpedicao
	{
		public event_dlgExpedicao ev_layer;
		
		public dlgExpedicao ( event_dlgExpedicao par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgExpedicaoLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgExpedicao.event_Load, null );
		}
		
		void BtnDirClick(object sender, EventArgs e)
		{
			saveFileDialog1.ShowDialog();
			
			TxtFile.Text = saveFileDialog1.FileName;
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgExpedicao.event_Confirmar, null );
		}
		
		void CboEmpresaSelectedIndexChanged(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgExpedicao.event_ComboChanged, null );
		}
	}
}

