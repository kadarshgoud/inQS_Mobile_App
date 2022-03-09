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
	$bid=$_POST['bewonerid']; 
	
	$query = "SELECT t11field01, t11field01a, t11field02_01, t11field02_02, t11field02_03, t11field02_04, t11field02_05, t11field02_06, t11field03_01, t11field03_02, t11field04 FROM tbl_form_ebqe_t11 WHERE id_orga_Einrichtung = '$en' && id_orga_Wohnbereich = '$wo'&& id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

	$sqlStmt = mysqli_query($connection, $query);
	
	$numrows=mysqli_num_rows($sqlStmt); 

	if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
			$row=mysqli_fetch_assoc($sqlStmt);  
			
			
			$schmerz01 =$row['t11field01'];
			$schmerz01a =$row['t11field01a'];  			
			$schmerz02_01 = $row['t11field02_01'];
			$schmerz02_02 =$row['t11field02_02'];  
			$schmerz02_03 = $row['t11field02_03'];
			$schmerz02_04 =$row['t11field02_04'];  
			$schmerz02_05 =$row['t11field02_05'];  
			$schmerz02_06 = $row['t11field02_06'];
			$schmerz03_01 =$row['t11field03_01'];  
			$schmerz03_02 = $row['t11field03_02'];
			$schmerz04 =$row['t11field04']; 
		}
		
	  echo $schmerz01.':'.$schmerz01a.':' .$schmerz02_01.':' .$schmerz02_02.':' .$schmerz02_03.':' .$schmerz02_04.':' .$schmerz02_05.':' .$schmerz02_06.':' .$schmerz03_01.':' .$schmerz03_02.':' .$schmerz04.':';
	  
	}	
	
	mysqli_close($connection);
?>