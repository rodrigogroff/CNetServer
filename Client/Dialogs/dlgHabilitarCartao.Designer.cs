using System.Windows.Forms;

namespace Client 
{
	partial class dlgHabilitarCartao : Form
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
			this.TxtSenha = new System.Windows.Forms.TextBox();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.TxtCartao = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(21, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(141, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Senha inicial do cartão";
			// 
			// TxtSenha
			// 
			this.TxtSenha.Location = new System.Drawing.Point(21, 88);
			this.TxtSenha.Name = "TxtSenha";
			this.TxtSenha.PasswordChar = '*';
			this.TxtSenha.Size = new System.Drawing.Size(163, 20);
			this.TxtSenha.TabIndex = 2;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(21, 121);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 3;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// TxtCartao
			// 
			this.TxtCartao.Location = new System.Drawing.Point(21, 35);
			this.TxtCartao.Name = "TxtCartao";
			this.TxtCartao.Size = new System.Drawing.Size(232, 20);
			this.TxtCartao.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(21, 19);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Número do cartão";
			// 
			// dlgHabilitarCartao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(289, 171);
			this.Controls.Add(this.TxtCartao);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.TxtSenha);
			this.Controls.Add(this.label2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgHabilitarCartao";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Habilitar novo cartão";
			this.Load += new System.EventHandler(this.DlgHabilitarCartaoLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtCartao;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.TextBox TxtSenha;
		public System.Windows.Forms.Label label2;
	}
}

