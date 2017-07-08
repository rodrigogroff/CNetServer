using System.Windows.Forms;

namespace Client 
{
	partial class dlgConfirmarRepasse : Form
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
			this.TxtDataIni = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.LstLojas = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.label3 = new System.Windows.Forms.Label();
			this.LstDetalhes = new System.Windows.Forms.ListView();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtRepasse = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Data para repasse";
			// 
			// TxtDataIni
			// 
			this.TxtDataIni.Location = new System.Drawing.Point(133, 20);
			this.TxtDataIni.Name = "TxtDataIni";
			this.TxtDataIni.Size = new System.Drawing.Size(96, 20);
			this.TxtDataIni.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(256, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Selecione uma loja para ver os detalhes de vendas";
			// 
			// LstLojas
			// 
			this.LstLojas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2});
			this.LstLojas.FullRowSelect = true;
			this.LstLojas.HideSelection = false;
			this.LstLojas.Location = new System.Drawing.Point(12, 80);
			this.LstLojas.Name = "LstLojas";
			this.LstLojas.Size = new System.Drawing.Size(519, 133);
			this.LstLojas.TabIndex = 3;
			this.LstLojas.UseCompatibleStateImageBehavior = false;
			this.LstLojas.View = System.Windows.Forms.View.Details;
			this.LstLojas.Click += new System.EventHandler(this.LstLojasClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Loja";
			this.columnHeader1.Width = 320;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Valor R$";
			this.columnHeader2.Width = 80;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 225);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(253, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Vendas confirmadas da loja selecionada";
			// 
			// LstDetalhes
			// 
			this.LstDetalhes.CheckBoxes = true;
			this.LstDetalhes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader3,
									this.columnHeader4,
									this.columnHeader5,
									this.columnHeader6,
									this.columnHeader7});
			this.LstDetalhes.FullRowSelect = true;
			this.LstDetalhes.HideSelection = false;
			this.LstDetalhes.Location = new System.Drawing.Point(12, 242);
			this.LstDetalhes.Name = "LstDetalhes";
			this.LstDetalhes.Size = new System.Drawing.Size(519, 241);
			this.LstDetalhes.TabIndex = 5;
			this.LstDetalhes.UseCompatibleStateImageBehavior = false;
			this.LstDetalhes.View = System.Windows.Forms.View.Details;
			this.LstDetalhes.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListView1ItemChecked);
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Valor R$";
			this.columnHeader3.Width = 70;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Cartão";
			this.columnHeader4.Width = 110;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "NSU";
			this.columnHeader5.Width = 70;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Data Venda";
			this.columnHeader6.Width = 120;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Data Repasse";
			this.columnHeader7.Width = 120;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(153, 499);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(245, 32);
			this.BtnConfirmar.TabIndex = 6;
			this.BtnConfirmar.Text = "Confirmar repasse para loja selecionada";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(298, 23);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Repasses previstos";
			// 
			// TxtRepasse
			// 
			this.TxtRepasse.Location = new System.Drawing.Point(422, 20);
			this.TxtRepasse.Name = "TxtRepasse";
			this.TxtRepasse.ReadOnly = true;
			this.TxtRepasse.Size = new System.Drawing.Size(109, 20);
			this.TxtRepasse.TabIndex = 8;
			this.TxtRepasse.TabStop = false;
			// 
			// dlgConfirmarRepasse
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(551, 545);
			this.Controls.Add(this.TxtRepasse);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.LstDetalhes);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.LstLojas);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TxtDataIni);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgConfirmarRepasse";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Confirmação de Repasses";
			this.Load += new System.EventHandler(this.DlgConfirmarRepasseLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ColumnHeader columnHeader7;
		public System.Windows.Forms.TextBox TxtRepasse;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.ListView LstDetalhes;
		public System.Windows.Forms.TextBox TxtDataIni;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.ColumnHeader columnHeader6;
		public System.Windows.Forms.ColumnHeader columnHeader5;
		public System.Windows.Forms.ColumnHeader columnHeader4;
		public System.Windows.Forms.ColumnHeader columnHeader3;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.ColumnHeader columnHeader2;
		public System.Windows.Forms.ColumnHeader columnHeader1;
		public System.Windows.Forms.ListView LstLojas;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
	}
}

