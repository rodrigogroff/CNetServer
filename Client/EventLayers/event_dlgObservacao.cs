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
	public class event_dlgObservacao : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_val_TxtMotivo = 6;
		public const int event_FormIsClosing = 7;
		public const int event_BtnConfirmarClick = 8;
		public const int event_DlgObservacaoFormClosing = 9;
		#endregion

		public dlgObservacao i_Form;

		//UserVariables
		
		public string title = "";
		public string message = "";
		
		alphaTextController		ctrl_TxtMotivo	= new alphaTextController();
		
		Color 	colorInvalid 	= Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgObservacao ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgObservacao ( this );
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
					
					i_Form.Text = title;
					i_Form.LblObs.Text = message;
					
					ctrl_TxtMotivo.AcquireTextBox ( i_Form.TxtMotivo, this, event_val_TxtMotivo, 80, alphaTextController.ENABLE_NUMBERS, alphaTextController.ENABLE_SYMBOLS );
					
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
					
					i_Form.Close();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtMotivo -
				
				case event_val_TxtMotivo:
				{
					//InitEventCode event_val_TxtMotivo
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtMotivo.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtMotivo.BackColor = Color.White;	
								ctrl_TxtMotivo.IsUserValidated = true;
								ctrl_TxtMotivo.CleanError();
							}
							else
							{
								i_Form.TxtMotivo.BackColor = colorInvalid;	
								ctrl_TxtMotivo.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_FormIsClosing -
				
				case event_FormIsClosing:
				{
					//InitEventCode event_FormIsClosing
					
					FormClosingEventArgs e = arg as FormClosingEventArgs;
					
					if ( !ctrl_TxtMotivo.IsUserValidated )
					{
						e.Cancel = true;
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
				
				#region - event_DlgObservacaoFormClosing -
				
				case event_DlgObservacaoFormClosing:
				{
					//InitEventCode event_DlgObservacaoFormClosing
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
