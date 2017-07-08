﻿// ###################################################### 
// ## SyCraf Engine Codegen                          #### 
// ###################################################### 
// ## This file is entirely written by               #### 
// ## the construction bot. DO NOT EDIT THIS FILE.   #### 
// ###################################################### 

using System;
using System.Collections;

namespace SyCrafEngine
{
	public class Context
	{
		public const string TRUE = "1";
		public const string FALSE = "0";
		public const string NOT_SET = "0";
		public const string EMPTY = "";
		public const string OPEN = "0";
		public const string CLOSED = "1";
		public const string NONE = "0";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  TRUE,
													FALSE,
													NOT_SET,
													EMPTY,
													OPEN,
													CLOSED,
													NONE } );
		}
	}
	
	public class Language
	{
		public const string English = "0";
		public const string Portuguese = "1";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  English,
													Portuguese } );
		}
	}
	
	public class LanguageDesc
	{
		public const string English = "LanguageDesc.English";
		public const string Portuguese = "LanguageDesc.Portuguese";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  English,
													Portuguese } );
		}
	}
	
	public class InfraSoftwareClient
	{
		public const string nameClient = "ConveyNet";
		public const string pathDir = "pathDir";
		public const string maxPacket = "maxPacket";
		public const string clientServerPort = "clientServerPort";
		public const string serverMachine = "serverMachine";
		public const string upgradePath = "upgradePath";
		public const string language = "language";
		public const string lastUser = "lastUser";
		public const string app = "app";
		public const string serverStandby = "serverStandby";
		public const string serverStandByPort = "serverStandByPort";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  nameClient,
													pathDir,
													maxPacket,
													clientServerPort,
													serverMachine,
													upgradePath,
													language,
													lastUser,
													app,
													serverStandby,
													serverStandByPort } );
		}
	}
	
	public class CartaoStatus
	{
		public const string Habilitado = "0";
		public const string Bloqueado = "1";
		public const string EmDesativacao = "2";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  Habilitado,
													Bloqueado,
													EmDesativacao } );
		}
	}
	
	public class CartaoMotivoBloqueio
	{
		public const string Expirado = "0";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] { Expirado } );
		}
	}
	
	public class Erro
	{
		public const string Generico = "Falha geral de processo";
		public const string NovoCartao = "Falha na criação de novo cartão";
		public const string CartaoExiste = "Cartão já foi cadastrado";
		public const string RendaSupZero = "O valor de renda deve ser superior a zero";
		public const string ProfissaoInexistente = "Profissão inexistente";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  Generico,
													NovoCartao,
													CartaoExiste,
													RendaSupZero,
													ProfissaoInexistente } );
		}
	}
	
	public class TipoUsuario
	{
		public const string SuperUser = "0";
		public const string Administrador = "1";
		public const string Operador = "2";
		public const string OperadorEdu = "3";
		public const string OperadorCont = "4";
		public const string OperadorConvey = "5";
		public const string VendedorGift = "6";
		public const string AdminGift = "7";
		public const string Lojista = "8";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  SuperUser,
													Administrador,
													Operador,
													OperadorEdu,
													OperadorCont,
													OperadorConvey,
													VendedorGift,
													AdminGift,
													Lojista } );
		}
	}
	
	public class AlteraUsuario
	{
		public const string Bloqueio = "0";
		public const string Desbloqueio = "1";
		public const string TrocaSenha = "2";
		public const string Remover = "3";
		public const string ResetSenha = "4";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  Bloqueio,
													Desbloqueio,
													TrocaSenha,
													Remover,
													ResetSenha } );
		}
	}
	
	public class TipoOperacao
	{
		public const string CadNovoOper = "1";
		public const string AlterOper = "2";
		public const string CadEmpresa = "3";
		public const string AlterEmpresa = "4";
		public const string CadLoja = "5";
		public const string AlterLoja = "6";
		public const string CadTerminal = "7";
		public const string AlterTerminal = "8";
		public const string CadCartao = "9";
		public const string TrocaSenha = "10";
		public const string RemoverTerminal = "11";
		public const string Login = "12";
		public const string Logoff = "13";
		public const string AlterCartao = "14";
		public const string AlterSenha = "15";
		public const string CadPayFoneCliente = "16";
		public const string CadPayFoneLojista = "17";
		public const string NovaAgenda = "18";
		public const string RemAgenda = "19";
		public const string AlterEduDiario = "20";
		public const string CadDespesa = "21";
		public const string RemDespesa = "22";
		public const string RemProdGift = "23";
		public const string RemQuiosqueGift = "24";
		public const string AlterChamConvey = "25";
		public const string AltDadosPropCart = "26";
		public const string CancChequeGift = "27";
		public const string CancCadEmpresa = "28";
		public const string CompChequeGift = "29";
		public const string ConfCartConv = "30";
		public const string ProcArqBanConvey = "31";
		public const string RecargaGift = "32";
		public const string RepasseLojaGift = "33";
		public const string ReqSegViaCart = "34";
		public const string VincVendQuiosque = "35";
		public const string CadChamadoConvey = "36";
		public const string CadDepenCart = "37";
		public const string CadProdExtraGift = "38";
		public const string CadNovoQuiosque = "39";
		public const string GeraArqGrafica = "40";
		public const string BloqueioCartao = "41";
		public const string DesbloqueioCartao = "42";
		public const string BloqueioLoja = "43";
		public const string DesbloqueioLoja = "44";
		public const string CancelLoja = "45";
		public const string RemoveConvenio = "46";
		public const string ResolvePend = "47";
		public const string CancelamentoCartao = "48";
		public const string VendaGift = "49";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  CadNovoOper,
													AlterOper,
													CadEmpresa,
													AlterEmpresa,
													CadLoja,
													AlterLoja,
													CadTerminal,
													AlterTerminal,
													CadCartao,
													TrocaSenha,
													RemoverTerminal,
													Login,
													Logoff,
													AlterCartao,
													AlterSenha,
													CadPayFoneCliente,
													CadPayFoneLojista,
													NovaAgenda,
													RemAgenda,
													AlterEduDiario,
													CadDespesa,
													RemDespesa,
													RemProdGift,
													RemQuiosqueGift,
													AlterChamConvey,
													AltDadosPropCart,
													CancChequeGift,
													CancCadEmpresa,
													CompChequeGift,
													ConfCartConv,
													ProcArqBanConvey,
													RecargaGift,
													RepasseLojaGift,
													ReqSegViaCart,
													VincVendQuiosque,
													CadChamadoConvey,
													CadDepenCart,
													CadProdExtraGift,
													CadNovoQuiosque,
													GeraArqGrafica,
													BloqueioCartao,
													DesbloqueioCartao,
													BloqueioLoja,
													DesbloqueioLoja,
													CancelLoja,
													RemoveConvenio,
													ResolvePend,
													CancelamentoCartao,
													VendaGift } );
		}
	}
	
	public class TipoOperacaoDesc
	{
		public const string CadNovoOper = "Cadstramento de Operador";
		public const string AlterOper = "Manutenção de Operador";
		public const string CadEmpresa = "Cadastramento de Empresa";
		public const string AlterEmpresa = "Manutenção de Empresa";
		public const string CadLoja = "Cadastramento de Loja";
		public const string AlterLoja = "Manutenção de Loja";
		public const string CadTerminal = "Cadastramento de Terminal";
		public const string AlterTerminal = "Manutenção de Terminal";
		public const string CadCartao = "Cadastramento de Cartão";
		public const string TrocaSenha = "Troca de Senha";
		public const string RemoverTerminal = "Remoção de Terminal";
		public const string Login = "Login de Usuário";
		public const string Logoff = "Logoff de Usuário";
		public const string AlterCartao = "Alteração de Cartão";
		public const string AlterSenha = "Altera Senha de usuário de cartão";
		public const string CadPayFoneCliente = "Cadastro de Pay Fone para cliente";
		public const string CadPayFoneLojista = "Cadastro de pay Fone para lojista";
		public const string NovaAgenda = "Novo agendamento de tarefa";
		public const string RemAgenda = "Remoção de agendamento de tarefa";
		public const string AlterEduDiario = "Alteração de limite diário educacional";
		public const string CadDespesa = "Cadastramento de despesa";
		public const string RemDespesa = "Cancelamento de despesa";
		public const string RemProdGift = "Remoção de produto gift";
		public const string RemQuiosqueGift = "Remoção de quiosque gift";
		public const string AlterChamConvey = "Alteração de chamado conveynet";
		public const string AltDadosPropCart = "Alteração de dados cadastrais de prop. cartão";
		public const string CancChequeGift = "Cancelamento de cheque gift";
		public const string CancCadEmpresa = "Cancela cadastro de empresa";
		public const string CompChequeGift = "Compensação de cheque gift";
		public const string ConfCartConv = "Confirmação de cartão convênio";
		public const string ProcArqBanConvey = "Processamento de arquivo bancário";
		public const string RecargaGift = "Recarga de cartão gift";
		public const string RepasseLojaGift = "Repasse de loja gift";
		public const string ReqSegViaCart = "Requerimento de segunda via de cartão";
		public const string VincVendQuiosque = "Vinculação de vendedor para quiosque";
		public const string CadChamadoConvey = "Cadastro de chamado";
		public const string CadDepenCart = "Criação de dependente de cartão";
		public const string CadProdExtraGift = "Cadastro de produto extra gift";
		public const string CadNovoQuiosque = "Cadastro de novo quiosque";
		public const string GeraArqGrafica = "Gera arquivo de cartões para gráfica";
		public const string BloqueioCartao = "Bloqueio de cartão";
		public const string DesbloqueioCartao = "Desbloqueio de cartão";
		public const string BloqueioLoja = "Bloqueio de Loja";
		public const string DesbloqueioLoja = "Desbloqueio de Loja";
		public const string CancelLoja = "Cancelamento de contrato de loja";
		public const string RemoveConvenio = "Remoção de convênio";
		public const string ResolvePend = "Resolução de pendências";
		public const string CancelamentoCartao = "Cancelamento de Cartão";
		public const string VendaGift = "Venda pelo quiosque";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  CadNovoOper,
													AlterOper,
													CadEmpresa,
													AlterEmpresa,
													CadLoja,
													AlterLoja,
													CadTerminal,
													AlterTerminal,
													CadCartao,
													TrocaSenha,
													RemoverTerminal,
													Login,
													Logoff,
													AlterCartao,
													AlterSenha,
													CadPayFoneCliente,
													CadPayFoneLojista,
													NovaAgenda,
													RemAgenda,
													AlterEduDiario,
													CadDespesa,
													RemDespesa,
													RemProdGift,
													RemQuiosqueGift,
													AlterChamConvey,
													AltDadosPropCart,
													CancChequeGift,
													CancCadEmpresa,
													CompChequeGift,
													ConfCartConv,
													ProcArqBanConvey,
													RecargaGift,
													RepasseLojaGift,
													ReqSegViaCart,
													VincVendQuiosque,
													CadChamadoConvey,
													CadDepenCart,
													CadProdExtraGift,
													CadNovoQuiosque,
													GeraArqGrafica,
													BloqueioCartao,
													DesbloqueioCartao,
													BloqueioLoja,
													DesbloqueioLoja,
													CancelLoja,
													RemoveConvenio,
													ResolvePend,
													CancelamentoCartao,
													VendaGift } );
		}
	}
	
	public class Scheduler
	{
		public const string Specific = "0";
		public const string Daily = "1";
		public const string Weekly = "2";
		public const string Monthly = "3";
		public const string Minute = "4";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  Specific,
													Daily,
													Weekly,
													Monthly,
													Minute } );
		}
	}
	
	public class TipoParcela
	{
		public const string EM_ABERTO = "0";
		public const string QUITADO = "1";
		public const string CONTESTADO = "2";
		public const string CANCELADA = "3";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  EM_ABERTO,
													QUITADO,
													CONTESTADO,
													CANCELADA } );
		}
	}
	
	public class OperacaoCartao
	{
		public const string VENDA_EMPRESARIAL = "0";
		public const string CONF_VENDA_EMP = "1";
		public const string PAY_FONE_GRAVA_PEND = "2";
		public const string PAY_FONE_CANCELA_PEND = "3";
		public const string PAY_FONE_AUTORIZA_VENDA = "4";
		public const string PAY_FONE_CONFIRMA_VENDA = "5";
		public const string PAY_FONE_CANCELA_VENDA = "6";
		public const string PAY_FONE_CANCELA_PEND_LOJISTA = "7";
		public const string FALHA_VENDA_EMPRESARIAL = "8";
		public const string FALHA_PAY_FONE_GRAVA_PEND = "9";
		public const string FALHA_PAY_FONE_CANCELA_PEND = "10";
		public const string FALHA_PAY_FONE_AUTORIZA_VENDA = "11";
		public const string FALHA_PAY_FONE_CONFIRMA_VENDA = "12";
		public const string FALHA_PAY_FONE_CANCELA_VENDA = "13";
		public const string FALHA_PAY_FONE_CANCELA_PEND_LOJISTA = "14";
		public const string VENDA_EMPRESARIAL_CANCELA = "15";
		public const string FALHA_VENDA_EMPRESARIAL_CANCELA = "16";
		public const string FALHA_CONF_VENDA_EMP = "17";
		public const string EDU_DEP_IMEDIATO = "18";
		public const string EDU_DEP_FUNDO = "19";
		public const string EDU_DEP_DIARIO = "20";
		public const string VENDA_EMPRESARIAL_DESFAZ = "21";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  VENDA_EMPRESARIAL,
													CONF_VENDA_EMP,
													PAY_FONE_GRAVA_PEND,
													PAY_FONE_CANCELA_PEND,
													PAY_FONE_AUTORIZA_VENDA,
													PAY_FONE_CONFIRMA_VENDA,
													PAY_FONE_CANCELA_VENDA,
													PAY_FONE_CANCELA_PEND_LOJISTA,
													FALHA_VENDA_EMPRESARIAL,
													FALHA_PAY_FONE_GRAVA_PEND,
													FALHA_PAY_FONE_CANCELA_PEND,
													FALHA_PAY_FONE_AUTORIZA_VENDA,
													FALHA_PAY_FONE_CONFIRMA_VENDA,
													FALHA_PAY_FONE_CANCELA_VENDA,
													FALHA_PAY_FONE_CANCELA_PEND_LOJISTA,
													VENDA_EMPRESARIAL_CANCELA,
													FALHA_VENDA_EMPRESARIAL_CANCELA,
													FALHA_CONF_VENDA_EMP,
													EDU_DEP_IMEDIATO,
													EDU_DEP_FUNDO,
													EDU_DEP_DIARIO,
													VENDA_EMPRESARIAL_DESFAZ } );
		}
	}
	
	public class OperacaoCartaoDesc
	{
		public const string VENDA_EMPRESARIAL = "Venda";
		public const string CONF_VENDA_EMP = "Confirmação Venda";
		public const string PAY_FONE_GRAVA_PEND = "Venda Pay Fone";
		public const string PAY_FONE_CANCELA_PEND = "Cancelamento de Pendências de Pay Fone";
		public const string PAY_FONE_AUTORIZA_VENDA = "Autorização de Venda de Pay Fone";
		public const string PAY_FONE_CONFIRMA_VENDA = "Confirmação de Venda por Pay Fone";
		public const string PAY_FONE_CANCELA_VENDA = "Cancelamento de Venda por Pay Fone";
		public const string PAY_FONE_CANCELA_PEND_LOJISTA = "Cancelamento de Venda Pay Fone pelo lojista";
		public const string FALHA_VENDA_EMPRESARIAL = "Falha na Venda";
		public const string FALHA_PAY_FONE_GRAVA_PEND = "Falha na Gravação de Pendência para Pay Fone";
		public const string FALHA_PAY_FONE_CANCELA_PEND = "Falha no Cancelamento de Pendência de Pay Fone";
		public const string FALHA_PAY_FONE_AUTORIZA_VENDA = "Falha na Autorização de Venda de Pay Fone";
		public const string FALHA_PAY_FONE_CONFIRMA_VENDA = "Falha na Confirmação de Venda de Pay Fone";
		public const string FALHA_PAY_FONE_CANCELA_VENDA = "Falha no Cancelamento de Venda de Pay Fone";
		public const string FALHA_PAY_FONE_CANCELA_PEND_LOJISTA = "Falha no Cancelamento de Pendência por Lojista de Payfone";
		public const string VENDA_EMPRESARIAL_CANCELA = "Cancelamento de Venda";
		public const string FALHA_VENDA_EMPRESARIAL_CANCELA = "Falha no Cancelamento de Venda";
		public const string FALHA_CONF_VENDA_EMP = "Falha na Confirmação de Venda";
		public const string EDU_DEP_IMEDIATO = "Depósito Imediato Educacional";
		public const string EDU_DEP_FUNDO = "Depósito Fundo Educacional";
		public const string EDU_DEP_DIARIO = "Transferência Automática Educacional";
		public const string VENDA_EMPRESARIAL_DESFAZ = "Desfazimento de venda empresarial pendente";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  VENDA_EMPRESARIAL,
													CONF_VENDA_EMP,
													PAY_FONE_GRAVA_PEND,
													PAY_FONE_CANCELA_PEND,
													PAY_FONE_AUTORIZA_VENDA,
													PAY_FONE_CONFIRMA_VENDA,
													PAY_FONE_CANCELA_VENDA,
													PAY_FONE_CANCELA_PEND_LOJISTA,
													FALHA_VENDA_EMPRESARIAL,
													FALHA_PAY_FONE_GRAVA_PEND,
													FALHA_PAY_FONE_CANCELA_PEND,
													FALHA_PAY_FONE_AUTORIZA_VENDA,
													FALHA_PAY_FONE_CONFIRMA_VENDA,
													FALHA_PAY_FONE_CANCELA_VENDA,
													FALHA_PAY_FONE_CANCELA_PEND_LOJISTA,
													VENDA_EMPRESARIAL_CANCELA,
													FALHA_VENDA_EMPRESARIAL_CANCELA,
													FALHA_CONF_VENDA_EMP,
													EDU_DEP_IMEDIATO,
													EDU_DEP_FUNDO,
													EDU_DEP_DIARIO,
													VENDA_EMPRESARIAL_DESFAZ } );
		}
	}
	
	public class TipoCelular
	{
		public const string LOJA = "0";
		public const string CLIENTE = "1";
		public const string LOJA_TB = "2";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  LOJA,
													CLIENTE,
													LOJA_TB } );
		}
	}
	
	public class TipoPendPayFone
	{
		public const string PENDENTE = "0";
		public const string CANCELADO = "1";
		public const string CONFIRMADO = "2";
		public const string NEGADO = "3";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  PENDENTE,
													CANCELADO,
													CONFIRMADO,
													NEGADO } );
		}
	}
	
	public class TipoCartao
	{
		public const string empresarial = "0";
		public const string presente = "1";
		public const string educacional = "2";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  empresarial,
													presente,
													educacional } );
		}
	}
	
	public class TipoCartaoDesc
	{
		public const string empresarial = "Cartão Empresarial";
		public const string presente = "Cartão GiftCard";
		public const string educacional = "Cartão Universitário";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  empresarial,
													presente,
													educacional } );
		}
	}
	
	public class CartaoStatusDesc
	{
		public const string Habilitado = "Habilitado";
		public const string Bloqueado = "Bloqueado";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  Habilitado,
													Bloqueado } );
		}
	}
	
	public class TipoConfirmacao
	{
		public const string Pendente = "0";
		public const string Confirmada = "1";
		public const string Negada = "2";
		public const string Erro = "3";
		public const string Registro = "4";
		public const string Cancelada = "5";
		public const string Desfeita = "6";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  Pendente,
													Confirmada,
													Negada,
													Erro,
													Registro,
													Cancelada,
													Desfeita } );
		}
	}
	
	public class TipoConfirmacaoDesc
	{
		public const string Pendente = "Pendente";
		public const string Confirmada = "Confirmada";
		public const string Negada = "Negada";
		public const string Erro = "Erro";
		public const string Registro = "Registro";
		public const string Cancelada = "Cancelada";
		public const string Desfeita = "Desfeita";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  Pendente,
													Confirmada,
													Negada,
													Erro,
													Registro,
													Cancelada,
													Desfeita } );
		}
	}
	
	public class TipoAtividade
	{
		public const string FechMensal = "1";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] { FechMensal } );
		}
	}
	
	public class TipoAtividadeDesc
	{
		public const string FechMensal = "Fechamento Mensal";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] { FechMensal } );
		}
	}
	
	public class MotivoBloqueio
	{
		public const string PERDA = "0";
		public const string ROUBO = "1";
		public const string SENHA_ERRADA = "2";
		public const string CANCELAMENTO = "3";
		public const string ADMINISTRATIVO = "4";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  PERDA,
													ROUBO,
													SENHA_ERRADA,
													CANCELAMENTO,
													ADMINISTRATIVO } );
		}
	}
	
	public class MotivoBloqueioDesc
	{
		public const string PERDA = "Perda de Cartão";
		public const string ROUBO = "Roubo de cartão";
		public const string SENHA_ERRADA = "Senha - excedido numero de tentativas";
		public const string CANCELAMENTO = "Cancelamento de cartão";
		public const string ADMINISTRATIVO = "Motivo administrativo";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  PERDA,
													ROUBO,
													SENHA_ERRADA,
													CANCELAMENTO,
													ADMINISTRATIVO } );
		}
	}
	
	public class StatusExpedicao
	{
		public const string NaoExpedido = "0";
		public const string EmExpedicao = "1";
		public const string Expedido = "2";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  NaoExpedido,
													EmExpedicao,
													Expedido } );
		}
	}
	
	public class TipoCobranca
	{
		public const string Doc = "0";
		public const string DebitoCC = "1";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  Doc,
													DebitoCC } );
		}
	}
	
	public class TipoCobrancaDesc
	{
		public const string Doc = "DOC Bancário";
		public const string DebitoCC = "Débito em Conta Corrente";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  Doc,
													DebitoCC } );
		}
	}
	
	public class TipoSitFat
	{
		public const string Pendente = "0";
		public const string PagoCC = "1";
		public const string PagoDoc = "2";
		public const string PagoOutros = "3";
		public const string Cancelado = "4";
		public const string EmCobrança = "5";
		public const string BaixaCfeInst = "6";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  Pendente,
													PagoCC,
													PagoDoc,
													PagoOutros,
													Cancelado,
													EmCobrança,
													BaixaCfeInst } );
		}
	}
	
	public class TipoSitFatDesc
	{
		public const string Pendente = "Pendente pagamento";
		public const string PagoCC = "Pago via  Debito Conta Corrente";
		public const string PagoDoc = "Pago via DOC";
		public const string PagoOutros = "Pago outra forma";
		public const string Cancelado = "Fatura Cancelada";
		public const string BaixaCfeInst = "Baixa Conforme Instruções";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  Pendente,
													PagoCC,
													PagoDoc,
													PagoOutros,
													Cancelado,
													BaixaCfeInst } );
		}
	}
	
	public class TipoFat
	{
		public const string TBM = "1";
		public const string CartaoAtiv = "2";
		public const string FixoTrans = "3";
		public const string Percent = "4";
		public const string Extras = "5";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  TBM,
													CartaoAtiv,
													FixoTrans,
													Percent,
													Extras } );
		}
	}
	
	public class TipoFatDesc
	{
		public const string TBM = "Tarifa Básica Mensal";
		public const string CartaoAtiv = "Cartões Ativos";
		public const string FixoTrans = "Valor Fixo por Transação Efetuada";
		public const string Percent = "Percentual do Valor da Transação";
		public const string Extras = "Extras";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  TBM,
													CartaoAtiv,
													FixoTrans,
													Percent,
													Extras } );
		}
	}
	
	public class Parametros
	{
		public const string Empresa = "ConveyNET";
		public const string Cedente = "839854166077";
		public const string ConvenioDebConta = "00650";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  Empresa,
													Cedente,
													ConvenioDebConta } );
		}
	}
	
	public class TipoUsuarioDesc
	{
		public const string SuperUser = "Super usuário";
		public const string Administrador = "Administrador";
		public const string Operador = "Operador";
		public const string OperadorEdu = "Operador Educacional";
		public const string OperadorCont = "Operador Contábil";
		public const string OperadorConvey = "Operador ConveyNET";
		public const string VendedorGift = "Vendedor Gift Card";
		public const string AdminGift = "Administrador Gift Card";
		public const string Lojista = "Vendedor Varejo";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  SuperUser,
													Administrador,
													Operador,
													OperadorEdu,
													OperadorCont,
													OperadorConvey,
													VendedorGift,
													AdminGift,
													Lojista } );
		}
	}
	
	public class TipoPagamento
	{
		public const string Dinheiro = "0";
		public const string Cheque = "1";
		public const string Cartao = "2";
		
		public ArrayList GetArray()
		{
			return new ArrayList ( new string [] {  Dinheiro,
													Cheque,
													Cartao } );
		}
	}
}
