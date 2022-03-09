<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];

	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t04 SET t04fields2= '', t04fields3= '', t04field01= '', t04field02 = '', t04field03 = '', 
	t04field04 = '', t04field05 = '', t04field06= '', t04field07 = '', t04field08 = '', t04field09 = '', t04field10 = '', t04field11= '', t04field12 = '', 
	t04field13 = '' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);

mysqli_close($connection);
?>