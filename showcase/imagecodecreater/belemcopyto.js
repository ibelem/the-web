function copy2Clipboard() {
		document.getElementById("taCode").innerText = document.getElementById("CreatedPreview").innerText;
		var taCode = document.getElementById("taCode").innerText;
		textRange = taCode.createTextRange();
		textRange.execCommand("RemoveFormat");
		textRange.execCommand("Copy");
}

