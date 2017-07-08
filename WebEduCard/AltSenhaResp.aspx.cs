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

public partial class AltSenhaResp : WebBase
{
    protected void BtnConfirmar ( object sender, EventArgs e )
    {
        if (TxtSenhaNova.Value.ToString().Length < 4)
        {
            LblMsg.Text = "Senha deve ter quatro caracteres";
            return;            
        }

        if (TxtSenhaNova.Value.ToString() != TxtSenhaConfirma.Value.ToString())
        {
            LblMsg.Text = "Confirmação de senha não confere";
            return;
        }

        GetConnection();

        string senha      = var_util.DESCript(TxtSenhaAtual.Value.PadLeft ( 8, '*' ), "12345678" );
        string nova_senha = var_util.DESCript(TxtSenhaNova.Value.PadLeft  ( 8, '*' ), "12345678" );

        try
        {
            var_exchange.web_exec_alterSenhaEdu (   Session["st_cpf"].ToString(), 
                                                    senha, 
                                                    nova_senha,
                                                    SyCrafEngine.Context.TRUE );

            LblMsg.Text = var_exchange.m_Client.GetServerMessage();

            var_exchange.m_Client.ExitSession();

            Session["st_senha"] = nova_senha;
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
