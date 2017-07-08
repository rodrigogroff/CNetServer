using System.Windows.Forms;

namespace Client 
{
	partial class dlgAgendamento : Form
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
			this.LstTrans = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.BtnAdicionar = new System.Windows.Forms.Button();
			this.BtnRemover = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// LstTrans
			// 
			this.LstTrans.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3});
			this.LstTrans.FullRowSelect = true;
			this.LstTrans.HideSelection = false;
			this.LstTrans.Location = new System.Drawing.Point(21, 26);
			this.LstTrans.MultiSelect = false;
			this.LstTrans.Name = "LstTrans";
			this.LstTrans.Size = new System.Drawing.Size(514, 205);
			this.LstTrans.TabIndex = 8;
			this.LstTrans.UseCompatibleStateImageBehavior = false;
			this.LstTrans.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Empresa";
			this.columnHeader1.Width = 180;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Atividade";
			this.columnHeader2.Width = 120;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Informações";
			this.columnHeader3.Width = 180;
			// 
			// BtnAdicionar
			// 
			this.BtnAdicionar.Location = new System.Drawing.Point(21, 247);
			this.BtnAdicionar.Name = "BtnAdicionar";
			this.BtnAdicionar.Size = new System.Drawing.Size(75, 23);
			this.BtnAdicionar.TabIndex = 9;
			this.BtnAdicionar.Text = "Adicionar";
			this.BtnAdicionar.UseVisualStyleBackColor = true;
			this.BtnAdicionar.Click += new System.EventHandler(this.BtnAdicionarClick);
			// 
			// BtnRemover
			// 
			this.BtnRemover.Location = new System.Drawing.Point(460, 247);
			this.BtnRemover.Name = "BtnRemover";
			this.BtnRemover.Size = new System.Drawing.Size(75, 23);
			this.BtnRemover.TabIndex = 11;
			this.BtnRemover.Text = "Remover";
			this.BtnRemover.UseVisualStyleBackColor = true;
			this.BtnRemover.Click += new System.EventHandler(this.BtnRemoverClick);
			// 
			// dlgAgendamento
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(559, 287);
			this.Controls.Add(this.BtnRemover);
			this.Controls.Add(this.BtnAdicionar);
			this.Controls.Add(this.LstTrans);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgAgendamento";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Agendamento de atividades das empresas";
			this.Load += new System.EventHandler(this.DlgAgendamentoLoad);
			this.Shown += new System.EventHandler(this.DlgAgendamentoShown);
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.Button BtnRemover;
		public System.Windows.Forms.Button BtnAdicionar;
		public System.Windows.Forms.ColumnHeader columnHeader3;
		public System.Windows.Forms.ColumnHeader columnHeader2;
		public System.Windows.Forms.ColumnHeader columnHeader1;
		public System.Windows.Forms.ListView LstTrans;
	}
}

