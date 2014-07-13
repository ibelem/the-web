//Belem 实现图片生成代码

function belem_ImageCodes(e)
{
	var oCreatedCode = document.getElementById("CreatedCode");
	var oDiv=  document.getElementById("idDiv");
	var CreatedPreview = document.getElementById("CreatedPreview");
	
	var oBImage = document.getElementById("idBImg").value;
	var oFImage = document.getElementById("idFImg").value;
	var oFontColor = document.getElementById("idFontColor").value;
	var oBGColor = document.getElementById("idBgColor").value;
	var oBorderColor = document.getElementById("idBorderColor").value;
	var oDIVHeight = document.getElementById("idDIVHeight").value;
	var oSBBaseColor = document.getElementById("idSBBaseColor").value;
	var oSBFaceColor = document.getElementById("idSBFaceColor").value;
	var oSBTrackColor = document.getElementById("idSBTrackColor").value;
	var oSBArrowColor = document.getElementById("idSBArrowColor").value;
	var oSB3dlightColor = document.getElementById("idSB3dlightColor").value;
	var oSBDarkshadowColor = document.getElementById("idSBDarkshadowColor").value;
	var oSBHighlightColor = document.getElementById("idSBHighlightColor").value;
	var oSBShadowColor = document.getElementById("idSBShadowColor").value;
	
//	var oMyText = document.getElementById("TAMyText").value;
//	var oMyTextEncode = document.getElementById("TAMyText").value;
	
//	oMyText = oMyText.replace("\n","<br/>"); 
//	oMyText = oMyText.replace("\n\r","<br/>"); 
//	oMyTextEncode = oMyTextEncode.replace("\n","&lt;br/&gt;"); 
//	oMyTextEncode = oMyTextEncode.replace("\n\r","&lt;br/&gt;"); 
	var oMyText = " 当春天来了 冬天睡着了<br /><br />你 这里文字多是为了检测行高效果 检测图片和文字间距效果 还有什么效果呢  你说阿 你不说我怎么知道呢...<br /><br />还在戴着温暖的手套么<br /><br />阿<br /><br />春天 多么美好的春天啊 阿 还有那美好的夏天 美好的秋天 恩 冬天也是很美的 你 这里文字多是为了检测行高效果 检测图片和文字间距效果 还有什么效果呢  你说阿 你不说我怎么知道呢...在哪里啊 故乡的冬天!<br /><br />-- Belem 的散文诗 <br/>吐阿吐阿 吐干净了就没关系了 When hristmas Comes To Town, Happy Spring Festival!";
	var oMyTextEncode = "<br />当春天来了 冬天睡着了&lt;br /&gt;&lt;br /&gt;你 这里文字多是为了检测行高效果 检测图片和文字间距效果还有什么效果呢  你说阿 你不说我怎么知道呢...&lt;br /&gt;&lt;br /&gt;还在戴着温暖的手套么&lt;br /&gt;&lt;br /&gt;阿&lt;br /&gt;&lt;br/&gt;春天 多么美好的春天啊 阿 还有那美好的夏天 美好的秋天 恩 冬天也是很美的 你 这里文字多是为了检测行高效果 检测图片和文字间距效果 还有什么效果呢  你说阿 你不说我怎么知道呢...在哪里啊 故乡的冬天!&lt;br /&gt;&lt;br /&gt;-- Belem 的散文诗 <br/> 吐阿吐阿 吐干净了就没关系了 When hristmas Comes To Town, Happy Spring Festival!";
	
	with (document.getElementById("idBImgRepeatStyle")) var s_BImgRepeatStyle = options[selectedIndex].value;
	with (document.getElementById("idBImgPositionStyle")) var s_BImgPositionStyle = options[selectedIndex].value;
	with (document.getElementById("idFImgPositionStyle")) var s_FImgPositionStyle = options[selectedIndex].value;
	with (document.getElementById("idFontSize")) var s_FontSize = options[selectedIndex].value;
	with (document.getElementById("idFontAlign")) var s_FontAlign = options[selectedIndex].value;
	with (document.getElementById("idBorderStyle")) var s_BorderStyle = options[selectedIndex].value;
	with (document.getElementById("idBorderWidth")) var s_BorderWidth = options[selectedIndex].value;
	with (document.getElementById("FImgFontDis")) var s_FImgFontDis = options[selectedIndex].value;
	with (document.getElementById("idFontStyle")) var s_FontStyle = options[selectedIndex].value;
	with (document.getElementById("idFontFlow")) var s_FontFlow = options[selectedIndex].value;
	with (document.getElementById("idFontWeight")) var s_FontWeight = options[selectedIndex].value;
	with (document.getElementById("idFontLineHeight")) var s_FontLineHeight = options[selectedIndex].value;

	var sBImgRepeatStyle = s_BImgRepeatStyle;
	var sBImgPositionStyle = s_BImgPositionStyle;
	var sFImgPositionStyle = s_FImgPositionStyle;
	var sBorderStyle = s_BorderStyle;
	var sBorderWidth = s_BorderWidth;	
	var FImgFontDis = s_FImgFontDis;
	
	if(oBImage != "" && oBImage != null)
	{
		var sBImage = " style=\"height:100%; width:100%; background-position: "+ sBImgPositionStyle +"; background-repeat:" + sBImgRepeatStyle + ";\" background=\""+ oBImage +"\""  ;
		var sBImage_C = "<span style=\"color:orange; \">"+ sBImage +"</span>"; 
	}
	else
	{
		var sBImage = "";
		var sBImage_C = "";
	}

	var FImgFontDisFinal = "border:" + FImgFontDis + " " +oBGColor +" solid;";
	var FImgFontDisFinal_C = "<span style=\"color:limeGreen; \">"+ FImgFontDisFinal +"</span>"; 

	if(document.getElementById("CBAllowFImg").checked==true)
	{
		if(document.getElementById("CBAllowFImgBorder").checked==true)
		{
			var sFImage = "<div style=\"float:"+ sFImgPositionStyle +"; " +FImgFontDisFinal+ "\"><div style=\"border:1px #eeeeee solid;\"><div style=\"border:4px #ffffff solid;\"><img src=\"" + oFImage + "\" alt=\"\" /></div></div></div>";
			var sFImage_C = "<span style=\"color:green; \">&lt;div style=&quot;float:" + sFImgPositionStyle + "; border:1px #eeeeee solid;&quot;&gt;&lt;div style=&quot;"+FImgFontDisFinal_C+"&quot;&gt;&lt;div style=&quot;border:4px #ffffff solid;&quot;&gt;&lt;img src=&quot;" + oFImage + "&quot; alt=&quot;&quot; /&gt;&lt;/div&gt;&lt;/div&gt;&lt;/div&gt;</span>"; 
		}
		else
		{
			var sFImage = "<div style=\"float:"+ sFImgPositionStyle +";" +FImgFontDisFinal+ "\"><img src=\"" + oFImage + "\" alt=\"\" /></div>";
			var sFImage_C = "<span style=\"color:green; \">&lt;div style=&quot;float:" + sFImgPositionStyle + "; "+FImgFontDisFinal_C+"&quot;&gt;&lt;img src=&quot;" + oFImage + "&quot; alt=&quot;&quot; /&gt;&lt;/div&gt;</span>"; 
		}
	}
	else
	{
		var sFImage = "";
		var sFImage_C = "";
	}
	
	var sFontAlign = "text-align:" + s_FontAlign + ";";
	var sFontAlign_C =  "<span style=\"color:pink; \">" + sFontAlign + "</span>"; 
	
	var sFontStyle = "font-family:"+ s_FontStyle +";"; 
	var sFontStyle_C = "<span style=\"color:pink; \">" + sFontStyle + "</span>"; 
	
	var sFontSize = "font-size:" + s_FontSize + ";";
	var sFontSize_C = "<span style=\"color:pink; \">" + sFontSize + "</span>"; 
	
	var sFontColor = "color:" + oFontColor + ";";
	var sFontColor_C = "<span style=\"color:pink; \">" + sFontColor + "</span>"; 
	
	var sFontFlow = "layout-flow: "+ s_FontFlow + ";";
	var sFontFlow_C = "<span style=\"color:pink; \">" + sFontFlow + "</span>"; 
	
	var sBGColor = "background-color:" + oBGColor + ";";
	var sBGColor_C = "<span style=\"color:blue; \">" + sBGColor + "</span>"; 
	
	var FontLineHeight = "line-height:" + s_FontLineHeight +";";
	var FontLineHeight_C = "<span style=\"color:pink; \">" + FontLineHeight + "</span>"; 
	
	var FontWeight = s_FontWeight;
	
	if(FontWeight == "italic")
	{
		FontWeight = "font-style:italic;" ;
		var FontWeight_C = "<span style=\"color:pink; \">" + FontWeight + "</span>"; 
	}
	else
	{
		FontWeight = "font-weight:" +FontWeight+";" ;
		var FontWeight_C = "<span style=\"color:pink; \">" + FontWeight + "</span>";
	}
	
	if(document.getElementById("CBAllowBorder").checked==true)
	{
		var sBorder = "border: " + oBorderColor +" "+ sBorderWidth +" " + sBorderStyle+"; ";
		var sBorder_C = "<span style=\"color:brown; \">"+ sBorder +"</span> ";
	}
	else
	{
		var sBorder = "border: #a5cf3d 0px solid;";
		var sBorder_C = "<span style=\"color:brown; \">border: #a5cf3d 0px solid;</span>";
	}
	
	if(document.getElementById("CBDisableHor").checked == true )
	{
		var DisableHor = "overflow-x:hidden;";
	}
	else
	{
		var DisableHor = "";
	}
	
	if(document.getElementById("CBDisableV").checked == true )
	{
		var DisableV = "overflow-y:hidden;";
	}
	else
	{
		var DisableV = "";
	}
	
	var scrollstylefinall = "scrollbar-base-color:"+oSBBaseColor+";"
	+ "scrollbar-face-color:" + oSBFaceColor + "; scrollbar-track-color:" +oSBTrackColor+"; scrollbar-arrow-color:"+oSBArrowColor+"; scrollbar-3dlight-color: "+oSB3dlightColor+"; scrollbar-darkshadow-color: "+oSBDarkshadowColor+"; scrollbar-highlight-color:"+oSBHighlightColor+"; scrollbar-shadow-color:"+oSBShadowColor+";" ;
	
	if(document.getElementById("CBAllowHeight").checked == false )
	{
		var scrolls = "overflow:auto"; 
		var scrolls_C = "<span style=\"color:yellowgreen; \">"+ scrolls +"</span> ";
	}
	else 
	{
		var scrolls = "overflow:scroll; height:" + oDIVHeight + ";" + DisableHor  + DisableV + scrollstylefinall;
		var scrolls_C = "<span style=\"color:yellowgreen; \">"+ scrolls +"</span> ";
	}
	
	if(document.getElementById("CBAllowBImg").checked==true)
	{
		CreatedPreview.innerHTML =  
		" <div style=\""+sBorder+sBGColor+scrolls+"\">"
		+" <table" + sBImage + " >"
		+"<tr style=\"height:8px\"><td></td><td></td><td></td></tr>"
		+" <tr>"
		+" <td style=\"width:8px\"></td>"
		+" <td>"
		+" <div style=\""+sFontStyle +sFontSize + sFontColor+ sFontAlign + sFontFlow+ FontWeight+ FontLineHeight+" overflow:auto;\">"
		+ sFImage
		+ oMyText
		+"</div>"
		+"</td>"
		+"<td style=\"width:8px\"></td>"
		+"</tr>"
		+"<tr style=\"height:8px\"><td></td><td></td><td></td></tr>"
		+"</table>"
		+"</div> ";

		oCreatedCode.innerHTML =  
		" <br />&lt;div style=\""+sBorder_C+sBGColor_C+scrolls_C+"\"&gt; <br/>"
		+" &lt;table" + sBImage_C + " &gt;<br/>"
		+"&lt;tr style=\"height:8px\"&gt;&lt;td&gt;&lt;/td&gt;&lt;td&gt;&lt;/td&gt;&lt;td&gt;&lt;/td&gt;&lt;/tr&gt;<br/>"
		+" &lt;tr&gt;<br/>"
		+" &lt;td style=\"width:8px\"&gt;&lt;/td&gt;<br/>"
		+" &lt;td&gt;<br/>"
		+" &lt;div style=\""+ sFontStyle_C +sFontSize_C+ sFontColor_C+ sFontAlign_C +sFontFlow_C + FontWeight_C+ FontLineHeight_C+"overflow:auto;\"&gt;<br/>"
		+ sFImage_C
		+ oMyTextEncode
		+"&lt;/div&gt;<br/>"
		+"&lt;/td&gt;<br/>"
		+"&lt;td style=\"width:8px\"&gt;&lt;/td&gt;<br/>"
		+"&lt;/tr&gt;<br/>"
		+"&lt;tr style=\"height:8px\"&gt;&lt;td&gt;&lt;/td&gt;&lt;td&gt;&lt;/td&gt;&lt;td&gt;&lt;/td&gt;&lt;/tr&gt;<br/>"
		+"&lt;/table&gt;<br/>"
		+"&lt;/div&gt; <br/><br />";
	}
	else
		{
		CreatedPreview.innerHTML =  
		" <div style=\""+sBorder+sBGColor+scrolls+"\">"
		+"<div style=\"border: "+oBGColor+" 8px solid; \">"
		+" <div style=\""+sFontStyle+sFontSize + sFontColor+ sFontAlign + sFontFlow+FontWeight+FontLineHeight+ " overflow:auto;\">"
		+ sFImage
		+ oMyText
		+"</div>"
		+"</div>"
		+"</div>";

		oCreatedCode.innerHTML =  
		"<br /> &lt;div style=\""+sBorder_C+sBGColor_C+scrolls_C+"\"&gt; <br/>"
		+"&lt;div style=\"<span style=\"color:blue;\">border: "+oBGColor+" 8px solid;</span> \"&gt;<br/>"
		+"&lt;div style=\""+sFontStyle+sFontSize_C+ sFontColor_C+ sFontAlign_C + sFontFlow_C+ FontWeight_C+FontLineHeight_C+"overflow:auto;\"&gt;<br/>"
		+ sFImage_C
		+ oMyTextEncode
		+"&lt;/div&gt;<br/>"
		+"&lt;/div&gt; <br/>"
		+"&lt;/div&gt; <br/><br />" ;
	}

 
}
window.onload=belem_ImageCodes;