<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Decide.aspx.cs" Inherits="Decide" %>
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
                                                                             width: 24%;
                                                                         }
                                                                         .style2
                                                                         {
                                                                             text-align: center;
                                                                         }
                                                                         -->
</style></head>
<body>
    <form name="form1" id="form1" runat="server">
                <table align="center" class="style1">
                    <tr>
                        <td>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/logotipo_conveynet.jpg" 
                    style="text-align: center" />
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-left: 40px; text-align: center;">
                <asp:Label ID="LblNome" runat="server" ForeColor="#006600" Text="Label" 
                                style="text-align: center"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                <asp:Button ID="BtnTrans" runat="server" 
                    Text="Ver transações por data" Width="184px" onclick="BtnTrans_Click" 
                                style="text-align: center" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                <asp:Button ID="BtnRepasse" runat="server" 
                    Text="Ver repasse associação" Width="184px" onclick="BtnRepasse_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                <asp:Button ID="BtnSair" runat="server" 
                    Text="Sair" Width="72px" onclick="BtnSair_Click" />
                        </td>
                    </tr>
                </table>
                <br />
    <br />
    <br />
                <br />
            <br />
                <br />
                <br />
    <br />

    
            <br />
    <br />
</form>
</body>
</html>
