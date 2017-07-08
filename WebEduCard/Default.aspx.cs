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

public partial class Default : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            Session.Clear();
        }
    }

    protected void BtnConfirmar ( object sender, EventArgs e )
    {
        GetConnection();

        try
        {
            string senha = ""; 
            string tg_resp = "";

            if (TxtCartao.Text.Length > 0)
            {
                senha = var_util.DESCript(TxtSenhaAluno.Value.PadLeft(8, '*'), "12345678");
            }
            else
            {
                senha = var_util.DESCript(TxtSenhaResp.Value.PadLeft(8, '*'), "12345678");
            }

            if ( var_exchange.web_fetch_edu_inicial (   TxtCPF.Text,
                                                        TxtCartao.Text,
                                                        senha,
                                                        Context.Request.UserHostAddress.ToString(),
                                                        ref tg_resp ) )
            {
                var_exchange.m_Client.ExitSession();

                Session[ "st_senha"  ] = senha;
                Session[ "st_cpf"    ] = TxtCPF.Text;
                Session[ "st_cartao" ] = TxtCartao.Text;

                if ( tg_resp == SyCrafEngine.Context.TRUE )
                {
                    Response.Redirect("resp.aspx", true);
                }
                else
                {
                    Response.Redirect("forum.aspx", true);
                }
            }
            else
            {
                var_exchange.m_Client.ExitSession();

                Session["st_error"] = var_exchange.m_Client.GetServerMessage();
                Session["st_error_dest"] = "default.aspx";
                Response.Redirect("error.aspx", true);
            }
        }
        catch (System.Exception se)
        {
            if (se.Message == "Exit")
            {
                Session["st_error"] = "Esgotado tempo de espera no servidor";
                Session["st_error_dest"] = "default.aspx";
                Response.Redirect("error.aspx", true);
            }
        }              
    }
}
