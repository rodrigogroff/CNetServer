using System.Windows.Forms;

namespace Client 
{
	partial class dlgObservacao : Form
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
			this.LblObs = new System.Windows.Forms.Label();
			this.TxtMotivo = new System.Windows.Forms.TextBox();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// LblObs
			// 
			this.LblObs.Location = new System.Drawing.Point(28, 19);
			this.LblObs.Name = "LblObs";
			this.LblObs.Size = new System.Drawing.Size(214, 23);
			this.LblObs.TabIndex = 0;
			// 
			// TxtMotivo
			// 
			this.TxtMotivo.Location = new System.Drawing.Point(28, 41);
			this.TxtMotivo.Name = "TxtMotivo";
			this.TxtMotivo.Size = new System.Drawing.Size(214, 20);
			this.TxtMotivo.TabIndex = 1;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(98, 77);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 2;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// dlgObservacao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(270, 116);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.TxtMotivo);
			this.Controls.Add(this.LblObs);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgObservacao";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.DlgObservacaoLoad);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgObservacaoFormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtMotivo;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.Label LblObs;
	}
}

