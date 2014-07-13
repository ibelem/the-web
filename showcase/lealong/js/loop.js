/**
 * 本代码用于凌龙涂料的产品页功能设置
 * 由Belem编辑 2006.01
 * 主要功能:
 * 图像轮番显示效果
 */

var slideShowSpeed = 5000;
var crossFadeDuration = 16;
var Pic = new Array();

Pic[0] = 'img/loop/1.gif'
Pic[1] = 'img/loop/2.gif'
Pic[2] = 'img/loop/3.gif'
Pic[3] = 'img/loop/4.gif'
Pic[4] = 'img/loop/5.gif'

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

window.onload = function()
{ 
	runSlideShow();
}

