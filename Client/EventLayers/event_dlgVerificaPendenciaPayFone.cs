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
	public class event_dlgVerificaPendenciaPayFone : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_val_TxtTelefone = 6;
		public const int event_BtnConfirmaClick = 7;
		#endregion

		public dlgVerificaPendenciaPayFone i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController  	ctrl_TxtTelefone 		= new numberTextController();
		
		Color 	colorInvalid 	= Color.Lavender;		
			
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgVerificaPendenciaPayFone ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgVerificaPendenciaPayFone ( this );
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
				
				#region - event_Confirmar -
				
				case event_Confirmar:
				{
					//InitEventCode event_Confirmar
					
					bool IsDone = true;
					
					if ( !ctrl_TxtTelefone.IsUserValidated )	{	ctrl_TxtTelefone.SetErrorMessage 		( "O telefone deve ser preenchido" );	IsDone = false;	}
					
					if ( !IsDone )
						return false;
					
					StringBuilder sb_send_pend = new StringBuilder ( "05PFCP" );
					
					sb_send_pend.Append ( ctrl_TxtTelefone.getTextBoxValue() 							);
					sb_send_pend.Append ( Context.FALSE 												);
					
					string buf_response = var_exchange.m_Client.WriteServerMsg ( sb_send_pend.ToString() );
					
					string cod_resp     = buf_response.Substring  (  0,  2 );
					string cod_nsu      = buf_response.Substring  (  2,  6 );
					string valor        = buf_response.Substring  (  8, 12 ).TrimStart('0');
					string nome_loja    = buf_response.Substring  ( 20, 25 );
					string msg_erro     = buf_response.Substring  ( 45, 20 );
						
					i_Form.LstPend.Items.Clear();
					
					if ( cod_resp == "00" )
					{
						i_Form.LstPend.Items.Add ( "" );
						i_Form.LstPend.Items.Add ( " Pendência cadastrada:" );
						i_Form.LstPend.Items.Add ( "" );
						i_Form.LstPend.Items.Add ( " Loja   " + nome_loja );
						i_Form.LstPend.Items.Add ( " Valor  R$" + new money().formatToMoney ( valor ) );
						i_Form.LstPend.Items.Add ( "" );
						i_Form.LstPend.Items.Add ( " NSU " + cod_nsu );
					}
					else
					{
						MessageBox.Show ( "Nenhuma pendência encontrada", "Aviso" );
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
								
								if ( ctrl_TxtTelefone.GetEnterPressed() )
								{
									doEvent ( event_Confirmar, null );
								}								
							}
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnConfirmaClick -
				
				case event_BtnConfirmaClick:
				{
					//InitEventCode event_BtnConfirmaClick
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
