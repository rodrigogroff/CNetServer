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

public class PositionData_ExtratoCartaoFuturo
{
    public string loja, valor, parcela;

    public string Loja { get { return loja; } }
    public string Valor { get { return valor; } }
    public string Parcela { get { return parcela; } }
}

public partial class ExtratoFuturo : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LblNome.Text = Session["nome"].ToString();

            GetConnection();

            try
            {
                string output_st_content_block = "";
                
                string pass = Session["pass"].ToString();
                string cnpj = Session["cnpj"].ToString();

                if (var_exchange.fetch_extratoWebFuturo (   cnpj,
                                                            pass,
                                                            ref output_st_content_block ))
                {
                    ArrayList values = new ArrayList();

                    while (output_st_content_block != "")
                    {
                        ArrayList tmp_memory = new ArrayList();

                        if ( var_exchange.fetch_memory ( output_st_content_block, "200",
                                                         ref output_st_content_block,
                                                         ref tmp_memory))
                        {
                            long vr_gasto = 0;

                            for (int t = 0; t < tmp_memory.Count; ++t)
                            {
                                Rel_RTC rtc = new Rel_RTC(tmp_memory[t] as DataPortable);

                                PositionData_ExtratoCartaoFuturo bind = new PositionData_ExtratoCartaoFuturo();

                                bind.loja = rtc.get_st_loja();
                                bind.valor = new money().formatToMoney(rtc.get_vr_total());

                                vr_gasto += Convert.ToInt64(rtc.get_vr_total());

                                bind.parcela = rtc.get_st_indice_parcela() + " / " + rtc.get_nu_parc();

                                values.Add(bind);
                            }

                            LblGasto.Text = "Total previsto: R$ " + new money().formatToMoney(vr_gasto.ToString());
                        }
                    }

                    string note = var_exchange.m_Client.GetServerMessage();

                    var_exchange.m_Client.ExitSession();

                    if (note == "")
                    {
                        RptExtrato.DataSource = values;
                        RptExtrato.DataBind();
                    }
                    else
                    {
                        Session["st_error"] = note;
                        Session["st_error_dest"] = "trans.aspx";
                        Response.Redirect("error.aspx", true);
                    }
                }
                else
                {
                    var_exchange.m_Client.ExitSession();

                    Session["st_error"] = var_exchange.m_Client.GetServerMessage();
                    Session["st_error_dest"] = "trans.aspx";
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
    }

    protected void BtnSair_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx", true);
    }

    protected void BtnExtrato_Click(object sender, EventArgs e)
    {
        Response.Redirect("Extrato.aspx", true);
    }
}