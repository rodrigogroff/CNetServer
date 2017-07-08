using System.Windows.Forms;

namespace Client 
{
	partial class dlgFatRecManual : Form
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
			this.TxtCodigo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.CboTipo = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtTotal = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtVrPago = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.TxtVrDesc = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.TxtJuros = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.TxtVrDevido = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.TxtVrAbatimento = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.TxtMotivo = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TxtCodigo
			// 
			this.TxtCodigo.Location = new System.Drawing.Point(94, 50);
			this.TxtCodigo.Name = "TxtCodigo";
			this.TxtCodigo.Size = new System.Drawing.Size(154, 20);
			this.TxtCodigo.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(15, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "Código";
			// 
			// CboTipo
			// 
			this.CboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboTipo.FormattingEnabled = true;
			this.CboTipo.Items.AddRange(new object[] {
									"Empresa ou Associação",
									"Loja"});
			this.CboTipo.Location = new System.Drawing.Point(94, 17);
			this.CboTipo.Name = "CboTipo";
			this.CboTipo.Size = new System.Drawing.Size(154, 21);
			this.CboTipo.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(15, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Tipo";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(15, 85);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 8;
			this.label3.Text = "Valor Total";
			// 
			// TxtTotal
			// 
			this.TxtTotal.Location = new System.Drawing.Point(94, 82);
			this.TxtTotal.Name = "TxtTotal";
			this.TxtTotal.ReadOnly = true;
			this.TxtTotal.Size = new System.Drawing.Size(154, 20);
			this.TxtTotal.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(15, 117);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 10;
			this.label4.Text = "Valor Pago";
			// 
			// TxtVrPago
			// 
			this.TxtVrPago.Location = new System.Drawing.Point(94, 114);
			this.TxtVrPago.Name = "TxtVrPago";
			this.TxtVrPago.Size = new System.Drawing.Size(154, 20);
			this.TxtVrPago.TabIndex = 11;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(15, 320);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 12;
			this.label5.Text = "Vr. Parcela";
			// 
			// TxtVrDesc
			// 
			this.TxtVrDesc.Location = new System.Drawing.Point(94, 146);
			this.TxtVrDesc.Name = "TxtVrDesc";
			this.TxtVrDesc.ReadOnly = true;
			this.TxtVrDesc.Size = new System.Drawing.Size(154, 20);
			this.TxtVrDesc.TabIndex = 13;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(15, 224);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 14;
			this.label6.Text = "Juros";
			// 
			// TxtJuros
			// 
			this.TxtJuros.Location = new System.Drawing.Point(94, 221);
			this.TxtJuros.Name = "TxtJuros";
			this.TxtJuros.Size = new System.Drawing.Size(154, 20);
			this.TxtJuros.TabIndex = 15;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(15, 149);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 16;
			this.label7.Text = "Valor devido";
			// 
			// TxtVrDevido
			// 
			this.TxtVrDevido.Location = new System.Drawing.Point(94, 317);
			this.TxtVrDevido.Name = "TxtVrDevido";
			this.TxtVrDevido.ReadOnly = true;
			this.TxtVrDevido.Size = new System.Drawing.Size(154, 20);
			this.TxtVrDevido.TabIndex = 17;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(15, 256);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 23);
			this.label8.TabIndex = 18;
			this.label8.Text = "Abatimento";
			// 
			// TxtVrAbatimento
			// 
			this.TxtVrAbatimento.Location = new System.Drawing.Point(94, 253);
			this.TxtVrAbatimento.Name = "TxtVrAbatimento";
			this.TxtVrAbatimento.Size = new System.Drawing.Size(154, 20);
			this.TxtVrAbatimento.TabIndex = 19;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(15, 288);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 23);
			this.label9.TabIndex = 20;
			this.label9.Text = "Motivo";
			// 
			// TxtMotivo
			// 
			this.TxtMotivo.Location = new System.Drawing.Point(94, 285);
			this.TxtMotivo.Name = "TxtMotivo";
			this.TxtMotivo.Size = new System.Drawing.Size(154, 20);
			this.TxtMotivo.TabIndex = 21;
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(15, 195);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(233, 23);
			this.label10.TabIndex = 22;
			this.label10.Text = "Valor a ser lançado na próxima parcela";
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(173, 359);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 23;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// dlgFatRecManual
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(270, 394);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.TxtMotivo);
			this.Controls.Add(this.TxtVrAbatimento);
			this.Controls.Add(this.TxtVrDevido);
			this.Controls.Add(this.TxtJuros);
			this.Controls.Add(this.TxtVrDesc);
			this.Controls.Add(this.TxtVrPago);
			this.Controls.Add(this.TxtTotal);
			this.Controls.Add(this.TxtCodigo);
			this.Controls.Add(this.CboTipo);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgFatRecManual";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Recebimento Manual";
			this.Load += new System.EventHandler(this.DlgFatRecManualLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public System.Windows.Forms.TextBox TxtVrDevido;
		public System.Windows.Forms.TextBox TxtVrAbatimento;
		private System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.Label label10;
		public System.Windows.Forms.TextBox TxtMotivo;
		public System.Windows.Forms.Label label9;
		public System.Windows.Forms.Label label8;
		public System.Windows.Forms.Label label7;
		public System.Windows.Forms.TextBox TxtJuros;
		public System.Windows.Forms.Label label6;
		public System.Windows.Forms.TextBox TxtVrDesc;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.TextBox TxtVrPago;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox TxtTotal;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.ComboBox CboTipo;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox TxtCodigo;
	}
}

