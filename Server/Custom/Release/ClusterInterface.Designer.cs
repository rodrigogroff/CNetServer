/*
 * Created by SharpDevelop.
 * User: rod
 * Date: 7/8/2007
 * Time: 19:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SyCrafEngine
{
	partial class ClusterInterface 
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClusterInterface));
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblNowStats = new System.Windows.Forms.Label();
			this.lblMode = new System.Windows.Forms.Label();
			this.lblConfig = new System.Windows.Forms.Label();
			this.lblState = new System.Windows.Forms.Label();
			this.lblTopic = new System.Windows.Forms.Label();
			this.lblVersion = new System.Windows.Forms.Label();
			this.BtnCluster = new System.Windows.Forms.Button();
			this.BtnStart = new System.Windows.Forms.Button();
			this.BtnPause = new System.Windows.Forms.Button();
			this.lblAction = new System.Windows.Forms.Label();
			this.BtnClients = new System.Windows.Forms.Button();
			this.BtnCpu = new System.Windows.Forms.Button();
			this.BtnLoad = new System.Windows.Forms.Button();
			this.lblMonitoring = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tm_AppRefresh = new System.Windows.Forms.Timer(this.components);
			this.BtnBackup = new System.Windows.Forms.Button();
			this.BtnRestore = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.pgBackup = new System.Windows.Forms.ProgressBar();
			this.LblBackup = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.NumMaxThreads = new System.Windows.Forms.NumericUpDown();
			this.BtnStand = new System.Windows.Forms.Button();
			this.zed = new ZedGraph.ZedGraphControl();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumMaxThreads)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.lblNowStats);
			this.panel1.Controls.Add(this.lblMode);
			this.panel1.Controls.Add(this.lblConfig);
			this.panel1.Controls.Add(this.lblState);
			this.panel1.Controls.Add(this.lblTopic);
			this.panel1.Controls.Add(this.lblVersion);
			this.panel1.Location = new System.Drawing.Point(-16, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(755, 52);
			this.panel1.TabIndex = 0;
			// 
			// lblNowStats
			// 
			this.lblNowStats.BackColor = System.Drawing.Color.Transparent;
			this.lblNowStats.Location = new System.Drawing.Point(189, 27);
			this.lblNowStats.Name = "lblNowStats";
			this.lblNowStats.Size = new System.Drawing.Size(240, 23);
			this.lblNowStats.TabIndex = 7;
			// 
			// lblMode
			// 
			this.lblMode.BackColor = System.Drawing.Color.Transparent;
			this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lblMode.Location = new System.Drawing.Point(189, 11);
			this.lblMode.Name = "lblMode";
			this.lblMode.Size = new System.Drawing.Size(193, 23);
			this.lblMode.TabIndex = 6;
			// 
			// lblConfig
			// 
			this.lblConfig.BackColor = System.Drawing.Color.Transparent;
			this.lblConfig.Location = new System.Drawing.Point(428, 27);
			this.lblConfig.Name = "lblConfig";
			this.lblConfig.Size = new System.Drawing.Size(289, 23);
			this.lblConfig.TabIndex = 4;
			this.lblConfig.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblState
			// 
			this.lblState.BackColor = System.Drawing.Color.Transparent;
			this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblState.ForeColor = System.Drawing.Color.Gray;
			this.lblState.Location = new System.Drawing.Point(37, 27);
			this.lblState.Name = "lblState";
			this.lblState.Size = new System.Drawing.Size(190, 23);
			this.lblState.TabIndex = 5;
			// 
			// lblTopic
			// 
			this.lblTopic.BackColor = System.Drawing.Color.Transparent;
			this.lblTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTopic.Location = new System.Drawing.Point(37, 11);
			this.lblTopic.Name = "lblTopic";
			this.lblTopic.Size = new System.Drawing.Size(100, 23);
			this.lblTopic.TabIndex = 4;
			this.lblTopic.Text = "Status";
			// 
			// lblVersion
			// 
			this.lblVersion.BackColor = System.Drawing.Color.Transparent;
			this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lblVersion.Location = new System.Drawing.Point(421, 11);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(296, 23);
			this.lblVersion.TabIndex = 8;
			this.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// BtnCluster
			// 
			this.BtnCluster.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.BtnCluster.Location = new System.Drawing.Point(617, 58);
			this.BtnCluster.Name = "BtnCluster";
			this.BtnCluster.Size = new System.Drawing.Size(85, 22);
			this.BtnCluster.TabIndex = 6;
			this.BtnCluster.Text = "Nodes";
			this.BtnCluster.UseVisualStyleBackColor = true;
			this.BtnCluster.Click += new System.EventHandler(this.BtnClusterClick);
			// 
			// BtnStart
			// 
			this.BtnStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.BtnStart.Location = new System.Drawing.Point(12, 85);
			this.BtnStart.Name = "BtnStart";
			this.BtnStart.Size = new System.Drawing.Size(62, 36);
			this.BtnStart.TabIndex = 3;
			this.BtnStart.Text = "Start";
			this.BtnStart.UseVisualStyleBackColor = true;
			this.BtnStart.Click += new System.EventHandler(this.BtnStartClick);
			// 
			// BtnPause
			// 
			this.BtnPause.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.BtnPause.Location = new System.Drawing.Point(12, 127);
			this.BtnPause.Name = "BtnPause";
			this.BtnPause.Size = new System.Drawing.Size(62, 36);
			this.BtnPause.TabIndex = 5;
			this.BtnPause.Text = "Pause";
			this.BtnPause.UseVisualStyleBackColor = true;
			this.BtnPause.Click += new System.EventHandler(this.BtnPauseClick);
			// 
			// lblAction
			// 
			this.lblAction.Location = new System.Drawing.Point(12, 63);
			this.lblAction.Name = "lblAction";
			this.lblAction.Size = new System.Drawing.Size(85, 23);
			this.lblAction.TabIndex = 2;
			this.lblAction.Text = "Actions";
			// 
			// BtnClients
			// 
			this.BtnClients.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.BtnClients.Location = new System.Drawing.Point(347, 58);
			this.BtnClients.Name = "BtnClients";
			this.BtnClients.Size = new System.Drawing.Size(85, 22);
			this.BtnClients.TabIndex = 3;
			this.BtnClients.Text = "Clients";
			this.BtnClients.UseVisualStyleBackColor = true;
			this.BtnClients.Click += new System.EventHandler(this.BtnClientsClick);
			// 
			// BtnCpu
			// 
			this.BtnCpu.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.BtnCpu.Location = new System.Drawing.Point(527, 58);
			this.BtnCpu.Name = "BtnCpu";
			this.BtnCpu.Size = new System.Drawing.Size(85, 22);
			this.BtnCpu.TabIndex = 4;
			this.BtnCpu.Text = "CPU";
			this.BtnCpu.UseVisualStyleBackColor = true;
			this.BtnCpu.Click += new System.EventHandler(this.BtnCpuClick);
			// 
			// BtnLoad
			// 
			this.BtnLoad.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.BtnLoad.Location = new System.Drawing.Point(437, 58);
			this.BtnLoad.Name = "BtnLoad";
			this.BtnLoad.Size = new System.Drawing.Size(85, 22);
			this.BtnLoad.TabIndex = 6;
			this.BtnLoad.Text = "Load";
			this.BtnLoad.UseVisualStyleBackColor = true;
			this.BtnLoad.Click += new System.EventHandler(this.BtnLoadClick);
			// 
			// lblMonitoring
			// 
			this.lblMonitoring.Location = new System.Drawing.Point(241, 63);
			this.lblMonitoring.Name = "lblMonitoring";
			this.lblMonitoring.Size = new System.Drawing.Size(100, 23);
			this.lblMonitoring.TabIndex = 3;
			this.lblMonitoring.Text = "Monitoring";
			this.lblMonitoring.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(80, 63);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 23);
			this.label1.TabIndex = 8;
			this.label1.Text = "Log";
			// 
			// tm_AppRefresh
			// 
			this.tm_AppRefresh.Tick += new System.EventHandler(this.tm_AppRefreshTick);
			// 
			// BtnBackup
			// 
			this.BtnBackup.Enabled = false;
			this.BtnBackup.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.BtnBackup.Location = new System.Drawing.Point(150, 476);
			this.BtnBackup.Name = "BtnBackup";
			this.BtnBackup.Size = new System.Drawing.Size(62, 36);
			this.BtnBackup.TabIndex = 9;
			this.BtnBackup.Text = "Backup";
			this.BtnBackup.UseVisualStyleBackColor = true;
			this.BtnBackup.Click += new System.EventHandler(this.BtnBackupClick);
			// 
			// BtnRestore
			// 
			this.BtnRestore.Enabled = false;
			this.BtnRestore.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.BtnRestore.Location = new System.Drawing.Point(218, 476);
			this.BtnRestore.Name = "BtnRestore";
			this.BtnRestore.Size = new System.Drawing.Size(62, 36);
			this.BtnRestore.TabIndex = 10;
			this.BtnRestore.Text = "Restore";
			this.BtnRestore.UseVisualStyleBackColor = true;
			this.BtnRestore.Click += new System.EventHandler(this.BtnRestoreClick);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// pgBackup
			// 
			this.pgBackup.Location = new System.Drawing.Point(310, 476);
			this.pgBackup.Name = "pgBackup";
			this.pgBackup.Size = new System.Drawing.Size(392, 36);
			this.pgBackup.TabIndex = 11;
			this.pgBackup.Visible = false;
			// 
			// LblBackup
			// 
			this.LblBackup.Location = new System.Drawing.Point(310, 455);
			this.LblBackup.Name = "LblBackup";
			this.LblBackup.Size = new System.Drawing.Size(392, 23);
			this.LblBackup.TabIndex = 12;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(80, 426);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(177, 23);
			this.label2.TabIndex = 13;
			this.label2.Text = "Maximum Simultaneos Threads";
			// 
			// NumMaxThreads
			// 
			this.NumMaxThreads.Increment = new decimal(new int[] {
									10,
									0,
									0,
									0});
			this.NumMaxThreads.Location = new System.Drawing.Point(310, 424);
			this.NumMaxThreads.Maximum = new decimal(new int[] {
									9999,
									0,
									0,
									0});
			this.NumMaxThreads.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.NumMaxThreads.Name = "NumMaxThreads";
			this.NumMaxThreads.Size = new System.Drawing.Size(76, 20);
			this.NumMaxThreads.TabIndex = 14;
			this.NumMaxThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.NumMaxThreads.Value = new decimal(new int[] {
									300,
									0,
									0,
									0});
			this.NumMaxThreads.ValueChanged += new System.EventHandler(this.NumMaxThreadsValueChanged);
			// 
			// BtnStand
			// 
			this.BtnStand.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.BtnStand.Location = new System.Drawing.Point(80, 476);
			this.BtnStand.Name = "BtnStand";
			this.BtnStand.Size = new System.Drawing.Size(62, 36);
			this.BtnStand.TabIndex = 15;
			this.BtnStand.Text = "Standby";
			this.BtnStand.UseVisualStyleBackColor = true;
			this.BtnStand.Click += new System.EventHandler(this.BtnStandClick);
			// 
			// zed
			// 
			this.zed.Location = new System.Drawing.Point(85, 85);
			this.zed.Name = "zed";
			this.zed.ScrollGrace = 0;
			this.zed.ScrollMaxX = 0;
			this.zed.ScrollMaxY = 0;
			this.zed.ScrollMaxY2 = 0;
			this.zed.ScrollMinX = 0;
			this.zed.ScrollMinY = 0;
			this.zed.ScrollMinY2 = 0;
			this.zed.Size = new System.Drawing.Size(617, 322);
			this.zed.TabIndex = 16;
			// 
			// ClusterInterface
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(714, 536);
			this.Controls.Add(this.zed);
			this.Controls.Add(this.BtnStand);
			this.Controls.Add(this.NumMaxThreads);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.pgBackup);
			this.Controls.Add(this.BtnRestore);
			this.Controls.Add(this.BtnBackup);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BtnLoad);
			this.Controls.Add(this.BtnCpu);
			this.Controls.Add(this.BtnCluster);
			this.Controls.Add(this.BtnClients);
			this.Controls.Add(this.BtnPause);
			this.Controls.Add(this.BtnStart);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.lblAction);
			this.Controls.Add(this.lblMonitoring);
			this.Controls.Add(this.LblBackup);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "ClusterInterface";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Server Windows Interface";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClusterInterfaceFormClosed);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClusterInterfaceFormClosing);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.NumMaxThreads)).EndInit();
			this.ResumeLayout(false);
		}
		private ZedGraph.ZedGraphControl zed;
		public System.Windows.Forms.Button BtnStand;
		private System.Windows.Forms.NumericUpDown NumMaxThreads;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label LblBackup;
		private System.Windows.Forms.ProgressBar pgBackup;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		public System.Windows.Forms.Button BtnPause;
		public System.Windows.Forms.Button BtnCluster;
		public System.Windows.Forms.Button BtnClients;
		public System.Windows.Forms.Button BtnCpu;
		public System.Windows.Forms.Button BtnLoad;
		public System.Windows.Forms.Button BtnStart;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		public System.Windows.Forms.Button BtnRestore;
		public System.Windows.Forms.Button BtnBackup;
		private System.Windows.Forms.Timer tm_AppRefresh;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.Label lblAction;
		private System.Windows.Forms.Label lblMonitoring;
		private System.Windows.Forms.Label lblConfig;
		private System.Windows.Forms.Label lblNowStats;
		private System.Windows.Forms.Label lblMode;
		private System.Windows.Forms.Label lblState;
		private System.Windows.Forms.Label lblTopic;
		private System.Windows.Forms.Panel panel1;
	}
}
