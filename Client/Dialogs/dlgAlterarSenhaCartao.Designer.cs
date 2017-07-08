using System.Windows.Forms;

namespace Client 
{
	partial class dlgAlterarSenhaCartao : Form
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
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.TxtEmpresa = new System.Windows.Forms.TextBox();
			this.TxtMatricula = new System.Windows.Forms.TextBox();
			this.TxtTitularidade = new System.Windows.Forms.TextBox();
			this.TxtNovaSenha = new System.Windows.Forms.TextBox();
			this.TxtConfirmaSenha = new System.Windows.Forms.TextBox();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(15, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Empresa";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(15, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Matrícula";
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(15, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Titularidade";
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label5.Location = new System.Drawing.Point(15, 125);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 4;
			this.label5.Text = "Nova Senha";
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label6.Location = new System.Drawing.Point(15, 148);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 5;
			this.label6.Text = "Confirma Senha";
			// 
			// TxtEmpresa
			// 
			this.TxtEmpresa.Location = new System.Drawing.Point(107, 18);
			this.TxtEmpresa.Name = "TxtEmpresa";
			this.TxtEmpresa.Size = new System.Drawing.Size(100, 20);
			this.TxtEmpresa.TabIndex = 6;
			// 
			// TxtMatricula
			// 
			this.TxtMatricula.Location = new System.Drawing.Point(107, 41);
			this.TxtMatricula.Name = "TxtMatricula";
			this.TxtMatricula.Size = new System.Drawing.Size(100, 20);
			this.TxtMatricula.TabIndex = 7;
			// 
			// TxtTitularidade
			// 
			this.TxtTitularidade.Location = new System.Drawing.Point(107, 64);
			this.TxtTitularidade.Name = "TxtTitularidade";
			this.TxtTitularidade.Size = new System.Drawing.Size(100, 20);
			this.TxtTitularidade.TabIndex = 8;
			// 
			// TxtNovaSenha
			// 
			this.TxtNovaSenha.Location = new System.Drawing.Point(107, 122);
			this.TxtNovaSenha.Name = "TxtNovaSenha";
			this.TxtNovaSenha.PasswordChar = '*';
			this.TxtNovaSenha.Size = new System.Drawing.Size(100, 20);
			this.TxtNovaSenha.TabIndex = 10;
			// 
			// TxtConfirmaSenha
			// 
			this.TxtConfirmaSenha.Location = new System.Drawing.Point(107, 145);
			this.TxtConfirmaSenha.Name = "TxtConfirmaSenha";
			this.TxtConfirmaSenha.PasswordChar = '*';
			this.TxtConfirmaSenha.Size = new System.Drawing.Size(100, 20);
			this.TxtConfirmaSenha.TabIndex = 11;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(85, 180);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 12;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// dlgAlterarSenhaCartao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(244, 215);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.TxtConfirmaSenha);
			this.Controls.Add(this.TxtNovaSenha);
			this.Controls.Add(this.TxtTitularidade);
			this.Controls.Add(this.TxtMatricula);
			this.Controls.Add(this.TxtEmpresa);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgAlterarSenhaCartao";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Alterar Senha de Cartao";
			this.Load += new System.EventHandler(this.DlgAlterarSenhaCartaoLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.TextBox TxtConfirmaSenha;
		public System.Windows.Forms.TextBox TxtNovaSenha;
		public System.Windows.Forms.TextBox TxtTitularidade;
		public System.Windows.Forms.TextBox TxtMatricula;
		public System.Windows.Forms.TextBox TxtEmpresa;
		public System.Windows.Forms.Label label6;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
	}
}

