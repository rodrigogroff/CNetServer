<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="WebError" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Resposta do servidor ConveyNET</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><style type="text/css">
                                                                         <!--
body {
	background-image: url('fundo_edu.jpg');
	background-repeat: no-repeat;
	
                                                                             font-family: Arial, Helvetica, sans-serif;
                                                                             font-size: small;
                                                                         }
                                                                         -->
</style></head>
<body>
    <form name="form1" id="form1" runat="server">
    <p>
            <asp:Label ID="LblError" runat="server" 
                style="font-weight: 700; color: #CC3300"></asp:Label>
            </p>
    <p>
            <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Voltar 
            à pagina inicial</asp:LinkButton>
            </p>
</form>
</body>
</html>
