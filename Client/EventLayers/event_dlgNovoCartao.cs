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
	public class event_dlgNovoCartao : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int event_ErrorProvider = 3;
		public const int robot_ShowDialog = 4;
		public const int robot_CloseDialog = 5;
		public const int event_val_TxtCodEmpresa = 6;
		public const int event_val_TxtMatricula = 7;
		public const int event_val_TxtSenha = 8;
		public const int event_val_TxtVencimento = 9;
		public const int event_val_TxtBanco = 10;
		public const int event_val_TxtAgencia = 11;
		public const int event_val_TxtConta = 12;
		public const int event_val_TxtCelular = 13;
		public const int event_val_TxtLimTotal = 14;
		public const int event_val_TxtLimMensal = 15;
		public const int event_val_TxtLimRotativo = 16;
		public const int event_val_TxtCotaExtra = 17;
		public const int event_val_TxtDiaVenc = 18;
		public const int event_val_TxtFatura = 19;
		public const int event_val_TxtCpf = 20;
		public const int event_val_TxtNome = 21;
		public const int event_val_TxtEndereco = 22;
		public const int event_val_TxtNumero = 23;
		public const int event_val_TxtComplemento = 24;
		public const int event_val_TxtBairro = 25;
		public const int event_val_TxtCidade = 26;
		public const int event_val_TxtEstado = 27;
		public const int event_val_TxtCEP = 28;
		public const int event_val_TxtDDD = 29;
		public const int event_val_TxtTelefone = 30;
		public const int event_val_TxtDtNasc = 31;
		public const int event_val_TxtEmail = 32;
		public const int event_val_TxtRenda = 33;
		public const int event_val_TxtAfiliada = 34;
		public const int event_val_TxtPresenteado = 35;
		public const int event_val_TxtRecado = 36;
		public const int event_val_TxtNomeDep = 37;
		public const int event_AdicionarDependente = 38;
		public const int event_CboDepChange = 39;
		public const int event_AtualizarDep = 40;
		public const int event_Cancelar = 41;
		public const int event_Confirmar = 42;
		public const int event_val_TxtAluno = 43;
		public const int event_val_TxtSenhaResp = 44;
		public const int event_BtnAtualizarClick = 45;
		public const int event_BtnAdicionarClick = 46;
		public const int event_CboDependentesSelectedIndexChanged = 47;
		public const int event_BtnCancelarClick = 48;
		public const int event_BtnConfirmarClick = 49;
		#endregion

		public dlgNovoCartao i_Form;

		//UserVariables
		
		public CNetHeader header;

		numberTextController 		ctrl_TxtCodEmpresa	= new numberTextController();
		numberTextController 		ctrl_TxtMatricula	= new numberTextController();
		numberTextController 		ctrl_TxtSenha       = new numberTextController();
		dateTextController			ctrl_TxtVencimento  = new dateTextController();
		numberTextController 		ctrl_TxtBanco  		= new numberTextController();
		numberTextController 		ctrl_TxtAgencia 	= new numberTextController();
		numberTextController 		ctrl_TxtConta  		= new numberTextController();
		numberTextController 		ctrl_TxtCelular		= new numberTextController();
		moneyTextController  	   	ctrl_TxtLimTotal 	= new moneyTextController();
		moneyTextController  	   	ctrl_TxtLimMensal	= new moneyTextController();
		moneyTextController  	   	ctrl_TxtLimRotativo	= new moneyTextController();
		moneyTextController  	   	ctrl_TxtCotaExtra	= new moneyTextController();
		
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
		
		alphaTextController			ctrl_TxtAfiliada	= new alphaTextController();
		alphaTextController			ctrl_TxtPresenteado	= new alphaTextController();
		alphaTextController			ctrl_TxtRecado		= new alphaTextController();
		
		alphaTextController			ctrl_TxtNomeDep		= new alphaTextController();
		
		alphaTextController			ctrl_TxtAluno		= new alphaTextController();
		numberTextController 		ctrl_TxtSenhaResp   = new numberTextController();
		
		bool 		IsUpdatingDep 		= false;
		
		Color 		colorInvalid 		= Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgNovoCartao ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgNovoCartao ( this );
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
						
					ctrl_TxtCodEmpresa.AcquireTextBox 	( i_Form.TxtCodEmpresa, 	this, event_val_TxtCodEmpresa, 	6  );
					ctrl_TxtMatricula.AcquireTextBox 	( i_Form.TxtMatricula, 		this, event_val_TxtMatricula, 	6  );
					ctrl_TxtSenha.AcquireTextBox 		( i_Form.TxtSenha, 			this, event_val_TxtSenha, 		4  );
					ctrl_TxtVencimento.AcquireTextBox 	( i_Form.TxtVencimento, 	this, event_val_TxtVencimento, 	dateTextController.FORMAT_MMYY );
					ctrl_TxtBanco.AcquireTextBox 		( i_Form.TxtBanco, 			this, event_val_TxtBanco, 		4 	);
					ctrl_TxtAgencia.AcquireTextBox 		( i_Form.TxtAgencia, 		this, event_val_TxtAgencia, 	4 	);
					ctrl_TxtConta.AcquireTextBox 		( i_Form.TxtConta, 			this, event_val_TxtConta, 		10 	);
					ctrl_TxtCelular.AcquireTextBox 		( i_Form.TxtCelular, 		this, event_val_TxtCelular, 	10 	);
					ctrl_TxtLimMensal.AcquireTextBox 	( i_Form.TxtLimMensal, 		this, event_val_TxtLimMensal,  	"R$", 8 );
					ctrl_TxtLimTotal.AcquireTextBox 	( i_Form.TxtLimTotal, 		this, event_val_TxtLimTotal,  	"R$", 8 );
					ctrl_TxtLimRotativo.AcquireTextBox 	( i_Form.TxtLimRotativo, 	this, event_val_TxtLimRotativo, "R$", 8 );
					ctrl_TxtCotaExtra.AcquireTextBox 	( i_Form.TxtCotaExtra, 		this, event_val_TxtCotaExtra, 	"R$", 8 );
										
					ctrl_TxtLimMensal.IsUserValidated 	= true;
					ctrl_TxtLimTotal.IsUserValidated 	= true;
					ctrl_TxtLimRotativo.IsUserValidated = true;
					ctrl_TxtCotaExtra.IsUserValidated 	= true;

					ctrl_TxtCpf.AcquireTextBox 			( i_Form.TxtCpf, 			this, event_val_TxtCpf 						);
					ctrl_TxtNome.AcquireTextBox 		( i_Form.TxtNome, 			this, event_val_TxtNome, 		40, "" 		);
					ctrl_TxtEndereco.AcquireTextBox 	( i_Form.TxtEndereco, 		this, event_val_TxtEndereco, 	40, "" 		);
					ctrl_TxtNumero.AcquireTextBox 		( i_Form.TxtNumero, 		this, event_val_TxtNumero, 		6 			);
					ctrl_TxtComplemento.AcquireTextBox 	( i_Form.TxtComplemento, 	this, event_val_TxtComplemento, 40, alphaTextController.ENABLE_NUMBERS	);
					ctrl_TxtBairro.AcquireTextBox 		( i_Form.TxtBairro, 		this, event_val_TxtBairro, 		20, false 	);
					ctrl_TxtCidade.AcquireTextBox 		( i_Form.TxtCidade, 		this, event_val_TxtCidade, 		20, false 	);
					ctrl_TxtEstado.AcquireTextBox 		( i_Form.TxtEstado, 		this, event_val_TxtEstado,  	2, false 	);
					ctrl_TxtCEP.AcquireTextBox 			( i_Form.TxtCEP, 			this, event_val_TxtCEP, 		9 			);
					ctrl_TxtDDD.AcquireTextBox 			( i_Form.TxtDDD, 			this, event_val_TxtDDD, 		2 			);
					ctrl_TxtTelefone.AcquireTextBox 	( i_Form.TxtTelefone, 		this, event_val_TxtTelefone, 	8 			);
					ctrl_TxtDtNasc.AcquireTextBox 		( i_Form.TxtDtNasc, 		this, event_val_TxtDtNasc, 		dateTextController.FORMAT_DDMMYYYY );
					ctrl_TxtEmail.AcquireTextBox 		( i_Form.TxtEmail,			this, event_val_TxtEmail, 		40 );
					ctrl_TxtRenda.AcquireTextBox		( i_Form.TxtRenda, 			this, event_val_TxtRenda,	  	"R$", 8 );
					
					ctrl_TxtAfiliada.AcquireTextBox		( i_Form.TxtAfiliada, 		this, event_val_TxtAfiliada, 	30, "" 		);
					ctrl_TxtPresenteado.AcquireTextBox	( i_Form.TxtPresenteado, 	this, event_val_TxtPresenteado, 30, "" 		);
					ctrl_TxtRecado.AcquireTextBox		( i_Form.TxtRecado,	 		this, event_val_TxtRecado,		30, alphaTextController.ENABLE_NUMBERS, alphaTextController.ENABLE_SYMBOLS );
					
					ctrl_TxtNomeDep.AcquireTextBox		( i_Form.TxtNomeDep,	 	this, event_val_TxtNomeDep,		40, alphaTextController.ENABLE_NUMBERS );
					
					ctrl_TxtAluno.AcquireTextBox		( i_Form.TxtAluno,	 	this, event_val_TxtAluno,		20 );
					ctrl_TxtSenhaResp.AcquireTextBox 	( i_Form.TxtSenhaResp, 	this, event_val_TxtSenhaResp, 	4  );
					
					i_Form.BtnAtualizar.Enabled = false;
					
					if ( header.get_tg_user_type () ==  TipoUsuario.Administrador || 
				     	 header.get_tg_user_type() == TipoUsuario.Operador )
					{
						DadosEmpresa de = new DadosEmpresa();
						
						var_exchange.fetch_dadosEmpresa ( header.get_st_empresa(), ref header, ref de );
						                                 
						ctrl_TxtAfiliada.SetTextBoxText ( de.get_st_fantasia() );
						
						ctrl_TxtCodEmpresa.SetTextBoxText ( header.get_st_empresa() );
						i_Form.TxtCodEmpresa.ReadOnly = true;
					}
					else if ( header.get_tg_user_type () ==  TipoUsuario.AdminGift || 
				     	 	  header.get_tg_user_type()  == TipoUsuario.VendedorGift )
					{
						i_Form.TxtSenha.ReadOnly 	      = true;
						i_Form.TxtLimMensal.ReadOnly 	  = true;
						i_Form.TxtLimRotativo.ReadOnly 	  = true;
						i_Form.TxtLimTotal.ReadOnly 	  = true;
						i_Form.TxtCotaExtra.ReadOnly 	  = true;
						i_Form.TxtVencimento.ReadOnly     = true;
						i_Form.TxtBanco.ReadOnly     	  = true;
						i_Form.TxtAgencia.ReadOnly     	  = true;
						i_Form.TxtConta.ReadOnly     	  = true;
						i_Form.TxtCelular.ReadOnly     	  = true;
						i_Form.TxtAluno.ReadOnly 		  = true;
						i_Form.TxtSenhaResp.ReadOnly	  = true;
						i_Form.TxtAfiliada.ReadOnly		  = true;
						
						i_Form.tbCtrl.TabPages.RemoveAt (3);
						
						i_Form.Text = "Venda de cartão GiftCard";
						
						ctrl_TxtCodEmpresa.SetTextBoxText ( header.get_st_empresa() );							
						i_Form.TxtCodEmpresa.ReadOnly = true;
					}
					
					doEvent ( event_ErrorProvider, null );
					
					i_Form.CboTipoCart.Items.AddRange ( new TipoCartaoDesc().GetArray().ToArray() );
					i_Form.CboTipoCart.SelectedIndex = 1;
					
					if ( header.get_tg_user_type () !=  TipoUsuario.SuperUser )
					{
						if ( header.get_tg_user_type () != TipoUsuario.AdminGift && 
					     	 header.get_tg_user_type()  != TipoUsuario.VendedorGift )
						{
							i_Form.CboTipoCart.SelectedIndex = 0;
							i_Form.CboTipoCart.Enabled       = false;
							
							i_Form.TxtAluno.ReadOnly     = true;
							i_Form.TxtSenhaResp.ReadOnly = true;
							i_Form.TxtAfiliada.ReadOnly  = true;						
							i_Form.TxtRecado.ReadOnly    = true;
							i_Form.TxtPresenteado.ReadOnly = true;
						}
						else
						{
							i_Form.CboTipoCart.SelectedIndex = 1;
							i_Form.CboTipoCart.Enabled       = false;
							
							i_Form.TxtAluno.ReadOnly     = true;
							i_Form.TxtSenhaResp.ReadOnly = true;
						}
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ErrorProvider -
				
				case event_ErrorProvider:
				{
					//InitEventCode event_ErrorProvider
						
					ctrl_TxtCodEmpresa.SetupErrorProvider   ( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtMatricula.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtVencimento.SetupErrorProvider   ( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtBanco.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtAgencia.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtConta.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtCelular.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false );
										
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
					
					ctrl_TxtAluno.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtSenhaResp.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtLimMensal.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtLimTotal.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtPresenteado.SetupErrorProvider  ( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtRecado.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false );
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - robot_ShowDialog -
				
				case robot_ShowDialog:
				{
					//InitEventCode robot_ShowDialog
						
						if ( i_Form.IsDisposed ) i_Form = new dlgNovoCartao ( this );
						
						i_Form.Show();
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - robot_CloseDialog -
				
				case robot_CloseDialog:
				{
					//InitEventCode robot_CloseDialog
						
						i_Form.Close();
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCodEmpresa -
				
				case event_val_TxtCodEmpresa:
				{
					//InitEventCode event_val_TxtCodEmpresa
						
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtCodEmpresa.Text.Length > 0 )
							{
								i_Form.TxtCodEmpresa.BackColor     = Color.White;
								ctrl_TxtCodEmpresa.IsUserValidated = true;
								ctrl_TxtCodEmpresa.CleanError();
							}
							else
							{
								i_Form.TxtCodEmpresa.BackColor     = colorInvalid;
								ctrl_TxtCodEmpresa.IsUserValidated = false;
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
				
				#region - event_val_TxtSenha -
				
				case event_val_TxtSenha:
				{
					//InitEventCode event_val_TxtSenha
						
					if ( header.get_tg_user_type () ==  TipoUsuario.AdminGift || 
					     header.get_tg_user_type()  == TipoUsuario.VendedorGift )
					{
						return false;
					}
						
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtSenha.Text.Length > 3 )
							{
								i_Form.TxtSenha.BackColor = Color.White;
								ctrl_TxtSenha.IsUserValidated = true;
								ctrl_TxtSenha.CleanError();
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
				
				#region - event_val_TxtVencimento -
				
				case event_val_TxtVencimento:
				{
					//InitEventCode event_val_TxtVencimento
						
					if ( header.get_tg_user_type () ==  TipoUsuario.AdminGift || 
					     header.get_tg_user_type()  == TipoUsuario.VendedorGift )
					{
						return false;
					}
					
					switch ( arg as string )
					{
						case dateTextController.DATE_INVALID:
						{
							i_Form.TxtVencimento.BackColor = colorInvalid;
							ctrl_TxtVencimento.IsUserValidated = false;
							break;
						}
						
						case dateTextController.DATE_VALID:
						{
							i_Form.TxtVencimento.BackColor = Color.White;
							ctrl_TxtVencimento.IsUserValidated = true;
							ctrl_TxtVencimento.CleanError();
							break;
						}
						
						default: break;
					}
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtBanco -
				
				case event_val_TxtBanco:
				{
					//InitEventCode event_val_TxtBanco
						
					if ( header.get_tg_user_type () ==  TipoUsuario.AdminGift || 
					     header.get_tg_user_type()  == TipoUsuario.VendedorGift )
					{
						return false;
					}
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtBanco.Text.Length > 0 )
							{
								i_Form.TxtBanco.BackColor = Color.White;
								ctrl_TxtBanco.IsUserValidated = true;
								ctrl_TxtBanco.CleanError();
							}
							else
							{
								i_Form.TxtBanco.BackColor = colorInvalid;
								ctrl_TxtBanco.IsUserValidated = false;
							}
							
							break;
						}
						
						default: break;
					}
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtAgencia -
				
				case event_val_TxtAgencia:
				{
					//InitEventCode event_val_TxtAgencia
						
					if ( header.get_tg_user_type () ==  TipoUsuario.AdminGift || 
					     header.get_tg_user_type()  == TipoUsuario.VendedorGift )
					{
						return false;
					}
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtAgencia.Text.Length > 0 )
							{
								i_Form.TxtAgencia.BackColor = Color.White;
								ctrl_TxtAgencia.IsUserValidated = true;
								ctrl_TxtAgencia.CleanError();
							}
							else
							{
								i_Form.TxtAgencia.BackColor = colorInvalid;
								ctrl_TxtAgencia.IsUserValidated = false;
							}
							
							break;
						}
						
						default: break;
					}
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtConta -
				
				case event_val_TxtConta:
				{
					//InitEventCode event_val_TxtConta
						
					if ( header.get_tg_user_type () ==  TipoUsuario.AdminGift || 
					     header.get_tg_user_type()  == TipoUsuario.VendedorGift )
					{
						return false;
					}
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtConta.Text.Length > 5 )
							{
								i_Form.TxtConta.BackColor = Color.White;
								ctrl_TxtConta.IsUserValidated = true;
								ctrl_TxtConta.CleanError();
							}
							else
							{
								i_Form.TxtConta.BackColor = colorInvalid;
								ctrl_TxtConta.IsUserValidated = false;
							}
							
							break;
						}
						
						default: break;
					}
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCelular -
				
				case event_val_TxtCelular:
				{
					//InitEventCode event_val_TxtCelular
						
					if ( header.get_tg_user_type () ==  TipoUsuario.AdminGift || 
					     header.get_tg_user_type()  == TipoUsuario.VendedorGift )
					{
						return false;
					}
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtCelular.Text.Length > 7 )
							{
								i_Form.TxtCelular.BackColor = Color.White;
								ctrl_TxtCelular.IsUserValidated = true;
								ctrl_TxtCelular.CleanError();
							}
							else
							{
								i_Form.TxtCelular.BackColor = colorInvalid;
								ctrl_TxtCelular.IsUserValidated = false;
							}
							
							break;
						}
						
						default: break;
					}
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtLimTotal -
				
				case event_val_TxtLimTotal:
				{
					//InitEventCode event_val_TxtLimTotal
						
					if ( ctrl_TxtLimTotal.getTextBoxValue_Long() > 0 )
						ctrl_TxtLimTotal.CleanError();
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtLimMensal -
				
				case event_val_TxtLimMensal:
				{
					//InitEventCode event_val_TxtLimMensal
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtLimRotativo -
				
				case event_val_TxtLimRotativo:
				{
					//InitEventCode event_val_TxtLimRotativo
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCotaExtra -
				
				case event_val_TxtCotaExtra:
				{
					//InitEventCode event_val_TxtCotaExtra
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDiaVenc -
				
				case event_val_TxtDiaVenc:
				{
					//InitEventCode event_val_TxtDiaVenc
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtFatura -
				
				case event_val_TxtFatura:
				{
					//InitEventCode event_val_TxtFatura
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCpf -
				
				case event_val_TxtCpf:
				{
					//InitEventCode event_val_TxtCpf
						
					switch ( arg as string )
					{
						case cnpjTextController.CNPJ_INCOMPLETE:
						case cnpjTextController.CNPJ_INVALID:
						case cpfTextController.CPF_INCOMPLETE:
						case cpfTextController.CPF_INVALID:
						{
							i_Form.TxtCpf.BackColor = colorInvalid;
							ctrl_TxtCpf.IsUserValidated = false;
							
							i_Form.TxtEndereco.ReadOnly = false;
							i_Form.TxtNumero.ReadOnly = false;
							i_Form.TxtComplemento.ReadOnly = false;
							i_Form.TxtBairro.ReadOnly = false;
							i_Form.TxtCidade.ReadOnly = false;
							i_Form.TxtEstado.ReadOnly = false;
							i_Form.TxtCEP.ReadOnly = false;
							i_Form.TxtDDD.ReadOnly = false;
							i_Form.TxtTelefone.ReadOnly = false;
							i_Form.TxtDtNasc.ReadOnly = false;
							i_Form.TxtEmail.ReadOnly = false;
							i_Form.TxtRenda.ReadOnly = false;
							i_Form.TxtNome.ReadOnly = false;
										
							break;
						}
							
						case cpfTextController.CPF_VALID:
						case cnpjTextController.CNPJ_VALID:
						{
							i_Form.TxtCpf.BackColor = Color.White;
							ctrl_TxtCpf.IsUserValidated = true;
							ctrl_TxtCpf.CleanError();
							
							if ( !ctrl_TxtNome.IsUserValidated )
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
										
										ctrl_TxtEndereco.CleanError();
										ctrl_TxtNumero.CleanError();
										ctrl_TxtComplemento.CleanError();
										ctrl_TxtBairro.CleanError();
										ctrl_TxtCidade.CleanError();
										ctrl_TxtEstado.CleanError();
										ctrl_TxtCEP.CleanError();
										ctrl_TxtDDD.CleanError();
										ctrl_TxtTelefone.CleanError();
										ctrl_TxtDtNasc.CleanError();
										ctrl_TxtEmail.CleanError();
										ctrl_TxtRenda.CleanError();
										ctrl_TxtNome.CleanError();
										
										i_Form.TxtEndereco.ReadOnly = true;
										i_Form.TxtNumero.ReadOnly = true;
										i_Form.TxtComplemento.ReadOnly = true;
										i_Form.TxtBairro.ReadOnly = true;
										i_Form.TxtCidade.ReadOnly = true;
										i_Form.TxtEstado.ReadOnly = true;
										i_Form.TxtCEP.ReadOnly = true;
										i_Form.TxtDDD.ReadOnly = true;
										i_Form.TxtTelefone.ReadOnly = true;
										i_Form.TxtDtNasc.ReadOnly = true;
										i_Form.TxtEmail.ReadOnly = true;
										i_Form.TxtRenda.ReadOnly = true;
										i_Form.TxtNome.ReadOnly = true;
									}
									else
									{
										i_Form.TxtEndereco.ReadOnly = false;
										i_Form.TxtNumero.ReadOnly = false;
										i_Form.TxtComplemento.ReadOnly = false;
										i_Form.TxtBairro.ReadOnly = false;
										i_Form.TxtCidade.ReadOnly = false;
										i_Form.TxtEstado.ReadOnly = false;
										i_Form.TxtCEP.ReadOnly = false;
										i_Form.TxtDDD.ReadOnly = false;
										i_Form.TxtTelefone.ReadOnly = false;
										i_Form.TxtDtNasc.ReadOnly = false;
										i_Form.TxtEmail.ReadOnly = false;
										i_Form.TxtRenda.ReadOnly = false;
										i_Form.TxtNome.ReadOnly = false;
									}
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
				
				#region - event_val_TxtEndereco -
				
				case event_val_TxtEndereco:
				{
					//InitEventCode event_val_TxtEndereco
						
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtEndereco.getTextBoxValue().Length > 0 )
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
				
				#region - event_val_TxtBairro -
				
				case event_val_TxtBairro:
				{
					//InitEventCode event_val_TxtBairro
						
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
							{
								if ( ctrl_TxtBairro.getTextBoxValue().Length > 0 )
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
								if ( ctrl_TxtCidade.getTextBoxValue().Length > 0 )
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
				
				#region - event_val_TxtAfiliada -
				
				case event_val_TxtAfiliada:
				{
					//InitEventCode event_val_TxtAfiliada
						
					if ( header.get_tg_user_type () ==  TipoUsuario.AdminGift || 
					     header.get_tg_user_type()  == TipoUsuario.VendedorGift )
					{
						return false;
					}
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
							{
								if ( ctrl_TxtAfiliada.getTextBoxValue().Length > 4 )
								{
									i_Form.TxtAfiliada.BackColor = Color.White;
									ctrl_TxtAfiliada.IsUserValidated = true;
								}
								else
								{
									i_Form.TxtAfiliada.BackColor = colorInvalid;
									ctrl_TxtAfiliada.IsUserValidated = false;
								}
								
								break;
							}
							
							default: break;
					}
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtPresenteado -
				
				case event_val_TxtPresenteado:
				{
					//InitEventCode event_val_TxtPresenteado
						
					if ( header.get_tg_user_type () !=  TipoUsuario.AdminGift && 
				     	 header.get_tg_user_type()  != TipoUsuario.VendedorGift )
						return false;
						
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
							{
								if ( ctrl_TxtPresenteado.getTextBoxValue().Length > 4 )
								{
									i_Form.TxtPresenteado.BackColor = Color.White;
									ctrl_TxtPresenteado.IsUserValidated = true;
									ctrl_TxtPresenteado.CleanError();
								}
								else
								{
									i_Form.TxtPresenteado.BackColor = colorInvalid;
									ctrl_TxtPresenteado.IsUserValidated = false;
								}
								
								break;
							}
							
							default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtRecado -
				
				case event_val_TxtRecado:
				{
					//InitEventCode event_val_TxtRecado
						
					if ( header.get_tg_user_type () !=  TipoUsuario.AdminGift && 
				     	 header.get_tg_user_type()  != TipoUsuario.VendedorGift )
						return false;
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
							{
								if ( ctrl_TxtRecado.getTextBoxValue().Length > 3 )
								{
									i_Form.TxtRecado.BackColor = Color.White;
									ctrl_TxtRecado.IsUserValidated = true;
									ctrl_TxtRecado.CleanError();
								}
								else
								{
									i_Form.TxtRecado.BackColor = colorInvalid;
									ctrl_TxtRecado.IsUserValidated = false;
								}
								
								break;
							}
							
							default: break;
					}
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtNomeDep -
				
				case event_val_TxtNomeDep:
				{
					//InitEventCode event_val_TxtNomeDep
						
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtNomeDep.getTextBoxValue().Length > 3 )
							{
								i_Form.TxtNomeDep.BackColor = Color.White;
								ctrl_TxtNomeDep.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtNomeDep.BackColor = colorInvalid;
								ctrl_TxtNomeDep.IsUserValidated = false;
							}
							
							break;
						}
						
						default: break;
					}
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_AdicionarDependente -
				
				case event_AdicionarDependente:
				{
					//InitEventCode event_AdicionarDependente
						
					if ( ctrl_TxtNomeDep.IsUserValidated )
					{
						if ( i_Form.CboTipoCart.SelectedIndex.ToString() == TipoCartao.empresarial )
						{
							i_Form.CboDependentes.Items.Add ( ctrl_TxtNomeDep.getTextBoxValue() );
							i_Form.TxtTitularidade.Text = ( Convert.ToInt32 ( i_Form.TxtTitularidade.Text ) + 1 ).ToString();
							ctrl_TxtNomeDep.SetTextBoxText ( "" );
						}
						else
						{								
							if ( i_Form.CboTipoCart.SelectedIndex.ToString() == TipoCartao.educacional )
								MessageBox.Show ( "Cartão Educacional não possibilita dependentes", "Aviso" );
							else
								MessageBox.Show ( "Cartão GiftCard não possibilita dependentes", "Aviso" );
						}
					}
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CboDepChange -
				
				case event_CboDepChange:
				{
					//InitEventCode event_CboDepChange
						
					if ( IsUpdatingDep == true )
					{
						IsUpdatingDep = false;
						return true;
					}
					
					if ( i_Form.CboDependentes.Items.Count > 0 )
					{
						i_Form.TxtTitularidade.Text = ( i_Form.CboDependentes.SelectedIndex + 2 ).ToString();
						
						ctrl_TxtNomeDep.SetTextBoxText ( i_Form.CboDependentes.SelectedItem.ToString() );
						
						i_Form.BtnAdicionar.Enabled = false;
						i_Form.BtnAtualizar.Enabled = true;
					}
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_AtualizarDep -
				
				case event_AtualizarDep:
				{
					//InitEventCode event_AtualizarDep
					
					if ( i_Form.CboTipoCart.SelectedIndex.ToString() == TipoCartao.empresarial )
					{
						i_Form.BtnAdicionar.Enabled = true;
						i_Form.BtnAtualizar.Enabled = false;
						
						IsUpdatingDep = true;
						
						i_Form.CboDependentes.Items [ i_Form.CboDependentes.SelectedIndex ] = ctrl_TxtNomeDep.getTextBoxValue();
						i_Form.CboDependentes.SelectedIndex = 0;
						i_Form.TxtTitularidade.Text = ( i_Form.CboDependentes.Items.Count + 2 ).ToString();
						
						ctrl_TxtNomeDep.SetTextBoxText ( "" );
					}
					else
					{								
						if ( i_Form.CboTipoCart.SelectedIndex.ToString() == TipoCartao.educacional )
							MessageBox.Show ( "Cartão Educacional não possibilita dependentes", "Aviso" );
						else
							MessageBox.Show ( "Cartão GiftCard não possibilita dependentes", "Aviso" );
					}
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Cancelar -
				
				case event_Cancelar:
				{
					//InitEventCode event_Cancelar
						
					i_Form.Close();
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Confirmar -
				
				case event_Confirmar:
				{
					//InitEventCode event_Confirmar
						
					ctrl_TxtCodEmpresa.CleanError();
					ctrl_TxtMatricula.CleanError();
					ctrl_TxtVencimento.CleanError();
					ctrl_TxtBanco.CleanError();
					ctrl_TxtAgencia.CleanError();
					ctrl_TxtConta.CleanError();
					ctrl_TxtCelular.CleanError();
					ctrl_TxtCpf.CleanError();
					ctrl_TxtNome.CleanError();
					ctrl_TxtEndereco.CleanError();
					ctrl_TxtNumero.CleanError();
					ctrl_TxtComplemento.CleanError();
					ctrl_TxtBairro.CleanError();
					ctrl_TxtCidade.CleanError();
					ctrl_TxtEstado.CleanError();
					ctrl_TxtCEP.CleanError();
					ctrl_TxtDDD.CleanError();
					ctrl_TxtTelefone.CleanError();
					ctrl_TxtDtNasc.CleanError();
					ctrl_TxtEmail.CleanError();
					ctrl_TxtRenda.CleanError();
					ctrl_TxtAluno.CleanError();
					ctrl_TxtSenhaResp.CleanError();
					ctrl_TxtLimMensal.CleanError();
					ctrl_TxtLimTotal.CleanError();
					ctrl_TxtPresenteado.CleanError();
					ctrl_TxtRecado.CleanError();						
					
					bool IsDone = true;
					
					if ( !ctrl_TxtCodEmpresa.IsUserValidated )	{	ctrl_TxtCodEmpresa.SetErrorMessage 		( "O código da empresa deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtMatricula.IsUserValidated )	{	ctrl_TxtMatricula.SetErrorMessage 		( "A matricula deve ser informada" );	IsDone = false;	}
					
					if ( i_Form.CboTipoCart.SelectedIndex.ToString() != TipoCartao.educacional )
					{
						if ( i_Form.CboTipoCart.SelectedIndex.ToString() == TipoCartao.empresarial )
						{
							if ( !ctrl_TxtVencimento.IsUserValidated )	{	ctrl_TxtVencimento.SetErrorMessage 		( "Mês e ano de vencimento deve ser preenchido" );	IsDone = false;	}
						}
						
						if ( i_Form.CboTipoCart.SelectedIndex.ToString() == TipoCartao.presente )
						{
							/*
							if ( !ctrl_TxtPresenteado.IsUserValidated )
							{
								ctrl_TxtPresenteado.SetErrorMessage ( "Cartão presente requer nome de presenteado" );	
								IsDone = false;
							}
							*/
						}
					}
					else
					{
						if ( !ctrl_TxtAluno.IsUserValidated )		{	ctrl_TxtAluno.SetErrorMessage 			( "O nome do aluno deve ser informado" );			IsDone = false;	}
						if ( !ctrl_TxtSenhaResp.IsUserValidated )	{	ctrl_TxtSenhaResp.SetErrorMessage 		( "A senha do responsável deve ser informada" );	IsDone = false;	}
					}
					
					if ( !ctrl_TxtCpf.IsUserValidated )			{	ctrl_TxtCpf.SetErrorMessage 			( "O cpf deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtNome.IsUserValidated )		{	ctrl_TxtNome.SetErrorMessage 			( "O nome deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtEndereco.IsUserValidated )	{	ctrl_TxtEndereco.SetErrorMessage 		( "O endereço deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtNumero.IsUserValidated )		{	ctrl_TxtNumero.SetErrorMessage 			( "O número deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtCidade.IsUserValidated )		{	ctrl_TxtCidade.SetErrorMessage 			( "A cidade deve ser informada" );	IsDone = false;	}
					if ( !ctrl_TxtEstado.IsUserValidated )		{	ctrl_TxtEstado.SetErrorMessage 			( "O estado deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtDtNasc.IsUserValidated )		{	ctrl_TxtDtNasc.SetErrorMessage 			( "A data de nascimento deve ser informada" );	IsDone = false;	}
					
					if ( !IsDone )
					{
						MessageBox.Show ( "Existem pendências de cadastro", "Aviso" );
						return false;
					}
					
					// ### Dados do cartão
					
					DadosCartao dc = new DadosCartao();
					
					dc.set_st_empresa 			( ctrl_TxtCodEmpresa.getTextBoxValue() 					);
					dc.set_st_matricula 		( ctrl_TxtMatricula.getTextBoxValue() 					);
					dc.set_vr_limiteTotal 		( ctrl_TxtLimTotal.getTextBoxValue_NumberStr() 			);
					dc.set_vr_limiteMensal 		( ctrl_TxtLimMensal.getTextBoxValue_NumberStr()  		);
					dc.set_vr_limiteRotativo 	( ctrl_TxtLimRotativo.getTextBoxValue_NumberStr()  		);
					dc.set_vr_extraCota 		( ctrl_TxtCotaExtra.getTextBoxValue_NumberStr()  		);
					dc.set_st_banco 			( ctrl_TxtBanco.getTextBoxValue().PadLeft ( 1, '0') 	);
					dc.set_st_agencia 			( ctrl_TxtAgencia.getTextBoxValue().PadLeft ( 1, '0')	);
					dc.set_st_conta 			( ctrl_TxtConta.getTextBoxValue().PadLeft ( 1, '0') 	);
					dc.set_st_celCartao 		( ctrl_TxtCelular.getTextBoxValue() 					);
					dc.set_st_vencimento		( ctrl_TxtVencimento.getTextBoxValue_Number().PadLeft (4, '0') );
					dc.set_tg_tipoCartao		( i_Form.CboTipoCart.SelectedIndex.ToString() 			);
					
					dc.set_st_senha ( var_util.DESCript ( ctrl_TxtSenha.getTextBoxValue().PadLeft ( 8, '*'), "12345678" )	);
					
					// ### Dados proprietário
					
					DadosProprietario dp = new DadosProprietario();
					
					dp.set_st_cpf 				( ctrl_TxtCpf.getTextBoxValue() 				);
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

					DadosAdicionais da = new DadosAdicionais();
					
					da.set_st_empresa 			( ctrl_TxtAfiliada.getTextBoxValue() 			);
					da.set_st_presenteado 		( ctrl_TxtPresenteado.getTextBoxValue() 		);
					da.set_st_recado 			( ctrl_TxtRecado.getTextBoxValue()	 			);
					da.set_st_nome_aluno 		( ctrl_TxtAluno.getTextBoxValue() 				);

					da.set_st_senha_resp ( var_util.DESCript ( ctrl_TxtSenhaResp.getTextBoxValue(), "12345678" )	);
					
					StringBuilder deps = new StringBuilder();
					
					int max = i_Form.CboDependentes.Items.Count;
					
					for ( int t=0; t < max; ++t)
					{
						deps.Append ( i_Form.CboDependentes.Items[t].ToString() );
						if ( t < max - 1 )	deps.Append ( "|" );
					}
					
					string st_csv_deps = deps.ToString();
					
					if ( i_Form.CboTipoCart.SelectedIndex.ToString() == TipoCartao.presente )
					{
						event_dlgConfGiftCard ev_call = new event_dlgConfGiftCard ( var_util, var_exchange );
				
						ev_call.header = header;
						ev_call.dp 	   = dp;
						ev_call.da 	   = da;
						ev_call.dc 	   = dc;
						
						ev_call.i_Form.ShowDialog();
						i_Form.Close();
					}
					else
					{
						if ( var_exchange.ins_cartaoProprietario ( 	st_csv_deps,
						                                          	ref dc,
						                                          	ref dp,
						                                          	ref da,
						                                          	ref header ) )
						{
							i_Form.Close();
						}
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtAluno -
				
				case event_val_TxtAluno:
				{
					//InitEventCode event_val_TxtAluno
						
					if ( header.get_tg_user_type () ==  TipoUsuario.AdminGift || 
					     header.get_tg_user_type()  == TipoUsuario.VendedorGift )
					{
						return false;
					}
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
							{
								if ( ctrl_TxtAluno.getTextBoxValue().Length > 3 )
								{
									i_Form.TxtAluno.BackColor = Color.White;
									ctrl_TxtAluno.IsUserValidated = true;
									ctrl_TxtAluno.CleanError();
								}
								else
								{
									i_Form.TxtAluno.BackColor = colorInvalid;
									ctrl_TxtAluno.IsUserValidated = false;
								}
								
								break;
							}
							
							default: break;
					}
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtSenhaResp -
				
				case event_val_TxtSenhaResp:
				{
					//InitEventCode event_val_TxtSenhaResp
						
					if ( header.get_tg_user_type () ==  TipoUsuario.AdminGift || 
					     header.get_tg_user_type()  == TipoUsuario.VendedorGift )
					{
						return false;
					}
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
							{
								if ( i_Form.TxtSenhaResp.Text.Length > 3 )
								{
									i_Form.TxtSenhaResp.BackColor = Color.White;
									ctrl_TxtSenhaResp.IsUserValidated = true;
									ctrl_TxtSenhaResp.CleanError();
								}
								else
								{
									i_Form.TxtSenhaResp.BackColor = colorInvalid;
									ctrl_TxtSenhaResp.IsUserValidated = false;
								}
								
								break;
							}
							
							default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnAtualizarClick -
				
				case event_BtnAtualizarClick:
				{
					//InitEventCode event_BtnAtualizarClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnAdicionarClick -
				
				case event_BtnAdicionarClick:
				{
					//InitEventCode event_BtnAdicionarClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CboDependentesSelectedIndexChanged -
				
				case event_CboDependentesSelectedIndexChanged:
				{
					//InitEventCode event_CboDependentesSelectedIndexChanged
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
