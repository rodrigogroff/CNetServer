using System.Windows.Forms;

namespace Client 
{
	partial class dlgConsultaTransacoes : Form
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
			this.TxtNSU = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage10 = new System.Windows.Forms.TabPage();
			this.TxtTelefone = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.tabPage9 = new System.Windows.Forms.TabPage();
			this.TxtCartao = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tabPage8 = new System.Windows.Forms.TabPage();
			this.TxtDataFim = new System.Windows.Forms.TextBox();
			this.TxtDataIni = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.TxtCodEmpresa = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.TxtCNPJLoja = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.TxtTerminal = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.TxtValor = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.TxtParcelas = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tabPage7 = new System.Windows.Forms.TabPage();
			this.CboOper = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tabPage11 = new System.Windows.Forms.TabPage();
			this.CboStat = new System.Windows.Forms.ComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.BtnConsultar = new System.Windows.Forms.Button();
			this.LstTrans = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.label13 = new System.Windows.Forms.Label();
			this.TxtCodLoja = new System.Windows.Forms.TextBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage10.SuspendLayout();
			this.tabPage9.SuspendLayout();
			this.tabPage8.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage7.SuspendLayout();
			this.tabPage11.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage10);
			this.tabControl1.Controls.Add(this.tabPage9);
			this.tabControl1.Controls.Add(this.tabPage8);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage6);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Controls.Add(this.tabPage7);
			this.tabControl1.Controls.Add(this.tabPage11);
			this.tabControl1.Location = new System.Drawing.Point(21, 18);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(720, 94);
			this.tabControl1.TabIndex = 4;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.TxtNSU);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(712, 68);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "NSU";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// TxtNSU
			// 
			this.TxtNSU.Location = new System.Drawing.Point(123, 25);
			this.TxtNSU.Name = "TxtNSU";
			this.TxtNSU.Size = new System.Drawing.Size(87, 20);
			this.TxtNSU.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(17, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Informe o NSU";
			// 
			// tabPage10
			// 
			this.tabPage10.Controls.Add(this.TxtTelefone);
			this.tabPage10.Controls.Add(this.label11);
			this.tabPage10.Location = new System.Drawing.Point(4, 22);
			this.tabPage10.Name = "tabPage10";
			this.tabPage10.Size = new System.Drawing.Size(712, 68);
			this.tabPage10.TabIndex = 9;
			this.tabPage10.Text = "PayFone";
			this.tabPage10.UseVisualStyleBackColor = true;
			// 
			// TxtTelefone
			// 
			this.TxtTelefone.Location = new System.Drawing.Point(122, 20);
			this.TxtTelefone.Name = "TxtTelefone";
			this.TxtTelefone.Size = new System.Drawing.Size(142, 20);
			this.TxtTelefone.TabIndex = 8;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(16, 23);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(100, 23);
			this.label11.TabIndex = 7;
			this.label11.Text = "Telefone";
			// 
			// tabPage9
			// 
			this.tabPage9.Controls.Add(this.TxtCartao);
			this.tabPage9.Controls.Add(this.label10);
			this.tabPage9.Location = new System.Drawing.Point(4, 22);
			this.tabPage9.Name = "tabPage9";
			this.tabPage9.Size = new System.Drawing.Size(712, 68);
			this.tabPage9.TabIndex = 8;
			this.tabPage9.Text = "Cartão";
			this.tabPage9.UseVisualStyleBackColor = true;
			// 
			// TxtCartao
			// 
			this.TxtCartao.Location = new System.Drawing.Point(124, 19);
			this.TxtCartao.Name = "TxtCartao";
			this.TxtCartao.Size = new System.Drawing.Size(142, 20);
			this.TxtCartao.TabIndex = 6;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(18, 22);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 23);
			this.label10.TabIndex = 5;
			this.label10.Text = "Matricula";
			// 
			// tabPage8
			// 
			this.tabPage8.Controls.Add(this.TxtDataFim);
			this.tabPage8.Controls.Add(this.TxtDataIni);
			this.tabPage8.Controls.Add(this.label6);
			this.tabPage8.Controls.Add(this.label9);
			this.tabPage8.Location = new System.Drawing.Point(4, 22);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Size = new System.Drawing.Size(712, 68);
			this.tabPage8.TabIndex = 7;
			this.tabPage8.Text = "Período";
			this.tabPage8.UseVisualStyleBackColor = true;
			// 
			// TxtDataFim
			// 
			this.TxtDataFim.Location = new System.Drawing.Point(281, 22);
			this.TxtDataFim.Name = "TxtDataFim";
			this.TxtDataFim.Size = new System.Drawing.Size(87, 20);
			this.TxtDataFim.TabIndex = 5;
			// 
			// TxtDataIni
			// 
			this.TxtDataIni.Location = new System.Drawing.Point(101, 22);
			this.TxtDataIni.Name = "TxtDataIni";
			this.TxtDataIni.Size = new System.Drawing.Size(87, 20);
			this.TxtDataIni.TabIndex = 4;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(21, 25);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 0;
			this.label6.Text = "Data Inicial";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(209, 25);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 23);
			this.label9.TabIndex = 6;
			this.label9.Text = "Data Final";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.TxtCodEmpresa);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(712, 68);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Empresa";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// TxtCodEmpresa
			// 
			this.TxtCodEmpresa.Location = new System.Drawing.Point(127, 22);
			this.TxtCodEmpresa.Name = "TxtCodEmpresa";
			this.TxtCodEmpresa.Size = new System.Drawing.Size(144, 20);
			this.TxtCodEmpresa.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(21, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Cód. da Empresa";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.TxtCodLoja);
			this.tabPage3.Controls.Add(this.label13);
			this.tabPage3.Controls.Add(this.TxtCNPJLoja);
			this.tabPage3.Controls.Add(this.label3);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(712, 68);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Loja";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// TxtCNPJLoja
			// 
			this.TxtCNPJLoja.Location = new System.Drawing.Point(123, 15);
			this.TxtCNPJLoja.Name = "TxtCNPJLoja";
			this.TxtCNPJLoja.Size = new System.Drawing.Size(144, 20);
			this.TxtCNPJLoja.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(17, 18);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "CNPJ da Loja";
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.TxtTerminal);
			this.tabPage4.Controls.Add(this.label4);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(712, 68);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Terminal";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// TxtTerminal
			// 
			this.TxtTerminal.Location = new System.Drawing.Point(123, 25);
			this.TxtTerminal.Name = "TxtTerminal";
			this.TxtTerminal.Size = new System.Drawing.Size(144, 20);
			this.TxtTerminal.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(17, 28);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 2;
			this.label4.Text = "Código do Terminal";
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.TxtValor);
			this.tabPage6.Controls.Add(this.label7);
			this.tabPage6.Location = new System.Drawing.Point(4, 22);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Size = new System.Drawing.Size(712, 68);
			this.tabPage6.TabIndex = 5;
			this.tabPage6.Text = "Valor";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// TxtValor
			// 
			this.TxtValor.Location = new System.Drawing.Point(123, 25);
			this.TxtValor.Name = "TxtValor";
			this.TxtValor.Size = new System.Drawing.Size(109, 20);
			this.TxtValor.TabIndex = 4;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(17, 28);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(160, 23);
			this.label7.TabIndex = 3;
			this.label7.Text = "Valor Total";
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.TxtParcelas);
			this.tabPage5.Controls.Add(this.label5);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(712, 68);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Parcelas";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// TxtParcelas
			// 
			this.TxtParcelas.Location = new System.Drawing.Point(183, 25);
			this.TxtParcelas.Name = "TxtParcelas";
			this.TxtParcelas.Size = new System.Drawing.Size(69, 20);
			this.TxtParcelas.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(17, 28);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(160, 23);
			this.label5.TabIndex = 2;
			this.label5.Text = "Número mínimo de parcelas";
			// 
			// tabPage7
			// 
			this.tabPage7.Controls.Add(this.CboOper);
			this.tabPage7.Controls.Add(this.label8);
			this.tabPage7.Location = new System.Drawing.Point(4, 22);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Size = new System.Drawing.Size(712, 68);
			this.tabPage7.TabIndex = 6;
			this.tabPage7.Text = "Operação";
			this.tabPage7.UseVisualStyleBackColor = true;
			// 
			// CboOper
			// 
			this.CboOper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboOper.FormattingEnabled = true;
			this.CboOper.Location = new System.Drawing.Point(171, 25);
			this.CboOper.Name = "CboOper";
			this.CboOper.Size = new System.Drawing.Size(249, 21);
			this.CboOper.TabIndex = 5;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(17, 28);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(160, 23);
			this.label8.TabIndex = 4;
			this.label8.Text = "Filtrar por tipo de operação";
			// 
			// tabPage11
			// 
			this.tabPage11.Controls.Add(this.CboStat);
			this.tabPage11.Controls.Add(this.label12);
			this.tabPage11.Location = new System.Drawing.Point(4, 22);
			this.tabPage11.Name = "tabPage11";
			this.tabPage11.Size = new System.Drawing.Size(712, 68);
			this.tabPage11.TabIndex = 10;
			this.tabPage11.Text = "Status";
			this.tabPage11.UseVisualStyleBackColor = true;
			// 
			// CboStat
			// 
			this.CboStat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboStat.FormattingEnabled = true;
			this.CboStat.Location = new System.Drawing.Point(141, 18);
			this.CboStat.Name = "CboStat";
			this.CboStat.Size = new System.Drawing.Size(121, 21);
			this.CboStat.TabIndex = 1;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(21, 21);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(100, 23);
			this.label12.TabIndex = 0;
			this.label12.Text = "Selecione o status";
			// 
			// BtnConsultar
			// 
			this.BtnConsultar.Location = new System.Drawing.Point(21, 127);
			this.BtnConsultar.Name = "BtnConsultar";
			this.BtnConsultar.Size = new System.Drawing.Size(75, 23);
			this.BtnConsultar.TabIndex = 6;
			this.BtnConsultar.Text = "Consultar";
			this.BtnConsultar.UseVisualStyleBackColor = true;
			this.BtnConsultar.Click += new System.EventHandler(this.BtnConsultarClick);
			// 
			// LstTrans
			// 
			this.LstTrans.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3,
									this.columnHeader4,
									this.columnHeader5,
									this.columnHeader6,
									this.columnHeader7,
									this.columnHeader8,
									this.columnHeader9,
									this.columnHeader10});
			this.LstTrans.FullRowSelect = true;
			this.LstTrans.HideSelection = false;
			this.LstTrans.Location = new System.Drawing.Point(21, 164);
			this.LstTrans.MultiSelect = false;
			this.LstTrans.Name = "LstTrans";
			this.LstTrans.Size = new System.Drawing.Size(889, 205);
			this.LstTrans.TabIndex = 7;
			this.LstTrans.UseCompatibleStateImageBehavior = false;
			this.LstTrans.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "NSU";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Cartão";
			this.columnHeader2.Width = 110;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Loja";
			this.columnHeader3.Width = 110;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Terminal";
			this.columnHeader4.Width = 70;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Valor";
			this.columnHeader5.Width = 70;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Parcelas";
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Data";
			this.columnHeader7.Width = 120;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Operação";
			this.columnHeader8.Width = 90;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Status";
			this.columnHeader9.Width = 80;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Mensagem";
			this.columnHeader10.Width = 90;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(17, 41);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(100, 23);
			this.label13.TabIndex = 4;
			this.label13.Text = "Código da Loja";
			// 
			// TxtCodLoja
			// 
			this.TxtCodLoja.Location = new System.Drawing.Point(123, 38);
			this.TxtCodLoja.Name = "TxtCodLoja";
			this.TxtCodLoja.Size = new System.Drawing.Size(144, 20);
			this.TxtCodLoja.TabIndex = 5;
			// 
			// dlgConsultaTransacoes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(933, 390);
			this.Controls.Add(this.BtnConsultar);
			this.Controls.Add(this.LstTrans);
			this.Controls.Add(this.tabControl1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgConsultaTransacoes";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Consulta de Transações";
			this.Load += new System.EventHandler(this.DlgConsultaTransacoesLoad);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage10.ResumeLayout(false);
			this.tabPage10.PerformLayout();
			this.tabPage9.ResumeLayout(false);
			this.tabPage9.PerformLayout();
			this.tabPage8.ResumeLayout(false);
			this.tabPage8.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			this.tabPage6.ResumeLayout(false);
			this.tabPage6.PerformLayout();
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			this.tabPage7.ResumeLayout(false);
			this.tabPage11.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.TextBox TxtCodLoja;
		public System.Windows.Forms.Label label13;
		public System.Windows.Forms.ComboBox CboStat;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TabPage tabPage11;
		public System.Windows.Forms.TextBox TxtCodEmpresa;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		public System.Windows.Forms.TextBox TxtTelefone;
		public System.Windows.Forms.Label label11;
		private System.Windows.Forms.TabPage tabPage10;
		public System.Windows.Forms.Label label10;
		public System.Windows.Forms.TextBox TxtCartao;
		private System.Windows.Forms.TabPage tabPage9;
		public System.Windows.Forms.TextBox TxtDataFim;
		public System.Windows.Forms.TextBox TxtDataIni;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TabPage tabPage8;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		public System.Windows.Forms.ListView LstTrans;
		public System.Windows.Forms.ComboBox CboOper;
		public System.Windows.Forms.TextBox TxtParcelas;
		public System.Windows.Forms.TextBox TxtValor;
		public System.Windows.Forms.TextBox TxtCNPJLoja;
		public System.Windows.Forms.TextBox TxtTerminal;
		public System.Windows.Forms.ColumnHeader columnHeader7;
		public System.Windows.Forms.ColumnHeader columnHeader6;
		public System.Windows.Forms.ColumnHeader columnHeader5;
		public System.Windows.Forms.ColumnHeader columnHeader4;
		public System.Windows.Forms.ColumnHeader columnHeader3;
		public System.Windows.Forms.ColumnHeader columnHeader2;
		public System.Windows.Forms.ColumnHeader columnHeader1;
		public System.Windows.Forms.Button BtnConsultar;
		public System.Windows.Forms.TextBox TxtNSU;
		public System.Windows.Forms.Label label8;
		public System.Windows.Forms.TabPage tabPage7;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.TabPage tabPage5;
		public System.Windows.Forms.Label label7;
		public System.Windows.Forms.TabPage tabPage6;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.TabPage tabPage4;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.TabPage tabPage3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.TabPage tabPage2;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.TabPage tabPage1;
		public System.Windows.Forms.TabControl tabControl1;
	}
}

