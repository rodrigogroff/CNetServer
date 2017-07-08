using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgRecebeArqBanco
	{
		public event_dlgRecebeArqBanco ev_layer;
		
		public dlgRecebeArqBanco ( event_dlgRecebeArqBanco par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgRecebeArqBancoLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgRecebeArqBanco.event_Load, null );
		}
		
		void BtnProcessarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgRecebeArqBanco.event_Processar, null );
		}
		
		void BtnProcurarClick(object sender, EventArgs e)
		{
			openFileDialog1.FileName = "";
			
			if ( openFileDialog1.ShowDialog() == DialogResult.OK )
			{
				TxtFile.Text = openFileDialog1.FileName;
			}
		}
	}
}

