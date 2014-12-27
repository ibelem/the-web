<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="/">

<html>

<head>
<title><xsl:for-each select="b"><xsl:value-of select="e" /> - <xsl:value-of select="l" /></xsl:for-each></title>
<meta http-equiv="content-type" content="text/html; charset=utf-8" /> 
<meta http-equiv="Content-Language" content="utf-8" />
<meta name="robots" content="all" />
<meta name="author" content="beyondsoft, 博彦科技" />
<meta name="Copyright" content="Copyright (c) 2008 博彦培训月刊编辑社" />
<meta name="description" content="博彦培训月刊" />
<meta name="keywords" content="博彦培训月刊" />
<link type="text/css" href="../../css/ver200808_olympic.css" media="all" rel="stylesheet" />
<link type="text/css" href="../../css/nav_olympic.css" media="all" rel="stylesheet" />
<style type="text/css">
#authorImgnow_dingding {
	height:64px;
	width:64px;
	background:#fff url('../../img/64_64/<xsl:for-each select="b/m/author"><xsl:value-of select="img" /></xsl:for-each>') no-repeat;
}
.ileaf {
	background:#fff url('../../img/ileaf.gif') no-repeat center;
	height:25px;
}

</style>
<script type="text/javascript" src="../../js/jquery-1.1.3.1.min.js"></script>
<script type="text/javascript" src="../../js/jquery.easing.min.js"></script>
<script type="text/javascript" src="../../js/jquery.lavalamp.min.js"></script>
<script type="text/javascript" src="../../js/wego.js"></script>
<script type="text/javascript" src="../../js/slide_sidebar.js"></script>
</head>

<body>
<div id="wrap">
<div id="header">
<div id="nav">
<ul class="ui-tabs-nav" id="1">
 	<li><a href="../../default.htm" title="Home page">首 页</a></li>
    <li><a href="../../articles.htm" title="Articles">存 档</a></li>
    <li><a href="../../topics.htm" title="Topics">栏 目</a></li>
    <li><a href="../../contribution.htm" title="Contribution">投 稿</a></li>
    <li><a href="../../about.htm" title="About">关 于</a></li>
</ul>
</div>
<div id="mNum"><xsl:for-each select="b"><xsl:value-of select="l" /> <xsl:value-of select="e2" /></xsl:for-each></div>
<div id="logo"></div>
</div>
<div id="main">
<div id="left">
<div class="article" id="default">
<div class="title"><xsl:for-each select="b/m"><xsl:value-of select="title" /></xsl:for-each></div>
<div class="articleby">Author: <xsl:for-each select="b/m/author"><xsl:value-of select="name" /></xsl:for-each> 
Topic: <xsl:for-each select="b/m/topic">
<xsl:variable name="topicname">
	<xsl:value-of select="name"/>
</xsl:variable>
<xsl:variable name="topicid">
	<xsl:value-of select="id"/>
</xsl:variable>

<a href="../../topics.htm#{$topicid}" title="{$topicname}"><xsl:value-of select="name"/></a>
</xsl:for-each>
</div>
<div class="ileaf"></div>
<xsl:for-each select="b/m/article/i">
<div class="items"><xsl:value-of select="section" /></div>
</xsl:for-each>


<xsl:for-each select="b/m/article/gif">
<xsl:variable name="imgsrc">
  <xsl:value-of select="section" /> 
</xsl:variable>
<div style="text-align:center;padding:20px 0px;"><img src="../../img/{$imgsrc}" alt="" /></div>
</xsl:for-each>

<xsl:for-each select="b/m/article/i2">
<div class="items"><xsl:value-of select="section" /></div>
</xsl:for-each>

<xsl:for-each select="b/m/article/i3">
<xsl:variable name="attachsrc">
  <xsl:value-of select="section" /> 
</xsl:variable>
<div style="text-align:center;padding:10px 0px;"><a href="../../articles/03/{$attachsrc}" title="程序下载">本文程序下载</a></div>
</xsl:for-each>



<div class="articleAbout">
<div class="authorImg"><div id="authorImgnow_dingding"></div></div>
<div class="authorAboutT">作者信息: <xsl:for-each select="b/m/author"><xsl:value-of select="name" /></xsl:for-each></div>
<div class="authorAboutL"><xsl:for-each select="b/m/author"><xsl:value-of select="intro" /></xsl:for-each></div>
<div class="authorAboutLITLE">E-Mail: <xsl:for-each select="b/m/author"><xsl:value-of select="email" /></xsl:for-each> </div>
<div class="authorAboutLITLE"><xsl:for-each select="b/m/author"><xsl:value-of select="other" /></xsl:for-each></div>
<div class="authorAboutLITLEF"> </div>
</div>
<div id="fnav">
<ul id="pagination-digg">
 
      <!-- <li  class="next-off">&amp;raquo;</li> -->
      <li><a href="../03/transformationa.xml">10</a></li>
            <li><a href="../03/transformation.xml">9</a></li>
      <li><a href="../03/innovation.xml">8</a></li>      
      <li><a href="../03/management.xml">7</a></li>
      <li><a href="../03/learningscript.xml">6</a></li>
      <li><a href="../03/hottech.xml">5</a></li>
      <li><a href="../03/specialfocus.xml">4</a></li>      
      <li><a href="../03/feature.xml">3</a></li>
      <li><a href="../03/monthlyoverview.xml">2</a></li>
      <li><a href="../03/default.xml">1</a></li>
     <!--	<li class="previous-off">&amp;laquo; </li> -->

</ul>
</div>
<div class="articleFooter"></div>
</div>
</div>


<div id="right">
<div class="notes">
<h4>第三期内容</h4>
<ol class="catalog">
<xsl:for-each select="b/m/topic/id">
<xsl:variable name="classP">
  <xsl:if test="1"></xsl:if> 
</xsl:variable>



<li class="{$classP}"><a href="../02/default.xml" title="">刊首语(Preface)</a></li>
<li class="{$classP}"><a href="../02/monthlyoverview.xml" title="">培训之星(Monthly Overview)</a></li>
<li><a href="../03/feature.xml" title="">特写(Feature)</a></li>
<li><a href="../03/specialfocus.xml" title="">特别关注(Special Focus)</a></li>
<li><a href="../03/hottech.xml" title="">热点技术(Hot Tech + Info)</a></li>
<li><a href="../03/learningscript.xml" title="">学习手记(Learning Script)</a></li>
<li><a href="../03/management.xml" title="">管理(Management)</a></li>
<li><a href="../03/innovation.xml" title="">创新(Innovation)</a></li>
<li><a href="../03/transformation.xml" title="">成长(Transformation)</a></li>
<li><a href="../03/transformationa.xml" title="">成长(Transformation)a</a></li>
<li><a href="../../mini/03/default.htm" title="">3月 Mini Page</a></li>
<li><a href="../../mini/02/default.htm" title="">2月 Mini Page</a></li>
<li><a href="../../mini/01/default.htm" title="">1月 Mini Page</a></li>



</xsl:for-each>
</ol>
</div>
</div>

<div id="right2">
<div class="iimg"></div>
<div class="notes2">
<div id="headerquote">Quit. Don't quit.</div>
</div>
</div>


</div>
<div style="clear: both;"></div>
<div id="footer">
©2008 <span style="color:#669900">B</span><span style="color:#FF3399">T</span><span style="color:#3366FF">O</span> Beyondsoft Training Online - 博彦培训月刊 保留所有权利
</div>
</div>

</body>

</html>

</xsl:template>

</xsl:stylesheet> 

