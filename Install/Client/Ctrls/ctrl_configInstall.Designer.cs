/*
 * Created by SharpDevelop.
 * User: rodrigo.groff
 * Date: 23/10/2007
 * Time: 16:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ClientSetup
{
	partial class ctrl_configInstall
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
			this.lblFinal = new System.Windows.Forms.Label();
			this.lblConfig = new System.Windows.Forms.Label();
			this.lblNext = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblFinal
			// 
			this.lblFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblFinal.Location = new System.Drawing.Point(16, 15);
			this.lblFinal.Name = "lblFinal";
			this.lblFinal.Size = new System.Drawing.Size(287, 23);
			this.lblFinal.TabIndex = 0;
			this.lblFinal.Text = "label1";
			// 
			// lblConfig
			// 
			this.lblConfig.ForeColor = System.Drawing.Color.Navy;
			this.lblConfig.Location = new System.Drawing.Point(16, 38);
			this.lblConfig.Name = "lblConfig";
			this.lblConfig.Size = new System.Drawing.Size(301, 153);
			this.lblConfig.TabIndex = 1;
			this.lblConfig.Text = "label1";
			// 
			// lblNext
			// 
			this.lblNext.Location = new System.Drawing.Point(16, 205);
			this.lblNext.Name = "lblNext";
			this.lblNext.Size = new System.Drawing.Size(272, 23);
			this.lblNext.TabIndex = 2;
			this.lblNext.Text = "label1";
			this.lblNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ctrl_configInstall
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblNext);
			this.Controls.Add(this.lblConfig);
			this.Controls.Add(this.lblFinal);
			this.Name = "ctrl_configInstall";
			this.Size = new System.Drawing.Size(320, 274);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lblNext;
		private System.Windows.Forms.Label lblConfig;
		private System.Windows.Forms.Label lblFinal;
	}
}
