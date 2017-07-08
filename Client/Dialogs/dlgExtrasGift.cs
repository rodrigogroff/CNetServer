using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgExtrasGift
	{
		public event_dlgExtrasGift ev_layer;
		
		public dlgExtrasGift ( event_dlgExtrasGift par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgExtrasGiftLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgExtrasGift.event_Load, null );
		}
		
		void BtnRemoverClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgExtrasGift.event_Remover, null );
		}
		
		void BtnAdicionarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgExtrasGift.event_Adicionar, null );
		}
		
		void LstProdClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgExtrasGift.event_Selecionar, null );
		}
	}
}

