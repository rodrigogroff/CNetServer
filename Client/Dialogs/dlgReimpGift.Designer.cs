using System.Windows.Forms;

namespace Client 
{
	partial class dlgReimpGift : Form
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
			this.TxtSit = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.TxtSaldo = new System.Windows.Forms.TextBox();
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtCartao = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtEmpresa = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.LstComprov = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.label5 = new System.Windows.Forms.Label();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TxtSit
			// 
			this.TxtSit.Location = new System.Drawing.Point(110, 118);
			this.TxtSit.Name = "TxtSit";
			this.TxtSit.ReadOnly = true;
			this.TxtSit.Size = new System.Drawing.Size(236, 20);
			this.TxtSit.TabIndex = 36;
			this.TxtSit.TabStop = false;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(15, 121);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 35;
			this.label7.Text = "Situação";
			// 
			// TxtSaldo
			// 
			this.TxtSaldo.Location = new System.Drawing.Point(110, 94);
			this.TxtSaldo.Name = "TxtSaldo";
			this.TxtSaldo.ReadOnly = true;
			this.TxtSaldo.Size = new System.Drawing.Size(236, 20);
			this.TxtSaldo.TabIndex = 33;
			this.TxtSaldo.TabStop = false;
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(110, 70);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.ReadOnly = true;
			this.TxtNome.Size = new System.Drawing.Size(236, 20);
			this.TxtNome.TabIndex = 32;
			this.TxtNome.TabStop = false;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(15, 97);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 31;
			this.label2.Text = "Saldo Disp.";
			// 
			// TxtCartao
			// 
			this.TxtCartao.Location = new System.Drawing.Point(110, 41);
			this.TxtCartao.Name = "TxtCartao";
			this.TxtCartao.Size = new System.Drawing.Size(121, 20);
			this.TxtCartao.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(15, 44);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 29;
			this.label4.Text = "Matricula";
			// 
			// TxtEmpresa
			// 
			this.TxtEmpresa.Location = new System.Drawing.Point(110, 17);
			this.TxtEmpresa.Name = "TxtEmpresa";
			this.TxtEmpresa.Size = new System.Drawing.Size(121, 20);
			this.TxtEmpresa.TabIndex = 4;
			this.TxtEmpresa.TabStop = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(15, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 27;
			this.label1.Text = "Empresa";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(15, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 34;
			this.label3.Text = "Nome Cliente";
			// 
			// LstComprov
			// 
			this.LstComprov.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3});
			this.LstComprov.FullRowSelect = true;
			this.LstComprov.HideSelection = false;
			this.LstComprov.Location = new System.Drawing.Point(15, 177);
			this.LstComprov.MultiSelect = false;
			this.LstComprov.Name = "LstComprov";
			this.LstComprov.Size = new System.Drawing.Size(331, 155);
			this.LstComprov.TabIndex = 2;
			this.LstComprov.UseCompatibleStateImageBehavior = false;
			this.LstComprov.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Data";
			this.columnHeader1.Width = 120;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Valor";
			this.columnHeader2.Width = 85;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Tipo";
			this.columnHeader3.Width = 90;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(15, 158);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(165, 23);
			this.label5.TabIndex = 38;
			this.label5.Text = "Comprovantes disponíveis";
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(253, 338);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(93, 23);
			this.BtnConfirmar.TabIndex = 3;
			this.BtnConfirmar.Text = "Imprimir";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// dlgReimpGift
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(366, 378);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.LstComprov);
			this.Controls.Add(this.TxtSit);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.TxtSaldo);
			this.Controls.Add(this.TxtNome);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TxtCartao);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.TxtEmpresa);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label5);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgReimpGift";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Reimpressão de venda GiftCard";
			this.Load += new System.EventHandler(this.DlgReimpGiftLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.ListView LstComprov;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox TxtEmpresa;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox TxtCartao;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.TextBox TxtSaldo;
		public System.Windows.Forms.Label label7;
		public System.Windows.Forms.TextBox TxtSit;
	}
}

