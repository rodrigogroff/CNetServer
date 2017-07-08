using System.Windows.Forms;

namespace Client 
{
	partial class dlgManutencaoTerminal : Form
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
			this.LstTerminais = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.TxtCNPJ = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.BtnAlterar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(16, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 13;
			this.label1.Text = "Terminais";
			// 
			// LstTerminais
			// 
			this.LstTerminais.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2});
			this.LstTerminais.FullRowSelect = true;
			this.LstTerminais.HideSelection = false;
			this.LstTerminais.Location = new System.Drawing.Point(16, 67);
			this.LstTerminais.MultiSelect = false;
			this.LstTerminais.Name = "LstTerminais";
			this.LstTerminais.Size = new System.Drawing.Size(250, 146);
			this.LstTerminais.TabIndex = 14;
			this.LstTerminais.UseCompatibleStateImageBehavior = false;
			this.LstTerminais.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Código";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Localização";
			this.columnHeader2.Width = 150;
			// 
			// TxtCNPJ
			// 
			this.TxtCNPJ.Location = new System.Drawing.Point(155, 18);
			this.TxtCNPJ.Name = "TxtCNPJ";
			this.TxtCNPJ.Size = new System.Drawing.Size(111, 20);
			this.TxtCNPJ.TabIndex = 16;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(16, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 17;
			this.label3.Text = "Código da loja";
			// 
			// BtnAlterar
			// 
			this.BtnAlterar.Location = new System.Drawing.Point(16, 219);
			this.BtnAlterar.Name = "BtnAlterar";
			this.BtnAlterar.Size = new System.Drawing.Size(75, 23);
			this.BtnAlterar.TabIndex = 18;
			this.BtnAlterar.Text = "Alterar";
			this.BtnAlterar.UseVisualStyleBackColor = true;
			this.BtnAlterar.Click += new System.EventHandler(this.BtnAlterarClick);
			// 
			// dlgManutencaoTerminal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(287, 263);
			this.Controls.Add(this.BtnAlterar);
			this.Controls.Add(this.TxtCNPJ);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.LstTerminais);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgManutencaoTerminal";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Manutenção de Terminal";
			this.Load += new System.EventHandler(this.DlgManutencaoTerminalLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.Button BtnAlterar;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox TxtCNPJ;
		public System.Windows.Forms.ColumnHeader columnHeader2;
		public System.Windows.Forms.ColumnHeader columnHeader1;
		public System.Windows.Forms.ListView LstTerminais;
		public System.Windows.Forms.Label label1;
	}
}

