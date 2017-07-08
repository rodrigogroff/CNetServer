using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgLogin
	{
		public event_dlgLogin ev_layer;
		
		public dlgLogin ( event_dlgLogin par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgLogin.event_Confirmar, e );
		}
		
		void DlgLoginLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgLogin.event_Load, e );
		}

        private void LblVersion_Click(object sender, EventArgs e)
        {

        }
	}
}

