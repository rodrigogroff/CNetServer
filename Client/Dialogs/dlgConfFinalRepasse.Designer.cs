using System.Windows.Forms;

namespace Client 
{
	partial class dlgConfFinalRepasse : Form
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
			this.TxtValor = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.TxtConta = new System.Windows.Forms.TextBox();
			this.TxtAgencia = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtBanco = new System.Windows.Forms.TextBox();
			this.TxtIdent = new System.Windows.Forms.TextBox();
			this.rbDep = new System.Windows.Forms.RadioButton();
			this.rbCheque = new System.Windows.Forms.RadioButton();
			this.rbDinheiro = new System.Windows.Forms.RadioButton();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(15, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Loja";
			// 
			// TxtLoja
			// 
			this.TxtLoja.Location = new System.Drawing.Point(70, 16);
			this.TxtLoja.Name = "TxtLoja";
			this.TxtLoja.ReadOnly = true;
			this.TxtLoja.Size = new System.Drawing.Size(226, 20);
			this.TxtLoja.TabIndex = 1;
			this.TxtLoja.TabStop = false;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(15, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Valor";
			// 
			// TxtValor
			// 
			this.TxtValor.Location = new System.Drawing.Point(70, 49);
			this.TxtValor.Name = "TxtValor";
			this.TxtValor.ReadOnly = true;
			this.TxtValor.Size = new System.Drawing.Size(79, 20);
			this.TxtValor.TabIndex = 3;
			this.TxtValor.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.TxtConta);
			this.groupBox1.Controls.Add(this.TxtAgencia);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.TxtBanco);
			this.groupBox1.Controls.Add(this.TxtIdent);
			this.groupBox1.Controls.Add(this.rbDep);
			this.groupBox1.Controls.Add(this.rbCheque);
			this.groupBox1.Controls.Add(this.rbDinheiro);
			this.groupBox1.Location = new System.Drawing.Point(15, 86);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(281, 192);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Formas de pagamento";
			// 
			// TxtConta
			// 
			this.TxtConta.Location = new System.Drawing.Point(169, 149);
			this.TxtConta.Name = "TxtConta";
			this.TxtConta.ReadOnly = true;
			this.TxtConta.Size = new System.Drawing.Size(72, 20);
			this.TxtConta.TabIndex = 11;
			// 
			// TxtAgencia
			// 
			this.TxtAgencia.Location = new System.Drawing.Point(169, 121);
			this.TxtAgencia.Name = "TxtAgencia";
			this.TxtAgencia.ReadOnly = true;
			this.TxtAgencia.Size = new System.Drawing.Size(72, 20);
			this.TxtAgencia.TabIndex = 10;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(106, 152);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 23);
			this.label5.TabIndex = 9;
			this.label5.Text = "Conta";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(106, 124);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(57, 23);
			this.label4.TabIndex = 8;
			this.label4.Text = "Agência";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(106, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 23);
			this.label3.TabIndex = 7;
			this.label3.Text = "Banco";
			// 
			// TxtBanco
			// 
			this.TxtBanco.Location = new System.Drawing.Point(169, 93);
			this.TxtBanco.Name = "TxtBanco";
			this.TxtBanco.ReadOnly = true;
			this.TxtBanco.Size = new System.Drawing.Size(72, 20);
			this.TxtBanco.TabIndex = 6;
			// 
			// TxtIdent
			// 
			this.TxtIdent.Location = new System.Drawing.Point(96, 62);
			this.TxtIdent.Name = "TxtIdent";
			this.TxtIdent.Size = new System.Drawing.Size(145, 20);
			this.TxtIdent.TabIndex = 5;
			// 
			// rbDep
			// 
			this.rbDep.Location = new System.Drawing.Point(18, 90);
			this.rbDep.Name = "rbDep";
			this.rbDep.Size = new System.Drawing.Size(104, 24);
			this.rbDep.TabIndex = 2;
			this.rbDep.TabStop = true;
			this.rbDep.Text = "Depósito";
			this.rbDep.UseVisualStyleBackColor = true;
			// 
			// rbCheque
			// 
			this.rbCheque.Location = new System.Drawing.Point(18, 59);
			this.rbCheque.Name = "rbCheque";
			this.rbCheque.Size = new System.Drawing.Size(104, 24);
			this.rbCheque.TabIndex = 1;
			this.rbCheque.TabStop = true;
			this.rbCheque.Text = "Cheque";
			this.rbCheque.UseVisualStyleBackColor = true;
			// 
			// rbDinheiro
			// 
			this.rbDinheiro.Location = new System.Drawing.Point(18, 29);
			this.rbDinheiro.Name = "rbDinheiro";
			this.rbDinheiro.Size = new System.Drawing.Size(104, 24);
			this.rbDinheiro.TabIndex = 0;
			this.rbDinheiro.TabStop = true;
			this.rbDinheiro.Text = "Dinheiro";
			this.rbDinheiro.UseVisualStyleBackColor = true;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(115, 297);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 5;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// dlgConfFinalRepasse
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(310, 333);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.TxtValor);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TxtLoja);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgConfFinalRepasse";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Finalizando Repasse";
			this.Load += new System.EventHandler(this.DlgConfFinalRepasseLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtIdent;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.TextBox TxtAgencia;
		public System.Windows.Forms.TextBox TxtConta;
		public System.Windows.Forms.TextBox TxtBanco;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.RadioButton rbDep;
		public System.Windows.Forms.RadioButton rbCheque;
		public System.Windows.Forms.RadioButton rbDinheiro;
		public System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.TextBox TxtValor;
		public System.Windows.Forms.TextBox TxtLoja;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
	}
}

