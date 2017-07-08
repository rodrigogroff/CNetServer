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
	public class event_dlgRecargaGift : EventLayer
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
		public const int event_val_TxtTit = 8;
		public const int event_val_TxtCartao = 9;
		public const int event_BtnConfirmarClick = 10;
		#endregion

		public dlgRecargaGift i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController 	ctrl_TxtEmpresa		= new numberTextController();
		numberTextController 	ctrl_TxtMatricula	= new numberTextController();
		
		Color 	colorInvalid = Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgRecargaGift ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgRecargaGift ( this );
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
					
					ctrl_TxtEmpresa.AcquireTextBox 		( i_Form.TxtEmpresa, 	this, event_val_TxtEmpresa, 	6 );
					ctrl_TxtMatricula.AcquireTextBox 	( i_Form.TxtMatricula, 	this, event_val_TxtMatricula, 	6 );
					
					if ( header.get_tg_user_type() == TipoUsuario.VendedorGift || 
					     header.get_tg_user_type() == TipoUsuario.AdminGift ||
					     header.get_tg_user_type() == TipoUsuario.Operador ||
					     header.get_tg_user_type() == TipoUsuario.Administrador )
					{
						ctrl_TxtEmpresa.SetTextBoxText  ( header.get_st_empresa() );
						i_Form.TxtEmpresa.ReadOnly 		= true ;
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
					
					DadosProprietario dp = new DadosProprietario();
					DadosCartao dc = new DadosCartao();
					DadosAdicionais da = new DadosAdicionais();
					
					if ( var_exchange.fetch_proprietarioGift ( ctrl_TxtMatricula.getTextBoxValue(), ref header, ref dp ) )
					{
						dc.set_st_empresa 	( ctrl_TxtEmpresa.getTextBoxValue() 	);
						dc.set_st_matricula ( ctrl_TxtMatricula.getTextBoxValue() 	);
						
						event_dlgConfGiftCard ev_call = new event_dlgConfGiftCard ( var_util, var_exchange );
						
						ev_call.header  = header;
						ev_call.dp 	    = dp;
						ev_call.da 	    = da;
						ev_call.dc 	    = dc;
						ev_call.recarga = true;
											
						ev_call.i_Form.ShowDialog();
						i_Form.Close();
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
									doEvent ( event_val_TxtCartao, null );
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
									doEvent ( event_val_TxtCartao, null );
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
				
				#region - event_val_TxtTit -
				
				case event_val_TxtTit:
				{
					//InitEventCode event_val_TxtTit
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCartao -
				
				case event_val_TxtCartao:
				{
					//InitEventCode event_val_TxtCartao
					
					if ( !ctrl_TxtEmpresa.IsUserValidated && 
					     !ctrl_TxtMatricula.IsUserValidated )
						return false;
					
					string empresa      = ctrl_TxtEmpresa.getTextBoxValue();
					string matricula    = ctrl_TxtMatricula.getTextBoxValue();
					string titularidade = "01";
					
					string output_nu_maxParcelas 	= "";
					string output_vr_dispMes 		= "";
					string output_vr_dispTotal 		= "";
					string output_st_nome 			= "";
							
					if ( var_exchange.fetch_dadosCartao ( 	empresa, 
					                                     	matricula, 
					                                     	titularidade, 
					                                     	ref header, 
					                                     	ref output_nu_maxParcelas, 
					                                     	ref output_vr_dispMes,
					                                    	ref output_vr_dispTotal,
					                                   		ref output_st_nome ) )
					{
						 i_Form.TxtNome.Text = output_st_nome;
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
