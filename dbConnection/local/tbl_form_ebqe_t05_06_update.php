<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}
	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t05field16_01 = $_POST['t05field16_01'];
	$t05field16_02 = $_POST['t05field16_02'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t05 SET t05field16_01= '$t05field16_01', t05field16_02 = '$t05field16_02' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
            
           $row=mysqli_fetch_assoc($sqlStmt);
		    
			$bewalt16_01 =$row['t05field16_01'];  
	  $bewalt16_02 = $row['t05field16_02'];
		}
	  echo $bewalt16_01.':' .$bewalt16_02.':';
	
	}

mysqli_close($connection);
?>