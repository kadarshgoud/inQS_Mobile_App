<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}
		$master = $_POST['mstr'];
		$bid = $_POST['bewonerid'];
		$t01field03 = $_POST['t01field03'];
		$t01field04 = $_POST['t01field04'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t01 SET t01field03 = '$t01field03', t01field04= '$t01field04' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
		$row=mysqli_fetch_assoc($sqlStmt);
		  $mob03 =$row['t01field03'];  
		  $mob04 =$row['t01field04'];  
		}
	echo $mob03.':' .$mob04.':';
	}

mysqli_close($connection);
?>