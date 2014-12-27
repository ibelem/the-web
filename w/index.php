<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>[ min ] - Where is minz?</title>
<meta http-equiv="Content-Language" content="UTF-8" />
<meta name="robots" content="all" />
<meta name="author" content="Belem, belem@163.com" />
<meta name="Copyright" content="Copyright (c) 2010, Belem, min, minz, 张敏" />
<meta name="keywords" content= "Belem, min, minz, 张敏, 丁沟, 江都" />
<meta name="description" content="By Belem, min, minz, 张敏, lieb.cn, belemview.com, min-vip.com" />
<link href="style/home.css" type="text/css" rel="stylesheet" />
<script type="text/javascript">

	if(navigator.userAgent.toLowerCase().indexOf("windows") != -1 && navigator.userAgent.toLowerCase().indexOf("msie") != -1) {	
		if (!navigator.geolocation) {  
			document.write("  微软 Internet Explorer 或者档次较低浏览器? 对不起, 暂时没法支持...");
			location.href = "http://lieb.cn";
		}
	}
</script>

<script type="text/javascript" src="script/geo.js"></script>

</head>

<body>
<div id="wrap">
<table id="mytable" cellspacing="0" cellpadding="0" summary="Where is minz?">
<caption>Where is minz?</caption>
  <tr>
    <th>ID</th>
    <th class="iname">姓 名</th>
    <th class="igeo">纬 度</th>
	<th class="igeo">经 度</th>
    <th class="iloc">位 置</th>
    <th class="iclient">客户端</th>
	<th class="itime">时 间</th>
  </tr>
<?php require_once('Connections/conn.php'); ?>
<?php 
if(!$mysqlconn_belemview_t) echo "没有连接成功!"; 
mysql_db_query($database_belemview,"set names 'utf8'"); 
//mysql_db_query($database_belemview,"SHOW CHARACTER SET like 'utf8'"); 
$result = mysql_db_query($database_belemview,"select * from vip_where"); 

