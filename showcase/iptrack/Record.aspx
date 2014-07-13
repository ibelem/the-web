<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Record.aspx.cs" Inherits="Record"  ViewStateEncryptionMode="Never" EnableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>BELEM - IP Track</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Language" content="utf-8" />
<meta name="robots" content="all" />
<meta name="author" content="Belem, hi@live.com" />
<meta name="Copyright" content="Copyright (c) 2008 Belem, 张敏" />
<meta name="description" content="IP Track, Windows Live Spaces 小工具, By Belem, 张敏" />
<meta name="keywords" content="IP Track, Windows Live Spaces 小工具, By Belem, 张敏" />
<link href="css/photoborder.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
      <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true" />
    
    <div id="B_Header">  
    <a href="http://www.belemview.com/bbs" title="belemview.com"><img src="img/logo.gif" style="border-width:0px;" alt="小声讨论" /></a> 
</div>
 
<div id="B_HeaderNav"> 
    <a href="http://lieb.cn" title="首 页">首 页 </a><span> &gt; </span><a href="Default.aspx" title="IP Track">IP Track</a> </div>
<div id="B_Outer_Wrapper">

	<div id="B_Wrapper">
		<div id="B_LeftMainContainer">
 
            <div id="B_LeftNav">
             
 

<div class="btnleftNav2"> 
<script type="text/javascript"><!--
google_ad_client = "pub-9899474829491302";
google_alternate_color = "FFFFFF";
google_ad_width = 120;
google_ad_height = 240;
google_ad_format = "120x240_as";
google_ad_type = "text_image";
google_ad_channel ="";
google_color_border = "FFFFFF";
google_color_bg = "FFFFFF";
google_color_link = "333333";
google_color_url = "232323";
google_color_text = "4C4C4C";
//--></script>
<script type="text/javascript"
  src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
</script>
</div>
 
 
            </div>			
				
			<div id="B_Main"> 
           
<div id="B_S1"> <asp:Label ID="Label2"
            runat="server" Text=""></asp:Label> 的 IP Track 
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/IPTrack/img/feed.gif" OnClick="ImageButton1_Click" AlternateText="您的 IP Track RSS Feed" />
 
<div class="thepanel">
      
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label> <p /> 
     <div style="text-align:center;">
     过滤不作记录的IP列表<br /> 
     
     
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:IPTrackConnectionString %>" SelectCommand="SELECT [FilterIP], [ipid] FROM [IPTrackIPFilter] WHERE ([SpaceAlias] = @SpaceAlias)" OldValuesParameterFormatString="original_{0}" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [IPTrackIPFilter] WHERE [ipid] = @original_ipid AND [FilterIP] = @original_FilterIP" InsertCommand="INSERT INTO [IPTrackIPFilter] ([FilterIP]) VALUES (@FilterIP)" UpdateCommand="UPDATE [IPTrackIPFilter] SET [FilterIP] = @FilterIP WHERE [ipid] = @original_ipid AND [FilterIP] = @original_FilterIP">
        <SelectParameters>
            <asp:QueryStringParameter Name="SpaceAlias" QueryStringField="user" Type="String" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="original_ipid" Type="Int32" />
            <asp:Parameter Name="original_FilterIP" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="FilterIP" Type="String" />
            <asp:Parameter Name="original_ipid" Type="Int32" />
            <asp:Parameter Name="original_FilterIP" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="FilterIP" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
         &nbsp;<br />
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
         <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"  Width="618px" 
             AutoGenerateColumns="False" DataKeyNames="ipid" DataSourceID="SqlDataSource2" PageSize="5">
             <Columns>
                 <asp:BoundField DataField="ipid" HeaderText="ipid" InsertVisible="False" ReadOnly="True"
                     SortExpression="ipid" Visible="False" />
                 <asp:BoundField DataField="FilterIP" HeaderText="如下 IP 不被记录" SortExpression="FilterIP" />
                 <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" HeaderText="更新" CancelText="取消" DeleteText="删除" EditText="编辑" InsertText="插入" NewText="新增" SelectText="选择" UpdateText="更新" />
             </Columns>
         </asp:GridView>
<%--                  <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AllowSorting="True"  Width="618px" 
             AutoGenerateColumns="False" DataKeyNames="ipid" DataSourceID="SqlDataSource2" PageSize="5">
             <Columns>
                 <asp:BoundField DataField="ipid" HeaderText="ipid" InsertVisible="False" ReadOnly="True"
                     SortExpression="ipid" Visible="false" />
                 <asp:BoundField DataField="FilterIP" HeaderText="如下 IP 不被记录" SortExpression="FilterIP" />
                 <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" HeaderText="更新" />
             </Columns>
         </asp:GridView>--%>
         </ContentTemplate>
         </asp:UpdatePanel><br />
         谁都可以修改删除, 所以各位请问是不是应该增加一个注册的功能? 但是他们说已经不会用了, 郁闷...<p />
    </div>   
     
    <div style="text-align:center;">
        <asp:Label ID="Label3" runat="server" Text="空间地址空间访问记录 点击访问时间按时间排序"></asp:Label><br /><br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Width="618px" PageSize="60" CellPadding="4" ForeColor="#333333" GridLines="None">
            <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="IPs" DataNavigateUrlFormatString="http://edu.dheart.net/ip/index.php?ip={0}"
                    DataTextField="IPs" HeaderText="IP" SortExpression="IPs" Target="_blank" />
                 <asp:HyperLinkField DataNavigateUrlFields="IPs" DataNavigateUrlFormatString="http://www.sogou.com/features/ip.jsp?query={0}"
                    DataTextField="IPs" HeaderText="IP" SortExpression="IPs" Target="_blank" />
                <asp:BoundField DataField="RealAddress" HeaderText="IP 地址" SortExpression="RealAddress" />
                <asp:BoundField DataField="IPTime" HeaderText="访问时间" SortExpression="IPTime" />

            </Columns>
            <FooterStyle BackColor="green" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True"  />
            <HeaderStyle BackColor="green" Font-Bold="True" ForeColor="White"  />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="green" />
        </asp:GridView>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server">返回我的共享空间</asp:HyperLink> | <a href="Default.aspx" title="配置我的空间IP访问记录">配置我的空间</a>
        <br /><br />
        
        <asp:Label ID="Label4" runat="server" Text="因BELEM个人网站数据库大小的原因, 每月10日将清空上月的数据, 请注意及时浏览."></asp:Label><p />
    
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:IPTrackConnectionString %>"
            SelectCommand="SELECT [SpaceAlias], [IPs], [IPTime], [RealAddress] FROM [SpacesIPs] WHERE ([SpaceAlias] = @SpaceAlias) ORDER BY [IPTime] DESC">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="gb2312" Name="SpaceAlias" QueryStringField="user"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

</div>

</div>   


     </div>
 

<div id="B_Footer">&copy;2008 <a href="http://www.belemview.com" title="About Belem" target="_blank">Belem</a> | <a href="http://lieb.cn" title="Lieb!, enhance your Windows Live Spaces.">Lieb.cn</a> | <a href="http://belemview.spaces.live.com " target="_blank" title="Belem的共享空间">共享空间</a> | <a href="http://bbs.belemview.com " target="_blank" title="小声讨论">小声讨论</a>   
 </div>
 </div>
 </div>
 </div>
 
    

        
  
    </form>
</body>
</html>
