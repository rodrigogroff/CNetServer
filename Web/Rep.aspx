<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rep.aspx.cs" Inherits="Rep" %>
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
                                                                         .style1
                                                                         {
                                                                             width: 88%;
                                                                             height: 30px;
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
                                                                         .style20
                                                                         {
                                                                             width: 120px;
                                                                             margin-left: 80px;
                                                                             height: 41px;
                                                                         }
                                                                         .style21
                                                                         {
                                                                             width: 118px;
                                                                             height: 41px;
                                                                         }
                                                                         .style22
                                                                         {
                                                                             width: 239px;
                                                                             height: 41px;
                                                                         }
                                                                         .style23
                                                                         {
                                                                             width: 35%;
                                                                         }
                                                                         .style24
                                                                         {
                                                                             text-align: center;
                                                                             margin-left: 80px;
                                                                         }
                                                                         .style25
                                                                         {
                                                                             width: 100%;
                                                                         }
                                                                         .style26
                                                                         {
                                                                             color: #333399;
                                                                         }
                                                                         -->
</style></head>
<body>
    <form name="form1" id="form1" runat="server">
                <table align="center" class="style23">
                    <tr>
                        <td>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/logotipo_conveynet.jpg" 
                    style="text-align: center" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style24">
                <asp:Label ID="LblNome" runat="server" ForeColor="#006600" 
                    style="font-weight: 700" Text="Label"></asp:Label>
                            <b><span class="style26">
                            <br />
                            <br />
                            Relatório de transações a serem
                            <br />
                            repassadas pela associação<br />
                            <br />
                            </span></b>
                        </td>
                    </tr>
                    <tr>
                        <td class="style24">
    <table class="style1">
        <tr>
            <td class="style20">
    
    
                <asp:Label ID="LblMes" runat="server">Mês</asp:Label>
                <br />
                <asp:TextBox ID="TxtMes" runat="server" Width="71px"></asp:TextBox>
                </td>
            <td class="style21">
    
    
                <asp:Label ID="LblAno" runat="server">Ano</asp:Label>
                <br />
                <asp:TextBox ID="TxtAno" runat="server" Width="67px"></asp:TextBox>
                </td>
            <td class="style22">
    
    
                <asp:Label ID="LblAssoc" runat="server">Associação</asp:Label>
                <br />
                <asp:DropDownList ID="CboEmp" runat="server">
                </asp:DropDownList>
                <br />
                </td>
        </tr>
        </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="style24">
                            <br />
    
    
                <asp:Button ID="BtnConsultaRep" runat="server" onclick="BtnRepasse_Click" 
                    Text="Consultar Repasse" Width="174px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style24">
    
    
                <asp:Button ID="BtnVoltar" runat="server" onclick="BtnVoltar_Click" 
                    Text="Voltar" Width="174px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style24">
                            &nbsp;</td>
                    </tr>
                </table>
                <table align="center" class="style25">
                    <tr>
                        <td style="text-align: center">
    
    
                <asp:Label ID="LblTot" runat="server"></asp:Label>
                            <br />
                            <br />
    
    
    <asp:Repeater ID="RptRepassse" runat="server">
        
        
        <HeaderTemplate>
<table border=0 cellspacing=0  cellpadding=5 >
<tr bgcolor='#DDDDDD' >

<td><b>Data</b></td>
<td><b>NSU</b></td>
<td><b>Cartão</b></td>
<td><b>Valor R$</b></td>
<td><b>Ind. Parcela</b></td>
<td><b>Repasse R$</b></td>
</tr>
</HeaderTemplate>

<ItemTemplate>
<tr>
<td> <%# DataBinder.Eval(Container.DataItem, "Data") %> </td>
<td> <%# DataBinder.Eval(Container.DataItem, "NSU") %> </td>
<td> <%# DataBinder.Eval(Container.DataItem, "Cartao") %> </td>
<td> <%# DataBinder.Eval(Container.DataItem, "Valor") %> </td>
<td> <%# DataBinder.Eval(Container.DataItem, "IndParc") %> </td>
<td> <%# DataBinder.Eval(Container.DataItem, "Repasse") %> </td>
</tr>
</ItemTemplate>

<FooterTemplate>
</table>
</FooterTemplate>

</asp:Repeater>

    
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
    
    
            <br />
    <br />
</form>
</body>
</html>
