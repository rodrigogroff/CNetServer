/*
 * Created by SharpDevelop.
 * User: rodrigo.groff
 * Date: 25/10/2007
 * Time: 13:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ClientSetup
{
	partial class ctrl_uninstallConfirm
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
			this.lblConf = new System.Windows.Forms.Label();
			this.rbYes = new System.Windows.Forms.RadioButton();
			this.rbNo = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// lblConf
			// 
			this.lblConf.ForeColor = System.Drawing.Color.Navy;
			this.lblConf.Location = new System.Drawing.Point(7, 12);
			this.lblConf.Name = "lblConf";
			this.lblConf.Size = new System.Drawing.Size(238, 24);
			this.lblConf.TabIndex = 0;
			this.lblConf.Text = "label1";
			// 
			// rbYes
			// 
			this.rbYes.Location = new System.Drawing.Point(7, 38);
			this.rbYes.Name = "rbYes";
			this.rbYes.Size = new System.Drawing.Size(104, 24);
			this.rbYes.TabIndex = 1;
			this.rbYes.TabStop = true;
			this.rbYes.Text = "rbYes";
			this.rbYes.UseVisualStyleBackColor = true;
			// 
			// rbNo
			// 
			this.rbNo.Location = new System.Drawing.Point(7, 59);
			this.rbNo.Name = "rbNo";
			this.rbNo.Size = new System.Drawing.Size(104, 24);
			this.rbNo.TabIndex = 2;
			this.rbNo.TabStop = true;
			this.rbNo.Text = "rbNo";
			this.rbNo.UseVisualStyleBackColor = true;
			// 
			// ctrl_uninstallConfirm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.rbNo);
			this.Controls.Add(this.rbYes);
			this.Controls.Add(this.lblConf);
			this.Name = "ctrl_uninstallConfirm";
			this.Size = new System.Drawing.Size(258, 274);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lblConf;
		private System.Windows.Forms.RadioButton rbNo;
		private System.Windows.Forms.RadioButton rbYes;
	}
}
