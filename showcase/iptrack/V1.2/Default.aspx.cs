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

public partial class IPTracking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string text = Server.UrlEncode(TextBox1.Text.Trim());

        if (!String.IsNullOrEmpty(text))
        {
            //this.Response.Redirect("Tracking.aspx?user=" + text);

            string the = "�뽫����HTML����ճ�������չ�������ҳ��HTMLģ�����Sandbox Gadgetģ��:<br><br> <div style=\"border: 1px solid #ccc; padding:10px; font-family:Courier New;\">";
                
            string theT = "<img src=\"http://lieb.cn/IPTrack/Tracking.aspx?user="+ text +"\" alt=\"\" width=\"0px\" height=\"0px\" />";

            string the2 = "</div> <br/>�Ժ�, ���û�������Ŀռ�ʱ, �뵽<a href=\"http://lieb.cn/iptrack\" title=\"\">http://lieb.cn/iptrack</a>���[�鿴IP���ʼ�¼]��ť���ɲ�ѯ��ʷ��Ϣ.����ճ������HTML���뵽���չ�������ҳ��HTMLģ�����Sandbox Gadgetģ��:<br><br> <div style=\"border: 1px solid #ccc; padding:10px; font-family:Courier New;\">";

            string theG = "<a href=\"http://lieb.cn/iptrack/Record.aspx?user=" + text + "\" title=\"\" target=\"_blank\">�鿴�ҵ�IP���ʼ�¼</a> ";

            string theRSS =  "<a href=\"http://lieb.cn/iptrack/RSS.aspx?user=" + text + "\" title=\"\" target=\"_blank\">IP���ʼ�¼ RSS Feed</a>";

            Label1.Text = the + "<span style=\"color:green;\">" + Server.HtmlEncode(theT) + "</span>" + the2 + "<span style=\"color:#76923C;\">" + Server.HtmlEncode(theG) + "</span></div>" + "<div style=\"margin: 2px auto; border: 1px solid #ccc; padding:10px; font-family:Courier New;\"><span style=\"color:#0070C0;\"> " + Server.HtmlEncode(theRSS) + "</span></div>";
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string text = Server.UrlEncode(TextBox1.Text.Trim());

        if (!String.IsNullOrEmpty(text))
        {
            this.Response.Redirect("Record.aspx?user=" + text);
        }
    }
}
