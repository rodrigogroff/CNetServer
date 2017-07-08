/*
 * Created by SharpDevelop.
 * User: rodrigo.groff
 * Date: 24/10/2007
 * Time: 8:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ClientSetup
{
	partial class ctrl_installing
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
			this.lblCopy = new System.Windows.Forms.Label();
			this.pgDisk = new System.Windows.Forms.ProgressBar();
			this.lblCurrentFile = new System.Windows.Forms.Label();
			this.lblActions = new System.Windows.Forms.Label();
			this.lblEnd = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblCopy
			// 
			this.lblCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCopy.Location = new System.Drawing.Point(10, 14);
			this.lblCopy.Name = "lblCopy";
			this.lblCopy.Size = new System.Drawing.Size(225, 23);
			this.lblCopy.TabIndex = 0;
			this.lblCopy.Text = "label1";
			// 
			// pgDisk
			// 
			this.pgDisk.Location = new System.Drawing.Point(10, 32);
			this.pgDisk.Name = "pgDisk";
			this.pgDisk.Size = new System.Drawing.Size(275, 23);
			this.pgDisk.Step = 1;
			this.pgDisk.TabIndex = 2;
			// 
			// lblCurrentFile
			// 
			this.lblCurrentFile.ForeColor = System.Drawing.Color.Navy;
			this.lblCurrentFile.Location = new System.Drawing.Point(10, 58);
			this.lblCurrentFile.Name = "lblCurrentFile";
			this.lblCurrentFile.Size = new System.Drawing.Size(225, 23);
			this.lblCurrentFile.TabIndex = 4;
			this.lblCurrentFile.Text = "label1";
			// 
			// lblActions
			// 
			this.lblActions.ForeColor = System.Drawing.Color.Navy;
			this.lblActions.Location = new System.Drawing.Point(10, 154);
			this.lblActions.Name = "lblActions";
			this.lblActions.Size = new System.Drawing.Size(156, 107);
			this.lblActions.TabIndex = 5;
			this.lblActions.Text = "label1";
			// 
			// lblEnd
			// 
			this.lblEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnd.Location = new System.Drawing.Point(135, 231);
			this.lblEnd.Name = "lblEnd";
			this.lblEnd.Size = new System.Drawing.Size(172, 30);
			this.lblEnd.TabIndex = 6;
			this.lblEnd.Text = "label1";
			this.lblEnd.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// ctrl_installing
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblEnd);
			this.Controls.Add(this.lblActions);
			this.Controls.Add(this.lblCurrentFile);
			this.Controls.Add(this.pgDisk);
			this.Controls.Add(this.lblCopy);
			this.Name = "ctrl_installing";
			this.Size = new System.Drawing.Size(320, 274);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lblEnd;
		private System.Windows.Forms.Label lblActions;
		private System.Windows.Forms.Label lblCurrentFile;
		private System.Windows.Forms.ProgressBar pgDisk;
		private System.Windows.Forms.Label lblCopy;
	}
}
