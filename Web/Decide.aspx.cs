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

public partial class Decide : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LblNome.Text = Session["nome"].ToString();
        }
    }

    protected void BtnTrans_Click(object sender, EventArgs e)
    {
        Response.Redirect("Trans.aspx", true);
        return;
    }

    protected void BtnSair_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx", true);
        return;
    }

    protected void BtnRepasse_Click(object sender, EventArgs e)
    {
        Response.Redirect("Rep.aspx", true);
        return;
    }
}