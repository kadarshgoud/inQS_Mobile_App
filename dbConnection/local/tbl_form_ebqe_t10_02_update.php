<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t10field05 = $_POST['t10field05'];
	$t10field06 = $_POST['t10field06'];
	$t10field07 = $_POST['t10field07'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t10 SET t10field05= '$t10field05', t10field06 = '$t10field06', t10field07 = '$t10field07' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
			$row=mysqli_fetch_assoc($sqlStmt);
   
		 $freih05 =$row['t10field05'];  
	   $freih06 = $row['t10field06'];
	   $freih07 =$row['t10field07'];  
		}
	  echo   $freih05.':' .$freih06.':' .$freih07.':';
	}

mysqli_close($connection);
?>