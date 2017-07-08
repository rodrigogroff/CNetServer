using System.Windows.Forms;

namespace Client 
{
	partial class dlgVendaOffline : Form
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
			this.TxtMoney_Valor = new System.Windows.Forms.TextBox();
			this.TxtCartao = new System.Windows.Forms.TextBox();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Valor";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Cartão";
			// 
			// TxtMoney_Valor
			// 
			this.TxtMoney_Valor.Location = new System.Drawing.Point(81, 25);
			this.TxtMoney_Valor.Name = "TxtMoney_Valor";
			this.TxtMoney_Valor.Size = new System.Drawing.Size(148, 20);
			this.TxtMoney_Valor.TabIndex = 2;
			// 
			// TxtCartao
			// 
			this.TxtCartao.Location = new System.Drawing.Point(81, 58);
			this.TxtCartao.Name = "TxtCartao";
			this.TxtCartao.Size = new System.Drawing.Size(148, 20);
			this.TxtCartao.TabIndex = 3;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(154, 91);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 4;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// dlgVendaOffline
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(259, 139);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.TxtCartao);
			this.Controls.Add(this.TxtMoney_Valor);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgVendaOffline";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Venda Offline";
			this.Load += new System.EventHandler(this.dlgVendaOfflineLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtCartao;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.TextBox TxtMoney_Valor;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
	}
}

