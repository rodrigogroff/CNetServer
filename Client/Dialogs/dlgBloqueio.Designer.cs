using System.Windows.Forms;

namespace Client 
{
	partial class dlgBloqueio : Form
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
			this.TxtEmpresa = new System.Windows.Forms.TextBox();
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.CboBloq = new System.Windows.Forms.ComboBox();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtMatricula = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.TxtTit = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Empresa";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 103);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Nome";
			// 
			// TxtEmpresa
			// 
			this.TxtEmpresa.Location = new System.Drawing.Point(107, 11);
			this.TxtEmpresa.Name = "TxtEmpresa";
			this.TxtEmpresa.Size = new System.Drawing.Size(121, 20);
			this.TxtEmpresa.TabIndex = 2;
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(107, 100);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.ReadOnly = true;
			this.TxtNome.Size = new System.Drawing.Size(232, 20);
			this.TxtNome.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 133);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Motivo Bloqueio";
			// 
			// CboBloq
			// 
			this.CboBloq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboBloq.FormattingEnabled = true;
			this.CboBloq.Location = new System.Drawing.Point(107, 130);
			this.CboBloq.Name = "CboBloq";
			this.CboBloq.Size = new System.Drawing.Size(232, 21);
			this.CboBloq.TabIndex = 5;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(264, 172);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 6;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 38);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Matricula";
			// 
			// TxtMatricula
			// 
			this.TxtMatricula.Location = new System.Drawing.Point(107, 35);
			this.TxtMatricula.Name = "TxtMatricula";
			this.TxtMatricula.Size = new System.Drawing.Size(121, 20);
			this.TxtMatricula.TabIndex = 8;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(12, 62);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 9;
			this.label5.Text = "Titularidade";
			// 
			// TxtTit
			// 
			this.TxtTit.Location = new System.Drawing.Point(107, 59);
			this.TxtTit.Name = "TxtTit";
			this.TxtTit.Size = new System.Drawing.Size(121, 20);
			this.TxtTit.TabIndex = 10;
			// 
			// dlgBloqueio
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(359, 212);
			this.Controls.Add(this.TxtTit);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.TxtMatricula);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.CboBloq);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.TxtNome);
			this.Controls.Add(this.TxtEmpresa);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgBloqueio";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Bloqueio de Cartão";
			this.Load += new System.EventHandler(this.DlgBloqueioLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtTit;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.TextBox TxtEmpresa;
		public System.Windows.Forms.TextBox TxtMatricula;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.ComboBox CboBloq;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
	}
}

