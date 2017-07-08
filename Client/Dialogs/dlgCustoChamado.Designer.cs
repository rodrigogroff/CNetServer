using System.Windows.Forms;

namespace Client 
{
	partial class dlgCustoChamado : Form
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
			this.TxtValor = new System.Windows.Forms.TextBox();
			this.btnConfirmar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(23, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Valor";
			// 
			// TxtValor
			// 
			this.TxtValor.Location = new System.Drawing.Point(71, 27);
			this.TxtValor.Name = "TxtValor";
			this.TxtValor.Size = new System.Drawing.Size(100, 20);
			this.TxtValor.TabIndex = 1;
			// 
			// btnConfirmar
			// 
			this.btnConfirmar.Location = new System.Drawing.Point(68, 71);
			this.btnConfirmar.Name = "btnConfirmar";
			this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.btnConfirmar.TabIndex = 2;
			this.btnConfirmar.Text = "Confirmar";
			this.btnConfirmar.UseVisualStyleBackColor = true;
			this.btnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// dlgCustoChamado
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(211, 111);
			this.Controls.Add(this.btnConfirmar);
			this.Controls.Add(this.TxtValor);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgCustoChamado";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Custo para este chamado";
			this.Load += new System.EventHandler(this.DlgCustoChamadoLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btnConfirmar;
		public System.Windows.Forms.TextBox TxtValor;
		private System.Windows.Forms.Label label1;
	}
}

