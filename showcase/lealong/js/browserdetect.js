var n = (document.layers) ? 1:0; 
var ie = (document.all) ? 1:0;
var safari = (navigator.userAgent.indexOf("Safari") > -1) ? 1:0;
var mac = (navigator.userAgent.indexOf('Mac')>-1) ? 1:0;
function openWin( html, name, wval, hval ) {
	// set general size vars
	var w_val = wval;
	var h_val = hval;


	// if browser is ie mac
	if (ie && mac) {
		w_val -= 16;
		h_val -= 16;
	}
	
	// if browser is safari mac
	if (safari && mac) {
		w_val -= 2;
		h_val += 15;
	}
	
	// open the browser
	var nw=window.open( html, name, 'width='+w_val+',height='+h_val+',status,scrollbars,resizable');
	nw.focus();
		
}
