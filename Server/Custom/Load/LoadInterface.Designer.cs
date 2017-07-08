/*
 * Created by SharpDevelop.
 * User: rodrigo.groff
 * Date: 29/01/2008
 * Time: 12:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SyCrafEngine
{
	partial class LoadInterface
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
			this.BtnRun = new System.Windows.Forms.Button();
			this.numThreads = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.LstThreads = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.label3 = new System.Windows.Forms.Label();
			this.LstReport = new System.Windows.Forms.ListView();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtTransaction = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.numThreads)).BeginInit();
			this.SuspendLayout();
			// 
			// BtnRun
			// 
			this.BtnRun.Location = new System.Drawing.Point(238, 65);
			this.BtnRun.Name = "BtnRun";
			this.BtnRun.Size = new System.Drawing.Size(75, 23);
			this.BtnRun.TabIndex = 0;
			this.BtnRun.Text = "Run";
			this.BtnRun.UseVisualStyleBackColor = true;
			this.BtnRun.Click += new System.EventHandler(this.BtnRunClick);
			// 
			// numThreads
			// 
			this.numThreads.Location = new System.Drawing.Point(145, 19);
			this.numThreads.Maximum = new decimal(new int[] {
									9999,
									0,
									0,
									0});
			this.numThreads.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.numThreads.Name = "numThreads";
			this.numThreads.Size = new System.Drawing.Size(61, 20);
			this.numThreads.TabIndex = 1;
			this.numThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numThreads.Value = new decimal(new int[] {
									1,
									0,
									0,
									0});
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(15, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Simultaneous tasks";
			// 
			// LstThreads
			// 
			this.LstThreads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3,
									this.columnHeader4});
			this.LstThreads.FullRowSelect = true;
			this.LstThreads.Location = new System.Drawing.Point(12, 124);
			this.LstThreads.Name = "LstThreads";
			this.LstThreads.Size = new System.Drawing.Size(328, 154);
			this.LstThreads.TabIndex = 3;
			this.LstThreads.UseCompatibleStateImageBehavior = false;
			this.LstThreads.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Thread";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Done";
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Lowest (ms)";
			this.columnHeader3.Width = 90;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Time";
			this.columnHeader4.Width = 90;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 105);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 7;
			this.label3.Text = "Thread execution";
			// 
			// LstReport
			// 
			this.LstReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader5,
									this.columnHeader6,
									this.columnHeader7,
									this.columnHeader8});
			this.LstReport.FullRowSelect = true;
			this.LstReport.Location = new System.Drawing.Point(12, 307);
			this.LstReport.Name = "LstReport";
			this.LstReport.Size = new System.Drawing.Size(328, 129);
			this.LstReport.TabIndex = 8;
			this.LstReport.UseCompatibleStateImageBehavior = false;
			this.LstReport.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Threads";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Lowest";
			this.columnHeader6.Width = 75;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Average";
			this.columnHeader7.Width = 75;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Max Time";
			this.columnHeader8.Width = 90;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 288);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 9;
			this.label4.Text = "Process report";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(15, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 10;
			this.label2.Text = "Transaction";
			// 
			// TxtTransaction
			// 
			this.TxtTransaction.Location = new System.Drawing.Point(15, 67);
			this.TxtTransaction.Name = "TxtTransaction";
			this.TxtTransaction.Size = new System.Drawing.Size(191, 20);
			this.TxtTransaction.TabIndex = 11;
			this.TxtTransaction.Text = "!";
			// 
			// LoadInterface
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(364, 463);
			this.Controls.Add(this.TxtTransaction);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.LstReport);
			this.Controls.Add(this.LstThreads);
			this.Controls.Add(this.numThreads);
			this.Controls.Add(this.BtnRun);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.DoubleBuffered = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LoadInterface";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Server Load Performance Test";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoadInterfaceFormClosing);
			((System.ComponentModel.ISupportInitialize)(this.numThreads)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox TxtTransaction;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListView LstReport;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListView LstThreads;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numThreads;
		private System.Windows.Forms.Button BtnRun;
	}
}
