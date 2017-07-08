<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RespExt.aspx.cs" Inherits="RespExt" %>

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
                                                                             width: 290px;
                                                                             height: 42px;
                                                                         }
                                                                         #TxtSenha
                                                                         {
                                                                             width: 148px;
                                                                             margin-left: 0px;
                                                                         }
                                                                         .style18
                                                                         {
                                                                             width: 7px;
                                                                             height: 29px;
                                                                         }
                                                                         .style19
                                                                         {
                                                                             width: 106px;
                                                                             height: 29px;
                                                                         }
                                                                         .style20
                                                                         {
                                                                             width: 76px;
                                                                             height: 29px;
                                                                         }
                                                                         .style22
                                                                         {
                                                                             width: 6px;
                                                                             height: 29px;
                                                                         }
                                                                         .style23
                                                                         {
                                                                             width: 76px;
                                                                             height: 25px;
                                                                         }
                                                                         .style25
                                                                         {
                                                                             height: 25px;
                                                                             width: 7px;
                                                                         }
                                                                         .style27
                                                                         {
                                                                             height: 25px;
                                                                             width: 6px;
                                                                         }
                                                                         .style28
                                                                         {
                                                                             height: 25px;
                                                                             width: 106px;
                                                                         }
                                                                         .style33
                                                                         {
                                                                             height: 12px;
                                                                             width: 106px;
                                                                             font-weight: 700;
                                                                             color: #339933;
                                                                         }
                                                                         .style41
                                                                         {
                                                                             font-weight: normal;
                                                                         }
                                                                         .style43
                                                                         {
                                                                             width: 106px;
                                                                             font-weight: 700;
                                                                             }
                                                                         .style46
                                                                         {
                                                                             width: 7px;
                                                                             height: 12px;
                                                                         }
                                                                         .style47
                                                                         {
                                                                             width: 6px;
                                                                             height: 12px;
                                                                         }
                                                                         .style48
                                                                         {
                                                                             width: 76px;
                                                                             height: 12px;
                                                                         }
                                                                         .style49
                                                                         {
                                                                             width: 93%;
                                                                         }
                                                                         .style50
                                                                         {
                                                                             width: 313px;
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
                                                                         }
                                                                         .style56
                                                                         {
                                                                             width: 7px;
                                                                             }
                                                                         .style57
                                                                         {
                                                                             width: 6px;
                                                                             }
                                                                         .style58
                                                                         {
                                                                             width: 76px;
                                                                         }
                                                                         .style59
                                                                         {
                                                                             height: 22px;
                                                                         }
                                                                         .style60
                                                                         {
                                                                             font-family: Tahoma;
                                                                         }
                                                                         .style63
                                                                         {
                                                                             width: 290px;
                                                                             height: 24px;
                                                                         }
                                                                         .style64
                                                                         {
                                                                             height: 24px;
                                                                         }
                                                                         .style65
                                                                         {
                                                                             width: 782px;
                                                                             height: 24px;
                                                                         }
                                                                         .style67
                                                                         {
                                                                             width: 782px;
                                                                             height: 24px;
                                                                             font-family: Tahoma;
                                                                             color: #339933;
                                                                         }
                                                                         .style68
                                                                         {
                                                                             font-size: xx-small;
                                                                         }
                                                                         .style69
                                                                         {
                                                                             color: #999999;
                                                                         }
