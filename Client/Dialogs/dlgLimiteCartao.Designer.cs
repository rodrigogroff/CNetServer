using System.Windows.Forms;

namespace Client 
{
	partial class dlgLimiteCartao : Form
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
			this.LstCartoes = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.TxtCpf = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.TxtLimTotal = new System.Windows.Forms.TextBox();
			this.TxtLimRotativo = new System.Windows.Forms.TextBox();
			this.TxtLimMensal = new System.Windows.Forms.TextBox();
			this.TxtCotaExtra = new System.Windows.Forms.TextBox();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.LblNome = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(22, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "CPF Proprietário";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(22, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(157, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Cartões disponíveis";
			// 
			// LstCartoes
			// 
			this.LstCartoes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3});
			this.LstCartoes.FullRowSelect = true;
			this.LstCartoes.HideSelection = false;
			this.LstCartoes.Location = new System.Drawing.Point(22, 74);
			this.LstCartoes.MultiSelect = false;
			this.LstCartoes.Name = "LstCartoes";
			this.LstCartoes.Size = new System.Drawing.Size(300, 169);
			this.LstCartoes.TabIndex = 2;
			this.LstCartoes.UseCompatibleStateImageBehavior = false;
			this.LstCartoes.View = System.Windows.Forms.View.Details;
			this.LstCartoes.Click += new System.EventHandler(this.LstCartoesClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Número";
			this.columnHeader1.Width = 90;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Status";
			this.columnHeader2.Width = 90;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Vencimento";
			this.columnHeader3.Width = 90;
			// 
			// TxtCpf
			// 
			this.TxtCpf.Location = new System.Drawing.Point(139, 18);
			this.TxtCpf.Name = "TxtCpf";
			this.TxtCpf.Size = new System.Drawing.Size(94, 20);
			this.TxtCpf.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Location = new System.Drawing.Point(14, 27);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 5;
			this.label4.Text = "Total";
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Location = new System.Drawing.Point(14, 50);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 6;
			this.label5.Text = "Rotativo";
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Location = new System.Drawing.Point(14, 73);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 7;
			this.label6.Text = "Mensal";
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Location = new System.Drawing.Point(14, 96);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 8;
			this.label7.Text = "Cota Extra";
			// 
			// TxtLimTotal
			// 
			this.TxtLimTotal.Location = new System.Drawing.Point(73, 24);
			this.TxtLimTotal.Name = "TxtLimTotal";
			this.TxtLimTotal.Size = new System.Drawing.Size(115, 20);
			this.TxtLimTotal.TabIndex = 3;
			// 
			// TxtLimRotativo
			// 
			this.TxtLimRotativo.Location = new System.Drawing.Point(73, 47);
			this.TxtLimRotativo.Name = "TxtLimRotativo";
			this.TxtLimRotativo.Size = new System.Drawing.Size(115, 20);
			this.TxtLimRotativo.TabIndex = 4;
			// 
			// TxtLimMensal
			// 
			this.TxtLimMensal.Location = new System.Drawing.Point(73, 70);
			this.TxtLimMensal.Name = "TxtLimMensal";
			this.TxtLimMensal.Size = new System.Drawing.Size(115, 20);
			this.TxtLimMensal.TabIndex = 5;
			// 
			// TxtCotaExtra
			// 
			this.TxtCotaExtra.Location = new System.Drawing.Point(73, 93);
			this.TxtCotaExtra.Name = "TxtCotaExtra";
			this.TxtCotaExtra.Size = new System.Drawing.Size(115, 20);
			this.TxtCotaExtra.TabIndex = 6;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(113, 127);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 7;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.groupBox1.Controls.Add(this.TxtLimTotal);
			this.groupBox1.Controls.Add(this.BtnConfirmar);
			this.groupBox1.Controls.Add(this.TxtCotaExtra);
			this.groupBox1.Controls.Add(this.TxtLimMensal);
			this.groupBox1.Controls.Add(this.TxtLimRotativo);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.groupBox1.Location = new System.Drawing.Point(328, 74);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(214, 169);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Limites do Cartões";
			// 
			// LblNome
			// 
			this.LblNome.BackColor = System.Drawing.Color.Transparent;
			this.LblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblNome.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LblNome.Location = new System.Drawing.Point(260, 21);
			this.LblNome.Name = "LblNome";
			this.LblNome.Size = new System.Drawing.Size(289, 23);
			this.LblNome.TabIndex = 15;
			// 
			// dlgLimiteCartao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(561, 263);
			this.Controls.Add(this.LblNome);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.TxtCpf);
			this.Controls.Add(this.LstCartoes);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgLimiteCartao";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Limites de Cartão";
			this.Load += new System.EventHandler(this.DlgLimiteCartaoLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.Label LblNome;
		public System.Windows.Forms.TextBox TxtCpf;
		public System.Windows.Forms.TextBox TxtCotaExtra;
		public System.Windows.Forms.TextBox TxtLimMensal;
		public System.Windows.Forms.TextBox TxtLimRotativo;
		public System.Windows.Forms.TextBox TxtLimTotal;
		public System.Windows.Forms.ListView LstCartoes;
		public System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.Label label7;
		public System.Windows.Forms.Label label6;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.ColumnHeader columnHeader3;
		public System.Windows.Forms.ColumnHeader columnHeader2;
		public System.Windows.Forms.ColumnHeader columnHeader1;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
	}
}

