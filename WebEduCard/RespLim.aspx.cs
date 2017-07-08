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

public partial class RespLim : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetConnection();

            Label1.Visible = false;

            DadosCartaoEdu dce = new DadosCartaoEdu();

            try
            {
                if (var_exchange.web_fetch_saldo_edu (  Session["st_cartao"].ToString(),
                                                        Session["st_senha"].ToString(),
                                                        SyCrafEngine.Context.TRUE,
                                                        ref dce))
                {
                    LblAluno.Text = "Aluno: " + dce.get_st_aluno();

                    long diario   = Convert.ToInt64(dce.get_vr_diario());
                    long calc_mes = 0;
                    
                    if (dce.get_tg_semanaToda() == SyCrafEngine.Context.TRUE)
                    {
                        rb_tipo.SelectedIndex = 1;
                        calc_mes = diario * 31;
                    }
                    else
                    {
                        rb_tipo.SelectedIndex = 0;
                        calc_mes = diario * 22;
                    }

                    TxtMens.Text = new money().formatToMoney ( calc_mes.ToString() );
                    TxtDir.Value = new money().formatToMoney ( diario.ToString() );
                }

                var_exchange.m_Client.ExitSession();
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

    protected void BtnDefinir_Click(object sender, EventArgs e)
    {
        if (rb_tipo.SelectedIndex == -1)
        {
            Session["st_error"] = "Escolha o tipo de transferência";
            Session["st_error_dest"] = "resplim.aspx";
            Response.Redirect("error.aspx", true);
            return;
        }

        GetConnection();

        try
        {
            long diario = Convert.ToInt64 ( new money().getNumericValue ( TxtDir.Value.ToString() ) );
            long calc_mes = diario * 31;

            if ( rb_tipo.SelectedIndex == 0 )
                calc_mes = diario * 22;

            TxtMens.Text = new money().formatToMoney(calc_mes.ToString());

            var_exchange.web_exec_trocaLim (    Session["st_cartao"].ToString(),
                                                Session["st_senha"].ToString(),
                                                new money().getNumericValue ( TxtDir.Value.ToString() ).ToString(),
                                                rb_tipo.SelectedIndex.ToString() );

            Label1.Visible = true;
            Label1.Text = var_exchange.m_Client.GetServerMessage();

            var_exchange.m_Client.ExitSession();
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

    protected void rb_tipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        long diario = Convert.ToInt64(new money().getNumericValue(TxtDir.Value.ToString()));
        long calc_mes = diario * 31;

        if (rb_tipo.SelectedIndex == 0)
            calc_mes = diario * 22;

        TxtMens.Text = new money().formatToMoney(calc_mes.ToString());
    }
}
