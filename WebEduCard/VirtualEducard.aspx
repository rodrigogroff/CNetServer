<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VirtualEducard.aspx.cs" Inherits="VirtualEducard" %>

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
                                                                         .style3
                                                                         {
                                                                             width: 260px;
                                                                             height: 126px;
                                                                             margin-right: 11px;
                                                                         }
                                                                         #TxtSenha
                                                                         {
                                                                             width: 148px;
                                                                             margin-left: 0px;
                                                                         }
                                                                         .style83
                                                                         {
                                                                             height: 25px;
                                                                             font-family: Arial, Helvetica, sans-serif;
                                                                         }
                                                                         .style85
                                                                         {
                                                                             height: 28px;
                                                                             font-weight: bold;
                                                                             color: #006600;
                                                                             font-size: medium;
                                                                         }
                                                                         .style99
                                                                         {
                                                                             height: 2px;
                                                                         }
                                                                         .style100
                                                                         {
                                                                             height: 2px;
                                                                             font-family: Tahoma;
                                                                             width: 776px;
                                                                         }
                                                                         .style101
                                                                         {
                                                                             width: 290px;
                                                                             height: 2px;
                                                                         }
                                                                         .style104
                                                                         {
                                                                             width: 776px;
                                                                             height: 22px;
                                                                             font-family: Tahoma;
                                                                         }
                                                                         .style105
                                                                         {
                                                                             width: 290px;
                                                                             height: 22px;
                                                                         }
                                                                         .style107
                                                                         {
                                                                             font-family: Tahoma;
                                                                         }
                                                                         .style111
                                                                         {
                                                                             height: 22px;
                                                                             }
                                                                         .style117
                                                                         {
                                                                             font-size: large;
                                                                             font-weight: bold;
                                                                         }
                                                                         .style126
                                                                         {
                                                                             height: 25px;
                                                                             font-family: Tahoma;
                                                                             width: 126px;
                                                                         }
                                                                         #TxtVrCompra
                                                                         {
                                                                             width: 96px;
                                                                         }
                                                                         #TxtVrVenda
                                                                         {
                                                                             width: 96px;
                                                                         }
                                                                         .style141
                                                                         {
                                                                             font-size: small;
                                                                             color: #333333;
                                                                         }
                                                                         .style144
                                                                         {
                                                                             font-size: small;
                                                                             }
                                                                         .style151
                                                                         {
                                                                             width: 116px;
                                                                             height: 25px;
                                                                         }
                                                                         .style153
                                                                         {
                                                                         }
                                                                         .style154
                                                                         {
                                                                             height: 25px;
                                                                         }
                                                                         .style157
                                                                         {
                                                                             height: 28px;
                                                                             color: #666666;
                                                                             font-size: x-small;
                                                                         }
                                                                         .style158
                                                                         {
                                                                             color: #999999;
                                                                             font-size: x-small;
                                                                         }
                                                                         .style159
                                                                         {
                                                                             font-weight: normal;
                                                                             font-size: x-small;
                                                                             color: #666666;
                                                                         }
                                                                         .style161
                                                                         {
                                                                             width: 3px;
                                                                         }
                                                                         .style163
                                                                         {
                                                                             font-size: medium;
                                                                             font-weight: bold;
                                                                         }
                                                                         .style164
                                                                         {
                                                                             width: 935px;
                                                                         }
                                                                         .style166
                                                                         {
                                                                             height: 2px;
                                                                             font-family: Tahoma;
                                                                             width: 776px;
                                                                             font-weight: bold;
                                                                         }
                                                                         .style167
                                                                         {
                                                                             width: 657px;
                                                                         }
                                                                         .style169
                                                                         {
                                                                             width: 105px;
                                                                         }
                                                                         .style170
                                                                         {
                                                                             width: 136px;
                                                                         }
