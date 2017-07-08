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
	public class event_dlgVendaLojista : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_val_TxtSenha = 5;
		public const int event_val_TxtCartao = 6;
		public const int event_val_TxtValor = 7;
		public const int event_Confirmar = 8;
		public const int event_Print = 9;
		public const int event_Definir = 10;
		public const int event_val_TxtParcelas = 11;
		public const int event_BtnConfirmarClick = 12;
		public const int event_BtnDivisaoClick = 13;
		#endregion

		public dlgVendaLojista i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		ArrayList lstPar = new ArrayList();
		
		pinpadTextController 	ctrl_TxtSenha   = new pinpadTextController();
		pincardTextController 	ctrl_TxtCartao	= new pincardTextController();
		moneyTextController 	ctrl_TxtValor	= new moneyTextController();
		numberTextController	ctrl_TxtParcelas   = new numberTextController();
		
		Color 	colorInvalid = Color.Lavender;
		
		string nsu_venda = "";
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgVendaLojista ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgVendaLojista ( this );
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
					
					ctrl_TxtSenha.AcquireTextBox 		( i_Form.TxtSenha,  this, event_val_TxtSenha, 	 4 		);
					ctrl_TxtCartao.AcquireTextBox 		( i_Form.TxtCartao, this, event_val_TxtCartao,  15  	);
					ctrl_TxtValor.AcquireTextBox		( i_Form.TxtValor, 	this, event_val_TxtValor,	"R$", 9 );
					
					ctrl_TxtParcelas.AcquireTextBox     ( i_Form.TxtParcelas, this, event_val_TxtParcelas,  2  	);
					
					ctrl_TxtSenha.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtCartao.SetupErrorProvider   ( ErrorIconAlignment.MiddleRight, false );
					
					ctrl_TxtParcelas.SetTextBoxText ( "1" );
					
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
				
				#region - event_val_TxtSenha -
				
				case event_val_TxtSenha:
				{
					//InitEventCode event_val_TxtSenha
					
					switch ( arg as string )
					{
						case pinpadTextController.PINPAD_INCOMPLETE:
						case pinpadTextController.PINPAD_COMPLETE:
						{
							if ( i_Form.TxtSenha.Text.Length > 3 )
							{
								i_Form.TxtSenha.BackColor = Color.White;
								ctrl_TxtSenha.IsUserValidated = true;
								ctrl_TxtSenha.CleanError();
							}
							else
							{
								i_Form.TxtSenha.BackColor = colorInvalid;
								ctrl_TxtSenha.IsUserValidated = false;
							}
													
							break;
						}
						
						case pinpadTextController.PINPAD_ENTRA:
						{
							doEvent ( event_Confirmar, null );
							break;
						}
						
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCartao -
				
				case event_val_TxtCartao:
				{
					//InitEventCode event_val_TxtCartao
					
					switch ( arg as string )
					{
						case pincardTextController.PINCARD_INCOMPLETE:
						{
							i_Form.TxtCartao.BackColor     = colorInvalid;	
							ctrl_TxtCartao.IsUserValidated = false;
							break;
						}
							
						case pincardTextController.PINCARD_COMPLETE:
						{
							i_Form.TxtCartao.BackColor     = Color.White;	
							ctrl_TxtCartao.IsUserValidated = true;
							ctrl_TxtCartao.CleanError();
							
							if ( ctrl_TxtCartao.IsTermInput )
							{
								i_Form.TxtSenha.Focus();
							}

							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtValor -
				
				case event_val_TxtValor:
				{
					//InitEventCode event_val_TxtValor
					
					if ( arg as string == moneyTextController.MONEY_ZERO )
					{
						i_Form.TxtValor.BackColor = colorInvalid;	
						ctrl_TxtValor.IsUserValidated = false;
					}
					else
					{
						i_Form.TxtValor.BackColor = Color.White;	
						ctrl_TxtValor.IsUserValidated = true;
						ctrl_TxtValor.CleanError();
					}
										
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Confirmar -
				
				case event_Confirmar:
				{
					//InitEventCode event_Confirmar
					
					if ( !ctrl_TxtValor.IsUserValidated )
					{
						return false;
					}
					
					var_exchange.m_Client.QuietMode = true;
					
					POS_Entrada  pe = new POS_Entrada();
			
					string cript_senha = new ApplicationUtil().DESCript ( ctrl_TxtSenha.getTextBoxValue().PadLeft ( 8, '*' ), "12345678" );
					
					pe.set_st_senha    		( cript_senha 													);
		            pe.set_st_empresa   	( ctrl_TxtCartao.getTextBoxValue().Substring ( 0, 6 ) 			);
		            pe.set_st_matricula 	( ctrl_TxtCartao.getTextBoxValue().Substring ( 6, 6 ) 			);
		            pe.set_st_titularidade 	( ctrl_TxtCartao.getTextBoxValue().Substring ( 12, 2 ) 			);
					pe.set_vr_valor			( ctrl_TxtValor.getTextBoxValue_NumberStr().PadLeft ( 12, '0' ) );
					pe.set_st_terminal		( header.get_nu_terminal()										);
					pe.set_nu_parcelas		( ctrl_TxtParcelas.getTextBoxValue()							);
					
					if ( ctrl_TxtParcelas.getTextBoxValue_Long() == 1 )
					{
						pe.set_st_valores		( ctrl_TxtValor.getTextBoxValue_NumberStr().PadLeft ( 12, '0' ) );
					}
					else
					{
						string st_lst_val = "";
						
						for (int t=0; t < lstPar.Count; ++t )
						{
							st_lst_val += lstPar[t].ToString().PadLeft ( 12, '0' );
						}
						
						pe.set_st_valores ( st_lst_val );
					}
					
					POS_Resposta resp = new POS_Resposta();
					
					string msg = "";
					
					if ( var_exchange.exec_pos_vendaEmpresarial ( ref pe, 
		                                                          ref msg, 
		                                                          ref resp ) )
		            {
			            nsu_venda = resp.get_st_nsuRcb();
			            
			            if ( var_exchange.exec_pos_confirmaVendaEmpresarial ( nsu_venda, 
			                                                                  ref pe, 
			                                                                  ref msg, 
			                                                                  ref resp ) )
			            {
			            	var_exchange.m_Client.QuietMode = false;
			            	
			            	MessageBox.Show ( "NSU: " + nsu_venda, "Transação confirmada" );	
			            	
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
			            }
			            else
			            {
			            	MessageBox.Show ( msg, "Erro na transação" );	
			            }
		            }
		            else
		            {
		            	MessageBox.Show ( msg, "Erro na transação" );
		            }
		            
		            var_exchange.m_Client.QuietMode = false;
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Print -
				
				case event_Print:
				{
					//InitEventCode event_Print
					
					ArrayList lst = new ArrayList();
					
					var_exchange.fetch_reciboVendaLojista ( nsu_venda, ref header, ref lst );
					
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
		            
		            i_Form.Close();
		            
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Definir -
				
				case event_Definir:
				{
					//InitEventCode event_Definir
					
					event_dlgVendaParcelada ev_call = new event_dlgVendaParcelada ( var_util, var_exchange );
					
					ev_call.header    = header;
					ev_call.lstPar    = lstPar;
					ev_call.tot_parcs = ctrl_TxtParcelas.getTextBoxValue_Long();
					ev_call.tot_valor = ctrl_TxtValor.getTextBoxValue_Long();
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtParcelas -
				
				case event_val_TxtParcelas:
				{
					//InitEventCode event_val_TxtParcelas
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
				
				#region - event_BtnDivisaoClick -
				
				case event_BtnDivisaoClick:
				{
					//InitEventCode event_BtnDivisaoClick
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
