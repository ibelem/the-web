<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="IPTracking" ValidateRequest="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true" />
    <div>
        <asp:Label ID="Label2" runat="server" Text="您的空间地址: "></asp:Label>
        http://<asp:TextBox ID="TextBox1" runat="server" MaxLength="48" Width="108px"></asp:TextBox>.spaces.live.com<br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="获得IP记录代码" OnClick="Button1_Click" />&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="查看IP访问记录" OnClick="Button2_Click" /><p />
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        
        </div>
        <p />
          <div style="text-align:left;margin-top:20px;">
      &copy; 2008 <a href="http://belemview.com" title="BELEM" target="_blank">BELEM</a> <a href="http://belemview.spaces.live.com" title="SPACE" target="_blank">共享空间</a>
    </div>  
    
    </form>
</body>
</html>
