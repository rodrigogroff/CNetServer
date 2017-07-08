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
	public class event_dlgHabilitarCartao : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_val_TxtSenha = 5;
		public const int event_val_TxtCartao = 6;
		public const int event_Confirmar = 7;
		public const int event_val_TxtEmpresa = 8;
		public const int event_BtnConfirmarClick = 9;
		#endregion

		public dlgHabilitarCartao i_Form;

		//UserVariables
		
		public CNetHeader header;
				
		pinpadTextController 	ctrl_TxtSenha   = new pinpadTextController();
		pincardTextController 	ctrl_TxtCartao	= new pincardTextController();
		
		Color 	colorInvalid = Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgHabilitarCartao ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgHabilitarCartao ( this );
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
					
					ctrl_TxtSenha.AcquireTextBox 		( i_Form.TxtSenha,  this, event_val_TxtSenha, 	 4 );
					ctrl_TxtCartao.AcquireTextBox 		( i_Form.TxtCartao, this, event_val_TxtCartao,  15  );
					
					ctrl_TxtSenha.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtCartao.SetupErrorProvider   ( ErrorIconAlignment.MiddleRight, false );
					
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
				
				#region - event_Confirmar -
				
				case event_Confirmar:
				{
					//InitEventCode event_Confirmar
					
					bool IsDone = true;
					
					if ( !ctrl_TxtCartao.IsUserValidated )	{	ctrl_TxtCartao.SetErrorMessage 		( "O código completo do cartão deve ser informado (12 digitos)" );	IsDone = false;	}
					if ( !ctrl_TxtSenha.IsUserValidated )	{	ctrl_TxtSenha.SetErrorMessage 		( "A senha deve ter 4 digitos" );	IsDone = false;	}
					
					if ( !IsDone )
						return false;
					
					var_exchange.exec_edu_habilita ( ctrl_TxtCartao.getTextBoxValue(), 
					                                 var_util.DESCript ( ctrl_TxtSenha.getTextBoxValue().PadLeft ( 8, '*'), "12345678" ),
					                                 ref header );
					
					ctrl_TxtCartao.SetTextBoxText ( "" );
					ctrl_TxtSenha.SetTextBoxText ( "" );
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtEmpresa -
				
				case event_val_TxtEmpresa:
				{
					//InitEventCode event_val_TxtEmpresa
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
