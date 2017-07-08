using System.Windows.Forms;

namespace Client 
{
	partial class dlgSelecionaEmpresa : Form
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
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.LstEmpresas = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(12, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(133, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Empresas disponíveis";
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(204, 185);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 2;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// LstEmpresas
			// 
			this.LstEmpresas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2});
			this.LstEmpresas.FullRowSelect = true;
			this.LstEmpresas.HideSelection = false;
			this.LstEmpresas.Location = new System.Drawing.Point(12, 31);
			this.LstEmpresas.MultiSelect = false;
			this.LstEmpresas.Name = "LstEmpresas";
			this.LstEmpresas.Size = new System.Drawing.Size(267, 148);
			this.LstEmpresas.TabIndex = 3;
			this.LstEmpresas.UseCompatibleStateImageBehavior = false;
			this.LstEmpresas.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Código";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Nome Fantasia";
			this.columnHeader2.Width = 175;
			// 
			// dlgSelecionaEmpresa
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(292, 221);
			this.Controls.Add(this.LstEmpresas);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgSelecionaEmpresa";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Selecione a Empresa";
			this.Load += new System.EventHandler(this.DlgSelecionaEmpresaLoad);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.ListView LstEmpresas;
		public System.Windows.Forms.Label label1;
	}
}

