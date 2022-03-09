<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	
	

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t08 SET t08field01= '', t08field02_01 = '', t08field02_02 = '', t08field03_01 = '', t08field03_02 = '', 
	t08field03_03 = '', t08field03_04 = '', t08field03_05 = '', t08field03_06 = '', t08field04 = '' 
	WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);

mysqli_close($connection);
?>