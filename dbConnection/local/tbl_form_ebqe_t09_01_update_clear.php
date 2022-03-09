<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t09 SET t09field01= '', t09field02_01 = '', t09field02_02 = '', t09field02_03 = '', 
	t09field02_04 = '', t09field02_05 = '', t09field02_06 = '' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	

mysqli_close($connection);
?>