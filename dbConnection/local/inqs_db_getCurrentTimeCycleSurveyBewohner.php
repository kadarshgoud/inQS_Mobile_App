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
	
	$query = "SELECT * FROM  tbl_pers_bewohner WHERE id_orga_Einrichtung = '$en' && id_orga_Wohnbereich = '$wo'&& tbl_pers_bewohner.is_delete = 0";
	
	$sqlStmt = mysqli_query($connection, $query);
	
	$numrows=mysqli_num_rows($sqlStmt); 

    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
		  $row=mysqli_fetch_assoc($sqlStmt);  
	  
		  $name=$row['Bewohnercode'];  
		  $id = $row['id'];
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