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
	
	$query = "SELECT t01field01, t01field02, t01field03, t01field04, t01field05, t01field06 FROM tbl_form_ebqe_t01 WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo'&& id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);
	
	
	$numrows=mysqli_num_rows($sqlStmt); 

if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $mob01 =$row['t01field01']; $mob02 = $row['t01field02']; $mob03 =$row['t01field03']; $mob04 = $row['t01field04']; $mob05 =$row['t01field05'];  $mob06 = $row['t01field06'];
       
		}
	  echo $mob01.':' .$mob02.':' .$mob03.':' .$mob04.':' .$mob05.':' .$mob06.':';
		
	
	}
		mysqli_close($connection);
?>