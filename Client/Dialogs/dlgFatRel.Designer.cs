using System.Windows.Forms;

namespace Client 
{
	partial class dlgFatRel : Form
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
			this.TxtDtFim = new System.Windows.Forms.TextBox();
			this.TxtDtIni = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.CboRelat = new System.Windows.Forms.ComboBox();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label1.Location = new System.Drawing.Point(17, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(184, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Período de vencimento da fatura";
			// 
			// TxtDtFim
			// 
			this.TxtDtFim.Location = new System.Drawing.Point(147, 55);
			this.TxtDtFim.Name = "TxtDtFim";
			this.TxtDtFim.Size = new System.Drawing.Size(100, 20);
			this.TxtDtFim.TabIndex = 7;
			// 
			// TxtDtIni
			// 
			this.TxtDtIni.Location = new System.Drawing.Point(17, 55);
			this.TxtDtIni.Name = "TxtDtIni";
			this.TxtDtIni.Size = new System.Drawing.Size(100, 20);
			this.TxtDtIni.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(147, 38);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 5;
			this.label4.Text = "Vencimento final";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(17, 38);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 4;
			this.label5.Text = "Vencimento inicial";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(17, 92);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 8;
			this.label2.Text = "Tipo de relatório";
			// 
			// CboRelat
			// 
			this.CboRelat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboRelat.FormattingEnabled = true;
			this.CboRelat.Items.AddRange(new object[] {
									"Faturamento pronto para envio ao banco",
									"Faturamento em cobrança",
									"Faturamento pagos via DOC",
									"Faturamento pagos via débito em conta",
									"Faturamento conforme instrução do banco"});
			this.CboRelat.Location = new System.Drawing.Point(17, 111);
			this.CboRelat.Name = "CboRelat";
			this.CboRelat.Size = new System.Drawing.Size(230, 21);
			this.CboRelat.TabIndex = 9;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(17, 148);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(230, 23);
			this.BtnConfirmar.TabIndex = 10;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// dlgFatRel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(279, 191);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.CboRelat);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TxtDtFim);
			this.Controls.Add(this.TxtDtIni);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgFatRel";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Relatórios de Faturamento";
			this.Load += new System.EventHandler(this.DlgFatRelLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.ComboBox CboRelat;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox TxtDtIni;
		public System.Windows.Forms.TextBox TxtDtFim;
		public System.Windows.Forms.Label label1;
	}
}

