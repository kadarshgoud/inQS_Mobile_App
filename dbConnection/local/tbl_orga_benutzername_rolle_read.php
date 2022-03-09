<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}


	$en = $_POST['einrichtung'];
	$wo = $_POST['wohnbereich'];
	$idBew = $_POST['idBew'];
	
	$query = "SELECT username, id_orga_benutzer_gruppe FROM tbl_mobile_user WHERE id_orga_Einrichtung = '$en' && id_orga_wohnbereich = '$wo' && id_benutzer = '$idBew'";

$sqlStmt = mysqli_query($connection, $query);
	
	
	$numrows=mysqli_num_rows($sqlStmt); 

if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $anmeldename =$row['username'];  
	  $gruppe = $row['id_orga_benutzer_gruppe'];
       
		}
	  echo $anmeldename.':' .$gruppe;
		
	}
		
mysqli_close($connection);
?>