using System.Windows.Forms;

namespace Client 
{
	partial class dlgFinalGift : Form
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
			this.LblTotal = new System.Windows.Forms.Label();
			this.rbDinheiro = new System.Windows.Forms.RadioButton();
			this.rbCheque = new System.Windows.Forms.RadioButton();
			this.rbCartao = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtIdent = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.CboTipoCart = new System.Windows.Forms.ComboBox();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// LblTotal
			// 
			this.LblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblTotal.Location = new System.Drawing.Point(25, 28);
			this.LblTotal.Name = "LblTotal";
			this.LblTotal.Size = new System.Drawing.Size(152, 23);
			this.LblTotal.TabIndex = 0;
			// 
			// rbDinheiro
			// 
			this.rbDinheiro.Location = new System.Drawing.Point(19, 26);
			this.rbDinheiro.Name = "rbDinheiro";
			this.rbDinheiro.Size = new System.Drawing.Size(104, 24);
			this.rbDinheiro.TabIndex = 2;
			this.rbDinheiro.TabStop = true;
			this.rbDinheiro.Text = "Dinheiro";
			this.rbDinheiro.UseVisualStyleBackColor = true;
			// 
			// rbCheque
			// 
			this.rbCheque.Location = new System.Drawing.Point(19, 56);
			this.rbCheque.Name = "rbCheque";
			this.rbCheque.Size = new System.Drawing.Size(104, 24);
			this.rbCheque.TabIndex = 3;
			this.rbCheque.TabStop = true;
			this.rbCheque.Text = "Cheque";
			this.rbCheque.UseVisualStyleBackColor = true;
			// 
			// rbCartao
			// 
			this.rbCartao.Location = new System.Drawing.Point(19, 86);
			this.rbCartao.Name = "rbCartao";
			this.rbCartao.Size = new System.Drawing.Size(104, 24);
			this.rbCartao.TabIndex = 4;
			this.rbCartao.TabStop = true;
			this.rbCartao.Text = "Cartão";
			this.rbCartao.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(19, 125);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Ident.";
			// 
			// TxtIdent
			// 
			this.TxtIdent.Location = new System.Drawing.Point(72, 122);
			this.TxtIdent.MaxLength = 40;
			this.TxtIdent.Name = "TxtIdent";
			this.TxtIdent.Size = new System.Drawing.Size(186, 20);
			this.TxtIdent.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(87, 92);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 23);
			this.label3.TabIndex = 7;
			this.label3.Text = "Tipo";
			// 
			// CboTipoCart
			// 
			this.CboTipoCart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboTipoCart.FormattingEnabled = true;
			this.CboTipoCart.Items.AddRange(new object[] {
									"Visa",
									"Mastercard",
									"BanriCompras",
									"HyperCard",
									"American Express"});
			this.CboTipoCart.Location = new System.Drawing.Point(136, 89);
			this.CboTipoCart.Name = "CboTipoCart";
			this.CboTipoCart.Size = new System.Drawing.Size(122, 21);
			this.CboTipoCart.TabIndex = 8;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(113, 269);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 9;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.TxtIdent);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.CboTipoCart);
			this.groupBox1.Controls.Add(this.rbDinheiro);
			this.groupBox1.Controls.Add(this.rbCheque);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.rbCartao);
			this.groupBox1.Location = new System.Drawing.Point(12, 93);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(272, 158);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Formas de pagamento";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.LblTotal);
			this.groupBox2.Location = new System.Drawing.Point(12, 17);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(272, 70);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Valor do GiftCard";
			// 
			// dlgFinalGift
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(301, 308);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.BtnConfirmar);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgFinalGift";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Efetuar pagamento para compra de cartão Gift";
			this.Load += new System.EventHandler(this.DlgFinalGiftLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.ComboBox CboTipoCart;
		public System.Windows.Forms.TextBox TxtIdent;
		public System.Windows.Forms.GroupBox groupBox2;
		public System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.RadioButton rbCartao;
		public System.Windows.Forms.RadioButton rbCheque;
		public System.Windows.Forms.RadioButton rbDinheiro;
		public System.Windows.Forms.Label LblTotal;
	}
}

