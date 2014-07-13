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

public partial class CountingDown_h2 : System.Web.UI.Page
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
        DateTime dtTo = DateTime.Parse("2004/7/26");
        DateTime dtNow = System.DateTime.Now.Date;
        TimeSpan theResult = dtNow - dtTo;

        DateTime dtTo3 = DateTime.Parse("2007/8/10");
        DateTime dtNow3 = System.DateTime.Now.Date;
        TimeSpan theResult3 = dtTo3 - dtNow3;

        long theOutDate = (long)theResult.TotalDays;
        long theOutDate3 = (long)theResult3.TotalDays;

        string imgTextShow = "Belem @ Bsoft: " + theOutDate.ToString() + " days.";
        string imgTextShow3 = "New career: " + theOutDate3.ToString() + " days later.";

        string imgFromUrl = "h3.jpg";

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
        g.DrawString(imgTextShow, new Font("tahoma", 12), tcbrush, 9, 38);
        g.DrawString(imgTextShow3, new Font("tahoma", 12), tcbrush, 9, 54);
        g.Dispose();
        bm.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
    }
}
