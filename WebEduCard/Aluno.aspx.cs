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

public partial class Aluno : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RptExtrato.Visible = false;
        LblExtrato.Visible = false;

        if (!Page.IsPostBack)
        {
            GetConnection();

            DadosCartaoEdu dce = new DadosCartaoEdu();

            string st_cartao = Session["st_cartao"].ToString();
            string st_senha  = Session["st_senha"].ToString();

            try
            {
                if (var_exchange.web_fetch_saldo_edu(st_cartao,
                                                        st_senha,
                                                        SyCrafEngine.Context.FALSE,
                                                        ref dce))
                {
                    Label1.Text  = dce.get_st_aluno();

                    int diario   = Convert.ToInt32(dce.get_vr_diario());
                    int calc_mes = diario * 31;

                    DateTime tim = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);

                    long dias = tim.Subtract(DateTime.Now).Days;
                    long prev_mes = dias * diario;

                    TxtVrDisp.Text = "R$ " + new money().formatToMoney(dce.get_vr_disp());
                    TxtVrDispDiario.Text = "R$ " + new money().formatToMoney(diario.ToString());
                    TxtVrDispMensal.Text = "R$ " + new money().formatToMoney(calc_mes.ToString());
                    TxtVrSaldoMes.Text = "R$ " + new money().formatToMoney(prev_mes.ToString());
                    TxtSaldoTotal.Text = "R$ " + new money().formatToMoney(dce.get_vr_depot());

                    DtIni.SelectedDate = DateTime.Now;
                    DtFim.SelectedDate = DateTime.Now;

                    var_exchange.m_Client.ExitSession();
                }
                else
                {
                    var_exchange.m_Client.ExitSession();

                    Session["st_error"] = var_exchange.m_Client.GetServerMessage();
                    Session["st_error_dest"] = "aluno.aspx";
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

    protected void BtnConfirmar ( object sender, EventArgs e )
    {
        GetConnection();

        money money_helper = new money();

        try
        {
            DateTime t_start = (DateTime)DtIni.SelectedDate;
            DateTime t_end = (DateTime)DtFim.SelectedDate;

            t_start = new DateTime(t_start.Year, t_start.Month, t_start.Day);

            string st_csv = "";
            string st_total_periodo = "";

            GetConnection();

            if (!var_exchange.web_fetch_rel_edu_extrato(Session["st_cartao"].ToString(),
                                                            var_util.DESCript(TxtSenha.Value.PadLeft(8, '*'), "12345678"),
                                                            var_util.GetDataBaseTimeFormat((DateTime)t_start),
                                                            var_util.GetDataBaseTimeFormat((DateTime)t_end.AddHours(23).AddMinutes(59).AddSeconds(59)),
                                                            SyCrafEngine.Context.TRUE,
                                                            ref st_csv,
                                                            ref st_total_periodo))
            {
                var_exchange.m_Client.ExitSession();

                Session["st_error"] = var_exchange.m_Client.GetServerMessage();
                Session["st_error_dest"] = "RespExt.aspx";
                Response.Redirect("error.aspx", true);
                return;
            }

            RptExtrato.Visible = true;
            LblExtrato.Visible = true;

            LblExtrato.Text = "Extrato de atividades do cartão: " + DtIni.SelectedDate.ToShortDateString() + " até " + DtFim.SelectedDate.ToShortDateString();

            ArrayList values = new ArrayList();

            ArrayList desc = new TipoConfirmacaoDesc().GetArray();
            ArrayList desc_op = new OperacaoCartaoDesc().GetArray();

            while (st_csv != "")
            {
                ArrayList list = new ArrayList();

                var_exchange.fetch_memory(st_csv, "400", ref st_csv, ref list);

                for (int t = 0; t < list.Count; ++t)
                {
                    EduExtrato rel_line = new EduExtrato(list[t] as DataPortable);

                    PositionData_ExtratoEdu bind = new PositionData_ExtratoEdu();

                    bind.nsu = rel_line.get_st_nsu();
                    bind.data = var_util.getDDMMYYYY_format(rel_line.get_dt_trans());
                    bind.valor = money_helper.formatToMoney(rel_line.get_vr_valor());
                    bind.loja = rel_line.get_st_loja();
                    bind.saldo = money_helper.formatToMoney(rel_line.get_vr_disp());
                    bind.fundo = money_helper.formatToMoney(rel_line.get_vr_fundo());
                    bind.operacao = desc_op[Convert.ToInt32(rel_line.get_en_oper())].ToString();

                    values.Add(bind);
                }
            }

            RptExtrato.DataSource = values;
            RptExtrato.DataBind();

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

    protected void BtnForum_Click(object sender, EventArgs e)
    {
        Response.Redirect("Forum.aspx", true);
    }
}
