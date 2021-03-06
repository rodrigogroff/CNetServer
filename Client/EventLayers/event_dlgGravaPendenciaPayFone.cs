﻿using System;
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
	public class event_dlgGravaPendenciaPayFone : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_val_TxtTelefone = 6;
		public const int event_val_TxtTelLojista = 7;
		public const int event_val_TxtValor = 8;
		public const int event_BtnConfirmarClick = 9;
		#endregion

		public dlgGravaPendenciaPayFone i_Form;

		//UserVariables
		
		public CNetHeader header;

		numberTextController  	ctrl_TxtTelefone 		= new numberTextController();
		numberTextController  	ctrl_TxtTelLojista 		= new numberTextController();
		
		moneyTextController  	ctrl_TxtValor 			= new moneyTextController();
		
		Color 	colorInvalid 	= Color.Lavender;		
			
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgGravaPendenciaPayFone ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgGravaPendenciaPayFone ( this );
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
					
					ctrl_TxtTelefone.AcquireTextBox		( i_Form.TxtTelefone, 		this, event_val_TxtTelefone, 	10 			);
					ctrl_TxtTelLojista.AcquireTextBox	( i_Form.TxtTelLojista, 	this, event_val_TxtTelLojista, 	10 			);
					ctrl_TxtValor.AcquireTextBox		( i_Form.TxtValor,  	 	this, event_val_TxtValor, 		"R$",  	9 	);
					
					ctrl_TxtTelefone.SetupErrorProvider 	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtTelLojista.SetupErrorProvider 	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtValor.SetupErrorProvider 		( ErrorIconAlignment.MiddleRight, false ); 					
					
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
					
					if ( !ctrl_TxtTelefone.IsUserValidated )	{	ctrl_TxtTelefone.SetErrorMessage 		( "Telefone deve ter 10 caracteres" );	IsDone = false;	}
					if ( !ctrl_TxtTelLojista.IsUserValidated )	{	ctrl_TxtTelLojista.SetErrorMessage 		( "Telefone deve ter 10 caracteres" );	IsDone = false;	}
					if ( !ctrl_TxtValor.IsUserValidated )		{	ctrl_TxtValor.SetErrorMessage 			( "Valor deve estar preenchido" );	IsDone = false;	}
					
					if ( !IsDone )
						return false;
					
					StringBuilder sb_send_pend = new StringBuilder ( "05PFGP" );
					
					sb_send_pend.Append ( ctrl_TxtTelefone.getTextBoxValue() 							);
					sb_send_pend.Append ( ctrl_TxtTelLojista.getTextBoxValue() 							);
					sb_send_pend.Append ( ctrl_TxtValor.getTextBoxValue_NumberStr().PadLeft ( 12, '0' ) );
					sb_send_pend.Append ( Context.FALSE 												);

					string buf_response = var_exchange.m_Client.WriteServerMsg ( sb_send_pend.ToString() );
					
					string cod_resp     = buf_response.Substring  ( 0,  2 );
					string cod_nsu      = buf_response.Substring  ( 2,  6 );
					string msg_erro     = buf_response.Substring  ( 8, 20 );
						
					if ( cod_resp == "00" )
					{
						MessageBox.Show ( "Nsu: " +  cod_nsu, "Pendência gravada" );
					}
					else
					{
						MessageBox.Show ( cod_resp + " - " + msg_erro, "Falha na transação" );
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtTelefone -
				
				case event_val_TxtTelefone:
				{
					//InitEventCode event_val_TxtTelefone
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( ctrl_TxtTelefone.getTextBoxValue().Length < 10 )
							{
								i_Form.TxtTelefone.BackColor = colorInvalid;	
								ctrl_TxtTelefone.IsUserValidated = false;
							}
							else							
							{
								i_Form.TxtTelefone.BackColor = Color.White;	
								ctrl_TxtTelefone.IsUserValidated = true;
								ctrl_TxtTelefone.CleanError();
							}
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtTelLojista -
				
				case event_val_TxtTelLojista:
				{
					//InitEventCode event_val_TxtTelLojista
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( ctrl_TxtTelLojista.getTextBoxValue().Length < 10 )
							{
								i_Form.TxtTelLojista.BackColor = colorInvalid;	
								ctrl_TxtTelLojista.IsUserValidated = false;
							}
							else							
							{
								i_Form.TxtTelLojista.BackColor = Color.White;	
								ctrl_TxtTelLojista.IsUserValidated = true;
								ctrl_TxtTelLojista.CleanError();
							}
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtValor -
				
				case event_val_TxtValor:
				{
					//InitEventCode event_val_TxtValor
					
					switch ( arg as string )
					{
						case moneyTextController.MONEY_ZERO:
						{
							i_Form.TxtValor.BackColor = colorInvalid;	
							ctrl_TxtValor.IsUserValidated = false;
							break;
						}
							
						default:
						{
							i_Form.TxtValor.BackColor = Color.White;	
							ctrl_TxtValor.IsUserValidated = true;
							ctrl_TxtValor.CleanError();
							break;
						}
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
