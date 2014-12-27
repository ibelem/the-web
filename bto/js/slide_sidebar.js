 			var ts = new Array();
            var ct = 0;

            ts[0] = "Quit. Don't quit.";
            ts[1] = "Noodles. Don't noodles.";
            ts[2] = "You are too concerned with what was and what will be.";
            ts[3] = "There's a saying.";
            ts[4] = "Yesterday is history,";
            ts[5] = "Tomorrow is a mystery,";
            ts[6] = "But today is a gift.";
  			                               
            function display_next_testimonial() {
                if (ct + 1 >= ts.length) {
	                    ct = 0;
	                } else {
	                    ct++;
	                }
	                
                window.setTimeout("document.getElementById('headerquote').innerHTML = ts[ct];", 300);            
                }
            
            
            setInterval('display_next_testimonial();', 4000);
            
 			display_next_testimonial();
