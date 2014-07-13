<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Record.aspx.cs" Inherits="Record"  ViewStateEncryptionMode="Never" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>BELEM - IP Tracking - Results</title>
    <style type="text/css">
    body {
    
    font-size: 12px;
    font-family: verdana, arial;
    color: #333;
    
    margin-left: 20px;
    
    }
    
    a:link, a:visited, a:active {
    text-decoration: none;
    color: #E5228A;
    }

    a:hover
    {
    text-decoration: underline;
    color: #333;
    }
    
    
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
        <asp:Label ID="Label1" runat="server" Text="您的共享空间地址为:"></asp:Label> <asp:Label ID="Label2"
            runat="server" Text=""></asp:Label> <p /><p /><br />
    <div style="text-align:center;">
        <asp:Label ID="Label3" runat="server" Text="最近访问您空间的IP历史记录 点击访问时间按时间排序"></asp:Label><br /><br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1"
            ForeColor="#333333" GridLines="None" Width="618px" PageSize="60">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <Columns>
 
 <asp:HyperLinkField DataNavigateUrlFields="IPs" DataNavigateUrlFormatString="http://edu.dheart.net/ip/index.php?ip={0}"
                    DataTextField="IPs" HeaderText="IP地址" SortExpression="IPs" Target="_blank" />

                <asp:BoundField DataField="IPTime" HeaderText="访问时间" SortExpression="IPTime" />
            </Columns>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server">返回我的共享空间</asp:HyperLink> | <a href="Default.aspx" title="配置我的空间IP访问记录">配置我的空间</a>
        <br /><br />
        
        <asp:Label ID="Label4" runat="server" Text="因BELEM个人网站数据库大小的原因, 每月10日将清空上月的数据, 请注意及时浏览."></asp:Label><p />
    
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Belem_ADongNiConnectionString %>"
            SelectCommand="SELECT [ipid], [SpaceAlias], [IPs], [IPTime] FROM [SpacesIPs] WHERE ([SpaceAlias] = @SpaceAlias)">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="gb2312" Name="SpaceAlias" QueryStringField="user"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        
      <div style="text-align:left;margin-top:20px;">
      &copy; 2007 <a href="http://belemview.com" title="BELEM" target="_blank">BELEM</a> <a href="http://gb2312.spaces.live.com" title="SPACE" target="_blank">SPACE</a>
      <br /><span style="font-size:9px;">The first small tool for Windows Live Spaces users after BELEM left Windows Live China Spaces Core Team. [W/O AJAX Version]</span></div>  
    </form>
</body>
</html>
