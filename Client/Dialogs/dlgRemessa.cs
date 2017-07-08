using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgRemessa
	{
		public event_dlgRemessa ev_layer;
		
		public dlgRemessa ( event_dlgRemessa par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgRemessaLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgRemessa.event_Load, null );
		}
		
		void BtnBuscarClick(object sender, EventArgs e)
		{
			openFileDialog1.FileName = "";
			
			if ( openFileDialog1.ShowDialog() == DialogResult.OK )
			{
				TxtFile.Text = openFileDialog1.FileName;
			}
		}
		
		void BtnProcClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgRemessa.event_Processar, null );
		}
	}
}

