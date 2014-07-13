<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
<meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
<title>HTTP HEADER + POST</title>
    <style type="text/css">
    body {
        margin:20px auto;
        text-align:left;
        font-size:13px;
        font-family: Arial, Helvetica, sans-serif;
        width:80%;
    }
    .r {
		font-family:"Courier New", Courier, monospace;
	}
 
	.it {
		color:green;
		font-weight:bold;
	}
    </style>
</head>

<body>
<h3>HTTP HEADER + POST</h3>
<div class="r">
<span style="color: red"><script type="text/javascript">document.write("platform: " + navigator.platform + "   Name:" + navigator.appName);</script></span><br/><br/>
<?php
	date_default_timezone_set('PRC');
	
	if (!function_exists('apache_request_headers')) { 
			function apache_request_headers() { 
				foreach ($_SERVER as $name => $value) 
			   { 
				   if (substr($name, 0, 5) == 'HTTP_') 
				   { 
					   $name = str_replace(' ', '-', ucwords(strtolower(str_replace('_', ' ', substr($name, 5))))); 
					   $headers[$name] = $value; 
				   } else if ($name == "HTTP_X_IMSI") { 
					   $headers["HTTP_X_IMSI"] = $value; 
				   } else if ($name == "HTTP_X_MAC") { 
					   $headers["HTTP_X_MAC"] = $value; 
				   } 
			   } 
			   return $headers; 
			}
	} 
 
 
    $headers = apache_request_headers();
	
	echo date("D M j G:i:s T Y")."<br/><br/>";
    
    $g = "<div class='it'>Header Info:</div>";
	foreach ($headers as $header => $v) { 
		$g = $g."$header: $v<br/>"; 
	}

	$g = $g."<br/>URL: ".$_SERVER ['HTTP_HOST'].$_SERVER['PHP_SELF']."<br/>"; 
	
	$g = $g."HTTPS: ".$_SERVER['HTTPS']."<br/>"; 
	$g = $g."HTTP_HOST: ".$_SERVER['HTTP_HOST']."<br/>"; 
	$g = $g."PHP_SELF: ".$_SERVER['PHP_SELF']."<br/>"; 
	$g = $g."HTTP_REFERER: ".$_SERVER['HTTP_REFERER']."<br/>"; 
	$g = $g."SERVER_NAME: ".$_SERVER['SERVER_NAME']."<br/>"; 
	$g = $g."SERVER_ADDR: ".$_SERVER['SERVER_ADDR']."<br/>"; 	
	$g = $g."SERVER_SOFTWARE: ".$_SERVER['SERVER_SOFTWARE']."<br/>"; 
	$g = $g."SERVER_PROTOCOL: ".$_SERVER['SERVER_PROTOCOL']."<br/>"; 
	$g = $g."REQUEST_METHOD: ".$_SERVER['REQUEST_METHOD']."<br/>"; 
	$g = $g."GATEWAY_INTERFACE: ".$_SERVER['GATEWAY_INTERFACE']."<br/>"; 
	$g = $g."QUERY_STRING: ".$_SERVER['QUERY_STRING']."<br/>"; 
	$g = $g."REMOTE_ADDR: ".$_SERVER['REMOTE_ADDR']."<br/>"; 
	$g = $g."REMOTE_HOST: ".$_SERVER['REMOTE_HOST']."<br/>"; 
	$g = $g."REMOTE_PORT: ".$_SERVER['REMOTE_PORT']."<br/>"; 
	$g = $g."SERVER_SIGNATURE: ".$_SERVER['SERVER_SIGNATURE']."<br/>"; 
	$g = $g."SCRIPT_FILENAME: ".$_SERVER['SCRIPT_FILENAME']."<br/>"; 
	$g = $g."SERVER_ADMIN: ".$_SERVER['SERVER_ADMIN']."<br/>"; 
	$g = $g."PATH_TRANSLATED: ".$_SERVER['PATH_TRANSLATED']."<br/>"; 
	$g = $g."SCRIPT_NAME: ".$_SERVER['SCRIPT_NAME']."<br/>"; 
	$g = $g."REQUEST_URI: ".$_SERVER['REQUEST_URI']."<br/>"; 
	$g = $g."PHP_AUTH_USER: ".$_SERVER['PHP_AUTH_USER']."<br/>"; 
	$g = $g."PHP_AUTH_PW: ".$_SERVER['PHP_AUTH_PW']."<br/>"; 
	$g = $g."AUTH_TYPE: ".$_SERVER['AUTH_TYPE']."<br/>"; 
	$g = $g."HTTP_X_FORWARDED_FOR: ".$_SERVER['HTTP_X_FORWARDED_FOR']."<br/>"; 
 
	$g = $g."<br/><div class='it'>POST Info:</div>";
	
	$g = $g.file_get_contents("php://input");

    print_r($g);
	
	$date=date("Y-m-d");
	    
    $filename="log/".$date.".txt";
 
	if (is_readable($filename) == false || is_writable($filename) == false) {
		//touch($filename);
		$handling = fopen($filename, "w+"); 
	} else {
		$handling = fopen($filename, 'a');
	}
 
	$t = "";
	foreach ($headers as $header => $v) { 
		$t = $t."$header: $v\n";
	}
	
	$t = $t."\nURL: ".$_SERVER ['HTTP_HOST'].$_SERVER['PHP_SELF']."\n"; 
	$t = $t."HTTPS: ".$_SERVER['HTTPS']."\n"; 
	$t = $t."HTTP_HOST: ".$_SERVER['HTTP_HOST']."\n"; 
	$t = $t."PHP_SELF: ".$_SERVER['PHP_SELF']."\n"; 
	$t = $t."HTTP_REFERER: ".$_SERVER['HTTP_REFERER']."\n"; 
	
	$t = $t."SERVER_NAME: ".$_SERVER['SERVER_NAME']."\n"; 
	$t = $t."SERVER_ADDR: ".$_SERVER['SERVER_ADDR']."\n"; 	
	$t = $t."SERVER_SOFTWARE: ".$_SERVER['SERVER_SOFTWARE']."\n"; 
	$t = $t."SERVER_PROTOCOL: ".$_SERVER['SERVER_PROTOCOL']."\n"; 
	$t = $t."REQUEST_METHOD: ".$_SERVER['REQUEST_METHOD']."\n"; 
	$t = $t."GATEWAY_INTERFACE: ".$_SERVER['GATEWAY_INTERFACE']."\n"; 
	$t = $t."QUERY_STRING: ".$_SERVER['QUERY_STRING']."\n"; 
	$t = $t."REMOTE_ADDR: ".$_SERVER['REMOTE_ADDR']."\n"; 
	$t = $t."REMOTE_HOST: ".$_SERVER['REMOTE_HOST']."\n"; 
	$t = $t."REMOTE_PORT: ".$_SERVER['REMOTE_PORT']."\n"; 
	$t = $t."SERVER_SIGNATURE: ".$_SERVER['SERVER_SIGNATURE']."\n"; 
	$t = $t."SCRIPT_FILENAME: ".$_SERVER['SCRIPT_FILENAME']."\n"; 
	$t = $t."SERVER_ADMIN: ".$_SERVER['SERVER_ADMIN']."\n"; 
	$t = $t."PATH_TRANSLATED: ".$_SERVER['PATH_TRANSLATED']."\n"; 
	$t = $t."SCRIPT_NAME: ".$_SERVER['SCRIPT_NAME']."\n"; 
	$t = $t."REQUEST_URI: ".$_SERVER['REQUEST_URI']."\n"; 
	$t = $t."PHP_AUTH_USER: ".$_SERVER['PHP_AUTH_USER']."\n"; 
	$t = $t."PHP_AUTH_PW: ".$_SERVER['PHP_AUTH_PW']."\n"; 
	$t = $t."AUTH_TYPE: ".$_SERVER['AUTH_TYPE']."\n"; 
	$t = $t."HTTP_X_FORWARDED_FOR: ".$_SERVER['HTTP_X_FORWARDED_FOR']."\n"; 

	$t = $t."\nPOST: ";
	$t = $t.file_get_contents("php://input");
	
	fwrite($handling, "\n\r\n\r".date("D M j G:i:s T Y")."\n\r".$t);
	
	//$filenameact="act.txt";
	
	$filenameact="log/".$date."_act.txt";
	
	if (is_readable($filenameact) == false || is_writable($filenameact) == false) {
		//touch($filename);
		$handlingact = fopen($filenameact, "w+"); 
	} else {
		$handlingact = fopen($filenameact, 'a');
	}
 
	$tact = "";
	foreach ($headers as $header => $v) { 
 
		if( 
		strpos($header,"X-nHorizon-Hash")>-1 || strpos($header,"X-OperaMini-Screen-Height")>-1 ||
		strpos($header,"X-OperaMini-Screen-Width")>-1 || strpos($header,"X-OperaMini-Features")>-1 ||
		strpos($header,"X-OperaMini-GeoData")>-1 || strpos($header,"X-OperaMini-Skin-Resolution")>-1 ||
		
		strpos($header,"Cookie")>-1 || strpos($header,"Connection")>-1 || strpos($header,"Accept-Encoding")>-1 || strpos($header,"Accept-Language")>-1 || strpos($header,"Accept")>-1 || strpos($header,"Host")>-1 || strpos($header,"Cache-Control")>-1) {
			;
		} else {
			$tact = $tact."$header: $v\n";
		}
	}
	
	$tact = $tact."\nPOST: ";
	$tact = $tact.file_get_contents("php://input");
	
	fwrite($handlingact, "\n\r\n\r".date("D M j G:i:s T Y")."\n\r".$tact);
 

?>

</div>
<p/><div class="f">&copy;2013 Internal. <a href="log/<?php echo $date; ?>.txt" title="查看 log"><?php echo $date; ?>.txt</a> / <a href="log/<?php echo $date; ?>_act.txt" title="ACT log"><?php echo $date; ?>_act.txt</a> / <a href="log.php">full logs</a> / <a href="ua.htm" title="常用 UA">ua</a></div>
</body>

</html>
