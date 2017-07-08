using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgFatGerarArquivo
	{
		public event_dlgFatGerarArquivo ev_layer;
		
		public dlgFatGerarArquivo ( event_dlgFatGerarArquivo par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgFatGerarArquivoLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgFatGerarArquivo.event_Load, null );
		}
		
		void BtnDirClick(object sender, EventArgs e)
		{
			folderBrowserDialog1.Description = "Selecione diretório para arquivo de faturamento:";
			folderBrowserDialog1.ShowDialog();
			
			TxtFile.Text = folderBrowserDialog1.SelectedPath;
			
			if ( TxtFile.Text [ TxtFile.Text.Length - 1 ] != '\\' )
				TxtFile.Text += @"\";
			
			if ( CboOption.SelectedIndex == 1 )
			{
				TxtFile.Text += "RSTA" + 
							DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) +
							DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + 
							"ZZ" + 
							".BJW";
			}
			else
			{
				TxtFile.Text += "REMESSA" + 
								DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) +
								DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + 
								".TXT";
			}
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgFatGerarArquivo.event_Confirmar, null );
		}
	}
}

