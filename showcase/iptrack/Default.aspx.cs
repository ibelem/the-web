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
            Label3.Text = "����ǰ�� IP Ϊ: " + Request.UserHostAddress.ToString(); ;
        }
    }
 
    private void ShowCodes()
    {
        string text = Server.UrlEncode(TextBox1.Text.Trim());

        if (!String.IsNullOrEmpty(text))
        {
            //this.Response.Redirect("Tracking.aspx?user=" + text);

            string the = "�뽫����HTML����ճ�������չ�������ҳ��HTMLģ�����Sandbox Gadgetģ��:<br><br> <div style=\"border: 1px dashed #ccc; background-color:#FDF5E6; padding:10px; font-family:Courier New;\">";

            string theT = "<img src=\"http://lieb.cn/IPTrack/Tracking.aspx?user=" + text + "\" alt=\"\" width=\"0px\" height=\"0px\" />";

            string the2 = "</div> <br/>ճ������HTML���뵽���չ�������ҳ��HTMLģ�����Sandbox Gadgetģ��:<br><br> <div style=\"border: 1px dashed #ccc; padding:10px; font-family:Courier New;\">";

            string theG = "<a href=\"http://lieb.cn/iptrack/Record.aspx?user=" + text + "\" title=\"\" target=\"_blank\">�鿴�ҵ�IP���ʼ�¼</a> ";

            string theRSS = "<a href=\"http://lieb.cn/iptrack/RSS.aspx?user=" + text + "\" title=\"\" target=\"_blank\">IP���ʼ�¼ RSS Feed</a>";

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
                    lbFilterSucc.Text = "���ڿ��� BELEM ������, ��ʲô IP ��û��, û�������Թ��˰�...";
                }
                else
                {
                    lbFilterSucc.Text = "IP �������óɹ�, IP " + ip1 + " " + ip2 + " �������Ĺ���ռ�ʱ��������¼.";
                }
            }

            catch (Exception ex)
            {
                lbFilterSucc.Text = ex.Message.ToString();
            }

        }
        else
        {
            lbFilterSucc.Text = "�����������һ�����ռ��ַ.";
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
