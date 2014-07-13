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
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
 

public partial class S2S_Default : System.Web.UI.Page
{
    //public static List<string> strPUIDlist = new List<string>();
    public List<SpaceBlog> listBlog = new List<SpaceBlog>();

    public class SpaceBlog
    {
        public string Blog_CNT;
        public string Blog_TITL;
        public string Blog_DATE;
        public string Blog_CATE;
        public string _UID;
        public string _PUID;

        
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbSourceSpaceCheck.Visible = false;
            lbTargetSpaceCheck.Visible = false;
            lbBlank.Visible = false;
        }

    }
    protected void cbPub_CheckedChanged(object sender, EventArgs e)
    {
        VerifyThreePreCheck();
    }
    protected void cbFoot_CheckedChanged(object sender, EventArgs e)
    {
        VerifyThreePreCheck();
    }
    protected void cbDateFormat_CheckedChanged(object sender, EventArgs e)
    {
        VerifyThreePreCheck();
    }
    protected void btMove_Click(object sender, EventArgs e)
    {

        if (cbPub.Checked && cbFoot.Checked && cbDateFormat.Checked)
        {
            lbPub.Visible = false;
            StartStrip();
        }
        else
        {
            //ThreadStart ts = new ThreadStart(VerifyThreePreCheck);
            //Thread td = new Thread(ts);
            //td.Start();
            VerifyThreePreCheck();
        }

    }

    private void StartStrip()
    {

        if (!String.IsNullOrEmpty(tbsource.Text.Trim()) && !String.IsNullOrEmpty(tbsec.Text.Trim()) && !String.IsNullOrEmpty(tbspaces.Text.Trim()))
        {
            try
            {
                   string theLastLink = "http://" + tbsource.Text.Trim() + ".spaces.live.com/default.aspx?_c11_BlogPart_pagedir=Last&_c11_BlogPart_BlogPart=blogview&_c=BlogPart&mkt=zh-cn";
                theBelemShrinkrWeb.BelemSpaceMover bsm = new theBelemShrinkrWeb.BelemSpaceMover();
                    bsm.getHTMLPageCodes(theLastLink, "UTF-8");
                    string getTheFirstScreenSourceCode2 = bsm.fullPage;

                    if (!String.IsNullOrEmpty(getTheFirstScreenSourceCode2))
                    {
                        BelemWantToStrip(getTheFirstScreenSourceCode2);
                        lbSourceSpaceCheck.Visible = false;
                        lbTargetSpaceCheck.Visible = true;
                        lbTargetSpaceCheck.Text = "<div id=\"divMoveSpacesSucc\" class=\"NoError\"> <img src=\"images/bq/002.gif\" alt=\"Success!\" /> ��ϲ, ���ѳɹ���ҵ�<a href=\"http://" + tbspaces.Text.Trim() + ".spaces.live.com\" title=\"�鿴�����¿ռ�\" target=\"_blank\">http://" + tbspaces.Text.Trim() + ".spaces.live.com</a></div>"; 
                    }
                    else
                    {
                        lbSourceSpaceCheck.Visible = true;
                        lbSourceSpaceCheck.Text = "<div id=\"divCheckSourceSpacesA\" class=\"OnError\"> <img src=\"images/bq/101.gif\" alt=\"Failed!\" /> ���ź�, Դ�ռ䷵���˿�����, ����Դ����ռ�����ݲ����û����������������������...</div>";
                    }
                
            }

            catch (Exception e)
            {

                string kkk = e.Message.ToString();
                lbSourceSpaceCheck.Visible = true;
                lbSourceSpaceCheck.Text = "<div id=\"divCheckSourceSpacesErr2\" class=\"OnError\"><img src=\"images/bq/101.gif\" alt=\"Failed!\" />" + kkk + "�ǳ��ź�, �޷����Դ�ռ�����. <br/> ��ȷ�����������־ģ�鵽Դ����ռ���, Ҳ����Դ����ռ�����ݲ����û�����������/���ٴ�������...</div>";
            }
        }
        else
        {
            lbBlank.Visible = true;
            lbBlank.Text = "<div id=\"divCheckBlank\" class=\"OnError\"><img src=\"images/bq/101.gif\" alt=\"Failed!\" /> ��Щ�ط��հ�δ��, ����ȷ��д...</div>";

        }
    }

    public string theUID = "";

    private void BelemWantToStrip(string verifyThePage)
    {
 
            string strRegExPattern = @"blog/cns![A-Z0-9]{15,16}![0-9]{1,20}.entry#trackback";

            RegexOptions ro = RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.IgnoreCase;
            MatchCollection mc = Regex.Matches(verifyThePage, strRegExPattern, ro);

            int iFirstToLast = 0;
            string iAmFirstpermalink = "";
            theBelemShrinkrWeb.BelemSpaceMover bsm = new theBelemShrinkrWeb.BelemSpaceMover();
            bsm.MyStripped(verifyThePage, strRegExPattern);

            iAmFirstpermalink = bsm.RegEd.ToString();
            iAmFirstpermalink = iAmFirstpermalink.Replace("blog/cns!", "");
            iAmFirstpermalink = iAmFirstpermalink.Replace(".entry#trackback", "");


            string getUIDReg = @"![A-Z0-9]{15,16}!";
            bsm.MyStripped(verifyThePage, getUIDReg);
            theUID = bsm.RegEd.ToString();
            theUID = theUID.Replace("!", "");

            iAmFirstpermalink = iAmFirstpermalink.Replace(theUID + "!", "");
            int intIAmFirstpermalink2 = Int32.Parse(iAmFirstpermalink);

            foreach (Match onebyone in mc)
            {
                string myCid = onebyone.ToString();
                myCid = myCid.Replace("blog/cns!", "");
                myCid = myCid.Replace(".entry#trackback", "");
                myCid = myCid.Replace(theUID + "!", "");

               
                iFirstToLast++;
                //// strPUIDlist.Add(myCid);
                if (iFirstToLast == 20)
                {
                    kickYouOffSon(verifyThePage, theUID, myCid, true);
                }
                else
                {
                    kickYouOffSon(verifyThePage, theUID, myCid, false);
                }

            }

            if (iFirstToLast >= 20)
            {
                iFirstToLast = 0;
                string newHereYouGo = "http://" + tbsource.Text.Trim() + ".spaces.live.com/?_c11_BlogPart_pagedir=Previous&_c11_BlogPart_handle=cns!" + theUID + "!" + iAmFirstpermalink + "&_c11_BlogPart_BlogPart=blogview&_c=BlogPart&mkt=zh-cn";
                letsGoFurther(newHereYouGo, iAmFirstpermalink);
            }
            else
            {
                CheckPushOrNot(true);
            }
 
    }

    private void letsGoFurther(string newTWUrl, string theNextPageTopPUID)
    {
        try
        {
            theBelemShrinkrWeb.BelemSpaceMover bsm2 = new theBelemShrinkrWeb.BelemSpaceMover();
            bsm2.getHTMLPageCodes(newTWUrl, "UTF-8");
            string gotYouTW = bsm2.fullPage;

            string strRegExPattern = @"blog/cns![A-Z0-9]{15,16}![0-9]{1,20}.entry#trackback";

            RegexOptions ro = RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.IgnoreCase;
            MatchCollection mc = Regex.Matches(gotYouTW, strRegExPattern, ro);

            int iFirstToLast = 0;
            string iAmFirstpermalink = "";
            bsm2.MyStripped(gotYouTW, strRegExPattern);

            iAmFirstpermalink = bsm2.RegEd.ToString();
            iAmFirstpermalink = iAmFirstpermalink.Replace("blog/cns!", "");
            iAmFirstpermalink = iAmFirstpermalink.Replace(".entry#trackback", "");
            iAmFirstpermalink = iAmFirstpermalink.Replace(theUID + "!", "");

            int intIAmFirstpermalink = Int32.Parse(iAmFirstpermalink);

            foreach (Match onebyone in mc)
            {
                string myCid = onebyone.ToString();
                myCid = myCid.Replace("blog/cns!", "");
                myCid = myCid.Replace(".entry#trackback", "");
                myCid = myCid.Replace(theUID + "!", "");

                int intMyCid = Int32.Parse(myCid);
                int inttheNextPageTopPUID = Int32.Parse(theNextPageTopPUID);

                if (intMyCid > inttheNextPageTopPUID)
                {
                    iFirstToLast++;
                    //// strPUIDlist.Add(myCid);
                    if (iFirstToLast == 20)
                    {
                        kickYouOffSon(gotYouTW, theUID, myCid, true);
                    }
                    else 
                    {
                        kickYouOffSon(gotYouTW, theUID, myCid, false);
                    }
                }
                
            }

            if (iFirstToLast == 20)
            {
                iFirstToLast = 0;
                string newHereYouGoNextTW = "http://" + tbsource.Text.Trim() + ".spaces.live.com/?_c11_BlogPart_pagedir=Previous&_c11_BlogPart_handle=cns!" + theUID + "!" + iAmFirstpermalink + "&_c11_BlogPart_BlogPart=blogview&_c=BlogPart&mkt=zh-cn";
                letsGoFurther(newHereYouGoNextTW, iAmFirstpermalink);
            }
            else
            {
                CheckPushOrNot(true);
            }

        }
        catch(Exception e)
        {
            string lllll = e.Message.ToString();
            lbBlank.Visible = true;
            lbBlank.Text = "<div id=\"divCheckBlankCatch\" class=\"OnError\"><img src=\"images/bq/101.gif\" alt=\"Failed!\" /> " + lllll + " </div>";
        }


    }

    public int j = 1;

    private void kickYouOffSon(string pageHTMLS, string theUID, string thePUID, bool hi)
    {
        theBelemShrinkrWeb.BelemSpaceMover bsmReg = new theBelemShrinkrWeb.BelemSpaceMover();
        string strFirstReg = @"entrycns!"+ theUID + "!"+ thePUID +"(.*)cns!" + theUID + "!" +thePUID+ ".entry#post";
        bsmReg.MyStripped(pageHTMLS, strFirstReg);
        string theClearedPage = bsmReg.RegEd;

        string _title = "";
        string strRegExPatternEntryTitle = @"subjcns!"+ theUID +"!"+ thePUID +"(.{0,512})</a></h4>";
        bsmReg.MyStripped(theClearedPage, strRegExPatternEntryTitle);
        _title = bsmReg.RegEd;
        string replaceBlogTitleFront = "subjcns!" + theUID + "!" + thePUID + "\">" + "<a href=\"" + "http://" + tbsource.Text.Trim() +".spaces.live.com/blog/cns!"+ theUID +"!"+ thePUID +".entry" + "\">";
        string replaceBlogTitleBehind = "</a></h4>";
        _title = _title.Replace(replaceBlogTitleFront, "");
        _title = _title.Replace(replaceBlogTitleBehind, "");
        //_title = HttpUtility.HtmlDecode(_title);

        if (_title == "")
        {
            _title = "�ޱ�����־";
        }

        string _cate = "";
        string strRegExPatternEntryCate = "bv:cat=\".{0,128}\"><h4";
        bsmReg.MyStripped(theClearedPage, strRegExPatternEntryCate);
        _cate = bsmReg.RegEd;
        string replaceBlogCateFront = "bv:cat=\"";
        string replaceBlogCateBehind = "\"><h4";
        _cate = _cate.Replace(replaceBlogCateFront, "");
        _cate = _cate.Replace(replaceBlogCateBehind, "");
        if (_cate == "")
        {
            _cate = "Ĭ�����";
        }

        string _body = "";
        string strRegExPatternEntryBody = "bvMsg\">(.*)</div>( *)<div class=\"footerLinks\">";
        bsmReg.MyStripped(theClearedPage, strRegExPatternEntryBody);
        _body = bsmReg.RegEd;
        string replaceBlogBodyFront = "bvMsg\">";
        string replaceBlogBodyBehind = "</div><div class=\"footerLinks\">";
        string replaceBlogBodyBehind2 = "</div> <div class=\"footerLinks\">";
        _body = _body.Replace(replaceBlogBodyFront, "");
        _body = _body.Replace(replaceBlogBodyBehind, "");
        _body = _body.Replace(replaceBlogBodyBehind2, "");


        string _date = "";
        string strRegExPatternEntryDate = @"class=" + "\"footerLinks\"> *<nobr> *(20[0-2][0-9]/[0-1]?[0-9]/[0-9]?[0-9]) +(([01]?[0-9])|(2[0-3])):([0-5]?[0-9]):([0-5]?[0-9]) *</nobr>";
        bsmReg.MyStripped(theClearedPage, strRegExPatternEntryDate);
        _date = bsmReg.RegEd;
        string replaceBlogDateFront = "class=\"footerLinks\"><nobr>";
        string replaceBlogDateBehind = "</nobr>";
        _date = _date.Replace(replaceBlogDateFront, "");
        _date = _date.Replace(replaceBlogDateBehind, "");
        if (_date == "")
        {
            _date = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        string _uid = theUID;
        string _puid = thePUID;

        SpaceBlog _tempblog = new SpaceBlog();
        _tempblog.Blog_CNT = _body;
        _tempblog.Blog_DATE = _date;
        _tempblog.Blog_TITL = _title;
        _tempblog.Blog_CATE = _cate;
        _tempblog._UID = _uid;
        _tempblog._PUID = _puid;
        //this._Blog.Add(_tempblog);
        listBlog.Add(_tempblog);

        CheckPushOrNot(hi);

        
    }

    private void CheckPushOrNot(bool hi)
    {
        if (hi == true)
        {
            int maxEntries = listBlog.Count;
            for (int i = maxEntries - 1; i >= 0; i--)
            {
                string uid = listBlog[i]._UID.ToString();
                string puid = listBlog[i]._PUID.ToString();
                string sourceUrl = "http://" + tbsource.Text.Trim() + ".spaces.live.com/blog/cns!" + uid + "!" + puid + ".entry";
                string blogTitle = listBlog[i].Blog_TITL.ToString();
                string blogDate = listBlog[i].Blog_DATE.ToString();
                string blogDes = listBlog[i].Blog_CNT.ToString();

                if (cbAddDate.Checked && cbAddUrl.Checked) 
                {
                    blogDes = blogDes + "<br/><br/><div>" + "<a href=\"" + sourceUrl + "\" title=\"�鿴ԭ��־��ַ\" target=\"_blank\">�鿴ԭ��־��ַ</a>" + " ԭ��������: " + blogDate + "</div>";
                }
                else if (cbAddUrl.Checked && !cbAddDate.Checked)
                {
                    blogDes = blogDes + "<br/><br/><div>" + "<a href=\"" + sourceUrl + "\" title=\"�鿴ԭ��־��ַ\" target=\"_blank\">�鿴ԭ��־��ַ</a></div>";
                }
                else if (!cbAddUrl.Checked && cbAddDate.Checked)
                {
                    blogDes = blogDes + "<br/><br/><div> ԭ��������: " + blogDate + "</div>";
                }
                
                string blogCate = listBlog[i].Blog_CATE.ToString();

                moveToNewSpaces(tbspaces.Text.Trim(), tbsec.Text.Trim(), blogTitle, blogDes, blogDate, blogCate, j, puid);
                j++;
            }
            listBlog.Clear();
        }
    }


    private void moveToNewSpaces(string username, string password, string blogTitle, string blogDes, string blogDate, string blogCate, int numEntries, string thePUID)
    {
        GetMyAPI.getBelem_fromAPI gbelem = new GetMyAPI.getBelem_fromAPI();

        try
        {
            gbelem.postYourInfo(username, password, blogCate, blogTitle, blogDes);
            ShowMyProgress(blogTitle, numEntries, thePUID);
            //lbBlank.Text += iiiii;
            //lbBlank.Visible = true;
        }
        catch (Exception e)
        {
            lbBlank.Visible = true;
            lbBlank.Text = e.Message.ToString();
        }
    }

 
    private void ShowMyProgress(string blogTitle, int numEntries, string puid)
    {
        lbProgressResult.Visible = true;
        string myPUrl = "http://" + tbsource.Text.Trim() + ".spaces.live.com/blog/cns!" + theUID + "!" + puid + ".entry";
        string iiiii = "<div class=\"moving\">" + numEntries.ToString() + ". <a href=\"" + myPUrl + "\" title=\"" + blogTitle +" \" target=\"_blank\">" + blogTitle + "</a></div>";
        lbProgressResult.Text += iiiii;
    }

    protected void tbsource_TextChanged(object sender, EventArgs e)
    {
        CheckSourceLinkAccessible();
    }

    protected void tbspaces_TextChanged(object sender, EventArgs e)
    {
        CheckTargetSpaceAccessible();
    }


    protected void tbsec_TextChanged(object sender, EventArgs e)
    {
        CheckTargetSpaceAccessible();
    }


    private void CheckTargetSpaceAccessible()
    {
        if (!String.IsNullOrEmpty(tbsec.Text.Trim()) && !String.IsNullOrEmpty(tbspaces.Text.Trim()))
        {
            lbBlank.Visible = false;
            if (tbspaces.Text.Trim() == tbsource.Text.Trim())
            {
                lbTargetSpaceCheck.Visible = true;
                lbTargetSpaceCheck.Text = "<div id=\"divCheckTargetSpaces\" class=\"OnError\"><img src=\"images/bq/101.gif\" alt=\"Failed!\" /> �Բ���, BELEM ��Ϳ��, ��ѡ�����Լ����Լ��ռ���, �˷�������Դ, ���˷ѵ簡!!!</div>";
            }
            else
            {
                try
                {
                    GetMyAPI.getBelem_fromAPI gbf = new GetMyAPI.getBelem_fromAPI();
                    gbf.getSpaceInfo(tbspaces.Text.Trim(), tbsec.Text.Trim());

                    string checkEqualInfo = gbf.TheGetUrl;
                    checkEqualInfo = checkEqualInfo.Replace("http://spaces.msn.com/members/", "");

                    if (checkEqualInfo == tbspaces.Text.Trim())
                    {
                        lbTargetSpaceCheck.Visible = true;
                        lbTargetSpaceCheck.Text = "<div id=\"divCheckTargetSpaces\" class=\"NoError\"><img src=\"images/bq/002.gif\" alt=\"Success!\" /> ��ϲ! �¿ռ��ַ�ͻ����ֶ���ȷ, �������� http://" + tbspaces.Text.Trim() + ".spaces.live.com ���!</div>";
                    }
                    else
                    {
                        lbTargetSpaceCheck.Visible = true;
                        lbTargetSpaceCheck.Text = "<div id=\"divCheckTargetSpaces\" class=\"OnError\"><img src=\"images/bq/102.gif\" alt=\"Failed!\" />  ���ź�, �¿ռ��ַ�ͻ����ֿ��ܴ��ڴ���, ���޷��� http://" + tbspaces.Text.Trim() + ".spaces.live.com ���, ���޸ĺ�����!</div>";
                    }
                }
                catch
                {
                    lbTargetSpaceCheck.Visible = true;
                    lbTargetSpaceCheck.Text = "<div id=\"divCheckTargetSpaces\" class=\"OnError\"><img src=\"images/bq/102.gif\" alt=\"Failed!\" /> �ǳ��ź�, �¿ռ��ַ������ֿ��ܴ��ڴ���, �޷��� http://" + tbspaces.Text.Trim() + ".spaces.live.com ���, ���޸���ȷ������!</div>";
                }
            }
        }
        else
        {
            lbBlank.Visible = true;
            lbBlank.Text = "<div id=\"divCheckBlank\" class=\"OnError\"><img src=\"images/bq/101.gif\" alt=\"Failed!\" /> �¿ռ��ַ�������δ��, ����ȷ��д...</div>";
        }
    }

 
    private void CheckSourceLinkAccessible()
    {
        if (!String.IsNullOrEmpty(tbsource.Text.Trim()))
        {
            lbBlank.Visible = false;

            try
            {
                string theFirstLink = "http://" + tbsource.Text.Trim() + ".spaces.live.com/minimal/feed.rss";
                theBelemShrinkrWeb.BelemSpaceMover bsm = new theBelemShrinkrWeb.BelemSpaceMover();
                bsm.getHTMLPageCodes(theFirstLink, "UTF-8");

                string getTheFirstScreenSourceCode = bsm.fullPage;


                if (!String.IsNullOrEmpty(bsm.fullPage))
                {
                    if (getTheFirstScreenSourceCode.Contains("<live:type>blog</live:type>"))
                    {
                        lbSourceSpaceCheck.Visible = true;
                        lbSourceSpaceCheck.Text = "<div id=\"divCheckSourceSpacesCA\" class=\"NoError\"><img src=\"images/bq/001.gif\" alt=\"Success!\" /> ��ϲ! Դ�ռ� http://" + tbsource.Text.Trim() + ".spaces.live.com ��ַ��ȷ! ��ȷ��Դ�ռ���־ģ��������ҷ���������������������.</div>";
                    }
                    else
                    {
                        lbSourceSpaceCheck.Visible = true;
                        lbSourceSpaceCheck.Text = "<div id=\"divCheckSourceSpacesCB\" class=\"OnError\"><img src=\"images/bq/101.gif\" alt=\"Failed!\" /> ���ź�, Դ�ռ�δ������ȷ����, ��ȷ��Դ�ռ� http://" + tbsource.Text.Trim() + ".spaces.live.com Ȩ��Ϊ��������־ģ�������?</div>";
                    }
                }
                else
                {
                    lbSourceSpaceCheck.Visible = true;
                    lbSourceSpaceCheck.Text = "<div id=\"divCheckSourceSpacesCError\" class=\"OnError\"> <img src=\"images/bq/101.gif\" alt=\"Failed!\" /> ���ź�, Դ�ռ䷵���˿�����, ��ȷ��Դ�ռ� http://" + tbsource.Text.Trim() + ".spaces.live.com Ȩ��Ϊ��������־ģ�������?</div>";
                }
            }

            catch 
            {
                try
                { 
                    string theFirstLink = "http://" + tbsource.Text.Trim() + ".spaces.live.com";
                    theBelemShrinkrWeb.BelemSpaceMover bsm = new theBelemShrinkrWeb.BelemSpaceMover();
                    bsm.getHTMLPageCodes(theFirstLink, "UTF-8");

                    string getTheFirstScreenSourceCode = bsm.fullPage;


                    if (!String.IsNullOrEmpty(bsm.fullPage))
                    {
                        if (getTheFirstScreenSourceCode.Contains("spaces.css"))
                        {
                            lbSourceSpaceCheck.Visible = true;
                            lbSourceSpaceCheck.Text = "<div id=\"divCheckSourceSpaces\" class=\"NoError\"><img src=\"images/bq/001.gif\" alt=\"Success!\" /> ��ϲ! Դ�ռ� http://" + tbsource.Text.Trim() + ".spaces.live.com ��ַ��ȷ! ��ȷ��Դ�ռ���־ģ��������ҷ���������������������.</div>";
                        }
                        else
                        {
                            lbSourceSpaceCheck.Visible = true;
                            lbSourceSpaceCheck.Text = "<div id=\"divCheckSourceSpaces\" class=\"OnError\"><img src=\"images/bq/101.gif\" alt=\"Failed!\" /> ���ź�, Դ�ռ�δ������ȷ����, ��ȷ��Դ�ռ� http://" + tbsource.Text.Trim() + ".spaces.live.com Ȩ��Ϊ��������־ģ�������?</div>";
                        }
                    }
                    else
                    {
                        lbSourceSpaceCheck.Visible = true;
                        lbSourceSpaceCheck.Text = "<div id=\"divCheckSourceSpaces\" class=\"OnError\"> <img src=\"images/bq/101.gif\" alt=\"Failed!\" /> ���ź�, Դ�ռ䷵���˿�����, ��ȷ��Դ�ռ� http://" + tbsource.Text.Trim() + ".spaces.live.com Ȩ��Ϊ��������־ģ�������?</div>";
                    }

                }

                catch(Exception ec)
                {
                    string kkk = ec.Message.ToString();
                    lbSourceSpaceCheck.Visible = true;
                    lbSourceSpaceCheck.Text = "<div id=\"divCheckSourceSpaces\" class=\"OnError\"><img src=\"images/bq/101.gif\" alt=\"Failed!\" />" + kkk + " �ǳ��ź�, �޷����Դ�ռ�����, ��ȷ��Դ�ռ� http://" + tbsource.Text.Trim() + ".spaces.live.com Ȩ��Ϊ��������־ģ�������?</div>";
                }
                }
        }
        else
        {
            lbBlank.Visible = true;
            lbBlank.Text = "<div id=\"divCheckBlank\" class=\"OnError\"><img src=\"images/bq/101.gif\" alt=\"Failed!\" /> Դ�ռ��ַδ��, ����ȷ��д...</div>";
        }
    }
    private void VerifyThreePreCheck()
    {
        string error1 = "ֻ�н�Դ�ռ�����Ϊ��������ִ�а�Ҳ���.";
        string error2 = "ֻ�н�Դ�ռ���־��������Ϊ��ҳ����ʾ����ִ�а�Ҳ���.";
        string error3 = "ֻ�н�Դ�ռ���־��������Ϊָ����ʽ����ִ�а�Ҳ���.";
        string theBr = "<br/>";

        if (cbPub.Checked && cbFoot.Checked && cbDateFormat.Checked)
        {
            lbPub.Visible = false;
        }
        else if (cbPub.Checked && !cbFoot.Checked && !cbDateFormat.Checked)
        {
            lbPub.Visible = true;
            lbPub.Text = "<div id=\"divPub\" class=\"OnError\">" + error2 + theBr + error3 + "</div>";
        }
        else if (!cbPub.Checked && cbFoot.Checked && !cbDateFormat.Checked)
        {
            lbPub.Visible = true;
            lbPub.Text = "<div id=\"divPub\" class=\"OnError\">" + error1 + theBr + error3 + "</div>";
        }
        else if (!cbPub.Checked && !cbFoot.Checked && cbDateFormat.Checked)
        {
            lbPub.Visible = true;
            lbPub.Text = "<div id=\"divPub\" class=\"OnError\">" + error1 + theBr + error2 + "</div>";
        }
        else if (cbPub.Checked && cbFoot.Checked && !cbDateFormat.Checked)
        {
            lbPub.Visible = true;
            lbPub.Text = "<div id=\"divPub\" class=\"OnError\">" + error3 + "</div>";
        }
        else if (!cbPub.Checked && cbFoot.Checked && cbDateFormat.Checked)
        {
            lbPub.Visible = true;
            lbPub.Text = "<div id=\"divPub\" class=\"OnError\">" + error1 + "</div>";
        }
        else if (cbPub.Checked && !cbFoot.Checked && cbDateFormat.Checked)
        {
            lbPub.Visible = true;
            lbPub.Text = "<div id=\"divPub\" class=\"OnError\">" + error2 + "</div>";
        }
        else
        {
            lbPub.Visible = true;
            lbPub.Text = "<div id=\"divPub\" class=\"OnError\">" + error1 + theBr + error2 + theBr + error3 + "</div>";
        }

    }



}
