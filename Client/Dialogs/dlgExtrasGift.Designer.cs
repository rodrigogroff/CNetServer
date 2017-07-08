using System.Windows.Forms;

namespace Client 
{
	partial class dlgExtrasGift : Form
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
			this.LstProd = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.BtnRemover = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.BtnAdicionar = new System.Windows.Forms.Button();
			this.TxtValor = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtEmpresa = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(158, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Lista de produtos disponíveis";
			// 
			// LstProd
			// 
			this.LstProd.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2});
			this.LstProd.FullRowSelect = true;
			this.LstProd.HideSelection = false;
			this.LstProd.Location = new System.Drawing.Point(16, 66);
			this.LstProd.Name = "LstProd";
			this.LstProd.Size = new System.Drawing.Size(238, 123);
			this.LstProd.TabIndex = 1;
			this.LstProd.UseCompatibleStateImageBehavior = false;
			this.LstProd.View = System.Windows.Forms.View.Details;
			this.LstProd.Click += new System.EventHandler(this.LstProdClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Produto";
			this.columnHeader1.Width = 120;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Valor";
			this.columnHeader2.Width = 90;
			// 
			// BtnRemover
			// 
			this.BtnRemover.Location = new System.Drawing.Point(16, 197);
			this.BtnRemover.Name = "BtnRemover";
			this.BtnRemover.Size = new System.Drawing.Size(75, 23);
			this.BtnRemover.TabIndex = 2;
			this.BtnRemover.Text = "Remover";
			this.BtnRemover.UseVisualStyleBackColor = true;
			this.BtnRemover.Click += new System.EventHandler(this.BtnRemoverClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.BtnAdicionar);
			this.groupBox1.Controls.Add(this.TxtValor);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.TxtNome);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.ForeColor = System.Drawing.Color.Black;
			this.groupBox1.Location = new System.Drawing.Point(16, 243);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(238, 105);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Novo Produto";
			// 
			// BtnAdicionar
			// 
			this.BtnAdicionar.Location = new System.Drawing.Point(145, 62);
			this.BtnAdicionar.Name = "BtnAdicionar";
			this.BtnAdicionar.Size = new System.Drawing.Size(75, 23);
			this.BtnAdicionar.TabIndex = 4;
			this.BtnAdicionar.Text = "Adicionar";
			this.BtnAdicionar.UseVisualStyleBackColor = true;
			this.BtnAdicionar.Click += new System.EventHandler(this.BtnAdicionarClick);
			// 
			// TxtValor
			// 
			this.TxtValor.Location = new System.Drawing.Point(50, 64);
			this.TxtValor.Name = "TxtValor";
			this.TxtValor.Size = new System.Drawing.Size(89, 20);
			this.TxtValor.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(9, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Valor";
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(50, 31);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.Size = new System.Drawing.Size(170, 20);
			this.TxtNome.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 34);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Nome";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 18);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(158, 23);
			this.label4.TabIndex = 4;
			this.label4.Text = "Empresa";
			// 
			// TxtEmpresa
			// 
			this.TxtEmpresa.Location = new System.Drawing.Point(85, 15);
			this.TxtEmpresa.Name = "TxtEmpresa";
			this.TxtEmpresa.Size = new System.Drawing.Size(89, 20);
			this.TxtEmpresa.TabIndex = 8;
			// 
			// dlgExtrasGift
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(272, 362);
			this.Controls.Add(this.TxtEmpresa);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.BtnRemover);
			this.Controls.Add(this.LstProd);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgExtrasGift";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Produtos Extras Gift";
			this.Load += new System.EventHandler(this.DlgExtrasGiftLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtEmpresa;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.TextBox TxtValor;
		public System.Windows.Forms.Button BtnAdicionar;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.Button BtnRemover;
		public System.Windows.Forms.ListView LstProd;
		public System.Windows.Forms.ColumnHeader columnHeader2;
		public System.Windows.Forms.ColumnHeader columnHeader1;
		public System.Windows.Forms.Label label1;
	}
}

