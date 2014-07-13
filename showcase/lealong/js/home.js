/**
 * 本代码用于凌龙涂料的产品页功能设置
 * 由Belem编辑 2006.01 BelemCheung@hotmail.com
 * 主要功能:
 * 图像轮番显示效果
 * 以及菜单效果
 */

function scbg(objRef, state) {
	objRef.style.backgroundColor = (1 == state) ? '#efefef' : '#FFFFFF';
	return;
}

var slideShowSpeed = 5000;
var crossFadeDuration = 16;
var Pic = new Array();

Pic[0] = 'img/loop/1.jpg'
Pic[1] = 'img/loop/2.jpg'
Pic[2] = 'img/loop/3.jpg'
Pic[3] = 'img/loop/4.jpg'
Pic[4] = 'img/loop/5.jpg'
Pic[5] = 'img/loop/6.jpg'

var t;
var j = 0;
var p = Pic.length;
var preLoad = new Array();
for (i = 0; i < p; i++) {
preLoad[i] = new Image();
preLoad[i].src = Pic[i];
}
function runSlideShow() {
if (document.all) {
document.images.SlideShow.style.filter="blendTrans(duration=2)";
document.images.SlideShow.style.filter="blendTrans(duration=crossFadeDuration)";
document.images.SlideShow.filters.blendTrans.Apply();
}
document.images.SlideShow.src = preLoad[j].src;
if (document.all) {
document.images.SlideShow.filters.blendTrans.Play();
}
j = j + 1;
if (j > (p - 1)) j = 0;
t = setTimeout('runSlideShow()', slideShowSpeed);
}


function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}

function MM_jumpMenu(targ,selObj,restore){ //v3.0
  eval(targ+".location='"+selObj.options[selObj.selectedIndex].value+"'");
  if (restore) selObj.selectedIndex=0;
}


function together() 
{ 
	runSlideShow();
	MM_preloadImages('img/framework/showall/showall_hover1.gif','img/framework/showall/showall_hover2.gif','img/framework/showall/showall_hover3.gif','img/framework/showall/showall_hover4.gif','img/framework/showall/showall_hover5.gif');
}

