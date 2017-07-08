/*
 * Created by SharpDevelop.
 * User: rodrigo.groff
 * Date: 22/10/2007
 * Time: 10:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ServerSetup
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblVers = new System.Windows.Forms.Label();
			this.lblSubTitle = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.btnPrevious = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.ctrl_appDir1 = new ServerSetup.ctrl_appDir();
			this.ctrl_Intro1 = new ServerSetup.ctrl_Intro();
			
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.ctrl_bdChoice1 = new ServerSetup.ctrl_bdChoice();
			this.ctrl_configInstall1 = new ServerSetup.ctrl_configInstall();
			this.ctrl_installing1 = new ServerSetup.ctrl_installing();
			
			this.ctrl_softRemove1 = new ServerSetup.ctrl_softRemove();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.lblVers);
			this.panel1.Controls.Add(this.lblSubTitle);
			this.panel1.Controls.Add(this.lblTitle);
			this.panel1.Location = new System.Drawing.Point(-12, -8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(584, 66);
			this.panel1.TabIndex = 0;
			// 
			// lblVers
			// 
			this.lblVers.BackColor = System.Drawing.Color.Transparent;
			this.lblVers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblVers.Location = new System.Drawing.Point(425, 20);
			this.lblVers.Name = "lblVers";
			this.lblVers.Size = new System.Drawing.Size(66, 23);
			this.lblVers.TabIndex = 2;
			this.lblVers.Text = "01.00.0001";
			this.lblVers.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblSubTitle
			// 
			this.lblSubTitle.BackColor = System.Drawing.Color.Transparent;
			this.lblSubTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSubTitle.Location = new System.Drawing.Point(23, 37);
			this.lblSubTitle.Name = "lblSubTitle";
			this.lblSubTitle.Size = new System.Drawing.Size(442, 23);
			this.lblSubTitle.TabIndex = 1;
			this.lblSubTitle.Text = "Click \'Next\' to proceed with the installation procedure.";
			// 
			// lblTitle
			// 
			this.lblTitle.BackColor = System.Drawing.Color.Transparent;
			this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.Location = new System.Drawing.Point(23, 20);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(260, 23);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Welcome to the installation program";
			// 
			// btnPrevious
			// 
			this.btnPrevious.Location = new System.Drawing.Point(177, 341);
			this.btnPrevious.Name = "btnPrevious";
			this.btnPrevious.Size = new System.Drawing.Size(75, 23);
			this.btnPrevious.TabIndex = 1;
			this.btnPrevious.Text = "Previous";
			this.btnPrevious.UseVisualStyleBackColor = true;
			this.btnPrevious.Click += new System.EventHandler(this.BtnPreviousClick);
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(360, 341);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(75, 23);
			this.btnNext.TabIndex = 2;
			this.btnNext.Text = "Next";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.BtnNextClick);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Location = new System.Drawing.Point(-2, 57);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(150, 345);
			this.panel2.TabIndex = 3;
			// 
			// panel3
			// 
			this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
			this.panel3.Location = new System.Drawing.Point(-19, -28);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(178, 347);
			this.panel3.TabIndex = 0;
			// 
			// ctrl_appDir1
			// 
			this.ctrl_appDir1.Location = new System.Drawing.Point(160, 68);
			this.ctrl_appDir1.Name = "ctrl_appDir1";
			this.ctrl_appDir1.Size = new System.Drawing.Size(320, 274);
			this.ctrl_appDir1.TabIndex = 0;
			// 
			// ctrl_Intro1
			// 
			this.ctrl_Intro1.Location = new System.Drawing.Point(160, 68);
			this.ctrl_Intro1.Name = "ctrl_Intro1";
			this.ctrl_Intro1.Size = new System.Drawing.Size(320, 274);
			this.ctrl_Intro1.TabIndex = 4;
			
			// 
			// timer1
			// 
			this.timer1.Interval = 10;
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// ctrl_bdChoice1
			// 
			this.ctrl_bdChoice1.Location = new System.Drawing.Point(160, 68);
			this.ctrl_bdChoice1.Name = "ctrl_bdChoice1";
			this.ctrl_bdChoice1.Size = new System.Drawing.Size(320, 274);
			this.ctrl_bdChoice1.TabIndex = 6;
			// 
			// ctrl_configInstall1
			// 
			this.ctrl_configInstall1.Location = new System.Drawing.Point(160, 68);
			this.ctrl_configInstall1.Name = "ctrl_configInstall1";
			this.ctrl_configInstall1.Size = new System.Drawing.Size(320, 274);
			this.ctrl_configInstall1.TabIndex = 7;
			// 
			// ctrl_installing1
			// 
			this.ctrl_installing1.Location = new System.Drawing.Point(160, 68);
			this.ctrl_installing1.Name = "ctrl_installing1";
			this.ctrl_installing1.Size = new System.Drawing.Size(320, 274);
			this.ctrl_installing1.TabIndex = 8;
			
			// 
			// ctrl_softRemove1
			// 
			this.ctrl_softRemove1.Location = new System.Drawing.Point(160, 68);
			this.ctrl_softRemove1.Name = "ctrl_softRemove1";
			this.ctrl_softRemove1.Size = new System.Drawing.Size(320, 274);
			this.ctrl_softRemove1.TabIndex = 10;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(490, 374);
			this.Controls.Add(this.ctrl_softRemove1);
			
			this.Controls.Add(this.ctrl_installing1);
			this.Controls.Add(this.ctrl_configInstall1);
			this.Controls.Add(this.ctrl_bdChoice1);
			this.Controls.Add(this.ctrl_appDir1);
			
			this.Controls.Add(this.ctrl_Intro1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnPrevious);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Server Setup";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lblVers;
		private ServerSetup.ctrl_softRemove ctrl_softRemove1;
		
		private ServerSetup.ctrl_installing ctrl_installing1;
		private ServerSetup.ctrl_configInstall ctrl_configInstall1;
		private ServerSetup.ctrl_bdChoice ctrl_bdChoice1;
		private ServerSetup.ctrl_appDir ctrl_appDir1;
		private System.Windows.Forms.Timer timer1;
		
		private ServerSetup.ctrl_Intro ctrl_Intro1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lblSubTitle;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnPrevious;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Panel panel1;
	}
}
