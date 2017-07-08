using System.Windows.Forms;

namespace Client 
{
	partial class dlgNovoCartao : Form
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
			this.tbCtrl = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.TxtRenda = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.TxtEmail = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.TxtDtNasc = new System.Windows.Forms.TextBox();
			this.label26 = new System.Windows.Forms.Label();
			this.TxtTelefone = new System.Windows.Forms.TextBox();
			this.TxtDDD = new System.Windows.Forms.TextBox();
			this.TxtCEP = new System.Windows.Forms.TextBox();
			this.TxtEstado = new System.Windows.Forms.TextBox();
			this.TxtCidade = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.TxtBairro = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.TxtComplemento = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.TxtNumero = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.TxtEndereco = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.TxtNome = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.TxtCpf = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label39 = new System.Windows.Forms.Label();
			this.CboTipoCart = new System.Windows.Forms.ComboBox();
			this.TxtCotaExtra = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.TxtLimRotativo = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.TxtLimMensal = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.TxtLimTotal = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.TxtCelular = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.TxtConta = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.TxtAgencia = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.TxtBanco = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.TxtVencimento = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtSenha = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TxtMatricula = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtCodEmpresa = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.TxtSenhaResp = new System.Windows.Forms.TextBox();
			this.label32 = new System.Windows.Forms.Label();
			this.TxtAluno = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label35 = new System.Windows.Forms.Label();
			this.TxtRecado = new System.Windows.Forms.TextBox();
			this.TxtPresenteado = new System.Windows.Forms.TextBox();
			this.label34 = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.TxtAfiliada = new System.Windows.Forms.TextBox();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.BtnAtualizar = new System.Windows.Forms.Button();
			this.BtnAdicionar = new System.Windows.Forms.Button();
			this.TxtNomeDep = new System.Windows.Forms.TextBox();
			this.label38 = new System.Windows.Forms.Label();
			this.TxtTitularidade = new System.Windows.Forms.TextBox();
			this.label37 = new System.Windows.Forms.Label();
			this.CboDependentes = new System.Windows.Forms.ComboBox();
			this.label36 = new System.Windows.Forms.Label();
			this.BtnCancelar = new System.Windows.Forms.Button();
			this.BtnConfirmar = new System.Windows.Forms.Button();
			this.tbCtrl.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbCtrl
			// 
			this.tbCtrl.Controls.Add(this.tabPage2);
			this.tbCtrl.Controls.Add(this.tabPage1);
			this.tbCtrl.Controls.Add(this.tabPage3);
			this.tbCtrl.Controls.Add(this.tabPage4);
			this.tbCtrl.Location = new System.Drawing.Point(22, 24);
			this.tbCtrl.Name = "tbCtrl";
			this.tbCtrl.SelectedIndex = 0;
			this.tbCtrl.Size = new System.Drawing.Size(483, 335);
			this.tbCtrl.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.TxtRenda);
			this.tabPage2.Controls.Add(this.label28);
			this.tabPage2.Controls.Add(this.TxtEmail);
			this.tabPage2.Controls.Add(this.label27);
			this.tabPage2.Controls.Add(this.TxtDtNasc);
			this.tabPage2.Controls.Add(this.label26);
			this.tabPage2.Controls.Add(this.TxtTelefone);
			this.tabPage2.Controls.Add(this.TxtDDD);
			this.tabPage2.Controls.Add(this.TxtCEP);
			this.tabPage2.Controls.Add(this.TxtEstado);
			this.tabPage2.Controls.Add(this.TxtCidade);
			this.tabPage2.Controls.Add(this.label25);
			this.tabPage2.Controls.Add(this.label24);
			this.tabPage2.Controls.Add(this.label23);
			this.tabPage2.Controls.Add(this.label22);
			this.tabPage2.Controls.Add(this.label21);
			this.tabPage2.Controls.Add(this.TxtBairro);
			this.tabPage2.Controls.Add(this.label20);
			this.tabPage2.Controls.Add(this.TxtComplemento);
			this.tabPage2.Controls.Add(this.label19);
			this.tabPage2.Controls.Add(this.TxtNumero);
			this.tabPage2.Controls.Add(this.label18);
			this.tabPage2.Controls.Add(this.TxtEndereco);
			this.tabPage2.Controls.Add(this.label17);
			this.tabPage2.Controls.Add(this.TxtNome);
			this.tabPage2.Controls.Add(this.label16);
			this.tabPage2.Controls.Add(this.TxtCpf);
			this.tabPage2.Controls.Add(this.label15);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(475, 309);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Proprietário";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// TxtRenda
			// 
			this.TxtRenda.Location = new System.Drawing.Point(327, 198);
			this.TxtRenda.Name = "TxtRenda";
			this.TxtRenda.Size = new System.Drawing.Size(100, 20);
			this.TxtRenda.TabIndex = 27;
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(258, 201);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(100, 23);
			this.label28.TabIndex = 26;
			this.label28.Text = "Renda";
			// 
			// TxtEmail
			// 
			this.TxtEmail.Location = new System.Drawing.Point(327, 169);
			this.TxtEmail.Name = "TxtEmail";
			this.TxtEmail.Size = new System.Drawing.Size(100, 20);
			this.TxtEmail.TabIndex = 25;
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(258, 172);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(100, 23);
			this.label27.TabIndex = 24;
			this.label27.Text = "Email";
			// 
			// TxtDtNasc
			// 
			this.TxtDtNasc.Location = new System.Drawing.Point(327, 140);
			this.TxtDtNasc.Name = "TxtDtNasc";
			this.TxtDtNasc.Size = new System.Drawing.Size(100, 20);
			this.TxtDtNasc.TabIndex = 23;
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(258, 143);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(100, 23);
			this.label26.TabIndex = 22;
			this.label26.Text = "Data Nasc.";
			// 
			// TxtTelefone
			// 
			this.TxtTelefone.Location = new System.Drawing.Point(327, 111);
			this.TxtTelefone.Name = "TxtTelefone";
			this.TxtTelefone.Size = new System.Drawing.Size(100, 20);
			this.TxtTelefone.TabIndex = 21;
			// 
			// TxtDDD
			// 
			this.TxtDDD.Location = new System.Drawing.Point(327, 82);
			this.TxtDDD.Name = "TxtDDD";
			this.TxtDDD.Size = new System.Drawing.Size(100, 20);
			this.TxtDDD.TabIndex = 19;
			// 
			// TxtCEP
			// 
			this.TxtCEP.Location = new System.Drawing.Point(327, 53);
			this.TxtCEP.Name = "TxtCEP";
			this.TxtCEP.Size = new System.Drawing.Size(100, 20);
			this.TxtCEP.TabIndex = 17;
			// 
			// TxtEstado
			// 
			this.TxtEstado.Location = new System.Drawing.Point(327, 24);
			this.TxtEstado.Name = "TxtEstado";
			this.TxtEstado.Size = new System.Drawing.Size(100, 20);
			this.TxtEstado.TabIndex = 15;
			// 
			// TxtCidade
			// 
			this.TxtCidade.Location = new System.Drawing.Point(98, 198);
			this.TxtCidade.Name = "TxtCidade";
			this.TxtCidade.Size = new System.Drawing.Size(121, 20);
			this.TxtCidade.TabIndex = 13;
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(258, 114);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(100, 23);
			this.label25.TabIndex = 20;
			this.label25.Text = "Telefone";
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(258, 85);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(100, 23);
			this.label24.TabIndex = 18;
			this.label24.Text = "DDD";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(258, 56);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(100, 23);
			this.label23.TabIndex = 16;
			this.label23.Text = "CEP";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(258, 27);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(100, 23);
			this.label22.TabIndex = 14;
			this.label22.Text = "Estado";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(17, 201);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(100, 23);
			this.label21.TabIndex = 12;
			this.label21.Text = "Cidade";
			// 
			// TxtBairro
			// 
			this.TxtBairro.Location = new System.Drawing.Point(98, 169);
			this.TxtBairro.Name = "TxtBairro";
			this.TxtBairro.Size = new System.Drawing.Size(121, 20);
			this.TxtBairro.TabIndex = 11;
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(17, 172);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(100, 23);
			this.label20.TabIndex = 10;
			this.label20.Text = "Bairro";
			// 
			// TxtComplemento
			// 
			this.TxtComplemento.Location = new System.Drawing.Point(98, 140);
			this.TxtComplemento.Name = "TxtComplemento";
			this.TxtComplemento.Size = new System.Drawing.Size(121, 20);
			this.TxtComplemento.TabIndex = 9;
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(17, 143);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(100, 23);
			this.label19.TabIndex = 8;
			this.label19.Text = "Complemento";
			// 
			// TxtNumero
			// 
			this.TxtNumero.Location = new System.Drawing.Point(98, 111);
			this.TxtNumero.Name = "TxtNumero";
			this.TxtNumero.Size = new System.Drawing.Size(121, 20);
			this.TxtNumero.TabIndex = 7;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(17, 114);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(100, 23);
			this.label18.TabIndex = 6;
			this.label18.Text = "Número";
			// 
			// TxtEndereco
			// 
			this.TxtEndereco.Location = new System.Drawing.Point(98, 82);
			this.TxtEndereco.Name = "TxtEndereco";
			this.TxtEndereco.Size = new System.Drawing.Size(121, 20);
			this.TxtEndereco.TabIndex = 5;
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(17, 85);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(100, 23);
			this.label17.TabIndex = 4;
			this.label17.Text = "Endereço";
			// 
			// TxtNome
			// 
			this.TxtNome.Location = new System.Drawing.Point(98, 53);
			this.TxtNome.Name = "TxtNome";
			this.TxtNome.Size = new System.Drawing.Size(121, 20);
			this.TxtNome.TabIndex = 3;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(17, 56);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(100, 23);
			this.label16.TabIndex = 2;
			this.label16.Text = "Nome";
			// 
			// TxtCpf
			// 
			this.TxtCpf.Location = new System.Drawing.Point(98, 24);
			this.TxtCpf.Name = "TxtCpf";
			this.TxtCpf.Size = new System.Drawing.Size(121, 20);
			this.TxtCpf.TabIndex = 1;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(17, 27);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(100, 23);
			this.label15.TabIndex = 0;
			this.label15.Text = "CPF ou CNPJ";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label39);
			this.tabPage1.Controls.Add(this.CboTipoCart);
			this.tabPage1.Controls.Add(this.TxtCotaExtra);
			this.tabPage1.Controls.Add(this.label12);
			this.tabPage1.Controls.Add(this.TxtLimRotativo);
			this.tabPage1.Controls.Add(this.label11);
			this.tabPage1.Controls.Add(this.TxtLimMensal);
			this.tabPage1.Controls.Add(this.label10);
			this.tabPage1.Controls.Add(this.TxtLimTotal);
			this.tabPage1.Controls.Add(this.label9);
			this.tabPage1.Controls.Add(this.TxtCelular);
			this.tabPage1.Controls.Add(this.label8);
			this.tabPage1.Controls.Add(this.TxtConta);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.TxtAgencia);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.TxtBanco);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.TxtVencimento);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.TxtSenha);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.TxtMatricula);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.TxtCodEmpresa);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(475, 309);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Cartão";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label39
			// 
			this.label39.Location = new System.Drawing.Point(12, 276);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(112, 23);
			this.label39.TabIndex = 29;
			this.label39.Text = "Tipo de cartão";
			// 
			// CboTipoCart
			// 
			this.CboTipoCart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboTipoCart.FormattingEnabled = true;
			this.CboTipoCart.Location = new System.Drawing.Point(130, 273);
			this.CboTipoCart.Name = "CboTipoCart";
			this.CboTipoCart.Size = new System.Drawing.Size(308, 21);
			this.CboTipoCart.TabIndex = 28;
			// 
			// TxtCotaExtra
			// 
			this.TxtCotaExtra.Location = new System.Drawing.Point(338, 192);
			this.TxtCotaExtra.Name = "TxtCotaExtra";
			this.TxtCotaExtra.Size = new System.Drawing.Size(100, 20);
			this.TxtCotaExtra.TabIndex = 23;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(257, 195);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(112, 23);
			this.label12.TabIndex = 22;
			this.label12.Text = "Cota Extra";
			// 
			// TxtLimRotativo
			// 
			this.TxtLimRotativo.Location = new System.Drawing.Point(130, 192);
			this.TxtLimRotativo.Name = "TxtLimRotativo";
			this.TxtLimRotativo.Size = new System.Drawing.Size(100, 20);
			this.TxtLimRotativo.TabIndex = 21;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(12, 195);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(112, 23);
			this.label11.TabIndex = 20;
			this.label11.Text = "Limite Rotativo";
			// 
			// TxtLimMensal
			// 
			this.TxtLimMensal.Location = new System.Drawing.Point(338, 157);
			this.TxtLimMensal.Name = "TxtLimMensal";
			this.TxtLimMensal.Size = new System.Drawing.Size(100, 20);
			this.TxtLimMensal.TabIndex = 19;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(257, 160);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(112, 23);
			this.label10.TabIndex = 18;
			this.label10.Text = "Limite Mensal";
			// 
			// TxtLimTotal
			// 
			this.TxtLimTotal.Location = new System.Drawing.Point(130, 157);
			this.TxtLimTotal.Name = "TxtLimTotal";
			this.TxtLimTotal.Size = new System.Drawing.Size(100, 20);
			this.TxtLimTotal.TabIndex = 17;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(12, 160);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(112, 23);
			this.label9.TabIndex = 16;
			this.label9.Text = "Limite Total";
			// 
			// TxtCelular
			// 
			this.TxtCelular.Location = new System.Drawing.Point(338, 110);
			this.TxtCelular.Name = "TxtCelular";
			this.TxtCelular.Size = new System.Drawing.Size(100, 20);
			this.TxtCelular.TabIndex = 15;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(257, 113);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(112, 23);
			this.label8.TabIndex = 14;
			this.label8.Text = "Celular";
			// 
			// TxtConta
			// 
			this.TxtConta.Location = new System.Drawing.Point(338, 78);
			this.TxtConta.Name = "TxtConta";
			this.TxtConta.Size = new System.Drawing.Size(100, 20);
			this.TxtConta.TabIndex = 13;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(257, 81);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(112, 23);
			this.label7.TabIndex = 12;
			this.label7.Text = "Conta";
			// 
			// TxtAgencia
			// 
			this.TxtAgencia.Location = new System.Drawing.Point(338, 49);
			this.TxtAgencia.Name = "TxtAgencia";
			this.TxtAgencia.Size = new System.Drawing.Size(100, 20);
			this.TxtAgencia.TabIndex = 11;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(257, 52);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(112, 23);
			this.label6.TabIndex = 10;
			this.label6.Text = "Agência";
			// 
			// TxtBanco
			// 
			this.TxtBanco.Location = new System.Drawing.Point(338, 20);
			this.TxtBanco.Name = "TxtBanco";
			this.TxtBanco.Size = new System.Drawing.Size(100, 20);
			this.TxtBanco.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(257, 23);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(112, 23);
			this.label5.TabIndex = 8;
			this.label5.Text = "Banco";
			// 
			// TxtVencimento
			// 
			this.TxtVencimento.Location = new System.Drawing.Point(130, 110);
			this.TxtVencimento.Name = "TxtVencimento";
			this.TxtVencimento.Size = new System.Drawing.Size(100, 20);
			this.TxtVencimento.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 113);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(112, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Vencimento (MMAA)";
			// 
			// TxtSenha
			// 
			this.TxtSenha.Location = new System.Drawing.Point(130, 78);
			this.TxtSenha.MaxLength = 8;
			this.TxtSenha.Name = "TxtSenha";
			this.TxtSenha.PasswordChar = '*';
			this.TxtSenha.Size = new System.Drawing.Size(100, 20);
			this.TxtSenha.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 81);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Senha";
			// 
			// TxtMatricula
			// 
			this.TxtMatricula.Location = new System.Drawing.Point(130, 49);
			this.TxtMatricula.Name = "TxtMatricula";
			this.TxtMatricula.Size = new System.Drawing.Size(100, 20);
			this.TxtMatricula.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Matrícula";
			// 
			// TxtCodEmpresa
			// 
			this.TxtCodEmpresa.Location = new System.Drawing.Point(130, 20);
			this.TxtCodEmpresa.Name = "TxtCodEmpresa";
			this.TxtCodEmpresa.Size = new System.Drawing.Size(100, 20);
			this.TxtCodEmpresa.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Código da empresa";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.groupBox2);
			this.tabPage3.Controls.Add(this.groupBox1);
			this.tabPage3.Controls.Add(this.label31);
			this.tabPage3.Controls.Add(this.TxtAfiliada);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(475, 309);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Adicional";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.TxtSenhaResp);
			this.groupBox2.Controls.Add(this.label32);
			this.groupBox2.Controls.Add(this.TxtAluno);
			this.groupBox2.Controls.Add(this.label30);
			this.groupBox2.Location = new System.Drawing.Point(28, 126);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(339, 113);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Cartão Educacional";
			// 
			// TxtSenhaResp
			// 
			this.TxtSenhaResp.Location = new System.Drawing.Point(151, 64);
			this.TxtSenhaResp.MaxLength = 8;
			this.TxtSenhaResp.Name = "TxtSenhaResp";
			this.TxtSenhaResp.PasswordChar = '*';
			this.TxtSenhaResp.Size = new System.Drawing.Size(161, 20);
			this.TxtSenhaResp.TabIndex = 12;
			// 
			// label32
			// 
			this.label32.Location = new System.Drawing.Point(20, 67);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(119, 23);
			this.label32.TabIndex = 11;
			this.label32.Text = "Senha do Responsável";
			// 
			// TxtAluno
			// 
			this.TxtAluno.Location = new System.Drawing.Point(150, 30);
			this.TxtAluno.Name = "TxtAluno";
			this.TxtAluno.Size = new System.Drawing.Size(161, 20);
			this.TxtAluno.TabIndex = 10;
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(20, 33);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(100, 23);
			this.label30.TabIndex = 10;
			this.label30.Text = "Nome do aluno";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label35);
			this.groupBox1.Controls.Add(this.TxtRecado);
			this.groupBox1.Controls.Add(this.TxtPresenteado);
			this.groupBox1.Controls.Add(this.label34);
			this.groupBox1.Location = new System.Drawing.Point(26, 18);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(341, 92);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Cartão presente";
			// 
			// label35
			// 
			this.label35.Location = new System.Drawing.Point(21, 58);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(100, 23);
			this.label35.TabIndex = 8;
			this.label35.Text = "Recado";
			// 
			// TxtRecado
			// 
			this.TxtRecado.Location = new System.Drawing.Point(151, 55);
			this.TxtRecado.Name = "TxtRecado";
			this.TxtRecado.Size = new System.Drawing.Size(162, 20);
			this.TxtRecado.TabIndex = 9;
			// 
			// TxtPresenteado
			// 
			this.TxtPresenteado.Location = new System.Drawing.Point(151, 22);
			this.TxtPresenteado.Name = "TxtPresenteado";
			this.TxtPresenteado.Size = new System.Drawing.Size(162, 20);
			this.TxtPresenteado.TabIndex = 7;
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(21, 25);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(100, 23);
			this.label34.TabIndex = 6;
			this.label34.Text = "Nome presenteado";
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(48, 257);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(100, 23);
			this.label31.TabIndex = 0;
			this.label31.Text = "Empresa afiliada";
			// 
			// TxtAfiliada
			// 
			this.TxtAfiliada.Location = new System.Drawing.Point(177, 254);
			this.TxtAfiliada.Name = "TxtAfiliada";
			this.TxtAfiliada.Size = new System.Drawing.Size(162, 20);
			this.TxtAfiliada.TabIndex = 1;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.BtnAtualizar);
			this.tabPage4.Controls.Add(this.BtnAdicionar);
			this.tabPage4.Controls.Add(this.TxtNomeDep);
			this.tabPage4.Controls.Add(this.label38);
			this.tabPage4.Controls.Add(this.TxtTitularidade);
			this.tabPage4.Controls.Add(this.label37);
			this.tabPage4.Controls.Add(this.CboDependentes);
			this.tabPage4.Controls.Add(this.label36);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(475, 309);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Dependentes";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// BtnAtualizar
			// 
			this.BtnAtualizar.Location = new System.Drawing.Point(235, 126);
			this.BtnAtualizar.Name = "BtnAtualizar";
			this.BtnAtualizar.Size = new System.Drawing.Size(75, 23);
			this.BtnAtualizar.TabIndex = 7;
			this.BtnAtualizar.Text = "Atualizar";
			this.BtnAtualizar.UseVisualStyleBackColor = true;
			this.BtnAtualizar.Click += new System.EventHandler(this.BtnAtualizarClick);
			// 
			// BtnAdicionar
			// 
			this.BtnAdicionar.Location = new System.Drawing.Point(328, 126);
			this.BtnAdicionar.Name = "BtnAdicionar";
			this.BtnAdicionar.Size = new System.Drawing.Size(75, 23);
			this.BtnAdicionar.TabIndex = 6;
			this.BtnAdicionar.Text = "Adicionar";
			this.BtnAdicionar.UseVisualStyleBackColor = true;
			this.BtnAdicionar.Click += new System.EventHandler(this.BtnAdicionarClick);
			// 
			// TxtNomeDep
			// 
			this.TxtNomeDep.Location = new System.Drawing.Point(235, 81);
			this.TxtNomeDep.Name = "TxtNomeDep";
			this.TxtNomeDep.Size = new System.Drawing.Size(168, 20);
			this.TxtNomeDep.TabIndex = 5;
			// 
			// label38
			// 
			this.label38.Location = new System.Drawing.Point(177, 84);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(108, 23);
			this.label38.TabIndex = 4;
			this.label38.Text = "Nome";
			// 
			// TxtTitularidade
			// 
			this.TxtTitularidade.Location = new System.Drawing.Point(105, 81);
			this.TxtTitularidade.Name = "TxtTitularidade";
			this.TxtTitularidade.ReadOnly = true;
			this.TxtTitularidade.Size = new System.Drawing.Size(50, 20);
			this.TxtTitularidade.TabIndex = 3;
			this.TxtTitularidade.Text = "2";
			this.TxtTitularidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label37
			// 
			this.label37.Location = new System.Drawing.Point(26, 84);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(108, 23);
			this.label37.TabIndex = 2;
			this.label37.Text = "Titularidade";
			// 
			// CboDependentes
			// 
			this.CboDependentes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboDependentes.FormattingEnabled = true;
			this.CboDependentes.Location = new System.Drawing.Point(105, 26);
			this.CboDependentes.Name = "CboDependentes";
			this.CboDependentes.Size = new System.Drawing.Size(168, 21);
			this.CboDependentes.TabIndex = 1;
			this.CboDependentes.SelectedIndexChanged += new System.EventHandler(this.CboDependentesSelectedIndexChanged);
			// 
			// label36
			// 
			this.label36.Location = new System.Drawing.Point(26, 29);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(108, 23);
			this.label36.TabIndex = 0;
			this.label36.Text = "Dependentes";
			// 
			// BtnCancelar
			// 
			this.BtnCancelar.Location = new System.Drawing.Point(179, 380);
			this.BtnCancelar.Name = "BtnCancelar";
			this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
			this.BtnCancelar.TabIndex = 1;
			this.BtnCancelar.Text = "Cancelar";
			this.BtnCancelar.UseVisualStyleBackColor = true;
			this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelarClick);
			// 
			// BtnConfirmar
			// 
			this.BtnConfirmar.Location = new System.Drawing.Point(272, 380);
			this.BtnConfirmar.Name = "BtnConfirmar";
			this.BtnConfirmar.Size = new System.Drawing.Size(75, 23);
			this.BtnConfirmar.TabIndex = 2;
			this.BtnConfirmar.Text = "Confirmar";
			this.BtnConfirmar.UseVisualStyleBackColor = true;
			this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmarClick);
			// 
			// dlgNovoCartao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(527, 417);
			this.Controls.Add(this.BtnConfirmar);
			this.Controls.Add(this.BtnCancelar);
			this.Controls.Add(this.tbCtrl);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgNovoCartao";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cadastramento de cartão";
			this.Load += new System.EventHandler(this.DlgNovoCartaoLoad);
			this.tbCtrl.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.TextBox TxtAluno;
		public System.Windows.Forms.TextBox TxtSenhaResp;
		public System.Windows.Forms.Label label32;
		public System.Windows.Forms.Label label30;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.ComboBox CboTipoCart;
		public System.Windows.Forms.Label label39;
		public System.Windows.Forms.Button BtnAtualizar;
		public System.Windows.Forms.Button BtnAdicionar;
		public System.Windows.Forms.TextBox TxtNomeDep;
		public System.Windows.Forms.TextBox TxtTitularidade;
		public System.Windows.Forms.ComboBox CboDependentes;
		public System.Windows.Forms.TextBox TxtNumero;
		public System.Windows.Forms.TextBox TxtCodEmpresa;
		public System.Windows.Forms.TextBox TxtSenha;
		public System.Windows.Forms.TextBox TxtConta;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label36;
		public System.Windows.Forms.TextBox TxtRecado;
		public System.Windows.Forms.TextBox TxtPresenteado;
		public System.Windows.Forms.TextBox TxtAfiliada;
		public System.Windows.Forms.Label label35;
		public System.Windows.Forms.Label label34;
		public System.Windows.Forms.Label label31;
		public System.Windows.Forms.TextBox TxtRenda;
		public System.Windows.Forms.TextBox TxtEmail;
		public System.Windows.Forms.TextBox TxtDtNasc;
		public System.Windows.Forms.TextBox TxtTelefone;
		public System.Windows.Forms.TextBox TxtDDD;
		public System.Windows.Forms.TextBox TxtCEP;
		public System.Windows.Forms.TextBox TxtEstado;
		public System.Windows.Forms.TextBox TxtCidade;
		public System.Windows.Forms.TextBox TxtBairro;
		public System.Windows.Forms.TextBox TxtComplemento;
		public System.Windows.Forms.TextBox TxtEndereco;
		public System.Windows.Forms.TextBox TxtNome;
		public System.Windows.Forms.TextBox TxtCpf;
		public System.Windows.Forms.Label label28;
		public System.Windows.Forms.Label label27;
		public System.Windows.Forms.Label label26;
		public System.Windows.Forms.Label label25;
		public System.Windows.Forms.Label label24;
		public System.Windows.Forms.Label label23;
		public System.Windows.Forms.Label label22;
		public System.Windows.Forms.Label label21;
		public System.Windows.Forms.Label label20;
		public System.Windows.Forms.Label label19;
		public System.Windows.Forms.Label label18;
		public System.Windows.Forms.Label label17;
		public System.Windows.Forms.Label label16;
		public System.Windows.Forms.Label label15;
		public System.Windows.Forms.Button BtnConfirmar;
		public System.Windows.Forms.Button BtnCancelar;
		public System.Windows.Forms.TextBox TxtCotaExtra;
		public System.Windows.Forms.Label label12;
		public System.Windows.Forms.TextBox TxtLimRotativo;
		public System.Windows.Forms.Label label11;
		public System.Windows.Forms.TextBox TxtLimMensal;
		public System.Windows.Forms.TextBox TxtLimTotal;
		public System.Windows.Forms.Label label10;
		public System.Windows.Forms.Label label9;
		public System.Windows.Forms.TextBox TxtCelular;
		public System.Windows.Forms.Label label8;
		public System.Windows.Forms.Label label7;
		public System.Windows.Forms.TextBox TxtAgencia;
		public System.Windows.Forms.Label label6;
		public System.Windows.Forms.TextBox TxtBanco;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox TxtVencimento;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox TxtMatricula;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.TabPage tabPage4;
		public System.Windows.Forms.TabPage tabPage3;
		public System.Windows.Forms.TabPage tabPage2;
		public System.Windows.Forms.TabPage tabPage1;
		public System.Windows.Forms.TabControl tbCtrl;
	}
}

