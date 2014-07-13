<?php

	//db connection detils
	$host = "localhost";
  $user = "belem_belemvi";
  $password = "179457zm";
  $database = "belem_belemviewsite";
	
	//make connection
  $server = mysql_connect($host, $user, $password);
  $connection = mysql_select_db($database, $server);
	
	//query the database
  $query = mysql_query("SELECT name, comment FROM gardenpartner_comment ORDER BY name ASC ");
	
	//loop through and return results
  for ($x = 0, $numrows = mysql_num_rows($query); $x < $numrows; $x++) {
		$row = mysql_fetch_assoc($query);
    
		$comments[$x] = array("name" => $row["name"], "comment" => $row["comment"]);		
	}
	
	//echo JSON to page
	$response = $_GET["jsoncallback"] . "(" . json_encode($comments) . ")";
	echo $response;

?>