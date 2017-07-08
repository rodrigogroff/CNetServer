/*
 * Created by SharpDevelop.
 * User: rodrigog
 * Date: 3/10/2008
 * Time: 13:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Client
{
	partial class dlgGraph
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
			this.zed = new ZedGraph.ZedGraphControl();
			this.SuspendLayout();
			// 
			// zed
			// 
			this.zed.IsAntiAlias = true;
			this.zed.IsShowPointValues = true;
			this.zed.IsSynchronizeXAxes = true;
			this.zed.IsSynchronizeYAxes = true;
			this.zed.Location = new System.Drawing.Point(10, 10);
			this.zed.Name = "zed";
			this.zed.ScrollGrace = 0;
			this.zed.ScrollMaxX = 0;
			this.zed.ScrollMaxY = 0;
			this.zed.ScrollMaxY2 = 0;
			this.zed.ScrollMinX = 0;
			this.zed.ScrollMinY = 0;
			this.zed.ScrollMinY2 = 0;
			this.zed.Size = new System.Drawing.Size(520, 460);
			this.zed.TabIndex = 0;
			// 
			// dlgGraph
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(552, 486);
			this.Controls.Add(this.zed);
			this.DoubleBuffered = true;
			this.MinimizeBox = false;
			this.Name = "dlgGraph";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Resize += new System.EventHandler(this.DlgGraphResize);
			this.ResumeLayout(false);
		}
		public ZedGraph.ZedGraphControl zed;
	}
}
