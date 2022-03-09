<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
		$t00field08 = $_POST['t00field08'];
		$t00field08_01 = $_POST['t00field08_01'];
		$t00field08_02 = $_POST['t00field08_02'];
		$t00field08_03 = $_POST['t00field08_03'];
		$t00field08_04 = $_POST['t00field08_04'];
		$t00field08_05 = $_POST['t00field08_05'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t00 SET t00field08 = '$t00field08', t00field08_01= '$t00field08_01', t00field08_02 = '$t00field08_02', t00field08_03 = '$t00field08_03', t00field08_04 = '$t00field08_04', t00field08_05 = '$t00field08_05' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
		$row=mysqli_fetch_assoc($sqlStmt);
		  $field08 =$row['t00field08']; 
         $field08_01=$row['t00field08_01'];  
	     $field08_02 =$row['t00field08_02'];  
		 $field08_03 =$row['t00field08_03'];  
		 $field08_04 =$row['t00field08_04'];  
		 $field08_05 =$row['t00field08_05'];  
		}
	echo $field08.':'.$field08_01.':'.$field08_02.':'.$field08_03.':'.$field08_04.':'.$field08_05;
	}

mysqli_close($connection);
?>