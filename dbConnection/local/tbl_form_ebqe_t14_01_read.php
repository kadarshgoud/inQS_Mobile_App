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
	
	$query = "SELECT t14field01, t14field02, t14field03 FROM tbl_form_ebqe_t14 WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo'&& id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);
	
	
	$numrows=mysqli_num_rows($sqlStmt); 

if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $medik01 =$row['t14field01'];
		$medik02 =$row['t14field02'];
	$medik03 =$row['t14field03'];	  
	
		}
	  echo $medik01.':' .$medik02.':' .$medik03.':';
		
	
	}
	
	
	
	
	
	mysqli_close($connection);
?>