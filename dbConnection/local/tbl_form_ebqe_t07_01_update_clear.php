<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	
	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t07 SET t07field00= '', t07field01 = '', t07field02 = '', 
	t07field03_01 = '', t07field03_02 = '', t07field03_03 = '', t07field03_04 = '', t07field04 = '', t07field04_02 = '' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);

mysqli_close($connection);
?>