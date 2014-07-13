<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
<meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
<title>HTTP Headers</title>
    <style type="text/css">
    body {
        margin:20px auto;
        text-align:left;
        font-size:1em;
        font-family:verdana;
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
    </style>
</head>

<body>
<h3>浏览器页面请求头部信息</h3><a href="ua.htm" title="常用 UA">常用 UA</a><p/>

<div class="r">
<span style="color: red"><script type="text/javascript">document.write("platform: " + navigator.platform + " Name:" + navigator.appName);</script></span><br/><br/>
<?php

	if (!function_exists('getallheaders')) 
	 {
		 function getallheaders() 
		 {
			foreach ($_SERVER as $name => $value) 
			{
				if (substr($name, 0, 5) == 'HTTP_') 
				{
					$headers[str_replace(' ', '-', ucwords(strtolower(str_replace('_', ' ', substr($name, 5)))))] = $value;
				}
			}
			return $headers;
		 }
	 }
 
 
    $headers = getallheaders();
    
    $g = "<div class='it'>Main Info:</div><br/>";
	foreach ($headers as $header => $v) { 
		$g = $g."$header: $v<br/>"; 
	}
	
	$g = $g."<br/><div class='it'>Other Info:</div><br/>";

/*
	$g = $g."HTTP_UA_OS: ".$_SERVER["HTTP_UA_OS"]."<br/>"; 
	$g = $g."HTTP_UA_CPU: ".$_SERVER["HTTP_UA_CPU"]."<br/>"; 
	$g = $g."HTTP_UA_COLOR: ".$_SERVER["HTTP_UA_COLOR"]."<br/>"; 
	$g = $g."HTTP_UA_PIXELS: ".$_SERVER["HTTP_UA_PIXELS"]."<br/>"; 
	$g = $g."HTTP_UA_VOICE: ".$_SERVER["HTTP_UA_VOICE"]."<br/>"; 
*/					

	$g = $g."URL: ".$_SERVER ['HTTP_HOST'].$_SERVER['PHP_SELF']."<br/>"; 
	
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
//	$g = $g."HTTP_ACCEPT: ".$_SERVER['HTTP_ACCEPT']."<br/>"; 
//	$g = $g."HTTP_ACCEPT_CHARSET: ".$_SERVER['HTTP_ACCEPT_CHARSET']."<br/>"; 
//	$g = $g."HTTP_ACCEPT_ENCODING: ".$_SERVER['HTTP_ACCEPT_ENCODING']."<br/>"; 
//	$g = $g."HTTP_ACCEPT_LANGUAGE: ".$_SERVER['HTTP_ACCEPT_LANGUAGE']."<br/>"; 
//	$g = $g."HTTP_CONNECTION: ".$_SERVER['HTTP_CONNECTION']."<br/>"; 
//	$g = $g."HTTP_USER_AGENT: ".$_SERVER['HTTP_USER_AGENT']."<br/>"; 
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

	
/*
	$_SERVER['PHP_SELF'] #当前正在执行脚本的文件名，与 document root相关。
	$_SERVER['argv'] #传递给该脚本的参数。
	$_SERVER['argc'] #包含传递给程序的命令行参数的个数（如果运行在命令行模式）。
	$_SERVER['GATEWAY_INTERFACE'] #服务器使用的 CGI 规范的版本。例如，“CGI/1.1”。
	$_SERVER['SERVER_NAME'] #当前运行脚本所在服务器主机的名称。
	$_SERVER['SERVER_SOFTWARE'] #服务器标识的字串，在响应请求时的头部中给出。
	$_SERVER['SERVER_PROTOCOL'] #请求页面时通信协议的名称和版本。例如，“HTTP/1.0”。
	$_SERVER['REQUEST_METHOD'] #访问页面时的请求方法。例如：“GET”、“HEAD”，“POST”，“PUT”。
	$_SERVER['QUERY_STRING'] #查询(query)的字符串。
	$_SERVER['QUERY_STRING'] #当前运行脚本所在的文档根目录。在服务器配置文件中定义。
	$_SERVER['HTTP_ACCEPT'] #当前请求的 Accept: 头部的内容。
	$_SERVER['HTTP_ACCEPT_CHARSET'] #当前请求的 Accept-Charset: 头部的内容。例如：“iso-8859-1,*,utf-8”。
	$_SERVER['HTTP_ACCEPT_ENCODING'] #当前请求的 Accept-Encoding: 头部的内容。例如：“gzip”。
	$_SERVER['HTTP_ACCEPT_LANGUAGE']#当前请求的 Accept-Language: 头部的内容。例如：“en”。
	$_SERVER['HTTP_CONNECTION'] #当前请求的 Connection: 头部的内容。例如：“Keep-Alive”。
	$_SERVER['HTTP_HOST'] #当前请求的 Host: 头部的内容。
	$_SERVER['HTTP_REFERER'] #链接到当前页面的前一页面的 URL 地址。
	$_SERVER['HTTP_USER_AGENT'] #当前请求的 User_Agent: 头部的内容。
	$_SERVER['HTTPS'] — 如果通过https访问,则被设为一个非空的值(on)，否则返回off
	$_SERVER['REMOTE_ADDR'] #正在浏览当前页面用户的 IP 地址。
	$_SERVER['REMOTE_HOST'] #正在浏览当前页面用户的主机名。
	$_SERVER['REMOTE_PORT'] #用户连接到服务器时所使用的端口。
	$_SERVER['SCRIPT_FILENAME'] #当前执行脚本的绝对路径名。
	$_SERVER['SERVER_ADMIN'] #管理员信息
	$_SERVER['SERVER_PORT'] #服务器所使用的端口
	$_SERVER['SERVER_SIGNATURE'] #包含服务器版本和虚拟主机名的字符串。
	$_SERVER['PATH_TRANSLATED'] #当前脚本所在文件系统（不是文档根目录）的基本路径。
	$_SERVER['SCRIPT_NAME'] #包含当前脚本的路径。这在页面需要指向自己时非常有用。
	$_SERVER['REQUEST_URI'] #访问此页面所需的 URI。例如，“/index.html”。
	$_SERVER['PHP_AUTH_USER'] #当 PHP 运行在 Apache 模块方式下，并且正在使用 HTTP 认证功能，这个变量便是用户输入的用户名。
	$_SERVER['PHP_AUTH_PW'] #当 PHP 运行在 Apache 模块方式下，并且正在使用 HTTP 认证功能，这个变量便是用户输入的密码。
	$_SERVER['AUTH_TYPE'] #当 PHP 运行在 Apache 模块方式下，并且正在使用 HTTP 认证功能，这个变量便是认证的类型。
	$_SERVER['HTTP_X_FORWARDED_FOR'] #透过代理服务器取得客户端的真实 IP 地址
*/


    print_r($g);
    
    $filename="log.txt";
	 
	$handling = fopen($filename, 'a');
	
	$t = "";
	foreach ($headers as $header => $v) { 
		$t = $t."$header: $v\n";
	}
	
	$t = $t."URL: ".$_SERVER ['HTTP_HOST'].$_SERVER['PHP_SELF']."\n"; 
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


	fwrite($handling, "\n\r\n\r".date("D M j G:i:s T Y")."\n\r".$t);
	
	$filenameact="act.txt";
	 
	$handlingact = fopen($filenameact, 'a');
	
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
	
	fwrite($handlingact, "\n\r\n\r".date("D M j G:i:s T Y")."\n\r".$tact);

?>
 

</div>
<p/><div class="f">&copy;2012 Internal. <a href="log.txt" title="查看 log">HTTP log</a> <a href="act.txt" title="ACT log">ACT log</a></div>
</body>

</html>
