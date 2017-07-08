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
	public class event_dlgNovoDependente : EventLayer
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
		public const int event_val_TxtNome = 8;
		public const int event_BtnConfirmarClick = 9;
		#endregion

		public dlgNovoDependente i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController 	ctrl_TxtEmpresa		= new numberTextController();
		numberTextController 	ctrl_TxtMatricula	= new numberTextController();
		alphaTextController		ctrl_TxtNome		= new alphaTextController();
		
		Color colorInvalid = Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgNovoDependente ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgNovoDependente ( this );
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
					
					ctrl_TxtEmpresa.AcquireTextBox 	 ( i_Form.TxtEmpresa, 	this, event_val_TxtEmpresa, 	6  );
					ctrl_TxtMatricula.AcquireTextBox ( i_Form.TxtMatricula, this, event_val_TxtMatricula, 	6  );
					ctrl_TxtNome.AcquireTextBox 	 ( i_Form.TxtNome, 		this, event_val_TxtNome, 		20	);
					
					if ( header.get_tg_user_type() == TipoUsuario.Administrador || 
				     	 header.get_tg_user_type() == TipoUsuario.Operador )
					{
						ctrl_TxtEmpresa.SetTextBoxText ( header.get_st_empresa() );
						i_Form.TxtEmpresa.ReadOnly = true;
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
					
					if ( i_Form.TxtProt.Text.Length == 0 )
					{
						MessageBox.Show ( "Confirme o cartão de proprietário", "Aviso" );
						return false;
					}
					
					if ( !ctrl_TxtEmpresa.IsUserValidated )
					{
						MessageBox.Show ( "Informe a empresa corretamente", "Aviso" );
						return false;
					}
					
					if ( !ctrl_TxtMatricula.IsUserValidated )
					{
						MessageBox.Show ( "Informe a matricula corretamente e depois pressione enter para validação", "Aviso" );
						return false;
					}
					
					if ( !ctrl_TxtNome.IsUserValidated )
					{
						MessageBox.Show ( "Preencha o nome do dependente corretamente", "Aviso" );
						return false;
					}		
					
					var_exchange.ins_dependente ( ctrl_TxtEmpresa.getTextBoxValue(),
					                              ctrl_TxtMatricula.getTextBoxValue(),
					                              ctrl_TxtNome.getTextBoxValue(),
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
								i_Form.TxtMatricula.BackColor = Color.White;
								ctrl_TxtMatricula.IsUserValidated = true;
								ctrl_TxtMatricula.CleanError();
								
								if ( ctrl_TxtMatricula.GetEnterPressed() )
								{
									string output_nu_maxParcelas = "";
									string output_vr_dispMes 	 = "";
									string output_vr_dispTotal   = "";
									string output_st_nome 	 	 = "";
									
									var_exchange.fetch_dadosCartao ( ctrl_TxtEmpresa.getTextBoxValue(),
									                                 ctrl_TxtMatricula.getTextBoxValue(),
									                                 "01",
									                                 ref header,
									                                 ref output_nu_maxParcelas,
									                                 ref output_vr_dispMes,
									                                 ref output_vr_dispTotal,
									                                 ref output_st_nome );
									
									i_Form.TxtProt.Text = output_st_nome;
								}
							}
							else
							{
								i_Form.TxtMatricula.BackColor = colorInvalid;
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
