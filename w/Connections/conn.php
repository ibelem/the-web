<?php
# Type="MYSQL"
# HTTP="true"
$hostname_belemview = "localhost";
$database_belemview = "";
$username_belemview = "";
$password_belemview = "";

$mysqlconn_belemview_q = mysql_pconnect($hostname_belemview, $username_belemview, $password_belemview) or trigger_error(mysql_error(),E_USER_ERROR); 
$mysqlconn_belemview_t=mysql_connect("$hostname_belemview","$username_belemview",$password_belemview) or trigger_error(mysql_error(),E_USER_ERROR); 
?>
 
 
