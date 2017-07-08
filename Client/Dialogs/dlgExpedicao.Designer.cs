using System.Windows.Forms;

namespace Client 
{
	partial class dlgExpedicao : Form
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
			this.TxtFile = new System.Windows.Forms.TextBox();
			this.BtnDir = new System.Windows.Forms.Button();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.CboEmpresa = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(20, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(162, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Arquivo para salvar dados";
			// 
			// TxtFile
			// 
			this.TxtFile.Location = new System.Drawing.Point(20, 72);
			this.TxtFile.Name = "TxtFile";
			this.TxtFile.ReadOnly = true;
			this.TxtFile.Size = new System.Drawing.Size(346, 20);
			this.TxtFile.TabIndex = 1;
			// 
			// BtnDir
			// 
			this.BtnDir.Location = new System.Drawing.Point(372, 70);
			this.BtnDir.Name = "BtnDir";
			this.BtnDir.Size = new System.Drawing.Size(75, 23);
			this.BtnDir.TabIndex = 2;
			this.BtnDir.Text = "Diretório";
			this.BtnDir.UseVisualStyleBackColor = true;
			this.BtnDir.Click += new System.EventHandler(this.BtnDirClick);
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(20, 110);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 3;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(20, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Empresa";
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(249, 19);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.ReadOnly = true;
			this.TxtNome.Size = new System.Drawing.Size(198, 20);
			this.TxtNome.TabIndex = 6;
			// 
			// CboEmpresa
			// 
			this.CboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboEmpresa.FormattingEnabled = true;
			this.CboEmpresa.Location = new System.Drawing.Point(86, 19);
			this.CboEmpresa.Name = "CboEmpresa";
			this.CboEmpresa.Size = new System.Drawing.Size(139, 21);
			this.CboEmpresa.TabIndex = 7;
			this.CboEmpresa.SelectedIndexChanged += new System.EventHandler(this.CboEmpresaSelectedIndexChanged);
			// 
			// dlgExpedicao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(463, 150);
			this.Controls.Add(this.CboEmpresa);
			this.Controls.Add(this.TxtNome);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.BtnDir);
			this.Controls.Add(this.TxtFile);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgExpedicao";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Expedição de cartões";
			this.Load += new System.EventHandler(this.DlgExpedicaoLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.ComboBox CboEmpresa;
		public System.Windows.Forms.TextBox TxtNome;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox TxtFile;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		public System.Windows.Forms.Button BtnConfirmar;
		private System.Windows.Forms.Button BtnDir;
		private System.Windows.Forms.Label label1;
	}
}

