<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AltSenhaResp.aspx.cs" Inherits="AltSenhaResp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
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
                                                                         .style3
                                                                         {
                                                                             width: 456px;
                                                                             height: 25px;
                                                                         }
                                                                         #TxtSenha
                                                                         {
                                                                             width: 152px;
                                                                             margin-left: 0px;
                                                                         }
                                                                         .style19
                                                                         {
                                                                             width: 10px;
                                                                             height: 42px;
                                                                         }
                                                                         .style23
                                                                         {
                                                                             height: 42px;
                                                                             color: #000099;
                                                                             width: 296px;
                                                                         }
                                                                         .style24
                                                                         {
                                                                             height: 42px;
                                                                             color: #000099;
                                                                             }
                                                                         .style25
                                                                         {
                                                                             height: 42px;
                                                                             color: #339933;
                                                                             }
                                                                         .style26
                                                                         {
                                                                             width: 10px;
                                                                             height: 16px;
                                                                         }
                                                                         .style27
                                                                         {
                                                                             height: 16px;
                                                                             color: #000099;
                                                                         }
                                                                         .style28
                                                                         {
                                                                             height: 16px;
                                                                             color: #000099;
                                                                             width: 296px;
                                                                         }
                                                                         .style29
                                                                         {
                                                                             width: 10px;
                                                                             height: 17px;
                                                                         }
                                                                         .style30
                                                                         {
                                                                             height: 17px;
                                                                             color: #000099;
                                                                         }
                                                                         .style31
                                                                         {
                                                                             height: 17px;
                                                                             color: #000099;
                                                                             width: 296px;
                                                                         }
                                                                         .style32
                                                                         {
                                                                             width: 10px;
                                                                             height: 15px;
                                                                         }
                                                                         .style33
                                                                         {
                                                                             height: 15px;
                                                                             color: #000099;
                                                                         }
                                                                         .style34
                                                                         {
                                                                             height: 15px;
                                                                             color: #000099;
                                                                             width: 296px;
                                                                         }
                                                                         .style35
                                                                         {
                                                                             color: #000000;
                                                                         }
-->
</style></head>
<body>
    <form name="form1" id="form1" runat="server">
    <div>
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
                <td class="style25" colspan="2">
                    <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Resp.aspx">Voltar à 
        lista de alunos</asp:HyperLink>
                    <br />
                    <br />
                    <span class="style35">Alterar senha de responsável<br />
                    </span>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style32">
                    </td>
                <td class="style33">
                    Senha atual</td>
                <td class="style34">
                    <input id="TxtSenhaAtual" type="password" runat="server" tabindex="5"></td>
            </tr>
            <tr>
                <td class="style26">
                    </td>
                <td class="style27">
                    Nova senha</td>
                <td class="style28">
                    <input id="TxtSenhaNova" type="password" runat="server" tabindex="5"></td>
            </tr>
            <tr>
                <td class="style29">
                    </td>
                <td class="style30">
                    Confirmar senha</td>
                <td class="style31">
                    <input id="TxtSenhaConfirma" type="password" runat="server" tabindex="5"></td>
            </tr>
            <tr>
                <td class="style19">
                    &nbsp;</td>
                <td class="style24">
                    &nbsp;</td>
                <td class="style23">
                    <asp:Button ID="Button1" runat="server" Text="Alterar Senha" Width="114px" 
                        onclick="BtnConfirmar" TabIndex="3" />
                </td>
            </tr>
            <tr>
                <td class="style19">
                    &nbsp;</td>
                <td class="style24" colspan="2">
                    <asp:Label ID="LblMsg" runat="server" style="font-weight: 700; color: #000000;" 
                        Text=""></asp:Label>
                </td>
            </tr>
            </table>
        <br />
        <br />
    </div>
</form>
</body>
</html>
