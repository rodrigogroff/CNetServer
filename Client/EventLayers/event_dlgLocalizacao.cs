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
	public class event_dlgLocalizacao : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_val_TxtLocalizacao = 6;
		public const int event_BtnConfirmarClick = 7;
		#endregion

		public dlgLocalizacao i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		public string var_TxtTerminal = "";
		public string var_TxtLocalizacao = "";
		
		alphaTextController	ctrl_TxtLocalizacao	= new alphaTextController();
		
		Color 	colorInvalid = Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgLocalizacao ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgLocalizacao ( this );
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
					
					ctrl_TxtLocalizacao.AcquireTextBox  ( i_Form.TxtLocalizacao, this, event_val_TxtLocalizacao, 	40, alphaTextController.ENABLE_NUMBERS, alphaTextController.ENABLE_SYMBOLS 	);
					ctrl_TxtLocalizacao.SetTextBoxText ( var_TxtLocalizacao );
					
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
					
					if ( ctrl_TxtLocalizacao.IsUserValidated )
					{
						if ( var_exchange.exec_alteraTerminal ( var_TxtTerminal,
						                                  		ctrl_TxtLocalizacao.getTextBoxValue(),
						                                  		ref header ) )
						{
							i_Form.Close();
						}
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtLocalizacao -
				
				case event_val_TxtLocalizacao:
				{
					//InitEventCode event_val_TxtLocalizacao
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtLocalizacao.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtLocalizacao.BackColor = Color.White;	
								ctrl_TxtLocalizacao.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtLocalizacao.BackColor = colorInvalid;	
								ctrl_TxtLocalizacao.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
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
