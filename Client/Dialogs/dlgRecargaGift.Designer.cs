using System.Windows.Forms;

namespace Client 
{
	partial class dlgRecargaGift : Form
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
			this.TxtMatricula = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.TxtEmpresa = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TxtMatricula
			// 
			this.TxtMatricula.Location = new System.Drawing.Point(107, 39);
			this.TxtMatricula.Name = "TxtMatricula";
			this.TxtMatricula.Size = new System.Drawing.Size(151, 20);
			this.TxtMatricula.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 42);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 15;
			this.label4.Text = "Matricula";
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(107, 91);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.ReadOnly = true;
			this.TxtNome.Size = new System.Drawing.Size(151, 20);
			this.TxtNome.TabIndex = 14;
			// 
			// TxtEmpresa
			// 
			this.TxtEmpresa.Location = new System.Drawing.Point(107, 16);
			this.TxtEmpresa.Name = "TxtEmpresa";
			this.TxtEmpresa.Size = new System.Drawing.Size(151, 20);
			this.TxtEmpresa.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 94);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 12;
			this.label2.Text = "Nome";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 11;
			this.label1.Text = "Empresa";
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(183, 131);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 6;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// dlgRecargaGift
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(278, 173);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.TxtMatricula);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.TxtNome);
			this.Controls.Add(this.TxtEmpresa);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgRecargaGift";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Recarga de cartão GiftCard";
			this.Load += new System.EventHandler(this.DlgRecargaGiftLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox TxtEmpresa;
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox TxtMatricula;
	}
}

