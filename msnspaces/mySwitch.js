function scbg(objRef, state) {
	objRef.style.backgroundColor = (1 == state) ? '#eefcff' : '#fff';
	return;
}
 
  			var testimonials = new Array();
            var current_testimonial = 0;
            
            testimonials[0] = "Good day you guys! <div class=\"quotedby\">&mdash; Happy Children's Day! &nbsp; &nbsp; &nbsp;</div>";
            testimonials[1] = "Good day you guys! <div class=\"quotedby\">&mdash; Happy Dragon Boat Festival!</div>";
            testimonials[2] = "Good day you guys! <div class=\"quotedby\">&mdash; Summer solstice on June 19th.";
            			                               
            function display_next_testimonial() {
                if (current_testimonial + 1 >= testimonials.length) {
                    current_testimonial = 0;
                } else {
                    current_testimonial++;
                }
                
                new Effect.Fade('headerquote', {duration:.3});
                
                window.setTimeout("$('headerquote').innerHTML = testimonials[current_testimonial];"+ " new Effect.Appear('headerquote', {duration:.3});",300);
            }
              
            setInterval('display_next_testimonial();', 5000);