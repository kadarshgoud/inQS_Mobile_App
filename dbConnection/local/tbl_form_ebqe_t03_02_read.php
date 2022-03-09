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
	
	$query = "SELECT t03field06, t03field07, t03field08, t03field09, t03field10 FROM tbl_form_ebqe_t03 WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo'&& id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);
	
	
	$numrows=mysqli_num_rows($sqlStmt); 

if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
     $verhalt06=$row['t03field06'];  
	  $verhalt07 = $row['t03field07'];
	  $verhalt08 =$row['t03field08'];  
	  $verhalt09 = $row['t03field09'];
	  $verhalt10 =$row['t03field10'];  
		}
	  echo $verhalt06.':' .$verhalt07.':' .$verhalt08.':' .$verhalt09.':' .$verhalt10.':';
	}
	
	
	
	
	
	mysqli_close($connection);
?>