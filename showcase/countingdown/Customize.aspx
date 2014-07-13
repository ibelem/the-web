<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Customize.aspx.cs" Inherits="_Customize" %>

<%@ Register Src="ASCX/CustomizeSelect.ascx" TagName="CustomizeSelect" TagPrefix="uc2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>BELEM - 倒计时</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Language" content="utf-8" />
<meta name="robots" content="all" />
<meta name="author" content="Belem, BelemCheung@hotmail.com" />
<meta name="Copyright" content="Copyright (c) 2006 Belem, 张敏" />
<meta name="description" content="Counting Down, Count down, Spaces, Windows Live, Belem,Easy Start To The Day" />
<meta name="keywords" content="Counting Down, Count down, Spaces, Windows Live, Belem,Easy Start To The Day" />
<link type="text/css" href="suppports/thestyle.css" media="screen" rel="Stylesheet" />
<link href="../CountingDown/suppports/ajaxtabs.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
       <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
        </cc1:ToolkitScriptManager>
        
 <div id="wrap">

<div id="headertop">&nbsp;</div>


<div id="content-wrap">


<div id="header">
<div id="headerleiste"></div>
<div id="header_inner" class="fixed">
<div id="homebutton" onclick="location.href='http://blog.belemview.com';" style="cursor: pointer;"></div>
<div id="v_logo" onclick="location.href='http://blog.belemview.com';" style="cursor: pointer;">
<h1 style="display: none;"><span >BELEM Counting Down</span></h1>
</div>


</div>
</div>


<uc2:CustomizeSelect ID="CustomizeSelect1" runat="server" />



<div id="belemfooterim">
  <div class="belemfooterim_contain clearfix">
  <h1 id="logo"><a href="http://belemview.com/" accesskey="1">BELEM</a></h1>
	
	<div id="belemfootertext">
	 &copy; 2007 This is Belem. Belem worries about his life.
	</div> 
 </div>
 
</div> 
</div>
 </div> 
          
 
    </form>
</body>
</html>
