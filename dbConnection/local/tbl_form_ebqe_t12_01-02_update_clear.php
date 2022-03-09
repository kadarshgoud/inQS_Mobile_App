<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t12 SET t12field00= '', t12field01_01 = '', t12field01_02 = '', t12field01_03 = '', t12field02_01 = '', 
	t12field02_02 = '', t12field02_03_01= '', t12field02_03_02 = '', t12field02_03_03 = '', t12field02_03_04 = '', t12field02_04 = '', t12field03 = '' 
	WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
mysqli_close($connection);
?>