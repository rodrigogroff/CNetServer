/*
 * Created by SharpDevelop.
 * User: rodrigo.groff
 * Date: 31/08/2007
 * Time: 14:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Client
{
	partial class Robot
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
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
			this.lstCoverage = new System.Windows.Forms.ListBox();
			this.btnAll = new System.Windows.Forms.Button();
			this.lstJobs = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblAvail = new System.Windows.Forms.Label();
			this.lstRobotScript = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.numDelay = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.chkEnabled = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
			this.SuspendLayout();
			// 
			// lstCoverage
			// 
			this.lstCoverage.Font = new System.Drawing.Font("Lucida Sans Typewriter", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstCoverage.FormattingEnabled = true;
			this.lstCoverage.HorizontalScrollbar = true;
			this.lstCoverage.ItemHeight = 10;
			this.lstCoverage.Location = new System.Drawing.Point(211, 66);
			this.lstCoverage.Name = "lstCoverage";
			this.lstCoverage.ScrollAlwaysVisible = true;
			this.lstCoverage.Size = new System.Drawing.Size(477, 164);
			this.lstCoverage.TabIndex = 1;
			// 
			// btnAll
			// 
			this.btnAll.Location = new System.Drawing.Point(12, 13);
			this.btnAll.Name = "btnAll";
			this.btnAll.Size = new System.Drawing.Size(186, 23);
			this.btnAll.TabIndex = 3;
			this.btnAll.Text = "Execute All";
			this.btnAll.UseVisualStyleBackColor = true;
			this.btnAll.Click += new System.EventHandler(this.BtnAllClick);
			// 
			// lstJobs
			// 
			this.lstJobs.Font = new System.Drawing.Font("Lucida Sans Typewriter", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstJobs.FormattingEnabled = true;
			this.lstJobs.HorizontalScrollbar = true;
			this.lstJobs.ItemHeight = 10;
			this.lstJobs.Location = new System.Drawing.Point(12, 66);
			this.lstJobs.Name = "lstJobs";
			this.lstJobs.ScrollAlwaysVisible = true;
			this.lstJobs.Size = new System.Drawing.Size(186, 344);
			this.lstJobs.TabIndex = 4;
			this.lstJobs.DoubleClick += new System.EventHandler(this.LstJobsDoubleClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(211, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(215, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "Current coverage results:";
			// 
			// lblAvail
			// 
			this.lblAvail.Location = new System.Drawing.Point(12, 50);
			this.lblAvail.Name = "lblAvail";
			this.lblAvail.Size = new System.Drawing.Size(186, 23);
			this.lblAvail.TabIndex = 6;
			this.lblAvail.Text = "Available jobs:";
			// 
			// lstRobotScript
			// 
			this.lstRobotScript.Font = new System.Drawing.Font("Lucida Sans Typewriter", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstRobotScript.FormattingEnabled = true;
			this.lstRobotScript.HorizontalScrollbar = true;
			this.lstRobotScript.ItemHeight = 10;
			this.lstRobotScript.Location = new System.Drawing.Point(211, 256);
			this.lstRobotScript.Name = "lstRobotScript";
			this.lstRobotScript.ScrollAlwaysVisible = true;
			this.lstRobotScript.Size = new System.Drawing.Size(477, 154);
			this.lstRobotScript.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(211, 240);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(215, 23);
			this.label2.TabIndex = 8;
			this.label2.Text = "Current robot script:";
			// 
			// numDelay
			// 
			this.numDelay.Increment = new decimal(new int[] {
									50,
									0,
									0,
									0});
			this.numDelay.Location = new System.Drawing.Point(321, 17);
			this.numDelay.Maximum = new decimal(new int[] {
									10000,
									0,
									0,
									0});
			this.numDelay.Name = "numDelay";
			this.numDelay.Size = new System.Drawing.Size(83, 20);
			this.numDelay.TabIndex = 9;
			this.numDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numDelay.ThousandsSeparator = true;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(410, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(24, 23);
			this.label3.TabIndex = 10;
			this.label3.Text = "ms";
			// 
			// chkEnabled
			// 
			this.chkEnabled.Location = new System.Drawing.Point(211, 13);
			this.chkEnabled.Name = "chkEnabled";
			this.chkEnabled.Size = new System.Drawing.Size(104, 24);
			this.chkEnabled.TabIndex = 11;
			this.chkEnabled.Text = "Script logging";
			this.chkEnabled.UseVisualStyleBackColor = true;
			this.chkEnabled.CheckedChanged += new System.EventHandler(this.ChkDisableCheckedChanged);
			// 
			// Robot
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(703, 424);
			this.Controls.Add(this.chkEnabled);
			this.Controls.Add(this.numDelay);
			this.Controls.Add(this.lstRobotScript);
			this.Controls.Add(this.lstJobs);
			this.Controls.Add(this.btnAll);
			this.Controls.Add(this.lstCoverage);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblAvail);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Robot";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Interface Robot Testing and Coverage";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RobotFormClosing);
			((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.CheckBox chkEnabled;
		private System.Windows.Forms.NumericUpDown numDelay;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox lstRobotScript;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblAvail;
		private System.Windows.Forms.ListBox lstJobs;
		private System.Windows.Forms.Button btnAll;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lstCoverage;
	}
}
