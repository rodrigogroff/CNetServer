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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtSt_Nome = new System.Windows.Forms.TextBox();
			this.TxtSt_Empresa = new System.Windows.Forms.TextBox();
			this.TxtSt_Senha = new System.Windows.Forms.TextBox();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 51);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nome";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Loja";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Senha";
			// 
			// TxtSt_Nome
			// 
			this.TxtSt_Nome.Location = new System.Drawing.Point(90, 48);
			this.TxtSt_Nome.Name = "TxtSt_Nome";
			this.TxtSt_Nome.Size = new System.Drawing.Size(100, 20);
			this.TxtSt_Nome.TabIndex = 2;
			// 
			// TxtSt_Empresa
			// 
			this.TxtSt_Empresa.Location = new System.Drawing.Point(90, 19);
			this.TxtSt_Empresa.Name = "TxtSt_Empresa";
			this.TxtSt_Empresa.Size = new System.Drawing.Size(100, 20);
			this.TxtSt_Empresa.TabIndex = 1;
			// 
			// TxtSt_Senha
			// 
			this.TxtSt_Senha.Location = new System.Drawing.Point(90, 77);
			this.TxtSt_Senha.Name = "TxtSt_Senha";
			this.TxtSt_Senha.PasswordChar = '*';
			this.TxtSt_Senha.Size = new System.Drawing.Size(100, 20);
			this.TxtSt_Senha.TabIndex = 3;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(115, 117);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 4;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// dlgLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(218, 158);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.TxtSt_Senha);
			this.Controls.Add(this.TxtSt_Empresa);
			this.Controls.Add(this.TxtSt_Nome);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgLogin";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login lojista";
			this.Load += new System.EventHandler(this.dlgLoginLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.TextBox TxtSt_Senha;
		public System.Windows.Forms.TextBox TxtSt_Empresa;
		public System.Windows.Forms.TextBox TxtSt_Nome;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
	}
}

