using System.Windows.Forms;

namespace Client 
{
	partial class dlgRemessa : Form
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
			this.TxtCodEmpresa = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtFile = new System.Windows.Forms.TextBox();
			this.BtnBuscar = new System.Windows.Forms.Button();
			this.BtnProc = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Empresa";
			// 
			// TxtCodEmpresa
			// 
			this.TxtCodEmpresa.Location = new System.Drawing.Point(86, 13);
			this.TxtCodEmpresa.Name = "TxtCodEmpresa";
			this.TxtCodEmpresa.Size = new System.Drawing.Size(100, 20);
			this.TxtCodEmpresa.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Arquivo";
			// 
			// TxtFile
			// 
			this.TxtFile.Location = new System.Drawing.Point(86, 47);
			this.TxtFile.Name = "TxtFile";
			this.TxtFile.ReadOnly = true;
			this.TxtFile.Size = new System.Drawing.Size(185, 20);
			this.TxtFile.TabIndex = 3;
			// 
			// BtnBuscar
			// 
			this.BtnBuscar.Location = new System.Drawing.Point(280, 45);
			this.BtnBuscar.Name = "BtnBuscar";
			this.BtnBuscar.Size = new System.Drawing.Size(61, 23);
			this.BtnBuscar.TabIndex = 4;
			this.BtnBuscar.Text = "Buscar";
			this.BtnBuscar.UseVisualStyleBackColor = true;
			this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscarClick);
			// 
			// BtnProc
			// 
			this.BtnProc.Location = new System.Drawing.Point(212, 83);
			this.BtnProc.Name = "BtnProc";
			this.BtnProc.Size = new System.Drawing.Size(129, 23);
			this.BtnProc.TabIndex = 5;
			this.BtnProc.Text = "Processar arquivo";
			this.BtnProc.UseVisualStyleBackColor = true;
			this.BtnProc.Click += new System.EventHandler(this.BtnProcClick);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// dlgRemessa
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(367, 127);
			this.Controls.Add(this.BtnProc);
			this.Controls.Add(this.BtnBuscar);
			this.Controls.Add(this.TxtFile);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TxtCodEmpresa);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgRemessa";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Importação para lote de novos cartões";
			this.Load += new System.EventHandler(this.DlgRemessaLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtCodEmpresa;
		public System.Windows.Forms.TextBox TxtFile;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		public System.Windows.Forms.Button BtnProc;
		private System.Windows.Forms.Button BtnBuscar;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}

