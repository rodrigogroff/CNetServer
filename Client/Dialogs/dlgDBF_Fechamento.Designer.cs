using System.Windows.Forms;

namespace Client 
{
	partial class dlgDBF_Fechamento : Form
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
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.LblText = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(27, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Salvar em:";
			// 
			// TxtFile
			// 
			this.TxtFile.Location = new System.Drawing.Point(27, 75);
			this.TxtFile.Name = "TxtFile";
			this.TxtFile.ReadOnly = true;
			this.TxtFile.Size = new System.Drawing.Size(210, 20);
			this.TxtFile.TabIndex = 1;
			this.TxtFile.TabStop = false;
			// 
			// BtnProcurar
			// 
			this.BtnProcurar.Location = new System.Drawing.Point(260, 73);
			this.BtnProcurar.Name = "BtnProcurar";
			this.BtnProcurar.Size = new System.Drawing.Size(75, 23);
			this.BtnProcurar.TabIndex = 2;
			this.BtnProcurar.Text = "Procurar";
			this.BtnProcurar.UseVisualStyleBackColor = true;
			this.BtnProcurar.Click += new System.EventHandler(this.BtnProcurarClick);
			// 
			// LblText
			// 
			this.LblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblText.Location = new System.Drawing.Point(27, 22);
			this.LblText.Name = "LblText";
			this.LblText.Size = new System.Drawing.Size(308, 23);
			this.LblText.TabIndex = 3;
			this.LblText.Text = "Relatório de cartões: ";
			// 
			// dlgDBF_Fechamento
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(368, 135);
			this.Controls.Add(this.LblText);
			this.Controls.Add(this.BtnProcurar);
			this.Controls.Add(this.TxtFile);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgDBF_Fechamento";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Fechamento via arquivo BDF";
			this.Load += new System.EventHandler(this.DlgDBF_FechamentoLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.Label LblText;
		public System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		public System.Windows.Forms.TextBox TxtFile;
		private System.Windows.Forms.Button BtnProcurar;
		private System.Windows.Forms.Label label1;
	}
}

