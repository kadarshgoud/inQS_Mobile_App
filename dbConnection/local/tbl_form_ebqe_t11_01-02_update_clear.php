<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	
	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t11 SET t11field01= '', t11field01a= '', t11field02_01 = '', t11field02_02 = '', t11field02_03 = '', t11field02_03 = '', t11field02_04 = '', t11field02_05= '', t11field02_06 = '', t11field03_01 = '', t11field03_02 = '', t11field04 = '' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
mysqli_close($connection);
?>