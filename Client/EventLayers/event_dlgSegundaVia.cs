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
	public class event_dlgSegundaVia : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_val_TxtEmpresa = 6;
		public const int event_val_TxtMatricula = 7;
		public const int event_val_TxtTitularidade = 8;
		public const int event_BuscaDados = 9;
		public const int event_BtnConfirmarClick = 10;
		#endregion

		public dlgSegundaVia i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController 		ctrl_TxtEmpresa			= new numberTextController();
		numberTextController 		ctrl_TxtMatricula		= new numberTextController();
		numberTextController 		ctrl_TxtTitularidade	= new numberTextController();
		
		Color 	colorInvalid 	= Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgSegundaVia ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgSegundaVia ( this );
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
					
					ctrl_TxtEmpresa.AcquireTextBox 		( i_Form.TxtEmpresa, 		this, event_val_TxtEmpresa, 		6 );
					ctrl_TxtMatricula.AcquireTextBox 	( i_Form.TxtMatricula, 		this, event_val_TxtMatricula, 		6 );
					ctrl_TxtTitularidade.AcquireTextBox ( i_Form.TxtTitularidade, 	this, event_val_TxtTitularidade,	2 );
					
					ctrl_TxtEmpresa.SetupErrorProvider ( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtMatricula.SetupErrorProvider ( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtTitularidade.SetupErrorProvider ( ErrorIconAlignment.MiddleRight, false );
					
					if ( header.get_tg_user_type () ==  TipoUsuario.Administrador || 
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
					
					if ( !ctrl_TxtEmpresa.IsUserValidated )
					{	ctrl_TxtEmpresa.SetErrorMessage 		( "Código de empresa deve estar preenchido" );	return false;	}
					
					if ( !ctrl_TxtMatricula.IsUserValidated )
					{	ctrl_TxtMatricula.SetErrorMessage 		( "Código de matrícula deve estar preenchido" );	return false;	}
					
					if ( !ctrl_TxtTitularidade.IsUserValidated )
					{	ctrl_TxtTitularidade.SetErrorMessage 	( "Código de titularidade deve estar preenchido" );	return false;	}
					
					var_exchange.exec_segundaVia ( ctrl_TxtEmpresa.getTextBoxValue(),
					                              ctrl_TxtMatricula.getTextBoxValue(),
					                              ctrl_TxtTitularidade.getTextBoxValue(),
					                              ref header );
					
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
								
								if ( ctrl_TxtEmpresa.GetEnterPressed() )
								{
									doEvent ( event_BuscaDados, null );
								}
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
								
								if ( ctrl_TxtMatricula.GetEnterPressed() )
								{
									doEvent ( event_BuscaDados, null );
								}
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
								
								if ( ctrl_TxtTitularidade.GetEnterPressed() )
								{
									doEvent ( event_BuscaDados, null );
								}
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
				
				#region - event_BuscaDados -
				
				case event_BuscaDados:
				{
					//InitEventCode event_BuscaDados
					
					string maxParc = "";
					string dispMes = "";
					string dispTot = "";
					string st_nome = "";
					
					var_exchange.fetch_dadosCartao ( ctrl_TxtEmpresa.getTextBoxValue().PadLeft ( 6, '0' ),
					                                ctrl_TxtMatricula.getTextBoxValue().PadLeft ( 6, '0' ),
					                                ctrl_TxtTitularidade.getTextBoxValue().PadLeft ( 2, '0' ),
					                                ref header,
					                                ref maxParc,
					                                ref dispMes,
					                                ref dispTot,
					                                ref st_nome );
					                                
					       
					i_Form.TxtNome.Text = st_nome;
					
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
