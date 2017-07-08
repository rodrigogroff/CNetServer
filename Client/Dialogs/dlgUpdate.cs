using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgUpdate
	{
		public event_dlgUpdate ev_layer;
		
		public dlgUpdate ( event_dlgUpdate par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgUpdateLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgUpdate.event_Load, null );
		}
	}
}

