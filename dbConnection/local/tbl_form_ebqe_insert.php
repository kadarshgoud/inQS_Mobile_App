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

	$query = "INSERT INTO tbl_form_ebqe (id, id_orga_einrichtung, id_orga_wohnbereich, id_mstr_ebqe, id_pers_Bewohner, bogenart, id_form_ebqe) 
	VALUES ('".$maxId."','".$en."','".$wo."','".$wn."','".$bid."','".$bogenart."','".$maxId."');";
	
	$queryKurz = "INSERT INTO tbl_form_ebqe_kurz (id_orga_Einrichtung, id_orga_Wohnbereich, id_mstr_ebqe, id_pers_Bewohner, id_form_EBQE) 
	VALUES ('".$en."','".$wo."','".$wn."','".$bid."','".$maxId."');";
	
	$query00 = "INSERT INTO tbl_form_ebqe_t00 (id_orga_Einrichtung, id_orga_Wohnbereich, id_mstr_ebqe, id_pers_Bewohner, id_form_EBQE) 
	VALUES ('".$en."','".$wo."','".$wn."','".$bid."','".$maxId."');";
	$query01 = "INSERT INTO tbl_form_ebqe_t01 (id_orga_Einrichtung, id_orga_Wohnbereich, id_mstr_ebqe, id_pers_Bewohner, id_form_EBQE) 
	VALUES ('".$en."','".$wo."','".$wn."','".$bid."','".$maxId."');";
	$query02 = "INSERT INTO tbl_form_ebqe_t02 (id_orga_Einrichtung, id_orga_Wohnbereich, id_mstr_ebqe, id_pers_Bewohner, id_form_EBQE) 
	VALUES ('".$en."','".$wo."','".$wn."','".$bid."','".$maxId."');";
	$query03 = "INSERT INTO tbl_form_ebqe_t03 (id_orga_Einrichtung, id_orga_Wohnbereich, id_mstr_ebqe, id_pers_Bewohner, id_form_EBQE) 
	VALUES ('".$en."','".$wo."','".$wn."','".$bid."','".$maxId."');";
	$query04 = "INSERT INTO tbl_form_ebqe_t04 (id_orga_Einrichtung, id_orga_Wohnbereich, id_mstr_ebqe, id_pers_Bewohner, id_form_EBQE) 
	VALUES ('".$en."','".$wo."','".$wn."','".$bid."','".$maxId."');";
	$query05 = "INSERT INTO tbl_form_ebqe_t05 (id_orga_Einrichtung, id_orga_Wohnbereich, id_mstr_ebqe, id_pers_Bewohner, id_form_EBQE) 
	VALUES ('".$en."','".$wo."','".$wn."','".$bid."','".$maxId."');";
	$query06 = "INSERT INTO tbl_form_ebqe_t06 (id_orga_Einrichtung, id_orga_Wohnbereich, id_mstr_ebqe, id_pers_Bewohner, id_form_EBQE) 
	VALUES ('".$en."','".$wo."','".$wn."','".$bid."','".$maxId."');";
	$query07 = "INSERT INTO tbl_form_ebqe_t07 (id_orga_Einrichtung, id_orga_Wohnbereich, id_mstr_ebqe, id_pers_Bewohner, id_form_EBQE) 
	VALUES ('".$en."','".$wo."','".$wn."','".$bid."','".$maxId."');";
	$query08 = "INSERT INTO tbl_form_ebqe_t08 (id_orga_Einrichtung, id_orga_Wohnbereich, id_mstr_ebqe, id_pers_Bewohner, id_form_EBQE) 
	VALUES ('".$en."','".$wo."','".$wn."','".$bid."','".$maxId."');";
	$query09 = "INSERT INTO tbl_form_ebqe_t09 (id_orga_Einrichtung, id_orga_Wohnbereich, id_mstr_ebqe, id_pers_Bewohner, id_form_EBQE) 
	VALUES ('".$en."','".$wo."','".$wn."','".$bid."','".$maxId."');";
	$query10 = "INSERT INTO tbl_form_ebqe_t10 (id_orga_Einrichtung, id_orga_Wohnbereich, id_mstr_ebqe, id_pers_Bewohner, id_form_EBQE) 
	VALUES ('".$en."','".$wo."','".$wn."','".$bid."','".$maxId."');";
	$query11 = "INSERT INTO tbl_form_ebqe_t11 (id_orga_Einrichtung, id_orga_Wohnbereich, id_mstr_ebqe, id_pers_Bewohner, id_form_EBQE) 
	VALUES ('".$en."','".$wo."','".$wn."','".$bid."','".$maxId."');";
	$query12 = "INSERT INTO tbl_form_ebqe_t12 (id_orga_Einrichtung, id_orga_Wohnbereich, id_mstr_ebqe, id_pers_Bewohner, id_form_EBQE) 
	VALUES ('".$en."','".$wo."','".$wn."','".$bid."','".$maxId."');";
	$query13 = "INSERT INTO tbl_form_ebqe_t13 (id_orga_Einrichtung, id_orga_Wohnbereich, id_mstr_ebqe, id_pers_Bewohner, id_form_EBQE) 
	VALUES ('".$en."','".$wo."','".$wn."','".$bid."','".$maxId."');";
	$query14 = "INSERT INTO tbl_form_ebqe_t14 (id_orga_Einrichtung, id_orga_Wohnbereich, id_mstr_ebqe, id_pers_Bewohner, id_form_EBQE) 
	VALUES ('".$en."','".$wo."','".$wn."','".$bid."','".$maxId."');";
	$query15 = "INSERT INTO tbl_form_ebqe_t15 (id_orga_Einrichtung, id_orga_Wohnbereich, id_mstr_ebqe, id_pers_Bewohner, id_form_EBQE) 
	VALUES ('".$en."','".$wo."','".$wn."','".$bid."','".$maxId."');";
	$query16 = "INSERT INTO tbl_form_ebqe_t16 (id_orga_Einrichtung, id_orga_Wohnbereich, id_mstr_ebqe, id_pers_Bewohner, id_form_EBQE) 
	VALUES ('".$en."','".$wo."','".$wn."','".$bid."','".$maxId."');";
	

	$sqlStmt = mysqli_query($connection, $query);
	$sqlStmt00 = mysqli_query($connection, $query00); $sqlStmt01 = mysqli_query($connection, $query01); $sqlStmt02 = mysqli_query($connection, $query02);
	$sqlStmt03 = mysqli_query($connection, $query03); $sqlStmt04 = mysqli_query($connection, $query04); $sqlStmt05 = mysqli_query($connection, $query05);
	$sqlStmt06 = mysqli_query($connection, $query06); $sqlStmt07 = mysqli_query($connection, $query07); $sqlStmt08 = mysqli_query($connection, $query08);
	$sqlStmt09 = mysqli_query($connection, $query09); $sqlStmt10 = mysqli_query($connection, $query10); $sqlStmt11 = mysqli_query($connection, $query11);
	$sqlStmt12 = mysqli_query($connection, $query12); $sqlStmt13 = mysqli_query($connection, $query13); $sqlStmt14 = mysqli_query($connection, $query14);
	$sqlStmt15 = mysqli_query($connection, $query15); $sqlStmt16 = mysqli_query($connection, $query16);
	
mysqli_close($connection);

?>