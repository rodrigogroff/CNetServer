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
	public class event_dlgAlterarSenhaCartao : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_val_TxtSenha = 6;
		public const int event_val_TxtNovaSenha = 7;
		public const int event_val_TxtConfirmaSenha = 8;
		public const int event_val_TxtEmpresa = 9;
		public const int event_val_TxtMatricula = 10;
		public const int event_val_TxtTitularidade = 11;
		public const int event_BtnConfirmarClick = 12;
		#endregion

		public dlgAlterarSenhaCartao i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController	ctrl_TxtNovaSenha 		= new numberTextController();
		numberTextController	ctrl_TxtConfirmaSenha 	= new numberTextController();		
		numberTextController 	ctrl_TxtEmpresa			= new numberTextController();
		numberTextController 	ctrl_TxtMatricula		= new numberTextController();
		numberTextController 	ctrl_TxtTitularidade	= new numberTextController();
		
		Color 	colorInvalid = Color.Lavender;
			
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgAlterarSenhaCartao ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgAlterarSenhaCartao ( this );
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
				
					ctrl_TxtNovaSenha.AcquireTextBox			( i_Form.TxtNovaSenha,		this, event_val_TxtNovaSenha,	4 );
					ctrl_TxtConfirmaSenha.AcquireTextBox		( i_Form.TxtConfirmaSenha,	this, event_val_TxtConfirmaSenha,	4 );
					
					ctrl_TxtEmpresa.AcquireTextBox 				( i_Form.TxtEmpresa, 		this, event_val_TxtEmpresa, 6  );
					ctrl_TxtMatricula.AcquireTextBox 			( i_Form.TxtMatricula, 		this, event_val_TxtMatricula, 6  );
					ctrl_TxtTitularidade.AcquireTextBox 		( i_Form.TxtTitularidade, 	this, event_val_TxtTitularidade, 2  );
					
					ctrl_TxtNovaSenha.SetupErrorProvider 		( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtConfirmaSenha.SetupErrorProvider 	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtEmpresa.SetupErrorProvider 			( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtMatricula.SetupErrorProvider 		( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtTitularidade.SetupErrorProvider 	( ErrorIconAlignment.MiddleRight, false ); 
					
					if ( header.get_tg_user_type() == TipoUsuario.Administrador  || 
					     header.get_tg_user_type() == TipoUsuario.Operador )
					{
						ctrl_TxtEmpresa.SetTextBoxText ( header.get_st_empresa() );
						i_Form.TxtEmpresa.ReadOnly = true;
					}
					
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
					
					if ( !ctrl_TxtNovaSenha.IsUserValidated 		)	{	ctrl_TxtNovaSenha.SetErrorMessage 		( "Senha deve possuir 4 caracteres numéricos" 	);	IsDone = false;	}
					if ( !ctrl_TxtConfirmaSenha.IsUserValidated 	)	{	ctrl_TxtConfirmaSenha.SetErrorMessage 	( "Senha deve possuir 4 caracteres numéricos" 	);	IsDone = false;	}
					if ( !ctrl_TxtEmpresa.IsUserValidated 			)	{	ctrl_TxtEmpresa.SetErrorMessage 		( "Código de empresa não está preenchido" 		);	IsDone = false;	}
					if ( !ctrl_TxtMatricula.IsUserValidated 		)	{	ctrl_TxtMatricula.SetErrorMessage 		( "Código de matricula não está preenchido" 	);	IsDone = false;	}
					if ( !ctrl_TxtTitularidade.IsUserValidated 		)	{	ctrl_TxtTitularidade.SetErrorMessage 	( "Titularidade não está preenchida" 			);	IsDone = false;	}
					
					if ( !IsDone )
					{
						return false;
					}					
					
					var_exchange.exec_alteraSenhaCartao ( ctrl_TxtEmpresa.getTextBoxValue(), 
					                                     ctrl_TxtMatricula.getTextBoxValue(),
					                                     ctrl_TxtTitularidade.getTextBoxValue(),
					                                     "",
														 var_util.DESCript ( ctrl_TxtNovaSenha.getTextBoxValue().PadLeft (8, '*'), "12345678" ),
					                                     ref header );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtSenha -
				
				case event_val_TxtSenha:
				{
					//InitEventCode event_val_TxtSenha
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
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtNovaSenha.Text.Length == 4 )
							{
								i_Form.TxtNovaSenha.BackColor     = Color.White;	
								ctrl_TxtNovaSenha.IsUserValidated = true;
								ctrl_TxtNovaSenha.CleanError();
							}
							else
							{
								i_Form.TxtNovaSenha.BackColor     = colorInvalid;	
								ctrl_TxtNovaSenha.IsUserValidated = false;
							}
							
							break;
						}
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
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtConfirmaSenha.Text.Length == 4 )
							{
								i_Form.TxtConfirmaSenha.BackColor     = Color.White;	
								ctrl_TxtConfirmaSenha.IsUserValidated = true;
								ctrl_TxtConfirmaSenha.CleanError();
							}
							else
							{
								i_Form.TxtConfirmaSenha.BackColor     = colorInvalid;	
								ctrl_TxtConfirmaSenha.IsUserValidated = false;
							}
							
							break;
						}
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
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtEmpresa.Text.Length > 0 )
							{
								i_Form.TxtEmpresa.BackColor     = Color.White;	
								ctrl_TxtEmpresa.IsUserValidated = true;
								ctrl_TxtEmpresa.CleanError();
							}
							else
							{
								i_Form.TxtEmpresa.BackColor     = colorInvalid;	
								ctrl_TxtEmpresa.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtMatricula -
				
				case event_val_TxtMatricula:
				{
					//InitEventCode event_val_TxtMatricula
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtMatricula.Text.Length > 0 )
							{
								i_Form.TxtMatricula.BackColor     = Color.White;	
								ctrl_TxtMatricula.IsUserValidated = true;
								ctrl_TxtMatricula.CleanError();
							}
							else
							{
								i_Form.TxtMatricula.BackColor     = colorInvalid;	
								ctrl_TxtMatricula.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtTitularidade -
				
				case event_val_TxtTitularidade:
				{
					//InitEventCode event_val_TxtTitularidade
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtTitularidade.Text.Length > 0 )
							{
								i_Form.TxtTitularidade.BackColor     = Color.White;	
								ctrl_TxtTitularidade.IsUserValidated = true;
								ctrl_TxtTitularidade.CleanError();
							}
							else
							{
								i_Form.TxtTitularidade.BackColor     = colorInvalid;	
								ctrl_TxtTitularidade.IsUserValidated = false;
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
