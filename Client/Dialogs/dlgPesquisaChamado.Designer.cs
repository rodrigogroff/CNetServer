using System.Windows.Forms;

namespace Client 
{
	partial class dlgPesquisaChamado : Form
	{
		private System.ComponentModel.IContainer components = null;
		
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
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtLoja = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.CboSit = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.CboOpers = new System.Windows.Forms.ComboBox();
			this.LstChamados = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.TxtDtAbIni = new System.Windows.Forms.TextBox();
			this.TxtDtAbFim = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.CboPrioridade = new System.Windows.Forms.ComboBox();
			this.CboCateg = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.TxtDtFechFim = new System.Windows.Forms.TextBox();
			this.TxtDtFechIni = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.BtnProcurar = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.TxtCNPJ = new System.Windows.Forms.TextBox();
			this.ChkTecnico = new System.Windows.Forms.CheckBox();
			this.label12 = new System.Windows.Forms.Label();
			this.CboResp = new System.Windows.Forms.ComboBox();
			this.BtnReport = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(369, 19);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.ReadOnly = true;
			this.TxtNome.Size = new System.Drawing.Size(179, 20);
			this.TxtNome.TabIndex = 12;
			this.TxtNome.TabStop = false;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(306, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 11;
			this.label4.Text = "Nome";
			// 
			// TxtLoja
			// 
			this.TxtLoja.Location = new System.Drawing.Point(139, 19);
			this.TxtLoja.Name = "TxtLoja";
			this.TxtLoja.Size = new System.Drawing.Size(141, 20);
			this.TxtLoja.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(22, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 9;
			this.label1.Text = "Cód. Loja";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(22, 84);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 13;
			this.label2.Text = "Situação";
			// 
			// CboSit
			// 
			this.CboSit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboSit.FormattingEnabled = true;
			this.CboSit.Items.AddRange(new object[] {
									"Abertos",
									"Fechados"});
			this.CboSit.Location = new System.Drawing.Point(139, 81);
			this.CboSit.Name = "CboSit";
			this.CboSit.Size = new System.Drawing.Size(141, 21);
			this.CboSit.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(22, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 15;
			this.label3.Text = "Operador Atual";
			// 
			// CboOpers
			// 
			this.CboOpers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboOpers.FormattingEnabled = true;
			this.CboOpers.Items.AddRange(new object[] {
									"Abertos",
									"Fechados"});
			this.CboOpers.Location = new System.Drawing.Point(139, 109);
			this.CboOpers.Name = "CboOpers";
			this.CboOpers.Size = new System.Drawing.Size(141, 21);
			this.CboOpers.TabIndex = 3;
			// 
			// LstChamados
			// 
			this.LstChamados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader5,
									this.columnHeader2,
									this.columnHeader4});
			this.LstChamados.FullRowSelect = true;
			this.LstChamados.Location = new System.Drawing.Point(22, 271);
			this.LstChamados.Name = "LstChamados";
			this.LstChamados.Size = new System.Drawing.Size(526, 222);
			this.LstChamados.TabIndex = 13;
			this.LstChamados.UseCompatibleStateImageBehavior = false;
			this.LstChamados.View = System.Windows.Forms.View.Details;
			this.LstChamados.DoubleClick += new System.EventHandler(this.LstChamadosDoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Dt. Abertura";
			this.columnHeader1.Width = 130;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Dt. Fechamento";
			this.columnHeader5.Width = 130;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Operador (Resp.)";
			this.columnHeader2.Width = 120;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Descrição";
			this.columnHeader4.Width = 110;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(306, 84);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(128, 23);
			this.label5.TabIndex = 18;
			this.label5.Text = "Dt. Inicial para abertura";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(306, 112);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(128, 23);
			this.label6.TabIndex = 19;
			this.label6.Text = "Dt. Final para abertura";
			// 
			// TxtDtAbIni
			// 
			this.TxtDtAbIni.Location = new System.Drawing.Point(461, 81);
			this.TxtDtAbIni.Name = "TxtDtAbIni";
			this.TxtDtAbIni.Size = new System.Drawing.Size(87, 20);
			this.TxtDtAbIni.TabIndex = 7;
			// 
			// TxtDtAbFim
			// 
			this.TxtDtAbFim.Location = new System.Drawing.Point(461, 109);
			this.TxtDtAbFim.Name = "TxtDtAbFim";
			this.TxtDtAbFim.Size = new System.Drawing.Size(87, 20);
			this.TxtDtAbFim.TabIndex = 8;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(22, 140);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 22;
			this.label7.Text = "Prioridade";
			// 
			// CboPrioridade
			// 
			this.CboPrioridade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboPrioridade.FormattingEnabled = true;
			this.CboPrioridade.Items.AddRange(new object[] {
									"(Todos)",
									"Urgente",
									"Alta",
									"Média",
									"Baixa",
									"Nenhuma"});
			this.CboPrioridade.Location = new System.Drawing.Point(139, 137);
			this.CboPrioridade.Name = "CboPrioridade";
			this.CboPrioridade.Size = new System.Drawing.Size(141, 21);
			this.CboPrioridade.TabIndex = 4;
			// 
			// CboCateg
			// 
			this.CboCateg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboCateg.FormattingEnabled = true;
			this.CboCateg.Items.AddRange(new object[] {
									"(Todos)",
									"Área Comercial - REME",
									"Atualização VNC",
									"Cancelamento de Transações",
									"Conexão",
									"Conexão (Fatura)",
									"Conexão 0800",
									"Expedição",
									"Hardware",
									"Hardware (Fatura)",
									"Impressora",
									"Instalação",
									"Instalação ADSL",
									"Liberação de Contrato",
									"Pendência",
									"Pendência de Cliente",
									"Pós-Atendimento",
									"Pré-Instalação",
									"Reinstalação",
									"Reinstalação (Fatura)",
									"Retreinamento",
									"Retreinamento (Fatura)",
									"Software (Fatura)",
									"Software - Atualização",
									"Substituição de Equipamento",
									"Transação",
									"Treinamento",
									"Usuário Intranet",
									"Usuário Net"});
			this.CboCateg.Location = new System.Drawing.Point(139, 165);
			this.CboCateg.Name = "CboCateg";
			this.CboCateg.Size = new System.Drawing.Size(141, 21);
			this.CboCateg.TabIndex = 5;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(22, 168);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 23);
			this.label8.TabIndex = 24;
			this.label8.Text = "Categoria";
			// 
			// TxtDtFechFim
			// 
			this.TxtDtFechFim.Location = new System.Drawing.Point(461, 165);
			this.TxtDtFechFim.Name = "TxtDtFechFim";
			this.TxtDtFechFim.Size = new System.Drawing.Size(87, 20);
			this.TxtDtFechFim.TabIndex = 10;
			// 
			// TxtDtFechIni
			// 
			this.TxtDtFechIni.Location = new System.Drawing.Point(461, 137);
			this.TxtDtFechIni.Name = "TxtDtFechIni";
			this.TxtDtFechIni.Size = new System.Drawing.Size(87, 20);
			this.TxtDtFechIni.TabIndex = 9;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(306, 168);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(149, 23);
			this.label9.TabIndex = 27;
			this.label9.Text = "Dt. Final para fechamento";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(306, 140);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(149, 23);
			this.label10.TabIndex = 26;
			this.label10.Text = "Dt. Inicial para fechamento";
			// 
			// BtnProcurar
			// 
			this.BtnProcurar.Location = new System.Drawing.Point(22, 233);
			this.BtnProcurar.Name = "BtnProcurar";
			this.BtnProcurar.Size = new System.Drawing.Size(75, 23);
			this.BtnProcurar.TabIndex = 12;
			this.BtnProcurar.Text = "Procurar";
			this.BtnProcurar.UseVisualStyleBackColor = true;
			this.BtnProcurar.Click += new System.EventHandler(this.BtnProcurarClick);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(22, 45);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(100, 23);
			this.label11.TabIndex = 31;
			this.label11.Text = "CNPJ Loja";
			// 
			// TxtCNPJ
			// 
			this.TxtCNPJ.Location = new System.Drawing.Point(139, 42);
			this.TxtCNPJ.Name = "TxtCNPJ";
			this.TxtCNPJ.Size = new System.Drawing.Size(141, 20);
			this.TxtCNPJ.TabIndex = 1;
			// 
			// ChkTecnico
			// 
			this.ChkTecnico.Location = new System.Drawing.Point(306, 191);
			this.ChkTecnico.Name = "ChkTecnico";
			this.ChkTecnico.Size = new System.Drawing.Size(130, 24);
			this.ChkTecnico.TabIndex = 11;
			this.ChkTecnico.Text = "Requer visita técnica";
			this.ChkTecnico.UseVisualStyleBackColor = true;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(22, 196);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(100, 23);
			this.label12.TabIndex = 32;
			this.label12.Text = "Responsável";
			// 
			// CboResp
			// 
			this.CboResp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboResp.FormattingEnabled = true;
			this.CboResp.Location = new System.Drawing.Point(139, 193);
			this.CboResp.Name = "CboResp";
			this.CboResp.Size = new System.Drawing.Size(141, 21);
			this.CboResp.TabIndex = 6;
			// 
			// BtnReport
			// 
			this.BtnReport.Location = new System.Drawing.Point(429, 499);
			this.BtnReport.Name = "BtnReport";
			this.BtnReport.Size = new System.Drawing.Size(119, 23);
			this.BtnReport.TabIndex = 33;
			this.BtnReport.Text = "Relatório";
			this.BtnReport.UseVisualStyleBackColor = true;
			this.BtnReport.Click += new System.EventHandler(this.BtnReportClick);
			// 
			// dlgPesquisaChamado
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(574, 539);
			this.Controls.Add(this.BtnReport);
			this.Controls.Add(this.CboResp);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.ChkTecnico);
			this.Controls.Add(this.TxtCNPJ);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.BtnProcurar);
			this.Controls.Add(this.TxtDtFechFim);
			this.Controls.Add(this.TxtDtFechIni);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.CboCateg);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.CboPrioridade);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.TxtDtAbFim);
			this.Controls.Add(this.TxtDtAbIni);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.LstChamados);
			this.Controls.Add(this.CboOpers);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.CboSit);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TxtNome);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.TxtLoja);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgPesquisaChamado";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Pesquisa de Chamados";
			this.Load += new System.EventHandler(this.DlgPesquisaChamadoLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.Button BtnReport;
		public System.Windows.Forms.ComboBox CboResp;
		public System.Windows.Forms.Label label12;
		public System.Windows.Forms.ComboBox CboPrioridade;
		public System.Windows.Forms.CheckBox ChkTecnico;
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.TextBox TxtCNPJ;
		public System.Windows.Forms.Label label11;
		public System.Windows.Forms.Button BtnProcurar;
		public System.Windows.Forms.TextBox TxtDtAbIni;
		public System.Windows.Forms.TextBox TxtDtAbFim;
		public System.Windows.Forms.TextBox TxtDtFechFim;
		public System.Windows.Forms.TextBox TxtDtFechIni;
		public System.Windows.Forms.ColumnHeader columnHeader5;
		public System.Windows.Forms.Label label10;
		public System.Windows.Forms.Label label9;
		public System.Windows.Forms.Label label8;
		public System.Windows.Forms.ComboBox CboCateg;
		public System.Windows.Forms.Label label7;
		public System.Windows.Forms.Label label6;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.ColumnHeader columnHeader4;
		public System.Windows.Forms.ColumnHeader columnHeader2;
		public System.Windows.Forms.ColumnHeader columnHeader1;
		public System.Windows.Forms.ListView LstChamados;
		public System.Windows.Forms.ComboBox CboOpers;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.ComboBox CboSit;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox TxtLoja;
		public System.Windows.Forms.Label label4;
	}
}

