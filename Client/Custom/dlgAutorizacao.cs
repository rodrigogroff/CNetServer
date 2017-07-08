using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
	public partial class dlgAutorizacao : Form
	{
		public string senha = "";
		public bool IsConfirmed = false;
	
		public dlgAutorizacao()
		{
			InitializeComponent();
		}
		
		void BtnAutorizarClick(object sender, EventArgs e)
		{
			IsConfirmed = true;
			senha = TxtSenha.Text;
			Close();
		}
	}
}
