<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}
	
$query = "SELECT app_version FROM tbl_mobile_config";
	
$sqlStmt = mysqli_query($connection, $query);

$numrows=mysqli_num_rows($sqlStmt); 
	
if($numrows > 0)  
{  
    for($i = 0; $i< $numrows ; $i++)
	{
		$row=mysqli_fetch_assoc($sqlStmt);  
		$appv =$row['app_version'];  
		echo $appv;	
	}
}

mysqli_close($connection);
?>