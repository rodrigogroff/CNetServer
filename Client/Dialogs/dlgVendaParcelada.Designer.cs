using System.Windows.Forms;

namespace Client 
{
	partial class dlgVendaParcelada : Form
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
			this.LblParc = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.LstParcs = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtValor = new System.Windows.Forms.TextBox();
			this.LblVrTot = new System.Windows.Forms.Label();
			this.LblDiff = new System.Windows.Forms.Label();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// LblParc
			// 
			this.LblParc.Location = new System.Drawing.Point(15, 18);
			this.LblParc.Name = "LblParc";
			this.LblParc.Size = new System.Drawing.Size(204, 23);
			this.LblParc.TabIndex = 0;
			this.LblParc.Text = "Número total de parcelas: ";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(15, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(119, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Valor de cada parcela";
			// 
			// LstParcs
			// 
			this.LstParcs.FormattingEnabled = true;
			this.LstParcs.Location = new System.Drawing.Point(15, 71);
			this.LstParcs.Name = "LstParcs";
			this.LstParcs.Size = new System.Drawing.Size(120, 147);
			this.LstParcs.TabIndex = 2;
			this.LstParcs.Click += new System.EventHandler(this.LstParcsClick);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(152, 52);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(101, 23);
			this.label3.TabIndex = 3;
			this.label3.Text = "Redefinir";
			// 
			// TxtValor
			// 
			this.TxtValor.Location = new System.Drawing.Point(152, 71);
			this.TxtValor.Name = "TxtValor";
			this.TxtValor.Size = new System.Drawing.Size(100, 20);
			this.TxtValor.TabIndex = 4;
			// 
			// LblVrTot
			// 
			this.LblVrTot.Location = new System.Drawing.Point(15, 230);
			this.LblVrTot.Name = "LblVrTot";
			this.LblVrTot.Size = new System.Drawing.Size(154, 23);
			this.LblVrTot.TabIndex = 5;
			this.LblVrTot.Text = "Valor Total: R$";
			// 
			// LblDiff
			// 
			this.LblDiff.Location = new System.Drawing.Point(15, 253);
			this.LblDiff.Name = "LblDiff";
			this.LblDiff.Size = new System.Drawing.Size(154, 23);
			this.LblDiff.TabIndex = 6;
			this.LblDiff.Text = "Diferença: R$ ";
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(178, 248);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 7;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// dlgVendaParcelada
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(282, 294);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.LblDiff);
			this.Controls.Add(this.LblVrTot);
			this.Controls.Add(this.TxtValor);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.LstParcs);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.LblParc);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgVendaParcelada";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Venda Parcelada";
			this.Load += new System.EventHandler(this.DlgVendaParceladaLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.Label LblVrTot;
		public System.Windows.Forms.Label LblDiff;
		public System.Windows.Forms.Label LblParc;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.TextBox TxtValor;
		public System.Windows.Forms.ListBox LstParcs;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label2;
	}
}