$i=1;
while($row = mysql_fetch_object($result)) { 
	$udevice = strtolower($row->uclient);
	
	 if (strpos($udevice,"ipad")) {
 		$udevice = "Apple iPad";	
	} else if (strpos($udevice,"ipod")) {
 		$udevice = "Apple iPod";	
	} else if (strpos($udevice,"iphone")) { 
 		$udevice = "Apple iPhone";
	} else if (strpos($udevice,"mac os")) {
 		$udevice = "Apple Mac";	
	} else if (strpos($udevice,"linux")) {
		if (strpos($udevice,"android")) {
	 		if (strpos($udevice,"milestone")) {
		 		$udevice = "Motorola Milestone";	
			} else if (strpos($udevice,"droid")) {
		 		$udevice = "Motorola Droid";	
			} else if (strpos($udevice,"mb200")) {
		 		$udevice = "Motorola CLIQ";	
			} else if (strpos($udevice,"nexus one")) {
		 		$udevice = "Google Nexus One";	
			} else if (strpos($udevice,"desire")) {
		 		$udevice = "HTC Desire";	
			} else if (strpos($udevice,"hero")) {
		 		$udevice = "HTC Hero";	
			} else if (strpos($udevice,"legend")) {
		 		$udevice = "HTC Legend";	
			} else if (strpos($udevice,"magic")) {
		 		$udevice = "HTC Magic";	
			} else if (strpos($udevice,"tatto")) {
		 		$udevice = "HTC Tattoo";	
			} else if (strpos($udevice,"adr")) {
		 		$udevice = "HTC Incredible";	
			} else if (strpos($udevice,"i9000")) {
		 		$udevice = "Samsung i9000";	
			} else if (strpos($udevice,"xt720")) {
		 		$udevice = "Motorola Motoroi";	
			} else if (strpos($udevice,"htc")) {
		 		$udevice = "HTC Android";	
			} else if (strpos($udevice,"moto")) {
		 		$udevice = "Motorola Android";	
			} else if (strpos($udevice,"opera")>=0) {
		 		$udevice = "Android Opera";	
			} else {
		 		$udevice = "Android";	
			}
		} else if (strpos($udevice,"kindle")) {
 			$udevice = "Amazon Kindle";	
		} else {
	 		
	 		if (strpos($udevice,"opera")>=0) {
	 			$udevice = "Linux Opera";	
			} else if (strpos($udevice,"firefox")) {
	 			$udevice = "Linux Firefox";	
			} else if (strpos($udevice,"chrome")) {
	 			$udevice = "Linux Google Chrome";	
			} else if (strpos($udevice,"Safari")) {
	 			$udevice = "Linux Safari";	
			} else {
				$udevice = "Linux";
			}
		} 
 
	} else if (strpos($udevice,"window")) {
 		//echo '<script>alert("'.$udevice.'");</script>';
 		if (strpos($udevice,"firefox")) {
 			$udevice = "Windows Firefox";	
		} else if (strpos($udevice,"chrome")) {
 			$udevice = "Windows Chrome";	
		} else if (strpos($udevice,"safari")) {
 			$udevice = "Windows Safari";	
		} else if (strpos($udevice,"windows phone os 7")) {
 			$udevice = "Windows Phone 7";	
		} else if (strpos($udevice,"windows phone os 8")) {
 			$udevice = "Windows Phone 8";	
		} else if (strpos($udevice,"opera")>=0) {
 			$udevice = "Windows Opera";	
		} else {
			if (strpos($udevice,"i917")) {
	 			$udevice = "Samsumg Focus";	
			} else {
				$udevice = "Windows";
			}
		}

	} else if (strpos($udevice,"blackberry")>=0) {
		if (strpos($udevice,"blackberry")>=0 && strpos($udevice,"9100")>=0) {
 			$udevice = "Blackberry Pearl 3G";	
		}
		else {
 			$udevice = "Blackberry 黑莓设备";	
 		}
	} else if (strpos($udevice,"symb")>=0) {
 		$udevice = "Symbian";	
	} else if (strpos($udevice,"brew")>=0) {
 		$udevice = "Brew 设备";	
	} else if (strpos($udevice,"unix")>=0) {
 		$udevice = "Unix";	
	} else if (strpos($udevice,"webos")>=0) {
 		$udevice = "Palm 设备";	
	} else if (strpos($udevice,"j2me")>=0) {
 		$udevice = "Java 设备";	
	} else if (strpos($udevice,"mtk")>=0) {
 		$udevice = "山寨机";	
	} else {
		$udevice = "N/A";
	}

	if($i%2==1) {
  		echo '<tr><td>'. $row->uid .'</td><td  class="iname">'. $row->uname .'</td><td class="igeo">'.$row->ulatitude.'</td><td class="igeo">'.$row->ulongitude.'</td><td class="iloc">'.$row->ulocationaddress.' <a href="go.htm?lat='.$row->ulatitude.'&lon='.$row->ulongitude.'" title="地图">Go</a></td><td class="iclient">'.$udevice.'</td><td class="itime">'.$row->uupdatetime.'</td></tr>';
  	}
  	else {
  		echo '<tr><td class="alt">'. $row->uid .'</td><td class="alt iname">'. $row->uname .'</td><td class="alt igeo">'.$row->ulatitude.'</td><td class="alt igeo">'.$row->ulongitude.'</td><td class="alt iloc">'.$row->ulocationaddress.' <a href="go.htm?lat='.$row->ulatitude.'&lon='.$row->ulongitude.'" title="地图">Go</a></td><td class="alt iclient">'.$udevice.'</td><td class="alt itime">'.$row->uupdatetime.'</td></tr>';
  	}
$i++;
} 
 
$i=1;
mysql_free_result($result);
?>
</table>

    <form action="kpost.php" method="post">
                    <div class="row2">姓名: <input id="iusr" name="iusr" type="text" size="24" value="minz" maxlength="24" /> <input type="checkbox" id="cbIsMin" />我不是 minz.</div>
                    <div class="row2">纬度: <input id="ilatitude" name="ilatitude" type="text" size="12" value="" maxlength="12" /> 经度: <input id="ilongitude" name="ilongitude" type="text" size="12" value="" maxlength="12" /></div>
                    <div class="row2">位置: <input id="ilocation" name="ilocation" type="text" size="64" value="" maxlength="64" /></div>
					<div class="row2"><input type="submit" id="btnCT" value="添加"></input></div>
     </form> 

</div> 
<script type="text/javascript" src="script/cb.js"></script>
</body>
</html>