using System.Windows.Forms;

namespace Client 
{
	partial class dlgEduSegundaVia : Form
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
			this.BtnEmitir = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.TxtAluno = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.LstAlunos = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// BtnEmitir
			// 
			this.BtnEmitir.Location = new System.Drawing.Point(23, 201);
			this.BtnEmitir.Name = "BtnEmitir";
			this.BtnEmitir.Size = new System.Drawing.Size(218, 23);
			this.BtnEmitir.TabIndex = 9;
			this.BtnEmitir.Text = "Emitir nova via";
			this.BtnEmitir.UseVisualStyleBackColor = true;
			this.BtnEmitir.Click += new System.EventHandler(this.BtnEmitirClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(23, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(139, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "Nome do aluno";
			// 
			// TxtAluno
			// 
			this.TxtAluno.Location = new System.Drawing.Point(128, 20);
			this.TxtAluno.Name = "TxtAluno";
			this.TxtAluno.Size = new System.Drawing.Size(113, 20);
			this.TxtAluno.TabIndex = 10;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(23, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(139, 23);
			this.label2.TabIndex = 7;
			this.label2.Text = "Cartões";
			// 
			// LstAlunos
			// 
			this.LstAlunos.FormattingEnabled = true;
			this.LstAlunos.Location = new System.Drawing.Point(23, 74);
			this.LstAlunos.Name = "LstAlunos";
			this.LstAlunos.Size = new System.Drawing.Size(218, 108);
			this.LstAlunos.TabIndex = 11;
			// 
			// dlgEduSegundaVia
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(272, 248);
			this.Controls.Add(this.LstAlunos);
			this.Controls.Add(this.TxtAluno);
			this.Controls.Add(this.BtnEmitir);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgEduSegundaVia";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Emissão de segunda via";
			this.Load += new System.EventHandler(this.DlgEduSegundaViaLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtAluno;
		public System.Windows.Forms.ListBox LstAlunos;
		public System.Windows.Forms.Button BtnEmitir;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.Label label2;
	}
}

