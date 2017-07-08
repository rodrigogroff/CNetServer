using System.Windows.Forms;

namespace Client 
{
	partial class dlgPF_CadastroLojista : Form
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
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.TxtTelefone = new System.Windows.Forms.TextBox();
			this.TxtEmpresa = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtTerminal = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(135, 105);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(77, 23);
			this.BtnConfirmar.TabIndex = 4;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(45, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 9;
			this.label1.Text = "Empresa";
			// 
			// TxtTelefone
			// 
			this.TxtTelefone.Location = new System.Drawing.Point(107, 65);
			this.TxtTelefone.Name = "TxtTelefone";
			this.TxtTelefone.Size = new System.Drawing.Size(105, 20);
			this.TxtTelefone.TabIndex = 3;
			// 
			// TxtEmpresa
			// 
			this.TxtEmpresa.Location = new System.Drawing.Point(107, 21);
			this.TxtEmpresa.Name = "TxtEmpresa";
			this.TxtEmpresa.Size = new System.Drawing.Size(105, 20);
			this.TxtEmpresa.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(45, 68);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 11;
			this.label4.Text = "Telefone";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(45, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 14;
			this.label2.Text = "Terminal";
			// 
			// TxtTerminal
			// 
			this.TxtTerminal.Location = new System.Drawing.Point(107, 43);
			this.TxtTerminal.Name = "TxtTerminal";
			this.TxtTerminal.Size = new System.Drawing.Size(105, 20);
			this.TxtTerminal.TabIndex = 2;
			// 
			// dlgPF_CadastroLojista
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(245, 144);
			this.Controls.Add(this.TxtTerminal);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.TxtTelefone);
			this.Controls.Add(this.TxtEmpresa);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgPF_CadastroLojista";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Pay Fone - Cadastro de Lojista";
			this.Load += new System.EventHandler(this.DlgPF_CadastroLojistaLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtTerminal;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox TxtEmpresa;
		public System.Windows.Forms.TextBox TxtTelefone;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.Button BtnConfirmar;
	}
}

