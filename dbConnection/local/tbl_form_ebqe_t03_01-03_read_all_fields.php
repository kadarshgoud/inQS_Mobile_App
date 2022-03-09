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
	
	$query = "SELECT t03field01, t03field02, t03field03, t03field04, t03field05, t03field06, t03field07, t03field08, t03field09, t03field10, t03field11, t03field12, t03field13 FROM tbl_form_ebqe_t03 WHERE id_orga_Einrichtung = '$en'
&& id_orga_Wohnbereich = '$wo'&& id_mstr_ebqe = '$wn'&& id_pers_Bewohner= '$bid'";

$sqlStmt = mysqli_query($connection, $query);
	
	
	$numrows=mysqli_num_rows($sqlStmt); 

if($numrows > 0)  
    {  
        for($i = 0; $i< $numrows ; $i++)
		{
      $row=mysqli_fetch_assoc($sqlStmt);  
       
	
      $verhalt01 =$row['t03field01'];  
	  $verhalt02 = $row['t03field02'];
	  $verhalt03 =$row['t03field03'];  
	  $verhalt04 = $row['t03field04'];
	  $verhalt05 =$row['t03field05'];  
	  $verhalt06=$row['t03field06'];  
	  $verhalt07 = $row['t03field07'];
	  $verhalt08 =$row['t03field08'];  
	  $verhalt09 = $row['t03field09'];
	  $verhalt10 =$row['t03field10'];
	  $verhalt11 =$row['t03field11'];  $verhalt12 = $row['t03field12']; $verhalt13 =$row['t03field13'];  
		}
	  echo $verhalt01.':' .$verhalt02.':' .$verhalt03.':' .$verhalt04.':' .$verhalt05.':' .$verhalt06.':' .$verhalt07.':' .$verhalt08.':' .$verhalt09.':' .$verhalt10.':' .$verhalt11.':' .$verhalt12.':' .$verhalt13.':';
		
	}
	mysqli_close($connection);
?>