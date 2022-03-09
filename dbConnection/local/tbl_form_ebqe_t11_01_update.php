<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t11field01 = $_POST['t11field01'];
	$t11field01a = $_POST['t11field01a'];
	$t11field02_01 = $_POST['t11field02_01'];
	$t11field02_02 = $_POST['t11field02_02'];
	$t11field02_03 = $_POST['t11field02_03'];
	$t11field02_04 = $_POST['t11field02_04'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t11 SET t11field01= '$t11field01', t11field01a= '$t11field01a', t11field02_01 = '$t11field02_01', t11field02_02 = '$t11field02_02', t11field02_03 = '$t11field02_03', t11field02_03 = '$t11field02_03', t11field02_04 = '$t11field02_04' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
			$row=mysqli_fetch_assoc($sqlStmt);  
		
			$schmerz01 =$row['t11field01']; 
			$schmerz01a =$row['t11field01a'];	  
			$schmerz02_01 = $row['t11field02_01'];
			$schmerz02_02 =$row['t11field02_02'];  
			$schmerz02_03 = $row['t11field02_03'];
			$schmerz02_04 =$row['t11field02_04'];  
		}
	  echo $schmerz01.':' .$schmerz01a.':'.$schmerz02_01.':' .$schmerz02_02.':' .$schmerz02_03.':' .$schmerz02_04.':';
		
	}
mysqli_close($connection);
?>