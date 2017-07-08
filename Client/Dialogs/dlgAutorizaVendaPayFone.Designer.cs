using System.Windows.Forms;

namespace Client 
{
	partial class dlgAutorizaVendaPayFone : Form
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
			this.TxtTelefone = new System.Windows.Forms.TextBox();
			this.TxtSenha = new System.Windows.Forms.TextBox();
			this.TxtNSU = new System.Windows.Forms.TextBox();
			this.BntConfirmar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(19, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Telefone";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(19, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "NSU";
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(19, 38);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Senha";
			// 
			// TxtTelefone
			// 
			this.TxtTelefone.Location = new System.Drawing.Point(100, 12);
			this.TxtTelefone.Name = "TxtTelefone";
			this.TxtTelefone.Size = new System.Drawing.Size(100, 20);
			this.TxtTelefone.TabIndex = 3;
			// 
			// TxtSenha
			// 
			this.TxtSenha.Location = new System.Drawing.Point(100, 35);
			this.TxtSenha.Name = "TxtSenha";
			this.TxtSenha.PasswordChar = '*';
			this.TxtSenha.Size = new System.Drawing.Size(100, 20);
			this.TxtSenha.TabIndex = 4;
			// 
			// TxtNSU
			// 
			this.TxtNSU.Location = new System.Drawing.Point(100, 58);
			this.TxtNSU.Name = "TxtNSU";
			this.TxtNSU.Size = new System.Drawing.Size(100, 20);
			this.TxtNSU.TabIndex = 5;
			// 
			// BntConfirmar
			// 
			this.BntConfirmar.Location = new System.Drawing.Point(125, 96);
			this.BntConfirmar.Name = "BntConfirmar";
			this.BntConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BntConfirmar.TabIndex = 6;
			this.BntConfirmar.Text = "Confirmar";
			this.BntConfirmar.UseVisualStyleBackColor = true;
			this.BntConfirmar.Click += new System.EventHandler(this.BntConfirmarClick);
			// 
			// dlgAutorizaVendaPayFone
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(232, 135);
			this.Controls.Add(this.BntConfirmar);
			this.Controls.Add(this.TxtNSU);
			this.Controls.Add(this.TxtSenha);
			this.Controls.Add(this.TxtTelefone);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgAutorizaVendaPayFone";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Autoriza Venda de PayFone";
			this.Load += new System.EventHandler(this.DlgAutorizaVendaPayFoneLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.Button BntConfirmar;
		public System.Windows.Forms.TextBox TxtNSU;
		public System.Windows.Forms.TextBox TxtSenha;
		public System.Windows.Forms.TextBox TxtTelefone;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
	}
}

