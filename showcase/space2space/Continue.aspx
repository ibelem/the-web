<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Continue.aspx.cs" Inherits="S2S_Continue" ValidateRequest="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>Windows Live Spaces - 从共享空间搬家到共享空间</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" /> 
    <meta name="robots" content="all" /><meta name="author" content="Belem, BelemCheung@hotmail.com" />
    <meta name="Copyright" content="Copyright (c) 2007 Belem, 张敏" />
    <meta name="description" content="Lieb, Windows Live Spaces系列小工具, By Belem, 张敏, Easy Start To The Day" />
    <meta name="keywords" content="Lieb, Windows Live Spaces, MSN, Spaces, Windows Live, Belem, 张敏, Easy Start To The Day, 年华已逝" />
    <script type="text/javascript" src="js/jquery121.min.js"></script>
    <script type="text/javascript" src="js/jtip.js"></script>
    <script type="text/javascript" src="js/yougo.js"></script>
    <link href="css/global.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
          <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true" AsyncPostBackTimeout="360000000" />
    <div class="wrap">
    
    <div class="part1">
    <div id="mtitle">Windows Live Spaces - 从共享空间搬家到共享空间 - 继续搬迁</div>
    <div class="title">继续配置您的空间</div>
    <div class="Items">
        源空间搬迁<a href="cont.htm?width=384" id="four" class="jTip" name="什么是失败的第一篇日志固定链接">失败的第一篇日志固定链接</a>:
        <asp:TextBox ID="tbsource" runat="server" AutoPostBack="true" BackColor="LavenderBlush" BorderStyle="Solid" BorderWidth="1px" Width="460px" MaxLength="264" OnTextChanged="tbsource_TextChanged"></asp:TextBox><br />
            搬家到: http://<asp:TextBox ID="tbspaces" runat="server" BackColor="LavenderBlush" BorderStyle="Solid" BorderWidth="1px" Width="89px" MaxLength="64" OnTextChanged="tbspaces_TextChanged" AutoPostBack="True"></asp:TextBox>.spaces.live.com | 
            新空间机密字(区分大小写): <asp:TextBox ID="tbsec" runat="server" BackColor="LavenderBlush" BorderStyle="Solid" BorderWidth="1px" Width="89px" MaxLength="10" OnTextChanged="tbsec_TextChanged" AutoPostBack="True"></asp:TextBox>  <br />  
                   <asp:UpdateProgress ID="Up1" DynamicLayout="true" runat="server"><ProgressTemplate><div id="divShowMeProgress" class="NoErrorProgress"><img src="images/loading.gif" alt="数据处理中..." />  数据处理中, 请稍后.</div></ProgressTemplate></asp:UpdateProgress>

            <asp:UpdatePanel ID="upSandT" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                 <asp:Label ID="lbSourceSpaceCheck" runat="server" Text=""></asp:Label>
                <asp:Label ID="lbTargetSpaceCheck" runat="server" Text=""></asp:Label>
                <asp:Label ID="lbBlank" runat="server" Text=""></asp:Label>
             </ContentTemplate>
             <Triggers>
             <asp:AsyncPostBackTrigger ControlID="tbsource" EventName="TextChanged"/>
              <asp:AsyncPostBackTrigger ControlID="tbspaces" EventName="TextChanged"/>
               <asp:AsyncPostBackTrigger ControlID="tbsec" EventName="TextChanged"/>
               <asp:AsyncPostBackTrigger ControlID="btMove" EventName="Click" />
             </Triggers>
            </asp:UpdatePanel>
            
            <asp:UpdatePanel ID="upPreStatus" runat="server" UpdateMode="Conditional">
            <ContentTemplate> 
                <asp:Label ID="lbPub" runat="server" Text=""></asp:Label>
             </ContentTemplate>
             <Triggers>
                          <asp:AsyncPostBackTrigger ControlID="cbPub" EventName="CheckedChanged" />
             <asp:AsyncPostBackTrigger ControlID="cbFoot" EventName="CheckedChanged" />
             <asp:AsyncPostBackTrigger ControlID="cbDateFormat" EventName="CheckedChanged" />
             <asp:AsyncPostBackTrigger ControlID="btMove" EventName="Click" />
             </Triggers>
            </asp:UpdatePanel> 
 
            <span class="startC">*</span> <asp:CheckBox ID="cbPub" runat="server" Text="" OnCheckedChanged="cbPub_CheckedChanged" AutoPostBack="true" ForeColor="Transparent" /> 源空间已设置为公共空间 
            <span class="startC">*</span> <asp:CheckBox ID="cbFoot" runat="server" OnCheckedChanged="cbFoot_CheckedChanged" AutoPostBack="true" Text="" /> 源空间的日志日期已设置为在页脚显示 
            <span class="startC">*</span> <asp:CheckBox ID="cbDateFormat" OnCheckedChanged="cbDateFormat_CheckedChanged"  AutoPostBack="true" runat="server" Text=""  /> 源空间的日志日期显示格式已按要求设置 <br />
    </div>
    <div class="title">新空间日志增强</div>
    <div class="Items">
    <asp:CheckBox ID="cbAddDate" runat="server" Text="在新空间日志中添加原发布日期"/> 底部显示"原发布日期: 2005.10.31 20:07:04" 请配置源日志日期在页脚显示, 否则该项选择后日期不正确.<br />
    <asp:CheckBox ID="cbAddUrl" runat="server" Text="在新空间日志中添加原URL地址"/> 底部显示"查看原日志地址"<br />
      </div>
 
    <div class="title">继续搬迁结果</div>
    <div class="Items">
    <asp:UpdatePanel ID="upMoveNow" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="lbProgressFront" runat="server" Text="如下日志被搬迁到您的新空间."></asp:Label> <br /><br />
                <asp:Label ID="lbProgressResult" runat="server" Text=""></asp:Label>
                <br /><asp:Label ID="lbProgressEnd" runat="server" Text="您也可以将上述结果复制为源空间日志地图."></asp:Label>
             </ContentTemplate>
             <Triggers>
             <asp:AsyncPostBackTrigger ControlID="btMove" EventName="Click" />
             </Triggers>
            </asp:UpdatePanel>

    </div>
 
     <div class="title"></div>
    <div class="do">
     <asp:Button ID="btMove" runat="server" Text="继续搬家!" Width="200px" OnClick="btMove_Click"/>  
    </div>
    
    <div class="title">注意事项</div>
    <div class="Items">
    1. 搬家时请注意保持您的网络连接正常, 搬家时间视您网络速度, 空间日志多少决定, 可能会持续数小时.<br />
    2. 本搬家工具只能搬空间日志, 其他如日志评论, 日志发布时间, 相册, 列表等一律不能搬迁.<br />
    3. 如果您是首次搬家, 请到<a href="Default.aspx" title="空间搬家">空间搬家</a>执行相应操作...  
    </div>
    <p />
     
    </div>
        <cc1:TextBoxWatermarkExtender  ID="TBWt1" runat="server" WatermarkCssClass="twater" TargetControlID="tbsource" WatermarkText="http://gb2312.spaces.live.com/blog/cns!3CDBA96A871601F6!262.entry"></cc1:TextBoxWatermarkExtender>
    <cc1:TextBoxWatermarkExtender  ID="TextBoxWatermarkExtender1" runat="server" WatermarkCssClass="twater" TargetControlID="tbspaces" WatermarkText="belemview"></cc1:TextBoxWatermarkExtender>
    <cc1:TextBoxWatermarkExtender  ID="TextBoxWatermarkExtender2" runat="server" WatermarkCssClass="twater" TargetControlID="tbsec" WatermarkText="belem"></cc1:TextBoxWatermarkExtender>
    </div>
        <div id="iFooter">
<%--            <a href="http://validator.w3.org/check?uri=http://lieb.cn/s2s" title="Validated XHTML 1.0 Transitional" target="_blank"><img src="images/icons/xhtmlb.gif" alt="XHTML 1.0"/></a> <a href="http://jigsaw.w3.org/css-validator/validator?uri=http://lieb.cn/s2s" title="Validated CSS" target="_blank"><img src="images/icons/cssb.gif" alt="Validated CSS" /></a> <a href="" title="RSS"><img src="images/icons/rssb.gif" alt="RSS Feed"/></a><p />
--%> 
 <p/>
本页所用的悠嘻猴图片版权归属悠嘻猴作者, 致意!
<br />由于共享空间不断在更新, 若空间升级后本搬家工具不可用, 请及时告知 <a href="http://belemview.spaces.live.com" title="BELEM 的共享空间" target="_blank">BELEM</a>.<br />
    &copy; 2007 This is <a href="http://belemview.spaces.live.com" title="BELEM 的共享空间" target="_blank">BELEM</a> 郁闷, 很郁闷 
 
    </div>
 
    </form>

</body>
</html>
