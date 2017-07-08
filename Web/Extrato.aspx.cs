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

public class PositionData_ExtratoCartao
{
    public string data, cart, nsu, loja, valor, parcela;

    public string Data { get { return data; } }
    public string Cart { get { return cart; } }
    public string NSU { get { return nsu; } }
    public string Loja { get { return loja; } }
    public string Valor { get { return valor; } }
    public string Parcela { get { return parcela; } }
}

public partial class Extrato : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LblNome.Text = Session["nome"].ToString();
            TxtAno.Text = DateTime.Now.Year.ToString();
            CboMes.SelectedIndex = (DateTime.Now.Month - 1);

            BtnExtrato_Click(null, null);
        }
    }

    protected void BtnSair_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx", true);
    }

    protected void BtnFuturo_Click(object sender, EventArgs e)
    {
        Response.Redirect("ExtratoFuturo.aspx", true);
    }

    protected void BtnExtrato_Click(object sender, EventArgs e)
    {
        if (TxtAno.Text.Length != 4)
            return;

        GetConnection();

        try
        {
            string output_st_content_block = "";
            string output_vr_disp = "";
            string output_vr_lim = "";

            string pass = Session["pass"].ToString();
            string cnpj = Session["cnpj"].ToString();

            if (var_exchange.fetch_extratoWeb(  cnpj + (CboMes.SelectedIndex + 1 ).ToString().PadLeft (2,'0') + TxtAno.Text,
                                                pass,
                                                ref output_st_content_block,
                                                ref output_vr_disp,
                                                ref output_vr_lim))
            {
                ArrayList values = new ArrayList();

                while (output_st_content_block != "")
                {
                    ArrayList tmp_memory = new ArrayList();

                    if (var_exchange.fetch_memory(output_st_content_block, "200",
                                                     ref output_st_content_block,
                                                     ref tmp_memory))
                    {
                        long vr_gasto = 0;

                        for (int t = 0; t < tmp_memory.Count; ++t)
                        {
                            Rel_RTC rtc = new Rel_RTC(tmp_memory[t] as DataPortable);

                            PositionData_ExtratoCartao bind = new PositionData_ExtratoCartao();

                            bind.nsu = rtc.get_st_nsu();
                            bind.cart = rtc.get_en_op_cartao();
                            bind.data = var_util.getDDMMYYYY_format(rtc.get_dt_trans());
                            bind.loja = rtc.get_st_loja();
                            bind.valor = new money().formatToMoney(rtc.get_vr_total());

                            vr_gasto += Convert.ToInt64(rtc.get_vr_total());

                            bind.parcela = rtc.get_st_indice_parcela() + " / " + rtc.get_st_term();

                            values.Add(bind);
                        }

                        LblTot.Text = "Total disponível: R$ " + new money().formatToMoney(output_vr_disp);

                        if (output_vr_lim == "")
                            LblLim.Visible = false;
                        else
                            LblLim.Text = "Limite mensal: R$ " + new money().formatToMoney(output_vr_lim);

                        LblGasto.Text = "Total de gastos: R$ " + new money().formatToMoney(vr_gasto.ToString());
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