<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}
	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];	
	
	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_kurz SET tkurzfield05= '', tkurzfield06 = '', tkurzfield07 = '', tkurzfield08 = '' , tkurzfield09 = '' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);
	
	$numrows=mysqli_num_rows($sqlStmt); 

mysqli_close($connection);
?>