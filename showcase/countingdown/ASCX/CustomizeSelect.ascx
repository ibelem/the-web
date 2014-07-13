<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CustomizeSelect.ascx.cs" Inherits="ASCX_CustomizeSelect" %>


<div id="main_inner" class="fixed">
<div id="main_belem_3c">
<div id="belem_3c_l1">    
 
    <div class="post">
	
<div class="entry" id="hereitis">
    
<div>    
<asp:UpdatePanel ID="UpdatePanel1" runat="server">

<ContentTemplate>
1. 您的倒计日期 
&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" Width="80px">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True" Width="80px" >
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" Width="80px">
        </asp:DropDownList> 
    
<%-- <a href="#featuredbanners" title="更多样式">更多</a>--%>
</ContentTemplate>
</asp:UpdatePanel>
</div>

<div>    
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
<ContentTemplate>
2. 输入显示文字:
<asp:TextBox ID="tbFront" runat="server" MaxLength="24" Width="140px" OnTextChanged="tbFront_TextChanged" AutoPostBack="true">距离BELEM生日还有</asp:TextBox><asp:TextBox ID="tbAllDates" runat="server" MaxLength="4" Width="40px" OnTextChanged="tbFront_TextChanged" AutoPostBack="true" Enabled="False">0</asp:TextBox><asp:TextBox ID="tbTextLast" runat="server" MaxLength="12" Width="51px" OnTextChanged="tbFront_TextChanged" AutoPostBack="true">天</asp:TextBox><br />
3. 文字显示颜色:
<asp:TextBox ID="tbTextColor" runat="server" Width="140px"　OnTextChanged="tbFront_TextChanged" AutoPostBack="true">#333333</asp:TextBox><br />
<br /> 
 
 
 <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label> 
</ContentTemplate>
</asp:UpdatePanel> 
</div>

 <asp:UpdateProgress ID="UpdateProgress1" runat="server">
 <ProgressTemplate>
 <div style="position:absolute; top:0px; right:0px; text-align:right; background: green; color:#fff; padding: 4px 10px;">生成中, 请稍候...</div>
 </ProgressTemplate>
</asp:UpdateProgress>

 <div class="thecenter"> 
	 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
    
<ul id="maintab" class="shadetabs">
<li class="nav_p1"><a href="#p1" title="最窄图片">最窄图片</a></li>
<li class="nav_p2"><a href="#p2" title="窄列图片">窄列图片</a></li>
<li class="nav_p3"><a href="#p3" title="中等图片">中等图片</a></li>
<li class="nav_p4"><a href="#p4" title="偏宽图片">偏宽图片</a></li>
<li class="nav_p5"><a href="#p5" title="最宽图片">最宽图片</a></li>
</ul>
<br />
<div id="p1">

<fieldset title="最窄图片">
<legend><strong>最窄图片</strong></legend>

	    <ul>
			<li>
                <asp:Image ID="imgWed1" runat="server" AlternateText="Img 1" ImageUrl="~/CountingDown/CountBase/customize/type1/1.jpg"   />
				<br /> 选择该背景: <asp:RadioButton ID="rbWed1" runat="server" GroupName="Wedding" AutoPostBack="true" Checked="true"  OnCheckedChanged="rbs_CheckedChanged" /> <a href="#hereitis" title="选择好图片后回到页顶">回到页顶</a>
			</li>
			<li>
                <asp:Image ID="imgWed2" runat="server" AlternateText="Img 2" ImageUrl="~/CountingDown/CountBase/customize/type1/2.jpg"  />
				<br /> 选择该背景: <asp:RadioButton ID="rbWed2" runat="server" GroupName="Wedding" AutoPostBack="true" OnCheckedChanged="rbs_CheckedChanged" /> <a href="#hereitis" title="选择好图片后回到页顶">回到页顶</a>
			</li>
			<li>
                <asp:Image ID="imgWed3" runat="server" AlternateText="Img 3" ImageUrl="~/CountingDown/CountBase/customize/type1/3.jpg"  />
				<br /> 选择该背景: <asp:RadioButton ID="rbWed3" runat="server" GroupName="Wedding" AutoPostBack="true" OnCheckedChanged="rbs_CheckedChanged"/> <a href="#hereitis" title="选择好图片后回到页顶">回到页顶</a>
			</li>
				         <li>
                <asp:Image ID="imgWed4" runat="server" AlternateText="Img 4" ImageUrl="~/CountingDown/CountBase/customize/type1/4.jpg"  />
				<br /> 选择该背景: <asp:RadioButton ID="rbWed4" runat="server" GroupName="Wedding" AutoPostBack="true" OnCheckedChanged="rbs_CheckedChanged"/> <a href="#hereitis" title="选择好图片后回到页顶">回到页顶</a>
			</li>
				         <li>
                <asp:Image ID="imgWed5" runat="server" AlternateText="Img 5" ImageUrl="~/CountingDown/CountBase/customize/type1/5.jpg"  />
				<br /> 选择该背景: <asp:RadioButton ID="rbWed5" runat="server" GroupName="Wedding" AutoPostBack="true" OnCheckedChanged="rbs_CheckedChanged"/> <a href="#hereitis" title="选择好图片后回到页顶">回到页顶</a>
			</li>
				         <li>
                <asp:Image ID="imgWed6" runat="server" AlternateText="Img 6" ImageUrl="~/CountingDown/CountBase/customize/type1/6.jpg"  />
				<br /> 选择该背景: <asp:RadioButton ID="rbWed6" runat="server" GroupName="Wedding" AutoPostBack="true" OnCheckedChanged="rbs_CheckedChanged"/> <a href="#hereitis" title="选择好图片后回到页顶">回到页顶</a>
			</li>
        </ul>
 </fieldset>       
