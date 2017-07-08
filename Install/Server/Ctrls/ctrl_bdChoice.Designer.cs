/*
 * Created by SharpDevelop.
 * User: rodrigo.groff
 * Date: 23/10/2007
 * Time: 15:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ServerSetup
{
	partial class ctrl_bdChoice
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
			this.lblBDSel = new System.Windows.Forms.Label();
			this.lstBD = new System.Windows.Forms.ListBox();
			this.lblUser = new System.Windows.Forms.Label();
			this.lblPassword = new System.Windows.Forms.Label();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.lblPort = new System.Windows.Forms.Label();
			this.txtDB = new System.Windows.Forms.TextBox();
			this.lblDBMachine = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblBDSel
			// 
			this.lblBDSel.ForeColor = System.Drawing.Color.Navy;
			this.lblBDSel.Location = new System.Drawing.Point(11, 10);
			this.lblBDSel.Name = "lblBDSel";
			this.lblBDSel.Size = new System.Drawing.Size(225, 23);
			this.lblBDSel.TabIndex = 0;
			this.lblBDSel.Text = "label1";
			// 
			// lstBD
			// 
			this.lstBD.FormattingEnabled = true;
			this.lstBD.Location = new System.Drawing.Point(11, 27);
			this.lstBD.Name = "lstBD";
			this.lstBD.Size = new System.Drawing.Size(267, 121);
			this.lstBD.TabIndex = 1;
			// 
			// lblUser
			// 
			this.lblUser.ForeColor = System.Drawing.Color.Navy;
			this.lblUser.Location = new System.Drawing.Point(11, 206);
			this.lblUser.Name = "lblUser";
			this.lblUser.Size = new System.Drawing.Size(127, 23);
			this.lblUser.TabIndex = 2;
			this.lblUser.Text = "label1";
			// 
			// lblPassword
			// 
			this.lblPassword.ForeColor = System.Drawing.Color.Navy;
			this.lblPassword.Location = new System.Drawing.Point(166, 206);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(124, 23);
			this.lblPassword.TabIndex = 3;
			this.lblPassword.Text = "label2";
			// 
			// txtUser
			// 
			this.txtUser.Location = new System.Drawing.Point(11, 222);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(127, 20);
			this.txtUser.TabIndex = 4;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(166, 222);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(112, 20);
			this.txtPassword.TabIndex = 5;
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(166, 178);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(112, 20);
			this.txtPort.TabIndex = 6;
			this.txtPort.Text = "3306";
			// 
			// lblPort
			// 
			this.lblPort.ForeColor = System.Drawing.Color.Navy;
			this.lblPort.Location = new System.Drawing.Point(166, 160);
			this.lblPort.Name = "lblPort";
			this.lblPort.Size = new System.Drawing.Size(124, 23);
			this.lblPort.TabIndex = 7;
			this.lblPort.Text = "label2";
			// 
			// txtDB
			// 
			this.txtDB.Location = new System.Drawing.Point(11, 178);
			this.txtDB.Name = "txtDB";
			this.txtDB.Size = new System.Drawing.Size(127, 20);
			this.txtDB.TabIndex = 9;
			// 
			// lblDBMachine
			// 
			this.lblDBMachine.ForeColor = System.Drawing.Color.Navy;
			this.lblDBMachine.Location = new System.Drawing.Point(11, 160);
			this.lblDBMachine.Name = "lblDBMachine";
			this.lblDBMachine.Size = new System.Drawing.Size(127, 23);
			this.lblDBMachine.TabIndex = 10;
			this.lblDBMachine.Text = "label1";
			// 
			// ctrl_bdChoice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txtDB);
			this.Controls.Add(this.lblDBMachine);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtUser);
			this.Controls.Add(this.lblPassword);
			this.Controls.Add(this.lblUser);
			this.Controls.Add(this.lstBD);
			this.Controls.Add(this.lblBDSel);
			this.Controls.Add(this.lblPort);
			this.Name = "ctrl_bdChoice";
			this.Size = new System.Drawing.Size(320, 274);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label lblDBMachine;
		private System.Windows.Forms.TextBox txtDB;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label lblPort;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtUser;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.Label lblUser;
		private System.Windows.Forms.ListBox lstBD;
		private System.Windows.Forms.Label lblBDSel;
	}
}
