using System.Windows.Forms;

namespace Client 
{
	partial class dlgCancelamento : Form
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
			this.LstVendas = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.BtnCancelar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Vendas de hoje";
			// 
			// LstVendas
			// 
			this.LstVendas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3,
									this.columnHeader4});
			this.LstVendas.FullRowSelect = true;
			this.LstVendas.HideSelection = false;
			this.LstVendas.Location = new System.Drawing.Point(12, 31);
			this.LstVendas.MultiSelect = false;
			this.LstVendas.Name = "LstVendas";
			this.LstVendas.Size = new System.Drawing.Size(415, 216);
			this.LstVendas.TabIndex = 1;
			this.LstVendas.UseCompatibleStateImageBehavior = false;
			this.LstVendas.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Cartão";
			this.columnHeader1.Width = 100;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Valor";
			this.columnHeader2.Width = 80;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Data e Hora";
			this.columnHeader3.Width = 140;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "NSU";
			this.columnHeader4.Width = 70;
			// 
			// BtnCancelar
			// 
			this.BtnCancelar.Location = new System.Drawing.Point(352, 252);
			this.BtnCancelar.Name = "BtnCancelar";
			this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
			this.BtnCancelar.TabIndex = 2;
			this.BtnCancelar.Text = "Cancelar";
			this.BtnCancelar.UseVisualStyleBackColor = true;
			this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelarClick);
			// 
			// dlgCancelamento
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(440, 287);
			this.Controls.Add(this.BtnCancelar);
			this.Controls.Add(this.LstVendas);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgCancelamento";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cancelamento de vendas";
			this.Load += new System.EventHandler(this.dlgCancelamentoLoad);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ColumnHeader columnHeader4;
		public System.Windows.Forms.Button BtnCancelar;
		public System.Windows.Forms.ListView LstVendas;
		public System.Windows.Forms.ColumnHeader columnHeader3;
		public System.Windows.Forms.ColumnHeader columnHeader2;
		public System.Windows.Forms.ColumnHeader columnHeader1;
		public System.Windows.Forms.Label label1;
	}
}

