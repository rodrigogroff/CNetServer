using System.Windows.Forms;

namespace Client 
{
	partial class dlgLojista : Form
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
			this.LstUsers = new System.Windows.Forms.ListBox();
			this.TxtCodLoja = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtNomeLoja = new System.Windows.Forms.TextBox();
			this.BtnVincular = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(20, 152);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Cód. Loja";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(19, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Lojistas";
			// 
			// LstUsers
			// 
			this.LstUsers.FormattingEnabled = true;
			this.LstUsers.Location = new System.Drawing.Point(19, 38);
			this.LstUsers.Name = "LstUsers";
			this.LstUsers.Size = new System.Drawing.Size(243, 95);
			this.LstUsers.TabIndex = 2;
			// 
			// TxtCodLoja
			// 
			this.TxtCodLoja.Location = new System.Drawing.Point(96, 149);
			this.TxtCodLoja.Name = "TxtCodLoja";
			this.TxtCodLoja.Size = new System.Drawing.Size(166, 20);
			this.TxtCodLoja.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(20, 184);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Nome Loja";
			// 
			// TxtNomeLoja
			// 
			this.TxtNomeLoja.Location = new System.Drawing.Point(96, 181);
			this.TxtNomeLoja.Name = "TxtNomeLoja";
			this.TxtNomeLoja.ReadOnly = true;
			this.TxtNomeLoja.Size = new System.Drawing.Size(166, 20);
			this.TxtNomeLoja.TabIndex = 5;
			// 
			// BtnVincular
			// 
			this.BtnVincular.Location = new System.Drawing.Point(187, 221);
			this.BtnVincular.Name = "BtnVincular";
			this.BtnVincular.Size = new System.Drawing.Size(75, 23);
			this.BtnVincular.TabIndex = 6;
			this.BtnVincular.Text = "Vincular";
			this.BtnVincular.UseVisualStyleBackColor = true;
			this.BtnVincular.Click += new System.EventHandler(this.BtnVincularClick);
			// 
			// dlgLojista
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 266);
			this.Controls.Add(this.BtnVincular);
			this.Controls.Add(this.TxtNomeLoja);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.TxtCodLoja);
			this.Controls.Add(this.LstUsers);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgLojista";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Administração de Lojistas";
			this.Load += new System.EventHandler(this.DlgLojistaLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtCodLoja;
		public System.Windows.Forms.Button BtnVincular;
		public System.Windows.Forms.TextBox TxtNomeLoja;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.ListBox LstUsers;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
	}
}

