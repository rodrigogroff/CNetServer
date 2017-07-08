using System.Windows.Forms;

namespace Client 
{
	partial class dlgMensagensEdu : Form
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
			this.LstMsg = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.label2 = new System.Windows.Forms.Label();
			this.txtMsg = new System.Windows.Forms.TextBox();
			this.TxtDt_Ini = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtDt_Fim = new System.Windows.Forms.TextBox();
			this.BtnNovo = new System.Windows.Forms.Button();
			this.BtnAtualizar = new System.Windows.Forms.Button();
			this.BtnRemover = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(132, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Lista de mensagens";
			// 
			// LstMsg
			// 
			this.LstMsg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2});
			this.LstMsg.FullRowSelect = true;
			this.LstMsg.HideSelection = false;
			this.LstMsg.Location = new System.Drawing.Point(16, 32);
			this.LstMsg.Name = "LstMsg";
			this.LstMsg.Size = new System.Drawing.Size(319, 161);
			this.LstMsg.TabIndex = 1;
			this.LstMsg.UseCompatibleStateImageBehavior = false;
			this.LstMsg.View = System.Windows.Forms.View.Details;
			this.LstMsg.DoubleClick += new System.EventHandler(this.LstMsgDoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Texto";
			this.columnHeader1.Width = 150;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Período";
			this.columnHeader2.Width = 145;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(351, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(132, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Conteúdo";
			// 
			// txtMsg
			// 
			this.txtMsg.Location = new System.Drawing.Point(351, 32);
			this.txtMsg.MaxLength = 800;
			this.txtMsg.Multiline = true;
			this.txtMsg.Name = "txtMsg";
			this.txtMsg.Size = new System.Drawing.Size(213, 112);
			this.txtMsg.TabIndex = 3;
			// 
			// TxtDt_Ini
			// 
			this.TxtDt_Ini.Location = new System.Drawing.Point(351, 173);
			this.TxtDt_Ini.Name = "TxtDt_Ini";
			this.TxtDt_Ini.Size = new System.Drawing.Size(100, 20);
			this.TxtDt_Ini.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(351, 157);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(132, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Data Inicio";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(464, 157);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(132, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Data Fim";
			// 
			// TxtDt_Fim
			// 
			this.TxtDt_Fim.Location = new System.Drawing.Point(464, 173);
			this.TxtDt_Fim.Name = "TxtDt_Fim";
			this.TxtDt_Fim.Size = new System.Drawing.Size(100, 20);
			this.TxtDt_Fim.TabIndex = 7;
			// 
			// BtnNovo
			// 
			this.BtnNovo.Location = new System.Drawing.Point(464, 205);
			this.BtnNovo.Name = "BtnNovo";
			this.BtnNovo.Size = new System.Drawing.Size(100, 23);
			this.BtnNovo.TabIndex = 8;
			this.BtnNovo.Text = "Nova Mensagem";
			this.BtnNovo.UseVisualStyleBackColor = true;
			this.BtnNovo.Click += new System.EventHandler(this.BtnNovoClick);
			// 
			// BtnAtualizar
			// 
			this.BtnAtualizar.Location = new System.Drawing.Point(351, 205);
			this.BtnAtualizar.Name = "BtnAtualizar";
			this.BtnAtualizar.Size = new System.Drawing.Size(100, 23);
			this.BtnAtualizar.TabIndex = 9;
			this.BtnAtualizar.Text = "Atualizar";
			this.BtnAtualizar.UseVisualStyleBackColor = true;
			this.BtnAtualizar.Click += new System.EventHandler(this.BtnAtualizarClick);
			// 
			// BtnRemover
			// 
			this.BtnRemover.Location = new System.Drawing.Point(16, 205);
			this.BtnRemover.Name = "BtnRemover";
			this.BtnRemover.Size = new System.Drawing.Size(100, 23);
			this.BtnRemover.TabIndex = 10;
			this.BtnRemover.Text = "Remover";
			this.BtnRemover.UseVisualStyleBackColor = true;
			this.BtnRemover.Click += new System.EventHandler(this.BtnRemoverClick);
			// 
			// dlgMensagensEdu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(593, 249);
			this.Controls.Add(this.BtnRemover);
			this.Controls.Add(this.BtnAtualizar);
			this.Controls.Add(this.BtnNovo);
			this.Controls.Add(this.TxtDt_Fim);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.TxtDt_Ini);
			this.Controls.Add(this.txtMsg);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.LstMsg);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgMensagensEdu";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Mensagens aos pais e alunos";
			this.Load += new System.EventHandler(this.dlgMensagensEduLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.Button BtnRemover;
		public System.Windows.Forms.TextBox txtMsg;
		public System.Windows.Forms.ListView LstMsg;
		public System.Windows.Forms.Button BtnAtualizar;
		public System.Windows.Forms.Button BtnNovo;
		public System.Windows.Forms.TextBox TxtDt_Fim;
		public System.Windows.Forms.TextBox TxtDt_Ini;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.ColumnHeader columnHeader2;
		public System.Windows.Forms.ColumnHeader columnHeader1;
		public System.Windows.Forms.Label label1;
	}
}

