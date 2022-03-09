<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}
	$en = $_POST['einrichtung'];
	$wo = $_POST['wohnbereich'];
	$wn = $_POST['id'];
	$bid = $_POST['bewonerid'];
	$bogenart = $_POST['bogenart'];
	$maxId = $_POST['maxId'];

	$query = "INSERT INTO tbl_form_ebqe_mobile (id, id_orga_einrichtung, id_orga_wohnbereich, id_mstr_ebqe, id_pers_Bewohner, bogenart, id_form_ebqe) 
	VALUES ('".$maxId."','".$en."','".$wo."','".$wn."','".$bid."','".$bogenart."','".$maxId."');";
	
	$sqlStmt = mysqli_query($connection, $query);
	
mysqli_close($connection);

?>