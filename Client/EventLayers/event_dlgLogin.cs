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
	public class event_dlgLogin : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_val_TxtNome = 6;
		public const int event_val_TxtEmpresa = 7;
		public const int event_val_TxtSenha = 8;
		public const int event_BtnConfirmarClick = 9;
		#endregion

		public dlgLogin i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		alphaTextController			ctrl_TxtNome	= new alphaTextController();
		alphaTextController 		ctrl_TxtEmpresa	= new alphaTextController();
		alphaTextController			ctrl_TxtSenha	= new alphaTextController();
		
		Color 	colorInvalid = Color.Lavender;
		
		public bool var_IsCanceled   = true;
		public bool var_IsChangePass = false;
		
		public string var_st_nome = "";
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgLogin ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgLogin ( this );
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
					
					InstallData inst_data = new InstallData();
										
					i_Form.LblVersion.Text = inst_data.st_version;
					
					ctrl_TxtNome.AcquireTextBox 	( i_Form.TxtNome, 		this, event_val_TxtNome, 		20, alphaTextController.ENABLE_NUMBERS 			);
					ctrl_TxtEmpresa.AcquireTextBox 	( i_Form.TxtEmpresa, 	this, event_val_TxtEmpresa, 	8,  alphaTextController.ENABLE_NUMBERS  		);
					ctrl_TxtSenha.AcquireTextBox	( i_Form.TxtSenha,		this, event_val_TxtSenha,		16, alphaTextController.ENABLE_NUMBERS, alphaTextController.ENABLE_SYMBOLS );
					
					ctrl_TxtNome.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtEmpresa.SetupErrorProvider  ( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtSenha.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false );
										
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - robot_ShowDialog -
				
				case robot_ShowDialog:
				{
					//InitEventCode robot_ShowDialog
					
					if ( i_Form.IsDisposed ) i_Form = new dlgLogin ( this );
					
					i_Form.Show();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - robot_CloseDialog -
				
				case robot_CloseDialog:
				{
					//InitEventCode robot_CloseDialog
					
					i_Form.Close();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Confirmar -
				
				case event_Confirmar:
				{
					//InitEventCode event_Confirmar
					
					bool IsDone = true;
					
					if ( !ctrl_TxtNome.IsUserValidated )	{	ctrl_TxtNome.SetErrorMessage 	( "Nome incompleto" );	IsDone = false;	}
					if ( !ctrl_TxtSenha.IsUserValidated )	{	ctrl_TxtSenha.SetErrorMessage 	( "Senha incompleta" );	IsDone = false;	}
					
					if ( !IsDone )
					{
						return false;
					}
					
					string tg_trocaSenha  = "";
					string var_st_empresa = ctrl_TxtEmpresa.getTextBoxValue();
					string st_senha_atual = var_util.getMd5Hash ( ctrl_TxtSenha.getTextBoxValue() );
					
					if ( var_exchange.exec_login (  ctrl_TxtNome.getTextBoxValue(), 
					                              	var_st_empresa, 
					                              	st_senha_atual,
					                              	ref tg_trocaSenha, 
					                              	ref header ) )
					{
						if ( tg_trocaSenha == Context.TRUE )
						{
							var_IsChangePass = true;
						}
						
						var_IsCanceled = false;
						
						var_st_nome = ctrl_TxtNome.getTextBoxValue();
							
						i_Form.Close();
					}
					else
					{
						if ( !ctrl_TxtEmpresa.IsUserValidated )	
							ctrl_TxtEmpresa.SetErrorMessage ( "Código de empresa incompleto" );
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtNome -
				
				case event_val_TxtNome:
				{
					//InitEventCode event_val_TxtNome
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtNome.getTextBoxValue().Length > 3 )
							{
								i_Form.TxtNome.BackColor = Color.White;	
								ctrl_TxtNome.IsUserValidated = true;
								ctrl_TxtNome.CleanError();
							}
							else
							{
								i_Form.TxtNome.BackColor = colorInvalid;	
								ctrl_TxtNome.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtEmpresa -
				
				case event_val_TxtEmpresa:
				{
					//InitEventCode event_val_TxtEmpresa
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtEmpresa.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtEmpresa.BackColor = Color.White;	
								ctrl_TxtEmpresa.IsUserValidated = true;
								ctrl_TxtEmpresa.CleanError();
							}
							else
							{
								i_Form.TxtEmpresa.BackColor = colorInvalid;	
								ctrl_TxtEmpresa.IsUserValidated = false;
							}
							
							if ( ctrl_TxtEmpresa.GetEnterPressed() )
							{
								doEvent ( event_Confirmar, null );
							}
							
							break;
						}
							
						default: break;
					}
					
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
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtSenha.getTextBoxValue().Length > 3 )
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
							
							if ( ctrl_TxtSenha.GetEnterPressed() )
							{
								doEvent ( event_Confirmar, null );
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
