using System.Windows.Forms;

namespace Client 
{
	partial class dlgVendaLojista : Form
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
			this.TxtCartao = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.TxtSenha = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.TxtValor = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtParcelas = new System.Windows.Forms.TextBox();
			this.BtnDivisao = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TxtCartao
			// 
			this.TxtCartao.Location = new System.Drawing.Point(24, 96);
			this.TxtCartao.Name = "TxtCartao";
			this.TxtCartao.Size = new System.Drawing.Size(232, 20);
			this.TxtCartao.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 80);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 12;
			this.label4.Text = "Número do cartão";
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(137, 147);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(119, 23);
			this.BtnConfirmar.TabIndex = 4;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// TxtSenha
			// 
			this.TxtSenha.Location = new System.Drawing.Point(24, 149);
			this.TxtSenha.Name = "TxtSenha";
			this.TxtSenha.PasswordChar = '*';
			this.TxtSenha.Size = new System.Drawing.Size(100, 20);
			this.TxtSenha.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 133);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(141, 23);
			this.label2.TabIndex = 10;
			this.label2.Text = "Senha cartão";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 13;
			this.label1.Text = "Valor da Venda";
			// 
			// TxtValor
			// 
			this.TxtValor.Location = new System.Drawing.Point(24, 42);
			this.TxtValor.Name = "TxtValor";
			this.TxtValor.Size = new System.Drawing.Size(100, 20);
			this.TxtValor.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(137, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 14;
			this.label3.Text = "Parcelas";
			// 
			// TxtParcelas
			// 
			this.TxtParcelas.Location = new System.Drawing.Point(137, 42);
			this.TxtParcelas.Name = "TxtParcelas";
			this.TxtParcelas.Size = new System.Drawing.Size(44, 20);
			this.TxtParcelas.TabIndex = 15;
			// 
			// BtnDivisao
			// 
			this.BtnDivisao.Location = new System.Drawing.Point(193, 40);
			this.BtnDivisao.Name = "BtnDivisao";
			this.BtnDivisao.Size = new System.Drawing.Size(63, 23);
			this.BtnDivisao.TabIndex = 16;
			this.BtnDivisao.Text = "Definir";
			this.BtnDivisao.UseVisualStyleBackColor = true;
			this.BtnDivisao.Click += new System.EventHandler(this.BtnDivisaoClick);
			// 
			// dlgVendaLojista
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(287, 198);
			this.Controls.Add(this.BtnDivisao);
			this.Controls.Add(this.TxtParcelas);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.TxtValor);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TxtCartao);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.TxtSenha);
			this.Controls.Add(this.label2);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgVendaLojista";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Venda Lojista";
			this.Load += new System.EventHandler(this.DlgVendaLojistaLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.Button BtnDivisao;
		public System.Windows.Forms.TextBox TxtParcelas;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox TxtValor;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox TxtSenha;
		public System.Windows.Forms.Button BtnConfirmar;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox TxtCartao;
	}
}

