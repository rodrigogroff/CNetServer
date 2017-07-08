using System.Windows.Forms;

namespace Client 
{
	partial class dlgPend : Form
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
			this.LstPend = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.BtnRemover = new System.Windows.Forms.Button();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// LstPend
			// 
			this.LstPend.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2});
			this.LstPend.FullRowSelect = true;
			this.LstPend.HideSelection = false;
			this.LstPend.Location = new System.Drawing.Point(12, 22);
			this.LstPend.Name = "LstPend";
			this.LstPend.Size = new System.Drawing.Size(252, 143);
			this.LstPend.TabIndex = 0;
			this.LstPend.UseCompatibleStateImageBehavior = false;
			this.LstPend.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Cartão";
			this.columnHeader1.Width = 120;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Valor";
			this.columnHeader2.Width = 90;
			// 
			// BtnRemover
			// 
			this.BtnRemover.Location = new System.Drawing.Point(12, 171);
			this.BtnRemover.Name = "BtnRemover";
			this.BtnRemover.Size = new System.Drawing.Size(75, 23);
			this.BtnRemover.TabIndex = 1;
			this.BtnRemover.Text = "Remover";
			this.BtnRemover.UseVisualStyleBackColor = true;
			this.BtnRemover.Click += new System.EventHandler(this.BtnRemoverClick);
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(189, 171);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 2;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// dlgPend
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(279, 209);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.BtnRemover);
			this.Controls.Add(this.LstPend);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgPend";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Pendências de vendas offline";
			this.Load += new System.EventHandler(this.dlgPendLoad);
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.Button BtnRemover;
		public System.Windows.Forms.ColumnHeader columnHeader2;
		public System.Windows.Forms.ColumnHeader columnHeader1;
		public System.Windows.Forms.ListView LstPend;
	}
}

