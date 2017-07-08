using System.Windows.Forms;

namespace Client 
{
	partial class dlgCadastroAtividade : Form
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
			this.CboAtiv = new System.Windows.Forms.ComboBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.TxtMesHor = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.TxtDiaMes = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.CboDiaSem = new System.Windows.Forms.ComboBox();
			this.TxtSemHor = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.TxtDiaHor = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtEmpresa = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.CboAff = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 68);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tipo de atividade";
			// 
			// CboAtiv
			// 
			this.CboAtiv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboAtiv.FormattingEnabled = true;
			this.CboAtiv.Location = new System.Drawing.Point(16, 85);
			this.CboAtiv.Name = "CboAtiv";
			this.CboAtiv.Size = new System.Drawing.Size(264, 21);
			this.CboAtiv.TabIndex = 1;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new System.Drawing.Point(16, 202);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(268, 161);
			this.tabControl1.TabIndex = 2;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.TxtMesHor);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.TxtDiaMes);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(260, 135);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Mensal";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// TxtMesHor
			// 
			this.TxtMesHor.Location = new System.Drawing.Point(139, 79);
			this.TxtMesHor.Name = "TxtMesHor";
			this.TxtMesHor.Size = new System.Drawing.Size(57, 20);
			this.TxtMesHor.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(53, 82);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 2;
			this.label5.Text = "Horário:";
			// 
			// TxtDiaMes
			// 
			this.TxtDiaMes.Location = new System.Drawing.Point(139, 40);
			this.TxtDiaMes.Name = "TxtDiaMes";
			this.TxtDiaMes.Size = new System.Drawing.Size(57, 20);
			this.TxtDiaMes.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(53, 43);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "Dia do mês:";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.CboDiaSem);
			this.tabPage2.Controls.Add(this.TxtSemHor);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(260, 135);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Semanal";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// CboDiaSem
			// 
			this.CboDiaSem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboDiaSem.FormattingEnabled = true;
			this.CboDiaSem.Items.AddRange(new object[] {
									"Domingo",
									"Segunda",
									"Terça",
									"Quarta",
									"Quinta",
									"Sexta",
									"Sábado"});
			this.CboDiaSem.Location = new System.Drawing.Point(51, 38);
			this.CboDiaSem.Name = "CboDiaSem";
			this.CboDiaSem.Size = new System.Drawing.Size(131, 21);
			this.CboDiaSem.TabIndex = 6;
			// 
			// TxtSemHor
			// 
			this.TxtSemHor.Location = new System.Drawing.Point(125, 80);
			this.TxtSemHor.Name = "TxtSemHor";
			this.TxtSemHor.Size = new System.Drawing.Size(57, 20);
			this.TxtSemHor.TabIndex = 5;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(51, 83);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 4;
			this.label7.Text = "Horário:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(51, 19);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 0;
			this.label6.Text = "Dia da Semana:";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.TxtDiaHor);
			this.tabPage3.Controls.Add(this.label8);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(260, 135);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Diário";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// TxtDiaHor
			// 
			this.TxtDiaHor.Location = new System.Drawing.Point(124, 54);
			this.TxtDiaHor.Name = "TxtDiaHor";
			this.TxtDiaHor.Size = new System.Drawing.Size(57, 20);
			this.TxtDiaHor.TabIndex = 7;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(62, 57);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 23);
			this.label8.TabIndex = 6;
			this.label8.Text = "Horário:";
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(209, 373);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 3;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Empresa";
			// 
			// TxtEmpresa
			// 
			this.TxtEmpresa.Location = new System.Drawing.Point(16, 36);
			this.TxtEmpresa.Name = "TxtEmpresa";
			this.TxtEmpresa.Size = new System.Drawing.Size(77, 20);
			this.TxtEmpresa.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 180);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Agendamento";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(16, 118);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 23);
			this.label9.TabIndex = 7;
			this.label9.Text = "Empresa Afiliada";
			// 
			// CboAff
			// 
			this.CboAff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboAff.FormattingEnabled = true;
			this.CboAff.Location = new System.Drawing.Point(16, 135);
			this.CboAff.Name = "CboAff";
			this.CboAff.Size = new System.Drawing.Size(264, 21);
			this.CboAff.TabIndex = 8;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(116, 19);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 23);
			this.label10.TabIndex = 9;
			this.label10.Text = "Empresa";
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(116, 36);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.ReadOnly = true;
			this.TxtNome.Size = new System.Drawing.Size(164, 20);
			this.TxtNome.TabIndex = 10;
			// 
			// dlgCadastroAtividade
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(305, 411);
			this.Controls.Add(this.TxtNome);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.CboAff);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.TxtEmpresa);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.CboAtiv);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgCadastroAtividade";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cadastro de Atividade";
			this.Load += new System.EventHandler(this.DlgCadastroAtividadeLoad);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.Label label10;
		public System.Windows.Forms.ComboBox CboAff;
		public System.Windows.Forms.Label label9;
		public System.Windows.Forms.TextBox TxtEmpresa;
		public System.Windows.Forms.ComboBox CboAtiv;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.TextBox TxtDiaHor;
		public System.Windows.Forms.ComboBox CboDiaSem;
		public System.Windows.Forms.Label label8;
		public System.Windows.Forms.TextBox TxtSemHor;
		public System.Windows.Forms.TextBox TxtMesHor;
		public System.Windows.Forms.Label label7;
		public System.Windows.Forms.Label label6;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.TextBox TxtDiaMes;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.TabPage tabPage3;
		public System.Windows.Forms.TabPage tabPage2;
		public System.Windows.Forms.TabPage tabPage1;
		public System.Windows.Forms.TabControl tabControl1;
		public System.Windows.Forms.Label label1;
	}
}