-->
</style></head>
<body>
    <form name="form1" id="form1" runat="server">
    <div style="width: 987px">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <span class="style117">Aplicações Virtuais</span>
        <br />
        <span class="style158">Todos os valores apresentados na página são fictícios.</span><br />
        <br />
        <table style="width: 984px" >
            <tr valign=top>
                <td class="style169">
            <asp:Label ID="LblAluno" runat="server" 
                    style="font-weight: 700; color: #000099; font-size: medium;"></asp:Label>
                    <br />
                    </td>
                <td class="style167">

                    <span class="style163">Carteira de Investimentos</span><br />

                    </td>
                <td class="style161">

                    &nbsp;</td>
                </tr>
            <tr valign=top>
                <td class="style169">
        <table class="style3" cellspacing=0 cellpadding=1>
            <tr >
                <td class="style111">
                </td>
                <td class="style104">
                    Saldo disponível</td>
                <td class="style105">
                    <asp:Label ID="TxtVrDispVirtual" runat="server" style="font-weight: 700"></asp:Label>
                    </span>
                </td>
            </tr>
            <tr >
                <td class="style99">
                </td>
                <td class="style100">
                    Valor na carteira</td>
                <td class="style101">
                    <asp:Label ID="TxtVrTotalInv" runat="server" style="font-weight: 700"></asp:Label>
                    </span>
                </td>
            </tr>
            <tr >
                <td class="style99">
                    &nbsp;</td>
                <td class="style166">
                    Total</td>
                <td class="style101">
                    <asp:Label ID="TxtVrTotal" runat="server" 
                        style="font-weight: 700; color: #006600;"></asp:Label>
                </td>
            </tr>
            <tr >
                <td class="style99">
                    &nbsp;</td>
                <td class="style100">
                    % Rentabilidade</td>
                <td class="style101">
                    <asp:Label ID="TxtPctRend" runat="server" 
                        style="font-weight: 700; color: #006600;"></asp:Label>
                                </td>
            </tr>
            <tr >
                <td class="style99">
                    &nbsp;</td>
                <td class="style100">
                    &nbsp;</td>
                <td class="style101">
                    &nbsp;</td>
            </tr>
            <tr >
                <td class="style99">
                    &nbsp;</td>
                <td class="style100">
                    <asp:LinkButton ID="LnkAltSenha" runat="server" onclick="LnkSenha_Click">Trocar 
                    Senha</asp:LinkButton>
                                </td>
                <td class="style101">
                    &nbsp;</td>
            </tr>
            <tr >
                <td class="style99">
                    &nbsp;</td>
                <td class="style100">
                    <asp:LinkButton ID="LnkRanking" runat="server" onclick="LnkRanking_Click">Ranking</asp:LinkButton>
                                </td>
                <td class="style101">
                    &nbsp;</td>
            </tr>
            </table>
                        <br />
                    <br />

                    </td>
                <td class="style167">

                    <span class="style144">
        <asp:Repeater ID="RptEmpresas" runat="server">
        
        
        <HeaderTemplate>
<table border=0 cellspacing=5  cellpadding=5 >
<tr bgcolor='#C5D1FD' >
<td><b>Nome</b></td>
<td><b>Ações</b></td>
<td><b>Oscilação</b></td>
<td><b>Cotação</b></td>
<td><b>Valor Atual</b></td>
<td><b>Preço Médio.</b></td>
<td><b>Custo Médio.</b></td>
<td><b>% Rent. Ação.</b></td>
</tr>
</HeaderTemplate>

<ItemTemplate>
<tr>
<td align=right > <%# DataBinder.Eval(Container.DataItem, "Nome") %> </td>
<td align=right > <%# DataBinder.Eval(Container.DataItem, "Acoes") %> </td>
<td align=right > <%# DataBinder.Eval(Container.DataItem, "Osc") %> </td>
<td align=right > <%# DataBinder.Eval(Container.DataItem, "VrDia") %> </td>
<td align=right > <%# DataBinder.Eval(Container.DataItem, "Invest") %> </td>
<td align=right > <%# DataBinder.Eval(Container.DataItem, "PMedio") %> </td>
<td align=right > <%# DataBinder.Eval(Container.DataItem, "CMedio") %> </td>
<td align=right > <%# DataBinder.Eval(Container.DataItem, "Rent") %> </td>
</tr>
</ItemTemplate>

<FooterTemplate>
</table>
</FooterTemplate>

