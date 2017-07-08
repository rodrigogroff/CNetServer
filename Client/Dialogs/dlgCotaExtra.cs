using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgCotaExtra
	{
		public event_dlgCotaExtra ev_layer;
		
		public dlgCotaExtra ( event_dlgCotaExtra par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		public void dlgCotaExtraLoad ( object sender, EventArgs e )
		{
			ev_layer.doEvent ( event_dlgCotaExtra.event_Load, null );
		}
		
		void BtnAplicClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgCotaExtra.event_BtnAplicClick, null );
		}
		
		void BtnRemoveClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgCotaExtra.event_BtnRemoveClick, null );
		}
		
		void BtnConfClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgCotaExtra.event_BtnConfClick, null );
		}
		
		void ChkAlfaCheckedChanged(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgCotaExtra.event_ChkAlfaCheckedChanged, null );
		}
	}
}

