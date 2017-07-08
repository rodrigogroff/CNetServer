<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Resp.aspx.cs" Inherits="Resp" %>

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
                                                                             width: 790px;
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
                                                                             font-weight: bold;
                                                                             text-align: left;
                                                                             width: 80px;
                                                                         }
                                                                         .style24
                                                                         {
                                                                             height: 42px;
                                                                             color: #000099;
                                                                             width: 580px;
                                                                         }
                                                                         .style25
                                                                         {
                                                                             height: 42px;
                                                                             color: #000099;
                                                                             width: 80px;
                                                                         }
                                                                         .style28
                                                                         {
                                                                             font-size: medium;
                                                                         }
                                                                         .style29
                                                                         {
                                                                             font-size: large;
                                                                         }
                                                                         .style30
                                                                         {
                                                                             font-size: x-large;
                                                                             color: #006600;
                                                                         }
                                                                         .style31
                                                                         {
                                                                             font-size: large;
                                                                             font-weight: bold;
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
                <td class="style24">
                    <br />
                    <asp:Label ID="LblResp" runat="server" style="font-weight: 700; color: #990033"></asp:Label>
                    <br />
                    <br />
                    <span class="style31">Lista de alunos vinculados a este CPF</span><br />
                    <br />
                </td>
                <td class="style23" valign=bottom align=left>
                    &nbsp;</td>
            </tr>
            <tr valign=top>
                <td class="style19">
                    &nbsp;</td>
                <td class="style24">
                    <asp:GridView ID="GridAlunos" runat="server" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" Width="722px" OnRowCommand="GridButton" 
                        AutoGenerateColumns="False" >
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#EFF3FB" />
                        <Columns>
                            <asp:BoundField HeaderText="Cartão" DataField="Cartao">
                                <HeaderStyle HorizontalAlign="Left" Width="120px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Nome" HeaderText="Nome" >
                                <HeaderStyle HorizontalAlign="Left" Width="200px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Saldo" HeaderText="Saldo" >
                                <HeaderStyle HorizontalAlign="Left" Width="110px" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Button" Text="Limite" 
                                ShowHeader="True" CommandName="Cred" />
                            <asp:ButtonField ButtonType="Button" Text="Extrato" CommandName="Ext" />
                            <asp:ButtonField ButtonType="Button" Text="Boleto" CommandName="Bol" />
                        </Columns>
                        <PagerStyle BackColor="#2461BF" ForeColor="White" 
                            HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                    <br />
            <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Altere sua 
                    senha</asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="BtnSair" runat="server" onclick="BtnSair_Click">Sair</asp:LinkButton>
                    <br />
                    <br />
                </td>
                <td class="style25" valign=top>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style19">
                    &nbsp;</td>
                <td class="style24">
                    <b><span class="style30">Noticias e eventos das escolas</span><span 
                        class="style29"><br />
                    </span></b><span class="style28">
                    <br />
                    <asp:Label ID="LblTit1" runat="server" 
                        style="font-weight: 700; color: #CC0000;" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="LblMsg1" runat="server" Text="Label" style="color: #333333"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="LblTit2" runat="server" 
                        style="font-weight: 700; color: #CC0000;" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="LblMsg2" runat="server" Text="Label" style="color: #000000"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="LblTit3" runat="server" 
                        style="font-weight: 700; color: #CC0000;" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="LblMsg3" runat="server" Text="Label" style="color: #000000"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="LblTit4" runat="server" 
                        style="font-weight: 700; color: #CC0000;" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="LblMsg4" runat="server" Text="Label" style="color: #000000"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="LblTit5" runat="server" 
                        style="font-weight: 700; color: #CC0000;" Text="Label"></asp:Label>
                    <br />
                    </span>
                    <asp:Label ID="LblMsg5" runat="server" Text="Label" 
                        style="color: #000000; font-size: medium;"></asp:Label>
                    </td>
                <td class="style25">
                    &nbsp;</td>
            </tr>
            </table>
        <br />
        <br />
    </div>
</form>
</body>
</html>
