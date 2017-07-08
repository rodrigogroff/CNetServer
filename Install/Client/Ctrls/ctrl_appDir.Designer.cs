/*
 * Created by SharpDevelop.
 * User: rodrigo.groff
 * Date: 23/10/2007
 * Time: 13:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ClientSetup
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
			this.lblServerPort = new System.Windows.Forms.Label();
			this.lblMPS = new System.Windows.Forms.Label();
			this.nu_CSP = new System.Windows.Forms.NumericUpDown();
			this.nu_MPS = new System.Windows.Forms.NumericUpDown();
			this.txtSrvName = new System.Windows.Forms.TextBox();
			this.lblServerName = new System.Windows.Forms.Label();
			this.LblUpgradePath = new System.Windows.Forms.Label();
			this.TxtUpgradePath = new System.Windows.Forms.TextBox();
			this.btnFindPath = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.nu_CSP)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nu_MPS)).BeginInit();
			this.SuspendLayout();
			// 
			// txtLocation
			// 
			this.txtLocation.Location = new System.Drawing.Point(10, 30);
			this.txtLocation.Name = "txtLocation";
			this.txtLocation.ReadOnly = true;
			this.txtLocation.Size = new System.Drawing.Size(217, 20);
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
			this.btnFind.Location = new System.Drawing.Point(238, 28);
			this.btnFind.Name = "btnFind";
			this.btnFind.Size = new System.Drawing.Size(75, 23);
			this.btnFind.TabIndex = 2;
			this.btnFind.Text = "button1";
			this.btnFind.UseVisualStyleBackColor = true;
			this.btnFind.Click += new System.EventHandler(this.BtnFindClick);
			// 
			// lblServerPort
			// 
			this.lblServerPort.ForeColor = System.Drawing.Color.Navy;
			this.lblServerPort.Location = new System.Drawing.Point(10, 144);
			this.lblServerPort.Name = "lblServerPort";
			this.lblServerPort.Size = new System.Drawing.Size(127, 23);
			this.lblServerPort.TabIndex = 4;
			this.lblServerPort.Text = "Server Port";
			// 
			// lblMPS
			// 
			this.lblMPS.ForeColor = System.Drawing.Color.Navy;
			this.lblMPS.Location = new System.Drawing.Point(143, 144);
			this.lblMPS.Name = "lblMPS";
			this.lblMPS.Size = new System.Drawing.Size(174, 23);
			this.lblMPS.TabIndex = 5;
			this.lblMPS.Text = "Max Packet Size";
			// 
			// nu_CSP
			// 
			this.nu_CSP.Location = new System.Drawing.Point(10, 161);
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
			this.nu_MPS.Location = new System.Drawing.Point(143, 161);
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
			// txtSrvName
			// 
			this.txtSrvName.Location = new System.Drawing.Point(10, 113);
			this.txtSrvName.Name = "txtSrvName";
			this.txtSrvName.Size = new System.Drawing.Size(217, 20);
			this.txtSrvName.TabIndex = 10;
			// 
			// lblServerName
			// 
			this.lblServerName.ForeColor = System.Drawing.Color.Navy;
			this.lblServerName.Location = new System.Drawing.Point(10, 96);
			this.lblServerName.Name = "lblServerName";
			this.lblServerName.Size = new System.Drawing.Size(174, 23);
			this.lblServerName.TabIndex = 11;
			this.lblServerName.Text = "Server Name";
			// 
			// LblUpgradePath
			// 
			this.LblUpgradePath.ForeColor = System.Drawing.Color.Navy;
			this.LblUpgradePath.Location = new System.Drawing.Point(10, 200);
			this.LblUpgradePath.Name = "LblUpgradePath";
			this.LblUpgradePath.Size = new System.Drawing.Size(174, 23);
			this.LblUpgradePath.TabIndex = 12;
			this.LblUpgradePath.Text = "Upgrade path";
			// 
			// TxtUpgradePath
			// 
			this.TxtUpgradePath.Location = new System.Drawing.Point(10, 222);
			this.TxtUpgradePath.Name = "TxtUpgradePath";
			this.TxtUpgradePath.ReadOnly = true;
			this.TxtUpgradePath.Size = new System.Drawing.Size(217, 20);
			this.TxtUpgradePath.TabIndex = 13;
			// 
			// btnFindPath
			// 
			this.btnFindPath.Location = new System.Drawing.Point(238, 220);
			this.btnFindPath.Name = "btnFindPath";
			this.btnFindPath.Size = new System.Drawing.Size(75, 23);
			this.btnFindPath.TabIndex = 14;
			this.btnFindPath.Text = "Browse";
			this.btnFindPath.UseVisualStyleBackColor = true;
			this.btnFindPath.Click += new System.EventHandler(this.BtnFindPathClick);
			// 
			// ctrl_appDir
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnFindPath);
			this.Controls.Add(this.TxtUpgradePath);
			this.Controls.Add(this.LblUpgradePath);
			this.Controls.Add(this.txtSrvName);
			this.Controls.Add(this.nu_MPS);
			this.Controls.Add(this.nu_CSP);
			this.Controls.Add(this.lblMPS);
			this.Controls.Add(this.lblServerPort);
			this.Controls.Add(this.btnFind);
			this.Controls.Add(this.txtLocation);
			this.Controls.Add(this.lblLocation);
			this.Controls.Add(this.lblServerName);
			this.Name = "ctrl_appDir";
			this.Size = new System.Drawing.Size(320, 274);
			((System.ComponentModel.ISupportInitialize)(this.nu_CSP)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nu_MPS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btnFindPath;
		private System.Windows.Forms.TextBox TxtUpgradePath;
		private System.Windows.Forms.Label LblUpgradePath;
		private System.Windows.Forms.Label lblMPS;
		private System.Windows.Forms.Label lblServerPort;
		private System.Windows.Forms.TextBox txtSrvName;
		private System.Windows.Forms.Label lblServerName;
		private System.Windows.Forms.NumericUpDown nu_MPS;
		private System.Windows.Forms.NumericUpDown nu_CSP;
		private System.Windows.Forms.Button btnFind;
		private System.Windows.Forms.TextBox txtLocation;
		private System.Windows.Forms.Label lblLocation;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
	}
}
