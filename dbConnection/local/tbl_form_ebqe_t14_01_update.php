<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t14field01 = $_POST['t14field01'];
	$t14field02 = $_POST['t14field02'];
	$t14field03 = $_POST['t14field03'];
	
	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t14 SET t14field01= '$t14field01', t14field02= '$t14field02', t14field03= '$t14field03' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $medik01 =$row['t14field01'];
		$medik02 =$row['t14field02'];
	$medik03 =$row['t14field03'];	  
		}
	  echo $medik01.':' .$medik02.':' .$medik03.':';

	}
mysqli_close($connection);
?>