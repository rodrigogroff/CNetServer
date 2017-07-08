/*
 * Created by SharpDevelop.
 * User: rodrigo.groff
 * Date: 22/10/2007
 * Time: 11:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ServerSetup
{
	partial class ctrl_Intro
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
			this.rbAgree = new System.Windows.Forms.RadioButton();
			this.rbDisagree = new System.Windows.Forms.RadioButton();
			this.txtIntro = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// rbAgree
			// 
			this.rbAgree.Location = new System.Drawing.Point(14, 199);
			this.rbAgree.Name = "rbAgree";
			this.rbAgree.Size = new System.Drawing.Size(228, 30);
			this.rbAgree.TabIndex = 0;
			this.rbAgree.TabStop = true;
			this.rbAgree.Text = "rbAgree";
			this.rbAgree.UseVisualStyleBackColor = true;
			// 
			// rbDisagree
			// 
			this.rbDisagree.Location = new System.Drawing.Point(14, 220);
			this.rbDisagree.Name = "rbDisagree";
			this.rbDisagree.Size = new System.Drawing.Size(228, 30);
			this.rbDisagree.TabIndex = 1;
			this.rbDisagree.TabStop = true;
			this.rbDisagree.Text = "rbDisagree";
			this.rbDisagree.UseVisualStyleBackColor = true;
			// 
			// txtIntro
			// 
			this.txtIntro.BackColor = System.Drawing.Color.White;
			this.txtIntro.Location = new System.Drawing.Point(14, 13);
			this.txtIntro.Multiline = true;
			this.txtIntro.Name = "txtIntro";
			this.txtIntro.ReadOnly = true;
			this.txtIntro.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtIntro.Size = new System.Drawing.Size(289, 180);
			this.txtIntro.TabIndex = 2;
			// 
			// ctrl_Intro
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txtIntro);
			this.Controls.Add(this.rbDisagree);
			this.Controls.Add(this.rbAgree);
			this.Name = "ctrl_Intro";
			this.Size = new System.Drawing.Size(320, 274);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox txtIntro;
		private System.Windows.Forms.RadioButton rbDisagree;
		private System.Windows.Forms.RadioButton rbAgree;
	}
}
