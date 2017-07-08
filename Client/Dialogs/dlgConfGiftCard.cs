using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class dlgConfGiftCard
	{
		public event_dlgConfGiftCard ev_layer;
		
		public dlgConfGiftCard ( event_dlgConfGiftCard par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;
		}
		
		void DlgConfGiftCardLoad(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConfGiftCard.event_Load, null );
		}
		
		void BtnConfirmarClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_dlgConfGiftCard.event_Confirmar, null );
		}
		
		void LstProdItemChecked(object sender, ItemCheckedEventArgs e)
		{
			ev_layer.doEvent ( event_dlgConfGiftCard.event_CalcTotal, null );
		}
		
		public bool IsTerm = false;
		
		void DlgConfGiftCardFormClosing(object sender, FormClosingEventArgs e)
		{
			if ( !IsTerm )
			{
				string msg = "Confirma cancelamento de venda de cartão GiftCard?";
				
				if ( ev_layer.recarga )
					msg = "Confirma cancelamento de recarga para cartão GiftCard?";
				
				if ( MessageBox.Show (	msg,
			                    		"Aviso", 
			                    		MessageBoxButtons.YesNo, 
			                    		MessageBoxIcon.Question, 
			                    		MessageBoxDefaultButton.Button2 ) == DialogResult.No )
				{
					e.Cancel = true;
				}
			}
		}
	}
}

