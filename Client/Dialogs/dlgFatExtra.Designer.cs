using System.Windows.Forms;

namespace Client 
{
	partial class dlgFatExtra : Form
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
			this.TxtCodigo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.CboTipo = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtExtra = new System.Windows.Forms.TextBox();
			this.TxtCobranca = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.ChkDesconto = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// TxtCodigo
			// 
			this.TxtCodigo.Location = new System.Drawing.Point(68, 50);
			this.TxtCodigo.Name = "TxtCodigo";
			this.TxtCodigo.Size = new System.Drawing.Size(65, 20);
			this.TxtCodigo.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "Código";
			// 
			// CboTipo
			// 
			this.CboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboTipo.FormattingEnabled = true;
			this.CboTipo.Items.AddRange(new object[] {
									"Empresa ou Associação",
									"Loja"});
			this.CboTipo.Location = new System.Drawing.Point(68, 18);
			this.CboTipo.Name = "CboTipo";
			this.CboTipo.Size = new System.Drawing.Size(198, 21);
			this.CboTipo.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Tipo";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 84);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(135, 23);
			this.label3.TabIndex = 8;
			this.label3.Text = "Loja ou Empresa";
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(12, 102);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.ReadOnly = true;
			this.TxtNome.Size = new System.Drawing.Size(254, 20);
			this.TxtNome.TabIndex = 9;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(104, 220);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(81, 23);
			this.BtnConfirmar.TabIndex = 10;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 133);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(135, 23);
			this.label4.TabIndex = 11;
			this.label4.Text = "Descrição da fatura";
			// 
			// TxtExtra
			// 
			this.TxtExtra.Location = new System.Drawing.Point(12, 151);
			this.TxtExtra.MaxLength = 31;
			this.TxtExtra.Name = "TxtExtra";
			this.TxtExtra.Size = new System.Drawing.Size(254, 20);
			this.TxtExtra.TabIndex = 12;
			// 
			// TxtCobranca
			// 
			this.TxtCobranca.Location = new System.Drawing.Point(68, 183);
			this.TxtCobranca.Name = "TxtCobranca";
			this.TxtCobranca.Size = new System.Drawing.Size(81, 20);
			this.TxtCobranca.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(12, 185);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 23);
			this.label5.TabIndex = 14;
			this.label5.Text = "Valor";
			// 
			// ChkDesconto
			// 
			this.ChkDesconto.Location = new System.Drawing.Point(173, 181);
			this.ChkDesconto.Name = "ChkDesconto";
			this.ChkDesconto.Size = new System.Drawing.Size(104, 24);
			this.ChkDesconto.TabIndex = 15;
			this.ChkDesconto.Text = "Desconto";
			this.ChkDesconto.UseVisualStyleBackColor = true;
			// 
			// dlgFatExtra
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(289, 255);
			this.Controls.Add(this.ChkDesconto);
			this.Controls.Add(this.TxtCobranca);
			this.Controls.Add(this.TxtExtra);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.TxtNome);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.TxtCodigo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.CboTipo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label5);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgFatExtra";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Fatura Extra";
			this.Load += new System.EventHandler(this.DlgFatExtraLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.CheckBox ChkDesconto;
		public System.Windows.Forms.TextBox TxtExtra;
		public System.Windows.Forms.TextBox TxtCobranca;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox TxtNome;
		private System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.ComboBox CboTipo;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox TxtCodigo;
	}
}

