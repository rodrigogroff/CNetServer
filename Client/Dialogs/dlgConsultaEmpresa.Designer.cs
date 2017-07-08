using System.Windows.Forms;

namespace Client 
{
	partial class dlgConsultaEmpresa : Form
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
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.TxtCidade = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.TxtEstado = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.TxtQtdCartoes = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.TxtQtdParc = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.TxtVrMax = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.TxtVrMin = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tabPage7 = new System.Windows.Forms.TabPage();
			this.TxtQtdLojas = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.BtnConsultar = new System.Windows.Forms.Button();
			this.LstEmpresas = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.BtnCancelar = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage7.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage6);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Controls.Add(this.tabPage7);
			this.tabControl1.Location = new System.Drawing.Point(17, 19);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(515, 105);
			this.tabControl1.TabIndex = 3;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.TxtNome);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(507, 79);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Nome";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(123, 25);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.Size = new System.Drawing.Size(144, 20);
			this.TxtNome.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(17, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nome da empresa";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.TxtCidade);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(507, 79);
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
			this.tabPage3.Size = new System.Drawing.Size(507, 79);
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
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.TxtQtdCartoes);
			this.tabPage4.Controls.Add(this.label4);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(507, 79);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Cartões";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// TxtQtdCartoes
			// 
			this.TxtQtdCartoes.Location = new System.Drawing.Point(123, 25);
			this.TxtQtdCartoes.Name = "TxtQtdCartoes";
			this.TxtQtdCartoes.Size = new System.Drawing.Size(144, 20);
			this.TxtQtdCartoes.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(17, 28);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 2;
			this.label4.Text = "Quantidade";
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.TxtQtdParc);
			this.tabPage6.Controls.Add(this.label7);
			this.tabPage6.Location = new System.Drawing.Point(4, 22);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Size = new System.Drawing.Size(507, 79);
			this.tabPage6.TabIndex = 5;
			this.tabPage6.Text = "Parcelas";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// TxtQtdParc
			// 
			this.TxtQtdParc.Location = new System.Drawing.Point(123, 25);
			this.TxtQtdParc.Name = "TxtQtdParc";
			this.TxtQtdParc.Size = new System.Drawing.Size(83, 20);
			this.TxtQtdParc.TabIndex = 4;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(17, 28);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(160, 23);
			this.label7.TabIndex = 3;
			this.label7.Text = "Quantidade mínima";
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.TxtVrMax);
			this.tabPage5.Controls.Add(this.label6);
			this.tabPage5.Controls.Add(this.TxtVrMin);
			this.tabPage5.Controls.Add(this.label5);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(507, 79);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Mensalidade";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// TxtVrMax
			// 
			this.TxtVrMax.Location = new System.Drawing.Point(205, 43);
			this.TxtVrMax.Name = "TxtVrMax";
			this.TxtVrMax.Size = new System.Drawing.Size(144, 20);
			this.TxtVrMax.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(17, 46);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(160, 23);
			this.label6.TabIndex = 4;
			this.label6.Text = "Valor máximo de mensalidade";
			// 
			// TxtVrMin
			// 
			this.TxtVrMin.Location = new System.Drawing.Point(205, 17);
			this.TxtVrMin.Name = "TxtVrMin";
			this.TxtVrMin.Size = new System.Drawing.Size(144, 20);
			this.TxtVrMin.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(17, 20);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(160, 23);
			this.label5.TabIndex = 2;
			this.label5.Text = "Valor mínimo de mensalidade";
			// 
			// tabPage7
			// 
			this.tabPage7.Controls.Add(this.TxtQtdLojas);
			this.tabPage7.Controls.Add(this.label8);
			this.tabPage7.Location = new System.Drawing.Point(4, 22);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Size = new System.Drawing.Size(507, 79);
			this.tabPage7.TabIndex = 6;
			this.tabPage7.Text = "Lojas";
			this.tabPage7.UseVisualStyleBackColor = true;
			// 
			// TxtQtdLojas
			// 
			this.TxtQtdLojas.Location = new System.Drawing.Point(123, 25);
			this.TxtQtdLojas.Name = "TxtQtdLojas";
			this.TxtQtdLojas.Size = new System.Drawing.Size(100, 20);
			this.TxtQtdLojas.TabIndex = 0;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(17, 28);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(160, 23);
			this.label8.TabIndex = 4;
			this.label8.Text = "Quantidade Lojas";
			// 
			// BtnConsultar
			// 
			this.BtnConsultar.Location = new System.Drawing.Point(17, 135);
			this.BtnConsultar.Name = "BtnConsultar";
			this.BtnConsultar.Size = new System.Drawing.Size(75, 23);
			this.BtnConsultar.TabIndex = 4;
			this.BtnConsultar.Text = "Consultar";
			this.BtnConsultar.UseVisualStyleBackColor = true;
			this.BtnConsultar.Click += new System.EventHandler(this.BtnConsultarClick);
			// 
			// LstEmpresas
			// 
			this.LstEmpresas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3,
									this.columnHeader4,
									this.columnHeader5,
									this.columnHeader6,
									this.columnHeader7,
									this.columnHeader8,
									this.columnHeader9});
			this.LstEmpresas.FullRowSelect = true;
			this.LstEmpresas.HideSelection = false;
			this.LstEmpresas.Location = new System.Drawing.Point(17, 172);
			this.LstEmpresas.MultiSelect = false;
			this.LstEmpresas.Name = "LstEmpresas";
			this.LstEmpresas.Size = new System.Drawing.Size(676, 205);
			this.LstEmpresas.TabIndex = 5;
			this.LstEmpresas.UseCompatibleStateImageBehavior = false;
			this.LstEmpresas.View = System.Windows.Forms.View.Details;
			this.LstEmpresas.DoubleClick += new System.EventHandler(this.LstEmpresasDoubleClick);
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
			// columnHeader5
			// 
			this.columnHeader5.Text = "Cartões";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Parcelas";
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Taxa";
			this.columnHeader7.Width = 80;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Lojas";
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "CNPJ";
			this.columnHeader9.Width = 100;
			// 
			// BtnCancelar
			// 
			this.BtnCancelar.Location = new System.Drawing.Point(483, 396);
			this.BtnCancelar.Name = "BtnCancelar";
			this.BtnCancelar.Size = new System.Drawing.Size(210, 23);
			this.BtnCancelar.TabIndex = 6;
			this.BtnCancelar.Text = "Cancelar Empresa";
			this.BtnCancelar.UseVisualStyleBackColor = true;
			this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelarClick);
			// 
			// dlgConsultaEmpresa
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(705, 447);
			this.Controls.Add(this.BtnCancelar);
			this.Controls.Add(this.BtnConsultar);
			this.Controls.Add(this.LstEmpresas);
			this.Controls.Add(this.tabControl1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgConsultaEmpresa";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Consulta de Empresas";
			this.Load += new System.EventHandler(this.DlgConsultaEmpresaLoad);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
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
			this.tabPage7.PerformLayout();
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.Button BtnCancelar;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		public System.Windows.Forms.Label label8;
		public System.Windows.Forms.TextBox TxtQtdLojas;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.TabPage tabPage7;
		public System.Windows.Forms.ListView LstEmpresas;
		public System.Windows.Forms.TextBox TxtQtdCartoes;
		public System.Windows.Forms.TextBox TxtQtdParc;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		public System.Windows.Forms.ColumnHeader columnHeader6;
		public System.Windows.Forms.ColumnHeader columnHeader5;
		public System.Windows.Forms.ColumnHeader columnHeader4;
		public System.Windows.Forms.ColumnHeader columnHeader3;
		public System.Windows.Forms.ColumnHeader columnHeader2;
		public System.Windows.Forms.ColumnHeader columnHeader1;
		public System.Windows.Forms.Button BtnConsultar;
		public System.Windows.Forms.Label label7;
		public System.Windows.Forms.TabPage tabPage6;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.TextBox TxtVrMin;
		public System.Windows.Forms.Label label6;
		public System.Windows.Forms.TextBox TxtVrMax;
		public System.Windows.Forms.TabPage tabPage5;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.TabPage tabPage4;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox TxtEstado;
		public System.Windows.Forms.TabPage tabPage3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox TxtCidade;
		public System.Windows.Forms.TabPage tabPage2;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.TabPage tabPage1;
		public System.Windows.Forms.TabControl tabControl1;
	}
}

