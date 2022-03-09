<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
		$t00field13_1 = $_POST['t00field13_1'];
		$t00field13_2 = $_POST['t00field13_2'];
		$t00field13_3 = $_POST['t00field13_3'];
		$t00field13_4 = $_POST['t00field13_4'];
		$t00field13_5 = $_POST['t00field13_5'];
		$t00field13_6 = $_POST['t00field13_6'];
		$t00field13_7 = $_POST['t00field13_7'];
		$t00field13_7_1 = $_POST['t00field13_7_1'];
		$t00field13_8 = $_POST['t00field13_8'];
		$t00field13_9 = $_POST['t00field13_9'];
		$t00field13_10 = $_POST['t00field13_10'];
		$t00field13_11 = $_POST['t00field13_11'];
		$t00field13_11_1 = $_POST['t00field13_11_1'];
		$t00field13_11_2 = $_POST['t00field13_11_2'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t00 SET t00field13_1 = '$t00field13_1', t00field13_2= '$t00field13_2', t00field13_3 = '$t00field13_3', t00field13_4 = '$t00field13_4', 
	t00field13_5 = '$t00field13_5', t00field13_6 = '$t00field13_6', t00field13_7 = '$t00field13_7',
	t00field13_7_1 = '$t00field13_7_1', t00field13_8 = '$t00field13_8', t00field13_9 = '$t00field13_9',
	t00field13_10 = '$t00field13_10', t00field13_11 = '$t00field13_11', t00field13_11_1 = '$t00field13_11_1', t00field13_11_2 = '$t00field13_11_2' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
			$row=mysqli_fetch_assoc($sqlStmt);
			$field13_1 =$row['t00field13_1']; 
			$field13_2 =$row['t00field13_2'];  
			$field13_3 =$row['t00field13_3']; 
			$field13_4 =$row['t00field13_4'];  
			$field13_5 =$row['t00field13_5'];
			$field13_6 =$row['t00field13_6'];
			$field13_7 =$row['t00field13_7'];
			$field13_7_1 =$row['t00field13_7_1'];
			$field13_8 =$row['t00field13_8']; 
			$field13_9 =$row['t00field13_9'];
			$field13_10 =$row['t00field13_10'];
			$field13_11 =$row['t00field13_11'];	
			$field13_11_1 =$row['t00field13_11_1'];		 
			$field13_11_2 =$row['t00field13_11_2'];
		}
		
		echo $field13_1.':' .$field13_2.':' .$field13_3.':' .$field13_4.':' .$field13_5.':' .$field13_6.':' .$field13_7.':' .$field13_7_1.':' .$field13_8.':' .$field13_9.':' .$field13_10.':' .$field13_11.':'.$field13_11_1.':'.$field13_11_2;
	}

mysqli_close($connection);
?>