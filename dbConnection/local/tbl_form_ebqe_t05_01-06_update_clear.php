<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	
	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_t05 SET t05field01_03= '', t05field01_02 = '', t05field02_03 = '', t05field02_02 = '', t05field03_03 = '', 
	t05field03_02 = '', t05field04_03= '', t05field04_02 = '', t05field05_03 = '', t05field05_02 = '', t05field06_03 = '', t05field06_02 = '', t05field07_03= '', t05field07_02 = '', 
	t05field08_03 = '', t05field08_02 = '', t05field09_03 = '', t05field09_02 = '', t05field10_03= '', t05field10_02 = '', t05field11_03 = '', t05field11_02 = '', t05field12_03 = '', 
	t05field12_02 = '', t05field13_03= '', t05field13_02 = '', t05field14_03 = '', t05field14_02 = '', t05field15_03 = '', t05field15_02 = '', t05field16_01= '', t05field16_02 = '' 
	WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);

mysqli_close($connection);
?>