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
	
	$query = "SELECT tkurzfield01, tkurzfield02, tkurzfield03, tkurzfield04 ,tkurzfield05, tkurzfield06, tkurzfield07, tkurzfield08, tkurzfield09 FROM tbl_form_ebqe_kurz WHERE id_orga_Einrichtung = '$en' && id_orga_Wohnbereich = '$wo'&& id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

	$sqlStmt = mysqli_query($connection, $query);

	$numrows=mysqli_num_rows($sqlStmt); 
	 
    if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{            
			$row=mysqli_fetch_assoc($sqlStmt);
		   
            $tkurzfield01 = $row['tkurzfield01']; 
			$tkurzfield02 = $row['tkurzfield02']; 
			$tkurzfield03 = $row['tkurzfield03']; 
			$tkurzfield04 = $row['tkurzfield04']; 
			$tkurzfield05 = $row['tkurzfield05'];  
			$tkurzfield06 = $row['tkurzfield06']; 
			$tkurzfield07 = $row['tkurzfield07']; 
			$tkurzfield08 = $row['tkurzfield08']; 
			$tkurzfield09 = $row['tkurzfield09'];	  
		}
			echo $tkurzfield01.':'.$tkurzfield02.':'.$tkurzfield03.':'.$tkurzfield04.':'.$tkurzfield05.':'.$tkurzfield06.':'.$tkurzfield07.':' .$tkurzfield08.':'.$tkurzfield09;
	}	
	
mysqli_close($connection);
?>