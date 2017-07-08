using System.Windows.Forms;

namespace Client 
{
	partial class dlgRelatorios : Form
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtDtIni = new System.Windows.Forms.TextBox();
			this.TxtDtFim = new System.Windows.Forms.TextBox();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.LstReport = new System.Windows.Forms.ListBox();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtCartao = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.TxtEmpresa = new System.Windows.Forms.TextBox();
			this.TxtLoja = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.TxtPayFone = new System.Windows.Forms.TextBox();
			this.TxtEstado = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.TxtCidade = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.TxtTit = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(17, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(247, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Selecione o relatório de sua preferência";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(17, 200);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Data de Inicio";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(234, 200);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Data de Fim";
			// 
			// TxtDtIni
			// 
			this.TxtDtIni.Location = new System.Drawing.Point(100, 197);
			this.TxtDtIni.Name = "TxtDtIni";
			this.TxtDtIni.Size = new System.Drawing.Size(106, 20);
			this.TxtDtIni.TabIndex = 2;
			// 
			// TxtDtFim
			// 
			this.TxtDtFim.Location = new System.Drawing.Point(305, 197);
			this.TxtDtFim.Name = "TxtDtFim";
			this.TxtDtFim.Size = new System.Drawing.Size(106, 20);
			this.TxtDtFim.TabIndex = 3;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(336, 312);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 11;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// LstReport
			// 
			this.LstReport.FormattingEnabled = true;
			this.LstReport.Location = new System.Drawing.Point(17, 38);
			this.LstReport.Name = "LstReport";
			this.LstReport.Size = new System.Drawing.Size(394, 147);
			this.LstReport.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(17, 228);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Cód. Empresa";
			// 
			// TxtCartao
			// 
			this.TxtCartao.Location = new System.Drawing.Point(100, 253);
			this.TxtCartao.Name = "TxtCartao";
			this.TxtCartao.Size = new System.Drawing.Size(106, 20);
			this.TxtCartao.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(17, 256);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 22);
			this.label5.TabIndex = 10;
			this.label5.Text = "Cartão";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(234, 228);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 23);
			this.label6.TabIndex = 11;
			this.label6.Text = "Cód. Loja";
			// 
			// TxtEmpresa
			// 
			this.TxtEmpresa.Location = new System.Drawing.Point(100, 225);
			this.TxtEmpresa.Name = "TxtEmpresa";
			this.TxtEmpresa.Size = new System.Drawing.Size(106, 20);
			this.TxtEmpresa.TabIndex = 4;
			// 
			// TxtLoja
			// 
			this.TxtLoja.Location = new System.Drawing.Point(305, 225);
			this.TxtLoja.Name = "TxtLoja";
			this.TxtLoja.Size = new System.Drawing.Size(106, 20);
			this.TxtLoja.TabIndex = 8;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(17, 312);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 23);
			this.label7.TabIndex = 14;
			this.label7.Text = "PayFone";
			// 
			// TxtPayFone
			// 
			this.TxtPayFone.Location = new System.Drawing.Point(100, 309);
			this.TxtPayFone.Name = "TxtPayFone";
			this.TxtPayFone.Size = new System.Drawing.Size(106, 20);
			this.TxtPayFone.TabIndex = 7;
			// 
			// TxtEstado
			// 
			this.TxtEstado.Location = new System.Drawing.Point(305, 253);
			this.TxtEstado.Name = "TxtEstado";
			this.TxtEstado.Size = new System.Drawing.Size(106, 20);
			this.TxtEstado.TabIndex = 9;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(234, 256);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(74, 23);
			this.label8.TabIndex = 17;
			this.label8.Text = "Estado";
			// 
			// TxtCidade
			// 
			this.TxtCidade.Location = new System.Drawing.Point(305, 281);
			this.TxtCidade.Name = "TxtCidade";
			this.TxtCidade.Size = new System.Drawing.Size(106, 20);
			this.TxtCidade.TabIndex = 10;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(234, 284);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(88, 23);
			this.label9.TabIndex = 19;
			this.label9.Text = "Cidade";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(17, 284);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(88, 23);
			this.label10.TabIndex = 20;
			this.label10.Text = "Titularidade";
			// 
			// TxtTit
			// 
			this.TxtTit.Location = new System.Drawing.Point(100, 281);
			this.TxtTit.Name = "TxtTit";
			this.TxtTit.Size = new System.Drawing.Size(106, 20);
			this.TxtTit.TabIndex = 6;
			// 
			// dlgRelatorios
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(439, 353);
			this.Controls.Add(this.TxtTit);
			this.Controls.Add(this.TxtCidade);
			this.Controls.Add(this.TxtEstado);
			this.Controls.Add(this.TxtPayFone);
			this.Controls.Add(this.TxtLoja);
			this.Controls.Add(this.TxtEmpresa);
			this.Controls.Add(this.TxtCartao);
			this.Controls.Add(this.LstReport);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.TxtDtFim);
			this.Controls.Add(this.TxtDtIni);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label8);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgRelatorios";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Relatórios ConveyNET";
			this.Load += new System.EventHandler(this.DlgRelatoriosLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtTit;
		public System.Windows.Forms.Label label10;
		public System.Windows.Forms.TextBox TxtCidade;
		public System.Windows.Forms.TextBox TxtEstado;
		public System.Windows.Forms.Label label9;
		public System.Windows.Forms.Label label8;
		public System.Windows.Forms.TextBox TxtLoja;
		public System.Windows.Forms.TextBox TxtPayFone;
		public System.Windows.Forms.Label label7;
		public System.Windows.Forms.TextBox TxtCartao;
		public System.Windows.Forms.Label label6;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.TextBox TxtEmpresa;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox TxtDtFim;
		public System.Windows.Forms.TextBox TxtDtIni;
		public System.Windows.Forms.ListBox LstReport;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
	}
}

