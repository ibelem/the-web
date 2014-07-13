<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
<meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
<title>HTTP Header + POST logs</title>
    <style type="text/css">
    body {
        margin:20px auto;
        text-align:left;
        font-size:1em;
        font-family: Arial, Helvetica, sans-serif;
        width:80%;
    }
    .r {
	font-family:"Courier New", Courier, monospace;
	font-size:0.8em;
	}
	.f {
	font-size:0.8em;
}
.it {
	color:green;
	font-weight:bold;
}
#ihr {
	border-bottom:1px solid #333;
	margin: 10px auto;
	padding: 10px 0px;
}
    </style>
</head>

<body>
<h3>HTTP Header + POST logs</h3>
<div class="r">
<?php
	date_default_timezone_set('PRC');
 
	//$date=date("Y-m-d");
 
 
	$base_dir="log/";
	$fso=opendir($base_dir);
	echo  "<div id='ihr'>".$base_dir."</div>";
	while($flist=readdir($fso)){
		  echo "<a href='log/".$flist."'>".$flist."</a><br/>";
	}
	closedir($fso)
 
?>

</div>
 
</body>

</html>
