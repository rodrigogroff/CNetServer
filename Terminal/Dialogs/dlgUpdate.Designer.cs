using System.Windows.Forms;

namespace Client 
{
	partial class dlgUpdate : Form
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
			this.LblCmd = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// LblCmd
			// 
			this.LblCmd.Location = new System.Drawing.Point(12, 33);
			this.LblCmd.Name = "LblCmd";
			this.LblCmd.Size = new System.Drawing.Size(339, 23);
			this.LblCmd.TabIndex = 0;
			this.LblCmd.Text = "Buscando ultima versão do programa de atualização...";
			this.LblCmd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// dlgUpdate
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(354, 80);
			this.Controls.Add(this.LblCmd);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgUpdate";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Configurando atualização automática";
			this.Load += new System.EventHandler(this.DlgUpdateLoad);
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.Label LblCmd;
	}
}

