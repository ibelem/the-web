<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DateSelect.ascx.cs" Inherits="ASCX_DateSelect" %>

<div id="main_inner" class="fixed">
<div id="main_belem_3c">
<div id="belem_3c_l1">    
 
    <div class="post">
	
<div class="entry">
<div>    
<asp:UpdatePanel ID="ux" runat ="server">
<ContentTemplate>
1. 您的纪念类型:
<asp:RadioButton ID="rbCount" runat="server" GroupName="TheType" AutoPostBack="true" OnCheckedChanged="rbType_CheckedChanged"  Checked="true" Text="倒计时" />
<asp:RadioButton ID="rbMemory" runat="server" GroupName="TheType" AutoPostBack="true" OnCheckedChanged="rbType_CheckedChanged" Text="纪念日" />
</ContentTemplate>
 </asp:UpdatePanel>
</div>
    
<div>    
<asp:UpdatePanel ID="UpdatePanel7" runat="server">
<ContentTemplate>
2. 您的纪念日期 
<asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True" >
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True">
        </asp:DropDownList> 
 <asp:Label ID="Label1" runat="server"></asp:Label>  <br /> <br />  
 
 <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label> 
 
<%-- <a href="#featuredbanners" title="更多样式">更多</a>--%>
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
	    <ul>
	         <li>
                <asp:Image ID="imgWed4" runat="server" AlternateText="Img 4" ImageUrl="~/CountingDown/CountBase/Wedding/Count/4.gif"  />
				<br /> 选择该背景: <asp:RadioButton ID="rbWed4" runat="server" GroupName="Wedding" AutoPostBack="true" OnCheckedChanged="rbs_CheckedChanged"/>
			</li>
			<li>
                <asp:Image ID="imgWed1" runat="server" AlternateText="Img 1" ImageUrl="~/CountingDown/CountBase/Wedding/Count/1.gif"   />
				<br /> 选择该背景: <asp:RadioButton ID="rbWed1" runat="server" GroupName="Wedding" AutoPostBack="true" Checked="true"  OnCheckedChanged="rbs_CheckedChanged" />
			</li>
			<li>
                <asp:Image ID="imgWed2" runat="server" AlternateText="Img 2" ImageUrl="~/CountingDown/CountBase/Wedding/Count/2.gif"  />
				<br /> 选择该背景: <asp:RadioButton ID="rbWed2" runat="server" GroupName="Wedding" AutoPostBack="true" OnCheckedChanged="rbs_CheckedChanged" />
			</li>
			<li>
                <asp:Image ID="imgWed3" runat="server" AlternateText="Img 3" ImageUrl="~/CountingDown/CountBase/Wedding/Count/3.gif"  />
				<br /> 选择该背景: <asp:RadioButton ID="rbWed3" runat="server" GroupName="Wedding" AutoPostBack="true" OnCheckedChanged="rbs_CheckedChanged"/>
			</li>
        </ul>
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
<a href="mailto:zhangmin@live.com">zhangmin@live.com</a></p>

<asp:UpdatePanel ID="UpdatePanel4" runat="server">
<ContentTemplate>
    
<asp:ImageButton ID="imgCreateButton" runat="server"  ImageUrl="~/CountingDown/CountBase/createButton.gif" OnClick="imgCreateButton_Click"/><p /><br />
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
