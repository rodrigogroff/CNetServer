﻿// ###################################################### 
// ## SyCraf Engine Codegen                          #### 
// ###################################################### 
// ## This file is entirely written by               #### 
// ## the construction bot. DO NOT EDIT THIS FILE.   #### 
// ###################################################### 

using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public class RobotEngine : Infra_RobotEngine
	{		
		public Exchange var_exchange;
		public ApplicationUtil var_util;
		
		public void execJob ( string label, ref ListBox cmds, int timeout, bool update )
		{
			RobotJob job = config.getJob ( label );
			var_util.var_robot = job;
			
			if ( job != null )
			{
				job.run ( ref hsh_layers, ref hsh_layers_events, ref cmds, timeout, update );
			}
			else
			{
				MessageBox.Show ( "Unknown Job!", "Error" );
			}
		}
		
		public RobotEngine ( ApplicationUtil util, Exchange ex )
		{
			var_exchange = ex;
			var_util = util;
			
			#if ROBOT
			
			event_dlgRemessa tmp_event_dlgRemessa = new event_dlgRemessa ( util, ex );
			tmp_event_dlgRemessa.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgRemessa" ] = tmp_event_dlgRemessa;
			
			event_dlgGraficosEmp tmp_event_dlgGraficosEmp = new event_dlgGraficosEmp ( util, ex );
			tmp_event_dlgGraficosEmp.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgGraficosEmp" ] = tmp_event_dlgGraficosEmp;
			
			event_dlgDBF_Fechamento tmp_event_dlgDBF_Fechamento = new event_dlgDBF_Fechamento ( util, ex );
			tmp_event_dlgDBF_Fechamento.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgDBF_Fechamento" ] = tmp_event_dlgDBF_Fechamento;
			
			event_dlgReimpGift tmp_event_dlgReimpGift = new event_dlgReimpGift ( util, ex );
			tmp_event_dlgReimpGift.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgReimpGift" ] = tmp_event_dlgReimpGift;
			
			event_dlgObservacao tmp_event_dlgObservacao = new event_dlgObservacao ( util, ex );
			tmp_event_dlgObservacao.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgObservacao" ] = tmp_event_dlgObservacao;
			
			event_dlgPrevLojista tmp_event_dlgPrevLojista = new event_dlgPrevLojista ( util, ex );
			tmp_event_dlgPrevLojista.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgPrevLojista" ] = tmp_event_dlgPrevLojista;
			
			event_dlgVendaParcelada tmp_event_dlgVendaParcelada = new event_dlgVendaParcelada ( util, ex );
			tmp_event_dlgVendaParcelada.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgVendaParcelada" ] = tmp_event_dlgVendaParcelada;
			
			event_dlgVendaLojista tmp_event_dlgVendaLojista = new event_dlgVendaLojista ( util, ex );
			tmp_event_dlgVendaLojista.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgVendaLojista" ] = tmp_event_dlgVendaLojista;
			
			event_dlgLojista tmp_event_dlgLojista = new event_dlgLojista ( util, ex );
			tmp_event_dlgLojista.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgLojista" ] = tmp_event_dlgLojista;
			
			event_dlgFatRecManual tmp_event_dlgFatRecManual = new event_dlgFatRecManual ( util, ex );
			tmp_event_dlgFatRecManual.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgFatRecManual" ] = tmp_event_dlgFatRecManual;
			
			event_dlgResPend tmp_event_dlgResPend = new event_dlgResPend ( util, ex );
			tmp_event_dlgResPend.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgResPend" ] = tmp_event_dlgResPend;
			
			event_dlgNovoDependente tmp_event_dlgNovoDependente = new event_dlgNovoDependente ( util, ex );
			tmp_event_dlgNovoDependente.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgNovoDependente" ] = tmp_event_dlgNovoDependente;
			
			event_dlgUpdate tmp_event_dlgUpdate = new event_dlgUpdate ( util, ex );
			tmp_event_dlgUpdate.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgUpdate" ] = tmp_event_dlgUpdate;
			
			event_dlgConfFinalRepasse tmp_event_dlgConfFinalRepasse = new event_dlgConfFinalRepasse ( util, ex );
			tmp_event_dlgConfFinalRepasse.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgConfFinalRepasse" ] = tmp_event_dlgConfFinalRepasse;
			
			event_dlgConfirmarRepasse tmp_event_dlgConfirmarRepasse = new event_dlgConfirmarRepasse ( util, ex );
			tmp_event_dlgConfirmarRepasse.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgConfirmarRepasse" ] = tmp_event_dlgConfirmarRepasse;
			
			event_dlgCompensaCheque tmp_event_dlgCompensaCheque = new event_dlgCompensaCheque ( util, ex );
			tmp_event_dlgCompensaCheque.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgCompensaCheque" ] = tmp_event_dlgCompensaCheque;
			
			event_dlgConsultaGift tmp_event_dlgConsultaGift = new event_dlgConsultaGift ( util, ex );
			tmp_event_dlgConsultaGift.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgConsultaGift" ] = tmp_event_dlgConsultaGift;
			
			event_dlgRecargaGift tmp_event_dlgRecargaGift = new event_dlgRecargaGift ( util, ex );
			tmp_event_dlgRecargaGift.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgRecargaGift" ] = tmp_event_dlgRecargaGift;
			
			event_dlgFinalGift tmp_event_dlgFinalGift = new event_dlgFinalGift ( util, ex );
			tmp_event_dlgFinalGift.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgFinalGift" ] = tmp_event_dlgFinalGift;
			
			event_dlgQuiosque tmp_event_dlgQuiosque = new event_dlgQuiosque ( util, ex );
			tmp_event_dlgQuiosque.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgQuiosque" ] = tmp_event_dlgQuiosque;
			
			event_dlgConfGiftCard tmp_event_dlgConfGiftCard = new event_dlgConfGiftCard ( util, ex );
			tmp_event_dlgConfGiftCard.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgConfGiftCard" ] = tmp_event_dlgConfGiftCard;
			
			event_dlgExtrasGift tmp_event_dlgExtrasGift = new event_dlgExtrasGift ( util, ex );
			tmp_event_dlgExtrasGift.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgExtrasGift" ] = tmp_event_dlgExtrasGift;
			
			event_dlgCustoChamado tmp_event_dlgCustoChamado = new event_dlgCustoChamado ( util, ex );
			tmp_event_dlgCustoChamado.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgCustoChamado" ] = tmp_event_dlgCustoChamado;
			
			event_dlgEditaChamado tmp_event_dlgEditaChamado = new event_dlgEditaChamado ( util, ex );
			tmp_event_dlgEditaChamado.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgEditaChamado" ] = tmp_event_dlgEditaChamado;
			
			event_dlgPesquisaChamado tmp_event_dlgPesquisaChamado = new event_dlgPesquisaChamado ( util, ex );
			tmp_event_dlgPesquisaChamado.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgPesquisaChamado" ] = tmp_event_dlgPesquisaChamado;
			
			event_dlgNovoChamado tmp_event_dlgNovoChamado = new event_dlgNovoChamado ( util, ex );
			tmp_event_dlgNovoChamado.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgNovoChamado" ] = tmp_event_dlgNovoChamado;
			
			event_dlgDadosCadastrais tmp_event_dlgDadosCadastrais = new event_dlgDadosCadastrais ( util, ex );
			tmp_event_dlgDadosCadastrais.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgDadosCadastrais" ] = tmp_event_dlgDadosCadastrais;
			
			event_dlgFatRel tmp_event_dlgFatRel = new event_dlgFatRel ( util, ex );
			tmp_event_dlgFatRel.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgFatRel" ] = tmp_event_dlgFatRel;
			
			event_dlgRecebeArqBanco tmp_event_dlgRecebeArqBanco = new event_dlgRecebeArqBanco ( util, ex );
			tmp_event_dlgRecebeArqBanco.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgRecebeArqBanco" ] = tmp_event_dlgRecebeArqBanco;
			
			event_dlgFatGerarArquivo tmp_event_dlgFatGerarArquivo = new event_dlgFatGerarArquivo ( util, ex );
			tmp_event_dlgFatGerarArquivo.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgFatGerarArquivo" ] = tmp_event_dlgFatGerarArquivo;
			
			event_dlgSegundaVia tmp_event_dlgSegundaVia = new event_dlgSegundaVia ( util, ex );
			tmp_event_dlgSegundaVia.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgSegundaVia" ] = tmp_event_dlgSegundaVia;
			
			event_dlgCancelaDespesa tmp_event_dlgCancelaDespesa = new event_dlgCancelaDespesa ( util, ex );
			tmp_event_dlgCancelaDespesa.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgCancelaDespesa" ] = tmp_event_dlgCancelaDespesa;
			
			event_dlgFatExtra tmp_event_dlgFatExtra = new event_dlgFatExtra ( util, ex );
			tmp_event_dlgFatExtra.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgFatExtra" ] = tmp_event_dlgFatExtra;
			
			event_dlgFaturamento tmp_event_dlgFaturamento = new event_dlgFaturamento ( util, ex );
			tmp_event_dlgFaturamento.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgFaturamento" ] = tmp_event_dlgFaturamento;
			
			event_dlgAdminEmpresas tmp_event_dlgAdminEmpresas = new event_dlgAdminEmpresas ( util, ex );
			tmp_event_dlgAdminEmpresas.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgAdminEmpresas" ] = tmp_event_dlgAdminEmpresas;
			
			event_dlgEduSegundaVia tmp_event_dlgEduSegundaVia = new event_dlgEduSegundaVia ( util, ex );
			tmp_event_dlgEduSegundaVia.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgEduSegundaVia" ] = tmp_event_dlgEduSegundaVia;
			
			event_dlgEduCancelarCartao tmp_event_dlgEduCancelarCartao = new event_dlgEduCancelarCartao ( util, ex );
			tmp_event_dlgEduCancelarCartao.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgEduCancelarCartao" ] = tmp_event_dlgEduCancelarCartao;
			
			event_dlgConfCartao tmp_event_dlgConfCartao = new event_dlgConfCartao ( util, ex );
			tmp_event_dlgConfCartao.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgConfCartao" ] = tmp_event_dlgConfCartao;
			
			event_dlgExpedicao tmp_event_dlgExpedicao = new event_dlgExpedicao ( util, ex );
			tmp_event_dlgExpedicao.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgExpedicao" ] = tmp_event_dlgExpedicao;
			
			event_dlgHabilitarCartao tmp_event_dlgHabilitarCartao = new event_dlgHabilitarCartao ( util, ex );
			tmp_event_dlgHabilitarCartao.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgHabilitarCartao" ] = tmp_event_dlgHabilitarCartao;
			
			event_dlgDesbloqueio tmp_event_dlgDesbloqueio = new event_dlgDesbloqueio ( util, ex );
			tmp_event_dlgDesbloqueio.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgDesbloqueio" ] = tmp_event_dlgDesbloqueio;
			
			event_dlgBloqueio tmp_event_dlgBloqueio = new event_dlgBloqueio ( util, ex );
			tmp_event_dlgBloqueio.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgBloqueio" ] = tmp_event_dlgBloqueio;
			
			event_dlgEducacional tmp_event_dlgEducacional = new event_dlgEducacional ( util, ex );
			tmp_event_dlgEducacional.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgEducacional" ] = tmp_event_dlgEducacional;
			
			event_dlgFechamento tmp_event_dlgFechamento = new event_dlgFechamento ( util, ex );
			tmp_event_dlgFechamento.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgFechamento" ] = tmp_event_dlgFechamento;
			
			event_dlgCadastroAtividade tmp_event_dlgCadastroAtividade = new event_dlgCadastroAtividade ( util, ex );
			tmp_event_dlgCadastroAtividade.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgCadastroAtividade" ] = tmp_event_dlgCadastroAtividade;
			
			event_dlgAgendamento tmp_event_dlgAgendamento = new event_dlgAgendamento ( util, ex );
			tmp_event_dlgAgendamento.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgAgendamento" ] = tmp_event_dlgAgendamento;
			
			event_dlgRelatorios tmp_event_dlgRelatorios = new event_dlgRelatorios ( util, ex );
			tmp_event_dlgRelatorios.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgRelatorios" ] = tmp_event_dlgRelatorios;
			
			event_dlgCancelaVendaPayFone tmp_event_dlgCancelaVendaPayFone = new event_dlgCancelaVendaPayFone ( util, ex );
			tmp_event_dlgCancelaVendaPayFone.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgCancelaVendaPayFone" ] = tmp_event_dlgCancelaVendaPayFone;
			
			event_dlgVendaEmpresarialCancelamento tmp_event_dlgVendaEmpresarialCancelamento = new event_dlgVendaEmpresarialCancelamento ( util, ex );
			tmp_event_dlgVendaEmpresarialCancelamento.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgVendaEmpresarialCancelamento" ] = tmp_event_dlgVendaEmpresarialCancelamento;
			
			event_dlgSelecionaTerminal tmp_event_dlgSelecionaTerminal = new event_dlgSelecionaTerminal ( util, ex );
			tmp_event_dlgSelecionaTerminal.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgSelecionaTerminal" ] = tmp_event_dlgSelecionaTerminal;
			
			event_dlgVendaEmpresarial tmp_event_dlgVendaEmpresarial = new event_dlgVendaEmpresarial ( util, ex );
			tmp_event_dlgVendaEmpresarial.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgVendaEmpresarial" ] = tmp_event_dlgVendaEmpresarial;
			
			event_dlgAlterarSenhaCartao tmp_event_dlgAlterarSenhaCartao = new event_dlgAlterarSenhaCartao ( util, ex );
			tmp_event_dlgAlterarSenhaCartao.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgAlterarSenhaCartao" ] = tmp_event_dlgAlterarSenhaCartao;
			
			event_dlgPF_CadastroLojista tmp_event_dlgPF_CadastroLojista = new event_dlgPF_CadastroLojista ( util, ex );
			tmp_event_dlgPF_CadastroLojista.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgPF_CadastroLojista" ] = tmp_event_dlgPF_CadastroLojista;
			
			event_dlgPF_CadastroCliente tmp_event_dlgPF_CadastroCliente = new event_dlgPF_CadastroCliente ( util, ex );
			tmp_event_dlgPF_CadastroCliente.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgPF_CadastroCliente" ] = tmp_event_dlgPF_CadastroCliente;
			
			event_dlgAutorizaVendaPayFone tmp_event_dlgAutorizaVendaPayFone = new event_dlgAutorizaVendaPayFone ( util, ex );
			tmp_event_dlgAutorizaVendaPayFone.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgAutorizaVendaPayFone" ] = tmp_event_dlgAutorizaVendaPayFone;
			
			event_dlgVerificaPendenciaPayFone tmp_event_dlgVerificaPendenciaPayFone = new event_dlgVerificaPendenciaPayFone ( util, ex );
			tmp_event_dlgVerificaPendenciaPayFone.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgVerificaPendenciaPayFone" ] = tmp_event_dlgVerificaPendenciaPayFone;
			
			event_dlgCancelaPendenciaPayFone tmp_event_dlgCancelaPendenciaPayFone = new event_dlgCancelaPendenciaPayFone ( util, ex );
			tmp_event_dlgCancelaPendenciaPayFone.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgCancelaPendenciaPayFone" ] = tmp_event_dlgCancelaPendenciaPayFone;
			
			event_dlgGravaPendenciaPayFone tmp_event_dlgGravaPendenciaPayFone = new event_dlgGravaPendenciaPayFone ( util, ex );
			tmp_event_dlgGravaPendenciaPayFone.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgGravaPendenciaPayFone" ] = tmp_event_dlgGravaPendenciaPayFone;
			
			event_dlgConsultaTransacoes tmp_event_dlgConsultaTransacoes = new event_dlgConsultaTransacoes ( util, ex );
			tmp_event_dlgConsultaTransacoes.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgConsultaTransacoes" ] = tmp_event_dlgConsultaTransacoes;
			
			event_dlgConsultaCartao tmp_event_dlgConsultaCartao = new event_dlgConsultaCartao ( util, ex );
			tmp_event_dlgConsultaCartao.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgConsultaCartao" ] = tmp_event_dlgConsultaCartao;
			
			event_dlgLimiteCartao tmp_event_dlgLimiteCartao = new event_dlgLimiteCartao ( util, ex );
			tmp_event_dlgLimiteCartao.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgLimiteCartao" ] = tmp_event_dlgLimiteCartao;
			
			event_dlgLocalizacao tmp_event_dlgLocalizacao = new event_dlgLocalizacao ( util, ex );
			tmp_event_dlgLocalizacao.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgLocalizacao" ] = tmp_event_dlgLocalizacao;
			
			event_dlgConsultaAuditoria tmp_event_dlgConsultaAuditoria = new event_dlgConsultaAuditoria ( util, ex );
			tmp_event_dlgConsultaAuditoria.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgConsultaAuditoria" ] = tmp_event_dlgConsultaAuditoria;
			
			event_dlgConsultaEmpresa tmp_event_dlgConsultaEmpresa = new event_dlgConsultaEmpresa ( util, ex );
			tmp_event_dlgConsultaEmpresa.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgConsultaEmpresa" ] = tmp_event_dlgConsultaEmpresa;
			
			event_dlgConsultaLoja tmp_event_dlgConsultaLoja = new event_dlgConsultaLoja ( util, ex );
			tmp_event_dlgConsultaLoja.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgConsultaLoja" ] = tmp_event_dlgConsultaLoja;
			
			event_dlgConvenios tmp_event_dlgConvenios = new event_dlgConvenios ( util, ex );
			tmp_event_dlgConvenios.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgConvenios" ] = tmp_event_dlgConvenios;
			
			event_dlgManutencaoTerminal tmp_event_dlgManutencaoTerminal = new event_dlgManutencaoTerminal ( util, ex );
			tmp_event_dlgManutencaoTerminal.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgManutencaoTerminal" ] = tmp_event_dlgManutencaoTerminal;
			
			event_dlgSelecionaEmpresa tmp_event_dlgSelecionaEmpresa = new event_dlgSelecionaEmpresa ( util, ex );
			tmp_event_dlgSelecionaEmpresa.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgSelecionaEmpresa" ] = tmp_event_dlgSelecionaEmpresa;
			
			event_dlgNovoTerminal tmp_event_dlgNovoTerminal = new event_dlgNovoTerminal ( util, ex );
			tmp_event_dlgNovoTerminal.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgNovoTerminal" ] = tmp_event_dlgNovoTerminal;
			
			event_dlgManutencaoUsuario tmp_event_dlgManutencaoUsuario = new event_dlgManutencaoUsuario ( util, ex );
			tmp_event_dlgManutencaoUsuario.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgManutencaoUsuario" ] = tmp_event_dlgManutencaoUsuario;
			
			event_dlgNovaLoja tmp_event_dlgNovaLoja = new event_dlgNovaLoja ( util, ex );
			tmp_event_dlgNovaLoja.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgNovaLoja" ] = tmp_event_dlgNovaLoja;
			
			event_dlgNovaEmpresa tmp_event_dlgNovaEmpresa = new event_dlgNovaEmpresa ( util, ex );
			tmp_event_dlgNovaEmpresa.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgNovaEmpresa" ] = tmp_event_dlgNovaEmpresa;
			
			event_dlgCadastroUsuario tmp_event_dlgCadastroUsuario = new event_dlgCadastroUsuario ( util, ex );
			tmp_event_dlgCadastroUsuario.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgCadastroUsuario" ] = tmp_event_dlgCadastroUsuario;
			
			event_dlgPassword tmp_event_dlgPassword = new event_dlgPassword ( util, ex );
			tmp_event_dlgPassword.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgPassword" ] = tmp_event_dlgPassword;
			
			event_dlgLogin tmp_event_dlgLogin = new event_dlgLogin ( util, ex );
			tmp_event_dlgLogin.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgLogin" ] = tmp_event_dlgLogin;
			
			event_dlgNovoCartao tmp_event_dlgNovoCartao = new event_dlgNovoCartao ( util, ex );
			tmp_event_dlgNovoCartao.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "dlgNovoCartao" ] = tmp_event_dlgNovoCartao;
			
			event_MainForm tmp_event_MainForm = new event_MainForm ( util, ex );
			tmp_event_MainForm.mapEvents ( ref lst_layers, ref hsh_layers_events );
			hsh_layers [ "MainForm" ] = tmp_event_MainForm;
			
			Load();
			
			#endif
		}
	}
}