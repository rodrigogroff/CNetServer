using System.Windows.Forms;

namespace Client 
{
	partial class dlgCompensaCheque : Form
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
			this.TxtIdent = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtCheque = new System.Windows.Forms.TextBox();
			this.BtnCancelar = new System.Windows.Forms.Button();
			this.BtnCompensar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Identificação";
			// 
			// TxtIdent
			// 
			this.TxtIdent.Location = new System.Drawing.Point(118, 21);
			this.TxtIdent.Name = "TxtIdent";
			this.TxtIdent.Size = new System.Drawing.Size(198, 20);
			this.TxtIdent.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Dados do cheque";
			// 
			// TxtCheque
			// 
			this.TxtCheque.Location = new System.Drawing.Point(12, 76);
			this.TxtCheque.Multiline = true;
			this.TxtCheque.Name = "TxtCheque";
			this.TxtCheque.ReadOnly = true;
			this.TxtCheque.Size = new System.Drawing.Size(304, 111);
			this.TxtCheque.TabIndex = 3;
			// 
			// BtnCancelar
			// 
			this.BtnCancelar.Location = new System.Drawing.Point(12, 201);
			this.BtnCancelar.Name = "BtnCancelar";
			this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
			this.BtnCancelar.TabIndex = 4;
			this.BtnCancelar.Text = "Cancelar";
			this.BtnCancelar.UseVisualStyleBackColor = true;
			this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelarClick);
			// 
			// BtnCompensar
			// 
			this.BtnCompensar.Location = new System.Drawing.Point(241, 201);
			this.BtnCompensar.Name = "BtnCompensar";
			this.BtnCompensar.Size = new System.Drawing.Size(75, 23);
			this.BtnCompensar.TabIndex = 5;
			this.BtnCompensar.Text = "Compensar";
			this.BtnCompensar.UseVisualStyleBackColor = true;
			this.BtnCompensar.Click += new System.EventHandler(this.BtnCompensarClick);
			// 
			// dlgCompensaCheque
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(331, 237);
			this.Controls.Add(this.BtnCompensar);
			this.Controls.Add(this.BtnCancelar);
			this.Controls.Add(this.TxtCheque);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TxtIdent);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgCompensaCheque";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Manutenção de cheques";
			this.Load += new System.EventHandler(this.DlgCompensaChequeLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtCheque;
		private System.Windows.Forms.Button BtnCompensar;
		private System.Windows.Forms.Button BtnCancelar;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox TxtIdent;
		private System.Windows.Forms.Label label1;
	}
}

