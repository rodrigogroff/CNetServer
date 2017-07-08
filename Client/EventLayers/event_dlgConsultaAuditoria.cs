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
	public class event_dlgConsultaAuditoria : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Consultar = 5;
		public const int event_val_TxtDtIni = 6;
		public const int event_val_TxtDtFim = 7;
		public const int event_val_TxtNome = 8;
		public const int event_val_TxtObs = 9;
		public const int event_BtnConsultarClick = 10;
		#endregion

		public dlgConsultaAuditoria i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		alphaTextController			ctrl_TxtNome  = new alphaTextController();
		alphaTextController			ctrl_TxtObs	  = new alphaTextController();
		
		dateTextController			ctrl_TxtDtIni = new dateTextController();
		dateTextController			ctrl_TxtDtFim = new dateTextController();
		
		Color 		colorInvalid 		= Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgConsultaAuditoria ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgConsultaAuditoria ( this );
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
					
					i_Form.CboOper.Items.AddRange ( new TipoOperacaoDesc().GetArray().ToArray() );
					
					ctrl_TxtDtIni.AcquireTextBox 	( i_Form.TxtDtIni, 	this, event_val_TxtDtIni, 	dateTextController.FORMAT_DDMMYYYY );
					ctrl_TxtDtFim.AcquireTextBox 	( i_Form.TxtDtFim, 	this, event_val_TxtDtFim, 	dateTextController.FORMAT_DDMMYYYY );
					
					ctrl_TxtDtIni.SetTextBoxText 	( 	DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Year.ToString().PadLeft ( 2, '0' ) );
					
					ctrl_TxtDtFim.SetTextBoxText 	( 	DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Year.ToString().PadLeft ( 2, '0' ) );
					
					ctrl_TxtNome.AcquireTextBox		( i_Form.TxtNome, 		this, event_val_TxtNome, 	20 		);
					ctrl_TxtObs.AcquireTextBox		( i_Form.TxtObs, 		this, event_val_TxtObs, 	30, alphaTextController.ENABLE_NUMBERS		);
					
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
				
				#region - event_Consultar -
				
				case event_Consultar:
				{
					//InitEventCode event_Consultar
					
					i_Form.BtnConsultar.Enabled = false;
					
					DadosConsultaAuditoria dca = new DadosConsultaAuditoria();
					
					if ( i_Form.CboOper.SelectedIndex > 0 )
						dca.set_nu_oper ( ( i_Form.CboOper.SelectedIndex + 1) .ToString() );
					
					dca.set_st_user ( ctrl_TxtNome.getTextBoxValue() );
					dca.set_st_obs 	( ctrl_TxtObs.getTextBoxValue()	 );
					
					if ( ctrl_TxtDtIni.getTextBoxValue().Length > 0 )
						dca.set_dt_ini  ( var_util.GetDataBaseTimeFormat ( ctrl_TxtDtIni.getTextBoxValue_Date() ) );
					
					if ( ctrl_TxtDtFim.getTextBoxValue().Length > 0 )
						dca.set_dt_fim  ( var_util.GetDataBaseTimeFormat ( ctrl_TxtDtFim.getTextBoxValue_Date().AddHours ( 23 ).AddMinutes ( 59 )  ) );
					
					string st_csv_id = "";

					i_Form.LstAuditoria.Items.Clear();
					
					if ( var_exchange.fetch_consultaAuditoria ( ref dca, 
					                                      		ref header, 
					                                      		ref st_csv_id ) )
					{
						ArrayList full_memory = new ArrayList();
							
						while ( st_csv_id != "" )
						{
							ArrayList tmp_memory  = new ArrayList();
							
							if ( var_exchange.fetch_memory ( st_csv_id, "400",  ref st_csv_id, ref tmp_memory ) )
								for ( int t=0; t < tmp_memory.Count; ++t )
									full_memory.Add ( tmp_memory[t] );
						}
						
						ArrayList desc = new TipoOperacaoDesc().GetArray();
								
						for ( int t=0; t < full_memory.Count; ++t )
						{
							DadosAuditoria da = new DadosAuditoria ( full_memory[t] as DataPortable );
									
							int index = Convert.ToInt32 ( da.get_nu_oper() ) - 1;
									
							string [] full_row = new string [] { 	da.get_dt_operacao(), 
																	da.get_st_usuario(),
																	desc [ index ].ToString(),
																	da.get_st_obs(),
																	da.get_id_link()	};
								
							i_Form.LstAuditoria.Items.Add ( var_util.GetListViewItem ( "", full_row ) );
						}
						
						Application.DoEvents();							
					}
					
					i_Form.BtnConsultar.Enabled = true;
					
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
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDtFim -
				
				case event_val_TxtDtFim:
				{
					//InitEventCode event_val_TxtDtFim
					
					switch ( arg as string )
					{
						case dateTextController.DATE_INVALID:
						{
							i_Form.TxtDtFim.BackColor = colorInvalid;	
							ctrl_TxtDtFim.IsUserValidated = false;
							break;
						}
							
						case dateTextController.DATE_VALID:
						{
							i_Form.TxtDtFim.BackColor = Color.White;	
							ctrl_TxtDtFim.IsUserValidated = true;
							ctrl_TxtDtFim.CleanError();
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtNome -
				
				case event_val_TxtNome:
				{
					//InitEventCode event_val_TxtNome
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtNome.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtNome.BackColor = Color.White;	
								ctrl_TxtNome.IsUserValidated = true;
								ctrl_TxtNome.CleanError();
							}
							else
							{
								i_Form.TxtNome.BackColor = colorInvalid;	
								ctrl_TxtNome.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtObs -
				
				case event_val_TxtObs:
				{
					//InitEventCode event_val_TxtObs
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtObs.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtObs.BackColor = Color.White;	
								ctrl_TxtObs.IsUserValidated = true;
								ctrl_TxtObs.CleanError();
							}
							else
							{
								i_Form.TxtObs.BackColor = colorInvalid;	
								ctrl_TxtObs.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnConsultarClick -
				
				case event_BtnConsultarClick:
				{
					//InitEventCode event_BtnConsultarClick
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
