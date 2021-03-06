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
	public class event_dlgFaturamento : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_val_TxtCodigo = 5;
		#endregion

		public dlgFaturamento i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController ctrl_TxtCodigo	= new numberTextController();
		
		Color 	colorInvalid 	= Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgFaturamento ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgFaturamento ( this );
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
					
					ctrl_TxtCodigo.AcquireTextBox ( i_Form.TxtCodigo, this, event_val_TxtCodigo, 6 );
					
					i_Form.CboTipo.SelectedIndex = 1;
										
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
				
				#region - event_val_TxtCodigo -
				
				case event_val_TxtCodigo:
				{
					//InitEventCode event_val_TxtCodigo
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtCodigo.Text.Length > 0 )
							{
								i_Form.TxtCodigo.BackColor     = Color.White;	
								ctrl_TxtCodigo.IsUserValidated = true;
								ctrl_TxtCodigo.CleanError();
								
								if ( ctrl_TxtCodigo.GetEnterPressed() )
								{
									if ( i_Form.CboTipo.SelectedIndex != -1 )
									{
										string msg = "";
										string tg_empresa = Context.FALSE;
										string vr_valor = "";
										
										if ( i_Form.CboTipo.SelectedIndex == 0 )
											tg_empresa = Context.TRUE;
										
										if ( var_exchange.fetch_dadosFaturamento ( 	tg_empresa,
										                                      		ctrl_TxtCodigo.getTextBoxValue(), 
										                                      		ref header, 
										                                      		ref msg, 
										                                      		ref vr_valor ) )
										{
											i_Form.TxtResponse.Text = msg.Replace ( "@","\r\n" );
										}
									}
								}
							}
							else
							{
								i_Form.TxtCodigo.BackColor     = colorInvalid;	
								ctrl_TxtCodigo.IsUserValidated = false;
								
								if ( ctrl_TxtCodigo.GetEnterPressed() )
								{
									event_dlgConsultaEmpresa ev_call = new event_dlgConsultaEmpresa ( var_util, var_exchange );
					
									ev_call.header = header;
									
									ev_call.i_Form.ShowDialog();
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
		
				default: break;
			}
		
			return false;
		}
	}
}
