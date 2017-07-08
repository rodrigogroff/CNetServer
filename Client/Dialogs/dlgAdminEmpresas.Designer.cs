using System.Windows.Forms;

namespace Client 
{
	partial class dlgAdminEmpresas : Form
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
			this.TxtEmpresa = new System.Windows.Forms.TextBox();
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.LstEmp = new System.Windows.Forms.ListBox();
			this.BtnRemover = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.LstEmpDisp = new System.Windows.Forms.ListBox();
			this.BtnVincular = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(19, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(143, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Cód. Empresa Admin";
			// 
			// TxtEmpresa
			// 
			this.TxtEmpresa.Location = new System.Drawing.Point(19, 36);
			this.TxtEmpresa.Name = "TxtEmpresa";
			this.TxtEmpresa.Size = new System.Drawing.Size(154, 20);
			this.TxtEmpresa.TabIndex = 1;
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(188, 36);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.Size = new System.Drawing.Size(154, 20);
			this.TxtNome.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(188, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(97, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Nome da empresa";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(19, 238);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(166, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Empresas vinculadas";
			// 
			// LstEmp
			// 
			this.LstEmp.FormattingEnabled = true;
			this.LstEmp.Location = new System.Drawing.Point(19, 255);
			this.LstEmp.Name = "LstEmp";
			this.LstEmp.Size = new System.Drawing.Size(323, 121);
			this.LstEmp.TabIndex = 5;
			// 
			// BtnRemover
			// 
			this.BtnRemover.Location = new System.Drawing.Point(267, 382);
			this.BtnRemover.Name = "BtnRemover";
			this.BtnRemover.Size = new System.Drawing.Size(75, 23);
			this.BtnRemover.TabIndex = 6;
			this.BtnRemover.Text = "Remover";
			this.BtnRemover.UseVisualStyleBackColor = true;
			this.BtnRemover.Click += new System.EventHandler(this.BtnRemoverClick);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(19, 73);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(179, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Empresas disponíveis";
			// 
			// LstEmpDisp
			// 
			this.LstEmpDisp.FormattingEnabled = true;
			this.LstEmpDisp.Location = new System.Drawing.Point(19, 92);
			this.LstEmpDisp.Name = "LstEmpDisp";
			this.LstEmpDisp.Size = new System.Drawing.Size(323, 121);
			this.LstEmpDisp.TabIndex = 8;
			// 
			// BtnVincular
			// 
			this.BtnVincular.Location = new System.Drawing.Point(267, 219);
			this.BtnVincular.Name = "BtnVincular";
			this.BtnVincular.Size = new System.Drawing.Size(75, 23);
			this.BtnVincular.TabIndex = 9;
			this.BtnVincular.Text = "Vincular";
			this.BtnVincular.UseVisualStyleBackColor = true;
			this.BtnVincular.Click += new System.EventHandler(this.BtnVincularClick);
			// 
			// dlgAdminEmpresas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(363, 415);
			this.Controls.Add(this.BtnVincular);
			this.Controls.Add(this.LstEmpDisp);
			this.Controls.Add(this.BtnRemover);
			this.Controls.Add(this.LstEmp);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.TxtNome);
			this.Controls.Add(this.TxtEmpresa);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label4);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgAdminEmpresas";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Empresas Administradoras";
			this.Load += new System.EventHandler(this.DlgAdminEmpresasLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.ListBox LstEmpDisp;
		private System.Windows.Forms.Button BtnVincular;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button BtnRemover;
		public System.Windows.Forms.ListBox LstEmp;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.TextBox TxtEmpresa;
		private System.Windows.Forms.Label label1;
	}
}

