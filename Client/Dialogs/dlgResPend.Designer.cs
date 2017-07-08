using System.Windows.Forms;

namespace Client 
{
	partial class dlgResPend : Form
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
			this.TxtDtIni = new System.Windows.Forms.TextBox();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.TxtValor = new System.Windows.Forms.TextBox();
			this.TxtData = new System.Windows.Forms.TextBox();
			this.TxtCartao = new System.Windows.Forms.TextBox();
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.TxtNSU = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.BtnCancelar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TxtDtIni
			// 
			this.TxtDtIni.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtDtIni.Location = new System.Drawing.Point(93, 46);
			this.TxtDtIni.Name = "TxtDtIni";
			this.TxtDtIni.Size = new System.Drawing.Size(182, 20);
			this.TxtDtIni.TabIndex = 2;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BtnConfirmar.Location = new System.Drawing.Point(173, 192);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(102, 23);
			this.BtnConfirmar.TabIndex = 3;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// TxtValor
			// 
			this.TxtValor.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtValor.Location = new System.Drawing.Point(93, 150);
			this.TxtValor.Name = "TxtValor";
			this.TxtValor.ReadOnly = true;
			this.TxtValor.Size = new System.Drawing.Size(182, 20);
			this.TxtValor.TabIndex = 24;
			this.TxtValor.TabStop = false;
			// 
			// TxtData
			// 
			this.TxtData.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtData.Location = new System.Drawing.Point(93, 124);
			this.TxtData.Name = "TxtData";
			this.TxtData.ReadOnly = true;
			this.TxtData.Size = new System.Drawing.Size(182, 20);
			this.TxtData.TabIndex = 22;
			this.TxtData.TabStop = false;
			// 
			// TxtCartao
			// 
			this.TxtCartao.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtCartao.Location = new System.Drawing.Point(93, 98);
			this.TxtCartao.Name = "TxtCartao";
			this.TxtCartao.ReadOnly = true;
			this.TxtCartao.Size = new System.Drawing.Size(182, 20);
			this.TxtCartao.TabIndex = 20;
			this.TxtCartao.TabStop = false;
			// 
			// TxtNome
			// 
			this.TxtNome.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtNome.Location = new System.Drawing.Point(93, 72);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.ReadOnly = true;
			this.TxtNome.Size = new System.Drawing.Size(182, 20);
			this.TxtNome.TabIndex = 18;
			this.TxtNome.TabStop = false;
			// 
			// TxtNSU
			// 
			this.TxtNSU.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtNSU.Location = new System.Drawing.Point(93, 20);
			this.TxtNSU.Name = "TxtNSU";
			this.TxtNSU.Size = new System.Drawing.Size(182, 20);
			this.TxtNSU.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label5.Location = new System.Drawing.Point(17, 153);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 23;
			this.label5.Text = "Valor";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(17, 127);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 21;
			this.label4.Text = "Data e Hora";
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(17, 101);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 19;
			this.label3.Text = "Cartão";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(17, 75);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 16;
			this.label2.Text = "Proprietário";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(17, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 13;
			this.label1.Text = "NSU";
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label6.Location = new System.Drawing.Point(17, 49);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 25;
			this.label6.Text = "Dia Venda";
			// 
			// BtnCancelar
			// 
			this.BtnCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BtnCancelar.Location = new System.Drawing.Point(17, 192);
			this.BtnCancelar.Name = "BtnCancelar";
			this.BtnCancelar.Size = new System.Drawing.Size(102, 23);
			this.BtnCancelar.TabIndex = 4;
			this.BtnCancelar.Text = "Cancelar";
			this.BtnCancelar.UseVisualStyleBackColor = true;
			this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelarClick);
			// 
			// dlgResPend
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 244);
			this.Controls.Add(this.BtnCancelar);
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
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgResPend";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Resolução de pendência";
			this.Load += new System.EventHandler(this.DlgResPendLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button BtnCancelar;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		public System.Windows.Forms.TextBox TxtNSU;
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.TextBox TxtCartao;
		public System.Windows.Forms.TextBox TxtData;
		public System.Windows.Forms.TextBox TxtValor;
		private System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.TextBox TxtDtIni;
	}
}

