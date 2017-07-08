/*
 * Created by SharpDevelop.
 * User: rodrigo.groff
 * Date: 8/5/2006
 * Time: 16:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

 using System.Windows.Forms;
 
namespace Client
{
	partial class MainForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components = null;
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		
		/// <summary>
		/// Disposes resources used by the form.
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
			this.LblCmd = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// LblCmd
			// 
			this.LblCmd.BackColor = System.Drawing.Color.Transparent;
			this.LblCmd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.LblCmd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.LblCmd.Location = new System.Drawing.Point(12, 36);
			this.LblCmd.Name = "LblCmd";
			this.LblCmd.Size = new System.Drawing.Size(323, 23);
			this.LblCmd.TabIndex = 1;
			this.LblCmd.Text = "label1";
			this.LblCmd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// MainForm
			// 
			this.BackColor = System.Drawing.Color.DimGray;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(347, 94);
			this.Controls.Add(this.LblCmd);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(0, 171);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Web Update ";
			this.TopMost = true;
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.Label LblCmd;
		
	}
}
