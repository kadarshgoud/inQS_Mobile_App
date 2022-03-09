<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

$username = $_POST['username'];
	
$query = "SELECT id_orga_Einrichtung, id_orga_wohnbereich, id_orga_benutzer_gruppe, id FROM tbl_orga_benutzer WHERE Anmeldename = '$username' && is_locked != 1 && is_delete != 1";
	
$sqlStmt = mysqli_query($connection, $query);

$numrows=mysqli_num_rows($sqlStmt); 
	
if($numrows > 0)  
{  
    for($i = 0; $i< $numrows ; $i++)
	{
		$row=mysqli_fetch_assoc($sqlStmt);  
		$einrichtung =$row['id_orga_Einrichtung'];  
		$wohnbereich = $row['id_orga_wohnbereich'];
		$role = $row['id_orga_benutzer_gruppe'];
		$id_benutzer = $row['id'];
		echo $einrichtung.':'.$wohnbereich.':'.$role.':'.$id_benutzer;		
	}
}

mysqli_close($connection);
?>