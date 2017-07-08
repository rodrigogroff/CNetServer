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
	public class event_dlgDadosCadastrais : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Alterar = 5;
		public const int event_val_TxtCpf = 6;
		public const int event_val_TxtNome = 7;
		public const int event_val_TxtEndereco = 8;
		public const int event_val_TxtNumero = 9;
		public const int event_val_TxtComplemento = 10;
		public const int event_val_txtBairro = 11;
		public const int event_val_TxtCidade = 12;
		public const int event_val_TxtEstado = 13;
		public const int event_val_TxtCEP = 14;
		public const int event_val_TxtDDD = 15;
		public const int event_val_TxtTelefone = 16;
		public const int event_val_TxtDtNasc = 17;
		public const int event_val_TxtEmail = 18;
		public const int event_val_TxtRenda = 19;
		public const int event_BtnAlterarClick = 20;
		#endregion

		public dlgDadosCadastrais i_Form;

		//UserVariables
		
		public CNetHeader header;

		public string cpf_cnpj = "";
		public DadosProprietario dp = new DadosProprietario();
		
		cpfCnpjTextController		ctrl_TxtCpf			= new cpfCnpjTextController();
		alphaTextController			ctrl_TxtNome		= new alphaTextController();
		alphaTextController			ctrl_TxtEndereco	= new alphaTextController();
		numberTextController		ctrl_TxtNumero		= new numberTextController();
		alphaTextController			ctrl_TxtComplemento	= new alphaTextController();
		alphaTextController			ctrl_TxtBairro		= new alphaTextController();
		alphaTextController			ctrl_TxtCidade		= new alphaTextController();
		alphaTextController			ctrl_TxtEstado		= new alphaTextController();
		numberTextController		ctrl_TxtCEP			= new numberTextController();
		numberTextController		ctrl_TxtDDD			= new numberTextController();
		numberTextController 		ctrl_TxtTelefone	= new numberTextController();
		dateTextController			ctrl_TxtDtNasc		= new dateTextController();
		emailTextController			ctrl_TxtEmail		= new emailTextController();
		moneyTextController  	   	ctrl_TxtRenda		= new moneyTextController();
		
		Color 		colorInvalid 		= Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgDadosCadastrais ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgDadosCadastrais ( this );
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
					
					ctrl_TxtCpf.AcquireTextBox 			( i_Form.TxtCpf, 			this, event_val_TxtCpf 						);
					ctrl_TxtNome.AcquireTextBox 		( i_Form.TxtNome, 			this, event_val_TxtNome, 		40, false	);
					ctrl_TxtEndereco.AcquireTextBox 	( i_Form.TxtEndereco, 		this, event_val_TxtEndereco, 	40, "" 		);
					ctrl_TxtNumero.AcquireTextBox 		( i_Form.TxtNumero, 		this, event_val_TxtNumero, 		6 			);
					ctrl_TxtComplemento.AcquireTextBox 	( i_Form.TxtComplemento, 	this, event_val_TxtComplemento, 40, alphaTextController.ENABLE_NUMBERS	);
					ctrl_TxtBairro.AcquireTextBox 		( i_Form.TxtBairro, 		this, event_val_txtBairro, 		40, false 	);
					ctrl_TxtCidade.AcquireTextBox 		( i_Form.TxtCidade, 		this, event_val_TxtCidade, 		20, false 	);
					ctrl_TxtEstado.AcquireTextBox 		( i_Form.TxtEstado, 		this, event_val_TxtEstado,  	2, false 	);
					ctrl_TxtCEP.AcquireTextBox 			( i_Form.TxtCEP, 			this, event_val_TxtCEP, 		6 			);
					ctrl_TxtDDD.AcquireTextBox 			( i_Form.TxtDDD, 			this, event_val_TxtDDD, 		2 			);
					ctrl_TxtTelefone.AcquireTextBox 	( i_Form.TxtTelefone, 		this, event_val_TxtTelefone, 	8 			);
					ctrl_TxtDtNasc.AcquireTextBox 		( i_Form.TxtDtNasc, 		this, event_val_TxtDtNasc, 		dateTextController.FORMAT_DDMMYYYY );
					ctrl_TxtEmail.AcquireTextBox 		( i_Form.TxtEmail,			this, event_val_TxtEmail, 		40 );
					ctrl_TxtRenda.AcquireTextBox		( i_Form.TxtRenda, 			this, event_val_TxtRenda,	  	"R$", 8 );
					
					ctrl_TxtCpf.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtNome.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtEndereco.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtNumero.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtComplemento.SetupErrorProvider  ( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtBairro.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtCidade.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtEstado.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtCEP.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtDDD.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtTelefone.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtDtNasc.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtEmail.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtRenda.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false );
						
					ctrl_TxtCpf.SetTextBoxText ( cpf_cnpj );
					ctrl_TxtCpf.forceValidation();
					
					if ( cpf_cnpj != "" )
					{
						ctrl_TxtEndereco.SetTextBoxText 		( dp.get_st_endereco()		);
						ctrl_TxtNumero.SetTextBoxText    		( dp.get_st_numero() 		);
						ctrl_TxtComplemento.SetTextBoxText    	( dp.get_st_complemento() 	);
						ctrl_TxtBairro.SetTextBoxText			( dp.get_st_bairro() 		);
						ctrl_TxtCidade.SetTextBoxText 			( dp.get_st_cidade() 		);
						ctrl_TxtEstado.SetTextBoxText 			( dp.get_st_UF()		 	);
						ctrl_TxtCEP.SetTextBoxText 				( dp.get_st_CEP() 			);
						ctrl_TxtDDD.SetTextBoxText 				( dp.get_st_ddd()	 		);
						ctrl_TxtTelefone.SetTextBoxText 		( dp.get_st_telefone() 		);
						ctrl_TxtDtNasc.SetTextBoxText 			( dp.get_dt_nasc() 			);
						ctrl_TxtEmail.SetTextBoxText			( dp.get_st_email() 		);
						ctrl_TxtRenda.SetTextBoxString			( dp.get_vr_renda() 		);
						ctrl_TxtNome.SetTextBoxText   			( dp.get_st_nome() 			);
					}
					else
					{
						i_Form.TxtCpf.ReadOnly = false;
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
				
				#region - event_Alterar -
				
				case event_Alterar:
				{
					//InitEventCode event_Alterar
					
					bool IsDone = true;
					
					if ( !ctrl_TxtNome.IsUserValidated )		{	ctrl_TxtNome.SetErrorMessage 			( "O nome deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtEndereco.IsUserValidated )	{	ctrl_TxtEndereco.SetErrorMessage 		( "O endereço deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtNumero.IsUserValidated )		{	ctrl_TxtNumero.SetErrorMessage 			( "O número deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtComplemento.IsUserValidated )	{	ctrl_TxtComplemento.SetErrorMessage 	( "O complemento deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtBairro.IsUserValidated )		{	ctrl_TxtBairro.SetErrorMessage 			( "O bairro deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtCidade.IsUserValidated )		{	ctrl_TxtCidade.SetErrorMessage 			( "A cidade deve ser informada" );	IsDone = false;	}
					if ( !ctrl_TxtEstado.IsUserValidated )		{	ctrl_TxtEstado.SetErrorMessage 			( "O estado deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtCEP.IsUserValidated )			{	ctrl_TxtCEP.SetErrorMessage 			( "O CEP deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtDDD.IsUserValidated )			{	ctrl_TxtDDD.SetErrorMessage 			( "O DDD deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtTelefone.IsUserValidated )	{	ctrl_TxtTelefone.SetErrorMessage 		( "O telefone deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtDtNasc.IsUserValidated )		{	ctrl_TxtDtNasc.SetErrorMessage 			( "A data de nascimento deve ser informada" );	IsDone = false;	}
					
					if ( !IsDone )
					{
						MessageBox.Show ( "Existem pendências de cadastro", "Aviso" );
						return false;
					}
					
					DadosProprietario dp = new DadosProprietario ();
					
					dp.set_st_nome 				( ctrl_TxtNome.getTextBoxValue() 				);
					dp.set_st_endereco 			( ctrl_TxtEndereco.getTextBoxValue() 			);
					dp.set_st_numero 			( ctrl_TxtNumero.getTextBoxValue() 				);
					dp.set_st_complemento 		( ctrl_TxtComplemento.getTextBoxValue() 		);
					dp.set_st_bairro 			( ctrl_TxtBairro.getTextBoxValue() 				);
					dp.set_st_cidade 			( ctrl_TxtCidade.getTextBoxValue() 				);
					dp.set_st_UF 				( ctrl_TxtEstado.getTextBoxValue() 				);
					dp.set_st_CEP 				( ctrl_TxtCEP.getTextBoxValue()					);
					dp.set_st_ddd 				( ctrl_TxtDDD.getTextBoxValue() 				);
					dp.set_st_telefone 			( ctrl_TxtTelefone.getTextBoxValue() 			);
					dp.set_vr_renda 			( ctrl_TxtRenda.getTextBoxValue_NumberStr() 	);
					dp.set_st_email 			( ctrl_TxtEmail.getTextBoxValue() 				);
					dp.set_dt_nasc 				( var_util.GetDataBaseTimeFormat ( ctrl_TxtDtNasc.getTextBoxValue_Date() ) );

					var_exchange.exec_alteraProprietario ( ctrl_TxtCpf.getTextBoxValue(), ref dp, ref header );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCpf -
				
				case event_val_TxtCpf:
				{
					//InitEventCode event_val_TxtCpf
					
					if ( ctrl_TxtCpf.getTextBoxValue().Length == 11 ||  // cpf
					    ctrl_TxtCpf.getTextBoxValue().Length == 14   )  // cnpj
					{
						DadosProprietario dp = new DadosProprietario();
						
						if ( var_exchange.fetch_proprietario ( 	ctrl_TxtCpf.getTextBoxValue(),
						                                      	ref header,
						                                      	ref dp ) )
						{
							if ( dp.get_tg_found() == Context.TRUE )
							{
								ctrl_TxtEndereco.SetTextBoxText 		( dp.get_st_endereco()		);
								ctrl_TxtNumero.SetTextBoxText    		( dp.get_st_numero() 		);
								ctrl_TxtComplemento.SetTextBoxText    	( dp.get_st_complemento() 	);
								ctrl_TxtBairro.SetTextBoxText			( dp.get_st_bairro() 		);
								ctrl_TxtCidade.SetTextBoxText 			( dp.get_st_cidade() 		);
								ctrl_TxtEstado.SetTextBoxText 			( dp.get_st_UF()		 	);
								ctrl_TxtCEP.SetTextBoxText 				( dp.get_st_CEP() 			);
								ctrl_TxtDDD.SetTextBoxText 				( dp.get_st_ddd()	 		);
								ctrl_TxtTelefone.SetTextBoxText 		( dp.get_st_telefone() 		);
								ctrl_TxtDtNasc.SetTextBoxText 			( dp.get_dt_nasc() 			);
								ctrl_TxtEmail.SetTextBoxText			( dp.get_st_email() 		);
								ctrl_TxtRenda.SetTextBoxString			( dp.get_vr_renda() 		);
								ctrl_TxtNome.SetTextBoxText   			( dp.get_st_nome() 			);
							}
						}
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
							if ( ctrl_TxtNome.getTextBoxValue().Length > 3 )
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
				
				#region - event_val_TxtEndereco -
				
				case event_val_TxtEndereco:
				{
					//InitEventCode event_val_TxtEndereco
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtEndereco.getTextBoxValue().Length > 8 )
							{
								i_Form.TxtEndereco.BackColor = Color.White;
								ctrl_TxtEndereco.IsUserValidated = true;
								ctrl_TxtEndereco.CleanError();
							}
							else
							{
								i_Form.TxtEndereco.BackColor = colorInvalid;
								ctrl_TxtEndereco.IsUserValidated = false;
							}
							
							break;
						}
						
						default: break;
					}					
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtNumero -
				
				case event_val_TxtNumero:
				{
					//InitEventCode event_val_TxtNumero
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtNumero.Text.Length > 0 )
							{
								i_Form.TxtNumero.BackColor = Color.White;
								ctrl_TxtNumero.IsUserValidated = true;
								ctrl_TxtNumero.CleanError();
							}
							else
							{
								i_Form.TxtNumero.BackColor = colorInvalid;
								ctrl_TxtNumero.IsUserValidated = false;
							}
							
							break;
						}
						
						default: break;
					}
				
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtComplemento -
				
				case event_val_TxtComplemento:
				{
					//InitEventCode event_val_TxtComplemento
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
							{
								if ( ctrl_TxtComplemento.getTextBoxValue().Length > 0 )
								{
									i_Form.TxtComplemento.BackColor = Color.White;
									ctrl_TxtComplemento.IsUserValidated = true;
									ctrl_TxtComplemento.CleanError();
								}
								else
								{
									i_Form.TxtComplemento.BackColor = colorInvalid;
									ctrl_TxtComplemento.IsUserValidated = false;
								}
								
								break;
							}
							
							default: break;
					}
				
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_txtBairro -
				
				case event_val_txtBairro:
				{
					//InitEventCode event_val_txtBairro
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
							{
								if ( ctrl_TxtBairro.getTextBoxValue().Length > 3 )
								{
									i_Form.TxtBairro.BackColor = Color.White;
									ctrl_TxtBairro.IsUserValidated = true;
									ctrl_TxtBairro.CleanError();
								}
								else
								{
									i_Form.TxtBairro.BackColor = colorInvalid;
									ctrl_TxtBairro.IsUserValidated = false;
								}
								
								break;
							}
							
							default: break;
					}
				
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCidade -
				
				case event_val_TxtCidade:
				{
					//InitEventCode event_val_TxtCidade
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
							{
								if ( ctrl_TxtCidade.getTextBoxValue().Length > 3 )
								{
									i_Form.TxtCidade.BackColor = Color.White;
									ctrl_TxtCidade.IsUserValidated = true;
									ctrl_TxtCidade.CleanError();
								}
								else
								{
									i_Form.TxtCidade.BackColor = colorInvalid;
									ctrl_TxtCidade.IsUserValidated = false;
								}
								
								break;
							}
							
							default: break;
					}
				
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtEstado -
				
				case event_val_TxtEstado:
				{
					//InitEventCode event_val_TxtEstado
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtEstado.getTextBoxValue().Length == 2 )
							{
								i_Form.TxtEstado.BackColor = Color.White;
								ctrl_TxtEstado.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtEstado.BackColor = colorInvalid;
								ctrl_TxtEstado.IsUserValidated = false;
								ctrl_TxtEstado.CleanError();
							}
							
							break;
						}
						
						default: break;
					}
				
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCEP -
				
				case event_val_TxtCEP:
				{
					//InitEventCode event_val_TxtCEP
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtCEP.Text.Length > 3 )
							{
								i_Form.TxtCEP.BackColor = Color.White;
								ctrl_TxtCEP.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtCEP.BackColor = colorInvalid;
								ctrl_TxtCEP.IsUserValidated = false;
								ctrl_TxtCEP.CleanError();
							}
							
							break;
						}
						
						default: break;
					}
				
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDDD -
				
				case event_val_TxtDDD:
				{
					//InitEventCode event_val_TxtDDD
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtDDD.Text.Length > 1 )
							{
								i_Form.TxtDDD.BackColor = Color.White;
								ctrl_TxtDDD.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtDDD.BackColor = colorInvalid;
								ctrl_TxtDDD.IsUserValidated = false;
								ctrl_TxtDDD.CleanError();
							}
							
							break;
						}
						
						default: break;
					}
				
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtTelefone -
				
				case event_val_TxtTelefone:
				{
					//InitEventCode event_val_TxtTelefone
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( ctrl_TxtTelefone.getTextBoxValue().Length < 8 )
							{
								i_Form.TxtTelefone.BackColor = colorInvalid;
								ctrl_TxtTelefone.IsUserValidated = false;
							}
							else
							{
								i_Form.TxtTelefone.BackColor = Color.White;
								ctrl_TxtTelefone.IsUserValidated = true;
								ctrl_TxtTelefone.CleanError();
							}
							break;
						}
						
						default: break;
					}
				
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDtNasc -
				
				case event_val_TxtDtNasc:
				{
					//InitEventCode event_val_TxtDtNasc
					
					switch ( arg as string )
					{
						case dateTextController.DATE_INVALID:
							{
								i_Form.TxtDtNasc.BackColor = colorInvalid;
								ctrl_TxtDtNasc.IsUserValidated = false;
								break;
							}
							
						case dateTextController.DATE_VALID:
							{
								i_Form.TxtDtNasc.BackColor = Color.White;
								ctrl_TxtDtNasc.IsUserValidated = true;
								ctrl_TxtDtNasc.CleanError();
								break;
							}
							
							default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtEmail -
				
				case event_val_TxtEmail:
				{
					//InitEventCode event_val_TxtEmail
					
					switch ( arg as string )
					{
						case emailTextController.EMAIL_INVALID:
						{
							i_Form.TxtEmail.BackColor = colorInvalid;
							ctrl_TxtEmail.IsUserValidated = false;
							break;
						}
						
						case emailTextController.EMAIL_VALID:
						{
							i_Form.TxtEmail.BackColor = Color.White;
							ctrl_TxtEmail.IsUserValidated = true;
							ctrl_TxtEmail.CleanError();
							break;
						}
						
						default: break;
					}
				
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtRenda -
				
				case event_val_TxtRenda:
				{
					//InitEventCode event_val_TxtRenda
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnAlterarClick -
				
				case event_BtnAlterarClick:
				{
					//InitEventCode event_BtnAlterarClick
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
