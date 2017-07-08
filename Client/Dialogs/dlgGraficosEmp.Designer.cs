using System.Windows.Forms;

namespace Client 
{
	partial class dlgGraficosEmp : Form
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.CboGraph = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.CboTipo = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.BtnRemover = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.BtnGrafico = new System.Windows.Forms.Button();
			this.TxtEmpresa = new System.Windows.Forms.TextBox();
			this.LstLines = new System.Windows.Forms.ListView();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.TxtCodLoja = new System.Windows.Forms.TextBox();
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.BtnAdicionar = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.BtnBuscarLista = new System.Windows.Forms.Button();
			this.BtnGeraTrans = new System.Windows.Forms.Button();
			this.LstTransLojas = new System.Windows.Forms.ListView();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.label8 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.BtnRanking = new System.Windows.Forms.Button();
			this.LstRanking = new System.Windows.Forms.ListBox();
			this.label9 = new System.Windows.Forms.Label();
			this.TxtDtFim = new System.Windows.Forms.TextBox();
			this.TxtDtIni = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new System.Drawing.Point(12, 51);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(462, 342);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.CboGraph);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.CboTipo);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.BtnRemover);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.BtnGrafico);
			this.tabPage1.Controls.Add(this.TxtEmpresa);
			this.tabPage1.Controls.Add(this.LstLines);
			this.tabPage1.Controls.Add(this.TxtCodLoja);
			this.tabPage1.Controls.Add(this.TxtNome);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.BtnAdicionar);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(454, 316);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Financeiro Lojas";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// CboGraph
			// 
			this.CboGraph.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboGraph.FormattingEnabled = true;
			this.CboGraph.Items.AddRange(new object[] {
									"Barras",
									"Curvas"});
			this.CboGraph.Location = new System.Drawing.Point(131, 281);
			this.CboGraph.Name = "CboGraph";
			this.CboGraph.Size = new System.Drawing.Size(94, 21);
			this.CboGraph.TabIndex = 103;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(19, 281);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 102;
			this.label7.Text = "Tipo de gráfico";
			// 
			// CboTipo
			// 
			this.CboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboTipo.FormattingEnabled = true;
			this.CboTipo.Items.AddRange(new object[] {
									"Variável",
									"Acumulado"});
			this.CboTipo.Location = new System.Drawing.Point(131, 253);
			this.CboTipo.Name = "CboTipo";
			this.CboTipo.Size = new System.Drawing.Size(94, 21);
			this.CboTipo.TabIndex = 101;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(19, 256);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 100;
			this.label6.Text = "Tipo de operação";
			// 
			// BtnRemover
			// 
			this.BtnRemover.Location = new System.Drawing.Point(362, 82);
			this.BtnRemover.Name = "BtnRemover";
			this.BtnRemover.Size = new System.Drawing.Size(75, 23);
			this.BtnRemover.TabIndex = 6;
			this.BtnRemover.Text = "Remover";
			this.BtnRemover.UseVisualStyleBackColor = true;
			this.BtnRemover.Click += new System.EventHandler(this.BtnRemoverClick);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(19, 28);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Cód. Loja";
			// 
			// BtnGrafico
			// 
			this.BtnGrafico.Location = new System.Drawing.Point(337, 251);
			this.BtnGrafico.Name = "BtnGrafico";
			this.BtnGrafico.Size = new System.Drawing.Size(100, 23);
			this.BtnGrafico.TabIndex = 5;
			this.BtnGrafico.Text = "Gerar Gráfico";
			this.BtnGrafico.UseVisualStyleBackColor = true;
			this.BtnGrafico.Click += new System.EventHandler(this.BtnGraficoClick);
			// 
			// TxtEmpresa
			// 
			this.TxtEmpresa.Location = new System.Drawing.Point(337, 25);
			this.TxtEmpresa.Name = "TxtEmpresa";
			this.TxtEmpresa.Size = new System.Drawing.Size(100, 20);
			this.TxtEmpresa.TabIndex = 3;
			// 
			// LstLines
			// 
			this.LstLines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader5,
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3});
			this.LstLines.FullRowSelect = true;
			this.LstLines.GridLines = true;
			this.LstLines.Location = new System.Drawing.Point(19, 120);
			this.LstLines.Name = "LstLines";
			this.LstLines.Size = new System.Drawing.Size(418, 111);
			this.LstLines.TabIndex = 99;
			this.LstLines.TabStop = false;
			this.LstLines.UseCompatibleStateImageBehavior = false;
			this.LstLines.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Empresa";
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Inicial";
			this.columnHeader1.Width = 90;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Final";
			this.columnHeader2.Width = 90;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Loja";
			this.columnHeader3.Width = 150;
			// 
			// TxtCodLoja
			// 
			this.TxtCodLoja.Location = new System.Drawing.Point(125, 25);
			this.TxtCodLoja.Name = "TxtCodLoja";
			this.TxtCodLoja.Size = new System.Drawing.Size(100, 20);
			this.TxtCodLoja.TabIndex = 2;
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(125, 53);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.ReadOnly = true;
			this.TxtNome.Size = new System.Drawing.Size(312, 20);
			this.TxtNome.TabIndex = 8;
			this.TxtNome.TabStop = false;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(19, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Nome da loja";
			// 
			// BtnAdicionar
			// 
			this.BtnAdicionar.Location = new System.Drawing.Point(19, 82);
			this.BtnAdicionar.Name = "BtnAdicionar";
			this.BtnAdicionar.Size = new System.Drawing.Size(75, 23);
			this.BtnAdicionar.TabIndex = 4;
			this.BtnAdicionar.Text = "Adicionar";
			this.BtnAdicionar.UseVisualStyleBackColor = true;
			this.BtnAdicionar.Click += new System.EventHandler(this.BtnAdicionarClick);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(252, 28);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 10;
			this.label5.Text = "Cód. Empresa";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.BtnBuscarLista);
			this.tabPage2.Controls.Add(this.BtnGeraTrans);
			this.tabPage2.Controls.Add(this.LstTransLojas);
			this.tabPage2.Controls.Add(this.label8);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(454, 316);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Transações";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// BtnBuscarLista
			// 
			this.BtnBuscarLista.Location = new System.Drawing.Point(337, 10);
			this.BtnBuscarLista.Name = "BtnBuscarLista";
			this.BtnBuscarLista.Size = new System.Drawing.Size(100, 23);
			this.BtnBuscarLista.TabIndex = 3;
			this.BtnBuscarLista.Text = "Buscar Lista";
			this.BtnBuscarLista.UseVisualStyleBackColor = true;
			this.BtnBuscarLista.Click += new System.EventHandler(this.BtnBuscarListaClick);
			// 
			// BtnGeraTrans
			// 
			this.BtnGeraTrans.Location = new System.Drawing.Point(337, 284);
			this.BtnGeraTrans.Name = "BtnGeraTrans";
			this.BtnGeraTrans.Size = new System.Drawing.Size(100, 23);
			this.BtnGeraTrans.TabIndex = 2;
			this.BtnGeraTrans.Text = "Gerar Gráfico";
			this.BtnGeraTrans.UseVisualStyleBackColor = true;
			this.BtnGeraTrans.Click += new System.EventHandler(this.BtnGeraTransClick);
			// 
			// LstTransLojas
			// 
			this.LstTransLojas.CheckBoxes = true;
			this.LstTransLojas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader8,
									this.columnHeader4,
									this.columnHeader6,
									this.columnHeader7});
			this.LstTransLojas.FullRowSelect = true;
			this.LstTransLojas.HideSelection = false;
			this.LstTransLojas.Location = new System.Drawing.Point(22, 39);
			this.LstTransLojas.MultiSelect = false;
			this.LstTransLojas.Name = "LstTransLojas";
			this.LstTransLojas.Size = new System.Drawing.Size(415, 236);
			this.LstTransLojas.TabIndex = 0;
			this.LstTransLojas.UseCompatibleStateImageBehavior = false;
			this.LstTransLojas.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Transações";
			this.columnHeader8.Width = 80;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Código";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Tipo";
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Nome";
			this.columnHeader7.Width = 180;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(22, 21);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(203, 23);
			this.label8.TabIndex = 1;
			this.label8.Text = "Lista completa de empresas e lojas";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.BtnRanking);
			this.tabPage3.Controls.Add(this.LstRanking);
			this.tabPage3.Controls.Add(this.label9);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(454, 316);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Ranking";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// BtnRanking
			// 
			this.BtnRanking.Location = new System.Drawing.Point(30, 216);
			this.BtnRanking.Name = "BtnRanking";
			this.BtnRanking.Size = new System.Drawing.Size(100, 23);
			this.BtnRanking.TabIndex = 3;
			this.BtnRanking.Text = "Gerar Gráfico";
			this.BtnRanking.UseVisualStyleBackColor = true;
			this.BtnRanking.Click += new System.EventHandler(this.BtnRankingClick);
			// 
			// LstRanking
			// 
			this.LstRanking.FormattingEnabled = true;
			this.LstRanking.Items.AddRange(new object[] {
									"Melhores 5 associações em desempenho financeiro",
									"Melhores 5 estabelecimentos em quantidade de transações",
									""});
			this.LstRanking.Location = new System.Drawing.Point(30, 40);
			this.LstRanking.Name = "LstRanking";
			this.LstRanking.Size = new System.Drawing.Size(336, 160);
			this.LstRanking.TabIndex = 1;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(27, 21);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(149, 23);
			this.label9.TabIndex = 0;
			this.label9.Text = "Escolha a categoria";
			// 
			// TxtDtFim
			// 
			this.TxtDtFim.Location = new System.Drawing.Point(353, 17);
			this.TxtDtFim.Name = "TxtDtFim";
			this.TxtDtFim.Size = new System.Drawing.Size(100, 20);
			this.TxtDtFim.TabIndex = 1;
			// 
			// TxtDtIni
			// 
			this.TxtDtIni.Location = new System.Drawing.Point(141, 17);
			this.TxtDtIni.Name = "TxtDtIni";
			this.TxtDtIni.Size = new System.Drawing.Size(100, 20);
			this.TxtDtIni.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(268, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Período Final";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(23, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Período Inicial";
			// 
			// dlgGraficosEmp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(489, 405);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.TxtDtFim);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TxtDtIni);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgGraficosEmp";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Gráficos de performance";
			this.Load += new System.EventHandler(this.DlgGraficosEmpLoad);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.Button BtnRanking;
		private System.Windows.Forms.ListBox LstRanking;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TabPage tabPage3;
		public System.Windows.Forms.Button BtnBuscarLista;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		public System.Windows.Forms.Button BtnGeraTrans;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		public System.Windows.Forms.ListView LstTransLojas;
		public System.Windows.Forms.ComboBox CboGraph;
		public System.Windows.Forms.Label label7;
		public System.Windows.Forms.ComboBox CboTipo;
		public System.Windows.Forms.Label label6;
		public System.Windows.Forms.Button BtnRemover;
		public System.Windows.Forms.TextBox TxtEmpresa;
		public System.Windows.Forms.ListView LstLines;
		public System.Windows.Forms.ColumnHeader columnHeader5;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.ColumnHeader columnHeader3;
		public System.Windows.Forms.ColumnHeader columnHeader2;
		public System.Windows.Forms.ColumnHeader columnHeader1;
		public System.Windows.Forms.TextBox TxtCodLoja;
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox TxtDtIni;
		public System.Windows.Forms.TextBox TxtDtFim;
		public System.Windows.Forms.Button BtnAdicionar;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.Button BtnGrafico;
		public System.Windows.Forms.TabPage tabPage2;
		public System.Windows.Forms.TabPage tabPage1;
		public System.Windows.Forms.TabControl tabControl1;
	}
}

