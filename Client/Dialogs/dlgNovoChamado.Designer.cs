using System.Windows.Forms;

namespace Client 
{
	partial class dlgNovoChamado : Form
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
			this.TxtLoja = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtDesc = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.CboPrioridade = new System.Windows.Forms.ComboBox();
			this.ChkTecnico = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.CboCateg = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(15, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Cód. Loja";
			// 
			// TxtLoja
			// 
			this.TxtLoja.Location = new System.Drawing.Point(84, 16);
			this.TxtLoja.Name = "TxtLoja";
			this.TxtLoja.Size = new System.Drawing.Size(60, 20);
			this.TxtLoja.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(15, 82);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Descrição";
			// 
			// TxtDesc
			// 
			this.TxtDesc.Location = new System.Drawing.Point(15, 98);
			this.TxtDesc.MaxLength = 600;
			this.TxtDesc.Multiline = true;
			this.TxtDesc.Name = "TxtDesc";
			this.TxtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TxtDesc.Size = new System.Drawing.Size(249, 113);
			this.TxtDesc.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(15, 226);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Prioridade";
			// 
			// CboPrioridade
			// 
			this.CboPrioridade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboPrioridade.FormattingEnabled = true;
			this.CboPrioridade.Items.AddRange(new object[] {
									"Urgente",
									"Alta",
									"Média",
									"Baixa",
									"Nenhuma"});
			this.CboPrioridade.Location = new System.Drawing.Point(84, 223);
			this.CboPrioridade.Name = "CboPrioridade";
			this.CboPrioridade.Size = new System.Drawing.Size(180, 21);
			this.CboPrioridade.TabIndex = 3;
			// 
			// ChkTecnico
			// 
			this.ChkTecnico.Location = new System.Drawing.Point(84, 282);
			this.ChkTecnico.Name = "ChkTecnico";
			this.ChkTecnico.Size = new System.Drawing.Size(130, 24);
			this.ChkTecnico.TabIndex = 5;
			this.ChkTecnico.Text = "Requer visita técnica";
			this.ChkTecnico.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(15, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Nome";
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(84, 45);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.ReadOnly = true;
			this.TxtNome.Size = new System.Drawing.Size(180, 20);
			this.TxtNome.TabIndex = 8;
			this.TxtNome.TabStop = false;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(105, 319);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 6;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(15, 255);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 10;
			this.label5.Text = "Categoria";
			// 
			// CboCateg
			// 
			this.CboCateg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
			this.CboCateg.Location = new System.Drawing.Point(84, 252);
			this.CboCateg.Name = "CboCateg";
			this.CboCateg.Size = new System.Drawing.Size(180, 21);
			this.CboCateg.TabIndex = 4;
			// 
			// dlgNovoChamado
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 352);
			this.Controls.Add(this.CboCateg);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.TxtNome);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.ChkTecnico);
			this.Controls.Add(this.CboPrioridade);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.TxtDesc);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TxtLoja);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgNovoChamado";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Novo Chamado";
			this.Load += new System.EventHandler(this.DlgNovoChamadoLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.ComboBox CboPrioridade;
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.ComboBox CboCateg;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button BtnConfirmar;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox TxtLoja;
		public System.Windows.Forms.TextBox TxtDesc;
		public System.Windows.Forms.CheckBox ChkTecnico;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}

