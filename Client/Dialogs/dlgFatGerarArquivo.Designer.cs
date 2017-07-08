using System.Windows.Forms;

namespace Client 
{
	partial class dlgFatGerarArquivo : Form
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
			this.TxtDtIni = new System.Windows.Forms.TextBox();
			this.TxtDtFim = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtFile = new System.Windows.Forms.TextBox();
			this.BtnDir = new System.Windows.Forms.Button();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.CboOption = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Vencimento inicial";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(154, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Vencimento final";
			// 
			// TxtDtIni
			// 
			this.TxtDtIni.Location = new System.Drawing.Point(24, 36);
			this.TxtDtIni.Name = "TxtDtIni";
			this.TxtDtIni.Size = new System.Drawing.Size(100, 20);
			this.TxtDtIni.TabIndex = 2;
			// 
			// TxtDtFim
			// 
			this.TxtDtFim.Location = new System.Drawing.Point(154, 36);
			this.TxtDtFim.Name = "TxtDtFim";
			this.TxtDtFim.Size = new System.Drawing.Size(100, 20);
			this.TxtDtFim.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Arquivo de destino";
			// 
			// TxtFile
			// 
			this.TxtFile.Location = new System.Drawing.Point(24, 90);
			this.TxtFile.Name = "TxtFile";
			this.TxtFile.ReadOnly = true;
			this.TxtFile.Size = new System.Drawing.Size(176, 20);
			this.TxtFile.TabIndex = 5;
			this.TxtFile.TabStop = false;
			// 
			// BtnDir
			// 
			this.BtnDir.Location = new System.Drawing.Point(217, 88);
			this.BtnDir.Name = "BtnDir";
			this.BtnDir.Size = new System.Drawing.Size(92, 23);
			this.BtnDir.TabIndex = 6;
			this.BtnDir.Text = "Salvar como..";
			this.BtnDir.UseVisualStyleBackColor = true;
			this.BtnDir.Click += new System.EventHandler(this.BtnDirClick);
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(217, 142);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(92, 23);
			this.BtnConfirmar.TabIndex = 7;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// CboOption
			// 
			this.CboOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboOption.FormattingEnabled = true;
			this.CboOption.Items.AddRange(new object[] {
									"Cobrança DOC",
									"Débito em conta"});
			this.CboOption.Location = new System.Drawing.Point(24, 142);
			this.CboOption.Name = "CboOption";
			this.CboOption.Size = new System.Drawing.Size(176, 21);
			this.CboOption.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 125);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 9;
			this.label4.Text = "Tipo de cobrança";
			// 
			// dlgFatGerarArquivo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(335, 189);
			this.Controls.Add(this.CboOption);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.BtnDir);
			this.Controls.Add(this.TxtFile);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.TxtDtFim);
			this.Controls.Add(this.TxtDtIni);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label4);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgFatGerarArquivo";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Gerar arquivo para faturamento";
			this.Load += new System.EventHandler(this.DlgFatGerarArquivoLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.ComboBox CboOption;
		public System.Windows.Forms.TextBox TxtDtIni;
		public System.Windows.Forms.TextBox TxtDtFim;
		public System.Windows.Forms.TextBox TxtFile;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.Button BtnDir;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
	}
}

