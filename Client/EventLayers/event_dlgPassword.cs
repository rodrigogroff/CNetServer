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
	public class event_dlgPassword : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_val_TxtSenhaAtual = 6;
		public const int event_val_TxtNovaSenha = 7;
		public const int event_val_TxtConfirmaSenha = 8;
		public const int event_BtnConfirmarClick = 9;
		#endregion

		public dlgPassword i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		alphaTextController			ctrl_TxtSenhaAtual		= new alphaTextController();
		alphaTextController			ctrl_TxtNovaSenha		= new alphaTextController();
		alphaTextController			ctrl_TxtConfirmaSenha	= new alphaTextController();
		
		Color 	colorInvalid = Color.Lavender;
		
		public bool var_IsCanceled   = true;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgPassword ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgPassword ( this );
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
					
					ctrl_TxtSenhaAtual.AcquireTextBox		( i_Form.TxtSenhaAtual,		this, event_val_TxtSenhaAtual,			16, alphaTextController.ENABLE_NUMBERS, alphaTextController.ENABLE_SYMBOLS );
					ctrl_TxtNovaSenha.AcquireTextBox		( i_Form.TxtNovaSenha,		this, event_val_TxtNovaSenha,			16, alphaTextController.ENABLE_NUMBERS, alphaTextController.ENABLE_SYMBOLS );
					ctrl_TxtConfirmaSenha.AcquireTextBox	( i_Form.TxtConfirmaSenha,	this, event_val_TxtConfirmaSenha,		16, alphaTextController.ENABLE_NUMBERS, alphaTextController.ENABLE_SYMBOLS );
					
					ctrl_TxtNovaSenha.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtConfirmaSenha.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false );
					
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
					
					if ( ctrl_TxtNovaSenha.getTextBoxValue() != ctrl_TxtConfirmaSenha.getTextBoxValue() )
					{
						ctrl_TxtConfirmaSenha.SetErrorMessage ( "Senha inválida" );
						return false;
					}
					
					if ( !ctrl_TxtNovaSenha.IsUserValidated )
					{
						ctrl_TxtNovaSenha.SetErrorMessage ( "Senha incompleta" );
						ctrl_TxtConfirmaSenha.SetErrorMessage ( "Senha incompleta" );
						return false;
					}
					
					string st_senha_atual = var_util.getMd5Hash ( ctrl_TxtSenhaAtual.getTextBoxValue() );
					string st_senha_nova  = var_util.getMd5Hash ( ctrl_TxtNovaSenha.getTextBoxValue() );
					
					if ( var_exchange.exec_trocaSenha ( st_senha_atual, 
						                              	st_senha_nova, 
						                              	ref header ) )
					{
						var_IsCanceled = false;
						i_Form.Close();
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtSenhaAtual -
				
				case event_val_TxtSenhaAtual:
				{
					//InitEventCode event_val_TxtSenhaAtual
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtSenhaAtual.getTextBoxValue().Length > 3 )
							{
								i_Form.TxtSenhaAtual.BackColor = Color.White;	
								ctrl_TxtSenhaAtual.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtSenhaAtual.BackColor = colorInvalid;	
								ctrl_TxtSenhaAtual.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtNovaSenha -
				
				case event_val_TxtNovaSenha:
				{
					//InitEventCode event_val_TxtNovaSenha
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtNovaSenha.getTextBoxValue().Length > 3 )
							{
								i_Form.TxtNovaSenha.BackColor = Color.White;	
								ctrl_TxtNovaSenha.IsUserValidated = true;
								ctrl_TxtNovaSenha.CleanError();
							}
							else
							{
								i_Form.TxtNovaSenha.BackColor = colorInvalid;	
								ctrl_TxtNovaSenha.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtConfirmaSenha -
				
				case event_val_TxtConfirmaSenha:
				{
					//InitEventCode event_val_TxtConfirmaSenha
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtConfirmaSenha.getTextBoxValue().Length > 3 )
							{
								i_Form.TxtConfirmaSenha.BackColor = Color.White;	
								ctrl_TxtConfirmaSenha.IsUserValidated = true;
								ctrl_TxtConfirmaSenha.CleanError();
							}
							else
							{
								i_Form.TxtConfirmaSenha.BackColor = colorInvalid;	
								ctrl_TxtConfirmaSenha.IsUserValidated = false;
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
