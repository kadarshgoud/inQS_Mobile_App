<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}
	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	
	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t00 SET t00field01= '', t00field02_1 = '', t00field02_2 = '', t00field03 = '' , t00field04 = '', t00field05 = '', 
	t00field06 = '', t00field07_01= '', t00field07_02 = '',t00field07_03 = '', t00field07_04 = '', t00field07_05 = '', t00field07_06 = '', t00field08 = '', 
	t00field08_01= '', t00field08_02 = '', t00field08_03 = '', t00field08_04 = '', t00field08_05 = '', t00field09 = '', t00field10 = '', t00field11 = '',
	t00field12 = '', t00field13_1 = '', t00field13_2= '', t00field13_3 = '', t00field13_4 = '', 
	t00field13_5 = '', t00field13_6 = '', t00field13_7 = '',
	t00field13_7_1 = '', t00field13_8 = '', t00field13_9 = '',
	t00field13_10 = '', t00field13_11 = '', t00field13_11_1 = '', t00field13_11_2 = '' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 

mysqli_close($connection);
?>