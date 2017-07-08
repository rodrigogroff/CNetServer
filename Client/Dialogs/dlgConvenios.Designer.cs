using System.Windows.Forms;

namespace Client 
{
	partial class dlgConvenios : Form
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
			this.label4 = new System.Windows.Forms.Label();
			this.TxtFantasia = new System.Windows.Forms.TextBox();
			this.TxtEmpresa = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.LstConvenios = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.BtnRemover = new System.Windows.Forms.Button();
			this.BtnAdicionar = new System.Windows.Forms.Button();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtTaxa = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.TxtRepasse = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.TxtLoja = new System.Windows.Forms.TextBox();
			this.TxtConta = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.TxtAg = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.TxtBanco = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(15, 83);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 12;
			this.label4.Text = "Nome Fantasia";
			// 
			// TxtFantasia
			// 
			this.TxtFantasia.Location = new System.Drawing.Point(107, 80);
			this.TxtFantasia.Name = "TxtFantasia";
			this.TxtFantasia.Size = new System.Drawing.Size(114, 20);
			this.TxtFantasia.TabIndex = 3;
			// 
			// TxtEmpresa
			// 
			this.TxtEmpresa.Location = new System.Drawing.Point(107, 53);
			this.TxtEmpresa.Name = "TxtEmpresa";
			this.TxtEmpresa.Size = new System.Drawing.Size(114, 20);
			this.TxtEmpresa.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(15, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 11;
			this.label3.Text = "Cód. Empresa";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(15, 178);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 13;
			this.label1.Text = "Convênios";
			// 
			// LstConvenios
			// 
			this.LstConvenios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3,
									this.columnHeader4,
									this.columnHeader5,
									this.columnHeader6,
									this.columnHeader7});
			this.LstConvenios.FullRowSelect = true;
			this.LstConvenios.HideSelection = false;
			this.LstConvenios.Location = new System.Drawing.Point(15, 194);
			this.LstConvenios.MultiSelect = false;
			this.LstConvenios.Name = "LstConvenios";
			this.LstConvenios.Size = new System.Drawing.Size(427, 134);
			this.LstConvenios.TabIndex = 10;
			this.LstConvenios.UseCompatibleStateImageBehavior = false;
			this.LstConvenios.View = System.Windows.Forms.View.Details;
			this.LstConvenios.Click += new System.EventHandler(this.LstConveniosClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Código";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Empresa";
			this.columnHeader2.Width = 145;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Taxa";
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Dias Repasse";
			this.columnHeader4.Width = 120;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Banco";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Agência";
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Conta";
			this.columnHeader7.Width = 80;
			// 
			// BtnRemover
			// 
			this.BtnRemover.Location = new System.Drawing.Point(356, 355);
			this.BtnRemover.Name = "BtnRemover";
			this.BtnRemover.Size = new System.Drawing.Size(75, 23);
			this.BtnRemover.TabIndex = 12;
			this.BtnRemover.Text = "Remover";
			this.BtnRemover.UseVisualStyleBackColor = true;
			this.BtnRemover.Click += new System.EventHandler(this.BtnRemoverClick);
			// 
			// BtnAdicionar
			// 
			this.BtnAdicionar.Location = new System.Drawing.Point(15, 134);
			this.BtnAdicionar.Name = "BtnAdicionar";
			this.BtnAdicionar.Size = new System.Drawing.Size(206, 23);
			this.BtnAdicionar.TabIndex = 9;
			this.BtnAdicionar.Text = "Adicionar / Atualizar";
			this.BtnAdicionar.UseVisualStyleBackColor = true;
			this.BtnAdicionar.Click += new System.EventHandler(this.BtnAdicionarClick);
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(15, 355);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 11;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(259, 27);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 18;
			this.label2.Text = "Taxa Admin. (%)";
			// 
			// TxtTaxa
			// 
			this.TxtTaxa.Location = new System.Drawing.Point(366, 24);
			this.TxtTaxa.Name = "TxtTaxa";
			this.TxtTaxa.Size = new System.Drawing.Size(76, 20);
			this.TxtTaxa.TabIndex = 4;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label5.Location = new System.Drawing.Point(259, 54);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 20;
			this.label5.Text = "Dias para Repasse";
			// 
			// TxtRepasse
			// 
			this.TxtRepasse.Location = new System.Drawing.Point(366, 51);
			this.TxtRepasse.Name = "TxtRepasse";
			this.TxtRepasse.Size = new System.Drawing.Size(75, 20);
			this.TxtRepasse.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label6.Location = new System.Drawing.Point(15, 27);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 22;
			this.label6.Text = "Código da Loja";
			// 
			// TxtLoja
			// 
			this.TxtLoja.Location = new System.Drawing.Point(107, 24);
			this.TxtLoja.Name = "TxtLoja";
			this.TxtLoja.Size = new System.Drawing.Size(114, 20);
			this.TxtLoja.TabIndex = 1;
			// 
			// TxtConta
			// 
			this.TxtConta.Location = new System.Drawing.Point(366, 136);
			this.TxtConta.Name = "TxtConta";
			this.TxtConta.Size = new System.Drawing.Size(76, 20);
			this.TxtConta.TabIndex = 8;
			// 
			// label9
			// 
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label9.Location = new System.Drawing.Point(310, 139);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(108, 23);
			this.label9.TabIndex = 27;
			this.label9.Text = "Conta";
			// 
			// TxtAg
			// 
			this.TxtAg.Location = new System.Drawing.Point(366, 109);
			this.TxtAg.Name = "TxtAg";
			this.TxtAg.Size = new System.Drawing.Size(76, 20);
			this.TxtAg.TabIndex = 7;
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label8.Location = new System.Drawing.Point(310, 112);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(108, 23);
			this.label8.TabIndex = 25;
			this.label8.Text = "Agência";
			// 
			// TxtBanco
			// 
			this.TxtBanco.Location = new System.Drawing.Point(366, 80);
			this.TxtBanco.Name = "TxtBanco";
			this.TxtBanco.Size = new System.Drawing.Size(76, 20);
			this.TxtBanco.TabIndex = 6;
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label7.Location = new System.Drawing.Point(310, 83);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(108, 23);
			this.label7.TabIndex = 24;
			this.label7.Text = "Banco";
			// 
			// dlgConvenios
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(464, 393);
			this.Controls.Add(this.TxtConta);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.TxtAg);
			this.Controls.Add(this.TxtLoja);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.TxtRepasse);
			this.Controls.Add(this.TxtBanco);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.TxtTaxa);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.BtnAdicionar);
			this.Controls.Add(this.BtnRemover);
			this.Controls.Add(this.LstConvenios);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TxtFantasia);
			this.Controls.Add(this.TxtEmpresa);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgConvenios";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Convênios";
			this.Load += new System.EventHandler(this.DlgConveniosLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtLoja;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		public System.Windows.Forms.TextBox TxtAg;
		public System.Windows.Forms.TextBox TxtConta;
		public System.Windows.Forms.Label label9;
		public System.Windows.Forms.Label label8;
		public System.Windows.Forms.Label label7;
		public System.Windows.Forms.TextBox TxtBanco;
		public System.Windows.Forms.Label label6;
		public System.Windows.Forms.TextBox TxtRepasse;
		public System.Windows.Forms.TextBox TxtTaxa;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.ListView LstConvenios;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Button BtnConfirmar;
		private System.Windows.Forms.Button BtnAdicionar;
		private System.Windows.Forms.Button BtnRemover;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox TxtEmpresa;
		public System.Windows.Forms.TextBox TxtFantasia;
		public System.Windows.Forms.Label label4;
	}
}

