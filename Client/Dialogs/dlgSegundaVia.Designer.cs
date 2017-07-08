using System.Windows.Forms;

namespace Client 
{
	partial class dlgSegundaVia : Form
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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtEmpresa = new System.Windows.Forms.TextBox();
			this.TxtMatricula = new System.Windows.Forms.TextBox();
			this.TxtTitularidade = new System.Windows.Forms.TextBox();
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Empresa";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(94, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Matricula";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(174, 20);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(79, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Titularidade";
			// 
			// TxtEmpresa
			// 
			this.TxtEmpresa.Location = new System.Drawing.Point(16, 39);
			this.TxtEmpresa.Name = "TxtEmpresa";
			this.TxtEmpresa.Size = new System.Drawing.Size(54, 20);
			this.TxtEmpresa.TabIndex = 3;
			this.TxtEmpresa.Text = "000000";
			// 
			// TxtMatricula
			// 
			this.TxtMatricula.Location = new System.Drawing.Point(94, 39);
			this.TxtMatricula.Name = "TxtMatricula";
			this.TxtMatricula.Size = new System.Drawing.Size(54, 20);
			this.TxtMatricula.TabIndex = 4;
			this.TxtMatricula.Text = "000000";
			// 
			// TxtTitularidade
			// 
			this.TxtTitularidade.Location = new System.Drawing.Point(174, 39);
			this.TxtTitularidade.Name = "TxtTitularidade";
			this.TxtTitularidade.Size = new System.Drawing.Size(54, 20);
			this.TxtTitularidade.TabIndex = 5;
			this.TxtTitularidade.Text = "99";
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(16, 92);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.ReadOnly = true;
			this.TxtNome.Size = new System.Drawing.Size(212, 20);
			this.TxtNome.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 73);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 8;
			this.label4.Text = "Nome proprietário";
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(16, 128);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(212, 23);
			this.BtnConfirmar.TabIndex = 9;
			this.BtnConfirmar.Text = "Solicitar segunda via";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// dlgSegundaVia
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(258, 174);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.TxtNome);
			this.Controls.Add(this.TxtTitularidade);
			this.Controls.Add(this.TxtMatricula);
			this.Controls.Add(this.TxtEmpresa);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label4);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgSegundaVia";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Segunda via de cartão";
			this.Load += new System.EventHandler(this.DlgSegundaViaLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.TextBox TxtTitularidade;
		public System.Windows.Forms.TextBox TxtMatricula;
		public System.Windows.Forms.TextBox TxtEmpresa;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
	}
}

