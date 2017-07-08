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
	public class event_dlgCancelaPendenciaPayFone : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_val_TxtTelefone = 5;
		public const int event_val_TxtNSU = 6;
		public const int event_Confirmar = 7;
		public const int event_BtnCOnfirmarClick = 8;
		#endregion

		public dlgCancelaPendenciaPayFone i_Form;

		//UserVariables
		
		public CNetHeader header;
			
		numberTextController  	ctrl_TxtNSU      = new numberTextController();
		numberTextController  	ctrl_TxtTelefone = new numberTextController();
		
		Color colorInvalid = Color.Lavender;		
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgCancelaPendenciaPayFone ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgCancelaPendenciaPayFone ( this );
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
					
					ctrl_TxtNSU.AcquireTextBox			( i_Form.TxtNSU, 		 this, event_val_TxtNSU, 			6 	);
					ctrl_TxtTelefone.AcquireTextBox		( i_Form.TxtTelefone,  	 this, event_val_TxtTelefone, 		10 	);
					
					ctrl_TxtNSU.SetupErrorProvider 			( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtTelefone.SetupErrorProvider 	( ErrorIconAlignment.MiddleRight, false );
					
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
				
				#region - event_val_TxtNSU -
				
				case event_val_TxtNSU:
				{
					//InitEventCode event_val_TxtNSU
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( ctrl_TxtNSU.getTextBoxValue().Length == 0 )
							{
								i_Form.TxtNSU.BackColor = colorInvalid;	
								ctrl_TxtNSU.IsUserValidated = false;
							}
							else							
							{
								i_Form.TxtNSU.BackColor = Color.White;	
								ctrl_TxtNSU.IsUserValidated = true;
								ctrl_TxtNSU.CleanError();
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
					
					if ( !ctrl_TxtTelefone.IsUserValidated )	{	ctrl_TxtTelefone.SetErrorMessage 	( "Telefone deve ter 10 caracteres" );	IsDone = false;	}
					if ( !ctrl_TxtNSU.IsUserValidated )			{	ctrl_TxtNSU.SetErrorMessage 		( "NSU deve estar preenchido" );	IsDone = false;	}
					
					if ( !IsDone )
						return false;
					
					StringBuilder sb_send_pend = new StringBuilder ( "05PFXP" );
					
					sb_send_pend.Append ( ctrl_TxtTelefone.getTextBoxValue() 							);
					sb_send_pend.Append ( ctrl_TxtNSU.getTextBoxValue().PadLeft ( 6, '0' ) );
					sb_send_pend.Append ( Context.FALSE 												);

					string buf_response = var_exchange.m_Client.WriteServerMsg ( sb_send_pend.ToString() );
					
					string cod_resp     = buf_response.Substring  ( 0,  2 );
					string msg          = buf_response.Substring  ( 2, 20 );
						
					if ( cod_resp == "00" )
					{
						MessageBox.Show ( "Sucesso no cancelamento", "Aviso" );
					}
					else
					{
						MessageBox.Show ( cod_resp + " - " +  msg, "Erro" );
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnCOnfirmarClick -
				
				case event_BtnCOnfirmarClick:
				{
					//InitEventCode event_BtnCOnfirmarClick
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
