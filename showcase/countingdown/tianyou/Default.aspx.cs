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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DateTime dtTo = DateTime.Parse("2009.09.22");
            DateTime dtNow = System.DateTime.Now.Date;
            TimeSpan theResult = dtTo - dtNow;

            long theOutDate = (long)theResult.TotalDays;

            string imgFromUrl = "1.jpg";

            string imgTextShow = "距离2009年09月22日还有 " + theOutDate.ToString() + " 天";

            int imgPointLeft = 110;
            int imgPointTop = 120;

            Bitmap bm = new Bitmap(Server.MapPath(imgFromUrl), true);
            Graphics g = Graphics.FromImage(bm);

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.High;
            g.SmoothingMode = SmoothingMode.HighQuality;

            Color tcColor = new Color();
            tcColor = ColorTranslator.FromHtml("#fff");
            //Color bgcColor = new Color();
            //bgcColor = ColorTranslator.FromHtml("#" + bgc);
            SolidBrush tcbrush = new SolidBrush(tcColor);
            //g.Clear(Color.Transparent);
            g.DrawString(imgTextShow, new Font("tahoma", 9), tcbrush, imgPointLeft, imgPointTop);
            g.Dispose();
            bm.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch
        {
            this.Response.Redirect("http://belemview.spaces.live.com");
        }

    }
}
