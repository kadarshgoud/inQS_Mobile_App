<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}
		$master = $_POST['mstr'];
		$bid = $_POST['bewonerid'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t01 SET t01field01 = '', t01field02= '', t01field03 = '', t01field04= '', t01field05 = '', t01field06= '' 
	WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'");  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
mysqli_close($connection);
?>