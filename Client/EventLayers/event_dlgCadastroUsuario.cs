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
	public class event_dlgCadastroUsuario : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_val_TxtNome = 6;
		public const int event_val_TxtSenha = 7;
		public const int event_val_TxtEmpresa = 8;
		public const int event_BtnConfirmarClick = 9;
		#endregion

		public dlgCadastroUsuario i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		alphaTextController		ctrl_TxtNome  	= new alphaTextController();
		alphaTextController		ctrl_TxtSenha 	= new alphaTextController();
		numberTextController 	ctrl_TxtEmpresa	= new numberTextController();
		
		Color 	colorInvalid = Color.Lavender;
							
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgCadastroUsuario ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgCadastroUsuario ( this );
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
					
					ctrl_TxtNome.AcquireTextBox 	( i_Form.TxtNome, 		this, event_val_TxtNome, 	20, alphaTextController.ENABLE_NUMBERS 									   );
					ctrl_TxtSenha.AcquireTextBox	( i_Form.TxtSenha,		this, event_val_TxtSenha,	16, alphaTextController.ENABLE_NUMBERS, alphaTextController.ENABLE_SYMBOLS );
					ctrl_TxtEmpresa.AcquireTextBox 	( i_Form.TxtEmpresa, 	this, event_val_TxtEmpresa, 6  );
					
					if ( header.get_tg_user_type() == TipoUsuario.SuperUser )
					{
						i_Form.CboNivel.Items.AddRange ( new TipoUsuarioDesc().GetArray().ToArray() );
					}
					else
					{
						ctrl_TxtEmpresa.SetTextBoxText ( header.get_st_empresa() );
						i_Form.TxtEmpresa.Enabled  = false;
					
						if ( header.get_tg_user_type() == TipoUsuario.Administrador )
						{
							i_Form.CboNivel.Items.Add ( TipoUsuarioDesc.Operador );
						}
						else if ( header.get_tg_user_type() == TipoUsuario.AdminGift )
						{
							i_Form.CboNivel.Items.Add ( TipoUsuarioDesc.VendedorGift );
							i_Form.CboNivel.Items.Add ( TipoUsuarioDesc.AdminGift 	 );
						}
					}
					
					i_Form.CboNivel.SelectedIndex = 0;
				
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
					
					if ( !ctrl_TxtNome.IsUserValidated )		
					{
						MessageBox.Show ( "Preencher o nome corretamente", "Aviso" ); 
						return false; 
					}
					
					if ( !ctrl_TxtSenha.IsUserValidated )		
					{ 
						MessageBox.Show ( "Preencher a senha corretamente", "Aviso" ); 
						return false; 
					}
					
					if ( i_Form.CboNivel.SelectedIndex.ToString() != TipoUsuario.OperadorCont && 
					     i_Form.CboNivel.SelectedIndex.ToString() != TipoUsuario.OperadorConvey && 
					     i_Form.CboNivel.SelectedIndex.ToString() != TipoUsuario.SuperUser && 
					     i_Form.CboNivel.SelectedIndex.ToString() != TipoUsuario.Lojista )
					{
						if ( !ctrl_TxtEmpresa.IsUserValidated )
						{ 
							MessageBox.Show ( "Preencher a empresa corretamente", "Aviso" ); 
							return false; 
						}
					}
			
					string tg_trocaSenha = Context.FALSE;
					
					if ( i_Form.ChkTrocaSenha.Checked )
						tg_trocaSenha = Context.TRUE;
					
					string st_senha  = var_util.getMd5Hash ( ctrl_TxtSenha.getTextBoxValue() );
					string nivel_cad = "";
					
					if ( header.get_tg_user_type() == TipoUsuario.SuperUser )
					{
						nivel_cad = i_Form.CboNivel.SelectedIndex.ToString();
					}
					else
					{
						if ( header.get_tg_user_type() == TipoUsuario.Administrador )
						{
							nivel_cad = TipoUsuario.Operador;
						}
						else if ( header.get_tg_user_type() == TipoUsuario.AdminGift )
						{
							if ( i_Form.CboNivel.SelectedIndex == 0 )
								nivel_cad = TipoUsuario.VendedorGift;
							else
								nivel_cad = TipoUsuario.AdminGift;
						}
					}
					
					var_exchange.ins_usuario ( 	ctrl_TxtNome.getTextBoxValue(), 
					  							st_senha, 
					                          	tg_trocaSenha, 
					                          	nivel_cad,
					                          	ctrl_TxtEmpresa.getTextBoxValue(),
					                          	ref header );
					
					if ( nivel_cad == TipoUsuario.Lojista )
					{
						event_dlgLojista ev_call = new event_dlgLojista ( var_util, var_exchange );
					
						ev_call.header = header;
						
						ev_call.i_Form.ShowDialog();						
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
				
				#region - event_val_TxtSenha -
				
				case event_val_TxtSenha:
				{
					//InitEventCode event_val_TxtSenha
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtSenha.getTextBoxValue().Length > 3 )
							{
								i_Form.TxtSenha.BackColor = Color.White;	
								ctrl_TxtSenha.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtSenha.BackColor = colorInvalid;	
								ctrl_TxtSenha.IsUserValidated = false;
							}
							
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
