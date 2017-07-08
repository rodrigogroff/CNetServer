/*
 * Created by SharpDevelop.
 * User: rodrigo.groff
 * Date: 23/10/2007
 * Time: 13:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ServerSetup
{
	partial class ctrl_appDir
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
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.txtLocation = new System.Windows.Forms.TextBox();
			this.lblLocation = new System.Windows.Forms.Label();
			this.btnFind = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.nu_CSP = new System.Windows.Forms.NumericUpDown();
			this.nu_MPS = new System.Windows.Forms.NumericUpDown();
			this.btnFindPath = new System.Windows.Forms.Button();
			this.TxtUpgradePath = new System.Windows.Forms.TextBox();
			this.LblUpgradePath = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtStandby = new System.Windows.Forms.TextBox();
			this.numStandPort = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.TxtFailFS = new System.Windows.Forms.TextBox();
			this.btnFS = new System.Windows.Forms.Button();
			this.TxtWebStandby = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.nu_CSP)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nu_MPS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numStandPort)).BeginInit();
			this.SuspendLayout();
			// 
			// txtLocation
			// 
			this.txtLocation.Location = new System.Drawing.Point(10, 30);
			this.txtLocation.Name = "txtLocation";
			this.txtLocation.ReadOnly = true;
			this.txtLocation.Size = new System.Drawing.Size(224, 20);
			this.txtLocation.TabIndex = 0;
			// 
			// lblLocation
			// 
			this.lblLocation.ForeColor = System.Drawing.Color.Navy;
			this.lblLocation.Location = new System.Drawing.Point(10, 14);
			this.lblLocation.Name = "lblLocation";
			this.lblLocation.Size = new System.Drawing.Size(206, 23);
			this.lblLocation.TabIndex = 1;
			this.lblLocation.Text = "label1";
			// 
			// btnFind
			// 
			this.btnFind.Location = new System.Drawing.Point(240, 28);
			this.btnFind.Name = "btnFind";
			this.btnFind.Size = new System.Drawing.Size(75, 23);
			this.btnFind.TabIndex = 2;
			this.btnFind.Text = "button1";
			this.btnFind.UseVisualStyleBackColor = true;
			this.btnFind.Click += new System.EventHandler(this.BtnFindClick);
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.Color.Navy;
			this.label1.Location = new System.Drawing.Point(10, 59);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(174, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Client Server Port";
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.Navy;
			this.label2.Location = new System.Drawing.Point(150, 59);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(174, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Max Packet Size";
			// 
			// nu_CSP
			// 
			this.nu_CSP.Location = new System.Drawing.Point(10, 76);
			this.nu_CSP.Maximum = new decimal(new int[] {
									99999,
									0,
									0,
									0});
			this.nu_CSP.Minimum = new decimal(new int[] {
									1000,
									0,
									0,
									0});
			this.nu_CSP.Name = "nu_CSP";
			this.nu_CSP.Size = new System.Drawing.Size(84, 20);
			this.nu_CSP.TabIndex = 8;
			this.nu_CSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.nu_CSP.ThousandsSeparator = true;
			this.nu_CSP.Value = new decimal(new int[] {
									1000,
									0,
									0,
									0});
			// 
			// nu_MPS
			// 
			this.nu_MPS.Increment = new decimal(new int[] {
									512,
									0,
									0,
									0});
			this.nu_MPS.Location = new System.Drawing.Point(150, 76);
			this.nu_MPS.Maximum = new decimal(new int[] {
									999999,
									0,
									0,
									0});
			this.nu_MPS.Minimum = new decimal(new int[] {
									4096,
									0,
									0,
									0});
			this.nu_MPS.Name = "nu_MPS";
			this.nu_MPS.Size = new System.Drawing.Size(84, 20);
			this.nu_MPS.TabIndex = 9;
			this.nu_MPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.nu_MPS.ThousandsSeparator = true;
			this.nu_MPS.Value = new decimal(new int[] {
									64000,
									0,
									0,
									0});
			// 
			// btnFindPath
			// 
			this.btnFindPath.Location = new System.Drawing.Point(238, 124);
			this.btnFindPath.Name = "btnFindPath";
			this.btnFindPath.Size = new System.Drawing.Size(75, 23);
			this.btnFindPath.TabIndex = 12;
			this.btnFindPath.Text = "button1";
			this.btnFindPath.UseVisualStyleBackColor = true;
			this.btnFindPath.Click += new System.EventHandler(this.BtnFindPathClick);
			// 
			// TxtUpgradePath
			// 
			this.TxtUpgradePath.Location = new System.Drawing.Point(8, 126);
			this.TxtUpgradePath.Name = "TxtUpgradePath";
			this.TxtUpgradePath.ReadOnly = true;
			this.TxtUpgradePath.Size = new System.Drawing.Size(224, 20);
			this.TxtUpgradePath.TabIndex = 10;
			// 
			// LblUpgradePath
			// 
			this.LblUpgradePath.ForeColor = System.Drawing.Color.Navy;
			this.LblUpgradePath.Location = new System.Drawing.Point(8, 110);
			this.LblUpgradePath.Name = "LblUpgradePath";
			this.LblUpgradePath.Size = new System.Drawing.Size(206, 23);
			this.LblUpgradePath.TabIndex = 11;
			this.LblUpgradePath.Text = "label1";
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.Color.Navy;
			this.label4.Location = new System.Drawing.Point(8, 160);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(113, 23);
			this.label4.TabIndex = 14;
			this.label4.Text = "Local Standby IP";
			// 
			// TxtStandby
			// 
			this.TxtStandby.Location = new System.Drawing.Point(10, 179);
			this.TxtStandby.Name = "TxtStandby";
			this.TxtStandby.Size = new System.Drawing.Size(84, 20);
			this.TxtStandby.TabIndex = 16;
			// 
			// numStandPort
			// 
			this.numStandPort.Location = new System.Drawing.Point(238, 179);
			this.numStandPort.Maximum = new decimal(new int[] {
									99999,
									0,
									0,
									0});
			this.numStandPort.Minimum = new decimal(new int[] {
									1000,
									0,
									0,
									0});
			this.numStandPort.Name = "numStandPort";
			this.numStandPort.Size = new System.Drawing.Size(73, 20);
			this.numStandPort.TabIndex = 18;
			this.numStandPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numStandPort.ThousandsSeparator = true;
			this.numStandPort.Value = new decimal(new int[] {
									1000,
									0,
									0,
									0});
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.Navy;
			this.label3.Location = new System.Drawing.Point(238, 160);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(75, 23);
			this.label3.TabIndex = 19;
			this.label3.Text = "Port";
			// 
			// label5
			// 
			this.label5.ForeColor = System.Drawing.Color.Navy;
			this.label5.Location = new System.Drawing.Point(10, 212);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(174, 23);
			this.label5.TabIndex = 20;
			this.label5.Text = "Fail FileSystem";
			// 
			// TxtFailFS
			// 
			this.TxtFailFS.Location = new System.Drawing.Point(10, 230);
			this.TxtFailFS.Name = "TxtFailFS";
			this.TxtFailFS.ReadOnly = true;
			this.TxtFailFS.Size = new System.Drawing.Size(222, 20);
			this.TxtFailFS.TabIndex = 21;
			// 
			// btnFS
			// 
			this.btnFS.Location = new System.Drawing.Point(238, 228);
			this.btnFS.Name = "btnFS";
			this.btnFS.Size = new System.Drawing.Size(75, 23);
			this.btnFS.TabIndex = 22;
			this.btnFS.Text = "button1";
			this.btnFS.UseVisualStyleBackColor = true;
			this.btnFS.Click += new System.EventHandler(this.BtnFSClick);
			// 
			// TxtWebStandby
			// 
			this.TxtWebStandby.Location = new System.Drawing.Point(118, 179);
			this.TxtWebStandby.Name = "TxtWebStandby";
			this.TxtWebStandby.Size = new System.Drawing.Size(114, 20);
			this.TxtWebStandby.TabIndex = 23;
			// 
			// label6
			// 
			this.label6.ForeColor = System.Drawing.Color.Navy;
			this.label6.Location = new System.Drawing.Point(118, 160);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(113, 23);
			this.label6.TabIndex = 24;
			this.label6.Text = "Web Standby IP";
			// 
			// ctrl_appDir
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.TxtWebStandby);
			this.Controls.Add(this.btnFS);
			this.Controls.Add(this.TxtFailFS);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.numStandPort);
			this.Controls.Add(this.TxtStandby);
			this.Controls.Add(this.btnFindPath);
			this.Controls.Add(this.TxtUpgradePath);
			this.Controls.Add(this.LblUpgradePath);
			this.Controls.Add(this.nu_MPS);
			this.Controls.Add(this.nu_CSP);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnFind);
			this.Controls.Add(this.txtLocation);
			this.Controls.Add(this.lblLocation);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label6);
			this.Name = "ctrl_appDir";
			this.Size = new System.Drawing.Size(320, 274);
			((System.ComponentModel.ISupportInitialize)(this.nu_CSP)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nu_MPS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numStandPort)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox TxtWebStandby;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox TxtFailFS;
		private System.Windows.Forms.Button btnFS;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numStandPort;
		private System.Windows.Forms.TextBox TxtStandby;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox TxtUpgradePath;
		private System.Windows.Forms.Button btnFindPath;
		private System.Windows.Forms.Label LblUpgradePath;
		private System.Windows.Forms.NumericUpDown nu_MPS;
		private System.Windows.Forms.NumericUpDown nu_CSP;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnFind;
		private System.Windows.Forms.TextBox txtLocation;
		private System.Windows.Forms.Label lblLocation;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
	}
}
