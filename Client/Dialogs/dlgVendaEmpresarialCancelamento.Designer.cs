using System.Windows.Forms;

namespace Client 
{
	partial class dlgVendaEmpresarialCancelamento : Form
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
			this.TxtNSU = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtCartao = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtData = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.TxtValor = new System.Windows.Forms.TextBox();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.TxtDtIni = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(20, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "NSU";
			// 
			// TxtNSU
			// 
			this.TxtNSU.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtNSU.Location = new System.Drawing.Point(96, 18);
			this.TxtNSU.Name = "TxtNSU";
			this.TxtNSU.Size = new System.Drawing.Size(182, 20);
			this.TxtNSU.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(20, 73);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Proprietário";
			// 
			// TxtNome
			// 
			this.TxtNome.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtNome.Location = new System.Drawing.Point(96, 70);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.ReadOnly = true;
			this.TxtNome.Size = new System.Drawing.Size(182, 20);
			this.TxtNome.TabIndex = 3;
			this.TxtNome.TabStop = false;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(20, 99);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Cartão";
			// 
			// TxtCartao
			// 
			this.TxtCartao.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtCartao.Location = new System.Drawing.Point(96, 96);
			this.TxtCartao.Name = "TxtCartao";
			this.TxtCartao.ReadOnly = true;
			this.TxtCartao.Size = new System.Drawing.Size(182, 20);
			this.TxtCartao.TabIndex = 5;
			this.TxtCartao.TabStop = false;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(20, 125);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Data e Hora";
			// 
			// TxtData
			// 
			this.TxtData.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtData.Location = new System.Drawing.Point(96, 122);
			this.TxtData.Name = "TxtData";
			this.TxtData.ReadOnly = true;
			this.TxtData.Size = new System.Drawing.Size(182, 20);
			this.TxtData.TabIndex = 7;
			this.TxtData.TabStop = false;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label5.Location = new System.Drawing.Point(20, 151);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 8;
			this.label5.Text = "Valor";
			// 
			// TxtValor
			// 
			this.TxtValor.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtValor.Location = new System.Drawing.Point(96, 148);
			this.TxtValor.Name = "TxtValor";
			this.TxtValor.ReadOnly = true;
			this.TxtValor.Size = new System.Drawing.Size(182, 20);
			this.TxtValor.TabIndex = 9;
			this.TxtValor.TabStop = false;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BtnConfirmar.Location = new System.Drawing.Point(176, 190);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(102, 23);
			this.BtnConfirmar.TabIndex = 3;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// TxtDtIni
			// 
			this.TxtDtIni.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtDtIni.Location = new System.Drawing.Point(96, 44);
			this.TxtDtIni.Name = "TxtDtIni";
			this.TxtDtIni.Size = new System.Drawing.Size(182, 20);
			this.TxtDtIni.TabIndex = 2;
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label6.Location = new System.Drawing.Point(20, 47);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 12;
			this.label6.Text = "Dia Venda";
			// 
			// dlgVendaEmpresarialCancelamento
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(301, 225);
			this.Controls.Add(this.TxtDtIni);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.TxtValor);
			this.Controls.Add(this.TxtData);
			this.Controls.Add(this.TxtCartao);
			this.Controls.Add(this.TxtNome);
			this.Controls.Add(this.TxtNSU);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label6);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgVendaEmpresarialCancelamento";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cancelamento de Venda";
			this.Load += new System.EventHandler(this.DlgVendaEmpresarialCancelamentoLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtDtIni;
		private System.Windows.Forms.Label label6;
		public System.Windows.Forms.TextBox TxtData;
		private System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.TextBox TxtValor;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox TxtCartao;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox TxtNome;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox TxtNSU;
		private System.Windows.Forms.Label label1;
	}
}

