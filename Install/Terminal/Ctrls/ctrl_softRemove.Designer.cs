/*
 * Created by SharpDevelop.
 * User: rodrigo.groff
 * Date: 25/10/2007
 * Time: 13:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ClientSetup
{
	partial class ctrl_softRemove
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
			this.lblRemove = new System.Windows.Forms.Label();
			this.lblEnd = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblRemove
			// 
			this.lblRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblRemove.Location = new System.Drawing.Point(16, 33);
			this.lblRemove.Name = "lblRemove";
			this.lblRemove.Size = new System.Drawing.Size(279, 23);
			this.lblRemove.TabIndex = 1;
			this.lblRemove.Text = "label1";
			// 
			// lblEnd
			// 
			this.lblEnd.ForeColor = System.Drawing.Color.Navy;
			this.lblEnd.Location = new System.Drawing.Point(124, 251);
			this.lblEnd.Name = "lblEnd";
			this.lblEnd.Size = new System.Drawing.Size(171, 23);
			this.lblEnd.TabIndex = 2;
			this.lblEnd.Text = "label1";
			this.lblEnd.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// ctrl_softRemove
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblEnd);
			this.Controls.Add(this.lblRemove);
			this.Name = "ctrl_softRemove";
			this.Size = new System.Drawing.Size(320, 274);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lblEnd;
		private System.Windows.Forms.Label lblRemove;
	}
}
