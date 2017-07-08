using System.Windows.Forms;

namespace Client 
{
	partial class dlgFaturamento : Form
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
			this.CboTipo = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtCodigo = new System.Windows.Forms.TextBox();
			this.TxtResponse = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(21, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tipo";
			// 
			// CboTipo
			// 
			this.CboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboTipo.FormattingEnabled = true;
			this.CboTipo.Items.AddRange(new object[] {
									"Empresa ou Associação",
									"Loja"});
			this.CboTipo.Location = new System.Drawing.Point(77, 22);
			this.CboTipo.Name = "CboTipo";
			this.CboTipo.Size = new System.Drawing.Size(154, 21);
			this.CboTipo.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(256, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Código";
			// 
			// TxtCodigo
			// 
			this.TxtCodigo.Location = new System.Drawing.Point(303, 22);
			this.TxtCodigo.Name = "TxtCodigo";
			this.TxtCodigo.Size = new System.Drawing.Size(65, 20);
			this.TxtCodigo.TabIndex = 1;
			// 
			// TxtResponse
			// 
			this.TxtResponse.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtResponse.Location = new System.Drawing.Point(21, 61);
			this.TxtResponse.Multiline = true;
			this.TxtResponse.Name = "TxtResponse";
			this.TxtResponse.ReadOnly = true;
			this.TxtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TxtResponse.Size = new System.Drawing.Size(347, 172);
			this.TxtResponse.TabIndex = 4;
			this.TxtResponse.TabStop = false;
			// 
			// dlgFaturamento
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(389, 255);
			this.Controls.Add(this.TxtResponse);
			this.Controls.Add(this.TxtCodigo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.CboTipo);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgFaturamento";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Faturamento Pendente";
			this.Load += new System.EventHandler(this.DlgFaturamentoLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtResponse;
		public System.Windows.Forms.ComboBox CboTipo;
		public System.Windows.Forms.TextBox TxtCodigo;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
	}
}

