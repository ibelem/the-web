<?php
 

		$uUsr = $_POST["iusr"];
		$uUA = $_SERVER["HTTP_USER_AGENT"];
		$uKX = $_POST["cbKX"];
		$uWB = $_POST["cbWB"];
 		$uQQ = $_POST["cbQQ"];
 		$uSH = $_POST["cbSH"];
 		$u163 = $_POST["cb163"];
 		$uFE = $_POST["cbFE"];
 		 		 		 		
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
			} else if (strpos($udevice,"windows phone os 7")) {
	 			$udevice = "Windows Phone 7";	
			} else if (strpos($udevice,"windows phone os 8")) {
	 			$udevice = "Windows Phone 8";	
			} else if (strpos($udevice,"msie")) {
	 			$udevice = "Windows Internet Explorer";	
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
	 		$udevice = "Blackberry";	
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
		
		
		require_once('../Connections/conn.php');
		mysql_db_query($database_belemview,"set names 'utf8'"); 
		
		
		$uName = "";		
		$uMail = "";
		$uUrl = "http://lieb.cn";
		$uUsr =trim($uUsr);
		$uMessage = $uUsr. ' via '.$udevice;

		$timeoffset=15;
		$uTime = date("Y-m-d H:i:s", time() + $timeoffset * 3600);
		
		$sql= "INSERT INTO `lieb`.`vip_homemessage` (`mid`, `uname`, `umail`, `uurl`, `uupdatetime`, `umessage`, `unote`) VALUES (NULL, '$uName', '$uMail', '$uUrl', '$uTime', '$uMessage', NULL);";
		
		$t;
				
		if($uMessage !== false && $uMessage !== "")
		{	
					$con = $mysqlconn_belemview_t;
					if(!$con) echo "没有连接成功!"; 
							 			
					mysql_select_db($database_belemview, $con);
										
					if (!mysql_query($sql,$con))
					  {
					  	die('数据插入失败: ' . mysql_error());
					  }
		 			
					mysql_close($con);
					
					$t = "Inserted into DB sucessfully.<br/><br/>";
		}
		else
		{
			$t = "Inserted into DB -- FAILED.<br/><br/>";	
		}
		

		
		include("../w/Connections/Snoopy.class.php");
		
		$uKXResult;
		$uWBResult;
		$uQQResult;
		$uSHResult;
		$u163Result;
		$uFEResult;
		
		$uUsr =trim($uUsr);
		$uUsr = $uUsr. ' via '.$udevice.', http://lieb.cn';
			
		if($uKX == "on")
		{
			try {
				define('KAIXIN001_USERNAME' , '');
				define('KAIXIN001_PASSWORD' , '');
				$snoopy = new Snoopy();
		
				$referer = 'http://www.kaixin001.com/';
				$loginUrl = 'http://www.kaixin001.com/login/login.php';
				$loginFormData['url'] = '/home/';
				$loginFormData['email'] = KAIXIN001_USERNAME;
				$loginFormData['password'] = KAIXIN001_PASSWORD;
				
				$ztFormUrl = 'http://www.kaixin001.com/home/status.php';
				$ztSubmitUrl = 'http://www.kaixin001.com/friend/status_submit.php';
				$ztFormData['state'] = $uUsr;
				$ztFormData['_'] = '';
				
				$snoopy->referer  = $referer;
				$snoopy->submit($loginUrl,$loginFormData);
				$snoopy->fetch($ztFormUrl);	
				$uKXResult .= "Kaixin001 signed in. ";	
				$snoopy->submit($ztSubmitUrl,$ztFormData);
				$uKXResult .="Kaixin001: Successfully.<br/> ";
			}
			catch (Exception $e)
			{
			    $uKXResult="Text posted into kaixin001 failed: ".$e->getMessage().'<br/>';
			}

		}
		
		if($uQQ == "on")	
		{
			try {

			define('QQWB_USERNAME' , '');
			define('QQWB_PASSWORD' , '');
			$snoopy3 = new Snoopy();
	
			$referer3 = 'http://t.3g.qq.com/';
			$loginUrl3 = 'http://pt.3g.qq.com/microblogLogin?&sid=Gd8H/Hk3qLXJOMkXUX4bTA==';

			$loginFormData3['qq'] = QQWB_USERNAME;
			$loginFormData3['pwd'] = QQWB_PASSWORD;
			$loginFormData3['goUrl'] = 'http://ti.3g.qq.com/g/s?aid=loginjump';
			$loginFormData3['q_from'] = 'mblog';
			$loginFormData3['r_sid'] = '';		
			
			$ztFormUrl3 = 'http://ti.3g.qq.com/g/s?sid=OeOGIKpHBccTg7r/Z0tn0Q==&r=191650&&hu=ibelem&aid=h';
			$ztSubmitUrl3 = 'http://ti.3g.qq.com/g/s?sid=OeOGIKpHBccTg7r/Z0tn0Q==&r=946203&hu=ibelem&aid=amsg&bid=h%23ibelem%230%230%230%230&rof=true&ifh=1';
			$ztFormData3['msg'] = $uUsr;
			$ztFormData3['ac'] = '51';
			$ztFormData3['confirm'] = '广播';
					
			$snoopy3->referer  = $referer3;
			$snoopy3->submit($loginUrl3,$loginFormData3);
			
			$snoopy3->fetch($ztFormUrl3);
			$uQQResult .="Tencent/QQ weibo: signed in. ";				
			$snoopy3->submit($ztSubmitUrl3,$ztFormData3);
			$uQQResult .="Tencent/QQ weibo: successfully.<br/> ";
			}
			catch (Exception $eQQ)
			{
			    $uQQResult="Text posted into Tencent/QQ weibo failed: ".$eQQ->getMessage().'<br/>';
			}
		}

		if($uSH == "on")	
		{
			try {

			define('SOHUWB_USERNAME' , '');
			define('SOHUWB_PASSWORD' , '');
			$snoopySOHU = new Snoopy();
	
			$refererSOHU = 'http://3g.t.sohu.com'; 
			$loginUrlSOHU = 'http://3g.t.sohu.com/login.do';

			$loginFormDataSOHU['u'] = SOHUWB_USERNAME;
			$loginFormDataSOHU['p'] = SOHUWB_PASSWORD;
			$loginFormDataSOHU['m'] = 'doLogin';
			$loginFormDataSOHU['f_r'] = '';
	
			$ztFormUrlSOHU = 'http://3g.t.sohu.com/fridoc.do?tid=143bZWdG-xpVib29rQHNvaHUuY29tOj_2g8935a9b7&suv=9039725506670';
			$ztSubmitUrlSOHU = 'http://3g.t.sohu.com/send.do?tid=143bZWdG-xpVib29rQHNvaHUuY29tOj_2g8935a9b7&suv=9039725506670';
			$ztFormDataSOHU['content'] = $uUsr;
			$ztFormDataSOHU['ru'] = './dridoc.do?currentpage=';
			$ztFormDataSOHU['gid'] = '';
			$ztFormDataSOHU['send'] = '发送';
								
			$snoopySOHU->referer  = $refererSOHU;
			$snoopySOHU->submit($loginUrlSOHU,$loginFormDataSOHU);
			
			$snoopySOHU->fetch($ztFormUrlSOHU);		
			$uSHResult .="SOHU weibo: signed in. ";		
			$snoopySOHU->submit($ztSubmitUrlSOHU,$ztFormDataSOHU);
			$uSHResult .="SOHU weibo: successfully.<br/> ";
			}
			catch (Exception $eSOHU)
			{
			    $uSHResult="Text posted into SOHU weibo failed: ".$eSOHU->getMessage().'<br/>';
			}
		}
		
		if($uFE == "on")	
		{
			try {

			define('FE_USERNAME' , '');
			define('FE_PASSWORD' , '');
			$snoopyFE = new Snoopy();
	
			$refererFE = 'http://m.t.ifeng.com/'; 
			$loginUrlFE = 'http://m.t.ifeng.com/?_c=account&_a=doLogin';

			$loginFormDataFE['loginusername'] = FE_USERNAME;
			$loginFormDataFE['password'] = FE_PASSWORD;
			$loginFormDataFE['remember'] = '1';
			$loginFormDataFE['refUrl'] = 'http://m.t.ifeng.com';
			$loginFormDataFE['v'] = '2';
			$loginFormDataFE['PHPSESSID'] = '86go9v3ru31ld0g1cvig8kp3s5';
			$loginFormDataFE['_qkey'] = '';
	
			$ztFormUrlFE = 'http://m.t.ifeng.com/?v=2&PHPSESSID=86go9v3ru31ld0g1cvig8kp3s5';
			$ztSubmitUrlFE = 'http://m.t.ifeng.com/?_c=tweet&_a=add';
			
			/*
			$ztFormDataFE['content'] = $uUsr;
			$ztFormDataFE['ru'] = './dridoc.do?currentpage=';
			$ztFormDataFE['gid'] = '';
			$ztFormDataFE['send'] = '发送';
			*/
			
			/*
			
			-----------------------------7db6d2110c96
			Content-Disposition: form-data; name="content"
			
			你好 CES
			-----------------------------7db6d2110c96
			Content-Disposition: form-data; name="ca"
			
			user_space
			-----------------------------7db6d2110c96
			Content-Disposition: form-data; name="replyUid"
			
			
			-----------------------------7db6d2110c96
			Content-Disposition: form-data; name="replyTid"
			
			
			-----------------------------7db6d2110c96
			Content-Disposition: form-data; name="backurl"
			
			http://m.t.ifeng.com/?v=2&PHPSESSID=86go9v3ru31ld0g1cvig8kp3s5
			-----------------------------7db6d2110c96
			Content-Disposition: form-data; name="v"
			
			2
			-----------------------------7db6d2110c96
			Content-Disposition: form-data; name="PHPSESSID"
			
			86go9v3ru31ld0g1cvig8kp3s5
			-----------------------------7db6d2110c96
			Content-Disposition: form-data; name="_qkey"
			
			
			-----------------------------7db6d2110c96--

			*/
			
			$postdataFE['content'] = $uUsr;
			$postdataFE['ca'] = 'user_space';
			$postdataFE['replyUid'] = '';
			$postdataFE['replyTid'] = '';
			$postdataFE['backurl'] = 'http://m.t.ifeng.com/?v=2&PHPSESSID=86go9v3ru31ld0g1cvig8kp3s5';
			$postdataFE['v'] = '2';
			$postdataFE['PHPSESSID'] = '86go9v3ru31ld0g1cvig8kp3s5';
			$postdataFE['_qkey'] = '';
														
			$snoopyFE->referer  = $refererFE;
			$snoopyFE->submit($loginUrlFE,$loginFormDataFE);
			
			$snoopyFE->fetch($ztFormUrlFE);		
			$uFEResult .="iFeng weibo: signed in. ";	
			
			//$snoopyFE->set_submit_multipart(); 	
			$snoopyFE->submit_type = "multipart/form-data";
			$snoopyFE->submit($ztSubmitUrlFE,$postdataFE);
			$uFEResult .="iFeng weibo: successfully.<br/> ";
			}
			catch (Exception $eFE)
			{
			    $uFEResult="Text posted into iFeng weibo failed: ".$eFE->getMessage().'<br/>';
			}
		}

		if($u163 == "on")	
		{
			try {

			define('WB163_USERNAME' , '');
			define('WB163_PASSWORD' , '');
			$snoopy163 = new Snoopy();
	
			$referer163 = 'http://3g.163.com/t/session';
			$loginUrl163 = 'http://reg.163.com/mlogin.jsp';

			$loginFormData163['username'] = WB163_USERNAME;
			$loginFormData163['password'] = WB163_PASSWORD;
			$loginFormData163['type'] = '1';
			$loginFormData163['url'] = 'http://3g.163.com/t/';
			$loginFormData163['url2'] = 'http://3g.163.com/t/account/loginFailed';
			$loginFormData163['product'] = '3g_t';
			$loginFormData163['isloginyoudao'] = '0';
			$loginFormData163['savelogin'] = '1';
			$loginFormData163['sub'] = '登录';
						
			$ztFormUrl163 = 'http://3g.163.com/t/?username=belem';
			$ztSubmitUrl163 = 'http://3g.163.com/t/statuses/update.do';
			
			$postdata163;
			 
			$postdata163['url'] = '/t/#p';
			$postdata163['emReturnUrl'] = '/t/';
			$postdata163['status'] = $uUsr;
			$postdata163['sub'] = '发布';
						
			/*
			
			-----------------------------7db1d426110c96
			Content-Disposition: form-data; name="url"
			
			/t/#p
			-----------------------------7db1d426110c96
			Content-Disposition: form-data; name="emReturnUrl"
			
			/t/
			-----------------------------7db1d426110c96
			Content-Disposition: form-data; name="status"
			
			测试一下
			-----------------------------7db1d426110c96
			Content-Disposition: form-data; name="sub"
			
			发布
			-----------------------------7db1d426110c96--

			*/

							
			$snoopy163->referer  = $referer163;
			$snoopy163->submit($loginUrl163,$loginFormData163);
			
			$snoopy163->fetch($ztFormUrl163);

			$u163Result .="163 weibo: signed in. ";	
			
			$snoopy163->submit_type = "multipart/form-data";		
			$snoopy163->submit($ztSubmitUrl163,$postdata163);
			$u163Result .="163 weibo: successfully.<br/> ";

			}
			catch (Exception $e163)
			{
			    $u163Result="Text posted into 163 weibo failed: ".$e163->getMessage().'<br/>';
			}
		}

		if($uWB == "on")	
		{
			try {

			define('SINAWB_USERNAME' , '');
			define('SINAWB_PASSWORD' , '');
			$snoopy2 = new Snoopy();
	
			$referer2 = 'http://3g.sina.com.cn/prog/wapsite/sso/login.php?ns=1&revalid=2&backURL=http%3A%2F%2Fweibo.cn%2Fdpool%2Fttt%2Fhome.php&backTitle=%D0%C2%C0%CB%CE%A2%B2%A9&vt=';
			$loginUrl2 = 'http://3g.sina.com.cn/prog/wapsite/sso/login_submit.php?rand=944548731&backURL=http%3A%2F%2Fweibo.cn%2Fdpool%2Fttt%2Fhome.php&backTitle=%D0%C2%C0%CB%CE%A2%B2%A9&vt=4&revalid=2&ns=1';
			$loginFormData2['remember'] = 'on';
			$loginFormData2['deea'] = '256156483';
			$loginFormData2['mobile'] = SINAWB_USERNAME;
			$loginFormData2['password'] = SINAWB_PASSWORD;
			$loginFormData2['backURL'] = 'http://weibo.cn/dpool/ttt/home.php';
			$loginFormData2['backTitle'] = '新浪微博';
			$loginFormData2['submit'] = '登录';		
	
			$ztFormUrl2 = 'http://weibo.cn/dpool/ttt/home.php?gsid=3_58a34dc7d04411c597ebd9eb52047b7bfc0bcc&vt=4&lret=1';
							
			$ztSubmitUrl2 = 'http://weibo.cn/dpool/ttt/mblogDeal.php?st=5fa4&st=5fa4&vt=4&gsid=3_58a34dc7d04411c597ebd9eb52047b7bfc0bcc';
			
			$ztFormData2['content'] = $uUsr;
			$ztFormData2['rl'] = '0';
			$ztFormData2['act'] = 'add';
					
			$snoopy2->referer  = $referer2;
			$snoopy2->submit($loginUrl2,$loginFormData2);
			
			$snoopy2->fetch($ztFormUrl2);	
			
 			$uWBResult .="SINA weibo: signed in. ";		
			$snoopy2->submit($ztSubmitUrl2,$ztFormData2);
			$uWBResult .="SINA weibo: successfully.<br/> ";
			
			}
			catch (Exception $eWB)
			{
			    $uWBResult="Text posted into SINA weibo failed: ".$eWB->getMessage().'<br/>';
			}
		}
		
		echo $t.$uKXResult.$uWBResult.$uQQResult.$uSHResult.$u163Result.$uFEResult."<br/> <a href='../i'>Go back</a>";

?>  
