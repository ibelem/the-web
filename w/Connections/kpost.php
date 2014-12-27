<?php
		require_once('Connections/conn.php');

		$uUsr = $_POST["iusr"];
		$uLat = $_POST["ilatitude"];
		$uLon = $_POST["ilongitude"];
		$uLoc = $_POST["ilocation"];
		$uUA = $_SERVER["HTTP_USER_AGENT"];
 
		$udevice = strtolower($uUA);
	
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
			} else if (strpos($udevice,"opera")>=0) {
	 			$udevice = "Windows Opera";	
			} else {
				if (strpos($udevice,"i917")) {
		 			$udevice = "Samsumg Focus";	
				} else {
					$udevice = "Windows";
				}
			}
	
		} else if (strpos($udevice,"blackberry")) {
	 		$udevice = "Blackberry 黑莓设备";	
		} else if (strpos($udevice,"symb")) {
	 		$udevice = "Symbian";	
		} else if (strpos($udevice,"brew")) {
	 		$udevice = "Brew 设备";	
		} else if (strpos($udevice,"unix")) {
	 		$udevice = "Unix";	
		} else if (strpos($udevice,"webos")) {
	 		$udevice = "Palm 设备";	
		} else if (strpos($udevice,"j2me")) {
	 		$udevice = "Java 设备";	
		} else if (strpos($udevice,"mtk")) {
	 		$udevice = "山寨机";	
		} else {
			$udevice = "N/A";
		}

		
		$timeoffset=15;
		$uTime = date("Y-m-d H:i:s", time() + $timeoffset * 3600);
		
		$sql= "INSERT INTO `minvipco_vip`.`vip_where` (`uid`, `uname`, `ulatitude`, `ulongitude`, `uupdatetime`, `ulocationaddress`, `uclient`, `unotes`) VALUES (NULL, '$uUsr', '$uLat', '$uLon', '$uTime', '$uLoc', '$uUA', NULL);";
				
		if($uUsr !== false && $uLat !== false)
		{	
					$con = $mysqlconn_belemview_t;
					if(!$con) echo "没有连接成功!"; 
							 			
					mysql_select_db($database_belemview, $con);
										
					if (!mysql_query($sql,$con))
					  {
					  	die('数据插入失败: ' . mysql_error());
					  }
		 			
					mysql_close($con);
		}
		else
		{
			echo "缺少数据输入. <a href='index.php'>返回首页</a>" ;		
		}
		
		echo "Where is minz? <script>window.location='index.php';</script>";

		
		include("Connections/Snoopy.class.php");
		
		
		define('KAIXIN001_USERNAME' , '');
		define('KAIXIN001_PASSWORD' , '');
		$snoopy = new Snoopy();

		$referer = 'http://www.kaixin001.com/';//这个可以不要
		$loginUrl = 'http://www.kaixin001.com/login/login.php';//登陆提交的地址
		$loginFormData['url'] = '/home/';//$loginFormData 是登陆需要提交的Form的数据
		$loginFormData['email'] = KAIXIN001_USERNAME;
		$loginFormData['password'] = KAIXIN001_PASSWORD;
		
		$ztFormUrl = ' http://www.kaixin001.com/home/status.php';
		$ztSubmitUrl = 'http://www.kaixin001.com/friend/status_submit.php';
		$ztFormData['state'] = '[minz] @N'.$uLat.'+E'.$uLon.' '.$uTime.' by '.$udevice.'. http://lieb.cn/where/go.htm?lat='.$uLat.'&lon='.$uLon;
		$ztFormData['_'] = '';
		
		$snoopy->referer  = $referer;
		$snoopy->submit($loginUrl,$loginFormData);//提交登陆数据
		

		
		$snoopy->fetch($ztFormUrl);//跳转到发转贴的页面，要得到一个稍后要用到的提交的参数rpuserastr，		
		$snoopy->submit($ztSubmitUrl,$ztFormData);

?>  
