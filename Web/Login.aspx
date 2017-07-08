<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ConveyNET</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><style type="text/css">
                                                                         <!--
body {
	background-repeat: no-repeat;
	font-family: Arial, Helvetica, sans-serif;
	font-size: small;
                                                                             font-weight: 700;
                                                                         }
                                                                         #TxtSenha
                                                                         {
                                                                             width: 75px;
                                                                             margin-left: 0px;
                                                                         }
                                                                         #TxtSenha0
                                                                         {
                                                                             width: 75px;
                                                                             margin-left: 0px;
                                                                         }
                                                                         #TxtSenhaResp
                                                                         {
                                                                             width: 75px;
                                                                         }
                                                                         #TxtSenhaAluno
                                                                         {
                                                                             width: 74px;
                                                                         }
                                                                         #TxtPass0
                                                                         {
                                                                             width: 69px;
                                                                         }
                                                                         #TxtPass1
                                                                         {
                                                                             width: 69px;
                                                                         }
                                                                         #TxtPass
                                                                         {
                                                                             width: 71px;
                                                                         }
                                                                         .style1
                                                                         {
                                                                             width: 34%;
                                                                         }
                                                                         .style2
                                                                         {
                                                                         }
                                                                         .style3
                                                                         {
                                                                             width: 350px;
                                                                         }
                                                                         -->
</style></head>
<body>
    <form name="form1" id="form1" runat="server">
    <br />
    <br />
    <br />
    <table class="style1" align="center">
        <tr>
            <td class="style2" colspan="3">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/logotipo_conveynet.jpg" 
                    style="text-align: center" />
            </td>
        </tr>
        <tr>
            <td>
                Associação</td>
            <td>
                &nbsp;</td>
            <td class="style3">
                <asp:TextBox ID="TxtAssoc" runat="server" Width="102px" MaxLength="6" 
                    ontextchanged="TxtAssoc_TextChanged"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td>
                Matrícula</td>
            <td>
                &nbsp;</td>
            <td class="style3">
                <asp:TextBox ID="TxtMat" runat="server" Width="102px" MaxLength="6"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td>
                Titularidade</td>
            <td>
                &nbsp;</td>
            <td class="style3">
                <asp:TextBox ID="TxtTit" runat="server" Width="102px" MaxLength="2"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Senha</td>
            <td>
                &nbsp;</td>
            <td class="style3">
                <input id="TxtPass" type="password" runat="server" maxlength="4" /></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style3">
                <asp:Button ID="BtnConfirmar" runat="server" onclick="BtnConfirmar_Click" 
                    Text="Confirmar" Width="113px" />
            </td>
        </tr>
    </table>

    
            <br />
    <br />
</form>
</body>
</html>
