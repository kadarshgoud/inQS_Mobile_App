<?php

$connection = mysqli_connect("localhost", "root", "123456", "inqsdatabase");
if (mysqli_connect_errno()) 
{
    echo mysql_errno($connection) . ": " . mysql_error($connection). "\n";
    die();
}
	$en = $_POST['einrichtung'];
	$idBew = $_POST['idBew'];
	
	$query = "SELECT Bezeichnung FROM tbl_orga_wohnbereich WHERE id_orga_Einrichtung = '$en' && id = '$idBew'";

$sqlStmt = mysqli_query($connection, $query);
	
	$numrows=mysqli_num_rows($sqlStmt); 

if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $Bezeichnung =$row['Bezeichnung'];  
		}
	  echo $Bezeichnung;
		
	}
		
mysqli_close($connection);
?>