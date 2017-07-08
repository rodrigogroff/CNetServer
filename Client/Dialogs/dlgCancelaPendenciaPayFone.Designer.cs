using System.Windows.Forms;

namespace Client 
{
	partial class dlgCancelaPendenciaPayFone : Form
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
			this.TxtTelefone = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtNSU = new System.Windows.Forms.TextBox();
			this.BtnCOnfirmar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(12, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Telefone";
			// 
			// TxtTelefone
			// 
			this.TxtTelefone.Location = new System.Drawing.Point(99, 16);
			this.TxtTelefone.Name = "TxtTelefone";
			this.TxtTelefone.Size = new System.Drawing.Size(100, 20);
			this.TxtTelefone.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(12, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "NSU";
			// 
			// TxtNSU
			// 
			this.TxtNSU.Location = new System.Drawing.Point(99, 42);
			this.TxtNSU.Name = "TxtNSU";
			this.TxtNSU.Size = new System.Drawing.Size(100, 20);
			this.TxtNSU.TabIndex = 2;
			// 
			// BtnCOnfirmar
			// 
			this.BtnCOnfirmar.Location = new System.Drawing.Point(124, 83);
			this.BtnCOnfirmar.Name = "BtnCOnfirmar";
			this.BtnCOnfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnCOnfirmar.TabIndex = 3;
			this.BtnCOnfirmar.Text = "Confirmar";
			this.BtnCOnfirmar.UseVisualStyleBackColor = true;
			this.BtnCOnfirmar.Click += new System.EventHandler(this.BtnCOnfirmarClick);
			// 
			// dlgCancelaPendenciaPayFone
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(224, 118);
			this.Controls.Add(this.BtnCOnfirmar);
			this.Controls.Add(this.TxtNSU);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TxtTelefone);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgCancelaPendenciaPayFone";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cancela Pendência PayFone";
			this.Load += new System.EventHandler(this.DlgCancelaPendenciaPayFoneLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.Button BtnCOnfirmar;
		public System.Windows.Forms.TextBox TxtNSU;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox TxtTelefone;
		public System.Windows.Forms.Label label1;
	}
}

