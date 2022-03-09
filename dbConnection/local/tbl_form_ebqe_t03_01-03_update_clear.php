<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	
	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t03 SET t03field01= '', t03field02 = '', t03field03 = '', t03field04 = '', t03field05 = '', 
	t03field06= '', t03field07 = '', t03field08 = '', t03field09 = '', t03field10 = '', t03field11= '', t03field12 = '', t03field13 = '' 
	WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	$numrows=mysqli_num_rows($sqlStmt); 
 
mysqli_close($connection);
?>