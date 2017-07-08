using System.Windows.Forms;

namespace Client 
{
	partial class dlgVendaOnline : Form
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
			this.TxtMoney_Valor = new System.Windows.Forms.TextBox();
			this.TxtCartao = new System.Windows.Forms.TextBox();
			this.TxtSenha = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(22, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Valor";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(22, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Cartão";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(22, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Senha";
			// 
			// TxtMoney_Valor
			// 
			this.TxtMoney_Valor.Location = new System.Drawing.Point(86, 23);
			this.TxtMoney_Valor.Name = "TxtMoney_Valor";
			this.TxtMoney_Valor.Size = new System.Drawing.Size(100, 20);
			this.TxtMoney_Valor.TabIndex = 3;
			// 
			// TxtCartao
			// 
			this.TxtCartao.Location = new System.Drawing.Point(86, 58);
			this.TxtCartao.Name = "TxtCartao";
			this.TxtCartao.Size = new System.Drawing.Size(100, 20);
			this.TxtCartao.TabIndex = 4;
			// 
			// TxtSenha
			// 
			this.TxtSenha.Location = new System.Drawing.Point(86, 93);
			this.TxtSenha.Name = "TxtSenha";
			this.TxtSenha.Size = new System.Drawing.Size(100, 20);
			this.TxtSenha.TabIndex = 5;
			// 
			// dlgVendaOnline
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(215, 136);
			this.Controls.Add(this.TxtSenha);
			this.Controls.Add(this.TxtCartao);
			this.Controls.Add(this.TxtMoney_Valor);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgVendaOnline";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Venda Online";
			this.Load += new System.EventHandler(this.dlgVendaOnlineLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtSenha;
		public System.Windows.Forms.TextBox TxtCartao;
		public System.Windows.Forms.TextBox TxtMoney_Valor;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
	}
}

