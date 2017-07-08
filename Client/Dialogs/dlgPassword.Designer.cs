using System.Windows.Forms;

namespace Client 
{
	partial class dlgPassword : Form
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
			this.TxtSenhaAtual = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtNovaSenha = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtConfirmaSenha = new System.Windows.Forms.TextBox();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(18, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Senha atual";
			// 
			// TxtSenhaAtual
			// 
			this.TxtSenhaAtual.Location = new System.Drawing.Point(108, 20);
			this.TxtSenhaAtual.Name = "TxtSenhaAtual";
			this.TxtSenhaAtual.PasswordChar = '*';
			this.TxtSenhaAtual.Size = new System.Drawing.Size(116, 20);
			this.TxtSenhaAtual.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Location = new System.Drawing.Point(18, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Nova senha";
			// 
			// TxtNovaSenha
			// 
			this.TxtNovaSenha.Location = new System.Drawing.Point(108, 50);
			this.TxtNovaSenha.Name = "TxtNovaSenha";
			this.TxtNovaSenha.PasswordChar = '*';
			this.TxtNovaSenha.Size = new System.Drawing.Size(116, 20);
			this.TxtNovaSenha.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Location = new System.Drawing.Point(18, 82);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Confirmar senha";
			// 
			// TxtConfirmaSenha
			// 
			this.TxtConfirmaSenha.Location = new System.Drawing.Point(108, 79);
			this.TxtConfirmaSenha.Name = "TxtConfirmaSenha";
			this.TxtConfirmaSenha.PasswordChar = '*';
			this.TxtConfirmaSenha.Size = new System.Drawing.Size(116, 20);
			this.TxtConfirmaSenha.TabIndex = 5;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(108, 115);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(116, 23);
			this.BtnConfirmar.TabIndex = 6;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// dlgPassword
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(252, 164);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.TxtConfirmaSenha);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.TxtNovaSenha);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TxtSenhaAtual);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgPassword";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Troca de senha";
			this.Load += new System.EventHandler(this.DlgPasswordLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtConfirmaSenha;
		private System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox TxtNovaSenha;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox TxtSenhaAtual;
		public System.Windows.Forms.Label label1;
	}
}

