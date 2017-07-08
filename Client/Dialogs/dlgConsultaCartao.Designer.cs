using System.Windows.Forms;

namespace Client 
{
	partial class dlgConsultaCartao : Form
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
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.TxtCpf = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.TxtCartao = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.tabPage7 = new System.Windows.Forms.TabPage();
			this.TxtCNPJ = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtEmpresa = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.TxtCotaExtra = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.TxtLimMensal = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtLimTotal = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.TxtCidade = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.TxtEstado = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.CboSit = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.tabPage8 = new System.Windows.Forms.TabPage();
			this.CboExp = new System.Windows.Forms.ComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.BtnConsultar = new System.Windows.Forms.Button();
			this.LstCartao = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.LblCart = new System.Windows.Forms.Label();
			this.BtnRelatorio = new System.Windows.Forms.Button();
			this.ChkAlfa = new System.Windows.Forms.CheckBox();
			this.BtnExclui = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.tabPage7.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage8.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage6);
			this.tabControl1.Controls.Add(this.tabPage7);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Controls.Add(this.tabPage8);
			this.tabControl1.Location = new System.Drawing.Point(18, 21);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(465, 109);
			this.tabControl1.TabIndex = 3;
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.TxtCpf);
			this.tabPage6.Controls.Add(this.label10);
			this.tabPage6.Controls.Add(this.TxtCartao);
			this.tabPage6.Controls.Add(this.label9);
			this.tabPage6.Location = new System.Drawing.Point(4, 22);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Size = new System.Drawing.Size(457, 83);
			this.tabPage6.TabIndex = 10;
			this.tabPage6.Text = "Cartão";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// TxtCpf
			// 
			this.TxtCpf.Location = new System.Drawing.Point(128, 46);
			this.TxtCpf.Name = "TxtCpf";
			this.TxtCpf.Size = new System.Drawing.Size(142, 20);
			this.TxtCpf.TabIndex = 6;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(22, 49);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 23);
			this.label10.TabIndex = 5;
			this.label10.Text = "CPF ou CNPJ";
			// 
			// TxtCartao
			// 
			this.TxtCartao.Location = new System.Drawing.Point(128, 18);
			this.TxtCartao.Name = "TxtCartao";
			this.TxtCartao.Size = new System.Drawing.Size(142, 20);
			this.TxtCartao.TabIndex = 4;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(22, 21);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 23);
			this.label9.TabIndex = 3;
			this.label9.Text = "Matricula";
			// 
			// tabPage7
			// 
			this.tabPage7.Controls.Add(this.TxtCNPJ);
			this.tabPage7.Controls.Add(this.label3);
			this.tabPage7.Controls.Add(this.TxtEmpresa);
			this.tabPage7.Controls.Add(this.label8);
			this.tabPage7.Location = new System.Drawing.Point(4, 22);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Size = new System.Drawing.Size(457, 83);
			this.tabPage7.TabIndex = 6;
			this.tabPage7.Text = "Empresa";
			this.tabPage7.UseVisualStyleBackColor = true;
			// 
			// TxtCNPJ
			// 
			this.TxtCNPJ.Location = new System.Drawing.Point(123, 48);
			this.TxtCNPJ.Name = "TxtCNPJ";
			this.TxtCNPJ.Size = new System.Drawing.Size(142, 20);
			this.TxtCNPJ.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(17, 51);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 3;
			this.label3.Text = "CNPJ da empresa";
			// 
			// TxtEmpresa
			// 
			this.TxtEmpresa.Location = new System.Drawing.Point(123, 17);
			this.TxtEmpresa.Name = "TxtEmpresa";
			this.TxtEmpresa.Size = new System.Drawing.Size(142, 20);
			this.TxtEmpresa.TabIndex = 1;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(17, 20);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 23);
			this.label8.TabIndex = 2;
			this.label8.Text = "Código da empresa";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.TxtNome);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(457, 83);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Nome";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(123, 25);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.Size = new System.Drawing.Size(144, 20);
			this.TxtNome.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(17, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nome proprietário";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.TxtCotaExtra);
			this.tabPage2.Controls.Add(this.label5);
			this.tabPage2.Controls.Add(this.TxtLimMensal);
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Controls.Add(this.TxtLimTotal);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(457, 83);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Limites";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// TxtCotaExtra
			// 
			this.TxtCotaExtra.Location = new System.Drawing.Point(262, 17);
			this.TxtCotaExtra.Name = "TxtCotaExtra";
			this.TxtCotaExtra.Size = new System.Drawing.Size(78, 20);
			this.TxtCotaExtra.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(196, 20);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 6;
			this.label5.Text = "Cota Extra";
			// 
			// TxtLimMensal
			// 
			this.TxtLimMensal.Location = new System.Drawing.Point(82, 45);
			this.TxtLimMensal.Name = "TxtLimMensal";
			this.TxtLimMensal.Size = new System.Drawing.Size(78, 20);
			this.TxtLimMensal.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(17, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 4;
			this.label4.Text = "Mensal";
			// 
			// TxtLimTotal
			// 
			this.TxtLimTotal.Location = new System.Drawing.Point(82, 17);
			this.TxtLimTotal.Name = "TxtLimTotal";
			this.TxtLimTotal.Size = new System.Drawing.Size(78, 20);
			this.TxtLimTotal.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(17, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Total";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.TxtCidade);
			this.tabPage3.Controls.Add(this.label6);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(457, 83);
			this.tabPage3.TabIndex = 7;
			this.tabPage3.Text = "Cidade";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// TxtCidade
			// 
			this.TxtCidade.Location = new System.Drawing.Point(123, 25);
			this.TxtCidade.Name = "TxtCidade";
			this.TxtCidade.Size = new System.Drawing.Size(144, 20);
			this.TxtCidade.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(17, 28);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 4;
			this.label6.Text = "Cidade";
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.TxtEstado);
			this.tabPage4.Controls.Add(this.label7);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(457, 83);
			this.tabPage4.TabIndex = 8;
			this.tabPage4.Text = "Estado";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// TxtEstado
			// 
			this.TxtEstado.Location = new System.Drawing.Point(123, 25);
			this.TxtEstado.Name = "TxtEstado";
			this.TxtEstado.Size = new System.Drawing.Size(144, 20);
			this.TxtEstado.TabIndex = 7;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(17, 28);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 6;
			this.label7.Text = "Estado";
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.CboSit);
			this.tabPage5.Controls.Add(this.label11);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(457, 83);
			this.tabPage5.TabIndex = 11;
			this.tabPage5.Text = "Situação";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// CboSit
			// 
			this.CboSit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboSit.FormattingEnabled = true;
			this.CboSit.Items.AddRange(new object[] {
									"Habilitados",
									"Bloqueados",
									"Cancelados",
									"(Todos)"});
			this.CboSit.Location = new System.Drawing.Point(180, 31);
			this.CboSit.Name = "CboSit";
			this.CboSit.Size = new System.Drawing.Size(173, 21);
			this.CboSit.TabIndex = 8;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(32, 34);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(119, 23);
			this.label11.TabIndex = 7;
			this.label11.Text = "Situação dos cartões";
			// 
			// tabPage8
			// 
			this.tabPage8.Controls.Add(this.CboExp);
			this.tabPage8.Controls.Add(this.label12);
			this.tabPage8.Location = new System.Drawing.Point(4, 22);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Size = new System.Drawing.Size(457, 83);
			this.tabPage8.TabIndex = 12;
			this.tabPage8.Text = "Expedição";
			this.tabPage8.UseVisualStyleBackColor = true;
			// 
			// CboExp
			// 
			this.CboExp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboExp.FormattingEnabled = true;
			this.CboExp.Items.AddRange(new object[] {
									"Requerido pela associação",
									"Cartão em produção na gráfica",
									"Emitido para associação"});
			this.CboExp.Location = new System.Drawing.Point(218, 29);
			this.CboExp.Name = "CboExp";
			this.CboExp.Size = new System.Drawing.Size(207, 21);
			this.CboExp.TabIndex = 10;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(27, 32);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(162, 23);
			this.label12.TabIndex = 9;
			this.label12.Text = "Situação de entrega dos cartões";
			// 
			// BtnConsultar
			// 
			this.BtnConsultar.Location = new System.Drawing.Point(18, 136);
			this.BtnConsultar.Name = "BtnConsultar";
			this.BtnConsultar.Size = new System.Drawing.Size(75, 23);
			this.BtnConsultar.TabIndex = 7;
			this.BtnConsultar.Text = "Consultar";
			this.BtnConsultar.UseVisualStyleBackColor = true;
			this.BtnConsultar.Click += new System.EventHandler(this.BtnConsultarClick);
			// 
			// LstCartao
			// 
			this.LstCartao.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader8,
									this.columnHeader2,
									this.columnHeader3,
									this.columnHeader4,
									this.columnHeader5,
									this.columnHeader6,
									this.columnHeader7});
			this.LstCartao.FullRowSelect = true;
			this.LstCartao.HideSelection = false;
			this.LstCartao.Location = new System.Drawing.Point(18, 165);
			this.LstCartao.MultiSelect = false;
			this.LstCartao.Name = "LstCartao";
			this.LstCartao.Size = new System.Drawing.Size(706, 205);
			this.LstCartao.TabIndex = 8;
			this.LstCartao.UseCompatibleStateImageBehavior = false;
			this.LstCartao.View = System.Windows.Forms.View.Details;
			this.LstCartao.DoubleClick += new System.EventHandler(this.LstCartaoDoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Cartão";
			this.columnHeader1.Width = 110;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Bloqueado";
			this.columnHeader8.Width = 72;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Nome";
			this.columnHeader2.Width = 100;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Lim. Total";
			this.columnHeader3.Width = 80;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Lim. Mensal";
			this.columnHeader4.Width = 80;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Cota Extra";
			this.columnHeader5.Width = 80;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Disp. Mês";
			this.columnHeader6.Width = 75;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Disp Total";
			this.columnHeader7.Width = 75;
			// 
			// LblCart
			// 
			this.LblCart.Location = new System.Drawing.Point(573, 136);
			this.LblCart.Name = "LblCart";
			this.LblCart.Size = new System.Drawing.Size(151, 23);
			this.LblCart.TabIndex = 9;
			this.LblCart.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// BtnRelatorio
			// 
			this.BtnRelatorio.Location = new System.Drawing.Point(601, 376);
			this.BtnRelatorio.Name = "BtnRelatorio";
			this.BtnRelatorio.Size = new System.Drawing.Size(123, 23);
			this.BtnRelatorio.TabIndex = 10;
			this.BtnRelatorio.Text = "Relatório";
			this.BtnRelatorio.UseVisualStyleBackColor = true;
			this.BtnRelatorio.Click += new System.EventHandler(this.BtnRelatorioClick);
			// 
			// ChkAlfa
			// 
			this.ChkAlfa.Checked = true;
			this.ChkAlfa.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ChkAlfa.Location = new System.Drawing.Point(22, 374);
			this.ChkAlfa.Name = "ChkAlfa";
			this.ChkAlfa.Size = new System.Drawing.Size(188, 24);
			this.ChkAlfa.TabIndex = 11;
			this.ChkAlfa.Text = "Ordenar alfabeticamente";
			this.ChkAlfa.UseVisualStyleBackColor = true;
			this.ChkAlfa.CheckedChanged += new System.EventHandler(this.ChkAlfaCheckedChanged);
			// 
			// BtnExclui
			// 
			this.BtnExclui.Location = new System.Drawing.Point(187, 376);
			this.BtnExclui.Name = "BtnExclui";
			this.BtnExclui.Size = new System.Drawing.Size(123, 23);
			this.BtnExclui.TabIndex = 12;
			this.BtnExclui.Text = "Excluir cartão";
			this.BtnExclui.UseVisualStyleBackColor = true;
			this.BtnExclui.Visible = false;
			this.BtnExclui.Click += new System.EventHandler(this.BtnExcluiClick);
			// 
			// dlgConsultaCartao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(746, 416);
			this.Controls.Add(this.BtnExclui);
			this.Controls.Add(this.ChkAlfa);
			this.Controls.Add(this.BtnRelatorio);
			this.Controls.Add(this.LblCart);
			this.Controls.Add(this.BtnConsultar);
			this.Controls.Add(this.LstCartao);
			this.Controls.Add(this.tabControl1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgConsultaCartao";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Consulta de Cartões";
			this.Load += new System.EventHandler(this.DlgConsultaCartaoLoad);
			this.tabControl1.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			this.tabPage6.PerformLayout();
			this.tabPage7.ResumeLayout(false);
			this.tabPage7.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			this.tabPage5.ResumeLayout(false);
			this.tabPage8.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.Button BtnExclui;
		public System.Windows.Forms.CheckBox ChkAlfa;
		public System.Windows.Forms.Button BtnRelatorio;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		public System.Windows.Forms.ComboBox CboExp;
		public System.Windows.Forms.Label label12;
		private System.Windows.Forms.TabPage tabPage8;
		public System.Windows.Forms.ComboBox CboSit;
		public System.Windows.Forms.Label label11;
		private System.Windows.Forms.TabPage tabPage5;
		public System.Windows.Forms.TextBox TxtCpf;
		public System.Windows.Forms.Label label10;
		public System.Windows.Forms.Label LblCart;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		public System.Windows.Forms.TextBox TxtCartao;
		public System.Windows.Forms.Label label9;
		private System.Windows.Forms.TabPage tabPage6;
		public System.Windows.Forms.TextBox TxtEstado;
		public System.Windows.Forms.Label label7;
		public System.Windows.Forms.TextBox TxtCidade;
		public System.Windows.Forms.Label label6;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabPage tabPage3;
		public System.Windows.Forms.ListView LstCartao;
		public System.Windows.Forms.TextBox TxtCotaExtra;
		public System.Windows.Forms.TextBox TxtLimMensal;
		public System.Windows.Forms.TextBox TxtLimTotal;
		public System.Windows.Forms.TextBox TxtCNPJ;
		public System.Windows.Forms.TextBox TxtEmpresa;
		public System.Windows.Forms.ColumnHeader columnHeader5;
		public System.Windows.Forms.ColumnHeader columnHeader4;
		public System.Windows.Forms.ColumnHeader columnHeader3;
		public System.Windows.Forms.ColumnHeader columnHeader2;
		public System.Windows.Forms.ColumnHeader columnHeader1;
		public System.Windows.Forms.Button BtnConsultar;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.TabPage tabPage2;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.TabPage tabPage1;
		public System.Windows.Forms.Label label8;
		private System.Windows.Forms.TabPage tabPage7;
		public System.Windows.Forms.TabControl tabControl1;
	}
}

