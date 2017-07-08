using System.Windows.Forms;

namespace Client 
{
	partial class dlgFechamento : Form
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
			this.CboReport = new System.Windows.Forms.ComboBox();
			this.TxtMes = new System.Windows.Forms.TextBox();
			this.TxtAno = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.CboAfiliada = new System.Windows.Forms.ComboBox();
			this.BtnDBF = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// CboReport
			// 
			this.CboReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboReport.FormattingEnabled = true;
			this.CboReport.Items.AddRange(new object[] {
									"Fechamento por lojas e terminais",
									"Fechamento por cartões"});
			this.CboReport.Location = new System.Drawing.Point(21, 34);
			this.CboReport.Name = "CboReport";
			this.CboReport.Size = new System.Drawing.Size(219, 21);
			this.CboReport.TabIndex = 0;
			// 
			// TxtMes
			// 
			this.TxtMes.Location = new System.Drawing.Point(21, 146);
			this.TxtMes.Name = "TxtMes";
			this.TxtMes.Size = new System.Drawing.Size(75, 20);
			this.TxtMes.TabIndex = 1;
			// 
			// TxtAno
			// 
			this.TxtAno.Location = new System.Drawing.Point(164, 146);
			this.TxtAno.Name = "TxtAno";
			this.TxtAno.Size = new System.Drawing.Size(76, 20);
			this.TxtAno.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(21, 129);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Mês";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(164, 129);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Ano";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(21, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Tipo de relatório";
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(165, 182);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 6;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(21, 68);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(177, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Empresa afiliada";
			// 
			// CboAfiliada
			// 
			this.CboAfiliada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboAfiliada.FormattingEnabled = true;
			this.CboAfiliada.Location = new System.Drawing.Point(21, 85);
			this.CboAfiliada.Name = "CboAfiliada";
			this.CboAfiliada.Size = new System.Drawing.Size(219, 21);
			this.CboAfiliada.TabIndex = 8;
			// 
			// BtnDBF
			// 
			this.BtnDBF.Location = new System.Drawing.Point(21, 182);
			this.BtnDBF.Name = "BtnDBF";
			this.BtnDBF.Size = new System.Drawing.Size(75, 23);
			this.BtnDBF.TabIndex = 9;
			this.BtnDBF.Text = "Gerar DBF";
			this.BtnDBF.UseVisualStyleBackColor = true;
			this.BtnDBF.Click += new System.EventHandler(this.BtnDBFClick);
			// 
			// dlgFechamento
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(269, 230);
			this.Controls.Add(this.BtnDBF);
			this.Controls.Add(this.CboAfiliada);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.TxtAno);
			this.Controls.Add(this.TxtMes);
			this.Controls.Add(this.CboReport);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgFechamento";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Fechamento da Empresa:";
			this.Load += new System.EventHandler(this.DlgFechamentoLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.Button BtnDBF;
		public System.Windows.Forms.ComboBox CboAfiliada;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox TxtAno;
		public System.Windows.Forms.TextBox TxtMes;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.ComboBox CboReport;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
	}
}

