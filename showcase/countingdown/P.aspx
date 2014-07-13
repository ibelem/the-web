<%@ Page Language="C#" AutoEventWireup="true" CodeFile="P.aspx.cs" Inherits="P" %>

<%@ Register Src="ASCX/Counter.ascx" TagName="Counter" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>BELEM - 倒计时你个头</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Language" content="utf-8" />
<meta name="robots" content="all" />
<meta name="author" content="Belem, BelemCheung@hotmail.com" />
<meta name="Copyright" content="Copyright (c) 2006 Belem, 张敏" />
<meta name="description" content="Counting Down, Count down, Spaces, Windows Live, Belem,Easy Start To The Day" />
<meta name="keywords" content="Counting Down, Count down, Spaces, Windows Live, Belem,Easy Start To The Day" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:Counter ID="Counter1" runat="server" />
    
    </div>
    </form>
</body>
</html>
