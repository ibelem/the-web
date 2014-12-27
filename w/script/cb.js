	function addEventHandler(oNode, sEvt, sFunc, bCaptures) {
			oNode.addEventListener(sEvt, sFunc, bCaptures);			
	}
	
	var iCK = document.getElementById("cbIsMin");
	
	function cKChecked() {
		if(iCK.checked){
		  	document.getElementById("iusr").value="";
		 }
		else{
		  	document.getElementById("iusr").value="minz";
		 }
	}
	addEventHandler(iCK, "click", cKChecked, false);

