<?php
 

		$uMsg = $_POST["imsg"];
		$uKX = $_POST["cbKX"];
		$uWB = $_POST["cbWB"];
 		$uQQ = $_POST["cbQQ"];
 		$uSH = $_POST["cbSH"];
 		$u163 = $_POST["cb163"];
 		$uFE = $_POST["cbFE"];

 		$uKXMail = $_POST["tKXMail"];	
 		$uWBMail = $_POST["tWBMail"];		
 		$uQQMail = $_POST["tQQMail"];	
 		$uSHMail = $_POST["tSHMail"];	
 		$uFEMail = $_POST["tFEMail"];	
 		$u163Mail = $_POST["t163Mail"];	
 		
 		$uKXPsd = $_POST["tKXPsd"];	
 		$uWBPsd = $_POST["tWBPsd"];		
 		$uQQPsd = $_POST["tQQPsd"];	
 		$uSHPsd = $_POST["tSHPsd"];	
 		$uFEPsd = $_POST["tFEPsd"];	
 		$u163Psd = $_POST["t163Psd"];	
	
	
		define('KAIXIN001_USERNAME' , $uKXMail);
		define('KAIXIN001_PASSWORD' , $uKXPsd);
			
		define('SINAWB_USERNAME' , $uWBMail);
		define('SINAWB_PASSWORD' , $uWBPsd);
		
		define('QQWB_USERNAME' , $uQQMail);
		define('QQWB_PASSWORD' , $uQQPsd);
		
		define('SOHUWB_USERNAME' , $uSHMail);
		define('SOHUWB_PASSWORD' , $uSHPsd);
		
		define('FE_USERNAME' , $uFEMail);
		define('FE_PASSWORD' , $uFEPsd);

		define('WB163_USERNAME' , $u163Mail);
		define('WB163_PASSWORD' , $u163Psd);
		
		
		include("../w/Connections/Snoopy.class.php");
		
		$uKXResult;
		$uWBResult;
		$uQQResult;
		$uSHResult;
		$u163Result;
		$uFEResult;
		
		$uMsg =trim($uMsg);

			
		if($uKX == "on")
		{
			try {

				$snoopy = new Snoopy();
		
				$referer = 'http://www.kaixin001.com/';
				$loginUrl = 'http://www.kaixin001.com/login/login.php';
				$loginFormData['url'] = '/home/';
				$loginFormData['email'] = KAIXIN001_USERNAME;
				$loginFormData['password'] = KAIXIN001_PASSWORD;
				
				$ztFormUrl = 'http://www.kaixin001.com/home/status.php';
				$ztSubmitUrl = 'http://www.kaixin001.com/friend/status_submit.php';
				$ztFormData['state'] = $uMsg;
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
		
		if($uWB == "on")	
		{
			try {


			$snoopy2 = new Snoopy();
	
			$referer2 = 'http://3g.sina.com.cn/prog/wapsite/sso/login.php?ns=1&revalid=2&backURL=http%3A%2F%2Ft.sina.cn%2Fdpool%2Fttt%2Fhome.php&backTitle=%D0%C2%C0%CB%CE%A2%B2%A9&vt=4&PHPSESSID=baded13c462d628d4fc09911ec32384d';
			$loginUrl2 = 'http://3g.sina.com.cn/prog/wapsite/sso/login_submit.php?rand=2106032175&backURL=http%3A%2F%2Ft.sina.cn%2Fdpool%2Fttt%2Fhome.php&backTitle=%D0%C2%C0%CB%CE%A2%B2%A9&vt=4&revalid=2&ns=1&PHPSESSID=baded13c462d628d4fc09911ec32384d';
			$loginFormData2['remember'] = 'on';
			$loginFormData2['mobile'] = SINAWB_USERNAME;
			$loginFormData2['password'] = SINAWB_PASSWORD;
			$loginFormData2['backURL'] = 'http://t.sina.cn/dpool/ttt/home.php';
			$loginFormData2['backTitle'] = '新浪微博';
			$loginFormData2['submit'] = '登录';		
	
			$ztFormUrl2 = 'http://t.sina.cn/dpool/ttt/home.php?gsid=3_58a34dc7d04411c597ebd9eb52047b7bfc0bcc&vt=4&lret=1';
			$ztSubmitUrl2 = 'http://t.sina.cn/dpool/ttt/mblogDeal.php?st=5fa4&st=5fa4&vt=4&gsid=3_58a34dc7d04411c597ebd9eb52047b7bfc0bcc';
			$ztFormData2['content'] = $uMsg;
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
		
		if($uQQ == "on")	
		{
			try {


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
			$ztFormData3['msg'] = $uMsg;
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
			
			$snoopySOHU = new Snoopy();
	
			$refererSOHU = 'http://3g.t.sohu.com'; 
			$loginUrlSOHU = 'http://3g.t.sohu.com/login.do';

			$loginFormDataSOHU['u'] = SOHUWB_USERNAME;
			$loginFormDataSOHU['p'] = SOHUWB_PASSWORD;
			$loginFormDataSOHU['m'] = 'doLogin';
			$loginFormDataSOHU['f_r'] = '';
	
			$ztFormUrlSOHU = 'http://3g.t.sohu.com/fridoc.do?tid=143bZWdG-xpVib29rQHNvaHUuY29tOj_2g8935a9b7&suv=9039725506670';
			$ztSubmitUrlSOHU = 'http://3g.t.sohu.com/send.do?tid=143bZWdG-xpVib29rQHNvaHUuY29tOj_2g8935a9b7&suv=9039725506670';
			$ztFormDataSOHU['content'] = $uMsg;
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
						
			
			$postdataFE['content'] = $uMsg;
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
			$postdata163['status'] = $uMsg;
			$postdata163['sub'] = '发布';
							
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
		
		echo $t.$uKXResult.$uWBResult.$uQQResult.$uSHResult.$u163Result.$uFEResult."<br/>";

?>  
