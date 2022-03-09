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
	
	$query = "SELECT * FROM  tbl_pers_bewohner JOIN tbl_form_ebqe ON tbl_pers_bewohner.id = tbl_form_ebqe.id_pers_Bewohner WHERE tbl_pers_bewohner.id_orga_Einrichtung = '$en' && tbl_pers_bewohner.id_orga_Wohnbereich = '$wo'&& tbl_form_ebqe.id_mstr_ebqe = '$wn' && tbl_pers_bewohner.is_delete = 0 && tbl_form_ebqe.ende = 1";
	
	$sqlStmt = mysqli_query($connection, $query);	
	
	$numrows=mysqli_num_rows($sqlStmt); 	
	
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
		  $row=mysqli_fetch_assoc($sqlStmt);  
	  
		  $name=$row['Bewohnercode'];  
		  $id = $row['id_pers_Bewohner'];
		  $idOrgEin = $row['id_orga_Einrichtung'];
		  $idOrgWohn=$row['id_orga_Wohnbereich'];
		  $bogenart=$row['bogenart'];
		  $geburtsmonat=$row['Geburtsmonat'];
		  $geburtsjahr=$row['Geburtsjahr'];
		  $datumHeimeinzug=$row['DatumHeimeinzuges'];
		  $geschlecht=$row['Geschlecht'];

		  echo $id.':'.$name.':'.$idOrgEin.':'.$idOrgWohn.':'.$bogenart.':'.$geburtsmonat.':'.$geburtsjahr.':'.$datumHeimeinzug.':'.$geschlecht.'|';
		}
	}
	
mysqli_close($connection);

?>