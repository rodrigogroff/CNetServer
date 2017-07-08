<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ranking.aspx.cs" Inherits="Ranking" %>

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
                                                                         #TxtSenha
                                                                         {
                                                                             width: 148px;
                                                                             margin-left: 0px;
                                                                         }
                                                                         .style49
                                                                         {
                                                                             width: 86%;
                                                                         }
                                                                         .style53
                                                                         {
                                                                             width: 12px;
                                                                         }
                                                                         .style54
                                                                         {
                                                                             height: 33px;
                                                                             width: 12px;
                                                                         }
                                                                         .style55
                                                                         {
                                                                             height: 33px;
                                                                             font-weight: bold;
                                                                             font-size: medium;
                                                                             color: #006600;
                                                                         }
                                                                         -->
</style></head>
<body>
    <form name="form1" id="form1" runat="server">
    <div style="width: 870px">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
            <br />
        <table class="style49">
            <tr>
                <td class="style54">
                </td>
                <td class="style55">
                    Ranking Geral de Investimentos Virtuais</td>
            </tr>
            <tr>
                <td class="style53">
                    &nbsp;</td>
                <td>
        <asp:Repeater ID="RptRanking" runat="server">
        
        
        <HeaderTemplate>
<table border=0 cellspacing=0  cellpadding=5 >
<tr bgcolor='#DDDDDD' >
<td><b>Posição</b></td>
<td><b>Nome</b></td>
<td><b>Valor</b></td>
</tr>
</HeaderTemplate>

<ItemTemplate>
<tr>
<td align=right > <%# DataBinder.Eval(Container.DataItem, "Pos") %> </td>
<td> <%# DataBinder.Eval(Container.DataItem, "Nome") %> </td>
<td align=right > <%# DataBinder.Eval(Container.DataItem, "Valor") %> </td>
</tr>
</ItemTemplate>

<FooterTemplate>
</table>
</FooterTemplate>

</asp:Repeater>

                    <br />
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="VirtualEducard.aspx">Voltar</asp:HyperLink>

                </td>
            </tr>
        </table>
        <br />

        <br />
        <br />

        <br />


        </asp:Repeater>
    </div>
</form>
</body>
</html>
