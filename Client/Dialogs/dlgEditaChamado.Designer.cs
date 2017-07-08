using System.Windows.Forms;

namespace Client 
{
	partial class dlgEditaChamado : Form
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
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtLoja = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.CboOpers = new System.Windows.Forms.ComboBox();
			this.TxtDesc = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtNewSolution = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.TxtDtAbertura = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.TxtDtFechamento = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.CboSit = new System.Windows.Forms.ComboBox();
			this.BtnAlterar = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.CboCateg = new System.Windows.Forms.ComboBox();
			this.TxtHist = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(339, 18);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.ReadOnly = true;
			this.TxtNome.Size = new System.Drawing.Size(213, 20);
			this.TxtNome.TabIndex = 12;
			this.TxtNome.TabStop = false;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(281, 21);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 11;
			this.label4.Text = "Nome";
			// 
			// TxtLoja
			// 
			this.TxtLoja.Location = new System.Drawing.Point(85, 18);
			this.TxtLoja.Name = "TxtLoja";
			this.TxtLoja.ReadOnly = true;
			this.TxtLoja.Size = new System.Drawing.Size(180, 20);
			this.TxtLoja.TabIndex = 10;
			this.TxtLoja.TabStop = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 9;
			this.label1.Text = "Cód. Loja";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(15, 290);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(110, 23);
			this.label2.TabIndex = 13;
			this.label2.Text = "Mudar para operador";
			// 
			// CboOpers
			// 
			this.CboOpers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboOpers.FormattingEnabled = true;
			this.CboOpers.Location = new System.Drawing.Point(143, 287);
			this.CboOpers.Name = "CboOpers";
			this.CboOpers.Size = new System.Drawing.Size(121, 21);
			this.CboOpers.TabIndex = 1;
			// 
			// TxtDesc
			// 
			this.TxtDesc.Location = new System.Drawing.Point(16, 69);
			this.TxtDesc.MaxLength = 600;
			this.TxtDesc.Multiline = true;
			this.TxtDesc.Name = "TxtDesc";
			this.TxtDesc.ReadOnly = true;
			this.TxtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TxtDesc.Size = new System.Drawing.Size(249, 81);
			this.TxtDesc.TabIndex = 16;
			this.TxtDesc.TabStop = false;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 51);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(160, 23);
			this.label3.TabIndex = 15;
			this.label3.Text = "Motivo do chamado";
			// 
			// TxtNewSolution
			// 
			this.TxtNewSolution.Location = new System.Drawing.Point(281, 69);
			this.TxtNewSolution.MaxLength = 600;
			this.TxtNewSolution.Multiline = true;
			this.TxtNewSolution.Name = "TxtNewSolution";
			this.TxtNewSolution.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TxtNewSolution.Size = new System.Drawing.Size(271, 81);
			this.TxtNewSolution.TabIndex = 0;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(281, 51);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(154, 23);
			this.label5.TabIndex = 17;
			this.label5.Text = "Andamento da solução";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 220);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 19;
			this.label6.Text = "Data Abertura";
			// 
			// TxtDtAbertura
			// 
			this.TxtDtAbertura.Location = new System.Drawing.Point(144, 217);
			this.TxtDtAbertura.Name = "TxtDtAbertura";
			this.TxtDtAbertura.ReadOnly = true;
			this.TxtDtAbertura.Size = new System.Drawing.Size(121, 20);
			this.TxtDtAbertura.TabIndex = 20;
			this.TxtDtAbertura.TabStop = false;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 253);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 21;
			this.label7.Text = "Data Fechamento";
			// 
			// TxtDtFechamento
			// 
			this.TxtDtFechamento.Location = new System.Drawing.Point(144, 250);
			this.TxtDtFechamento.Name = "TxtDtFechamento";
			this.TxtDtFechamento.ReadOnly = true;
			this.TxtDtFechamento.Size = new System.Drawing.Size(121, 20);
			this.TxtDtFechamento.TabIndex = 22;
			this.TxtDtFechamento.TabStop = false;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(15, 324);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(110, 23);
			this.label8.TabIndex = 23;
			this.label8.Text = "Mudar para situação";
			// 
			// CboSit
			// 
			this.CboSit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboSit.FormattingEnabled = true;
			this.CboSit.Items.AddRange(new object[] {
									"Aberto",
									"Fechado"});
			this.CboSit.Location = new System.Drawing.Point(144, 321);
			this.CboSit.Name = "CboSit";
			this.CboSit.Size = new System.Drawing.Size(121, 21);
			this.CboSit.TabIndex = 2;
			// 
			// BtnAlterar
			// 
			this.BtnAlterar.Location = new System.Drawing.Point(16, 361);
			this.BtnAlterar.Name = "BtnAlterar";
			this.BtnAlterar.Size = new System.Drawing.Size(75, 23);
			this.BtnAlterar.TabIndex = 3;
			this.BtnAlterar.Text = "Alterar";
			this.BtnAlterar.UseVisualStyleBackColor = true;
			this.BtnAlterar.Click += new System.EventHandler(this.BtnAlterarClick);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(278, 163);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 23);
			this.label9.TabIndex = 26;
			this.label9.Text = "Histórico";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(16, 163);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(110, 23);
			this.label10.TabIndex = 28;
			this.label10.Text = "Categoria";
			// 
			// CboCateg
			// 
			this.CboCateg.BackColor = System.Drawing.SystemColors.Control;
			this.CboCateg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboCateg.Enabled = false;
			this.CboCateg.FormattingEnabled = true;
			this.CboCateg.Items.AddRange(new object[] {
									"Área Comercial - REME",
									"Atualização VNC",
									"Cancelamento de Transações",
									"Conexão",
									"Conexão (Fatura)",
									"Conexão 0800",
									"Expedição",
									"Hardware",
									"Hardware (Fatura)",
									"Impressora",
									"Instalação",
									"Instalação ADSL",
									"Liberação de Contrato",
									"Pendência",
									"Pendência de Cliente",
									"Pós-Atendimento",
									"Pré-Instalação",
									"Reinstalação",
									"Reinstalação (Fatura)",
									"Retreinamento",
									"Retreinamento (Fatura)",
									"Software (Fatura)",
									"Software - Atualização",
									"Substituição de Equipamento",
									"Transação",
									"Treinamento",
									"Usuário Intranet",
									"Usuário Net"});
			this.CboCateg.Location = new System.Drawing.Point(16, 182);
			this.CboCateg.Name = "CboCateg";
			this.CboCateg.Size = new System.Drawing.Size(249, 21);
			this.CboCateg.TabIndex = 29;
			this.CboCateg.TabStop = false;
			// 
			// TxtHist
			// 
			this.TxtHist.BackColor = System.Drawing.SystemColors.Control;
			this.TxtHist.Location = new System.Drawing.Point(281, 182);
			this.TxtHist.MaxLength = 600;
			this.TxtHist.Multiline = true;
			this.TxtHist.Name = "TxtHist";
			this.TxtHist.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TxtHist.Size = new System.Drawing.Size(271, 160);
			this.TxtHist.TabIndex = 30;
			this.TxtHist.TabStop = false;
			// 
			// dlgEditaChamado
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(570, 400);
			this.Controls.Add(this.TxtHist);
			this.Controls.Add(this.CboCateg);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.BtnAlterar);
			this.Controls.Add(this.CboSit);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.TxtDtFechamento);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.TxtDtAbertura);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.TxtNewSolution);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.TxtDesc);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.CboOpers);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TxtNome);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.TxtLoja);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgEditaChamado";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Informações sobre chamado";
			this.Load += new System.EventHandler(this.DlgEditaChamadoLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.ComboBox CboOpers;
		public System.Windows.Forms.TextBox TxtDtFechamento;
		public System.Windows.Forms.ComboBox CboCateg;
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.TextBox TxtNewSolution;
		public System.Windows.Forms.TextBox TxtHist;
		public System.Windows.Forms.Label label10;
		public System.Windows.Forms.Label label9;
		public System.Windows.Forms.Button BtnAlterar;
		public System.Windows.Forms.ComboBox CboSit;
		public System.Windows.Forms.Label label8;
		public System.Windows.Forms.Label label7;
		public System.Windows.Forms.TextBox TxtDtAbertura;
		public System.Windows.Forms.Label label6;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox TxtDesc;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox TxtLoja;
		public System.Windows.Forms.Label label4;
	}
}

