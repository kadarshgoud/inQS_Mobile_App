<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t00field07_01 = $_POST['t00field07_01'];
	$t00field07_02 = $_POST['t00field07_02'];
	$t00field07_03 = $_POST['t00field07_03'];
	$t00field07_04 = $_POST['t00field07_04'];
	$t00field07_05 = $_POST['t00field07_05'];
	$t00field07_06 = $_POST['t00field07_06'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t00 SET t00field07_01= '$t00field07_01', t00field07_02 = '$t00field07_02', t00field07_03 = '$t00field07_03', 
	t00field07_04 = '$t00field07_04', t00field07_05 = '$t00field07_05', t00field07_06 = '$t00field07_06' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
            
           $row=mysqli_fetch_assoc($sqlStmt);
		   
         $field07_01=$row['t00field07_01'];  
	     $field07_02 =$row['t00field07_02'];  
		 $field07_03 =$row['t00field07_03'];  
		 $field07_04 =$row['t00field07_04'];  
		 $field07_05 =$row['t00field07_05'];  
		 $field07_06 =$row['t00field07_06'];  
		}
	echo $field07_01.':' .$field07_02.':' .$field07_03.':' .$field07_04.':' .$field07_05.':' .$field07_06.':';
	}

mysqli_close($connection);
?>