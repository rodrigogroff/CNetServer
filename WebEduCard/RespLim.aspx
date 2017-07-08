<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RespLim.aspx.cs" Inherits="RespLim" %>

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
                                                                             width: 568px;
                                                                         }
                                                                         .style7
                                                                         {
                                                                             width: 10px;
                                                                             height: 23px;
                                                                         }
                                                                         .style8
                                                                         {
                                                                             width: 112px;
                                                                             height: 23px;
                                                                         }
                                                                         .style10
                                                                         {
                                                                             width: 10px;
                                                                             height: 24px;
                                                                         }
                                                                         .style11
                                                                         {
                                                                             width: 112px;
                                                                             height: 24px;
                                                                         }
                                                                         .style13
                                                                         {
                                                                             width: 10px;
                                                                             height: 30px;
                                                                         }
                                                                         .style14
                                                                         {
                                                                             width: 112px;
                                                                             height: 30px;
                                                                         }
                                                                         .style16
                                                                         {
                                                                             width: 420px;
                                                                         }
                                                                         .style17
                                                                         {
                                                                             width: 420px;
                                                                             height: 24px;
                                                                         }
                                                                         .style18
                                                                         {
                                                                             width: 420px;
                                                                             height: 30px;
                                                                         }
                                                                         .style19
                                                                         {
                                                                             height: 23px;
                                                                             width: 136px;
                                                                         }
                                                                         .style20
                                                                         {
                                                                             height: 24px;
                                                                             width: 136px;
                                                                         }
                                                                         .style21
                                                                         {
                                                                             height: 30px;
                                                                             width: 136px;
                                                                         }
                                                                         .style22
                                                                         {
                                                                             width: 4px;
                                                                             height: 23px;
                                                                         }
                                                                         .style23
                                                                         {
                                                                             width: 4px;
                                                                             height: 24px;
                                                                         }
                                                                         .style24
                                                                         {
                                                                             width: 4px;
                                                                             height: 30px;
                                                                         }
                                                                         #TxtDir
                                                                         {
                                                                             width: 73px;
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
        <table class="style1">
            <tr>
                <td class="style7">
                </td>
                <td class="style8">
                    Valor mensal</td>
                <td class="style19">
                    <asp:TextBox ID="TxtMens" BackColor = LightGray  runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style22">
                    &nbsp;</td>
                <td class="style16" rowspan="2">
                    <asp:RadioButtonList ID="rb_tipo" runat="server" 
                        AutoPostBack =true 
                        onselectedindexchanged="rb_tipo_SelectedIndexChanged">
                        <asp:ListItem>Transferência somente em dias úteis</asp:ListItem>
                        <asp:ListItem>Transferência todos os dias da semana</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="style10">
                </td>
                <td class="style11">
                    Valor diário</td>
                <td class="style20">
                    <input id="TxtDir" type="text" runat="server" onkeydown="mascara(this,currfunc)" /></td>
                <td class="style23">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style13">
                </td>
                <td class="style14">
                </td>
                <td class="style21">
                    <asp:Button ID="BtnDefinir" runat="server" onclick="BtnDefinir_Click" 
                        Text="Definir" />
                </td>
                <td class="style24">
                    &nbsp;</td>
                <td class="style18">
                    &nbsp;</td>
            </tr>
        </table>
            <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#339933" 
            Text="Label"></asp:Label>
        <br />

        <br />
        <br />

        <br />


        </asp:Repeater>
    </div>
</form>
</body>
</html>
