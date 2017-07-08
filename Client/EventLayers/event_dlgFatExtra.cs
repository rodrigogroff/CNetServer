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
	public class event_dlgFatExtra : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_val_TxtCodigo = 6;
		public const int event_val_TxtCobranca = 7;
		public const int event_BtnConfirmarClick = 8;
		#endregion

		public dlgFatExtra i_Form;

		//UserVariables
	
		public CNetHeader header;
		
		numberTextController ctrl_TxtCodigo	= new numberTextController();
		moneyTextController ctrl_TxtCobranca = new moneyTextController();
		
		Color 	colorInvalid 	= Color.Lavender;		
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgFatExtra ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgFatExtra ( this );
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
					
					ctrl_TxtCodigo.AcquireTextBox   ( i_Form.TxtCodigo, 	this, event_val_TxtCodigo,   		6 );
					ctrl_TxtCobranca.AcquireTextBox ( i_Form.TxtCobranca, 	this, event_val_TxtCobranca, "R$", 	6 );
					
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
					
					if ( ctrl_TxtCodigo.getTextBoxValue().Length == 0 )
						return false;
					
					if ( ctrl_TxtCobranca.getTextBoxValue_Long() == 0 )
						return false;
					
					string emp = Context.FALSE;
					string desconto = Context.FALSE;
					
					if ( i_Form.CboTipo.SelectedIndex == 0 )
						emp = Context.TRUE;		
					
					if ( i_Form.ChkDesconto.Checked )
						desconto = Context.TRUE;
					
					var_exchange.ins_despesa (  ctrl_TxtCobranca.getTextBoxValue_NumberStr(),
					                          	ctrl_TxtCodigo.getTextBoxValue(),
					                          	emp,
					                          	i_Form.TxtExtra.Text,
					                          	desconto,
					                          	ref header );
					
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
										if ( i_Form.CboTipo.SelectedIndex == 0 )
										{
											DadosEmpresa de = new DadosEmpresa();
											
											var_exchange.fetch_dadosEmpresa ( 	ctrl_TxtCodigo.getTextBoxValue(),
											                                 	ref header, 
											                                 	ref de );
											
											i_Form.TxtNome.Text = de.get_st_fantasia();
										}
										else
										{
											DadosLoja dl = new DadosLoja();
												
											var_exchange.fetch_dadosLoja ( 	"", 
											                              	ctrl_TxtCodigo.getTextBoxValue(),
											                              	ref header,
																			ref dl );
											
											i_Form.TxtNome.Text = dl.get_st_nome();
										}
									}
								}
							}
							else
							{
								i_Form.TxtCodigo.BackColor     = colorInvalid;	
								ctrl_TxtCodigo.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCobranca -
				
				case event_val_TxtCobranca:
				{
					//InitEventCode event_val_TxtCobranca
					
					if ( ctrl_TxtCobranca.getTextBoxValue_Long() == 0 )
					{
						i_Form.TxtCobranca.BackColor     = colorInvalid;	
						ctrl_TxtCobranca.IsUserValidated = false;
					}
					else
					{
						i_Form.TxtCobranca.BackColor     = Color.White;	
						ctrl_TxtCobranca.IsUserValidated = true;
						ctrl_TxtCobranca.CleanError();
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
