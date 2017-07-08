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

public partial class LoginLojista : WebBase
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

        if (pass.Length == 0)
        {
            Session["st_error"] = "Informar corretamente a senha de sua loja";
            Session["st_error_dest"] = "loginlojista.aspx";
            Response.Redirect("error.aspx", true);
            return;
        }

        if (TxtCNPJ.Text.Length == 0)
        {
            Session["st_error"] = "Informar corretamente o cnpj de sua loja";
            Session["st_error_dest"] = "loginlojista.aspx";
            Response.Redirect("error.aspx", true);
            return;
        }

        GetConnection();

        try
        {
            string nome = "";

            if (var_exchange.exec_loginLojista(TxtCNPJ.Text, pass, ref nome))
            {
                Session["cnpj"] = TxtCNPJ.Text;
                Session["pass"] = pass;
                Session["nome"] = nome;

                var_exchange.m_Client.ExitSession();

                Response.Redirect("Decide.aspx", true);
                return;
            }

            string note = var_exchange.m_Client.GetServerMessage();

            var_exchange.m_Client.ExitSession();

            if (note != "")
            {
                Session["st_error"] = note;
                Session["st_error_dest"] = "loginlojista.aspx";
                Response.Redirect("error.aspx", true);
            }
        }
        catch (System.Exception se)
        {
            if (se.Message == "Exit")
            {
                Session["st_error"] = "Esgotado tempo de espera no servidor";
                Session["st_error_dest"] = "loginlojista.aspx";
                Response.Redirect("error.aspx", true);
            }
        }
    }
}