</asp:Repeater>

                        </span>

                    </td>
                <td class="style161">

                    &nbsp;</td>
                </tr>
            </table>

        <table class="style164">
            <tr>
                <td class="style170">

        <table cellspacing=0 cellpadding=1 
            style="width: 789px; height: 173px; margin-right: 10px;">
            <tr  valign=top>
                <td class="style85" colspan="2">
                    Investimentos e Resgates<br />
                    <span class="style159">Custo de 25 centavos virtuais por operação<br />
                    <br />
                    </span>

                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl="ClassifSetorial.html" style="font-size: small">Lista de códigos 
                    de empresas</asp:HyperLink>
                                <br />
                                </td>
                <td class="style157">

                    &nbsp;</td>
                <td class="style153" rowspan="6">

                    <asp:Label ID="LblDiaMov" runat="server" 
                        style="color: #006600; font-weight: 700; font-size: medium;"></asp:Label>

                    <span class="style141">
                    <br />
                    <asp:Calendar ID="DtIni" runat="server" BackColor="#FFFFCC" 
                        BorderColor="#FFCC66" DayNameFormat="Shortest" 
                        Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="150px" 
                        Width="200px" BorderWidth="1px" ShowGridLines="True" 
                            style="text-align: left" onselectionchanged="DtIni_SelectionChanged">
                        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                        <SelectorStyle BackColor="#FFCC66" />
                        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#CC9966" />
                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
                            ForeColor="#FFFFCC" />
                    </asp:Calendar>
                    <br />
                    <asp:LinkButton ID="LnkUpdate" runat="server" onclick="LnkUpdate_Click" >Movimentação 
                    de fundos nesta data</asp:LinkButton>

                    <br />
        <asp:Repeater ID="RptExtrato" runat="server" onitemcommand="RptExtrato_ItemCommand">
        
        
        <HeaderTemplate>
<table border=0 cellspacing=5  cellpadding=5 >
<tr bgcolor='#FCD581' >
<td><b>Nome</b></td>
<td><b>Mov. Ações</b></td>
<td><b>Total</b></td>
</tr>
</HeaderTemplate>

<ItemTemplate>
<tr>
<td align=right > <%# DataBinder.Eval(Container.DataItem, "Nome") %> </td>
<td align=right > <%# DataBinder.Eval(Container.DataItem, "Mov") %> </td>
<td> <%# DataBinder.Eval(Container.DataItem, "Total") %> </td>
</tr>
</ItemTemplate>

<FooterTemplate>
</table>
</FooterTemplate>

</asp:Repeater>

                    </span>

                    </td>
            </tr>
            <tr >
                <td class="style126">
                    Código da empresa</td>
                <td class="style151">
                    </span>
                    <asp:TextBox ID="TxtCodEmpresa" runat="server" Width="99px"></asp:TextBox>
                </td>
                <td class="style154">
                    <asp:LinkButton ID="LnkHist" runat="server" onclick="LnkHist_Click" >Histórico 
                    Rentabilidade</asp:LinkButton>

                    </td>
            </tr>
            <tr >
                <td class="style107" colspan="2">

                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr >
                <td class="style126">
                    Compra de ações</td>
                <td class="style151">
                    <input id="TxtVrCompra" type="text" runat="server" onkeydown="mascara(this,currfunc)" />
                </td>
                <td class="style154">
                    <asp:Button ID="BtnCompra" runat="server" Text="Compra" 
                        onclick="BtnCompra_Click" Width="80px" />
                </td>
            </tr>
            <tr >
                <td class="style126">Venda de ações</td>
                <td class="style151">
                    <input id="TxtVrVenda" type="text" runat="server" onkeydown="mascara(this,currfunc)" />
                </td>
                <td class="style154">
                    <asp:Button ID="BtnVenda" runat="server" Text="Venda" 
                        onclick="BtnVenda_Click" Width="80px" />
                </td>
            </tr>
            <tr >
                <td class="style83" colspan="3">
                    <br />
        <asp:Repeater ID="RptHist" runat="server">
        
        
        <HeaderTemplate>
<table border=0 cellspacing=5  cellpadding=5 >
<tr bgcolor='#DEDEDE' >
<td><b>Nome</b></td>
<td><b>Rendimento</b></td>
<td><b>Data</b></td>
</tr>
</HeaderTemplate>

<ItemTemplate>
<tr>
<td align=right > <%# DataBinder.Eval(Container.DataItem, "Nome") %> </td>
<td> <%# DataBinder.Eval(Container.DataItem, "Rend") %> </td>
<td align=right > <%# DataBinder.Eval(Container.DataItem, "Data") %> </td>
</tr>
</ItemTemplate>

<FooterTemplate>
</table>
</FooterTemplate>

</asp:Repeater>

                    <br />

                    <br />

                </td>
            </tr>
            </table>

                    </td>
                </tr>
            </table>

            <br />
            <br />

        <br />

    </div>

    <br />

    <p>
        &nbsp;</p>

</form>
</body>
</html>
