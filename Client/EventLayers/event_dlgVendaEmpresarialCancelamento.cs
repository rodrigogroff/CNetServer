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
	public class event_dlgVendaEmpresarialCancelamento : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_val_TxtNSU = 5;
		public const int event_Confirmar = 6;
		public const int event_BuscaDados = 7;
		public const int event_val_TxtDtIni = 8;
		public const int event_BtnConfirmarClick = 9;
		#endregion

		public dlgVendaEmpresarialCancelamento i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController 	ctrl_TxtNSU   = new numberTextController();
		dateTextController		ctrl_TxtDtIni = new dateTextController();
		
		Color colorInvalid = Color.Lavender;
		
		public DadosNSU dn = new DadosNSU();
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgVendaEmpresarialCancelamento ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgVendaEmpresarialCancelamento ( this );
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
					
					ctrl_TxtNSU.AcquireTextBox ( i_Form.TxtNSU, this, event_val_TxtNSU, 6 );
					ctrl_TxtDtIni.AcquireTextBox 	( i_Form.TxtDtIni, 	this, event_val_TxtDtIni, 	dateTextController.FORMAT_DDMMYYYY );
					
					ctrl_TxtDtIni.SetTextBoxText 	( 	DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Year.ToString().PadLeft ( 2, '0' ) );
					
					ctrl_TxtNSU.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false );
					
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
				
				#region - event_val_TxtNSU -
				
				case event_val_TxtNSU:
				{
					//InitEventCode event_val_TxtNSU
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtNSU.Text.Length > 0 )
							{
								i_Form.TxtNSU.BackColor     = Color.White;	
								ctrl_TxtNSU.IsUserValidated = true;
								ctrl_TxtNSU.CleanError();
								
								if ( ctrl_TxtNSU.GetEnterPressed() )
								{
									doEvent ( event_BuscaDados, null );
								}
							}
							else
							{
								i_Form.TxtNSU.BackColor     = colorInvalid;	
								ctrl_TxtNSU.IsUserValidated = false;
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
					
					if ( !ctrl_TxtNSU.IsUserValidated )	{ ctrl_TxtNSU.SetErrorMessage ( "O numerode NSU deve ser informado" ); IsDone = false; }
		
					if ( !IsDone )
						return false;
					
					if ( !doEvent ( event_BuscaDados, null ) )
						return false;
					
					POS_Entrada pe = new POS_Entrada();
					POS_Resposta pr = new POS_Resposta();
					
					pe.set_st_terminal 		( dn.get_st_terminal() 		);
					pe.set_st_empresa  		( dn.get_st_empresa()		);
					pe.set_st_matricula 	( dn.get_st_matricula() 	);
					pe.set_st_titularidade 	( dn.get_st_titularidade() 	);
					pe.set_nu_parcelas		( "0" 						);
					
					string st_msg = "";
					
					var_exchange.m_Client.QuietMode = true;
					
					if ( var_exchange.exec_pos_cancelaVendaEmpresarial ( 	ctrl_TxtNSU.getTextBoxValue(), 
					                                                    	var_util.GetDataBaseTimeFormat ( ctrl_TxtDtIni.getTextBoxValue_Date() ),
					                                                    	header.get_st_user_id(),
						                                               		ref pe,
						                                               		ref st_msg,
						                                               		ref pr ) )
					{
						MessageBox.Show ( "Sucesso no cancelamento", "Aviso" );
					}
					else
					{
						MessageBox.Show ( st_msg, "Erro" );
					}
					
					var_exchange.m_Client.QuietMode = false;
										
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BuscaDados -
				
				case event_BuscaDados:
				{
					//InitEventCode event_BuscaDados
					
					if ( var_exchange.fetch_dadosNSU ( 	ctrl_TxtNSU.getTextBoxValue(), 
					                                  	var_util.GetDataBaseTimeFormat ( ctrl_TxtDtIni.getTextBoxValue_Date() ),
					                                  	TipoConfirmacao.Confirmada,
					                                  	ref header, 
					                                  	ref dn ) )
					{
						i_Form.TxtNome.Text 	= dn.get_st_nome();
						i_Form.TxtCartao.Text	= dn.get_st_cartao();
						i_Form.TxtData.Text		= dn.get_dt_operacao();
						i_Form.TxtValor.Text	= "R$ " + new money().formatToMoney ( dn.get_vr_valor() );
						
						ctrl_TxtNSU.SetTextBoxText ( ctrl_TxtNSU.getTextBoxValue().PadLeft ( 6, '0' ) );
					}
					else
						return false;
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDtIni -
				
				case event_val_TxtDtIni:
				{
					//InitEventCode event_val_TxtDtIni
					
					switch ( arg as string )
					{
						case dateTextController.DATE_INVALID:
						{
							i_Form.TxtDtIni.BackColor = colorInvalid;	
							ctrl_TxtDtIni.IsUserValidated = false;
							break;
						}
							
						case dateTextController.DATE_VALID:
						{
							i_Form.TxtDtIni.BackColor = Color.White;	
							ctrl_TxtDtIni.IsUserValidated = true;
							ctrl_TxtDtIni.CleanError();
							
							if ( ctrl_TxtDtIni.GetEnterPressed() )
							{
								doEvent ( event_BuscaDados, null );
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
