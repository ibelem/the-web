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
using System.Xml;

public partial class IPTrack_RSS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (String.IsNullOrEmpty(Request.Params["user"].ToString()) || Request.Params["user"].ToString() == "yyyako" || Request.Params["user"].ToString() == "gb2312")
            {
                this.Response.Redirect("Default.aspx");
            }

            else
            {
                string my = Server.HtmlEncode(Request.Params["user"].ToString());

                string alias = Server.HtmlEncode(my);

                XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, System.Text.Encoding.UTF8);

                WriteRSSPrologue(writer, alias);

                ListItems(writer, alias);

                WriteRSSClosing(writer);
                writer.Flush();
                writer.Close();

                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.ContentType = "text/xml";
                Response.Cache.SetCacheability(HttpCacheability.Public);

                Response.End(); 

            }
            
        }


    }


    private XmlTextWriter WriteRSSPrologue(XmlTextWriter writer, string alias)
    {
        writer.WriteStartDocument();
        writer.WriteStartElement("rss");
        writer.WriteAttributeString("version", "2.0");
        writer.WriteAttributeString("xmlns:dc",
           "http://purl.org/dc/elements/1.1/");
        writer.WriteStartElement("channel");
        writer.WriteElementString("title", "最近访问 http://" + alias + ".spaces.live.com 的 IP 记录");
        writer.WriteElementString("link", "http://lieb.cn/IPTrack/RSS.aspx?user=" + alias);
        writer.WriteElementString("description",
           "IP Track: 显示最近访问 http://" + alias + ".spaces.live.com 的用户来源. - By BELEM");
        writer.WriteElementString("pubDate", DateTime.Now.ToUniversalTime().ToString());
        writer.WriteElementString("copyright", "Copyright 2008 Belem");
        writer.WriteElementString("generator", "IP Track V1.3 http://lieb.cn/iptrack/");

        return writer;
    }


    private void ListItems(XmlTextWriter writer, string alias)
    {
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["IPTrackConnectionString"].ToString();

        string sqlC = "SELECT DISTINCT TOP 20 [IPs], [IPTime], [RealAddress] FROM [SpacesIPs] WHERE ([SpaceAlias] = '" + alias + "') ORDER BY [IPTime] DESC";
        SqlDataAdapter dadpt = new SqlDataAdapter(sqlC, connstr);
        DataSet ds = new DataSet();
        dadpt.Fill(ds, "ips");

        string IP = "";
        string Address = "";
        string t = "";

        for (int i = 0; i < ds.Tables["ips"].Rows.Count; i++)
        {

            IP = ds.Tables["ips"].Rows[i]["IPs"].ToString();
            Address = ds.Tables["ips"].Rows[i]["RealAddress"].ToString();
            t = ds.Tables["ips"].Rows[i]["IPTime"].ToString();
            string ilik = "http://lieb.cn/IPTrack/Record.aspx?user=" + alias;

            string iTitle = "访客: " + Address.Trim();
            string iDes = "IP地址为 " + IP + " 的朋友访问了您的共享空间, 他的真实地址为: " + Address.Trim() + ".";
            AddRSSItem(writer, iTitle, ilik, iDes, t);

        }
    }

    public XmlTextWriter AddRSSItem(XmlTextWriter writer,
         string sItemTitle, string sItemLink,
         string sItemDescription, string idt)
    {
        //DateTime dt = Convert.ToDateTime(idt);
        //dt = dt.ToUniversalTime();

        writer.WriteStartElement("item");
        writer.WriteElementString("title", sItemTitle);
        writer.WriteElementString("link", sItemLink);
        writer.WriteElementString("description", sItemDescription);
        writer.WriteElementString("pubDate", idt);
        writer.WriteEndElement();

        return writer;
    }

    public XmlTextWriter WriteRSSClosing(XmlTextWriter writer)
    {
        writer.WriteEndElement();
        writer.WriteEndElement();
        writer.WriteEndDocument();

        return writer;
    }



    //private void StartRSS(string alias)
    //{
    //    Response.Clear();
    //    Response.ContentType = "text/xml";
    //    Response.ContentEncoding = System.Text.Encoding.UTF8;
    //    XmlSerializer xml = new XmlSerializer(typeof(rss));
    //    xml.Serialize(Response.Output, FakeRss(alias));
    //    Response.End();
    //}

    //private rss FakeRss(string alias)
    //{
    //    rss someRss = new rss();
    //    someRss.version = "2.0";
    //    someRss.channel = new rssChannel();
    //    someRss.channel.description = "IP Track: 显示最近访问 http://" + alias + ".spaces.live.com 的用户来源. - By BELEM";
    //    someRss.channel.language = "zh-cn";
    //    someRss.channel.link = "http://lieb.cn";
    //    someRss.channel.title = "最近访问 http://" + alias + ".spaces.live.com 的 IP 记录";
    //    someRss.channel.pubDate = DateTime.Now.ToUniversalTime();
    //    someRss.channel.generator = "IP Track V1.3 http://lieb.cn/iptrack/ - BELEM";
    //    someRss.channel.lastBuildDate = DateTime.Now.ToUniversalTime();


    //    string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["IPTrackConnectionString"].ToString();

    //    string sqlC = "SELECT DISTINCT TOP 20 [IPs], [IPTime], [RealAddress] FROM [SpacesIPs] WHERE ([SpaceAlias] = '" + alias + "') ORDER BY [IPTime] DESC";
    //    SqlDataAdapter dadpt = new SqlDataAdapter(sqlC, connstr);
    //    DataSet ds = new DataSet();
    //    dadpt.Fill(ds, "ips");

    //    string IP = "";
    //    string Address = "";
    //    string t = "";

    //    for (int i = 0; i < ds.Tables["ips"].Rows.Count; i++)
    //    {

    //        IP = ds.Tables["ips"].Rows[i]["IPs"].ToString();
    //        Address = ds.Tables["ips"].Rows[i]["RealAddress"].ToString();
    //        t = ds.Tables["ips"].Rows[i]["IPTime"].ToString();

    //        string iTitle = "新访客来自: " + Address.Trim();
    //        string iDes = "IP地址为 " + IP + " 的朋友访问了您的共享空间, 他的真实地址为: " + Address.Trim() + ".";

    //        rssChannelItem channelItem = new rssChannelItem();
    //        DateTime dt = Convert.ToDateTime(t);
    //        dt = dt.ToUniversalTime();

    //        channelItem.pubDate = dt;
    //        channelItem.title = iTitle;
    //        channelItem.link = "http://lieb.cn/IPTrack/RSS.aspx?user=" + alias;
    //        channelItem.guid = "http://" + alias + ".spaces.live.com";
    //        channelItem.description = iDes;
    //        someRss.channel.item = new rssChannelItem[] { channelItem };
    //    }



    //    ds.Clear();
    //    dadpt.Dispose();

    //    return someRss;
    //}

    ////private void Channels(rss someRss, string alias, string ititle, string idescription, string idt)
    ////{
    ////    rssChannelItem channelItem = new rssChannelItem();
    ////    DateTime dt = Convert.ToDateTime(idt);
    ////    dt = dt.ToUniversalTime();

    ////    channelItem.pubDate = dt;
    ////    channelItem.title = ititle;
    ////    channelItem.link = "http://lieb.cn/IPTrack/RSS.aspx?user=" + alias;
    ////    channelItem.guid = "http://" + alias + ".spaces.live.com";
    ////    channelItem.description = idescription;
    ////    someRss.channel.item = new rssChannelItem[] { channelItem };

    ////}
}
