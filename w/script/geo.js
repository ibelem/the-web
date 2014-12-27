	function isNull(str) { 
		if (str == "") return true; 
		var regu = "^[ ]+$"; 
		var re = new RegExp(regu); 
		return re.test(str); 
	}
	function handle_geolocation_query()  
			{  
				var elat = document.getElementById("ilatitude");
				var elon = document.getElementById("ilongitude");

				if (navigator.geolocation) {  
					navigator.geolocation.getCurrentPosition(function(position) {  
							lat = position.coords.latitude;
							lon = position.coords.longitude;
							
							elat.setAttribute("value",lat);
							elon.setAttribute("value",lon);
						});
				}
				else {
						elat.setAttribute("value","39.9");
						elon.setAttribute("value","116.4");							
				}

			}
			
	document.addEventListener("DOMContentLoaded", handle_geolocation_query, false);	
