/**
 * 本代码用于凌龙涂料的产品页功能设置
 * 由Belem编辑 2006.01
 * 主要功能:
 * 1. 表格行的动态效果
 * 2. 页面按子项显示
 * 3. 页面滑过效果
 */

function fixLinks()
{
  if (!document.getElementsByTagName) return null;
  var server = document.location.hostname;
  var anchors = document.getElementsByTagName("a");
  for(var i=0; i < anchors.length; i++)
  {
    var a = anchors[i];
    var href = a.href;
    var id = a.id;
    var title = a.title;
    if (href.indexOf("#sidebartop") != -1) { // back to top
      a.className = "alt";
    } else if ((href.indexOf("#") != -1) && (href.indexOf("sidebartop") == -1)) { // jump ref
      var index = href.indexOf("#") + 1;
      href = "javascript:show('" + href.substring(index) + "');";
      a.setAttribute("href",href);
    }
  }
}

function hideDivs(exempt)
{
  if (!document.getElementsByTagName) return null;
  if (!exempt) exempt = "";
  var divs = document.getElementsByTagName("div");
  for(var i=0; i < divs.length; i++)
  {
    var div = divs[i];
    var id = div.id;
    if ((id != "header") && (id != "logo")&& (id != "nav_menu") 
		&& (id != "footer")&& (id != "main") && (id != "menuleft") 
		&& (id != "top") && (id != "sidebar") && (id != "sidebartop") 
		&& (id != "footer_links")  && (id != "copyright_lealong") && (id != "top2")
		
		&&(id != "p1_1") && (id != "p1_2")&& (id != "p1_3") 
		&&(id != "p1_4") && (id != "p1_5")&& (id != "p1_6") 
		&&(id != "p1_7") && (id != "p1_8")&& (id != "p1_9")
		&&(id != "p1_10") && (id != "p1_11")&& (id != "p1_12") 
		&&(id != "p1_13") && (id != "p1_14")

		&&(id != "p2_1") && (id != "p2_2")&& (id != "p2_3") 
		&&(id != "p2_4") && (id != "p2_5")&& (id != "p2_6") 
		&&(id != "p2_7") && (id != "p2_8")&& (id != "p2_9")
		&&(id != "p2_10") && (id != "p2_11")&& (id != "p2_12") 
		&&(id != "p2_13") && (id != "p2_14")&& (id != "p2_15")
		&&(id != "p2_16") && (id != "p2_17")

		&&(id != "p3_1") && (id != "p3_2")&& (id != "p3_3") 
		&&(id != "p3_4") && (id != "p3_5")&& (id != "p3_6") 
		&&(id != "p3_7") && (id != "p3_8")&& (id != "p3_9")
		&&(id != "p3_10") && (id != "p3_11")&& (id != "p3_12") 
		&&(id != "p3_13") 	&&(id != "p3_14") 

		&&(id != "p4_1") && (id != "p4_2")&& (id != "p4_3") 
		&&(id != "p4_4") && (id != "p4_5")&& (id != "p4_6") 
		&&(id != "p4_7") && (id != "p4_8")&& (id != "p4_9")
		&&(id != "p4_10") && (id != "p4_11")&& (id != "p4_12") 
		&&(id != "p4_13") && (id != "p4_14")&& (id != "p4_15")

		&&(id != "p5_1") && (id != "p5_2")&& (id != "p5_3") 
		&&(id != "p5_4") && (id != "p5_5")&& (id != "p5_6") 
		&&(id != "p5_7") && (id != "p5_8")&& (id != "p5_9")
		&&(id != "p5_10") && (id != "p5_11")&& (id != "p5_12") 
		&&(id != "p5_13") && (id != "p5_14") && (id != "p5_15")
		&& (id != "p5_16") && (id != "p5_17")

		&&(id != "p6_1") && (id != "p6_2")&& (id != "p6_3") 
		&&(id != "p6_4") && (id != "p6_5")&& (id != "p6_6") 
		&&(id != "p6_7") && (id != "p6_8")&& (id != "p6_9")
		&&(id != "p6_10") && (id != "p6_11")&& (id != "p6_12") 
		&&(id != "p6_13") && (id != "p6_14")&& (id != "p6_15") 
		&& (id != "p6_16")&& (id != "p6_17")


		&&(id != "p7_1") && (id != "p7_2")&& (id != "p7_3") 
		&&(id != "p7_4") && (id != "p7_5")&& (id != "p7_6") 
		&&(id != "p7_7") && (id != "p7_8")&& (id != "p7_9")
		&&(id != "p7_10") && (id != "p7_11")&& (id != "p7_12") 
		&&(id != "p7_13") && (id != "p7_14")&& (id != "p7_15")
		&&(id != "p7_16") && (id != "p7_17")

	&& (id != exempt))
    {
      div.className = "hidden";
    }
  }
}

function show(what)
{
  if (!document.getElementById) return null;
  showWhat = document.getElementById(what);
  showWhat.className = "";
  hideDivs(what);
}

function sendFocus(what)
{
  var obj = document.getElementById(what);
  obj.focus();
}

function tableruler()
{
	if (document.getElementById && document.createTextNode)
	{
		var tables=document.getElementsByTagName('table');
		for (var i=0;i<tables.length;i++)
		{
			if(tables[i].className=='ruler')
			{
				var trs=tables[i].getElementsByTagName('tr');
				for(var j=0;j<trs.length;j++)
				{
					if(trs[j].parentNode.nodeName=='TBODY')
					{
						trs[j].onmouseover=function(){this.className='ruled';return false}
						trs[j].onmouseout=function(){this.className='';return false}
					}
				}
			}
		}
	}
}


window.onload = function()
{ tableruler();
  fixLinks();
  hideDivs("p5");
  sendFocus("nav_p1");
}

function scbg(objRef, state) {
	objRef.style.backgroundColor = (1 == state) ? '#DBDEEA' : '#FFFFFF';
	return;
}