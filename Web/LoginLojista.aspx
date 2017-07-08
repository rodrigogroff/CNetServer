<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginLojista.aspx.cs" Inherits="LoginLojista" %>
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
            <td class="style2">
                Login</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:TextBox ID="TxtCNPJ" runat="server" Width="158px"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="style2">
                Senha</td>
            <td>
                &nbsp;</td>
            <td>
                <input id="TxtPass" type="password" runat="server" /></td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
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
