<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}
	$query = "SELECT MAX(`id`) AS maxId from tbl_form_ebqe";

	$sqlStmt = mysqli_query($connection, $query);

	$numrows=mysqli_num_rows($sqlStmt); 
	  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
           $row=mysqli_fetch_assoc($sqlStmt);
		   
            $result=$row['maxId'];
		}

	echo $result;	
	}
	
mysqli_close($connection);

?>