using System.Windows.Forms;

namespace Client 
{
	partial class dlgNovaEmpresa : Form
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
            this.TxtFantasia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtSocial = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtCNPJ = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtEndereco = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtCidade = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtEstado = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtCEP = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtTelefone = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtCartoes = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtParcelas = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtFatura = new System.Windows.Forms.TextBox();
            this.BtnConfirmar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtHomepage = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.CheckIsento = new System.Windows.Forms.CheckBox();
            this.TxtContaDeb = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.TxtValCartAtv = new System.Windows.Forms.TextBox();
            this.TxtDiaVenc = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.CboCob = new System.Windows.Forms.ComboBox();
            this.TxtBancoCob = new System.Windows.Forms.TextBox();
            this.TxtFranqTrans = new System.Windows.Forms.TextBox();
            this.TxtVrMin = new System.Windows.Forms.TextBox();
            this.TxtVrTrans = new System.Windows.Forms.TextBox();
            this.TxtPctTrans = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.TxtTarif = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtObs = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.BtnBloq = new System.Windows.Forms.Button();
            this.BtnDesbloq = new System.Windows.Forms.Button();
            this.LblBloq = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // TxtEmpresa
            // 
            this.TxtEmpresa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtEmpresa.Location = new System.Drawing.Point(112, 27);
            this.TxtEmpresa.Name = "TxtEmpresa";
            this.TxtEmpresa.Size = new System.Drawing.Size(110, 20);
            this.TxtEmpresa.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome Fantasia";
            // 
            // TxtFantasia
            // 
            this.TxtFantasia.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtFantasia.Location = new System.Drawing.Point(112, 50);
            this.TxtFantasia.Name = "TxtFantasia";
            this.TxtFantasia.Size = new System.Drawing.Size(355, 20);
            this.TxtFantasia.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Razão Social";
            // 
            // TxtSocial
            // 
            this.TxtSocial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtSocial.Location = new System.Drawing.Point(112, 73);
            this.TxtSocial.Name = "TxtSocial";
            this.TxtSocial.Size = new System.Drawing.Size(355, 20);
            this.TxtSocial.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(244, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "CNPJ";
            // 
            // TxtCNPJ
            // 
            this.TxtCNPJ.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtCNPJ.Location = new System.Drawing.Point(309, 27);
            this.TxtCNPJ.Name = "TxtCNPJ";
            this.TxtCNPJ.Size = new System.Drawing.Size(158, 20);
            this.TxtCNPJ.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(12, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Endereço";
            // 
            // TxtEndereco
            // 
            this.TxtEndereco.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtEndereco.Location = new System.Drawing.Point(112, 96);
            this.TxtEndereco.Name = "TxtEndereco";
            this.TxtEndereco.Size = new System.Drawing.Size(355, 20);
            this.TxtEndereco.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(12, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Cidade";
            // 
            // TxtCidade
            // 
            this.TxtCidade.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtCidade.Location = new System.Drawing.Point(112, 119);
            this.TxtCidade.Name = "TxtCidade";
            this.TxtCidade.Size = new System.Drawing.Size(110, 20);
            this.TxtCidade.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(244, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Estado";
            // 
            // TxtEstado
            // 
            this.TxtEstado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtEstado.Location = new System.Drawing.Point(346, 119);
            this.TxtEstado.Name = "TxtEstado";
            this.TxtEstado.Size = new System.Drawing.Size(121, 20);
            this.TxtEstado.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(12, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "CEP";
            // 
            // TxtCEP
            // 
            this.TxtCEP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtCEP.Location = new System.Drawing.Point(112, 142);
            this.TxtCEP.Name = "TxtCEP";
            this.TxtCEP.Size = new System.Drawing.Size(110, 20);
            this.TxtCEP.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(244, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Telefone";
            // 
            // TxtTelefone
            // 
            this.TxtTelefone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtTelefone.Location = new System.Drawing.Point(346, 142);
            this.TxtTelefone.Name = "TxtTelefone";
            this.TxtTelefone.Size = new System.Drawing.Size(121, 20);
            this.TxtTelefone.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(12, 168);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 18;
            this.label10.Text = "Previsão Cartões";
            // 
            // TxtCartoes
            // 
            this.TxtCartoes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtCartoes.Location = new System.Drawing.Point(112, 165);
            this.TxtCartoes.Name = "TxtCartoes";
            this.TxtCartoes.Size = new System.Drawing.Size(110, 20);
            this.TxtCartoes.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(244, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Max. Parcelas";
            // 
            // TxtParcelas
            // 
            this.TxtParcelas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtParcelas.Location = new System.Drawing.Point(346, 165);
            this.TxtParcelas.Name = "TxtParcelas";
            this.TxtParcelas.Size = new System.Drawing.Size(121, 20);
            this.TxtParcelas.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(11, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Período Fat.";
            // 
            // TxtFatura
            // 
            this.TxtFatura.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtFatura.Location = new System.Drawing.Point(112, 142);
            this.TxtFatura.Name = "TxtFatura";
            this.TxtFatura.Size = new System.Drawing.Size(110, 20);
            this.TxtFatura.TabIndex = 22;
            // 
            // BtnConfirmar
            // 
            this.BtnConfirmar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnConfirmar.Location = new System.Drawing.Point(391, 438);
            this.BtnConfirmar.Name = "BtnConfirmar";
            this.BtnConfirmar.Size = new System.Drawing.Size(89, 23);
            this.BtnConfirmar.TabIndex = 44;
            this.BtnConfirmar.Text = "Confirmar";
            this.BtnConfirmar.UseVisualStyleBackColor = true;
            this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtHomepage);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.CheckIsento);
            this.groupBox1.Controls.Add(this.TxtContaDeb);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.TxtValCartAtv);
            this.groupBox1.Controls.Add(this.TxtDiaVenc);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.CboCob);
            this.groupBox1.Controls.Add(this.TxtBancoCob);
            this.groupBox1.Controls.Add(this.TxtFranqTrans);
            this.groupBox1.Controls.Add(this.TxtVrMin);
            this.groupBox1.Controls.Add(this.TxtVrTrans);
            this.groupBox1.Controls.Add(this.TxtPctTrans);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.TxtTarif);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.TxtFatura);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Location = new System.Drawing.Point(13, 246);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 176);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações para Faturamento";
            // 
            // txtHomepage
            // 
            this.txtHomepage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtHomepage.Location = new System.Drawing.Point(342, 142);
            this.txtHomepage.Name = "txtHomepage";
            this.txtHomepage.Size = new System.Drawing.Size(125, 20);
            this.txtHomepage.TabIndex = 28;
            this.txtHomepage.TextChanged += new System.EventHandler(this.txtHomepage_TextChanged);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(242, 145);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 23);
            this.label13.TabIndex = 62;
            this.label13.Text = "HOMEPAGE";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // CheckIsento
            // 
            this.CheckIsento.Location = new System.Drawing.Point(392, 162);
            this.CheckIsento.Name = "CheckIsento";
            this.CheckIsento.Size = new System.Drawing.Size(104, 24);
            this.CheckIsento.TabIndex = 29;
            this.CheckIsento.Text = "Isento de fatura";
            this.CheckIsento.UseVisualStyleBackColor = true;
            // 
            // TxtContaDeb
            // 
            this.TxtContaDeb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtContaDeb.Location = new System.Drawing.Point(346, 120);
            this.TxtContaDeb.Name = "TxtContaDeb";
            this.TxtContaDeb.Size = new System.Drawing.Size(121, 20);
            this.TxtContaDeb.TabIndex = 27;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label26.Location = new System.Drawing.Point(244, 123);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(100, 23);
            this.label26.TabIndex = 59;
            this.label26.Text = "Conta Débito";
            // 
            // TxtValCartAtv
            // 
            this.TxtValCartAtv.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtValCartAtv.Location = new System.Drawing.Point(346, 97);
            this.TxtValCartAtv.Name = "TxtValCartAtv";
            this.TxtValCartAtv.Size = new System.Drawing.Size(121, 20);
            this.TxtValCartAtv.TabIndex = 26;
            // 
            // TxtDiaVenc
            // 
            this.TxtDiaVenc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtDiaVenc.Location = new System.Drawing.Point(346, 74);
            this.TxtDiaVenc.Name = "TxtDiaVenc";
            this.TxtDiaVenc.Size = new System.Drawing.Size(121, 20);
            this.TxtDiaVenc.TabIndex = 25;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(244, 77);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(107, 22);
            this.label22.TabIndex = 40;
            this.label22.Text = "Dia Venc. Fatura";
            // 
            // CboCob
            // 
            this.CboCob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboCob.FormattingEnabled = true;
            this.CboCob.Location = new System.Drawing.Point(346, 27);
            this.CboCob.Name = "CboCob";
            this.CboCob.Size = new System.Drawing.Size(121, 21);
            this.CboCob.TabIndex = 23;
            // 
            // TxtBancoCob
            // 
            this.TxtBancoCob.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtBancoCob.Location = new System.Drawing.Point(346, 51);
            this.TxtBancoCob.Name = "TxtBancoCob";
            this.TxtBancoCob.Size = new System.Drawing.Size(121, 20);
            this.TxtBancoCob.TabIndex = 24;
            // 
            // TxtFranqTrans
            // 
            this.TxtFranqTrans.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtFranqTrans.Location = new System.Drawing.Point(112, 119);
            this.TxtFranqTrans.Name = "TxtFranqTrans";
            this.TxtFranqTrans.Size = new System.Drawing.Size(110, 20);
            this.TxtFranqTrans.TabIndex = 21;
            // 
            // TxtVrMin
            // 
            this.TxtVrMin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtVrMin.Location = new System.Drawing.Point(112, 96);
            this.TxtVrMin.Name = "TxtVrMin";
            this.TxtVrMin.Size = new System.Drawing.Size(110, 20);
            this.TxtVrMin.TabIndex = 20;
            // 
            // TxtVrTrans
            // 
            this.TxtVrTrans.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtVrTrans.Location = new System.Drawing.Point(112, 73);
            this.TxtVrTrans.Name = "TxtVrTrans";
            this.TxtVrTrans.Size = new System.Drawing.Size(110, 20);
            this.TxtVrTrans.TabIndex = 19;
            // 
            // TxtPctTrans
            // 
            this.TxtPctTrans.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtPctTrans.Location = new System.Drawing.Point(112, 50);
            this.TxtPctTrans.Name = "TxtPctTrans";
            this.TxtPctTrans.Size = new System.Drawing.Size(110, 20);
            this.TxtPctTrans.TabIndex = 18;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(244, 54);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(107, 22);
            this.label24.TabIndex = 31;
            this.label24.Text = "Banco Cobrança";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(244, 30);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(92, 13);
            this.label23.TabIndex = 30;
            this.label23.Text = "Tipo de Cobrança";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(11, 99);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 13);
            this.label20.TabIndex = 27;
            this.label20.Text = "Valor Mínimo";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(11, 76);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(82, 13);
            this.label19.TabIndex = 26;
            this.label19.Text = "Valor por Trans.";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(11, 53);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(94, 13);
            this.label18.TabIndex = 25;
            this.label18.Text = "Pct. por transação";
            // 
            // TxtTarif
            // 
            this.TxtTarif.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtTarif.Location = new System.Drawing.Point(112, 27);
            this.TxtTarif.Name = "TxtTarif";
            this.TxtTarif.Size = new System.Drawing.Size(110, 20);
            this.TxtTarif.TabIndex = 17;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(11, 30);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 13);
            this.label17.TabIndex = 23;
            this.label17.Text = "Tarifa Básica";
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(244, 100);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(107, 22);
            this.label25.TabIndex = 43;
            this.label25.Text = "Valor  Cartão Ativo";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(11, 122);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(107, 23);
            this.label21.TabIndex = 28;
            this.label21.Text = "Franquia Trans.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtObs);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.TxtEmpresa);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TxtCNPJ);
            this.groupBox2.Controls.Add(this.TxtSocial);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.TxtFantasia);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TxtEndereco);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TxtParcelas);
            this.groupBox2.Controls.Add(this.TxtCidade);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.TxtCartoes);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.TxtEstado);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.TxtTelefone);
            this.groupBox2.Controls.Add(this.TxtCEP);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(496, 223);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Identificação";
            // 
            // TxtObs
            // 
            this.TxtObs.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtObs.Location = new System.Drawing.Point(112, 188);
            this.TxtObs.Name = "TxtObs";
            this.TxtObs.Size = new System.Drawing.Size(355, 20);
            this.TxtObs.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(12, 191);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 23);
            this.label14.TabIndex = 28;
            this.label14.Text = "Observação";
            // 
            // BtnBloq
            // 
            this.BtnBloq.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnBloq.Location = new System.Drawing.Point(13, 438);
            this.BtnBloq.Name = "BtnBloq";
            this.BtnBloq.Size = new System.Drawing.Size(89, 23);
            this.BtnBloq.TabIndex = 45;
            this.BtnBloq.Text = "Bloqueio";
            this.BtnBloq.UseVisualStyleBackColor = true;
            this.BtnBloq.Click += new System.EventHandler(this.BtnBloqClick);
            // 
            // BtnDesbloq
            // 
            this.BtnDesbloq.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnDesbloq.Location = new System.Drawing.Point(125, 438);
            this.BtnDesbloq.Name = "BtnDesbloq";
            this.BtnDesbloq.Size = new System.Drawing.Size(89, 23);
            this.BtnDesbloq.TabIndex = 46;
            this.BtnDesbloq.Text = "Desbloqueio";
            this.BtnDesbloq.UseVisualStyleBackColor = true;
            this.BtnDesbloq.Click += new System.EventHandler(this.BtnDesbloqClick);
            // 
            // LblBloq
            // 
            this.LblBloq.BackColor = System.Drawing.Color.Transparent;
            this.LblBloq.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblBloq.Location = new System.Drawing.Point(249, 443);
            this.LblBloq.Name = "LblBloq";
            this.LblBloq.Size = new System.Drawing.Size(100, 23);
            this.LblBloq.TabIndex = 29;
            // 
            // dlgNovaEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(525, 475);
            this.Controls.Add(this.LblBloq);
            this.Controls.Add(this.BtnDesbloq);
            this.Controls.Add(this.BtnBloq);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnConfirmar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgNovaEmpresa";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Empresa";
            this.Load += new System.EventHandler(this.DlgNovaEmpresaLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		public System.Windows.Forms.Label LblBloq;
		public System.Windows.Forms.Button BtnDesbloq;
		public System.Windows.Forms.Button BtnBloq;
		public System.Windows.Forms.TextBox TxtObs;
		public System.Windows.Forms.Label label14;
		public System.Windows.Forms.CheckBox CheckIsento;
		private System.Windows.Forms.GroupBox groupBox2;
		public System.Windows.Forms.Label label26;
		public System.Windows.Forms.TextBox TxtContaDeb;
		public System.Windows.Forms.TextBox TxtValCartAtv;
		public System.Windows.Forms.Label label25;
		public System.Windows.Forms.Label label22;
		public System.Windows.Forms.TextBox TxtDiaVenc;
		public System.Windows.Forms.TextBox TxtBancoCob;
		public System.Windows.Forms.ComboBox CboCob;
		public System.Windows.Forms.TextBox TxtVrMin;
		public System.Windows.Forms.TextBox TxtFranqTrans;
		public System.Windows.Forms.TextBox TxtTarif;
		public System.Windows.Forms.Label label20;
		public System.Windows.Forms.Label label21;
		public System.Windows.Forms.Label label23;
		public System.Windows.Forms.Label label24;
		public System.Windows.Forms.TextBox TxtPctTrans;
		public System.Windows.Forms.TextBox TxtVrTrans;
		public System.Windows.Forms.Label label17;
		public System.Windows.Forms.Label label18;
		public System.Windows.Forms.Label label19;
		public System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.TextBox TxtParcelas;
		public System.Windows.Forms.TextBox TxtFatura;
		public System.Windows.Forms.TextBox TxtCidade;
		public System.Windows.Forms.TextBox TxtEstado;
		public System.Windows.Forms.TextBox TxtCEP;
		public System.Windows.Forms.TextBox TxtTelefone;
		public System.Windows.Forms.TextBox TxtCartoes;
		public System.Windows.Forms.TextBox TxtFantasia;
		public System.Windows.Forms.TextBox TxtSocial;
		public System.Windows.Forms.TextBox TxtEndereco;
		public System.Windows.Forms.TextBox TxtCNPJ;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.Label label12;
		public System.Windows.Forms.Label label11;
		public System.Windows.Forms.Label label10;
		public System.Windows.Forms.Label label9;
		public System.Windows.Forms.Label label8;
		public System.Windows.Forms.Label label7;
		public System.Windows.Forms.Label label6;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox TxtEmpresa;
		public System.Windows.Forms.Label label1;
        public TextBox txtHomepage;
        public Label label13;
	}
}