-->
</style></head>
<body>
    <form name="form1" id="form1" runat="server">
    <div style="width: 797px">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Resp.aspx">Voltar à 
        lista de alunos</asp:HyperLink>
        <br />
        <br />
        <table class="style49" >
            <tr valign=top>
                <td class="style50">
        <table class="style3" cellspacing=0 cellpadding=1>
            <tr  valign=top>
                <td class="style59">
                </td>
                <td class="style59" colspan="2">
            <asp:Label ID="Label1" runat="server" Text="LblSaldo" 
                    style="font-weight: 700; color: #000099"></asp:Label>
                </td>
            </tr>
            <tr bgcolor='#DDDDDD'>
                <td class="style64">
                </td>
                <td class="style65">
                    <span class="style60">Valor disponível para uso</td>
                <td class="style63">
                    <asp:Label ID="TxtVrDisp" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr >
                <td class="style64">
                </td>
                <td class="style65">
                    Valor diário definido</td>
                <td class="style63">
                    <asp:Label ID="TxtVrDispDiario" runat="server" style="font-weight: 700" 
                        Text="Label"></asp:Label>
                </td>
            </tr>
            <tr >
                <td class="style64">
                    </td>
                <td class="style65">
                    &nbsp;</td>
                <td class="style63">
                    &nbsp;</td>
            </tr>
            <tr >
                <td class="style64">
                    </td>
                <td class="style65">
                    <span class="style60">Valor mensal definido *</span></td>
                <td class="style63">
                    <span class="style60">
                    <asp:Label ID="TxtVrDispMensal" runat="server" 
                        Text="Label"></asp:Label>
                    </span>
                </td>
            </tr>
            <tr >
                <td class="style64">
                    </td>
                <td class="style65">
                    <span class="style60">Saldo até o fim do mês *</span></td>
                <td class="style63">
                    <span class="style60">
                    <asp:Label ID="TxtVrSaldoMes" runat="server" 
                        Text="Label"></asp:Label>
                    </span>
                </td>
            </tr>
            <tr >
                <td class="style64">
                    &nbsp;</td>
                <td class="style67">
                    Saldo a liberar em fundo **</td>
                <td class="style63">
                    <span class="style60">
                    <asp:Label ID="TxtSaldoTotal" runat="server" style="color: #339933;" 
                        Text="Label"></asp:Label>
                    </span>
                </td>
            </tr>
        </table>
                        <br />
                        <span class="style68"><span class="style69">* Valores calculados com base em valor diário</span><br 
                        class="style69" />
                    <span class="style69">** Valores depositados em fundo educacional</span></span></span></td>
                    <td>
        <table class="style3">
            <tr>
                <td class="style46">
                </td>
                <td class="style33">
                    Extrato</td>
                <td class="style47">
                    </td>
                <td class="style48">
                    </td>
                <td class="style48">
                    </td>
            </tr>
            <tr>
                <td class="style18">
                </td>
                <td class="style19">
                    Período Inicial </td>
                <td class="style22">
                    </td>
                <td class="style20">
                    Período Final</td>
                <td class="style20">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style25">
                </td>
                <td class="style28">
                    <asp:Calendar ID="DtIni" runat="server" BackColor="#FFFFCC" 
                        BorderColor="#FFCC66" DayNameFormat="Shortest" 
                        Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="115px" 
                        Width="151px" BorderWidth="1px" ShowGridLines="True">
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
                </td>
                <td class="style27">
                    &nbsp;</td>
                <td class="style23">
                    <asp:Calendar ID="DtFim" runat="server" BackColor="#FFFFCC" 
                        BorderColor="#FFCC66" DayNameFormat="Shortest" 
                        Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="16px" 
                        Width="16px" BorderWidth="1px" ShowGridLines="True">
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
                </td>
                <td class="style23">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style56">
                    </td>
                <td class="style43">
                    <span class="style41">Senha</span></td>
                <td class="style57">
                    </td>
                <td class="style58">
                    </td>
                <td class="style58">
                    </td>
            </tr>
            <tr>
                <td class="style25">
                    &nbsp;</td>
                <td class="style28">
                    <input id="TxtSenha" type="password" runat="server"></td>
                <td class="style27">
                    &nbsp;</td>
                <td class="style23">
                    <asp:Button ID="Button1" runat="server" Text="Confirmar" Width="77px" 
                        onclick="BtnConfirmar" />
                </td>
                <td class="style23">
                    &nbsp;</td>
            </tr>
            </table>
                    </td>
                </tr>
            </table>
            <br />
        <table class="style49">
            <tr>
                <td class="style54">
                </td>
                <td class="style55">
            <asp:Label ID="LblExtrato" runat="server" Text="LblSaldo" 
                    style="font-weight: 700; color: #339933"></asp:Label>

                </td>
            </tr>
            <tr>
                <td class="style53">
                    &nbsp;</td>
                <td>
        <asp:Repeater ID="RptExtrato" runat="server">
        
        
        <HeaderTemplate>
<table border=0 cellspacing=0  cellpadding=5 >
<tr bgcolor='#DDDDDD' >
<td><b>NSU</b></td>
<td><b>Data</b></td>
<td><b>Valor R$</b></td>
<td><b>Loja</b></td>
<td><b>Saldo R$</b></td>
<td><b>Fundo R$</b></td>
<td><b>Operação</b></td>
</tr>
</HeaderTemplate>

<ItemTemplate>
<tr>
<td align=right > <%# DataBinder.Eval(Container.DataItem, "Nsu") %> </td>
<td> <%# DataBinder.Eval(Container.DataItem, "Data") %> </td>
<td align=right > <%# DataBinder.Eval(Container.DataItem, "Valor") %> </td>
<td> <%# DataBinder.Eval(Container.DataItem, "Loja") %> </td>
<td align=right > <%# DataBinder.Eval(Container.DataItem, "Saldo") %> </td>
<td align=right > <%# DataBinder.Eval(Container.DataItem, "Fundo") %> </td>
<td> <%# DataBinder.Eval(Container.DataItem, "Operacao") %> </td>
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


        </asp:Repeater>
    </div>
</form>
</body>
</html>
