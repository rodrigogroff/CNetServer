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

public partial class Ranking : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetConnection();

            string st_csv = "";

            try
            {
                var_exchange.web_fetch_edu_ranking(ref st_csv);                
            
                money money_helper = new money();

                ArrayList values = new ArrayList();

    //            string var_tmp_listCSV = "";

                var_util.clearPortable();

  //              var_util.indexCSV(st_csv);
//                var_util.setBatchAmount(var_util.max_pack / 250);

      //          while (var_util.nextBatch(ref var_tmp_listCSV) == true)
                {
                    ArrayList list = new ArrayList();
                    /*
                    if (var_exchange.fetch_memory(var_tmp_listCSV, ref list))
                    {
                        for (int t = 0; t < list.Count; ++t)
                        {
                            DadosRanking rnk = new DadosRanking(list[t] as DataPortable);

                            PositionData_Ranking bind = new PositionData_Ranking();

                            bind.pos   = rnk.get_st_pos();
                            bind.nome  = rnk.get_st_nome();
                            bind.valor = money_helper.formatToMoney(rnk.get_vr_valor());
                            
                            values.Add(bind);
                        }
                    }
                     * */
                }

                var_exchange.m_Client.ExitSession();

                RptRanking.DataSource = values;
                RptRanking.DataBind();
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
}
