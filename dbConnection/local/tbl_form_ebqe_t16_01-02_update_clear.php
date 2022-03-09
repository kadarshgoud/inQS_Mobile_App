<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t16 SET t16field01= '', t16field02 = '', t16field03 = '', t16field04 = '', t16field05 = '', 
	t16field06 = '', t16field07 = '', t16field08 = '', t16field09 = '', t16field10= '', t16field11 = '' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
mysqli_close($connection);
?>