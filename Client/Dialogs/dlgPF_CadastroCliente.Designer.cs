using System.Windows.Forms;

namespace Client 
{
	partial class dlgPF_CadastroCliente : Form
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
			this.TxtEmpresa = new System.Windows.Forms.TextBox();
			this.TxtMatricula = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtTelefone = new System.Windows.Forms.TextBox();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(48, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Empresa";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(48, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Matricula";
			// 
			// TxtEmpresa
			// 
			this.TxtEmpresa.Location = new System.Drawing.Point(111, 18);
			this.TxtEmpresa.Name = "TxtEmpresa";
			this.TxtEmpresa.Size = new System.Drawing.Size(98, 20);
			this.TxtEmpresa.TabIndex = 2;
			// 
			// TxtMatricula
			// 
			this.TxtMatricula.Location = new System.Drawing.Point(111, 41);
			this.TxtMatricula.Name = "TxtMatricula";
			this.TxtMatricula.Size = new System.Drawing.Size(98, 20);
			this.TxtMatricula.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(48, 67);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Telefone";
			// 
			// TxtTelefone
			// 
			this.TxtTelefone.Location = new System.Drawing.Point(111, 64);
			this.TxtTelefone.Name = "TxtTelefone";
			this.TxtTelefone.Size = new System.Drawing.Size(98, 20);
			this.TxtTelefone.TabIndex = 7;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(132, 100);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(77, 23);
			this.BtnConfirmar.TabIndex = 8;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// dlgPF_CadastroCliente
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(238, 139);
			this.Controls.Add(this.TxtMatricula);
			this.Controls.Add(this.TxtEmpresa);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.TxtTelefone);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label4);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgPF_CadastroCliente";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Pay Fone - Cadastro de Clientes";
			this.Load += new System.EventHandler(this.DlgPF_CadastroClienteLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtTelefone;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox TxtMatricula;
		public System.Windows.Forms.TextBox TxtEmpresa;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
	}
}

