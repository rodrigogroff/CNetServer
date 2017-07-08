using System.Windows.Forms;

namespace Client 
{
	partial class dlgFinanceiro : Form
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
			this.cal = new System.Windows.Forms.MonthCalendar();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.LblVendas = new System.Windows.Forms.Label();
			this.LblVendasCanc = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.LblOper = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cal
			// 
			this.cal.Location = new System.Drawing.Point(18, 18);
			this.cal.Name = "cal";
			this.cal.TabIndex = 0;
			this.cal.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.CalDateSelected);
			this.cal.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.CalDateChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(194, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Vendas:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(194, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(127, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Vendas canceladas:";
			// 
			// LblVendas
			// 
			this.LblVendas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblVendas.Location = new System.Drawing.Point(332, 18);
			this.LblVendas.Name = "LblVendas";
			this.LblVendas.Size = new System.Drawing.Size(100, 23);
			this.LblVendas.TabIndex = 3;
			this.LblVendas.Text = "R$";
			// 
			// LblVendasCanc
			// 
			this.LblVendasCanc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblVendasCanc.Location = new System.Drawing.Point(332, 52);
			this.LblVendasCanc.Name = "LblVendasCanc";
			this.LblVendasCanc.Size = new System.Drawing.Size(100, 23);
			this.LblVendasCanc.TabIndex = 4;
			this.LblVendasCanc.Text = "R$";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(194, 86);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Operações:";
			// 
			// LblOper
			// 
			this.LblOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblOper.Location = new System.Drawing.Point(332, 86);
			this.LblOper.Name = "LblOper";
			this.LblOper.Size = new System.Drawing.Size(100, 23);
			this.LblOper.TabIndex = 6;
			this.LblOper.Text = "1";
			// 
			// dlgFinanceiro
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(464, 196);
			this.Controls.Add(this.LblOper);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.LblVendasCanc);
			this.Controls.Add(this.LblVendas);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cal);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgFinanceiro";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Financeiro";
			this.Load += new System.EventHandler(this.dlgFinanceiroLoad);
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.Label LblOper;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label LblVendasCanc;
		public System.Windows.Forms.Label LblVendas;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.MonthCalendar cal;
	}
}

