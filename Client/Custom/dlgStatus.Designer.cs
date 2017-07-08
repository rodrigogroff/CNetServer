using System.Windows.Forms;

namespace Client 
{
	partial class dlgStatus : Form
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
			this.LblActivity = new System.Windows.Forms.Label();
			this.pgStatus = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// LblActivity
			// 
			this.LblActivity.Location = new System.Drawing.Point(24, 24);
			this.LblActivity.Name = "LblActivity";
			this.LblActivity.Size = new System.Drawing.Size(240, 23);
			this.LblActivity.TabIndex = 0;
			// 
			// pgStatus
			// 
			this.pgStatus.Location = new System.Drawing.Point(24, 47);
			this.pgStatus.Maximum = 0;
			this.pgStatus.Name = "pgStatus";
			this.pgStatus.Size = new System.Drawing.Size(240, 43);
			this.pgStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.pgStatus.TabIndex = 1;
			// 
			// dlgStatus
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 105);
			this.Controls.Add(this.pgStatus);
			this.Controls.Add(this.LblActivity);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgStatus";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Processamento";
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.ProgressBar pgStatus;
		public System.Windows.Forms.Label LblActivity;
	}
}

