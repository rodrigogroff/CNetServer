using System.Windows.Forms;

namespace Client 
{
	partial class dlgEducacional : Form
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
			this.TxtCartao = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtAluno = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.BtnAlterar = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.TxtDin = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.TxtEdu = new System.Windows.Forms.TextBox();
			this.TxtExtra = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.BtnPagamento = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.TxtDiario = new System.Windows.Forms.TextBox();
			this.TxtMensal = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.TxtVrDispMensal = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.TxtSaldoTotal = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.TxtVrDispDiario = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.TxtVrSaldoMes = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.TxtVrDisp = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.TxtDtFim = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.TxtDtIni = new System.Windows.Forms.TextBox();
			this.BtnExtrato = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.TxtEmpresa = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(198, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Cartão";
			// 
			// TxtCartao
			// 
			this.TxtCartao.Location = new System.Drawing.Point(243, 12);
			this.TxtCartao.Name = "TxtCartao";
			this.TxtCartao.Size = new System.Drawing.Size(112, 20);
			this.TxtCartao.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(18, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Aluno";
			// 
			// TxtAluno
			// 
			this.TxtAluno.Location = new System.Drawing.Point(74, 48);
			this.TxtAluno.Name = "TxtAluno";
			this.TxtAluno.ReadOnly = true;
			this.TxtAluno.Size = new System.Drawing.Size(281, 20);
			this.TxtAluno.TabIndex = 3;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Location = new System.Drawing.Point(18, 88);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(341, 296);
			this.tabControl1.TabIndex = 4;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.BtnAlterar);
			this.tabPage2.Controls.Add(this.groupBox2);
			this.tabPage2.Controls.Add(this.BtnPagamento);
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(333, 270);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Recibos";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// BtnAlterar
			// 
			this.BtnAlterar.Location = new System.Drawing.Point(256, 68);
			this.BtnAlterar.Name = "BtnAlterar";
			this.BtnAlterar.Size = new System.Drawing.Size(62, 23);
			this.BtnAlterar.TabIndex = 4;
			this.BtnAlterar.Text = "Definir";
			this.BtnAlterar.UseVisualStyleBackColor = true;
			this.BtnAlterar.Click += new System.EventHandler(this.BtnAlterarClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.TxtDin);
			this.groupBox2.Controls.Add(this.label16);
			this.groupBox2.Controls.Add(this.TxtEdu);
			this.groupBox2.Controls.Add(this.TxtExtra);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Location = new System.Drawing.Point(17, 125);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(223, 114);
			this.groupBox2.TabIndex = 19;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Entrada de Valores";
			// 
			// TxtDin
			// 
			this.TxtDin.Location = new System.Drawing.Point(125, 84);
			this.TxtDin.Name = "TxtDin";
			this.TxtDin.ReadOnly = true;
			this.TxtDin.Size = new System.Drawing.Size(82, 20);
			this.TxtDin.TabIndex = 14;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(11, 87);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(131, 23);
			this.label16.TabIndex = 18;
			this.label16.Text = "Valor em dinheiro";
			// 
			// TxtEdu
			// 
			this.TxtEdu.Location = new System.Drawing.Point(125, 25);
			this.TxtEdu.Name = "TxtEdu";
			this.TxtEdu.Size = new System.Drawing.Size(82, 20);
			this.TxtEdu.TabIndex = 5;
			// 
			// TxtExtra
			// 
			this.TxtExtra.Location = new System.Drawing.Point(125, 54);
			this.TxtExtra.Name = "TxtExtra";
			this.TxtExtra.Size = new System.Drawing.Size(82, 20);
			this.TxtExtra.TabIndex = 6;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(11, 57);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(131, 23);
			this.label7.TabIndex = 16;
			this.label7.Text = "Disp. Imediato";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(11, 28);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(131, 23);
			this.label6.TabIndex = 14;
			this.label6.Text = "Fundo Educacional";
			// 
			// BtnPagamento
			// 
			this.BtnPagamento.Location = new System.Drawing.Point(256, 207);
			this.BtnPagamento.Name = "BtnPagamento";
			this.BtnPagamento.Size = new System.Drawing.Size(62, 23);
			this.BtnPagamento.TabIndex = 7;
			this.BtnPagamento.Text = "Confirmar";
			this.BtnPagamento.UseVisualStyleBackColor = true;
			this.BtnPagamento.Click += new System.EventHandler(this.BtnPagamentoClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.TxtDiario);
			this.groupBox1.Controls.Add(this.TxtMensal);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(17, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(223, 89);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Definição de Limites";
			// 
			// TxtDiario
			// 
			this.TxtDiario.Location = new System.Drawing.Point(125, 25);
			this.TxtDiario.Name = "TxtDiario";
			this.TxtDiario.ReadOnly = true;
			this.TxtDiario.Size = new System.Drawing.Size(82, 20);
			this.TxtDiario.TabIndex = 3;
			// 
			// TxtMensal
			// 
			this.TxtMensal.Location = new System.Drawing.Point(125, 54);
			this.TxtMensal.Name = "TxtMensal";
			this.TxtMensal.Size = new System.Drawing.Size(82, 20);
			this.TxtMensal.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(11, 28);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 10;
			this.label3.Text = "Valor Diário";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(11, 57);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(117, 23);
			this.label4.TabIndex = 12;
			this.label4.Text = "Aprox. Valor Mensal";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.TxtVrDispMensal);
			this.tabPage3.Controls.Add(this.label14);
			this.tabPage3.Controls.Add(this.TxtSaldoTotal);
			this.tabPage3.Controls.Add(this.label13);
			this.tabPage3.Controls.Add(this.TxtVrDispDiario);
			this.tabPage3.Controls.Add(this.label10);
			this.tabPage3.Controls.Add(this.TxtVrSaldoMes);
			this.tabPage3.Controls.Add(this.label9);
			this.tabPage3.Controls.Add(this.TxtVrDisp);
			this.tabPage3.Controls.Add(this.label8);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(333, 270);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Saldo";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// TxtVrDispMensal
			// 
			this.TxtVrDispMensal.Location = new System.Drawing.Point(158, 95);
			this.TxtVrDispMensal.Name = "TxtVrDispMensal";
			this.TxtVrDispMensal.ReadOnly = true;
			this.TxtVrDispMensal.Size = new System.Drawing.Size(100, 20);
			this.TxtVrDispMensal.TabIndex = 15;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(23, 98);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(115, 23);
			this.label14.TabIndex = 14;
			this.label14.Text = "Valor Mensal definido";
			// 
			// TxtSaldoTotal
			// 
			this.TxtSaldoTotal.Location = new System.Drawing.Point(158, 166);
			this.TxtSaldoTotal.Name = "TxtSaldoTotal";
			this.TxtSaldoTotal.ReadOnly = true;
			this.TxtSaldoTotal.Size = new System.Drawing.Size(100, 20);
			this.TxtSaldoTotal.TabIndex = 13;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(23, 169);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(160, 23);
			this.label13.TabIndex = 12;
			this.label13.Text = "Saldo a liberar em fundo";
			// 
			// TxtVrDispDiario
			// 
			this.TxtVrDispDiario.Location = new System.Drawing.Point(158, 59);
			this.TxtVrDispDiario.Name = "TxtVrDispDiario";
			this.TxtVrDispDiario.ReadOnly = true;
			this.TxtVrDispDiario.Size = new System.Drawing.Size(100, 20);
			this.TxtVrDispDiario.TabIndex = 11;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(23, 62);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(115, 23);
			this.label10.TabIndex = 10;
			this.label10.Text = "Valor Diário definido";
			// 
			// TxtVrSaldoMes
			// 
			this.TxtVrSaldoMes.Location = new System.Drawing.Point(158, 130);
			this.TxtVrSaldoMes.Name = "TxtVrSaldoMes";
			this.TxtVrSaldoMes.ReadOnly = true;
			this.TxtVrSaldoMes.Size = new System.Drawing.Size(100, 20);
			this.TxtVrSaldoMes.TabIndex = 9;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(23, 133);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(160, 23);
			this.label9.TabIndex = 8;
			this.label9.Text = "Saldo até o fim do mês";
			// 
			// TxtVrDisp
			// 
			this.TxtVrDisp.Location = new System.Drawing.Point(158, 23);
			this.TxtVrDisp.Name = "TxtVrDisp";
			this.TxtVrDisp.ReadOnly = true;
			this.TxtVrDisp.Size = new System.Drawing.Size(100, 20);
			this.TxtVrDisp.TabIndex = 7;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(23, 26);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(160, 23);
			this.label8.TabIndex = 6;
			this.label8.Text = "Disponível imediato";
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.TxtDtFim);
			this.tabPage4.Controls.Add(this.label15);
			this.tabPage4.Controls.Add(this.TxtDtIni);
			this.tabPage4.Controls.Add(this.BtnExtrato);
			this.tabPage4.Controls.Add(this.label5);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(333, 270);
			this.tabPage4.TabIndex = 4;
			this.tabPage4.Text = "Extrato";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// TxtDtFim
			// 
			this.TxtDtFim.Location = new System.Drawing.Point(127, 46);
			this.TxtDtFim.Name = "TxtDtFim";
			this.TxtDtFim.Size = new System.Drawing.Size(73, 20);
			this.TxtDtFim.TabIndex = 11;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(21, 49);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(100, 23);
			this.label15.TabIndex = 26;
			this.label15.Text = "Periodo Final";
			// 
			// TxtDtIni
			// 
			this.TxtDtIni.Location = new System.Drawing.Point(127, 15);
			this.TxtDtIni.Name = "TxtDtIni";
			this.TxtDtIni.Size = new System.Drawing.Size(73, 20);
			this.TxtDtIni.TabIndex = 10;
			// 
			// BtnExtrato
			// 
			this.BtnExtrato.Location = new System.Drawing.Point(21, 92);
			this.BtnExtrato.Name = "BtnExtrato";
			this.BtnExtrato.Size = new System.Drawing.Size(75, 23);
			this.BtnExtrato.TabIndex = 12;
			this.BtnExtrato.Text = "Extrato";
			this.BtnExtrato.UseVisualStyleBackColor = true;
			this.BtnExtrato.Click += new System.EventHandler(this.BtnExtratoClick);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(21, 18);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 25;
			this.label5.Text = "Periodo Inicial";
			// 
			// TxtEmpresa
			// 
			this.TxtEmpresa.Location = new System.Drawing.Point(74, 12);
			this.TxtEmpresa.Name = "TxtEmpresa";
			this.TxtEmpresa.Size = new System.Drawing.Size(112, 20);
			this.TxtEmpresa.TabIndex = 1;
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(18, 15);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(100, 23);
			this.label17.TabIndex = 6;
			this.label17.Text = "Empresa";
			// 
			// dlgEducacional
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(379, 408);
			this.Controls.Add(this.TxtEmpresa);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.TxtAluno);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TxtCartao);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label17);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgEducacional";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cartão Educacional";
			this.Load += new System.EventHandler(this.DlgEducacionalLoad);
			this.tabControl1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtEmpresa;
		public System.Windows.Forms.Label label17;
		public System.Windows.Forms.TextBox TxtDtFim;
		public System.Windows.Forms.TextBox TxtDin;
		public System.Windows.Forms.Label label16;
		public System.Windows.Forms.TextBox TxtAluno;
		public System.Windows.Forms.Button BtnExtrato;
		private System.Windows.Forms.Label label15;
		public System.Windows.Forms.TextBox TxtDtIni;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TabPage tabPage4;
		public System.Windows.Forms.TextBox TxtVrSaldoMes;
		public System.Windows.Forms.TextBox TxtSaldoTotal;
		public System.Windows.Forms.TextBox TxtVrDispMensal;
		public System.Windows.Forms.TextBox TxtVrDisp;
		public System.Windows.Forms.TextBox TxtVrDispDiario;
		public System.Windows.Forms.TextBox TxtEdu;
		public System.Windows.Forms.TextBox TxtExtra;
		public System.Windows.Forms.TextBox TxtDiario;
		public System.Windows.Forms.TextBox TxtMensal;
		public System.Windows.Forms.Button BtnAlterar;
		public System.Windows.Forms.GroupBox groupBox2;
		public System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.Label label14;
		public System.Windows.Forms.Label label13;
		public System.Windows.Forms.Label label8;
		public System.Windows.Forms.Label label7;
		public System.Windows.Forms.Label label6;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.Label label10;
		public System.Windows.Forms.Label label9;
		public System.Windows.Forms.Button BtnPagamento;
		public System.Windows.Forms.TabPage tabPage3;
		public System.Windows.Forms.TabPage tabPage2;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.TabControl tabControl1;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox TxtCartao;
		public System.Windows.Forms.Label label1;
	}
}

