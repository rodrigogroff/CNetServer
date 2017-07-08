using System.Windows.Forms;

namespace Client 
{
	partial class dlgNovaLoja : Form
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
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.TxtContaDeb = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.TxtContato = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.TxtFax = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.TxtTelefone = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.TxtCEP = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.TxtEstado = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.TxtCidade = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.TxtEndereco = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.TxtCNPJ = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtSocial = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtLoja = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtInscEst = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.TxtEnderecoInst = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.TxtObs = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.CheckIsento = new System.Windows.Forms.CheckBox();
			this.TxtBancoFat = new System.Windows.Forms.TextBox();
			this.CboTipoCob = new System.Windows.Forms.ComboBox();
			this.TxtDiaVenc = new System.Windows.Forms.TextBox();
			this.TxtPeriodoFat = new System.Windows.Forms.TextBox();
			this.TxtFranquia = new System.Windows.Forms.TextBox();
			this.TxtVrMinimo = new System.Windows.Forms.TextBox();
			this.TxtVrTransacao = new System.Windows.Forms.TextBox();
			this.TxtPctValor = new System.Windows.Forms.TextBox();
			this.TxtMensalidade = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.TxtSenhaWeb = new System.Windows.Forms.TextBox();
			this.LblAcesso = new System.Windows.Forms.Label();
			this.BtnBloq = new System.Windows.Forms.Button();
			this.BtnDesbloq = new System.Windows.Forms.Button();
			this.LblSit = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BtnConfirmar.Location = new System.Drawing.Point(364, 493);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(89, 23);
			this.BtnConfirmar.TabIndex = 26;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// TxtContaDeb
			// 
			this.TxtContaDeb.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtContaDeb.Location = new System.Drawing.Point(331, 120);
			this.TxtContaDeb.Name = "TxtContaDeb";
			this.TxtContaDeb.Size = new System.Drawing.Size(110, 20);
			this.TxtContaDeb.TabIndex = 24;
			// 
			// label13
			// 
			this.label13.BackColor = System.Drawing.Color.Transparent;
			this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label13.Location = new System.Drawing.Point(230, 123);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(100, 23);
			this.label13.TabIndex = 57;
			this.label13.Text = "Conta Débito";
			// 
			// TxtContato
			// 
			this.TxtContato.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtContato.Location = new System.Drawing.Point(331, 180);
			this.TxtContato.Name = "TxtContato";
			this.TxtContato.Size = new System.Drawing.Size(110, 20);
			this.TxtContato.TabIndex = 12;
			// 
			// label11
			// 
			this.label11.BackColor = System.Drawing.Color.Transparent;
			this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label11.Location = new System.Drawing.Point(230, 183);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(100, 23);
			this.label11.TabIndex = 53;
			this.label11.Text = "Contato";
			// 
			// TxtFax
			// 
			this.TxtFax.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtFax.Location = new System.Drawing.Point(106, 203);
			this.TxtFax.Name = "TxtFax";
			this.TxtFax.Size = new System.Drawing.Size(89, 20);
			this.TxtFax.TabIndex = 13;
			// 
			// label10
			// 
			this.label10.BackColor = System.Drawing.Color.Transparent;
			this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label10.Location = new System.Drawing.Point(12, 206);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 23);
			this.label10.TabIndex = 51;
			this.label10.Text = "Fax";
			// 
			// TxtTelefone
			// 
			this.TxtTelefone.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtTelefone.Location = new System.Drawing.Point(331, 157);
			this.TxtTelefone.Name = "TxtTelefone";
			this.TxtTelefone.Size = new System.Drawing.Size(110, 20);
			this.TxtTelefone.TabIndex = 10;
			// 
			// label9
			// 
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label9.Location = new System.Drawing.Point(230, 160);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 23);
			this.label9.TabIndex = 49;
			this.label9.Text = "Telefone";
			// 
			// TxtCEP
			// 
			this.TxtCEP.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtCEP.Location = new System.Drawing.Point(106, 180);
			this.TxtCEP.Name = "TxtCEP";
			this.TxtCEP.Size = new System.Drawing.Size(89, 20);
			this.TxtCEP.TabIndex = 11;
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label8.Location = new System.Drawing.Point(12, 183);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 23);
			this.label8.TabIndex = 47;
			this.label8.Text = "CEP";
			// 
			// TxtEstado
			// 
			this.TxtEstado.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtEstado.Location = new System.Drawing.Point(331, 134);
			this.TxtEstado.Name = "TxtEstado";
			this.TxtEstado.Size = new System.Drawing.Size(110, 20);
			this.TxtEstado.TabIndex = 8;
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label7.Location = new System.Drawing.Point(230, 138);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 45;
			this.label7.Text = "Estado";
			// 
			// TxtCidade
			// 
			this.TxtCidade.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtCidade.Location = new System.Drawing.Point(106, 157);
			this.TxtCidade.Name = "TxtCidade";
			this.TxtCidade.Size = new System.Drawing.Size(89, 20);
			this.TxtCidade.TabIndex = 9;
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label6.Location = new System.Drawing.Point(12, 160);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 43;
			this.label6.Text = "Cidade";
			// 
			// TxtEndereco
			// 
			this.TxtEndereco.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtEndereco.Location = new System.Drawing.Point(106, 88);
			this.TxtEndereco.Name = "TxtEndereco";
			this.TxtEndereco.Size = new System.Drawing.Size(335, 20);
			this.TxtEndereco.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label5.Location = new System.Drawing.Point(12, 91);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 41;
			this.label5.Text = "Endereço";
			// 
			// TxtCNPJ
			// 
			this.TxtCNPJ.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtCNPJ.Location = new System.Drawing.Point(282, 19);
			this.TxtCNPJ.Name = "TxtCNPJ";
			this.TxtCNPJ.Size = new System.Drawing.Size(159, 20);
			this.TxtCNPJ.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(230, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 39;
			this.label4.Text = "CNPJ";
			// 
			// TxtSocial
			// 
			this.TxtSocial.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtSocial.Location = new System.Drawing.Point(106, 65);
			this.TxtSocial.Name = "TxtSocial";
			this.TxtSocial.Size = new System.Drawing.Size(335, 20);
			this.TxtSocial.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(12, 68);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 37;
			this.label3.Text = "Razão Social";
			// 
			// TxtLoja
			// 
			this.TxtLoja.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtLoja.Location = new System.Drawing.Point(106, 19);
			this.TxtLoja.Name = "TxtLoja";
			this.TxtLoja.Size = new System.Drawing.Size(89, 20);
			this.TxtLoja.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(12, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 33;
			this.label1.Text = "Código";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(12, 138);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 66;
			this.label2.Text = "Insc. Estadual";
			// 
			// TxtInscEst
			// 
			this.TxtInscEst.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtInscEst.Location = new System.Drawing.Point(106, 135);
			this.TxtInscEst.Name = "TxtInscEst";
			this.TxtInscEst.Size = new System.Drawing.Size(89, 20);
			this.TxtInscEst.TabIndex = 7;
			// 
			// label18
			// 
			this.label18.BackColor = System.Drawing.Color.Transparent;
			this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label18.Location = new System.Drawing.Point(12, 114);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(100, 23);
			this.label18.TabIndex = 70;
			this.label18.Text = "Endereço Inst.";
			// 
			// TxtEnderecoInst
			// 
			this.TxtEnderecoInst.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtEnderecoInst.Location = new System.Drawing.Point(106, 111);
			this.TxtEnderecoInst.Name = "TxtEnderecoInst";
			this.TxtEnderecoInst.Size = new System.Drawing.Size(335, 20);
			this.TxtEnderecoInst.TabIndex = 6;
			// 
			// label14
			// 
			this.label14.BackColor = System.Drawing.Color.Transparent;
			this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label14.Location = new System.Drawing.Point(12, 231);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(100, 23);
			this.label14.TabIndex = 72;
			this.label14.Text = "Observação";
			// 
			// TxtObs
			// 
			this.TxtObs.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtObs.Location = new System.Drawing.Point(106, 226);
			this.TxtObs.Name = "TxtObs";
			this.TxtObs.Size = new System.Drawing.Size(335, 20);
			this.TxtObs.TabIndex = 14;
			// 
			// label15
			// 
			this.label15.BackColor = System.Drawing.Color.Transparent;
			this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label15.Location = new System.Drawing.Point(12, 45);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(100, 23);
			this.label15.TabIndex = 73;
			this.label15.Text = "Nome";
			// 
			// TxtNome
			// 
			this.TxtNome.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtNome.Location = new System.Drawing.Point(106, 42);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.Size = new System.Drawing.Size(335, 20);
			this.TxtNome.TabIndex = 3;
			// 
			// label19
			// 
			this.label19.BackColor = System.Drawing.Color.Transparent;
			this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label19.Location = new System.Drawing.Point(12, 28);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(100, 23);
			this.label19.TabIndex = 77;
			this.label19.Text = "Mensalidade";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.CheckIsento);
			this.groupBox1.Controls.Add(this.TxtBancoFat);
			this.groupBox1.Controls.Add(this.CboTipoCob);
			this.groupBox1.Controls.Add(this.TxtDiaVenc);
			this.groupBox1.Controls.Add(this.TxtPeriodoFat);
			this.groupBox1.Controls.Add(this.TxtFranquia);
			this.groupBox1.Controls.Add(this.TxtVrMinimo);
			this.groupBox1.Controls.Add(this.TxtVrTransacao);
			this.groupBox1.Controls.Add(this.TxtPctValor);
			this.groupBox1.Controls.Add(this.TxtContaDeb);
			this.groupBox1.Controls.Add(this.TxtMensalidade);
			this.groupBox1.Controls.Add(this.label27);
			this.groupBox1.Controls.Add(this.label26);
			this.groupBox1.Controls.Add(this.label25);
			this.groupBox1.Controls.Add(this.label24);
			this.groupBox1.Controls.Add(this.label23);
			this.groupBox1.Controls.Add(this.label22);
			this.groupBox1.Controls.Add(this.label21);
			this.groupBox1.Controls.Add(this.label20);
			this.groupBox1.Controls.Add(this.label19);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Location = new System.Drawing.Point(12, 293);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(471, 183);
			this.groupBox1.TabIndex = 78;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Faturamento";
			// 
			// CheckIsento
			// 
			this.CheckIsento.Location = new System.Drawing.Point(331, 149);
			this.CheckIsento.Name = "CheckIsento";
			this.CheckIsento.Size = new System.Drawing.Size(108, 24);
			this.CheckIsento.TabIndex = 25;
			this.CheckIsento.Text = "Isento de fatura";
			this.CheckIsento.UseVisualStyleBackColor = true;
			// 
			// TxtBancoFat
			// 
			this.TxtBancoFat.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtBancoFat.Location = new System.Drawing.Point(331, 97);
			this.TxtBancoFat.Name = "TxtBancoFat";
			this.TxtBancoFat.Size = new System.Drawing.Size(110, 20);
			this.TxtBancoFat.TabIndex = 23;
			// 
			// CboTipoCob
			// 
			this.CboTipoCob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboTipoCob.FormattingEnabled = true;
			this.CboTipoCob.Items.AddRange(new object[] {
									"DOC",
									"Débito em Conta"});
			this.CboTipoCob.Location = new System.Drawing.Point(331, 74);
			this.CboTipoCob.Name = "CboTipoCob";
			this.CboTipoCob.Size = new System.Drawing.Size(110, 21);
			this.CboTipoCob.TabIndex = 22;
			// 
			// TxtDiaVenc
			// 
			this.TxtDiaVenc.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtDiaVenc.Location = new System.Drawing.Point(331, 51);
			this.TxtDiaVenc.Name = "TxtDiaVenc";
			this.TxtDiaVenc.Size = new System.Drawing.Size(110, 20);
			this.TxtDiaVenc.TabIndex = 21;
			// 
			// TxtPeriodoFat
			// 
			this.TxtPeriodoFat.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtPeriodoFat.Location = new System.Drawing.Point(331, 28);
			this.TxtPeriodoFat.Name = "TxtPeriodoFat";
			this.TxtPeriodoFat.Size = new System.Drawing.Size(110, 20);
			this.TxtPeriodoFat.TabIndex = 20;
			// 
			// TxtFranquia
			// 
			this.TxtFranquia.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtFranquia.Location = new System.Drawing.Point(107, 120);
			this.TxtFranquia.Name = "TxtFranquia";
			this.TxtFranquia.Size = new System.Drawing.Size(88, 20);
			this.TxtFranquia.TabIndex = 19;
			// 
			// TxtVrMinimo
			// 
			this.TxtVrMinimo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtVrMinimo.Location = new System.Drawing.Point(107, 97);
			this.TxtVrMinimo.Name = "TxtVrMinimo";
			this.TxtVrMinimo.Size = new System.Drawing.Size(88, 20);
			this.TxtVrMinimo.TabIndex = 18;
			// 
			// TxtVrTransacao
			// 
			this.TxtVrTransacao.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtVrTransacao.Location = new System.Drawing.Point(107, 74);
			this.TxtVrTransacao.Name = "TxtVrTransacao";
			this.TxtVrTransacao.Size = new System.Drawing.Size(88, 20);
			this.TxtVrTransacao.TabIndex = 17;
			// 
			// TxtPctValor
			// 
			this.TxtPctValor.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtPctValor.Location = new System.Drawing.Point(107, 51);
			this.TxtPctValor.Name = "TxtPctValor";
			this.TxtPctValor.Size = new System.Drawing.Size(88, 20);
			this.TxtPctValor.TabIndex = 16;
			// 
			// TxtMensalidade
			// 
			this.TxtMensalidade.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtMensalidade.Location = new System.Drawing.Point(107, 28);
			this.TxtMensalidade.Name = "TxtMensalidade";
			this.TxtMensalidade.Size = new System.Drawing.Size(88, 20);
			this.TxtMensalidade.TabIndex = 15;
			// 
			// label27
			// 
			this.label27.BackColor = System.Drawing.Color.Transparent;
			this.label27.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label27.Location = new System.Drawing.Point(230, 100);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(100, 23);
			this.label27.TabIndex = 85;
			this.label27.Text = "Banco Fatura";
			// 
			// label26
			// 
			this.label26.BackColor = System.Drawing.Color.Transparent;
			this.label26.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label26.Location = new System.Drawing.Point(230, 77);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(100, 23);
			this.label26.TabIndex = 84;
			this.label26.Text = "Tipo Cobrança";
			// 
			// label25
			// 
			this.label25.BackColor = System.Drawing.Color.Transparent;
			this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label25.Location = new System.Drawing.Point(230, 54);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(100, 23);
			this.label25.TabIndex = 83;
			this.label25.Text = "Dia Venc.";
			// 
			// label24
			// 
			this.label24.BackColor = System.Drawing.Color.Transparent;
			this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label24.Location = new System.Drawing.Point(230, 31);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(100, 23);
			this.label24.TabIndex = 82;
			this.label24.Text = "Período Fat.";
			// 
			// label23
			// 
			this.label23.BackColor = System.Drawing.Color.Transparent;
			this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label23.Location = new System.Drawing.Point(12, 120);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(100, 23);
			this.label23.TabIndex = 81;
			this.label23.Text = "Franquia Trans.";
			// 
			// label22
			// 
			this.label22.BackColor = System.Drawing.Color.Transparent;
			this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label22.Location = new System.Drawing.Point(12, 97);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(100, 23);
			this.label22.TabIndex = 80;
			this.label22.Text = "Valor Mínimo";
			// 
			// label21
			// 
			this.label21.BackColor = System.Drawing.Color.Transparent;
			this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label21.Location = new System.Drawing.Point(12, 74);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(100, 23);
			this.label21.TabIndex = 79;
			this.label21.Text = "Valor Transação";
			// 
			// label20
			// 
			this.label20.BackColor = System.Drawing.Color.Transparent;
			this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label20.Location = new System.Drawing.Point(12, 51);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(100, 23);
			this.label20.TabIndex = 78;
			this.label20.Text = "Pct. Transação";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.TxtSenhaWeb);
			this.groupBox2.Controls.Add(this.TxtSocial);
			this.groupBox2.Controls.Add(this.TxtNome);
			this.groupBox2.Controls.Add(this.TxtLoja);
			this.groupBox2.Controls.Add(this.TxtObs);
			this.groupBox2.Controls.Add(this.TxtCNPJ);
			this.groupBox2.Controls.Add(this.TxtEnderecoInst);
			this.groupBox2.Controls.Add(this.TxtEndereco);
			this.groupBox2.Controls.Add(this.TxtInscEst);
			this.groupBox2.Controls.Add(this.TxtCidade);
			this.groupBox2.Controls.Add(this.TxtEstado);
			this.groupBox2.Controls.Add(this.TxtContato);
			this.groupBox2.Controls.Add(this.TxtCEP);
			this.groupBox2.Controls.Add(this.TxtFax);
			this.groupBox2.Controls.Add(this.TxtTelefone);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.label15);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label14);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label18);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.LblAcesso);
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(471, 263);
			this.groupBox2.TabIndex = 79;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Identificação";
			// 
			// TxtSenhaWeb
			// 
			this.TxtSenhaWeb.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TxtSenhaWeb.Location = new System.Drawing.Point(331, 203);
			this.TxtSenhaWeb.Name = "TxtSenhaWeb";
			this.TxtSenhaWeb.Size = new System.Drawing.Size(110, 20);
			this.TxtSenhaWeb.TabIndex = 75;
			// 
			// LblAcesso
			// 
			this.LblAcesso.BackColor = System.Drawing.Color.Transparent;
			this.LblAcesso.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LblAcesso.Location = new System.Drawing.Point(230, 206);
			this.LblAcesso.Name = "LblAcesso";
			this.LblAcesso.Size = new System.Drawing.Size(100, 23);
			this.LblAcesso.TabIndex = 74;
			this.LblAcesso.Text = "Acesso internet";
			// 
			// BtnBloq
			// 
			this.BtnBloq.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BtnBloq.Location = new System.Drawing.Point(157, 493);
			this.BtnBloq.Name = "BtnBloq";
			this.BtnBloq.Size = new System.Drawing.Size(89, 23);
			this.BtnBloq.TabIndex = 80;
			this.BtnBloq.Text = "Bloquear";
			this.BtnBloq.UseVisualStyleBackColor = true;
			this.BtnBloq.Click += new System.EventHandler(this.BtnBloqClick);
			// 
			// BtnDesbloq
			// 
			this.BtnDesbloq.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BtnDesbloq.Location = new System.Drawing.Point(253, 493);
			this.BtnDesbloq.Name = "BtnDesbloq";
			this.BtnDesbloq.Size = new System.Drawing.Size(89, 23);
			this.BtnDesbloq.TabIndex = 81;
			this.BtnDesbloq.Text = "Desbloquear";
			this.BtnDesbloq.UseVisualStyleBackColor = true;
			this.BtnDesbloq.Click += new System.EventHandler(this.BtnDesbloqClick);
			// 
			// LblSit
			// 
			this.LblSit.BackColor = System.Drawing.Color.Transparent;
			this.LblSit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LblSit.Location = new System.Drawing.Point(12, 498);
			this.LblSit.Name = "LblSit";
			this.LblSit.Size = new System.Drawing.Size(139, 23);
			this.LblSit.TabIndex = 86;
			// 
			// dlgNovaLoja
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(499, 554);
			this.Controls.Add(this.LblSit);
			this.Controls.Add(this.BtnDesbloq);
			this.Controls.Add(this.BtnBloq);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.BtnConfirmar);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgNovaLoja";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.DlgNovaLojaLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.Label LblAcesso;
		public System.Windows.Forms.TextBox TxtSenhaWeb;
		public System.Windows.Forms.Label LblSit;
		public System.Windows.Forms.Button BtnDesbloq;
		public System.Windows.Forms.Button BtnBloq;
		private System.Windows.Forms.GroupBox groupBox2;
		public System.Windows.Forms.CheckBox CheckIsento;
		public System.Windows.Forms.ComboBox CboTipoCob;
		public System.Windows.Forms.TextBox TxtMensalidade;
		public System.Windows.Forms.TextBox TxtBancoFat;
		public System.Windows.Forms.TextBox TxtPeriodoFat;
		public System.Windows.Forms.TextBox TxtDiaVenc;
		public System.Windows.Forms.TextBox TxtFranquia;
		public System.Windows.Forms.TextBox TxtVrTransacao;
		public System.Windows.Forms.TextBox TxtVrMinimo;
		public System.Windows.Forms.TextBox TxtPctValor;
		public System.Windows.Forms.Label label23;
		public System.Windows.Forms.Label label24;
		public System.Windows.Forms.Label label25;
		public System.Windows.Forms.Label label26;
		public System.Windows.Forms.Label label27;
		public System.Windows.Forms.Label label22;
		public System.Windows.Forms.Label label20;
		public System.Windows.Forms.Label label21;
		private System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.Label label19;
		public System.Windows.Forms.TextBox TxtLoja;
		public System.Windows.Forms.TextBox TxtContaDeb;
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.Label label15;
		public System.Windows.Forms.TextBox TxtObs;
		public System.Windows.Forms.Label label14;
		public System.Windows.Forms.TextBox TxtFax;
		public System.Windows.Forms.TextBox TxtContato;
		public System.Windows.Forms.TextBox TxtEnderecoInst;
		public System.Windows.Forms.Label label18;
		public System.Windows.Forms.TextBox TxtInscEst;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox TxtSocial;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox TxtCNPJ;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.TextBox TxtEndereco;
		public System.Windows.Forms.Label label6;
		public System.Windows.Forms.TextBox TxtCidade;
		public System.Windows.Forms.Label label7;
		public System.Windows.Forms.TextBox TxtEstado;
		public System.Windows.Forms.Label label8;
		public System.Windows.Forms.TextBox TxtCEP;
		public System.Windows.Forms.Label label9;
		public System.Windows.Forms.TextBox TxtTelefone;
		public System.Windows.Forms.Label label10;
		public System.Windows.Forms.Label label11;
		public System.Windows.Forms.Label label13;
		public System.Windows.Forms.Button BtnConfirmar;
	}
}

