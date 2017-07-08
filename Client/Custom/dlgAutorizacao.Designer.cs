/*
 * Created by SharpDevelop.
 * User: rodrigog
 * Date: 23/05/2008
 * Time: 16:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Client
{
	partial class dlgAutorizacao
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
			this.TxtSenha = new System.Windows.Forms.TextBox();
			this.BtnAutorizar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(49, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Senha do Operador";
			// 
			// TxtSenha
			// 
			this.TxtSenha.Location = new System.Drawing.Point(41, 39);
			this.TxtSenha.MaxLength = 16;
			this.TxtSenha.Name = "TxtSenha";
			this.TxtSenha.PasswordChar = '*';
			this.TxtSenha.Size = new System.Drawing.Size(116, 20);
			this.TxtSenha.TabIndex = 4;
			// 
			// BtnAutorizar
			// 
			this.BtnAutorizar.Location = new System.Drawing.Point(62, 74);
			this.BtnAutorizar.Name = "BtnAutorizar";
			this.BtnAutorizar.Size = new System.Drawing.Size(75, 23);
			this.BtnAutorizar.TabIndex = 5;
			this.BtnAutorizar.Text = "Autorizar";
			this.BtnAutorizar.UseVisualStyleBackColor = true;
			this.BtnAutorizar.Click += new System.EventHandler(this.BtnAutorizarClick);
			// 
			// dlgAutorizacao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(198, 116);
			this.Controls.Add(this.BtnAutorizar);
			this.Controls.Add(this.TxtSenha);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgAutorizacao";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Autorização Requerida";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.Button BtnAutorizar;
		public System.Windows.Forms.TextBox TxtSenha;
		public System.Windows.Forms.Label label1;
	}
}
