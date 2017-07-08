/*
 * Created by SharpDevelop.
 * User: rodrigo.groff
 * Date: 22/10/2007
 * Time: 14:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ClientSetup
{
	partial class ctrl_Lang
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
			this.lblLang = new System.Windows.Forms.Label();
			this.cboLang = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// lblLang
			// 
			this.lblLang.ForeColor = System.Drawing.Color.Navy;
			this.lblLang.Location = new System.Drawing.Point(9, 13);
			this.lblLang.Name = "lblLang";
			this.lblLang.Size = new System.Drawing.Size(138, 23);
			this.lblLang.TabIndex = 0;
			this.lblLang.Text = "Select your language";
			// 
			// cboLang
			// 
			this.cboLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboLang.FormattingEnabled = true;
			this.cboLang.Location = new System.Drawing.Point(9, 31);
			this.cboLang.Name = "cboLang";
			this.cboLang.Size = new System.Drawing.Size(220, 21);
			this.cboLang.TabIndex = 1;
			this.cboLang.SelectedIndexChanged += new System.EventHandler(this.CboLangSelectedIndexChanged);
			// 
			// ctrl_Lang
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.cboLang);
			this.Controls.Add(this.lblLang);
			this.Name = "ctrl_Lang";
			this.Size = new System.Drawing.Size(258, 274);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lblLang;
		private System.Windows.Forms.ComboBox cboLang;
	}
}
