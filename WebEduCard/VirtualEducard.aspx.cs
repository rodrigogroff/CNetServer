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

public class PositionData_MovFundo
{
    public string nome, mov, total;

    public string Nome  { get { return nome;    } }
    public string Mov   { get { return mov;     } }
    public string Total { get { return total;   } }
}

public class PositionData_FundoEmpresa
{
    public string nome, acoes, osc, vrdia, invest, preco_medio, custo_medio, rent;

    public string Nome   { get { return nome; } }
    public string Acoes  { get { return acoes; } }
    public string Osc    { get { return osc; } }
    public string VrDia  { get { return vrdia; } }
    public string Invest { get { return invest; } }
    public string PMedio { get { return preco_medio; } }
    public string CMedio { get { return custo_medio; } }
    public string Rent   { get { return rent; } }
}

public class PositionData_RendEmpresa
{
    public string nome, rend, data;

    public string Nome { get { return nome; } }
    public string Rend { get { return rend; } }
    public string Data { get { return data; } }
}

public partial class VirtualEducard : WebBase
{
    public void BuscaDados ( DateTime tim )
    {
        RptHist.Visible = false;

        GetConnection();

        string st_cartao = Session["st_cartao"].ToString();
        string st_senha  = Session["st_senha"].ToString();

        ArrayList lst    = new ArrayList();
        ArrayList lstEmp = new ArrayList();

        DadosCartaoEdu dce = new DadosCartaoEdu();

        money mon = new money();

        try
        {
            if ( var_exchange.web_fetch_edu_virtual (   st_cartao,
                                                        st_senha,
                                                        var_util.ConvertDate(tim),
                                                        ref dce,
                                                        ref lst,
                                                        ref lstEmp ))
            {
                if ( dce.get_nu_vrRank() != "0" )
                    LblAluno.Text = "#" + dce.get_nu_vrRank() + " - " + dce.get_st_aluno();
                else
                    LblAluno.Text = dce.get_st_aluno();

                LblDiaMov.Text = tim.ToLongDateString();

                TxtVrDispVirtual.Text = mon.formatToMoney(dce.get_vr_disp_virtual());
                TxtVrTotalInv.Text = mon.formatToMoney(dce.get_vr_invest_virtual());

                TxtVrTotal.Text = mon.setMoneyFormat (  Convert.ToInt64(dce.get_vr_disp_virtual() ) +
                                                        Convert.ToInt64(dce.get_vr_invest_virtual() ) );

                ArrayList values      = new ArrayList();
                ArrayList valuesEmp   = new ArrayList();

                for (int t = 0; t < lstEmp.Count; ++t)
                {
                    DadosMovEmpresaVirtual      dMov = new DadosMovEmpresaVirtual(lstEmp[t] as DataPortable);
                    PositionData_FundoEmpresa   bind = new PositionData_FundoEmpresa();

                    bind.nome  = dMov.get_st_nome();
                    bind.acoes = dMov.get_vr_acoes();
                    bind.osc   = dMov.get_vr_osc();
                    bind.vrdia = mon.formatToMoney ( dMov.get_vr_dia() );
                    bind.preco_medio = mon.formatToMoney(dMov.get_vr_preco_medio());

                    bind.invest = (Convert.ToInt64(dMov.get_vr_acoes()) * Convert.ToInt64(dMov.get_vr_dia())).ToString();
                    bind.invest = mon.formatToMoney(bind.invest);
                    
                    bool neg = false;

                    if ( bind.osc.IndexOf("-") >= 0)
                        neg = true;

                    bind.osc = bind.osc.Replace ("-", "");
                    bind.osc = bind.osc.PadLeft(4, '0');

                    int len = bind.osc.Length;

                    if (len == 4)
                        bind.osc = "0," + bind.osc;
                    else
                        bind.osc = bind.osc.Insert(len - 4, ",");

                    if ( neg ) bind.osc = "-" + bind.osc;

                    bind.osc += "%";

                    if (bind.osc == "0,0000%") bind.osc = "-";

                    valuesEmp.Add(bind);
                }
                
                RptEmpresas.DataSource = valuesEmp;
                RptEmpresas.DataBind();

                RptEmpresas.Visible = true;

                for (int t = 0; t < lst.Count; ++t)
                {
                    DadosMovEmpresaVirtual  dMov = new DadosMovEmpresaVirtual(lst[t] as DataPortable);
                    PositionData_MovFundo   bind = new PositionData_MovFundo();

                    bind.nome  = dMov.get_st_nome();
                    bind.mov   = dMov.get_vr_mov_fundo();

                    if (bind.mov.IndexOf("-") == -1)
                        bind.mov = "+" + bind.mov;

                    bind.total = dMov.get_vr_total();

                    values.Add(bind);
                }

                RptExtrato.DataSource = values;
                RptExtrato.DataBind();

                RptExtrato.Visible = true;
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BuscaDados ( DateTime.Now );
        }
    }

    protected void BtnCompra_Click(object sender, EventArgs e)
    {
        if (TxtCodEmpresa.Text != "")
        {
            Aplicacao ( new money().prepareNumber ( TxtVrCompra.Value.ToString() ), TxtCodEmpresa.Text);
        }
    }

    protected void BtnVenda_Click(object sender, EventArgs e)
    {
        if (TxtCodEmpresa.Text != "")
        {
            Aplicacao ( "-" + new money().prepareNumber ( TxtVrVenda.Value.ToString() ), TxtCodEmpresa.Text);
        }
    }

    void Aplicacao(string val, string code)
    {
        GetConnection();

        try
        {
            if (!var_exchange.web_exec_edu_aplic_fundo ( Session["st_cartao"].ToString(),
                                                         Session["st_senha"].ToString(),
                                                         code,
                                                         val ) )
            {
                var_exchange.m_Client.ExitSession();

                Session["st_error"] = var_exchange.m_Client.GetServerMessage();
                Session["st_error_dest"] = "VirtualEducard.aspx";
                Response.Redirect("error.aspx", true);
                return;
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

        BuscaDados ( DateTime.Now );
    }
        
    protected void LnkUpdate_Click(object sender, EventArgs e)
    {
        BuscaDados ( DtIni.SelectedDate );
    }

    protected void LnkHist_Click(object sender, EventArgs e)
    {
        GetConnection();
        
        try
        {
            string st_csv = "";

            if (!var_exchange.web_fetch_edu_emp_hist (   Session["st_cartao"].ToString(),
                                                         Session["st_senha"].ToString(),
                                                         TxtCodEmpresa.Text,
                                                         ref st_csv))
            {
                var_exchange.m_Client.ExitSession();

                Session["st_error"] = var_exchange.m_Client.GetServerMessage();
                Session["st_error_dest"] = "VirtualEducard.aspx";
                Response.Redirect("error.aspx", true);
                return;
            }

            ArrayList values = new ArrayList();

            //string var_tmp_listCSV = "";

            var_util.clearPortable();

            var_util.indexCSV(st_csv);
//            var_util.setBatchAmount(var_util.max_pack / 250);

            ArrayList desc    = new TipoConfirmacaoDesc().GetArray();
            ArrayList desc_op = new OperacaoCartaoDesc().GetArray();

          //  while (var_util.nextBatch(ref var_tmp_listCSV) == true)
            {
                ArrayList list = new ArrayList();
/*
                if (var_exchange.fetch_memory(var_tmp_listCSV, ref list))
                {
                    for (int t = 0; t < list.Count; ++t)
                    {
                        DadosMovEmpresaVirtual   mov  = new DadosMovEmpresaVirtual(list[t] as DataPortable);
                        PositionData_RendEmpresa bind = new PositionData_RendEmpresa();

                        bind.data = var_util.getDDMMYYYY_format(mov.get_dt_dia()).Substring(0, 10);
                        bind.nome = mov.get_st_nome();
                        bind.rend = mov.get_vr_osc();

                        bool neg = false;

                        if (bind.rend.IndexOf("-") >= 0)
                            neg = true;

                        bind.rend = bind.rend.Replace("-", "");
                        bind.rend = bind.rend.PadLeft(4, '0');

                        int len = bind.rend.Length;

                        if (len == 4)
                            bind.rend = "0," + bind.rend;
                        else
                            bind.rend = bind.rend.Insert(len - 4, ",");

                        if (neg) bind.rend = "-" + bind.rend;

                        bind.rend += "%";

                        if (bind.rend == "0,0000%") bind.rend = "-";
                        
                        values.Add(bind);
                    }
                }
 * */
            }

            RptHist.DataSource = values;
            RptHist.DataBind();

            if ( values.Count > 0 )
                RptHist.Visible = true;

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

    protected void LnkRanking_Click(object sender, EventArgs e)
    {
        Response.Redirect("ranking.aspx", true);
    }

    protected void LnkSenha_Click(object sender, EventArgs e)
    {
        Response.Redirect("altsenha.aspx", true);
    }
    protected void DtIni_SelectionChanged(object sender, EventArgs e)
    {

    }
    protected void RptExtrato_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}
