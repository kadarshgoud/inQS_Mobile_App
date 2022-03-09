<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t02 SET t02field01= '', t02field02 = '', t02field03 = '', t02field04 = '', t02field05 = '',
	t02field06= '', t02field07 = '', t02field08 = '', t02field09 = '', t02field10= '', t02field11 = '' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
mysqli_close($connection);
?>