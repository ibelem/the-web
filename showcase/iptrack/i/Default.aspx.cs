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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class IPTrack_i_Default : System.Web.UI.Page
{
    string user = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        //SELECT DISTINCT TOP 10 IPs, IPTime, RealAddress
        //FROM SpacesIPs
        //WHERE (SpaceAlias = 'bestinmedotcn') AND (RealAddress LIKE '%扬州%')
        //ORDER BY IPTime DESC

        //SELECT DISTINCT TOP 10 ipid, IPs, IPTime, RealAddress
        //FROM SpacesIPs
        //WHERE (SpaceAlias = 'bestinmedotcn') AND (ipid NOT IN
        //          (SELECT ipid
        //         FROM SpacesIPs AS SpacesIPs_1
        //         WHERE (RealAddress LIKE '%承德%') OR
        //               (RealAddress LIKE '%洛阳%')))
        //ORDER BY IPTime DESC


        //if (!String.IsNullOrEmpty(Request.Params["user"].ToString()))
        //{
        //    user = Server.HtmlEncode(Request.Params["user"].ToString());
        //    getData(user);
        //}

        //else
        //{
            
        //}

        try
        {
            if (!String.IsNullOrEmpty(Request.Params["user"].ToString()))
            {
                CreateRandomCode();
                user = Server.HtmlEncode(Request.Params["user"].ToString());
                getData(user);
            }
 
        }
        catch(Exception ex)
        {
            string iii = ex.Message.ToString();
        }
    } 

    private void getData(string theUser)
    {
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["Belem_ADongNiConnectionString"].ToString();
        
        string sqlC = "SELECT DISTINCT TOP 5 ipid, IPs, IPTime, RealAddress FROM SpacesIPs WHERE (SpaceAlias = '"+ theUser +"') ORDER BY IPTime DESC";
        SqlDataAdapter dadpt = new SqlDataAdapter(sqlC, connstr);
        DataSet ds = new DataSet();
        dadpt.Fill(ds, "ips");

        if (!(ds.Tables["ips"].Rows.Count < 5))
        {
            string IP1 = ds.Tables["ips"].Rows[0]["IPs"].ToString();
            string IP2 = ds.Tables["ips"].Rows[1]["IPs"].ToString();
            string IP3 = ds.Tables["ips"].Rows[2]["IPs"].ToString();
            string IP4 = ds.Tables["ips"].Rows[3]["IPs"].ToString();
            string IP5 = ds.Tables["ips"].Rows[4]["IPs"].ToString();

            string Address1 = ds.Tables["ips"].Rows[0]["RealAddress"].ToString();
            string Address2 = ds.Tables["ips"].Rows[1]["RealAddress"].ToString();
            string Address3 = ds.Tables["ips"].Rows[2]["RealAddress"].ToString();
            string Address4 = ds.Tables["ips"].Rows[3]["RealAddress"].ToString();
            string Address5 = ds.Tables["ips"].Rows[4]["RealAddress"].ToString();

            string Time1 = ds.Tables["ips"].Rows[0]["IPTime"].ToString();
            string Time2 = ds.Tables["ips"].Rows[1]["IPTime"].ToString();
            string Time3 = ds.Tables["ips"].Rows[2]["IPTime"].ToString();
            string Time4 = ds.Tables["ips"].Rows[3]["IPTime"].ToString();
            string Time5 = ds.Tables["ips"].Rows[4]["IPTime"].ToString();

            ds.Clear();
            dadpt.Dispose();

            createVcode(IP1, IP2, IP3, IP4, IP5, Address1, Address2, Address3, Address4, Address5, Time1, Time2, Time3, Time4, Time5);
        }
        else
        {
            createVcode("数据量不足, 您当前IP记录数小于5.");
        }


         
    }

    string randomCode = "";
    private void CreateRandomCode()
    {
        Random rand = new Random();
        int t = rand.Next(0, 3);
        randomCode = t.ToString();
    }

    private void createVcode(string i1, string i2,string i3,string i4,string i5,
        string a1, string a2, string a3, string a4, string a5,
        string t1,string t2, string t3, string t4, string t5)
    {
        string imgFromUrl = "img/" + randomCode + ".jpg";

        Bitmap bm = new Bitmap(Server.MapPath(imgFromUrl), true);
        Graphics g = Graphics.FromImage(bm);

        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        //g.CompositingQuality = CompositingQuality.HighQuality;
        //g.InterpolationMode = InterpolationMode.High;
        //g.SmoothingMode = SmoothingMode.HighQuality;

        
        float imgPointTop1 = 24;
        float imgPointTop2 = 40;
        float imgPointTop3 = 56;
        float imgPointTop4 = 72;
        float imgPointTop5 = 88;

        float imgPointLeft1 = 190;
        float imgPointLeft2 = 330;
        float imgPointLeft3 = 520;

        Color tcColor = new Color();
        tcColor = ColorTranslator.FromHtml("#76923C");
        SolidBrush tcbrush = new SolidBrush(tcColor);
        g.DrawString(i1, new Font("tahoma", 12), tcbrush, imgPointLeft1, imgPointTop1);
        g.DrawString(i2, new Font("tahoma", 12), tcbrush, imgPointLeft1, imgPointTop2);
        g.DrawString(i3, new Font("tahoma", 12), tcbrush, imgPointLeft1, imgPointTop3);
        g.DrawString(i4, new Font("tahoma", 12), tcbrush, imgPointLeft1, imgPointTop4);
        g.DrawString(i5, new Font("tahoma", 12), tcbrush, imgPointLeft1, imgPointTop5);

        g.DrawString(a1, new Font("tahoma", 12), tcbrush, imgPointLeft2, imgPointTop1);
        g.DrawString(a2, new Font("tahoma", 12), tcbrush, imgPointLeft2, imgPointTop2);
        g.DrawString(a3, new Font("tahoma", 12), tcbrush, imgPointLeft2, imgPointTop3);
        g.DrawString(a4, new Font("tahoma", 12), tcbrush, imgPointLeft2, imgPointTop4);
        g.DrawString(a5, new Font("tahoma", 12), tcbrush, imgPointLeft2, imgPointTop5);

        g.DrawString(t1, new Font("tahoma", 12), tcbrush, imgPointLeft3, imgPointTop1);
        g.DrawString(t2, new Font("tahoma", 12), tcbrush, imgPointLeft3, imgPointTop2);
        g.DrawString(t3, new Font("tahoma", 12), tcbrush, imgPointLeft3, imgPointTop3);
        g.DrawString(t4, new Font("tahoma", 12), tcbrush, imgPointLeft3, imgPointTop4);
        g.DrawString(t5, new Font("tahoma", 12), tcbrush, imgPointLeft3, imgPointTop5);

        g.DrawString("DEMO - " + user + " 空间的 IP 访问显示. - By BELEM", new Font("tahoma", 12), tcbrush, 80, 108);

        g.Dispose();
        bm.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
    }

    private void createVcode(string notEnough)
    {
        string imgFromUrl = "img/" + randomCode + ".jpg";

        Bitmap bm = new Bitmap(Server.MapPath(imgFromUrl), true);
        Graphics g = Graphics.FromImage(bm);

        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        g.CompositingQuality = CompositingQuality.HighQuality;
        g.InterpolationMode = InterpolationMode.High;
        g.SmoothingMode = SmoothingMode.HighQuality;

        float imgPointLeft1 = 20;
        float imgPointTop1 = 20;

        Color tcColor = new Color();
        tcColor = ColorTranslator.FromHtml("#76923C");
        SolidBrush tcbrush = new SolidBrush(tcColor);
        g.DrawString(notEnough, new Font("tahoma", 11), tcbrush, imgPointLeft1, imgPointTop1);

        g.Dispose();
        bm.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
    }
}
