using System.Windows.Forms;

namespace Client 
{
	partial class dlgCadastroUsuario : Form
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
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtSenha = new System.Windows.Forms.TextBox();
			this.ChkTrocaSenha = new System.Windows.Forms.CheckBox();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtEmpresa = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.CboNivel = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(12, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nome";
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(100, 25);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.Size = new System.Drawing.Size(142, 20);
			this.TxtNome.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(12, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Senha inicial";
			// 
			// TxtSenha
			// 
			this.TxtSenha.Location = new System.Drawing.Point(100, 52);
			this.TxtSenha.Name = "TxtSenha";
			this.TxtSenha.Size = new System.Drawing.Size(142, 20);
			this.TxtSenha.TabIndex = 2;
			// 
			// ChkTrocaSenha
			// 
			this.ChkTrocaSenha.BackColor = System.Drawing.Color.Transparent;
			this.ChkTrocaSenha.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ChkTrocaSenha.Location = new System.Drawing.Point(100, 151);
			this.ChkTrocaSenha.Name = "ChkTrocaSenha";
			this.ChkTrocaSenha.Size = new System.Drawing.Size(142, 24);
			this.ChkTrocaSenha.TabIndex = 5;
			this.ChkTrocaSenha.Text = "Trocar senha ao logon";
			this.ChkTrocaSenha.UseVisualStyleBackColor = false;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(167, 181);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 6;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(12, 82);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Empresa";
			// 
			// TxtEmpresa
			// 
			this.TxtEmpresa.Location = new System.Drawing.Point(100, 79);
			this.TxtEmpresa.Name = "TxtEmpresa";
			this.TxtEmpresa.Size = new System.Drawing.Size(142, 20);
			this.TxtEmpresa.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(12, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Nível";
			// 
			// CboNivel
			// 
			this.CboNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboNivel.FormattingEnabled = true;
			this.CboNivel.Location = new System.Drawing.Point(100, 109);
			this.CboNivel.Name = "CboNivel";
			this.CboNivel.Size = new System.Drawing.Size(142, 21);
			this.CboNivel.TabIndex = 4;
			// 
			// dlgCadastroUsuario
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(274, 225);
			this.Controls.Add(this.CboNivel);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.TxtEmpresa);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.ChkTrocaSenha);
			this.Controls.Add(this.TxtSenha);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TxtNome);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgCadastroUsuario";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cadastro de Usuarios";
			this.Load += new System.EventHandler(this.DlgCadastroUsuarioLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.ComboBox CboNivel;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox TxtEmpresa;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.CheckBox ChkTrocaSenha;
		public System.Windows.Forms.TextBox TxtSenha;
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
	}
}

