using System.Windows.Forms;

namespace Client 
{
	partial class dlgConfGiftCard : Form
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
			this.LstDados = new System.Windows.Forms.ListBox();
			this.LstProd = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.label2 = new System.Windows.Forms.Label();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtCarga = new System.Windows.Forms.TextBox();
			this.LblTotal = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtCodAcesso = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(15, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(148, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Dados do proprietário:";
			// 
			// LstDados
			// 
			this.LstDados.FormattingEnabled = true;
			this.LstDados.Location = new System.Drawing.Point(15, 34);
			this.LstDados.Name = "LstDados";
			this.LstDados.Size = new System.Drawing.Size(158, 134);
			this.LstDados.TabIndex = 1;
			// 
			// LstProd
			// 
			this.LstProd.CheckBoxes = true;
			this.LstProd.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2});
			this.LstProd.FullRowSelect = true;
			this.LstProd.Location = new System.Drawing.Point(191, 34);
			this.LstProd.Name = "LstProd";
			this.LstProd.Size = new System.Drawing.Size(237, 163);
			this.LstProd.TabIndex = 2;
			this.LstProd.UseCompatibleStateImageBehavior = false;
			this.LstProd.View = System.Windows.Forms.View.Details;
			this.LstProd.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.LstProdItemChecked);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Produto";
			this.columnHeader1.Width = 120;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Valor";
			this.columnHeader2.Width = 80;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(191, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(148, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Lista de produtos disponíveis";
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(353, 210);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 4;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(15, 215);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Valor Carga:";
			// 
			// TxtCarga
			// 
			this.TxtCarga.Location = new System.Drawing.Point(93, 212);
			this.TxtCarga.Name = "TxtCarga";
			this.TxtCarga.Size = new System.Drawing.Size(80, 20);
			this.TxtCarga.TabIndex = 6;
			// 
			// LblTotal
			// 
			this.LblTotal.Location = new System.Drawing.Point(191, 215);
			this.LblTotal.Name = "LblTotal";
			this.LblTotal.Size = new System.Drawing.Size(131, 23);
			this.LblTotal.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(15, 180);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 23);
			this.label4.TabIndex = 8;
			this.label4.Text = "Cód. Acesso:";
			// 
			// TxtCodAcesso
			// 
			this.TxtCodAcesso.Location = new System.Drawing.Point(93, 177);
			this.TxtCodAcesso.Name = "TxtCodAcesso";
			this.TxtCodAcesso.Size = new System.Drawing.Size(80, 20);
			this.TxtCodAcesso.TabIndex = 9;
			// 
			// dlgConfGiftCard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(450, 249);
			this.Controls.Add(this.TxtCodAcesso);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.LblTotal);
			this.Controls.Add(this.TxtCarga);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.LstProd);
			this.Controls.Add(this.LstDados);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgConfGiftCard";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Confirmação para compra de cartão Gift";
			this.Load += new System.EventHandler(this.DlgConfGiftCardLoad);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgConfGiftCardFormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtCodAcesso;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.Label LblTotal;
		public System.Windows.Forms.TextBox TxtCarga;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.ListView LstProd;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.ColumnHeader columnHeader2;
		public System.Windows.Forms.ColumnHeader columnHeader1;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.ListBox LstDados;
		public System.Windows.Forms.Label label1;
	}
}

