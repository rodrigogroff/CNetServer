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
	public class event_dlgCompensaCheque : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Cancelar = 5;
		public const int event_Compensar = 6;
		public const int event_val_TxtIdent = 7;
		public const int event_BtnCancelarClick = 8;
		public const int event_BtnCompensarClick = 9;
		#endregion

		public dlgCompensaCheque i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController ctrl_TxtIdent = new numberTextController();
				
		Color 	colorInvalid = Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgCompensaCheque ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgCompensaCheque ( this );
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
					
					ctrl_TxtIdent.AcquireTextBox ( i_Form.TxtIdent, this, event_val_TxtIdent, 20  );
					
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
				
				#region - event_Cancelar -
				
				case event_Cancelar:
				{
					//InitEventCode event_Cancelar
					
					var_exchange.exec_cancelaChequeGift ( ctrl_TxtIdent.getTextBoxValue(), ref header );
					
					string st_msg = "";
									
					var_exchange.fetch_chequeGift ( ctrl_TxtIdent.getTextBoxValue(), 
					                                ref header,
					                                ref st_msg );
					
					i_Form.TxtCheque.Text = st_msg.Replace ( "@", "\r\n" );									
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Compensar -
				
				case event_Compensar:
				{
					//InitEventCode event_Compensar
					
					var_exchange.exec_compensaChequeGift ( ctrl_TxtIdent.getTextBoxValue(), ref header );
					
					string st_msg = "";
									
					var_exchange.fetch_chequeGift ( ctrl_TxtIdent.getTextBoxValue(), 
					                                ref header,
					                                ref st_msg );
					
					i_Form.TxtCheque.Text = st_msg.Replace ( "@", "\r\n" );									

					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtIdent -
				
				case event_val_TxtIdent:
				{
					//InitEventCode event_val_TxtIdent
					
					i_Form.TxtCheque.Text = "";
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtIdent.Text.Length > 0 )
							{
								i_Form.TxtIdent.BackColor = Color.White;
								ctrl_TxtIdent.IsUserValidated = true;
								ctrl_TxtIdent.CleanError();
								
								if ( ctrl_TxtIdent.GetEnterPressed() )
								{
									string st_msg = "";
									
									var_exchange.fetch_chequeGift ( ctrl_TxtIdent.getTextBoxValue(), 
									                                ref header,
									                                ref st_msg );
									
									i_Form.TxtCheque.Text = st_msg.Replace ( "@", "\r\n" );									
								}
							}
							else
							{
								i_Form.TxtIdent.BackColor = colorInvalid;
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
				
				#region - event_BtnCancelarClick -
				
				case event_BtnCancelarClick:
				{
					//InitEventCode event_BtnCancelarClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnCompensarClick -
				
				case event_BtnCompensarClick:
				{
					//InitEventCode event_BtnCompensarClick
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
