using System.Windows.Forms;

namespace Client 
{
	partial class dlgConsultaAuditoria : Form
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.CboOper = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.TxtObs = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.TxtDtFim = new System.Windows.Forms.TextBox();
			this.TxtDtIni = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.BtnConsultar = new System.Windows.Forms.Button();
			this.LstAuditoria = new System.Windows.Forms.ListView();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new System.Drawing.Point(18, 26);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(515, 105);
			this.tabControl1.TabIndex = 6;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.TxtNome);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(507, 79);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Usuário";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(117, 25);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.Size = new System.Drawing.Size(144, 20);
			this.TxtNome.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(11, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nome";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.CboOper);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(507, 79);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Operação";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// CboOper
			// 
			this.CboOper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboOper.FormattingEnabled = true;
			this.CboOper.Location = new System.Drawing.Point(117, 25);
			this.CboOper.Name = "CboOper";
			this.CboOper.Size = new System.Drawing.Size(371, 21);
			this.CboOper.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(11, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Operação";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.TxtObs);
			this.tabPage3.Controls.Add(this.label3);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(507, 79);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Observação";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// TxtObs
			// 
			this.TxtObs.Location = new System.Drawing.Point(117, 25);
			this.TxtObs.Name = "TxtObs";
			this.TxtObs.Size = new System.Drawing.Size(144, 20);
			this.TxtObs.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(11, 28);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Observação";
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.TxtDtFim);
			this.tabPage4.Controls.Add(this.TxtDtIni);
			this.tabPage4.Controls.Add(this.label5);
			this.tabPage4.Controls.Add(this.label4);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(507, 79);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Período";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// TxtDtFim
			// 
			this.TxtDtFim.Location = new System.Drawing.Point(113, 46);
			this.TxtDtFim.Name = "TxtDtFim";
			this.TxtDtFim.Size = new System.Drawing.Size(98, 20);
			this.TxtDtFim.TabIndex = 6;
			// 
			// TxtDtIni
			// 
			this.TxtDtIni.Location = new System.Drawing.Point(113, 15);
			this.TxtDtIni.Name = "TxtDtIni";
			this.TxtDtIni.Size = new System.Drawing.Size(98, 20);
			this.TxtDtIni.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(21, 49);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 4;
			this.label5.Text = "Data Final";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(21, 18);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 3;
			this.label4.Text = "Data Inicial";
			// 
			// BtnConsultar
			// 
			this.BtnConsultar.Location = new System.Drawing.Point(18, 142);
			this.BtnConsultar.Name = "BtnConsultar";
			this.BtnConsultar.Size = new System.Drawing.Size(75, 23);
			this.BtnConsultar.TabIndex = 7;
			this.BtnConsultar.Text = "Consultar";
			this.BtnConsultar.UseVisualStyleBackColor = true;
			this.BtnConsultar.Click += new System.EventHandler(this.BtnConsultarClick);
			// 
			// LstAuditoria
			// 
			this.LstAuditoria.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader8,
									this.columnHeader9,
									this.columnHeader10,
									this.columnHeader11,
									this.columnHeader12});
			this.LstAuditoria.FullRowSelect = true;
			this.LstAuditoria.HideSelection = false;
			this.LstAuditoria.Location = new System.Drawing.Point(18, 179);
			this.LstAuditoria.MultiSelect = false;
			this.LstAuditoria.Name = "LstAuditoria";
			this.LstAuditoria.Size = new System.Drawing.Size(515, 205);
			this.LstAuditoria.TabIndex = 8;
			this.LstAuditoria.UseCompatibleStateImageBehavior = false;
			this.LstAuditoria.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Data";
			this.columnHeader8.Width = 110;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Usuário";
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Operação";
			this.columnHeader10.Width = 150;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "Observação";
			this.columnHeader11.Width = 100;
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "Link";
			// 
			// dlgConsultaAuditoria
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(552, 407);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.BtnConsultar);
			this.Controls.Add(this.LstAuditoria);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgConsultaAuditoria";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Registro de Auditoria";
			this.Load += new System.EventHandler(this.DlgConsultaAuditoriaLoad);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.TextBox TxtDtIni;
		public System.Windows.Forms.TextBox TxtDtFim;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.ComboBox CboOper;
		public System.Windows.Forms.ListView LstAuditoria;
		public System.Windows.Forms.TextBox TxtObs;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		public System.Windows.Forms.Button BtnConsultar;
		public System.Windows.Forms.TabPage tabPage4;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.TabPage tabPage3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.TabPage tabPage2;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.TabPage tabPage1;
		public System.Windows.Forms.TabControl tabControl1;
	}
}

