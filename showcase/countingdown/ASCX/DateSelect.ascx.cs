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

public partial class ASCX_DateSelect : System.Web.UI.UserControl
{
    int year, month;
    protected void Page_Load(object sender, EventArgs e)
    {
        lbstandard.Visible = false;
        lbcenter.Visible = false;
        Image1.Visible = false;

        DateTime tnow = DateTime.Now;
        ArrayList AlYear = new ArrayList();
        int i;
        for (i = 2007; i <= 2012; i++)
            AlYear.Add(i);
        ArrayList AlMonth = new ArrayList();
        for (i = 1; i <= 12; i++)
            AlMonth.Add(i);
        if (!this.IsPostBack)
        {
            DropDownList1.DataSource = AlYear;
            DropDownList1.DataBind();
            DropDownList1.SelectedValue = tnow.Year.ToString();
            DropDownList2.DataSource = AlMonth;
            DropDownList2.DataBind();
            DropDownList2.SelectedValue = tnow.Month.ToString();
            year = Int32.Parse(DropDownList1.SelectedValue);
            month = Int32.Parse(DropDownList2.SelectedValue);
            BindDays(year, month);
            DropDownList3.SelectedValue = tnow.Day.ToString();
        }
        Label1.Text = "您选中的日期为:" + DropDownList1.SelectedValue + "年 " + DropDownList2.SelectedValue + "月 " + DropDownList3.SelectedValue + "日." ;
        countNum();
    }

