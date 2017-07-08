using System.Windows.Forms;

namespace Client 
{
	partial class dlgLogin : Form
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
            this.TxtEmpresa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtSenha = new System.Windows.Forms.TextBox();
            this.BtnConfirmar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.LblVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // TxtNome
            // 
            this.TxtNome.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtNome.Location = new System.Drawing.Point(110, 17);
            this.TxtNome.Name = "TxtNome";
            this.TxtNome.Size = new System.Drawing.Size(130, 20);
            this.TxtNome.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(16, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Código Empresa";
            // 
            // TxtEmpresa
            // 
            this.TxtEmpresa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtEmpresa.Location = new System.Drawing.Point(110, 75);
            this.TxtEmpresa.Name = "TxtEmpresa";
            this.TxtEmpresa.Size = new System.Drawing.Size(130, 20);
            this.TxtEmpresa.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(16, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Senha";
            // 
            // TxtSenha
            // 
            this.TxtSenha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtSenha.Location = new System.Drawing.Point(110, 46);
            this.TxtSenha.Name = "TxtSenha";
            this.TxtSenha.PasswordChar = '*';
            this.TxtSenha.Size = new System.Drawing.Size(130, 20);
            this.TxtSenha.TabIndex = 2;
            // 
            // BtnConfirmar
            // 
            this.BtnConfirmar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnConfirmar.Location = new System.Drawing.Point(110, 118);
            this.BtnConfirmar.Name = "BtnConfirmar";
            this.BtnConfirmar.Size = new System.Drawing.Size(130, 23);
            this.BtnConfirmar.TabIndex = 6;
            this.BtnConfirmar.Text = "Confirmar";
            this.BtnConfirmar.UseVisualStyleBackColor = true;
            this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(16, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "ConveyNET";
            // 
            // LblVersion
            // 
            this.LblVersion.BackColor = System.Drawing.Color.Transparent;
            this.LblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblVersion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblVersion.Location = new System.Drawing.Point(16, 163);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(224, 23);
            this.LblVersion.TabIndex = 8;
            this.LblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.LblVersion.Click += new System.EventHandler(this.LblVersion_Click);
            // 
            // dlgLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(274, 195);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.BtnConfirmar);
            this.Controls.Add(this.TxtSenha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtEmpresa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login de usuário";
            this.Load += new System.EventHandler(this.DlgLoginLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		public System.Windows.Forms.Label LblVersion;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.TextBox TxtSenha;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox TxtEmpresa;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.Label label1;
	}
}

