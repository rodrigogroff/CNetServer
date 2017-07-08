using System.Windows.Forms;

namespace Client 
{
	partial class dlgConsultaGift : Form
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
			this.TxtMatricula = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtEmpresa = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.TxtSaldo = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.LstProd = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.label5 = new System.Windows.Forms.Label();
			this.LstCred = new System.Windows.Forms.ListView();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.label7 = new System.Windows.Forms.Label();
			this.TxtSit = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// TxtMatricula
			// 
			this.TxtMatricula.Location = new System.Drawing.Point(110, 39);
			this.TxtMatricula.Name = "TxtMatricula";
			this.TxtMatricula.Size = new System.Drawing.Size(121, 20);
			this.TxtMatricula.TabIndex = 14;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(15, 42);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 13;
			this.label4.Text = "Matricula";
			// 
			// TxtEmpresa
			// 
			this.TxtEmpresa.Location = new System.Drawing.Point(110, 15);
			this.TxtEmpresa.Name = "TxtEmpresa";
			this.TxtEmpresa.Size = new System.Drawing.Size(121, 20);
			this.TxtEmpresa.TabIndex = 12;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(15, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 11;
			this.label1.Text = "Empresa";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(264, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 17;
			this.label2.Text = "Saldo Disp.";
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(359, 15);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.ReadOnly = true;
			this.TxtNome.Size = new System.Drawing.Size(236, 20);
			this.TxtNome.TabIndex = 18;
			// 
			// TxtSaldo
			// 
			this.TxtSaldo.Location = new System.Drawing.Point(359, 39);
			this.TxtSaldo.Name = "TxtSaldo";
			this.TxtSaldo.ReadOnly = true;
			this.TxtSaldo.Size = new System.Drawing.Size(236, 20);
			this.TxtSaldo.TabIndex = 19;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(264, 18);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 20;
			this.label3.Text = "Nome Cliente";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(15, 108);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(182, 23);
			this.label6.TabIndex = 21;
			this.label6.Text = "Histórico";
			// 
			// LstProd
			// 
			this.LstProd.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2});
			this.LstProd.FullRowSelect = true;
			this.LstProd.Location = new System.Drawing.Point(15, 127);
			this.LstProd.Name = "LstProd";
			this.LstProd.Size = new System.Drawing.Size(219, 120);
			this.LstProd.TabIndex = 22;
			this.LstProd.UseCompatibleStateImageBehavior = false;
			this.LstProd.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Produto";
			this.columnHeader1.Width = 130;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Valor";
			this.columnHeader2.Width = 65;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(264, 108);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(182, 23);
			this.label5.TabIndex = 23;
			this.label5.Text = "Créditos pendentes";
			// 
			// LstCred
			// 
			this.LstCred.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader3,
									this.columnHeader4,
									this.columnHeader5});
			this.LstCred.FullRowSelect = true;
			this.LstCred.Location = new System.Drawing.Point(264, 127);
			this.LstCred.Name = "LstCred";
			this.LstCred.Size = new System.Drawing.Size(331, 120);
			this.LstCred.TabIndex = 24;
			this.LstCred.UseCompatibleStateImageBehavior = false;
			this.LstCred.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Documento";
			this.columnHeader3.Width = 100;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Valor";
			this.columnHeader4.Width = 75;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Data";
			this.columnHeader5.Width = 130;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(264, 66);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 25;
			this.label7.Text = "Situação";
			// 
			// TxtSit
			// 
			this.TxtSit.Location = new System.Drawing.Point(359, 63);
			this.TxtSit.Name = "TxtSit";
			this.TxtSit.ReadOnly = true;
			this.TxtSit.Size = new System.Drawing.Size(236, 20);
			this.TxtSit.TabIndex = 26;
			// 
			// dlgConsultaGift
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(621, 267);
			this.Controls.Add(this.TxtSit);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.LstCred);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.LstProd);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.TxtSaldo);
			this.Controls.Add(this.TxtNome);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TxtMatricula);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.TxtEmpresa);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgConsultaGift";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Consulta Giftcard";
			this.Load += new System.EventHandler(this.DlgConsultaGiftLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtSit;
		public System.Windows.Forms.Label label7;
		public System.Windows.Forms.ListView LstProd;
		public System.Windows.Forms.ListView LstCred;
		public System.Windows.Forms.ColumnHeader columnHeader5;
		public System.Windows.Forms.ColumnHeader columnHeader4;
		public System.Windows.Forms.ColumnHeader columnHeader3;
		public System.Windows.Forms.ColumnHeader columnHeader2;
		public System.Windows.Forms.ColumnHeader columnHeader1;
		public System.Windows.Forms.Label label6;
		public System.Windows.Forms.TextBox TxtSaldo;
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox TxtEmpresa;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox TxtMatricula;
		public System.Windows.Forms.Label label5;
	}
}