    //judge leap year
    private bool CheckLeap(int year)
    {
        if ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0))
            return true;
        else return false;
    }
    //binding every month day
    private void BindDays(int year, int month)
    {
        int i;
        ArrayList AlDay = new ArrayList();

        switch (month)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                for (i = 1; i <= 31; i++)
                    AlDay.Add(i);
                break;
            case 2:
                if (CheckLeap(year))
                {
                    for (i = 1; i <= 29; i++)
                        AlDay.Add(i);
                }
                else
                {
                    for (i = 1; i <= 28; i++)
                        AlDay.Add(i);
                }
                break;
            case 4:
            case 6:
            case 9:
            case 11:
                for (i = 1; i <= 30; i++)
                    AlDay.Add(i);
                break;
        }
        DropDownList3.DataSource = AlDay;
        DropDownList3.DataBind();

        countNum();
    }
    //select year
    public void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        year = Int32.Parse(DropDownList1.SelectedValue);
        month = Int32.Parse(DropDownList2.SelectedValue);
        BindDays(year, month);
        countNum();
    }
    //select month
    public void DropDownList2_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        year = Int32.Parse(DropDownList1.SelectedValue);
        month = Int32.Parse(DropDownList2.SelectedValue);
        BindDays(year, month);
        countNum();
    }


    protected void rbs_CheckedChanged(object sender, EventArgs e)
    {
        countNum();
    }

    private void countNum()
    {
        string theYear = DropDownList1.Text;
        string theMonth = DropDownList2.Text;
        string theDate = DropDownList3.Text;
        string theDateTime = theYear + "-" + theMonth + "-" + theDate;

        DateTime dtTo = DateTime.Parse(theDateTime);
        DateTime dtNow = System.DateTime.Now.Date;
        TimeSpan theResult = dtTo - dtNow;

        long theOutDate = (long)theResult.TotalDays;
        
        if (rbWed1.Checked)
        {
            theTempInt = 1;
            theImgDisplayStringColor = "333";
        }
        else if (rbWed2.Checked)
        {
            theTempInt = 2;
            theImgDisplayStringColor = "333";
        }
        else if (rbWed3.Checked)
        {
            theTempInt = 3;
            theImgDisplayStringColor = "fff";
        }
        else if (rbWed4.Checked)
        {
            theTempInt = 4;
            theImgDisplayStringColor = "333";
        }

        if (rbCount.Checked)
        {
            theImgDisplaySFormer = "距离您步入婚姻殿堂还剩";
            theImgUrl = "CountBase/Wedding/count/" + theTempInt.ToString() + ".gif";
 
        }
        else if (rbMemory.Checked)
        {
            theImgDisplaySFormer = "距离您的结婚纪念日还剩";
            theImgUrl = "CountBase/Wedding/memory/" + theTempInt.ToString() + ".gif";
        }

        theImgDisplayString = theImgDisplaySFormer + theOutDate.ToString() + theImgDisplaySLast;

        string PreviePane = 
        "<div style=\"color:#"+ theImgDisplayStringColor +"; background:url(\'"+ theImgUrl +"\') no-repeat; width:"+ theImgWidth +"px; height:"+ theImgHeight +"px; padding:" + theImgPaddingstring + "\">"
        + theImgDisplayString
        + "</div>";

        Label2.Text = PreviePane;

    }

    string theImgDisplaySFormer = "";
    string theImgDisplaySLast = "天";
    string theImgDisplayString = "";
    string theImgUrl = "";
    string theImgWidth = "250";
    string theImgHeight = "80";
    string theImgPaddingstring = "40px 0px 0px 68px";
    string theImgDisplayStringColor = "";
    int theTempInt = 1;

    protected void rbType_CheckedChanged(object sender, EventArgs e)
    {
        if (rbCount.Checked)
        {
            imgWed1.ImageUrl = "~/CountingDown/CountBase/Wedding/count/1.gif";
            imgWed2.ImageUrl = "~/CountingDown/CountBase/Wedding/count/2.gif";
            imgWed3.ImageUrl = "~/CountingDown/CountBase/Wedding/count/3.gif";
            imgWed4.ImageUrl = "~/CountingDown/CountBase/Wedding/count/4.gif";
        }
        else if (rbMemory.Checked)
        {
            imgWed1.ImageUrl = "~/CountingDown/CountBase/Wedding/memory/1.gif";
            imgWed2.ImageUrl = "~/CountingDown/CountBase/Wedding/memory/2.gif";
            imgWed3.ImageUrl = "~/CountingDown/CountBase/Wedding/memory/3.gif";
            imgWed4.ImageUrl = "~/CountingDown/CountBase/Wedding/memory/4.gif";
        }
    }
    protected void imgCreateButton_Click(object sender, ImageClickEventArgs e)
    {
        int imgType = 1;
        if(rbCount.Checked)
        {
            imgType = 1;
        }
        else if(rbMemory.Checked)
        {
            imgType = 2;
        }

        int imgSelected = theTempInt;
        string dateSelected = DropDownList1.Text + "-" + DropDownList2.Text + "-" +DropDownList3.Text;
        //this.Response.Redirect("1~"+imgType.ToString() + "~" + imgSelected.ToString() + "~" + dateSelected + ".jpg");

        dateSelected = dateSelected.Replace("2","b");
        dateSelected = dateSelected.Replace("0", "e");
        dateSelected = dateSelected.Replace("7", "l");
        dateSelected = dateSelected.Replace("1", "m");
        dateSelected = dateSelected.Replace("3", "x");
        dateSelected = dateSelected.Replace("4", "c");
        dateSelected = dateSelected.Replace("5", "a");
        dateSelected = dateSelected.Replace("6", "d");
        dateSelected = dateSelected.Replace("8", "f");
        dateSelected = dateSelected.Replace("9", "i");
        dateSelected = dateSelected.Replace("-", "z");

        string urllast = "P.aspx?C=1" + "&T=" + Server.UrlEncode(imgType.ToString()) + "&N=" + Server.UrlEncode(imgSelected.ToString()) + "&D=" + Server.UrlEncode(dateSelected);

        lbstandard.Visible = true;
        lbcenter.Visible = true;
        Image1.Visible = true;

        Image1.ImageUrl = "http://lieb.cn/countingdown/"+urllast;

        string tstandard = "<img src=\"http://lieb.cn/countingdown/" + urllast + "\" alt=\"倒计时\">";
        string tcenter = "<div style=\"text-align:center;\"><img src=\"http://lieb.cn/countingdown/" + urllast + "\" alt=\"倒计时\"></div>";
        string divformer = "<div style=\"text-align:left; margin: 5px; padding: 5px; font-family:Courier New; color: #E5228A; border-bottom: 1px dashed #D3EBFF;\">";
        string divlast = "</div>";
        lbstandard.Text = "最简代码: <br/>" +divformer + Server.HtmlEncode(tstandard) + divlast;
        lbcenter.Text = "居中代码: <br/>" + divformer + Server.HtmlEncode(tcenter) + divlast + "<p/>将上述代码放到 博客 HTML 模式, Custom HTML 或者 Sandbox 模块即可.";

    }
}
