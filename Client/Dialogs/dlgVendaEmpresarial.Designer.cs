using System.Windows.Forms;

namespace Client 
{
	partial class dlgVendaEmpresarial : Form
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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtEmpresa = new System.Windows.Forms.TextBox();
			this.TxtMatricula = new System.Windows.Forms.TextBox();
			this.TxtValor = new System.Windows.Forms.TextBox();
			this.LstLojas = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.TxtVrDispTotal = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.TxtTitularidade = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.TxtCodAcesso = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(13, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Empresa";
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(13, 70);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Matricula";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(13, 35);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 3;
			this.label4.Text = "Valor";
			// 
			// TxtEmpresa
			// 
			this.TxtEmpresa.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtEmpresa.Location = new System.Drawing.Point(92, 32);
			this.TxtEmpresa.Name = "TxtEmpresa";
			this.TxtEmpresa.Size = new System.Drawing.Size(81, 20);
			this.TxtEmpresa.TabIndex = 1;
			// 
			// TxtMatricula
			// 
			this.TxtMatricula.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtMatricula.Location = new System.Drawing.Point(92, 67);
			this.TxtMatricula.Name = "TxtMatricula";
			this.TxtMatricula.Size = new System.Drawing.Size(81, 20);
			this.TxtMatricula.TabIndex = 2;
			// 
			// TxtValor
			// 
			this.TxtValor.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtValor.Location = new System.Drawing.Point(92, 32);
			this.TxtValor.Name = "TxtValor";
			this.TxtValor.Size = new System.Drawing.Size(81, 20);
			this.TxtValor.TabIndex = 5;
			// 
			// LstLojas
			// 
			this.LstLojas.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LstLojas.FormattingEnabled = true;
			this.LstLojas.HorizontalScrollbar = true;
			this.LstLojas.Location = new System.Drawing.Point(13, 93);
			this.LstLojas.Name = "LstLojas";
			this.LstLojas.Size = new System.Drawing.Size(413, 108);
			this.LstLojas.TabIndex = 6;
			this.LstLojas.TabStop = false;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(13, 67);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 25;
			this.label1.Text = "Escolha a loja:";
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BtnConfirmar.Location = new System.Drawing.Point(345, 30);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(81, 23);
			this.BtnConfirmar.TabIndex = 7;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// TxtNome
			// 
			this.TxtNome.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtNome.Location = new System.Drawing.Point(277, 32);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.ReadOnly = true;
			this.TxtNome.Size = new System.Drawing.Size(149, 20);
			this.TxtNome.TabIndex = 4;
			this.TxtNome.TabStop = false;
			// 
			// label10
			// 
			this.label10.BackColor = System.Drawing.Color.Transparent;
			this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label10.Location = new System.Drawing.Point(185, 35);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 23);
			this.label10.TabIndex = 24;
			this.label10.Text = "Nome do cliente";
			// 
			// TxtVrDispTotal
			// 
			this.TxtVrDispTotal.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtVrDispTotal.Location = new System.Drawing.Point(277, 67);
			this.TxtVrDispTotal.Name = "TxtVrDispTotal";
			this.TxtVrDispTotal.ReadOnly = true;
			this.TxtVrDispTotal.Size = new System.Drawing.Size(149, 20);
			this.TxtVrDispTotal.TabIndex = 22;
			this.TxtVrDispTotal.TabStop = false;
			// 
			// label13
			// 
			this.label13.BackColor = System.Drawing.Color.Transparent;
			this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label13.Location = new System.Drawing.Point(185, 70);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(100, 23);
			this.label13.TabIndex = 23;
			this.label13.Text = "Disp. Total";
			// 
			// TxtTitularidade
			// 
			this.TxtTitularidade.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtTitularidade.Location = new System.Drawing.Point(92, 137);
			this.TxtTitularidade.Name = "TxtTitularidade";
			this.TxtTitularidade.Size = new System.Drawing.Size(81, 20);
			this.TxtTitularidade.TabIndex = 4;
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label8.Location = new System.Drawing.Point(13, 140);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 23);
			this.label8.TabIndex = 11;
			this.label8.Text = "Extra";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.TxtCodAcesso);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.TxtNome);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.TxtVrDispTotal);
			this.groupBox2.Controls.Add(this.TxtMatricula);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Controls.Add(this.TxtEmpresa);
			this.groupBox2.Controls.Add(this.TxtTitularidade);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Location = new System.Drawing.Point(12, 14);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(446, 175);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Dados Cartão";
			// 
			// TxtCodAcesso
			// 
			this.TxtCodAcesso.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtCodAcesso.Location = new System.Drawing.Point(92, 102);
			this.TxtCodAcesso.Name = "TxtCodAcesso";
			this.TxtCodAcesso.Size = new System.Drawing.Size(81, 20);
			this.TxtCodAcesso.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label5.Location = new System.Drawing.Point(13, 105);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 26;
			this.label5.Text = "Cod. Acesso";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.LstLojas);
			this.groupBox3.Controls.Add(this.TxtValor);
			this.groupBox3.Controls.Add(this.BtnConfirmar);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Location = new System.Drawing.Point(12, 214);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(446, 214);
			this.groupBox3.TabIndex = 10;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Finalizando venda por cartão";
			// 
			// dlgVendaEmpresarial
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(476, 446);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgVendaEmpresarial";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Venda GiftCard";
			this.Load += new System.EventHandler(this.DlgVendaEmpresarialLoad);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.TextBox TxtCodAcesso;
		public System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox2;
		public System.Windows.Forms.ListBox LstLojas;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.Label label10;
		public System.Windows.Forms.TextBox TxtVrDispTotal;
		public System.Windows.Forms.Label label13;
		public System.Windows.Forms.TextBox TxtValor;
		public System.Windows.Forms.TextBox TxtTitularidade;
		public System.Windows.Forms.TextBox TxtMatricula;
		public System.Windows.Forms.TextBox TxtEmpresa;
		public System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox3;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label2;
	}
}

