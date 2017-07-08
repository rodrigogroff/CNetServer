using System.Windows.Forms;

namespace Client 
{
	partial class dlgSelecionaTerminal : Form
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.LstLojas = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.LstTerm = new System.Windows.Forms.ListView();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.TxtNome);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.LstLojas);
			this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.groupBox1.Location = new System.Drawing.Point(19, 19);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(266, 227);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Informe a Loja";
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(69, 30);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.Size = new System.Drawing.Size(185, 20);
			this.TxtNome.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(18, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Nome";
			// 
			// LstLojas
			// 
			this.LstLojas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2});
			this.LstLojas.FullRowSelect = true;
			this.LstLojas.HideSelection = false;
			this.LstLojas.Location = new System.Drawing.Point(18, 70);
			this.LstLojas.MultiSelect = false;
			this.LstLojas.Name = "LstLojas";
			this.LstLojas.Size = new System.Drawing.Size(236, 141);
			this.LstLojas.TabIndex = 0;
			this.LstLojas.UseCompatibleStateImageBehavior = false;
			this.LstLojas.View = System.Windows.Forms.View.Details;
			this.LstLojas.Click += new System.EventHandler(this.LstLojasClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Loja";
			this.columnHeader1.Width = 120;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Código";
			this.columnHeader2.Width = 90;
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.Color.Transparent;
			this.groupBox2.Controls.Add(this.LstTerm);
			this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.groupBox2.Location = new System.Drawing.Point(293, 18);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(266, 228);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Selecione o Terminal";
			// 
			// LstTerm
			// 
			this.LstTerm.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader3,
									this.columnHeader4});
			this.LstTerm.FullRowSelect = true;
			this.LstTerm.HideSelection = false;
			this.LstTerm.Location = new System.Drawing.Point(16, 31);
			this.LstTerm.MultiSelect = false;
			this.LstTerm.Name = "LstTerm";
			this.LstTerm.Size = new System.Drawing.Size(236, 181);
			this.LstTerm.TabIndex = 1;
			this.LstTerm.UseCompatibleStateImageBehavior = false;
			this.LstTerm.View = System.Windows.Forms.View.Details;
			this.LstTerm.Click += new System.EventHandler(this.LstTermClick);
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Código";
			this.columnHeader3.Width = 70;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Localização";
			this.columnHeader4.Width = 140;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(470, 256);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 2;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// dlgSelecionaTerminal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(579, 296);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgSelecionaTerminal";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Seleção de Terminal";
			this.Load += new System.EventHandler(this.DlgSelecionaTerminalLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.ColumnHeader columnHeader4;
		public System.Windows.Forms.ColumnHeader columnHeader3;
		public System.Windows.Forms.ListView LstTerm;
		public System.Windows.Forms.ColumnHeader columnHeader2;
		public System.Windows.Forms.ColumnHeader columnHeader1;
		public System.Windows.Forms.ListView LstLojas;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.GroupBox groupBox2;
		public System.Windows.Forms.GroupBox groupBox1;
	}
}

