using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using SyCrafEngine;

//UserIncludes

using System.Drawing.Printing;

//UserIncludes END

namespace Client
{
	public class event_dlgFinalGift : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_FormIsClosing = 6;
		public const int event_val_TxtIdent = 7;
		public const int event_Print = 8;
		public const int event_BtnConfirmarClick = 9;
		#endregion

		public dlgFinalGift i_Form;

		//UserVariables
		
		public CNetHeader 			header;
		
		public DadosProprietario 	dp;
		public DadosCartao 			dc;
		public DadosAdicionais 		da;
		
		public long total = 0;
		public long carga = 0;
		
		public ArrayList lstProdsNome  = new ArrayList();
		public ArrayList lstProdsValor = new ArrayList();
		
		public bool IsTerm = false;
		public bool recarga = false;
		
		string id_gift = "";
		
		numberTextController ctrl_TxtIdent = new numberTextController();
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgFinalGift ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgFinalGift ( this );
		}
		
		public override bool doEvent ( int event_number, object arg )
		{
			switch ( event_number )
			{
				#region - event_Load -
				
				case event_Load:
				{
					//InitEventCode event_Load
					
					#if ROBOT
					var_util.execDefinedRobot ( this, var_alias );	
					#else
					
					doEvent ( event_Translate, 			null );
					doEvent ( event_FormIsOpening, 		null );
					
					#endif
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Translate -
				
				case event_Translate:
				{
					//InitEventCode event_Translate
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_FormIsOpening -
				
				case event_FormIsOpening:
				{
					//InitEventCode event_FormIsOpening
					
					i_Form.LblTotal.Text = "Total: R$ " + new money().formatToMoney ( total.ToString() );
					i_Form.rbDinheiro.Checked = true;
					
					ctrl_TxtIdent.AcquireTextBox ( i_Form.TxtIdent, this, event_val_TxtIdent, 20 );
					
					i_Form.CboTipoCart.SelectedIndex = 0;
					
					if ( recarga )
						i_Form.Text = "Efetuar pagamento para recarga de cartão Gift";
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - robot_ShowDialog -
				
				case robot_ShowDialog:
				{
					//InitEventCode robot_ShowDialog
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - robot_CloseDialog -
				
				case robot_CloseDialog:
				{
					//InitEventCode robot_CloseDialog
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Confirmar -
				
				case event_Confirmar:
				{
					//InitEventCode event_Confirmar
					
					if ( i_Form.rbCheque.Checked )
					{
						if ( i_Form.TxtIdent.Text.Length == 0 )
						{
							MessageBox.Show ( "Informe a identificação do cheque", "Aviso"  );
							return false;
						}
					}
					else if ( i_Form.rbCartao.Checked )
					{
						if ( i_Form.TxtIdent.Text.Length == 0 )
						{
							MessageBox.Show ( "Informe a identificação da venda pelo cartão", "Aviso"  );
							return false;
						}	
						
						if ( i_Form.CboTipoCart.SelectedIndex == -1 )
						{
							MessageBox.Show ( "Escolha o tipo de cartão", "Aviso"  );
							return false;
						}
					}
					
					dc.set_vr_dispTotal ( carga.ToString() );
					
					string tipoPag = TipoPagamento.Dinheiro;
					string info    = i_Form.TxtIdent.Text;;
					
					if ( i_Form.rbCheque.Checked )
					{
						tipoPag = TipoPagamento.Cheque;
					}
					else if ( i_Form.rbCartao.Checked )
					{
						tipoPag = TipoPagamento.Cartao;
					}
					else
					{
						info    = "";
					}
					
					ArrayList lst = new ArrayList();
					
					for (int t=0; t < lstProdsNome.Count; ++t )
					{
						DadosProdutoGift dpg = new DadosProdutoGift();
						
						dpg.set_st_nome  ( lstProdsNome[t].ToString()  );
						dpg.set_vr_valor ( lstProdsValor[t].ToString() );
						
						lst.Add ( dpg );
					}
					
					string tg_adesao = Context.TRUE;
					
					if ( recarga )
						tg_adesao = Context.FALSE;
					
					var_exchange.exec_recargaGift ( dc.get_st_empresa(),
				                                    dc.get_st_matricula(),
				                                    carga.ToString(),
				                                    tipoPag,
				                                    i_Form.CboTipoCart.SelectedIndex.ToString(),
				                                    info,
				                                    tg_adesao,
				                                    ref header,
				                                    ref lst,
				                                    ref id_gift );
				
					if ( !recarga )
					{
						if ( !var_exchange.ins_cartaoProprietario ( "",
						                                          	ref dc,
						                                          	ref dp,
						                                          	ref da,
						                                          	ref header ) )
						{
							return false;
						}
					}
					
					IsTerm = true;
					
					bool Finish = false;
					
					while ( !Finish )
					{
						PrintDocument 		pd      = new PrintDocument();
			            PrintDialog 		pDialog = new PrintDialog();
			            
			            pDialog.Document = pd;
			            
			            PrintPreviewDialog prevDialog = new PrintPreviewDialog();
			            prevDialog.Document = pd;
			            
			            pd.PrintPage += new PrintPageEventHandler ( i_Form.Inven_Report );
			            prevDialog.ShowDialog();
			
			            if (pDialog.ShowDialog() == DialogResult.OK)
			            {
			                pd.Print();
			            }
			            
			            if ( MessageBox.Show (	"Impressão bem sucedida?",
					                    		"Aviso", 
					                    		MessageBoxButtons.YesNo, 
					                    		MessageBoxIcon.Question, 
					                    		MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
						{
			            	Finish = true;
						}
					}
					
		            i_Form.Close();
							
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_FormIsClosing -
				
				case event_FormIsClosing:
				{
					//InitEventCode event_FormIsClosing
					
					if ( MessageBox.Show (	"Confirma cancelamento de cadastro de cartão GiftCard?",
				                    		"Aviso", 
				                    		MessageBoxButtons.YesNo, 
				                    		MessageBoxIcon.Question, 
				                    		MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
					{
						return false;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtIdent -
				
				case event_val_TxtIdent:
				{
					//InitEventCode event_val_TxtIdent
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Print -
				
				case event_Print:
				{
					//InitEventCode event_Print
					
					ArrayList lst = new ArrayList();
					
					var_exchange.fetch_comprov_Gift ( id_gift, Context.FALSE, ref header, ref lst );
					
					PrintPageEventArgs e = arg as PrintPageEventArgs;
										
					Graphics g = e.Graphics;
		            int n = 0;
		            Font myFont = new Font("Courier New", 10);
		            
		            try
			        {
			            for (int t=0; t < lst.Count; ++t )
			            {
			            	DataPortable port = lst[t] as DataPortable;
			            	
				            g.DrawString ( port.getValue ( "linha" ), myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
			            }
		            	
			            myFont.Dispose();
		           	}
		            catch (Exception ex)
		            {
		                MessageBox.Show(ex.Message.ToString());
		            }
		            			
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnConfirmarClick -
				
				case event_BtnConfirmarClick:
				{
					//InitEventCode event_BtnConfirmarClick
					//EndEventCode
					return true;
				}
				
				#endregion
		
				default: break;
			}
		
			return false;
		}
	}
}
