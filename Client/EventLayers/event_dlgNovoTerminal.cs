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
	public class event_dlgNovoTerminal : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_val_TxtTerminal = 6;
		public const int event_val_TxtLocalizacao = 7;
		public const int event_val_TxtCNPJ = 8;
		public const int event_BtnConfirmarClick = 9;
		#endregion

		public dlgNovoTerminal i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		alphaTextController			ctrl_TxtLocalizacao		= new alphaTextController();
		numberTextController		ctrl_TxtCNPJ			= new numberTextController();
		
		Color 	colorInvalid = Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgNovoTerminal ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgNovoTerminal ( this );
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
					
					ctrl_TxtLocalizacao.AcquireTextBox 	( i_Form.TxtLocalizacao, 	this, event_val_TxtLocalizacao, 	40, alphaTextController.ENABLE_NUMBERS, alphaTextController.ENABLE_SYMBOLS  );
					ctrl_TxtCNPJ.AcquireTextBox 		( i_Form.TxtCNPJ, 			this, event_val_TxtCNPJ, 			8  );
					
					ctrl_TxtLocalizacao.IsUserValidated = true;
					
					ctrl_TxtCNPJ.SetupErrorProvider		( ErrorIconAlignment.MiddleRight, false ); 
										
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
					
					bool IsDone = true;
					
					if ( !ctrl_TxtCNPJ.IsUserValidated 	)		{	ctrl_TxtCNPJ.SetErrorMessage 		( "O código da loja deve ser preenchido" );	IsDone = false;	}
					
					if ( !IsDone )
					{
						return false;
					}
					
					DadosTerminal dt = new DadosTerminal();
					
					dt.set_st_localizacao 	( ctrl_TxtLocalizacao.getTextBoxValue() );
					
					var_exchange.ins_terminal ( ctrl_TxtCNPJ.getTextBoxValue(),
					                           	ref dt, 
					                           	ref header );
															
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtTerminal -
				
				case event_val_TxtTerminal:
				{
					//InitEventCode event_val_TxtTerminal
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtLocalizacao -
				
				case event_val_TxtLocalizacao:
				{
					//InitEventCode event_val_TxtLocalizacao
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCNPJ -
				
				case event_val_TxtCNPJ:
				{
					//InitEventCode event_val_TxtCNPJ
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtCNPJ.Text.Length > 0 )
							{
								i_Form.TxtCNPJ.BackColor     = Color.White;	
								ctrl_TxtCNPJ.IsUserValidated = true;
								ctrl_TxtCNPJ.CleanError();
							}
							else
							{
								i_Form.TxtCNPJ.BackColor     = colorInvalid;	
								ctrl_TxtCNPJ.IsUserValidated = false;
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
