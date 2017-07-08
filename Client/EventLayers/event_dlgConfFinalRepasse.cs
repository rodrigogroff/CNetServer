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
	public class event_dlgConfFinalRepasse : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_val_TxtIdent = 6;
		public const int event_Print = 7;
		public const int event_BtnConfirmarClick = 8;
		#endregion

		public dlgConfFinalRepasse i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController 		ctrl_TxtIdent	= new numberTextController();
		
		public ArrayList lstParcelas = new ArrayList();
		
		public string st_loja     = "";
		public string st_codLoja  = "";
		public string vr_valor    = "";
		
		string id_confRepasse = "";
				
		Color 	colorInvalid = Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgConfFinalRepasse ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgConfFinalRepasse ( this );
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
					
					i_Form.TxtLoja.Text  = st_loja;
					i_Form.TxtValor.Text = "R$ " + new money().formatToMoney ( vr_valor );
					
					ctrl_TxtIdent.AcquireTextBox ( i_Form.TxtIdent, this, event_val_TxtIdent, 20 );
					
					string banco = "";
					string ag 	 = "";
					string conta = "";
					
					var_exchange.fetch_convenioLojaGift ( st_codLoja, ref header, ref banco, ref ag, ref conta );
					              
					i_Form.TxtBanco.Text   = banco;
					i_Form.TxtAgencia.Text = ag;
					i_Form.TxtConta.Text   = conta;
					
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
					
					if ( !i_Form.rbCheque.Checked &&
					     !i_Form.rbDep.Checked    &&
					     !i_Form.rbDinheiro.Checked )
					{
						return false;
					}
					
					if ( i_Form.rbCheque.Checked && 
					     !ctrl_TxtIdent.IsUserValidated )
					{
						MessageBox.Show ( "Preencha a identificação do cheque", "Aviso" );
						return false;
					}
					
					string tg_opcao = "0"; // dinheiro
					
					if ( i_Form.rbCheque.Checked )	tg_opcao = "1";
					if ( i_Form.rbDep.Checked )		tg_opcao = "2";	
					
					vr_valor = vr_valor.Replace ( "R$", "" );
										
					var_exchange.exec_repasseLoja ( st_codLoja,
					                                tg_opcao,
					                                ctrl_TxtIdent.getTextBoxValue(),
					                                new money().getNumericValue ( vr_valor ).ToString(),
					                                ref header,
					                                ref lstParcelas,
					                                ref id_confRepasse );
					
					
					bool IsPrinted = false;
					
					while ( !IsPrinted )
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
			            
			            if ( MessageBox.Show (	"Imprimiiu corretamente?",
					                    		"Aviso", 
					                    		MessageBoxButtons.YesNo, 
					                    		MessageBoxIcon.Question, 
					                    		MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
						{
							IsPrinted = true;
						}
					}
					
					i_Form.Close();
					                                
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtIdent -
				
				case event_val_TxtIdent:
				{
					//InitEventCode event_val_TxtIdent
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtIdent.Text.Length > 0 )
							{
								i_Form.TxtIdent.BackColor     = Color.White;
								ctrl_TxtIdent.IsUserValidated = true;
								ctrl_TxtIdent.CleanError();
							}
							else
							{
								i_Form.TxtIdent.BackColor     = colorInvalid;
								ctrl_TxtIdent.IsUserValidated = false;
							}
							
							break;
						}
						
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Print -
				
				case event_Print:
				{
					//InitEventCode event_Print
					
					DadosRepRecibo drr = new DadosRepRecibo();
					
					ArrayList lstRec = new ArrayList();
					
					var_exchange.fetch_reciboRepasse ( id_confRepasse, 
					                                   ref header, 
					                                   ref drr, 
					                                   ref lstRec );
					
					PrintPageEventArgs e = arg as PrintPageEventArgs;
										
					Graphics g = e.Graphics;
		            int n = 0;
		            Font myFont = new Font("Courier New", 10);
		            
		            try
			        {		            	
		            	g.DrawString ( "RECIBO DE CONFIRMAÇÃO DO REPASSE FINANCEIRO", myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
		            	g.DrawString ( "", myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
		            	g.DrawString ( DateTime.Now.ToLongDateString().ToUpper(), myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
		            	g.DrawString ( "", myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
		            	g.DrawString ( "Nome da loja: " + drr.get_loja(), myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
		            	g.DrawString ( "CNPJ: " + drr.get_cnpj(), myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
		            	
		            	if ( drr.get_pagto() == TipoPagamento.Dinheiro )
		            	{
		            		g.DrawString ( "Forma pagamento: dinheiro ", myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
		            	}
		            	else if ( drr.get_pagto() == TipoPagamento.Cheque )
		            	{
		            		g.DrawString ( "Forma pagamento: Cheque " + drr.get_st_extra(), myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
		            	}
		            	else 
		            	{
		            		g.DrawString ( "Forma pagamento: Depósito " + drr.get_st_extra(), myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
		            	}
		            	
		            	string tipo_pag = "";
		            	
		            	g.DrawString ( tipo_pag, myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
		            	g.DrawString ( "", myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
		            	g.DrawString ( "Cartão            Data e Hora          NSU       Valor     Data Vencimento", myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
		            	g.DrawString ( "------------------------------------------------------------------------------------", myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
		            	
			            for (int t=0; t < lstRec.Count; ++t )
			            {
			            	DadosRepasse port = new DadosRepasse ( lstRec[t] as DataPortable );
			            	
			            	string line = port.get_st_cartao().PadRight ( 18, ' ' );
			            	
			            	line += var_util.getDDMMYYYY_format ( port.get_dt_trans() ).PadRight ( 21, ' ' );
			            	line += port.get_st_nsu().PadRight ( 10, ' ' );
			            	line += new money().formatToMoney ( port.get_vr_total() ).PadRight ( 10,' ');
		            		line += var_util.getDDMMYYYY_format ( port.get_dt_repasse() ).PadRight ( 21, ' ' );
			            	
				            g.DrawString ( line, myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
			            }
			            
			            g.DrawString ( "", myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
			            g.DrawString ( "Valor das compras: R$ " + new money().formatToMoney ( drr.get_vr_compras() ), myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
			            g.DrawString ( "Taxa de administração: " + drr.get_tx_admin(), myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
			            g.DrawString ( "Desconto: R$ " + drr.get_vr_desc(), myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
			            g.DrawString ( "Valor total do reembolso: " + new money().formatToMoney ( drr.get_vr_tot_rep() ), myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
			            g.DrawString ( "", myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
			            g.DrawString ( "", myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
			            g.DrawString ( "", myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
			            g.DrawString ( "", myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
			            g.DrawString ( "", myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
			            g.DrawString ( "____________________________________________", myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
			            g.DrawString ( "Assinatura do responsável", myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
		            	
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
