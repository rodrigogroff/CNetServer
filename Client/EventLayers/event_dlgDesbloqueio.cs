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
	public class event_dlgDesbloqueio : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_val_TxtCartao = 5;
		public const int event_Confirmar = 6;
		public const int event_val_TxtEmpresa = 7;
		public const int event_val_TxtMatricula = 8;
		public const int event_val_TxtTit = 9;
		public const int event_BtnConfirmarClick = 10;
		#endregion

		public dlgDesbloqueio i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController 	ctrl_TxtEmpresa		= new numberTextController();
		numberTextController 	ctrl_TxtMatricula	= new numberTextController();
		numberTextController 	ctrl_TxtTit			= new numberTextController();
		
		Color 	colorInvalid = Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgDesbloqueio ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgDesbloqueio ( this );
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
					
					ctrl_TxtEmpresa.AcquireTextBox 		( i_Form.TxtEmpresa, 	this, event_val_TxtEmpresa, 6 );
					ctrl_TxtMatricula.AcquireTextBox 	( i_Form.TxtMatricula, 	this, event_val_TxtMatricula, 6 );
					ctrl_TxtTit.AcquireTextBox 			( i_Form.TxtTit, 		this, event_val_TxtTit, 2 );
					
					if ( header.get_tg_user_type() == TipoUsuario.VendedorGift || 
					    header.get_tg_user_type() == TipoUsuario.AdminGift ||
					     header.get_tg_user_type() == TipoUsuario.Operador ||
					     header.get_tg_user_type() == TipoUsuario.Administrador )
					{
						ctrl_TxtEmpresa.SetTextBoxText  ( header.get_st_empresa() );
						i_Form.TxtEmpresa.ReadOnly = true ;
						
						if ( header.get_tg_user_type() == TipoUsuario.VendedorGift || 
						    header.get_tg_user_type() == TipoUsuario.AdminGift 	)
						{
							ctrl_TxtTit.SetTextBoxText  ( "01" );
							i_Form.TxtTit.ReadOnly = true ;
						}
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
				
				#region - event_val_TxtCartao -
				
				case event_val_TxtCartao:
				{
					//InitEventCode event_val_TxtCartao
					
					if ( !ctrl_TxtEmpresa.IsUserValidated && 
					     !ctrl_TxtMatricula.IsUserValidated && 
					     !ctrl_TxtTit.IsUserValidated )
						return false;
										
					string empresa      = ctrl_TxtEmpresa.getTextBoxValue();
					string matricula    = ctrl_TxtMatricula.getTextBoxValue();
					string titularidade = ctrl_TxtTit.getTextBoxValue();
					
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
				
				#region - event_Confirmar -
				
				case event_Confirmar:
				{
					//InitEventCode event_Confirmar
					
					var_exchange.exec_desbloqueio ( ctrl_TxtEmpresa.getTextBoxValue().PadLeft ( 6, '0' ) +
					                            	ctrl_TxtMatricula.getTextBoxValue().PadLeft ( 6, '0' ) + 
					                            	ctrl_TxtTit.getTextBoxValue().PadLeft ( 2, '0' ),  
					                            	ref header );
					
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
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtTit.Text.Length > 0 )
							{
								i_Form.TxtTit.BackColor     = Color.White;	
								ctrl_TxtTit.IsUserValidated = true;
								ctrl_TxtTit.CleanError();
								
								if ( ctrl_TxtTit.GetEnterPressed() )
								{
									doEvent ( event_val_TxtCartao, null );
								}
							}
							else
							{
								i_Form.TxtTit.BackColor     = colorInvalid;	
								ctrl_TxtTit.IsUserValidated = false;
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
