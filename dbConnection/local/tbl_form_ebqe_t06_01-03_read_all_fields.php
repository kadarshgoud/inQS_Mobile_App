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
	
	$query = "SELECT t06field01, t06field02, t06field03, t06field04, t06field05, t06field06 FROM tbl_form_ebqe_t06 WHERE id_orga_Einrichtung = '$en' && id_orga_Wohnbereich = '$wo'&& id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);
	
	
	$numrows=mysqli_num_rows($sqlStmt); 

if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $gest01 =$row['t06field01'];  
	  $gest02 = $row['t06field02'];
	   $gest03 =$row['t06field03'];  
	  $gest04 = $row['t06field04'];
	  $gest05 =$row['t06field05'];  
	  $gest06 = $row['t06field06'];
       
		}
	  echo $gest01.':' .$gest02.':' .$gest03.':' .$gest04.':' .$gest05.':' .$gest06.':';
		
	
	}
	
	mysqli_close($connection);
?>