<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Trans.aspx.cs" Inherits="Trans" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    protected void TxtMes_TextChanged(object sender, EventArgs e)
    {
            }
</script>

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
                                                                             width: 48%;
                                                                             height: 108px;
                                                                         }
                                                                         .style4
                                                                         {
                                                                             width: 239px;
                                                                             height: 11px;
                                                                         }
                                                                         .style10
                                                                         {
                                                                             width: 151px;
                                                                             margin-left: 80px;
                                                                             height: 11px;
                                                                         }
                                                                         .style16
                                                                         {
                                                                             width: 6px;
                                                                             height: 11px;
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
                                                                         .style23
                                                                         {
                                                                             width: 151px;
                                                                             margin-left: 80px;
                                                                             height: 16px;
                                                                         }
                                                                         .style24
                                                                         {
                                                                             width: 6px;
                                                                             height: 16px;
                                                                         }
                                                                         .style25
                                                                         {
                                                                             width: 239px;
                                                                             height: 16px;
                                                                         }
                                                                         .style26
                                                                         {
                                                                             width: 37%;
                                                                             height: 50px;
                                                                         }
                                                                         .style27
                                                                         {
                                                                             width: 100%;
                                                                         }
                                                                         .style28
                                                                         {
                                                                             color: #333399;
                                                                             font-weight: bold;
                                                                         }
                                                                         -->
</style></head>
<body>
    <form name="form1" id="form1" runat="server">
                <table align="center" class="style26">
                    <tr>
                        <td>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/logotipo_conveynet.jpg" 
                    style="text-align: center" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                <asp:Label ID="LblNome" runat="server" ForeColor="#006600" 
                    style="font-weight: 700; text-align: center;" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <span class="style28">Relatório de transações efetuadas no período</span><br />
                            <br />
    <table class="style1">
        <tr>
            <td class="style10">
                Data Inicial</td>
            <td class="style16">
                </td>
            <td class="style4">
                Data Final</td>
        </tr>
        <tr>
            <td class="style23">
                <asp:Calendar ID="DtIni" runat="server" BackColor="White" 
                    BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                    DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                    ForeColor="#003399" Height="71px" Width="85px">
                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                    <WeekendDayStyle BackColor="#CCCCFF" />
                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                        Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                </asp:Calendar>
            </td>
            <td class="style24">
                </td>
            <td class="style25">
                <asp:Calendar ID="DtFim" runat="server" BackColor="White" 
                    BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                    DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                    ForeColor="#003399" Height="38px" Width="17px">
                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                    <WeekendDayStyle BackColor="#CCCCFF" />
                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                        Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                </asp:Calendar>
            </td>
        </tr>
        </table>
                                <br />
    
    
                <asp:Button ID="BtnConfirmar" runat="server" onclick="BtnConfirmar_Click" 
                    Text="Consultar Transações" Width="177px" />
                                <br />
                                <br />
    
    
                <asp:Button ID="BtnVoltar" runat="server" onclick="BtnVoltar_Click" 
                    Text="Voltar" Width="177px" />
                                <br />
                            </td>
                        </tr>
                    </table>
                    <table align="center" class="style27">
                        <tr>
                            <td style="text-align: center">
                                <br />
    
    
                                <br />
    
    
                <asp:Label ID="LblTot" runat="server"></asp:Label>
                                <br />
                                <br />
    
    
    <asp:Repeater ID="RptExtrato" runat="server">
        
        
        <HeaderTemplate>
<table border=0 cellspacing=0  cellpadding=5 >
<tr bgcolor='#DDDDDD' >

<td><b>Data</b></td>
<td><b>NSU</b></td>
<td><b>Valor R$</b></td>
<td><b>Parcelas</b></td>
<td><b>Situação</b></td>
<td><b>Cartão</b></td>
<td><b>Associação</b></td>
</tr>
</HeaderTemplate>

<ItemTemplate>
<tr>
<td> <%# DataBinder.Eval(Container.DataItem, "Data") %> </td>
<td> <%# DataBinder.Eval(Container.DataItem, "NSU") %> </td>
<td> <%# DataBinder.Eval(Container.DataItem, "Valor") %> </td>
<td> <%# DataBinder.Eval(Container.DataItem, "Parcelas") %> </td>
<td> <%# DataBinder.Eval(Container.DataItem, "Desc") %> </td>
<td> <%# DataBinder.Eval(Container.DataItem, "Cartao") %> </td>
<td> <%# DataBinder.Eval(Container.DataItem, "Assoc") %> </td>
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
</form>
</body>
</html>
