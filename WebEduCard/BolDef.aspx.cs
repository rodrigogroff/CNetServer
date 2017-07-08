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

public partial class BolDef : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetConnection();

            TxtDisp.Text = "0,00";
                        
            DadosCartaoEdu dce = new DadosCartaoEdu();

            try
            {
                if (var_exchange.web_fetch_saldo_edu (  Session["st_cartao"].ToString(),
                                                        Session["st_senha"].ToString(),
                                                        SyCrafEngine.Context.TRUE,
                                                        ref dce))
                {
                    LblAluno.Text = "Aluno: " + dce.get_st_aluno();

                    long calc_mes = 0;

                    if (dce.get_tg_semanaToda() == SyCrafEngine.Context.TRUE )
                    {
                        calc_mes = Convert.ToInt64(dce.get_vr_diario()) * 31;
                    }
                    else
                    {
                        calc_mes = Convert.ToInt64(dce.get_vr_diario()) * 22;
                    }
                    
                    TxtMens.Text = new money().formatToMoney ( calc_mes.ToString() );
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

    protected void BtnConfirmar_Click(object sender, EventArgs e)
    {
        money mon = new money();

        long vr_tot = mon.getNumericValue(TxtDisp.Text) +
                      mon.getNumericValue(TxtMens.Text);

        string st_tot = mon.setMoneyFormat(vr_tot);

        GetConnection();

        string id_number = "";

        try
        {
            var_exchange.web_exec_confirmaBoleto (  mon.getNumericValue(TxtMens.Text).ToString(),
                                                    mon.getNumericValue(TxtDisp.Text).ToString(),
                                                    Session["st_cartao"].ToString(),
                                                    ref id_number );


            TxtBolNome.Text     = Session["st_nomeResp"].ToString();
            TxtBolNumero.Text   = id_number;
            TxtBolTot.Text      = st_tot.Replace(".", "");

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
