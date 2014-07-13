<?php

  //db connection detils
  $host = "localhost";
  $user = "belem_belemvi";
  $password = "179457zm";
  $database = "belem_belemviewsite";
	
  //make connection
  $server = mysql_connect($host, $user, $password);
  $connection = mysql_select_db($database, $server);
	
  //get POST data
  $name = mysql_real_escape_string($_POST["author"]);
  $comment = mysql_real_escape_string($_POST["comment"]);

  //add new comment to database
  
  if(!empty($name))
  {
  	mysql_query("INSERT INTO gardenpartner_comment VALUES(' $name ',' $comment ')");
  }

?>