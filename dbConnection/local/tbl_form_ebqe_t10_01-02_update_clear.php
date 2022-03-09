<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t10 SET t10field01= '', t10field02_01 = '', t10field02_02 = '', t10field02_03 = '', 
	t10field02_04 = '', t10field03 = '', t10field04 = '', t10field05= '', t10field06 = '', t10field07 = '' 
	WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	

mysqli_close($connection);
?>