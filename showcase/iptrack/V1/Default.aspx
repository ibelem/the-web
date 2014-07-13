<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="IPTracking" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>BELEM - IP Tracking</title>
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
    <div>
        <asp:Label ID="Label2" runat="server" Text="您的空间地址: "></asp:Label>
        http://<asp:TextBox ID="TextBox1" runat="server" MaxLength="48" Width="108px"></asp:TextBox>.spaces.live.com<br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="获得IP记录代码" OnClick="Button1_Click" />&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="查看IP访问记录" OnClick="Button2_Click" /><p />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label></div>
        <p />
          <div style="text-align:left;margin-top:20px;">
      &copy; 2007 <a href="http://belemview.com" title="BELEM" target="_blank">BELEM</a> <a href="http://gb2312.spaces.live.com" title="SPACE" target="_blank">SPACE</a>
      <br /><span style="font-size:9px;">The first small tool for Windows Live Spaces users after BELEM left Windows Live China Spaces Core Team. [W/O AJAX Version]</span></div>  
    
    </form>
</body>
</html>
