using System.Windows.Forms;

namespace Client 
{
	partial class dlgCotaExtra : Form
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
			this.TxtNu_Empresa = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtMoney_Vlr = new System.Windows.Forms.TextBox();
			this.LstCart = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.BtnAplic = new System.Windows.Forms.Button();
			this.BtnRemove = new System.Windows.Forms.Button();
			this.BtnConf = new System.Windows.Forms.Button();
			this.ChkAlfa = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Empresa";
			// 
			// TxtNu_Empresa
			// 
			this.TxtNu_Empresa.Location = new System.Drawing.Point(98, 28);
			this.TxtNu_Empresa.Name = "TxtNu_Empresa";
			this.TxtNu_Empresa.Size = new System.Drawing.Size(100, 20);
			this.TxtNu_Empresa.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 71);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Valor";
			// 
			// TxtMoney_Vlr
			// 
			this.TxtMoney_Vlr.Location = new System.Drawing.Point(98, 68);
			this.TxtMoney_Vlr.Name = "TxtMoney_Vlr";
			this.TxtMoney_Vlr.Size = new System.Drawing.Size(100, 20);
			this.TxtMoney_Vlr.TabIndex = 3;
			// 
			// LstCart
			// 
			this.LstCart.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3});
			this.LstCart.FullRowSelect = true;
			this.LstCart.HideSelection = false;
			this.LstCart.Location = new System.Drawing.Point(24, 137);
			this.LstCart.Name = "LstCart";
			this.LstCart.Size = new System.Drawing.Size(374, 279);
			this.LstCart.TabIndex = 4;
			this.LstCart.UseCompatibleStateImageBehavior = false;
			this.LstCart.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Matricula";
			this.columnHeader1.Width = 100;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Nome";
			this.columnHeader2.Width = 160;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Cota";
			// 
			// BtnAplic
			// 
			this.BtnAplic.Location = new System.Drawing.Point(266, 66);
			this.BtnAplic.Name = "BtnAplic";
			this.BtnAplic.Size = new System.Drawing.Size(132, 23);
			this.BtnAplic.TabIndex = 5;
			this.BtnAplic.Text = "Aplicar a todos";
			this.BtnAplic.UseVisualStyleBackColor = true;
			this.BtnAplic.Click += new System.EventHandler(this.BtnAplicClick);
			// 
			// BtnRemove
			// 
			this.BtnRemove.Location = new System.Drawing.Point(24, 427);
			this.BtnRemove.Name = "BtnRemove";
			this.BtnRemove.Size = new System.Drawing.Size(132, 23);
			this.BtnRemove.TabIndex = 6;
			this.BtnRemove.Text = "Retirar cota";
			this.BtnRemove.UseVisualStyleBackColor = true;
			this.BtnRemove.Click += new System.EventHandler(this.BtnRemoveClick);
			// 
			// BtnConf
			// 
			this.BtnConf.Location = new System.Drawing.Point(266, 427);
			this.BtnConf.Name = "BtnConf";
			this.BtnConf.Size = new System.Drawing.Size(132, 23);
			this.BtnConf.TabIndex = 7;
			this.BtnConf.Text = "Confirmar";
			this.BtnConf.UseVisualStyleBackColor = true;
			this.BtnConf.Click += new System.EventHandler(this.BtnConfClick);
			// 
			// ChkAlfa
			// 
			this.ChkAlfa.Location = new System.Drawing.Point(24, 107);
			this.ChkAlfa.Name = "ChkAlfa";
			this.ChkAlfa.Size = new System.Drawing.Size(174, 24);
			this.ChkAlfa.TabIndex = 8;
			this.ChkAlfa.Text = "Ordenar alfabeticamente";
			this.ChkAlfa.UseVisualStyleBackColor = true;
			this.ChkAlfa.CheckedChanged += new System.EventHandler(this.ChkAlfaCheckedChanged);
			// 
			// dlgCotaExtra
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(418, 469);
			this.Controls.Add(this.ChkAlfa);
			this.Controls.Add(this.BtnConf);
			this.Controls.Add(this.BtnRemove);
			this.Controls.Add(this.BtnAplic);
			this.Controls.Add(this.LstCart);
			this.Controls.Add(this.TxtMoney_Vlr);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TxtNu_Empresa);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgCotaExtra";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cota extra para cartões convênio";
			this.Load += new System.EventHandler(this.dlgCotaExtraLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.CheckBox ChkAlfa;
		public System.Windows.Forms.TextBox TxtMoney_Vlr;
		public System.Windows.Forms.TextBox TxtNu_Empresa;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Button BtnConf;
		private System.Windows.Forms.Button BtnRemove;
		private System.Windows.Forms.Button BtnAplic;
		public System.Windows.Forms.ListView LstCart;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}

