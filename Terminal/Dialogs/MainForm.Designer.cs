/*
 * Created by SharpDevelop.
 * User: rodrigo.groff
 * Date: 8/5/2006
 * Time: 16:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

 using System.Windows.Forms;
 
namespace Client
{
	partial class MainForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components = null;
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		
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
			this.LblVersion = new System.Windows.Forms.Label();
			this.BtnVendaOnline = new System.Windows.Forms.Button();
			this.BtnVendaDigitada = new System.Windows.Forms.Button();
			this.BtnPendencias = new System.Windows.Forms.Button();
			this.BtnCancelamento = new System.Windows.Forms.Button();
			this.BtnFinanceiro = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// LblVersion
			// 
			this.LblVersion.BackColor = System.Drawing.Color.Transparent;
			this.LblVersion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.LblVersion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.LblVersion.Location = new System.Drawing.Point(169, 115);
			this.LblVersion.Name = "LblVersion";
			this.LblVersion.Size = new System.Drawing.Size(126, 23);
			this.LblVersion.TabIndex = 1;
			this.LblVersion.Text = "Operação Offline";
			this.LblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// BtnVendaOnline
			// 
			this.BtnVendaOnline.Location = new System.Drawing.Point(18, 30);
			this.BtnVendaOnline.Name = "BtnVendaOnline";
			this.BtnVendaOnline.Size = new System.Drawing.Size(126, 23);
			this.BtnVendaOnline.TabIndex = 2;
			this.BtnVendaOnline.Text = "Venda Online";
			this.BtnVendaOnline.UseVisualStyleBackColor = true;
			this.BtnVendaOnline.Click += new System.EventHandler(this.BtnVendaOnlineClick);
			// 
			// BtnVendaDigitada
			// 
			this.BtnVendaDigitada.Location = new System.Drawing.Point(18, 69);
			this.BtnVendaDigitada.Name = "BtnVendaDigitada";
			this.BtnVendaDigitada.Size = new System.Drawing.Size(126, 23);
			this.BtnVendaDigitada.TabIndex = 3;
			this.BtnVendaDigitada.Text = "Venda Digitada";
			this.BtnVendaDigitada.UseVisualStyleBackColor = true;
			this.BtnVendaDigitada.Click += new System.EventHandler(this.BtnVendaDigitadaClick);
			// 
			// BtnPendencias
			// 
			this.BtnPendencias.Location = new System.Drawing.Point(169, 30);
			this.BtnPendencias.Name = "BtnPendencias";
			this.BtnPendencias.Size = new System.Drawing.Size(126, 23);
			this.BtnPendencias.TabIndex = 4;
			this.BtnPendencias.Text = "Pendências";
			this.BtnPendencias.UseVisualStyleBackColor = true;
			this.BtnPendencias.Click += new System.EventHandler(this.BtnPendenciasClick);
			// 
			// BtnCancelamento
			// 
			this.BtnCancelamento.Location = new System.Drawing.Point(169, 69);
			this.BtnCancelamento.Name = "BtnCancelamento";
			this.BtnCancelamento.Size = new System.Drawing.Size(126, 23);
			this.BtnCancelamento.TabIndex = 5;
			this.BtnCancelamento.Text = "Cancelamento";
			this.BtnCancelamento.UseVisualStyleBackColor = true;
			this.BtnCancelamento.Click += new System.EventHandler(this.BtnCancelamentoClick);
			// 
			// BtnFinanceiro
			// 
			this.BtnFinanceiro.Location = new System.Drawing.Point(18, 108);
			this.BtnFinanceiro.Name = "BtnFinanceiro";
			this.BtnFinanceiro.Size = new System.Drawing.Size(126, 23);
			this.BtnFinanceiro.TabIndex = 6;
			this.BtnFinanceiro.Text = "Financeiro";
			this.BtnFinanceiro.UseVisualStyleBackColor = true;
			this.BtnFinanceiro.Click += new System.EventHandler(this.BtnFinanceiroClick);
			// 
			// MainForm
			// 
			this.BackColor = System.Drawing.Color.DimGray;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(313, 165);
			this.Controls.Add(this.BtnFinanceiro);
			this.Controls.Add(this.BtnCancelamento);
			this.Controls.Add(this.BtnPendencias);
			this.Controls.Add(this.BtnVendaDigitada);
			this.Controls.Add(this.BtnVendaOnline);
			this.Controls.Add(this.LblVersion);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(0, 171);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Terminal Lojista";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.Button BtnFinanceiro;
		public System.Windows.Forms.Button BtnCancelamento;
		public System.Windows.Forms.Button BtnPendencias;
		public System.Windows.Forms.Button BtnVendaDigitada;
		public System.Windows.Forms.Button BtnVendaOnline;
		
		public System.Windows.Forms.Label LblVersion;
	}
}
