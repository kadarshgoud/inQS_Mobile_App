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
	
	$query = "SELECT t12field00, t12field01_01, t12field01_02, t12field01_03, t12field02_01, t12field02_02 FROM tbl_form_ebqe_t12 WHERE id_orga_Einrichtung = '$en' && id_orga_Wohnbereich = '$wo' && id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);
	
	
	$numrows=mysqli_num_rows($sqlStmt); 

if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $heim00 =$row['t12field00'];  
	  $heim01_01 = $row['t12field01_01'];
	  $heim01_02 =$row['t12field01_02'];  
	  $heim01_03 = $row['t12field01_03'];
	  $heim02_01 =$row['t12field02_01'];
		$heim02_02 =$row['t12field02_02'];	  
	  
       
		}
		
	  echo $heim00.':' .$heim01_01.':' .$heim01_02.':' .$heim01_03.':' .$heim02_01.':' .$heim02_02.':';
		
	
	}
	
	
	
	
	
	mysqli_close($connection);
?>