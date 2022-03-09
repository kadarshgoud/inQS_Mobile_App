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
	
	$query = "SELECT t08field01, t08field02_01, t08field02_02, t08field03_01, t08field03_02, t08field03_03, t08field03_04, t08field03_05, t08field03_06, t08field04 
	FROM tbl_form_ebqe_t08 WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo'&& id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);
	
	
	$numrows=mysqli_num_rows($sqlStmt); 

if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $korp01 =$row['t08field01'];  
	  $korp02_01 = $row['t08field02_01'];
	  $korp02_02 =$row['t08field02_02'];  
	  $korp03_01 = $row['t08field03_01'];
	  $korp03_02 =$row['t08field03_02'];  
	  $korp03_03 = $row['t08field03_03'];
	  $korp03_04 = $row['t08field03_04'];
	  $korp03_05 = $row['t08field03_05'];
	  $korp03_06 = $row['t08field03_06'];
	  $korp04 = $row['t08field04'];
       
		}
	  echo $korp01.':' .$korp02_01.':' .$korp02_02.':' .$korp03_01.':' .$korp03_02.':' .$korp03_03.':' .$korp03_04.':' .$korp03_05.':' .$korp03_06.':' .$korp04.':';
		
	
	}
	
	
	
	
	
	mysqli_close($connection);
?>