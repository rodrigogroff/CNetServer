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

public partial class WebError : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LblError.Text = Session["st_error"].ToString();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string dest = Session["st_error_dest"].ToString();

        Response.Redirect ( dest, true);
    }
}
