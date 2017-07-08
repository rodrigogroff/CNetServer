using System.Windows.Forms;

namespace Client 
{
	partial class dlgRecebeArqBanco : Form
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
			this.BtnProcurar = new System.Windows.Forms.Button();
			this.BtnProcessar = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(23, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(130, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Arquivo a processar";
			// 
			// TxtFile
			// 
			this.TxtFile.Location = new System.Drawing.Point(23, 41);
			this.TxtFile.Name = "TxtFile";
			this.TxtFile.ReadOnly = true;
			this.TxtFile.Size = new System.Drawing.Size(180, 20);
			this.TxtFile.TabIndex = 1;
			// 
			// BtnProcurar
			// 
			this.BtnProcurar.Location = new System.Drawing.Point(222, 39);
			this.BtnProcurar.Name = "BtnProcurar";
			this.BtnProcurar.Size = new System.Drawing.Size(75, 23);
			this.BtnProcurar.TabIndex = 2;
			this.BtnProcurar.Text = "Procurar";
			this.BtnProcurar.UseVisualStyleBackColor = true;
			this.BtnProcurar.Click += new System.EventHandler(this.BtnProcurarClick);
			// 
			// BtnProcessar
			// 
			this.BtnProcessar.Location = new System.Drawing.Point(23, 88);
			this.BtnProcessar.Name = "BtnProcessar";
			this.BtnProcessar.Size = new System.Drawing.Size(75, 23);
			this.BtnProcessar.TabIndex = 3;
			this.BtnProcessar.Text = "Processar";
			this.BtnProcessar.UseVisualStyleBackColor = true;
			this.BtnProcessar.Click += new System.EventHandler(this.BtnProcessarClick);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// dlgRecebeArqBanco
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(322, 129);
			this.Controls.Add(this.BtnProcessar);
			this.Controls.Add(this.BtnProcurar);
			this.Controls.Add(this.TxtFile);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgRecebeArqBanco";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Recebe Arquivo Bancário";
			this.Load += new System.EventHandler(this.DlgRecebeArqBancoLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		public System.Windows.Forms.TextBox TxtFile;
		public System.Windows.Forms.Button BtnProcessar;
		public System.Windows.Forms.Button BtnProcurar;
		public System.Windows.Forms.Label label1;
	}
}

