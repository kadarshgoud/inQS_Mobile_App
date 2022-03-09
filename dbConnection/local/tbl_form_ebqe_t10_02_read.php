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
	
	$query = "SELECT t10field05, t10field06, t10field07 FROM tbl_form_ebqe_t10 WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo' && id_mstr_ebqe = '$wn' && id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);
	
	
	$numrows=mysqli_num_rows($sqlStmt); 

if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $freih05 =$row['t10field05'];  
	   $freih06 = $row['t10field06'];
	   $freih07 =$row['t10field07'];  
	   
	   
	  
       
		}
	  echo   $freih05.':' .$freih06.':' .$freih07.':';
		
	
	}
	
	
	
	
	
	mysqli_close($connection);
?>