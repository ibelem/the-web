 $(document).ready(function() {
 
			$("div.trathismonth a").fancybox({
				'zoomSpeedIn':	0, 
				'zoomSpeedOut':	0, 
				'overlayShow':	true
			});
			
			$("a#trathismonth_gb").fancybox({
				'itemLoadCallback': getGroupItems
			});
			
			$("a#trathismonth_ky").fancybox({
				'itemLoadCallback': getGroupItemsKy
			});

 			$("a#trathismonth_qxg").fancybox({
				'itemLoadCallback': getGroupItemsqxg
			});
			
			$("a#trathismonth_wr").fancybox({
				'itemLoadCallback': getGroupItemswr
			});

			$("a#trathismonth_col").fancybox({
				'itemLoadCallback': getGroupItemscol
			});
 
		});

		var imageList = [
			{url: "img/trainingphoto/gb1.jpg", title: "顾斌与同仁培训 1"},
			{url: "img/trainingphoto/gb2.jpg", title: "顾斌与同仁培训 2"},
			{url: "img/trainingphoto/gb3.jpg", title: "顾斌与同仁培训 3"},
			{url: "img/trainingphoto/gb4.jpg", title: "顾斌与同仁培训 4"}
		];
		
		var imageListKy = [
			{url: "img/trainingphoto/ky1.jpg", title: "寇永培训 1"},
			{url: "img/trainingphoto/ky2.jpg", title: "寇永培训 2"} 

		];
		
		var imageListqxg = [
			{url: "img/trainingphoto/qxg1.jpg", title: "乔晓光培训 1"},
			{url: "img/trainingphoto/qxg2.jpg", title: "乔晓光培训 2"},
			{url: "img/trainingphoto/qxg3.jpg", title: "乔晓光培训 3"}

		];
		
		var imageListwr = [
			{url: "img/trainingphoto/wr1.jpg", title: "吴锐培训 1"},
			{url: "img/trainingphoto/wr2.jpg", title: "吴锐培训 2"} 

		];
		
		var imageListcol = [
			{url: "img/trainingphoto/class1.jpg", title: "培训课 1"},
			{url: "img/trainingphoto/class2.jpg", title: "培训课 2"},
			{url: "img/trainingphoto/stu1.jpg", title: "培训课 3"} 
		];


		
		function getGroupItems(opts) {
			jQuery.each(imageList, function(i, val) {
		        opts.itemArray.push(val);
		    });
		}
		
		function getGroupItemsKy(opts) {
			jQuery.each(imageListKy, function(i, val) {
		        opts.itemArray.push(val);
		    });
		}
		
		function getGroupItemsqxg(opts) {
			jQuery.each(imageListqxg, function(i, val) {
		        opts.itemArray.push(val);
		    });
		}

		function getGroupItemswr(opts) {
			jQuery.each(imageListwr, function(i, val) {
		        opts.itemArray.push(val);
		    });
		}

		function getGroupItemscol(opts) {
			jQuery.each(imageListcol, function(i, val) {
		        opts.itemArray.push(val);
		    });
		}