ypSlideOutMenu.Registry = []
ypSlideOutMenu.aniLen = 700
ypSlideOutMenu.hideDelay = 200
ypSlideOutMenu.minCPUResolution = 10
// constructor
function ypSlideOutMenu(id, dir, left, top, width, height)
{
this.ie = document.all ? 1 : 0
this.ns4 = document.layers ? 1 : 0
this.dom = document.getElementById ? 1 : 0
if (this.ie || this.ns4 || this.dom) {
this.id = id
this.dir = dir
this.orientation = dir == "left" || dir == "right" ? "h" : "v"
this.dirType = dir == "right" || dir == "down" ? "-" : "+"
this.dim = this.orientation == "h" ? width : height
this.hideTimer = false
this.aniTimer = false
this.open = false
this.over = false
this.startTime = 0
this.gRef = "ypSlideOutMenu_"+id
eval(this.gRef+"=this")
ypSlideOutMenu.Registry[id] = this
var d = document
var strCSS = "";
strCSS += '#' + this.id + 'Container { visibility:hidden; '
strCSS += 'left:' + left + 'px; '
strCSS += 'top:' + top + 'px; '
strCSS += 'overflow:hidden; z-index:10000; }'
strCSS += '#' + this.id + 'Container, #' + this.id + 'Content { position:absolute; '
strCSS += 'width:' + width + 'px; '
strCSS += 'height:' + height + 'px; '
strCSS += 'clip:rect(0 ' + width + ' ' + height + ' 0); '
strCSS += '}'
this.css = strCSS;
this.load()
}
}
ypSlideOutMenu.writeCSS = function() {
document.writeln('<style type="text/css">');
for (var id in ypSlideOutMenu.Registry) {
document.writeln(ypSlideOutMenu.Registry[id].css);
}
document.writeln('</style>');
}
ypSlideOutMenu.prototype.load = function() {
var d = document
var lyrId1 = this.id + "Container"
var lyrId2 = this.id + "Content"
var obj1 = this.dom ? d.getElementById(lyrId1) : this.ie ? d.all[lyrId1] : d.layers[lyrId1]
if (obj1) var obj2 = this.ns4 ? obj1.layers[lyrId2] : this.ie ? d.all[lyrId2] : d.getElementById(lyrId2)
var temp
if (!obj1 || !obj2) window.setTimeout(this.gRef + ".load()", 100)
else {
this.container = obj1
this.menu = obj2
this.style = this.ns4 ? this.menu : this.menu.style
this.homePos = eval("0" + this.dirType + this.dim)
this.outPos = 0
this.accelConst = (this.outPos - this.homePos) / ypSlideOutMenu.aniLen / ypSlideOutMenu.aniLen 
// set event handlers.
if (this.ns4) this.menu.captureEvents(Event.MOUSEOVER | Event.MOUSEOUT);
this.menu.onmouseover = new Function("ypSlideOutMenu.showMenu('" + this.id + "')")
this.menu.onmouseout = new Function("ypSlideOutMenu.hideMenu('" + this.id + "')")
//set initial state
this.endSlide()
}
}
ypSlideOutMenu.showMenu = function(id)
{
var reg = ypSlideOutMenu.Registry
var obj = ypSlideOutMenu.Registry[id]
if (obj.container) {
obj.over = true
for (menu in reg) if (id != menu) ypSlideOutMenu.hide(menu)
if (obj.hideTimer) { reg[id].hideTimer = window.clearTimeout(reg[id].hideTimer) }
if (!obj.open && !obj.aniTimer) reg[id].startSlide(true)
}
}
ypSlideOutMenu.hideMenu = function(id)
{
var obj = ypSlideOutMenu.Registry[id]
if (obj.container) {
if (obj.hideTimer) window.clearTimeout(obj.hideTimer)
obj.hideTimer = window.setTimeout("ypSlideOutMenu.hide('" + id + "')", ypSlideOutMenu.hideDelay);
}
}
ypSlideOutMenu.hideAll = function()
{
var reg = ypSlideOutMenu.Registry
for (menu in reg) {
ypSlideOutMenu.hide(menu);
if (menu.hideTimer) window.clearTimeout(menu.hideTimer);
}
}
ypSlideOutMenu.hide = function(id)
{
var obj = ypSlideOutMenu.Registry[id]
obj.over = false
if (obj.hideTimer) window.clearTimeout(obj.hideTimer)
obj.hideTimer = 0
if (obj.open && !obj.aniTimer) obj.startSlide(false)
}
ypSlideOutMenu.prototype.startSlide = function(open) {
this[open ? "onactivate" : "ondeactivate"]()
this.open = open
if (open) this.setVisibility(true)
this.startTime = (new Date()).getTime() 
this.aniTimer = window.setInterval(this.gRef + ".slide()", ypSlideOutMenu.minCPUResolution)
}
ypSlideOutMenu.prototype.slide = function() {
var elapsed = (new Date()).getTime() - this.startTime
if (elapsed > ypSlideOutMenu.aniLen) this.endSlide()
else {
var d = Math.round(Math.pow(ypSlideOutMenu.aniLen-elapsed, 2) * this.accelConst)
if (this.open && this.dirType == "-") d = -d
else if (this.open && this.dirType == "+") d = -d
else if (!this.open && this.dirType == "-") d = -this.dim + d
else d = this.dim + d
this.moveTo(d)
}
}
ypSlideOutMenu.prototype.endSlide = function() {
this.aniTimer = window.clearTimeout(this.aniTimer)
this.moveTo(this.open ? this.outPos : this.homePos)
if (!this.open) this.setVisibility(false)
if ((this.open && !this.over) || (!this.open && this.over)) {
this.startSlide(this.over)
}
}
ypSlideOutMenu.prototype.setVisibility = function(bShow) { 
var s = this.ns4 ? this.container : this.container.style
s.visibility = bShow ? "visible" : "hidden"
}
ypSlideOutMenu.prototype.moveTo = function(p) { 
this.style[this.orientation == "h" ? "left" : "top"] = this.ns4 ? p : p + "px"
}
ypSlideOutMenu.prototype.getPos = function(c) {
return parseInt(this.style[c])
}
ypSlideOutMenu.prototype.onactivate = function() { }
ypSlideOutMenu.prototype.ondeactivate = function() { }

if(navigator.userAgent.indexOf('MSIE')!=-1){ 
new ypSlideOutMenu("menu1", "left", 259, 300, 500, 20)
new ypSlideOutMenu("menu2", "left", 259, 300, 500, 20)
new ypSlideOutMenu("menu3", "left", 259, 300, 500, 20)
new ypSlideOutMenu("menu4", "left", 259, 300, 500, 20)
new ypSlideOutMenu("menu5", "left", 259, 300, 500, 20)
}
else {

new ypSlideOutMenu("menu1", "left", 266, 316, 500, 20)
new ypSlideOutMenu("menu2", "left", 266, 316, 500, 20)
new ypSlideOutMenu("menu3", "left", 266, 316, 500, 20)
new ypSlideOutMenu("menu4", "left", 266, 316, 500, 20)
new ypSlideOutMenu("menu5", "left", 266, 316, 500, 20)


}

    ypSlideOutMenu.writeCSS();