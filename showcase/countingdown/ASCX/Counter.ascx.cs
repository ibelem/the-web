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

public partial class ASCX_Counter : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
            try
            
            {
            //?Cate=1&imgType=1&ImgNum=1&toDate=date
            string theCate = Server.UrlDecode(this.Request.Params[0].ToString());
            string theType = Server.UrlDecode(this.Request.Params[1].ToString());
            string theNum = Server.UrlDecode(this.Request.Params[2].ToString());
            string theDate = Server.UrlDecode(this.Request.Params[3].ToString());

            theDate = theDate.Replace("b", "2");
            theDate = theDate.Replace("e", "0");
            theDate = theDate.Replace("l", "7");
            theDate = theDate.Replace("m", "1");
            theDate = theDate.Replace("x", "3");
            theDate = theDate.Replace("c", "4");
            theDate = theDate.Replace("a", "5");
            theDate = theDate.Replace("d", "6");
            theDate = theDate.Replace("f", "8");
            theDate = theDate.Replace("i", "9");
            theDate = theDate.Replace("z", "-");

            GetImg(theDate, theCate, theType, theNum);

        }
        catch
        {
            this.Response.Redirect("Default.aspx");
        }
    }


    private void GetImg(string theDate, string theCate, string theType, string theNum)
    {
        try
        {
            DateTime dtTo = DateTime.Parse(theDate);
            DateTime dtNow = System.DateTime.Now.Date;
            TimeSpan theResult = dtTo - dtNow;

            long theOutDate = (long)theResult.TotalDays;

            //int imgWidth = 0;
            //int imgHeight = 0;
            int imgPointLeft = 0;
            int imgPointTop = 0;
            string imgTextFormer = "";
            string imgTextLast = "天";
            string imgTextColor = "";
            string imgFromUrl = "";

            if (theCate == "1")
            {
                //imgWidth = 250;
                //imgHeight = 80;
                imgPointLeft = 60;
                imgPointTop = 48;

                if (theType == "1")
                {
                    imgTextFormer = "距离您步入婚姻殿堂还剩";
                    imgFromUrl = "CountBase/Wedding/count/" + theNum.ToString() + ".jpg";
                }
                else if (theType == "2")
                {
                    imgTextFormer = "距离您的结婚纪念日还剩";
                    imgFromUrl = "CountBase/Wedding/memory/" + theNum.ToString() + ".jpg";
                }

                if (theNum == "1")
                {
                    imgTextColor = "333";
                }
                else if (theNum == "2")
                {
                    imgTextColor = "333";
                }
                else if (theNum == "3")
                {
                    imgTextColor = "fff";
                }
                else if (theNum == "4")
                {
                    imgTextColor = "333";
                }

            }
            else if (theCate == "2")
            {
                //imgWidth = 350;
                //imgHeight = 180;
                imgPointLeft = 0;
                imgPointTop = 8;

                if (theType == "1")
                {
                    imgTextFormer = "距离您步入婚姻殿堂还剩";
                }
                else if (theType == "2")
                {
                    imgTextFormer = "距离您的结婚纪念日还剩";
                }

                if (theNum == "1")
                {
                    imgTextColor = "333";
                }
                else if (theNum == "2")
                {
                    imgTextColor = "333";
                }
                else if (theNum == "3")
                {
                    imgTextColor = "fff";
                }
                else if (theNum == "4")
                {
                    imgTextColor = "333";
                }

            }


            string imgTextShow = imgTextFormer + theOutDate.ToString() + imgTextLast;


            Bitmap bm = new Bitmap(Server.MapPath(imgFromUrl), true);
            Graphics g = Graphics.FromImage(bm);

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.High;
            g.SmoothingMode = SmoothingMode.HighQuality;

            Color tcColor = new Color();
            tcColor = ColorTranslator.FromHtml("#" + imgTextColor);
            //Color bgcColor = new Color();
            //bgcColor = ColorTranslator.FromHtml("#" + bgc);
            SolidBrush tcbrush = new SolidBrush(tcColor);
            //g.Clear(Color.Transparent);
            g.DrawString(imgTextShow, new Font("tahoma", 11), tcbrush, imgPointLeft, imgPointTop);
            g.Dispose();
            bm.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch
        {
            this.Response.Redirect("Default.aspx");
        }
     
    }
}
