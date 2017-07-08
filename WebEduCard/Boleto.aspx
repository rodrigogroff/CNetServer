<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Boleto.aspx.cs" Inherits="Boleto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">    
<TITLE>Maniezo Webdeveloper</TITLE><META http-equiv=Content-Type content=text/html; charset=windows-1252><meta name=GENERATOR content=NetDinamica><style type=text/css><!--.cp {  font: bold 10px Arial; color: black}
<!--.ti {  font: 9px Arial, Helvetica, sans-serif}
<!--.ld { font: bold 15px Arial; color: #000000}
<!--.ct { FONT: 9px "Arial Narrow"; COLOR: #000033}
<!--.cn { FONT: 9px Arial; COLOR: black }
<!--.bc { font: bold 22px Arial; color: #000000 }
.style1
{
width: 684px;
height: 271px;
background-image: url('fundo_boleto_1.jpg');
}
                                                                                                                                                      .style2
                                                                                                                                                      {
                                                                                                                                                          width: 674px;
                                                                                                                                                          height: 488px;
                                                                                                                                                          background-image: url('fundo_boleto_2.JPG');
                                                                                                                                                      }
                                                                                                                                                      .style7
                                                                                                                                                      {
                                                                                                                                                          height: 164px;
                                                                                                                                                      }
                                                                                                                                                      .style11
                                                                                                                                                      {
                                                                                                                                                          height: 7px;
                                                                                                                                                          text-align: right;
                                                                                                                                                      }
                                                                                                                                                      .style12
                                                                                                                                                      {
                                                                                                                                                          text-align: right;
                                                                                                                                                      }
                                                                                                                                                      .style13
                                                                                                                                                      {
                                                                                                                                                          height: 26px;
                                                                                                                                                          text-align: right;
                                                                                                                                                      }
                                                                                                                                                      .style14
                                                                                                                                                      {
                                                                                                                                                          text-align: right;
                                                                                                                                                          height: 28px;
                                                                                                                                                      }
                                                                                                                                                      .style15
                                                                                                                                                      {
                                                                                                                                                          text-align: right;
                                                                                                                                                          height: 24px;
                                                                                                                                                      }
                                                                                                                                                      .style16
                                                                                                                                                      {
                                                                                                                                                          height: 164px;
                                                                                                                                                          width: 261px;
                                                                                                                                                      }
                                                                                                                                                      .style17
                                                                                                                                                      {
                                                                                                                                                          text-align: right;
                                                                                                                                                          height: 28px;
                                                                                                                                                          width: 261px;
                                                                                                                                                      }
                                                                                                                                                      .style18
                                                                                                                                                      {
                                                                                                                                                          height: 26px;
                                                                                                                                                          text-align: left;
                                                                                                                                                          width: 261px;
                                                                                                                                                      }
                                                                                                                                                      .style19
                                                                                                                                                      {
                                                                                                                                                          text-align: right;
                                                                                                                                                          width: 261px;
                                                                                                                                                      }
                                                                                                                                                      .style20
                                                                                                                                                      {
                                                                                                                                                          height: 7px;
                                                                                                                                                          text-align: right;
                                                                                                                                                          width: 261px;
                                                                                                                                                      }
                                                                                                                                                      .style21
                                                                                                                                                      {
                                                                                                                                                          text-align: right;
                                                                                                                                                          height: 24px;
                                                                                                                                                          width: 261px;
                                                                                                                                                      }
                                                                                                                                                      .style22
                                                                                                                                                      {
                                                                                                                                                          width: 261px;
                                                                                                                                                      }
                                                                                                                                                      .style23
                                                                                                                                                      {
                                                                                                                                                          height: 164px;
                                                                                                                                                          width: 138px;
                                                                                                                                                      }
                                                                                                                                                      .style30
                                                                                                                                                      {
                                                                                                                                                          height: 164px;
                                                                                                                                                          text-align: left;
                                                                                                                                                          width: 338px;
                                                                                                                                                      }
                                                                                                                                                      .style37
                                                                                                                                                      {
                                                                                                                                                          height: 164px;
                                                                                                                                                          width: 62px;
                                                                                                                                                          text-align: left;
                                                                                                                                                      }
                                                                                                                                                      .style39
                                                                                                                                                      {
                                                                                                                                                          height: 26px;
                                                                                                                                                          text-align: right;
                                                                                                                                                          width: 62px;
                                                                                                                                                      }
                                                                                                                                                      .style40
                                                                                                                                                      {
                                                                                                                                                          height: 164px;
                                                                                                                                                          width: 517px;
                                                                                                                                                          text-align: left;
                                                                                                                                                      }
                                                                                                                                                      .style41
                                                                                                                                                      {
                                                                                                                                                          text-align: right;
                                                                                                                                                          height: 28px;
                                                                                                                                                          width: 517px;
                                                                                                                                                      }
                                                                                                                                                      .style42
                                                                                                                                                      {
                                                                                                                                                          height: 26px;
                                                                                                                                                          text-align: right;
                                                                                                                                                          width: 517px;
                                                                                                                                                      }
                                                                                                                                                      .style43
                                                                                                                                                      {
                                                                                                                                                          text-align: right;
                                                                                                                                                          width: 517px;
                                                                                                                                                      }
                                                                                                                                                      .style44
                                                                                                                                                      {
                                                                                                                                                          height: 7px;
                                                                                                                                                          text-align: right;
                                                                                                                                                          width: 517px;
                                                                                                                                                      }
                                                                                                                                                      .style45
                                                                                                                                                      {
                                                                                                                                                          text-align: right;
                                                                                                                                                          height: 24px;
                                                                                                                                                          width: 517px;
                                                                                                                                                      }
                                                                                                                                                      .style46
                                                                                                                                                      {
                                                                                                                                                          width: 517px;
                                                                                                                                                      }
                                                                                                                                                      .style47
                                                                                                                                                      {
                                                                                                                                                          text-align: right;
                                                                                                                                                          height: 28px;
                                                                                                                                                          width: 62px;
                                                                                                                                                      }
                                                                                                                                                      .style48
                                                                                                                                                      {
                                                                                                                                                          text-align: right;
                                                                                                                                                          width: 62px;
                                                                                                                                                      }
                                                                                                                                                      .style49
                                                                                                                                                      {
                                                                                                                                                          height: 7px;
                                                                                                                                                          text-align: right;
                                                                                                                                                          width: 62px;
                                                                                                                                                      }
                                                                                                                                                      .style50
                                                                                                                                                      {
                                                                                                                                                          text-align: right;
                                                                                                                                                          height: 24px;
                                                                                                                                                          width: 62px;
                                                                                                                                                      }
                                                                                                                                                      .style51
                                                                                                                                                      {
                                                                                                                                                          width: 62px;
                                                                                                                                                      }
                                                                                                                                                      .style52
                                                                                                                                                      {
                                                                                                                                                          text-align: right;
                                                                                                                                                          height: 28px;
                                                                                                                                                          width: 338px;
                                                                                                                                                      }
                                                                                                                                                      .style53
                                                                                                                                                      {
                                                                                                                                                          height: 26px;
                                                                                                                                                          text-align: right;
                                                                                                                                                          width: 338px;
                                                                                                                                                      }
                                                                                                                                                      .style54
                                                                                                                                                      {
                                                                                                                                                          text-align: right;
                                                                                                                                                          width: 338px;
                                                                                                                                                      }
                                                                                                                                                      .style55
                                                                                                                                                      {
                                                                                                                                                          height: 7px;
                                                                                                                                                          text-align: right;
                                                                                                                                                          width: 338px;
                                                                                                                                                      }
                                                                                                                                                      .style56
                                                                                                                                                      {
                                                                                                                                                          text-align: right;
                                                                                                                                                          height: 24px;
                                                                                                                                                          width: 338px;
                                                                                                                                                      }
                                                                                                                                                      .style57
                                                                                                                                                      {
                                                                                                                                                          width: 338px;
                                                                                                                                                      }
                                                                                                                                                      .style58
                                                                                                                                                      {
                                                                                                                                                          text-align: right;
                                                                                                                                                          height: 28px;
                                                                                                                                                          width: 138px;
                                                                                                                                                      }
                                                                                                                                                      .style59
                                                                                                                                                      {
                                                                                                                                                          height: 26px;
                                                                                                                                                          text-align: right;
                                                                                                                                                          width: 138px;
                                                                                                                                                      }
                                                                                                                                                      .style60
                                                                                                                                                      {
                                                                                                                                                          text-align: right;
                                                                                                                                                          width: 138px;
                                                                                                                                                      }
                                                                                                                                                      .style61
                                                                                                                                                      {
                                                                                                                                                          height: 7px;
                                                                                                                                                          text-align: right;
                                                                                                                                                          width: 138px;
                                                                                                                                                      }
                                                                                                                                                      .style62
                                                                                                                                                      {
                                                                                                                                                          text-align: right;
                                                                                                                                                          height: 24px;
                                                                                                                                                          width: 138px;
                                                                                                                                                      }
                                                                                                                                                      .style63
                                                                                                                                                      {
                                                                                                                                                          width: 138px;
                                                                                                                                                      }
--></style> 
<meta NAME="keywords" CONTENT="boleto boleta, boleto bancário em PHP ou ASP, ITAU, banco do brasil, bradesco, bbv, real, brb, nossa caixa, cef, unibanco, hsbc, bcn, santander, banerj com codigo fonte incluso em PHP ou ASP, banco cobrança boleto para o banco do brasil, com codigo fonte incluso em PHP ou AS, cobranca bancária bancaria ficha de compensação compensacao codigo código barras 2 de 5 barra pagamento cartao cartão de crédito credito debito cobrar conta corrente banco central fabrabam cnab ">
</head>

<BODY text=#000000 bgColor=#ffffff topMargin=0 rightMargin=0>

    <form id="form1" runat="server">
    <br />
    <table class="style1">
        <tr>
            <td class="style7">
                </td>
            <td class="style16">
                &nbsp;</td>
            <td class="style23">
                &nbsp;</td>
            <td class="style37">
                &nbsp;</td>
            <td class="style40">
                &nbsp;</td>
            <td class="style30">
                </td>
            <td class="style7">
                </td>
        </tr>
        <tr>
            <td class="style14">
                </td>
            <td class="style17">
                &nbsp;</td>
            <td class="style58">
                &nbsp;</td>
            <td class="style47">
                &nbsp;</td>
            <td class="style41">
                &nbsp;</td>
            <td class="style52">
                &nbsp;</td>
            <td class="style14">
                </td>
        </tr>
        <tr>
            <td class="style13">
                </td>
            <td class="style18">
                ADCRED</td>
            <td class="style59">
                &nbsp;</td>
            <td class="style39">
                &nbsp;</td>
            <td class="style42">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td class="style13">
                </td>
        </tr>
        <tr>
            <td class="style12">
                </td>
            <td class="style19">
                &nbsp;</td>
            <td class="style60">
                &nbsp;</td>
            <td class="style48">
                &nbsp;</td>
            <td class="style43">
                &nbsp;</td>
            <td class="style54">
                &nbsp;</td>
            <td class="style12">
                </td>
        </tr>
        <tr>
            <td class="style11">
                </td>
            <td class="style20">
                &nbsp;</td>
            <td class="style61">
                &nbsp;</td>
            <td class="style49">
                &nbsp;</td>
            <td class="style44">
                &nbsp;</td>
            <td class="style55">
                &nbsp;</td>
            <td class="style11">
                </td>
        </tr>
        <tr>
            <td class="style15">
                </td>
            <td class="style21">
                &nbsp;</td>
            <td class="style62">
                &nbsp;</td>
            <td class="style50">
                &nbsp;</td>
            <td class="style45">
                &nbsp;</td>
            <td class="style56">
                &nbsp;</td>
            <td class="style15">
                </td>
        </tr>
        <tr>
            <td class="style11">
                </td>
            <td class="style20">
                &nbsp;</td>
            <td class="style61">
                &nbsp;</td>
            <td class="style49">
                &nbsp;</td>
            <td class="style44">
                &nbsp;</td>
            <td class="style55">
                </td>
            <td class="style11">
                </td>
        </tr>
        <tr>
            <td>
                </td>
            <td class="style22">
                &nbsp;</td>
            <td class="style63">
                &nbsp;</td>
            <td class="style51">
                &nbsp;</td>
            <td class="style46">
                &nbsp;</td>
            <td class="style57">
                &nbsp;</td>
            <td>
                </td>
        </tr>
    </table>
    <br />
    <table class="style2">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    </form>
</BODY></HTML>