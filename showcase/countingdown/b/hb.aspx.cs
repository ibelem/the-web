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

public partial class CountingDown_hb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            LiBo();
        }
        catch
        {
            ;
        }

    }

    private void LiBo()
    {
         
        string imgTextShow = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + System.DateTime.Now.DayOfWeek.ToString();
       
	//string imgTextShow = "Hello CHina";
        string imgFromUrl = "hb2.jpg";

        Bitmap bm = new Bitmap(Server.MapPath(imgFromUrl), true);
        Graphics g = Graphics.FromImage(bm);

        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        g.CompositingQuality = CompositingQuality.HighQuality;
        g.InterpolationMode = InterpolationMode.High;
        g.SmoothingMode = SmoothingMode.HighQuality;

        Color tcColor = new Color();
        tcColor = ColorTranslator.FromHtml("#333333");
        //Color bgcColor = new Color();
        //bgcColor = ColorTranslator.FromHtml("#" + bgc);
        SolidBrush tcbrush = new SolidBrush(tcColor);
        //g.Clear(Color.Transparent);
        g.DrawString(imgTextShow, new Font("tahoma", 12), tcbrush, 400, 30);
        g.Dispose();
        bm.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
    }
}
