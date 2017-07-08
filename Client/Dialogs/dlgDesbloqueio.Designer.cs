using System.Windows.Forms;

namespace Client 
{
	partial class dlgDesbloqueio : Form
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
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtTit = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.TxtMatricula = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtEmpresa = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(264, 129);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 13;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(107, 91);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.ReadOnly = true;
			this.TxtNome.Size = new System.Drawing.Size(232, 20);
			this.TxtNome.TabIndex = 10;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 94);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 8;
			this.label2.Text = "Nome";
			// 
			// TxtTit
			// 
			this.TxtTit.Location = new System.Drawing.Point(107, 60);
			this.TxtTit.Name = "TxtTit";
			this.TxtTit.Size = new System.Drawing.Size(121, 20);
			this.TxtTit.TabIndex = 19;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(12, 63);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 18;
			this.label5.Text = "Titularidade";
			// 
			// TxtMatricula
			// 
			this.TxtMatricula.Location = new System.Drawing.Point(107, 36);
			this.TxtMatricula.Name = "TxtMatricula";
			this.TxtMatricula.Size = new System.Drawing.Size(121, 20);
			this.TxtMatricula.TabIndex = 17;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 39);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 16;
			this.label4.Text = "Matricula";
			// 
			// TxtEmpresa
			// 
			this.TxtEmpresa.Location = new System.Drawing.Point(107, 12);
			this.TxtEmpresa.Name = "TxtEmpresa";
			this.TxtEmpresa.Size = new System.Drawing.Size(121, 20);
			this.TxtEmpresa.TabIndex = 15;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 14;
			this.label1.Text = "Empresa";
			// 
			// dlgDesbloqueio
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(356, 165);
			this.Controls.Add(this.TxtTit);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.TxtMatricula);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.TxtEmpresa);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.TxtNome);
			this.Controls.Add(this.label2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgDesbloqueio";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Desbloqueio de Cartão";
			this.Load += new System.EventHandler(this.DlgDesbloqueioLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox TxtEmpresa;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox TxtMatricula;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.TextBox TxtTit;
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.Label label2;
	}
}

