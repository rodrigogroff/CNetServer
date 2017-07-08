using System.Windows.Forms;

namespace Client 
{
	partial class dlgEduCancelarCartao : Form
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
			this.BtnCancelar = new System.Windows.Forms.Button();
			this.LstAlunos = new System.Windows.Forms.ListBox();
			this.TxtAluno = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// BtnCancelar
			// 
			this.BtnCancelar.Location = new System.Drawing.Point(20, 204);
			this.BtnCancelar.Name = "BtnCancelar";
			this.BtnCancelar.Size = new System.Drawing.Size(218, 23);
			this.BtnCancelar.TabIndex = 4;
			this.BtnCancelar.Text = "Cancelar Cartão";
			this.BtnCancelar.UseVisualStyleBackColor = true;
			this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelarClick);
			// 
			// LstAlunos
			// 
			this.LstAlunos.FormattingEnabled = true;
			this.LstAlunos.Location = new System.Drawing.Point(20, 75);
			this.LstAlunos.Name = "LstAlunos";
			this.LstAlunos.Size = new System.Drawing.Size(218, 108);
			this.LstAlunos.TabIndex = 15;
			// 
			// TxtAluno
			// 
			this.TxtAluno.Location = new System.Drawing.Point(125, 21);
			this.TxtAluno.Name = "TxtAluno";
			this.TxtAluno.Size = new System.Drawing.Size(113, 20);
			this.TxtAluno.TabIndex = 14;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(20, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(139, 23);
			this.label2.TabIndex = 13;
			this.label2.Text = "Cartões";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(20, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(139, 23);
			this.label1.TabIndex = 12;
			this.label1.Text = "Nome do aluno";
			// 
			// dlgEduCancelarCartao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(260, 250);
			this.Controls.Add(this.LstAlunos);
			this.Controls.Add(this.TxtAluno);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BtnCancelar);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgEduCancelarCartao";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cancelar Cartão de Aluno";
			this.Load += new System.EventHandler(this.DlgEduCancelarCartaoLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox TxtAluno;
		public System.Windows.Forms.ListBox LstAlunos;
		private System.Windows.Forms.Button BtnCancelar;
	}
}

