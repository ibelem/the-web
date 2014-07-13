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

public partial class Record : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (String.IsNullOrEmpty(Request.Params["user"].ToString()) || Request.Params["user"].ToString() == "yyyako" || Request.Params["user"].ToString() == "gb2312")
                {
                    this.Response.Redirect("Default.aspx");
                }

                else
                {
                    string my = Server.HtmlEncode(Request.Params["user"].ToString());

                    Label2.Text = "http://" + Server.HtmlEncode(my) + ".spaces.live.com";

                    HyperLink1.NavigateUrl = "http://" + Server.HtmlEncode(my) + ".spaces.live.com";

                    Label1.Text = "您当前的 IP 为: " + Request.UserHostAddress.ToString();

                }
            }
            catch
            {
                this.Response.Redirect("Default.aspx");
            }

        
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        this.Response.Redirect("http://lieb.cn/IPTrack/RSS.aspx?user=" + Server.HtmlEncode(Request.Params["user"].ToString()));
    }
}
