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
	public class event_dlgNovaEmpresa : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_val_TxtEmpresa = 6;
		public const int event_val_TxtCNPJ = 7;
		public const int event_val_TxtFantasia = 8;
		public const int event_val_TxtSocial = 9;
		public const int event_val_TxtEndereco = 10;
		public const int event_val_TxtCidade = 11;
		public const int event_val_TxtEstado = 12;
		public const int event_val_TxtCEP = 13;
		public const int event_val_TxtTelefone = 14;
		public const int event_val_TxtCartoes = 15;
		public const int event_val_TxtFatura = 16;
		public const int event_val_TxtDiaCredito = 17;
		public const int event_val_TxtTaxa = 18;
		public const int event_val_TxtDiasBloqueio = 19;
		public const int event_val_TxtPontos = 20;
		public const int event_val_TxtParcelas = 21;
		public const int event_BuscaDados = 22;
		public const int event_val_TxtTarif = 23;
		public const int event_val_TxtPctTrans = 24;
		public const int event_val_TxtVrTrans = 25;
		public const int event_val_TxtVrMin = 26;
		public const int event_val_TxtFranqTrans = 27;
		public const int event_val_TxtBancoCob = 28;
		public const int event_val_TxtDiaVenc = 29;
		public const int event_val_TxtValCartAtv = 30;
		public const int event_val_TxtContaDeb = 31;
		public const int event_val_TxtObs = 32;
		public const int event_BtnConfirmarClick = 33;
		public const int event_BtnBloqClick = 34;
		public const int event_BtnDesbloqClick = 35;
		#endregion

		public dlgNovaEmpresa i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		public bool IsMaintenance = false;		
		
		public string par_code = "";
		
		numberTextController 		ctrl_TxtEmpresa			= new numberTextController();
		cnpjTextController			ctrl_TxtCNPJ			= new cnpjTextController();
		alphaTextController			ctrl_TxtFantasia		= new alphaTextController();
		alphaTextController			ctrl_TxtSocial			= new alphaTextController();
		alphaTextController			ctrl_TxtEndereco		= new alphaTextController();
		alphaTextController			ctrl_TxtCidade			= new alphaTextController();
		alphaTextController			ctrl_TxtEstado			= new alphaTextController();
		numberTextController		ctrl_TxtCEP				= new numberTextController();
		numberTextController 		ctrl_TxtTelefone		= new numberTextController();
		numberTextController 		ctrl_TxtCartoes			= new numberTextController();
		numberTextController 		ctrl_TxtParcelas		= new numberTextController();
		numberTextController 		ctrl_TxtFatura			= new numberTextController();
		moneyTextController  	   	ctrl_TxtTarif			= new moneyTextController();
		percentTextController		ctrl_TxtPctTrans		= new percentTextController();
		moneyTextController  	   	ctrl_TxtVrTrans			= new moneyTextController();
		moneyTextController  	   	ctrl_TxtVrMin			= new moneyTextController();
		numberTextController 		ctrl_TxtFranqTrans		= new numberTextController();
		numberTextController 		ctrl_TxtBancoCob		= new numberTextController();
		numberTextController 		ctrl_TxtDiaVenc  		= new numberTextController();
		moneyTextController			ctrl_TxtValCartAtv		= new moneyTextController();
		numberTextController	    ctrl_TxtContaDeb  		= new numberTextController();
		
		alphaTextController			ctrl_TxtObs				= new alphaTextController();
        alphaTextController         ctrl_TxtHomepage = new alphaTextController();
		Color 	colorInvalid 	= Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgNovaEmpresa ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgNovaEmpresa ( this );
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

					i_Form.CboCob.Items.Clear();
					i_Form.CboCob.Items.AddRange ( new TipoCobrancaDesc().GetArray().ToArray() );					
					
					if ( IsMaintenance )
					{
						i_Form.Text =  "Manutenção de cadastro da empresa";
						i_Form.BtnConfirmar.Text = "Atualizar";
					}
					else
					{
						i_Form.Text =  "Cadastro de empresa";
					}
					
					ctrl_TxtEmpresa.AcquireTextBox 			( i_Form.TxtEmpresa, 		this, event_val_TxtEmpresa, 		6  	);
					ctrl_TxtCNPJ.AcquireTextBox 			( i_Form.TxtCNPJ, 			this, event_val_TxtCNPJ 				);
					ctrl_TxtFantasia.AcquireTextBox 		( i_Form.TxtFantasia, 		this, event_val_TxtFantasia, 		40, alphaTextController.ENABLE_NUMBERS 	);
					ctrl_TxtSocial.AcquireTextBox 			( i_Form.TxtSocial, 		this, event_val_TxtSocial, 			40, alphaTextController.ENABLE_NUMBERS, alphaTextController.ENABLE_SYMBOLS 	);
					ctrl_TxtEndereco.AcquireTextBox 		( i_Form.TxtEndereco, 		this, event_val_TxtEndereco, 		40, alphaTextController.ENABLE_NUMBERS, alphaTextController.ENABLE_SYMBOLS 	);
					ctrl_TxtCidade.AcquireTextBox 			( i_Form.TxtCidade, 		this, event_val_TxtCidade, 			20, false 	);
					ctrl_TxtEstado.AcquireTextBox 			( i_Form.TxtEstado, 		this, event_val_TxtEstado, 			2, false 	);
					ctrl_TxtCEP.AcquireTextBox 				( i_Form.TxtCEP, 			this, event_val_TxtCEP, 			10 	);
					ctrl_TxtTelefone.AcquireTextBox 		( i_Form.TxtTelefone, 		this, event_val_TxtTelefone,  		10 	);
					ctrl_TxtCartoes.AcquireTextBox 			( i_Form.TxtCartoes, 		this, event_val_TxtCartoes,  		6 	);
					ctrl_TxtParcelas.AcquireTextBox 		( i_Form.TxtParcelas, 		this, event_val_TxtParcelas,  		2 	);
					ctrl_TxtFatura.AcquireTextBox 			( i_Form.TxtFatura, 		this, event_val_TxtFatura, 			2 	);
					
					ctrl_TxtObs.AcquireTextBox 	( i_Form.TxtObs, 	this, event_val_TxtObs, 	200, alphaTextController.ENABLE_NUMBERS, alphaTextController.ENABLE_SYMBOLS 	);

					// faturamento
					
					ctrl_TxtTarif.AcquireTextBox 			( i_Form.TxtTarif, 			this, event_val_TxtTarif, 			"R$", 6 	);
					ctrl_TxtPctTrans.AcquireTextBox 		( i_Form.TxtPctTrans, 		this, event_val_TxtTarif,              5, 2     );
					ctrl_TxtVrTrans.AcquireTextBox 			( i_Form.TxtVrTrans, 		this, event_val_TxtVrTrans, 		"R$", 6 	);
					ctrl_TxtVrMin.AcquireTextBox 			( i_Form.TxtVrMin, 			this, event_val_TxtVrMin, 			"R$", 6 	);
					ctrl_TxtFranqTrans.AcquireTextBox 		( i_Form.TxtFranqTrans, 	this, event_val_TxtFranqTrans, 			  8  	);
					ctrl_TxtBancoCob.AcquireTextBox 		( i_Form.TxtBancoCob, 		this, event_val_TxtBancoCob, 			3 	);
					ctrl_TxtDiaVenc.AcquireTextBox 			( i_Form.TxtDiaVenc, 		this, event_val_TxtDiaVenc, 			2 	);
					ctrl_TxtValCartAtv.AcquireTextBox 		( i_Form.TxtValCartAtv,		this, event_val_TxtValCartAtv, 		"R$", 6 	);
					ctrl_TxtContaDeb.AcquireTextBox 		( i_Form.TxtContaDeb, 		this, event_val_TxtContaDeb, 			14 		);
										
					ctrl_TxtEmpresa.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtCNPJ.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtFantasia.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtSocial.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtEndereco.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtCidade.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtEstado.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtCEP.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtTelefone.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtCartoes.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtParcelas.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtFatura.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtTarif.SetupErrorProvider 	  	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtPctTrans.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtVrTrans.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtVrMin.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtFranqTrans.SetupErrorProvider   ( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtBancoCob.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtDiaVenc.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtValCartAtv.SetupErrorProvider  	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtContaDeb.SetupErrorProvider  	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtObs.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false ); 
					
					ctrl_TxtFranqTrans.SetTextBoxText ( "0" );
					
					i_Form.BtnBloq.Visible = false;
					i_Form.BtnDesbloq.Visible = false;
					
					if ( par_code.Length > 0 )
					{
						doEvent ( event_BuscaDados, null );
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
											
					if ( !ctrl_TxtEmpresa.IsUserValidated 		)	{	ctrl_TxtEmpresa.SetErrorMessage 		( "Código de empresa deve estar preenchido" );	IsDone = false;	}
					if ( !ctrl_TxtCNPJ.IsUserValidated 			)	{	ctrl_TxtCNPJ.SetErrorMessage 			( "CNPJ deve estar preenchido" );	IsDone = false;	}
					if ( !ctrl_TxtFantasia.IsUserValidated 		)	{	ctrl_TxtFantasia.SetErrorMessage 		( "Descrição de fantasia deve estar preenchida" );	IsDone = false;	}
					if ( !ctrl_TxtSocial.IsUserValidated 		)	{	ctrl_TxtSocial.SetErrorMessage 			( "Descrição social deve estar preenchida" );	IsDone = false;	}
					if ( !ctrl_TxtEndereco.IsUserValidated 		)	{	ctrl_TxtEndereco.SetErrorMessage 		( "Endereço deve estar preenchido" );	IsDone = false;	}
					if ( !ctrl_TxtEstado.IsUserValidated 		)	{	ctrl_TxtEstado.SetErrorMessage 			( "Estado deve ser preenchido" );	IsDone = false;	}
					if ( !ctrl_TxtCidade.IsUserValidated 		)	{	ctrl_TxtCidade.SetErrorMessage 			( "Cidade deve ser preenchida" );	IsDone = false;	}
					if ( !ctrl_TxtCEP.IsUserValidated 			)	{	ctrl_TxtCEP.SetErrorMessage 			( "CEP deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtTelefone.IsUserValidated		)	{	ctrl_TxtTelefone.SetErrorMessage	 	( "Telefone deve conter 10 caracteres" );	IsDone = false;	}
					if ( !ctrl_TxtCartoes.IsUserValidated 		)	{	ctrl_TxtCartoes.SetErrorMessage 		( "Número de cartões deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtParcelas.IsUserValidated 		)	{	ctrl_TxtParcelas.SetErrorMessage 		( "Número de parcelas deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtFatura.IsUserValidated 		)	{	ctrl_TxtFatura.SetErrorMessage 			( "O dia de fatura deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtDiaVenc.IsUserValidated 		)	{	ctrl_TxtDiaVenc.SetErrorMessage 		( "O dia de vencimento de fatura deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtBancoCob.IsUserValidated 		)	{	ctrl_TxtBancoCob.SetErrorMessage 		( "O banco para cobrança deve ser informado" );	IsDone = false;	}
					if ( i_Form.CboCob.SelectedIndex == -1		)	{	MessageBox.Show("Esolha o tipo de Cobrança para faturamento","Aviso");	IsDone = false;	}
					
					if ( !ctrl_TxtObs.IsUserValidated 		)	{	ctrl_TxtObs.SetErrorMessage 		( "Observação deve estar preenchida" );	IsDone = false;	}
					
					if ( !ctrl_TxtFranqTrans.IsUserValidated 	)	{	ctrl_TxtFranqTrans.SetErrorMessage 		( "O número de transações deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtContaDeb.IsUserValidated 		)	{	ctrl_TxtContaDeb.SetErrorMessage 		( "O número de conta deve ser informado" );	IsDone = false;	}
					
					if ( !IsDone )
					{
						return false;
					}
					
					DadosEmpresa de = new DadosEmpresa();
					
					de.set_st_empresa 		( ctrl_TxtEmpresa.getTextBoxValue()				);
					de.set_nu_CNPJ 			( ctrl_TxtCNPJ.getTextBoxValue() 				);
					de.set_st_fantasia 		( ctrl_TxtFantasia.getTextBoxValue() 			);
					de.set_st_social 		( ctrl_TxtSocial.getTextBoxValue() 				);
					de.set_st_endereco 		( ctrl_TxtEndereco.getTextBoxValue() 			);
					de.set_st_cidade 		( ctrl_TxtCidade.getTextBoxValue() 				);
					de.set_st_estado 		( ctrl_TxtEstado.getTextBoxValue() 				);
					de.set_nu_CEP 			( ctrl_TxtCEP.getTextBoxValue() 				);
					de.set_nu_telefone 		( ctrl_TxtTelefone.getTextBoxValue() 			);
					de.set_nu_cartoes 		( ctrl_TxtCartoes.getTextBoxValue() 			);
					de.set_nu_parcelas 		( ctrl_TxtParcelas.getTextBoxValue()		 	);
					de.set_nu_periodoFat 	( ctrl_TxtFatura.getTextBoxValue() 				);
					de.set_vr_mensalidade	( ctrl_TxtTarif.getTextBoxValue_NumberStr() 			);
					de.set_vr_cartaoAtivo	( ctrl_TxtValCartAtv.getTextBoxValue_NumberStr()		);
					de.set_nu_pctValor		( ctrl_TxtPctTrans.getTextBoxValue().PadLeft (1,'0') 	);
					de.set_vr_transacao		( ctrl_TxtVrTrans.getTextBoxValue_NumberStr() 			);
					de.set_vr_minimo		( ctrl_TxtVrMin.getTextBoxValue_NumberStr() 			);
					de.set_nu_franquia		( ctrl_TxtFranqTrans.getTextBoxValue() 					);
					de.set_nu_diaVenc		( ctrl_TxtDiaVenc.getTextBoxValue() 					);
					de.set_tg_tipoCobranca	( i_Form.CboCob.SelectedIndex.ToString() 				);
					de.set_nu_bancoFat		( ctrl_TxtBancoCob.getTextBoxValue() 					);
					de.set_nu_contaDeb		( ctrl_TxtContaDeb.getTextBoxValue() 			);
					de.set_st_obs			( ctrl_TxtObs.getTextBoxValue()	 						);
                    de.set_st_homepage      ( i_Form.txtHomepage.Text);
					
					if ( i_Form.CheckIsento.Checked )
					{
						de.set_tg_isento ( Context.TRUE );
					}
					else
					{
						de.set_tg_isento ( Context.FALSE );
					}

					if ( IsMaintenance )
					{
						var_exchange.exec_alteraEmpresa ( ref de, ref header );
					}
					else
					{
						var_exchange.ins_empresa ( ref de, ref header );
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
								
								if ( IsMaintenance )
								{
									if ( ctrl_TxtEmpresa.GetEnterPressed() )
									{
										doEvent ( event_BuscaDados, "Empresa" );
									}									
								}								
							}
							else
							{
								i_Form.TxtEmpresa.BackColor     = colorInvalid;	
								ctrl_TxtEmpresa.IsUserValidated = false;
								
								if ( ctrl_TxtEmpresa.GetEnterPressed() )
								{
									if ( IsMaintenance )
									{
										doEvent ( event_BuscaDados, "Empresa" );
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
							
							if ( ctrl_TxtCNPJ.GetEnterPressed() )
							{
								if ( IsMaintenance )
								{
									doEvent ( event_BuscaDados, "CNPJ" );
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
				
				#region - event_val_TxtFantasia -
				
				case event_val_TxtFantasia:
				{
					//InitEventCode event_val_TxtFantasia
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtFantasia.getTextBoxValue().Length > 2 )
							{
								i_Form.TxtFantasia.BackColor = Color.White;	
								ctrl_TxtFantasia.IsUserValidated = true;
								ctrl_TxtFantasia.CleanError();
							}
							else
							{
								i_Form.TxtFantasia.BackColor = colorInvalid;	
								ctrl_TxtFantasia.IsUserValidated = false;
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
							if ( ctrl_TxtSocial.getTextBoxValue().Length > 3 )
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
							if ( i_Form.TxtTelefone.Text.Length == 10 )
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
				
				#region - event_val_TxtCartoes -
				
				case event_val_TxtCartoes:
				{
					//InitEventCode event_val_TxtCartoes
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtCartoes.Text.Length > 0 )
							{
								i_Form.TxtCartoes.BackColor = Color.White;	
								ctrl_TxtCartoes.IsUserValidated = true;
								ctrl_TxtCartoes.CleanError();
							}
							else
							{
								i_Form.TxtCartoes.BackColor = colorInvalid;	
								ctrl_TxtCartoes.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtFatura -
				
				case event_val_TxtFatura:
				{
					//InitEventCode event_val_TxtFatura
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( ctrl_TxtFatura.getTextBoxValue_Long() > 0 && 
								 ctrl_TxtFatura.getTextBoxValue_Long() < 29)
							{
								i_Form.TxtFatura.BackColor = Color.White;	
								ctrl_TxtFatura.IsUserValidated = true;
								ctrl_TxtFatura.CleanError();
							}
							else
							{
								i_Form.TxtFatura.BackColor = colorInvalid;	
								ctrl_TxtFatura.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDiaCredito -
				
				case event_val_TxtDiaCredito:
				{
					//InitEventCode event_val_TxtDiaCredito
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtTaxa -
				
				case event_val_TxtTaxa:
				{
					//InitEventCode event_val_TxtTaxa
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDiasBloqueio -
				
				case event_val_TxtDiasBloqueio:
				{
					//InitEventCode event_val_TxtDiasBloqueio
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtPontos -
				
				case event_val_TxtPontos:
				{
					//InitEventCode event_val_TxtPontos
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtParcelas -
				
				case event_val_TxtParcelas:
				{
					//InitEventCode event_val_TxtParcelas
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( ctrl_TxtParcelas.getTextBoxValue_Long() > 0 )
							{
								i_Form.TxtParcelas.BackColor = Color.White;	
								ctrl_TxtParcelas.IsUserValidated = true;
								ctrl_TxtParcelas.CleanError();
							}
							else
							{
								i_Form.TxtParcelas.BackColor = colorInvalid;	
								ctrl_TxtParcelas.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BuscaDados -
				
				case event_BuscaDados:
				{
					//InitEventCode event_BuscaDados
					
					if ( par_code.Length > 0 )
					{
						ctrl_TxtEmpresa.SetTextBoxText ( par_code );
					}
					else if ( ctrl_TxtEmpresa.getTextBoxValue().Length == 0 )
					{
						return false;
					}
					
					DadosEmpresa de = new DadosEmpresa();
					
					if ( var_exchange.fetch_dadosEmpresa ( ctrl_TxtEmpresa.getTextBoxValue(), ref header, ref de ) )
					{
						ctrl_TxtEmpresa.SetTextBoxText 		( de.get_st_empresa() 		);	
						
						ctrl_TxtCNPJ.SetTextBoxText 		( de.get_nu_CNPJ()  		);
						ctrl_TxtCNPJ.forceValidation();
						
						ctrl_TxtFantasia.SetTextBoxText 	( de.get_st_fantasia() 							);
						ctrl_TxtSocial.SetTextBoxText 		( de.get_st_social() 							);
						ctrl_TxtEndereco.SetTextBoxText 	( de.get_st_endereco() 							);
						ctrl_TxtCidade.SetTextBoxText 		( de.get_st_cidade() 							);
						ctrl_TxtEstado.SetTextBoxText 		( de.get_st_estado() 							);
						ctrl_TxtCEP.SetTextBoxText 			( de.get_nu_CEP() 								);
						ctrl_TxtTelefone.SetTextBoxText 	( de.get_nu_telefone() 							);
						ctrl_TxtCartoes.SetTextBoxText 		( de.get_nu_cartoes() 							);
						ctrl_TxtParcelas.SetTextBoxText 	( de.get_nu_parcelas() 							);
						ctrl_TxtFatura.SetTextBoxText 		( de.get_nu_periodoFat() 						);
						ctrl_TxtContaDeb.SetTextBoxText 	( de.get_nu_contaDeb().PadLeft ( 1, '0' ) 		);
						ctrl_TxtTarif.SetTextBoxString 		( de.get_vr_mensalidade()						);
						ctrl_TxtValCartAtv.SetTextBoxString ( de.get_vr_cartaoAtivo()						);
						ctrl_TxtPctTrans.SetTextBoxText 	( de.get_nu_pctValor()							);
						ctrl_TxtVrTrans.SetTextBoxString 	( de.get_vr_transacao()							);
						ctrl_TxtVrMin.SetTextBoxString 		( de.get_vr_minimo()							);
						ctrl_TxtFranqTrans.SetTextBoxText 	( de.get_nu_franquia()							);	
						ctrl_TxtDiaVenc.SetTextBoxText 		( de.get_nu_diaVenc()							);	
						ctrl_TxtBancoCob.SetTextBoxText 	( de.get_nu_bancoFat()							);
                        ctrl_TxtObs.SetTextBoxText(de.get_st_obs()                                          );
                        ctrl_TxtHomepage.SetTextBoxText			( de.get_st_homepage());
						
						if ( de.get_tg_bloq() == Context.TRUE )
						{
							i_Form.LblBloq.Text = "Bloqueada";
							i_Form.BtnBloq.Visible = false;
							i_Form.BtnDesbloq.Visible = true;
						}
						else
						{
							i_Form.LblBloq.Text = "Operacional";
							i_Form.BtnBloq.Visible = true;
							i_Form.BtnDesbloq.Visible = false;
						}
						
						if ( de.get_tg_tipoCobranca() != "" )
						{
							i_Form.CboCob.SelectedIndex = Convert.ToInt32( de.get_tg_tipoCobranca() );
						}
						
						if ( de.get_tg_isento() == Context.TRUE )
						{
							i_Form.CheckIsento.Checked = true;
						}
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtTarif -
				
				case event_val_TxtTarif:
				{
					//InitEventCode event_val_TxtTarif
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtPctTrans -
				
				case event_val_TxtPctTrans:
				{
					//InitEventCode event_val_TxtPctTrans
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtVrTrans -
				
				case event_val_TxtVrTrans:
				{
					//InitEventCode event_val_TxtVrTrans
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtVrMin -
				
				case event_val_TxtVrMin:
				{
					//InitEventCode event_val_TxtVrMin
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtFranqTrans -
				
				case event_val_TxtFranqTrans:
				{
					//InitEventCode event_val_TxtFranqTrans
					
					if ( ctrl_TxtFranqTrans.getTextBoxValue().Length > 0 )
					{
						i_Form.TxtFranqTrans.BackColor = Color.White;	
						ctrl_TxtFranqTrans.IsUserValidated = true;
						ctrl_TxtFranqTrans.CleanError();
					}
					else		
					{
						i_Form.TxtFranqTrans.BackColor = colorInvalid;	
						ctrl_TxtFranqTrans.IsUserValidated = false;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtBancoCob -
				
				case event_val_TxtBancoCob:
				{
					//InitEventCode event_val_TxtBancoCob
				
					if ( ctrl_TxtBancoCob.getTextBoxValue().Length > 0 )
					{
						i_Form.TxtBancoCob.BackColor = Color.White;	
						ctrl_TxtBancoCob.IsUserValidated = true;
						ctrl_TxtBancoCob.CleanError();
					}
					else
					{
						i_Form.TxtBancoCob.BackColor = colorInvalid;	
						ctrl_TxtBancoCob.IsUserValidated = false;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDiaVenc -
				
				case event_val_TxtDiaVenc:
				{
					//InitEventCode event_val_TxtDiaVenc
					
					long dia = ctrl_TxtDiaVenc.getTextBoxValue_Long();
					
					if ( dia > 0 && dia < 29 )
					{
						i_Form.TxtDiaVenc.BackColor = Color.White;	
						ctrl_TxtDiaVenc.IsUserValidated = true;
						ctrl_TxtDiaVenc.CleanError();
					}
					else
					{
						i_Form.TxtDiaVenc.BackColor = colorInvalid;	
						ctrl_TxtDiaVenc.IsUserValidated = false;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtValCartAtv -
				
				case event_val_TxtValCartAtv:
				{
					//InitEventCode event_val_TxtValCartAtv
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
					
					var_exchange.exec_bloq_empresa ( ctrl_TxtEmpresa.getTextBoxValue(), ref header );
					
					doEvent ( event_BuscaDados, null );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnDesbloqClick -
				
				case event_BtnDesbloqClick:
				{
					//InitEventCode event_BtnDesbloqClick
					
					var_exchange.exec_desbloq_empresa ( ctrl_TxtEmpresa.getTextBoxValue(), ref header );
					
					doEvent ( event_BuscaDados, null );
					
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
