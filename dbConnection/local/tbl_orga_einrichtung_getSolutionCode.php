<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$en = $_POST['einrichtung'];
	
	$query = "SELECT CAST(AES_DECRYPT(solution,'tud55coz') AS CHAR (255)) as strReturn FROM tbl_orga_einrichtung WHERE id = '$en'";

	$sqlStmt = mysqli_query($connection, $query);

	$numrows=mysqli_num_rows($sqlStmt);
	  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{            
           $row=mysqli_fetch_assoc($sqlStmt);
		   
            $solutionCode=$row['strReturn'];  
		}
		
		echo $solutionCode;
	}	
	
mysqli_close($connection);
?>