<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BolDef.aspx.cs" Inherits="BolDef" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<script type="text/javascript" src="jsMascara.js" ></script>
<head runat="server">
    <title>Cartão Universitário</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><style type="text/css">
                                                                         <!--
body {
	background-image: url('fundo_edu.jpg');
	background-repeat: no-repeat;
	
                                                                             font-family: Arial, Helvetica, sans-serif;
                                                                             font-size: small;
                                                                         }
                                                                         #TxtSenha
                                                                         {
                                                                             width: 148px;
                                                                             margin-left: 0px;
                                                                         }
                                                                         .style1
                                                                         {
                                                                             width: 546px;
                                                                         }
                                                                         .style13
                                                                         {
                                                                             width: 10px;
                                                                             height: 33px;
                                                                         }
                                                                         .style14
                                                                         {
                                                                             width: 271px;
                                                                             height: 33px;
                                                                         }
                                                                         .style16
                                                                         {
                                                                             width: 10px;
                                                                             height: 17px;
                                                                         }
                                                                         .style17
                                                                         {
                                                                             width: 271px;
                                                                             height: 17px;
                                                                         }
                                                                         .style18
                                                                         {
                                                                             height: 17px;
                                                                             width: 44px;
                                                                         }
                                                                         .style19
                                                                         {
                                                                             width: 10px;
                                                                             height: 23px;
                                                                         }
                                                                         .style20
                                                                         {
                                                                             width: 271px;
                                                                             height: 23px;
                                                                         }
                                                                         .style21
                                                                         {
                                                                             height: 23px;
                                                                             width: 44px;
                                                                         }
                                                                         .style22
                                                                         {
                                                                             width: 10px;
                                                                             height: 10px;
                                                                         }
                                                                         .style23
                                                                         {
                                                                             width: 271px;
                                                                             height: 10px;
                                                                         }
                                                                         .style24
                                                                         {
                                                                             height: 10px;
                                                                             width: 44px;
                                                                         }
                                                                         .style25
                                                                         {
                                                                             height: 33px;
                                                                             width: 44px;
                                                                         }
                                                                         .style26
                                                                         {
                                                                             width: 10px;
                                                                         }
                                                                         .style27
                                                                         {
                                                                             width: 271px;
                                                                         }
                                                                         .style28
                                                                         {
                                                                             width: 44px;
                                                                         }
                                                                         .style29
                                                                         {
                                                                             width: 10px;
                                                                             height: 1px;
                                                                         }
                                                                         .style30
                                                                         {
                                                                             width: 271px;
                                                                             height: 1px;
                                                                         }
                                                                         .style31
                                                                         {
                                                                             height: 1px;
                                                                             width: 44px;
                                                                         }
                                                                         -->
</style></head>
<body>

    <form name="form1" id="form1" runat="server">
    <div style="width: 755px">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Resp.aspx">Voltar à 
        lista de alunos</asp:HyperLink>
        <br />
        <br />
            <asp:Label ID="LblAluno" runat="server" 
                    style="font-weight: 700; color: #000099"></asp:Label>
                <br />
        <br />
        <br />
        <b>Confirmação de valor para impressão de boleto bancário</b><br />
        <br />
        <table class="style1">
            <tr>
                <td class="style16">
                </td>
                <td class="style17">
                    Valor a ser depositado em fundo educacional</td>
                <td class="style18">
                    <asp:TextBox ID="TxtMens" onkeydown="mascara(this,currfunc)" runat="server" 
                        Width="85px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style19">
                </td>
                <td class="style20">
                    Valor a ser depositado em disponível imediato</td>
                <td class="style21">
                    <asp:TextBox ID="TxtDisp" onkeydown="mascara(this,currfunc)" runat="server" 
                        Width="83px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style13">
                </td>
                <td class="style14">
                    <asp:Button ID="BtnConfirmar" runat="server" onclick="BtnConfirmar_Click" 
                        Text="Confirmar Valores" Width="131px" />
                </td>
                <td class="style25">
                    </td>
            </tr>
            <tr>
                <td class="style22">
                </td>
                <td class="style23">
                    &nbsp;</td>
                <td class="style24">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style26">
                    </td>
                <td class="style27">
                    Número de
                    Identificação deste boleto</td>
                <td class="style28">
                    <asp:TextBox ID="TxtBolNumero" runat="server" Width="180px" ReadOnly="True"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="style29">
                    </td>
                <td class="style30">
                    Nome do responsável pelo pagamento</td>
                <td class="style31">
                    <asp:TextBox ID="TxtBolNome" runat="server" Width="180px" ReadOnly="True"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="style26">
                    </td>
                <td class="style27">
                    Valor total do documento </td>
                <td class="style28">
                    <asp:TextBox ID="TxtBolTot" runat="server" Width="180px" ReadOnly="True"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="style13">
                    &nbsp;</td>
                <td class="style14">
          <input type=button  value="Gerar Boleto" OnClick="desviaBoleto()"></td>
                <td class="style25">
                    &nbsp;</td>
            </tr>
            </table>
            <br />
          &nbsp;<br />

        <br />
        
    </div>
</form>
</body>
</html>
