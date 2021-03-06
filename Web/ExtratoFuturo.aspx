﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExtratoFuturo.aspx.cs" Inherits="ExtratoFuturo" %>
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
                                                                         #form1
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
                                style="text-align: center; font-weight: 700;"></asp:Label>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-left: 40px; text-align: center;">
                            <asp:Button ID="BtnExtrato" runat="server" onclick="BtnExtrato_Click" Text="Extrato Atual" 
                                Width="157px" />
                            <br />
                            <asp:Button ID="BtnSair" runat="server" onclick="BtnSair_Click" Text="Sair" 
                                Width="55px" />
                        </td>
                    </tr>
                    </table>
                <br />
    
    
                Próximas parcelas devidas para seu cartão<br />
                <br />
    
    
    <asp:Repeater ID="RptExtrato" runat="server">
        
        
        <HeaderTemplate>
<table border=0 cellspacing=0  cellpadding=5 >
<tr bgcolor='#DDDDDD' >

<td><b>Loja</b></td>
<td><b>Valor R$</b></td>
<td><b>Parcela</b></td>
</tr>
</HeaderTemplate>

<ItemTemplate>
<tr>
<td> <%# DataBinder.Eval(Container.DataItem, "Loja") %> </td>
<td> <%# DataBinder.Eval(Container.DataItem, "Valor") %> </td>
<td> <%# DataBinder.Eval(Container.DataItem, "Parcela") %> </td>
</tr>
</ItemTemplate>

<FooterTemplate>
</table>
</FooterTemplate>

</asp:Repeater>

    
                <br />
    
    
                <asp:Label ID="LblGasto" runat="server"></asp:Label>

    
                <br />
</form>
</body>
</html>
