<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}
	
	$master = $_POST['mstr'];
	$bid = $_POST['bewonerid'];
	$tkurzfield01 = $_POST['tkurzfield01'];
	$tkurzfield02 = $_POST['tkurzfield02'];
	$tkurzfield03 = $_POST['tkurzfield03'];
	$tkurzfield04 = $_POST['tkurzfield04'];
	$tkurzfield05 = $_POST['tkurzfield05'];
	$tkurzfield06 = $_POST['tkurzfield06'];
	$tkurzfield07 = $_POST['tkurzfield07'];
	$tkurzfield08 = $_POST['tkurzfield08'];
	$tkurzfield09 = $_POST['tkurzfield09'];	
	
	$query1 = mysqli_query($connection,"UPDATE tbl_form_ebqe_kurz SET tkurzfield01= '$tkurzfield01', tkurzfield02 = '$tkurzfield02', tkurzfield03 = '$tkurzfield03', 
	tkurzfield04 = '$tkurzfield04' , tkurzfield05 = '$tkurzfield05', tkurzfield06 = '$tkurzfield06', tkurzfield07 = '$tkurzfield07', tkurzfield08 = '$tkurzfield08', tkurzfield09 = '$tkurzfield09' WHERE id_pers_Bewohner = '$bid' && id_mstr_ebqe = '$master'" );  
	
	$sqlStmt = mysqli_query($connection,$query1);	

mysqli_close($connection);
?>