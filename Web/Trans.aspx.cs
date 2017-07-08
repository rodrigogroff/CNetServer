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

public class PositionData_Extrato
{
    public string data, nsu, valor, cartao, desc, parcelas, assoc;

    public string Data       { get { return data;        } }
    public string NSU        { get { return nsu;         } }
    public string Valor      { get { return valor;       } }
    public string Parcelas   { get { return parcelas;    } }
    public string Desc       { get { return desc;        } }
    public string Cartao     { get { return cartao;      } }
    public string Assoc      { get { return assoc;       } }
}

public partial class Trans : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LblNome.Text = Session["nome"].ToString();
        }
    }

    protected void BtnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("decide.aspx", true);
    }

    protected void BtnConfirmar_Click(object sender, EventArgs e)
    {
        GetConnection();

        try
        {
            string output_st_content_block = "";

            ArrayList desc_status = new TipoConfirmacaoDesc().GetArray();

            string pass = Session ["pass"].ToString();
            string cnpj = Session ["cnpj"].ToString();

            DateTime t_start = (DateTime)DtIni.SelectedDate;
            DateTime t_end   = (DateTime)DtFim.SelectedDate;

            t_start = new DateTime(t_start.Year, t_start.Month, t_start.Day);

            if (var_exchange.fetch_consultaLojista(     cnpj,
                                                        var_util.GetDataBaseTimeFormat((DateTime)t_start),
                                                        var_util.GetDataBaseTimeFormat((DateTime)t_end.AddHours(23).AddMinutes(59).AddSeconds(59)),
                                                        pass,
                                                        ref output_st_content_block))
            {
                ArrayList values = new ArrayList();

                while (output_st_content_block != "")
                {
                    ArrayList tmp_memory = new ArrayList();

                    if (var_exchange.fetch_memory(output_st_content_block, "200",
                                                     ref output_st_content_block,
                                                     ref tmp_memory))
                    {
                        long vr_tot = 0;

                        for (int t = 0; t < tmp_memory.Count; ++t)
                        {
                            DadosConsultaTransacao dct = new DadosConsultaTransacao(tmp_memory[t] as DataPortable);

                            PositionData_Extrato bind = new PositionData_Extrato();

                            bind.nsu      = dct.get_st_nsu();
                            bind.data     = var_util.getDDMMYYYY_format(dct.get_dt_transacao());
                            bind.valor    = new money().formatToMoney(dct.get_vr_valor());
                            bind.cartao   = dct.get_st_cartao();
                            bind.parcelas = dct.get_nu_parcelas();
                            bind.desc     = desc_status[Convert.ToInt32(dct.get_tg_status())].ToString();
                            bind.assoc    = dct.get_st_cod_empresa();

                            if (dct.get_tg_status() == TipoConfirmacao.Confirmada) // desfazimento
                                vr_tot += Convert.ToInt64(dct.get_vr_valor());

                            values.Add(bind);
                        }

                        LblTot.Text = "Total : R$ " + new money().formatToMoney(vr_tot.ToString());
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
