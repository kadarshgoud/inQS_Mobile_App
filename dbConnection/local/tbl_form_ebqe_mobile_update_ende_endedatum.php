<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}	
	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$ende = $_POST['ende'];
	$endedatum = $_POST['endedatum'];	
	
	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_mobile SET ende= '1', endedatum = '$endedatum' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt);
	  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
            
           $row=mysqli_fetch_assoc($sqlStmt);
		  
	     $ende =$row['ende'];  
		 $endedatum =$row['endedatum'];  
		
		}
		
		echo $ende.':'.$endedatum;
	}

mysqli_close($connection);
?>