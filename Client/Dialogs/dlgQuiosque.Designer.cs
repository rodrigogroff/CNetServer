using System.Windows.Forms;

namespace Client 
{
	partial class dlgQuiosque : Form
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
			this.LstQ = new System.Windows.Forms.ListBox();
			this.BtnRemover = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtNovo = new System.Windows.Forms.TextBox();
			this.BtnAdicionar = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.LstVend = new System.Windows.Forms.ListBox();
			this.LstTodos = new System.Windows.Forms.ListBox();
			this.BtnLiberar = new System.Windows.Forms.Button();
			this.BtnVincular = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.TxtEmpresa = new System.Windows.Forms.TextBox();
			this.TxtNomeEmp = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(13, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Lista de Quiosques";
			// 
			// LstQ
			// 
			this.LstQ.FormattingEnabled = true;
			this.LstQ.Location = new System.Drawing.Point(13, 71);
			this.LstQ.Name = "LstQ";
			this.LstQ.Size = new System.Drawing.Size(120, 108);
			this.LstQ.TabIndex = 1;
			this.LstQ.SelectedIndexChanged += new System.EventHandler(this.LstQSelectedIndexChanged);
			// 
			// BtnRemover
			// 
			this.BtnRemover.Location = new System.Drawing.Point(13, 185);
			this.BtnRemover.Name = "BtnRemover";
			this.BtnRemover.Size = new System.Drawing.Size(120, 23);
			this.BtnRemover.TabIndex = 2;
			this.BtnRemover.Text = "Remover";
			this.BtnRemover.UseVisualStyleBackColor = true;
			this.BtnRemover.Click += new System.EventHandler(this.BtnRemoverClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 227);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Novo Quiosque";
			// 
			// TxtNovo
			// 
			this.TxtNovo.Location = new System.Drawing.Point(13, 244);
			this.TxtNovo.Name = "TxtNovo";
			this.TxtNovo.Size = new System.Drawing.Size(120, 20);
			this.TxtNovo.TabIndex = 4;
			// 
			// BtnAdicionar
			// 
			this.BtnAdicionar.Location = new System.Drawing.Point(149, 241);
			this.BtnAdicionar.Name = "BtnAdicionar";
			this.BtnAdicionar.Size = new System.Drawing.Size(120, 23);
			this.BtnAdicionar.TabIndex = 5;
			this.BtnAdicionar.Text = "Adicionar";
			this.BtnAdicionar.UseVisualStyleBackColor = true;
			this.BtnAdicionar.Click += new System.EventHandler(this.BtnAdicionarClick);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(149, 53);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(154, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Associados";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(285, 53);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(120, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Não associados";
			// 
			// LstVend
			// 
			this.LstVend.FormattingEnabled = true;
			this.LstVend.Location = new System.Drawing.Point(149, 71);
			this.LstVend.Name = "LstVend";
			this.LstVend.Size = new System.Drawing.Size(120, 108);
			this.LstVend.TabIndex = 8;
			// 
			// LstTodos
			// 
			this.LstTodos.FormattingEnabled = true;
			this.LstTodos.Location = new System.Drawing.Point(285, 71);
			this.LstTodos.Name = "LstTodos";
			this.LstTodos.Size = new System.Drawing.Size(120, 108);
			this.LstTodos.TabIndex = 9;
			// 
			// BtnLiberar
			// 
			this.BtnLiberar.Location = new System.Drawing.Point(149, 185);
			this.BtnLiberar.Name = "BtnLiberar";
			this.BtnLiberar.Size = new System.Drawing.Size(120, 23);
			this.BtnLiberar.TabIndex = 10;
			this.BtnLiberar.Text = "Liberar";
			this.BtnLiberar.UseVisualStyleBackColor = true;
			this.BtnLiberar.Click += new System.EventHandler(this.BtnLiberarClick);
			// 
			// BtnVincular
			// 
			this.BtnVincular.Location = new System.Drawing.Point(285, 185);
			this.BtnVincular.Name = "BtnVincular";
			this.BtnVincular.Size = new System.Drawing.Size(120, 23);
			this.BtnVincular.TabIndex = 11;
			this.BtnVincular.Text = "Vincular";
			this.BtnVincular.UseVisualStyleBackColor = true;
			this.BtnVincular.Click += new System.EventHandler(this.BtnVincularClick);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(13, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(120, 23);
			this.label5.TabIndex = 12;
			this.label5.Text = "Selecione a empresa";
			// 
			// TxtEmpresa
			// 
			this.TxtEmpresa.Location = new System.Drawing.Point(149, 16);
			this.TxtEmpresa.Name = "TxtEmpresa";
			this.TxtEmpresa.Size = new System.Drawing.Size(59, 20);
			this.TxtEmpresa.TabIndex = 13;
			// 
			// TxtNomeEmp
			// 
			this.TxtNomeEmp.Location = new System.Drawing.Point(225, 16);
			this.TxtNomeEmp.Name = "TxtNomeEmp";
			this.TxtNomeEmp.ReadOnly = true;
			this.TxtNomeEmp.Size = new System.Drawing.Size(180, 20);
			this.TxtNomeEmp.TabIndex = 14;
			// 
			// dlgQuiosque
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(430, 282);
			this.Controls.Add(this.TxtNomeEmp);
			this.Controls.Add(this.TxtEmpresa);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.BtnVincular);
			this.Controls.Add(this.BtnLiberar);
			this.Controls.Add(this.LstTodos);
			this.Controls.Add(this.LstVend);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.BtnAdicionar);
			this.Controls.Add(this.TxtNovo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.BtnRemover);
			this.Controls.Add(this.LstQ);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgQuiosque";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Manutenção de Quiosques";
			this.Load += new System.EventHandler(this.DlgQuiosqueLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtNomeEmp;
		public System.Windows.Forms.TextBox TxtEmpresa;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.Button BtnVincular;
		public System.Windows.Forms.Button BtnLiberar;
		public System.Windows.Forms.ListBox LstTodos;
		public System.Windows.Forms.ListBox LstVend;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Button BtnAdicionar;
		public System.Windows.Forms.TextBox TxtNovo;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Button BtnRemover;
		public System.Windows.Forms.ListBox LstQ;
		public System.Windows.Forms.Label label1;
	}
}

