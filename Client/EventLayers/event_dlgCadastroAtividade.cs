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
	public class event_dlgCadastroAtividade : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_val_TxtMesHor = 6;
		public const int event_val_TxtSemHor = 7;
		public const int event_val_TxtDiaHor = 8;
		public const int event_val_TxtEmpresa = 9;
		public const int event_val_TxtDiaMes = 10;
		public const int event_BtnConfirmarClick = 11;
		#endregion

		public dlgCadastroAtividade i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		dateTimeTextController	ctrl_TxtMesHor = new dateTimeTextController();
		dateTimeTextController	ctrl_TxtSemHor = new dateTimeTextController();
		dateTimeTextController	ctrl_TxtDiaHor = new dateTimeTextController();
		
		numberTextController	ctrl_TxtEmpresa = new numberTextController();
		numberTextController	ctrl_TxtDiaMes = new numberTextController();
			
		Color colorInvalid = Color.Lavender;
		
		public bool HouveCadastro = false;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgCadastroAtividade ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgCadastroAtividade ( this );
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
					
					ctrl_TxtMesHor.AcquireTextBox 		( i_Form.TxtMesHor,		this, event_val_TxtMesHor, 	dateTimeTextController.FORMAT_HHMM );
					ctrl_TxtSemHor.AcquireTextBox 		( i_Form.TxtSemHor,		this, event_val_TxtSemHor, 	dateTimeTextController.FORMAT_HHMM );
					ctrl_TxtDiaHor.AcquireTextBox 		( i_Form.TxtDiaHor,		this, event_val_TxtDiaHor, 	dateTimeTextController.FORMAT_HHMM );
					ctrl_TxtEmpresa.AcquireTextBox 		( i_Form.TxtEmpresa,	this, event_val_TxtEmpresa, 6 );
					ctrl_TxtDiaMes.AcquireTextBox 		( i_Form.TxtDiaMes,		this, event_val_TxtDiaMes,  2 );
					
					ctrl_TxtEmpresa.SetupErrorProvider  ( ErrorIconAlignment.MiddleRight, false ); 
					
					i_Form.CboAtiv.Items.AddRange ( new TipoAtividadeDesc().GetArray().ToArray() );
					
					if ( header.get_tg_user_type() != TipoUsuario.SuperUser  && 
					     header.get_tg_user_type() == TipoUsuario.Operador)
					{
						ctrl_TxtEmpresa.SetTextBoxText ( header.get_st_empresa() );
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
					
					if ( i_Form.CboAtiv.SelectedIndex == -1 )
					{
						MessageBox.Show ( "Selecione a atividade", "Aviso" );
						return false;
					}
					
					if ( !ctrl_TxtEmpresa.IsUserValidated )	
					{ 
						ctrl_TxtEmpresa.SetErrorMessage ( "Código da empresa deve ser informado" );	
						return false;	
					}
					
					string en_tipo_schedule = "";
					string st_horario = "";
					string st_aux = "";
					
					if ( ctrl_TxtDiaHor.IsUserValidated )
					{
						en_tipo_schedule = Scheduler.Daily;
						st_horario       = ctrl_TxtDiaHor.getTextBoxValue();
					}
					else if ( ctrl_TxtSemHor.IsUserValidated )
					{
						if ( i_Form.CboDiaSem.SelectedIndex == -1 )
						{
							MessageBox.Show ( "Escolha o dia da semana para a atividade", "Aviso" );
							return false;
						}
						
						en_tipo_schedule = Scheduler.Weekly;
						st_horario       = ctrl_TxtSemHor.getTextBoxValue();
						st_aux           = i_Form.CboDiaSem.SelectedIndex.ToString();
					}
					else if ( ctrl_TxtMesHor.IsUserValidated )
					{
						if ( !ctrl_TxtDiaMes.IsUserValidated )
						{
							MessageBox.Show ( "Escolha o dia do mês para a atividade", "Aviso" );
							return false;
						}
						
						en_tipo_schedule = Scheduler.Monthly;
						st_horario       = ctrl_TxtMesHor.getTextBoxValue();
						st_aux           = ctrl_TxtDiaMes.getTextBoxValue();
					}
					
					var_exchange.ins_agenda ( 	ctrl_TxtEmpresa.getTextBoxValue(), 
					                         	( i_Form.CboAtiv.SelectedIndex + 1 ).ToString(),
								            	en_tipo_schedule, 
								            	st_horario.Replace ( ":",""),
								            	st_aux,
								            	i_Form.CboAff.SelectedItem.ToString(),
								            	ref header );
			
					HouveCadastro = true;
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtMesHor -
				
				case event_val_TxtMesHor:
				{
					//InitEventCode event_val_TxtMesHor
					
					switch ( arg as string )
					{
						case dateTimeTextController.DATE_INVALID:
						{
							i_Form.TxtMesHor.BackColor = colorInvalid;	
							ctrl_TxtMesHor.IsUserValidated = false;
							break;
						}
							
						case dateTimeTextController.DATE_VALID:
						{
							i_Form.TxtMesHor.BackColor = Color.White;	
							ctrl_TxtMesHor.IsUserValidated = true;
							ctrl_TxtMesHor.CleanError();
							
							ctrl_TxtSemHor.SetTextBoxText ( "" );
							ctrl_TxtDiaHor.SetTextBoxText ( "" );
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtSemHor -
				
				case event_val_TxtSemHor:
				{
					//InitEventCode event_val_TxtSemHor
					
					switch ( arg as string )
					{
						case dateTimeTextController.DATE_INVALID:
						{
							i_Form.TxtSemHor.BackColor = colorInvalid;	
							ctrl_TxtSemHor.IsUserValidated = false;
							break;
						}
							
						case dateTimeTextController.DATE_VALID:
						{
							i_Form.TxtSemHor.BackColor = Color.White;	
							ctrl_TxtSemHor.IsUserValidated = true;
							ctrl_TxtSemHor.CleanError();
							
							ctrl_TxtMesHor.SetTextBoxText ( "" );
							ctrl_TxtDiaHor.SetTextBoxText ( "" );
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDiaHor -
				
				case event_val_TxtDiaHor:
				{
					//InitEventCode event_val_TxtDiaHor
					
					switch ( arg as string )
					{
						case dateTimeTextController.DATE_INVALID:
						{
							i_Form.TxtDiaHor.BackColor = colorInvalid;	
							ctrl_TxtDiaHor.IsUserValidated = false;
							break;
						}
							
						case dateTimeTextController.DATE_VALID:
						{
							i_Form.TxtDiaHor.BackColor = Color.White;	
							ctrl_TxtDiaHor.IsUserValidated = true;
							ctrl_TxtDiaHor.CleanError();
							
							ctrl_TxtMesHor.SetTextBoxText ( "" );
							ctrl_TxtSemHor.SetTextBoxText ( "" );
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
									ArrayList lst = new ArrayList();
									
									string nome_emp = "";
									
									var_exchange.fetch_empresasAfiliadas ( 	ctrl_TxtEmpresa.getTextBoxValue(),
									                                      	ref header,
									                                      	ref nome_emp,
									                                      	ref lst );
									
									i_Form.CboAff.Items.Clear();
									
									i_Form.TxtNome.Text = nome_emp;
									
									for ( int t =0 ; t < lst.Count; ++t )
									{
										DadosEmpresa de = new DadosEmpresa ( lst [t] as DataPortable );
										
										i_Form.CboAff.Items.Add ( de.get_st_empresa() );
									}
									
									if ( lst.Count == 0 )
									{
										i_Form.CboAff.Items.Add ( "" );
									}
									
									i_Form.CboAff.SelectedIndex = 0;
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
				
				#region - event_val_TxtDiaMes -
				
				case event_val_TxtDiaMes:
				{
					//InitEventCode event_val_TxtDiaMes
					
					if ( ctrl_TxtDiaMes.getTextBoxValue_Long() > 28 || 
					     ctrl_TxtDiaMes.getTextBoxValue_Long() < 1 )
					{
						i_Form.TxtDiaMes.BackColor     = colorInvalid;	
						ctrl_TxtDiaMes.IsUserValidated = false;
					}
					else
					{
						i_Form.TxtDiaMes.BackColor     = Color.White;	
						ctrl_TxtDiaMes.IsUserValidated = true;
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
