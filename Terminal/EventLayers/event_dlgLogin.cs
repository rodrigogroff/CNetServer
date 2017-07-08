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
		public const int event_val_TxtSt_Nome = 3;
		public const int event_val_TxtSt_Empresa = 4;
		public const int event_val_TxtSt_Senha = 5;
		public const int event_BtnConfirmarClick = 6;
		#endregion

		public dlgLogin i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		Color 	colorInvalid = Color.Lavender;
		
		public bool var_IsCanceled   = true;
		public bool var_IsChangePass = false;
		
		public string var_st_nome = "";
		
		alphaTextController  	   	ctrl_TxtSt_Nome = new alphaTextController();
		alphaTextController  	   	ctrl_TxtSt_Empresa = new alphaTextController();
		alphaTextController  	   	ctrl_TxtSt_Senha = new alphaTextController();
		
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
					ctrl_TxtSt_Nome.AcquireTextBox 	( i_Form.TxtSt_Nome, this, event_val_TxtSt_Nome, 20, alphaTextController.ENABLE_NUMBERS 			);
					ctrl_TxtSt_Empresa.AcquireTextBox 	( i_Form.TxtSt_Empresa, this, event_val_TxtSt_Empresa, 8,  alphaTextController.ENABLE_NUMBERS  		);
					ctrl_TxtSt_Senha.AcquireTextBox 	( i_Form.TxtSt_Senha, this, event_val_TxtSt_Senha, 16, alphaTextController.ENABLE_NUMBERS, alphaTextController.ENABLE_SYMBOLS );
					ctrl_TxtSt_Nome.SetupErrorProvider   ( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtSt_Empresa.SetupErrorProvider   ( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtSt_Senha.SetupErrorProvider   ( ErrorIconAlignment.MiddleRight, false ); 
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtSt_Nome -
				
				case event_val_TxtSt_Nome:
				{
					//InitEventCode event_val_TxtSt_Nome
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							ctrl_TxtSt_Nome.CleanError();
							if ( ctrl_TxtSt_Nome.getTextBoxValue().Length > 2 )
							{
								i_Form.TxtSt_Nome.BackColor = Color.White;
								ctrl_TxtSt_Nome.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtSt_Nome.BackColor = Color.Lavender;
								ctrl_TxtSt_Nome.IsUserValidated = false;
							}
							
							break;
						}
						
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtSt_Empresa -
				
				case event_val_TxtSt_Empresa:
				{
					//InitEventCode event_val_TxtSt_Empresa
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							ctrl_TxtSt_Empresa.CleanError();
							if ( ctrl_TxtSt_Empresa.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtSt_Empresa.BackColor = Color.White;
								ctrl_TxtSt_Empresa.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtSt_Empresa.BackColor = Color.Lavender;
								ctrl_TxtSt_Empresa.IsUserValidated = false;
							}
							
							break;
						}
						
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtSt_Senha -
				
				case event_val_TxtSt_Senha:
				{
					//InitEventCode event_val_TxtSt_Senha
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							ctrl_TxtSt_Senha.CleanError();
							if ( ctrl_TxtSt_Senha.getTextBoxValue().Length > 3 )
							{
								i_Form.TxtSt_Senha.BackColor = Color.White;
								ctrl_TxtSt_Senha.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtSt_Senha.BackColor = Color.Lavender;
								ctrl_TxtSt_Senha.IsUserValidated = false;
							}
							
							if ( ctrl_TxtSt_Senha.GetEnterPressed() )
							{
								doEvent ( event_BtnConfirmarClick, null );
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
					
					bool IsDone = true;
					
					if ( !ctrl_TxtSt_Nome.IsUserValidated )	{	ctrl_TxtSt_Nome.SetErrorMessage 	( "Nome incompleto" );	IsDone = false;	}
					if ( !ctrl_TxtSt_Senha.IsUserValidated )	{	ctrl_TxtSt_Senha.SetErrorMessage 	( "Senha incompleta" );	IsDone = false;	}
					
					if ( !IsDone )
					{
						return false;
					}
					
					string tg_trocaSenha  = "";
					string var_st_empresa = ctrl_TxtSt_Empresa.getTextBoxValue();
					string st_senha_atual = var_util.getMd5Hash ( ctrl_TxtSt_Senha.getTextBoxValue() );
					
					if ( var_exchange.exec_login (  ctrl_TxtSt_Nome.getTextBoxValue(), 
					                              	"l" + var_st_empresa, 
					                              	st_senha_atual,
					                              	ref tg_trocaSenha, 
					                              	ref header ) )
					{
						var_IsCanceled = false;
						i_Form.Close();
					}
					else
					{
						if ( !ctrl_TxtSt_Empresa.IsUserValidated )	
							ctrl_TxtSt_Empresa.SetErrorMessage ( "Código de empresa incompleto" );
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
