using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using SyCrafEngine;
using Client;

public partial class Login : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            Session.Clear();
        }
    }

    protected void BtnConfirmar_Click(object sender, EventArgs e)
    {
        string pass = TxtPass.Value;
        
        if (TxtAssoc.Text.Length == 0 )
        {
            Session["st_error"] = "Informar corretamente a sua associação";
            Session["st_error_dest"] = "login.aspx";
            Response.Redirect("error.aspx", true);
            return;
        }

        if ( TxtMat.Text.Length == 0)
        {
            Session["st_error"] = "Informar corretamente a sua matrícula";
            Session["st_error_dest"] = "login.aspx";
            Response.Redirect("error.aspx", true);
            return;
        }

        if (TxtTit.Text.Length == 0)
        {
            Session["st_error"] = "Informar corretamente a sua matrícula";
            Session["st_error_dest"] = "login.aspx";
            Response.Redirect("error.aspx", true);
            return;
        }

        if (pass.Length == 0)
        {
            Session["st_error"] = "Informar corretamente sua senha";
            Session["st_error_dest"] = "login.aspx";
            Response.Redirect("error.aspx", true);
            return;
        }

        try
        {
            string nome = "";

            GetConnection();

            pass = var_util.DESCript(pass, "12345678");

            string cart = TxtAssoc.Text.PadLeft(6, '0') +
                          TxtMat.Text.PadLeft(6, '0') +
                          TxtTit.Text.PadLeft(2, '0');

            if (var_exchange.exec_loginWeb ( cart, pass, ref nome))
            {
                Session["cnpj"] = cart;
                Session["pass"] = pass;
                Session["nome"] = nome;

                var_exchange.m_Client.ExitSession();

                Response.Redirect("extrato.aspx", true);
                return;
            }

            string note = var_exchange.m_Client.GetServerMessage();

            var_exchange.m_Client.ExitSession();

            if (note != "")
            {
                Session["st_error"] = note;
                Session["st_error_dest"] = "login.aspx";
                Response.Redirect("error.aspx", true);
            }
        }
        catch (System.Exception se)
        {
            if (se.Message == "Exit")
            {
                Session["st_error"] = "Esgotado tempo de espera no servidor";
                Session["st_error_dest"] = "login.aspx";
                Response.Redirect("error.aspx", true);
            }
        }
    }
    protected void TxtAssoc_TextChanged(object sender, EventArgs e)
    {

    }
}