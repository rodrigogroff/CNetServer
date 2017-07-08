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
	public class event_dlgVendaOnline : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int event_val_TxtMoney_Valor = 3;
		public const int event_val_TxtCartao = 4;
		public const int event_val_TxtSenha = 5;
		public const int event_Confirmar = 6;
		#endregion

		public dlgVendaOnline i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		moneyTextController  	   	ctrl_TxtMoney_Valor = new moneyTextController();
		pincardTextController 	ctrl_TxtCartao	= new pincardTextController();
		pinpadTextController 	ctrl_TxtSenha   = new pinpadTextController();
		
		Color 	colorInvalid = Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgVendaOnline ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgVendaOnline ( this );
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
					
					ctrl_TxtMoney_Valor.AcquireTextBox 	( i_Form.TxtMoney_Valor, this, event_val_TxtMoney_Valor, "R$", 8 );
					ctrl_TxtMoney_Valor.SetupErrorProvider   ( ErrorIconAlignment.MiddleRight, false ); 
					
					ctrl_TxtSenha.AcquireTextBox 		( i_Form.TxtSenha,  this, event_val_TxtSenha, 	 4 		);
					ctrl_TxtCartao.AcquireTextBox 		( i_Form.TxtCartao, this, event_val_TxtCartao,  15  	);
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtMoney_Valor -
				
				case event_val_TxtMoney_Valor:
				{
					//InitEventCode event_val_TxtMoney_Valor
					
					string myValEv = arg as string;
					
					if ( myValEv == moneyTextController.MONEY_ZERO )
					{
						i_Form.TxtMoney_Valor.BackColor = Color.Lavender;
						ctrl_TxtMoney_Valor.IsUserValidated = false;
						ctrl_TxtMoney_Valor.CleanError();
					}
					else
					{
						i_Form.TxtMoney_Valor.BackColor = Color.White;
						ctrl_TxtMoney_Valor.IsUserValidated = true;
						ctrl_TxtMoney_Valor.CleanError();
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
				
				#region - event_Confirmar -
				
				case event_Confirmar:
				{
					//InitEventCode event_Confirmar
					
					if ( !ctrl_TxtMoney_Valor.IsUserValidated )
						return false;
					
					var_exchange.m_Client.QuietMode = true;
					
					POS_Entrada  pe = new POS_Entrada();
			
					string cript_senha = new ApplicationUtil().DESCript ( ctrl_TxtSenha.getTextBoxValue().PadLeft ( 8, '*' ), "12345678" );
					
					pe.set_st_senha    		( cript_senha 															);
		            pe.set_st_empresa   	( ctrl_TxtCartao.getTextBoxValue().Substring ( 0, 6 ) 					);
		            pe.set_st_matricula 	( ctrl_TxtCartao.getTextBoxValue().Substring ( 6, 6 ) 					);
		            pe.set_st_titularidade 	( ctrl_TxtCartao.getTextBoxValue().Substring ( 12, 2 ) 					);
					pe.set_vr_valor			( ctrl_TxtMoney_Valor.getTextBoxValue_NumberStr().PadLeft ( 12, '0' ) 	);
					pe.set_st_terminal		( header.get_nu_terminal()												);
					pe.set_nu_parcelas		( "1"																	);
					
					pe.set_st_valores		( ctrl_TxtMoney_Valor.getTextBoxValue_NumberStr().PadLeft ( 12, '0' ) );
					
					POS_Resposta resp = new POS_Resposta();
					
					string msg = "";
					
					if ( var_exchange.exec_pos_vendaEmpresarial ( ref pe, 
		                                                          ref msg, 
		                                                          ref resp ) )
		            {
			            string nsu_venda = resp.get_st_nsuRcb();
			            
			            if ( var_exchange.exec_pos_confirmaVendaEmpresarial ( nsu_venda, 
			                                                                  ref pe, 
			                                                                  ref msg, 
			                                                                  ref resp ) )
			            {
			            	MessageBox.Show ( "Venda online confirmada", "Aviso" );
			            }
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
