<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cartão Universitário</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><style type="text/css">
                                                                         <!--
body {
	background-image: url('fundo_edu_como_funciona.jpg');
	background-repeat: no-repeat;
	font-family: Arial, Helvetica, sans-serif;
	font-size: small;
	
                                                                         }
                                                                         .style3
                                                                         {
                                                                             width: 921px;
                                                                             height: 25px;
                                                                         }
                                                                         .style15
                                                                         {
                                                                             height: 25px;
                                                                         }
                                                                         #TxtSenha
                                                                         {
                                                                             width: 75px;
                                                                             margin-left: 0px;
                                                                         }
                                                                         .style19
                                                                         {
                                                                             width: 1911px;
                                                                             height: 69px;
                                                                         }
                                                                         .style21
                                                                         {
                                                                             width: 54px;
                                                                             height: 25px;
                                                                             color: #339933;
                                                                         }
                                                                         .style30
                                                                         {
                                                                             width: 226px;
                                                                             height: 25px;
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
                                                                         .style38
                                                                         {
                                                                             height: 69px;
                                                                             font-weight: bold;
                                                                             color: #0000CC;
                                                                             font-size: medium;
                                                                             font-family: Tahoma;
                                                                         }
                                                                         .style39
                                                                         {
                                                                             width: 1911px;
                                                                             height: 25px;
                                                                         }
                                                                         .style43
                                                                         {
                                                                             width: 1911px;
                                                                             height: 43px;
                                                                         }
                                                                         .style44
                                                                         {
                                                                             height: 43px;
                                                                             font-weight: bold;
                                                                             color: #0000CC;
                                                                             font-size: medium;
                                                                             font-family: Tahoma;
                                                                         }
                                                                         .style46
                                                                         {
                                                                             height: 25px;
                                                                             color: #000000;
                                                                         }
                                                                         .style47
                                                                         {
                                                                             width: 1911px;
                                                                             height: 24px;
                                                                         }
                                                                         .style49
                                                                         {
                                                                             width: 226px;
                                                                             height: 24px;
                                                                         }
                                                                         .style50
                                                                         {
                                                                             height: 24px;
                                                                         }
                                                                         -->
</style></head>
<body>
    <form name="form1" id="form1" runat="server">
    <div style="width: 959px">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <table class="style3">
            <tr>
                <td class="style19">
                    </td>
                <td class="style38" colspan="2">
                    </td>
            </tr>
            <tr>
                <td class="style39">
                    </td>
                <td class="style46">
                    CPF</td>
                <td class="style30">
                    <asp:TextBox ID="TxtCPF" runat="server" Width="152px" TabIndex="1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style39">
                    </td>
                <td class="style46">
                    Senha</td>
                <td class="style30">
                    <input id="TxtSenhaResp" type="password" runat="server" tabindex="2"></td>
            </tr>
            <tr>
                <td class="style39">&nbsp;
                    </td>
                <td class="style21">&nbsp;</td> 
                <td class="style30">
                    <asp:Button ID="Button1" runat="server" Text="Confirmar" Width="77px" 
                        onclick="BtnConfirmar" TabIndex="3" />
                </td>
            </tr>
            <tr>
                <td class="style39">&nbsp;
                    </td>
                <td class="style15">&nbsp;</td> 
                <td class="style30">&nbsp;
                    </td>
            </tr>
            <tr>
                <td class="style43">
                    </td>
                <td class="style44" colspan="2"></td> 
            </tr>
            <tr>
                <td class="style39">&nbsp;
                    </td>
                <td class="style46">Cartão</td> 
                <td class="style30">
                    <asp:TextBox ID="TxtCartao" runat="server" Width="152px" TabIndex="4"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style39">&nbsp;
                    </td>
                <td class="style46">Senha</td> 
                <td class="style30">
                    <input id="TxtSenhaAluno" type="password" runat="server" tabindex="5"></td>
            </tr>
            <tr>
                <td class="style39">&nbsp;
                    </td>
                <td class="style15">&nbsp;</td> 
                <td class="style30">
                    <asp:Button ID="Button2" runat="server" Text="Confirmar" Width="77px" 
                        onclick="BtnConfirmar" TabIndex="6" />
                </td>
            </tr>
            <tr>
                <td class="style47">
                    </td>
                <td class="style50"></td> 
                <td class="style49">
                </td>
            </tr>
            <tr>
                <td class="style39">&nbsp;</td>
                <td class="style15" colspan="2">
                    &nbsp;</td> 
            </tr>
        </table>
        <p style="margin-left: 720px">&nbsp;</p>
    </div>
</form>
</body>
</html>
