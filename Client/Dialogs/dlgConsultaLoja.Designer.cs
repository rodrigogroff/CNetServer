using System.Windows.Forms;

namespace Client 
{
	partial class dlgConsultaLoja : Form
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
			this.BtnConsultar = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage7 = new System.Windows.Forms.TabPage();
			this.TxtEmpresa = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.TxtCNPJ = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.TxtLoja = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.TxtCidade = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.TxtEstado = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.TxtQtdTerm = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.LstLojas = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.LblQtd = new System.Windows.Forms.Label();
			this.BtnRelatorio = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage7.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.SuspendLayout();
			// 
			// BtnConsultar
			// 
			this.BtnConsultar.Location = new System.Drawing.Point(16, 128);
			this.BtnConsultar.Name = "BtnConsultar";
			this.BtnConsultar.Size = new System.Drawing.Size(75, 23);
			this.BtnConsultar.TabIndex = 1;
			this.BtnConsultar.Text = "Consultar";
			this.BtnConsultar.UseVisualStyleBackColor = true;
			this.BtnConsultar.Click += new System.EventHandler(this.BtnConsultarClick);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage7);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage6);
			this.tabControl1.Location = new System.Drawing.Point(16, 17);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(481, 105);
			this.tabControl1.TabIndex = 2;
			// 
			// tabPage7
			// 
			this.tabPage7.Controls.Add(this.TxtEmpresa);
			this.tabPage7.Controls.Add(this.label8);
			this.tabPage7.Location = new System.Drawing.Point(4, 22);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Size = new System.Drawing.Size(473, 79);
			this.tabPage7.TabIndex = 6;
			this.tabPage7.Text = "Associação";
			this.tabPage7.UseVisualStyleBackColor = true;
			// 
			// TxtEmpresa
			// 
			this.TxtEmpresa.Location = new System.Drawing.Point(123, 31);
			this.TxtEmpresa.Name = "TxtEmpresa";
			this.TxtEmpresa.Size = new System.Drawing.Size(144, 20);
			this.TxtEmpresa.TabIndex = 1;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(17, 34);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 23);
			this.label8.TabIndex = 2;
			this.label8.Text = "Código da empresa";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.TxtCNPJ);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.TxtLoja);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.TxtNome);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(473, 79);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Loja";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// TxtCNPJ
			// 
			this.TxtCNPJ.Location = new System.Drawing.Point(311, 19);
			this.TxtCNPJ.Name = "TxtCNPJ";
			this.TxtCNPJ.Size = new System.Drawing.Size(128, 20);
			this.TxtCNPJ.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(264, 22);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 4;
			this.label5.Text = "CNPJ";
			// 
			// TxtLoja
			// 
			this.TxtLoja.Location = new System.Drawing.Point(123, 42);
			this.TxtLoja.Name = "TxtLoja";
			this.TxtLoja.Size = new System.Drawing.Size(108, 20);
			this.TxtLoja.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(17, 45);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 2;
			this.label4.Text = "Código da Loja";
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(123, 19);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.Size = new System.Drawing.Size(108, 20);
			this.TxtNome.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(17, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nome da loja";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.TxtCidade);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(473, 79);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Cidade";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// TxtCidade
			// 
			this.TxtCidade.Location = new System.Drawing.Point(123, 25);
			this.TxtCidade.Name = "TxtCidade";
			this.TxtCidade.Size = new System.Drawing.Size(144, 20);
			this.TxtCidade.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(17, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Nome da cidade";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.TxtEstado);
			this.tabPage3.Controls.Add(this.label3);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(473, 79);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Estado";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// TxtEstado
			// 
			this.TxtEstado.Location = new System.Drawing.Point(123, 25);
			this.TxtEstado.Name = "TxtEstado";
			this.TxtEstado.Size = new System.Drawing.Size(144, 20);
			this.TxtEstado.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(17, 28);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Sigla do Estado";
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.TxtQtdTerm);
			this.tabPage6.Controls.Add(this.label7);
			this.tabPage6.Location = new System.Drawing.Point(4, 22);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Size = new System.Drawing.Size(473, 79);
			this.tabPage6.TabIndex = 5;
			this.tabPage6.Text = "Terminais";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// TxtQtdTerm
			// 
			this.TxtQtdTerm.Location = new System.Drawing.Point(123, 25);
			this.TxtQtdTerm.Name = "TxtQtdTerm";
			this.TxtQtdTerm.Size = new System.Drawing.Size(83, 20);
			this.TxtQtdTerm.TabIndex = 4;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(17, 28);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(160, 23);
			this.label7.TabIndex = 3;
			this.label7.Text = "Quantidade mínima";
			// 
			// LstLojas
			// 
			this.LstLojas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3,
									this.columnHeader4,
									this.columnHeader6,
									this.columnHeader7,
									this.columnHeader5,
									this.columnHeader8,
									this.columnHeader9});
			this.LstLojas.FullRowSelect = true;
			this.LstLojas.HideSelection = false;
			this.LstLojas.Location = new System.Drawing.Point(16, 165);
			this.LstLojas.MultiSelect = false;
			this.LstLojas.Name = "LstLojas";
			this.LstLojas.Size = new System.Drawing.Size(737, 205);
			this.LstLojas.TabIndex = 3;
			this.LstLojas.UseCompatibleStateImageBehavior = false;
			this.LstLojas.View = System.Windows.Forms.View.Details;
			this.LstLojas.DoubleClick += new System.EventHandler(this.LstLojasDoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Código";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Nome";
			this.columnHeader2.Width = 100;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Cidade";
			this.columnHeader3.Width = 70;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Estado";
			this.columnHeader4.Width = 50;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Terminais";
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "CNPJ";
			this.columnHeader7.Width = 100;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Dias Repasse";
			this.columnHeader5.Width = 90;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Pct. Repasse";
			this.columnHeader8.Width = 90;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Convênios";
			this.columnHeader9.Width = 80;
			// 
			// LblQtd
			// 
			this.LblQtd.Location = new System.Drawing.Point(587, 133);
			this.LblQtd.Name = "LblQtd";
			this.LblQtd.Size = new System.Drawing.Size(166, 23);
			this.LblQtd.TabIndex = 4;
			this.LblQtd.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// BtnRelatorio
			// 
			this.BtnRelatorio.Location = new System.Drawing.Point(630, 376);
			this.BtnRelatorio.Name = "BtnRelatorio";
			this.BtnRelatorio.Size = new System.Drawing.Size(123, 23);
			this.BtnRelatorio.TabIndex = 11;
			this.BtnRelatorio.Text = "Relatório";
			this.BtnRelatorio.UseVisualStyleBackColor = true;
			this.BtnRelatorio.Click += new System.EventHandler(this.BtnRelatorioClick);
			// 
			// dlgConsultaLoja
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(769, 424);
			this.Controls.Add(this.BtnRelatorio);
			this.Controls.Add(this.LblQtd);
			this.Controls.Add(this.BtnConsultar);
			this.Controls.Add(this.LstLojas);
			this.Controls.Add(this.tabControl1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgConsultaLoja";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Consulta de Lojas";
			this.Load += new System.EventHandler(this.DlgConsultaLojaLoad);
			this.tabControl1.ResumeLayout(false);
			this.tabPage7.ResumeLayout(false);
			this.tabPage7.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.tabPage6.ResumeLayout(false);
			this.tabPage6.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		public System.Windows.Forms.Button BtnRelatorio;
		public System.Windows.Forms.TextBox TxtCNPJ;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.TextBox TxtLoja;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox TxtEmpresa;
		public System.Windows.Forms.Label LblQtd;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		public System.Windows.Forms.Label label8;
		private System.Windows.Forms.TabPage tabPage7;
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.TextBox TxtQtdTerm;
		public System.Windows.Forms.Label label7;
		public System.Windows.Forms.TextBox TxtEstado;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox TxtCidade;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.TabPage tabPage6;
		public System.Windows.Forms.TabPage tabPage3;
		public System.Windows.Forms.ColumnHeader columnHeader6;
		public System.Windows.Forms.ColumnHeader columnHeader4;
		public System.Windows.Forms.ColumnHeader columnHeader3;
		public System.Windows.Forms.ColumnHeader columnHeader2;
		public System.Windows.Forms.ColumnHeader columnHeader1;
		public System.Windows.Forms.ListView LstLojas;
		public System.Windows.Forms.TabPage tabPage2;
		public System.Windows.Forms.TabPage tabPage1;
		public System.Windows.Forms.TabControl tabControl1;
		public System.Windows.Forms.Button BtnConsultar;
	}
}

