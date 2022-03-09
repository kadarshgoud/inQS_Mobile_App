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
	
	$query = "SELECT t04field06, t04field07, t04field08, t04field09, t04field10 FROM tbl_form_ebqe_t04 WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo'&& id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);
	
	
	$numrows=mysqli_num_rows($sqlStmt); 

if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $selbst06 =$row['t04field06'];  
	  $selbst07 = $row['t04field07'];
	  $selbst08 =$row['t04field08'];  
	  $selbst09 = $row['t04field09'];
	  $selbst10 =$row['t04field10'];  
	  
       
		}
	  echo $selbst06.':' .$selbst07.':' .$selbst08.':' .$selbst09.':' .$selbst10.':';
		
	
	}
	
	
	
	
	
	mysqli_close($connection);
?>