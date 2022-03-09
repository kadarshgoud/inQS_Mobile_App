<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$t07field00 = $_POST['t07field00'];
	$t07field01 = $_POST['t07field01'];
	$t07field02 = $_POST['t07field02'];
	$t07field03_01 = $_POST['t07field03_01'];
	$t07field03_02 = $_POST['t07field03_02'];
	$t07field03_03 = $_POST['t07field03_03'];
	$t07field03_04 = $_POST['t07field03_04'];
	$t07field04 = $_POST['t07field04'];
	$t07field04_02 = $_POST['t07field04_02'];
	

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t07 SET t07field00= '$t07field00', t07field01 = '$t07field01', t07field02 = '$t07field02', 
	t07field03_01 = '$t07field03_01', t07field03_02 = '$t07field03_02', t07field03_03 = '$t07field03_03', t07field03_04 = '$t07field03_04', t07field04 = '$t07field04', t07field04_02 = '$t07field04_02' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 
  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
			$row=mysqli_fetch_assoc($sqlStmt);
			$dekubitus00 =$row['t07field00'];  
			$dekubitus01 = $row['t07field01'];
			$dekubitus02 =$row['t07field02'];
			$dekubitus03_01 =$row['t07field03_01'];
			$dekubitus03_02 =$row['t07field03_02'];
			$dekubitus03_03 =$row['t07field03_03'];
			$dekubitus03_04 =$row['t07field03_04'];
			$dekubitus04 =$row['t07field04']; 
			$dekubitus04_02 =$row['t07field04_02'];	   
		}
	  echo  $dekubitus00.':' .$dekubitus01.':' .$dekubitus02.':' .$dekubitus03_01.':' .$dekubitus03_02.':' .$dekubitus03_03.':'.$dekubitus03_04.':' .$dekubitus04.':'.$dekubitus04_02;
	}

mysqli_close($connection);
?>