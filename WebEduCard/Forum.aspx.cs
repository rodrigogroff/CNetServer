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

public partial class Forum : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LblMsg1.Visible = false;
            LblMsg2.Visible = false;
            LblMsg3.Visible = false;
            LblMsg4.Visible = false;
            LblMsg5.Visible = false;

            LblTit1.Visible = false;
            LblTit2.Visible = false;
            LblTit3.Visible = false;
            LblTit4.Visible = false;
            LblTit5.Visible = false;

            ArrayList lstMsg = new ArrayList();

            for (int t = 0; t < lstMsg.Count; ++t)
            {
                if (t >= 5)
                    break;

                DadosEduMessage dem = new DadosEduMessage(lstMsg[t] as DataPortable);

                string st_text = dem.get_st_msg();

                while (st_text.Contains(" www."))
                {
                    int index = st_text.IndexOf(" www.");
                    int indexFim = st_text.IndexOf(" ", index + 1);

                    string teste = st_text.Substring(index + 1, indexFim - index - 1);

                    st_text = st_text.Replace(teste, "<a href=\"http://" + teste + "\">" + teste + "</a>");
                }

                #region - setando labels - 
                
                switch (t)
                {
                    case 0:
                        {
                            LblTit1.Text = dem.get_st_title();
                            LblMsg1.Text = st_text;

                            LblMsg1.Visible = true;
                            LblTit1.Visible = true;
                            break;
                        }

                    case 1:
                        {
                            LblTit2.Text = dem.get_st_title();
                            LblMsg2.Text = st_text;

                            LblMsg2.Visible = true;
                            LblTit2.Visible = true;
                            break;
                        }

                    case 2:
                        {
                            LblTit3.Text = dem.get_st_title();
                            LblMsg3.Text = st_text;

                            LblMsg3.Visible = true;
                            LblTit3.Visible = true;
                            break;
                        }

                    case 3:
                        {
                            LblTit4.Text = dem.get_st_title();
                            LblMsg4.Text = st_text;

                            LblMsg4.Visible = true;
                            LblTit4.Visible = true;
                            break;
                        }

                    case 4:
                        {
                            LblTit5.Text = dem.get_st_title();
                            LblMsg5.Text = st_text;

                            LblMsg5.Visible = true;
                            LblTit5.Visible = true;
                            break;
                        }

                    default: break;
                }

                #endregion
            }
        }
    }

    protected void BtnCartao_Click(object sender, EventArgs e)
    {
        Response.Redirect("aluno.aspx", true);
    }
}