</div>   
<br />
<div id="p3">
<fieldset title="中等图片">
<legend><strong>中等图片</strong></legend>
	    <ul>
			<li>
                <asp:Image ID="Image2" runat="server" AlternateText="Img 1" ImageUrl="~/CountingDown/CountBase/customize/type1/1.jpg"   />
				<br /> 选择该背景: <asp:RadioButton ID="RadioButton1" runat="server" GroupName="Wedding" AutoPostBack="true" Checked="true"  OnCheckedChanged="rbs_CheckedChanged" /> <a href="#hereitis" title="选择好图片后回到页顶">回到页顶</a>
			</li>
			<li>
                <asp:Image ID="Image3" runat="server" AlternateText="Img 2" ImageUrl="~/CountingDown/CountBase/customize/type1/2.jpg"  />
				<br /> 选择该背景: <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Wedding" AutoPostBack="true" OnCheckedChanged="rbs_CheckedChanged" /> <a href="#hereitis" title="选择好图片后回到页顶">回到页顶</a>
			</li>
			<li>
                <asp:Image ID="Image4" runat="server" AlternateText="Img 3" ImageUrl="~/CountingDown/CountBase/customize/type1/3.jpg"  />
				<br /> 选择该背景: <asp:RadioButton ID="RadioButton3" runat="server" GroupName="Wedding" AutoPostBack="true" OnCheckedChanged="rbs_CheckedChanged"/> <a href="#hereitis" title="选择好图片后回到页顶">回到页顶</a>
			</li>
				         <li>
                <asp:Image ID="Image5" runat="server" AlternateText="Img 4" ImageUrl="~/CountingDown/CountBase/customize/type1/4.jpg"  />
				<br /> 选择该背景: <asp:RadioButton ID="RadioButton4" runat="server" GroupName="Wedding" AutoPostBack="true" OnCheckedChanged="rbs_CheckedChanged"/> <a href="#hereitis" title="选择好图片后回到页顶">回到页顶</a>
			</li>
				         <li>
                <asp:Image ID="Image6" runat="server" AlternateText="Img 5" ImageUrl="~/CountingDown/CountBase/customize/type1/5.jpg"  />
				<br /> 选择该背景: <asp:RadioButton ID="RadioButton5" runat="server" GroupName="Wedding" AutoPostBack="true" OnCheckedChanged="rbs_CheckedChanged"/> <a href="#hereitis" title="选择好图片后回到页顶">回到页顶</a>
			</li>
				         <li>
                <asp:Image ID="Image7" runat="server" AlternateText="Img 6" ImageUrl="~/CountingDown/CountBase/customize/type1/6.jpg"  />
				<br /> 选择该背景: <asp:RadioButton ID="RadioButton6" runat="server" GroupName="Wedding" AutoPostBack="true" OnCheckedChanged="rbs_CheckedChanged"/> <a href="#hereitis" title="选择好图片后回到页顶">回到页顶</a>
			</li>
        </ul>
        </fieldset>
</div>      
        
        
		  </ContentTemplate>
    </asp:UpdatePanel>
    
    
        <p /> &nbsp;<p /> &nbsp;<p /> &nbsp;<p /> &nbsp;<p /> &nbsp;<p /> &nbsp;<p /> &nbsp; 
     
    </div>

 

 

 </div>
</div>

</div>
</div>



<div id="sidebar">

<div id="belem_3c">
<div id="belem_3c_l2">


<p>联络BELEM:<br />
<a href="mailto:hi@live.com">hi@live.com</a></p>

<asp:UpdatePanel ID="UpdatePanel4" runat="server">
<ContentTemplate>
<asp:ImageButton ID="imgCreateButton" runat="server"  ImageUrl="~/CountingDown/CountBase/createButton.gif" /><p /><br />   
<%--<asp:ImageButton ID="imgCreateButton" runat="server"  ImageUrl="~/CountingDown/CountBase/createButton.gif" OnClick="imgCreateButton_Click"/><p /><br />--%>
    <asp:Image ID="Image1" runat="server"  />
    <asp:Label ID="lbstandard" runat="server" Text="Label"></asp:Label>
     <asp:Label ID="lbcenter" runat="server" Text="Label"></asp:Label>
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="imgCreateButton" EventName="Click" />
</Triggers>
</asp:UpdatePanel>
</div>

<div id="belem_3c_l3">
 
<div id="linkliste">
<ul>
<li><a href="http://belemview.com/" title="belem view">belem view</a></li>
<li><a href="http://zhangmin.name/" title="zhang min">zhang min</a></li>
<li><a href="http://gb2312.spaces.live.com/" title="Easy Start To The Day">belem space</a></li>
<li><a href="http://lieb.cn/" title="Lieb">lieb.cn</a></li>
<li><a href="http://www.codedefect.com/" title="code defect">code defect</a></li>
</ul>

</div>

</div>
</div>
 
</div>
</div>
