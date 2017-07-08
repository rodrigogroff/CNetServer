<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Forum.aspx.cs" Inherits="Forum" %>

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
                                                                             width: 111%;
                                                                         }
                                                                         .style54
                                                                         {
                                                                             height: 33px;
                                                                             width: 176px;
                                                                         }
                                                                         .style55
                                                                         {
                                                                             height: 33px;
                                                                             font-weight: bold;
                                                                             font-size: medium;
                                                                             color: #006600;
                                                                         }
                                                                         .style56
                                                                         {
                                                                             width: 457px;
                                                                             height: 156px;
                                                                         }
                                                                         .style57
                                                                         {
                                                                             height: 33px;
                                                                             width: 20px;
                                                                         }
                                                                         .style58
                                                                         {
                                                                             width: 234px;
                                                                         }
                                                                         .style60
                                                                         {
                                                                             font-family: Georgia;
                                                                             font-weight: normal;
                                                                         }
                                                                         .style61
                                                                         {
                                                                             height: 33px;
                                                                             width: 18px;
                                                                         }
                                                                         .style30
                                                                         {
                                                                             font-size: x-large;
                                                                             color: #006600;
                                                                         }
                                                                         .style28
                                                                         {
                                                                             font-size: medium;
                                                                         }
                                                                         .style62
                                                                         {
                                                                             color: #006600;
                                                                         }
                                                                         .style63
                                                                         {
                                                                             height: 33px;
                                                                             width: 50px;
                                                                         }
                                                                         -->
</style></head>
<body bgcolor="#ffffff">
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
        <table class="style49" align="center" bgcolor="White" >
            <tr valign=top >
                <td class="style54">
                    <asp:Label ID="LblAluno" runat="server" 
                        style="font-family: Georgia; color: #333333">Rodrigo Groff</asp:Label>
                    <br />
                    <br style="font-size: xx-small" />
                    <asp:Image ID="ImgAluno" runat="server" Height="180px" ImageUrl='avatar.jpg' Width="150px" />
                    <br />
                    <asp:Label ID="lblPoints" runat="server" 
                        style="font-weight: 700; font-family: Arial">1020 pontos</asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="BtnCartao" Width = 170 runat="server" Text="Educard" 
                        onclick="BtnCartao_Click" />
                    <br />
                    <br />
                    <asp:Button ID="BtnDebate" Width = 170 runat="server" Text="Meus Debates(4)" />
                    <br />
                    <asp:Button ID="BtnClubes" Width = 170 runat="server" Text="Meus Clubes(2)" />
                    <br />
                    <asp:Button ID="BtnPodCasts" Width = 170px runat="server" 
                        Text="Meus Podcasts(13)" Height="26px" />
                    <br />
                    <br />
                    <asp:Button ID="BtnAvatar" Width = 170 runat="server" 
                        Text="Alterar Avatar" />
                </td>
                <td class="style61">
                    &nbsp;</td>
                <td class="style57">
                    <table class="style56">
                        <tr valign=top>
                            <td class="style58">
                                <asp:ImageButton ImageUrl="atualidades.jpg" ID="ImgAtu" runat="server" />
                            </td>
                            <td class="style60">
                                Debate aberto sobre assuntos que estão acontecendo no mundo e no Brasil. </td>
                        </tr>
                        <tr valign=top >
                            <td class="style58">
                                <asp:ImageButton ImageUrl="debates.jpg" ID="ImgDeb" runat="server" />
                            </td>
                            <td class="style60">
                                Lugar onde todos podem colocar sua opinião sobre qualquer assunto.</td>
                        </tr>
                        <tr valign=top >
                            <td class="style58">
                                <asp:ImageButton ImageUrl="clubes.jpg" ID="ImgClubes" runat="server" />
                            </td>
                            <td class="style60">
                                Grupos de alunos podem abrir seus próprios clubes destinados a tópicos  
                                com conteúdo privado.
                            </td>
                        </tr>
                        <tr valign=top >
                            <td class="style58">
                                <asp:ImageButton ImageUrl="podcasts.jpg" ID="ImgPod" runat="server" />
                            </td>
                            <td class="style60">
                                Grave suas experiências e opiniões e faça seu próprio show, tal como acontece no 
                                rádio.</td>
                        </tr>
                    </table>
                    </td>
                <td class="style63">
                    &nbsp;</td>
                <td class="style55" valign=top >
                    <b><span class="style62">Noticias e eventos</span><span class="style30"> </span></b><span class="style28">
                    <br />
                    <asp:Label ID="LblTit1" runat="server" 
                        style="font-weight: 700; color: #CC0000; font-size: small;" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="LblMsg1" runat="server" Text="Label" 
                        style="color: #333333; font-size: small;"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="LblTit2" runat="server" 
                        style="font-weight: 700; color: #CC0000; font-size: small;" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="LblMsg2" runat="server" Text="Label" 
                        style="color: #000000; font-size: small;"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="LblTit3" runat="server" 
                        style="font-weight: 700; color: #CC0000; font-size: small;" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="LblMsg3" runat="server" Text="Label" 
                        style="color: #000000; font-size: small;"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="LblTit4" runat="server" 
                        style="font-weight: 700; color: #CC0000; font-size: small;" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="LblMsg4" runat="server" Text="Label" 
                        style="color: #000000; font-size: small;"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="LblTit5" runat="server" 
                        style="font-weight: 700; color: #CC0000; font-size: small;" Text="Label"></asp:Label>
                    <br />
                    </span>
                    <asp:Label ID="LblMsg5" runat="server" Text="Label" 
                        style="color: #000000; font-size: small;"></asp:Label>
                </td>
            </tr>
            </table>
    </div>
</form>
</body>
</html>
