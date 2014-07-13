using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class IPTracking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label3.Text = "您当前的 IP 为: " + Request.UserHostAddress.ToString(); ;
        }
    }
 
    private void ShowCodes()
    {
        string text = Server.UrlEncode(TextBox1.Text.Trim());

        if (!String.IsNullOrEmpty(text))
        {
            //this.Response.Redirect("Tracking.aspx?user=" + text);

            string the = "请将下列HTML代码粘贴到您空共享间的首页的HTML模块或者Sandbox Gadget模块:<br><br> <div style=\"border: 1px dashed #ccc; background-color:#FDF5E6; padding:10px; font-family:Courier New;\">";

            string theT = "<img src=\"http://lieb.cn/IPTrack/Tracking.aspx?user=" + text + "\" alt=\"\" width=\"0px\" height=\"0px\" />";

            string the2 = "</div> <br/>粘贴如下HTML代码到您空共享间的首页的HTML模块或者Sandbox Gadget模块:<br><br> <div style=\"border: 1px dashed #ccc; padding:10px; font-family:Courier New;\">";

            string theG = "<a href=\"http://lieb.cn/iptrack/Record.aspx?user=" + text + "\" title=\"\" target=\"_blank\">查看我的IP访问记录</a> ";

            string theRSS = "<a href=\"http://lieb.cn/iptrack/RSS.aspx?user=" + text + "\" title=\"\" target=\"_blank\">IP访问记录 RSS Feed</a>";

            Label1.Text = the + "<span style=\"color:green;\">" + Server.HtmlEncode(theT) + "</span>" + the2 + "<span style=\"color:green;\">" + Server.HtmlEncode(theG) + "</span></div>" + "<div style=\"margin: 2px auto; background-color:#FDF5E6;border: 1px dashed #ccc; padding:10px; font-family:Courier New;\"><span style=\"color:green;\"> " + Server.HtmlEncode(theRSS) + "</span></div>";
        }
    }
 
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        ShowCodes();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string text = Server.UrlEncode(TextBox1.Text.Trim());

        if (!String.IsNullOrEmpty(text))
        {
            this.Response.Redirect("Record.aspx?user=" + text);
        }
    }
    protected void btFilter_Click(object sender, EventArgs e)
    {

        if (!String.IsNullOrEmpty(TextBox1.Text.Trim()))
        {
            string text = Server.UrlEncode(TextBox1.Text.Trim());

            string ip1 = tbIpFilter1.Text.Trim();
            string ip2 = tbIpFilter2.Text.Trim();
            string alias = text;

            try
            {
                if (!String.IsNullOrEmpty(ip1))
                {
                    DoFilter(ip1, alias);
                }
                
                if (!String.IsNullOrEmpty(ip2))
                {
                    DoFilter(ip2, alias);
                }

                if (String.IsNullOrEmpty(ip1) && String.IsNullOrEmpty(ip2))
                {
                    lbFilterSucc.Text = "您在考验 BELEM 的智商, 你什么 IP 都没填, 没东西可以过滤啊...";
                }
                else
                {
                    lbFilterSucc.Text = "IP 过滤设置成功, IP " + ip1 + " " + ip2 + " 访问您的共享空间时将不被记录.";
                }
            }

            catch (Exception ex)
            {
                lbFilterSucc.Text = ex.Message.ToString();
            }

        }
        else
        {
            lbFilterSucc.Text = "请首先输入第一步您空间地址.";
        }
    }

    private static void DoFilter(string ipF, string alias)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["IPTrackConnectionString"].ToString());
        objConn.Open();

        SqlCommand cmd = objConn.CreateCommand();
        string strSql = "BEL_IpsTrackFilter";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = strSql;

        cmd.Parameters.Clear();

        SqlParameter[] parameters = new SqlParameter[]
                    {
                     new SqlParameter("@SpaceAlias",SqlDbType.VarChar,50),
                     new SqlParameter("@FilterIP",SqlDbType.VarChar,50) 
                    };

        parameters[0].Value = alias;
        parameters[1].Value = ipF;


        foreach (SqlParameter sqlp in parameters)
            cmd.Parameters.Add(sqlp);

        cmd.ExecuteNonQuery();
        objConn.Close();
    }
 
}
