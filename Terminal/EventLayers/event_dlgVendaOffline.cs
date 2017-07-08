using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using SyCrafEngine;

//UserIncludes
//UserIncludes END

namespace Client
{
	public class event_dlgVendaOffline : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int event_val_TxtMoney_Valor = 3;
		public const int event_BtnConfirmarClick = 4;
		public const int event_val_TxtCartao = 5;
		#endregion

		public dlgVendaOffline i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		moneyTextController  	ctrl_TxtMoney_Valor = new moneyTextController();
		pincardTextController 	ctrl_TxtCartao	= new pincardTextController();
		
		Color 	colorInvalid = Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgVendaOffline ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgVendaOffline ( this );
		}
		
		public override bool doEvent ( int event_number, object arg )
		{
			switch ( event_number )
			{
				#region - event_Load -
				
				case event_Load:
				{
					//InitEventCode event_Load
					
					doEvent ( event_Translate, 			null );
					doEvent ( event_FormIsOpening, 		null );
					
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
					
					ctrl_TxtCartao.AcquireTextBox 		( i_Form.TxtCartao, this, event_val_TxtCartao,  15  	);
					
					ctrl_TxtCartao.SetupErrorProvider   ( ErrorIconAlignment.MiddleRight, false ); 
					
					ctrl_TxtMoney_Valor.AcquireTextBox 	( i_Form.TxtMoney_Valor, this, event_val_TxtMoney_Valor, "R$", 8 );
					
					ctrl_TxtMoney_Valor.SetupErrorProvider   ( ErrorIconAlignment.MiddleRight, false ); 
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtMoney_Valor -
				
				case event_val_TxtMoney_Valor:
				{
					//InitEventCode event_val_TxtMoney_Valor
					
					string myValEv = arg as string;
					
					if ( myValEv == moneyTextController.MONEY_ZERO )
					{
						i_Form.TxtMoney_Valor.BackColor = Color.Lavender;
						ctrl_TxtMoney_Valor.IsUserValidated = false;
						ctrl_TxtMoney_Valor.CleanError();
					}
					else
					{
						i_Form.TxtMoney_Valor.BackColor = Color.White;
						ctrl_TxtMoney_Valor.IsUserValidated = true;
						ctrl_TxtMoney_Valor.CleanError();
					}
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnConfirmarClick -
				
				case event_BtnConfirmarClick:
				{
					//InitEventCode event_BtnConfirmarClick
					
					if ( !ctrl_TxtMoney_Valor.IsUserValidated )
						return false;
					
					if ( !ctrl_TxtCartao.IsUserValidated )
						return false;
					
					StreamWriter sw = new StreamWriter ( 	@"Pendencias\" + DateTime.Now.Year.ToString() + 
					                                    	DateTime.Now.Month.ToString().PadLeft 	( 2, '0' ) +
					                                    	DateTime.Now.Day.ToString().PadLeft 	( 2, '0' ) +
					                                    	DateTime.Now.Hour.ToString().PadLeft 	( 2, '0' ) +
					                                    	DateTime.Now.Second.ToString().PadLeft 	( 2, '0' ) );
					
					sw.WriteLine ( ctrl_TxtCartao.getTextBoxValue() 				);
					sw.WriteLine ( ctrl_TxtMoney_Valor.getTextBoxValue_NumberStr() 	);
					                                
					sw.Close();
					
					ctrl_TxtCartao.SetTextBoxText ( "" );
					ctrl_TxtMoney_Valor.SetTextBoxLong ( 0 );
					
					MessageBox.Show ( "Venda offline confirmada", "Aviso" );
					
					i_Form.TxtMoney_Valor.Focus();
					
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
								//i_Form.TxtSenha.Focus();
							}

							break;
						}
							
						default: break;
					}
					
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
