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

public class PositionData_ExtratoRepasse
{
    public string data, nsu, cartao, valor, indparc, repasse;

    public string Data    { get { return data;      } }
    public string NSU     { get { return nsu;       } }
    public string Cartao  { get { return cartao;    } }
    public string Valor   { get { return valor;     } }
    public string IndParc { get { return indparc;   } }
    public string Repasse { get { return repasse;   } }
}

public partial class Rep : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LblNome.Text = Session["nome"].ToString();

            TxtMes.Text = (DateTime.Now.Month - 1 ).ToString();
            TxtAno.Text = DateTime.Now.Year.ToString();

            string pass = Session["pass"].ToString();
            string cnpj = Session["cnpj"].ToString();

            GetConnection();

            try
            {
                ArrayList lst = new ArrayList();

                if ( var_exchange.fetch_listawebConveniosLoja ( cnpj, 
                                                                pass, 
                                                                ref lst ) )
                {
                    var_exchange.m_Client.ExitSession();
                    
                    for (int t = 0; t < lst.Count; ++t)
                    {
                        DadosEmpresa de = new DadosEmpresa(lst[t] as DataPortable);

                        CboEmp.Items.Add(de.get_st_empresa());
                    }
                }
                else
                {
                    var_exchange.m_Client.ExitSession();

                    Session["st_error"] = var_exchange.m_Client.GetServerMessage();
                    Session["st_error_dest"] = "rep.aspx";
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

    protected void BtnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("decide.aspx", true);
    }

    protected void BtnRepasse_Click(object sender, EventArgs e)
    {
        if ( TxtMes.Text == "")
        {
            Session["st_error"] = "Informar o mês desejado para consulta de repasse";
            Session["st_error_dest"] = "default.aspx";
            Response.Redirect("error.aspx", true);
            return;
        }

        if (TxtAno.Text.Length < 4 )
        {
            Session["st_error"] = "Informar corretamente o ano desejado para consulta de repasse";
            Session["st_error_dest"] = "default.aspx";
            Response.Redirect("error.aspx", true);
            return;
        }

        GetConnection();

        try
        {
            string output_st_content_block = "";

            ArrayList desc_status = new TipoConfirmacaoDesc().GetArray();

            string pass = Session["pass"].ToString();
            string cnpj = Session["cnpj"].ToString();

            if (var_exchange.fetch_consultaLojistaRep (     cnpj,
                                                            pass,
                                                            TxtMes.Text,
                                                            TxtAno.Text,
                                                            CboEmp.SelectedItem.ToString(),
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

                            PositionData_ExtratoRepasse bind = new PositionData_ExtratoRepasse();

                            bind.data    = var_util.getDDMMYYYY_format(dct.get_dt_transacao());
                            bind.nsu = dct.get_st_nsu();
                            bind.valor   = new money().formatToMoney(dct.get_vr_valor());
                            bind.cartao  = dct.get_st_cartao();
                            bind.indparc = dct.get_nu_parcelas();
                            bind.repasse = new money().formatToMoney(dct.get_vr_repasse());
                            
                            vr_tot += Convert.ToInt64(dct.get_vr_repasse());

                            values.Add(bind);
                        }

                        LblTot.Text = "Total : R$ " + new money().formatToMoney(vr_tot.ToString());
                    }
                }

                string note = var_exchange.m_Client.GetServerMessage();

                var_exchange.m_Client.ExitSession();

                if (note == "")
                {
                    RptRepassse.DataSource = values;
                    RptRepassse.DataBind();
                }
                else
                {
                    Session["st_error"] = note;
                    Session["st_error_dest"] = "rep.aspx";
                    Response.Redirect("error.aspx", true);
                }
            }
            else
            {
                var_exchange.m_Client.ExitSession();

                Session["st_error"] = var_exchange.m_Client.GetServerMessage();
                Session["st_error_dest"] = "rep.aspx";
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
