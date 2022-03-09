<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}

	$en = $_POST['einrichtung'];
	$wo = $_POST['wohnbereich'];
	$solution = $_POST['solution'];
	
	$query = "SELECT id, Vorname, CAST(AES_DECRYPT(Nachname,'$solution') AS CHAR (255)) as Nachname FROM tbl_pers_bewohner WHERE id_orga_Einrichtung = '$en' && id_orga_Wohnbereich = '$wo' && is_delete != 1";

	$sqlStmt = mysqli_query($connection, $query);

	$numrows=mysqli_num_rows($sqlStmt);
	  
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{            
           $row=mysqli_fetch_assoc($sqlStmt);
		   
            $id=$row['id'];  
			$Vorname =$row['Vorname'];  
			$Nachname =$row['Nachname'];   
			
			echo $id.':'.$Vorname.':'.$Nachname.'|';
		}
	}	
	
mysqli_close($connection);
?>