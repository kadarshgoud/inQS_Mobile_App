<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}


	$en = $_POST['einrichtung'];
	$wo = $_POST['wohnbereich'];
	$bid = $_POST['bewonerid']; 
	
	$query = "SELECT DatumHeimeinzuges, Geburtsmonat, Geburtsjahr, Geschlecht FROM tbl_pers_bewohner WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo'&& id= '$bid'";

$sqlStmt = mysqli_query($connection, $query);
	$numrows=mysqli_num_rows($sqlStmt); 
	  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
            
           $row=mysqli_fetch_assoc($sqlStmt);
		   
            $DatumHeimeinzuges=$row['DatumHeimeinzuges'];  
			$Geburtsmonat =$row['Geburtsmonat'];  
			$Geburtsjahr =$row['Geburtsjahr'];  
			$Geschlecht =$row['Geschlecht'];  
		}
	echo $DatumHeimeinzuges.':'.$Geburtsmonat.':'.$Geburtsjahr.':'.$Geschlecht.':';
	}	
mysqli_close($connection);
?>