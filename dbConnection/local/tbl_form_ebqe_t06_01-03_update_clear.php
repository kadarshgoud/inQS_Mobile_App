<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t06 SET t06field01= '', t06field02 = '', t06field03= '', t06field04 = '', t06field05= '', t06field06 = '' 
	WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
mysqli_close($connection);
?>