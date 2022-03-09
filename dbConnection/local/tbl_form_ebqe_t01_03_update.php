<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}
		$master = $_POST['mstr'];
		$bid = $_POST['bewonerid'];
		$t01field05 = $_POST['t01field05'];
		$t01field06 = $_POST['t01field06'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t01 SET t01field05 = '$t01field05', t01field06= '$t01field06' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
		$row=mysqli_fetch_assoc($sqlStmt);
		  $mob05 =$row['t01field05'];  
		  $mob06 =$row['t01field06'];  
		}
	echo $mob05.':' .$mob06.':';
	}

mysqli_close($connection);
?>