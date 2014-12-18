using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            btnOk.Attributes.Add("onclick", "document.getElementById('waiting').style.display='block';document.getElementById('clicking').style.display='none';");//注册点击时隐藏按钮的脚本
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        Mobile mobile = new Mobile();
        DataSet ds = mobile.GetLinkYCJ_HC();
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();
    }
}