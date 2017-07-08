using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace Client
{
	public partial class MainForm
	{
		public event_MainForm ev_layer;
				
		public MainForm ( event_MainForm par_ev_layer )
		{
			InitializeComponent();
			
			ev_layer = par_ev_layer;		
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_FormIsClosing, null );
		}
		
		void TrocarSenhaToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_TrocaSenha, null );
		}
		
		void SairToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_Sair, null );
		}
		
		void CriarNovoToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_NovoCartaoProprietario, null );
		}
		
		void AlterarLimitesToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_LimitesCartao, null );
		}
		
		void AlterarSenhaToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_AlterarSenhaCartao, null );
		}
		
		void ConsultaToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_ConsultaCartao, null );
		}
		
		void ClienteToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_PF_CadastroCliente, null );			
		}
		
		void LojistaToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_PF_CadastroLojista, null );			
		}
		
		void CadastroToolStripMenuItem3Click(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_CadastroConvenio, null );			
		}
		
		void ManutençãoToolStripMenuItem2Click(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_ManutencaoConvenio, null );			
		}
		
		void ConsultaToolStripMenuItem2Click(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_ConsultaEmpresa, null );			
		}
		
		void CadastroToolStripMenuItem2Click(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_CadastroLoja, null );			
		}
		
		void ManutençãoToolStripMenuItem1Click(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_ManutencaoLoja, null );			
		}
		
		void ConsultaToolStripMenuItem1Click(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_ConsultaLoja, null );			
		}
		
		void CadastroToolStripMenuItem4Click(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_Terminal, null );						
		}
		
		void ManutençãoToolStripMenuItem3Click(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_ManutTerminal, null );						
		}
		
		void CadastroToolStripMenuItem1Click(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_CadastroUsuario, null );						
		}
		
		void ManutençãoToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_ManutencaoUsuario, null );			
		}
		
		void GravarPendênciaToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_GravaPendencia_PayFone, null );
		}
		
		void VerificaPendênciaToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_VerificaPendencia_PayFone, null );
		}
		
		void CancelaPendênciaToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_CancelaPendencia_PayFone, null );
		}
		
		void AutorizaVendaToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_AutorizaVenda_PayFone, null );			
		}
		
		void CancelaVendaToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_CancelaVendaPayFone, null );						
		}
		
		void EfetuaToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_VendaEmpresarial, null );						
		}
		
		void RegistrosToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_ConsultaAuditoria, null );						
		}
		
		void TransaçõesToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_ConsultaTransacoes, null );						
		}
		
		void RelatóriosToolStripMenuItemClick(object sender, EventArgs e)
		{
			
		}
		
		void AgendamentoToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_Agenda, null );						
		}
		
		void ConveniosToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_ManutConvenios, null );			
		}
		
		void CancelaToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_VendaEmpCancelamento, null );			
		}
		
		void ManutençãoToolStripMenuItem4Click(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_Educacional, null );			
		}
		
		void ToolStripMenuItem1Click(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_Bloqueio, null );			
		}
		
		void DesbloqueioToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_Desbloqueio, null );			
		}
		
		void HabilitarNovoCartãoToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_HabilitarEdu, null );			
		}
		
		void Menu_ExpediçãoClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_Expedicao, null );			
		}
		
		void Menu_ConfirmarCartaoClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_ConfCartao, null );			
		}
		
		void CancelarCartãoToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_EduCancelarCartao, null );			
		}
		
		void EmitirNovoCartãoToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_EduSegundaVia, null );			
		}
		
		void AdministradorasToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_Admins, null );			
		}
	
		void CadastroToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_FatExtra, null );			
		}
		
		void SegundaViaToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_SegundaVia, null );			
		}
		
		void PendenteToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_Faturamento, null );			
		}
		
		void GerarArquivoBancárioToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_FatGerarArquivo, null );
		}
		
		void ReceberArquivoBancárioToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_RecebeArqBanco, null );
		}
		
		void FatcadastroToolStripMenuItem2Click(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_FatExtra, null );
		}
		
		void FatcancelamentoToolStripMenuItem1Click(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_CancelaDespesa, null );			
		}
		
		void RelatóriosToolStripMenuItem1Click(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_FatRel, null );			
		}
		
		void RelatóriosToolStripMenuItem2Click(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_Relatorio, null );									
		}
		
		void DadosCadastraisToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_DadosCadastraisProp, null );	
		}
		
		void NovoToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_NovoChamado, null );	
		}
		
		void PesquisarToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_PesquisaChamado, null );	
		}
		
		void ProdutosExtrasToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_ProdutosExtrasGift, null );
		}
		
		void QuiosquesToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_Quiosque, null );
		}
		
		void Menu_RecargaGiftClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_RecargaGift, null );
		}
		
		void Menu_ConsultaGiftCardClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_ConsultaGift, null );
		}
		
		void Menu_ChequesGiftClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_CompensaChequeGift, null );			
		}
		
		void ConfirmaçãoDeRepassesToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_ConfirmarRepasse, null );			
		}
		
		void Menu_NovoDependenteClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_NovoDependente, null );			
		}
		
		void Menu_ResPendClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_ResPend, null );			
		}
		
		void Menu_Fat_RecManualClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_dlgFatRecManual, null );			
		}
		
		void Menu_LojistasClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_Lojista, null );			
		}
		
		void Menu_EfetuaVendaLojistaClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_VendaLojista, null );			
		}
		
		void RelatórioDeTarifasAoClienteToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_TarifasCliente, null );			
		}
		
		void Menu_ReimpGiftClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_ReimpGift, null );			
		}
		
		void Menu_GraficosClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_Graficos, null );			
		}
		
		void Menu_RemNovosCartoesClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_RemNovosCartoes, null );
		}
		
		void Menu_MensPaisClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_MensagensPais, null );
		}
		
		void CotaExtraToolStripMenuItemClick(object sender, EventArgs e)
		{
			ev_layer.doEvent ( event_MainForm.event_CotaExtraToolStripMenuItemClick, null );
		}
		
		void MenuStrip1ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			
		}
		
		void MenuExcluirCartClick(object sender, EventArgs e)
		{
			//ev_layer.doEvent ( event_MainForm.event_MenuExcluirCartClick, null );
		}
	}
}
