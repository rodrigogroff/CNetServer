using System.Windows.Forms;

namespace Client 
{
	partial class dlgNovoDependente : Form
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
			this.TxtEmpresa = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.TxtMatricula = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtProt = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(18, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Empresa";
			// 
			// TxtEmpresa
			// 
			this.TxtEmpresa.Location = new System.Drawing.Point(94, 29);
			this.TxtEmpresa.Name = "TxtEmpresa";
			this.TxtEmpresa.Size = new System.Drawing.Size(100, 20);
			this.TxtEmpresa.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(18, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Matricula";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.TxtMatricula);
			this.groupBox1.Controls.Add(this.TxtEmpresa);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(15, 18);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(214, 109);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Dados Proprietário";
			// 
			// TxtMatricula
			// 
			this.TxtMatricula.Location = new System.Drawing.Point(94, 67);
			this.TxtMatricula.Name = "TxtMatricula";
			this.TxtMatricula.Size = new System.Drawing.Size(100, 20);
			this.TxtMatricula.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(33, 145);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(157, 23);
			this.label4.TabIndex = 4;
			this.label4.Text = "Nome do proprietário";
			// 
			// TxtProt
			// 
			this.TxtProt.Location = new System.Drawing.Point(33, 162);
			this.TxtProt.Name = "TxtProt";
			this.TxtProt.ReadOnly = true;
			this.TxtProt.Size = new System.Drawing.Size(176, 20);
			this.TxtProt.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(33, 190);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(157, 23);
			this.label5.TabIndex = 7;
			this.label5.Text = "Nome do dependente";
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(33, 206);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.Size = new System.Drawing.Size(176, 20);
			this.TxtNome.TabIndex = 8;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(90, 255);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 9;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// dlgNovoDependente
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(254, 289);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.TxtNome);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.TxtProt);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.groupBox1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgNovoDependente";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Criação de dependente de cartão";
			this.Load += new System.EventHandler(this.DlgNovoDependenteLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtProt;
		public System.Windows.Forms.TextBox TxtNome;
		private System.Windows.Forms.Button BtnConfirmar;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox TxtMatricula;
		public System.Windows.Forms.TextBox TxtEmpresa;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}

