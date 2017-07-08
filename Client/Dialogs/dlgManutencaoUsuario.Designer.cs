using System.Windows.Forms;

namespace Client 
{
	partial class dlgManutencaoUsuario : Form
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
			this.TxtEmpresa = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.LstUsuarios = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.label3 = new System.Windows.Forms.Label();
			this.CboAcao = new System.Windows.Forms.ComboBox();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(20, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Empresa";
			// 
			// TxtEmpresa
			// 
			this.TxtEmpresa.Location = new System.Drawing.Point(85, 22);
			this.TxtEmpresa.Name = "TxtEmpresa";
			this.TxtEmpresa.Size = new System.Drawing.Size(100, 20);
			this.TxtEmpresa.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(20, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Usuários";
			// 
			// LstUsuarios
			// 
			this.LstUsuarios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader4,
									this.columnHeader3});
			this.LstUsuarios.FullRowSelect = true;
			this.LstUsuarios.HideSelection = false;
			this.LstUsuarios.Location = new System.Drawing.Point(20, 70);
			this.LstUsuarios.MultiSelect = false;
			this.LstUsuarios.Name = "LstUsuarios";
			this.LstUsuarios.Size = new System.Drawing.Size(409, 146);
			this.LstUsuarios.TabIndex = 3;
			this.LstUsuarios.UseCompatibleStateImageBehavior = false;
			this.LstUsuarios.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Nome";
			this.columnHeader1.Width = 90;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Bloqueado";
			this.columnHeader2.Width = 90;
			// 
			// columnHeader4
			// 
			this.columnHeader4.DisplayIndex = 3;
			this.columnHeader4.Text = "Nível";
			this.columnHeader4.Width = 110;
			// 
			// columnHeader3
			// 
			this.columnHeader3.DisplayIndex = 2;
			this.columnHeader3.Text = "Empresa";
			this.columnHeader3.Width = 90;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(68, 248);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Ação";
			// 
			// CboAcao
			// 
			this.CboAcao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboAcao.FormattingEnabled = true;
			this.CboAcao.Items.AddRange(new object[] {
									"Bloquear",
									"Desbloquear",
									"Solicitar troca de senha",
									"Remover usuário",
									"Limpeza de senha"});
			this.CboAcao.Location = new System.Drawing.Point(110, 245);
			this.CboAcao.Name = "CboAcao";
			this.CboAcao.Size = new System.Drawing.Size(182, 21);
			this.CboAcao.TabIndex = 5;
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(307, 245);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 6;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// dlgManutencaoUsuario
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(450, 294);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.CboAcao);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.LstUsuarios);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TxtEmpresa);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgManutencaoUsuario";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Manutenção de usuários";
			this.Load += new System.EventHandler(this.DlgManutencaoUsuarioLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.ColumnHeader columnHeader4;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.ComboBox CboAcao;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.ColumnHeader columnHeader3;
		public System.Windows.Forms.ColumnHeader columnHeader2;
		public System.Windows.Forms.ColumnHeader columnHeader1;
		public System.Windows.Forms.ListView LstUsuarios;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox TxtEmpresa;
		public System.Windows.Forms.Label label1;
	}
}

