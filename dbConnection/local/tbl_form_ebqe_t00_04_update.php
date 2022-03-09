<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
		$t00field09 = $_POST['t00field09'];
		$t00field10 = $_POST['t00field10'];
		$t00field11 = $_POST['t00field11'];
		$t00field12 = $_POST['t00field12'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t00 SET t00field09 = '$t00field09', t00field10 = '$t00field10', t00field11 = '$t00field11',
	t00field12 = '$t00field12' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
		$row=mysqli_fetch_assoc($sqlStmt);
		  $field09 =$row['t00field09']; 
         $field10 =$row['t00field10'];  
	     $field11 =$row['t00field11'];  
		 $field12 =$row['t00field12'];    
	}
	echo $field09.':' .$field10.':' .$field11.':' .$field12.':';
	}

mysqli_close($connection);
?>