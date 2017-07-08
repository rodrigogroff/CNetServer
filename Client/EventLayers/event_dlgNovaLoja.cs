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
	public class event_dlgNovaLoja : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_val_TxtCNPJ = 6;
		public const int event_val_TxtNome = 7;
		public const int event_val_TxtSocial = 8;
		public const int event_val_TxtEndereco = 9;
		public const int event_val_TxtEnderecoInst = 10;
		public const int event_val_TxtInscEst = 11;
		public const int event_val_TxtCidade = 12;
		public const int event_val_TxtEstado = 13;
		public const int event_val_TxtCEP = 14;
		public const int event_val_TxtTelefone = 15;
		public const int event_val_TxtFax = 16;
		public const int event_val_TxtContato = 17;
		public const int event_val_TxtMensalidade = 18;
		public const int event_val_TxtContaDeb = 19;
		public const int event_val_TxtObs = 20;
		public const int event_val_TxtRamo = 21;
		public const int event_BuscaDados = 22;
		public const int event_val_TxtLoja = 23;
		public const int event_val_TxtPctValor = 24;
		public const int event_val_TxtVrTransacao = 25;
		public const int event_val_TxtVrMinimo = 26;
		public const int event_val_TxtFranquia = 27;
		public const int event_val_TxtPeriodoFat = 28;
		public const int event_val_TxtDiaVenc = 29;
		public const int event_val_TxtBancoFat = 30;
		public const int event_Bloq = 31;
		public const int event_Desbloq = 32;
		public const int event_Cancelar = 33;
		public const int event_val_TxtSenhaWeb = 34;
		public const int event_BtnConfirmarClick = 35;
		public const int event_BtnBloqClick = 36;
		public const int event_BtnDesbloqClick = 37;
		public const int event_BtnCancelarClick = 38;
		#endregion

		public dlgNovaLoja i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		public bool IsMaintenance = false;	
		
		public string par_code = "";

		numberTextController 		ctrl_TxtSenhaWeb        = new numberTextController();
		
		numberTextController 		ctrl_TxtLoja			= new numberTextController();
		cnpjTextController			ctrl_TxtCNPJ			= new cnpjTextController();
		alphaTextController		    ctrl_TxtNome			= new alphaTextController();
		alphaTextController			ctrl_TxtSocial			= new alphaTextController();
		alphaTextController			ctrl_TxtEndereco		= new alphaTextController();
		alphaTextController			ctrl_TxtEnderecoInst	= new alphaTextController();
		numberTextController		ctrl_TxtInscEst			= new numberTextController();
		alphaTextController			ctrl_TxtCidade			= new alphaTextController();
		alphaTextController			ctrl_TxtEstado			= new alphaTextController();
		numberTextController		ctrl_TxtCEP				= new numberTextController();
		numberTextController 		ctrl_TxtTelefone		= new numberTextController();
		numberTextController 		ctrl_TxtFax				= new numberTextController();
		alphaTextController			ctrl_TxtContato			= new alphaTextController();
		numberTextController 	    ctrl_TxtContaDeb		= new numberTextController();
		alphaTextController			ctrl_TxtObs				= new alphaTextController();
		
		moneyTextController  	   	ctrl_TxtMensalidade		= new moneyTextController();
		percentTextController		ctrl_TxtPctValor 		= new percentTextController();
		moneyTextController  	   	ctrl_TxtVrTransacao		= new moneyTextController();
		moneyTextController  	   	ctrl_TxtVrMinimo		= new moneyTextController();
		numberTextController  	   	ctrl_TxtFranquia		= new numberTextController();
		numberTextController  	   	ctrl_TxtPeriodoFat		= new numberTextController();
		numberTextController  	   	ctrl_TxtDiaVenc			= new numberTextController();
		numberTextController  	   	ctrl_TxtBancoFat		= new numberTextController();
				
		Color 	colorInvalid 	= Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgNovaLoja ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgNovaLoja ( this );
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
					
					ctrl_TxtSenhaWeb.AcquireTextBox 		( i_Form.TxtSenhaWeb, 		this, event_val_TxtSenhaWeb, 		9  	);
					ctrl_TxtLoja.AcquireTextBox 			( i_Form.TxtLoja, 			this, event_val_TxtLoja, 			6  	);
					ctrl_TxtCNPJ.AcquireTextBox 			( i_Form.TxtCNPJ, 			this, event_val_TxtCNPJ 				);
					ctrl_TxtNome.AcquireTextBox		 		( i_Form.TxtNome,	 		this, event_val_TxtNome, 			40, alphaTextController.ENABLE_NUMBERS  );
					ctrl_TxtSocial.AcquireTextBox 			( i_Form.TxtSocial, 		this, event_val_TxtSocial, 			40, alphaTextController.ENABLE_NUMBERS  );
					ctrl_TxtEndereco.AcquireTextBox 		( i_Form.TxtEndereco, 		this, event_val_TxtEndereco, 		80, alphaTextController.ENABLE_NUMBERS, alphaTextController.ENABLE_SYMBOLS 	);
					ctrl_TxtEnderecoInst.AcquireTextBox 	( i_Form.TxtEnderecoInst,	this, event_val_TxtEnderecoInst, 	80, alphaTextController.ENABLE_NUMBERS, alphaTextController.ENABLE_SYMBOLS 	);
					ctrl_TxtInscEst.AcquireTextBox 			( i_Form.TxtInscEst, 		this, event_val_TxtInscEst,  		10 	);
					ctrl_TxtCidade.AcquireTextBox 			( i_Form.TxtCidade, 		this, event_val_TxtCidade, 			20, false 	 	);
					ctrl_TxtEstado.AcquireTextBox 			( i_Form.TxtEstado, 		this, event_val_TxtEstado, 			2, false 	 	);
					ctrl_TxtCEP.AcquireTextBox 				( i_Form.TxtCEP, 			this, event_val_TxtCEP,		  		8 	);
					ctrl_TxtTelefone.AcquireTextBox 		( i_Form.TxtTelefone, 		this, event_val_TxtTelefone,		10 	);
					ctrl_TxtFax.AcquireTextBox 				( i_Form.TxtFax,	 		this, event_val_TxtFax,				10 	);
					ctrl_TxtContato.AcquireTextBox 			( i_Form.TxtContato,		this, event_val_TxtContato,			20 	);
					ctrl_TxtContaDeb.AcquireTextBox 		( i_Form.TxtContaDeb,	 	this, event_val_TxtContaDeb, 		14  );
					ctrl_TxtObs.AcquireTextBox 				( i_Form.TxtObs,			this, event_val_TxtObs,				80, alphaTextController.ENABLE_NUMBERS, alphaTextController.ENABLE_SYMBOLS 	);
					ctrl_TxtMensalidade.AcquireTextBox 		( i_Form.TxtMensalidade, 	this, event_val_TxtMensalidade,		"R$", 	6 );
					ctrl_TxtPctValor.AcquireTextBox 		( i_Form.TxtPctValor,		this, event_val_TxtPctValor,		5,		2 );
					ctrl_TxtVrTransacao.AcquireTextBox 		( i_Form.TxtVrTransacao, 	this, event_val_TxtVrTransacao,		"R$", 	6 );
					ctrl_TxtVrMinimo.AcquireTextBox 		( i_Form.TxtVrMinimo, 		this, event_val_TxtVrMinimo,		"R$", 	6 );
					ctrl_TxtFranquia.AcquireTextBox 		( i_Form.TxtFranquia,	 	this, event_val_TxtFranquia,		8 	);
					ctrl_TxtPeriodoFat.AcquireTextBox 		( i_Form.TxtPeriodoFat,	 	this, event_val_TxtPeriodoFat,		2 	);
					ctrl_TxtDiaVenc.AcquireTextBox 			( i_Form.TxtDiaVenc,	 	this, event_val_TxtDiaVenc,			2 	);
					ctrl_TxtBancoFat.AcquireTextBox 		( i_Form.TxtBancoFat,	 	this, event_val_TxtBancoFat,		3 	);
					
					ctrl_TxtSenhaWeb.SetupErrorProvider 	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtLoja.SetupErrorProvider 	  	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtCNPJ.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtNome.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtSocial.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtEndereco.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtEnderecoInst.SetupErrorProvider ( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtInscEst.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtCidade.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtEstado.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtCEP.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtTelefone.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtFax.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtContato.SetupErrorProvider 		( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtMensalidade.SetupErrorProvider  ( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtContaDeb.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtObs.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtFranquia.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtPeriodoFat.SetupErrorProvider   ( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtDiaVenc.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtBancoFat.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					
					ctrl_TxtMensalidade.IsUserValidated = true;
					
					if ( par_code.Length > 0 )
					{
						ctrl_TxtCNPJ.SetTextBoxText ( par_code );
						ctrl_TxtCNPJ.forceValidation();
						
						doEvent ( event_BuscaDados, null );
					}
					
					if ( header.get_tg_user_type() == TipoUsuario.OperadorCont ||
					     header.get_tg_user_type() == TipoUsuario.SuperUser )
					{
						i_Form.BtnBloq.Visible     = true;
						i_Form.BtnDesbloq.Visible  = true;
						
					}
					else if ( header.get_tg_user_type() == TipoUsuario.OperadorConvey )
					{
						i_Form.BtnBloq.Visible     = true;
						i_Form.BtnDesbloq.Visible  = true;
					}
										
					if ( IsMaintenance )
					{
						if ( header.get_tg_user_type() == TipoUsuario.AdminGift || 
						     header.get_tg_user_type() == TipoUsuario.Administrador  )
						{
							i_Form.BtnBloq.Visible     	= false;
							i_Form.BtnDesbloq.Visible  	= false;
							
							i_Form.BtnConfirmar.Visible = false;
						}
					
						i_Form.Text              =  "Manutenção de cadastro de loja";
						i_Form.BtnConfirmar.Text = "Atualizar";
					}
					else
					{
						i_Form.Text =  "Cadastro de loja";
						
						string  cod = "";
						
						var_exchange.fetch_codLoja ( ref header, ref cod );
						
						ctrl_TxtLoja.SetTextBoxText ( cod );
						
						i_Form.BtnBloq.Visible     = false;
						i_Form.BtnDesbloq.Visible  = false;
						i_Form.LblSit.Visible      = false;
						
					}
					
					i_Form.TxtSenhaWeb.Visible = false;
					i_Form.LblAcesso.Visible   = false;
						
					if ( header.get_tg_user_type() == TipoUsuario.SuperUser || 
					     header.get_tg_user_type() == TipoUsuario.OperadorConvey )
					{
						i_Form.TxtSenhaWeb.Visible = true;
						i_Form.LblAcesso.Visible   = true;
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
					
					bool IsDone = true;
					
					if ( !ctrl_TxtSenhaWeb.IsUserValidated	 	)	{	ctrl_TxtLoja.SetErrorMessage 			( "Senha de acesso web deve ser informada" );	IsDone = false;	}
					if ( !ctrl_TxtLoja.IsUserValidated	 		)	{	ctrl_TxtLoja.SetErrorMessage 			( "Código da loja deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtCNPJ.IsUserValidated 			)	{	ctrl_TxtCNPJ.SetErrorMessage 			( "CNPJ deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtNome.IsUserValidated 			)	{	ctrl_TxtNome.SetErrorMessage 			( "Nome deve estar preenchido" );	IsDone = false;	}
					if ( !ctrl_TxtSocial.IsUserValidated 		)	{	ctrl_TxtSocial.SetErrorMessage 			( "A razão social deve estar preenchida" );	IsDone = false;	}
					if ( !ctrl_TxtEndereco.IsUserValidated 		)	{	ctrl_TxtEndereco.SetErrorMessage 		( "O endereço deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtEnderecoInst.IsUserValidated 	)	{	ctrl_TxtEnderecoInst.SetErrorMessage 	( "O endereço institucional deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtInscEst.IsUserValidated 		)	{	ctrl_TxtInscEst.SetErrorMessage 		( "A inscrição estadual deve ser informada" );	IsDone = false;	}
					if ( !ctrl_TxtCidade.IsUserValidated		)	{	ctrl_TxtCidade.SetErrorMessage		 	( "A cidade deve ser informada" );	IsDone = false;	}
					if ( !ctrl_TxtEstado.IsUserValidated 		)	{	ctrl_TxtEstado.SetErrorMessage 			( "O estado deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtCEP.IsUserValidated 			)	{	ctrl_TxtCEP.SetErrorMessage 			( "O CEP deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtTelefone.IsUserValidated 		)	{	ctrl_TxtTelefone.SetErrorMessage 		( "O telefone deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtFax.IsUserValidated 			)	{	ctrl_TxtFax.SetErrorMessage 			( "O número de FAX deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtContato.IsUserValidated 		)	{	ctrl_TxtContato.SetErrorMessage 		( "Um nome de contato deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtMensalidade.IsUserValidated 	)	{	ctrl_TxtMensalidade.SetErrorMessage 	( "O valor de mensalidade deve ser preenchido" );	IsDone = false;	}
					if ( !ctrl_TxtContaDeb.IsUserValidated 		)	{	ctrl_TxtContaDeb.SetErrorMessage 		( "A conta de débito deve ser informada" );	IsDone = false;	}
					if ( !ctrl_TxtObs.IsUserValidated 			)	{	ctrl_TxtObs.SetErrorMessage 			( "A observação deve ser informada" );	IsDone = false;	}
					
					if ( !ctrl_TxtPeriodoFat.IsUserValidated 	)	{	ctrl_TxtPeriodoFat.SetErrorMessage 		( "Dia para faturamento deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtDiaVenc.IsUserValidated 		)	{	ctrl_TxtDiaVenc.SetErrorMessage 		( "Dia para vencimento deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtBancoFat.IsUserValidated	 	)	{	ctrl_TxtBancoFat.SetErrorMessage 		( "Banco para fatura deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtFranquia.IsUserValidated	 	)	{	ctrl_TxtFranquia.SetErrorMessage 		( "Franquia de transações deve ser informada" );	IsDone = false;	}
					
					if ( !ctrl_TxtDiaVenc.IsUserValidated	 	)	{	ctrl_TxtDiaVenc.SetErrorMessage 		( "Dia de vencimento válido deve ser informado" );	IsDone = false;	}
					
					if ( i_Form.CboTipoCob.SelectedIndex == -1 )
					{
						MessageBox.Show ( "Favor informar tipo de cobrança", "Aviso" );
						IsDone = false;
					}
					    
					if ( !IsDone )
						return false;
					
					DadosLoja dl = new DadosLoja();
					
					dl.set_st_loja 			( ctrl_TxtLoja.getTextBoxValue() 						);
					dl.set_nu_CNPJ 			( ctrl_TxtCNPJ.getTextBoxValue() 						);
					dl.set_st_nome 			( ctrl_TxtNome.getTextBoxValue() 						);
					dl.set_st_social 		( ctrl_TxtSocial.getTextBoxValue() 						);
					dl.set_st_endereco 		( ctrl_TxtEndereco.getTextBoxValue() 					);
					dl.set_st_enderecoInst 	( ctrl_TxtEnderecoInst.getTextBoxValue()	 			);
					dl.set_nu_inscEst 		( ctrl_TxtInscEst.getTextBoxValue() 					);
					dl.set_st_cidade 		( ctrl_TxtCidade.getTextBoxValue() 						);
					dl.set_st_estado 		( ctrl_TxtEstado.getTextBoxValue() 						);
					dl.set_nu_CEP 			( ctrl_TxtCEP.getTextBoxValue() 						);
					dl.set_nu_telefone 		( ctrl_TxtTelefone.getTextBoxValue() 					);
					dl.set_nu_fax 			( ctrl_TxtFax.getTextBoxValue()	 						);
					dl.set_st_contato 		( ctrl_TxtContato.getTextBoxValue() 					);
					dl.set_vr_mensalidade 	( ctrl_TxtMensalidade.getTextBoxValue_NumberStr() 		);
					dl.set_nu_contaDeb 		( ctrl_TxtContaDeb.getTextBoxValue() 			);
					dl.set_st_obs 			( ctrl_TxtObs.getTextBoxValue() 						);
					dl.set_nu_pctValor		( ctrl_TxtPctValor.getTextBoxValue().PadLeft ( 1, '0' ) );
					dl.set_vr_transacao		( ctrl_TxtVrTransacao.getTextBoxValue_NumberStr()   	);
					dl.set_vr_minimo		( ctrl_TxtVrMinimo.getTextBoxValue_NumberStr()   		);
					dl.set_nu_franquia		( ctrl_TxtFranquia.getTextBoxValue()   					);
					dl.set_nu_periodoFat	( ctrl_TxtPeriodoFat.getTextBoxValue()   				);
					dl.set_nu_diavenc		( ctrl_TxtDiaVenc.getTextBoxValue()   					);
					dl.set_tg_tipoCobranca	( i_Form.CboTipoCob.SelectedIndex.ToString()			);
					dl.set_nu_bancoFat		( ctrl_TxtBancoFat.getTextBoxValue()   					);
					dl.set_st_senhaWeb      ( ctrl_TxtSenhaWeb.getTextBoxValue()					);
											
					if ( i_Form.CheckIsento.Checked )
					{
						dl.set_tg_isento ( Context.TRUE );
					}
					else
					{
						dl.set_tg_isento ( Context.FALSE );
					}
					
					if ( IsMaintenance )
					{
						var_exchange.exec_alteraLoja ( "", "", "", "", "", "", ref dl, ref header );
					}
					else
					{
						var_exchange.ins_loja ( "", "", "", ref dl, ref header );
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCNPJ -
				
				case event_val_TxtCNPJ:
				{
					//InitEventCode event_val_TxtCNPJ
					
					switch ( arg as string )
					{
						case cnpjTextController.CNPJ_INCOMPLETE:
						case cnpjTextController.CNPJ_INVALID:
						{
							i_Form.TxtCNPJ.BackColor     = colorInvalid;	
							ctrl_TxtCNPJ.IsUserValidated = false;
							break;
						}
							
						case cnpjTextController.CNPJ_VALID:
						{
							i_Form.TxtCNPJ.BackColor     = Color.White;	
							ctrl_TxtCNPJ.IsUserValidated = true;
							ctrl_TxtCNPJ.CleanError();
						
							if ( IsMaintenance )
							{
								if ( ctrl_TxtCNPJ.GetEnterPressed() )
								{
									doEvent ( event_BuscaDados, null );
								}									
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
							if ( ctrl_TxtNome.getTextBoxValue().Length > 8 )
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
				
				#region - event_val_TxtSocial -
				
				case event_val_TxtSocial:
				{
					//InitEventCode event_val_TxtSocial
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtSocial.getTextBoxValue().Length > 8 )
							{
								i_Form.TxtSocial.BackColor = Color.White;	
								ctrl_TxtSocial.IsUserValidated = true;
								ctrl_TxtSocial.CleanError();
							}
							else
							{
								i_Form.TxtSocial.BackColor = colorInvalid;	
								ctrl_TxtSocial.IsUserValidated = false;
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
				
				#region - event_val_TxtEnderecoInst -
				
				case event_val_TxtEnderecoInst:
				{
					//InitEventCode event_val_TxtEnderecoInst
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtEnderecoInst.getTextBoxValue().Length > 8 )
							{
								i_Form.TxtEnderecoInst.BackColor = Color.White;	
								ctrl_TxtEnderecoInst.IsUserValidated = true;
								ctrl_TxtEnderecoInst.CleanError();
							}
							else
							{
								i_Form.TxtEnderecoInst.BackColor = colorInvalid;	
								ctrl_TxtEnderecoInst.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtInscEst -
				
				case event_val_TxtInscEst:
				{
					//InitEventCode event_val_TxtInscEst
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( ctrl_TxtInscEst.getTextBoxValue().Length > 7 )
							{
								i_Form.TxtInscEst.BackColor = Color.White;	
								ctrl_TxtInscEst.IsUserValidated = true;
								ctrl_TxtInscEst.CleanError();
							}
							else
							{
								i_Form.TxtInscEst.BackColor = colorInvalid;	
								ctrl_TxtInscEst.IsUserValidated = false;
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
							if ( ctrl_TxtCidade.getTextBoxValue().Length > 2 )
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
								ctrl_TxtEstado.CleanError();
							}
							else
							{
								i_Form.TxtEstado.BackColor = colorInvalid;	
								ctrl_TxtEstado.IsUserValidated = false;
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
							if ( ctrl_TxtCEP.getTextBoxValue().Length > 7 )
							{
								i_Form.TxtCEP.BackColor = Color.White;	
								ctrl_TxtCEP.IsUserValidated = true;
								ctrl_TxtCEP.CleanError();
							}
							else
							{
								i_Form.TxtCEP.BackColor = colorInvalid;	
								ctrl_TxtCEP.IsUserValidated = false;
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
							if ( ctrl_TxtTelefone.getTextBoxValue().Length == 10 )
							{
								i_Form.TxtTelefone.BackColor = Color.White;	
								ctrl_TxtTelefone.IsUserValidated = true;
								ctrl_TxtTelefone.CleanError();
							}
							else
							{
								i_Form.TxtTelefone.BackColor = colorInvalid;	
								ctrl_TxtTelefone.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtFax -
				
				case event_val_TxtFax:
				{
					//InitEventCode event_val_TxtFax
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( ctrl_TxtFax.getTextBoxValue().Length == 10 )
							{
								i_Form.TxtFax.BackColor = Color.White;	
								ctrl_TxtFax.IsUserValidated = true;
								ctrl_TxtFax.CleanError();
							}
							else
							{
								i_Form.TxtFax.BackColor = colorInvalid;	
								ctrl_TxtFax.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtContato -
				
				case event_val_TxtContato:
				{
					//InitEventCode event_val_TxtContato
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtContato.getTextBoxValue().Length > 2 )
							{
								i_Form.TxtContato.BackColor = Color.White;	
								ctrl_TxtContato.IsUserValidated = true;
								ctrl_TxtContato.CleanError();
							}
							else
							{
								i_Form.TxtContato.BackColor = colorInvalid;	
								ctrl_TxtContato.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtMensalidade -
				
				case event_val_TxtMensalidade:
				{
					//InitEventCode event_val_TxtMensalidade
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtContaDeb -
				
				case event_val_TxtContaDeb:
				{
					//InitEventCode event_val_TxtContaDeb
							
					if ( ctrl_TxtContaDeb.getTextBoxValue().Length == 14 ) 
					{
						i_Form.TxtContaDeb.BackColor = Color.White;	
						ctrl_TxtContaDeb.IsUserValidated = true;
						ctrl_TxtContaDeb.CleanError();
					}
					else
					{
						i_Form.TxtContaDeb.BackColor = colorInvalid;	
						ctrl_TxtContaDeb.IsUserValidated = false;
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
				
				#region - event_val_TxtRamo -
				
				case event_val_TxtRamo:
				{
					//InitEventCode event_val_TxtRamo
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BuscaDados -
				
				case event_BuscaDados:
				{
					//InitEventCode event_BuscaDados
					
					DadosLoja dl = new DadosLoja();
					
					if ( var_exchange.fetch_dadosLoja ( ctrl_TxtCNPJ.getTextBoxValue(),
					                                    ctrl_TxtLoja.getTextBoxValue(),
					           	                      	ref header, 
					           	                      	ref dl ) )
					{
						ctrl_TxtCNPJ.SetTextBoxText 		( dl.get_nu_CNPJ()  		);
						ctrl_TxtCNPJ.forceValidation();
						
						ctrl_TxtLoja.SetTextBoxText 			( dl.get_st_loja() 								);
						ctrl_TxtNome.SetTextBoxText 			( dl.get_st_nome() 								);
						ctrl_TxtSocial.SetTextBoxText 			( dl.get_st_social() 							);
						ctrl_TxtEndereco.SetTextBoxText 		( dl.get_st_endereco() 							);
						ctrl_TxtEnderecoInst.SetTextBoxText	 	( dl.get_st_enderecoInst() 						);
						ctrl_TxtInscEst.SetTextBoxText 			( dl.get_nu_inscEst() 							);
						ctrl_TxtCidade.SetTextBoxText 			( dl.get_st_cidade() 							);
						ctrl_TxtEstado.SetTextBoxText 			( dl.get_st_estado() 							);
						ctrl_TxtCEP.SetTextBoxText 				( dl.get_nu_CEP() 								);
						ctrl_TxtTelefone.SetTextBoxText 		( dl.get_nu_telefone() 							);
						ctrl_TxtFax.SetTextBoxText 				( dl.get_nu_fax() 								);
						ctrl_TxtContato.SetTextBoxText 			( dl.get_st_contato() 							);
						ctrl_TxtMensalidade.SetTextBoxString	( dl.get_vr_mensalidade() 						);
						ctrl_TxtContaDeb.SetTextBoxText 		( dl.get_nu_contaDeb().PadLeft ( 1, '0' ) 		);
						ctrl_TxtObs.SetTextBoxText 				( dl.get_st_obs() 								);
						ctrl_TxtPctValor.SetTextBoxText 		( dl.get_nu_pctValor().PadLeft ( 1, '0' )		);
						ctrl_TxtVrTransacao.SetTextBoxString 	( dl.get_vr_transacao().PadLeft ( 1, '0' )		);
						ctrl_TxtVrMinimo.SetTextBoxString 		( dl.get_vr_minimo().PadLeft ( 1, '0' )			);
						ctrl_TxtFranquia.SetTextBoxText 		( dl.get_nu_franquia().PadLeft ( 1, '0' )		);
						ctrl_TxtPeriodoFat.SetTextBoxText 		( dl.get_nu_periodoFat().PadLeft ( 1, '0' )		);
						ctrl_TxtDiaVenc.SetTextBoxText 			( dl.get_nu_diavenc().PadLeft ( 1, '0' )		);
						ctrl_TxtBancoFat.SetTextBoxText 		( dl.get_nu_bancoFat().PadLeft ( 1, '0' )		);
						ctrl_TxtSenhaWeb.SetTextBoxText         ( dl.get_st_senhaWeb() 							);
						
						if ( dl.get_tg_blocked() == Context.TRUE )
						{
							i_Form.LblSit.Text = "Loja bloqueada";
						}
						else
						{
							i_Form.LblSit.Text = "Loja ativa";							
						}
						
						if ( dl.get_tg_isento() == Context.TRUE )
							i_Form.CheckIsento.Checked = true;
						
						if ( dl.get_tg_cancel() == Context.TRUE )
						{
							i_Form.LblSit.Text = "Loja cancelada";
						}
												
						if ( dl.get_tg_tipoCobranca() != "" )
							i_Form.CboTipoCob.SelectedIndex = Convert.ToInt32 ( dl.get_tg_tipoCobranca() );
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtLoja -
				
				case event_val_TxtLoja:
				{
					//InitEventCode event_val_TxtLoja
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtLoja.Text.Length > 0 )
							{
								i_Form.TxtLoja.BackColor     = Color.White;	
								ctrl_TxtLoja.IsUserValidated = true;
								ctrl_TxtLoja.CleanError();
								
								if ( IsMaintenance )
								{
									if ( ctrl_TxtLoja.GetEnterPressed() )
									{
										doEvent ( event_BuscaDados, null );
									}									
								}	
							}
							else
							{
								i_Form.TxtLoja.BackColor     = colorInvalid;	
								ctrl_TxtLoja.IsUserValidated = false;
								
								if ( ctrl_TxtLoja.GetEnterPressed() )
							    {
							    	event_dlgConsultaLoja ev_call = new event_dlgConsultaLoja ( var_util, var_exchange );
									
									ev_call.header = header;
									
									ev_call.i_Form.ShowDialog();
							    }
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtPctValor -
				
				case event_val_TxtPctValor:
				{
					//InitEventCode event_val_TxtPctValor
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtVrTransacao -
				
				case event_val_TxtVrTransacao:
				{
					//InitEventCode event_val_TxtVrTransacao
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtVrMinimo -
				
				case event_val_TxtVrMinimo:
				{
					//InitEventCode event_val_TxtVrMinimo
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtFranquia -
				
				case event_val_TxtFranquia:
				{
					//InitEventCode event_val_TxtFranquia
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtFranquia.Text.Length > 0 )
							{
								i_Form.TxtFranquia.BackColor     = Color.White;	
								ctrl_TxtFranquia.IsUserValidated = true;
								ctrl_TxtFranquia.CleanError();
							}
							else
							{
								i_Form.TxtFranquia.BackColor     = colorInvalid;	
								ctrl_TxtFranquia.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtPeriodoFat -
				
				case event_val_TxtPeriodoFat:
				{
					//InitEventCode event_val_TxtPeriodoFat
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtPeriodoFat.Text.Length > 0 )
							{
								i_Form.TxtPeriodoFat.BackColor     = Color.White;	
								ctrl_TxtPeriodoFat.IsUserValidated = true;
								ctrl_TxtPeriodoFat.CleanError();
							}
							else
							{
								i_Form.TxtPeriodoFat.BackColor     = colorInvalid;	
								ctrl_TxtPeriodoFat.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDiaVenc -
				
				case event_val_TxtDiaVenc:
				{
					//InitEventCode event_val_TxtDiaVenc
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtDiaVenc.Text.Length > 0 )
							{
								if ( ctrl_TxtDiaVenc.getTextBoxValue_Long() > 0  && 
								     ctrl_TxtDiaVenc.getTextBoxValue_Long() <= 28 )
								{
									i_Form.TxtDiaVenc.BackColor     = Color.White;	
									ctrl_TxtDiaVenc.IsUserValidated = true;
									ctrl_TxtDiaVenc.CleanError();
								}
								else
								{
									i_Form.TxtDiaVenc.BackColor     = colorInvalid;	
									ctrl_TxtDiaVenc.IsUserValidated = false;
								}
							}
							else
							{
								i_Form.TxtDiaVenc.BackColor     = colorInvalid;	
								ctrl_TxtDiaVenc.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtBancoFat -
				
				case event_val_TxtBancoFat:
				{
					//InitEventCode event_val_TxtBancoFat
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtBancoFat.Text.Length > 0 )
							{
								i_Form.TxtBancoFat.BackColor     = Color.White;	
								ctrl_TxtBancoFat.IsUserValidated = true;
								ctrl_TxtBancoFat.CleanError();
							}
							else
							{
								i_Form.TxtBancoFat.BackColor     = colorInvalid;	
								ctrl_TxtBancoFat.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Bloq -
				
				case event_Bloq:
				{
					//InitEventCode event_Bloq
					
					if ( !ctrl_TxtCNPJ.IsUserValidated )
						return false;
					
					if ( MessageBox.Show (	"Confirma bloqueamento da loja?",
			                    			"Aviso", 
			                    			MessageBoxButtons.YesNo, 
			                    			MessageBoxIcon.Question, 
			                    			MessageBoxDefaultButton.Button2 ) == DialogResult.No )
					{
						return false;
					}
					
					event_dlgObservacao ev_call = new event_dlgObservacao ( var_util, var_exchange );
					
					ev_call.title = "Bloqueamento de contrato";
					ev_call.message = "Motivo do bloqueamento da loja";
					
					ev_call.i_Form.ShowDialog();
					
					var_exchange.exec_bloq_loja ( ctrl_TxtCNPJ.getTextBoxValue(), 
					                              ev_call.i_Form.TxtMotivo.Text,
					                              ref header );
					
					doEvent ( event_BuscaDados, null );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Desbloq -
				
				case event_Desbloq:
				{
					//InitEventCode event_Desbloq
					
					if ( !ctrl_TxtCNPJ.IsUserValidated )
						return false;
					
					if ( MessageBox.Show (	"Confirma desbloqueamento da loja?",
			                    			"Aviso", 
			                    			MessageBoxButtons.YesNo, 
			                    			MessageBoxIcon.Question, 
			                    			MessageBoxDefaultButton.Button2 ) == DialogResult.No )
					{
						return false;
					}
					
					var_exchange.exec_desbloq_loja ( ctrl_TxtCNPJ.getTextBoxValue(), ref header );
					
					doEvent ( event_BuscaDados, null );
										
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Cancelar -
				
				case event_Cancelar:
				{
					//InitEventCode event_Cancelar
					
					if ( !ctrl_TxtCNPJ.IsUserValidated )
						return false;
					
					if ( MessageBox.Show (	"Confirma cancelamento da loja?",
			                    			"Aviso", 
			                    			MessageBoxButtons.YesNo, 
			                    			MessageBoxIcon.Question, 
			                    			MessageBoxDefaultButton.Button2 ) == DialogResult.No )
					{
						return false;
					}
					
					event_dlgObservacao ev_call = new event_dlgObservacao ( var_util, var_exchange );
					
					ev_call.title = "Cancelamento de contrato";
					ev_call.message = "Motivo do cancelamento da loja";
					
					ev_call.i_Form.ShowDialog();
					
					var_exchange.exec_cancel_Loja ( ctrl_TxtCNPJ.getTextBoxValue(), 
					                                ev_call.i_Form.TxtMotivo.Text,
					                                ref header );
					
					doEvent ( event_BuscaDados, null );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtSenhaWeb -
				
				case event_val_TxtSenhaWeb:
				{
					//InitEventCode event_val_TxtSenhaWeb
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtSenhaWeb.Text.Length > 0 )
							{
								i_Form.TxtSenhaWeb.BackColor     = Color.White;	
								ctrl_TxtSenhaWeb.IsUserValidated = true;
								ctrl_TxtSenhaWeb.CleanError();
							}
							else
							{
								i_Form.TxtSenhaWeb.BackColor     = colorInvalid;	
								ctrl_TxtSenhaWeb.IsUserValidated = false;
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
				
				#region - event_BtnBloqClick -
				
				case event_BtnBloqClick:
				{
					//InitEventCode event_BtnBloqClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnDesbloqClick -
				
				case event_BtnDesbloqClick:
				{
					//InitEventCode event_BtnDesbloqClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnCancelarClick -
				
				case event_BtnCancelarClick:
				{
					//InitEventCode event_BtnCancelarClick
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
