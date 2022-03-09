<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t03field01 = $_POST['t03field01'];
	$t03field02 = $_POST['t03field02'];
	$t03field03 = $_POST['t03field03'];
	$t03field04 = $_POST['t03field04'];
	$t03field05 = $_POST['t03field05'];
	

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t03 SET t03field01= '$t03field01', t03field02 = '$t03field02', t03field03 = '$t03field03', t03field04 = '$t03field04', t03field05 = '$t03field05' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
			$row=mysqli_fetch_assoc($sqlStmt);
		   $verhalt01 =$row['t03field01'];  
		   $verhalt02 =$row['t03field02'];  
		   $verhalt03 =$row['t03field03'];  
		   $verhalt04 =$row['t03field04'];  
		   $verhalt05 =$row['t03field05'];  

		}
	echo $verhalt01.':' .$verhalt02.':' .$verhalt03.':' .$verhalt04.':' .$verhalt05.':';
	}

mysqli_close($connection);
?>