using System.Windows.Forms;

namespace Client 
{
	partial class dlgCancelaDespesa : Form
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
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtCodigo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.CboTipo = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.LstDespesas = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.BtnCancelar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(12, 105);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.ReadOnly = true;
			this.TxtNome.Size = new System.Drawing.Size(301, 20);
			this.TxtNome.TabIndex = 15;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 87);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(135, 23);
			this.label3.TabIndex = 14;
			this.label3.Text = "Loja ou Empresa";
			// 
			// TxtCodigo
			// 
			this.TxtCodigo.Location = new System.Drawing.Point(68, 53);
			this.TxtCodigo.Name = "TxtCodigo";
			this.TxtCodigo.Size = new System.Drawing.Size(65, 20);
			this.TxtCodigo.TabIndex = 13;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 12;
			this.label2.Text = "Código";
			// 
			// CboTipo
			// 
			this.CboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboTipo.FormattingEnabled = true;
			this.CboTipo.Items.AddRange(new object[] {
									"Empresa ou Associação",
									"Loja"});
			this.CboTipo.Location = new System.Drawing.Point(68, 21);
			this.CboTipo.Name = "CboTipo";
			this.CboTipo.Size = new System.Drawing.Size(245, 21);
			this.CboTipo.TabIndex = 11;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 10;
			this.label1.Text = "Tipo";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 140);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(221, 23);
			this.label4.TabIndex = 16;
			this.label4.Text = "Despesas em aberto";
			// 
			// LstDespesas
			// 
			this.LstDespesas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2});
			this.LstDespesas.FullRowSelect = true;
			this.LstDespesas.Location = new System.Drawing.Point(12, 160);
			this.LstDespesas.Name = "LstDespesas";
			this.LstDespesas.Size = new System.Drawing.Size(301, 148);
			this.LstDespesas.TabIndex = 17;
			this.LstDespesas.UseCompatibleStateImageBehavior = false;
			this.LstDespesas.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Despesa";
			this.columnHeader1.Width = 180;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Valor R$";
			this.columnHeader2.Width = 90;
			// 
			// BtnCancelar
			// 
			this.BtnCancelar.Location = new System.Drawing.Point(171, 314);
			this.BtnCancelar.Name = "BtnCancelar";
			this.BtnCancelar.Size = new System.Drawing.Size(142, 23);
			this.BtnCancelar.TabIndex = 18;
			this.BtnCancelar.Text = "Cancelar despesa";
			this.BtnCancelar.UseVisualStyleBackColor = true;
			this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelarClick);
			// 
			// dlgCancelaDespesa
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 371);
			this.Controls.Add(this.BtnCancelar);
			this.Controls.Add(this.LstDespesas);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.TxtNome);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.TxtCodigo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.CboTipo);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgCancelaDespesa";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cancelamento de despesas";
			this.Load += new System.EventHandler(this.DlgCancelaDespesaLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		public System.Windows.Forms.ListView LstDespesas;
		private System.Windows.Forms.Button BtnCancelar;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.ComboBox CboTipo;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox TxtCodigo;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox TxtNome;
	}
}

