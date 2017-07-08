using System.Windows.Forms;

namespace Client 
{
	partial class dlgLocalizacao : Form
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
			this.label2 = new System.Windows.Forms.Label();
			this.TxtLocalizacao = new System.Windows.Forms.TextBox();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(17, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Localização";
			// 
			// TxtLocalizacao
			// 
			this.TxtLocalizacao.Location = new System.Drawing.Point(89, 26);
			this.TxtLocalizacao.Name = "TxtLocalizacao";
			this.TxtLocalizacao.Size = new System.Drawing.Size(181, 20);
			this.TxtLocalizacao.TabIndex = 3;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(109, 77);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 4;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// dlgLocalizacao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(292, 119);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.TxtLocalizacao);
			this.Controls.Add(this.label2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgLocalizacao";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Localização de Terminal";
			this.Load += new System.EventHandler(this.DlgLocalizacaoLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.TextBox TxtLocalizacao;
		public System.Windows.Forms.Label label2;
	}
}

