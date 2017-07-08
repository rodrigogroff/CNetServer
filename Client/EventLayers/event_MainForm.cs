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
	public class event_MainForm : EventLayer
	{
		#region - EVENTS -
		public const int event_Start = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int event_FormIsClosing = 3;
		public const int event_NovoCartaoProprietario = 4;
		public const int robot_ShowDialog = 5;
		public const int robot_CloseDialog = 6;
		public const int event_Sair = 7;
		public const int event_TrocaSenha = 8;
		public const int event_Logoff = 9;
		public const int event_Login = 10;
		public const int event_CadastroUsuario = 11;
		public const int event_CadastroConvenio = 12;
		public const int event_ManutencaoConvenio = 13;
		public const int event_ManutencaoLoja = 14;
		public const int event_CadastroLoja = 15;
		public const int event_ManutencaoUsuario = 16;
		public const int event_Terminal = 17;
		public const int event_ManutTerminal = 18;
		public const int event_ConsultaLoja = 19;
		public const int event_ConsultaEmpresa = 20;
		public const int event_ConsultaAuditoria = 21;
		public const int event_LimitesCartao = 22;
		public const int event_ConsultaCartao = 23;
		public const int event_ConsultaTransacoes = 24;
		public const int event_GravaPendencia_PayFone = 25;
		public const int event_CancelaPendencia_PayFone = 26;
		public const int event_VerificaPendencia_PayFone = 27;
		public const int event_AutorizaVenda_PayFone = 28;
		public const int event_PF_CadastroCliente = 29;
		public const int event_PF_CadastroLojista = 30;
		public const int event_AlterarSenhaCartao = 31;
		public const int event_VendaEmpresarial = 32;
		public const int event_VendaEmpCancelamento = 33;
		public const int event_CancelaPend_PayFone = 34;
		public const int event_VisibleControl = 35;
		public const int event_VisibleControlBar = 36;
		public const int event_refresh_Screen = 37;
		public const int event_CancelaVendaPayFone = 38;
		public const int event_Relatorio = 39;
		public const int event_Agenda = 40;
		public const int event_ManutConvenios = 41;
		public const int event_Educacional = 42;
		public const int event_Bloqueio = 43;
		public const int event_Desbloqueio = 44;
		public const int event_HabilitarEdu = 45;
		public const int event_Expedicao = 46;
		public const int event_ConfCartao = 47;
		public const int event_EduCancelarCartao = 48;
		public const int event_EduSegundaVia = 49;
		public const int event_Admins = 50;
		public const int event_Faturamento = 51;
		public const int event_FatExtra = 52;
		public const int event_CancelaDespesa = 53;
		public const int event_SegundaVia = 54;
		public const int event_FatGerarArquivo = 55;
		public const int event_RecebeArqBanco = 56;
		public const int event_FatRel = 57;
		public const int event_DadosCadastraisProp = 58;
		public const int event_NovoChamado = 59;
		public const int event_PesquisaChamado = 60;
		public const int event_ProdutosExtrasGift = 61;
		public const int event_Quiosque = 62;
		public const int event_RecargaGift = 63;
		public const int event_ConsultaGift = 64;
		public const int event_CompensaChequeGift = 65;
		public const int event_ConfirmarRepasse = 66;
		public const int event_NovoDependente = 67;
		public const int event_ResPend = 68;
		public const int event_dlgFatRecManual = 69;
		public const int event_Lojista = 70;
		public const int event_VendaLojista = 71;
		public const int event_TarifasCliente = 72;
		public const int event_ReimpGift = 73;
		public const int event_Graficos = 74;
		public const int event_RemNovosCartoes = 75;
		public const int event_MensagensPais = 76;
		public const int event_TrocarSenhaToolStripMenuItemClick = 77;
		public const int event_SairToolStripMenuItemClick = 78;
		public const int event_ConsultaToolStripMenuItemClick = 79;
		public const int event_Menu_ConsultaGiftCardClick = 80;
		public const int event_CriarNovoToolStripMenuItemClick = 81;
		public const int event_Menu_NovoDependenteClick = 82;
		public const int event_ClienteToolStripMenuItemClick = 83;
		public const int event_LojistaToolStripMenuItemClick = 84;
		public const int event_DadosCadastraisToolStripMenuItemClick = 85;
		public const int event_AlterarLimitesToolStripMenuItemClick = 86;
		public const int event_AlterarSenhaToolStripMenuItemClick = 87;
		public const int event_ToolStripMenuItem1Click = 88;
		public const int event_DesbloqueioToolStripMenuItemClick = 89;
		public const int event_SegundaViaToolStripMenuItemClick = 90;
		public const int event_Menu_RecargaGiftClick = 91;
		public const int event_CadastroToolStripMenuItem3Click = 92;
		public const int event_ManutençãoToolStripMenuItem2Click = 93;
		public const int event_ConsultaToolStripMenuItem2Click = 94;
		public const int event_AdministradorasToolStripMenuItemClick = 95;
		public const int event_CadastroToolStripMenuItem2Click = 96;
		public const int event_ManutençãoToolStripMenuItem1Click = 97;
		public const int event_ConsultaToolStripMenuItem1Click = 98;
		public const int event_ConveniosToolStripMenuItemClick = 99;
		public const int event_CadastroToolStripMenuItem4Click = 100;
		public const int event_ManutençãoToolStripMenuItem3Click = 101;
		public const int event_CadastroToolStripMenuItem1Click = 102;
		public const int event_ManutençãoToolStripMenuItemClick = 103;
		public const int event_Menu_LojistasClick = 104;
		public const int event_ProdutosExtrasToolStripMenuItemClick = 105;
		public const int event_QuiosquesToolStripMenuItemClick = 106;
		public const int event_Menu_GraficosClick = 107;
		public const int event_RelatóriosToolStripMenuItem2Click = 108;
		public const int event_GravarPendênciaToolStripMenuItemClick = 109;
		public const int event_VerificaPendênciaToolStripMenuItemClick = 110;
		public const int event_CancelaPendênciaToolStripMenuItemClick = 111;
		public const int event_AutorizaVendaToolStripMenuItemClick = 112;
		public const int event_CancelaVendaToolStripMenuItemClick = 113;
		public const int event_EfetuaToolStripMenuItemClick = 114;
		public const int event_Menu_EfetuaVendaLojistaClick = 115;
		public const int event_CancelaToolStripMenuItemClick = 116;
		public const int event_ManutençãoToolStripMenuItem4Click = 117;
		public const int event_CancelarCartãoToolStripMenuItemClick = 118;
		public const int event_EmitirNovoCartãoToolStripMenuItemClick = 119;
		public const int event_PendenteToolStripMenuItemClick = 120;
		public const int event_FatcadastroToolStripMenuItem2Click = 121;
		public const int event_FatcancelamentoToolStripMenuItem1Click = 122;
		public const int event_GerarArquivoBancárioToolStripMenuItemClick = 123;
		public const int event_ReceberArquivoBancárioToolStripMenuItemClick = 124;
		public const int event_RelatóriosToolStripMenuItem1Click = 125;
		public const int event_Menu_Fat_RecManualClick = 126;
		public const int event_RelatórioDeTarifasAoClienteToolStripMenuItemClick = 127;
		public const int event_AgendamentoToolStripMenuItemClick = 128;
		public const int event_Menu_ExpediçãoClick = 129;
		public const int event_Menu_ConfirmarCartaoClick = 130;
		public const int event_HabilitarNovoCartãoToolStripMenuItemClick = 131;
		public const int event_Menu_ChequesGiftClick = 132;
		public const int event_ConfirmaçãoDeRepassesToolStripMenuItemClick = 133;
		public const int event_Menu_ResPendClick = 134;
		public const int event_Menu_ReimpGiftClick = 135;
		public const int event_Menu_RemNovosCartoesClick = 136;
		public const int event_RegistrosToolStripMenuItemClick = 137;
		public const int event_TransaçõesToolStripMenuItemClick = 138;
		public const int event_PesquisarToolStripMenuItemClick = 139;
		public const int event_NovoToolStripMenuItemClick = 140;
		public const int event_Menu_MensPaisClick = 141;
		public const int event_MainFormFormClosing = 142;
		public const int event_CotaExtraToolStripMenuItemClick = 143;
		#endregion

		public MainForm i_Form;

		//UserVariables
		
		public CNetHeader header = new CNetHeader();
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_MainForm ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new MainForm ( this );
		}
		
		public override bool doEvent ( int event_number, object arg )
		{
			switch ( event_number )
			{
				#region - event_Start -
				
				case event_Start:
				{
					//InitEventCode event_Start
					
					#if ROBOT
					#else
									
					doEvent ( event_Translate, 			null );
					doEvent ( event_FormIsOpening, 		null );
					
					if ( !doEvent ( event_Login, 		null ) )
					{
						var_exchange.m_Client.ExitSession();
						Application.ExitThread();
						
						return false;
					}
					
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
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_FormIsClosing -
				
				case event_FormIsClosing:
				{
					//InitEventCode event_FormIsClosing
										
					#if ROBOT
					#else
					
					doEvent ( event_Logoff, null );
					
					var_exchange.m_Client.ExitSession();
					
					#endif
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_NovoCartaoProprietario -
				
				case event_NovoCartaoProprietario:
				{
					//InitEventCode event_NovoCartaoProprietario
					
					event_dlgNovoCartao ev_call = new event_dlgNovoCartao ( var_util, var_exchange );
					
					ev_call.header = header;	
				
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - robot_ShowDialog -
				
				case robot_ShowDialog:
				{
					//InitEventCode robot_ShowDialog
					
					if ( i_Form.IsDisposed ) i_Form = new MainForm ( this );
					
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
				
				#region - event_Sair -
				
				case event_Sair:
				{
					//InitEventCode event_Sair
					
					i_Form.Close();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_TrocaSenha -
				
				case event_TrocaSenha:
				{
					//InitEventCode event_TrocaSenha
					
					event_dlgPassword ev_call = new event_dlgPassword ( var_util, var_exchange );
					
					ev_call.header = header;
										
					ev_call.i_Form.ShowDialog();
										
					if ( ev_call.var_IsCanceled )
						return false;
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Logoff -
				
				case event_Logoff:
				{
					//InitEventCode event_Logoff
					
					var_exchange.exec_logoff ( ref header );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Login -
				
				case event_Login:
				{
					//InitEventCode event_Login
					
					event_dlgLogin 	ev_call  = new event_dlgLogin ( var_util, var_exchange );
					
					ev_call.header = header;
					ev_call.i_Form.ShowDialog();
					
					if ( ev_call.var_IsCanceled )
						return false;
					
					if ( ev_call.var_IsChangePass == true )
					{
						if ( !doEvent ( event_TrocaSenha, null ) )
						{
							doEvent ( event_Logoff, null );
							return false;
						}
					}
					
					i_Form.LblNivel.Text = ev_call.var_st_nome + " - ";
					
					switch ( header.get_tg_user_type() )
					{
						case TipoUsuario.SuperUser: 		i_Form.LblNivel.Text += "Super Usuário";							break;
						case TipoUsuario.Administrador: 	i_Form.LblNivel.Text += "Administrador";							break;
						case TipoUsuario.Operador: 			i_Form.LblNivel.Text += "Operador";									break;
						case TipoUsuario.OperadorEdu: 		i_Form.LblNivel.Text += "Educacional";								break;
						case TipoUsuario.OperadorConvey: 	i_Form.LblNivel.Text += "Operador ConveyNET (Operacional)";			break;
						case TipoUsuario.OperadorCont:	 	i_Form.LblNivel.Text += "Operador ConveyNET (Contabilidade)";		break;
						case TipoUsuario.VendedorGift:	 	i_Form.LblNivel.Text += "Vendedor GiftCard";						break;
						case TipoUsuario.AdminGift:	 		i_Form.LblNivel.Text += "Administrador GiftCard | EduCard";			break;
						case TipoUsuario.Lojista:	 		i_Form.LblNivel.Text += "Lojista";									break;
					
						default: break;
					}
					
					if ( header.get_tg_user_type() == TipoUsuario.Operador )
					{
						i_Form.Menu_ResPend.Visible     	= false;	i_Form.Menu_ResPend.Text = "";
						i_Form.Menu_Cadastro.Visible     	= false;	i_Form.Menu_Cadastro.Text = "";
						i_Form.Menu_CriarPayFone.Visible 	= false;	i_Form.Menu_CriarPayFone.Text = "";
						i_Form.Menu_Agendamento.Visible  	= false;	i_Form.Menu_Agendamento.Text = "";
						i_Form.Menu_Educacional.Visible  	= false;	i_Form.Menu_Educacional.Text = "";
						i_Form.Menu_EduManut.Visible     	= false;	i_Form.Menu_EduManut.Text = "";
						i_Form.MenuAuditRegistros.Visible   = false;	i_Form.MenuAuditRegistros.Text = "";
						i_Form.Menu_Expedição.Visible    	= false;	i_Form.Menu_Expedição.Text = "";
						i_Form.Menu_ConfirmarCartao.Visible = false;	i_Form.Menu_ConfirmarCartao.Text = "";
						i_Form.Menu_Relatorios.Visible 		= false;	i_Form.Menu_Relatorios.Text = "";
						i_Form.MenuFaturamento.Visible 		= false;	i_Form.MenuFaturamento.Text = "";
						i_Form.Menu_PayFone.Visible 		= false;	i_Form.Menu_PayFone.Text = "";
						i_Form.Menu_VendaCartao.Visible 	= false;	i_Form.Menu_VendaCartao.Text = "";
						i_Form.MenuHelpDesk.Visible         = false;	i_Form.MenuHelpDesk.Text = "";
						i_Form.Menu_ProdExtra.Visible 		= false;	i_Form.Menu_ProdExtra.Text = "";
						i_Form.Menu_LibGift.Visible 		= false;	i_Form.Menu_LibGift.Text = "";
						i_Form.Menu_Quiosques.Visible 		= false;	i_Form.Menu_Quiosques.Text = "";
						i_Form.Menu_RecargaGift.Visible 	= false;	i_Form.Menu_RecargaGift.Text = "";
						i_Form.Menu_ChequesGift.Visible 	= false;	i_Form.Menu_ChequesGift.Text = "";
						i_Form.Menu_ConsultaGiftCard.Visible 	= false;	i_Form.Menu_ConsultaGiftCard.Text = "";
						i_Form.Menu_ConfRepasse.Visible 	= false;	i_Form.Menu_ConfRepasse.Text = "";						
						i_Form.MenuAlterarLimites.Visible 	= false;	i_Form.MenuAlterarLimites.Text = "";
						i_Form.Menu_Graficos.Visible 	= false;	i_Form.Menu_Graficos.Text = "";
						i_Form.Menu_RemNovosCartoes.Visible 	= false;	i_Form.Menu_RemNovosCartoes.Text = "";
						i_Form.cotaExtraToolStripMenuItem.Visible = false;
					}
					else if ( header.get_tg_user_type() == TipoUsuario.OperadorEdu )
					{
						i_Form.Menu_ResPend.Visible     	= false;	i_Form.Menu_ResPend.Text = "";
						i_Form.Menu_Cartoes.Visible     	= false;	i_Form.Menu_Cartoes.Text = "";
						i_Form.Menu_Cadastro.Visible     	= false;	i_Form.Menu_Cadastro.Text = "";
						i_Form.Menu_CriarPayFone.Visible 	= false;	i_Form.Menu_CriarPayFone.Text = "";
						i_Form.Menu_PayFone.Visible      	= false;	i_Form.Menu_PayFone.Text = "";
						i_Form.Menu_VendaCartao.Visible  	= false;	i_Form.Menu_VendaCartao.Text = "";
						i_Form.Menu_Agendamento.Visible  	= false;	i_Form.Menu_Agendamento.Text = "";
						i_Form.Menu_Auditoria.Visible    	= false;	i_Form.Menu_Auditoria.Text = "";
						i_Form.Menu_Expedição.Visible    	= false;	i_Form.Menu_Expedição.Text = "";
						i_Form.Menu_ConfirmarCartao.Visible = false;	i_Form.Menu_ConfirmarCartao.Text = "";
						i_Form.Menu_Relatorios.Visible 		= false;	i_Form.Menu_Relatorios.Text = "";
						i_Form.MenuFaturamento.Visible 		= false;	i_Form.MenuFaturamento.Text = "";
						i_Form.Menu_Auditoria.Visible  		= false;	i_Form.Menu_Auditoria.Text = "";
						i_Form.Menu_PayFone.Visible 		= false;	i_Form.Menu_PayFone.Text = "";
						i_Form.Menu_VendaCartao.Visible 	= false;	i_Form.Menu_VendaCartao.Text = "";
						i_Form.MenuHelpDesk.Visible         = false;	i_Form.MenuHelpDesk.Text = "";
						i_Form.Menu_ProdExtra.Visible       = false;	i_Form.Menu_ProdExtra.Text = "";
						i_Form.Menu_LibGift.Visible 		= false;	i_Form.Menu_LibGift.Text = "";
						i_Form.Menu_Quiosques.Visible 		= false;	i_Form.Menu_Quiosques.Text = "";
						i_Form.Menu_RecargaGift.Visible 	= false;	i_Form.Menu_RecargaGift.Text = "";
						i_Form.Menu_ConsultaGiftCard.Visible 	= false;	i_Form.Menu_ConsultaGiftCard.Text = "";
						i_Form.Menu_ChequesGift.Visible 	= false;	i_Form.Menu_ChequesGift.Text = "";
						i_Form.Menu_ConfRepasse.Visible 	= false;	i_Form.Menu_ConfRepasse.Text = "";
						i_Form.Menu_NovoDependente.Visible 	= false; i_Form.Menu_NovoDependente.Text = "";
						i_Form.MenuAlterarLimites.Visible 	= false;	i_Form.MenuAlterarLimites.Text = "";
						i_Form.Menu_Graficos.Visible 	= false;	i_Form.Menu_Graficos.Text = "";
						i_Form.Menu_ReimpGift.Visible       = false;	i_Form.Menu_ReimpGift.Text = "";
						i_Form.Menu_RemNovosCartoes.Visible 	= false;	i_Form.Menu_RemNovosCartoes.Text = "";
						i_Form.cotaExtraToolStripMenuItem.Visible = false;
					}
					else if ( header.get_tg_user_type() == TipoUsuario.Lojista )
					{
						i_Form.Menu_ResPend.Visible     	= false;	i_Form.Menu_ResPend.Text = "";
						i_Form.Menu_Cartoes.Visible     	= false;	i_Form.Menu_Cartoes.Text = "";
						i_Form.Menu_Cadastro.Visible     	= false;	i_Form.Menu_Cadastro.Text = "";
						i_Form.Menu_CriarPayFone.Visible 	= false;	i_Form.Menu_CriarPayFone.Text = "";
						i_Form.Menu_PayFone.Visible      	= false;	i_Form.Menu_PayFone.Text = "";
						i_Form.Menu_Agendamento.Visible  	= false;	i_Form.Menu_Agendamento.Text = "";
						i_Form.Menu_Auditoria.Visible    	= false;	i_Form.Menu_Auditoria.Text = "";
						i_Form.Menu_Expedição.Visible    	= false;	i_Form.Menu_Expedição.Text = "";
						i_Form.Menu_ConfirmarCartao.Visible = false;	i_Form.Menu_ConfirmarCartao.Text = "";
						i_Form.MenuFaturamento.Visible 		= false;	i_Form.MenuFaturamento.Text = "";
						i_Form.Menu_Auditoria.Visible  		= false;	i_Form.Menu_Auditoria.Text = "";
						i_Form.Menu_PayFone.Visible 		= false;	i_Form.Menu_PayFone.Text = "";
						i_Form.MenuHelpDesk.Visible         = false;	i_Form.MenuHelpDesk.Text = "";
						i_Form.Menu_ProdExtra.Visible       = false;	i_Form.Menu_ProdExtra.Text = "";
						i_Form.Menu_LibGift.Visible 		= false;	i_Form.Menu_LibGift.Text = "";
						i_Form.Menu_Quiosques.Visible 		= false;	i_Form.Menu_Quiosques.Text = "";
						i_Form.Menu_RecargaGift.Visible 	= false;	i_Form.Menu_RecargaGift.Text = "";
						i_Form.Menu_ConsultaGiftCard.Visible 	= false;	i_Form.Menu_ConsultaGiftCard.Text = "";
						i_Form.Menu_ChequesGift.Visible 	= false;	i_Form.Menu_ChequesGift.Text = "";
						i_Form.Menu_ConfRepasse.Visible 	= false;	i_Form.Menu_ConfRepasse.Text = "";
						i_Form.Menu_NovoDependente.Visible 	= false; i_Form.Menu_NovoDependente.Text = "";
						i_Form.MenuAlterarLimites.Visible 	= false;	i_Form.MenuAlterarLimites.Text = "";
						i_Form.Menu_Educacional.Visible  	= false;	i_Form.Menu_Educacional.Text = "";
						i_Form.Menu_HabilitarCartao.Visible = false;	i_Form.Menu_HabilitarCartao.Text = "";
						i_Form.Menu_Graficos.Visible 	= false;	i_Form.Menu_Graficos.Text = "";
						i_Form.Menu_EfetuaVenda.Visible = false;	i_Form.Menu_EfetuaVenda.Text = "";						
						i_Form.Menu_ReimpGift.Visible       = false;	i_Form.Menu_ReimpGift.Text = "";
						i_Form.Menu_Graficos.Visible 	= false;	i_Form.Menu_Graficos.Text = "";
						i_Form.Menu_RemNovosCartoes.Visible 	= false;	i_Form.Menu_RemNovosCartoes.Text = "";
						i_Form.cotaExtraToolStripMenuItem.Visible = false;
					}
					else if ( header.get_tg_user_type() == TipoUsuario.Administrador )
					{
						i_Form.Menu_LojCad.Visible          = false;	i_Form.Menu_LojCad.Text = "";
						i_Form.Menu_LojManut.Visible        = false;	i_Form.Menu_LojManut.Text = "";
						i_Form.Menu_LojConv.Visible         = false;	i_Form.Menu_LojConv.Text = "";
						i_Form.Menu_Terminais.Visible       = false;	i_Form.Menu_Terminais.Text = "";
						i_Form.Menu_Empresas.Visible        = false;	i_Form.Menu_Empresas.Text = "";
						i_Form.Menu_CriarPayFone.Visible 	= false;	i_Form.Menu_CriarPayFone.Text = "";
						i_Form.Menu_Agendamento.Visible  	= false;	i_Form.Menu_Agendamento.Text = "";
						i_Form.Menu_Educacional.Visible  	= false;	i_Form.Menu_Educacional.Text = "";
						i_Form.Menu_EduManut.Visible     	= false;	i_Form.Menu_EduManut.Text = "";
						i_Form.Menu_Expedição.Visible    	= false;	i_Form.Menu_Expedição.Text = "";
						i_Form.Menu_ConfirmarCartao.Visible = false;	i_Form.Menu_ConfirmarCartao.Text = "";
						i_Form.MenuFaturamento.Visible 		= false;	i_Form.MenuFaturamento.Text = "";
						i_Form.Menu_PayFone.Visible 		= false;	i_Form.Menu_PayFone.Text = "";
						i_Form.Menu_VendaCartao.Visible 	= false;	i_Form.Menu_VendaCartao.Text = "";
						i_Form.MenuHelpDesk.Visible         = false;	i_Form.MenuHelpDesk.Text = "";
						i_Form.Menu_ProdExtra.Visible       = false;	i_Form.Menu_ProdExtra.Text = "";
						i_Form.Menu_LibGift.Visible 		= false;	i_Form.Menu_LibGift.Text = "";
						i_Form.Menu_Quiosques.Visible 		= false;	i_Form.Menu_Quiosques.Text = "";
						i_Form.Menu_RecargaGift.Visible 	= false;	i_Form.Menu_RecargaGift.Text = "";
						i_Form.Menu_ConsultaGiftCard.Visible 	= false;	i_Form.Menu_ConsultaGiftCard.Text = "";
						i_Form.Menu_ChequesGift.Visible 	 = false;	i_Form.Menu_ChequesGift.Text = "";
						i_Form.Menu_ConfRepasse.Visible 	= false;	i_Form.Menu_ConfRepasse.Text = "";
						i_Form.Menu_ReimpGift.Visible       = false;	i_Form.Menu_ReimpGift.Text = "";
						i_Form.Menu_RemNovosCartoes.Visible 	= false;	i_Form.Menu_RemNovosCartoes.Text = "";
						
						
					}
					else if ( header.get_tg_user_type() == TipoUsuario.OperadorConvey )
					{
						
						i_Form.Menu_Usuarios.Visible 			= false;	i_Form.Menu_Usuarios.Text = "";
						i_Form.Menu_PayFone.Visible 			= false;	i_Form.Menu_PayFone.Text = "";
						i_Form.Menu_Educacional.Visible  		= false;	i_Form.Menu_Educacional.Text = "";
						i_Form.Menu_Agendamento.Visible  		= false;	i_Form.Menu_Agendamento.Text = "";
						i_Form.MenuGerarArquivoBan.Visible  	= false;	i_Form.MenuGerarArquivoBan.Text = "";
						i_Form.MenuReceberArquivoBan.Visible  	= false;	i_Form.MenuReceberArquivoBan.Text = "";
						i_Form.MenuRelatoriosFat.Visible  		= false;	i_Form.MenuRelatoriosFat.Text = "";
						i_Form.MenuConsPendFat.Visible  		= false;	i_Form.MenuConsPendFat.Text = "";
						i_Form.MenuAuditRegistros.Visible  		= false;	i_Form.MenuAuditRegistros.Text = "";
						i_Form.Menu_ProdExtra.Visible 			= false;	i_Form.Menu_ProdExtra.Text = "";
						i_Form.Menu_RecargaGift.Visible 		= false;	i_Form.Menu_RecargaGift.Text = "";
						i_Form.Menu_ConsultaGiftCard.Visible 	= false;	i_Form.Menu_ConsultaGiftCard.Text = "";
						i_Form.Menu_ChequesGift.Visible 	 	= false;	i_Form.Menu_ChequesGift.Text = "";
						i_Form.Menu_ConfRepasse.Visible 	= false;	i_Form.Menu_ConfRepasse.Text = "";
						i_Form.Menu_EfetuaVenda.Visible = false;	i_Form.Menu_EfetuaVenda.Text = "";
						i_Form.MenuAlterarLimites.Visible 	= false;	i_Form.MenuAlterarLimites.Text = "";
						i_Form.Menu_Graficos.Visible 	= false;	i_Form.Menu_Graficos.Text = "";
						i_Form.cotaExtraToolStripMenuItem.Visible = false;
					}
					else if ( header.get_tg_user_type() == TipoUsuario.OperadorCont )
					{
						i_Form.Menu_ResPend.Visible     	= false;	i_Form.Menu_ResPend.Text = "";
						i_Form.Menu_CriarPayFone.Visible 	= false;	i_Form.Menu_CriarPayFone.Text = "";
						i_Form.Menu_Educacional.Visible  	= false;	i_Form.Menu_Educacional.Text = "";
						i_Form.Menu_EduManut.Visible     	= false;	i_Form.Menu_EduManut.Text = "";
						i_Form.Menu_Expedição.Visible    	= false;	i_Form.Menu_Expedição.Text = "";
						i_Form.Menu_ConfirmarCartao.Visible = false;	i_Form.Menu_ConfirmarCartao.Text = "";
						i_Form.Menu_Auditoria.Visible  		= false;	i_Form.Menu_Auditoria.Text = "";
						i_Form.Menu_Cartoes.Visible 		= false;	i_Form.Menu_Cartoes.Text = "";
						i_Form.Menu_Usuarios.Visible        = false;	i_Form.Menu_Usuarios.Text = "";
						i_Form.Menu_HabilitarCartao.Visible = false;	i_Form.Menu_HabilitarCartao.Text = "";
						i_Form.Menu_PayFone.Visible 		= false;	i_Form.Menu_PayFone.Text = "";
						i_Form.Menu_VendaCartao.Visible 	= false;	i_Form.Menu_VendaCartao.Text = "";
						i_Form.Menu_ProdExtra.Visible 		= false;	i_Form.Menu_ProdExtra.Text = "";
						i_Form.Menu_Quiosques.Visible 		= false;	i_Form.Menu_Quiosques.Text = "";
						i_Form.Menu_RecargaGift.Visible 	= false;	i_Form.Menu_RecargaGift.Text = "";
						i_Form.Menu_ConsultaGiftCard.Visible 	= false;	i_Form.Menu_ConsultaGiftCard.Text = "";
						i_Form.Menu_ChequesGift.Visible 	 = false;	i_Form.Menu_ChequesGift.Text = "";
						i_Form.Menu_ConfRepasse.Visible 	= false;	i_Form.Menu_ConfRepasse.Text = "";
						i_Form.Menu_NovoDependente.Visible = false; i_Form.Menu_NovoDependente.Text = "";
						i_Form.MenuAlterarLimites.Visible 	= false;	i_Form.MenuAlterarLimites.Text = "";
						i_Form.Menu_Graficos.Visible 	= false;	i_Form.Menu_Graficos.Text = "";
						i_Form.Menu_Graficos.Visible 	= false;	i_Form.Menu_Graficos.Text = "";
						i_Form.cotaExtraToolStripMenuItem.Visible = false;
					}
					else if ( header.get_tg_user_type() == TipoUsuario.VendedorGift )
					{	
						i_Form.Menu_ResPend.Visible     	= false;	i_Form.Menu_ResPend.Text = "";
						i_Form.Menu_Cadastro.Visible     	 = false;	i_Form.Menu_Cadastro.Text = "";
						i_Form.Menu_CriarPayFone.Visible 	 = false;	i_Form.Menu_CriarPayFone.Text = "";
						i_Form.Menu_Agendamento.Visible  	 = false;	i_Form.Menu_Agendamento.Text = "";
						i_Form.Menu_Auditoria.Visible    	 = false;	i_Form.Menu_Auditoria.Text = "";
						i_Form.Menu_Educacional.Visible  	 = false;	i_Form.Menu_Educacional.Text = "";
						i_Form.Menu_EduManut.Visible     	 = false;	i_Form.Menu_EduManut.Text = "";
						i_Form.Menu_Expedição.Visible    	 = false;	i_Form.Menu_Expedição.Text = "";
						i_Form.Menu_ConfirmarCartao.Visible  = false;	i_Form.Menu_ConfirmarCartao.Text = "";
						i_Form.Menu_Relatorios.Visible 		 = false;	i_Form.Menu_Relatorios.Text = "";
						i_Form.MenuFaturamento.Visible 		 = false;	i_Form.MenuFaturamento.Text = "";
						i_Form.Menu_PayFone.Visible 		 = false;	i_Form.Menu_PayFone.Text = "";
						i_Form.MenuHelpDesk.Visible          = false;	i_Form.MenuHelpDesk.Text = "";
						i_Form.Menu_ConsultaCartao.Visible   = false;	i_Form.Menu_ConsultaCartao.Text = "";
						i_Form.Menu_DadosCadCartao.Visible   = false;	i_Form.Menu_DadosCadCartao.Text = "";
						i_Form.MenuAlterarLimites.Visible  	 = false;	i_Form.MenuAlterarLimites.Text = "";
						i_Form.Menu_AlterarSenha.Visible  	 = false;	i_Form.Menu_AlterarSenha.Text = "";
						i_Form.Menu_SegundaViaCartao.Visible = false;	i_Form.Menu_SegundaViaCartao.Text = "";
						i_Form.Menu_HabilitarCartao	.Visible = false;	i_Form.Menu_HabilitarCartao.Text = "";
						i_Form.Menu_Empresas.Visible 	 	 = false;	i_Form.Menu_Empresas.Text = "";
						i_Form.Menu_Lojas.Visible 	 	 	 = false;	i_Form.Menu_Lojas.Text = "";
						i_Form.Menu_Terminais.Visible 	 	 = false;	i_Form.Menu_Terminais.Text = "";
						i_Form.Menu_Usuarios.Visible 	 	 = false;	i_Form.Menu_Usuarios.Text = "";
						i_Form.Menu_Quiosques.Visible 		 = false;	i_Form.Menu_Quiosques.Text = "";
						i_Form.Menu_LibGift.Visible 	 	 = false;	i_Form.Menu_LibGift.Text = "";
						i_Form.Menu_ChequesGift.Visible 	 = false;	i_Form.Menu_ChequesGift.Text = "";
						i_Form.Menu_ConfRepasse.Visible 	= false;	i_Form.Menu_ConfRepasse.Text = "";
						i_Form.Menu_NovoDependente.Visible = false; i_Form.Menu_NovoDependente.Text = "";
						i_Form.Menu_Graficos.Visible 	= false;	i_Form.Menu_Graficos.Text = "";
						i_Form.Menu_EfetuaVendaLojista.Visible = false; i_Form.Menu_EfetuaVendaLojista.Text = "";
						i_Form.Menu_CriarNovo.Text = "Venda de Cartão GiftCard";
						i_Form.Menu_Graficos.Visible 	= false;	i_Form.Menu_Graficos.Text = "";
						i_Form.Menu_RemNovosCartoes.Visible 	= false;	i_Form.Menu_RemNovosCartoes.Text = "";
						i_Form.cotaExtraToolStripMenuItem.Visible = false;
					}
					else if ( header.get_tg_user_type() == TipoUsuario.AdminGift )
					{
						i_Form.Menu_CriarPayFone.Visible 	 = false;	i_Form.Menu_CriarPayFone.Text = "";
						i_Form.Menu_Agendamento.Visible  	 = false;	i_Form.Menu_Agendamento.Text = "";
						i_Form.Menu_Educacional.Visible  	 = false;	i_Form.Menu_Educacional.Text = "";
						i_Form.Menu_EduManut.Visible     	 = false;	i_Form.Menu_EduManut.Text = "";
						i_Form.Menu_Expedição.Visible    	 = false;	i_Form.Menu_Expedição.Text = "";
						i_Form.Menu_ConfirmarCartao.Visible  = false;	i_Form.Menu_ConfirmarCartao.Text = "";
						i_Form.MenuFaturamento.Visible 		 = false;	i_Form.MenuFaturamento.Text = "";
						i_Form.Menu_PayFone.Visible 		 = false;	i_Form.Menu_PayFone.Text = "";
						i_Form.MenuHelpDesk.Visible          = false;	i_Form.MenuHelpDesk.Text = "";
						i_Form.Menu_DadosCadCartao.Visible   = false;	i_Form.Menu_DadosCadCartao.Text = "";
						i_Form.MenuAlterarLimites.Visible  	 = false;	i_Form.MenuAlterarLimites.Text = "";
						i_Form.Menu_AlterarSenha.Visible  	 = false;	i_Form.Menu_AlterarSenha.Text = "";
						i_Form.Menu_SegundaViaCartao.Visible = false;	i_Form.Menu_SegundaViaCartao.Text = "";
						i_Form.Menu_HabilitarCartao	.Visible = false;	i_Form.Menu_HabilitarCartao.Text = "";
						i_Form.Menu_Empresas.Visible 	 	 = false;	i_Form.Menu_Empresas.Text = "";
						i_Form.Menu_LojCad.Visible 	 	     = false;	i_Form.Menu_LojCad.Text = "";
						i_Form.Menu_LojManut.Visible 	 	 = false;	i_Form.Menu_LojManut.Text = "";
						i_Form.Menu_LojConv.Visible 	 	 = false;	i_Form.Menu_LojConv.Text = "";
						i_Form.Menu_Terminais.Visible 	 	 = false;	i_Form.Menu_Terminais.Text = "";
						i_Form.Menu_LibGift.Visible 		 = false;	i_Form.Menu_LibGift.Text = "";
						i_Form.Menu_NovoDependente.Visible   = false; 	i_Form.Menu_NovoDependente.Text = "";
						i_Form.Menu_Transacoes.Visible 		 = false; 	i_Form.Menu_Transacoes.Text = "";
						i_Form.Menu_RemNovosCartoes.Visible 	= false;	i_Form.Menu_RemNovosCartoes.Text = "";
						i_Form.Menu_EfetuaVendaLojista.Visible = false; i_Form.Menu_EfetuaVendaLojista.Text = "";
						i_Form.Menu_CriarNovo.Text = "Venda de Cartão GiftCard";
						i_Form.cotaExtraToolStripMenuItem.Visible = false;
					}
										
					InstallData inst_data = new InstallData();
										
					i_Form.LblVersion.Text = inst_data.st_version;
					
					i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CadastroUsuario -
				
				case event_CadastroUsuario:
				{
					//InitEventCode event_CadastroUsuario
					
					event_dlgCadastroUsuario ev_call = new event_dlgCadastroUsuario ( var_util, var_exchange );
					
					ev_call.header    = header;
								
					ev_call.i_Form.ShowDialog();
										
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CadastroConvenio -
				
				case event_CadastroConvenio:
				{
					//InitEventCode event_CadastroConvenio
					
					event_dlgNovaEmpresa ev_call = new event_dlgNovaEmpresa ( var_util, var_exchange );
					
					ev_call.header = header;
							
					ev_call.i_Form.ShowDialog();
										
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ManutencaoConvenio -
				
				case event_ManutencaoConvenio:
				{
					//InitEventCode event_ManutencaoConvenio
					
					event_dlgNovaEmpresa ev_call = new event_dlgNovaEmpresa ( var_util, var_exchange );
					
					ev_call.header    		= header;
					ev_call.IsMaintenance 	= true;
											
					ev_call.i_Form.ShowDialog();
										
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ManutencaoLoja -
				
				case event_ManutencaoLoja:
				{
					//InitEventCode event_ManutencaoLoja
					
					event_dlgNovaLoja ev_call = new event_dlgNovaLoja ( var_util, var_exchange );
					
					ev_call.header    		= header;
					ev_call.IsMaintenance 	= true;
										
					ev_call.i_Form.ShowDialog();
										
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CadastroLoja -
				
				case event_CadastroLoja:
				{
					//InitEventCode event_CadastroLoja
					
					event_dlgNovaLoja ev_call = new event_dlgNovaLoja ( var_util, var_exchange );
					
					ev_call.header    		= header;
						
					ev_call.i_Form.ShowDialog();
										
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ManutencaoUsuario -
				
				case event_ManutencaoUsuario:
				{
					//InitEventCode event_ManutencaoUsuario
					
					event_dlgManutencaoUsuario ev_call = new event_dlgManutencaoUsuario ( var_util, var_exchange );
					
					ev_call.header = header;
											
					ev_call.i_Form.ShowDialog();
									
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Terminal -
				
				case event_Terminal:
				{
					//InitEventCode event_Terminal
					
					event_dlgNovoTerminal ev_call = new event_dlgNovoTerminal ( var_util, var_exchange );
					
					ev_call.header = header;
										
					ev_call.i_Form.ShowDialog();
										
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ManutTerminal -
				
				case event_ManutTerminal:
				{
					//InitEventCode event_ManutTerminal
					
					event_dlgManutencaoTerminal ev_call = new event_dlgManutencaoTerminal ( var_util, var_exchange );
					
					ev_call.header = header;
										
					ev_call.i_Form.ShowDialog();
										
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ConsultaLoja -
				
				case event_ConsultaLoja:
				{
					//InitEventCode event_ConsultaLoja
					
					event_dlgConsultaLoja ev_call = new event_dlgConsultaLoja ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
									
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ConsultaEmpresa -
				
				case event_ConsultaEmpresa:
				{
					//InitEventCode event_ConsultaEmpresa
					
					event_dlgConsultaEmpresa ev_call = new event_dlgConsultaEmpresa ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ConsultaAuditoria -
				
				case event_ConsultaAuditoria:
				{
					//InitEventCode event_ConsultaAuditoria
					
					event_dlgConsultaAuditoria ev_call = new event_dlgConsultaAuditoria ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_LimitesCartao -
				
				case event_LimitesCartao:
				{
					//InitEventCode event_LimitesCartao
					
					event_dlgLimiteCartao ev_call = new event_dlgLimiteCartao ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ConsultaCartao -
				
				case event_ConsultaCartao:
				{
					//InitEventCode event_ConsultaCartao
					
					event_dlgConsultaCartao ev_call = new event_dlgConsultaCartao ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ConsultaTransacoes -
				
				case event_ConsultaTransacoes:
				{
					//InitEventCode event_ConsultaTransacoes
					
					event_dlgConsultaTransacoes ev_call = new event_dlgConsultaTransacoes ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_GravaPendencia_PayFone -
				
				case event_GravaPendencia_PayFone:
				{
					//InitEventCode event_GravaPendencia_PayFone
					
					//event_dlgGravaPendenciaPayFone
					
					event_dlgGravaPendenciaPayFone ev_call = new event_dlgGravaPendenciaPayFone ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CancelaPendencia_PayFone -
				
				case event_CancelaPendencia_PayFone:
				{
					//InitEventCode event_CancelaPendencia_PayFone
					
					event_dlgCancelaPendenciaPayFone ev_call = new event_dlgCancelaPendenciaPayFone ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_VerificaPendencia_PayFone -
				
				case event_VerificaPendencia_PayFone:
				{
					//InitEventCode event_VerificaPendencia_PayFone
					
					event_dlgVerificaPendenciaPayFone ev_call = new event_dlgVerificaPendenciaPayFone ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_AutorizaVenda_PayFone -
				
				case event_AutorizaVenda_PayFone:
				{
					//InitEventCode event_AutorizaVenda_PayFone
					
					event_dlgAutorizaVendaPayFone ev_call = new event_dlgAutorizaVendaPayFone ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_PF_CadastroCliente -
				
				case event_PF_CadastroCliente:
				{
					//InitEventCode event_PF_CadastroCliente
					
					event_dlgPF_CadastroCliente ev_call = new event_dlgPF_CadastroCliente ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_PF_CadastroLojista -
				
				case event_PF_CadastroLojista:
				{
					//InitEventCode event_PF_CadastroLojista
					
					event_dlgPF_CadastroLojista ev_call = new event_dlgPF_CadastroLojista ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_AlterarSenhaCartao -
				
				case event_AlterarSenhaCartao:
				{
					//InitEventCode event_AlterarSenhaCartao
					
					event_dlgAlterarSenhaCartao ev_call = new event_dlgAlterarSenhaCartao ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_VendaEmpresarial -
				
				case event_VendaEmpresarial:
				{
					//InitEventCode event_VendaEmpresarial
					
					event_dlgVendaEmpresarial ev_call = new event_dlgVendaEmpresarial ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_VendaEmpCancelamento -
				
				case event_VendaEmpCancelamento:
				{
					//InitEventCode event_VendaEmpCancelamento
					
					event_dlgVendaEmpresarialCancelamento ev_call = new event_dlgVendaEmpresarialCancelamento ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CancelaPend_PayFone -
				
				case event_CancelaPend_PayFone:
				{
					//InitEventCode event_CancelaPend_PayFone
					
					event_dlgCancelaPendenciaPayFone ev_call = new event_dlgCancelaPendenciaPayFone ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_VisibleControl -
				
				case event_VisibleControl:
				{
					//InitEventCode event_VisibleControl
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_VisibleControlBar -
				
				case event_VisibleControlBar:
				{
					//InitEventCode event_VisibleControlBar
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_refresh_Screen -
				
				case event_refresh_Screen:
				{
					//InitEventCode event_refresh_Screen
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CancelaVendaPayFone -
				
				case event_CancelaVendaPayFone:
				{
					//InitEventCode event_CancelaVendaPayFone
					
					event_dlgCancelaVendaPayFone ev_call = new event_dlgCancelaVendaPayFone ( var_util, var_exchange );
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Relatorio -
				
				case event_Relatorio:
				{
					//InitEventCode event_Relatorio
					
					event_dlgRelatorios ev_call = new event_dlgRelatorios ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Agenda -
				
				case event_Agenda:
				{
					//InitEventCode event_Agenda
					
					event_dlgAgendamento ev_call = new event_dlgAgendamento ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ManutConvenios -
				
				case event_ManutConvenios:
				{
					//InitEventCode event_ManutConvenios
					
					event_dlgConvenios ev_call = new event_dlgConvenios ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Educacional -
				
				case event_Educacional:
				{
					//InitEventCode event_Educacional
					
					event_dlgEducacional ev_call = new event_dlgEducacional ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Bloqueio -
				
				case event_Bloqueio:
				{
					//InitEventCode event_Bloqueio
					
					event_dlgBloqueio ev_call = new event_dlgBloqueio ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Desbloqueio -
				
				case event_Desbloqueio:
				{
					//InitEventCode event_Desbloqueio
					
					event_dlgDesbloqueio ev_call = new event_dlgDesbloqueio ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_HabilitarEdu -
				
				case event_HabilitarEdu:
				{
					//InitEventCode event_HabilitarEdu
					
					event_dlgHabilitarCartao ev_call = new event_dlgHabilitarCartao ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Expedicao -
				
				case event_Expedicao:
				{
					//InitEventCode event_Expedicao
					
					event_dlgExpedicao ev_call = new event_dlgExpedicao ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();					
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ConfCartao -
				
				case event_ConfCartao:
				{
					//InitEventCode event_ConfCartao
					
					event_dlgConfCartao ev_call = new event_dlgConfCartao ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();			
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_EduCancelarCartao -
				
				case event_EduCancelarCartao:
				{
					//InitEventCode event_EduCancelarCartao
					
					event_dlgEduCancelarCartao ev_call = new event_dlgEduCancelarCartao ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();	
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_EduSegundaVia -
				
				case event_EduSegundaVia:
				{
					//InitEventCode event_EduSegundaVia
					
					event_dlgEduSegundaVia ev_call = new event_dlgEduSegundaVia ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();	
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Admins -
				
				case event_Admins:
				{
					//InitEventCode event_Admins
					
					event_dlgAdminEmpresas ev_call = new event_dlgAdminEmpresas ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();	
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Faturamento -
				
				case event_Faturamento:
				{
					//InitEventCode event_Faturamento
					
					event_dlgFaturamento ev_call = new event_dlgFaturamento ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();	
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_FatExtra -
				
				case event_FatExtra:
				{
					//InitEventCode event_FatExtra
					
					event_dlgFatExtra ev_call = new event_dlgFatExtra ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();	
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CancelaDespesa -
				
				case event_CancelaDespesa:
				{
					//InitEventCode event_CancelaDespesa
					
					event_dlgCancelaDespesa ev_call = new event_dlgCancelaDespesa ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();	
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_SegundaVia -
				
				case event_SegundaVia:
				{
					//InitEventCode event_SegundaVia
					
					event_dlgSegundaVia ev_call = new event_dlgSegundaVia ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();	
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_FatGerarArquivo -
				
				case event_FatGerarArquivo:
				{
					//InitEventCode event_FatGerarArquivo
					
					event_dlgFatGerarArquivo ev_call = new event_dlgFatGerarArquivo ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();	
										
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_RecebeArqBanco -
				
				case event_RecebeArqBanco:
				{
					//InitEventCode event_RecebeArqBanco
					
					event_dlgRecebeArqBanco ev_call = new event_dlgRecebeArqBanco ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();	
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_FatRel -
				
				case event_FatRel:
				{
					//InitEventCode event_FatRel
					
					event_dlgFatRel ev_call = new event_dlgFatRel ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();	
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_DadosCadastraisProp -
				
				case event_DadosCadastraisProp:
				{
					//InitEventCode event_DadosCadastraisProp
					
					event_dlgDadosCadastrais ev_call = new event_dlgDadosCadastrais ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();	
										
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_NovoChamado -
				
				case event_NovoChamado:
				{
					//InitEventCode event_NovoChamado
					
					event_dlgNovoChamado ev_call = new event_dlgNovoChamado ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();	
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_PesquisaChamado -
				
				case event_PesquisaChamado:
				{
					//InitEventCode event_PesquisaChamado
					
					event_dlgPesquisaChamado ev_call = new event_dlgPesquisaChamado ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();	
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ProdutosExtrasGift -
				
				case event_ProdutosExtrasGift:
				{
					//InitEventCode event_ProdutosExtrasGift
					
					event_dlgExtrasGift ev_call = new event_dlgExtrasGift ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();	
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Quiosque -
				
				case event_Quiosque:
				{
					//InitEventCode event_Quiosque
					
					event_dlgQuiosque ev_call = new event_dlgQuiosque ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();	
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_RecargaGift -
				
				case event_RecargaGift:
				{
					//InitEventCode event_RecargaGift
					
					event_dlgRecargaGift ev_call = new event_dlgRecargaGift ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();	
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ConsultaGift -
				
				case event_ConsultaGift:
				{
					//InitEventCode event_ConsultaGift
					
					event_dlgConsultaGift ev_call = new event_dlgConsultaGift ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();	
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CompensaChequeGift -
				
				case event_CompensaChequeGift:
				{
					//InitEventCode event_CompensaChequeGift
					
					event_dlgCompensaCheque ev_call = new event_dlgCompensaCheque ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();	
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ConfirmarRepasse -
				
				case event_ConfirmarRepasse:
				{
					//InitEventCode event_ConfirmarRepasse
					
					event_dlgConfirmarRepasse ev_call = new event_dlgConfirmarRepasse ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_NovoDependente -
				
				case event_NovoDependente:
				{
					//InitEventCode event_NovoDependente
					
					event_dlgNovoDependente ev_call = new event_dlgNovoDependente ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ResPend -
				
				case event_ResPend:
				{
					//InitEventCode event_ResPend
					
					event_dlgResPend ev_call = new event_dlgResPend ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_dlgFatRecManual -
				
				case event_dlgFatRecManual:
				{
					//InitEventCode event_dlgFatRecManual
					
					event_dlgFatRecManual ev_call = new event_dlgFatRecManual ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Lojista -
				
				case event_Lojista:
				{
					//InitEventCode event_Lojista
					
					event_dlgLojista ev_call = new event_dlgLojista ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_VendaLojista -
				
				case event_VendaLojista:
				{
					//InitEventCode event_VendaLojista
					
					event_dlgVendaLojista ev_call = new event_dlgVendaLojista ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_TarifasCliente -
				
				case event_TarifasCliente:
				{
					//InitEventCode event_TarifasCliente
					
					// ##############################
					// # SETUP LISTS ################
					// ##############################
					
					ArrayList lstHeader 	= new ArrayList();
					ArrayList lstContent 	= new ArrayList();
					ArrayList lstTableSizes = new ArrayList();
					ArrayList lstFooter 	= new ArrayList();
					ArrayList lstMessages 	= new ArrayList();
					ArrayList lstFilters 	= new ArrayList();
					
					// ##############################
					// # CUSTOMIZE
					// ##############################
					
					dlgStatus stat = new dlgStatus ( "Relatório" );
					
					stat.LblActivity.Text = "Processando relatório no servidor";
					stat.Show();
					Application.DoEvents();
					
					string st_csv_content = "";
					string st_emp_content = "";
									
					if ( !var_exchange.fetch_rel_tarifas (	ref header,
										                 	ref st_csv_content,
										                    ref st_emp_content ) )
                 	{
						stat.Close();
						return false;                 		
                 	}
					
					stat.LblActivity.Text = "Buscando detalhes de faturamento";
					Application.DoEvents();
					
					ArrayList full_memory = new ArrayList();
												
					while ( st_csv_content != "" )
					{
						ArrayList tmp_memory = new ArrayList();
						
						if ( var_exchange.fetch_memory ( st_csv_content, "200", 
						                                 ref st_csv_content, 
						                                 ref tmp_memory ) )
						{
							for ( int t=0; t < tmp_memory.Count; ++t )
							{
								full_memory.Add ( tmp_memory[t] as DataPortable );
							}
						}
					}

					ArrayList full_memory_emp = new ArrayList();
					
					while ( st_emp_content != "" )
					{
						ArrayList tmp_memory = new ArrayList();
						
						if ( var_exchange.fetch_memory ( st_emp_content, "200", 
						                                 ref st_emp_content, 
						                                 ref tmp_memory ) )
						{
							for ( int t=0; t < tmp_memory.Count; ++t )
							{
								full_memory_emp.Add ( tmp_memory[t] as DataPortable );
							}
						}
					}
					
					stat.LblActivity.Text = "Gerando relatório para web";
					Application.DoEvents();
					
					stat.pgStatus.Maximum = full_memory_emp.Count;
					stat.pgStatus.Minimum = 0;
														
					money money_helper = new money();
									
					// Sub-título
					lstMessages.Add   ( "Relação de tarifas" );
					lstTableSizes.Add ( 900 );
					
					ArrayList lst_sub_tbl_head = new ArrayList();
					
					lst_sub_tbl_head.Add ( "Empresa" 	);
					lst_sub_tbl_head.Add ( "TBM" 		);
					lst_sub_tbl_head.Add ( "Pct Trans" 	);
					lst_sub_tbl_head.Add ( "Vr Trans" 	);
					lst_sub_tbl_head.Add ( "Vr Min" 	);
					lst_sub_tbl_head.Add ( "Franquia" 	);
					lst_sub_tbl_head.Add ( "Por Cartão" );
					lst_sub_tbl_head.Add ( "Isento" 	);
					lst_sub_tbl_head.Add ( "Situação" 	);
					
					lstHeader.Add ( lst_sub_tbl_head );
					
					ArrayList my_line_container = new ArrayList();
					
					long tot_tbm = 0, tot_ativas = 0, tot_bloq = 0, tot_canc = 0, tot_isentas = 0;
										
					// Passa por todas as empresas e lojas
					for ( int g=0; g < full_memory_emp.Count; ++g )
					{
						stat.pgStatus.Value = g + 1;
						Application.DoEvents();	
					
						DadosEmpresa emp = new DadosEmpresa ( full_memory_emp [g] as DataPortable );
						
						for ( int t=0; t < full_memory.Count; ++t )
						{
							Rel_Tarifas r_t = new Rel_Tarifas ( full_memory [t] as DataPortable );
							
							if ( r_t.get_st_emp() != emp.get_st_fantasia() )
								continue;					
							
							ArrayList lst_sub_content = new ArrayList();
							
							++t;
							
							lst_sub_content.Add ( r_t.getValue ( "st_val" ) );
							
							for (int h=1; h <= 8; ++h, ++t )
							{
								Rel_Tarifas r_t2 = new Rel_Tarifas ( full_memory [t] as DataPortable );
								
								string my_val = r_t2.getValue ( "st_val" );
								
								if ( h== 1)
								{
									tot_tbm += money_helper.getNumericValue ( my_val );
								}
								
								if ( h == 7 )
								{
									if ( my_val.StartsWith ( "S" ) )	tot_isentas++;
								}
								
								if ( h == 8 )
								{
									if ( my_val.StartsWith ( "A" ) )	tot_ativas++;
									if ( my_val.StartsWith ( "B" ) )	tot_bloq++;
									if ( my_val.StartsWith ( "C" ) )	tot_canc++;
								}
								
								lst_sub_content.Add ( my_val );
							}
							
							my_line_container.Add ( lst_sub_content );
						}	
					}
					
					lstContent.Add ( my_line_container );
					
					ArrayList lstFoot = new ArrayList();
						
					lstFoot.Add ( "Total TBM: R$ " + money_helper.setMoneyFormat ( tot_tbm ) );
					lstFoot.Add ( "" );
					lstFoot.Add ( "Total de empresas isentas: " + tot_isentas.ToString() );
					lstFoot.Add ( "" );
					lstFoot.Add ( "Total de empresas ativas: " + tot_ativas.ToString() );
					lstFoot.Add ( "Total de empresas bloqueadas: " + tot_bloq.ToString() );
					lstFoot.Add ( "Total de empresas canceladas: " + tot_canc.ToString() );
					
					lstFooter.Add ( lstFoot );
					
					stat.Close();
										
					SyCrafReport rel = new SyCrafReport ( 	"Relatório de tarifas ao cliente",
					                               		  	"RFTC", 
					                               		  	"Todas as lojas e empresas do faturamento",
					                               		  	var_util.GetDataBaseTimeFormat ( DateTime.Now ),
					                               		  	"",
						                               		ref lstHeader,
						                               		ref lstContent,
						                                	ref lstTableSizes,
						                                	ref lstFooter,
						                                	ref lstMessages,
						                                	ref lstFilters );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ReimpGift -
				
				case event_ReimpGift:
				{
					//InitEventCode event_ReimpGift
					
					event_dlgReimpGift ev_call = new event_dlgReimpGift ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Graficos -
				
				case event_Graficos:
				{
					//InitEventCode event_Graficos
					
					event_dlgGraficosEmp ev_call = new event_dlgGraficosEmp ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_RemNovosCartoes -
				
				case event_RemNovosCartoes:
				{
					//InitEventCode event_RemNovosCartoes
					
					event_dlgRemessa ev_call = new event_dlgRemessa ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_MensagensPais -
				
				case event_MensagensPais:
				{
					//InitEventCode event_MensagensPais
					
					event_dlgMensagensEdu ev_call = new event_dlgMensagensEdu ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_TrocarSenhaToolStripMenuItemClick -
				
				case event_TrocarSenhaToolStripMenuItemClick:
				{
					//InitEventCode event_TrocarSenhaToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_SairToolStripMenuItemClick -
				
				case event_SairToolStripMenuItemClick:
				{
					//InitEventCode event_SairToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ConsultaToolStripMenuItemClick -
				
				case event_ConsultaToolStripMenuItemClick:
				{
					//InitEventCode event_ConsultaToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Menu_ConsultaGiftCardClick -
				
				case event_Menu_ConsultaGiftCardClick:
				{
					//InitEventCode event_Menu_ConsultaGiftCardClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CriarNovoToolStripMenuItemClick -
				
				case event_CriarNovoToolStripMenuItemClick:
				{
					//InitEventCode event_CriarNovoToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Menu_NovoDependenteClick -
				
				case event_Menu_NovoDependenteClick:
				{
					//InitEventCode event_Menu_NovoDependenteClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ClienteToolStripMenuItemClick -
				
				case event_ClienteToolStripMenuItemClick:
				{
					//InitEventCode event_ClienteToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_LojistaToolStripMenuItemClick -
				
				case event_LojistaToolStripMenuItemClick:
				{
					//InitEventCode event_LojistaToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_DadosCadastraisToolStripMenuItemClick -
				
				case event_DadosCadastraisToolStripMenuItemClick:
				{
					//InitEventCode event_DadosCadastraisToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_AlterarLimitesToolStripMenuItemClick -
				
				case event_AlterarLimitesToolStripMenuItemClick:
				{
					//InitEventCode event_AlterarLimitesToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_AlterarSenhaToolStripMenuItemClick -
				
				case event_AlterarSenhaToolStripMenuItemClick:
				{
					//InitEventCode event_AlterarSenhaToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ToolStripMenuItem1Click -
				
				case event_ToolStripMenuItem1Click:
				{
					//InitEventCode event_ToolStripMenuItem1Click
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_DesbloqueioToolStripMenuItemClick -
				
				case event_DesbloqueioToolStripMenuItemClick:
				{
					//InitEventCode event_DesbloqueioToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_SegundaViaToolStripMenuItemClick -
				
				case event_SegundaViaToolStripMenuItemClick:
				{
					//InitEventCode event_SegundaViaToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Menu_RecargaGiftClick -
				
				case event_Menu_RecargaGiftClick:
				{
					//InitEventCode event_Menu_RecargaGiftClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CadastroToolStripMenuItem3Click -
				
				case event_CadastroToolStripMenuItem3Click:
				{
					//InitEventCode event_CadastroToolStripMenuItem3Click
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ManutençãoToolStripMenuItem2Click -
				
				case event_ManutençãoToolStripMenuItem2Click:
				{
					//InitEventCode event_ManutençãoToolStripMenuItem2Click
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ConsultaToolStripMenuItem2Click -
				
				case event_ConsultaToolStripMenuItem2Click:
				{
					//InitEventCode event_ConsultaToolStripMenuItem2Click
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_AdministradorasToolStripMenuItemClick -
				
				case event_AdministradorasToolStripMenuItemClick:
				{
					//InitEventCode event_AdministradorasToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CadastroToolStripMenuItem2Click -
				
				case event_CadastroToolStripMenuItem2Click:
				{
					//InitEventCode event_CadastroToolStripMenuItem2Click
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ManutençãoToolStripMenuItem1Click -
				
				case event_ManutençãoToolStripMenuItem1Click:
				{
					//InitEventCode event_ManutençãoToolStripMenuItem1Click
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ConsultaToolStripMenuItem1Click -
				
				case event_ConsultaToolStripMenuItem1Click:
				{
					//InitEventCode event_ConsultaToolStripMenuItem1Click
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ConveniosToolStripMenuItemClick -
				
				case event_ConveniosToolStripMenuItemClick:
				{
					//InitEventCode event_ConveniosToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CadastroToolStripMenuItem4Click -
				
				case event_CadastroToolStripMenuItem4Click:
				{
					//InitEventCode event_CadastroToolStripMenuItem4Click
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ManutençãoToolStripMenuItem3Click -
				
				case event_ManutençãoToolStripMenuItem3Click:
				{
					//InitEventCode event_ManutençãoToolStripMenuItem3Click
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CadastroToolStripMenuItem1Click -
				
				case event_CadastroToolStripMenuItem1Click:
				{
					//InitEventCode event_CadastroToolStripMenuItem1Click
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ManutençãoToolStripMenuItemClick -
				
				case event_ManutençãoToolStripMenuItemClick:
				{
					//InitEventCode event_ManutençãoToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Menu_LojistasClick -
				
				case event_Menu_LojistasClick:
				{
					//InitEventCode event_Menu_LojistasClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ProdutosExtrasToolStripMenuItemClick -
				
				case event_ProdutosExtrasToolStripMenuItemClick:
				{
					//InitEventCode event_ProdutosExtrasToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_QuiosquesToolStripMenuItemClick -
				
				case event_QuiosquesToolStripMenuItemClick:
				{
					//InitEventCode event_QuiosquesToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Menu_GraficosClick -
				
				case event_Menu_GraficosClick:
				{
					//InitEventCode event_Menu_GraficosClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_RelatóriosToolStripMenuItem2Click -
				
				case event_RelatóriosToolStripMenuItem2Click:
				{
					//InitEventCode event_RelatóriosToolStripMenuItem2Click
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_GravarPendênciaToolStripMenuItemClick -
				
				case event_GravarPendênciaToolStripMenuItemClick:
				{
					//InitEventCode event_GravarPendênciaToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_VerificaPendênciaToolStripMenuItemClick -
				
				case event_VerificaPendênciaToolStripMenuItemClick:
				{
					//InitEventCode event_VerificaPendênciaToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CancelaPendênciaToolStripMenuItemClick -
				
				case event_CancelaPendênciaToolStripMenuItemClick:
				{
					//InitEventCode event_CancelaPendênciaToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_AutorizaVendaToolStripMenuItemClick -
				
				case event_AutorizaVendaToolStripMenuItemClick:
				{
					//InitEventCode event_AutorizaVendaToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CancelaVendaToolStripMenuItemClick -
				
				case event_CancelaVendaToolStripMenuItemClick:
				{
					//InitEventCode event_CancelaVendaToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_EfetuaToolStripMenuItemClick -
				
				case event_EfetuaToolStripMenuItemClick:
				{
					//InitEventCode event_EfetuaToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Menu_EfetuaVendaLojistaClick -
				
				case event_Menu_EfetuaVendaLojistaClick:
				{
					//InitEventCode event_Menu_EfetuaVendaLojistaClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CancelaToolStripMenuItemClick -
				
				case event_CancelaToolStripMenuItemClick:
				{
					//InitEventCode event_CancelaToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ManutençãoToolStripMenuItem4Click -
				
				case event_ManutençãoToolStripMenuItem4Click:
				{
					//InitEventCode event_ManutençãoToolStripMenuItem4Click
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CancelarCartãoToolStripMenuItemClick -
				
				case event_CancelarCartãoToolStripMenuItemClick:
				{
					//InitEventCode event_CancelarCartãoToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_EmitirNovoCartãoToolStripMenuItemClick -
				
				case event_EmitirNovoCartãoToolStripMenuItemClick:
				{
					//InitEventCode event_EmitirNovoCartãoToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_PendenteToolStripMenuItemClick -
				
				case event_PendenteToolStripMenuItemClick:
				{
					//InitEventCode event_PendenteToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_FatcadastroToolStripMenuItem2Click -
				
				case event_FatcadastroToolStripMenuItem2Click:
				{
					//InitEventCode event_FatcadastroToolStripMenuItem2Click
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_FatcancelamentoToolStripMenuItem1Click -
				
				case event_FatcancelamentoToolStripMenuItem1Click:
				{
					//InitEventCode event_FatcancelamentoToolStripMenuItem1Click
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_GerarArquivoBancárioToolStripMenuItemClick -
				
				case event_GerarArquivoBancárioToolStripMenuItemClick:
				{
					//InitEventCode event_GerarArquivoBancárioToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ReceberArquivoBancárioToolStripMenuItemClick -
				
				case event_ReceberArquivoBancárioToolStripMenuItemClick:
				{
					//InitEventCode event_ReceberArquivoBancárioToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_RelatóriosToolStripMenuItem1Click -
				
				case event_RelatóriosToolStripMenuItem1Click:
				{
					//InitEventCode event_RelatóriosToolStripMenuItem1Click
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Menu_Fat_RecManualClick -
				
				case event_Menu_Fat_RecManualClick:
				{
					//InitEventCode event_Menu_Fat_RecManualClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_RelatórioDeTarifasAoClienteToolStripMenuItemClick -
				
				case event_RelatórioDeTarifasAoClienteToolStripMenuItemClick:
				{
					//InitEventCode event_RelatórioDeTarifasAoClienteToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_AgendamentoToolStripMenuItemClick -
				
				case event_AgendamentoToolStripMenuItemClick:
				{
					//InitEventCode event_AgendamentoToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Menu_ExpediçãoClick -
				
				case event_Menu_ExpediçãoClick:
				{
					//InitEventCode event_Menu_ExpediçãoClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Menu_ConfirmarCartaoClick -
				
				case event_Menu_ConfirmarCartaoClick:
				{
					//InitEventCode event_Menu_ConfirmarCartaoClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_HabilitarNovoCartãoToolStripMenuItemClick -
				
				case event_HabilitarNovoCartãoToolStripMenuItemClick:
				{
					//InitEventCode event_HabilitarNovoCartãoToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Menu_ChequesGiftClick -
				
				case event_Menu_ChequesGiftClick:
				{
					//InitEventCode event_Menu_ChequesGiftClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ConfirmaçãoDeRepassesToolStripMenuItemClick -
				
				case event_ConfirmaçãoDeRepassesToolStripMenuItemClick:
				{
					//InitEventCode event_ConfirmaçãoDeRepassesToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Menu_ResPendClick -
				
				case event_Menu_ResPendClick:
				{
					//InitEventCode event_Menu_ResPendClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Menu_ReimpGiftClick -
				
				case event_Menu_ReimpGiftClick:
				{
					//InitEventCode event_Menu_ReimpGiftClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Menu_RemNovosCartoesClick -
				
				case event_Menu_RemNovosCartoesClick:
				{
					//InitEventCode event_Menu_RemNovosCartoesClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_RegistrosToolStripMenuItemClick -
				
				case event_RegistrosToolStripMenuItemClick:
				{
					//InitEventCode event_RegistrosToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_TransaçõesToolStripMenuItemClick -
				
				case event_TransaçõesToolStripMenuItemClick:
				{
					//InitEventCode event_TransaçõesToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_PesquisarToolStripMenuItemClick -
				
				case event_PesquisarToolStripMenuItemClick:
				{
					//InitEventCode event_PesquisarToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_NovoToolStripMenuItemClick -
				
				case event_NovoToolStripMenuItemClick:
				{
					//InitEventCode event_NovoToolStripMenuItemClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Menu_MensPaisClick -
				
				case event_Menu_MensPaisClick:
				{
					//InitEventCode event_Menu_MensPaisClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_MainFormFormClosing -
				
				case event_MainFormFormClosing:
				{
					//InitEventCode event_MainFormFormClosing
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CotaExtraToolStripMenuItemClick -
				
				case event_CotaExtraToolStripMenuItemClick:
				{
					//InitEventCode event_CotaExtraToolStripMenuItemClick
					
					event_dlgCotaExtra ev_call = new event_dlgCotaExtra ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();	
					
					
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
