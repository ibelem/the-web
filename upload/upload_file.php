<?php
	echo '<style type="text/css">body {width:600px;margin:20px auto;font-family:Verdana;font-size:16px;}#footer {margin:10px auto;} div {margin: 10px auto; padding: 10px;}</style>';
?>

<?php
if (( $_FILES["file"]["type"] == "application/x-httpd-php"
	|| $_FILES["file"]["type"] == "application/x-javascript"
	|| $_FILES["file"]["type"] == "application/exe"
	|| $_FILES["file"]["type"] == "application/x-exe"
	|| $_FILES["file"]["type"] == "application/dos-exe"
	|| $_FILES["file"]["type"] == "vms/exe"
	|| $_FILES["file"]["type"] == "application/x-winexe"
	|| $_FILES["file"]["type"] == "application/bat"
	|| $_FILES["file"]["type"] == "application/x-bat"
)
|| ($_FILES["file"]["size"] > 200000000)) {
	echo "File format forbidden.";
}

	else
  {
	  if ($_FILES["file"]["error"] > 0)
	    {
	    echo "Return Code: " . $_FILES["file"]["error"] . "<br />";
	    }
	  else
	    {
	    echo "Upload: " . $_FILES["file"]["name"] . "<br />";
	    echo "Type: " . $_FILES["file"]["type"] . "<br />";
	    echo "Size: " . ($_FILES["file"]["size"] / 1024) . " Kb<br />";
	    //echo "Temp file: " . $_FILES["file"]["tmp_name"] . "<br />";
	
		    if (file_exists("./uploads/" . $_FILES["file"]["name"]))
		      {
		      echo $_FILES["file"]["name"] . " already exists. ";
		      }
		    else
		      {
			      move_uploaded_file($_FILES["file"]["tmp_name"], "./uploads/" . $_FILES["file"]["name"]);
			      
			     	$uploadedpath = "./uploads/" . $_FILES["file"]["name"];
			      	$md5fileupl = md5_file($uploadedpath);
					$sha1fileupl = sha1_file($uploadedpath);
			     	
			     	try {
				     	$originalpath = "./f/" . $_FILES["file"]["name"];
				     	$md5fileori = md5_file($originalpath);
				     	$sha1fileori = sha1_file($originalpath);
				     	
				     	echo 'Stored in: ' . './uploads/' . $_FILES["file"]["name"]. 
			     		 '<div style="background-color:#FFFFCC">上传文件 MD5 散列:'. $md5fileupl.'<br/>原始文件 MD5 散列:'.$md5fileori."</div>";
			     		
			     		 
			     		 if($md5fileori == $md5fileupl) {
			     		 	echo '<div style="background-color:green; color:#fff;">MD5 Hash - PASSed</div>';
			     		 }
			     		 else {
			     		 	echo '<div style="background-color:red; color:#fff;">MD5 Hash - FAILed</div>';
			     		 }
			     		 
			     		  echo '<div style="background-color:#FFFFCC">上传文件 SHA-1 散列:'. $md5fileupl.'<br/>原始文件 SHA-1 散列:'.$md5fileori."</div>";
			     		
						 if($sha1fileori == $sha1fileupl) {
			     		 	echo '<div style="background-color:green; color:#fff;">SHA-1 Hash - PASSed</div>';
			     		 }
			     		 else {
			     		 	echo '<div style="background-color:red; color:#fff;">SHA-1 Hash - FAILed</div>';
			     		 }
			     		 
				     	if (!unlink($uploadedpath))
						  {
						  	echo ("<div style='background-color:#CBECFD'>Error deleting ". $uploadedpath." </div><br/><a href='index.htm'>Back to Home</a>");
						  	
						  }
						else
						  {
						  	echo ("<div style='background-color:#CBECFD'>Deleted ".$uploadedpath ." </div> <br/><a href='index.htm'>Back to Home</a></div>");
						  }
		      		}
		      		catch (Exception $e){
		      				echo $e.' 请首先到<a href="http://people.opera.com/minz/upload/f">http://people.opera.com/minz/upload/f</a> 下载任意文件并上传, 其他文件不允许上传.';
		      		}
	
			 }
	    }
  }
 

?>