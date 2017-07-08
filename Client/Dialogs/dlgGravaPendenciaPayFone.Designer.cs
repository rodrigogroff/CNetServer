using System.Windows.Forms;

namespace Client 
{
	partial class dlgGravaPendenciaPayFone : Form
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
			this.TxtTelefone = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtTelLojista = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtValor = new System.Windows.Forms.TextBox();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(16, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Telefone do cliente";
			// 
			// TxtTelefone
			// 
			this.TxtTelefone.Location = new System.Drawing.Point(138, 46);
			this.TxtTelefone.Name = "TxtTelefone";
			this.TxtTelefone.Size = new System.Drawing.Size(100, 20);
			this.TxtTelefone.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(16, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Telefone do lojista";
			// 
			// TxtTelLojista
			// 
			this.TxtTelLojista.Location = new System.Drawing.Point(138, 22);
			this.TxtTelLojista.Name = "TxtTelLojista";
			this.TxtTelLojista.Size = new System.Drawing.Size(100, 20);
			this.TxtTelLojista.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(16, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Valor da transação";
			// 
			// TxtValor
			// 
			this.TxtValor.Location = new System.Drawing.Point(138, 70);
			this.TxtValor.Name = "TxtValor";
			this.TxtValor.Size = new System.Drawing.Size(100, 20);
			this.TxtValor.TabIndex = 4;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(138, 108);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(100, 23);
			this.BtnConfirmar.TabIndex = 5;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// dlgGravaPendenciaPayFone
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(268, 149);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.TxtValor);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.TxtTelLojista);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TxtTelefone);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgGravaPendenciaPayFone";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Grava Pendência Pay Fone";
			this.Load += new System.EventHandler(this.DlgGravaPendenciaPayFoneLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.TextBox TxtValor;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox TxtTelLojista;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox TxtTelefone;
		public System.Windows.Forms.Label label1;
	}
}

