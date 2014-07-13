<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RSS.aspx.cs" Inherits="IPTrack_RSS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ÎÒµÄ IP Track ¼ÇÂ¼</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Belem_ADongNiConnectionString %>" SelectCommand="SELECT TOP 20 [SpaceAlias], [IPs], [IPTime], [RealAddress] FROM [SpacesIPs] WHERE ([SpaceAlias] = @SpaceAlias) ORDER BY [IPTime] DESC">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="" Name="SpaceAlias" QueryStringField="user"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
