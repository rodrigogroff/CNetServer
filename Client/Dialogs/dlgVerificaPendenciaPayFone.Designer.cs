using System.Windows.Forms;

namespace Client 
{
	partial class dlgVerificaPendenciaPayFone : Form
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
			this.TxtTelefone = new System.Windows.Forms.TextBox();
			this.LstPend = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.BtnConfirma = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(13, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Telefone";
			// 
			// TxtTelefone
			// 
			this.TxtTelefone.Location = new System.Drawing.Point(94, 14);
			this.TxtTelefone.Name = "TxtTelefone";
			this.TxtTelefone.Size = new System.Drawing.Size(117, 20);
			this.TxtTelefone.TabIndex = 1;
			// 
			// LstPend
			// 
			this.LstPend.Font = new System.Drawing.Font("Lucida Console", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LstPend.FormattingEnabled = true;
			this.LstPend.ItemHeight = 9;
			this.LstPend.Location = new System.Drawing.Point(94, 43);
			this.LstPend.Name = "LstPend";
			this.LstPend.Size = new System.Drawing.Size(229, 85);
			this.LstPend.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(13, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Pendência";
			// 
			// BtnConfirma
			// 
			this.BtnConfirma.Location = new System.Drawing.Point(248, 12);
			this.BtnConfirma.Name = "BtnConfirma";
			this.BtnConfirma.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirma.TabIndex = 4;
			this.BtnConfirma.Text = "Consulta";
			this.BtnConfirma.UseVisualStyleBackColor = true;
			this.BtnConfirma.Click += new System.EventHandler(this.BtnConfirmaClick);
			// 
			// dlgVerificaPendenciaPayFone
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(335, 146);
			this.Controls.Add(this.BtnConfirma);
			this.Controls.Add(this.LstPend);
			this.Controls.Add(this.TxtTelefone);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgVerificaPendenciaPayFone";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Verifica Pendência PayFone";
			this.Load += new System.EventHandler(this.DlgVerificaPendenciaPayFoneLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.Button BtnConfirma;
		public System.Windows.Forms.ListBox LstPend;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox TxtTelefone;
		public System.Windows.Forms.Label label1;
	}
}

