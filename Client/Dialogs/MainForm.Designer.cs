/*
 * Created by SharpDevelop.
 * User: rodrigo.groff
 * Date: 8/5/2006
 * Time: 16:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

 using System.Windows.Forms;
 
namespace Client
{
	partial class MainForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components = null;
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.LblVersion = new System.Windows.Forms.Label();
            this.LblNivel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu_Opcoes = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_TrocarSenha = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Sair = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Cartoes = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_ConsultaCartao = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_ConsultaGiftCard = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_CriarNovo = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_NovoDependente = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_CriarPayFone = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lojistaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_DadosCadCartao = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAlterarLimites = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_AlterarSenha = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Bloqueio = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Desbloqueio = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_SegundaViaCartao = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_RecargaGift = new System.Windows.Forms.ToolStripMenuItem();
            this.cotaExtraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Cadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Empresas = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.manutençãoToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.administradorasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Lojas = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_LojCad = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_LojManut = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_LojConv = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Terminais = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.manutençãoToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Usuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manutençãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Lojistas = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_ProdExtra = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Quiosques = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Operacoes = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Graficos = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Relatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_PayFone = new System.Windows.Forms.ToolStripMenuItem();
            this.gravarPendênciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verificaPendênciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelaPendênciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autorizaVendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelaVendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_VendaCartao = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_EfetuaVenda = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_EfetuaVendaLojista = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_CancelaVenda = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Educacional = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_EduManut = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarCartãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emitirNovoCartãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_MensPais = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFaturamento = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuConsPendFat = new System.Windows.Forms.ToolStripMenuItem();
            this.extraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FatcadastroToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.FatcancelamentoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGerarArquivoBan = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReceberArquivoBan = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRelatoriosFat = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Fat_RecManual = new System.Windows.Forms.ToolStripMenuItem();
            this.relatórioDeTarifasAoClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Agendamento = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_LibGift = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Expedição = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_ConfirmarCartao = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_HabilitarCartao = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_ChequesGift = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_ConfRepasse = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_ResPend = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_ReimpGift = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_RemNovosCartoes = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Auditoria = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAuditRegistros = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Transacoes = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelpDesk = new System.Windows.Forms.ToolStripMenuItem();
            this.novoChamadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblVersion
            // 
            this.LblVersion.BackColor = System.Drawing.Color.Transparent;
            this.LblVersion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.LblVersion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LblVersion.Location = new System.Drawing.Point(12, 244);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(323, 23);
            this.LblVersion.TabIndex = 1;
            this.LblVersion.Text = "label1";
            // 
            // LblNivel
            // 
            this.LblNivel.BackColor = System.Drawing.Color.Transparent;
            this.LblNivel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNivel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.LblNivel.Location = new System.Drawing.Point(12, 226);
            this.LblNivel.Name = "LblNivel";
            this.LblNivel.Size = new System.Drawing.Size(323, 23);
            this.LblNivel.TabIndex = 2;
            this.LblNivel.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Opcoes,
            this.Menu_Cartoes,
            this.Menu_Cadastro,
            this.Menu_Operacoes,
            this.Menu_Auditoria,
            this.MenuHelpDesk});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(604, 24);
            this.menuStrip1.TabIndex = 67;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip1ItemClicked);
            // 
            // Menu_Opcoes
            // 
            this.Menu_Opcoes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_TrocarSenha,
            this.Menu_Sair});
            this.Menu_Opcoes.Name = "Menu_Opcoes";
            this.Menu_Opcoes.Size = new System.Drawing.Size(55, 20);
            this.Menu_Opcoes.Text = "Opções";
            // 
            // Menu_TrocarSenha
            // 
            this.Menu_TrocarSenha.Name = "Menu_TrocarSenha";
            this.Menu_TrocarSenha.Size = new System.Drawing.Size(152, 22);
            this.Menu_TrocarSenha.Text = "Trocar Senha";
            this.Menu_TrocarSenha.Click += new System.EventHandler(this.TrocarSenhaToolStripMenuItemClick);
            // 
            // Menu_Sair
            // 
            this.Menu_Sair.Name = "Menu_Sair";
            this.Menu_Sair.Size = new System.Drawing.Size(152, 22);
            this.Menu_Sair.Text = "Sair";
            this.Menu_Sair.Click += new System.EventHandler(this.SairToolStripMenuItemClick);
            // 
            // Menu_Cartoes
            // 
            this.Menu_Cartoes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_ConsultaCartao,
            this.Menu_ConsultaGiftCard,
            this.Menu_CriarNovo,
            this.Menu_NovoDependente,
            this.Menu_CriarPayFone,
            this.Menu_DadosCadCartao,
            this.MenuAlterarLimites,
            this.Menu_AlterarSenha,
            this.Menu_Bloqueio,
            this.Menu_Desbloqueio,
            this.Menu_SegundaViaCartao,
            this.Menu_RecargaGift,
            this.cotaExtraToolStripMenuItem});
            this.Menu_Cartoes.Name = "Menu_Cartoes";
            this.Menu_Cartoes.Size = new System.Drawing.Size(57, 20);
            this.Menu_Cartoes.Text = "Cartões";
            // 
            // Menu_ConsultaCartao
            // 
            this.Menu_ConsultaCartao.Name = "Menu_ConsultaCartao";
            this.Menu_ConsultaCartao.Size = new System.Drawing.Size(247, 22);
            this.Menu_ConsultaCartao.Text = "Consulta de Cartões";
            this.Menu_ConsultaCartao.Click += new System.EventHandler(this.ConsultaToolStripMenuItemClick);
            // 
            // Menu_ConsultaGiftCard
            // 
            this.Menu_ConsultaGiftCard.Name = "Menu_ConsultaGiftCard";
            this.Menu_ConsultaGiftCard.Size = new System.Drawing.Size(247, 22);
            this.Menu_ConsultaGiftCard.Text = "Consulta Cartão GiftCard";
            this.Menu_ConsultaGiftCard.Click += new System.EventHandler(this.Menu_ConsultaGiftCardClick);
            // 
            // Menu_CriarNovo
            // 
            this.Menu_CriarNovo.Name = "Menu_CriarNovo";
            this.Menu_CriarNovo.Size = new System.Drawing.Size(247, 22);
            this.Menu_CriarNovo.Text = "Criar Novo Cartão";
            this.Menu_CriarNovo.Click += new System.EventHandler(this.CriarNovoToolStripMenuItemClick);
            // 
            // Menu_NovoDependente
            // 
            this.Menu_NovoDependente.Name = "Menu_NovoDependente";
            this.Menu_NovoDependente.Size = new System.Drawing.Size(247, 22);
            this.Menu_NovoDependente.Text = "Criar Novo Cartão para dependente";
            this.Menu_NovoDependente.Click += new System.EventHandler(this.Menu_NovoDependenteClick);
            // 
            // Menu_CriarPayFone
            // 
            this.Menu_CriarPayFone.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem,
            this.lojistaToolStripMenuItem});
            this.Menu_CriarPayFone.Name = "Menu_CriarPayFone";
            this.Menu_CriarPayFone.Size = new System.Drawing.Size(247, 22);
            this.Menu_CriarPayFone.Text = "Criar Novo Pay Fone";
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.clienteToolStripMenuItem.Text = "Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.ClienteToolStripMenuItemClick);
            // 
            // lojistaToolStripMenuItem
            // 
            this.lojistaToolStripMenuItem.Name = "lojistaToolStripMenuItem";
            this.lojistaToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.lojistaToolStripMenuItem.Text = "Lojista";
            this.lojistaToolStripMenuItem.Click += new System.EventHandler(this.LojistaToolStripMenuItemClick);
            // 
            // Menu_DadosCadCartao
            // 
            this.Menu_DadosCadCartao.Name = "Menu_DadosCadCartao";
            this.Menu_DadosCadCartao.Size = new System.Drawing.Size(247, 22);
            this.Menu_DadosCadCartao.Text = "Alterar Dados Cadastrais";
            this.Menu_DadosCadCartao.Click += new System.EventHandler(this.DadosCadastraisToolStripMenuItemClick);
            // 
            // MenuAlterarLimites
            // 
            this.MenuAlterarLimites.Name = "MenuAlterarLimites";
            this.MenuAlterarLimites.Size = new System.Drawing.Size(247, 22);
            this.MenuAlterarLimites.Text = "Alteração de Limites Financeiros";
            this.MenuAlterarLimites.Click += new System.EventHandler(this.AlterarLimitesToolStripMenuItemClick);
            // 
            // Menu_AlterarSenha
            // 
            this.Menu_AlterarSenha.Name = "Menu_AlterarSenha";
            this.Menu_AlterarSenha.Size = new System.Drawing.Size(247, 22);
            this.Menu_AlterarSenha.Text = "Alterar Senha de Cartão";
            this.Menu_AlterarSenha.Click += new System.EventHandler(this.AlterarSenhaToolStripMenuItemClick);
            // 
            // Menu_Bloqueio
            // 
            this.Menu_Bloqueio.Name = "Menu_Bloqueio";
            this.Menu_Bloqueio.Size = new System.Drawing.Size(247, 22);
            this.Menu_Bloqueio.Text = "Bloqueio de Cartão";
            this.Menu_Bloqueio.Click += new System.EventHandler(this.ToolStripMenuItem1Click);
            // 
            // Menu_Desbloqueio
            // 
            this.Menu_Desbloqueio.Name = "Menu_Desbloqueio";
            this.Menu_Desbloqueio.Size = new System.Drawing.Size(247, 22);
            this.Menu_Desbloqueio.Text = "Desbloqueio de Cartão";
            this.Menu_Desbloqueio.Click += new System.EventHandler(this.DesbloqueioToolStripMenuItemClick);
            // 
            // Menu_SegundaViaCartao
            // 
            this.Menu_SegundaViaCartao.Name = "Menu_SegundaViaCartao";
            this.Menu_SegundaViaCartao.Size = new System.Drawing.Size(247, 22);
            this.Menu_SegundaViaCartao.Text = "Segunda Via de Cartão";
            this.Menu_SegundaViaCartao.Click += new System.EventHandler(this.SegundaViaToolStripMenuItemClick);
            // 
            // Menu_RecargaGift
            // 
            this.Menu_RecargaGift.Name = "Menu_RecargaGift";
            this.Menu_RecargaGift.Size = new System.Drawing.Size(247, 22);
            this.Menu_RecargaGift.Text = "Recarga de Cartão GiftCard";
            this.Menu_RecargaGift.Click += new System.EventHandler(this.Menu_RecargaGiftClick);
            // 
            // cotaExtraToolStripMenuItem
            // 
            this.cotaExtraToolStripMenuItem.Name = "cotaExtraToolStripMenuItem";
            this.cotaExtraToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.cotaExtraToolStripMenuItem.Text = "Cota Extra";
            this.cotaExtraToolStripMenuItem.Click += new System.EventHandler(this.CotaExtraToolStripMenuItemClick);
            // 
            // Menu_Cadastro
            // 
            this.Menu_Cadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Empresas,
            this.Menu_Lojas,
            this.Menu_Terminais,
            this.Menu_Usuarios,
            this.Menu_ProdExtra,
            this.Menu_Quiosques});
            this.Menu_Cadastro.Name = "Menu_Cadastro";
            this.Menu_Cadastro.Size = new System.Drawing.Size(63, 20);
            this.Menu_Cadastro.Text = "Cadastro";
            // 
            // Menu_Empresas
            // 
            this.Menu_Empresas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem3,
            this.manutençãoToolStripMenuItem2,
            this.consultaToolStripMenuItem2,
            this.administradorasToolStripMenuItem});
            this.Menu_Empresas.Name = "Menu_Empresas";
            this.Menu_Empresas.Size = new System.Drawing.Size(151, 22);
            this.Menu_Empresas.Text = "Empresas";
            // 
            // cadastroToolStripMenuItem3
            // 
            this.cadastroToolStripMenuItem3.Name = "cadastroToolStripMenuItem3";
            this.cadastroToolStripMenuItem3.Size = new System.Drawing.Size(151, 22);
            this.cadastroToolStripMenuItem3.Text = "Cadastro";
            this.cadastroToolStripMenuItem3.Click += new System.EventHandler(this.CadastroToolStripMenuItem3Click);
            // 
            // manutençãoToolStripMenuItem2
            // 
            this.manutençãoToolStripMenuItem2.Name = "manutençãoToolStripMenuItem2";
            this.manutençãoToolStripMenuItem2.Size = new System.Drawing.Size(151, 22);
            this.manutençãoToolStripMenuItem2.Text = "Manutenção";
            this.manutençãoToolStripMenuItem2.Click += new System.EventHandler(this.ManutençãoToolStripMenuItem2Click);
            // 
            // consultaToolStripMenuItem2
            // 
            this.consultaToolStripMenuItem2.Name = "consultaToolStripMenuItem2";
            this.consultaToolStripMenuItem2.Size = new System.Drawing.Size(151, 22);
            this.consultaToolStripMenuItem2.Text = "Consulta";
            this.consultaToolStripMenuItem2.Click += new System.EventHandler(this.ConsultaToolStripMenuItem2Click);
            // 
            // administradorasToolStripMenuItem
            // 
            this.administradorasToolStripMenuItem.Name = "administradorasToolStripMenuItem";
            this.administradorasToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.administradorasToolStripMenuItem.Text = "Administradoras";
            this.administradorasToolStripMenuItem.Click += new System.EventHandler(this.AdministradorasToolStripMenuItemClick);
            // 
            // Menu_Lojas
            // 
            this.Menu_Lojas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_LojCad,
            this.Menu_LojManut,
            this.consultaToolStripMenuItem1,
            this.Menu_LojConv});
            this.Menu_Lojas.Name = "Menu_Lojas";
            this.Menu_Lojas.Size = new System.Drawing.Size(151, 22);
            this.Menu_Lojas.Text = "Lojas";
            // 
            // Menu_LojCad
            // 
            this.Menu_LojCad.Name = "Menu_LojCad";
            this.Menu_LojCad.Size = new System.Drawing.Size(133, 22);
            this.Menu_LojCad.Text = "Cadastro";
            this.Menu_LojCad.Click += new System.EventHandler(this.CadastroToolStripMenuItem2Click);
            // 
            // Menu_LojManut
            // 
            this.Menu_LojManut.Name = "Menu_LojManut";
            this.Menu_LojManut.Size = new System.Drawing.Size(133, 22);
            this.Menu_LojManut.Text = "Manutenção";
            this.Menu_LojManut.Click += new System.EventHandler(this.ManutençãoToolStripMenuItem1Click);
            // 
            // consultaToolStripMenuItem1
            // 
            this.consultaToolStripMenuItem1.Name = "consultaToolStripMenuItem1";
            this.consultaToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.consultaToolStripMenuItem1.Text = "Consulta";
            this.consultaToolStripMenuItem1.Click += new System.EventHandler(this.ConsultaToolStripMenuItem1Click);
            // 
            // Menu_LojConv
            // 
            this.Menu_LojConv.Name = "Menu_LojConv";
            this.Menu_LojConv.Size = new System.Drawing.Size(133, 22);
            this.Menu_LojConv.Text = "Convênios";
            this.Menu_LojConv.Click += new System.EventHandler(this.ConveniosToolStripMenuItemClick);
            // 
            // Menu_Terminais
            // 
            this.Menu_Terminais.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem4,
            this.manutençãoToolStripMenuItem3});
            this.Menu_Terminais.Name = "Menu_Terminais";
            this.Menu_Terminais.Size = new System.Drawing.Size(151, 22);
            this.Menu_Terminais.Text = "Terminais";
            // 
            // cadastroToolStripMenuItem4
            // 
            this.cadastroToolStripMenuItem4.Name = "cadastroToolStripMenuItem4";
            this.cadastroToolStripMenuItem4.Size = new System.Drawing.Size(133, 22);
            this.cadastroToolStripMenuItem4.Text = "Cadastro";
            this.cadastroToolStripMenuItem4.Click += new System.EventHandler(this.CadastroToolStripMenuItem4Click);
            // 
            // manutençãoToolStripMenuItem3
            // 
            this.manutençãoToolStripMenuItem3.Name = "manutençãoToolStripMenuItem3";
            this.manutençãoToolStripMenuItem3.Size = new System.Drawing.Size(133, 22);
            this.manutençãoToolStripMenuItem3.Text = "Manutenção";
            this.manutençãoToolStripMenuItem3.Click += new System.EventHandler(this.ManutençãoToolStripMenuItem3Click);
            // 
            // Menu_Usuarios
            // 
            this.Menu_Usuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem1,
            this.manutençãoToolStripMenuItem,
            this.Menu_Lojistas});
            this.Menu_Usuarios.Name = "Menu_Usuarios";
            this.Menu_Usuarios.Size = new System.Drawing.Size(151, 22);
            this.Menu_Usuarios.Text = "Usuários";
            // 
            // cadastroToolStripMenuItem1
            // 
            this.cadastroToolStripMenuItem1.Name = "cadastroToolStripMenuItem1";
            this.cadastroToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.cadastroToolStripMenuItem1.Text = "Cadastro";
            this.cadastroToolStripMenuItem1.Click += new System.EventHandler(this.CadastroToolStripMenuItem1Click);
            // 
            // manutençãoToolStripMenuItem
            // 
            this.manutençãoToolStripMenuItem.Name = "manutençãoToolStripMenuItem";
            this.manutençãoToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.manutençãoToolStripMenuItem.Text = "Manutenção";
            this.manutençãoToolStripMenuItem.Click += new System.EventHandler(this.ManutençãoToolStripMenuItemClick);
            // 
            // Menu_Lojistas
            // 
            this.Menu_Lojistas.Name = "Menu_Lojistas";
            this.Menu_Lojistas.Size = new System.Drawing.Size(133, 22);
            this.Menu_Lojistas.Text = "Lojistas";
            this.Menu_Lojistas.Click += new System.EventHandler(this.Menu_LojistasClick);
            // 
            // Menu_ProdExtra
            // 
            this.Menu_ProdExtra.Name = "Menu_ProdExtra";
            this.Menu_ProdExtra.Size = new System.Drawing.Size(151, 22);
            this.Menu_ProdExtra.Text = "Produtos Extras";
            this.Menu_ProdExtra.Click += new System.EventHandler(this.ProdutosExtrasToolStripMenuItemClick);
            // 
            // Menu_Quiosques
            // 
            this.Menu_Quiosques.Name = "Menu_Quiosques";
            this.Menu_Quiosques.Size = new System.Drawing.Size(151, 22);
            this.Menu_Quiosques.Text = "Quiosques";
            this.Menu_Quiosques.Click += new System.EventHandler(this.QuiosquesToolStripMenuItemClick);
            // 
            // Menu_Operacoes
            // 
            this.Menu_Operacoes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Graficos,
            this.Menu_Relatorios,
            this.Menu_PayFone,
            this.Menu_VendaCartao,
            this.Menu_Educacional,
            this.MenuFaturamento,
            this.Menu_Agendamento,
            this.Menu_LibGift,
            this.Menu_Expedição,
            this.Menu_ConfirmarCartao,
            this.Menu_HabilitarCartao,
            this.Menu_ChequesGift,
            this.Menu_ConfRepasse,
            this.Menu_ResPend,
            this.Menu_ReimpGift,
            this.Menu_RemNovosCartoes});
            this.Menu_Operacoes.Name = "Menu_Operacoes";
            this.Menu_Operacoes.Size = new System.Drawing.Size(71, 20);
            this.Menu_Operacoes.Text = "Operações";
            // 
            // Menu_Graficos
            // 
            this.Menu_Graficos.Name = "Menu_Graficos";
            this.Menu_Graficos.Size = new System.Drawing.Size(275, 22);
            this.Menu_Graficos.Text = "Gráficos de performance";
            this.Menu_Graficos.Click += new System.EventHandler(this.Menu_GraficosClick);
            // 
            // Menu_Relatorios
            // 
            this.Menu_Relatorios.Name = "Menu_Relatorios";
            this.Menu_Relatorios.Size = new System.Drawing.Size(275, 22);
            this.Menu_Relatorios.Text = "Relatórios";
            this.Menu_Relatorios.Click += new System.EventHandler(this.RelatóriosToolStripMenuItem2Click);
            // 
            // Menu_PayFone
            // 
            this.Menu_PayFone.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gravarPendênciaToolStripMenuItem,
            this.verificaPendênciaToolStripMenuItem,
            this.cancelaPendênciaToolStripMenuItem,
            this.autorizaVendaToolStripMenuItem,
            this.cancelaVendaToolStripMenuItem});
            this.Menu_PayFone.Name = "Menu_PayFone";
            this.Menu_PayFone.Size = new System.Drawing.Size(275, 22);
            this.Menu_PayFone.Text = "Pay Fone";
            // 
            // gravarPendênciaToolStripMenuItem
            // 
            this.gravarPendênciaToolStripMenuItem.Name = "gravarPendênciaToolStripMenuItem";
            this.gravarPendênciaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.gravarPendênciaToolStripMenuItem.Text = "Gravar Pendência";
            this.gravarPendênciaToolStripMenuItem.Click += new System.EventHandler(this.GravarPendênciaToolStripMenuItemClick);
            // 
            // verificaPendênciaToolStripMenuItem
            // 
            this.verificaPendênciaToolStripMenuItem.Name = "verificaPendênciaToolStripMenuItem";
            this.verificaPendênciaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.verificaPendênciaToolStripMenuItem.Text = "Verifica Pendência";
            this.verificaPendênciaToolStripMenuItem.Click += new System.EventHandler(this.VerificaPendênciaToolStripMenuItemClick);
            // 
            // cancelaPendênciaToolStripMenuItem
            // 
            this.cancelaPendênciaToolStripMenuItem.Name = "cancelaPendênciaToolStripMenuItem";
            this.cancelaPendênciaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.cancelaPendênciaToolStripMenuItem.Text = "Cancela Pendência";
            this.cancelaPendênciaToolStripMenuItem.Click += new System.EventHandler(this.CancelaPendênciaToolStripMenuItemClick);
            // 
            // autorizaVendaToolStripMenuItem
            // 
            this.autorizaVendaToolStripMenuItem.Name = "autorizaVendaToolStripMenuItem";
            this.autorizaVendaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.autorizaVendaToolStripMenuItem.Text = "Autoriza Venda";
            this.autorizaVendaToolStripMenuItem.Click += new System.EventHandler(this.AutorizaVendaToolStripMenuItemClick);
            // 
            // cancelaVendaToolStripMenuItem
            // 
            this.cancelaVendaToolStripMenuItem.Name = "cancelaVendaToolStripMenuItem";
            this.cancelaVendaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.cancelaVendaToolStripMenuItem.Text = "Cancela Venda";
            this.cancelaVendaToolStripMenuItem.Click += new System.EventHandler(this.CancelaVendaToolStripMenuItemClick);
            // 
            // Menu_VendaCartao
            // 
            this.Menu_VendaCartao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_EfetuaVenda,
            this.Menu_EfetuaVendaLojista,
            this.Menu_CancelaVenda});
            this.Menu_VendaCartao.Name = "Menu_VendaCartao";
            this.Menu_VendaCartao.Size = new System.Drawing.Size(275, 22);
            this.Menu_VendaCartao.Text = "Autorizações de Venda";
            // 
            // Menu_EfetuaVenda
            // 
            this.Menu_EfetuaVenda.Name = "Menu_EfetuaVenda";
            this.Menu_EfetuaVenda.Size = new System.Drawing.Size(173, 22);
            this.Menu_EfetuaVenda.Text = "Efetua Venda Gift";
            this.Menu_EfetuaVenda.Click += new System.EventHandler(this.EfetuaToolStripMenuItemClick);
            // 
            // Menu_EfetuaVendaLojista
            // 
            this.Menu_EfetuaVendaLojista.Name = "Menu_EfetuaVendaLojista";
            this.Menu_EfetuaVendaLojista.Size = new System.Drawing.Size(173, 22);
            this.Menu_EfetuaVendaLojista.Text = "Efetua Venda Lojista";
            this.Menu_EfetuaVendaLojista.Click += new System.EventHandler(this.Menu_EfetuaVendaLojistaClick);
            // 
            // Menu_CancelaVenda
            // 
            this.Menu_CancelaVenda.Name = "Menu_CancelaVenda";
            this.Menu_CancelaVenda.Size = new System.Drawing.Size(173, 22);
            this.Menu_CancelaVenda.Text = "Cancela";
            this.Menu_CancelaVenda.Click += new System.EventHandler(this.CancelaToolStripMenuItemClick);
            // 
            // Menu_Educacional
            // 
            this.Menu_Educacional.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_EduManut,
            this.cancelarCartãoToolStripMenuItem,
            this.emitirNovoCartãoToolStripMenuItem,
            this.Menu_MensPais});
            this.Menu_Educacional.Name = "Menu_Educacional";
            this.Menu_Educacional.Size = new System.Drawing.Size(275, 22);
            this.Menu_Educacional.Text = "Cartão Educacional";
            // 
            // Menu_EduManut
            // 
            this.Menu_EduManut.Name = "Menu_EduManut";
            this.Menu_EduManut.Size = new System.Drawing.Size(213, 22);
            this.Menu_EduManut.Text = "Manutenção";
            this.Menu_EduManut.Click += new System.EventHandler(this.ManutençãoToolStripMenuItem4Click);
            // 
            // cancelarCartãoToolStripMenuItem
            // 
            this.cancelarCartãoToolStripMenuItem.Name = "cancelarCartãoToolStripMenuItem";
            this.cancelarCartãoToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.cancelarCartãoToolStripMenuItem.Text = "Cancelar cartão";
            this.cancelarCartãoToolStripMenuItem.Click += new System.EventHandler(this.CancelarCartãoToolStripMenuItemClick);
            // 
            // emitirNovoCartãoToolStripMenuItem
            // 
            this.emitirNovoCartãoToolStripMenuItem.Name = "emitirNovoCartãoToolStripMenuItem";
            this.emitirNovoCartãoToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.emitirNovoCartãoToolStripMenuItem.Text = "Segunda via de cartão";
            this.emitirNovoCartãoToolStripMenuItem.Click += new System.EventHandler(this.EmitirNovoCartãoToolStripMenuItemClick);
            // 
            // Menu_MensPais
            // 
            this.Menu_MensPais.Name = "Menu_MensPais";
            this.Menu_MensPais.Size = new System.Drawing.Size(213, 22);
            this.Menu_MensPais.Text = "Mensagens aos pais e alunos";
            this.Menu_MensPais.Click += new System.EventHandler(this.Menu_MensPaisClick);
            // 
            // MenuFaturamento
            // 
            this.MenuFaturamento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuConsPendFat,
            this.extraToolStripMenuItem,
            this.MenuGerarArquivoBan,
            this.MenuReceberArquivoBan,
            this.MenuRelatoriosFat,
            this.Menu_Fat_RecManual,
            this.relatórioDeTarifasAoClienteToolStripMenuItem});
            this.MenuFaturamento.Name = "MenuFaturamento";
            this.MenuFaturamento.Size = new System.Drawing.Size(275, 22);
            this.MenuFaturamento.Text = "Faturamento";
            // 
            // MenuConsPendFat
            // 
            this.MenuConsPendFat.Name = "MenuConsPendFat";
            this.MenuConsPendFat.Size = new System.Drawing.Size(215, 22);
            this.MenuConsPendFat.Text = "Consulta Pendência";
            this.MenuConsPendFat.Click += new System.EventHandler(this.PendenteToolStripMenuItemClick);
            // 
            // extraToolStripMenuItem
            // 
            this.extraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FatcadastroToolStripMenuItem2,
            this.FatcancelamentoToolStripMenuItem1});
            this.extraToolStripMenuItem.Name = "extraToolStripMenuItem";
            this.extraToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.extraToolStripMenuItem.Text = "Extras";
            // 
            // FatcadastroToolStripMenuItem2
            // 
            this.FatcadastroToolStripMenuItem2.Name = "FatcadastroToolStripMenuItem2";
            this.FatcadastroToolStripMenuItem2.Size = new System.Drawing.Size(142, 22);
            this.FatcadastroToolStripMenuItem2.Text = "Cadastro";
            this.FatcadastroToolStripMenuItem2.Click += new System.EventHandler(this.FatcadastroToolStripMenuItem2Click);
            // 
            // FatcancelamentoToolStripMenuItem1
            // 
            this.FatcancelamentoToolStripMenuItem1.Name = "FatcancelamentoToolStripMenuItem1";
            this.FatcancelamentoToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.FatcancelamentoToolStripMenuItem1.Text = "Cancelamento";
            this.FatcancelamentoToolStripMenuItem1.Click += new System.EventHandler(this.FatcancelamentoToolStripMenuItem1Click);
            // 
            // MenuGerarArquivoBan
            // 
            this.MenuGerarArquivoBan.Name = "MenuGerarArquivoBan";
            this.MenuGerarArquivoBan.Size = new System.Drawing.Size(215, 22);
            this.MenuGerarArquivoBan.Text = "Gerar Arquivo Bancário";
            this.MenuGerarArquivoBan.Click += new System.EventHandler(this.GerarArquivoBancárioToolStripMenuItemClick);
            // 
            // MenuReceberArquivoBan
            // 
            this.MenuReceberArquivoBan.Name = "MenuReceberArquivoBan";
            this.MenuReceberArquivoBan.Size = new System.Drawing.Size(215, 22);
            this.MenuReceberArquivoBan.Text = "Receber Arquivo Bancário";
            this.MenuReceberArquivoBan.Click += new System.EventHandler(this.ReceberArquivoBancárioToolStripMenuItemClick);
            // 
            // MenuRelatoriosFat
            // 
            this.MenuRelatoriosFat.Name = "MenuRelatoriosFat";
            this.MenuRelatoriosFat.Size = new System.Drawing.Size(215, 22);
            this.MenuRelatoriosFat.Text = "Relatórios";
            this.MenuRelatoriosFat.Click += new System.EventHandler(this.RelatóriosToolStripMenuItem1Click);
            // 
            // Menu_Fat_RecManual
            // 
            this.Menu_Fat_RecManual.Name = "Menu_Fat_RecManual";
            this.Menu_Fat_RecManual.Size = new System.Drawing.Size(215, 22);
            this.Menu_Fat_RecManual.Text = "Recebimento Manual";
            this.Menu_Fat_RecManual.Click += new System.EventHandler(this.Menu_Fat_RecManualClick);
            // 
            // relatórioDeTarifasAoClienteToolStripMenuItem
            // 
            this.relatórioDeTarifasAoClienteToolStripMenuItem.Name = "relatórioDeTarifasAoClienteToolStripMenuItem";
            this.relatórioDeTarifasAoClienteToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.relatórioDeTarifasAoClienteToolStripMenuItem.Text = "Relatório de tarifas ao cliente";
            this.relatórioDeTarifasAoClienteToolStripMenuItem.Click += new System.EventHandler(this.RelatórioDeTarifasAoClienteToolStripMenuItemClick);
            // 
            // Menu_Agendamento
            // 
            this.Menu_Agendamento.Name = "Menu_Agendamento";
            this.Menu_Agendamento.Size = new System.Drawing.Size(275, 22);
            this.Menu_Agendamento.Text = "Agendamento de atividades";
            this.Menu_Agendamento.Click += new System.EventHandler(this.AgendamentoToolStripMenuItemClick);
            // 
            // Menu_LibGift
            // 
            this.Menu_LibGift.Name = "Menu_LibGift";
            this.Menu_LibGift.Size = new System.Drawing.Size(275, 22);
            this.Menu_LibGift.Text = "Liberação faixa cartão GiftCard";
            // 
            // Menu_Expedição
            // 
            this.Menu_Expedição.Name = "Menu_Expedição";
            this.Menu_Expedição.Size = new System.Drawing.Size(275, 22);
            this.Menu_Expedição.Text = "Expedição de cartões para gráfica";
            this.Menu_Expedição.Click += new System.EventHandler(this.Menu_ExpediçãoClick);
            // 
            // Menu_ConfirmarCartao
            // 
            this.Menu_ConfirmarCartao.Name = "Menu_ConfirmarCartao";
            this.Menu_ConfirmarCartao.Size = new System.Drawing.Size(275, 22);
            this.Menu_ConfirmarCartao.Text = "Confirmar cartão recebido";
            this.Menu_ConfirmarCartao.Click += new System.EventHandler(this.Menu_ConfirmarCartaoClick);
            // 
            // Menu_HabilitarCartao
            // 
            this.Menu_HabilitarCartao.Name = "Menu_HabilitarCartao";
            this.Menu_HabilitarCartao.Size = new System.Drawing.Size(275, 22);
            this.Menu_HabilitarCartao.Text = "Habilitar novo cartão com primeira senha";
            this.Menu_HabilitarCartao.Click += new System.EventHandler(this.HabilitarNovoCartãoToolStripMenuItemClick);
            // 
            // Menu_ChequesGift
            // 
            this.Menu_ChequesGift.Name = "Menu_ChequesGift";
            this.Menu_ChequesGift.Size = new System.Drawing.Size(275, 22);
            this.Menu_ChequesGift.Text = "Compensação de Cheques";
            this.Menu_ChequesGift.Click += new System.EventHandler(this.Menu_ChequesGiftClick);
            // 
            // Menu_ConfRepasse
            // 
            this.Menu_ConfRepasse.Name = "Menu_ConfRepasse";
            this.Menu_ConfRepasse.Size = new System.Drawing.Size(275, 22);
            this.Menu_ConfRepasse.Text = "Confirmação de repasses aos lojistas";
            this.Menu_ConfRepasse.Click += new System.EventHandler(this.ConfirmaçãoDeRepassesToolStripMenuItemClick);
            // 
            // Menu_ResPend
            // 
            this.Menu_ResPend.Name = "Menu_ResPend";
            this.Menu_ResPend.Size = new System.Drawing.Size(275, 22);
            this.Menu_ResPend.Text = "Resolução de Pendências";
            this.Menu_ResPend.Click += new System.EventHandler(this.Menu_ResPendClick);
            // 
            // Menu_ReimpGift
            // 
            this.Menu_ReimpGift.Name = "Menu_ReimpGift";
            this.Menu_ReimpGift.Size = new System.Drawing.Size(275, 22);
            this.Menu_ReimpGift.Text = "Reimpressão de venda de cartão GiftCard";
            this.Menu_ReimpGift.Click += new System.EventHandler(this.Menu_ReimpGiftClick);
            // 
            // Menu_RemNovosCartoes
            // 
            this.Menu_RemNovosCartoes.Name = "Menu_RemNovosCartoes";
            this.Menu_RemNovosCartoes.Size = new System.Drawing.Size(275, 22);
            this.Menu_RemNovosCartoes.Text = "Carga de remessa de novos cartões";
            this.Menu_RemNovosCartoes.Click += new System.EventHandler(this.Menu_RemNovosCartoesClick);
            // 
            // Menu_Auditoria
            // 
            this.Menu_Auditoria.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAuditRegistros,
            this.Menu_Transacoes});
            this.Menu_Auditoria.Name = "Menu_Auditoria";
            this.Menu_Auditoria.Size = new System.Drawing.Size(62, 20);
            this.Menu_Auditoria.Text = "Auditoria";
            // 
            // MenuAuditRegistros
            // 
            this.MenuAuditRegistros.Name = "MenuAuditRegistros";
            this.MenuAuditRegistros.Size = new System.Drawing.Size(159, 22);
            this.MenuAuditRegistros.Text = "Registros Sistema";
            this.MenuAuditRegistros.Click += new System.EventHandler(this.RegistrosToolStripMenuItemClick);
            // 
            // Menu_Transacoes
            // 
            this.Menu_Transacoes.Name = "Menu_Transacoes";
            this.Menu_Transacoes.Size = new System.Drawing.Size(159, 22);
            this.Menu_Transacoes.Text = "Transações";
            this.Menu_Transacoes.Click += new System.EventHandler(this.TransaçõesToolStripMenuItemClick);
            // 
            // MenuHelpDesk
            // 
            this.MenuHelpDesk.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoChamadoToolStripMenuItem});
            this.MenuHelpDesk.Name = "MenuHelpDesk";
            this.MenuHelpDesk.Size = new System.Drawing.Size(66, 20);
            this.MenuHelpDesk.Text = "Help Desk";
            // 
            // novoChamadoToolStripMenuItem
            // 
            this.novoChamadoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pesquisarToolStripMenuItem,
            this.novoToolStripMenuItem});
            this.novoChamadoToolStripMenuItem.Name = "novoChamadoToolStripMenuItem";
            this.novoChamadoToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.novoChamadoToolStripMenuItem.Text = "Chamados";
            // 
            // pesquisarToolStripMenuItem
            // 
            this.pesquisarToolStripMenuItem.Name = "pesquisarToolStripMenuItem";
            this.pesquisarToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.pesquisarToolStripMenuItem.Text = "Pesquisar";
            this.pesquisarToolStripMenuItem.Click += new System.EventHandler(this.PesquisarToolStripMenuItemClick);
            // 
            // novoToolStripMenuItem
            // 
            this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
            this.novoToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.novoToolStripMenuItem.Text = "Novo";
            this.novoToolStripMenuItem.Click += new System.EventHandler(this.NovoToolStripMenuItemClick);
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.Maroon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(604, 276);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.LblNivel);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 171);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConveyNET - OLD SHOOL Way of Dev";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

}
		public System.Windows.Forms.ToolStripMenuItem cotaExtraToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem Menu_MensPais;
		public System.Windows.Forms.ToolStripMenuItem Menu_RemNovosCartoes;
		public System.Windows.Forms.ToolStripMenuItem Menu_Graficos;
		public System.Windows.Forms.ToolStripMenuItem Menu_ReimpGift;
		private System.Windows.Forms.ToolStripMenuItem relatórioDeTarifasAoClienteToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem Menu_EfetuaVendaLojista;
		public System.Windows.Forms.ToolStripMenuItem Menu_Lojistas;
		public System.Windows.Forms.ToolStripMenuItem Menu_Fat_RecManual;
		public System.Windows.Forms.ToolStripMenuItem Menu_ResPend;
		public System.Windows.Forms.ToolStripMenuItem Menu_Transacoes;
		public System.Windows.Forms.ToolStripMenuItem Menu_NovoDependente;
		public System.Windows.Forms.ToolStripMenuItem Menu_EfetuaVenda;
		public System.Windows.Forms.ToolStripMenuItem Menu_CancelaVenda;
		public System.Windows.Forms.ToolStripMenuItem Menu_ConfRepasse;
		public System.Windows.Forms.ToolStripMenuItem Menu_ChequesGift;
		public System.Windows.Forms.ToolStripMenuItem Menu_ConsultaGiftCard;
		public System.Windows.Forms.ToolStripMenuItem Menu_RecargaGift;
		public System.Windows.Forms.ToolStripMenuItem Menu_LibGift;
		public System.Windows.Forms.ToolStripMenuItem Menu_Quiosques;
		public System.Windows.Forms.ToolStripMenuItem Menu_SegundaViaCartao;
		public System.Windows.Forms.ToolStripMenuItem Menu_DadosCadCartao;
		public System.Windows.Forms.ToolStripMenuItem Menu_ProdExtra;
		public System.Windows.Forms.ToolStripMenuItem MenuHelpDesk;
		public System.Windows.Forms.ToolStripMenuItem MenuAuditRegistros;
		private System.Windows.Forms.ToolStripMenuItem pesquisarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem novoChamadoToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem MenuConsPendFat;
		public System.Windows.Forms.ToolStripMenuItem MenuRelatoriosFat;
		public System.Windows.Forms.ToolStripMenuItem MenuReceberArquivoBan;
		public System.Windows.Forms.ToolStripMenuItem MenuGerarArquivoBan;
		public System.Windows.Forms.ToolStripMenuItem Menu_HabilitarCartao;
		public System.Windows.Forms.ToolStripMenuItem Menu_Relatorios;
		public System.Windows.Forms.ToolStripMenuItem MenuFaturamento;
		private System.Windows.Forms.ToolStripMenuItem FatcancelamentoToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem FatcadastroToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem extraToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem Menu_LojConv;
		public System.Windows.Forms.ToolStripMenuItem Menu_LojManut;
		public System.Windows.Forms.ToolStripMenuItem Menu_LojCad;
		private System.Windows.Forms.ToolStripMenuItem administradorasToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem emitirNovoCartãoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cancelarCartãoToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem Menu_ConfirmarCartao;
		public System.Windows.Forms.ToolStripMenuItem Menu_Expedição;
		public System.Windows.Forms.ToolStripMenuItem Menu_EduManut;
		public System.Windows.Forms.ToolStripMenuItem Menu_CriarPayFone;
		public System.Windows.Forms.ToolStripMenuItem Menu_Operacoes;
		public System.Windows.Forms.ToolStripMenuItem Menu_PayFone;
		public System.Windows.Forms.ToolStripMenuItem Menu_VendaCartao;
		public System.Windows.Forms.ToolStripMenuItem Menu_Agendamento;
		public System.Windows.Forms.ToolStripMenuItem Menu_Auditoria;
		public System.Windows.Forms.ToolStripMenuItem Menu_Educacional;
		public System.Windows.Forms.ToolStripMenuItem Menu_Cartoes;
		public System.Windows.Forms.ToolStripMenuItem Menu_CriarNovo;
		public System.Windows.Forms.ToolStripMenuItem MenuAlterarLimites;
		public System.Windows.Forms.ToolStripMenuItem Menu_AlterarSenha;
		public System.Windows.Forms.ToolStripMenuItem Menu_ConsultaCartao;
		public System.Windows.Forms.ToolStripMenuItem Menu_Cadastro;
		public System.Windows.Forms.ToolStripMenuItem Menu_Empresas;
		public System.Windows.Forms.ToolStripMenuItem Menu_Lojas;
		public System.Windows.Forms.ToolStripMenuItem Menu_Terminais;
		public System.Windows.Forms.ToolStripMenuItem Menu_Usuarios;
		public System.Windows.Forms.ToolStripMenuItem Menu_Bloqueio;
		public System.Windows.Forms.ToolStripMenuItem Menu_Desbloqueio;
		public System.Windows.Forms.ToolStripMenuItem Menu_Opcoes;
		public System.Windows.Forms.ToolStripMenuItem Menu_Sair;
		public System.Windows.Forms.ToolStripMenuItem Menu_TrocarSenha;
		
		public System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem4;
		public System.Windows.Forms.ToolStripMenuItem cancelaVendaToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem autorizaVendaToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem cancelaPendênciaToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem verificaPendênciaToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem gravarPendênciaToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem manutençãoToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem1;
		public System.Windows.Forms.ToolStripMenuItem manutençãoToolStripMenuItem3;
		public System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem1;
		public System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem2;
		public System.Windows.Forms.ToolStripMenuItem manutençãoToolStripMenuItem2;
		public System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem3;
		public System.Windows.Forms.ToolStripMenuItem lojistaToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
		public System.Windows.Forms.MenuStrip menuStrip1;
		public System.Windows.Forms.Label LblNivel;
		public System.Windows.Forms.Label LblVersion;
	}
}
