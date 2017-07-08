using System.Windows.Forms;

namespace Client 
{
	partial class dlgPrevLojista : Form
	{
		private System.ComponentModel.IContainer components = null;
		
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
			this.label1 = new System.Windows.Forms.Label();
			this.LstEmp = new System.Windows.Forms.ListBox();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(17, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(142, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Selecione a associação:";
			// 
			// LstEmp
			// 
			this.LstEmp.FormattingEnabled = true;
			this.LstEmp.Location = new System.Drawing.Point(17, 38);
			this.LstEmp.Name = "LstEmp";
			this.LstEmp.Size = new System.Drawing.Size(248, 134);
			this.LstEmp.TabIndex = 1;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(190, 189);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 2;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// dlgPrevLojista
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(286, 229);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.LstEmp);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgPrevLojista";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Previsão de repasse por associações";
			this.Load += new System.EventHandler(this.DlgPrevLojistaLoad);
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.ListBox LstEmp;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.Label label1;
	}
}

